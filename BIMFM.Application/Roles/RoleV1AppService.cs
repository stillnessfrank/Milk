using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using BIMFM.Authorization;
using BIMFM.Authorization.Roles;
using BIMFM.Users;
using BIMFM.Roles.Dto;
using Microsoft.AspNet.Identity;

using Abp.AutoMapper;

namespace BIMFM.Roles
{
    //[AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleV1AppService :
        AsyncCrudAppService<Role, RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>, IRoleV1AppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRepository<Role> _roleRepository;

        public RoleV1AppService(
            IRepository<Role> repository,
            RoleManager roleManager,
            UserManager userManager,
            IRepository<User, long> userRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public override async Task<RoleDto> Create(CreateRoleDto input)
        {
            CheckCreatePermission();

            var role = input.MapTo<Role>();

            CheckErrors(await _roleManager.CreateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.Permissions.Where(x => x.Name == p.Name).Count() > 0)
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        

        public async Task UpdateRolePermissions(RoleDto input)
        {

            //CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.PermissionsStr.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            role.Name = input.Name;
            role.DisplayName = input.DisplayName;

            CheckErrors(await _roleManager.UpdateAsync(role));

        }


        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();

            var role = await _roleManager.FindByIdAsync(input.Id);
            if (role.IsStatic)
            {
                throw new UserFriendlyException("CannotDeleteAStaticRole");
            }


            var users = await GetUsersInRoleAsync(role.Name);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.Name));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        private Task<List<long>> GetUsersInRoleAsync(string roleName)
        {
            var users = (from user in _userRepository.GetAll()
                         join userRole in _userRoleRepository.GetAll() on user.Id equals userRole.UserId
                         join role in _roleRepository.GetAll() on userRole.RoleId equals role.Id
                         where role.Name == roleName
                         select user.Id).Distinct().ToList();

            return Task.FromResult(users);
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions)
            ));
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Permissions);
        }

        protected override Task<Role> GetEntityByIdAsync(int id)
        {
            var role = Repository.GetAllIncluding(x => x.Permissions).FirstOrDefault(x => x.Id == id);
            return Task.FromResult(role);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        public async Task<ListResultDto<RoleDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();

            var users = await _userRepository.GetAllListAsync();

            var dtos = ObjectMapper.Map<List<RoleDto>>(roles);

            foreach (var roleDto in dtos)
            {
                var role = roles.FirstOrDefault(a => a.Id == roleDto.Id);
                if (role != null)
                {
                    roleDto.LastModifierUserName = role.LastModificationTime == null ? role.CreatorUser.Name : role.LastModifierUser.Name;
                }
            }

            return new ListResultDto<RoleDto>(dtos);
        }

    }
}
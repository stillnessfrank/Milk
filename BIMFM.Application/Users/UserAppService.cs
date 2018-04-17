using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using BIMFM.Authorization;
using BIMFM.Authorization.Roles;
using BIMFM.Roles.Dto;
using BIMFM.Users.Dto;
using Microsoft.AspNet.Identity;

namespace BIMFM.Users
{
    /* THIS IS JUST A SAMPLE. */
    //[AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : BIMFMAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly UserManager _userManager;

        public UserAppService(IRepository<User, long> userRepository,
            IPermissionManager permissionManager, 
            IRepository<Role> roleRepository,
            UserManager userManager
            )
        {
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
            _userManager = userManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await UserManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<ListResultDto<UserListDto>> GetUsers()
        {
            var users = await _userRepository.GetAllListAsync();
            var roles = await _roleRepository.GetAllListAsync();

            List<UserListDto> list = new List<UserListDto>();

            foreach (var user in users)
            {
                UserListDto dto = user.MapTo<UserListDto>();
                if (user.Roles != null && user.Roles.Count>0)
                {
                    dto.RoleId = user.Roles.First().RoleId;
                    var role = roles.FirstOrDefault(a => a.Id == dto.RoleId);
                    if (role != null)
                    {
                        dto.RoleName = role.DisplayName;
                    }
                }
                list.Add(dto);
            }

            return new ListResultDto<UserListDto>(
                list
                );
        }

        public async Task<UserListDto> GetUserById(int id)
        {
            var user = await _userRepository.GetAsync(id);
            var dto = user.MapTo<UserListDto>();
            if (user.Roles != null && user.Roles.Count > 0)
            {
                dto.RoleId = user.Roles.First().RoleId;
            }
            else
            {
                dto.RoleId = 0;
            }
            return dto;
        }

        public async Task CreateUser(CreateUserInput input)
        {
            var user = input.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;
            user.IsActive = true;

            user.Roles = new Collection<UserRole>();
            user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, input.RoleId));
            await _userRepository.InsertAndGetIdAsync(user);
        }

        public async Task UpdateUser(UpdateUserDto input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            input.Password = new PasswordHasher().HashPassword(input.Password);

            ObjectMapper.Map(input, user);
            
            user.IsEmailConfirmed = true;
            user.IsActive = true;
            user.EmailAddress = Guid.NewGuid().ToString() + "@abc.com";

            CheckErrors(await _userManager.UpdateAsync(user));

            var role = await _roleRepository.GetAsync(input.RoleId);
            if (role != null)
            {
                string[] roleNames = new[] {role.Name};
                CheckErrors(await _userManager.SetRoles(user, roleNames));
            }
        }

        public async Task DeleteUser(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }
    }
}
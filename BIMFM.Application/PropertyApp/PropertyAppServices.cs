using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using BIMFM.Entities;
using BIMFM.PropertyApp.Dto;

namespace BIMFM.PropertyApp
{
    public class PropertyAppServices : ApplicationService, IPropertyAppServices
    {
        private readonly IRepository<Property> _propertyRepository;
        private readonly IRepository<PropertyInfo> _propertyInfoRepository;
        private readonly IRepository<ContractInfo> _contractInfoRepository;
        private readonly IRepository<Room> _roomRepository;

        public PropertyAppServices(
            IRepository<Property> propertyRepository,
            IRepository<PropertyInfo> propertyInfoRepository,
            IRepository<ContractInfo> contractInfoRepository,
            IRepository<Room> roomRepository
            )
        {
            _propertyRepository = propertyRepository;
            _propertyInfoRepository = propertyInfoRepository;
            _contractInfoRepository = contractInfoRepository;
            _roomRepository = roomRepository;
        }

        public async Task<int> CreateProperty(PropertyDto input)
        {
            
            var property = input.MapTo<Property>();
            property.Uid = Guid.NewGuid().ToString();
            var propertyId = await _propertyRepository.InsertAndGetIdAsync(property);
            if (property.PropertyRightCode == "3")
            {
                var contractInfo = input.ContractInfo.MapTo<ContractInfo>();
                contractInfo.Uid = Guid.NewGuid().ToString();
                contractInfo.PropertyId = propertyId;
                await _contractInfoRepository.InsertAsync(contractInfo);
            }
            else
            {
                var propertyInfo = input.PropertyInfo.MapTo<PropertyInfo>();
                propertyInfo.Uid = Guid.NewGuid().ToString();
                propertyInfo.PropertyId = propertyId;
                await _propertyInfoRepository.InsertAsync(propertyInfo);
            }
            return propertyId;
        }
        public async Task UpdateProperty(PropertyDto input)
        {
            var newProperty = input.MapTo<Property>();
            var oldProperty = await _propertyRepository.GetAsync(input.Id);
            oldProperty.Copy(newProperty);
            if (newProperty.PropertyRightCode != oldProperty.PropertyRightCode)
            {
                if (newProperty.PropertyRightCode == "3")
                {
                    var propertyInfoes = await _propertyInfoRepository.GetAllListAsync(a => a.PropertyId == input.Id);
                    foreach (var pinfo in propertyInfoes)
                    {
                        await _propertyInfoRepository.DeleteAsync(pinfo);
                    }
                    var newContractInfo = input.ContractInfo.MapTo<ContractInfo>();
                    newContractInfo.PropertyId = input.Id;
                    newContractInfo.Uid = Guid.NewGuid().ToString();
                    await _contractInfoRepository.InsertAsync(newContractInfo);
                }
                else
                {
                    var contractInfoes = await _contractInfoRepository.GetAllListAsync(a => a.PropertyId == input.Id);
                    foreach (var cinfo in contractInfoes)
                    {
                        await _contractInfoRepository.DeleteAsync(cinfo);
                    }
                    var newPropertyInfo = input.PropertyInfo.MapTo<PropertyInfo>();
                    newPropertyInfo.PropertyId = input.Id;
                    newPropertyInfo.Uid = Guid.NewGuid().ToString();
                    await _propertyInfoRepository.InsertAsync(newPropertyInfo);
                }
            }
            else
            {
                if (newProperty.PropertyRightCode == "3")
                {
                    var newContractInfo = input.ContractInfo.MapTo<ContractInfo>();
                    var oldContractInfo =
                        await _contractInfoRepository.FirstOrDefaultAsync(a => a.PropertyId == oldProperty.Id);
                    if (oldContractInfo != null)
                    {
                        oldContractInfo.Copy(newContractInfo);
                        await _contractInfoRepository.UpdateAsync(oldContractInfo);
                    }
                    
                }
                else
                {
                    var newPropertyInfo = input.PropertyInfo.MapTo<PropertyInfo>();
                    var oldPropertyInfo =
                        await _propertyInfoRepository.FirstOrDefaultAsync(a => a.PropertyId == oldProperty.Id);
                    if (oldPropertyInfo != null)
                    {
                        oldPropertyInfo.Copy(newPropertyInfo);
                        await _propertyInfoRepository.UpdateAsync(oldPropertyInfo);
                    }
                    
                }
            }
            await _propertyRepository.UpdateAsync(oldProperty);
        }
        public async Task DeleteProperty(PropertyDto input)
        {
            var propertyInfoes = await _propertyInfoRepository.GetAllListAsync(a => a.PropertyId == input.Id);
            foreach (var pinfo in propertyInfoes)
            {
                await _propertyInfoRepository.DeleteAsync(pinfo);
            }

            var contractInfoes = await _contractInfoRepository.GetAllListAsync(a => a.PropertyId == input.Id);
            foreach (var cinfo in contractInfoes)
            {
                await _contractInfoRepository.DeleteAsync(cinfo);
            }

            var rooms = await _roomRepository.GetAllListAsync(a => a.PropertyId == input.Id);
            foreach (var room in rooms)
            {
                await _roomRepository.DeleteAsync(room);
            }

            await _propertyRepository.DeleteAsync(input.Id);
        }

        public async Task<List<PropertyDto>> GetAllProperty()
        {
            List<PropertyDto> all = new List<PropertyDto>();

            List<Property> props = await _propertyRepository.GetAllListAsync();
            List<ContractInfo> cinfoes = await _contractInfoRepository.GetAllListAsync();
            List<PropertyInfo> pinfoes = await _propertyInfoRepository.GetAllListAsync();

            foreach (var prop in props)
            {
                var propDto = prop.MapTo<PropertyDto>();
                if (propDto.PropertyRightCode == "3")
                {
                    var cinfo = cinfoes.FirstOrDefault(a => a.PropertyId == prop.Id);
                    if (cinfo != null)
                    {
                        propDto.ContractInfo = cinfo.MapTo<ContractInfoDto>();
                    }
                }
                else
                {
                    var pinfo = pinfoes.FirstOrDefault(a => a.PropertyId == prop.Id);
                    if (pinfo != null)
                    {
                        propDto.PropertyInfo = pinfo.MapTo<PropertyInfoDto>();
                    }
                }
                all.Add(propDto);
            }

            return all.OrderBy(a => a.PropertyCode).ToList();
        }

        public async Task<PropertyDto> GetPropertyById(PropertyDto input)
        {
            PropertyDto propDto = null;
            var prop = await _propertyRepository.GetAsync(input.Id);
            if (prop != null)
            {
                propDto = prop.MapTo<PropertyDto>();
                if (propDto.PropertyRightCode == "3")
                {
                    var cinfo = _contractInfoRepository.FirstOrDefault(a => a.PropertyId == propDto.Id);
                    if (cinfo != null)
                    {
                        propDto.ContractInfo = cinfo.MapTo<ContractInfoDto>();
                    }
                }
                else
                {
                    var pinfo = _propertyInfoRepository.FirstOrDefault(a => a.PropertyId == propDto.Id);
                    if (pinfo != null)
                    {
                        propDto.PropertyInfo = pinfo.MapTo<PropertyInfoDto>();
                    }
                }
            }

            return propDto;
        }
        public PropertyInfoDto GetPropertyInfoByPropId(PropertyDto input)
        {
            PropertyInfoDto pinfoDto = null;
            var pinfo = _propertyInfoRepository.FirstOrDefault(a => a.PropertyId == input.Id);
            if (pinfo != null)
            {
                pinfoDto = pinfo.MapTo<PropertyInfoDto>();
            }
            return pinfoDto;
        }
        public ContractInfoDto GetContractInfoByPropId(PropertyDto input)
        {
            ContractInfoDto cinfoDto = null;
            var cinfo = _contractInfoRepository.FirstOrDefault(a => a.PropertyId == input.Id);
            if (cinfo != null)
            {
                cinfoDto = cinfo.MapTo<ContractInfoDto>();
            }
            return cinfoDto;
        }

        public async Task CreateRoom(RoomDto input)
        {
            Room room = input.MapTo<Room>();
            room.Uid = Guid.NewGuid().ToString();
            await _roomRepository.InsertAsync(room);
        }
        public async Task UpdateRoom(RoomDto input)
        {
            Room room = input.MapTo<Room>();
            var oldRoom = await _roomRepository.GetAsync(input.Id);
            if (oldRoom != null)
            {
                oldRoom.Copy(room);
                await _roomRepository.UpdateAsync(oldRoom);
            }
        }
        public async Task DeleteRoom(RoomDto input)
        {
            await _roomRepository.DeleteAsync(input.Id);
        }

        public async Task<RoomDto> GetRoomById(RoomDto input)
        {
            RoomDto roomDto = null;
            var room = await _roomRepository.GetAsync(input.Id);
            if (room != null)
            {
                roomDto = room.MapTo<RoomDto>();
            }
            return roomDto;
        }

        public async Task<List<RoomDto>> GetRoomsByPropId(PropertyDto input)
        {
            List<RoomDto> all = new List<RoomDto>();

            var rooms = await _roomRepository.GetAllListAsync(a => a.PropertyId == input.Id);
            foreach (var room in rooms)
            {
                var roomDto = room.MapTo<RoomDto>();
                all.Add(roomDto);
            }

            return all;
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            List<RoomDto> all = new List<RoomDto>();

            var properties = await _propertyRepository.GetAllListAsync();
            var propInfoes = await _propertyInfoRepository.GetAllListAsync();
            var rooms = await _roomRepository.GetAllListAsync();

            foreach (var room in rooms)
            {
                var roomDto = room.MapTo<RoomDto>();
                var property = properties.FirstOrDefault(a => a.Id == roomDto.PropertyId);
                if (property != null)
                {
                    roomDto.PropertyCode = property.PropertyCode;
                }
                var propInfo = propInfoes.FirstOrDefault(a => a.PropertyId == roomDto.PropertyId);
                if (propInfo != null)
                {
                    roomDto.CertificateAddress = propInfo.CertificateAddress;
                }
                all.Add(roomDto);
            }

            return all.OrderBy(a => a.PropertyCode).ThenBy(a => a.RoomCode).ToList();
        }

        public async Task<PropertyStatistics> GetPropertyStatistics()
        {
            var props = await _propertyRepository.GetAllListAsync();
            var hasCert = props.Where(a => a.PropertyRightCode == "1");
            var noCert = props.Where(a => a.PropertyRightCode == "2");
            var useRight = props.Where(a => a.PropertyRightCode == "3");
            var rooms = await _roomRepository.GetAllListAsync();

            var area = 0;

            return new PropertyStatistics()
            {
                PropertyAmount = props.Count,
                PropertyHasCertAmount = hasCert.Count(),
                PropertyNoCertAmount = noCert.Count(),
                PropertyUseRightAmount = useRight.Count(),
                RoomAmount = rooms.Count,
                TotalArea = area
            };

        }
    }
}

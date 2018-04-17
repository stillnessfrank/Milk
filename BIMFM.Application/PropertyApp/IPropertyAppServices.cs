using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using BIMFM.PropertyApp.Dto;

namespace BIMFM.PropertyApp
{
    public interface IPropertyAppServices : IApplicationService
    {
        Task<int> CreateProperty(PropertyDto input);
        Task UpdateProperty(PropertyDto input);
        Task DeleteProperty(PropertyDto input);
        Task<List<PropertyDto>> GetAllProperty();
        Task<PropertyDto> GetPropertyById(PropertyDto input);
        PropertyInfoDto GetPropertyInfoByPropId(PropertyDto input);
        ContractInfoDto GetContractInfoByPropId(PropertyDto input);
        Task CreateRoom(RoomDto input);
        Task UpdateRoom(RoomDto input);
        Task DeleteRoom(RoomDto input);
        Task<RoomDto> GetRoomById(RoomDto input);
        Task<List<RoomDto>> GetRoomsByPropId(PropertyDto input);
        Task<List<RoomDto>> GetAllRooms();
        Task<PropertyStatistics> GetPropertyStatistics();
    }
}

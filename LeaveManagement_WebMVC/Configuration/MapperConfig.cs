using AutoMapper;
using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models.LeaveType;

namespace LeaveManagement_WebMVC.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMappingForLeaveType();
        }

        private void CreateMappingForLeaveType()
        {
            CreateMap<LeaveType, LeaveTypeModel>();
            CreateMap<CreateLeaveTypeModel, LeaveType>();
            CreateMap<UpdateLeaveTypeModel, LeaveType>();
        }
    }
}

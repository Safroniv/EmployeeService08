using EmployeeService.Data;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using EmployeeService07Proto;
using Grpc.Core;
using static EmployeeService07Proto.DictionariesService;

namespace EmployeeService07.Services.Impl
{
    public class DictionariesService : DictionariesServiceBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public DictionariesService(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        public override Task<CreateEmployeeTypeResponce> CreateEmployeeType(CreateEmployeeTypeRequest request, ServerCallContext context)
        {
            var id = _employeeTypeRepository.Create(new EmployeeType { 
                Description = request.Description,
            });
            CreateEmployeeTypeResponce responce = new CreateEmployeeTypeResponce();
            responce.Id = id;
            return Task.FromResult(responce);
        }

        public override Task<DeleteEmployeeTypeResponce> DeleteEmployeeType(DeleteEmployeeTypeRequest request, ServerCallContext context)
        {
            _employeeTypeRepository.Delete(request.Id);
            return Task.FromResult(new DeleteEmployeeTypeResponce());
        }

        public override Task<GetAllEmployeeTypesResponce> GetAllEmployeeTypes (GetAllEmployeeTypesRequest request, ServerCallContext context)
        {
            GetAllEmployeeTypesResponce responce = new GetAllEmployeeTypesResponce();
            responce.EmployeeTypes.AddRange(
                            _employeeTypeRepository.GetAll().Select(et =>
                   new EmployeeService07Proto.EmpolyeeType
                   {
                       Id = et.Id,
                       Description = et.Description
                   }
                   ).ToList());
            return Task.FromResult(responce);
        }

    }
}

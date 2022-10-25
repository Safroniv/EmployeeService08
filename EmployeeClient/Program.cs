using Grpc.Net.Client;
using static EmployeeService07Proto.DictionariesService;

namespace EmployeeClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            DictionariesServiceClient client = new DictionariesServiceClient(channel);
            Console.WriteLine("Укажите тип сотрудника:");
            var responce = client.CreateEmployeeType(new EmployeeService07Proto.CreateEmployeeTypeRequest
            {
                Description = Console.ReadLine()
            });
            if (responce !=null)
            {
                Console.WriteLine($"Тип сотрудника успешно добавлен: #{responce.Id}");
            }
            var getAllEmployeeTypesResponce = client.GetAllEmployeeTypes(new EmployeeService07Proto.GetAllEmployeeTypesRequest());
            foreach (var employeeType in getAllEmployeeTypesResponce.EmployeeTypes)
            {
                Console.WriteLine($"{employeeType.Id}/{employeeType.Description}");
            }
        }
    }
}
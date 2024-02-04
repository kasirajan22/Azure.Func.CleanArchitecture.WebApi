using InfrastructureLayer;
using PresentationLayer;

namespace ApplicationLayer;

public class EmployeeService : ApplicationBase, IEmployeeService
{
    public EmployeeService(IRepositoryWrapper repository) : base(repository)
    {
    }

    public Response GetAll(Header header)
    {
        var emp = new List<EmployeeDto>
        {
            new EmployeeDto { Id = 107, Name = "Alice", Designation = "AI Engineer", DOJ = new DateOnly(2024, 01, 01), IsActive = true },
            new EmployeeDto { Id = 103, Name = "Bob", Designation = "Senior DevOps Engineer", DOJ = new DateOnly(1985, 1, 5), IsActive = true },
            new EmployeeDto { Id = 106, Name = "John", Designation = "Data Engineer", DOJ = new DateOnly(1995, 4, 17), IsActive = true },
            new EmployeeDto { Id = 104, Name = "Pop", Designation = "Associate Architect", DOJ = new DateOnly(1985, 6, 8), IsActive = false },
            new EmployeeDto { Id = 105, Name = "Ronald", Designation = "Senior Data Engineer", DOJ = new DateOnly(1991, 8, 23), IsActive = true },
            new EmployeeDto { Id = 102, Name = "Line", Designation = "Architect", DOJ = new DateOnly(1977, 1, 12), IsActive = true },
            new EmployeeDto { Id = 101, Name = "Daniel", Designation = "Architect", DOJ = new DateOnly(1977, 1, 12), IsActive = true },
            new EmployeeDto { Id = 113, Name = "Merlin", Designation = "Senior Consultant", DOJ = new DateOnly(1989, 10, 2), IsActive = true },
            new EmployeeDto { Id = 117, Name = "Sharna", Designation = "Data Analyst", DOJ = new DateOnly(1994, 5, 12), IsActive = true },
            new EmployeeDto { Id = 108, Name = "Zayne", Designation = "Data Analyst", DOJ = new DateOnly(1991, 1, 1), IsActive = true },
            new EmployeeDto { Id = 109, Name = "Isha", Designation = "App Maker", DOJ = new DateOnly(1996, 7, 1), IsActive = true },
            new EmployeeDto { Id = 111, Name = "Glenda", Designation = "Data Engineer", DOJ = new DateOnly(1994, 1, 12), IsActive = true },
        };
        return Response.Success(emp);
    }
}

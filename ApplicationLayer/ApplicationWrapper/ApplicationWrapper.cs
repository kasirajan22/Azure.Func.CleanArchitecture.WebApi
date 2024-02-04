using InfrastructureLayer;

namespace ApplicationLayer;

public sealed class ApplicationWrapper : IApplicationWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IEmployeeService> _employeeService;

    public ApplicationWrapper(IRepositoryWrapper repository)
    {
        _repository = repository;
        _userService = new(() => new UserService(_repository));
        _employeeService = new(() => new EmployeeService(_repository));
    }
    public IUserService userService => _userService.Value;
    public IEmployeeService employeeService => _employeeService.Value;
}

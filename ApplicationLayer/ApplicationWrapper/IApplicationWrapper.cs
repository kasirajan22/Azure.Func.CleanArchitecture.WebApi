namespace ApplicationLayer;

public interface IApplicationWrapper
{
    IUserService userService {get;}
    IEmployeeService employeeService {get;}
}

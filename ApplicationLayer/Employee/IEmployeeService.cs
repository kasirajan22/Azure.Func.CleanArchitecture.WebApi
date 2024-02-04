using PresentationLayer;

namespace ApplicationLayer;

public interface IEmployeeService
{
    Response GetAll(Header header);
}

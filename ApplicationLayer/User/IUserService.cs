using PresentationLayer;

namespace ApplicationLayer;

public interface IUserService
{
    Task<Response> SignUpAsync(SignUpRequestDto requestDto, Header header);
    Task<Response> SignInAsync(SignInDto requestDto, Header header);
}

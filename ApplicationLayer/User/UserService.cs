using DomainLayer;
using InfrastructureLayer;
using PresentationLayer;

namespace ApplicationLayer;

public class UserService : ApplicationBase, IUserService
{
    public UserService(IRepositoryWrapper repository) : base(repository)
    {

    }
    public async Task<Response> SignUpAsync(SignUpRequestDto requestDto, Header header)
    {
        var user = await _repository.userRepo.GetAsync(userName: requestDto.UserName);
        if (user is null)
        {
            int lastUserID = await _repository.userRepo.GetLatestUserIdAsync();
            string newUserID = lastUserID == 0 ? "1001" : (lastUserID + 1).ToString();

            var newUser = new User
            {
                NameIdentifier = "EMP" + newUserID.ToString(),
                UserName = requestDto.UserName,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                Password = SecurityManager.HashPassword(requestDto.Password),
            };
            _repository.userRepo.Create(newUser);
            await _repository.SaveAsync();
            return Response.Success("User added sucessfully!");
        }
        else
        {
            return Response.Failure("User already exist.");
        }
    }

    public async Task<Response> SignInAsync(SignInDto requestDto, Header header)
    {
        var user = await _repository.userRepo.GetAsync(userName: requestDto.UserName);
        if (user is not null)
        {
            if (SecurityManager.VerifyPassword(user!.Password, requestDto.Password))
            {
                var now = DateTime.UtcNow;
                await _repository.userSessionRepo.CloseExistingSessionsAsync(user.Id, now);
                var userSessionId = Guid.NewGuid();
                user.Token = JwtManager.Generate(user, userSessionId);
                var userSession = new UserSession
                {
                    Id = userSessionId,
                    UserId = user.Id,
                    StartsOn = now,
                    EndsOn = now.AddMinutes(480),
                    LoginType = "Web",
                    IpAddress = header.IpAddress,
                    SessionToken = user.Token
                };
                user.LastLogin = DateTime.UtcNow;
                _repository.userSessionRepo.Create(userSession);
                _repository.userRepo.Update(user);
                await _repository.SaveAsync();

                var resp = new UserDto {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    NameIdentifier = user.NameIdentifier,
                    ForcePasswordChange = user.ForcePasswordChange,
                    Token = user.Token
                };
                return Response.Success(resp);
            }

        }
            return Response.Failure("Unable to login.");

    }
}

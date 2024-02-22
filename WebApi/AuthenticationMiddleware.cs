// using Microsoft.Azure.Functions.Worker;
// using Microsoft.Azure.Functions.Worker.Middleware;
// using Microsoft.Azure.Functions.Worker.Http;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using System.Net;
// using Microsoft.AspNetCore.Authentication.JwtBearer;

// namespace WebApi;

// public class AuthenticationMiddleware : IFunctionsWorkerMiddleware
// {
//     private readonly JwtSecurityTokenHandler _tokenValidator;
//     private readonly TokenValidationParameters _tokenValidationParameters;

//     public AuthenticationMiddleware()
//     {
//         _tokenValidator = new JwtSecurityTokenHandler();
//         _tokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidateLifetime = true,
//             ValidateIssuerSigningKey = true,
//             ValidIssuer = Environment.GetEnvironmentVariable("JWTIssuer"),
//             ValidAudience = Environment.GetEnvironmentVariable("JWTAudience"),
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWTSecretKey")))
//         };
//     }

//     public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
//     {
//         // var request = context.GetHttpRequestData();
//         // var authorizationHeader = GetAccessToken(request);
//         // //  var authorizationHeader = request.Headers.GetValues("Authorization");
//         // // if (request.Headers.GetValues("Authorization") is IEnumerable<string> authorizationHeader && authorizationHeader.Any())
//         // // {
//         //     if (string.IsNullOrEmpty(authorizationHeader))
//         //     {
//         //         request.CreateResponse(HttpStatusCode.Unauthorized);
//         //         return;
//         //     }

//         //     var token = authorizationHeader.ToString().Replace("Bearer ", "");

//         //     try
//         //     {
//         //         _tokenValidator.ValidateToken(token, _tokenValidationParameters, out _);
//         //     }
//         //     catch
//         //     {
//         //         request.CreateResponse(HttpStatusCode.Unauthorized);
//         //         return;
//         //     }
//         // //}
//         await next(context);
//     }
//     private static string GetAccessToken(HttpRequestData req)
// {
//     // var authorizationHeader = req.Headers?["Authorization"];
//     // var parts = authorizationHeader?.ToString().Split(null) ?? new string[0];
//     // if (parts.Length == 2 && parts[0].Equals("Bearer"))
//     //     return parts[1];
//     return null;
// }
// }
// public static class FunctionContextExtensions
// {
//     public static HttpRequestData GetHttpRequestData(this FunctionContext functionContext)
//     {
//         var features = functionContext.Features;
//         var request = features.Get<HttpRequestData>();

//         return request;
//     }
// }

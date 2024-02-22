namespace Azure.Func.CleanArchitecture.WebApi;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeAttribute : Attribute
{
    public string[] Scopes { get; set; }
    public string[] UserRoles { get; set; }
}

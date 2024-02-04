namespace PresentationLayer;

public sealed class Header
{
    public Header() { }
    public Header(string ipAddress, string token) => (IpAddress, Token) = (ipAddress, token);
    public Guid UserId { get; set; }
    public Guid SessionId { get; set; }
    public string UserName { get; set; }
    public string IpAddress { get; set; }
    public string Token { get; set; }
    public string Name { get; set; }
    public string Roles { get; set; }
    public string ActualHeader { get; set; }

}

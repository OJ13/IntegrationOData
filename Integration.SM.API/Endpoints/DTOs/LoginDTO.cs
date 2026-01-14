namespace Integration.SM.API.Endpoints.DTOs
{
    public record LoginDTO(string Username, string Password);

    public record AutenticadoDTO(string Username, string Password, string[] Role);    
}

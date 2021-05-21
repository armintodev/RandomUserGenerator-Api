namespace UserGenerator.Api.DTOs
{
    public record CreateUserResult(int Id, string UserName, string Email, string Password);
}

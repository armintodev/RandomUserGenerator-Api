namespace UserGenerator.Api.DTOs
{
    public record CreateUserCommand
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Request { get; init; }
    };
}

namespace UserGenerator.Api.DTOs
{
    public record CreateUserCommand
    {
        public int Request { get; set; }
        public int Skip { get; set; }
    };
}

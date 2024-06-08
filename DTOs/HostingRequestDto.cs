namespace innomiate_api.DTOs
{
    public class HostingRequestDto
    {
        public int HostingRequestId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Request { get; set; }
        public int UserId { get; set; }
    }
}

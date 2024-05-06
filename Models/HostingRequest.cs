using INNOMIATE_API.Models;

namespace innomiate_api.Models
{
    public class HostingRequest
    {
        public int HostingRequestId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Request { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
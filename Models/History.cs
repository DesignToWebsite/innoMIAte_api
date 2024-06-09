using INNOMIATE_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace innomiate_api.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Operation {  get; set; }
        public string? OperationDate { get; set; }

    }
}

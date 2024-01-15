using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItemBlazor.Models
{
    public class Items
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

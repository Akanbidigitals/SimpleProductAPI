using System.ComponentModel.DataAnnotations;

namespace SimpleProductAPI.Model.Domain
{
    public class Product
    {
        [Key]
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Price { get; set; }   
    }
}

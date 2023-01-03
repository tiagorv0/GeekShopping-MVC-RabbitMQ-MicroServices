using System.ComponentModel.DataAnnotations;

namespace GeekShopping.OrderAPI.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

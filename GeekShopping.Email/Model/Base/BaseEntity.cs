using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Email.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

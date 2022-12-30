using System.ComponentModel.DataAnnotations;

namespace GeekShopping.CouponAPI.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

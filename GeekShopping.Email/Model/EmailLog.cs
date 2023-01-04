using GeekShopping.Email.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Email.Model
{
    [Table("email_logs")]
    public class EmailLog : BaseEntity
    {
        public string Email { get; set; }
        public string Log { get; set; }
        public DateTime SendDate { get; set; }
    }
}

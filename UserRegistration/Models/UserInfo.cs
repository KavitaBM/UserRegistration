using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistration.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string address { get; set; }
    }
}

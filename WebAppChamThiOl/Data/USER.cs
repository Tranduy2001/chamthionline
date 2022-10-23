using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppChamThiOl.Data
{
    [Table("User")]
    public class USER
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Tài khoản")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]

        public string? Password { get; set; }
        [Required]
        [Display(Name = "Họ và tên")]

        public string? FullName { get; set; }
        [Display(Name ="Là tài khoản quản trị")]

        public bool IsAdmin { get; set; }
    }
}

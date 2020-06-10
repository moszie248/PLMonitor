using System.ComponentModel.DataAnnotations;
namespace Pallet.ViewModels
{
    public class LoginViewModel
    {
        // [Display(Name = "Username", Prompt = "Username")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "กรุณากรอก ชื่อผู้ใช้")]
        public string username { get; set; }

        // [Display(Name = "Password", Prompt = "Password")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "กรุณากรอก รหัสผ่าน")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool ischecked {get; set;}
    }
}
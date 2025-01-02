using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Net.Models.Contacts
{
    public class Contact
    {
        [Key]
        public int Id {get; set;}

        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phải nhập họ tên!")]
        [Display(Name ="Họ và tên")]
        public string fullName { get; set;}

        [Required(ErrorMessage ="Phải nhập Emal!")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Phải là địa chỉ Email!")]
        public string Email {get; set; }
        public DateTime DateSent { get; set;}
        public string Message { get; set; }
        
        [StringLength(11)]
        [Phone(ErrorMessage ="Phải là số điện thoại!")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set;}
    }
}
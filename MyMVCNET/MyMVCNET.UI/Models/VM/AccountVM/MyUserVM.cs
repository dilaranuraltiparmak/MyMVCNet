using MyMVCNET.UI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Models.VM.AccountVM
{
    public class MyUserVM
    {
        [Display(Name = "Kullanıcı ID")]
        public int ID { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required]
        [StringLength(24)]
        public string FirstName { get; set; }
        [Display(Name = "Soyadı")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Şifre")]
        [Required]
        public string Password { get; set; }
        //todo yaşı kontrol ettir (attribute)
        [Display(Name = "Şu an ki yaşınız")]
        [AgeControl(18,50)]
        public int Age { get; set; }
        public bool RememberMe { get; set; }

    }
    [MetadataType(typeof(MyUserVM))]
    public partial class MyUser
    {

    }
}
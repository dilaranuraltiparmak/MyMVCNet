using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMVCNET.UI.Validation
{
    public class AgeControl:ValidationAttribute
    {
        int _yasbalangic = 0;
        int _yasbitis=0;
        public AgeControl(int yasbalangic,int yasBitis)
        {
            _yasbalangic = yasbalangic;
            _yasbitis = yasBitis;
        }

        public override bool IsValid(object value)
        {
            int gelenDeger=Convert.ToInt32(value);

            if(gelenDeger < _yasbalangic || gelenDeger> _yasbitis)
            {
                ErrorMessage = "Aralık dışında bir değer girilmeye çalışıldı.";
                return false;
            }
            return true;

        }
    }
}
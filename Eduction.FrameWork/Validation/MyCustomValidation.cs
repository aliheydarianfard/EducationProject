using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduction.FrameWork.Validation
{
    public class MyCustomValidation : ValidationAttribute
    {
        string[] Swearing = { "کیر", "گوه", "آشغال", "کس کش", "کیری" };
        public override bool IsValid(object value)
        {
            for (int i = 1; i < Swearing.Length; i++)
            {
                if (value != null)
                {
                    if (value.ToString().Contains(Swearing[i]))
                    {
                        ErrorMessage += "لطفا از کلمات غیر مجاز استفاده نکنید";
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

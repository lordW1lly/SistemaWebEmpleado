using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebEmpleado.Validations
{
    public class CheckLegajo : ValidationAttribute
    {
        public CheckLegajo()
        {
            ErrorMessage = "El formato debe ser de la forma : AA11111";
        }

        public override bool IsValid(object value)
        {
            string legajo = Convert.ToString(value);

           
            legajo.Replace(" ", "");

            
            if (legajo.Substring(0, 2) == "AA" && int.TryParse(legajo.Replace("AA", ""), out int numLegajo) && legajo.Replace("AA", "").Length == 5)
            {
                // Comienza con AA y el resto son números
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

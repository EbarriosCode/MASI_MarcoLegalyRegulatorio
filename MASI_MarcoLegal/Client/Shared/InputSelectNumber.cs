using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Client.Shared
{
    public class InputSelectNumber<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, out T result, 
            out string validationErrorMessage)
        {
            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (T)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "El valor elegido no es un número válido.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}

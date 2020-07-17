using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Extensions
{
    public static class ModelStateExtensions
    {
        //Get error messages. This is the method that will called at the each controller to check whether the 
        //model stateis having issues or not. 
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}

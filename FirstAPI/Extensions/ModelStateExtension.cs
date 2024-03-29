﻿using FirstAPI.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FirstAPI.Extensions
{
    public static class ModelStateExtension
    {
        //public static List<string> GetErrors(this ModelStateDictionary modelState)
        //{
        //    var result = new List<string>();

        //    foreach (var item in modelState.Values)
        //        result.AddRange(item.Errors.Select(error => error.ErrorMessage));

        //    return result;
        //}     

        public static List<object> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<object>();

            foreach (var item in modelState)
            {
                var propertyName = item.Key;
                var errorMessages = item.Value.Errors.Select(error => new
                {
                    type = propertyName.ToLower(),
                    message = error.ErrorMessage
                });

                errors.AddRange(errorMessages);
            }

            return errors;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace S15D05_Pics.validators
{
    public class PriceValidator : ValidationAttribute
    {
        private double _minValue;
        private double _maxValue;

        public PriceValidator(double min, double max)
        {
            _minValue = min;
            _maxValue = max;
        }
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double price = (double)value;
            if (price < _minValue)
            {
                return new ValidationResult("We want to give you some money");
            }
            else if (price > _maxValue)
            {
                return new ValidationResult("Not that much money");
            }

            return ValidationResult.Success;
        }

    }
}

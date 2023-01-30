using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static validaciones.Form1;

namespace validaciones
{
    public class Validations : AbstractValidator<String>
    {
        public Validations(String name)
        {
   

            RuleSet("up", () =>
            {
                RuleFor(x => name.Length).Equal(10);
                RuleFor(x => name.Last()).Equal('U');

            });

            RuleSet("embalador", () =>
            {
                RuleFor(x => name.Length).Equal(12);
                RuleFor(x => name.Last()).Equal('E');

            });
        }

        public void validarEtiquetas(String name)
        {

            double numericValue;
            name = name.ToUpper();
            bool isNumber = double.TryParse(name, out numericValue);
            if (!isNumber && name != "")
            {

                var validator = new Validations(name);

                ValidationResult result = validator.Validate(name, options => options.IncludeRuleSets("up"));
                if (result.IsValid)
                {

                    Console.WriteLine("Es una etiqueta de up");

                }
                ValidationResult result2 = validator.Validate(name, options => options.IncludeRuleSets("embalador"));
                if (result2.IsValid)
                {
                    Console.WriteLine("Es una etiqueta de embalador");
                }

                else { Console.WriteLine("La etiqueta no corresponde"); }

            }
        }
    }

}

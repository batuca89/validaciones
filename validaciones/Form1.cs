using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //var beer = new Beer() { name = "000000000U", alcohol = 0 };
            String valor = "";

            Validations validations = new Validations(valor);
            validations.validarEtiquetas(valor);

            //validarDatos(valor, "generales", "up");

            
 



        } 

        public void validarDatos( String name, String parametro1, String parametro2 )
        {
           
            double numericValue;
            name = name.ToUpper();
            bool isNumber = double.TryParse(name, out numericValue);
            if (!isNumber && name !="")
            {

            
            var validator = new BeerValidator(name);
            ValidationResult result = validator.Validate(name, options => options.IncludeRuleSets(parametro1, parametro2));
            if (result.IsValid)
            {
                
                    Console.WriteLine("Es una etiqueta de up");
                
            }
            ValidationResult result2 = validator.Validate(name, options => options.IncludeRuleSets("generales", "embalador"));
                if (result2.IsValid)
                {
                    Console.WriteLine("Es una etiqueta de embalador");
                }

                else { Console.WriteLine("La etiqueta no corresponde"); }

            }
        }

        public class BeerValidator : AbstractValidator<String>
        {
            public BeerValidator(String name)

            {

                RuleSet("generales", () =>
                {
                    RuleFor(x => name).NotEmpty();
                    RuleFor(x => name).NotNull();

                });

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
         
        }

        public class Beer
        {
            public String name { get; set; }
            public decimal alcohol { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

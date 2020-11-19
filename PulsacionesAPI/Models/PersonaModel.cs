using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PulsacionesAPI.Models
{
    public class PersonaModel
    {
        [Key]
        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Range(1, 99, ErrorMessage = "La edad debe estar en un rango entre 1 y 99")]
        public int Edad { get; set; }
        [SexoValidacion(ErrorMessage = "El sexo debe ser F o M")]
        public string Sexo { get; set; }

        public decimal Pulsacion { get; set; }

        public void CalcularPulsaciones()
        {
            if (Sexo.Equals("F") || Sexo.Equals("f"))
            {
                Pulsacion = (220 - Edad) / 10;
            }
            else
            {
                Pulsacion = (210 - Edad) / 10;
            }
        }
    }
    public class SexoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "M") || (value.ToString().ToUpper() == "F"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }

    }
}

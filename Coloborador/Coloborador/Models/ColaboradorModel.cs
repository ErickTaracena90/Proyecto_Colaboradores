using System.ComponentModel.DataAnnotations;

namespace Coloborador.Models
{
    public class ColaboradorModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string? nombres { get; set; }

        [Required(ErrorMessage = "El campo apellidos es obligatorio")]
        public string? apellidos { get; set; }

        [Required(ErrorMessage = "El campo fecha nacimiento es obligatorio")]
        public string? fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "El campo estado civil es obligatorio")]
        public string? estado_civil { get; set; }

        [Required(ErrorMessage = "El campo grado academico es obligatorio")]
        public string? grado_academico { get; set; }

        [Required(ErrorMessage = "El campo direccion es obligatorio")]
        public string? direccion { get; set; }

    }
}


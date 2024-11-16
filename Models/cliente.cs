using System;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI_EF.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}

namespace ClienteAPI_EF.Models
{
    public class InformacionCliente
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        [Required]
        public string TipoInformacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [Required]
        public string UsuarioCreador { get; set; }
        [Required]
        public bool EstadoInformacion { get; set; }
        
        public Cliente Cliente { get; set; }
    }
}
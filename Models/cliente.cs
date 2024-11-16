using System;
using System.Collections.Generic;

namespace clienteAPI_EF.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<InformacionCliente> InformacionClienteClienteId1Navigations { get; set; } = new List<InformacionCliente>();

    public virtual ICollection<InformacionCliente> InformacionClienteClientes { get; set; } = new List<InformacionCliente>();
}

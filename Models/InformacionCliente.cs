using System;
using System.Collections.Generic;

namespace clienteAPI_EF.Models;

public partial class InformacionCliente
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string TipoInformacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string UsuarioCreador { get; set; } = null!;

    public bool EstadoInformacion { get; set; }

    public int? ClienteId1 { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Cliente? ClienteId1Navigation { get; set; }
}

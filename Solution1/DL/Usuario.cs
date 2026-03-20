using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public string FechaAlta { get; set; } = null!;

    public string? FechaModificacion { get; set; }
}

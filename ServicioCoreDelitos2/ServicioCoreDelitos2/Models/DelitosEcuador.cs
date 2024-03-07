using System;
using System.Collections.Generic;

namespace ServicioCoreDelitos2.Models;

public partial class DelitosEcuador
{
    public int Id { get; set; }

    public string? Ciudad { get; set; }

    public string? Delito { get; set; }

    public DateTime? FechaDelito { get; set; }

    public int? MontoPerdida { get; set; }

    public string? Resuelto { get; set; }
}

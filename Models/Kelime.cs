using System;
using System.Collections.Generic;

namespace AdamAsmaca.Models;

public partial class Kelime
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public int? Kategoriid { get; set; }
}

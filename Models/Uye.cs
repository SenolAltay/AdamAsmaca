using System;
using System.Collections.Generic;

namespace AdamAsmaca.Models;

public partial class Uye
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Sifre { get; set; }

    public DateTime? Uyeolmatarihi { get; set; }
}

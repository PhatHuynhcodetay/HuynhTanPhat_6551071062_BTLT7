using System;
using System.Collections.Generic;

namespace Cau4_QuanLyLichKham.Models;

public partial class LichKham
{
    public int MaLich { get; set; }

    public string TenBenhNhan { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public DateOnly NgayKham { get; set; }

    public string GioKham { get; set; } = null!;

    public int MaBs { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual BacSi MaBsNavigation { get; set; } = null!;
}

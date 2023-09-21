using System;
using System.Collections.Generic;

namespace Registerloginpage.Models;

public partial class Tblcategory
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Tblproduct> Tblproducts { get; set; } = new List<Tblproduct>();
}

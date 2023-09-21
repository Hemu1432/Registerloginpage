using System;
using System.Collections.Generic;

namespace Registerloginpage.Models;

public partial class Tblproduct
{
    public int Productid { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Categoryid { get; set; }

    public virtual Tblcategory Category { get; set; } = null!;
}

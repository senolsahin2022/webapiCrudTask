using System;
using System.Collections.Generic;

namespace sunum2.Web.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserUserName { get; set; } = null!;

    public string UserUserPassword { get; set; } = null!;
    public bool Status { get; set; } = true;
}

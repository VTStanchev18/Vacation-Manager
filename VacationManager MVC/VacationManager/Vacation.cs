using System;
using System.Collections.Generic;

namespace Vacation_Manager.VacationManager;

public partial class Vacation
{
    public int Id { get; set; }

    public DateTime? BeggingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public DateTime? DateOfCreation { get; set; }

    public bool? HalfDay { get; set; }

    public bool? Approved { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}

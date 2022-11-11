using System;
using System.Collections.Generic;

namespace Vacation_Manager.VacationManager;

public partial class UserTeam
{
    public int LeaderId { get; set; }

    public int? UserId { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }

    public virtual User? User { get; set; }
}

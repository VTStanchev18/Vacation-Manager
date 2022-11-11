using System;
using System.Collections.Generic;

namespace Vacation_Manager.VacationManager;

public partial class Project
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}

using System;
using System.Collections.Generic;

namespace Vacation_Manager.VacationManager;

public partial class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();

    public virtual ICollection<UserTeam> UserTeams { get; } = new List<UserTeam>();
}

using System;
using System.Collections.Generic;

namespace Vacation_Manager.VacationManager;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Role { get; set; }

    public int? TeamId { get; set; }

    public virtual ICollection<UserTeam> UserTeams { get; } = new List<UserTeam>();

    public virtual ICollection<Vacation> Vacations { get; } = new List<Vacation>();
}

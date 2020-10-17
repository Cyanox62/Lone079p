using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lone079p
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;

		[Description("Determines if zombies should be considered when counting the amount of SCPs alive.")]
		public bool CountZombies { get; set; } = false;

		[Description("The announcement to be played when SCP-079 is replaced.")]
		public string ReplacementAnnouncement { get; set; } = "SCP 0 7 9 is now %scp";

		[Description("The percent chance for the respawn announcement to be played.")]
		public int AnnouncementChance { get; set; } = 40;

		[Description("The percent health that SCP-079 will respawn with.")]
		public int PercentHealth { get; set; } = 50;

		[Description("The amount of health a respawned SCP will have depending on their level.")]
		public Dictionary<int, Dictionary<RoleType, int>> HealthPercentages { get; set; } = new Dictionary<int, Dictionary<RoleType, int>>()
		{
			{ 1, new Dictionary<RoleType, int>()
				{
					{ RoleType.Scp049, 20 },
					{ RoleType.Scp096, 20 },
					{ RoleType.Scp106, 20 },
					{ RoleType.Scp173, 20 },
					{ RoleType.Scp93953, 10 },
					{ RoleType.Scp93989, 10 }
				}
			},
			{ 2, new Dictionary<RoleType, int>()
				{
					{ RoleType.Scp049, 20 },
					{ RoleType.Scp096, 20 },
					{ RoleType.Scp106, 20 },
					{ RoleType.Scp173, 20 },
					{ RoleType.Scp93953, 10 },
					{ RoleType.Scp93989, 10 }
				}
			},
			{ 3, new Dictionary<RoleType, int>()
				{
					{ RoleType.Scp049, 20 },
					{ RoleType.Scp096, 20 },
					{ RoleType.Scp106, 20 },
					{ RoleType.Scp173, 20 },
					{ RoleType.Scp93953, 10 },
					{ RoleType.Scp93989, 10 }
				}
			},
			{ 4, new Dictionary<RoleType, int>()
				{
					{ RoleType.Scp049, 20 },
					{ RoleType.Scp096, 20 },
					{ RoleType.Scp106, 20 },
					{ RoleType.Scp173, 20 },
					{ RoleType.Scp93953, 10 },
					{ RoleType.Scp93989, 10 }
				}
			},
			{ 5, new Dictionary<RoleType, int>()
				{
					{ RoleType.Scp049, 20 },
					{ RoleType.Scp096, 20 },
					{ RoleType.Scp106, 20 },
					{ RoleType.Scp173, 20 },
					{ RoleType.Scp93953, 10 },
					{ RoleType.Scp93989, 10 }
				}
			}
		};
	}
}

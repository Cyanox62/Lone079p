﻿using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lone079p
{
	class EventHandlers
	{
		private Vector3 scp939pos;

		private bool is106Contained, canChange;

		private IEnumerator<float> Check079(float delay = 1f)
		{
			if (Map.ActivatedGenerators != 5 && canChange)
			{
				yield return Timing.WaitForSeconds(delay);

				IEnumerable<Player> enumerable = Player.List.Where(x => x.Team == Team.SCP);
				if (!Lone079p.instance.Config.CountZombies) enumerable = enumerable.Where(x => x.Role != RoleType.Scp0492);
				List<Player> pList = enumerable.ToList();

				if (pList.Count == 1 && pList[0].Role == RoleType.Scp079)
				{
					Player player = pList[0];
					int level = player.Level + 1;

					Dictionary<RoleType, int> percentages = Lone079p.instance.Config.HealthPercentages[level];

					RoleType role = RoleType.Scp173;

					int rand = UnityEngine.Random.Range(0, 101);
					int last = 0;
					int sum = 0;
					foreach (var item in percentages)
					{
						last = sum;
						sum += item.Value;
						if (rand > last && rand <= sum)
						{
							role = item.Key;
						}
					}

					if (is106Contained && role == RoleType.Scp106) role = RoleType.Scp93953;
					player.SetRole(role);
					Timing.CallDelayed(1f, () => player.Position = scp939pos);

					player.Health = player.MaxHealth * Lone079p.instance.Config.PercentHealth / 100f;

					player.Broadcast(10, $"<i>You have been respawned as a random SCP with {Lone079p.instance.Config.PercentHealth}% health because all other SCPs have died.</i>");
					Cassie.Message(Lone079p.instance.Config.ReplacementAnnouncement.Replace("%scp", role.ToString().Substring(0, 6).Insert(3, " ").Insert(5, " ").Insert(7, " ")));
				}
			}
		}

		public void OnPlayerLeave(LeftEventArgs ev)
		{
			if (ev.Player.Team == Team.SCP) Timing.RunCoroutine(Check079(3f));
		}

		public void OnDetonated() => canChange = false;

		public void OnRoundStart()
		{
			Timing.CallDelayed(1f, () => scp939pos = Map.GetRandomSpawnPoint(RoleType.Scp93953));
			is106Contained = false;
			canChange = true;
		}

		public void OnPlayerDied(DiedEventArgs ev)
		{
			if (ev.Target.Team == Team.SCP)
			{
				Timing.RunCoroutine(Check079());
			}
		}

		public void OnScp106Contain(ContainingEventArgs ev)
		{
			is106Contained = true;
		}
	}
}
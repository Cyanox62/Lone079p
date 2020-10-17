using Exiled.API.Features;
using HarmonyLib;

namespace Lone079p
{
	public class Lone079p : Plugin<Config>
	{
		internal static Lone079p instance;

		private EventHandlers ev;
		private Harmony hInstance;

		public override void OnEnabled()
		{
			base.OnEnabled();

			instance = this;

			hInstance = new Harmony("cyanox.lone079p");
			hInstance.PatchAll();

			ev = new EventHandlers();
			Exiled.Events.Handlers.Player.Left += ev.OnPlayerLeave;
			Exiled.Events.Handlers.Player.Died += ev.OnPlayerDied;
			Exiled.Events.Handlers.Scp106.Containing += ev.OnScp106Contain;
			Exiled.Events.Handlers.Server.RoundStarted += ev.OnRoundStart;
			Exiled.Events.Handlers.Warhead.Detonated += ev.OnDetonated;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			ev = new EventHandlers();
			Exiled.Events.Handlers.Player.Left -= ev.OnPlayerLeave;
			Exiled.Events.Handlers.Player.Died -= ev.OnPlayerDied;
			Exiled.Events.Handlers.Scp106.Containing -= ev.OnScp106Contain;
			Exiled.Events.Handlers.Server.RoundStarted -= ev.OnRoundStart;
			Exiled.Events.Handlers.Warhead.Detonated -= ev.OnDetonated;

			hInstance.UnpatchAll();
		}

		public override string Name => "Lone079p";
		public override string Author => "Cyanox";
	}
}

// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace SpectatorList
{
    using System.Collections.Generic;
    using System.Text;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using NorthwoodLib.Pools;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnVerified(VerifiedEventArgs)"/>
        public void OnVerified(VerifiedEventArgs ev)
        {
            Timing.RunCoroutine(SpectatorList(ev.Player).CancelWith(ev.Player.GameObject));
        }

        private IEnumerator<float> SpectatorList(Player player)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(1f);
                if (player.IsDead)
                    continue;

                int count = 0;
                StringBuilder spectatorListBuilder = StringBuilderPool.Shared.Rent();
                foreach (Player spectator in player.CurrentSpectatingPlayers)
                {
                    if (spectator == player ||
                        spectator.IsGlobalModerator ||
                        (spectator.IsOverwatchEnabled && plugin.Config.IgnoreOverwatch) ||
                        (spectator.IsNorthwoodStaff && plugin.Config.IgnoreNorthwood))
                        continue;

                    spectatorListBuilder.Append("\n").Append(spectator.Nickname);
                    count++;
                }

                string spectatorList = StringBuilderPool.Shared.ToStringReturn(spectatorListBuilder);
                if (count > 0)
                    player.ShowHint(string.Format(plugin.Config.Message, player.Role.Color.ToHex(), count, spectatorList), 1.2f);
            }
        }
    }
}

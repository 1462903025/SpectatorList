// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace SpectatorList
{
    using System;
    using Exiled.API.Features;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc/>
        public override string Name => "SpectatorList";

        /// <inheritdoc />
        public override string Prefix => "SpectatorList";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new(5, 1, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new(1, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            PlayerEvents.Verified += eventHandlers.OnVerified;

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerEvents.Verified -= eventHandlers.OnVerified;
            eventHandlers = null;

            base.OnDisabled();
        }
    }
}
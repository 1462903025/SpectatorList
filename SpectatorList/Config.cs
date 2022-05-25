// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace SpectatorList
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the message to display to players that are being spectated.
        /// </summary>
        [Description("要显示给正在观看的玩家的消息。")]
        public string Message { get; set; } = "<align=right><size=45%><color={0}><b>👥 观众 ({1}):</b>{2}</color></size></align>";

        /// <summary>
        /// Gets or sets a value indicating whether players spectating with overwatch should be ignored from the spectator list.
        /// </summary>
        [Description("是否应从观众名单中忽略观看过度的玩家。")]
        public bool IgnoreOverwatch { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether spectating northwood staff should be ignored from the spectator list.
        /// </summary>
        [Description("是否应从观众名单中忽略观看NW官方的员工。")]
        public bool IgnoreNorthwood { get; set; } = false;
    }
}
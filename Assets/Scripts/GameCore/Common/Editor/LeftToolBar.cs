﻿using UnityEngine;
using static BeatRoyale.DebugData;

namespace BeatRoyale
{
    public static partial class ToolBar
    {
        private static void OnToolbarLeftGUI()
        {
            var needShowRadius = Config.needShowRadius;
            var serverEnabled = Config.serverEnabled;
            //GUI.changed = ToolbarExtender.leftRect.Contains(Event.current.mousePosition);

            if (DrawToggle("Server Enabled", "Server Disabled", serverEnabled))
            {
                Config.serverEnabled = !serverEnabled;
                Save();
            }

            if (DrawToggle("Radius Showed", "Radius Hidden", needShowRadius))
            {
                Config.needShowRadius = !needShowRadius;
                Save();
            }
        }

        private static bool DrawToggle(string enabledLabel, string disabledLabel, bool isEnabled, int width = 100)
        {
            return GUILayout.Button(isEnabled ? $"<b>{enabledLabel}</b>" : $"<b>{disabledLabel}</b>",
                isEnabled ? GreenButtonStyle : RedButtonStyle,
                GUILayout.MaxWidth(width), GUILayout.MinHeight(20));
        }
    }
}
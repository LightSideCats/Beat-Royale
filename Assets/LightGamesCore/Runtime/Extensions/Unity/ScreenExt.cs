﻿using UnityEngine;

namespace LGCore.Extensions.Unity
{
    public static class ScreenExt
    {
        public static float Aspect { get; private set; }
        public static bool IsPortrait => Screen.orientation == ScreenOrientation.Portrait;
        public static Rect Rect { get; private set; }

        static ScreenExt()
        {
            EntryPoint.TryCallAndListen(Init);
        }

        private static void Init()
        {
            Aspect = IsPortrait ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
            Rect = new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height));
        }
    }
}
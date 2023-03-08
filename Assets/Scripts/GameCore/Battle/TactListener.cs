﻿using System;
using MusicEventSystem.Configs;

namespace BeatRoyale
{
    public class TactListener : IDisposable
    {
        public event Action Ticked;
        private float offset;
        private TactListener(){}

        public static TactListener Listen(float offset = 0)
        {
            var listener = new TactListener();
            listener.offset = MusicReactiveTest.MusicOffset + offset;
            MusicData.TactTicked += listener.OnTick;

            return listener;
        }

        public TactListener OnTicked(Action action)
        {
            Ticked += action;
            return this;
        }

        private void OnTick()
        {
            new CountDownTimer(offset, true).Stopped += OnTickStoped;
        }

        private void OnTickStoped()
        {
            Ticked?.Invoke();
        }

        public void Dispose()
        {
            Ticked = null;
        }
    }
}
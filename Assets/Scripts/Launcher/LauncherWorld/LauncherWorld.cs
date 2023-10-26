﻿using BeatHeroes.Interfaces;
using BeatHeroes.Windows;
using LSCore;
using Sirenix.OdinInspector;

namespace BeatHeroes.Launcher
{
    public class LauncherWorld : ServiceManager
    {
        protected override void Awake()
        {
            base.Awake();
            BaseInitializer.Initialize(Init);
            Coins.Earn(100);
            Coins.Earn(120);
            Coins.Earn(40);
            Keys.Earn(123);
            Keys.Earn(532);

            Coins.TryConvertTo<Keys>(100, 2000);
        }

        private void Init()
        {
            MainWindow.Show();
        }

        [Button] private void Create(string clanName) => Clan.Create(clanName).OnComplete(task => Burger.Log($"[Clan] Create {clanName} {task.IsSuccess} {task.Exception}"));
        [Button] private void Join(string clanId) => Clan.Join(clanId).OnComplete(task => Burger.Log($"[Clan] Joined {clanId} {task.IsSuccess} {task.Exception}"));
        [Button] private void Delete() => Clan.Delete().OnComplete(task => Burger.Log($"[Clan] Delete {Clan.Id} {task.IsSuccess} {task.Exception}"));
        [Button] private void Leave() => Clan.Leave().OnComplete(task => Burger.Log($"[Clan] Leave {Clan.Id} {task.IsSuccess} {task.Exception}"));
        [Button] private void Kick(string userId) => Clan.Kick(userId).OnComplete(task => Burger.Log($"[Clan] Kick {Clan.Id} User: {userId} {task.IsSuccess} {task.Exception}"));
    }
}

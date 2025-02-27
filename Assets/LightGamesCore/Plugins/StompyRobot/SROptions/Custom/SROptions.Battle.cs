﻿#if DEBUG
using System.ComponentModel;
using Battle.Windows;
using Core.Server;
using GameCore.Battle;
using UnityEngine;
using static Core.ConfigModule.BaseConfig<Core.ConfigModule.DebugData>;

public partial class SROptions 
{
    [Category("Battle")]
    public void Win() 
    {
        MatchResultWindow.Show(true);
    }
    
    [Category("Battle")]
    public void Lose() 
    {
        MatchResultWindow.Show(false);
    }
    
    [Category("Battle")]
    public bool ShowRadius
    {
        get => Config.needShowRadius;
        set
        {
            Config.needShowRadius = value;
            RadiusUtils.SetActiveRadiuses(value);
        }
    }
    
    [Category("Battle")]
    public bool EnableServer
    {
        get => Config.serverEnabled;
        set => Config.serverEnabled = value;
    }
    
    [Category("Battle")]
    public bool InfinityMana
    {
        get => DeckWindow.InfinityMana;
        set => DeckWindow.InfinityMana = value;
    }
    
    [Category("Leaderboards")]
    public void IncreaseRank()
    {
        Leaderboards.Rank += Random.Range(0, 10);
    }
    
    [Category("Leaderboards")]
    public void DecreaseRank()
    {
        Leaderboards.Rank -= Random.Range(0, 10);
    }
}
#endif
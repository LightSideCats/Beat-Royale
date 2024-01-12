﻿using System.Collections.Generic;
using LSCore;
using LSCore.LevelSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BeatHeroes.Data
{
    public class HeroRankIconsConfigs : ValuesById<HeroRankIconsRef>
    {
        [SerializeField] [IdGroup] private LevelIdGroup group;
        private static HeroRankIconsConfigs instance;
        public static Dictionary<Id, HeroRankIconsRef> ById => instance.ByKey;
        
        public void Init() => instance = this;
        
#if UNITY_EDITOR
        protected override void SetupDataSelector(ValueDropdownList<Data> list) => SetupByGroup(group, list);
#endif
    }
}
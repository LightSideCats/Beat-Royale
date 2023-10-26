﻿using System;
using System.Collections.Generic;
using Battle.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GameCore.Battle.Data
{
    internal class Effectors : SerializedScriptableObject
    {
        [Serializable] 
        public class EffectorByName
        {
            [SerializeField, EntityId("Effectors")] public int effectorName;
            [OdinSerialize] public BaseEffector effector;
        }
        
        [OdinSerialize, TableList] private List<EffectorByName> byName = new();
        public static Dictionary<int, BaseEffector> ByName { get; } = new();

        public void Init()
        {
            for (int i = 0; i < byName.Count; i++)
            {
                var pair = byName[i];
                pair.effector.name = pair.effectorName;
                ByName.TryAdd(pair.effectorName, pair.effector);
            }
        }
    }
}
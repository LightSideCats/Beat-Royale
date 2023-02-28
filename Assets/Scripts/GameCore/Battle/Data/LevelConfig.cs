﻿using System.Collections.Generic;
using Battle.Data.GameProperty;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Battle.Data
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Battle/" + nameof(LevelConfig), order = 0)]
    public partial class LevelConfig : SerializedScriptableObject
    {
        [InfoBox("First level should contains entity scope with fixed value at all properties", InfoMessageType.Error, "$" + nameof(isFirstLevelError))]
        [InfoBox("Config is invalid. Check config name.", InfoMessageType.Error, "$" + nameof(IsInvalidName))]
        [OdinSerialize, TableList, OnValueChanged(nameof(OnUpgradeStepsChanged))] public List<GamePropertiesByScope> UpgradesByScope { get; set; } = new();
        [OdinSerialize] public List<BaseWallet> Price { get; set; } = new();

        public void InitProperties(Dictionary<string, List<BaseGameProperty>> properties)
        {
            for (int i = 0; i < UpgradesByScope.Count; i++)
            {
                var upgrade = UpgradesByScope[i];

                for (int j = 0; j < upgrade.Properties.Count; j++)
                {
                    var prop = upgrade.Properties[j];
                    var propType = prop.GetType().Name;
                    prop.scope = upgrade.Scope;

                    if (!properties.TryGetValue(propType, out var list))
                    {
                        list = new List<BaseGameProperty>();
                        properties.Add(propType, list);
                    }
                    
                    list.Add(prop);
                }
            }
        }
    }
}
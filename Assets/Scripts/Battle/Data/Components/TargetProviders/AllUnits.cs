﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Data.Components.TargetProviders
{
    [Serializable]
    internal class AllUnits : TargetProvider
    {
        public override IEnumerable<Transform> Targets 
        {
            get
            {
                foreach (var unit in OpponentWorld.Units)
                {
                    yield return unit.transform;
                }
            }
        }
    }
}
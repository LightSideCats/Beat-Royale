﻿using System.Collections.Generic;
using GameCore.Battle.Data;
using LSCore;
using UnityEngine;
using UnitsByTransform = GameCore.Battle.ObjectsByTransfroms<GameCore.Battle.Data.Unit>;

namespace Battle
{
    public abstract class BasePlayerWorld<T> : SingleService<T> where T : BasePlayerWorld<T>
    {
        private static Dictionary<Transform, Unit> units;
        public static int UnitCount => units.Count;
        
        public static IEnumerable<Unit> Units
        {
            get
            {
                foreach (var unit in units.Values)
                {
                    yield return unit;
                }
            }
        }
        
        private string userId;
        protected bool IsOpponent { get; private set; }

        protected string UserId
        {
            get => userId;
            set
            {
                userId = value;
                IsOpponent = UserId == "Opponent";
                units ??= new Dictionary<Transform, Unit>();
                if (!Unit.ByWorld.TryAdd(value, units))
                {
                    units.Clear();
                }
            }
        }

        protected override void Init()
        {
            enabled = false;
        }

        public static void Begin()
        {
            Instance.enabled = true;
            Instance.OnBegin();
        }
        
        public static void Stop()
        {
            Debug.Log($"Stoped {typeof(T)}");
            Instance.enabled = false;
            Instance.OnStop();
        }
        
        protected virtual void OnBegin(){}
        protected virtual void OnStop(){}
        
        protected Unit Spawn(Unit prefab)
        {
            var unit = Instantiate(prefab);
            InitUnit(unit);
            return unit;
        }
        
        private void InitUnit(Unit unit)
        {
            unit.Init(UserId);
        }

        private void Update()
        {
            foreach (var unit in units.Values)
            {
                unit.Run();
            }
        }
        
        private void FixedUpdate()
        {
            foreach (var unit in units.Values)
            {
                unit.FixedRun();
            }
        }
    }
}
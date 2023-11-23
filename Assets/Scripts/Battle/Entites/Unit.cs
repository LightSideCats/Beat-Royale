﻿using System;
using Battle.Data.Components;
using Battle.Data.Components.HitBox;
using Sirenix.Serialization;
using static Battle.ObjectsByTransfroms<Battle.Data.Unit>;

namespace Battle.Data
{
    public partial class Unit : BaseUnit
    {
        public event Action Destroyed;

        [OdinSerialize] private MoveComponent moveComponent = new();
        [OdinSerialize] private FindTargetComponent findTargetComponent = new ();
        [OdinSerialize] private AttackComponent attackComponent = new();
        [OdinSerialize] private HealthComponent healthComponent = new();
        [OdinSerialize] private HitBoxComponent hitBoxComponent = new ColiderHitBoxComponent();
        
        private float radius;

        public override void Init(string userId)
        {
            base.Init(userId);
            Add(transform, this);
            
            hitBoxComponent.Init(transform);
            findTargetComponent.Init(transform, IsOpponent);
            moveComponent.Init(transform, findTargetComponent);
            healthComponent.Init(transform, IsOpponent);
            attackComponent.Init(transform, findTargetComponent);
        }

        public void Run()
        {
            attackComponent.Update();
            moveComponent.SetEnabled(!attackComponent.IsInRadius);
            healthComponent.Update();
        }

        public void FixedRun()
        {
            moveComponent.Update();
        }

        public void Resett()
        {
            attackComponent.Buffs.Reset();
            moveComponent.Buffs.Reset();
            healthComponent.Reset();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            attackComponent.Enable();
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
            attackComponent.Disable();
        }

        public override void Destroy()
        {
            base.Destroy();
            hitBoxComponent.Destroy();
            attackComponent.Destroy();
            healthComponent.Destroy();
            moveComponent.Destroy();
            Remove(transform);
            Destroyed?.Invoke();
        }
    }
}
﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Scripting;
using static UnityEngine.Object;
using Object = UnityEngine.Object;

namespace GameCore.Battle.Data.Components
{
    [Preserve, Serializable]
    internal class ShootAttackComponent : AttackComponent
    {
        [SerializeField] private GameObject bulletPrefab;
        
        protected override Tween AttackAnimation()
        {
            var target = findTargetComponent.target;
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            return bullet.transform.DOMove(target.position, duration).OnComplete(() =>
            {
                Object.Destroy(bullet, 0.35f);
                TryApplyDamage(target);
            });
        }
    }
}
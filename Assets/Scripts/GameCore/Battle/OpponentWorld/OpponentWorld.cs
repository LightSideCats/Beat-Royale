﻿using System.Collections;
using System.Collections.Generic;
using Battle.Data;
using GameCore.Battle.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Battle
{
    public class OpponentWorld : BasePlayerWorld<OpponentWorld>
    {
        private static IList<ValueDropdownItem<int>> EnemyNames => IdToName.GetValues(EntityMeta.EntityIds);
        [SerializeField, ValueDropdown(nameof(EnemyNames))] private int enemyName;
        [SerializeField] private Transform spawnPoint;

        protected override void Init()
        {
            UserId = "Opponent";
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnOpponents());
        }

        private IEnumerator SpawnOpponents()
        {
            while (enabled)
            {
                Spawn();
                yield return new WaitForSeconds(1);
            }
        }

        private void Spawn()
        {
            Internal_Spawn(Heroes.ByName[enemyName], spawnPoint.position);
        }

        protected override void OnStop()
        {
            
        }
    }
}
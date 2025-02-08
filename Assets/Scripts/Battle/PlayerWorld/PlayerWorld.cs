using Battle.Windows;
using Battle.Data;
using LSCore.BattleModule;
using LSCore.LevelSystem;
using UnityEngine;

namespace Battle
{
    public class PlayerWorld : BaseTeamWorld<PlayerWorld>
    {
        [SerializeField] private LevelsManager heroes;
        [SerializeField] private Vector3 cameraOffset;
        public static Transform HeroTransform { get; private set; }
        private Unit hero;

        public override string UserId => BattlePlayerData.UserId;
        public override string TeamId => BattlePlayerData.TeamId;

        protected override void OnBegin()
        {
            MatchResultWindow.Showing += OnMatchResultShowing;
            var prefab = heroes.GetCurrentLevel<Unit>(PlayerData.Config.SelectedHero.Value);
            var pool = CreatePool(prefab);
            pool.Released += OnHeroDied;
            hero = pool.Get();
            HeroTransform = hero.transform;
            CameraMover.Init(BattleWorld.Camera, HeroTransform, cameraOffset);
        }

        private void OnMatchResultShowing()
        {
            MatchResultWindow.Showing -= OnMatchResultShowing;
            Stop();
        }

        private void OnHeroDied(Unit unit)
        {
            MatchResultWindow.Show(false);
        }
    }
}
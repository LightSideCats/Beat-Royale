using System.Collections.Generic;
using LGCore.Extensions.Unity;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LGCore.UIModule.Editor
{
    public static class RaycastTargetCleaner
    {
        [MenuItem(LGCorePaths.MenuItem.Tools + "/Disable Raycast Target")]
        public static void Clean()
        {
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();

            if (prefabStage == null)
            {
                var gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();

                for (int i = 0; i < gameObjects.Length; i++)
                {
                    Clean(gameObjects[i]);
                }
            }
            else
            {
                Clean(prefabStage.prefabContentsRoot);
                EditorSceneManager.MarkSceneDirty(prefabStage.scene);
            }
        }

        private static void Clean(GameObject gameObject)
        {
            var transforms = new List<Transform>();
            gameObject.transform.GetAllChild(transforms);
            Clean(gameObject.transform);
        
            for (int i = 0; i < transforms.Count; i++)
            {
                Clean(transforms[i]);
            }
        
            transforms.Clear();
        }

        private static void Clean(Component component)
        {
            var hasSelectable = component.TryGetComponent<Selectable>(out var selectable);
            var hasGraphic = component.TryGetComponent<Graphic>(out var graphic);

            if (hasSelectable)
            {
                if (hasGraphic)
                {
                    graphic.raycastTarget = true;
                }
                else
                {
                    Debug.LogWarning($"GameObject {selectable.name} with {nameof(Selectable)} component has no {nameof(Graphic)} component", selectable);
                }
            }
            else if (hasGraphic)
            {
                graphic.raycastTarget = false;
            }
        }
    }
}
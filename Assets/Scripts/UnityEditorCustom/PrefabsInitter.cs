using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditorCustom
{
    public static class PrefabsInitter
    {
        private static string _prefabsPath = "Assets/Prefabs/";
        
        [MenuItem("GameObject/Prefabs/UI/Button", priority = 12)]
        static void CreateCamera(MenuCommand menuCommand)
        {
            var parent = menuCommand.context as GameObject;
            
           
        }
    }
}
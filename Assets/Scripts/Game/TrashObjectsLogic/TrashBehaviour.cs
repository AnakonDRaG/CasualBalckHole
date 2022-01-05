using Audio.Context;
using Game.TrashObjectsLogic;
using Game.TrashSceneObjects.Interfaces;
using Zenject;

namespace UnityTemplateProjects.Game.TrashObjectsLogic
{
    public class TrashBehaviour : BaseTrashGameObject
    {
        private void Awake()
        {
            Initialize();
        }

    }
}
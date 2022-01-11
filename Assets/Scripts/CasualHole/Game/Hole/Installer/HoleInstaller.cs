using CasualHole.Game.Hole.Interface;
using UnityEngine;
using Zenject;

namespace CasualHole.Game.Hole.Installer
{
    public class HoleInstaller : MonoInstaller
    {
        [SerializeField] private HoleBehaviour _holeBehaviour;

        public override void InstallBindings()
        {
            Container.Bind<IHoleBehaviour>().FromInstance(_holeBehaviour).AsSingle();
        }
    }
}
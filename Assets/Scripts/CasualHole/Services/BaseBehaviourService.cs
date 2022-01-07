using UnityEngine;

namespace CasualHole.Services
{
    public class BaseBehaviourService: MonoBehaviour, IService
    {
        private bool _serviceIsInit = false;
        
        public virtual void Initialize()
        {
            if (_serviceIsInit)
                throw new UnityException($"This '{this.GetType().Name}' has already been initialized!");
            
            _serviceIsInit = true;
        }
    }
}
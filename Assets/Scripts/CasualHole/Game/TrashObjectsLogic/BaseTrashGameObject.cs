using Game.TrashObjectsLogic.Context;
using Game.TrashSceneObjects.Interfaces;
using UnityEngine;

namespace CasualHole.Game.TrashObjectsLogic
{
    public abstract class BaseTrashGameObject : MonoBehaviour, ITrash
    {
        protected TrashObjectContext _context;

        public virtual void Initialize()
        {
            _context = new TrashObjectContext()
            {
                Rigidbody = GetComponent<Rigidbody>(),
                OriginalLocalScale = transform.localScale,
            };
        }

        public void ForceTo(Vector3 position)
        {
            if (transform.position.y < position.y)
            {
                _context.Rigidbody.AddForce(position - new Vector3(0, 10, 0));
                return;
            }

            var distanceMath = Vector3.Distance(transform.position, position);

            _context.Rigidbody.AddForce(position - _context.Rigidbody.position);


            transform.localScale = new Vector3(
                Mathf.Clamp(Mathf.Pow(distanceMath, 2), _context.MinScale, _context.OriginalLocalScale.x),
                Mathf.Clamp(Mathf.Pow(distanceMath, 2), _context.MinScale, _context.OriginalLocalScale.y),
                Mathf.Clamp(Mathf.Pow(distanceMath, 2), _context.MinScale, _context.OriginalLocalScale.z));
        }

        public virtual void DestroyGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
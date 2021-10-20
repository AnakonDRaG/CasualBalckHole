using Game.TrashObjectsLogic.Model;
using Game.TrashSceneObjects.Interfaces;
using UnityEngine;

namespace Game.TrashObjectsLogic
{
    public abstract class BaseTrashGameObject : MonoBehaviour, ITrash
    {
        private TrashObjectModel _model;

        private void Awake()
        {
            _model = new TrashObjectModel(gameObject.GetComponent<Rigidbody>(), transform.localScale);
        }

        public void ForceTo(Vector3 position)
        {
            if (transform.position.y < position.y)
            {
                _model.Rigidbody.AddForce(position - new Vector3(0,10,0));
                return;
            }

            var distanceMath = Vector3.Distance(transform.position, position);

            _model.Rigidbody.AddForce((position - _model.Rigidbody.position));
            

            transform.localScale = new Vector3(
                Mathf.Clamp((distanceMath), _model.MinScale, _model.OriginalLocalScale.x),
                Mathf.Clamp((distanceMath), _model.MinScale, _model.OriginalLocalScale.y),
                Mathf.Clamp((distanceMath), _model.MinScale, _model.OriginalLocalScale.z));
        }

        public void DestroyGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
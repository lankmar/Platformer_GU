using UnityEngine;
using Platformer.View;
namespace Platformer.Controllers
{
    public class BulletController 
    {
        private Vector3 _velocity;
        float _angle;
        private Vector3 _axis;

        private LevelObjectView _view;
       // private CannonController

        public BulletController(LevelObjectView view)
        {
            _view = view;
            Active(false);
        }

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity, Vector3 position)
        {
            _velocity = velocity;
            _angle = Vector3.Angle(position, _velocity); //сюда передать   1:47
            _axis = Vector3.Cross(position, _velocity); //информацию из кенон контролер
            _view.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }

        public void Trow(Vector3 position, Vector3 velocity)
        {
            Active(true);
            SetVelocity(velocity, position);
            _view._transform.position = position;
            _view._rigidbody.velocity = Vector3.zero;
            _view._rigidbody.angularVelocity = 0;

            _view._rigidbody.AddForce(velocity, ForceMode2D.Impulse);

        
        }

    }
}
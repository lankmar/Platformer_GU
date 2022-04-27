using UnityEngine;
namespace Platformer.Controllers
{
    public class CannonController 
    {
        private Transform _mazzleTransform;
        private Transform _targetTransform;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axis;
        private Vector3 _startAngle;

        public CannonController(Transform muzzleTransform, Transform _plTransform)
        {
            _mazzleTransform = muzzleTransform;
            _targetTransform = _plTransform;
            _startAngle = _mazzleTransform.rotation.eulerAngles;

        }
        public void Update()
        {
            _dir = _targetTransform.position - _mazzleTransform.position;
            _angle = Vector3.Angle(Vector3.down, _dir); // переделать
            _axis = Vector3.Cross(Vector3.down, _dir);  // 

            _mazzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}
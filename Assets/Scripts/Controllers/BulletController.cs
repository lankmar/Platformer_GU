using UnityEngine;
using Platformer.View;
using System;

namespace Platformer.Controllers
{
    public class BulletController : IDisposable
    {
        private Vector3 _velocity;
        float _angle;
        private Vector3 _axis;

        private LevelObjectView _bulletView;
        private LevelObjectView _playerView;
        // private CannonController

        public BulletController(LevelObjectView view, LevelObjectView playerView)
        {
            _bulletView = view;
            Active(false);
            _playerView = playerView;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;
        }

        public void Active(bool val)
        {
            _bulletView.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity, Vector3 position)
        {
            _velocity = velocity;
            _angle = Vector3.Angle(position, _velocity); //сюда передать   1:47
            _axis = Vector3.Cross(position, _velocity); //информацию из кенон контролер
            _bulletView.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }

        public void Trow(Vector3 position, Vector3 velocity)
        {
            Active(true);
            SetVelocity(velocity, position);
            _bulletView._transform.position = position;
            _bulletView._rigidbody.velocity = Vector3.zero;
            _bulletView._rigidbody.angularVelocity = 0;

            _bulletView._rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
        
            // GameObject.Destroy(contactView.gameObject);
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
using Platformer.View;
using Platformer.Config;
using UnityEngine;
using Platformer.Utils;

namespace Platformer.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private const float _speed = 200f;
        private const float _animationSpeed = 15f;
        private const float _jumpSpeed = 10f;

        private const float _movingTresh = 0.2f;
        private const float _jumpTresh = 1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _xVelocity;
        private bool _isJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimatorController _animatorController;
        private ContactPooler _contactPooler;

        public PlayerController(LevelObjectView levelObjectView, SpriteAnimatorController spriteAnimator)
        {
            _view = levelObjectView;
            _animatorController = spriteAnimator;
            _animatorController.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        public void Update()
        {
            _animatorController.Update();
            _contactPooler.Update();


            _isJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _movingTresh;

            if (Move)
            {
                MoveTowards();
            }

            if (_contactPooler.IsGrounded)
            {
                _animatorController.StartAnimation(_view._spriteRenderer, Move ? AnimState.Walk : AnimState.Idle, true, _animationSpeed);
                if (_isJump && _view._rigidbody.velocity.y <= _jumpTresh)
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }

            }
            else
            {
                if (Mathf.Abs(_view._rigidbody.velocity.y) > _jumpTresh)
                {
                    _animatorController.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }

        private void MoveTowards()
        {
            _xVelocity = Time.fixedDeltaTime * _speed * (_xAxisInput < 0 ? -1 : 1);
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x: _xVelocity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

    }
}
using System.Collections;
using Platformer.Veiw;
using Platformer.Config;
using UnityEngine;
using Platformer.Utils;

namespace Platformer.Controllers
{
    public class PlayerTransformController : MonoBehaviour
    {
        private const float _speed = 5f;
        private const float _animationSpeed = 10f;
        private const float _jumpSpeed = 8f;
        private const float _g = 9.8f;
        private const float _movingTresh = 0.1f;
        private const float _jumpTresh = 1f;
        private const float _groindLevel = 0.2f;

        private Vector3 _leftScale = new Vector3(-1,1,1);
        private Vector3 _rightScale = new Vector3(1,1,1);

        private float _yVelocity;
        private bool _isJump;
        private float _xAxisInput;

        LevelObjectView _view;
        SpriteAnimatorController _animatorController;

        public PlayerTransformController(LevelObjectView levelObjectView, SpriteAnimatorController spriteAnimator)
        {
            _view = levelObjectView;
            _animatorController = spriteAnimator;
            _animatorController.StartAnimation(_view._spriteRenderer,AnimState.Idle, true,_animationSpeed);
            Debug.Log(_animatorController.ToString());
        }

        public void Update()
        {
            _isJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _movingTresh;
            _animatorController.Update();
            if (IsGrounted())
            {
                if (Move)
                {
                    MoveTowards();
                    _animatorController.StartAnimation(_view._spriteRenderer, Move ? AnimState.Walk : AnimState.Idle, true, _animationSpeed);
                }

                if (_isJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpSpeed;
                } else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _view._transform.position.Change(y: _groindLevel);
                }
            }
            else
            {
                if (Move) MoveTowards();

                if (Mathf.Abs(_yVelocity)>_jumpTresh)
                {
                    _animatorController.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }

                _yVelocity += _g * Time.deltaTime;
                _view._transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }

        private void MoveTowards()
        {
            _view._transform.position += Vector3.right * (Time.deltaTime * _speed * (_xAxisInput < 0 ? -1 : 1));
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public bool IsGrounted()
        {
            return _view._transform.position.y <= _groindLevel && _yVelocity <= 0;
        }
    }
}
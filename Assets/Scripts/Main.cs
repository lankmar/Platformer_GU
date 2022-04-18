using System.Collections;
using System.Collections.Generic;
using Platformer.Veiw;
using Platformer.Config;
using Platformer.Controllers;
using Platformer.Model;
using UnityEngine;
namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
       // [SerializeField] private int _animSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] Camera _camera;
        [SerializeField] Transform _back;

        private SpriteAnimatorController _playerAnimator;
        PlayerTransformController _playerController;
       // private ParalaxManager _paralaxManager;

        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimations");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            //_playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Walk, true, _animSpeed);
            _playerController = new PlayerTransformController(_playerView, _playerAnimator);
            //_paralaxManager = new ParalaxManager(_camera.transform, _back);
        }

        // Update is called once per frame
        void Update()
        {
            _playerController.Update();
            //_playerAnimator.Update();
            //_paralaxManager.Update();
        }
    }
}
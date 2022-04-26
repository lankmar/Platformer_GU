using System.Collections;
using System.Collections.Generic;
using Platformer.View;
using Platformer.Config;
using Platformer.Controllers;
using Platformer.Model;
using UnityEngine;
namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] Camera _camera;
        [SerializeField] Transform _back;

        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        // private ParalaxManager _paralaxManager;
        private CannonController _cannonController;
        private BulletEmitterController _bulletEmitterController;
        private CameraController _cameraController;


        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimations");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            //_playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Walk, true, _animSpeed);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _cannonController = new CannonController(_cannonView._muzzleTransform, _playerView.transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
            _cameraController = new CameraController(_playerView, Camera.main.transform);
            //_paralaxManager = new ParalaxManager(_camera.transform, _back);
        }

        // Update is called once per frame
        void Update()
        {
            _playerController.Update();
            //_playerAnimator.Update();
            //_paralaxManager.Update();

            _cannonController.Update();
            _bulletEmitterController.Update();
            _cameraController.Update();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Platformer.View;
using Platformer.Config;
using Platformer.Controllers;
using Platformer.Model;
using UnityEngine;
using Pathfinding;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private CharacterStatistics _characterStatistics;
        [SerializeField] private SpriteAnimatorConfig _CoinConfig;
       // [SerializeField] private int _animSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private List<LevelObjectView> _coinViews;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] Camera _camera;
        [SerializeField] Transform _back;
        [SerializeField] EnemyPatrol _enemyPatrol;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private PlayerController _playerController;
        // private ParalaxManager _paralaxManager;
        private CannonController _cannonController;
        private BulletEmitterController _bulletEmitterController;
        private CameraController _cameraController;
        private CoinsController _coinsController;
        private Controllers.CharacterController _characterController;
        private EnemyController _enemyController;


        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimations");
            _CoinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimations");
            _characterStatistics = Resources.Load<CharacterStatistics>("Archer");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _coinAnimator = new SpriteAnimatorController(_CoinConfig);
            //_playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Walk, true, _animSpeed);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _cannonController = new CannonController(_cannonView._muzzleTransform, _playerView.transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform, _playerView);
            _cameraController = new CameraController(_playerView, Camera.main.transform);
            _coinsController = new CoinsController(_playerView, _coinViews, _coinAnimator);
            _characterController = new Controllers.CharacterController(_characterStatistics, _playerView);
            _enemyController = new EnemyController(_enemyPatrol, _enemyPatrol.GetComponent<AIDestinationSetter>());
            //_paralaxManager = new ParalaxManager(_camera.transform, _back);

        }

        // Update is called once per frame
        void Update()
        {
            _playerController.Update();
            _coinAnimator.Update();
            //_playerAnimator.Update();
            //_paralaxManager.Update();

            _cannonController.Update();
            _bulletEmitterController.Update();
            _cameraController.Update();
            _enemyController.Update();
        }
    }
}
using System;
using UnityEngine;
using Platformer.View;
using Platformer.Config;
using System.Collections.Generic;

namespace Platformer.Controllers
{
    public class CoinsController : IDisposable
    {
        private float _animationSpeed = 10;
        private SpriteAnimatorController _spriteAnimator;
        private LevelObjectView _playerView;
        private List<LevelObjectView> _coinViews;

        public CoinsController(LevelObjectView playerView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimator)
        {
            _playerView = playerView;
            _coinViews = coinViews;
            _spriteAnimator = spriteAnimator;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var coin in coinViews)
            {
                _spriteAnimator.StartAnimation(coin._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator?.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;          
        }
    }
}
using UnityEngine;
using Platformer.View;
using System.Collections.Generic;

namespace Platformer.Controllers
{
    public class BulletEmitterController 
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _index;
        private float _timeTillNextBullet;
        
        private float _delay = 1;
        private float _startSpeed = 15;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach (LevelObjectView bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _bullets[_index].Active(false);
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_index].Trow(_transform.position, -_transform.up * _startSpeed);
                _index++;
                if (_index >= _bullets.Count) _index = 0;
            }
        }
    }
}
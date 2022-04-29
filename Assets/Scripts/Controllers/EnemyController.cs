using Pathfinding;
using Platformer.Model;
using UnityEngine;
namespace Platformer.Controllers
{
    public class EnemyController 
    {
        private EnemyPatrol _enemy;
        private AIDestinationSetter _aiDestination;

        private int _pointIndex = 0;
        private bool isPatrol = true;

        public EnemyController(EnemyPatrol enemy, AIDestinationSetter aiDestination)
        {
            _enemy = enemy;
            _aiDestination = aiDestination;

            _aiDestination.target = _enemy.PatrolPoints[_pointIndex];
        }

        public void Update()
        {
            if (Vector3.Distance(_enemy.PlayerTransform.position, _enemy.transform.position) <= _enemy.PlayerDetectionDistance)
            {
                _aiDestination.target = _enemy.PlayerTransform;
            }


            if (Vector3.Distance(_enemy.PlayerTransform.position, _enemy.transform.position) > _enemy.PlayerDetectionDistance && _aiDestination.target == _enemy.PlayerTransform)
            {
                _aiDestination.target = _enemy.PatrolPoints[_pointIndex];
                isPatrol = true;
            }


            if (Vector3.Distance(_enemy.PlayerTransform.position, _enemy.transform.position) > _enemy.PlayerDetectionDistance && Vector3.Distance(_enemy.transform.position, _enemy.PatrolPoints[_pointIndex].position) <= 1f)
            {
                _pointIndex++;
                isPatrol = true;
                if (_pointIndex > _enemy.PatrolPoints.Count - 1)
                {
                    Debug.Log("_pointIndex " + _pointIndex  + "_enemy.PatrolPoints.Count - 1 " + (_enemy.PatrolPoints.Count - 1));
                    _pointIndex = 0;
                }
                _aiDestination.target = _enemy.PatrolPoints[_pointIndex];
            }
        }
    }
}
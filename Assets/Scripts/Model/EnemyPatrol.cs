using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Model
{
    [RequireComponent(typeof(Pathfinding.AIPath), typeof (Pathfinding.AIDestinationSetter))]
    public class EnemyPatrol : MonoBehaviour
    {
        public Transform PlayerTransform;
        public List<Transform> PatrolPoints;
        public float PlayerDetectionDistance = 10;
    }
}
using UnityEngine;
using System;
namespace Platformer.View
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rigidbody;
        public LevelObjectType _objectType;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LevelObjectView levelObject = collision.gameObject.GetComponent<LevelObjectView>();

            OnLevelObjectContact?.Invoke(levelObject);
        }
    }

    public enum LevelObjectType
    { 
        Coin = 1,
        Bullet = 2,
        Mine = 3,
        lizer = 4,
        Door = 5, 
        Trap = 6,
        Enemy = 7
    }
}
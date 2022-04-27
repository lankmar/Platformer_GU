using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Config;
namespace Platformer.View
{
    public sealed class TrapView : LevelObjectView
    {
        [SerializeField] List<Transform> objects;
        private float angular = 0f;
        

        void Update()
        {
            
            foreach (var item in objects)
            {
                item.rotation = Quaternion.Euler(0f, 0f, angular);
            }
            angular -= 2.3f;
        }
    }
}
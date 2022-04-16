using System;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Config
{
    public enum AnimState
    { 
        Idle =0,
        Walk = 1,
        Attack = 2,
        Jump = 3,
        Death = 4
    }
    [CreateAssetMenu (fileName = "SpriteAnimatorConfig", menuName = "Configs / Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState State;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}
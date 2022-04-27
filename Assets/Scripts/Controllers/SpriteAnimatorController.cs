using System;
using System.Collections.Generic;
using Platformer.Config;
using UnityEngine;
namespace Platformer.Controllers
{
    public class SpriteAnimatorController : IDisposable
    {
        public sealed class Animation
        {
            public AnimState State;
            public List<Sprite> Sprites;
            public bool Loop;
            public float Speed = 1;
            public float Counter = 0;
            public bool Sleep;

            public void Update()
            {
                if (Sleep) return;
                Counter += Time.deltaTime * Speed;
                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleep = true;
                }
            }
        }

        private SpriteAnimatorConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimatorController(SpriteAnimatorConfig config)
        {
            _config = config;
        }
        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState state, bool loop, float speed)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Counter = 0;
                if (animation.State != state)
                {
                    animation.State = state;
                    animation.Sprites = _config.Sequences.Find(sequences => sequences.State ==state).Sprites;
                    animation.Speed = speed;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    State = state,
                    Sprites = _config.Sequences.Find(sequences => sequences.State == state).Sprites,
                    Loop = loop,
                    Speed = speed

                });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimation.ContainsKey(sprite))
            {
                _activeAnimation.Remove(sprite);
            }
        }
        
        public void Update()
        {
            
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Update();
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }

        }

        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}
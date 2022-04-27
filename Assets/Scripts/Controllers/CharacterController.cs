using Platformer.Model;
using Platformer.View;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CharacterController 
    {
        private CharacterStatistics _characterConfig;
        private LevelObjectView _playerView;
        private Vector3 _startPosotion;
       
        private const int MaxLifes = 3;
        private const int MaxHealth = 100;
        private const int MaxShildCount = 5;
        private const int StartCoinNumber = 0;


        public CharacterController(CharacterStatistics config, LevelObjectView playerView)
        {
            _characterConfig = config;
            _startPosotion = playerView.transform.position;
            _playerView = playerView;

            _characterConfig.coinNumber = StartCoinNumber;
            _characterConfig.livesNumber = MaxLifes;
            _characterConfig.health = MaxHealth;
            _characterConfig.shildCount = MaxShildCount - 2;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (contactView._objectType == LevelObjectType.Coin)
            {
                _characterConfig.coinNumber++; 
            }
            if (contactView._objectType == LevelObjectType.Bullet)
            {
                _characterConfig.health -= 40;
                if (_characterConfig.health <=0)
                {
                    _playerView._transform.position = _startPosotion;
                    _characterConfig.health = MaxHealth;
                    _characterConfig.livesNumber--;
                }
            }
            if (contactView._objectType == LevelObjectType.Trap)
            {
                _playerView._transform.position = _startPosotion;
                _characterConfig.health = MaxHealth;
                 _characterConfig.livesNumber--;
                   
               
            }


            if (_characterConfig.livesNumber <= 0)
            {
                Debug.Log("End Game");
            }
        }
    }
}
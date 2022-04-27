using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Model
{
    [CreateAssetMenu(fileName = "CharacterStatistics", menuName = "Character / Statistics", order = 2)]
    public class CharacterStatistics : ScriptableObject
    {
        public string characterName;
        public int livesNumber;
        public int coinNumber;
        public int health;
        public int shildCount;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technoire
{
    [CreateAssetMenu]
    public class PlayerData : CharacterData
    {
        public enum PlayerClass
        {
            StreetSamurai, SlumShaman, Techie, Fixer, RockerBoy, Nomad, Corp
        };

        public PlayerClass playerClass;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Technoire.BattleSystem.Attacks
{
    [System.Serializable]
    public class AttackContainter : MonoBehaviour
    {
        public AttackData primaryAttackData;
        public AttackData secondaryAttack;

        public List<AttackObject> attackList = new List<AttackObject>();
        //make list for all sub cats eventually;

        private void OnEnable()
        {
            foreach (AttackObject attackObject in attackList)
            {
                attackObject.SetData(attackObject.data);
            }
        }

    }
}


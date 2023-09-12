using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Technoire.BattleSystem.Attacks;

namespace Technoire.BattleSystem.Animations
{
    public class CombatAnimationManager : MonoBehaviour
    {
        private Animator animator;
        const string RANGED_ATTACK = "RangedAttack";
        const string IDLE_COMBAT_PISTOL = "IdleCombatPisol";
        bool playLoopBriefly;

        public string currentAnimation;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            AnimationChanger(IDLE_COMBAT_PISTOL);
        }

        private void OnEnable()
        {
            CombatEvents.UsePrimaryAttack += CheckplayLoopBriefly;
        }

        private void Update()
        {
            AnimationChanger(IDLE_COMBAT_PISTOL);
            if (playLoopBriefly && currentAnimation == IDLE_COMBAT_PISTOL)
            {
                AnimationChanger(RANGED_ATTACK);
                playLoopBriefly = false;
            }
            //Add melee animation here when there is one
        }

        void AnimationChanger(string newAnimation)
        {
            if (currentAnimation == newAnimation) return;
            {
                animator.Play(newAnimation);
                currentAnimation = newAnimation;
            }
        }

        void CheckplayLoopBriefly()
        {
            playLoopBriefly = true;
        } 
    }
}


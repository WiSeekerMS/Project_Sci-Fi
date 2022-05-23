using Assets.Scripts.BaseClasses;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CharacterAnimation : AnimationController
    {
        private static readonly int IdleID = Animator.StringToHash("Idle");
        private static readonly int RunID = Animator.StringToHash("IsRun");
        private static readonly int LeftTurnID = Animator.StringToHash("IsLeftTurn");
        private static readonly int RightTurnID = Animator.StringToHash("IsRightTurn");

        public void SetRunAnimation()
        {
            SetAnimation(RunID, true);
        }

        public void SetIdleAnimation()
        {
            SetAnimation(RunID, false);
        }

        public void SetTurnLeftAnimation()
        {
            SetAnimation(LeftTurnID, true);
        }

        public void SetTurnRightAnimation()
        {
            SetAnimation(RightTurnID, true);
        }
    }
}
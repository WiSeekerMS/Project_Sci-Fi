using Assets.Scripts.BaseClasses;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CharacterAnimation : AnimationController
    {
        private static readonly int RunID = Animator.StringToHash("IsRun");

        public void SetRunAnimation()
        {
            SetAnimation(RunID, true);
        }

        public void SetIdleAnimation()
        {
            SetAnimation(RunID, false);
        }
    }
}
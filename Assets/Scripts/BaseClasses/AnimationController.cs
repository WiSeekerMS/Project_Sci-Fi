using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        protected Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected void SetAnimation(int id, bool value)
        {
            if (animator) animator.SetBool(id, value);
        }

        protected void SetAnimation(int id)
        {
            if (animator) animator.SetTrigger(id);
        }
    }
}
using UnityEngine;

namespace UnityComponents.Animation
{
    public sealed class EnemyAnimator : MonoBehaviour
    {
        private static readonly int WalkHash = Animator.StringToHash("Walk");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        [SerializeField] private Animator animator;

        public void Walk()
        {
            animator.SetTrigger(WalkHash);
        }

        public void Idle()
        {
            animator.SetTrigger(IdleHash);
        }
    }
}
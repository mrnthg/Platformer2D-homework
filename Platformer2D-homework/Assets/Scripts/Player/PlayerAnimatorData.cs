using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Parameters
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    }
}

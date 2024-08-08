using UnityEngine;

public class MenuPlayerAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idel Animation");
    }
}

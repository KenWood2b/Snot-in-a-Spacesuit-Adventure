using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private MoveComponent moveComponent;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveComponent = GetComponent<MoveComponent>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        moveComponent.Move(moveInput);

        if (moveInput != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}

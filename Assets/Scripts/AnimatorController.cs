using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
     public ParticleSystem doubleJumpEffect;

    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);
       
        if (Input.GetKeyDown(KeyCode.Space) && characterMovement.jumpCount == 2)
        {
            // play double jump animation with particle system
            animator.SetTrigger("doFlip");
            doubleJumpEffect.Play();
            if (characterMovement.IsGrounded)
            {
                characterMovement.jumpCount = 0; // reset double jump counter
            }
        }
    }
}

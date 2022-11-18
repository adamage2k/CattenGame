using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    [SerializeField] GameObject sword;

    public AudioSource jump;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && PlayerMovement.isTouchingGround)
        {
            animator.SetTrigger("takeOf");
            Debug.Log("You are jumping!");
            JumpSound();
        }

        if (PlayerMovement.isTouchingGround)
        {
            animator.SetBool("isJump", false);
            //sword.GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            animator.SetBool("isJump", true);
            //sword.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }
        else
        {
            animator.SetFloat("moveSpeed", 0f);
        }

        if (Input.GetAxis("Horizontal") > 0.01f || PlayerMovement.playerPosition.x < FollowMouse.mouseWorldPosition.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") <= -0.01f || PlayerMovement.playerPosition.x > FollowMouse.mouseWorldPosition.x)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (Input.GetAxis("Horizontal") <= -0.01f && PlayerMovement.playerPosition.x < FollowMouse.mouseWorldPosition.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void JumpSound() 
    {
        jump.Play();
    }

}

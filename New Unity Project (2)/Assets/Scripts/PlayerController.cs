using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    private Vector3 movement;
    public float gravityScale;
    private int frameCountSince;
    Animator anim;
    private float canJump = 0f;
    private float timeTransition = 1.5f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed, moveDirection.y, CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed);
	movement = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal")*moveSpeed, 0.0f, CrossPlatformInputManager.GetAxis("Vertical")*moveSpeed);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
		if (controller.isGrounded && Time.time > canJump)
		{
			anim.SetBool("IsJump", true);
                	moveDirection.y = jumpForce;
			canJump = Time.time + .75f;
		}
        }

	if (moveDirection.y <= .5)
	{
		anim.SetBool("IsJump", false);
	}

	if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)
	{
		anim.SetBool("IsMove", true);
	}
	else
	{
		anim.SetBool("IsMove", false);
	}

	if (movement != Vector3.zero)
	{
        	transform.rotation = Quaternion.LookRotation(movement);
	}

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

	if (gameObject.transform.position.y < -10)
	{
		timeTransition -= Time.deltaTime;
		if(timeTransition <= 0)
		{
			SceneManager.LoadScene("LoseScreen");
		}
	}
	}
}

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
    public float gravityScale;
    private int frameCountSince;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed, moveDirection.y, CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

	if (gameObject.transform.position.y < -10)
	{
		SceneManager.LoadScene("LoseScreen");
	}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour {
	Animator anim;
	private float timeTran = 1.5f;
	private int isDone = 0;

	// Use this for initialization
	void Start () {
		anim = FindObjectOfType<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDone == 1)
		{
			timeTran -= Time.deltaTime;
			if(timeTran <= 0)
			{
				SceneManager.LoadScene("WinScreen");
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			anim.SetBool("HasWon", true);
			FindObjectOfType<PlayerController>().DestroyIt();
			isDone = 1;
		}
	}
}

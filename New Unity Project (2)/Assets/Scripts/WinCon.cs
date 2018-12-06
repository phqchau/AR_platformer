using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = FindObjectOfType<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			anim.SetBool("HasWon", true);
		}
	}
}

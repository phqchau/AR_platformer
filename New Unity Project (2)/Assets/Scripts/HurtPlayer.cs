using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive = 1;
	Animator anim;
	private float timeTrans = 1f;
	private int isFin = 0;

	// Use this for initialization
	void Start () {
		anim = FindObjectOfType<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFin == 1)
		{
			timeTrans -= Time.deltaTime;
			if(timeTrans <= 0)
			{
				SceneManager.LoadScene("LoseScreen");
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			anim.SetBool("IsDead", true);
			FindObjectOfType<PlayerController>().DestroyIt();
			isFin = 1;
			FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
		}
	}
}

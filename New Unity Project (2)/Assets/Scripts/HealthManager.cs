using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	private bool isRespawning;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HurtPlayer(int damage)
	{
		currentHealth -= damage;
	}
}

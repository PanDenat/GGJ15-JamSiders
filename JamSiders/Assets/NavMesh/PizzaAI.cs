using System;
using UnityEngine;
using System.Collections;

public class PizzaAI : MonoBehaviour
{
	public bool FirstWave;
	
	// Use this for initialization
	void Start ()
	{
		if (FirstWave)
			PizzaManager.instance.OnDeliverPizza += PizzeHere;
		else
			PizzaManager.instance.OnEatePizza += PizzeAgainHere;
	}

	private void PizzeAgainHere()
	{
		GetComponent<DestinationChecker>().Tag = "Pizza";
		GetComponent<Walker>().destination = null;
		PizzaManager.instance.OnDeliverPizza -= PizzeHere;

	}

	private void PizzeHere()
	{
		GetComponent<DestinationChecker>().Tag = "Pizza";
		GetComponent<Walker>().destination = null;
		PizzaManager.instance.OnEatePizza -= PizzeAgainHere;

	}
}

using System;
using UnityEngine;
using System.Collections;

public class PizzaManager : MonoBehaviour
{
	public static PizzaManager instance;

	public float WaitingTime;

	public Action OnDeliverPizza;
	public Action OnEatePizza;

	void Awake()
	{
		instance = this;
		StartCoroutine(WaitForPizza() );
	}
	IEnumerator WaitForPizza()
	{
		yield return new WaitForSeconds(WaitingTime);
		if (OnDeliverPizza!=null)
			OnDeliverPizza();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			if (OnDeliverPizza != null)
				OnDeliverPizza();
		if (Input.GetKeyDown(KeyCode.Return))
			if (OnEatePizza != null)
				OnEatePizza();
	}

	public void PizzaEaten()
	{
		OnEatePizza();
	}
}

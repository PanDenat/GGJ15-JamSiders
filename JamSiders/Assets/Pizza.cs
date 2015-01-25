using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			StartCoroutine(EatingPizza());
	}

	IEnumerator EatingPizza()
	{
		yield return new WaitForSeconds(2f);
		PizzaManager.instance.PizzaEaten();
	}
}

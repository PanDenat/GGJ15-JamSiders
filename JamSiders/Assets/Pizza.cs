using UnityEngine;
using System.Collections;

public class Pizza : MonoBehaviour
{
    bool triggered;

	void OnCollisionEnter(Collision other)
	{
        Debug.Log("Pizza collided with " + other.gameObject.name + " tagged "
            + other.gameObject.tag + (other.gameObject.tag == "Player" ? "==" : "!=") + "Player");
        if (triggered == false && other.gameObject.tag == "Player")
        {
            Debug.Log("Pizza triggered!");
            StartCoroutine(EatingPizza());
            triggered = true;
        }
	}

	IEnumerator EatingPizza()
	{
		yield return new WaitForSeconds(2f);
		PizzaManager.instance.PizzaEaten();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCaller : MonoBehaviour
{

	public UnityEngine.UI.Text Text;
	public GameObject Cloud;
	private static List<string> Messages;

	void Awake()
	{
		if (Messages != null)
			return;
		Messages = new List<string>();
		Messages.Add("Gdzie moja emka!?");
		Messages.Add("Pizza!!!!");
		Messages.Add("Pizza!");
		Messages.Add("Ide się umyć!");
		Messages.Add("Spanie jest dla słabych");
		Messages.Add("Zajęte");
		Messages.Add("Spadaj!");
		Messages.Add("Jeszcze jeden poziom...");
		Messages.Add("A co ja tu widzę?");

	}

	public void Update()
	{
		Cloud.transform.LookAt(Camera.main.transform);
		if (Cloud.activeSelf == false && rigidbody.velocity.y<-9)
		{
			Say();
		}
		if (transform.position.y < -20)
			Cloud.SetActive(false);
	}
	public void Say()
	{
		Cloud.SetActive(true);
		Text.text = GetMessage();
	    StartCoroutine(HideMessage());
	}

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3);
        Cloud.SetActive(false);
    }

	private string GetMessage()
	{
		return Messages[Random.Range(0, Messages.Count)];
	}

	public void SayPizza()
	{
		Cloud.SetActive(true);
		Text.text = "Pizza!";
		StartCoroutine(HideMessage());
	}
}

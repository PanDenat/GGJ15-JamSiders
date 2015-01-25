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
		if (Cloud.activeSelf == false && rigidbody.velocity.y<-5)
		{
			Say();
		}
	}
	public void Say()
	{
		Cloud.SetActive(true);
		Text.text = GetMessage();
	}

	private string GetMessage()
	{
		return Messages[Random.Range(0, Messages.Count)];
	}
}

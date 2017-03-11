using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void PeopleVsPeople (string sceneToChangeTo)
	{
		Application.LoadLevel (sceneToChangeTo);
	}
	public void PeopleVsComputer (string sceneToChangeTo)
	{

		Application.LoadLevel (sceneToChangeTo);
	}
	public void Menu (string sceneChangeTo)
	{
		Application.LoadLevel (sceneChangeTo);
	}
}

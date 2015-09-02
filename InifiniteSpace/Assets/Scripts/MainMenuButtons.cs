using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour 
{
	public void StartGame()
	{
		Application.LoadLevel ("FirstTestScene");
	}

	public void Exit()
	{
		Application.Quit();
	}

}

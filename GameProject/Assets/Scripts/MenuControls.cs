using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour {

	public void PlayPressed()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void SettingsPressed(GameObject MainMenu, GameObject Settings)
	{
		MainMenu.SetActive(false);
		Settings.SetActive(true);

	}

	public void ExitPressed()
	{
		Debug.Log("Exit pressed!");
		Application.Quit();
	}
}

using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartClick(){
		//print ("Game Started");
		Time.timeScale = 0.8f;
		Birds._gameManager.SendMessage ("CallCountDown");
		GameObject.Find ("StartButton").gameObject.SetActive (false);

	}

	public void OnRestartClick(){
		Application.LoadLevel (0);
	}
}

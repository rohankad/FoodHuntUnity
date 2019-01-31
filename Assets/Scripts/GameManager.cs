using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	GameObject[] _Prey, _SpwanPoints;
	public static int preyCount, spawnCount;
	public float _throwTime;
	public Text _scoreText, _countDown;
	public Button _restart;
	public GameObject _blastEffect, _timeBar;
	int score;
	public int _ThrowSpeed;




	// Use this for initialization
	void Start () {

		_Prey = GameObject.FindGameObjectsWithTag ("Prey");
		_SpwanPoints = GameObject.FindGameObjectsWithTag ("SpawnPoints");
		preyCount = _Prey.Length;
		spawnCount = _SpwanPoints.Length;
		_throwTime = (_throwTime == 0) ? 1 : _throwTime;

		_scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		_restart = GameObject.Find ("RestartButton").GetComponent<Button> ();
		_restart.gameObject.SetActive (false);
		_countDown.gameObject.SetActive (false);
		_timeBar.SetActive (false);

		if (_ThrowSpeed == null || _ThrowSpeed == 0) {
			_ThrowSpeed=600;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			CallThrowBirds();
		}
		//print ("_timeBar.activeInHierarchy : "+_timeBar.activeInHierarchy);
		if (SliderValue._SliderValue <= 0 && Globals.gameStarted) {
			Globals.gameStarted=false;
			StopAllCoroutines();
			_restart.gameObject.SetActive(true);
			_timeBar.SetActive(false);
		}

	}

	public void CallThrowBirds(){
		if (Globals.gameStarted)
			StartCoroutine ("ThrowUpBirds");
	}

	public void CallCountDown(){
		Globals._SliderVal = 1;
		StartCoroutine ("CountDown");
	}

	IEnumerator CountDown(){
		_countDown.gameObject.SetActive (true);

		for (int i=5; i>0; i--) {
			_countDown.text = "Starting in "+i +" Seconds!";
//				yield return new WaitForSeconds(1);
				yield return new WaitForSeconds(1f);
		}

		Globals.gameStarted = true;
		_countDown.gameObject.SetActive(false);
		CallThrowBirds();

	}

	IEnumerator ThrowUpBirds(){
		//print ("ThrowUpBirds ");
		if (Globals.gameStarted) {
		
		//	if(_timeBar.activeInHierarchy==false){
				//print ("activeInHierarchy false ");
				_timeBar.SetActive(true);
				int tempI=0;

				for(int i=0; i<preyCount;i++){
					_Prey[i].transform.position = _SpwanPoints[tempI++].transform.position;
				_Prey[i].GetComponentInChildren<SkinnedMeshRenderer>().enabled =true;
					//_Prey[i].GetComponent<Rigidbody>().gravityScale=1;
					_Prey[i].GetComponent<Rigidbody>().useGravity = true;
				_Prey[i].GetComponent<Rigidbody>().AddForce(_SpwanPoints[tempI-1].transform.up*_ThrowSpeed);
				//_Prey[i].GetComponent<Rigidbody>().velocity=Vector3.up * _ThrowSpeed;
					tempI = (tempI>=spawnCount)?0:tempI;
					yield return new WaitForSeconds(_throwTime);
				}

			//}
		}
	}

	public void IncrementScore(int value){
		score = score + value;
		_scoreText.text = "Score : " + score;
	}
}

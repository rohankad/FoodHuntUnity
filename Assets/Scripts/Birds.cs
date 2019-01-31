using UnityEngine;
using System.Collections;

public class Birds : MonoBehaviour {

	public static GameObject _gameManager;
	public enum mouseEnum{
		up,
		down
	}
	public mouseEnum mouseState;

	private Vector3 EnterPos, ExitPos;
	private float cutDistance;
	private float birdRadius;

	public GameObject _ParticleGameObject;

	public ParticleSystem _particles;
	private AudioSource _KnifeCutSound;

	// Use this for initialization
	void Start () {
		_KnifeCutSound = this.GetComponent<AudioSource> ();
		_gameManager = GameObject.Find ("GameManager");
		mouseState = mouseEnum.up;
		birdRadius = gameObject.GetComponent<SphereCollider> ().radius;
		_ParticleGameObject = GameObject.Find (this.gameObject.name+"/arcaneExplosionBase/arcaneFlash");


		//_particles = _ParticleGameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseState = mouseEnum.down;
		}else if(Input.GetMouseButtonDown(0)){
			mouseState = mouseEnum.up;
		}
	}

	void OnMouseDown(){
		print ("---------Touch Detected------");

		GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		_gameManager.SendMessage("IncrementScore",1);
	}

	/*void OnTriggerEnter(Collider tEnter) {
		if (mouseState == mouseEnum.up) {
			return;
		}

		if (tEnter.gameObject.tag == "Trail") {
			print ("Trail Enter");
			//_KnifeCutSound.Play(); play music
			EnterPos = tEnter.transform.position;
		}
	} */

	/*void OnTriggerExit(Collider tExit) {
		if (mouseState == mouseEnum.up) {
			return;
		}
		print ("Trail Exit : "+birdRadius);
		if (tExit.gameObject.tag == "Trail") {

			ExitPos = tExit.transform.position;
		
			cutDistance = Vector3.Distance(EnterPos, ExitPos);
		
			if(cutDistance >(birdRadius)){

				if(Time.timeScale > 0 && GetComponentInChildren<SkinnedMeshRenderer>().enabled ){
					GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

					//Explode(); play particles

					if(gameObject.name =="Donuts"){
						_gameManager.SendMessage("IncrementScore",3);
					} else if(gameObject.name =="HamEgg"){

					}else{

						_gameManager.SendMessage("IncrementScore",1);
					}
				}
			}

		}
	} */

	private void Explode(){

		_particles.Play ();
	}

}

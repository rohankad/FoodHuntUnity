using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	int count;
	// Use this for initialization
	void Start () {
		Debug.Log("preyCount : "+GameManager.preyCount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnTriggerEnter(Collider _obj) {
//		if (_obj.transform.tag == "Prey") {
//			count++;
//			Debug.Log("Count : "+count);
//			_obj.GetComponent<Rigidbody>().useGravity =false; //GravityScale = 0 in 2D
//			_obj.GetComponent<Rigidbody>().Sleep();
//
//			if(count==GameManager.preyCount){
//
//				count=0;
//				Birds._gameManager.SendMessage("CallThrowBirds");
//			}
//
//		}
//
//	}

	void OnCollisionEnter(Collision _obj) {
		if (_obj.transform.tag == "Prey") {
			count++;
		//	Debug.Log("Count : "+count);


				_obj.gameObject.GetComponent<Rigidbody>().useGravity =false; //GravityScale = 0 in 2D
				_obj.gameObject.GetComponent<Rigidbody>().Sleep();

			if(count==GameManager.preyCount){
			//	Debug.Log("Throw birds again");
				count=0;
				Birds._gameManager.SendMessage("CallThrowBirds");
			}

		}

	}
}

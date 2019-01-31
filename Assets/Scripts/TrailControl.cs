using UnityEngine;
using System.Collections;

public class TrailControl : MonoBehaviour {

	public Transform _target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0)){
			Vector3 _pos = Input.mousePosition;
			Vector3 _temp = Camera.main.WorldToScreenPoint(_target.position);
			//_target.position = Camera.main.ScreenToWorldPoint(new Vector3(_pos.x, _pos.y, _temp.z));
			  _target.position = Camera.main.ScreenToWorldPoint(new Vector3(_pos.x, _pos.y, _temp.z));
		}
	}
}

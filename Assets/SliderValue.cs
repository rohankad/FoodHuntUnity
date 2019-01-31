using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

	public static float _SliderValue;
	Slider _slider;
	public float _timeDelay;
	// Use this for initialization
	void Start () {
		_slider = GetComponent<Slider> ();
		_SliderValue = _slider.value;

	}
	
	// Update is called once per frame
	void Update () {
		//_slider.value = _SliderValue;
		_SliderValue = Mathf.MoveTowards (_slider.value, 0f, _timeDelay*Time.deltaTime);
		_slider.value = _SliderValue;

	}
}

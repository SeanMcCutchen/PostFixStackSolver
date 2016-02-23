using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class NewBehaviourScript : MonoBehaviour {

	string problem2 = "[2*(6/2)+(3^2)]";
	Text value;
	public int counter = 0;

	// Use this for initialization
	void Start () {
		value = gameObject.GetComponent<Text>();
		value.text="Value: ";
	}
	
	// Update is called once per frame
	void Update () {
		value.text = "Value to consider: " + problem2[counter];

		if(Input.GetMouseButtonDown(0))
			counter++;
	}
	public void OnClicked()
	{
		counter++;
	}

}

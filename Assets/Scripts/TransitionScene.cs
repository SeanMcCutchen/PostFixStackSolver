using UnityEngine;
using System.Collections;

public class TransitionScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadDemoModes() {
		Application.LoadLevel ("Demos");
	}

	public void loadPracticeMode() {
		Application.LoadLevel ("practice");
	}


	public void loadMainMenu() {
		Application.LoadLevel ("mainmenu");
	}

	public void loadBracket() {
		Application.LoadLevel ("bracket");
	}

	public void loadEasy() {
		Application.LoadLevel ("EasyDemo");
	}

	public void loadHard() {
		Application.LoadLevel ("HardDemo");
	}
	public void loadInvalid() {
		Application.LoadLevel ("InvalidDemo");
	}
}

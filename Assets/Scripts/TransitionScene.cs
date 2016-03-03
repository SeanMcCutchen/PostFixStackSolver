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
		Application.LoadLevel ("BracketDemo");
	}

	public void loadEasy() {
		Application.LoadLevel ("EasyDemo");
	}

	public void loadHard() {
		Application.LoadLevel ("HardDemo");
	}
	/*
	public void loadOptions() {
		Application.LoadLevel ("Options");
	}

	public void loadLearningMode() {
		Application.LoadLevel ("LearningMode");
	}

	public void loadPauseScreen () {
		Application.LoadLevel ("PauseMenu");
	}
*/
}

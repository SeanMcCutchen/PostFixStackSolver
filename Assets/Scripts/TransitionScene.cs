using UnityEngine;
using System.Collections;

public class TransitionScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadDemoMode() {
		Application.LoadLevel ("demo");
	}

	public void loadPracticeMode() {
		Application.LoadLevel ("practice");
	}


	public void loadMainMenu() {
		Application.LoadLevel ("mainmenu");
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

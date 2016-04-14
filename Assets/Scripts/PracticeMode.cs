using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;
public class PracticeMode : MonoBehaviour {

	//var expr = new List<Type>();


	List<string> expr = new List<string>{"1 + ( 52 - 34 ) ", "[ ( 5 + 7 ) * ( 23 - 5 ) ]", "100 / ( 5 * 4 ) ","[ ( 2 ^ 3 ) - 8 ]"
		, "5 * 8 - 8 / 4", "( 55 / 5 + 27 ) + 5 ^ 2", "55 / 5 - 10", "[1 + ( 5 * 8 - 10 ) / 6 ] "
		, "[ ( 5 ^ 3 ^ 2 ) / ( 100 - 19 * 5 ) ]", "( 3 ^ 2 ^ 3 ) ",
		"50 - ( 3 + 7 * 4 / 2 ) ", "[ ( 5 ^ 2 ) / 5 ] ", 
		"( 20 * 3 + 4 ) / ( 2 ^ 3 ) ", " 50 * 3 / 25 + 37 ", "5 * ( 30 / 6 + 22 ) ", 
		"120 / ( 6 * 5 * 2 ) ", "( ( ( 1 + 2 ) * 3 ) + 6 ) / ( 2 + 3 ) ", "( 8 / 4 ) / ( 120 / 60 ) ",
		"[ ( 5 ^ 3 ) / 5 ^ 2 ] ", "8 * 10 / 20 + 3 ", "[ ( 7 * 5 ) + ( 3 ^ 4 ) ]", "5 ^ 3 ^ 2 ",
		"[ ( 2 ^ 3 + 2 ^ 4 ) / 4 ] ", "( ( ( 7 + 2 ) * 3 ) + 6 ) / ( 2 + 1 ) ", "[ ( 2 ^ 3 ) * ( 43 - 11 * 3 ) ] ",
		"( 3 * 5 ^ 3 ) / 25", "45 * 2 / 9 + 3 - 11 ", "[ ( 45 / 5 * 10 ) / ( 33 / 11 ) ] ",
		"[ ( 5 ^ 3 ) / ( 50 / 10 ) + 27 ] ", "( 2 ^ 4 ) / ( 4 ^ 2 )", "5 + 44 / 4 - 7 ",
		"[ ( 5 ^ 2 + 5 * 20 ) / ( 125 / 5 ) ] ", "( 8 ^ 2 ) / 4 + 3 ^ 4 ", "[ 2 ^ ( 60 / 30 + 2 ) ] ", 
		"[ ( 4 * 5 + 7 ) / ( 3 ^ 2 ) ] ", "30 * 2 / 15 + 37 ", "4 ^ 2 + 18 / 2 ", "[ ( 4 + 33 ) + ( 124 / 4 ) ] ",
		"[ 5 * 3 / ( 7 - 2 ) ] " };                   
	List<string> postfixes = new List<string>{"1 52 34 - +", "5 7 + 23 5 - *","100 5 4 * /", "2 3 ^ - 8", "5 8 * 8 4 / -",
		"55 5 / 27 + 5 2 ^ +",
		"55 5 / 10 -"," 1 5 8 * 10 - 6 / +"," 5 3 ^ 2 ^ 100 19 5 * - /"," 3 2 ^ 3 ^",
		"50 3 7 4 * 2 / + -", "5 2 ^ 5 /", "20 3 * 4 + 2 3 ^ / ", "50 3 * 25 / 37 +"," 5 30 6 / 22 + *", 
		"120 6 5 * 2 * /" ," 1 2 + 3 * 6 + 2 3 + /"," 8 4 / 120 60 / /", "5 3 ^ 5 2 ^ /",
		"8 10 * 20 / 3 +", "7 5 * 3 4 ^ +"," 5 3 ^ 2 ^"," 2 3 ^ 2 4 ^ + 4 /", "7 2 + 3 * 6 + 2 1 + /",
		"2 3 ^ 43 11 3 * - *"," 3 5 3 ^ * 25 /","45 2 * 9 / 3 + 11 -"," 45 5 / 10 * 33 11 / /",
		"5 3 ^ 50 10 / / 27 +", "2 4 ^ 4 2 ^ /"," 5 44 4 / + 7 -", "5 2 ^ 5 20 * + 125 5 / /",
		"8 2 ^ 4 / 3 4 ^ +"," 2 60 30 / 2 + ^"," 4 5 * 7 + 3 2 ^ /"," 30 2 * 15 / 37 +", 
		"4 2 ^ 18 2 / +", "4 33 + 124 4 / +", "5 3 * 7 2 - /"}; 
	MyStack m = new MyStack ();
	public Text postfixString;
	public Text currvalue=0;
	private int probindex =0; 
	List<Rect> rects = new List<Rect>();

	String [] test;
	int curr = 0;
	// Use this for initialization
	void Start () {
		test = expr [probindex].Split (' ');


	}

	
	// Update is called once per frame
	void Update () {
		currvalue.text = test [currvalue];
		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 90;
				rects[i] = temp;
			}
			rects.Add (new Rect (125, 100, 150, 75));
			//Debug.Log ("adding rect");
			
			
		} else if (rects.Count > m.size () ) {
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y -= 90;
				rects[i] = temp;
			}
			rects.RemoveAt(rects.Count-1);
			//Debug.Log ("removing rect");
		}

	}

	void OnGUI () {
		GUIStyle style = new GUIStyle (GUI.skin.button);
		style.fontSize = 24;
		if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i) + "", style);
			}		

			
		} else if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i) + "", style);
			}		
		}
	}
			
		
	

}

﻿using UnityEngine;
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
	List<string> postfixes = new List<string>{"1 52 34 - + ", "5 7 + 23 5 - * ","100 5 4 * / ", "2 3 ^ - 8 ", "5 8 * 8 4 / - ",
		"55 5 / 27 + 5 2 ^ + ",
		"55 5 / 10 - "," 1 5 8 * 10 - 6 / + "," 5 3 ^ 2 ^ 100 19 5 * - / "," 3 2 ^ 3 ^ ",
		"50 3 7 4 * 2 / + - ", "5 2 ^ 5 / ", "20 3 * 4 + 2 3 ^ / ", "50 3 * 25 / 37 + "," 5 30 6 / 22 + * ", 
		"120 6 5 * 2 * / " ," 1 2 + 3 * 6 + 2 3 + / "," 8 4 / 120 60 / / ", "5 3 ^ 5 2 ^ / ",
		"8 10 * 20 / 3 + ", "7 5 * 3 4 ^ + "," 5 3 ^ 2 ^ "," 2 3 ^ 2 4 ^ + 4 / ", "7 2 + 3 * 6 + 2 1 + / ",
		"2 3 ^ 43 11 3 * - * "," 3 5 3 ^ * 25 / ","45 2 * 9 / 3 + 11 - "," 45 5 / 10 * 33 11 / / ",
		"5 3 ^ 50 10 / / 27 + ", "2 4 ^ 4 2 ^ / "," 5 44 4 / + 7 - ", "5 2 ^ 5 20 * + 125 5 / / ",
		"8 2 ^ 4 / 3 4 ^ + "," 2 60 30 / 2 + ^ "," 4 5 * 7 + 3 2 ^ / "," 30 2 * 15 / 37 + ", 
		"4 2 ^ 18 2 / + ", "4 33 + 124 4 / + ", "5 3 * 7 2 - / "}; 
	MyStack m = new MyStack ();
	public Text infixString;
	public Text postfixString;
	public Text currvalue;
	public Text validity;

	private int probindex =0; 
	List<Rect> rects = new List<Rect>();
	//List<string> pops = new List<string> ();
	String postfix;
	String [] test;
	String popped;
	public Button check1;
	public Button check2;
	public Button applyOP;
	public Button append;

	double temp1;
	double temp2;
	double temp3;
	bool isdone = false;
	bool check = false;
	int curr = 0;
	int currFix = 0;
	String theiranswer = "";
	// Use this for initialization
	void Start () {
		test = expr [probindex].Split (' ');
		applyOP.gameObject.SetActive(false);
		//check2.gameObject.SetActive(false);
	}

	
	// Update is called once per frame
	void Update () {
		if (check != true) {
			postfixString.text = postfix;
			infixString.text = "Infix String: " + expr [probindex];
		}
		if(isdone!=true && check != true)
			currvalue.text = "Current Value: " + test [curr];
		if (isdone == true) {
			
			check2.gameObject.SetActive(true);
			check1.gameObject.SetActive(false);
			append.gameObject.SetActive(false);


		}
		if (curr == test.Length - 1) {
			theiranswer = postfix;
			m = new MyStack ();
			isdone = true;
		}
	
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
	int postcurr = 0;
	public void pushToStack ()
	{
		if (isdone==true) {
			String[] splitit = theiranswer.Split (' ');
			m.push(splitit[postcurr]);
			postcurr++;
		}
		if (curr < test.Length) {
			m.push (test [curr]);
			curr++;
		} 


		
	}
	public void appendToString()
	{
		if (curr < test.Length) {
			postfix = string.Concat (postfix,  test [curr] + " ");
			curr++;
		}
	}

	public void popStack()
	{
		if (m.isEmpty() == false)
			popped = m.pop();
			if(popped != "(" && popped != "[" && popped != ")" && popped != "]")
			postfix = string.Concat (postfix,  popped + " " );
	}

	public void checkpostfix() {
		Debug.Log (postfix);
		Debug.Log (postfixes [currFix]);
		if (postfix == postfixes [currFix])
		{
			check = true;
			infixString.text = "Postfix String: " + postfix;
			postfixString.text = "";
			currvalue.text = "";
			test = postfix.Split (' ');
			validity.text = "Correct postfix expression!";
		}
		else
			validity.text = "Incorrect postfix expression";

	}
	public void toggle() {
		append.gameObject.SetActive(false);
		applyOP.gameObject.SetActive(true);
	}
/*
	public void applyOperation() {
		if (postfix [curr] = "+") {
			temp2 = m.pop ();
			temp1 = m.pop ();
			temp3 = temp1 + temp2;
			m.push (temp3.ToString());
		}
		else if (postfix [curr] == "-") {
			temp2 = m.pop ();
			temp1 = m.pop ();
			temp3 = temp1 - temp2;
			m.push (temp3.ToString());
		}
		else if (postfix [curr] == "*") {
			temp2 = m.pop ();
			temp1 = m.pop ();
			temp3 = temp1 * temp2;
			m.push (temp3.ToString());
		}
		else if (postfix [curr] == "/") {
			temp2 = m.pop ();
			temp1 = m.pop ();
			temp3 = temp1 / temp2;
			m.push (temp3.ToString());
		}
		else if (postfix [curr] == "^") {
			temp2 = m.pop ();
			temp1 = m.pop ();
			temp3 = Math.Pow (temp1,temp2);
			m.push (temp3.ToString());
		}
	}
*/
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

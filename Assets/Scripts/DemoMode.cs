﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class DemoMode : MonoBehaviour {
	
	static string problem1,problem2;
	MyStack m = new MyStack ();
	MyStack t = new MyStack ();
	//Stack<char> main = new Stack<char>();
	//Stack<char> trash = new Stack<char>();
	List<Rect> rects = new List<Rect>();
	List<Rect> garbage = new List<Rect>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;
	int y = 0;
	int z = 0;
	public Text txt;
	public Text value;
	public Text helper;
	char [] prob;
	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		problem1 = "[(2+4)+3*(4/2)";
		problem2 = "[2*(6/2)+(3^2)]";
		which = false;
/*		countop = problem1.Split('(').Length - 1;
		countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		countcbr = problem1.Split(']').Length - 1;
		
		prob = problem1.ToCharArray ();
		txt.text = "Expression: " + problem1;
		value.text = "Current value: " +prob[0];*/
		
	}
	
	// Update is called once per frame
	void Update () {
		// Rectangle needs to be added
		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 60;
				rects[i] = temp;
			}
			rects.Add (new Rect (100, 70, 100, 50));
			//Debug.Log ("adding rect");
			
			
		} else if (rects.Count > m.size () ) {
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y -= 60;
				rects[i] = temp;
			}
			rects.RemoveAt(rects.Count-1);
			//Debug.Log ("removing rect");
		}
		
		else if (garbage.Count < t.size () ) {
			// Update other rectangles
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y += 60;
				garbage[i] = temp;
			}
			garbage.Add (new Rect (850, 70, 100, 50));
			//Debug.Log ("adding rect");
			
			
		} else if (garbage.Count > t.size ()) {
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y -= 60;
				garbage[i] = temp;
			}
			garbage.RemoveAt(garbage.Count-1);
			//Debug.Log ("removing rect");
		}
		
	}
	
	void OnGUI () {

		if (m.size () > 0 && t.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"");
			}		
			for (int x = 0; x < garbage.Count; ++x) {
				GUI.contentColor = Color.red;
				GUI.Box (garbage[x], t.getAt (x)+"");
			}

		}

		else if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"");
			}		
		}
		else if (t.size () > 0) {
			for (int x = 0; x < garbage.Count; ++x) {
				GUI.contentColor = Color.red;
				GUI.Box (garbage[x], t.getAt (x)+"");
			}
		}
		
	}
	/*problem1 = "[(2+4)+3*(4/2)";
	problem2 = "[2*(6/2)+(3^2)]";*/
	public void bracketDemo(){
		switch (x)
		{
		case (1):

			break;
		case (2):
			break;
		case (3):
			break;
		case (4):
			break;
		case (5):
			break;
		}
		
	}
	
	


	/*public void stepThrough (){
	/	if(which==false)
			load1 ();
		else
			load2 ();
	}
	public void load1 (){
		
		if (x < prob.Length) {
			value.text = "Current value: " +prob[x];
			if (numbers.Contains (prob[x] + "")){
				Debug.Log(prob[x]);
				t.push (prob [x].ToString ());
			}
			else if (expressions.Contains(prob [x] + "")){
				m.push (prob [x].ToString ());
			}
			
		}
		if (x == prob.Length - 1) {
			
			if ((countop != countcp) || (countobr != countcbr)) {
				Debug.Log ("Invalid entry");
			}
			else{
				Debug.Log ("Works");
			}
		}
		if (x == prob.Length) {		
			switchproblem();
		}
		
		x++;
	}
	public void load2 (){
		
		if (x < prob.Length) {
			value.text ="Current value: "+ prob[x];
			if (numbers.Contains (prob [x] + ""))
			{
				
				t.push (prob [x].ToString ());
			}
			else if (expressions.Contains (prob [x] + ""))
			{
				
				m.push (prob [x].ToString ());
			}
			
		}
		if (x == prob.Length - 1) {
			
			if ((countop != countcp) || (countobr != countcbr)) {
				Debug.Log ("Invalid entry");
			} else {
				Debug.Log ("Works");
			}
			
		}
		x++;
	}
	void switchproblem(){
		x = 0;
		t = new MyStack ();
		m = new MyStack ();
		prob = problem2.ToCharArray ();
		countop = problem2.Split ('(').Length - 1;
		countcp = problem2.Split (')').Length - 1;
		countobr = problem2.Split ('[').Length - 1;
		countcbr = problem2.Split (']').Length - 1;
		txt.text = "Expression: " + problem2;
		which = true;
	}*/
}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class DemoMode : MonoBehaviour {

	static string problem1,problem2;
	Stack<char> main = new Stack<char>();
	Stack<char> trash = new Stack<char>();
	List<Rect> rects = new List<Rect>();
	List<Rect> garbage = new List<Rect>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;
	public Text txt;
	public Text value;
	char [] prob;
	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		problem1 = "[(2+4)+3*(4/2)";
		problem2 = "[2*(6/2)+(3^2)]";
		which = false;
		countop = problem1.Split('(').Length - 1;
		 countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		 countcbr = problem1.Split(']').Length - 1;

		prob = problem1.ToCharArray ();
		txt.text = "Expression: " + problem1;
		value.text = "Current value: " +prob[0];

	}
	
	// Update is called once per frame
	void Update () {
		// Rectangle needs to be added
		if (rects.Count < main.Count ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 60;
				rects[i] = temp;
			}
			rects.Add (new Rect (100, 50, 100, 50));
			Debug.Log ("adding rect");
			
			
		} else if (rects.Count > main.Count ) {
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y -= 60;
				rects[i] = temp;
			}
			rects.RemoveAt(rects.Count-1);
			Debug.Log ("removing rect");
		}
		
		else if (garbage.Count < trash.Count ) {
			// Update other rectangles
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y += 60;
				garbage[i] = temp;
			}
			garbage.Add (new Rect (200, 50, 100, 50));
			Debug.Log ("adding rect");
			
			
		} else if (garbage.Count > trash.Count) {
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y -= 60;
				garbage[i] = temp;
			}
			garbage.RemoveAt(garbage.Count-1);
			Debug.Log ("removing rect");
		}

	}

	void OnGUI () {
		if (main.Count > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.Box (rects [i], main.Pop ()+"");
			}
		}
		else if (trash.Count > 0) {
			for (int i = 0; i < garbage.Count; ++i) {
				GUI.Box (rects[i], trash.Pop ()+"");
			}
		}
		
	}

	public void stepThrough (){
		if(which==false)
		load1 ();
		else
		load2 ();
	}
	public void load1 (){

		if (x < prob.Length) {
			value.text = "Current value: " +prob[x];
			if (numbers.Contains (prob[x] + "")){
			


			}
			else if (expressions.Contains(prob [x] + "")){
				main.Push (prob [x]);
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

				trash.Push (prob [x]);
			}
			else if (expressions.Contains (prob [x] + ""))
			{

				main.Push (prob [x]);
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
		trash.Clear ();
		main.Clear ();
		prob = problem2.ToCharArray ();
		countop = problem2.Split ('(').Length - 1;
		countcp = problem2.Split (')').Length - 1;
		countobr = problem2.Split ('[').Length - 1;
		countcbr = problem2.Split (']').Length - 1;
		txt.text = "Expression: " + problem2;
		which = true;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class PostFixEval : MonoBehaviour {
	string problem1 = "[(2+4)+3*(4/2)";
	string problem2 = "[2*(6/2)+(3^2)]";
	Stack<char> main = new Stack<char>();
	Stack<char> trash = new Stack<char>();
	int [] priorities = new int[100];
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;


	Text txt;
	Text Value;


	char [] prob;
	bool which = false;
	
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		countop = problem1.Split('(').Length - 1;
		 countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		 countcbr = problem1.Split(']').Length - 1;

		txt = gameObject.GetComponent<Text>();
		txt.text= "Expression2: " + problem2;

		//value = gameObject.GetComponent<Text>();
		//value.text="Expression: ";
		
		//stack = new MyStack();
		//inputField = GameObject.Find ("Canvas").GetComponentInChildren<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text="Expression : " + problem2;
		Value.text = "Value to consider: " + Value;
	}

	public void OnClicked(Button button)
	{
		int counter = 0;
		Value.text = "Value to consider: " + problem1[counter];
		counter += 1;
	}

	public void stepThrough (){

		if(which==false)
		load1 ();
		else
		load2 ();
	}
	public void load1 (){
		prob = problem1.ToCharArray ();
		if (x < prob.Length) {
			if (numbers.Contains (prob[x] + ""))
				trash.Push (prob[x]);
			else if (expressions.Contains(prob [x] + ""))
				main.Push (prob [x]);
			
			
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
		
			if (numbers.Contains (prob [x] + ""))
				trash.Push (prob [x]);
			else if (expressions.Contains (prob [x] + ""))
				main.Push (prob [x]);
			
			
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
		which = true;
	}
}

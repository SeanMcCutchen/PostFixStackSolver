using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostFixEval : MonoBehaviour {
	string problem1 = "[(2+4)+3*(4/2)";
	string problem2 = "[2*(6/2)+(3^2)]";
	Stack<char> main = new Stack<char>();
	Stack<char> trash = new Stack<char>();
	int [] priorities = new int[100];
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;
	char [] prob;
	bool which = false;
	
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		countop = problem1.Split('(').Length - 1;
		 countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		 countcbr = problem1.Split(']').Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
	
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

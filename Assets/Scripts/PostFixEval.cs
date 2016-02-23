using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostFixEval : MonoBehaviour {
	string problem1 = "[(2+4)+3*(4/2)";
	string problem2 = "[2*(6/2)+(3^2)]";
	Stack<char> main = new Stack<char>();
	Stack<char> trash = new Stack<char>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;
	
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
		Debug.Log (x + "x");
		Debug.Log (countop + "countop");
		Debug.Log (countcp + "countcp");
		Debug.Log (countobr + "countobr");
		Debug.Log (countcbr + "countcbr");
		char [] prob1 = problem1.ToCharArray ();

		Debug.Log (prob1.Length + "length");

	
		if(x<prob1.Length)
		{
			if(numbers.Contains(prob1[x]+""))
			   trash.Push(prob1[x]);
			else if(expressions.Contains(prob1[x]+""))
				main.Push(prob1[x]);
			                            

		}
		if ((x == prob1.Length - 1)&&((countop!=countcp)||(countobr!=countcbr))) {
			Debug.Log ("Invalid entry");
		}
		x++;
	}


}

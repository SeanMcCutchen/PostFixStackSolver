using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class PostFixEval : MonoBehaviour {

	MyStack stack;
	InputField inputField;
	List<Rect> rects = new List<Rect>();

	string problem1 = "[(2+4)+3*(4/2)";
	string problem2 = "[2*(6/2)+(3^2)]";
	Stack<char> main = new Stack<char>();
	Stack<char> trash = new Stack<char>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;

	Text txt;

	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		countop = problem1.Split('(').Length - 1;
		 countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		 countcbr = problem1.Split(']').Length - 1;

		txt = gameObject.GetComponent<Text>();
		txt.text="Expression: " + problem2;

		stack = new MyStack();
		inputField = GameObject.Find ("Canvas").GetComponentInChildren<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text="Expression : " + problem2;  

		if (rects.Count < stack.size ()) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 60;
				rects[i] = temp;
			}
			rects.Add (new Rect (100, 50, 100, 50));
			Debug.Log ("adding rect");
			
			
		} else if (rects.Count > stack.size ()) {
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y -= 60;
				rects[i] = temp;
			}
			rects.RemoveAt(rects.Count-1);
			Debug.Log ("removing rect");
		}
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

	void OnGUI () {
		if (rects.Count > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.Box (rects[i], stack.getAt(i));
			}
		}
		
	}
	public void popStack () {
		stack.pop ();
	}
	public void pushStack () {
		StringBuilder builder = new StringBuilder ();
		char ch;
		for (int i =0; i < 2; i++) {
			//All 2-digit numbers
			ch = Convert.ToChar(UnityEngine.Random.Range(48, 58));
			builder.Append (ch);
		}
		builder.Append ("h");
		stack.push (builder.ToString());
	}


}

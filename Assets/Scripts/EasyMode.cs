﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class EasyMode : MonoBehaviour {

	static string problem1,problem2, problem3 ,problem4;
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

	int ispnum = -1;
	int icpnum = 0;

	bool evaluate;
	public Text txtEasy;
	public Text valueEasy;
	public Text helperEasy;
	public Text postFix;
	public Button nButton;
	public Text buttonText;
	public Text isp;
	public Text icp;
	public Text postfixString;
	public Text hint;
	public Image table;

	char [] prob2;
	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {

		//table.gameObject.SetActive (false);
		evaluate = true;
		problem1 = "[2*(6/2)+(3^2)]";
		problem2 = "[(2+4)+3*(4/2)";
		problem3 = "[1+(2^2^2)/6]";
		problem4 = "[8-(3+1)]";


		which = false;
		/*		countop = problem1.Split('(').Length - 1;
		countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		countcbr = problem1.Split(']').Length - 1;
		*/

		prob2 = problem4.ToCharArray ();
		txtEasy.text = "Expression: " + problem4;
	}

	// Update is called once per frame
	void Update () {

		if (evaluate) {
			isp.text = "In Stack Priority (ISP): " + ispnum;
			icp.text = "Incoming Priority (ICP): " + icpnum;
		} else {
			isp.text = "";
			icp.text = "";
			postfixString.text = "";
		}

		// Rectangle needs to be added
		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 90;
				rects[i] = temp;
			}
			rects.Add (new Rect (80, 100, 150, 75));
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

		/*else if (garbage.Count < t.size () ) {
			// Update other rectangles
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y += 90;
				garbage[i] = temp;
			}
			garbage.Add (new Rect (850, 70, 100, 50));
			//Debug.Log ("adding rect");
		

		} else if (garbage.Count > t.size ()) {
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y -= 90;
				garbage[i] = temp;
			}
			garbage.RemoveAt(garbage.Count-1);
			//Debug.Log ("removing rect");
		}
		*/

	}

	void OnGUI () {
		GUIStyle style = new GUIStyle (GUI.skin.button);
		style.fontSize = 24;
		if (m.size () > 0 && t.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"",style);
			}		
			for (int x = 0; x < garbage.Count; ++x) {
				GUI.contentColor = Color.red;
				GUI.Box (garbage[x], t.getAt (x)+"",style);
			}

		}

		else if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"",style);
			}		
		}
		else if (t.size () > 0) {
			for (int x = 0; x < garbage.Count; ++x) {
				GUI.contentColor = Color.red;
				GUI.Box (garbage[x], t.getAt (x)+"",style);
			}
		}

	}


	/*
	case (0):
			icpnum=7;
			m.push ("[");
			helperHard.text = "Pushing a scope opener";
			valueHard.text = "Current value: [ ";
			hint.text = "Hint: Always push scope openers";
			x++;
			break;
		case (1):
			//t.push ("2");
			ispnum=0;
			helperHard.text = "Number, adding to postfix string: 1";
			postfixString.text= "Postfix: 1";
			valueHard.text = "Current value: 1 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
	*/
	//[8-(3+1)]

	/*
	If Operand, Write it to the Postfix String
	If Scope Opener or Operator
		If the In-Coming Priority (ICP) is greater than the In-Stack Priority (ISP) Push
		If ICP < ISP Pop – Write Values To Postfix Until Can Push
		If Scope Closer, Pop till find opener – Write values to Postfix – Throw out scope opener!
	*/
	public void easyDemo(){
		switch (x) {
		case (0):
			//helperEasy.text = "Notice that In Stack Priority Starts at -1";
			hint.text = "If Operand, Write it to the Postfix String" +
				"\nIf Scope Opener or Operator" +
				"\n\t\t\tIf the ICP is greater than the ISP Push" +
				"\n\t\t\tIf ICP < ISP Pop – Write Values To Postfix Until Can Push" +
				"\n\t\t\tIf Scope Closer, Pop till find opener – Write values to Postfix " +
				"– Throw out scope opener!";
			x++;
			break;
		case (1):
			icpnum = 7;
			helperEasy.text = "Since ICP > ISP - Push scope opener";
			valueEasy.text = "Current value: [ ";
			hint.text = "Hint: Always push scope openers";
			x++;
			break;
		case (2):
			m.push ("[");	
			ispnum = 0;
			helperEasy.text = "Pushed scope opener to stack";
			x++;
			break;
		case (3):
			icpnum = 0;
			ispnum = 0;
			valueEasy.text = "Current value: 8 ";
			helperEasy.text = "Operand found";
			hint.text = "Hint: Always appending operand to postfix string";
			x++;
			break;
		case (4):
			helperEasy.text = "Operand, adding to postfix string: 8";
			postfixString.text = "Postfix: 8";
			x++;
			break;
		case (5):
			icpnum=1;
			helperEasy.text = "Since ICP > ISP - Push operator";
			valueEasy.text = "Current value: - ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (6):
			m.push ("-");
			helperEasy.text = "Operator, pushing to stack";
			ispnum = 2;
			hint.text = "";
			x++;
			break;
		case (7):
			icpnum = 7;
			helperEasy.text = "Since ICP > ISP - Push scope opener";
			valueEasy.text = "Current value: ( ";
			hint.text = "Hint: Always push scope openers";
			x++;
			break;
		case (8):
			m.push ("(");
			helperEasy.text = "Pushed scope opener to stack";
			ispnum = 0;
			x++;
			break;
		case (9):
			icpnum = 0;
			valueEasy.text = "Current value: 3 ";
			helperEasy.text = "Operand found";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (10):
			helperEasy.text = "Operand, appending to postfix string: 3";
			postfixString.text= "Postfix: 8 3";
			x++;
			break;
		case (11):
			icpnum=1;
			helperEasy.text = "Since ICP > ISP - Push operator";
			valueEasy.text = "Current value: + ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (12):
			m.push ("+");
			ispnum = 2;
			helperEasy.text = "Operator, pushing to stack";
			hint.text = "";
			x++;
			break;
		case (13):
			valueEasy.text = "Current value: 1 ";
			helperEasy.text = "Operand found";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (14):
			helperEasy.text = "Operand, adding to postfix string: 1";
			postfixString.text = "Postfix: 8 3 1";
			x++;
			break;
		case (15):
			valueEasy.text = "Current value: ) ";
			helperEasy.text = "Scope closer found";
			hint.text = "Hint: Pop till find opener – Write values to Postfix – Throw out scope opener!";
			x++;
			break;
		case (16):
			helperEasy.text = "Operator found - Pop and append  to the string";
			hint.text = "Hint: Pop till scope opener is found";
			x++;
			break;
		case (17):
			m.pop ();
			helperEasy.text = "Popping Stack | Appending operator";
			hint.text = "Hint: Pop until scope opener is found";
			postfixString.text = "Postfix: 8 3 1 +";
			x++;
			break;
		case (18):
			m.pop ();
			valueEasy.text = "Current value: ] ";
			helperEasy.text = "Scope closer found";
			hint.text = "Hint: Pop until scope opener is found";
			x++;
			break;
		case (19):
			helperEasy.text = "Writing values to postfix.";
			postfixString.text = "Postfix: 8 3 1 + -";
			hint.text = "";
			x++;
			break;
		case (20):
			postfixString.text = "Postfix: 8 3 1 + -";
			m.pop ();
			x++;
			break;
		case (21):
			postfixString.text = "Postfix: 8 3 1 + -";
			helperEasy.text = "Found opener and closer, valid | This is the postfix expression: 8 3 1 + -";
			hint.text = "Hint: Once postfix expression is built, empty the stack";
			x++;
			break;
		case (22):
			helperEasy.text = "Popping stack";
			m.pop ();
			x++;
			break;
		case (23):
			helperEasy.text = "Popping stack";
			m.pop ();
			x++;
			break;

			/*case ():
			  x++;
			break;

		case (100):
			ispnum = 0;
			//t.push ("8");
			helperEasy.text = "Number, adding to postfix string: 8";
			postfixString.text= "Postfix: 8";
			valueEasy.text = "Current value: 8 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (200):
			m.push ("-");
			icpnum=1;
			helperEasy.text = "Operator, pushing to stack";
			valueEasy.text = "Current value: - ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (3):
			m.push ("(");
			icpnum = 7;
			ispnum = 2;
			helperEasy.text = "Pushing a scope opener";
			valueEasy.text = "Current value: ( ";
			hint.text = "Hint: Always push scope openers";
			x++;
			break;
		case (4):
			t.push ("3");
			ispnum = 0;
			helperEasy.text = "Number, adding to postfix string: 3";
			postfixString.text= "Postfix: 8 3";
			valueEasy.text = "Current value: 3 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (5):
			icpnum = 1;
			m.push ("+");
			helperEasy.text = "Operator, pushing to stack";
			valueEasy.text = "Current value: + ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (6):
			//m.push ("1");
			ispnum = 2;
			helperEasy.text = "Number, adding to postfix string: 1";
			postfixString.text= "Postfix: 8 3 1";
			valueEasy.text = "Current value: 1 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (7):
			m.push (")");
			helperEasy.text = "Pushing a scope closer";
			helperEasy.text = "Popping the stack twice";
			postfixString.text= "Postfix: 8 3 1 +";
			valueEasy.text = "Current value: ) ";
			m.pop ();
			m.pop ();
			helperEasy.text = "Found opener and closer, valid";
			x++;
			break;
		case (8):
			m.push ("]");
			helperEasy.text = "Pushing a scope closer";
			helperEasy.text = "Popping the stack twice";
			valueEasy.text = "Current value: ] ";
			//postfixString.text= "Postfix: 8 3 1 + -";
			m.pop ();
			m.pop ();
			helperEasy.text = "Found opener and closer, valid | This is the postfix expression: 8 3 1 + -";
			t = new MyStack();
			x++;
			break;
		case (9):
			helperEasy.text = "Time to evaluate our expression";
			m = new MyStack ();
			t = new MyStack ();
			buttonText.text = "Evaluate";
			postfixString.text = "Postfix expression: 8 3 1 + -";
			x++;
			break;
		case (10): 
			helperEasy.text = "Operand, pushing to stack. Remaining expression: 3 1 + -";
			valueEasy.text = "Current Value: 8";
			buttonText.text = "Next Step";
			table.gameObject.SetActive (false);
			m.push("8");
			x++; 
			break;
		case (11):
			helperEasy.text = "Operand, pushing to stack. Remaining expression: 1 + -";
			valueEasy.text = "Current Value: 3";
			m.push("3");
			x++;
			break;
		case(12):
			helperEasy.text = "Operand, pushing to stack. Remaining expression: + -";
			valueEasy.text = "Current Value: 1";
			m.push("1");
			x++;
			break;
		case (13):
			helperEasy.text = "Operator, popping stack twice. Remaining expression: -";
			valueEasy.text = "Current Value: +";
			m.pop();
			m.pop();
			x++;
			break;
		case (14):
			helperEasy.text = "Applying operation: 3 + 1 = 4. Pushing 4 to stack. Remaining expression: -";
			m.push("4");
			x++;
			break;
		case (15):
			helperEasy.text = "Operator, popping stack twice.";
			valueEasy.text= "Current Value: - ";
			m.pop();
			m.pop();
			x++;
			break;
		case (16):
			helperEasy.text = "Applying operation: 8 - 4 = 4. We have an answer!";
			nButton.gameObject.SetActive(false);
			break;
		default:
			break;*/

		}
	}

	/*public void bracketDemo(){
		switch (x)
		{
		case (0):
			m.push ("[");
			helper.text = "Pushing a scope opener";
			x++;
			break;
		case (1):
			t.push ("2");
			helper.text = "Number, discarding";
			x++;
			break;
		case (2):
			t.push ("*");
			helper.text = "Operator, discarding";
			x++;
			break;
		case (3):
			m.push ("(");
			helper.text = "Pushing a scope opener";
			x++;
			break;
		case (4):
			t.push ("6");
			helper.text = "Number, discarding";
			x++;
			break;
		case (5):
			t.push ("/");
			helper.text = "Operator, discarding";
			x++;
			break;
		case (6):
			t.push ("2");
			helper.text = "Number, discarding";
			x++;
			break;
		case (7):
			m.push (")");
			helper.text = "Pushing a scope closer";
			helper.text = "Popping the stack twice";
			m.pop ();
			m.pop ();
			helper.text = "Found opener and closer, valid";
			x++;
			break;


		case (8):
			t.push ("+");
			helper.text = "Operator, discarding";
			x++;
			break;
		case (9):
			m.push ("(");
			helper.text = "Pushing a scope opener";
			x++;
			break;
		case (10):
			t.push ("3");
			helper.text = "Number, discarding";
			x++;
			break;
		case (11):
			t.push ("^");
			helper.text = "Operator, discarding";
			x++;
			break;
		case (12):
			t.push ("2");
			helper.text = "Number, discarding";
			x++;
			break;
		case (13):
			m.push (")");
			helper.text = "Pushing a scope closer";
			helper.text = "Popping the stack twice";
			m.pop ();
			m.pop ();
			helper.text = "Found opener and closer, valid";
			x++;
			break;
		case (14):
			m.push ("]");
			helper.text = "Pushing a scope closer";
			helper.text = "Popping the stack twice";
			m.pop ();
			m.pop ();
			helper.text = "Found opener and closer, valid";
			x++;
			break;
		case (15):
			helper.text = "Valid expression";
			t = new MyStack();
			break;
		default:
			break;

		}
	}*/




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

/*
Helpful Hints:
Always push scope openers
Append all operands to postfic string
If ICP > ISP Push
If ICP < ISP Pop and append to postfix until push is possible
When a scope closer is found, Pop until opener is found and append to postfix

*/
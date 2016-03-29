using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class HardMode : MonoBehaviour {
	
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
	public Text txtHard;
	public Text valueHard;
	public Text helperHard;
	public Text postfixString;
	public Text nextButton;
	public Button nButton;
	
	char [] prob3;
	
	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		
		problem1 = "[2*(6/2)+(3^2)]";
		problem2 = "[(2+4)+3*(4/2)";
		problem3 = "[1+(2^2^2)/4]";
		problem4 = "[8-(3+1)]";
		
		
		which = false;
		/*		countop = problem1.Split('(').Length - 1;
		countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		countcbr = problem1.Split(']').Length - 1;
		*/
		//prob = problem1.ToCharArray ();
		//txt.text = "Expression: " + problem1;
		
		prob3 = problem3.ToCharArray ();
		txtHard.text = "Expression: " + problem3;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (x < prob3.Length)
			//value.text = "Current value: " +prob[x];
		valueHard.text = "Current value: " + prob3 [x];
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

	public void bracketDemo(){
		switch (x)
		{
		case (0):
			m.push ("[");
			helperHard.text = "Pushing a scope opener";
			x++;
			break;
		case (1):
			//t.push ("2");
			helperHard.text = "Number, adding to postfix string: 1";
			postfixString.text= "Postfix: 1";
			x++;
			break;

		case (2):
			m.push ("+");
			helperHard.text = "Operator, pushing to stack";
			x++;
			break;
		case (3):
			m.push ("(");
			helperHard.text = "Pushing a scope opener";
			x++;
			break;
		case (4):
			//m.push ("2");
			helperHard.text = "Number, adding to postfix string: 1 2";
			postfixString.text = "Postfix: 1 2";
			x++;
			break;
		case (5):
			m.push ("^");
			helperHard.text = "Operator, pushing to stack";
			x++;
			break;
		case (6):
			//m.push ("2");
			helperHard.text = "Number, adding to postfix string: 1 2 2";
			postfixString.text= "Postfix: 1 2 2";
			x++;
			break;
		case (7):
			//m.push ("^");
			helperHard.text = "Operator same as top of stack, pop stack: 1 2 2 ^";
			postfixString.text = "Postfix: 1 2 2 ^";
			m.pop ();
			x++;
			break;

		case (8):
		//	t.push ("2");
			helperHard.text = "Operator, adding to postfix string: 1 2 2 ^ 2";
			postfixString.text= "Postfix: 1 2 2 ^ 2";
			x++;
			break;
		case (9):
			m.push (")");
			helperHard.text = "Pushing a scope opener";
			helperHard.text = "Popping the stack twice";
			m.pop ();
			m.pop ();
			helperHard.text = "Adding operator to postfix string: 1 2 2 ^ 2 ^";
			postfixString.text = "Postfix: 1 2 2 ^ 2 ^";
			x++;
			break;
		case (10):
			m.push ("/");
			helperHard.text = "Operator, pushing to stack";
			x++;
			break;
		case (11):
			//m.push ("6");
			helperHard.text = "Number, adding to postfix string: 1 2 2 ^ 2 ^ 4";
			postfixString.text = "Postfix: 1 2 2 ^ 2 ^ 4";
			x++;
			break;
		case (12):
			m.push ("]");
			helperHard.text = "Pushing a scope closer";
			helperHard.text = "Popping the rest of the stack";
			m.pop ();
			m.pop ();
			m.pop ();
			x++;
			break;
		case (13):
			helperHard.text = "Valid expression, final postfix string: 1 2 2 ^ 2 ^ 4 / +";
			postfixString.text = "Postfix: 1 2 2 ^ 2 ^ 4 / +";
			t = new MyStack();
			x++;
			break;
		case (14):
			nextButton.text = "Evaluate";
			helperHard.text = "Let's now evaluate our postfix expression";
			m = new MyStack();
			x++;
			break;
		case (15):
			nextButton.text = "Next Step";
			valueHard.text = "Current value: 1";
			helperHard.text = "Operand, pushing to stack. Remaining expression: 2 2 ^ 2 ^ 4 / +";
			m.push("1");
			x++;
			break;
		case (16):
			helperHard.text = "Operand, pushing to stack. Remaining expression: 2 ^ 2 ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push("2");
			x++;
			break;
		case (17):
			helperHard.text = "Operand, pushing to stack. Remaining expression: ^ 2 ^ 4 / +";
			m.push("2");
			x++;
			break;
		case (18):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: ^";
			m.pop();
			m.pop();
			x++;
			break;
		case (19):
			helperHard.text = "Applying operation: 2 ^ 2 = 4. Pushing 4 to stack. Remaining expression: 2 ^ 4 / +";
			m.push("4");
			x++;
			break;
		case (20):
			helperHard.text = "Operand, pushing to stack. Remaining expression: ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push("2");
			x++;
			break;
		case (21):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: ^";
			m.pop();
			m.pop();
			x++;
			break;
		case (22):
			helperHard.text = "Applying operation: 4 ^ 2 = 16. Pushing 16 to stack. Remaining expression: 4 / +";
			m.push("16");
			x++;
			break;
		case (23):
			helperHard.text = "Operand, pushing to stack. Remaining expression: / +";
			valueHard.text = "Current value: 4";
			m.push("4");
			x++;
			break;
		case (24):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: /";
			m.pop();
			m.pop();
			x++;
			break;
		case (25):
			helperHard.text = "Applying operation: 16 / 4 = 4. Pushing 4 to stack. Remaining expression: +";
			m.push("4");
			x++;
			break;
		case (26):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: +";
			m.pop();
			m.pop();
			x++;
			break;
		case (27):
			helperHard.text = "Applying operation: 1 + 4 = 5. Houston, we have an answer!";
			nButton.gameObject.SetActive(false);
			break;


		default:
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
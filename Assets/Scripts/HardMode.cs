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
	int ispnum = -1;
	int icpnum = 0;
	bool evaluate;
	public Text txtHard;
	public Text valueHard;
	public Text helperHard;
	public Text postfixString;
	public Text nextButton;
	public Text isp;
	public Text icp;
	public Button nButton;
	public Text hint;
	public Text exprDisplay;
	public Image table;

	char [] prob3;
	
	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {

		table.gameObject.SetActive (false);
		evaluate = true;
		problem1 = "[2*(6/2)+(3^2)]";
		problem2 = "[(2+4)+3*(4/2)";
		problem3 = "[ 1 + ( 2 ^ 3 ^ 2 ) / 4 ]";
		problem4 = "[8-(3+1)]";
		prob3 = problem3.ToCharArray ();
		txtHard.text = "Infix Expression: " + problem3;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (evaluate) {
			isp.text = "In Stack Priority : " + ispnum;
			icp.text = "Incoming Priority : " + icpnum;
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

	public void bracketDemo(){
		switch (x)
		{
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

		case (2):

			m.push ("+");
			icpnum=1;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: + ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (3):
			ispnum=2;
			m.push ("(");
			icpnum=7;
			helperHard.text = "Pushing a scope opener";
			valueHard.text = "Current value: ( ";
			hint.text = "Hint: Always push scope openers";
			x++;
			break;
		case (4):
			//m.push ("2");
			helperHard.text = "Operand, adding to postfix string: 1 2";
			postfixString.text = "Postfix: 1 2";
			valueHard.text = "Current value: 2 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (5):
			ispnum=0;
			m.push ("^");
			icpnum=6;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: ^ ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (6):
			//m.push ("2");
			helperHard.text = "Number, adding to postfix string: 1 2 3";
			postfixString.text= "Postfix: 1 2 3";
			valueHard.text = "Current value: 3 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (7):
			ispnum=5;
			m.push ("^");
			icpnum=6;
			helperHard.text = "Operator, pushing to stack";
			postfixString.text = "Postfix: 1 2 3";
			valueHard.text = "Current value: ^ ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			//m.pop ();
			x++;
			break;

		case (8):
		//	t.push ("2");
			helperHard.text = "Operand, adding to postfix string: 1 2 3 2";
			postfixString.text= "Postfix: 1 2 3 2";
			valueHard.text = "Current value: 2 ";
			x++;
			break;
		case (9):

			m.push (")");
			helperHard.text = "Pushing a scope closer, popping the stack until matching scope opener is found";
			m.pop ();
			m.pop ();
			m.pop ();
			m.pop ();
			valueHard.text = "Current value: ) ";
			helperHard.text = "Adding operators to postfix string: 1 2 3 2 ^ ^";
			postfixString.text = "Postfix: 1 2 3 2 ^ ^";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			x++;
			break;
		case (10):

			m.push ("/");
			icpnum=3;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: / ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			break;
		case (11):
			ispnum=4;
			//m.push ("6");
			helperHard.text = "Operand, adding to postfix string: 1 2 3 2 ^ ^ 4";
			postfixString.text = "Postfix: 1 2 3 2 ^ ^ 4";
			valueHard.text = "Current value: 4 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			break;
		case (12):
			m.push ("]");
			helperHard.text = "Pushing a scope closer";
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: ] ";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			m.pop ();
			m.pop ();
			m.pop ();
			m.pop ();
			x++;
			break;
		case (13):
			icp.text="";
			isp.text="";
			helperHard.text = "Valid expression, final postfix string: 1 2 3 2 ^ ^ 4 / +";
			postfixString.text = "Postfix: 1 2 3 2 ^ ^ 4 / +";
			valueHard.text = "";
			hint.text = "";
			t = new MyStack();
			x++;
			break;
		case (14):
			nextButton.text = "Evaluate";
			helperHard.text = "Let's now evaluate our postfix expression";
			evaluate = false;
			m = new MyStack();
			x++;
			break;
		case (15):
			nextButton.text = "Next Step";
			exprDisplay.text = "Postfix Expression: 1 2 3 2 ^ ^ 4 / +";
			valueHard.text = "Current value: 1";
			helperHard.text = "Operand, pushing to stack. Remaining expression: 2 3 2 ^ ^ 4 / +";
			hint.text = "When evaluating, always push operands to stack";
			table.gameObject.SetActive (false);
			m.push("1");
			x++;
			break;
		case (16):
			helperHard.text = "Operand, pushing to stack. Remaining expression: 3 2 ^ ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push("2");
			x++;
			break;
		case (17):
			helperHard.text = "Operand, pushing to stack. Remaining expression: 2 ^ ^ 4 / +";
			valueHard.text = "Current value: 3";
			m.push("3");
			x++;
			break;
		case (18):
			helperHard.text = "Operand, pushing to stack. Remaining expression: ^ ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push ("2");
			x++;
			break;
		case (19):
			helperHard.text = "Operator, popping stack twice";
			valueHard.text = "Current value: ^";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			m.pop ();
			m.pop ();
			x++;
			break;
		case (20):
			helperHard.text = "Applying operation: 3 ^ 2 = 9. Pushing 9 to stack. Remaining expression: ^ 4 / +";
			m.push("9");
			x++;
			break;
		case (21):
			helperHard.text = "Operator, popping stack twice.";
			m.pop();
			m.pop();
			x++;
			break;
		case (22):
			helperHard.text = "Applying operation: 2 ^ 9 = 512. Pushing 512 to stack. Remaining expression: 4 / +";
			m.push("512");
			x++;
			break;
		case (23):
			helperHard.text = "Operand, pushing to stack. Remaining expression: / +";
			valueHard.text = "Current value: 4";
			hint.text = "When evaluating, always push operands to stack";
			m.push("4");
			x++;
			break;
		case (24):
			helperHard.text = "Operator, popping stack twice.";
			m.pop ();
			m.pop();
			valueHard.text = "Current value: /";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			x++;
			break;
		case (25):
			helperHard.text = "Applying operation: 512 / 4 = 128. Pushing 128 to stack. Remaining expression: +";
			m.push("128");
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

			helperHard.text = "Applying operation: 128 + 1 = 129. Houston, we have an answer!";
			m.push ("129");
			hint.text = "";
			nButton.gameObject.SetActive(false);
			break;


		default:
			break;

			
		}

		
		
		
	}

	
}

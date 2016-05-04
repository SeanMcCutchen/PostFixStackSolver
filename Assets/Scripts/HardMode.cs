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
	public Button skipButton;
	public Text hint;
	public Text exprDisplay;
	public Image table;
	public AudioSource sound;
	string[] test;


	char [] prob3;

	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		table.gameObject.SetActive (true);
		evaluate = false;
		problem1 = "[2*(6/2)+(3^2)]";
		problem2 = "[(2+4)+3*(4/2)";
		problem3 = "[ 1 + ( 2 ^ 3 ^ 2 ) / 4 ]";
		problem4 = "[8-(3+1)]";
		prob3 = problem3.ToCharArray ();
		test = problem3.Split (' ');
		//txtHard.text = "Infix Expression: " + problem3;



	}

	// Update is called once per frame
	void Update () {
		if (evaluate) {
			isp.text = "In Stack Priority : " + ispnum;
			icp.text = "Incoming Priority : " + icpnum;
		} else {
			isp.text = "";
			icp.text = "";
			//postfixString.text = "";
		}
		StringBuilder str = new StringBuilder();
		for (int i = 0; i < test.Length; i++) {
			if (i ==  x)
				str.Append (string.Format ("<color=yellow>{0}</color>", test [x]));
			else
				str.Append (test[i]);
		}

		txtHard.text = "Infix String: " + str.ToString();

		// Rectangle needs to be added
		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 90;
				rects[i] = temp;
			}
			rects.Add (new Rect (150, 240, 200, 75));
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
		style.fontSize = 40;
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

	public void skip() {
		if (y < 23)
			y = 23;
		else if (y < 57)
			y = 57;
	}

	public void bracketDemo(){
		switch (y)
		{
		case (0):
			helperHard.text = "Our current value is a scope opener, always push scope openers";
			valueHard.text = "";
			y++;
			break;
		case (1):
			helperHard.text = "Pushing scope opener";
			y++;
			break;
		case (2):
			helperHard.text = "Scope opener pushed";
			m.push ("[");
			y++;
			break;
		case (3):
			helperHard.text = "Our current value is an operand. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (4):
			helperHard.text = "Our current value is an operator. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (5):
			helperHard.text = "Our current value is a scope opener, always push scope openers";
			x++;
			y++;
			break;
		case (6):
			helperHard.text = "Pushing scope opener";
			y++;
			break;
		case (7):
			helperHard.text = "Scope opener pushed";
			m.push ("(");
			y++;
			break;
		case (8):
			helperHard.text = "Our current value is an operand. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (9):
			helperHard.text = "Our current value is an operator. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (10):
			helperHard.text = "Our current value is an operand. While checking for bracket validity we ignore operators and operands";
			x++;
			y++;
			break;
		case (11):
			helperHard.text = "Our current value is an operator. While checking for bracket validity we ignore operators and operands";
			x++;
			y++;
			break;
		case (12):
			helperHard.text = "Our current value is an operand. While checking for bracket validity we ignore operators and operands";
			x++;
			y++;
			break;
		case (13):
			helperHard.text = "Our current value is a scope closer, pushing to stack then popping to check for validity";
			x++;
			y++;
			break;
		case (14):
			helperHard.text = "Scope opener pushed, popping stack to check for validity";
			m.push (")");
			y++;
			break;
		case (15):
			helperHard.text = "Popped stack. _ )";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (16):
			helperHard.text = "Popped stack. ( ) brackets match!";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (17):
			helperHard.text = "Our current value is an operator. While checking for bracket validity we ignore operators and operands";
			x++;
			y++;
			break;
		case (18):
			helperHard.text = "Our current value is an operand. While checking for bracket validity we ignore operators and operands";
			x++;
			y++;
			break;
		case (19):
			helperHard.text = "Our current value is a scope closer, pushing then popping to check for validity";
			x++;
			y++;
			break;
		case (20):
			helperHard.text = "Pushed to stack, now popping to check for validity";
			m.push ("]");
			y++;
			break;
		case (21):
			helperHard.text = "Stack popped. _ ]";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (22):
			helperHard.text = "Stack popped. [ ] brackets match!";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (23):
			helperHard.text = "Stack is empty. Valid expression w/ respect to brackets, next step to begin postfix formation";
			m = new MyStack ();
			y++;
			x = 0;
			break;
		case (24):
			icpnum = 7;
			evaluate = true;
			helperHard.text = "Pushing a scope opener";
			valueHard.text = "Current value: [ ";
			hint.text = "Hint: Always push scope openers";
			y++;
			break;
		case (25):
			icpnum=7;
			ispnum = 0;
			m.push ("[");
			helperHard.text = "Pushed scope opener to stack";
			y++;
			break;
		case (26):
			ispnum=0;
			evaluate = false;
			helperHard.text = "Operand, appending to postfix string: 1";
			valueHard.text = "Current value: 1 ";
			hint.text = "Hint: Always append operands to postfix string";
			y++;
			x++;
			break;
		case (27):
			helperHard.text = "Operand appended to postfix string";
			postfixString.text= "Postfix: 1";
			hint.text = "Hint: Always append operands to postfix string";
			y++;
			break;
		case (28):
			icpnum=1;
			evaluate = true;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: + ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			y++;
			x++;
			break;
		case (29):
			m.push ("+");
			helperHard.text = "Pushed Operator to stack";
			y++;
			break;
		case (30):
			ispnum=2;
			icpnum=7;
			helperHard.text = "Pushing a scope opener";
			valueHard.text = "Current value: ( ";
			hint.text = "Hint: Always push scope openers";
			x++;
			y++;
			break;
		case (31):
			m.push ("(");
			helperHard.text = "Pushed scope opener to stack";
			y++;
			break;
		case (32):
			evaluate = false;
			helperHard.text = "Operand, appending to postfix string";
			valueHard.text = "Current value: 2 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			y++;
			break;
		case (33):
			helperHard.text = "Operand appended to postfix string";
			postfixString.text = "Postfix: 1  2";
			y++;
			break;
		case (34):
			ispnum = 0;
			icpnum = 6;
			evaluate = true;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: ^ ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			y++;
			break;
		case (35):
			ispnum=0;
			m.push ("^");
			icpnum=6;
			helperHard.text = "Pushed operator to stack";
			y++;
			break;
		case (36):
			evaluate = false;
			helperHard.text = "Operand, appending to postfix string";
			ispnum = 5;
			valueHard.text = "Current value: 3 ";
			hint.text = "Hint: Always append operands to postfix string";
			x++;
			y++;
			break;
		case (37):
			helperHard.text = "Operand appended to postfix string";
			postfixString.text= "Postfix: 1  2  3";
			y++;
			break;
		case (38):
			evaluate = true;
			icpnum = 6;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: ^ ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			x++;
			y++;
			break;
		case (39):
			m.push ("^");
			ispnum=5;
			helperHard.text = "Pushed operator to stack";
			y++;
			break;
		case (40):
			evaluate = false;
			helperHard.text = "Operand, appending to postfix string";
			valueHard.text = "Current value: 2 ";
			x++;
			y++;
			break;
		case (41):
			helperHard.text = "Operand appended to postfix string";
			postfixString.text= "Postfix: 1  2  3  2";
			y++;
			break;
		case (42):
			m.push (")");
			helperHard.text = "Pushing a scope closer, popping the stack until matching scope opener is found";
			valueHard.text = "Current value: ) ";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			x++;
			break;
		case (43):
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: ) ";
			helperHard.text = "Appending operators to postfix string: 1 2 3 2 ^ ^";
			postfixString.text = "Postfix: 1  2  3  2  ^  ^";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			break;
		case (44):
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: ^ ";
			helperHard.text = "Appending operator to postfix string";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			break;
		case (45):
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: ^ ";
			helperHard.text = "Appending operators to postfix string";
			postfixString.text = "Postfix: 1  2  3  2  ^  ^ ";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			x++;
			break;
		case (46):
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: ( ";
			helperHard.text = "Found matching bracket";
			postfixString.text = "Postfix: 1  2  3  2  ^  ^";
			hint.text = "Matching bracket has been found, time to continue the postfix formation";
			y++;
			break;
		case (47):
			icpnum = 3;
			evaluate = true;
			helperHard.text = "Operator, pushing to stack";
			valueHard.text = "Current value: / ";
			hint.text = "Hint: Incoming priority greater than instack priority";
			y++;
			break;
		case (48):
			m.push ("/");
			icpnum=3;
			helperHard.text = "Pushed operator to stack";
			y++;
			break;
		case (49):
			evaluate = false;
			ispnum = 4;
			helperHard.text = "Operand, appending to postfix string";
			valueHard.text = "Current value: 4 ";
			hint.text = "Hint: Always append operands to postfix string";
			y++;
			x++;
			break;
		case (50):
			ispnum=4;
			helperHard.text = "Operand, adding to postfix string: 1 2 3 2 ^ ^ 4";
			postfixString.text = "Postfix: 1  2  3  2  ^  ^  4";
			y++;
			break;
		case (51):
			m.push ("]");
			helperHard.text = "Pushing a scope closer";
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: ] ";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			x++;
			break;
		case (52):
			m.pop ();
			sound.Play ();
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: ] ";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			break;
		case (53):
			m.pop ();
			sound.Play ();
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: / ";
			postfixString.text = "Postfix:  1  2  3  2  ^  ^  4  /";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			break;
		case (54):
			m.pop ();
			sound.Play ();
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: + ";
			postfixString.text = "Postfix: 1  2  3  2  ^  ^  4  /  +";
			hint.text = "Pop stack until you find matching brackets, append stack elements to postfix string";
			y++;
			break;
		case (55):
			m.pop ();
			sound.Play ();    
			helperHard.text = "Popping the rest of the stack, appending operands to postfix string";
			valueHard.text = "Current value: [ ";
			hint.text = "Matching bracket found, postfix expression has been formed";
			x++;
			y++;
			break;
		case (56):
			icp.text="";
			isp.text="";
			helperHard.text = "Valid expression, final postfix string: 1 2 3 2 ^ ^ 4 / +";
			postfixString.text = "Postfix:  1  2  3  2  ^  ^  4  /  +";
			valueHard.text = "";
			hint.text = "";
			t = new MyStack();
			y++;
			x++;
			break;
		case (57):
			nextButton.text = "Evaluate";
			helperHard.text = "Let's now evaluate our postfix expression";
			skipButton.gameObject.SetActive (false);
			evaluate = false;
			m = new MyStack();
			y++;
			x = 20;
			break;
		case (58):
			nextButton.text = "Next Step";
			exprDisplay.text = "Postfix Expression: 1 2 3 2 ^ ^ 4 / +";
			valueHard.text = "Current value: 1";
			helperHard.text = "Operand, pushing to stack";
			hint.text = "When evaluating, always push operands to stack";
			table.gameObject.SetActive (false);
			y++;
			break;
		case (59):
			m.push ("1");
			helperHard.text = "Pushed operand to stack. Remaining expression: 2 3 2 ^ ^ 4 / +";
			hint.text = "When evaluating, always push operands to stack";
			y++;
			x++;
			break;
		case (60):
			helperHard.text = "Operand, pushing to stack";
			valueHard.text = "Current value: 2";
			y++;
			break;
		case (61):
			helperHard.text = "Pushed operand to stack. Remaining expression: 3 2 ^ ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push("2");
			y++;
			x++;
			break;
		case (62):
			helperHard.text = "Operand, pushing to stack";
			valueHard.text = "Current value: 3";
			y++;
			break;
		case (63):
			helperHard.text = "Pushed operand to stack. Remaining expression: 2 ^ ^ 4 / +";
			m.push ("3");
			y++;
			x++;
			break;
		case (64):
			helperHard.text = "Operand, pushing to stack";
			valueHard.text = "Current value: 2";
			y++;
			break;
		case (65):
			helperHard.text = "Pushed operand to stack. Remaining expression: ^ ^ 4 / +";
			valueHard.text = "Current value: 2";
			m.push ("2");
			y++;
			x++;
			break;
		case (66):
			helperHard.text = "Operator, popping stack twice";
			valueHard.text = "Current value: ^";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			y++;
			break;
		case (67):
			helperHard.text = "Popped stack: _ ^ 2";
			valueHard.text = "Current value: 2";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (68):
			helperHard.text = "Popped stack: 3 ^ 2";
			valueHard.text = "Current value: 3";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			m.pop ();
			sound.Play ();
			y++;
			break;
		case (69):
			helperHard.text = "Applying operation: 3 ^ 2 = 9. Pushing 9 to stack";
			valueHard.text = "Current value: 9";
			y++;
			break;
		case (70):
			helperHard.text = "Pushed operand to stack. Remaining expression: ^ 4 / +";
			valueHard.text = "";
			m.push("9");
			x++;
			y++;
			break;
		case (71):
			helperHard.text = "Operator, popping stack twice.";
			y++;
			break;
		case (72):
			helperHard.text = "Popped stack:_ ^ 9";
			m.pop();
			sound.Play ();
			y++;
			break;
		case (73):
			helperHard.text = "Popped stack: 2 ^ 9";
			m.pop();
			sound.Play ();
			y++;
			break;
		case (74):
			helperHard.text = "Applying operation: 2 ^ 9 = 512. Pushing 512 to stack";
			valueHard.text = "Current value: 512";
			y++;
			break;
		case (75):
			helperHard.text = "Pushed operand to stack. Remaining expression: 4 / +";
			m.push("512");
			x++;
			y++;
			break;
		case (76):
			helperHard.text = "Operand, pushing to stack";
			valueHard.text = "Current value: 4";
			hint.text = "When evaluating, always push operands to stack";
			y++;
			break;
		case (77):
			helperHard.text = "Pushed operand to stack. Remaining expression: / +";
			valueHard.text = "Current value: 4";
			hint.text = "When evaluating, always push operands to stack";
			m.push("4");
			y++;
			x++;
			break;
		case (78):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: /";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			y++;
			break;
		case (79):
			helperHard.text = "Popped stack: _ / 4";
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: 4";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			y++;
			break;
		case (80):
			helperHard.text = "Popped stack: 512 / 4";
			m.pop ();
			sound.Play ();
			valueHard.text = "Current value: 512";
			hint.text = "When evaluating, operators cause the stack to pop twice. Put the first element on the right of the expression, the second on the left";
			y++;
			break;
		case (81):
			helperHard.text = "Applying operation: 512 / 4 = 128. Pushing 128 to stack. Remaining expression: +";
			valueHard.text = "Current value: 128";
			y++;
			break;
		case (82):
			helperHard.text = "Pushed operand to stack. Remaining expression: +";
			valueHard.text = "Current value: 128";
			m.push("128");
			y++;
			x++;
			break;
		case (83):
			helperHard.text = "Operator, popping stack twice.";
			valueHard.text = "Current value: +";
			y++;
			break;
		case (84):
			helperHard.text = "Popped stack: _ + 1";
			valueHard.text = "Current value: 1";
			m.pop();
			sound.Play ();
			y++;
			break;
		case (85):
			helperHard.text = "Popped stack: 128 + 1";
			valueHard.text = "Current value: +128";
			m.pop();
			sound.Play ();
			y++;
			break;
		case (86):
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

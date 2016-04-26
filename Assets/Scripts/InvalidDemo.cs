using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class InvalidDemo: MonoBehaviour {
	
	static string problem1,problem2, problem3 ,problem4, problem5;
	MyStack m = new MyStack ();
	MyStack t = new MyStack ();
	//Stack<char> main = new Stack<char>();
	//Stack<char> trash = new Stack<char>();
	List<Rect> rects = new List<Rect>();
	List<Rect> garbage = new List<Rect>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int t;
	int x = 0;
	int y = 0;
	int z = 0;
	int ispnum = -1;
	int icpnum = 0;
	bool evaluate;
	public Text txtInval;
	public Text valueInval;
	public Text helperInval;
	public Text postfixString;
	public Text nextButton;
	public Text isp;
	public Text icp;
	public Button nButton;
	public Text hint;
	public Text exprDisplay;
	public Image table;
	public AudioSource sound;
	
	
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
		problem5 = "[ ( 4 - 3 ) * ( 4 + 5 ]";
		prob3 = problem3.ToCharArray ();
		exprDisplay.text = "Infix Expression: " + problem5;
		icp.text = "";
		isp.text = "";
		
		
	}
	
	// Update is called once per frame
	void Update () {


		
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
		switch (y)
		{
		case (0):
			helperInval.text = "Pushing a scope opener";
			valueInval.text = "Current value: [ ";
			hint.text = "Hint: Always push scope openers";
			y++;
			break;
		case (1):
			m.push ("[");
			helperInval.text = "Pushed scope opener to stack";
			y++;
			x++;
			break;
		case (2):
			helperInval.text = "Pushing a scope opener";
			valueInval.text = "Current value: ( ";
			hint.text = "Hint: Always push scope openers";
			y++;
			break;
		case (3):
			m.push ("(");
			helperInval.text = "Pushed scope opener to stack";
			y++;
			x++;
			break;
		case (4):
			helperInval.text = "Operand, discarding";
			valueInval.text = "Current value: 4 ";
			hint.text = "Always discard operands when checking for bracket matching";
			y++;
			x++;
			break;
		case (5):
			helperInval.text = "Operator, discarding";
			valueInval.text = "Current value: - ";
			hint.text = "Always discard operators when checking for bracket matching";
			y++;
			x++;
			break;
		case (6):
			helperInval.text = "Operand, discarding";
			valueInval.text = "Current value: 3 ";
			hint.text = "Always discard operands when checking for bracket matching";
			y++;
			x++;
			break;
		case(7):
			helperInval.text = "Pushing a scope closer";
			valueInval.text = "Current value: )";
			hint.text = "Pop stack after pushinga scope closer, make sure the brackets match";
			y++;
			break;
		case (8):
			m.push (")");
			helperInval.text = "Pushed scope closer to stack";
			y++;
			break;
		case (9):
			m.pop ();
			sound.Play ();
			helperInval.text = "Popping stack: _ )";
			y++;
			break;
		case (10):
			m.pop ();
			sound.Play ();
			helperInval.text = "Popping stack: ( )";
			y++;
			break;
		case (11):
			helperInval.text = "Brackets match! Moving on with expression";
			y++;
			x++;
			break;
		case (12):
			helperInval.text = "Operator, discarding";
			valueInval.text = "Current value: * ";
			hint.text = "Always discard operators when checking for bracket matching";
			y++;
			x++;
			break;
		case(13):
			helperInval.text = "Pushing a scope opener";
			valueInval.text = "Current value: (";
			hint.text = "Always push scope openers";
			y++;
			break;
		case (14):
			m.push ("(");
			helperInval.text = "Pushed scope opener to stack";
			y++;
			break;
		case (15):
			helperInval.text = "Operand, discarding";
			valueInval.text = "Current value: 4 ";
			hint.text = "Always discard operands when checking for bracket matching";
			y++;
			x++;
			break;
		case (16):
			helperInval.text = "Operator, discarding";
			valueInval.text = "Current value: + ";
			hint.text = "Always discard operators when checking for bracket matching";
			y++;
			x++;
			break;
		case (17):
			helperInval.text = "Operand, discarding";
			valueInval.text = "Current value: 5 ";
			hint.text = "Always discard operands when checking for bracket matching";
			y++;
			x++;
			break;
		case(18):
			helperInval.text = "Pushing a scope closer";
			valueInval.text = "Current value: ]";
			hint.text = "Pop stack after pushinga scope closer, make sure the brackets match";
			y++;
			break;
		case (19):
			m.push ("]");
			helperInval.text = "Pushed scope closer to stack";
			y++;
			break;
		case (20):
			m.pop ();
			sound.Play ();
			helperInval.text = "Popping stack: _ ]";
			y++;
			break;
		case (21):
			m.pop ();
			sound.Play ();
			helperInval.text = "Popping stack: ( ]";
			y++;
			break;
		case (22):
			valueInval.text = "";
			helperInval.text = "Uh oh, our brackets don't match. Invalid expression";
			hint.text = "";
			nButton.gameObject.SetActive(false);
			break;
		default:
			break;
		}
	}
}

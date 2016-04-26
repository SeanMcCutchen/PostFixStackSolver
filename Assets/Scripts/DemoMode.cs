using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

public class DemoMode : MonoBehaviour {
	
	static string problem1,problem2, problem3 ,problem4;
	MyStack m = new MyStack ();
	//Stack<char> main = new Stack<char>();
	//Stack<char> trash = new Stack<char>();
	List<Rect> rects = new List<Rect>();
	string numbers = "0123456789";
	string expressions = "+-/*^()[]";
	int x = 0;
	int y = 0;
	int z = 0;
	public Text txt;
	public Text value;
	public Text helper;
	public Button btn;
	public AudioSource sound;

	char [] prob;

	bool which;
	int countop,countcp,countobr, countcbr;
	// Use this for initialization
	void Start () {
		
		problem1 = "[2*(6/2)+(3^2)]";
		problem2 = "[(2+4)+3*(4/2)";
		problem3 = "[1+(2^2^2)/6]";
		problem4 = "[8-(3+1)]";

		helper.text = "";
		which = false;
/*		countop = problem1.Split('(').Length - 1;
		countcp = problem1.Split(')').Length - 1;
		countobr = problem1.Split('[').Length - 1;
		countcbr = problem1.Split(']').Length - 1;
		*/
		prob = problem1.ToCharArray ();
		txt.text = "Expression: " + problem1;

	//	prob3 = problem3.ToCharArray ();
	//txtHard.text = "Expression: " + problem3;
	

		
	}

	// Update is called once per frame
	void Update () {
		if (x < prob.Length)
		value.text = "Current value: " +prob[x];
		//valueHard.text = "Current value: " + prob [x];
		// Rectangle needs to be added
		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 90;
				rects[i] = temp;
			}
			rects.Add (new Rect (80, 80, 150, 75));
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
/*		
		else if (garbage.Count < t.size () ) {
			// Update other rectangles
			for (int i = 0; i < garbage.Count; ++i) {
				Rect temp = garbage[i];
				temp.y += 60;
				garbage[i] = temp;
			}
			garbage.Add (new Rect (1400, 70, 100, 50));
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
*/		
	}
	
	void OnGUI () {

		if (m.size () > 0 ) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"");
			}		

		}

		else if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i)+"");
			}		
		}

		}
		


	public void bracketDemo(){
		switch (y)
		{
		case (0):
			helper.text = "Our current value is a scope opener";
			y++;
			break;
		case(1):
			helper.text = "Always push scope openers";
			y++;
			break;
		case (2):
			m.push ("[");
			helper.text = "Pushing scope opener";
			y++;
			break;
		case (3):
			helper.text = "Operand, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (4):
			helper.text = "Operator, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (5):
			helper.text = "Our current value is a scope opener";
			x++;
			y++;
			break;
		case (6):
			helper.text = "Always push scope openers";
			y++;
			break;
		case (7):
			m.push ("(");
			helper.text = "Pushing scope opener";
			y++;
			break;
		case (8):
			helper.text = "Operand, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (9):
			helper.text = "Operator, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (10):
			helper.text = "Operand, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (11):
			helper.text = "Our current value is a scope closer";
			y++;
			x++;
			break;
		case (12):
			helper.text = "Let's push it to the stack";
			y++;
			break;
		case (13):
			helper.text = "Pushing scope closer to the stack";
			m.push (")");
			y++;
			break;
		case (14):
			helper.text = "We now need to pop the stack twice to check for matching brackets";
			y++;
			break;
		case (15):
			m.pop ();
			sound.Play ();
			helper.text = "Popped thed stack. Let's pop again:  )";
			y++;
			break;
		case (16):
			m.pop ();
			sound.Play ();
			helper.text = "Now we compare: (  )";
			y++;
			break;
		case (17):
			helper.text = "The brackets match! Let's continue through the expression";
			y++;
			break;
		case (18):
			helper.text = "Operator, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (19):
			helper.text = "Our current value is a scope opener";
			y++;
			x++;
			break;
		case (20):
			helper.text = "Always push scope openers";
			y++;
			break;
		case (21):
			m.push ("(");
			helper.text = "Pushing scope opener";
			y++;
			break;
		case (22):
			helper.text = "Operand, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (23):
			helper.text = "Operator, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (24):
			helper.text = "Operand, discarding. While checking for bracket validity we ignore operators and operands";
			y++;
			x++;
			break;
		case (25):
			helper.text = "Our current value is a scope closer";
			y++;
			x++;
			break;
		case (26):
			helper.text = "Let's push it to the stack";
			y++;
			break;
		case (27):
			helper.text = "Pushing scope closer to the stack";
			m.push (")");
			y++;
			break;
		case (28):
			helper.text = "We now need to pop the stack twice to check for matching brackets";
			y++;
			break;
		case (29):
			m.pop ();
			sound.Play ();
			helper.text = "Popped the stack. Let's pop again:  )";
			y++;
			break;
		case (30):
			m.pop ();		
			sound.Play ();
			helper.text = "Now we compare: (  )";
			y++;
			break;
		case (31):
			helper.text = "The brackets match! Let's continue through the expression";
			y++;
			break;
		case (32):
			helper.text = "Our current value is a scope closer";
			y++;
			x++;
			break;
		case (33):
			helper.text = "Let's push it to the stack";
			y++;
			break;
		case (34):
			helper.text = "Pushing scope closer to the stack";
			m.push ("]");
			y++;
			break;
		case (35):
			helper.text = "We now need to pop the stack twice to check for matching brackets";
			y++;
			break;
		case (36):
			m.pop ();
			sound.Play ();
			helper.text = "Popped the stack. Let's pop again:  ]";
			y++;
			break;
		case (37):
			m.pop ();
			sound.Play ();
			helper.text = "Now we compare: [  ]";
			y++;
			break;
		case (38):
			helper.text = "The brackets match!";
			y++;
			x++;
			break;
		case (39):
			helper.text = "Valid expression";
			value.text = "";
			btn.gameObject.SetActive(false);
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
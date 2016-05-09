using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;
public class PracticeMode : MonoBehaviour {

	//var expr = new List<Type>();


	List<string> expr = new List<string>{"1 + ( 52 - 34 )", "[ ( 5 + 7 ) * ( 23 - 5 ) ]", "100 / ( 5 * 4 ) ","[ ( 2 ^ 3 ) - 8 ]"
		, "5 * 8 - 8 / 4", "( 55 / 5 + 27 ) + 5 ^ 2", "55 / 5 - 10", "[1 + ( 5 * 8 - 10 ) / 6 ] "
		, "[ ( 5 ^ 3 ^ 2 ) / ( 100 - 19 * 5 ) ]", "( 3 ^ 2 ^ 3 ) ",
		"50 - ( 3 + 7 * 4 / 2 ) ", "[ ( 5 ^ 2 ) / 5 ] ", 
		"( 20 * 3 + 4 ) / ( 2 ^ 3 ) ", " 50 * 3 / 25 + 37 ", "5 * ( 30 / 6 + 22 ) ", 
		"120 / ( 6 * 5 * 2 ) ", "( ( ( 1 + 2 ) * 3 ) + 6 ) / ( 2 + 3 ) ", "( 8 / 4 ) / ( 120 / 60 ) ",
		"[ ( 5 ^ 3 ) / 5 ^ 2 ] ", "8 * 10 / 20 + 3 ", "[ ( 7 * 5 ) + ( 3 ^ 4 ) ]", "5 ^ 3 ^ 2 ",
		"[ ( 2 ^ 3 + 2 ^ 4 ) / 4 ] ", "( ( ( 7 + 2 ) * 3 ) + 6 ) / ( 2 + 1 ) ", "[ ( 2 ^ 3 ) * ( 43 - 11 * 3 ) ] ",
		"( 3 * 5 ^ 3 ) / 25", "45 * 2 / 9 + 3 - 11 ", "[ ( 45 / 5 * 10 ) / ( 33 / 11 ) ] ",
		"[ ( 5 ^ 3 ) / ( 50 / 10 ) + 27 ] ", "( 2 ^ 4 ) / ( 4 ^ 2 )", "5 + 44 / 4 - 7 ",
		"[ ( 5 ^ 2 + 5 * 20 ) / ( 125 / 5 ) ] ", "( 8 ^ 2 ) / 4 + 3 ^ 4 ", "[ 2 ^ ( 60 / 30 + 2 ) ] ", 
		"[ ( 4 * 5 + 7 ) / ( 3 ^ 2 ) ] ", "30 * 2 / 15 + 37 ", "4 ^ 2 + 18 / 2 ", "[ ( 4 + 33 ) + ( 124 / 4 ) ] ",
		"[ 5 * 3 / ( 7 - 2 ) ] " };                   
	List<string> postfixes = new List<string>{"1 52 34 - + ", "5 7 + 23 5 - * ","100 5 4 * / ", "2 3 ^ - 8 ", "5 8 * 8 4 / - ",
		"55 5 / 27 + 5 2 ^ + ",
		"55 5 / 10 - "," 1 5 8 * 10 - 6 / + "," 5 3 ^ 2 ^ 100 19 5 * - / "," 3 2 ^ 3 ^ ",
		"50 3 7 4 * 2 / + - ", "5 2 ^ 5 / ", "20 3 * 4 + 2 3 ^ / ", "50 3 * 25 / 37 + "," 5 30 6 / 22 + * ", 
		"120 6 5 * 2 * / " ," 1 2 + 3 * 6 + 2 3 + / "," 8 4 / 120 60 / / ", "5 3 ^ 5 2 ^ / ",
		"8 10 * 20 / 3 + ", "7 5 * 3 4 ^ + "," 5 3 ^ 2 ^ "," 2 3 ^ 2 4 ^ + 4 / ", "7 2 + 3 * 6 + 2 1 + / ",
		"2 3 ^ 43 11 3 * - * "," 3 5 3 ^ * 25 / ","45 2 * 9 / 3 + 11 - "," 45 5 / 10 * 33 11 / / ",
		"5 3 ^ 50 10 / / 27 + ", "2 4 ^ 4 2 ^ / "," 5 44 4 / + 7 - ", "5 2 ^ 5 20 * + 125 5 / / ",
		"8 2 ^ 4 / 3 4 ^ + "," 2 60 30 / 2 + ^ "," 4 5 * 7 + 3 2 ^ / "," 30 2 * 15 / 37 + ", 
		"4 2 ^ 18 2 / + ", "4 33 + 124 4 / + ", "5 3 * 7 2 - / "}; 
	MyStack m = new MyStack ();
	public Text infixString;
	public Text postfixString;
	public Text currvalue;
	public Text validity;
	List<string> brackets = new List<string>{ "{","(","[",")","]","}"};
	private int probindex = 0; 
	List<Rect> rects = new List<Rect>();
	//List<string> pops = new List<string> ();
	String postfix;
	String [] test;
	String popped;
	public Button checkPostFix,checkEval,applyOP,append,pop,push,invalid,resetbtn,discardbtn,num1,num3,num6,num7;
	List <Button> btnlist = new List<Button>();
	public Image table;
	public AudioSource sound;
	bool bracket, build, eval,isvalid, canpop; 
	int temp1,temp2,temp3,wrong, icp, theiricp;
	bool switchToPostFix = false;
	bool switchToEvaluate = false;
	bool newprob = false;
	int checkWhenOver = 0;
	int curr = 0;
	int currFix = 0;
	bool bracketEval = false;


	// Use this for initialization
	void Start () {
		table.gameObject.SetActive (false);
		test = expr [probindex].Split (' ');
		theiricp = 0;
		canpop = true;
		btnlist.Add (checkPostFix);
		btnlist.Add (checkEval);
		btnlist.Add (applyOP);
		btnlist.Add (append);
		btnlist.Add (pop);
		btnlist.Add (push);
		btnlist.Add (invalid);
		btnlist.Add (resetbtn);
		btnlist.Add (discardbtn);
		btnlist.Add (num1);
		btnlist.Add (num3);
		btnlist.Add (num6);
		btnlist.Add (num7);
		hideAllBut(new List<Button>{discardbtn,push,pop,invalid,resetbtn});
		//checkEval.gameObject.SetActive(false);
	}


	// Update is called once per frame
	void Update () {
		
		//StringBuilder strBuilder = new StringBuilder(expr[probindex]);
	//	strBuilder[curr] =string.Format("<color=blue>{0}</color>",test[curr]);
		if (checkWhenOver == 0)
			bracketEval = true;
		if (checkWhenOver == 2) {
			bracketEval = false;
			table.gameObject.SetActive (true);
			switchToPostFix = true;
			hideAllBut(new List<Button>{append,push,pop,invalid,checkPostFix,resetbtn,num1,num3,num6,num7});
		}
		if (checkWhenOver == 3) {
			switchToPostFix = false;
			switchToEvaluate = true;
			table.gameObject.SetActive (false);

			hideAllBut(new List<Button>{push,pop,applyOP,checkEval,resetbtn});
		}
		if (curr == test.Length) {
			foreach (Button kk in btnlist) 
					kk.gameObject.SetActive(true);
			checkWhenOver = 2;
			curr = 0;
		}
		if (checkWhenOver == 2&&curr == test.Length-1&&m.isEmpty()==true) {
			foreach (Button kk in btnlist) 
				kk.gameObject.SetActive(true);
			checkWhenOver = 3;
			curr = 0;
		}
		if (checkWhenOver == 3 && curr == test.Length-1&&m.isEmpty()==true) {
			

			loadnextProb ();

		}
	

		//expr[probindex]=strBuilder.ToString();
		StringBuilder str = new StringBuilder();
		for (int t = 0; t < test.Length; t++){
	
			if (curr<test.Length&&test[t] == test [curr]&&t==curr)
				str.Append (string.Format ("<color=yellow>{0}</color>", test [curr]));
			else
				str.Append (test[t]);
		}

			
		if (switchToEvaluate != true||newprob==true) {
			postfixString.text = postfix;
			infixString.text = "Infix String: " + str.ToString();
		}
		if(switchToPostFix!=true && switchToEvaluate != true&& curr<test.Length)
			currvalue.text = "Current Value: " + test [curr];
		


		/*if(prob index == index of invalid expression)
		 * isvalid = false;
		 * 
		 * 
		 * 
		 */

		if (rects.Count < m.size () ) {
			// Update other rectangles
			for (int i = 0; i < rects.Count; ++i) {
				Rect temp = rects[i];
				temp.y += 90;
				rects[i] = temp;
			}
			rects.Add (new Rect (145,220, 150, 75));
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

	public void help(){
		
	}

	public void pushToStack ()
	{
		if (switchToEvaluate == true) {
			m.push(test[curr]);
			curr++;
		}
		if (switchToPostFix==true&&switchToEvaluate==false) {
			if (checkICP() == true) {
				validity.text = "";
				m.push (test [curr]);
				curr++;
				theiricp = 0;
			}
			else 
				validity.text = "Wrong ICP";
		}
		if (curr < test.Length&&switchToPostFix==false&&switchToEvaluate==false) {
			if ("})]".Contains (test [curr]))
				m.push (test [curr]);
			else {
				m.push (test [curr]);
				curr++;
			}
		} 



	}
	public void discard ()
	{
		if (curr < test.Length) {
			curr++;
			currvalue.text = "Current value: "+ test [curr];
		}
	}
	public void checkAnswer()
	{
		int x = Int32.Parse (m.getAt (m.getTop ()));

		//Debug.Log (x + "x");
		if (Int32.Parse (m.getAt (m.getTop ())) == postfixsolver.solve (postfixes [probindex])) {
			validity.text = "Correct Answer!";
			System.Threading.Thread.Sleep(500);
			loadnextProb ();


		}
		else {
			validity.text = "Wrong, the correct answer is " + postfixsolver.solve (postfixes [probindex]);
			System.Threading.Thread.Sleep(500);
			reset ();
		}
		


	}
	public string popS() {
		var temp = m.pop ();
		sound.Play ();
		return temp;
	}
	public bool checkICP()
	{
		switch (test [curr]) {
		case("+"):
			icp = 1;
			break;
		case("-"):
			icp = 1;
			break;
		case("*"):
			icp = 3;
			break;
		case("/"):
			icp = 3;
			break;
		case("^"):
			icp = 6;
			break;
		case("("):
			icp = 7;
			break;
		case("{"):
			icp = 7;
			break;	
		case("["):
			icp = 7;
			break;
		default:
			icp = 0;
			break;
		}
		if (theiricp == icp)
			return true;
		else
			return false;

	}
	public void hideAllBut(List<Button> btn){
		foreach (Button kk in btnlist) {
			if(btn.Contains(kk)==false)
				kk.gameObject.SetActive(false);
		}

	}

	public void appendToString()
	{
		if (curr < test.Length) {
			postfix = string.Concat (postfix,  test [curr] + " ");
			curr++;
		}
	}


	public void checkValid()
	{

		if (isvalid == true)
			wrong = -1;
		else 
			wrong = 1;


	}

	public void popStack()
	{
		
		if (test[curr] != "]"&&bracketEval==true)
		if (m.getAt (m.getTop()) == "[") {
			canpop = false;
			validity.text = "Brackets don't match up";
			hideAllBut (new List<Button>{invalid});
		}
		if (test[curr] != ")"&&bracketEval==true)
		if (m.getAt (m.getTop()) == "(") {
			canpop = false;
			validity.text = "Brackets don't match up";
			hideAllBut (new List<Button>{invalid});
		}
		if (test[curr]!= "}"&&bracketEval==true)
		if (m.getAt (m.getTop()) == "{") {
			canpop = false;
			validity.text = "Brackets don't match up";
			hideAllBut (new List<Button>{invalid});
		}
		if (switchToPostFix == true && brackets.Contains (m.getAt(m.getTop())) == false)
			postfix = string.Concat (postfix, m.getAt(m.getTop()))+" ";
		if (m.isEmpty () == false && canpop == true&&switchToPostFix==false) {
			popped = popS ();
			curr++;
		}
		if (m.isEmpty () == false && canpop == true) {
			popped = popS ();

		}

	//	if(popped != "(" && popped != "[" && popped != ")" && popped != "]")
		//	postfix = string.Concat (postfix,  popped + " " );
	}

	public void checkpostfix() {
		Debug.Log (postfix);
		Debug.Log (postfixes [currFix]);
		if (postfix == postfixes [currFix]&&switchToPostFix==true)
		{
			
			infixString.text = "Postfix String: " + postfix;
			postfixString.text = "";
			currvalue.text = "";
			test = postfix.Split (' ');
			validity.text = "Correct postfix expression!";
			checkWhenOver = 3;
			curr = 0;
			foreach (Button kk in btnlist) 
				kk.gameObject.SetActive(true);
		
		}
		else
			validity.text = "Incorrect postfix expression";

	}
	public void setICP1()
	{
		theiricp = 1;
	}
	public void setICP3()
	{
		theiricp = 3;
	}
	public void setICP6()
	{
		theiricp = 6;
	}
	public void setICP7()
	{
		theiricp = 7;
	}



	public void applyOperation() {
		if (test[curr] == "+"&&m.size()>=2) {
			temp2 = System.Int32.Parse(popS ());
			temp1 = System.Int32.Parse(popS ());
			temp3 = temp1 + temp2;
			m.push (temp3.ToString());
			curr++;
		}
		else if (test [curr] == "-"&&m.size()>=2) {
			temp2 = System.Int32.Parse(popS ());
			temp1 = System.Int32.Parse(popS ());
			temp3 = temp1 - temp2;
			m.push (temp3.ToString());
			curr++;
		}
		else if (test[curr] == "*"&&m.size()>=2) {
			temp2 = System.Int32.Parse(popS ());
			temp1 = System.Int32.Parse(popS ());
			temp3 = temp1 * temp2;
			m.push (temp3.ToString());
			curr++;
		}
		else if (test[curr] == "/"&&m.size()>=2) {
			temp2 = System.Int32.Parse(popS ());
			temp1 = System.Int32.Parse(popS ());
			temp3 = temp1 / temp2;
			m.push (temp3.ToString());
			curr++;
		}
		else if (test [curr] == "^"&&m.size()>=2) {
			temp2 = System.Int32.Parse(popS ());
			temp1 = System.Int32.Parse(popS ());
			temp3 = (int)Math.Pow (temp1,temp2);
			m.push (temp3.ToString());
			curr++;
		}
	}


	public void reset() {
		curr = 0;
		currvalue.text = "Current value: " + test [curr];
		m = new MyStack ();
		postfix = "";	validity.text = "";
		checkWhenOver = 0;
		foreach (Button kk in btnlist) 
			kk.gameObject.SetActive(true);
		hideAllBut(new List<Button>{discardbtn,push,pop,invalid,resetbtn});
	}

	public void loadnextProb() {
		probindex++;
		currFix++;
		test = expr [probindex].Split (' ');
		newprob = true;
		bracketEval = true;
		switchToEvaluate = false;
		switchToPostFix = false;
		curr = 0;
		checkWhenOver = 0;
		validity.text = "";
		currvalue.text = "Current value: " + test [curr];
		m = new MyStack ();
		postfix = "";
		foreach (Button kk in btnlist) 
			kk.gameObject.SetActive(true);
		hideAllBut(new List<Button>{discardbtn,push,pop,invalid,resetbtn});
	}
	void OnGUI () {

		GUIStyle style = new GUIStyle (GUI.skin.button);
	
		style.fontSize = 40;

		if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i) + "", style);
			}		
		

		} else if (m.size () > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.contentColor = Color.green;
				GUI.Box (rects [i], m.getAt (i) + "", style);
			}		
		}
	}




}
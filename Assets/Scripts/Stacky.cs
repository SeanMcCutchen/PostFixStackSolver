using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyStack {
	
	private string[] elems;
	private int top;
	
	public MyStack() {
		elems = new string[100];
		top = -1;
	}
	
	public void push(string elem) {
		top += 1;
		if (top < elems.Length) {
			//We have space!
			elems [top] = elem;
		} else {
			//We don't have space!
			//TODO copy array into bigger array
			Debug.Log ("Ran out of stack space!");
		}
	}
	
	public string pop() {
		if (top < 0) {
			return "Undefined";
		}
		string ret = elems [top];
		top -= 1;
		return ret;
	}
	
	public string peek() {
		if (top < 0) {
			return "Undefined";
		}
		return elems [top];
	}
	
	public bool isEmpty() {
		return (top == -1);
	}
	
	public int size() {
		return top+1;
	}
	public string getAt(int index) {
		return elems [index];
	}
}

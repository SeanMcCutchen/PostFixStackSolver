using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

	MyStack stack;
	List<Rect> rects = new List<Rect>();
	MyStack trash;
	List<Rect> garbage = new List<Rect>();
	// Use this for initialization
	void Start () {
		stack = new MyStack ();
		trash = new MyStack();
	}
	// Update is called once per frame
	void Update () {
		// Rectangle needs to be added
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

	    else if (garbage.Count < trash.size ()) {
		// Update other rectangles
		for (int i = 0; i < garbage.Count; ++i) {
			Rect temp = garbage[i];
			temp.y += 60;
			garbage[i] = temp;
		}
		garbage.Add (new Rect (200, 50, 100, 50));
		Debug.Log ("adding rect");
		
		
	} else if (garbage.Count > trash.size ()) {
		for (int i = 0; i < garbage.Count; ++i) {
			Rect temp = garbage[i];
			temp.y -= 60;
			garbage[i] = temp;
		}
		garbage.RemoveAt(garbage.Count-1);
		Debug.Log ("removing rect");
		}
	}
	void OnGUI () {
		if (rects.Count > 0) {
			for (int i = 0; i < rects.Count; ++i) {
				GUI.Box (rects [i], stack.getAt (i));
			}
		}
			else if (garbage.Count > 0) {
				for (int i = 0; i < garbage.Count; ++i) {
					GUI.Box (rects[i], trash.getAt(i));
				}
		}
		
	}
}

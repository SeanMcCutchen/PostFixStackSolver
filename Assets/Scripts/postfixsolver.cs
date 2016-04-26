using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class postfixsolver : MonoBehaviour {
	

	public static int solve(string postfix){
				postfix = postfix.Trim();
				string[] ans = postfix.Split(' ');
                Stack<int> eval = new Stack<int>();
	
                for (int x = 0; x < ans.Length; x++)
                {
                    if ("*+%/-^".Contains(ans[x]))
                    {
                        int temp1;
                        int temp2;

                        switch (ans[x])
                        {
				case ("^"):
					temp1 = eval.Pop ();
					temp2 = eval.Pop ();

					eval.Push ((int)Math.Pow (temp2, temp1));
								break;
                            case ("*"):
					temp1 = eval.Pop();
					temp2 = eval.Pop();
                                eval.Push(temp1*temp2);
                                break;
                            case "-":
                                temp1 = eval.Pop();
                                temp2 = eval.Pop();
                                eval.Push(temp2 - temp1);
                                break;
                            case "%":
                                temp1 = eval.Pop();
                                temp2 = eval.Pop();
                                eval.Push(temp2 % temp1);
                                break;
                            case "+":
                                eval.Push(eval.Pop() + eval.Pop());
                                break;
				case "/":
					temp1 = eval.Pop ();
					temp2 = eval.Pop ();
					eval.Push (temp2 / temp1);
					break;
                        }
			
                    }
                    else
                        eval.Push(System.Int32.Parse(ans[x]));
			
                }
		int answer = eval.Pop();
		return answer;
	}
}
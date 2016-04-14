using System;
using System.Collections;
using System.Text;

using UnityEngine;


public class  infixTopostfix : MonoBehaviour{
	public void test ()
	{
		Debug.Log(createPrefix("(6+42)/2+(3^2)"));
	}
	private string strResult = "";

	private int isOperand(char chrTemp)
		{
			char[] op = new char[6] { '*', '/', '+', '-', '^', '(' };
			foreach(char chr in op)
				if (chr == chrTemp)
				{
					return 1;
				}
			return 0;
		}
	private int isOperator(char chrTemp)
		{
			char[] op = new char[5] { '*', '/', '+', '-', '^' };
			foreach (char chr in op)
				if (chr == chrTemp)
				{
					return 1;
				}
			return 0;
		}


	public string createPrefix(string strInput)
		{
			int intCheck = 0;
			//int intStackCount = 0;
			object objStck=null;
			for (int intNextToken = 0; intNextToken <= strInput.Length - 1; intNextToken++)
			{
				intCheck = isOperand(strInput[intNextToken]);
				if (intCheck == 1)
					stkOperator.Push(strInput[intNextToken]);
				else
					if (strInput[intNextToken] == ')')
					{
						int c = stkOperator.Count;
						for (int intStackCount = 0; intStackCount <= c-1; intStackCount++)
						{
							objStck = stkOperator.Pop();
							intCheck = isOperator(char.Parse(objStck.ToString()));
							if (intCheck == 1)
							{
								strResult +=objStck.ToString()+" ";
							}
						}//end of for(int intStackCount...)
					}
					else
						strResult += strInput[intNextToken];

			}//end of for(int intNextToken...)
			int intCount = stkOperator.Count;
			if (intCount > 0)
			{
				int c = stkOperator.Count;
				for (int intStackCount = 0; intStackCount <= c-1 ; intStackCount++)
				{
					objStck = stkOperator.Pop();
					intCheck = isOperator(char.Parse(objStck.ToString()));
					if (intCheck == 1)
					{
					strResult += objStck.ToString()+ " ";
					}
				}//end of for(int intStackCount...)
			}

	

		return strResult;
		}

		private Stack stkOperator = new Stack();

	}


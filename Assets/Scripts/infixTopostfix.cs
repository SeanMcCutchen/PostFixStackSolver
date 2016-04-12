using System;
using System.Collections;
using System.Text;

	class infixTopostfix
	{
		public infixTopostfix(string strTemp)
		{
			strInput = strTemp;
		}

		private int isOperand(char  chrTemp)
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

		private string strResualt = "";
		private string strInput = "";
		public string createPrifex()
		{
			int intCheck = 0;
			//int intStackCount = 0;
			object objStck=null;
			for (int intNextToken = 0; intNextToken <= strInput.Length - 1; intNextToken++)
			{
				intCheck = isOperand(strInput[intNextToken]);
				if (intCheck == 1)
					stkOperatore.Push(strInput[intNextToken]);
				else
					if (strInput[intNextToken] == ')')
					{
						int c = stkOperatore.Count;
						for (int intStackCount = 0; intStackCount <= c-1; intStackCount++)
						{
							objStck = stkOperatore.Pop();
							intCheck = isOperator(char.Parse(objStck.ToString()));
							if (intCheck == 1)
							{
								strResualt += objStck.ToString();
							}
						}//end of for(int intStackCount...)
					}
					else
						strResualt += strInput[intNextToken];

			}//end of for(int intNextToken...)
			int intCount = stkOperatore.Count;
			if (intCount > 0)
			{
				int c = stkOperatore.Count;
				for (int intStackCount = 0; intStackCount <= c-1 ; intStackCount++)
				{
					objStck = stkOperatore.Pop();
					intCheck = isOperator(char.Parse(objStck.ToString()));
					if (intCheck == 1)
					{
						strResualt += objStck.ToString();
					}
				}//end of for(int intStackCount...)
			}

			return strResualt;
		}

		private Stack stkOperatore = new Stack();

	}


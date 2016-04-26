using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MathBot.MathClasses
{
	public class OperatorPriority
	{
		private static Dictionary<char, int> operatorPriority;

		public OperatorPriority()
		{
			if (operatorPriority.Equals(null))
			{
				operatorPriority = new Dictionary<char, int>();
				operatorPriority.Add('(', 4);
				operatorPriority.Add(')', 0);
				operatorPriority.Add('^', 1);
				operatorPriority.Add('*', 2);
				operatorPriority.Add('/', 2);
				operatorPriority.Add('+', 3);
				operatorPriority.Add('-', 3);
			}
		}
		public int ReturnOperatorsPriority(char operatorKey)
		{
			int priority = -1;

			try
			{
				operatorPriority.TryGetValue(operatorKey, out priority);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return priority;
		}
	}

	public class PostfixConverter
	{
		private string infixNotation;
		private string postfixNotation;
		public OperatorPriority op;

		public PostfixConverter(string infix)
		{
			infixNotation = infix;
			op = new OperatorPriority();
		}

		public void Converter()
		{
			Stack operators = new Stack();
			foreach (char c in infixNotation)
			{
				if(CheckIfOperand(c.ToString()))
				{
					postfixNotation += c;
				}
				else if (operators.Count == 0)
				{
					operators.Push(c);
				}
				else
				{
					HandleStackOperators(c, ref operators);
				}
			}
		}

		public bool CheckIfOperand(string potentialOperand)
		{
			bool success = false;
			string pattern = @"^[a-zA-Z0-9]";

			if (Regex.IsMatch(potentialOperand, pattern))
			{
				success = true;
			}

			return success;
		}

		public void HandleStackOperators(char currOperator, ref Stack operators)
		{
			if (OperatorGreaterThanTopOfStack(currOperator, (char)operators.Peek()))
			{
				operators.Push(currOperator);
			}
			else
			{
				postfixNotation += operators.Pop();
				while(!OperatorGreaterThanTopOfStack(currOperator, (char)operators.Peek()))
					postfixNotation += operators.Pop();

				operators.Push(currOperator);
			}
		}

		public bool OperatorGreaterThanTopOfStack(char currOperator, char topStackOperator)
		{
			bool success = true;
			int currOperatorPriority = op.ReturnOperatorsPriority(currOperator);
			int topOperatorPriority = op.ReturnOperatorsPriority(topStackOperator);
			if (currOperator < topOperatorPriority)
			{
				success = false;
			}
			return success;
		}

		public string ConvertAndReturn()
		{
			Converter();
			return postfixNotation;
		}

		public string ReturnPostfix()
		{
			return postfixNotation;
		}
		
	}
}

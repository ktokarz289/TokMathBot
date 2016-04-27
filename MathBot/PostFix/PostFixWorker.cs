using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostFix
{
	public class OperatorPriority
	{
		private static Dictionary<char, int> operatorPriority;
		private static Dictionary<char, int> operatorPriorityInStack;

		public OperatorPriority()
		{
			if (operatorPriority == null)
			{
				operatorPriority = new Dictionary<char, int>();
				operatorPriority.Add('(', 4);
				operatorPriority.Add(')', 5);
				operatorPriority.Add('^', 3);
				operatorPriority.Add('*', 2);
				operatorPriority.Add('/', 2);
				operatorPriority.Add('+', 1);
				operatorPriority.Add('-', 1);
			}

			if (operatorPriorityInStack == null)
			{
				operatorPriorityInStack = new Dictionary<char, int>();
				operatorPriorityInStack.Add('(', 0);
				operatorPriorityInStack.Add(')', 5);
				operatorPriorityInStack.Add('^', 3);
				operatorPriorityInStack.Add('*', 2);
				operatorPriorityInStack.Add('/', 2);
				operatorPriorityInStack.Add('+', 1);
				operatorPriorityInStack.Add('-', 1);
			}
		}
		public int ReturnOperatorsPriority(char operatorKey)
		{
			int priority = -1;

			try
			{
				operatorPriority.TryGetValue(operatorKey, out priority);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return priority;
		}

		public int ReturnOperatorsPriorityInStack(char operatorKey)
		{
			int priority = -1;

			try
			{
				operatorPriorityInStack.TryGetValue(operatorKey, out priority);
			}
			catch (Exception e)
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
				if (CheckIfOperand(c.ToString()))
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

			while (operators.Count > 0)
				PopThroughStack(ref operators);
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
				string character = operators.Pop().ToString();
				if (character != "(" && character != ")")
				{
					postfixNotation += character;
					while (operators.Count > 0 && !OperatorGreaterThanTopOfStack(currOperator, (char)operators.Peek()))
					{
						PopThroughStack(ref operators);
					}
				}
				else
				{
					do
					{
						PopThroughStack(ref operators);
					}
					while (operators.Peek().ToString() != "(");
					operators.Pop();
				}

				operators.Push(currOperator);
			}
		}

		public void PopThroughStack(ref Stack operators)
		{
			string character = operators.Pop().ToString();
			if (character != "(" && character != ")")
			{
				postfixNotation += character;
			}
		}

		public bool OperatorGreaterThanTopOfStack(char currOperator, char topStackOperator)
		{
			bool success = false;
			int currOperatorPriority = op.ReturnOperatorsPriority(currOperator);
			int topOperatorPriority = op.ReturnOperatorsPriorityInStack(topStackOperator);
			if (currOperatorPriority > topOperatorPriority)
			{
				success = true;
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

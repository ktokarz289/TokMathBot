using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostfixCalculator
{
    public class PfCalculator
    {
		private List<string> postfixEquation;
		public string CalculatePostfix(List<string> equation)
		{
			string result;
			postfixEquation = equation;
			while(EquationContainsOperators(postfixEquation))
			{
				int operatorIndex = GetIndexOfFirstOperator(postfixEquation);
				result = PerformOperation(operatorIndex);
				ReflectOperationInEquation(operatorIndex, result);
			}
			return ConvertArrayToString(postfixEquation);
		}

		public string ConvertArrayToString(List<string> equation)
		{
			string eqn = "";

			for (int i = 0; i < equation.Count; i++)
				eqn += equation[i];

			return eqn;
		}

		public string AddOperands(string operand1, string operand2)
		{
			int o1, o2, tempResult;
			string result = null;

			try
			{
				int.TryParse(operand1, out o1);
				int.TryParse(operand2, out o2);
				tempResult = o1 + o2;
				result = tempResult.ToString();
			}
			catch(Exception e)
			{
			}

			return result;
		}

		public string SubtractOperands(string operand1, string operand2)
		{
			int o1, o2, tempResult;
			string result = null;

			try
			{
				int.TryParse(operand1, out o1);
				int.TryParse(operand2, out o2);
				tempResult = o1 - o2;
				result = tempResult.ToString();
			}
			catch (Exception e)
			{
			}

			return result;
		}

		public string MultiplyOperands(string operand1, string operand2)
		{
			int o1, o2, tempResult;
			string result = null;

			try
			{
				int.TryParse(operand1, out o1);
				int.TryParse(operand2, out o2);
				tempResult = o1 * o2;
				result = tempResult.ToString();
			}
			catch (Exception e)
			{
			}

			return result;
		}

		public string ExponentOperands(string operand1, string operand2)
		{
			int o1, o2, tempResult;
			string result = null;

			try
			{
				int.TryParse(operand1, out o1);
				int.TryParse(operand2, out o2);
				tempResult = 1;
				for (int i = 0; i < o2; i++)
					tempResult *= o1;
				result = tempResult.ToString();
			}
			catch (Exception e)
			{
			}

			return result;
		}

		public string DivideOperands(string operand1, string operand2)
		{
			int o1, o2;
			decimal tempResult;
			string result = null;

			try
			{
				int.TryParse(operand1, out o1);
				int.TryParse(operand2, out o2);
				tempResult = o1 / o2;
				result = tempResult.ToString();
			}
			catch (Exception e)
			{
			}

			return result;
		}

		public bool EquationContainsOperators(List<string> equation)
		{
			bool success = false;
			string pattern = @"^[*+-/^]";

			for (int i = 0; i < equation.Count; i++)
			{
				if (Regex.IsMatch(equation[i], pattern))
				{
					return true;
				}
			}

			return success;
		}

		public int GetIndexOfFirstOperator(List<string> equation)
		{
			int index = -1;
			string pattern = @"^[*+-/^]";

			for (int i = 0; i < equation.Count; i++)
			{
				if (Regex.IsMatch(equation[i], pattern))
				{
					return i;
				}
			}

			return index;
		}

		public string PerformOperation(int operatorIndex)
		{
			string result = null, operand1, operand2;

			string oper = postfixEquation[operatorIndex];
			operand1 = postfixEquation[operatorIndex - 2].ToString();
			operand2 = postfixEquation[operatorIndex - 1].ToString();

			switch(oper)
			{
				case "^":
					result = ExponentOperands(operand1, operand2);
					break;
				case "*":
					result = MultiplyOperands(operand1, operand2);
					break;
				case "/":
					result = DivideOperands(operand1, operand2);
					break;
				case "+":
					result = AddOperands(operand1, operand2);
					break;
				case "-":
					result = SubtractOperands(operand1, operand2);
					break;
			}

			return result;
		}

		public void ReflectOperationInEquation(int operatorIndex, string result)
		{
			postfixEquation.RemoveRange(operatorIndex - 2, 3);
			postfixEquation.Insert(operatorIndex - 2, result);
		}
	}
}

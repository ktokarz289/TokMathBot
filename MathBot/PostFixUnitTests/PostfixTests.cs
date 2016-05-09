using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostFix;
using System.Collections.Generic;

namespace PostFixUnitTests
{
	[TestClass]
	public class PostfixTests
	{
		[TestMethod]
		public void SimpleEquation()
		{
			PostfixConverter converter = new PostfixConverter("1+2");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "12+");
		}

		[TestMethod]
		public void ComplexEqn1()
		{
			
			PostfixConverter converter = new PostfixConverter("1+2*3");
			List<string> postfix = converter.ConvertAndReturn();

			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}

			Assert.AreEqual(result, "123*+");
		}

		[TestMethod]
		public void ComplexEqn1Inverse()
		{
			PostfixConverter converter = new PostfixConverter("2*3+1");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "23*1+");
		}

		[TestMethod]
		public void ComplexEqn2()
		{
			PostfixConverter converter = new PostfixConverter("2*3+6*(3+4)");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "23*634+*+");
		}

		[TestMethod]
		public void ComplexEqn3()
		{
			PostfixConverter converter = new PostfixConverter("(3+4)*2*3+6");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "34+2*3*6+");
		}

		[TestMethod]
		public void LargerEqn3()
		{
			PostfixConverter converter = new PostfixConverter("12+3");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "123+");
		}

		[TestMethod]
		public void ExpEqn4()
		{
			PostfixConverter converter = new PostfixConverter("2^3");
			List<string> postfix = converter.ConvertAndReturn();
			string result = "";
			foreach (string c in postfix)
			{
				result += c;
			}
			Assert.AreEqual(result, "23^");
		}
	}
}

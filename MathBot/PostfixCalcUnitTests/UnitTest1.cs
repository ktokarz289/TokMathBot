using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PostFix;
using PostfixCalculator;

namespace PostfixCalcUnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestOperatorChecker()
		{
			string answer;
			PostfixConverter converter = new PostfixConverter("1+2");
			List<string> postfix = converter.ConvertAndReturn();

			PfCalculator calc = new PfCalculator();
			answer = calc.CalculatePostfix(postfix);
			Assert.AreEqual("3", answer);
		}

		[TestMethod]
		public void TestOperatorChecker2()
		{
			string answer;
			PostfixConverter converter = new PostfixConverter("1+2*3");
			List<string> postfix = converter.ConvertAndReturn();

			PfCalculator calc = new PfCalculator();
			answer = calc.CalculatePostfix(postfix);
			Assert.AreEqual("7", answer);
		}

		[TestMethod]
		public void ComplexEqn1Inverse()
		{
			string answer;
			PostfixConverter converter = new PostfixConverter("2*3+1");
			List<string> postfix = converter.ConvertAndReturn();

			PfCalculator calc = new PfCalculator();
			answer = calc.CalculatePostfix(postfix);
			Assert.AreEqual("7", answer);
		}

		[TestMethod]
		public void ComplexEqn2()
		{
			string answer;
			PostfixConverter converter = new PostfixConverter("2*3+6*(3+4)");
			List<string> postfix = converter.ConvertAndReturn();

			PfCalculator calc = new PfCalculator();
			answer = calc.CalculatePostfix(postfix);
			Assert.AreEqual("48", answer);
		}

		[TestMethod]
		public void ComplexEqn3()
		{
			string answer;
			PostfixConverter converter = new PostfixConverter("2^3");
			List<string> postfix = converter.ConvertAndReturn();

			PfCalculator calc = new PfCalculator();
			answer = calc.CalculatePostfix(postfix);
			Assert.AreEqual("8", answer);
		}
	}


}

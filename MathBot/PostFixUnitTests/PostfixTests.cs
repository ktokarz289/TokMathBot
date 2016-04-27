using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostFix;

namespace PostFixUnitTests
{
	[TestClass]
	public class PostfixTests
	{
		[TestMethod]
		public void SimpleEquation()
		{
			PostfixConverter converter = new PostfixConverter("1+2");
			string postfix = converter.ConvertAndReturn();

			Assert.AreEqual(postfix, "12+");
		}

		[TestMethod]
		public void ComplexEqn1()
		{
			PostfixConverter converter = new PostfixConverter("1+2*3");
			string postfix = converter.ConvertAndReturn();

			Assert.AreEqual(postfix, "123*+");
		}

		[TestMethod]
		public void ComplexEqn1Inverse()
		{
			PostfixConverter converter = new PostfixConverter("2*3+1");
			string postfix = converter.ConvertAndReturn();

			Assert.AreEqual(postfix, "23*1+");
		}

		[TestMethod]
		public void ComplexEqn2()
		{
			PostfixConverter converter = new PostfixConverter("2*3+6*(3+4)");
			string postfix = converter.ConvertAndReturn();

			Assert.AreEqual(postfix, "23*634+*+");
		}

		[TestMethod]
		public void ComplexEqn3()
		{
			PostfixConverter converter = new PostfixConverter("(3+4)*2*3+6");
			string postfix = converter.ConvertAndReturn();

			Assert.AreEqual(postfix, "34+2*3*6+");
		}
	}
}

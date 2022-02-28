using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rpn.API.Helper;
using Rpn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rpn.Tests
{
    [TestClass]
    public class CalculationTest
    {
        private readonly TLine[] stack = new TLine[]
        {
                new TLine() { value = 2 },
                new TLine(){ value = 3},
                new TLine(){ value = 9}
        };

        [TestMethod]
        public void Addition_Should_Be_True()
        {
 
            var result = CalculationHelper.Calculate(stack, OperatorsEnum.ADD);
            bool eval = (result == 12);
            Assert.IsTrue(eval, "1 should not be prime");
        }

        [TestMethod]
        public void Mult_Should_Be_True()
        {

            var result = CalculationHelper.Calculate(stack, OperatorsEnum.MUL);
            bool eval = (result == 27);
            Assert.IsTrue(eval, "1 should not be prime");
        }

        [TestMethod]
        public void Div_Should_Be_True()
        {

            var result = CalculationHelper.Calculate(stack, OperatorsEnum.DIV);
            bool eval = (result == 3);
            Assert.IsTrue(eval, "1 should not be prime");
        }

        [TestMethod]
        public void Sous_Should_Be_True()
        {

            var result = CalculationHelper.Calculate(stack, OperatorsEnum.SOUS);
            bool eval = (result == 6);
            Assert.IsTrue(eval, "1 should not be prime");
        }
    }
}

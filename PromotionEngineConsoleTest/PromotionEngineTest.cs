using NUnit.Framework;
using PromotionEngineConsole;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineConsoleTest
{
    public class Tests
    {
        PromotionEngine promotionEngineObj = null;
        [SetUp]
        public void Setup()
        {
            promotionEngineObj = new PromotionEngine();
        }

        [Test]
        public void WhenCalling_MapToSKU_WithNullorZero()
        {
            List<string> ip = new List<string>();
            var result = promotionEngineObj.MapToSKU(ip);
            Assert.AreEqual(result.ErrorMessage.Count, 1);
            Assert.AreEqual(result.ErrorMessage.First(), "Invalid Input ! Please Enter a Valid Input");
        }

        [Test]
        public void WhenCalling_MapToSKU_WithMultipleInvalidInput()
        {
            List<string> ip = new List<string>();
            ip.Add("3 A");
            ip.Add("B");
            ip.Add("C C");
            ip.Add("22 D");
            var result = promotionEngineObj.MapToSKU(ip);
            Assert.AreEqual(result.ErrorMessage.Count, 2);
            Assert.AreEqual(result.ErrorMessage.First(), "Invalid Input ! Please Enter a Valid Input");
            Assert.AreEqual(result.ErrorMessage.Skip(1).First(), "Invalid Input Count for C");
        }

        [Test]
        public void WhenCalling_MapToSKU_WithConflictingInput()
        {
            List<string> ip = new List<string>();
            ip.Add("11 Z");
            var result = promotionEngineObj.MapToSKU(ip);
            Assert.AreEqual(result.ErrorMessage.Count, 1);
            Assert.AreEqual(result.ErrorMessage.First(), "Invalid Input ! Please Enter a Valid Input");
        }

        [Test]
        public void WhenCalling_CalculateInvoice_WithValidDataI()
        {
            SKUModel sKUModel = new SKUModel();
            sKUModel.QuatityOfA = 3;
            sKUModel.QuatityOfB = 5;
            sKUModel.QuatityOfC = 1;
            sKUModel.QuatityOfD = 1;

            var result = promotionEngineObj.CalculateInvoice(sKUModel);
            Assert.AreEqual(result, 280);
        }

        [Test]
        public void WhenCalling_CalculateInvoice_WithValidDataII()
        {
            SKUModel sKUModel = new SKUModel();
            sKUModel.QuatityOfA = 1;
            sKUModel.QuatityOfB = 1;
            sKUModel.QuatityOfC = 1;

            var result = promotionEngineObj.CalculateInvoice(sKUModel);
            Assert.AreEqual(result, 100);
        }

        [Test]
        public void WhenCalling_CalculateInvoice_WithValidDataIII()
        {
            SKUModel sKUModel = new SKUModel();
            sKUModel.QuatityOfA = 5;
            sKUModel.QuatityOfB = 5;
            sKUModel.QuatityOfC = 1;

            var result = promotionEngineObj.CalculateInvoice(sKUModel);
            Assert.AreEqual(result, 370);
        }
    }
}
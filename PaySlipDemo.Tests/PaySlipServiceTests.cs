using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaySlipDemo.BusinessObjects.BindingModel;
using PaySlipDemo.BusinessObjects.Interfaces;

namespace PaySlipDemo.Tests
{
    [TestClass()]
    public class PaySlipServiceTests : IoCSupportedTest
    {
        [TestMethod()]
        public void Test_GeneratePaySlip_With_TaxSlab1()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 18000, // 0 – $18,200
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.AreEqual(0, result.IncomeTax);
        }


        [TestMethod()]
        public void Test_GeneratePaySlip_With_TaxSlab2()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 19000, // $18,201 – $37,000
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.AreEqual(13, result.IncomeTax);
        }

        [TestMethod()]
        public void Test_GeneratePaySlip_With_TaxSlab3()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 38000, // $37,001 – $87,000
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.AreEqual(324, result.IncomeTax);
        }

        [TestMethod()]
        public void Test_GeneratePaySlip_With_TaxSlab4()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 88000, // $87,001 – $180,000
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };
            
            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod()]
        public void Test_GeneratePaySlip_With_TaxSlab5()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 188000, // $180,001 and over
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Test_GeneratePaySlip_With_Negative_Salary()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = -188000, // $180,001 and over
                StartDate = "01 March – 31 March",
                SuperRate = 10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Test_GeneratePaySlip_With_Negative_SuperRate()
        {
            //Arrange 
            var model = new PaySlipBindingModel
            {
                FirstName = "Mandeep",
                LastName = "Singh",
                AnnualSalary = 188000, // $180,001 and over
                StartDate = "01 March – 31 March",
                SuperRate = -10
            };

            //Act
            var sut = Resolve<IPaySlipService>();
            var result = sut.GetPaySlip(model);

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
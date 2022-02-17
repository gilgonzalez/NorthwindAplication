using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Domain.Model;
using Northwind.Domain.Services;
using System;

namespace Northwind.Domain.UnitTest
{
    [TestClass]
    public class CustomerServiceUnitTest
    {
        CustomerService service;

        public CustomerServiceUnitTest()
        {
            this.service = new CustomerService();

        }
        [TestMethod]
        public void TestCorrectValidateCustomer()
        {
            Customer customer = new Customer();
            customer.CustomerId = "AEAEE";
            customer.CompanyName = "PEPITO";

            string value = this.service.ValidateCustomer(customer);
            Assert.AreEqual(value,"Valid");
        }

    }
}

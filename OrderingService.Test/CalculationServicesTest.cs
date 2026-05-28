using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Test
{
    internal class Class1
    {
        [TestFixtures]
        public class CalucaltionServiceTest
        {
            private FakeOrderService fakeOrderService
            private FakeCouponService fakeCouponService
            private FakeLoggerService fakeLoggerService
            private CalculationService  calculationService

        }
        [SetUp]
      public void SetUp()
        {
            fakeOrderService = new FakeOrderService();
            fakeCouponService = new FakeCouponService();
            fakeLoggerService = new FakeLoggerService();
            calculationServices = new CalculationServices(fakeOrderService, fakeCouponService);
            calucaltionServices.LoggerService = fakeLoggerService;


        }
        [TestCase(5,400,300,false,true)]
        [TestCase(-1,400,300,true,false)]
        [TestCase (5,200,300 false,true)]
        [TestCase (5,400,300 true,false )]
        public void CheckCouponValidity_CouponValid_Success(int expirationDateHours,double orderTotal,double couponMinimalRequiredOrderToTal,bool used,bool expected)
        {
            fakeOrderService.Orders = new List<Order>
            {
                new Order
                {
                    Total = orderTotal
                }

            };
            fakeCouponService.Coupon = new Coupon
            {
                expirationDate = DateTime.Now.AddHours(expirationDateHours),
                MinimalRequiredOrderToTal = new couponMinimalRequiredOrderTotal
                Used = used
            };
            bool actual = calculationService.CheckCouponValidity(Guid.NewGuid(),Guid.NewGuid());

            Assert.AreEqual(expected, actual);

        }
        [TestCase(0, 0, 0.0)] 
        [TestCase(1, 0, 0.0)] 
        [TestCase(3, 0, 0.0)] 
        [TestCase(3, 5, 0.0)] 
        [TestCase(4, 0, 0.05)] 
        [TestCase(5, 0, 0.05)] 
        [TestCase(5, 3, 0.05)] 
        [TestCase(6, 0, 0.1)] 
        [TestCase(6, 4, 0.1)] 

            public void CalculateUserDiscountTest_VariousDeliveredOrderCounts_ReturnsExpectedDiscount(
    int deliveredCount, int otherCount, double expected)
            {
                List orders = new List();

                for (int i = 0; i < deliveredCount; i++)
                {
                    orders.Add(new Order { Status = Status.Delivered });
                }
                for (int i = 0; i < otherCount; i++)
                {
                    orders.Add(new Order { Status = Status.Cancelled });
                }

                fakeOrderService.Orders = orders;

                double actual = calculationServices.CalculateUserDiscount(Guid.NewGuid());
                Assert.AreEqual(expected, actual);
            }
        }
    }

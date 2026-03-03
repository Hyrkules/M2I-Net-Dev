using Moq;
using TDDExo5.Interface;

namespace TDDExo5.Test
{
    [TestClass]
    public sealed class SubscriptionServiceTest
    {

        private Guid _userId;
        private string _email;

        [TestInitialize]
        public void Setup()
        {
            _userId = Guid.NewGuid();
            _email = "user@test.com";
        }

        [TestMethod]
        public void Subscribe_HasSubscirption_Exception()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();

            Mock.Get(repositoryMock)
                .Setup(r => r.GetByUserId(_userId))
                .Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });

            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            Assert.Throws<InvalidOperationException>(() => sub.Subscribe(_userId, _email, PlanType.Yearly));
        }

        [TestMethod]
        public void Subscribe_IsSubscribing_FailedException_NoSub_NoMail()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();

            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns((Subscription)null);
            Mock.Get(paymentMock).Setup(p => p.Charge(_userId, It.IsAny<decimal>())).Returns(false);

            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            Assert.Throws<InvalidOperationException>(() => sub.Subscribe(_userId, _email, PlanType.Yearly));

            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Never);
            Mock.Get(emailMock).Verify(e => e.Send(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void Subscribe_IsSubscribing_Succeed_Save_SendMail()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();

            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns((Subscription)null);
            Mock.Get(paymentMock).Setup(p => p.Charge(_userId, 9.99m)).Returns(true);

            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.Subscribe(_userId, _email, PlanType.Monthly);

            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
            Mock.Get(emailMock).Verify(e => e.Send(_email, It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void ChangePlan_HadNoPlan_Cancel()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();

            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });
            
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.ChangePlan(_userId, PlanType.Monthly);
            
            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Never);
            Mock.Get(paymentMock).Verify(p => p.Charge(It.IsAny<Guid>(), It.IsAny<decimal>()), Times.Never);
        }

        [TestMethod]
        public void ChangePlan_SamePlan_NoChange()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();
            
            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });
            
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.ChangePlan(_userId, PlanType.Monthly);
            
            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Never);
            Mock.Get(paymentMock).Verify(p => p.Charge(It.IsAny<Guid>(), It.IsAny<decimal>()), Times.Never);
        }

        [TestMethod]
        public void ChangePlan_MonthlyToYearly_PaymentRequired()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();
            
            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });
            Mock.Get(paymentMock).Setup(p => p.Charge(_userId, 99.00m)).Returns(true);
            
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.ChangePlan(_userId, PlanType.Yearly);
            
            Mock.Get(paymentMock).Verify(p => p.Charge(_userId, 99.00m), Times.Once);
            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
        }

        [TestMethod]
        public void ChangePlan_YearlyToMonthly_NoPayment()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();
            
            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns(new Subscription { UserId = _userId, Plan = PlanType.Yearly, IsActive = true });
            
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.ChangePlan(_userId, PlanType.Monthly);
            
            Mock.Get(paymentMock).Verify(p => p.Charge(It.IsAny<Guid>(), It.IsAny<decimal>()), Times.Never);
            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
        }

        [TestMethod]
        public void Cancel_NoSubscription_Exception()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();
            
            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns((Subscription)null);
            
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);
            
            Assert.Throws<InvalidOperationException>(() => sub.Cancel(_userId, _email));
        }

        [TestMethod]
        public void Cancel_HasSubscription_Cancelled()
        {
            var repositoryMock = Mock.Of<ISubscriptionRepository>();
            var paymentMock = Mock.Of<IPaymentGateway>();
            var emailMock = Mock.Of<IEmailSender>();

            Mock.Get(repositoryMock).Setup(r => r.GetByUserId(_userId)).Returns(new Subscription { UserId = _userId, Plan = PlanType.Monthly, IsActive = true });
            var sub = new SubscriptionService(repositoryMock, paymentMock, emailMock);

            sub.Cancel(_userId, _email);

            Mock.Get(repositoryMock).Verify(r => r.Save(It.IsAny<Subscription>()), Times.Once);
            Mock.Get(emailMock).Verify(e => e.Send(_email, It.IsAny<string>()), Times.Once);
        }
    }
}
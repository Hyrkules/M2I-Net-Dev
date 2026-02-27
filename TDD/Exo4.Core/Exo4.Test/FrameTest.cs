using Exo4.Core;
using Exo4.Core.Interface;
using Moq;

namespace Exo4.Test
{
    internal class FrameTest
    {
        [TestMethod]
        public void Roll_SimpleFrame_FirstRoll_CheckScore()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).Setup(g => g.RandomPin(It.IsAny<int>())).Returns(5);

            Frame frame = new Frame(simpleFrame, false);

            frame.MakeRoll();

            Assert.AreEqual(5, frame.score);
        }

        [TestMethod]
        public void Roll_SimpleFrame_SecondRoll_CheckScore()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(5)
                .Returns(4);

            Frame frame = new Frame(simpleFrame, false);

            frame.MakeRoll();
            frame.MakeRoll();

            Assert.AreEqual(9, frame.score);

        }

        [TestMethod]
        public void Roll_SimpleFrame_SecondRoll_FirstRollStrick_ReturnFalse()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(10)
                .Returns(0);

            Frame frame = new Frame(simpleFrame, false);

            frame.MakeRoll();

            Assert.IsFalse(frame.MakeRoll());
        }

        [TestMethod]
        public void Roll_SimpleFrame_MoreRolls_ReturnFalse()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(1)
                .Returns(2)
                .Returns(0);

            Frame frame = new Frame(simpleFrame, false);

            frame.MakeRoll();
            frame.MakeRoll();

            Assert.IsFalse(frame.MakeRoll());
        }

        [TestMethod]
        public void Roll_LastFrame_SecondRoll_FirstRollStrick_ReturnTrue()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(10)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();

            Assert.IsTrue(frame.MakeRoll());
        }

        [TestMethod]
        public void Roll_LastFrame_SecondRoll_FirstRollStrick_CheckScore()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(10)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();

            Assert.AreEqual(14, frame.score);
        }

        [TestMethod]
        public void Roll_LastFrame_ThirdRoll_FirstRollStrick_ReturnTrue()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(10)
                .Returns(2)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();

            Assert.IsTrue(frame.MakeRoll());
        }

        [TestMethod]
        public void Roll_LastFrame_ThirdRoll_FirstRollStrick_CheckScore()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(10)
                .Returns(2)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();
            frame.MakeRoll();

            Assert.AreEqual(18, frame.score);
        }

        [TestMethod]
        public void Roll_LastFrame_ThirdRoll_Spare_ReturnTrue()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(8)
                .Returns(2)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();
            frame.MakeRoll();

            Assert.IsTrue(frame.MakeRoll());
        }

        [TestMethod]
        public void Roll_LastFrame_ThirdRoll_Spare_CheckScore()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(8)
                .Returns(2)
                .Returns(2);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();
            frame.MakeRoll();

            Assert.AreEqual(14, frame.score);
        }

        [TestMethod]
        public void Roll_LastFrame_FourthRoll_ReturnFalse()
        {
            IGenerateur simpleFrame = Mock.Of<IGenerateur>();
            Mock.Get(simpleFrame).SetupSequence(g => g.RandomPin(It.IsAny<int>()))
                .Returns(8)
                .Returns(2)
                .Returns(2)
                .Returns(0);

            Frame frame = new Frame(simpleFrame, true);

            frame.MakeRoll();
            frame.MakeRoll();
            frame.MakeRoll();

            Assert.IsFalse(frame.MakeRoll());
        }
    }
}

using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerDialTest
    {
        private PowerDial uut;

        [SetUp]
        public void SetUp()
        {
            uut = new PowerDial();
        }

        [Test]
        public void Default_HasCorrectBounds()
        {
            // Arrange & Act is already done in SetUp()

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, uut.lowerBound);
                Assert.AreEqual(700, uut.upperBound);
            });
        }

        [Test]
        public void OverrideBounds_ValidValues()
        {
            // Arrange & Act
            uut = new PowerDial(1, 1300);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, uut.lowerBound);
                Assert.AreEqual(1300, uut.upperBound);
            });
        }

        [Test]
        public void OverrideBounds_NegativeValues_ResetsToDefault()
        {
            // Arrange & Act
            uut = new PowerDial(-1, 700);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, uut.lowerBound);
                Assert.AreEqual(700, uut.upperBound);
            });
        }

        [Test]
        public void OverrideBounds_UpperLessThanLower_ResetsToDefault()
        {
            // Arrange & Act
            uut = new PowerDial(300, 200);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, uut.lowerBound);
                Assert.AreEqual(700, uut.upperBound);
            });
        }

        // BVA: Range of valid input is [1:700] for default
        [TestCase(1)]
        [TestCase(50)]
        [TestCase(700)]
        public void Dial_FiresEventWithValidPower(int powerLevel)
        {
            // Arrange
            int actualPowerLevel = -1;
            uut.Dialed += (sender, e) =>
                actualPowerLevel = ((PowerChangedEventArgs)e).PowerLevel;

            // Act
            uut.Dial(powerLevel);

            // Assert
            Assert.AreEqual(powerLevel, actualPowerLevel);
        }

        // BVA: Every value <1 or >700 is invalid and throws exception for default
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(701)]
        public void Dial_FiresEvent_ThrowsException(int powerLevel)
        {
            // Arrange is already done in SetUp()
            // Act & Assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.Dial(powerLevel));
        }

    }
}

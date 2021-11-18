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
        PowerDial uut;

        [SetUp]
        public void SetUp()
        {
            uut = new PowerDial();
        }

        [Test]
        public void Default_HasCorrectBounds()
        {
            // Arrange & Act is done in SetUp()

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(uut.lowerBound, 1);
                Assert.AreEqual(uut.upperBound, 700);
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
                Assert.AreEqual(uut.lowerBound, 1);
                Assert.AreEqual(uut.upperBound, 1300);
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
                Assert.AreEqual(uut.lowerBound, 1);
                Assert.AreEqual(uut.upperBound, 700);
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
                Assert.AreEqual(uut.lowerBound, 1);
                Assert.AreEqual(uut.upperBound, 700);
            });
        }

    }
}

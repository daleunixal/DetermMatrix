using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DetermMatrix.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void NotSquareMatrixDeterminant()
        {
            var matrix = new double[2, 3];
            Assert.Throws<ArgumentException>((() => Matrix.GetDeterminant(matrix)));
        }

        [TestCase(2, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = -1)]
        [TestCase(5, ExpectedResult = -2)]
        [TestCase(7, ExpectedResult = -2)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(9, ExpectedResult = -2)]
        [TestCase(8, ExpectedResult = -2)]
        public double GetRedhefferDeterminant(int dimension)
        {
            return Matrix.GetDeterminant(Matrix.Fillredheffer(dimension));
        }
    }
}
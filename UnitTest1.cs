using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Лаба_12_би_дерево;
using ClassLibrary10;

namespace unitTestss
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestRemove()
        {
            MyTree<BankCard> tree = new MyTree<BankCard>(5);
            DebitCard deb1 = new DebitCard();
            deb1.RandomInit();
            tree.AddPoint(deb1);
            tree.Remove(deb1);
            Assert.AreEqual(0, tree.Count);
        }
        [TestMethod]
        public void AddPoint_NotExistingPoint_AddsPointCorrectly()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);

            // Act
            DebitCard deb2 = new DebitCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);

            // Assert
            Assert.AreEqual(1, tree.Count);
        }
        [TestMethod]
        public void AddPoint_ExistingPoint_DoesNotAddPoint()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);

            // Act
            DebitCard deb2 = new DebitCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);

            // Assert
            Assert.AreEqual(1, tree.Count);
        }
        //[TestMethod]
        //public void TransformToArray_TransformsTreeToArray()
        //{
        //    // Arrange
        //    MyTree<BankCard> tree = new MyTree<BankCard>(0);
        //    DebitCard deb2 = new DebitCard();
        //    deb2.RandomInit();
        //    tree.AddPoint(deb2);
        //    tree.AddPoint(deb2);
        //    tree.AddPoint(deb2);
        //    int current = 0;
        //    int[] expected = { 3, 5, 7 };
        //    int[] result = new int[3];

        //    // Act
        //    tree.TransformToArray(tree.root, result, ref current);

        //    // Assert
        //    CollectionAssert.AreEqual(expected, result);
        //}
        [TestMethod]
        public void TransformToFindTree_TransformsToFindTree()
        {
            // Arrange
            MyTree<BankCard> tree = new MyTree<BankCard>(0);
            CreditCard deb2 = new CreditCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);

            // Act
            tree.TransformToFindTree();

            // Assert
            Assert.IsTrue(tree.IsFindTree);
        }
        [TestMethod]
        public void DefaultConstructor_DataIsNull()
        {
            // Arrange
            var point = new Point<int>();

            // Act
            var data = point.Data;

            // Assert
            Assert.IsNull(data);
        }
        [TestMethod]
        public void ParameterizedConstructor_DataIsAssigned()
        {
            // Arrange
            var dataValue = 5;

            // Act
            var point = new Point<int>(dataValue);

            // Assert
            Assert.AreEqual(dataValue, point.Data);
        }
        [TestMethod]
        public void ToString_DataIsNotNull_ReturnsDataAsString()
        {
            // Arrange
            var dataValue = 10;
            var point = new Point<int>(dataValue);

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual(dataValue.ToString(), result);
        }
        [TestMethod]
        public void ToString_DataIsNull_ReturnsEmptyString()
        {
            // Arrange
            var point = new Point<string>();

            // Act
            var result = point.ToString();

            // Assert
            Assert.AreEqual("", result);
        }
        [TestMethod]



        public void MadeFromTreeToFindTree_AddsAllNodesToNewTree()
        {
            // Arrange
            MyTree<CreditCard> tree = new MyTree<CreditCard>(6);
            CreditCard deb2 = new CreditCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);
            MyTree<CreditCard> newTree = new MyTree<CreditCard>(6);
            newTree = tree.MadeFromTreeToFindTree(newTree);

            
        }
        [TestMethod]
        public void Clear_RemovesAllNodesFromTree()
        {
            // Arrange
            MyTree<CreditCard> tree = new MyTree<CreditCard>(6);
            CreditCard deb2 = new CreditCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);
            tree.Clear();

            // Assert
            Assert.AreEqual(0, tree.Count);
           
        }
        [TestMethod]
        public void GetAverageBalance_CalculatesCorrectAverage()
        {
            // Arrange
            MyTree<CreditCard> tree = new MyTree<CreditCard>(6);
            CreditCard deb2 = new CreditCard();
            deb2.RandomInit();
            tree.AddPoint(deb2);
            tree.AddPoint(deb2);
            double averageBalance = tree.GetAverageBalance();

            // Assert
            Assert.AreEqual(1500, averageBalance);
        }
    }
}


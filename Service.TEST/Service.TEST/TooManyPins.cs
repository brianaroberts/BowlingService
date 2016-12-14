using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace Service.TEST
{
	/// <summary>
	/// Summary description for Game
	/// </summary>
	[TestClass]
	public class TooManyPins
	{
		public TooManyPins()
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

		[ClassInitialize]
		public static void SetUpGame(TestContext testContext)
		{
			
			
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
		[ExpectedException(typeof(TooManyPinsException))]
		public void TooManyPinsWithOneThrow()
		{
			var ValidGame = new Bowling.Game("My First Game");
			ValidGame.Throw(5).Spare()	// 1  10
				.Throw(0).Spare()		// 2 22
				.Throw(12); 	// 10 73
		}

		[TestMethod]
		[ExpectedException(typeof(TooManyPinsException))]
		public void TooManyPinsWithTwoThrows()
		{
			var ValidGame = new Bowling.Game("My First Game");
			ValidGame.Throw(5).Spare()	// 1  10
				.Throw(0).Spare()		// 2 22
				.Throw(5).Throw(6); 	// 10 73
		}
	}
}

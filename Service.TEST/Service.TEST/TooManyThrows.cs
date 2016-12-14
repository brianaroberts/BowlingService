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
	public class GameNotOver
	{
		public GameNotOver()
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
		public void TooFewFrames()
		{
			var ValidGame = new Bowling.Game("My First Game");
			ValidGame.Throw(2);
			Assert.IsFalse(ValidGame.IsGameOver); 
		}

		[TestMethod]
		public void GameIsOver()
		{
			var ValidGame = new Bowling.Game("My First Game");
			for(var i=0; i < 10; i++ )
				ValidGame.Throw(0).Throw(2);

			Assert.IsTrue(ValidGame.IsGameOver); 
		}
	}
}

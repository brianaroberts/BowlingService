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
	public class PerfectGameTest
	{
		public PerfectGameTest()
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

		public static Bowling.Game ValidGame;
		public static List<int> ExpectedReturn; 

		[ClassInitialize]
		public static void SetUpGame(TestContext testContext)
		{
			ValidGame = new Bowling.Game("My First Game");
			while (!ValidGame.IsGameOver)
				ValidGame.Strike();
			ExpectedReturn = new List<int>() { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300};
			
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
		public void CorrectFrameCount()
		{
			TestContext.WriteLine(ValidGame.FrameCount.ToString());
			Assert.IsTrue(ValidGame.FrameCount == 12); // 12 Frames due to strikes.
		}

		public void IsCorrectScoreCard()
		{
			var scoreCard = ValidGame.GetGameScoreCard();
			TestContext.WriteLine(scoreCard.ToString());
			Assert.IsTrue(scoreCard.Count == 10 && scoreCard.SequenceEqual(ExpectedReturn));
		}
		[TestMethod]
		public void TestPerfectScore()
		{
			TestContext.WriteLine(ValidGame.GameScore().ToString());
			Assert.IsTrue(ValidGame.GameScore() == 300);
		}
	}
}

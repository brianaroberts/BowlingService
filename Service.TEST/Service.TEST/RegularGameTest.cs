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
	public class RegularGameTest
	{
		public RegularGameTest()
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

		public static Bowling.Game Game1;
		public static Bowling.Game Game2;
		public static List<int> ExpectedReturnGame1;
		public static List<int> ExpectedReturnGame2;
		public static int ExpectedFrameCount = 10;

		[ClassInitialize]
		public static void SetUpGame(TestContext testContext)
		{
			Game1 = new Bowling.Game("My First Game");
			Game1.Throw(5).Spare()	// 1	10
				.Throw(0).Spare()		// 2	22
				.Throw(2).Throw(4)		// 3	28
				.Throw(1).Throw(0)		// 4	29
				.Throw(4).Throw(1)		// 5	34
				.Strike()				// 6	46
				.Throw(0).Throw(2)		// 7	48
				.Strike()				// 8	63
				.Throw(2).Throw(3)		// 9	68
				.Throw(2).Throw(3); 	// 10	73
			Game2 = new Bowling.Game("My Second Game");
			Game2.Throw(5).Spare()		// 1	10
				.Throw(0).Spare()		// 2	30
				.Strike()				// 3	54
				.Strike()				// 4	69
				.Throw(4).Throw(1)		// 5	74
				.Strike()				// 6	86
				.Throw(0).Throw(2)		// 7	88
				.Strike()				// 8	103
				.Throw(2).Throw(3)		// 9	108
				.Throw(2).Spare() 		// 10	128
				.Strike();
			
			ExpectedReturnGame1 = new List<int>() { 10, 22, 28, 29, 34, 46, 48, 63, 68, 73};
			ExpectedReturnGame2 = new List<int>() { 10, 30, 54, 69, 74, 86, 88, 103, 108, 128};
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
		public void CorrectFrameCountGame1()
		{
			TestContext.WriteLine(Game1.FrameCount.ToString());
			Assert.IsTrue(Game1.FrameCount == ExpectedFrameCount); // 12 Frames due to strikes.
		}

		[TestMethod]
		public void IsCorrectScoreCardGame1()
		{
			var scoreCard = Game1.GetGameScoreCard();
			TestContext.WriteLine(scoreCard.ToString());
			Assert.IsTrue(scoreCard.Count == 10 && scoreCard.SequenceEqual(ExpectedReturnGame1));
		}

		[TestMethod]
		public void CorrectFrameCountGame2()
		{
			TestContext.WriteLine(Game2.FrameCount.ToString());
			Assert.IsTrue(Game2.FrameCount == 11); // 12 Frames due to strikes.
		}

		[TestMethod]
		public void IsCorrectScoreCardGame2()
		{
			var scoreCard = Game2.GetGameScoreCard();
			TestContext.WriteLine(scoreCard.ToString());
			Assert.IsTrue(scoreCard.Count == 10 && scoreCard.SequenceEqual(ExpectedReturnGame2));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{

	public class Game
	{
		const int MAX_FRAMES = 10;

		private List<BowlingFrame> Frames = new List<BowlingFrame>();
		private BowlingFrame activeFrame;
		public string Name;

		public int FrameCount => Frames.Count;

		public Game(string name)
		{
			this.Name = name; 
		}

		public bool IsGameOver => Frames.Count >= FrameLimit();
		
		public Game Throw(int pinsKnockedDown)
		{
			if (Frames.Count >= FrameLimit())
				throw new TooManyFramesException();

			getActiveFrame().Throw(pinsKnockedDown);
			if (getActiveFrame().IsDone)
				closeActiveFrame();
			
			return this; 
		}

		
		public Game Strike()
		{
			getActiveFrame().ThrowStrike();
			closeActiveFrame();
			return this; 
		}

		public Game Spare()
		{
			getActiveFrame().ThrowSpare();
			closeActiveFrame();
			return this; 
		}

		public int FrameScore(int frameNum)
		{
			return GetGameScoreCard()[frameNum - 1]; 
		}

		public int GameScore()
		{
			return GetGameScoreCard().Last(); 
		}

		public List<int> GetGameScoreCard()
		{
			var runningScore = Enumerable.Repeat(0, MAX_FRAMES).ToList();

			for (var i = 0; i < MAX_FRAMES; i++)
			{
				if (Frames[i].IsStrike() && Frames.Count > (i + 2))
				{
					runningScore[i] += Frames[i+1].FirstThrow;
					runningScore[i] += Frames[i + 1].IsStrike() ? Frames[i+2].FirstThrow : Frames[i+1].SecondThrow;	
				}
				if (Frames[i].IsSpare() && Frames.Count > (i + 1))
				{
					runningScore[i] += Frames[i+1].FirstThrow;
				}

				runningScore[i] += Frames[i].FrameScore + ((i>0) ? runningScore[i-1] : 0); 
			}

			return runningScore; 
		}

		public int FrameLimit()
		{
			var returnValue = MAX_FRAMES;

			if (Frames.Count == MAX_FRAMES && Frames.Last().IsStrikeOrSpare())
			{
				returnValue = Frames.Count + 1; 
			}
			if (Frames.Count == MAX_FRAMES + 1 && Frames.Last().IsStrike())
			{
				returnValue = Frames.Count + 1; 
			}
			return returnValue;
		}

		private void closeActiveFrame()
		{
			if (activeFrame == null) return; 
			Frames.Add(activeFrame);
			activeFrame = null;
		}

		private BowlingFrame getActiveFrame()
		{
			if (activeFrame != null && activeFrame.IsDone)
				closeActiveFrame();
			return activeFrame ?? (activeFrame = new BowlingFrame());
		}
	}

	public class TooManyFramesException : Exception
	{
		public TooManyFramesException()
		{
			
		}

		public TooManyFramesException(string message) : base(message)
		{
		}

		public TooManyFramesException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingFrame
    {
	    const int NUM_PINS = 10;
	    const int MAX_THROWS = 2; 
	    private int _firstThrow = 0;
	    private int _numThrows = 0; 
	    public int FirstThrow
	    {
		    get { return _firstThrow; }
		    set
		    {
			    if (value < 0)
				    throw new NoNegativePinsException(); 
				if (value > NUM_PINS || value + SecondThrow > NUM_PINS)
					throw new TooManyPinsException();
			    _firstThrow = value;
			    if (_firstThrow == NUM_PINS)
			    {
				    _numThrows = MAX_THROWS;
			    }
				else
					_numThrows++; 
		    }
	    }

	    private int _secondThrow = 0;
	    public int SecondThrow
	    {
		    get { return _secondThrow;  }
		    set
		    {
			    if (value < 0)
				    throw new NoNegativePinsException(); 
				if (value > NUM_PINS || value + FirstThrow > NUM_PINS)
					throw new TooManyPinsException();
			    _secondThrow = value;
			    _numThrows++; 
		    }
	    }

	    public int FrameScore => FirstThrow + SecondThrow;

	    public bool IsDone => _numThrows == MAX_THROWS; 


	    public int PinsKnockedDown => FirstThrow + SecondThrow;
		
	    public bool IsStrike()
	    {
		    return (FirstThrow == NUM_PINS);
	    }

		public bool IsSpare()
	    {
		    return FirstThrow != NUM_PINS && (FirstThrow + SecondThrow) == NUM_PINS;
	    }

	    public bool IsStrikeOrSpare()
	    {
		    return IsStrike() || IsSpare();
	    }

	    public void ThrowStrike()
	    {
		    Throw(NUM_PINS);
		    _numThrows = MAX_THROWS; 
	    }

	    public void ThrowSpare()
	    {
		    Throw(NUM_PINS - FirstThrow);
	    }

	    public void Throw(int pinsKnockedDown)
	    {
		    switch (_numThrows)
		    {
				case 0:
				    FirstThrow = pinsKnockedDown; 
				    break;
				case 1:
				    SecondThrow = pinsKnockedDown; 
				    break;
				default:
					throw new TooManyThrowsException();
		    }
		}

    }

	public class TooManyPinsException : Exception
	{
		public TooManyPinsException()
		{
			
		}

		public TooManyPinsException(string message) : base(message)
		{
		}

		public TooManyPinsException(string message, Exception inner) : base(message, inner)
		{
		}
	}

	public class NoNegativePinsException : Exception
	{
		public NoNegativePinsException()
		{
			
		}

		public NoNegativePinsException(string message) : base(message)
		{
		}

		public NoNegativePinsException(string message, Exception inner) : base(message, inner)
		{
		}
	}

	public class TooManyThrowsException : Exception
	{
		public TooManyThrowsException()
		{
			
		}

		public TooManyThrowsException(string message) : base(message)
		{
		}

		public TooManyThrowsException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}

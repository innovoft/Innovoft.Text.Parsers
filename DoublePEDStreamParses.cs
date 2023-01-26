using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft.Text
{
	public struct DoublePEDStreamParses : IStreamParseGet<double>
	{
		#region Fields
		private int mode;
		private double numerator;
		private bool point;
		private double denominator;
		private int exponent;
		#endregion //Fields

		#region Methods
		public void Prepare()
		{
			mode = 0;
			numerator = 0;
			point = false;
			denominator = 1;
			exponent = 0;
		}

		public void Stream(byte[] raw, int offset, int length)
		{
			var last = offset + length;
			if (mode == 0)
			{
				for (; offset < last; ++offset)
				{
					var letter = raw[offset];
					if (letter == 0x45)//E
					{
						mode = 1;
						++offset;
						break;
					}

					if (letter == 0x2E)//.
					{
						point = true;
						continue;
					}

					numerator = (10 * numerator) + (letter - 48);
					if (point)
					{
						denominator *= 10;
					}
				}
			}
			if (mode == 1)
			{
				for (; offset < last; ++offset)
				{
					var letter = raw[offset];

					mode = 2;
					++offset;
					break;
				}
			}
			if (mode == 2)
			{
				for (; offset < last; ++offset)
				{
					var letter = raw[offset];

					exponent = letter - 48;
					break;
				}
			}
		}

		public double Get()
		{
			var scale = 1;
			var bas = 10;
			while (exponent > 0)
			{
				if ((exponent & 1) != 0)
				{
					scale *= bas;
				}
				exponent >>= 1;
				bas *= bas;
			}
			var value = numerator / (denominator * scale);
			return value;
		}
		#endregion //Methods
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft.Text
{
	public interface IIStreamParseProcess
	{
		void Prepare();
		void Stream(byte[] raw, int offset, int length);
	}
}

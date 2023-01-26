using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft.Text
{
	public interface IStreamParseGet<T> : IIStreamParseProcess
	{
		T Get();
	}
}

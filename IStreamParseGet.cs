using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft.Text
{
	public interface IStreamParseGet<T> : IStreamParseProcess
	{
		T Get();
	}
}

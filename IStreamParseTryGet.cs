using System;
using System.Collections.Generic;
using System.Text;

namespace Innovoft.Text
{
	public interface IStreamParseTryGet<T> : IStreamParseProcess
	{
		bool TryGet(out T value);
	}
}

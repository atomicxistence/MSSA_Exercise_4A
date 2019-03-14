using System.Collections.Generic;

namespace SpaceTrucker.View
{
	interface IMenu
	{
		List<IOption> Options { get; }
	}
}

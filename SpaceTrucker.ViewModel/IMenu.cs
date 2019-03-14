using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	public interface IMenu
	{
		List<IOption> Options { get; }
	}
}

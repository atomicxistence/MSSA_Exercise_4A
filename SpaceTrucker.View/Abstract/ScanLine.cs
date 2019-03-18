namespace SpaceTrucker.View
{
	class ScanLine
	{
		private const string defaultLine = "                                                                                                          ";
		private const int viewScreenLength = 106;

		public string Line { get; }

		/// <summary>
		/// A single horizontal scan line in the view display
		/// </summary>
		/// <param name="line">Must be 106 characters long</param>
		public ScanLine(string line)
		{ 
			Line = line.Length == viewScreenLength ? line : defaultLine;
		}
	}
}

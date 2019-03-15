namespace SpaceTrucker.View
{
	public struct Coord
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Coord(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}

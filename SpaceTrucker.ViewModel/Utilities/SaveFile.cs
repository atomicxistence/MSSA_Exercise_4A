using System;
using System.Collections.Generic;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	[Serializable]
	class SaveFile
	{
		public WarpFactor MaxWarpFactor { get; set; }
		public WeaponSystem WeaponSystemPower { get; set; }
		public Capacity InventoryCapacity { get; set; }

		public int FuelLevel { get; set; }
		public Location LastLocation { get; set; }
		public long Balance { get; set; }
		public int ResetDaysRemaining { get; set; }

		public List<Ore> Inventory { get; set; }

		public SaveFile() { }
	}
}

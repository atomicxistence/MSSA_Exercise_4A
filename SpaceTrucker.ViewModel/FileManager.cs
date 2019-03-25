using System;
using System.Collections.Generic;
using System.IO;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	class FileManager
	{
		internal SaveFile saveGameSettings;

		public SaveFile LoadFile()
		{
			//TODO: validate save file on HDD
			//TODO: return settings
			return null;
		}

		public void SaveFile()
		{
			//TODO: save settings
			//TODO: create/overwrite save file on HDD
		}

		private void ValidateSaveFileExists()
		{
			//TODO: is there a file present?
		}
	}
}

using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SpaceTrucker.ViewModel
{
	class FileManager
	{
		private string fileLocation = $"{AppDomain.CurrentDomain.BaseDirectory}SpaceTrucker.json";

		public SaveFile LoadFile()
		{
			ValidateSaveFileExists();

			var json = new DataContractJsonSerializer(typeof(SaveFile));
			using (var reader = new FileStream(fileLocation, FileMode.Open))
			{
				return json.ReadObject(reader) as SaveFile;
			}
		}

		public void SaveFile(SaveFile saveGame)
		{
			var json = new DataContractJsonSerializer(typeof(SaveFile));
			using (var writer = new FileStream(fileLocation, FileMode.Create, FileAccess.Write))
			{
				json.WriteObject(writer, saveGame);
			}
		}

		private void ValidateSaveFileExists()
		{
			if (!File.Exists(fileLocation))
			{
				throw new FileNotFoundException("The game save file can not be found.");
			}
		}
	}
}

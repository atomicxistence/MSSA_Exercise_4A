using System.Collections.Generic;

namespace SpaceTrucker.ViewModel
{
	class Messages
	{
		//|---------- Max Length of Message Box ---------|

		internal static List<string[]> narrative = new List<string[]>
		{
			new string[]
			{
				"> Incoming Transmission:                      ",
				" -------- Weyland Consortium Dispatch ------- ",
				" Welcome to the fleet THX-1138. You have been ",
				" assigned trade route ALPHA.8.00. We are      ",
				" uploading the latest trend reports now.      ",
				" Calculate your routes accordingly. Reset     ",
	 			" maintenance in 18,249 days.                  ",
				"> End Transmission_                           ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" ---------- Pilot TFT-2314 ------------------ ",
				" Releasing ALPHA.8.00 to THX-1138. Advisement;",
				" detour the Slevene system. Trending low the  ",
				" last 1,239 days. Current balance has fallen  ",
				" below recommended allotment. Heading in for  ",
				" maintenance ahead of schedule.               ",
				" > End Transmission_                          ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" ------ Weyland Consortium Dispatch --------- ",
				" Pilot, your balance is unsatisfactory.       ",
				" Recalibrate your nav settings and plot the   ",
				" optimal route. Reevaluating reset maintenance",
				" deadline...                                  ",
				"> End Transmission_                           ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" ----- Weyland Consortium Dispatch ---------- ",
				" Headquarters is pleased with your current    ",
				" performance, Pilot. Proceed to ALPHA.8.01.   ",
				" Uploading latest trend reports. Keep this up ",
				" and we'll outfit the whole fleet with your   ",
				" Cortana chip!                                ",
				"> End Transmission_                           ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" -----------  LilSkippy 52.001 -------------- ",
				" Well I'll be a monkey's uncle.  I haven't    ",
				" seen one of your model out this far, in a    ",
				" long time. Just been me and my nephew Bonzo  ",
				" Centrorian titanium out here. Got any of them",
				" good Weyland trade tips?                     ",
				"> End Transmission_                           ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" ------ Weyland Consortium Dispatch --------- ",
				" YOU ARE OVERDUE FOR MAINTENANCE THX-1138.    ",
				" REPORT TO OUTPOST ALPHA.460 IMMEDIATELY.     ",
				"> End Transmission_                           ",
			},
			new string[]
			{
				"> Incoming Transmission:                      ",
				" ----- Weyland Consortium Dispatch ---------- ",
				" THX-1138, your current balance has exceeded  ",
				" expectations. Please reroute and report to   ",
				" Weyland R&D on Earth.                        ",
				"> End Transmission_                           ",
			}
		};

		internal static string[] errorPlanetNoShop = new string[]
			{
				"> Error Message:                              ",
				" -------------------------------------------- ",
				" This planet does not have a trade market.    ",
				" Charge your fuel cells and continue on your  ",
				" route.                                       ",
				"> End Message_                                ",
			};
	}
}

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
			}
		};
	}
}

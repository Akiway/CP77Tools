using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class gameNotificationsReceiverTest : gameuiWidgetGameController
	{
		[Ordinal(0)]  [RED("token")] public CHandle<inkGameNotificationToken> Token { get; set; }

		public gameNotificationsReceiverTest(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

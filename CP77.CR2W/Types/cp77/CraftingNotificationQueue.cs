using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class CraftingNotificationQueue : gameuiGenericNotificationGameController
	{
		[Ordinal(0)]  [RED("duration")] public CFloat Duration { get; set; }

		public CraftingNotificationQueue(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

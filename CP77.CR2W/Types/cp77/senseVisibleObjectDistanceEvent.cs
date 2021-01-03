using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class senseVisibleObjectDistanceEvent : redEvent
	{
		[Ordinal(0)]  [RED("distance")] public CFloat Distance { get; set; }

		public senseVisibleObjectDistanceEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

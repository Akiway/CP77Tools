using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class inkLatestSaveMetadataInfo : IScriptable
	{
		[Ordinal(0)]  [RED("lifePath")] public CEnum<inkLifePath> LifePath { get; set; }
		[Ordinal(1)]  [RED("locationName")] public CString LocationName { get; set; }
		[Ordinal(2)]  [RED("playTime")] public Double PlayTime { get; set; }
		[Ordinal(3)]  [RED("playthroughTime")] public Double PlaythroughTime { get; set; }
		[Ordinal(4)]  [RED("trackedQuest")] public CString TrackedQuest { get; set; }

		public inkLatestSaveMetadataInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

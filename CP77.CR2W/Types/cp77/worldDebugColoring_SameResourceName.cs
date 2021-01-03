using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class worldDebugColoring_SameResourceName : worldEditorDebugColoringSettings
	{
		[Ordinal(0)]  [RED("alpha")] public CUInt8 Alpha { get; set; }

		public worldDebugColoring_SameResourceName(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

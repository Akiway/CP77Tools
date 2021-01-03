using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class graphGraphSocketDefinition : graphIGraphObjectDefinition
	{
		[Ordinal(0)]  [RED("connections")] public CArray<CHandle<graphGraphConnectionDefinition>> Connections { get; set; }
		[Ordinal(1)]  [RED("name")] public CName Name { get; set; }

		public graphGraphSocketDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

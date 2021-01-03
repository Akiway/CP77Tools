using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questdbgCallstackPhase : questdbgCallstackBlock
	{
		[Ordinal(0)]  [RED("blocks")] public CArray<CUInt64> Blocks { get; set; }
		[Ordinal(1)]  [RED("phases")] public CArray<CUInt64> Phases { get; set; }

		public questdbgCallstackPhase(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class entReplicatedInputSetters : CVariable
	{
		[Ordinal(0)]  [RED("serverReplicatedTime")] public netTime ServerReplicatedTime { get; set; }

		public entReplicatedInputSetters(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

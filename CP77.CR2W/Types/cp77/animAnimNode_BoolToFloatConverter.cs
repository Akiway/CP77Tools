using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class animAnimNode_BoolToFloatConverter : animAnimNode_FloatValue
	{
		[Ordinal(0)]  [RED("inputNode")] public animBoolLink InputNode { get; set; }

		public animAnimNode_BoolToFloatConverter(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

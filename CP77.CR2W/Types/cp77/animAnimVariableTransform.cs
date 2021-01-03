using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class animAnimVariableTransform : animAnimVariable
	{
		[Ordinal(0)]  [RED("default")] public QsTransform Default { get; set; }
		[Ordinal(1)]  [RED("value")] public QsTransform Value { get; set; }

		public animAnimVariableTransform(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

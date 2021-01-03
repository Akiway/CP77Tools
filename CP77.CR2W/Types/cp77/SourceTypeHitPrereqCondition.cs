using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class SourceTypeHitPrereqCondition : BaseHitPrereqCondition
	{
		[Ordinal(0)]  [RED("source")] public CName Source { get; set; }

		public SourceTypeHitPrereqCondition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

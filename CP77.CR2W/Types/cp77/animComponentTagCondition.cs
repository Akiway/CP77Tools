using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class animComponentTagCondition : animIStaticCondition
	{
		[Ordinal(0)]  [RED("animTag")] public CName AnimTag { get; set; }

		public animComponentTagCondition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

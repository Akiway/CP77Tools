using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questCharacterCover_ConditionType : questICharacterConditionType
	{
		[Ordinal(0)]  [RED("coverRef")] public NodeRef CoverRef { get; set; }
		[Ordinal(1)]  [RED("puppetRef")] public gameEntityReference PuppetRef { get; set; }

		public questCharacterCover_ConditionType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

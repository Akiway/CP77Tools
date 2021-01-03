using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class entTemplateAppearance : CVariable
	{
		[Ordinal(0)]  [RED("appearanceName")] public CName AppearanceName { get; set; }
		[Ordinal(1)]  [RED("appearanceResource")] public raRef<appearanceAppearanceResource> AppearanceResource { get; set; }
		[Ordinal(2)]  [RED("name")] public CName Name { get; set; }

		public entTemplateAppearance(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class AIArgumentIntValue : AIArgumentDefinition
	{
		[Ordinal(0)]  [RED("defaultValue")] public CInt32 DefaultValue { get; set; }
		[Ordinal(1)]  [RED("type")] public CEnum<AIArgumentType> Type { get; set; }

		public AIArgumentIntValue(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

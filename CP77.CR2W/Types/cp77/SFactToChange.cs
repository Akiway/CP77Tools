using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class SFactToChange : CVariable
	{
		[Ordinal(0)]  [RED("factName")] public CName FactName { get; set; }
		[Ordinal(1)]  [RED("factValue")] public CInt32 FactValue { get; set; }
		[Ordinal(2)]  [RED("operationType")] public CEnum<EMathOperationType> OperationType { get; set; }

		public SFactToChange(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

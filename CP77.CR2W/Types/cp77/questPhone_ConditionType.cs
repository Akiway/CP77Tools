using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questPhone_ConditionType : questISystemConditionType
	{
		[Ordinal(0)]  [RED("addressee")] public CHandle<gameJournalPath> Addressee { get; set; }
		[Ordinal(1)]  [RED("callPhase")] public CEnum<questPhoneCallPhase> CallPhase { get; set; }
		[Ordinal(2)]  [RED("caller")] public CHandle<gameJournalPath> Caller { get; set; }

		public questPhone_ConditionType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

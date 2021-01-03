using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class scnOverrideTalkOnReturn_InterruptionScenarioOperation : scnIInterruptionScenarioOperation
	{
		[Ordinal(0)]  [RED("talkOnReturn")] public CBool TalkOnReturn { get; set; }

		public scnOverrideTalkOnReturn_InterruptionScenarioOperation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

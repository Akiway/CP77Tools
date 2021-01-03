using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class QuestFollowTarget : ActionEntityReference
	{
		[Ordinal(0)]  [RED("ForcedTarget")] public entEntityID ForcedTarget { get; set; }

		public QuestFollowTarget(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

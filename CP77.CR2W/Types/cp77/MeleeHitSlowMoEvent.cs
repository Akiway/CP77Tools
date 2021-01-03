using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class MeleeHitSlowMoEvent : redEvent
	{
		[Ordinal(0)]  [RED("isStrongAttack")] public CBool IsStrongAttack { get; set; }

		public MeleeHitSlowMoEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

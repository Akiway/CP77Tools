using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class KnockdownReactionTask : AIHitReactionTask
	{
		[Ordinal(0)]  [RED("tweakDBPackage")] public TweakDBID TweakDBPackage { get; set; }

		public KnockdownReactionTask(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

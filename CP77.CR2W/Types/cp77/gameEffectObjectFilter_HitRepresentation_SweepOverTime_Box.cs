using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class gameEffectObjectFilter_HitRepresentation_SweepOverTime_Box : gameEffectObjectFilter_HitRepresentation
	{

		public gameEffectObjectFilter_HitRepresentation_SweepOverTime_Box(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class StatPoolPrereqListener : BaseStatPoolPrereqListener
	{
		[Ordinal(0)]  [RED("state")] public wCHandle<StatPoolPrereqState> State { get; set; }

		public StatPoolPrereqListener(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

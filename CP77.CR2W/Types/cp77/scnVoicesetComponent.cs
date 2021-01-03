using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class scnVoicesetComponent : gameComponent
	{
		[Ordinal(0)]  [RED("combatVoSettingsName")] public CName CombatVoSettingsName { get; set; }

		public scnVoicesetComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

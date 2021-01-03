using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questIAudioCharacterManager_NodeSubTypeCharacterEntry : CVariable
	{
		[Ordinal(0)]  [RED("enableSubSystem")] public CBool EnableSubSystem { get; set; }
		[Ordinal(1)]  [RED("isPlayer")] public CBool IsPlayer { get; set; }
		[Ordinal(2)]  [RED("puppetRef")] public gameEntityReference PuppetRef { get; set; }

		public questIAudioCharacterManager_NodeSubTypeCharacterEntry(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

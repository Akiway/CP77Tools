using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class LockPerkArea : gamePlayerScriptableSystemRequest
	{
		[Ordinal(0)]  [RED("perkArea")] public CEnum<gamedataPerkArea> PerkArea { get; set; }

		public LockPerkArea(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

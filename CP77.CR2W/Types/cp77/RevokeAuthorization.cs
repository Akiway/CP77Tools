using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class RevokeAuthorization : redEvent
	{
		[Ordinal(0)]  [RED("level")] public CEnum<ESecurityAccessLevel> Level { get; set; }
		[Ordinal(1)]  [RED("user")] public entEntityID User { get; set; }

		public RevokeAuthorization(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

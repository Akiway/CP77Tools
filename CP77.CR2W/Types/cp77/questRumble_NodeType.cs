using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questRumble_NodeType : questIGameManagerNonSignalStoppingNodeType
	{
		[Ordinal(0)]  [RED("isPlayer")] public CBool IsPlayer { get; set; }
		[Ordinal(1)]  [RED("objectRef")] public gameEntityReference ObjectRef { get; set; }
		[Ordinal(2)]  [RED("rumbleEvent")] public CName RumbleEvent { get; set; }

		public questRumble_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

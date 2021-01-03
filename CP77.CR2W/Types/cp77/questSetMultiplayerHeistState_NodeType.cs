using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questSetMultiplayerHeistState_NodeType : questIMultiplayerHeistNodeType
	{
		[Ordinal(0)]  [RED("state")] public CEnum<questMultiplayerHeistState> State { get; set; }

		public questSetMultiplayerHeistState_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

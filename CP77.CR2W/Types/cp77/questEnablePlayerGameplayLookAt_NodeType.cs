using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questEnablePlayerGameplayLookAt_NodeType : questISceneManagerNodeType
	{
		[Ordinal(0)]  [RED("enable")] public CBool Enable { get; set; }

		public questEnablePlayerGameplayLookAt_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

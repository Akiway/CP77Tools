using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questPlayEnv_NodeType : questIEnvironmentManagerNodeType
	{
		[Ordinal(0)]  [RED("params")] public questPlayEnv_NodeTypeParams Params { get; set; }

		public questPlayEnv_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

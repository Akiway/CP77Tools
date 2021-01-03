using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questCharacterManagerParameters_SetProgressionBuild : questICharacterManagerParameters_NodeSubType
	{
		[Ordinal(0)]  [RED("buildID")] public TweakDBID BuildID { get; set; }

		public questCharacterManagerParameters_SetProgressionBuild(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class SceneCustomData_DistantShadows : SceneCustomData_DistantShadowsCommon
	{

		public SceneCustomData_DistantShadows(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

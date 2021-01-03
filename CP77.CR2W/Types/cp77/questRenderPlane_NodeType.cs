using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questRenderPlane_NodeType : questIRenderFxManagerNodeType
	{
		[Ordinal(0)]  [RED("puppetRef")] public gameEntityReference PuppetRef { get; set; }
		[Ordinal(1)]  [RED("renderPlane")] public CEnum<ERenderingPlane> RenderPlane { get; set; }

		public questRenderPlane_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

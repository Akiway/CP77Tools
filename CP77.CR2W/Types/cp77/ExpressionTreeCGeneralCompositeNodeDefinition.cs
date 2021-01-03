using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class ExpressionTreeCGeneralCompositeNodeDefinition : ExpressionTreeCGeneralNodeDefinition
	{
		[Ordinal(0)]  [RED("children")] public CArray<CHandle<LibTreeINodeDefinition>> Children { get; set; }

		public ExpressionTreeCGeneralCompositeNodeDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

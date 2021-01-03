using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questSetItemTags_NodeTypeParams : CVariable
	{
		[Ordinal(0)]  [RED("addTags")] public CBool AddTags { get; set; }
		[Ordinal(1)]  [RED("itemId")] public TweakDBID ItemId { get; set; }
		[Ordinal(2)]  [RED("objectRef")] public CHandle<questUniversalRef> ObjectRef { get; set; }
		[Ordinal(3)]  [RED("tags")] public gameEItemDynamicTags Tags { get; set; }

		public questSetItemTags_NodeTypeParams(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class VisibilitySimpleControllerBase : inkWidgetLogicController
	{
		[Ordinal(0)]  [RED("affectedWidgets")] public CArray<CName> AffectedWidgets { get; set; }
		[Ordinal(1)]  [RED("isVisible")] public CBool IsVisible { get; set; }
		[Ordinal(2)]  [RED("widget")] public wCHandle<inkWidget> Widget { get; set; }

		public VisibilitySimpleControllerBase(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

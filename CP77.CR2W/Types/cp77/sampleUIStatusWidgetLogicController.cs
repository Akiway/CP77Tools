using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class sampleUIStatusWidgetLogicController : inkWidgetLogicController
	{
		[Ordinal(0)]  [RED("disableStateColor")] public CColor DisableStateColor { get; set; }
		[Ordinal(1)]  [RED("enableStateColor")] public CColor EnableStateColor { get; set; }
		[Ordinal(2)]  [RED("iconWidget")] public wCHandle<inkRectangleWidget> IconWidget { get; set; }
		[Ordinal(3)]  [RED("textWidget")] public wCHandle<inkTextWidget> TextWidget { get; set; }

		public sampleUIStatusWidgetLogicController(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

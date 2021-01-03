using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class AnimFeature_Container : animAnimFeature
	{
		[Ordinal(0)]  [RED("opened")] public CBool Opened { get; set; }
		[Ordinal(1)]  [RED("transitionDuration")] public CFloat TransitionDuration { get; set; }

		public AnimFeature_Container(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class inkWidgetStateAnimatedTransition : CVariable
	{
		[Ordinal(0)]  [RED("animationName")] public CName AnimationName { get; set; }
		[Ordinal(1)]  [RED("endState")] public CName EndState { get; set; }
		[Ordinal(2)]  [RED("playbackOptions")] public inkanimPlaybackOptions PlaybackOptions { get; set; }
		[Ordinal(3)]  [RED("startState")] public CName StartState { get; set; }

		public inkWidgetStateAnimatedTransition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

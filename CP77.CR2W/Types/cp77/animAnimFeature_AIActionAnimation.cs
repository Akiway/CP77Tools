using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class animAnimFeature_AIActionAnimation : animAnimFeature_AIAction
	{
		[Ordinal(0)]  [RED("animFeatureName")] public CName AnimFeatureName { get; set; }

		public animAnimFeature_AIActionAnimation(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

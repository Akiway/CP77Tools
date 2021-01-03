using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class animAnimFeature_DodgeData : animAnimFeature
	{
		[Ordinal(0)]  [RED("dodgeDirection")] public CInt32 DodgeDirection { get; set; }
		[Ordinal(1)]  [RED("dodgeType")] public CInt32 DodgeType { get; set; }

		public animAnimFeature_DodgeData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class entdismembermentAppearanceMatch : CVariable
	{
		[Ordinal(0)]  [RED("Character")] public CName Character { get; set; }
		[Ordinal(1)]  [RED("Mesh")] public CName Mesh { get; set; }
		[Ordinal(2)]  [RED("SetByUser")] public CBool SetByUser { get; set; }

		public entdismembermentAppearanceMatch(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

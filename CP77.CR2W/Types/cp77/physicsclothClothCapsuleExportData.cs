using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class physicsclothClothCapsuleExportData : ISerializable
	{
		[Ordinal(0)]  [RED("capsules")] public CArray<physicsclothExportedCapsule> Capsules { get; set; }

		public physicsclothClothCapsuleExportData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

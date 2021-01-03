using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questToggleForceBrake_NodeType : questIVehicleManagerNodeType
	{
		[Ordinal(0)]  [RED("playerVehicle")] public CBool PlayerVehicle { get; set; }
		[Ordinal(1)]  [RED("val")] public CBool Val { get; set; }
		[Ordinal(2)]  [RED("vehicleRef")] public gameEntityReference VehicleRef { get; set; }

		public questToggleForceBrake_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

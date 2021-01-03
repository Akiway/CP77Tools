using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class vehicleControllerPS : gameComponentPS
	{
		[Ordinal(0)]  [RED("isAlarmOn")] public CBool IsAlarmOn { get; set; }
		[Ordinal(1)]  [RED("lightMode")] public CEnum<vehicleELightMode> LightMode { get; set; }
		[Ordinal(2)]  [RED("state")] public CEnum<vehicleEState> State { get; set; }
		[Ordinal(3)]  [RED("vehicleDoors")] public CStatic<6,vehicleVehicleSlotsState> VehicleDoors { get; set; }

		public vehicleControllerPS(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

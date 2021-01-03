using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class audioEditorSelectedData : audioAudioMetadata
	{
		[Ordinal(0)]  [RED("selectedFootstepsEventName")] public CName SelectedFootstepsEventName { get; set; }
		[Ordinal(1)]  [RED("selectedWeaponConfigurationName")] public CName SelectedWeaponConfigurationName { get; set; }

		public audioEditorSelectedData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

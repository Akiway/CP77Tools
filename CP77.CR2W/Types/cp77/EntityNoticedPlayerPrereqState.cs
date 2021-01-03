using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class EntityNoticedPlayerPrereqState : gamePrereqState
	{
		[Ordinal(0)]  [RED("listenerInt")] public CUInt32 ListenerInt { get; set; }
		[Ordinal(1)]  [RED("owner")] public wCHandle<gameObject> Owner { get; set; }

		public EntityNoticedPlayerPrereqState(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

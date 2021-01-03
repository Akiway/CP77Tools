using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class AddOrRemoveListenerEvent : redEvent
	{
		[Ordinal(0)]  [RED("add")] public CBool Add { get; set; }
		[Ordinal(1)]  [RED("listener")] public CHandle<PuppetListener> Listener { get; set; }

		public AddOrRemoveListenerEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

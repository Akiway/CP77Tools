using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class gameUnTagObjectRequest : gameScriptableSystemRequest
	{
		[Ordinal(0)]  [RED("object")] public wCHandle<gameObject> Object { get; set; }

		public gameUnTagObjectRequest(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

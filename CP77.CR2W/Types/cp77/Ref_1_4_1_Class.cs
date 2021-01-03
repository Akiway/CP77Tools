using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class Ref_1_4_1_Class : IScriptable
	{
		[Ordinal(0)]  [RED("intProp")] public CInt32 IntProp { get; set; }

		public Ref_1_4_1_Class(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

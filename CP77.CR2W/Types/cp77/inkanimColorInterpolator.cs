using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class inkanimColorInterpolator : inkanimInterpolator
	{
		[Ordinal(0)]  [RED("endValue")] public HDRColor EndValue { get; set; }
		[Ordinal(1)]  [RED("startValue")] public HDRColor StartValue { get; set; }

		public inkanimColorInterpolator(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

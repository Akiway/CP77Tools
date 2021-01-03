using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class audioGroupingLimitMetadata : audioAudioMetadata
	{
		[Ordinal(0)]  [RED("limit")] public CFloat Limit { get; set; }

		public audioGroupingLimitMetadata(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

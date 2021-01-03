using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class questDistanceComparison_ConditionType : questIDistanceConditionType
	{
		[Ordinal(0)]  [RED("comparisonType")] public CEnum<EComparisonType> ComparisonType { get; set; }
		[Ordinal(1)]  [RED("distanceDefinition1")] public CHandle<questObjectDistance> DistanceDefinition1 { get; set; }
		[Ordinal(2)]  [RED("distanceDefinition2")] public CHandle<questValueDistance> DistanceDefinition2 { get; set; }

		public questDistanceComparison_ConditionType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

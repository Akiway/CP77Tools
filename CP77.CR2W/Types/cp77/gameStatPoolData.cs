using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class gameStatPoolData : CVariable
	{
		[Ordinal(0)]  [RED("alternativeModifierRecords")] public [2]TweakDBID AlternativeModifierRecords { get; set; }
		[Ordinal(1)]  [RED("bonus")] public CFloat Bonus { get; set; }
		[Ordinal(2)]  [RED("bonusType")] public CEnum<gameStatPoolDataBonusType> BonusType { get; set; }
		[Ordinal(3)]  [RED("changeMode")] public CEnum<gameStatPoolDataValueChangeMode> ChangeMode { get; set; }
		[Ordinal(4)]  [RED("currentValue")] public CFloat CurrentValue { get; set; }
		[Ordinal(5)]  [RED("customLimitValue")] public CFloat CustomLimitValue { get; set; }
		[Ordinal(6)]  [RED("maxValue")] public CFloat MaxValue { get; set; }
		[Ordinal(7)]  [RED("modificationDelay")] public CFloat ModificationDelay { get; set; }
		[Ordinal(8)]  [RED("modificationStatus")] public CEnum<gameStatPoolDataStatPoolModificationStatus> ModificationStatus { get; set; }
		[Ordinal(9)]  [RED("modifiers")] public [2]gameStatPoolModifier Modifiers { get; set; }
		[Ordinal(10)]  [RED("ownerID")] public gameStatsObjectID OwnerID { get; set; }
		[Ordinal(11)]  [RED("recordID")] public TweakDBID RecordID { get; set; }
		[Ordinal(12)]  [RED("stat")] public CEnum<gamedataStatType> Stat { get; set; }
		[Ordinal(13)]  [RED("type")] public CEnum<gamedataStatPoolType> Type { get; set; }

		public gameStatPoolData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

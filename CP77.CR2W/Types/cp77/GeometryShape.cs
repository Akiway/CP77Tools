using System.IO;
using WolvenKit.CR2W.Reflection;
using FastMember;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
	[REDMeta]
	public class GeometryShape : ISerializable
	{
		[Ordinal(0)]  [RED("faces")] public CArray<GeometryShapeFace> Faces { get; set; }
		[Ordinal(1)]  [RED("indices")] public CArray<CUInt16> Indices { get; set; }
		[Ordinal(2)]  [RED("vertices")] public CArray<Vector3> Vertices { get; set; }

		public GeometryShape(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}

using System;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.TValle.Tools.Runtime.MeshNormalImporter
{
	// Token: 0x02000038 RID: 56
	public interface IMeshCustomNormalsImporter
	{
		// Token: 0x06000128 RID: 296
		void Import(NativeArray<float3>.ReadOnly CalculedNormals, NativeArray<float3>.ReadOnly CustomNormals);
	}
}

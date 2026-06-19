using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.MeshNormalImporter
{
	// Token: 0x02000037 RID: 55
	public class MeshCustomNormals : MonoBehaviour, IMeshCustomNormalsImporter
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000035FE File Offset: 0x000017FE
		public NativeArray<float3>.ReadOnly calculedNormals
		{
			get
			{
				return this.m_calculedNormals.AsReadOnly();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000360B File Offset: 0x0000180B
		public NativeArray<float3>.ReadOnly customNormals
		{
			get
			{
				return this.m_customNormals.AsReadOnly();
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00003618 File Offset: 0x00001818
		void IMeshCustomNormalsImporter.Import(NativeArray<float3>.ReadOnly CalculedNormals, NativeArray<float3>.ReadOnly CustomNormals)
		{
			this.m_calculedNormalsFromImporter = CalculedNormals.ToArray();
			this.m_customNormalsFromImporter = CustomNormals.ToArray();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00003634 File Offset: 0x00001834
		public void Awake()
		{
			if (!this.m_calculedNormals.IsCreated)
			{
				this.m_calculedNormals = new NativeArray<float3>(this.m_calculedNormalsFromImporter, Allocator.Persistent);
			}
			if (!this.m_customNormals.IsCreated)
			{
				this.m_customNormals = new NativeArray<float3>(this.m_customNormalsFromImporter, Allocator.Persistent);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00003674 File Offset: 0x00001874
		private void OnDestroy()
		{
			this.m_calculedNormals.Dispose();
			this.m_customNormals.Dispose();
		}

		// Token: 0x0400007B RID: 123
		[SerializeField]
		[HideInInspector]
		private float3[] m_calculedNormalsFromImporter;

		// Token: 0x0400007C RID: 124
		[SerializeField]
		[HideInInspector]
		private float3[] m_customNormalsFromImporter;

		// Token: 0x0400007D RID: 125
		private NativeArray<float3> m_calculedNormals;

		// Token: 0x0400007E RID: 126
		private NativeArray<float3> m_customNormals;
	}
}

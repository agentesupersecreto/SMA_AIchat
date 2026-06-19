using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001A8 RID: 424
	internal class InternalData : IDisposable
	{
		// Token: 0x06000A13 RID: 2579 RVA: 0x0002D593 File Offset: 0x0002B793
		public void Init(HoleInternal vag, HoleInternal anus)
		{
			this.m_vag = vag;
			this.m_anus = anus;
			this.internalLossyScale = new NativeArray<float3>(2, Allocator.Persistent, NativeArrayOptions.ClearMemory);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0002D5B1 File Offset: 0x0002B7B1
		public int IndexOf(Transform internalRoot)
		{
			if (internalRoot == this.m_vag.root)
			{
				return 0;
			}
			if (internalRoot == this.m_anus.root)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0002D5E0 File Offset: 0x0002B7E0
		public void UpdateData()
		{
			this.internalLossyScale[0] = this.m_vag.root.lossyScale;
			this.internalLossyScale[1] = this.m_anus.root.lossyScale;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0002D62F File Offset: 0x0002B82F
		public void Dispose()
		{
			if (this.internalLossyScale.IsCreated)
			{
				this.internalLossyScale.Dispose();
			}
		}

		// Token: 0x040007F9 RID: 2041
		public NativeArray<float3> internalLossyScale;

		// Token: 0x040007FA RID: 2042
		private HoleInternal m_vag;

		// Token: 0x040007FB RID: 2043
		private HoleInternal m_anus;
	}
}

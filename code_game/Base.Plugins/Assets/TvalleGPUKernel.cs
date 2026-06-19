using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000149 RID: 329
	[Serializable]
	public class TvalleGPUKernel
	{
		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x000200EA File Offset: 0x0001E2EA
		public int id
		{
			get
			{
				return this.m_kernel;
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x000200F4 File Offset: 0x0001E2F4
		public virtual void Init(ComputeShader cs, string name)
		{
			if (this.m_isInit)
			{
				return;
			}
			this.m_cs = cs;
			this.m_kernel = cs.FindKernel(name);
			uint num;
			uint num2;
			uint num3;
			cs.GetKernelThreadGroupSizes(this.m_kernel, out num, out num2, out num3);
			this.m_TGS = new int[]
			{
				(int)num,
				(int)num2,
				(int)num3
			};
			this.m_isInit = true;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0002014F File Offset: 0x0001E34F
		public void Dispatch(int UnityCount)
		{
			this.m_cs.Dispatch(this.id, Mathf.FloorToInt((float)(UnityCount / this.m_TGS[0])) + 1, this.m_TGS[1], this.m_TGS[2]);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00020184 File Offset: 0x0001E384
		public void SetBuffer(string name, ComputeBuffer buff)
		{
			this.m_cs.SetBuffer(this.id, name, buff);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00020199 File Offset: 0x0001E399
		public void SetBuffer(string name, GraphicsBuffer buff)
		{
			this.m_cs.SetBuffer(this.id, name, buff);
		}

		// Token: 0x0400026C RID: 620
		private bool m_isInit;

		// Token: 0x0400026D RID: 621
		private int m_kernel;

		// Token: 0x0400026E RID: 622
		protected ComputeShader m_cs;

		// Token: 0x0400026F RID: 623
		private int[] m_TGS;
	}
}

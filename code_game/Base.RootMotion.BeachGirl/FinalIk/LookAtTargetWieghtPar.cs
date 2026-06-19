using System;
using UnityEngine;

namespace Assets.FinalIk
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class LookAtTargetWieghtPar
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002D27 File Offset: 0x00000F27
		public LookAtTarget LookAtTarget
		{
			get
			{
				return this.m_LookAtTarget;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002D2F File Offset: 0x00000F2F
		public void Clear()
		{
			this.m_LookAtTarget.Clear();
			this.weight = 0f;
		}

		// Token: 0x04000007 RID: 7
		public float weight;

		// Token: 0x04000008 RID: 8
		[SerializeField]
		private LookAtTarget m_LookAtTarget;
	}
}

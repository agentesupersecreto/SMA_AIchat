using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public class FixedCoolDown
	{
		// Token: 0x0600030C RID: 780 RVA: 0x0000E074 File Offset: 0x0000C274
		public FixedCoolDown(float coolDownInSeconds)
		{
			this.m_seconds = coolDownInSeconds;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000E08E File Offset: 0x0000C28E
		public FixedCoolDown(int cadence)
		{
			this.m_seconds = 1f / (float)cadence;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000E0AF File Offset: 0x0000C2AF
		public bool isOn
		{
			get
			{
				return Time.time - this.lastUseTime < this.m_seconds;
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000E0C5 File Offset: 0x0000C2C5
		public void Apply()
		{
			this.lastUseTime = Time.time;
		}

		// Token: 0x040000A3 RID: 163
		[Tooltip("CoolDown time in secons")]
		[Range(0f, 3600f)]
		public float m_seconds;

		// Token: 0x040000A4 RID: 164
		[ReadOnlyUI]
		[SerializeField]
		private float lastUseTime = float.NegativeInfinity;
	}
}

using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000148 RID: 328
	[Serializable]
	public class SmoothWeight
	{
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x00020030 File Offset: 0x0001E230
		public float valor
		{
			get
			{
				return this.m_valor;
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00020038 File Offset: 0x0001E238
		public void SetSmooth(float weight, float velocity, bool smoothEnds = true, float distanceToSmooth = 0.25f)
		{
			float num = 1f;
			if (smoothEnds)
			{
				num = Mathf.Clamp01(Mathf.Abs(this.m_valor - weight) / distanceToSmooth);
			}
			this.m_valor = Mathf.MoveTowards(this.m_valor, weight, Time.deltaTime * velocity * num);
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0002007F File Offset: 0x0001E27F
		public void ResetSmooth(float velocity)
		{
			if (this.m_valor != 1f)
			{
				this.m_valor = Mathf.MoveTowards(this.m_valor, 1f, Time.deltaTime * velocity);
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x000200AB File Offset: 0x0001E2AB
		public void ZeroSmooth(float velocity)
		{
			if (this.m_valor != 0f)
			{
				this.m_valor = Mathf.MoveTowards(this.m_valor, 0f, Time.deltaTime * velocity);
			}
		}

		// Token: 0x0400026B RID: 619
		[SerializeField]
		private float m_valor = 1f;
	}
}

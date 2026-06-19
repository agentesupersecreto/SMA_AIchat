using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000104 RID: 260
	[Serializable]
	public abstract class BaseFlotanteDobleLayer : BaseFlotanteSingleLayer
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0001A0A5 File Offset: 0x000182A5
		public float base2
		{
			get
			{
				return this.m_base2;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x0001A0B0 File Offset: 0x000182B0
		public float valorCalculado2
		{
			get
			{
				float num = this.m_base2;
				if (this.m_promediable.Count > 0)
				{
					num = this.m_promediable.PromediarConValor(num);
				}
				float num2 = 1f;
				if (this.m_modificable.Count > 0)
				{
					num2 = this.m_modificable.ModificarValor(num2);
				}
				this.m_lastValorCalculado2 = num * num2;
				if (this.m_minValorable.Count > 0)
				{
					this.m_lastValorCalculado2 = this.m_minValorable.MaximoValorIncluyendo(this.m_lastValorCalculado2);
				}
				this.m_lastValorCalculado2 = this.Clamp(this.m_lastValorCalculado2);
				return this.m_lastValorCalculado2;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0001A146 File Offset: 0x00018346
		public float lastValor2
		{
			get
			{
				return this.m_lastValorCalculado2;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0001A14E File Offset: 0x0001834E
		public float weight2
		{
			get
			{
				if (this.base2 == 0f || !this.m_initiated2)
				{
					Debug.LogError("No se puede usar weight2 si la base2 es zero o nunca fue iniciada");
					return 0f;
				}
				return this.lastValor2 / this.base2;
			}
		}

		// Token: 0x0600076B RID: 1899
		protected abstract void LoadBase2(float val);

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0001A182 File Offset: 0x00018382
		public float initial2
		{
			get
			{
				return this.m_initial2;
			}
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0001A18A File Offset: 0x0001838A
		public override void InitBaseTodas(float val)
		{
			this.InitBase(val, val);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001A194 File Offset: 0x00018394
		public override float PromedioDeTodosLosLastValores()
		{
			float num = base.PromedioDeTodosLosLastValores();
			return (this.m_lastValorCalculado2 + num) / 2f;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0001A1B6 File Offset: 0x000183B6
		public override float MayorDeTodosLosLastValores()
		{
			return Mathf.Max(base.PromedioDeTodosLosLastValores(), this.m_lastValorCalculado2);
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001A1C9 File Offset: 0x000183C9
		public void InitBase(float val, float val2)
		{
			base.InitBase(val);
			this.InitBase2(val2);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001A1D9 File Offset: 0x000183D9
		public void InitBase2(float val2)
		{
			if (this.m_initiated2)
			{
				Debug.LogError("No se puede iniciar un valor mas de una vez");
				return;
			}
			this.m_initial2 = val2;
			this.m_initiated2 = true;
			this.LoadBase2(val2);
		}

		// Token: 0x0400020D RID: 525
		[SerializeField]
		protected float m_base2;

		// Token: 0x0400020E RID: 526
		[ReadOnlyUI]
		[SerializeField]
		protected float m_lastValorCalculado2;

		// Token: 0x0400020F RID: 527
		[NonSerialized]
		private bool m_initiated2;

		// Token: 0x04000210 RID: 528
		[SerializeField]
		[ReadOnlyUI]
		private float m_initial2;
	}
}

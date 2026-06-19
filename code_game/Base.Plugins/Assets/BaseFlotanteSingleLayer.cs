using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000102 RID: 258
	[Serializable]
	public abstract class BaseFlotanteSingleLayer : BaseFlotante
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00019E27 File Offset: 0x00018027
		[Obsolete]
		public float valorMidifcado
		{
			get
			{
				return this.Clamp(this.m_modificable.ModificarValor(this.m_base));
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x00019E40 File Offset: 0x00018040
		[Obsolete]
		public float valorPromediado
		{
			get
			{
				return this.Clamp(this.m_modificable.PromediarConValor(this.m_base));
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00019E59 File Offset: 0x00018059
		[Obsolete("", true)]
		public float baseMidifcada
		{
			get
			{
				return this.Clamp(this.m_modificable.ModificarValor(this.m_base));
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00019E72 File Offset: 0x00018072
		[Obsolete("", true)]
		public float basePromediada
		{
			get
			{
				return this.Clamp(this.m_modificable.PromediarConValor(this.m_base));
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00019E8B File Offset: 0x0001808B
		[Obsolete("", true)]
		public float promediadoOrBase
		{
			get
			{
				if (this.m_modificable.Count == 0)
				{
					return this.m_base;
				}
				return this.Clamp(this.m_modificable.PromediarSinValor());
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x00019EB2 File Offset: 0x000180B2
		public float valorCalculadoFast
		{
			get
			{
				if (this.m_lastValorCalculadoID.IsCurrent())
				{
					return this.m_lastValorCalculadoV2;
				}
				return this.valorCalculado;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00019ED0 File Offset: 0x000180D0
		public float valorCalculado
		{
			get
			{
				float num = this.m_base;
				if (this.m_adicionable.Count > 0)
				{
					num = this.m_adicionable.AdicinarValorIncluyendo(num);
				}
				if (this.m_promediable.Count > 0)
				{
					num = this.m_promediable.PromediarConValor(num);
				}
				float num2 = 1f;
				if (this.m_modificable.Count > 0)
				{
					num2 = this.m_modificable.ModificarValor(num2);
				}
				float num3 = num * num2;
				if (this.m_minValorable.Count > 0)
				{
					num3 = this.m_minValorable.MaximoValorIncluyendo(num3);
				}
				if (this.m_maxValorable.Count > 0)
				{
					num3 = this.m_maxValorable.MinimoValorIncluyendo(num3);
				}
				num3 = this.Clamp(num3);
				this.SetLastValorCalculado(num3);
				return num3;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x00019F88 File Offset: 0x00018188
		public float valorCalculadoSinModificaciones
		{
			get
			{
				float num = this.m_base;
				num = this.Clamp(num);
				this.SetLastValorCalculado(num);
				return num;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00019FAC File Offset: 0x000181AC
		public float lastValor
		{
			get
			{
				return this.m_lastValorCalculadoV2;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00019FB4 File Offset: 0x000181B4
		public float @base
		{
			get
			{
				return this.m_base;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00019FBC File Offset: 0x000181BC
		public float weight
		{
			get
			{
				if (this.@base == 0f || !this.m_initiated)
				{
					Debug.LogError("No se puede usar weight si la base es zero o nunca fue iniciada");
					return 0f;
				}
				return this.lastValor / this.@base;
			}
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00019FF0 File Offset: 0x000181F0
		protected void SetLastValorCalculado(float lastValorCalculado)
		{
			this.m_lastValorCalculadoV2 = lastValorCalculado;
			this.m_lastValorCalculadoID = UpdateAutoId.current;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0001A004 File Offset: 0x00018204
		public float initial
		{
			get
			{
				return this.m_initial;
			}
		}

		// Token: 0x0600075E RID: 1886
		protected abstract void LoadBase(float val);

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x0001A00C File Offset: 0x0001820C
		public bool initiated
		{
			get
			{
				return this.m_initiated;
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001A014 File Offset: 0x00018214
		public override void InitBaseTodas(float val)
		{
			this.InitBase(val);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001A01D File Offset: 0x0001821D
		public override float PromedioDeTodosLosLastValores()
		{
			return this.m_lastValorCalculadoV2;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001A025 File Offset: 0x00018225
		public override float MayorDeTodosLosLastValores()
		{
			return this.m_lastValorCalculadoV2;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001A02D File Offset: 0x0001822D
		public void InitBase(float val)
		{
			if (this.m_initiated)
			{
				Debug.LogError("No se puede iniciar un valor mas de una vez");
				return;
			}
			this.m_initial = val;
			this.m_initiated = true;
			this.LoadBase(val);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0001A057 File Offset: 0x00018257
		public void ForceNewValue(float val, bool normalizar)
		{
			if (!this.m_initiated)
			{
				this.InitBase(val);
			}
			if (normalizar)
			{
				this.LoadBase(Mathf.Lerp(this.Range.minValue, this.Range.maxValue, val));
				return;
			}
			this.LoadBase(val);
		}

		// Token: 0x04000206 RID: 518
		[SerializeField]
		protected float m_base;

		// Token: 0x04000207 RID: 519
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastValorCalculadoV2;

		// Token: 0x04000208 RID: 520
		private UpdateAutoId m_lastValorCalculadoID;

		// Token: 0x04000209 RID: 521
		[NonSerialized]
		private bool m_initiated;

		// Token: 0x0400020A RID: 522
		[SerializeField]
		[ReadOnlyUI]
		private float m_initial;
	}
}

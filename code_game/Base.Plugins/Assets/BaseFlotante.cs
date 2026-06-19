using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000101 RID: 257
	[Serializable]
	public abstract class BaseFlotante
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00019CC8 File Offset: 0x00017EC8
		public ModificableDeFloat adicionable
		{
			get
			{
				return this.m_adicionable;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00019CD0 File Offset: 0x00017ED0
		public ModificableDeFloat promediable
		{
			get
			{
				return this.m_promediable;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x00019CD8 File Offset: 0x00017ED8
		public ModificableDeFloat modificable
		{
			get
			{
				return this.m_modificable;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00019CE0 File Offset: 0x00017EE0
		public ModificableDeFloat minValorable
		{
			get
			{
				return this.m_minValorable;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x00019CE8 File Offset: 0x00017EE8
		public ModificableDeFloat maxValorable
		{
			get
			{
				return this.m_maxValorable;
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00019CF0 File Offset: 0x00017EF0
		protected virtual float Clamp(float valor)
		{
			float num = Mathf.Clamp(valor, this.Range.minValue, this.Range.maxValue);
			if (!this.silenciarAlertaDeRangos && !Mathf.Approximately(num, valor))
			{
				string[] array = new string[6];
				array[0] = "valor: ";
				array[1] = valor.ToString();
				array[2] = " fuera de rango: ";
				int num2 = 3;
				ClampRange clampRange = this.Range;
				array[num2] = clampRange.minValue.ToString();
				array[4] = " -> ";
				int num3 = 5;
				clampRange = this.Range;
				array[num3] = clampRange.maxValue.ToString();
				Debug.LogWarning(string.Concat(array));
			}
			return num;
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00019D8A File Offset: 0x00017F8A
		public ModificadorDeFloat ObtenerPromediadorNotNull(Object obj)
		{
			return this.m_promediable.ObtenerModificadorNotNull(obj);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00019D98 File Offset: 0x00017F98
		public ModificadorDeFloat ObtenerModificadorNotNull(Object obj)
		{
			return this.m_modificable.ObtenerModificadorNotNull(obj);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00019DA6 File Offset: 0x00017FA6
		public ModificadorDeFloat ObtenerMinValorableNotNull(Object obj)
		{
			return this.m_minValorable.ObtenerModificadorNotNull(obj);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00019DB4 File Offset: 0x00017FB4
		public ModificadorDeFloat ObtenerMaxValorableNotNull(Object obj)
		{
			return this.m_maxValorable.ObtenerModificadorNotNull(obj);
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600074C RID: 1868
		protected abstract ClampRange Range { get; }

		// Token: 0x0600074D RID: 1869
		public abstract void InitBaseTodas(float val);

		// Token: 0x0600074E RID: 1870
		public abstract float PromedioDeTodosLosLastValores();

		// Token: 0x0600074F RID: 1871
		public abstract float MayorDeTodosLosLastValores();

		// Token: 0x04000200 RID: 512
		public bool silenciarAlertaDeRangos;

		// Token: 0x04000201 RID: 513
		[SerializeField]
		protected ModificableDeFloat m_modificable = new ModificableDeFloat(1f);

		// Token: 0x04000202 RID: 514
		[SerializeField]
		protected ModificableDeFloat m_promediable = new ModificableDeFloat(0f);

		// Token: 0x04000203 RID: 515
		[SerializeField]
		protected ModificableDeFloat m_adicionable = new ModificableDeFloat(0f);

		// Token: 0x04000204 RID: 516
		[SerializeField]
		protected ModificableDeFloat m_minValorable = new ModificableDeFloat(float.MinValue);

		// Token: 0x04000205 RID: 517
		[SerializeField]
		protected ModificableDeFloat m_maxValorable = new ModificableDeFloat(float.MaxValue);
	}
}

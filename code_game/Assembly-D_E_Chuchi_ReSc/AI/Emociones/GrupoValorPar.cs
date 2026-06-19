using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x0200041A RID: 1050
	[Serializable]
	public abstract class GrupoValorPar<T> : GrupoSetter, Setter<T>
	{
		// Token: 0x06001710 RID: 5904 RVA: 0x00002E26 File Offset: 0x00001026
		public GrupoValorPar()
		{
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x0005ECDE File Offset: 0x0005CEDE
		public GrupoValorPar(GrupoQueCompartenValores p)
		{
			this.m_grupo = p;
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0005ECED File Offset: 0x0005CEED
		public T valor
		{
			get
			{
				return this.m_valor;
			}
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x0005ECF5 File Offset: 0x0005CEF5
		public GrupoQueCompartenValores grupo
		{
			get
			{
				return this.m_grupo;
			}
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x0005ECFD File Offset: 0x0005CEFD
		void Setter<T>.Set(T v)
		{
			this.m_valor = v;
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x0005ED06 File Offset: 0x0005CF06
		void GrupoSetter.Set(GrupoQueCompartenValores v)
		{
			this.m_grupo = v;
		}

		// Token: 0x040011F3 RID: 4595
		[ReadOnlyUI]
		[SerializeField]
		private GrupoQueCompartenValores m_grupo;

		// Token: 0x040011F4 RID: 4596
		[SerializeField]
		private T m_valor;
	}
}

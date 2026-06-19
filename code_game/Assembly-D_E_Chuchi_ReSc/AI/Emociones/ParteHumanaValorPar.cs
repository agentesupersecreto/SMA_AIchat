using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x0200041B RID: 1051
	[Serializable]
	public abstract class ParteHumanaValorPar<T>
	{
		// Token: 0x06001716 RID: 5910 RVA: 0x0005ED0F File Offset: 0x0005CF0F
		public ParteHumanaValorPar(ParteDelCuerpoHumano p)
		{
			this.m_parte = p;
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06001717 RID: 5911 RVA: 0x0005ED1E File Offset: 0x0005CF1E
		public T valor
		{
			get
			{
				return this.m_valor;
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0005ED26 File Offset: 0x0005CF26
		public ParteDelCuerpoHumano parte
		{
			get
			{
				return this.m_parte;
			}
		}

		// Token: 0x040011F5 RID: 4597
		[ReadOnlyUI]
		[SerializeField]
		private ParteDelCuerpoHumano m_parte;

		// Token: 0x040011F6 RID: 4598
		[SerializeField]
		private T m_valor;
	}
}

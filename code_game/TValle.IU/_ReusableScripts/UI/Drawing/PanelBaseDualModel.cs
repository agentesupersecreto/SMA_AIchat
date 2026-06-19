using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000032 RID: 50
	public abstract class PanelBaseDualModel : PanelBase
	{
		// Token: 0x0600015E RID: 350 RVA: 0x00005DDC File Offset: 0x00003FDC
		public void InstantiateModelA<TModel>() where TModel : class, new()
		{
			this.m_a = new TModel();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005DEE File Offset: 0x00003FEE
		public void InstantiateModelB<TModel>() where TModel : class, new()
		{
			this.m_b = new TModel();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005E00 File Offset: 0x00004000
		public void SetModelA(object Model)
		{
			this.m_a = Model;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005E09 File Offset: 0x00004009
		public void SetModelB(object Model)
		{
			this.m_b = Model;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005E12 File Offset: 0x00004012
		public void SetSelector(Func<int> selector)
		{
			this.m_selector = selector;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005E1C File Offset: 0x0000401C
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			int num = this.m_selector();
			if (num == 0)
			{
				return this.m_a;
			}
			if (num != 1)
			{
				throw new ArgumentOutOfRangeException(num.ToString());
			}
			return this.m_b;
		}

		// Token: 0x040000AB RID: 171
		[SerializeReference]
		protected object m_a;

		// Token: 0x040000AC RID: 172
		[SerializeReference]
		protected object m_b;

		// Token: 0x040000AD RID: 173
		private Func<int> m_selector;
	}
}

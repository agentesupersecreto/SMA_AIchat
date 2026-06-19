using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000031 RID: 49
	public abstract class PanelBaseSingleModel : PanelBase
	{
		// Token: 0x0600015A RID: 346 RVA: 0x00005DB1 File Offset: 0x00003FB1
		public void InstantiateModel<TModel>() where TModel : class, new()
		{
			this.m_model = new TModel();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005DC3 File Offset: 0x00003FC3
		public void SetModel(object Model)
		{
			this.m_model = Model;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005DCC File Offset: 0x00003FCC
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			return this.m_model;
		}

		// Token: 0x040000AA RID: 170
		[SerializeReference]
		protected object m_model;
	}
}

using System;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000033 RID: 51
	public abstract class PanelBaseSingleModel<TModel> : PanelBase where TModel : class, new()
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00005E60 File Offset: 0x00004060
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			return this.m_model;
		}

		// Token: 0x040000AE RID: 174
		[SerializeField]
		protected TModel m_model = new TModel();
	}
}

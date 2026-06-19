using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200002F RID: 47
	public interface ICustomDrawingModel
	{
		// Token: 0x0600014B RID: 331
		IUIPanel Draw(Transform target);

		// Token: 0x0600014C RID: 332
		void SetControlesAPanel(IUIPanel panel, UnityAction destruir, UnityAction hide);

		// Token: 0x0600014D RID: 333
		void SetValoresAPanel(IUIPanel panel, bool silenced);

		// Token: 0x0600014E RID: 334
		void SetValoresAModelo(IUIPanel panel);
	}
}

using System;
using Assets._ReusableScripts.Miscellaneous.Activables;

namespace Assets._ReusableScripts.UI.Interacciones.Donas
{
	// Token: 0x0200001F RID: 31
	public class DesactivarEnDonaDeInteraccion : ActivarEn
	{
		// Token: 0x060000CD RID: 205 RVA: 0x00004719 File Offset: 0x00002919
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.invertir = true;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004728 File Offset: 0x00002928
		protected override bool PuedeActivar()
		{
			return DonaDeInteraccion.main != null && DonaDeInteraccion.main.isDrawing;
		}
	}
}

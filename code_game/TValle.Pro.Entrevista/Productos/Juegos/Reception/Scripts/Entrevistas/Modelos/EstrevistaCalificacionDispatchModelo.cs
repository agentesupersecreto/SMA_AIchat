using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000014 RID: 20
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Modelo]
	[Serializable]
	public class EstrevistaCalificacionDispatchModelo
	{
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060000E6 RID: 230 RVA: 0x00005570 File Offset: 0x00003770
		// (remove) Token: 0x060000E7 RID: 231 RVA: 0x000055A8 File Offset: 0x000037A8
		public event Action<EstrevistaCalificacionDispatchModelo> onGoBackClicked;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060000E8 RID: 232 RVA: 0x000055E0 File Offset: 0x000037E0
		// (remove) Token: 0x060000E9 RID: 233 RVA: 0x00005618 File Offset: 0x00003818
		public event Action<EstrevistaCalificacionDispatchModelo> onDispatchHerClicked;

		// Token: 0x060000EA RID: 234 RVA: 0x0000564D File Offset: 0x0000384D
		[Label("Go Back", "US")]
		[BotonDePanel]
		public void GoBack()
		{
			Action<EstrevistaCalificacionDispatchModelo> action = this.onGoBackClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005660 File Offset: 0x00003860
		[Label("Dispatch her", "US")]
		[BotonDePanel]
		public void DispatchHer()
		{
			Action<EstrevistaCalificacionDispatchModelo> action = this.onDispatchHerClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}
	}
}

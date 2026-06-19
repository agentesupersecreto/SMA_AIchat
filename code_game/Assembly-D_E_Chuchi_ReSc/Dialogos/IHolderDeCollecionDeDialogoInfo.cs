using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001CA RID: 458
	public interface IHolderDeCollecionDeDialogoInfo
	{
		// Token: 0x06000AE0 RID: 2784
		bool IsValid();

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000AE1 RID: 2785
		float modDeScore { get; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000AE2 RID: 2786
		int cantidadDeListasDeDialogos { get; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000AE3 RID: 2787
		int cantidadDeDialogosInfo { get; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000AE4 RID: 2788
		bool paraCualquierRasgo { get; }

		// Token: 0x06000AE5 RID: 2789
		bool ContieneRasgo(PersonalidadRasgo rasgo);

		// Token: 0x06000AE6 RID: 2790
		DialogoInfo ObtenerDialogo();

		// Token: 0x06000AE7 RID: 2791
		DialogoInfo ObtenerDialogo(Localizacion localizacion, DialogoInfo last);

		// Token: 0x06000AE8 RID: 2792
		[Obsolete("TODO: alterar el puntajeBuscando con las emociones del character")]
		bool Proc(PersonalidadRasgo rasgo, float puntajeBuscando, out float score);
	}
}

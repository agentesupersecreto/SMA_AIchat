using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos
{
	// Token: 0x020001DF RID: 479
	public abstract class SimpleHolderDeDialogos : ScriptableObject, IHolderDeCollecionDeDialogoInfo
	{
		// Token: 0x06000B6C RID: 2924 RVA: 0x0003410B File Offset: 0x0003230B
		protected void OnDisable()
		{
			this.OnDeshabilitado();
		}

		// Token: 0x06000B6D RID: 2925
		protected abstract void OnDeshabilitado();

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000B6E RID: 2926
		public abstract int cantidadDeListasDeDialogos { get; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000B6F RID: 2927
		public abstract int cantidadDeDialogosInfo { get; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000B70 RID: 2928
		public abstract bool paraCualquierRasgo { get; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000B71 RID: 2929
		public abstract float modDeScore { get; }

		// Token: 0x06000B72 RID: 2930
		public abstract bool ContieneRasgo(PersonalidadRasgo rasgo);

		// Token: 0x06000B73 RID: 2931
		public abstract bool IsValid();

		// Token: 0x06000B74 RID: 2932
		public abstract DialogoInfo ObtenerDialogo();

		// Token: 0x06000B75 RID: 2933
		public abstract DialogoInfo ObtenerDialogo(Localizacion localizacion, DialogoInfo last);

		// Token: 0x06000B76 RID: 2934
		[Obsolete("TODO: alterar el puntajeBuscando con las emociones del character")]
		public abstract bool Proc(PersonalidadRasgo rasgo, float puntajeBuscando, out float score);
	}
}

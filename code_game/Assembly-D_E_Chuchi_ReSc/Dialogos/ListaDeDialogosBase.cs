using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001D3 RID: 467
	public abstract class ListaDeDialogosBase : ScriptableObject, ICollecionDeDialogoInfo
	{
		// Token: 0x06000B28 RID: 2856
		protected abstract void AddDialogoInfo(string text);

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000B29 RID: 2857
		public abstract int Count { get; }

		// Token: 0x06000B2A RID: 2858
		public abstract void ReordenarSegunChance();

		// Token: 0x06000B2B RID: 2859
		public abstract void AutoGenerar(string auto);

		// Token: 0x06000B2C RID: 2860
		public abstract void RemoverRepetidos();

		// Token: 0x06000B2D RID: 2861
		public abstract void RemoverVacios();

		// Token: 0x06000B2E RID: 2862
		public abstract string InvertAutoGenerar();

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000B2F RID: 2863
		public abstract IReadOnlyList<DialogoInfo> dialogosInfoBase { get; }

		// Token: 0x06000B30 RID: 2864
		public abstract DialogoInfo ObtenerDialogo();

		// Token: 0x06000B31 RID: 2865
		public abstract DialogoInfo ObtenerDialogo(DialogoInfo last);
	}
}

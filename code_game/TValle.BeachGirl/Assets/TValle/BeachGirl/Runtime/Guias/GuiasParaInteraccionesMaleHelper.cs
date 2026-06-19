using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Guias
{
	// Token: 0x020000A6 RID: 166
	public class GuiasParaInteraccionesMaleHelper : CustomMonobehaviour
	{
		// Token: 0x04000302 RID: 770
		public GuiasParaInteraccionesMaleHelper.Guias guias = new GuiasParaInteraccionesMaleHelper.Guias();

		// Token: 0x02000195 RID: 405
		[Serializable]
		public class Guias
		{
			// Token: 0x040008F1 RID: 2289
			public Transform holdPenisPulgar;

			// Token: 0x040008F2 RID: 2290
			public Transform holdPenisIndice;

			// Token: 0x040008F3 RID: 2291
			public Transform holdPenisHand;
		}
	}
}

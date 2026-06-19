using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class AutoRatingWraper
	{
		// Token: 0x040000AF RID: 175
		[HideInInspector]
		public int modo;

		// Token: 0x040000B0 RID: 176
		public InterpretacionSimple simple;

		// Token: 0x040000B1 RID: 177
		public InterpretacionCompletaDeFemale completa;
	}
}

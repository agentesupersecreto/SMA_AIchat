using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class AutoRatingProfile
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00006AAF File Offset: 0x00004CAF
		public bool IsValid()
		{
			return this.mode > -1 && !string.IsNullOrWhiteSpace(this.nombre) && this.picture != null;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006AD8 File Offset: 0x00004CD8
		public void Reset()
		{
			this.mode = -1;
			this.nombre = string.Empty;
			this.simple = InterpretacionSimple.@default;
			this.completa = InterpretacionSimple.defaultCompleta;
			if (this.picture != null)
			{
				Object.Destroy(this.picture);
			}
			this.picture = null;
		}

		// Token: 0x040000AA RID: 170
		public int mode = -1;

		// Token: 0x040000AB RID: 171
		public string nombre = string.Empty;

		// Token: 0x040000AC RID: 172
		public Texture2D picture;

		// Token: 0x040000AD RID: 173
		public InterpretacionSimple simple = InterpretacionSimple.@default;

		// Token: 0x040000AE RID: 174
		public InterpretacionCompletaDeFemale completa = InterpretacionSimple.defaultCompleta;
	}
}

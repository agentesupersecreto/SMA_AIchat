using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff.Mapas
{
	// Token: 0x020002C5 RID: 709
	[CreateAssetMenu(fileName = "DisplayableBuffMap", menuName = "Objetos/Buff/DisplayableBuffMap")]
	public class DisplayableBuffMap : BuffMap
	{
		// Token: 0x06001227 RID: 4647 RVA: 0x00055524 File Offset: 0x00053724
		protected override void SetConfigToNewEvent(BuffEvento r, DateTime start, string idSegundaria, ArgumentoDeEfecto argumento, BuffMap.Duracion duracionOverride = null)
		{
			base.SetConfigToNewEvent(r, start, idSegundaria, argumento, duracionOverride);
			r.displayFirst = this.displayAlwaysOnTop;
		}

		// Token: 0x04000D3F RID: 3391
		[Space]
		[Header("Displayable")]
		public bool displayAlwaysOnTop;

		// Token: 0x04000D40 RID: 3392
		public Nombrable.Class nombreLocalizado = new Nombrable.Class();

		// Token: 0x04000D41 RID: 3393
		public Nombrable.Class postNombreLocalizado = new Nombrable.Class();

		// Token: 0x04000D42 RID: 3394
		public Nombrable.Class tooltipLocalizada = new Nombrable.Class();

		// Token: 0x04000D43 RID: 3395
		[Space]
		public List<DisplayableBuffMap.NombresPorID> nombresPorID = new List<DisplayableBuffMap.NombresPorID>();

		// Token: 0x020002C6 RID: 710
		[Serializable]
		public class NombresPorID
		{
			// Token: 0x04000D44 RID: 3396
			public string id;

			// Token: 0x04000D45 RID: 3397
			public Nombrable.Class nombreLocalizado = new Nombrable.Class();

			// Token: 0x04000D46 RID: 3398
			public Nombrable.Class postNombreLocalizado = new Nombrable.Class();

			// Token: 0x04000D47 RID: 3399
			public Nombrable.Class tooltipLocalizada = new Nombrable.Class();
		}
	}
}

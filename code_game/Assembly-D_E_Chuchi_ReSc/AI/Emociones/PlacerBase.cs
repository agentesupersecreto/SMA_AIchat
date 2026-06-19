using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000401 RID: 1025
	public abstract class PlacerBase : Emocion
	{
		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001661 RID: 5729 RVA: 0x00030684 File Offset: 0x0002E884
		public sealed override float prioridad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06001662 RID: 5730 RVA: 0x0005CDAB File Offset: 0x0005AFAB
		public sealed override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.placer;
			}
		}
	}
}

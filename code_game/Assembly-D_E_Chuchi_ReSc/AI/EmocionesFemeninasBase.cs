using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200034F RID: 847
	public abstract class EmocionesFemeninasBase : EmocionesHumanasBase
	{
		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06001243 RID: 4675
		public abstract Arousal arousal { get; }

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06001244 RID: 4676
		public abstract ConsentToHero consentToHero { get; }

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06001245 RID: 4677
		public abstract DesHielo desHielo { get; }

		// Token: 0x06001246 RID: 4678 RVA: 0x0004F58B File Offset: 0x0004D78B
		public EmocionesFemeninasValues ObtenerModsFemeninos()
		{
			return new EmocionesFemeninasValues(this);
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x0004F593 File Offset: 0x0004D793
		public EmocionesFemeninasValues ObtenerModsFemeninos(bool NoLimitado)
		{
			return new EmocionesFemeninasValues(this, NoLimitado);
		}
	}
}

using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200034E RID: 846
	[Serializable]
	public struct EmocionesFemeninasValues
	{
		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x0004F480 File Offset: 0x0004D680
		public static EmocionesFemeninasValues emptyValid
		{
			get
			{
				return new EmocionesFemeninasValues
				{
					m_loaded = true,
					humanasValues = EmocionesHumanasValuesOld.emptyValid
				};
			}
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0004F4AC File Offset: 0x0004D6AC
		internal EmocionesFemeninasValues(EmocionesFemeninasBase emos)
		{
			this.humanasValues = emos.ObtenerModsHumanosOld();
			this.arousal = emos.arousal.value.mod;
			this.consentToHero = emos.consentToHero.value.mod;
			this.desHielo = emos.desHielo.value.mod;
			this.m_loaded = true;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0004F518 File Offset: 0x0004D718
		internal EmocionesFemeninasValues(EmocionesFemeninasBase emos, bool NoLimitado)
		{
			this = new EmocionesFemeninasValues(emos);
			if (NoLimitado)
			{
				this.arousal = emos.arousal.valorNoLimitado / 100f;
				this.consentToHero = emos.consentToHero.valorNoLimitado / 100f;
				this.desHielo = emos.desHielo.valorNoLimitado / 100f;
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x0004F574 File Offset: 0x0004D774
		public bool loaded
		{
			get
			{
				return this.m_loaded && this.humanasValues.loaded;
			}
		}

		// Token: 0x04000F61 RID: 3937
		[SerializeField]
		private bool m_loaded;

		// Token: 0x04000F62 RID: 3938
		public float arousal;

		// Token: 0x04000F63 RID: 3939
		public float consentToHero;

		// Token: 0x04000F64 RID: 3940
		public float desHielo;

		// Token: 0x04000F65 RID: 3941
		public EmocionesHumanasValuesOld humanasValues;
	}
}

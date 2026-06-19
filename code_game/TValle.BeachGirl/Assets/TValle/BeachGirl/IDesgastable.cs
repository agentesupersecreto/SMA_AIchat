using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200001D RID: 29
	public interface IDesgastable
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000071 RID: 113
		float current { get; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000072 RID: 114
		float currentAI { get; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000073 RID: 115
		ModificableDeFloat minimo { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000074 RID: 116
		ModificableDeFloat sumable { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000075 RID: 117
		ModificableDeFloat modificable { get; }

		// Token: 0x06000076 RID: 118
		void CalcularDesgastes(out float desgasteMinimo, out float desgasteActual, out float desgasteLimpio);
	}
}

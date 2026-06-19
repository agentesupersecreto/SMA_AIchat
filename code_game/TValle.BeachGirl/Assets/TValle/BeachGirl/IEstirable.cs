using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200001E RID: 30
	public interface IEstirable
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000077 RID: 119
		bool defaultEstirableEstate { get; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000078 RID: 120
		bool currentEstirableEstate { get; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000079 RID: 121
		ModificableDeBool estirandoOR { get; }
	}
}

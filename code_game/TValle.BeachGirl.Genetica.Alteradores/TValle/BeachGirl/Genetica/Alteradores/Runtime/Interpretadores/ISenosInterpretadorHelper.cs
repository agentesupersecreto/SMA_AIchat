using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000017 RID: 23
	public interface ISenosInterpretadorHelper
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060000C3 RID: 195
		float currentSubjectiveAureolaSize { get; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060000C4 RID: 196
		float currentSubjectiveNippleSize { get; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060000C5 RID: 197
		float minBrightness { get; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060000C6 RID: 198
		float maxBrightness { get; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060000C7 RID: 199
		Color colorDePezonesSinModificaciones { get; }
	}
}

using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200000B RID: 11
	public interface IFacialSkinInterpretadorHelper
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000069 RID: 105
		float currentEyeShadowWeigth { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006A RID: 106
		float currentCheeksMakeUpWeigth { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006B RID: 107
		Color lipstickColorSinModificaciones { get; }
	}
}

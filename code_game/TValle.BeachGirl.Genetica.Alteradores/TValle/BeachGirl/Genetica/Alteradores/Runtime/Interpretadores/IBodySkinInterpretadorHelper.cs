using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000005 RID: 5
	public interface IBodySkinInterpretadorHelper
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000051 RID: 81
		float currentSkinTanWeigth { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000052 RID: 82
		float currentSkinUniformity { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000053 RID: 83
		Color fingerNailsSinModificaciones { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000054 RID: 84
		Color toeNailsSinModificaciones { get; }
	}
}

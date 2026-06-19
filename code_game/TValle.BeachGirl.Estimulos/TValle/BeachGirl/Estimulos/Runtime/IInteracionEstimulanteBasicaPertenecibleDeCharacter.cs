using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Estimulos.Runtime
{
	// Token: 0x02000022 RID: 34
	public interface IInteracionEstimulanteBasicaPertenecibleDeCharacter : IInteracionEstimulanteBasica
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000FB RID: 251
		Component GetRealEstimulante { get; }
	}
}

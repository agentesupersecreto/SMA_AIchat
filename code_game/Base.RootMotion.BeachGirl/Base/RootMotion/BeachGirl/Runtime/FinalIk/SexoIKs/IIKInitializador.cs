using System;
using Assets.TValle.BeachGirl.Runtime;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000022 RID: 34
	public interface IIKInitializador
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000114 RID: 276
		// (set) Token: 0x06000115 RID: 277
		Vector3 axisEurleOffset { get; set; }

		// Token: 0x06000116 RID: 278
		void FixAxis(TipoDeSexIK tipo);

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000117 RID: 279
		Transform lokingBone { get; }
	}
}

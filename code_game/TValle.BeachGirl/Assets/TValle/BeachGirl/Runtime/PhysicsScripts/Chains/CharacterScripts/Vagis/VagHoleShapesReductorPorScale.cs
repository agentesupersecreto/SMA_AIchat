using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Vagis
{
	// Token: 0x02000080 RID: 128
	[RequireComponent(typeof(VagHole))]
	public class VagHoleShapesReductorPorScale : HoleShapesReductorPorScale
	{
		// Token: 0x06000369 RID: 873 RVA: 0x0000A428 File Offset: 0x00008628
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000A436 File Offset: 0x00008636
		protected override IReadOnlyList<string> GetHoleShapeNames()
		{
			return this.m_holeShapesController.nombresDeVag;
		}
	}
}

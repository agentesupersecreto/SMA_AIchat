using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Anuss
{
	// Token: 0x02000092 RID: 146
	[RequireComponent(typeof(AnusHole))]
	public class AnusHoleShapesReductorPorScale : HoleShapesReductorPorScale
	{
		// Token: 0x0600043E RID: 1086 RVA: 0x0000E09B File Offset: 0x0000C29B
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000E0A9 File Offset: 0x0000C2A9
		protected override IReadOnlyList<string> GetHoleShapeNames()
		{
			return this.m_holeShapesController.nombresDeAnus;
		}
	}
}

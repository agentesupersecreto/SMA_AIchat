using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Penes
{
	// Token: 0x0200011B RID: 283
	public class PenisPartPunta : PenisPart, IPenisPartPuntaPenetratiosCallbacks, IPenisPartPenetratiosCallbacks
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x000295FE File Offset: 0x000277FE
		public sealed override void SetParam(Penetrador p, int i, PenisPoint pu, Transform bone)
		{
			base.SetParam(p, i, pu, bone);
			this.m_scaler.scaleAltura = true;
		}
	}
}

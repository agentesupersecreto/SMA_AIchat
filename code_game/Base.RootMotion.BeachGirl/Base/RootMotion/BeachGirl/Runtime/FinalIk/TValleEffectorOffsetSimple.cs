using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x0200001D RID: 29
	public abstract class TValleEffectorOffsetSimple : TValleEffectorOffsetBase
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x000069F3 File Offset: 0x00004BF3
		public void Init(IKLayerFlag IKLayer, IKOrderFlag IKOrder, IKPassOrderFlag IKPassOrder)
		{
			if (this.m_init)
			{
				return;
			}
			this.m_init = true;
			this.iKLayer = IKLayer;
			this.iKOrder = IKOrder;
			this.iKPassOrder = IKPassOrder;
			base.Subscribe(2);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006A2D File Offset: 0x00004C2D
		[Obsolete("", true)]
		public void Init(TValleOffsetModifier.Tipo Ik, TValleOffsetModifier.Tipo pass)
		{
			if (this.m_init)
			{
				return;
			}
			this.m_init = true;
			this.updateOnPass = pass;
			this.updateOnIK = Ik;
			base.Subscribe(2);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006A60 File Offset: 0x00004C60
		protected void SetOffset(IKEffector effector, FullBodyBipedEffector fullBodyBipedEffector, Vector3 positionOffset)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.m_IEffectorIsLooked != null && !this.m_IEffectorIsLooked.PuedeTrasladarse(fullBodyBipedEffector))
			{
				return;
			}
			effector.positionOffset += positionOffset;
			bool debugDraw = this.debugDraw;
		}

		// Token: 0x040000A7 RID: 167
		private bool m_init;
	}
}

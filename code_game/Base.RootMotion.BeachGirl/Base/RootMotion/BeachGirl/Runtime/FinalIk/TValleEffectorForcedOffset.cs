using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x02000019 RID: 25
	public abstract class TValleEffectorForcedOffset : TValleEffectorOffsetBase
	{
		// Token: 0x060000CA RID: 202 RVA: 0x000063FF File Offset: 0x000045FF
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
			base.Subscribe(1);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006439 File Offset: 0x00004639
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
			base.Subscribe(1);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000646C File Offset: 0x0000466C
		protected TValleEffectorForcer ObtenerForcer(FullBodyBipedIK ik)
		{
			TValleEffectorForcer componentNotNull;
			if (!this.m_forcerDeIK.TryGetValue(ik, out componentNotNull))
			{
				componentNotNull = ik.GetComponentNotNull<TValleEffectorForcer>();
				this.m_forcerDeIK.Add(ik, componentNotNull);
			}
			return componentNotNull;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000064A0 File Offset: 0x000046A0
		protected void SetOffset(TValleEffectorForcer forcer, ref Vector3 forcingPositionOffset, ref float forcingPositionOffsetWeigth, IKEffector effector, FullBodyBipedEffector fullBodyBipedEffector, Vector3 positionOffset, float positionOffsetWeigth)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.m_IEffectorIsLooked != null && !this.m_IEffectorIsLooked.PuedeTrasladarse(fullBodyBipedEffector))
			{
				return;
			}
			bool debugDraw = this.debugDraw;
			forcingPositionOffset += positionOffset;
			forcingPositionOffsetWeigth = Mathf.Max(forcingPositionOffsetWeigth, positionOffsetWeigth * this.weight);
		}

		// Token: 0x0400007A RID: 122
		public float bodyOverridenWeight;

		// Token: 0x0400007B RID: 123
		public float leftShoulderOverridenWeight;

		// Token: 0x0400007C RID: 124
		public float rightShoulderOverridenWeight;

		// Token: 0x0400007D RID: 125
		public float leftThighOverridenWeight;

		// Token: 0x0400007E RID: 126
		public float rightThighOverridenWeight;

		// Token: 0x0400007F RID: 127
		public float leftHandOverridenWeight;

		// Token: 0x04000080 RID: 128
		public float rightHandOverridenWeight;

		// Token: 0x04000081 RID: 129
		public float leftFootOverridenWeight;

		// Token: 0x04000082 RID: 130
		public float rightFootOverridenWeight;

		// Token: 0x04000083 RID: 131
		private bool m_init;

		// Token: 0x04000084 RID: 132
		private Dictionary<FullBodyBipedIK, TValleEffectorForcer> m_forcerDeIK = new Dictionary<FullBodyBipedIK, TValleEffectorForcer>();
	}
}

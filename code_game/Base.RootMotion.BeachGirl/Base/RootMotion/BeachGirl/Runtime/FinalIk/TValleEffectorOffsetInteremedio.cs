using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x0200001C RID: 28
	public abstract class TValleEffectorOffsetInteremedio : TValleEffectorOffsetBase
	{
		// Token: 0x060000DF RID: 223 RVA: 0x00006879 File Offset: 0x00004A79
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
			base.Subscribe(3);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000068B3 File Offset: 0x00004AB3
		[Obsolete("", true)]
		public void Init(TValleOffsetModifier.Tipo Ik, TValleOffsetModifier.Tipo pasando)
		{
			if (this.m_init)
			{
				return;
			}
			this.m_init = true;
			this.updateOnPass = pasando;
			this.updateOnIK = Ik;
			base.Subscribe(3);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000068E8 File Offset: 0x00004AE8
		protected void SetOffset(IKEffector effector, FullBodyBipedEffector fullBodyBipedEffector, Vector3 positionOffset)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			Vector3 position = effector.position;
			effector.positionOffset += positionOffset;
			bool debugDraw = this.debugDraw;
			if (effector.positionWeight <= 0f)
			{
				return;
			}
			if (this.m_IEffectorIsLooked != null && !this.m_IEffectorIsLooked.PuedeTrasladarse(fullBodyBipedEffector))
			{
				return;
			}
			Vector3 vector = Vector3.Lerp(Vector3.zero, positionOffset, effector.positionWeight.OutPow(this.power));
			ValueTuple<IKEffector, Vector3> valueTuple = new ValueTuple<IKEffector, Vector3>(effector, vector);
			this.effectorsPositionChanges.Enqueue(valueTuple);
			effector.position += vector;
			bool debugDraw2 = this.debugDraw;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006990 File Offset: 0x00004B90
		protected override void IKUpdated(FullBodyBipedIK ik)
		{
			while (this.effectorsPositionChanges.Count > 0)
			{
				ValueTuple<IKEffector, Vector3> valueTuple = this.effectorsPositionChanges.Dequeue();
				valueTuple.Item1.position -= valueTuple.Item2;
			}
		}

		// Token: 0x040000A4 RID: 164
		public float power = 3f;

		// Token: 0x040000A5 RID: 165
		private bool m_init;

		// Token: 0x040000A6 RID: 166
		private Queue<ValueTuple<IKEffector, Vector3>> effectorsPositionChanges = new Queue<ValueTuple<IKEffector, Vector3>>();
	}
}

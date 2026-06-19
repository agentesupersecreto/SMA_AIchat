using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Males
{
	// Token: 0x0200009F RID: 159
	public sealed class FingerPenisDedosParentFix : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0000FD12 File Offset: 0x0000DF12
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.beforePhyscisConstraints);
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000FD1B File Offset: 0x0000DF1B
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterPhyscisConstraints);
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0000FD24 File Offset: 0x0000DF24
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Animator bodyAnimator = this.GetComponentEnRoot(false).bodyAnimator;
			this.m_hand = bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			this.m_prox = bodyAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
			this.m_middle = bodyAnimator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
			this.m_distal = bodyAnimator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000FD7C File Offset: 0x0000DF7C
		public override void OnUpdateEvent1()
		{
			this.m_prox.parent = this.m_hand;
			this.m_middle.parent = this.m_hand;
			this.m_distal.parent = this.m_hand;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000FDB1 File Offset: 0x0000DFB1
		public override void OnUpdateEvent2()
		{
			this.m_distal.parent = this.m_middle;
			this.m_middle.parent = this.m_prox;
			this.m_prox.parent = this.m_hand;
		}

		// Token: 0x040002DF RID: 735
		private Transform m_hand;

		// Token: 0x040002E0 RID: 736
		private Transform m_prox;

		// Token: 0x040002E1 RID: 737
		private Transform m_middle;

		// Token: 0x040002E2 RID: 738
		private Transform m_distal;
	}
}

using System;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime.IK;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020001B4 RID: 436
	[RequireComponent(typeof(LimbIKDeCustomPose))]
	public class ChangePinnedBoneColor : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x000342EA File Offset: 0x000324EA
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LimbIKDeCustomPose = base.GetComponent<LimbIKDeCustomPose>();
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00034300 File Offset: 0x00032500
		public override void OnUpdateEvent1()
		{
			if (this.m_LimbIKDeCustomPose.handOrFeet.gizmosDeSkeleton.modo == GizmosDeSkeleton.ModoV2.inactivo)
			{
				return;
			}
			bool flag = !Singleton<GeneralInputProxy>.instance.toolMovement.goingDown;
			this.m_LimbIKDeCustomPose.pinHandOrFeet = flag;
			for (int i = 0; i < this.m_LimbIKDeCustomPose.handOrFeet.pinableGizmosDeBone.Count; i++)
			{
				this.m_LimbIKDeCustomPose.handOrFeet.pinableGizmosDeBone[i].SetPinState(flag);
			}
		}

		// Token: 0x040007EC RID: 2028
		private LimbIKDeCustomPose m_LimbIKDeCustomPose;
	}
}

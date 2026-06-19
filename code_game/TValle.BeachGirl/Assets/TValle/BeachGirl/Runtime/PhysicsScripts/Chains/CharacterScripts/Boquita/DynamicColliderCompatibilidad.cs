using System;
using System.Collections.Generic;
using Assets.Base.Bones.Runtime.PoseLoaderSaver;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000088 RID: 136
	public class DynamicColliderCompatibilidad : CustomMonobehaviour
	{
		// Token: 0x060003D0 RID: 976 RVA: 0x0000B97B File Offset: 0x00009B7B
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LoadPosesFormLastFrameAndRestore = this.GetComponentNotNull<LoadPosesFormLastFrameAndRestore>();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000B990 File Offset: 0x00009B90
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			MapaSingletonDeFemaleBones instance = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			Transform transform = base.transform.FindDeepChild(instance.LabiosRoot, true);
			List<Transform> list = new List<Transform>
			{
				transform.FindDeepChild(instance.LabioOutUp, true),
				transform.FindDeepChild(instance.LabioOutDown, true),
				transform.FindDeepChild(instance.LabioOutUp_R, true),
				transform.FindDeepChild(instance.LabioOutUp_L, true),
				transform.FindDeepChild(instance.LabioOutDown_R, true),
				transform.FindDeepChild(instance.LabioOutDown_L, true),
				transform.FindDeepChild(instance.LabioOutSide_R, true),
				transform.FindDeepChild(instance.LabioOutSide_L, true),
				transform.FindDeepChild(instance.LabioInUp, true),
				transform.FindDeepChild(instance.LabioInDown, true),
				transform.FindDeepChild(instance.LabioInUp_R, true),
				transform.FindDeepChild(instance.LabioInUp_L, true),
				transform.FindDeepChild(instance.LabioInDown_R, true),
				transform.FindDeepChild(instance.LabioInDown_L, true),
				transform.FindDeepChild(instance.LabioInSide_R, true),
				transform.FindDeepChild(instance.LabioInSide_L, true),
				transform.FindDeepChild(instance.LabioOutSTREUp, true),
				transform.FindDeepChild(instance.LabioOutSTREDown, true),
				transform.FindDeepChild(instance.LabioOutSTREUp_R, true),
				transform.FindDeepChild(instance.LabioOutSTREUp_L, true),
				transform.FindDeepChild(instance.LabioOutSTREDown_R, true),
				transform.FindDeepChild(instance.LabioOutSTREDown_L, true),
				transform.FindDeepChild(instance.LabioOutSTRESide_R, true),
				transform.FindDeepChild(instance.LabioOutSTRESide_L, true),
				transform.FindDeepChild(instance.DEFLabioInUp_R, true),
				transform.FindDeepChild(instance.DEFLabioInUp_L, true),
				transform.FindDeepChild(instance.DEFLabioInDown_R, true),
				transform.FindDeepChild(instance.DEFLabioInDown_L, true),
				transform.FindDeepChild(instance.DEFLabioInUp_R_001, true),
				transform.FindDeepChild(instance.DEFLabioInUp_L_001, true),
				transform.FindDeepChild(instance.DEFLabioInDown_R_001, true),
				transform.FindDeepChild(instance.DEFLabioInDown_L_001, true)
			};
			this.m_LoadPosesFormLastFrameAndRestore.Init(list, GlobalUpdater.UpdateType.afterPhyscisConstraints, GlobalUpdater.UpdateType.beforeDynamicColliders, GlobalUpdater.UpdateType.afterDynamicColliders);
		}

		// Token: 0x04000236 RID: 566
		private LoadPosesFormLastFrameAndRestore m_LoadPosesFormLastFrameAndRestore;
	}
}

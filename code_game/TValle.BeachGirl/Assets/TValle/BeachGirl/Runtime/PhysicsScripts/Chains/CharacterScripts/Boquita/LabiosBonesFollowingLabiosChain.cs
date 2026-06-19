using System;
using Assets.TValle.BeachGirl.Runtime.Guias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008C RID: 140
	public class LabiosBonesFollowingLabiosChain : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000C1A6 File Offset: 0x0000A3A6
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates2);
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000C1AF File Offset: 0x0000A3AF
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LabiosChain = base.GetComponent<LabiosChain>();
			if (!this.m_LabiosChain.isStared)
			{
				base.SetManualStart();
				this.m_LabiosChain.stared += this.M_LabiosChain_stared;
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000C1ED File Offset: 0x0000A3ED
		private void M_LabiosChain_stared(object sender)
		{
			base.ManualStart();
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000C1F8 File Offset: 0x0000A3F8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Animator bodyAnimator = this.GetRoot().bodyAnimator;
			Renderer renderer = MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerRenderer(bodyAnimator, MapaSingleton<MapaSingletonDeMainSkins>.instance.body);
			this.m_guias = renderer.GetComponentInChildren<CollecionDeGuiasSlaveChildOf>();
			if (this.m_guias == null)
			{
				throw new ArgumentNullException("m_guias", "m_guias null reference.");
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000C258 File Offset: 0x0000A458
		public void UpdateBonesPoses()
		{
			if (this.updateLabioBonesPoses)
			{
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp_L, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_L);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutSide_L, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_L);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown_L, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_L);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutDown_R, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInDown_R);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutSide_R, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInSide_R);
				this.UpdateBonePose(MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioOutUp_R, MapaSingleton<MapaSingletonDeFemaleBones>.instance.LabioInUp_R);
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000C340 File Offset: 0x0000A540
		private void UpdateBonePose(string puntoName, string guiaName)
		{
			Object @object;
			if (!this.m_guias.guiasPorNombreDeSlave.TryGetValue(guiaName, out @object))
			{
				throw new InvalidOperationException();
			}
			Transform transform = (Transform)@object;
			int num;
			if (!this.m_LabiosChain.indexDePuntoNombre.TryGetValue(puntoName, out num))
			{
				throw new InvalidOperationException();
			}
			LabioPoint labioPoint = this.m_LabiosChain.puntos[num];
			if (this.updateLabioBonesPosition)
			{
				Vector3 vector = labioPoint.targetBodyTransform.position - transform.position;
				labioPoint.scalerBone.position += vector;
			}
			if (this.updateLabioBonesRotation)
			{
				Quaternion quaternion = labioPoint.targetBodyTransform.rotation * Quaternion.Inverse(transform.rotation);
				labioPoint.scalerBone.rotation *= quaternion;
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000C411 File Offset: 0x0000A611
		public override void OnUpdateEvent1()
		{
			this.UpdateBonesPoses();
		}

		// Token: 0x0400024A RID: 586
		private LabiosChain m_LabiosChain;

		// Token: 0x0400024B RID: 587
		private CollecionDeGuiasSlaveChildOf m_guias;

		// Token: 0x0400024C RID: 588
		public bool updateLabioBonesPoses = true;

		// Token: 0x0400024D RID: 589
		public bool updateLabioBonesPosition = true;

		// Token: 0x0400024E RID: 590
		public bool updateLabioBonesRotation = true;
	}
}

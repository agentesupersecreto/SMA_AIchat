using System;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000255 RID: 597
	public class HandDamperChangeOnFingerTouch : CustomUpdatedMonobehaviourBase, ISkinOnCollisionStayListiner
	{
		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00046A8C File Offset: 0x00044C8C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_handController = this.GetComponentEnRoot(false);
			if (this.m_handController == null)
			{
				throw new ArgumentNullException("m_handController", "m_handController null reference.");
			}
			PuppetMaster componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("puppet", "puppet null reference.");
			}
			this.m_PuppetMusclePropMods = this.GetComponentEnRoot(false);
			if (this.m_PuppetMusclePropMods == null)
			{
				throw new ArgumentNullException("m_PuppetMusclePropMods", "m_PuppetMusclePropMods null reference.");
			}
			PuppetMusclePropMods.PropModificables propModificables = this.m_PuppetMusclePropMods.Obtener(componentEnRoot.GetMuscle(HumanBodyBones.RightUpperArm));
			PuppetMusclePropMods.PropModificables propModificables2 = this.m_PuppetMusclePropMods.Obtener(componentEnRoot.GetMuscle(HumanBodyBones.RightLowerArm));
			PuppetMusclePropMods.PropModificables propModificables3 = this.m_PuppetMusclePropMods.Obtener(componentEnRoot.GetMuscle(HumanBodyBones.RightHand));
			this.m_damperModHand = propModificables3.modificables.muscleDamper.ObtenerModificadorNotNull(this);
			this.m_damperModForeArm = propModificables2.modificables.muscleDamper.ObtenerModificadorNotNull(this);
			this.m_damperModArm = propModificables.modificables.muscleDamper.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x00046B98 File Offset: 0x00044D98
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat damperModHand = this.m_damperModHand;
			if (damperModHand != null)
			{
				damperModHand.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat damperModForeArm = this.m_damperModForeArm;
			if (damperModForeArm != null)
			{
				damperModForeArm.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat damperModArm = this.m_damperModArm;
			if (damperModArm == null)
			{
				return;
			}
			damperModArm.TryRemoverDeOwner(true);
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00046BE4 File Offset: 0x00044DE4
		public override void OnUpdateEvent1()
		{
			try
			{
				this.isUsingFinger = this.m_handController.tipoDePose == HandTipoDePose.finger;
				bool flag = this.isUsingFinger && this.isTouching;
				float num = (flag ? this.config.armsDamperModAtTouching : 1f);
				float num2 = (flag ? this.config.handsDamperModAtTouching : 1f);
				float num3 = (flag ? this.config.armsInVelocity : this.config.armsOutVelocity);
				float num4 = (flag ? this.config.handsInVelocity : this.config.handsOutVelocity);
				this.m_damperModArm.valor.valor = Mathf.MoveTowards(this.m_damperModArm.valor.valor, num, Time.deltaTime * num3);
				this.m_damperModForeArm.valor.valor = Mathf.MoveTowards(this.m_damperModForeArm.valor.valor, num, Time.deltaTime * num3);
				this.m_damperModHand.valor.valor = Mathf.MoveTowards(this.m_damperModHand.valor.valor, num2, Time.deltaTime * num4);
			}
			finally
			{
				this.isTouching = false;
			}
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00046D28 File Offset: 0x00044F28
		void ISkinOnCollisionStayListiner.OnStay(ColisionBasicaV2 collision, Skin sender)
		{
			this.isTouching = true;
		}

		// Token: 0x04000B0D RID: 2829
		public bool isUsingFinger;

		// Token: 0x04000B0E RID: 2830
		public bool isTouching;

		// Token: 0x04000B0F RID: 2831
		public HandDamperChangeOnFingerTouch.Config config = new HandDamperChangeOnFingerTouch.Config();

		// Token: 0x04000B10 RID: 2832
		private PuppetMusclePropMods m_PuppetMusclePropMods;

		// Token: 0x04000B11 RID: 2833
		[SerializeField]
		private ModificadorDeFloat m_damperModHand;

		// Token: 0x04000B12 RID: 2834
		[SerializeField]
		private ModificadorDeFloat m_damperModForeArm;

		// Token: 0x04000B13 RID: 2835
		[SerializeField]
		private ModificadorDeFloat m_damperModArm;

		// Token: 0x04000B14 RID: 2836
		private HandControllerV2 m_handController;

		// Token: 0x02000256 RID: 598
		[Serializable]
		public class Config
		{
			// Token: 0x04000B15 RID: 2837
			public float armsDamperModAtTouching = 5f;

			// Token: 0x04000B16 RID: 2838
			public float handsDamperModAtTouching = 10f;

			// Token: 0x04000B17 RID: 2839
			public float armsInVelocity = 5f;

			// Token: 0x04000B18 RID: 2840
			public float armsOutVelocity = 5f;

			// Token: 0x04000B19 RID: 2841
			public float handsInVelocity = 10f;

			// Token: 0x04000B1A RID: 2842
			public float handsOutVelocity = 10f;
		}
	}
}

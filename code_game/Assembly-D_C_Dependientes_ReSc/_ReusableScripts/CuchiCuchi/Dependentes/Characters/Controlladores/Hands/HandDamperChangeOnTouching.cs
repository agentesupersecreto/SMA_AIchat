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
	// Token: 0x0200025A RID: 602
	public class HandDamperChangeOnTouching : CustomUpdatedMonobehaviourBase, ISkinOnCollisionStayListiner
	{
		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0004732C File Offset: 0x0004552C
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

		// Token: 0x06000FDE RID: 4062 RVA: 0x00047438 File Offset: 0x00045638
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

		// Token: 0x06000FDF RID: 4063 RVA: 0x00047484 File Offset: 0x00045684
		public override void OnUpdateEvent1()
		{
			try
			{
				this.isUsingHand = this.m_handController.tipoDePose == HandTipoDePose.massage;
				bool flag = this.isUsingHand && this.isTouching;
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

		// Token: 0x06000FE0 RID: 4064 RVA: 0x000475C8 File Offset: 0x000457C8
		void ISkinOnCollisionStayListiner.OnStay(ColisionBasicaV2 collision, Skin sender)
		{
			this.isTouching = true;
		}

		// Token: 0x04000B32 RID: 2866
		public bool isUsingHand;

		// Token: 0x04000B33 RID: 2867
		public bool isTouching;

		// Token: 0x04000B34 RID: 2868
		public HandDamperChangeOnTouching.Config config = new HandDamperChangeOnTouching.Config();

		// Token: 0x04000B35 RID: 2869
		private PuppetMusclePropMods m_PuppetMusclePropMods;

		// Token: 0x04000B36 RID: 2870
		[SerializeField]
		private ModificadorDeFloat m_damperModHand;

		// Token: 0x04000B37 RID: 2871
		[SerializeField]
		private ModificadorDeFloat m_damperModForeArm;

		// Token: 0x04000B38 RID: 2872
		[SerializeField]
		private ModificadorDeFloat m_damperModArm;

		// Token: 0x04000B39 RID: 2873
		private HandControllerV2 m_handController;

		// Token: 0x0200025B RID: 603
		[Serializable]
		public class Config
		{
			// Token: 0x04000B3A RID: 2874
			public float armsDamperModAtTouching = 2f;

			// Token: 0x04000B3B RID: 2875
			public float handsDamperModAtTouching = 5f;

			// Token: 0x04000B3C RID: 2876
			public float armsInVelocity = 2f;

			// Token: 0x04000B3D RID: 2877
			public float armsOutVelocity = 2f;

			// Token: 0x04000B3E RID: 2878
			public float handsInVelocity = 5f;

			// Token: 0x04000B3F RID: 2879
			public float handsOutVelocity = 5f;
		}
	}
}

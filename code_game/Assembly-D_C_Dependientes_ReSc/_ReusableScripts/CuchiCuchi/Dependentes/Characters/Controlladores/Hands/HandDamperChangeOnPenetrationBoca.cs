using System;
using System.Collections;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000257 RID: 599
	public class HandDamperChangeOnPenetrationBoca : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x00033596 File Offset: 0x00031796
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00046D99 File Offset: 0x00044F99
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_FingerPhyscisController = this.GetComponentEnRoot(false);
			while (this.m_FingerPhyscisController == null)
			{
				yield return null;
				this.m_FingerPhyscisController = this.GetComponentEnRoot(false);
			}
			if (this.m_FingerPhyscisController == null)
			{
				throw new ArgumentNullException("m_FingerPhyscisController", "m_FingerPhyscisController null reference.");
			}
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
			this.m_damperMinHand = propModificables3.valoresMinimos.muscleDamper.ObtenerModificadorNotNull(this);
			this.m_damperMinForeArm = propModificables2.valoresMinimos.muscleDamper.ObtenerModificadorNotNull(this);
			this.m_damperMinArm = propModificables.valoresMinimos.muscleDamper.ObtenerModificadorNotNull(this);
			this.m_pinMinHand = propModificables3.valoresMinimos.pinWeight.ObtenerModificadorNotNull(this);
			this.m_pinMinForeArm = propModificables2.valoresMinimos.pinWeight.ObtenerModificadorNotNull(this);
			this.m_pinMinArm = propModificables.valoresMinimos.pinWeight.ObtenerModificadorNotNull(this);
			while (!this.m_FingerPhyscisController.finger.isStared)
			{
				yield return null;
			}
			this.m_FingerPhyscisController.finger.stayed += this.Finger_stayed;
			yield break;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x00046DA8 File Offset: 0x00044FA8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat damperMinHand = this.m_damperMinHand;
			if (damperMinHand != null)
			{
				damperMinHand.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat damperMinForeArm = this.m_damperMinForeArm;
			if (damperMinForeArm != null)
			{
				damperMinForeArm.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat damperMinArm = this.m_damperMinArm;
			if (damperMinArm != null)
			{
				damperMinArm.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat pinMinHand = this.m_pinMinHand;
			if (pinMinHand != null)
			{
				pinMinHand.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat pinMinForeArm = this.m_pinMinForeArm;
			if (pinMinForeArm != null)
			{
				pinMinForeArm.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat pinMinArm = this.m_pinMinArm;
			if (pinMinArm != null)
			{
				pinMinArm.TryRemoverDeOwner(true);
			}
			FingerPhyscisController fingerPhyscisController = this.m_FingerPhyscisController;
			if (((fingerPhyscisController != null) ? fingerPhyscisController.finger : null) != null)
			{
				this.m_FingerPhyscisController.finger.stayed -= this.Finger_stayed;
			}
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00046E64 File Offset: 0x00045064
		public override void OnUpdateEvent1()
		{
			try
			{
				this.isUsingFinger = this.m_handController.tipoDePose == HandTipoDePose.finger;
				bool flag = this.isUsingFinger && this.isPenetrating;
				float num = (flag ? this.config.armsDamperModAtPenetrating : 0f);
				float num2 = (flag ? this.config.handsDamperModAtPenetrating : 0f);
				float num3 = (flag ? this.config.armsMinPinAtPenetrating : 0f);
				float num4 = (flag ? this.config.handsMinPinAtPenetrating : 0f);
				float num5 = (flag ? this.config.armsInVelocity : this.config.armsOutVelocity);
				float num6 = (flag ? this.config.handsInVelocity : this.config.handsOutVelocity);
				this.m_damperMinArm.valor.valor = Mathf.MoveTowards(this.m_damperMinArm.valor.valor, num, Time.deltaTime * num5);
				this.m_damperMinForeArm.valor.valor = Mathf.MoveTowards(this.m_damperMinForeArm.valor.valor, num, Time.deltaTime * num5);
				this.m_damperMinHand.valor.valor = Mathf.MoveTowards(this.m_damperMinHand.valor.valor, num2, Time.deltaTime * num6);
				this.m_pinMinArm.valor.valor = Mathf.MoveTowards(this.m_pinMinArm.valor.valor, num3, Time.deltaTime * num5);
				this.m_pinMinForeArm.valor.valor = Mathf.MoveTowards(this.m_pinMinForeArm.valor.valor, num3, Time.deltaTime * num5);
				this.m_pinMinHand.valor.valor = Mathf.MoveTowards(this.m_pinMinHand.valor.valor, num4, Time.deltaTime * num6);
			}
			finally
			{
				this.isPenetrating = false;
			}
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00047064 File Offset: 0x00045264
		private void Finger_stayed(IPeneConPartes pene, BoneStretchedChain hole)
		{
			if (hole is IBocaHole)
			{
				this.isPenetrating = true;
			}
		}

		// Token: 0x04000B1B RID: 2843
		public bool isUsingFinger;

		// Token: 0x04000B1C RID: 2844
		public bool isPenetrating;

		// Token: 0x04000B1D RID: 2845
		public HandDamperChangeOnPenetrationBoca.Config config = new HandDamperChangeOnPenetrationBoca.Config();

		// Token: 0x04000B1E RID: 2846
		private PuppetMusclePropMods m_PuppetMusclePropMods;

		// Token: 0x04000B1F RID: 2847
		[SerializeField]
		private ModificadorDeFloat m_damperMinHand;

		// Token: 0x04000B20 RID: 2848
		[SerializeField]
		private ModificadorDeFloat m_damperMinForeArm;

		// Token: 0x04000B21 RID: 2849
		[SerializeField]
		private ModificadorDeFloat m_damperMinArm;

		// Token: 0x04000B22 RID: 2850
		[SerializeField]
		private ModificadorDeFloat m_pinMinHand;

		// Token: 0x04000B23 RID: 2851
		[SerializeField]
		private ModificadorDeFloat m_pinMinForeArm;

		// Token: 0x04000B24 RID: 2852
		[SerializeField]
		private ModificadorDeFloat m_pinMinArm;

		// Token: 0x04000B25 RID: 2853
		private HandControllerV2 m_handController;

		// Token: 0x04000B26 RID: 2854
		private FingerPhyscisController m_FingerPhyscisController;

		// Token: 0x02000258 RID: 600
		[Serializable]
		public class Config
		{
			// Token: 0x04000B27 RID: 2855
			public float armsDamperModAtPenetrating = 3f;

			// Token: 0x04000B28 RID: 2856
			public float handsDamperModAtPenetrating = 3f;

			// Token: 0x04000B29 RID: 2857
			public float handsMinPinAtPenetrating = 1f;

			// Token: 0x04000B2A RID: 2858
			public float armsMinPinAtPenetrating = 1f;

			// Token: 0x04000B2B RID: 2859
			public float armsInVelocity = 2f;

			// Token: 0x04000B2C RID: 2860
			public float armsOutVelocity = 2f;

			// Token: 0x04000B2D RID: 2861
			public float handsInVelocity = 5f;

			// Token: 0x04000B2E RID: 2862
			public float handsOutVelocity = 5f;
		}
	}
}

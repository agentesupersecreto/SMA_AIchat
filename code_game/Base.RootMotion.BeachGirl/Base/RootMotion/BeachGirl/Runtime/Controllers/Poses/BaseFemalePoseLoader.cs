using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Poses
{
	// Token: 0x02000033 RID: 51
	public abstract class BaseFemalePoseLoader : FemaleAnimController
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000C72A File Offset: 0x0000A92A
		public BaseFemalePoseLoader.Pose current
		{
			get
			{
				if (this.m_current == null || this.m_current.isEmpty)
				{
					return null;
				}
				return this.m_current;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600022B RID: 555 RVA: 0x0000C749 File Offset: 0x0000A949
		public override ICharacter character
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000C754 File Offset: 0x0000A954
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_FemaleChar = base.GetComponent<IFemaleChar>();
			this.m_PuppetMaster = base.GetComponentInChildren<PuppetMaster>();
			this.m_AtadurasDePuppet = this.GetComponentEnRoot(false);
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			if (this.m_AtadurasDePuppet == null)
			{
				throw new ArgumentNullException("m_AtadurasDePuppet", "m_AtadurasDePuppet null reference.");
			}
			base.SetManualStart();
			this.m_FemaleChar.stared += this.M_FemaleChar_stared;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C7DF File Offset: 0x0000A9DF
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000C7E8 File Offset: 0x0000A9E8
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		private void M_FemaleChar_stared(object obj)
		{
			base.ManualStart();
			this.OnFemaleCharStared();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000C7FE File Offset: 0x0000A9FE
		protected virtual void OnFemaleCharStared()
		{
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000C800 File Offset: 0x0000AA00
		public override void LiberarAtaduras()
		{
			if (this.m_current != null)
			{
				this.m_current.LiberarAtaduras(this.m_AtadurasDePuppet);
			}
		}

		// Token: 0x0400019C RID: 412
		protected IFemaleChar m_FemaleChar;

		// Token: 0x0400019D RID: 413
		protected PuppetMaster m_PuppetMaster;

		// Token: 0x0400019E RID: 414
		protected IAtadurasDePuppetAI m_AtadurasDePuppet;

		// Token: 0x0400019F RID: 415
		[NonSerialized]
		protected BaseFemalePoseLoader.Pose m_current;

		// Token: 0x02000129 RID: 297
		[Serializable]
		public class AtadurasJoints : IDisposable
		{
			// Token: 0x17000221 RID: 545
			// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x000300B8 File Offset: 0x0002E2B8
			public static Rigidbody dummy
			{
				get
				{
					if (BaseFemalePoseLoader.AtadurasJoints.m_dummy == null)
					{
						BaseFemalePoseLoader.AtadurasJoints.m_dummy = new GameObject("dummy_AtadurasDePose")
						{
							transform = 
							{
								position = Vector3.forward * 1000f
							}
						}.AddComponent<Rigidbody>();
						BaseFemalePoseLoader.AtadurasJoints.m_dummy.isKinematic = true;
					}
					return BaseFemalePoseLoader.AtadurasJoints.m_dummy;
				}
			}

			// Token: 0x06000AD3 RID: 2771 RVA: 0x00030110 File Offset: 0x0002E310
			private void LoadInvoke(PuppetMaster puppet, Animator animator, ConfiguracionDePoscionSexual.Ataduras ataduras)
			{
				this.isInvoking = true;
				GlobalUpdater.instancia.Invokar(delegate
				{
					if (this.invokeAborted)
					{
						return;
					}
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.hips, ataduras.hips);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.manoR, ataduras.manoR);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.manoL, ataduras.manoL);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.canillaR, ataduras.canillaR);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.canillaL, ataduras.canillaL);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.pieR, ataduras.pieR);
					BaseFemalePoseLoader.AtadurasJoints.SetConfig(this.pieL, ataduras.pieL);
					this.isInvoking = false;
				}, ataduras.delay);
			}

			// Token: 0x06000AD4 RID: 2772 RVA: 0x0003015C File Offset: 0x0002E35C
			public void Load(PuppetMaster puppet, Animator animator, ConfiguracionDePoscionSexual.Ataduras ataduras)
			{
				this.invokeAborted = false;
				if (ataduras.hips != TipoDeAtadura.None)
				{
					this.Load(ref this.hips, puppet, animator, HumanBodyBones.Hips, ataduras.hips);
				}
				if (ataduras.manoR != TipoDeAtadura.None)
				{
					this.Load(ref this.manoR, puppet, animator, HumanBodyBones.RightHand, ataduras.manoR);
				}
				if (ataduras.manoL != TipoDeAtadura.None)
				{
					this.Load(ref this.manoL, puppet, animator, HumanBodyBones.LeftHand, ataduras.manoL);
				}
				if (ataduras.canillaR != TipoDeAtadura.None)
				{
					this.Load(ref this.canillaR, puppet, animator, HumanBodyBones.RightLowerLeg, ataduras.canillaR);
				}
				if (ataduras.canillaL != TipoDeAtadura.None)
				{
					this.Load(ref this.canillaL, puppet, animator, HumanBodyBones.LeftLowerLeg, ataduras.canillaL);
				}
				if (ataduras.pieR != TipoDeAtadura.None)
				{
					this.Load(ref this.pieR, puppet, animator, HumanBodyBones.RightFoot, ataduras.pieR);
				}
				if (ataduras.pieL != TipoDeAtadura.None)
				{
					this.Load(ref this.pieL, puppet, animator, HumanBodyBones.LeftFoot, ataduras.pieL);
				}
				this.LoadInvoke(puppet, animator, ataduras);
			}

			// Token: 0x06000AD5 RID: 2773 RVA: 0x00030248 File Offset: 0x0002E448
			public void Load(ref ConfigurableJoint joint, PuppetMaster puppet, Animator animator, HumanBodyBones boneEnum, TipoDeAtadura tipo)
			{
				if (joint != null)
				{
					throw new InvalidOperationException();
				}
				Muscle muscle = puppet.GetMuscle(animator, boneEnum);
				joint = BaseFemalePoseLoader.AtadurasJoints.CrearJoint(muscle.rigidbody, tipo);
			}

			// Token: 0x06000AD6 RID: 2774 RVA: 0x00030280 File Offset: 0x0002E480
			private static void SetConfig(ConfigurableJoint joint, TipoDeAtadura tipo)
			{
				if (joint == null)
				{
					return;
				}
				switch (tipo)
				{
				case TipoDeAtadura._fixed:
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					goto IL_008E;
				case TipoDeAtadura.fixedPosition:
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					goto IL_008E;
				case TipoDeAtadura.fixedForward:
					joint.zMotion = ConfigurableJointMotion.Locked;
					goto IL_008E;
				case TipoDeAtadura.fixedUpwards:
					joint.yMotion = ConfigurableJointMotion.Locked;
					goto IL_008E;
				}
				throw new ArgumentOutOfRangeException(tipo.ToString());
				IL_008E:
				joint.connectedBody = null;
			}

			// Token: 0x06000AD7 RID: 2775 RVA: 0x00030324 File Offset: 0x0002E524
			private static ConfigurableJoint CrearJoint(Rigidbody owner, TipoDeAtadura tipo)
			{
				if (tipo == TipoDeAtadura.None)
				{
					throw new InvalidOperationException();
				}
				ConfigurableJoint configurableJoint = owner.gameObject.AddComponent<ConfigurableJoint>();
				configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
				configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
				configurableJoint.xMotion = ConfigurableJointMotion.Free;
				configurableJoint.yMotion = ConfigurableJointMotion.Free;
				configurableJoint.zMotion = ConfigurableJointMotion.Free;
				configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
				configurableJoint.connectedBody = BaseFemalePoseLoader.AtadurasJoints.dummy;
				return configurableJoint;
			}

			// Token: 0x06000AD8 RID: 2776 RVA: 0x00030384 File Offset: 0x0002E584
			public void Clear()
			{
				this.invokeAborted = true;
				this.Clear(ref this.hips);
				this.Clear(ref this.manoR);
				this.Clear(ref this.manoL);
				this.Clear(ref this.canillaR);
				this.Clear(ref this.canillaL);
				this.Clear(ref this.pieR);
				this.Clear(ref this.pieL);
			}

			// Token: 0x06000AD9 RID: 2777 RVA: 0x000303EC File Offset: 0x0002E5EC
			private void Clear(ref ConfigurableJoint joint)
			{
				if (joint)
				{
					Object.Destroy(joint);
				}
				joint = null;
			}

			// Token: 0x06000ADA RID: 2778 RVA: 0x00030401 File Offset: 0x0002E601
			public void Dispose()
			{
				if (BaseFemalePoseLoader.AtadurasJoints.m_dummy)
				{
					Object.Destroy(BaseFemalePoseLoader.AtadurasJoints.m_dummy.gameObject);
				}
			}

			// Token: 0x040006E5 RID: 1765
			private static Rigidbody m_dummy;

			// Token: 0x040006E6 RID: 1766
			public ConfigurableJoint hips;

			// Token: 0x040006E7 RID: 1767
			public ConfigurableJoint manoR;

			// Token: 0x040006E8 RID: 1768
			public ConfigurableJoint manoL;

			// Token: 0x040006E9 RID: 1769
			public ConfigurableJoint canillaR;

			// Token: 0x040006EA RID: 1770
			public ConfigurableJoint canillaL;

			// Token: 0x040006EB RID: 1771
			public ConfigurableJoint pieR;

			// Token: 0x040006EC RID: 1772
			public ConfigurableJoint pieL;

			// Token: 0x040006ED RID: 1773
			private bool isInvoking;

			// Token: 0x040006EE RID: 1774
			private bool invokeAborted;
		}

		// Token: 0x0200012A RID: 298
		[Serializable]
		public class AtadurasConControllador
		{
			// Token: 0x17000222 RID: 546
			// (get) Token: 0x06000ADC RID: 2780 RVA: 0x00030426 File Offset: 0x0002E626
			public bool isInvokingToAnim
			{
				get
				{
					return this.m_isInvokingToAnim;
				}
			}

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000ADD RID: 2781 RVA: 0x0003042E File Offset: 0x0002E62E
			public bool isInvokingToPuppet
			{
				get
				{
					return this.m_isInvokingToPuppet;
				}
			}

			// Token: 0x06000ADE RID: 2782 RVA: 0x00030436 File Offset: 0x0002E636
			public void Load(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAAnimacionV2 ataduras)
			{
				this.invokeToAnimAborted = false;
				this.LoadInvoke(controllador, ataduras);
			}

			// Token: 0x06000ADF RID: 2783 RVA: 0x00030448 File Offset: 0x0002E648
			private void LoadInvoke(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAAnimacionV2 ataduras)
			{
				this.m_isInvokingToAnim = true;
				GlobalUpdater.instancia.Invokar(delegate
				{
					if (this.invokeToAnimAborted)
					{
						return;
					}
					if (ataduras.hipsR.activar)
					{
						this.Load(controllador, ataduras.hipsR, TipoDeAtaduraDePuppet.caderaR);
					}
					if (ataduras.hipsL.activar)
					{
						this.Load(controllador, ataduras.hipsL, TipoDeAtaduraDePuppet.caderaL);
					}
					if (ataduras.manoR.activar)
					{
						this.Load(controllador, ataduras.manoR, TipoDeAtaduraDePuppet.manoR);
					}
					if (ataduras.manoL.activar)
					{
						this.Load(controllador, ataduras.manoL, TipoDeAtaduraDePuppet.manoL);
					}
					if (ataduras.pieR.activar)
					{
						this.Load(controllador, ataduras.pieR, TipoDeAtaduraDePuppet.pieR);
					}
					if (ataduras.pieL.activar)
					{
						this.Load(controllador, ataduras.pieL, TipoDeAtaduraDePuppet.pieL);
					}
					if (ataduras.rodillaR.activar)
					{
						this.Load(controllador, ataduras.rodillaR, TipoDeAtaduraDePuppet.rodillaR);
					}
					if (ataduras.rodillaL.activar)
					{
						this.Load(controllador, ataduras.rodillaL, TipoDeAtaduraDePuppet.rodillaL);
					}
					if (ataduras.hipsR.ignorar)
					{
						this.Ignorar(controllador, ataduras.hipsR, TipoDeAtaduraDePuppet.caderaR);
					}
					if (ataduras.hipsL.ignorar)
					{
						this.Ignorar(controllador, ataduras.hipsL, TipoDeAtaduraDePuppet.caderaL);
					}
					if (ataduras.manoR.ignorar)
					{
						this.Ignorar(controllador, ataduras.manoR, TipoDeAtaduraDePuppet.manoR);
					}
					if (ataduras.manoL.ignorar)
					{
						this.Ignorar(controllador, ataduras.manoL, TipoDeAtaduraDePuppet.manoL);
					}
					if (ataduras.pieR.ignorar)
					{
						this.Ignorar(controllador, ataduras.pieR, TipoDeAtaduraDePuppet.pieR);
					}
					if (ataduras.pieL.ignorar)
					{
						this.Ignorar(controllador, ataduras.pieL, TipoDeAtaduraDePuppet.pieL);
					}
					if (ataduras.rodillaR.ignorar)
					{
						this.Ignorar(controllador, ataduras.rodillaR, TipoDeAtaduraDePuppet.rodillaR);
					}
					if (ataduras.rodillaL.ignorar)
					{
						this.Ignorar(controllador, ataduras.rodillaL, TipoDeAtaduraDePuppet.rodillaL);
					}
					this.m_isInvokingToAnim = false;
				}, ataduras.delay);
			}

			// Token: 0x06000AE0 RID: 2784 RVA: 0x00030499 File Offset: 0x0002E699
			public void Load(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion ConfigAta, TipoDeAtaduraDePuppet tipo)
			{
				this.m_atandoAnim.Add(tipo);
				controllador.Forzar(tipo, ConfigAta.weight);
			}

			// Token: 0x06000AE1 RID: 2785 RVA: 0x000304B4 File Offset: 0x0002E6B4
			public void Ignorar(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAAnimacionV2.AtaduraAAnimacion ConfigAta, TipoDeAtaduraDePuppet tipo)
			{
				this.m_ignorandoAnim.Add(tipo);
				controllador.Ignorar(tipo);
			}

			// Token: 0x06000AE2 RID: 2786 RVA: 0x000304CC File Offset: 0x0002E6CC
			public void ClearToAnim(IAtadurasDePuppetAI controllador)
			{
				this.invokeToAnimAborted = true;
				for (int i = 0; i < this.m_atandoAnim.Count; i++)
				{
					controllador.DejarDeForzar(this.m_atandoAnim[i]);
				}
				for (int j = 0; j < this.m_ignorandoAnim.Count; j++)
				{
					controllador.DejarDeIgnorar(this.m_ignorandoAnim[j]);
				}
			}

			// Token: 0x06000AE3 RID: 2787 RVA: 0x00030530 File Offset: 0x0002E730
			[Obsolete("hace conflicto con interacciones segundarias", true)]
			public void Load(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAMuscles ataduras)
			{
				this.invokeToPuppetAborted = false;
				this.LoadInvoke(controllador, ataduras);
			}

			// Token: 0x06000AE4 RID: 2788 RVA: 0x00030544 File Offset: 0x0002E744
			[Obsolete("hace conflicto con interacciones segundarias", true)]
			private void LoadInvoke(IAtadurasDePuppetAI controllador, ConfiguracionDePoscionSexual.AtadurasAMuscles ataduras)
			{
				this.m_isInvokingToPuppet = true;
				GlobalUpdater.instancia.Invokar(delegate
				{
					if (this.invokeToPuppetAborted)
					{
						return;
					}
					if (ataduras.manoL.activar)
					{
						this.Load(controllador, TipoDeMuscleAlQueSePuedeAtar.HandL, ataduras.manoL.target);
					}
					if (ataduras.manoR.activar)
					{
						this.Load(controllador, TipoDeMuscleAlQueSePuedeAtar.HandR, ataduras.manoR.target);
					}
					this.m_isInvokingToPuppet = false;
				}, ataduras.delay);
			}

			// Token: 0x06000AE5 RID: 2789 RVA: 0x00030595 File Offset: 0x0002E795
			[Obsolete("hace conflicto con interacciones segundarias", true)]
			public void Load(IAtadurasDePuppetAI controllador, TipoDeMuscleAlQueSePuedeAtar from, TipoDeMuscleAlQueSePuedeAtar to)
			{
				this.m_atandoPuppet.Add(from);
				controllador.Forzar(from, to);
			}

			// Token: 0x06000AE6 RID: 2790 RVA: 0x000305AC File Offset: 0x0002E7AC
			[Obsolete("hace conflicto con interacciones segundarias", true)]
			public void ClearToPuppet(IAtadurasDePuppetAI controllador)
			{
				this.invokeToPuppetAborted = true;
				for (int i = 0; i < this.m_atandoPuppet.Count; i++)
				{
					controllador.DejarDeForzar(this.m_atandoPuppet[i]);
				}
			}

			// Token: 0x040006EF RID: 1775
			[SerializeField]
			[ReadOnlyUI]
			private List<TipoDeAtaduraDePuppet> m_atandoAnim = new List<TipoDeAtaduraDePuppet>();

			// Token: 0x040006F0 RID: 1776
			[SerializeField]
			[ReadOnlyUI]
			private List<TipoDeAtaduraDePuppet> m_ignorandoAnim = new List<TipoDeAtaduraDePuppet>();

			// Token: 0x040006F1 RID: 1777
			[SerializeField]
			[ReadOnlyUI]
			private List<TipoDeMuscleAlQueSePuedeAtar> m_atandoPuppet = new List<TipoDeMuscleAlQueSePuedeAtar>();

			// Token: 0x040006F2 RID: 1778
			private bool m_isInvokingToAnim;

			// Token: 0x040006F3 RID: 1779
			private bool invokeToAnimAborted;

			// Token: 0x040006F4 RID: 1780
			private bool m_isInvokingToPuppet;

			// Token: 0x040006F5 RID: 1781
			private bool invokeToPuppetAborted;
		}

		// Token: 0x0200012B RID: 299
		public class Pose
		{
			// Token: 0x06000AE8 RID: 2792 RVA: 0x00030614 File Offset: 0x0002E814
			public Pose(BaseFemalePoseLoader owner, PuppetMaster puppet, IAtadurasDePuppetAI AtadurasDePuppet, Animator animator, TipoDePose pose, bool puppetModoPorAnimatorState)
			{
				if (puppet == null)
				{
					throw new ArgumentNullException("puppet", "puppet null reference.");
				}
				if (owner == null)
				{
					throw new ArgumentNullException("owner", "owner null reference.");
				}
				if (AtadurasDePuppet == null)
				{
					throw new ArgumentNullException("controlladorDeAtaduras", "controlladorDeAtaduras null reference.");
				}
				ConfiguracionDePoscionSexual config = Singleton<FemalePosesConfigs>.instance.GetConfig(pose);
				if (config == null)
				{
					throw new ArgumentNullException("config", "config null reference.");
				}
				this.m_owner = owner;
				config.AplicarOnFemale(puppet, owner, puppetModoPorAnimatorState);
				this.SetConfig(config);
				this.m_ataduras.Load(puppet, animator, config.ataduras);
				this.m_atadurasDeControllador.Load(AtadurasDePuppet, config.atadurasAAnimacionV2);
			}

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x000306E6 File Offset: 0x0002E8E6
			public bool isEmpty
			{
				get
				{
					return this.config == null;
				}
			}

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x06000AEA RID: 2794 RVA: 0x000306F4 File Offset: 0x0002E8F4
			public TipoDePose pose
			{
				get
				{
					if (this.isEmpty)
					{
						return TipoDePose.dePieRigida;
					}
					return this.config.pose;
				}
			}

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0003070B File Offset: 0x0002E90B
			public ConfiguracionDePoscionSexual config
			{
				get
				{
					return this.m_config;
				}
			}

			// Token: 0x06000AEC RID: 2796 RVA: 0x00030713 File Offset: 0x0002E913
			public void OnPose(IAtadurasDePuppetAI atadurasDePuppet)
			{
			}

			// Token: 0x06000AED RID: 2797 RVA: 0x00030715 File Offset: 0x0002E915
			protected void SetConfig(ConfiguracionDePoscionSexual c)
			{
				this.m_config = c;
			}

			// Token: 0x06000AEE RID: 2798 RVA: 0x0003071E File Offset: 0x0002E91E
			public void ClearPose(IAtadurasDePuppetAI AtadurasDePuppet)
			{
				this.LiberarAtaduras(AtadurasDePuppet);
			}

			// Token: 0x06000AEF RID: 2799 RVA: 0x00030727 File Offset: 0x0002E927
			public void LiberarAtaduras(IAtadurasDePuppetAI AtadurasDePuppet)
			{
				this.m_ataduras.Clear();
				this.m_atadurasDeControllador.ClearToAnim(AtadurasDePuppet);
			}

			// Token: 0x040006F6 RID: 1782
			[SerializeField]
			[ReadOnlyUI]
			private BaseFemalePoseLoader m_owner;

			// Token: 0x040006F7 RID: 1783
			[SerializeField]
			[ReadOnlyUI]
			private ConfiguracionDePoscionSexual m_config;

			// Token: 0x040006F8 RID: 1784
			[SerializeField]
			[ReadOnlyUI]
			private BaseFemalePoseLoader.AtadurasJoints m_ataduras = new BaseFemalePoseLoader.AtadurasJoints();

			// Token: 0x040006F9 RID: 1785
			[SerializeField]
			[ReadOnlyUI]
			private BaseFemalePoseLoader.AtadurasConControllador m_atadurasDeControllador = new BaseFemalePoseLoader.AtadurasConControllador();
		}

		// Token: 0x0200012C RID: 300
		[Obsolete("", true)]
		public class Position
		{
		}
	}
}

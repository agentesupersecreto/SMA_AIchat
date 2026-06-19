using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Poses;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Poses.HandPoses;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000AC RID: 172
	public sealed class InteractionSystemV3 : InteractionSystem
	{
		// Token: 0x1400005E RID: 94
		// (add) Token: 0x0600068D RID: 1677 RVA: 0x0001FFA4 File Offset: 0x0001E1A4
		// (remove) Token: 0x0600068E RID: 1678 RVA: 0x0001FFDC File Offset: 0x0001E1DC
		public event Action<InteractionSystemV3> effectorsUpdated;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x0600068F RID: 1679 RVA: 0x00020014 File Offset: 0x0001E214
		// (remove) Token: 0x06000690 RID: 1680 RVA: 0x0002004C File Offset: 0x0001E24C
		public event Action<InteractionSystemV3> interacted;

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x00020081 File Offset: 0x0001E281
		public int IK_layer
		{
			get
			{
				return this.m_IK_layer;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00020089 File Offset: 0x0001E289
		public bool doCheckInteractionObjects
		{
			get
			{
				return this.m_doCheckInteractionObjects;
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00020094 File Offset: 0x0001E294
		public PoserDeInterSys GetPoserDeBone(Transform bone)
		{
			PoserDeInterSys poserDeInterSys;
			if (!this.m_poserDeBone.TryGetValue(bone, out poserDeInterSys))
			{
				return null;
			}
			return poserDeInterSys;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000200B4 File Offset: 0x0001E2B4
		private void Awake()
		{
			if (this.fullBody == null)
			{
				this.fullBody = base.GetComponent<FullBodyBipedIK>();
			}
			this.interactionEffectors = new InteractionEffector[]
			{
				new InteractionEffectorV2(FullBodyBipedEffector.Body),
				new InteractionEffectorV2(FullBodyBipedEffector.LeftFoot),
				new InteractionEffectorV2(FullBodyBipedEffector.LeftHand),
				new InteractionEffectorV2(FullBodyBipedEffector.LeftShoulder),
				new InteractionEffectorV2(FullBodyBipedEffector.LeftThigh),
				new InteractionEffectorV2(FullBodyBipedEffector.RightFoot),
				new InteractionEffectorV2(FullBodyBipedEffector.RightHand),
				new InteractionEffectorV2(FullBodyBipedEffector.RightShoulder),
				new InteractionEffectorV2(FullBodyBipedEffector.RightThigh)
			};
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("@char", "@char null reference.");
			}
			this.m_ikUpdater = componentEnRoot.GetComponentInChildren<IIKUpdater>();
			if (this.m_ikUpdater == null)
			{
				throw new ArgumentNullException("m_ikUpdater", "InteractionSystemV3 requiere un component IIKUpdater q actualize los iks.");
			}
			this.m_Updater = this.GetComponentNotNull<InteractionSystemV2Updater>();
			this.m_Updater.update += this.M_Updater_update;
			this.m_Updater.lateUpdate += this.M_Updater_lateUpdate;
			Animator bodyAnimator = componentEnRoot.bodyAnimator;
			Transform boneTransform = bodyAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
			Transform boneTransform2 = bodyAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			HandPoserDeInterSys handPoserDeInterSys = boneTransform.gameObject.AddComponent<HandPoserDeInterSys>();
			handPoserDeInterSys.system = this;
			handPoserDeInterSys.SetAnimator(bodyAnimator);
			handPoserDeInterSys.InitiateComponent();
			handPoserDeInterSys.UpdateSystem();
			HandPoserDeInterSys handPoserDeInterSys2 = boneTransform2.gameObject.AddComponent<HandPoserDeInterSys>();
			handPoserDeInterSys2.system = this;
			handPoserDeInterSys2.SetAnimator(bodyAnimator);
			handPoserDeInterSys2.InitiateComponent();
			handPoserDeInterSys2.UpdateSystem();
			this.m_poserDeBone.Add(boneTransform, handPoserDeInterSys);
			this.m_poserDeBone.Add(boneTransform2, handPoserDeInterSys2);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00020240 File Offset: 0x0001E440
		protected sealed override void Start()
		{
			base.Start();
			if (base.ik.solver.effectors.Length == 0)
			{
				throw new InvalidOperationException();
			}
			if (base.ik.solver.chain.Length == 0)
			{
				throw new InvalidOperationException();
			}
			this.m_IKID = this.m_ikUpdater.IDDeIK(this.fullBody);
			if (this.m_IKID < 0)
			{
				throw new InvalidOperationException();
			}
			this.m_IK_layer = this.m_ikUpdater.LayerDeIK(this.fullBody);
			if (this.m_IK_layer < 0)
			{
				throw new InvalidOperationException();
			}
			int num = this.m_ikUpdater.InvertLayerDeIK(this.fullBody);
			if (num < 0 || num >= this.m_ikUpdater.cantidadDeIKs)
			{
				throw new InvalidOperationException();
			}
			ICharacter componentInParent = base.GetComponentInParent<ICharacter>();
			ILookAtIK componentInChildren = componentInParent.GetComponentInChildren<ILookAtIK>();
			OjosLookAtManager componentInChildren2 = componentInParent.GetComponentInChildren<OjosLookAtManager>();
			if (componentInChildren != null && componentInChildren2 != null)
			{
				this.lookAt = new InteractionLookAtV2(this.lookAt, componentInChildren, componentInChildren2, num);
				this.m_lookAtV2 = (InteractionLookAtV2)this.lookAt;
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0002033F File Offset: 0x0001E53F
		private void M_Updater_update()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			base.Update();
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00020350 File Offset: 0x0001E550
		private void M_Updater_lateUpdate(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			bool flag = false;
			if ((PassEventData.esUltimo && this.paraPass == InteractionSystemV3.TipoDePass.ultimo) || PassEventData.index + InteractionSystemV3.TipoDePass.primero == this.paraPass)
			{
				base.LateUpdate();
				flag = true;
			}
			else if (this.forASinglePass)
			{
				for (int i = 0; i < this.interactionEffectors.Length; i++)
				{
					((InteractionEffectorV2)this.interactionEffectors[i]).TemporalResetToDefaults();
				}
			}
			if (flag)
			{
				Action<InteractionSystemV3> action = this.effectorsUpdated;
				if (action == null)
				{
					return;
				}
				action(this);
			}
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x000203D8 File Offset: 0x0001E5D8
		public InteractionEffectorV2 GetInteractionEffector(FullBodyBipedEffector effector)
		{
			return (InteractionEffectorV2)this.interactionEffectors.FirstOrDefault((InteractionEffector e) => e.effectorType == effector);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0002040E File Offset: 0x0001E60E
		private void OnEnable()
		{
			this.m_ikUpdater.onSingleIKUpdatedPass1 += this.M_ikUpdater_passed;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00020427 File Offset: 0x0001E627
		private void OnDisable()
		{
			this.m_currentLookAtPriority = float.MinValue;
			this.m_ikUpdater.onSingleIKUpdatedPass1 -= this.M_ikUpdater_passed;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0002044C File Offset: 0x0001E64C
		private void M_ikUpdater_passed(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (this.fullBody == null)
			{
				return;
			}
			if (IKEventData.id != this.m_IKID)
			{
				return;
			}
			bool flag = false;
			if ((PassEventData.esUltimo && this.paraPass == InteractionSystemV3.TipoDePass.ultimo) || PassEventData.index + InteractionSystemV3.TipoDePass.primero == this.paraPass)
			{
				for (int i = 0; i < this.interactionEffectors.Length; i++)
				{
					this.interactionEffectors[i].OnPostFBBIK();
				}
				flag = true;
			}
			if (flag)
			{
				Action<InteractionSystemV3> action = this.interacted;
				if (action == null)
				{
					return;
				}
				action(this);
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x000204DC File Offset: 0x0001E6DC
		public void StopInmediatamente()
		{
			if (this.fullBody == null)
			{
				return;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				this.interactionEffectors[i].Stop();
			}
			for (int j = 0; j < this.interactionEffectors.Length; j++)
			{
				this.interactionEffectors[j].ResetToDefaults(2.1474836E+09f);
			}
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00020540 File Offset: 0x0001E740
		public void StopInmediatamente(FullBodyBipedEffector effector)
		{
			if (this.fullBody == null)
			{
				return;
			}
			InteractionEffector interactionEffector = this.interactionEffectors.FirstOrDefault((InteractionEffector e) => e.effectorType == effector);
			if (interactionEffector != null)
			{
				interactionEffector.Stop();
			}
			if (interactionEffector == null)
			{
				return;
			}
			interactionEffector.ResetToDefaults(2.1474836E+09f);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x000205A0 File Offset: 0x0001E7A0
		protected sealed override void OnInteractionPause_LookAt(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			if (interactionObject.lookAtTarget == null)
			{
				return;
			}
			InteractionObjectV2Base interactionObjectV2Base = interactionObject as InteractionObjectV2Base;
			if (interactionObjectV2Base && !this.SameLookAtUser(interactionObjectV2Base))
			{
				return;
			}
			base.OnInteractionPause_LookAt(effector, interactionObject);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000205E0 File Offset: 0x0001E7E0
		protected sealed override void OnInteractionResume_LookAt(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			if (interactionObject.lookAtTarget == null)
			{
				return;
			}
			InteractionObjectV2Base interactionObjectV2Base = interactionObject as InteractionObjectV2Base;
			if (interactionObjectV2Base && !this.SameLookAtUser(interactionObjectV2Base))
			{
				return;
			}
			base.OnInteractionResume_LookAt(effector, interactionObject);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00020620 File Offset: 0x0001E820
		protected sealed override void OnInteractionStop_LookAt(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			if (interactionObject.lookAtTarget == null)
			{
				return;
			}
			InteractionObjectV2Base interactionObjectV2Base = interactionObject as InteractionObjectV2Base;
			if (interactionObjectV2Base && !this.SameLookAtUser(interactionObjectV2Base))
			{
				return;
			}
			base.OnInteractionStop_LookAt(effector, interactionObject);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00020660 File Offset: 0x0001E860
		protected sealed override void OnLookAtInteraction_LookAt(FullBodyBipedEffector effector, InteractionObject interactionObject)
		{
			if (interactionObject.otherLookAtTarget == null)
			{
				return;
			}
			InteractionObjectV2Base interactionObjectV2Base = interactionObject as InteractionObjectV2Base;
			if (interactionObjectV2Base)
			{
				if (!this.PrioridadMayorOIgualQueCurrent(interactionObjectV2Base))
				{
					return;
				}
				this.lookAt.lerpSpeed = interactionObjectV2Base.lookAtVelocityMod;
			}
			base.OnLookAtInteraction_LookAt(effector, interactionObject);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000206AE File Offset: 0x0001E8AE
		private bool SameLookAtUser(InteractionObjectV2Base interactionObject)
		{
			return !(interactionObject.otherLookAtTarget == null) && interactionObject.otherLookAtTarget == this.m_lookAtV2.ObtenerElLookAtTargetActual();
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x000206D8 File Offset: 0x0001E8D8
		private bool PrioridadMayorOIgualQueCurrent(InteractionObjectV2Base interactionObject)
		{
			if (interactionObject.otherLookAtTarget == null)
			{
				return false;
			}
			if (interactionObject.lookAtPriority >= this.m_currentLookAtPriority || this.m_lookAtV2.ObtenerElLookAtTargetActual() == null)
			{
				this.m_currentLookAtPriority = interactionObject.lookAtPriority;
				return true;
			}
			return false;
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x00020728 File Offset: 0x0001E928
		public bool estaInteractuando
		{
			get
			{
				if (!base.IsValid(true))
				{
					return false;
				}
				for (int i = 0; i < this.interactionEffectors.Length; i++)
				{
					if (this.interactionEffectors[i].inInteraction)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00020768 File Offset: 0x0001E968
		public bool EstaInteractuando(FullBodyBipedEffector effectorType)
		{
			InteractionEffectorV2 interactionEffectorV;
			return this.EstaInteractuandoConV2(effectorType, out interactionEffectorV);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00020780 File Offset: 0x0001E980
		public bool EstaInteractuandoConV2(FullBodyBipedEffector effectorType, out InteractionEffectorV2 effector)
		{
			effector = null;
			if (!base.IsValid(true))
			{
				return false;
			}
			for (int i = 0; i < this.interactionEffectors.Length; i++)
			{
				if (this.interactionEffectors[i].effectorType == effectorType)
				{
					effector = this.interactionEffectors[i] as InteractionEffectorV2;
					return effector.inInteraction && effector != null;
				}
			}
			return false;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x000207DF File Offset: 0x0001E9DF
		protected sealed override void OnPreFBBIK()
		{
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x000207E1 File Offset: 0x0001E9E1
		protected sealed override void OnPostFBBIK()
		{
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000207E3 File Offset: 0x0001E9E3
		protected sealed override void Update()
		{
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000207E5 File Offset: 0x0001E9E5
		protected sealed override void LateUpdate()
		{
		}

		// Token: 0x04000479 RID: 1145
		public InteractionSystemV3.TipoDePass paraPass = InteractionSystemV3.TipoDePass.primero;

		// Token: 0x0400047A RID: 1146
		public bool forASinglePass;

		// Token: 0x0400047B RID: 1147
		[SerializeField]
		private bool m_doCheckInteractionObjects = true;

		// Token: 0x0400047C RID: 1148
		[ReadOnlyUI]
		[SerializeField]
		private int m_IKID = -1;

		// Token: 0x0400047D RID: 1149
		[ReadOnlyUI]
		[SerializeField]
		private int m_IK_layer = -1;

		// Token: 0x0400047E RID: 1150
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentLookAtPriority = float.MinValue;

		// Token: 0x0400047F RID: 1151
		private InteractionSystemV2Updater m_Updater;

		// Token: 0x04000480 RID: 1152
		private IIKUpdater m_ikUpdater;

		// Token: 0x04000481 RID: 1153
		[SerializeField]
		private InteractionLookAtV2 m_lookAtV2;

		// Token: 0x04000482 RID: 1154
		private Dictionary<Transform, PoserDeInterSys> m_poserDeBone = new Dictionary<Transform, PoserDeInterSys>();

		// Token: 0x0200018E RID: 398
		public enum TipoDePass
		{
			// Token: 0x040008DB RID: 2267
			None,
			// Token: 0x040008DC RID: 2268
			primero,
			// Token: 0x040008DD RID: 2269
			segundo,
			// Token: 0x040008DE RID: 2270
			tercero,
			// Token: 0x040008DF RID: 2271
			cuarto,
			// Token: 0x040008E0 RID: 2272
			quinto,
			// Token: 0x040008E1 RID: 2273
			ultimo = 32
		}
	}
}

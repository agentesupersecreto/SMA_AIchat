using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.CustomEffectors
{
	// Token: 0x02000030 RID: 48
	public class ToesEffectorTValle : CustomMonobehaviour, IToesIKEffector, IIKCustomEffector
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000B969 File Offset: 0x00009B69
		public IToeIKEffector derecho
		{
			get
			{
				return this.m_derecho;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0000B971 File Offset: 0x00009B71
		public IToeIKEffector izquierdo
		{
			get
			{
				return this.m_izquierdo;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x0000B979 File Offset: 0x00009B79
		public IReadOnlyList<CustomBipedEffector> effectorsTypes
		{
			get
			{
				return ToesEffectorTValle.m_effectorsTypes;
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000B980 File Offset: 0x00009B80
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.ik = base.GetComponent<FullBodyBipedIK>();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_IKID = this.m_updater.IDDeIK(this.ik);
			if (this.m_IKID < 0)
			{
				throw new InvalidOperationException();
			}
			if (this.ik.solver.initiated)
			{
				this.OnPostInitiate();
				return;
			}
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000BA2F File Offset: 0x00009C2F
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onSingleIKUpdatingPass1 += this.OnIkUpdaterPass;
			this.m_updater.onSingleIKUpdatedPass1 += this.OnIkUpdaterPass;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000BA65 File Offset: 0x00009C65
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updater != null)
			{
				this.m_updater.onSingleIKUpdatingPass1 -= this.OnIkUpdaterPass;
				this.m_updater.onSingleIKUpdatedPass1 -= this.OnIkUpdaterPass;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000BAA4 File Offset: 0x00009CA4
		private void OnPostInitiate()
		{
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
			ICharacterRoot root = this.GetRoot();
			Animator animator = ((root != null) ? root.bodyAnimator : null);
			if (animator == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.m_izquierdo.Init(Side.L, this, animator);
			this.m_derecho.Init(Side.R, this, animator);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000BB25 File Offset: 0x00009D25
		private void OnIkUpdaterPass(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (this.m_IKID != IKEventData.id)
			{
				return;
			}
			if (!PassEventData.esUltimo)
			{
				return;
			}
			this.RotateToes();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000BB46 File Offset: 0x00009D46
		private void RotateToes()
		{
			if (this.ik == null)
			{
				return;
			}
			this.m_derecho.Solve();
			this.m_izquierdo.Solve();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000BB6D File Offset: 0x00009D6D
		public Quaternion GetRotationTargetOf(CustomBipedEffector effector)
		{
			if (effector == CustomBipedEffector.toeIzquierdo)
			{
				return this.m_izquierdo.rotation;
			}
			if (effector != CustomBipedEffector.toeDerecho)
			{
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
			return this.m_derecho.rotation;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000BBAB File Offset: 0x00009DAB
		public float GetRotationWeightOf(CustomBipedEffector effector)
		{
			if (effector == CustomBipedEffector.toeIzquierdo)
			{
				return this.m_izquierdo.rotationWeight;
			}
			if (effector != CustomBipedEffector.toeDerecho)
			{
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
			return this.m_derecho.rotationWeight;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000BBE9 File Offset: 0x00009DE9
		public bool IsEffectorOf(CustomBipedEffector effector)
		{
			return effector == CustomBipedEffector.toeIzquierdo || effector == CustomBipedEffector.toeDerecho;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000BBFE File Offset: 0x00009DFE
		public void SetRotationTargetOf(CustomBipedEffector effector, Quaternion rotation)
		{
			if (effector == CustomBipedEffector.toeIzquierdo)
			{
				this.m_izquierdo.rotation = rotation;
				return;
			}
			if (effector != CustomBipedEffector.toeDerecho)
			{
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
			this.m_derecho.rotation = rotation;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000BC3E File Offset: 0x00009E3E
		public void SetRotationWeightOf(CustomBipedEffector effector, float weight)
		{
			if (effector == CustomBipedEffector.toeIzquierdo)
			{
				this.m_izquierdo.rotationWeight = weight;
				return;
			}
			if (effector != CustomBipedEffector.toeDerecho)
			{
				throw new ArgumentOutOfRangeException(effector.ToString());
			}
			this.m_derecho.rotationWeight = weight;
		}

		// Token: 0x04000178 RID: 376
		private static List<CustomBipedEffector> m_effectorsTypes = new List<CustomBipedEffector>
		{
			CustomBipedEffector.toeDerecho,
			CustomBipedEffector.toeIzquierdo
		};

		// Token: 0x04000179 RID: 377
		private FullBodyBipedIK ik;

		// Token: 0x0400017A RID: 378
		[SerializeField]
		private ToesEffectorTValle.ToeEffecor m_derecho = new ToesEffectorTValle.ToeEffecor();

		// Token: 0x0400017B RID: 379
		[SerializeField]
		private ToesEffectorTValle.ToeEffecor m_izquierdo = new ToesEffectorTValle.ToeEffecor();

		// Token: 0x0400017C RID: 380
		private IIKUpdater m_updater;

		// Token: 0x0400017D RID: 381
		private int m_IKID;

		// Token: 0x02000120 RID: 288
		[Serializable]
		public class ToeEffecor : IToeIKEffector
		{
			// Token: 0x1700021D RID: 541
			// (get) Token: 0x06000AAD RID: 2733 RVA: 0x0002F48B File Offset: 0x0002D68B
			// (set) Token: 0x06000AAE RID: 2734 RVA: 0x0002F493 File Offset: 0x0002D693
			public float rotationWeight
			{
				get
				{
					return this.m_rotationWeight;
				}
				set
				{
					this.m_rotationWeight = value;
				}
			}

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0002F49C File Offset: 0x0002D69C
			// (set) Token: 0x06000AB0 RID: 2736 RVA: 0x0002F4A4 File Offset: 0x0002D6A4
			public Quaternion rotation
			{
				get
				{
					return this.m_rotation;
				}
				set
				{
					this.m_rotation = value;
				}
			}

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0002F4AD File Offset: 0x0002D6AD
			// (set) Token: 0x06000AB2 RID: 2738 RVA: 0x0002F4B5 File Offset: 0x0002D6B5
			public Vector3 offsetRotation
			{
				get
				{
					return this.m_offsetRotation;
				}
				set
				{
					this.m_offsetRotation = value;
				}
			}

			// Token: 0x17000220 RID: 544
			// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0002F4BE File Offset: 0x0002D6BE
			public Quaternion defaultLocalRotation
			{
				get
				{
					return this.m_defaultLocalRotation;
				}
			}

			// Token: 0x06000AB4 RID: 2740 RVA: 0x0002F4C8 File Offset: 0x0002D6C8
			public void Init(Side side, ToesEffectorTValle effector, Animator anim)
			{
				this.m_effector = effector;
				switch (side)
				{
				case Side.L:
					this.m_heelBone = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
					this.m_toesBone = anim.GetBoneTransform(HumanBodyBones.LeftToes);
					goto IL_0070;
				case Side.R:
					this.m_heelBone = anim.GetBoneTransform(HumanBodyBones.RightFoot);
					this.m_toesBone = anim.GetBoneTransform(HumanBodyBones.RightToes);
					goto IL_0070;
				}
				throw new ArgumentOutOfRangeException(side.ToString());
				IL_0070:
				this.m_defaultLocalRotation = Quaternion.Inverse(this.m_heelBone.rotation) * this.m_toesBone.rotation;
				this.m_offSetToForward = Quaternion.Inverse(this.m_toesBone.rotation) * anim.transform.rotation;
			}

			// Token: 0x06000AB5 RID: 2741 RVA: 0x0002F594 File Offset: 0x0002D794
			public void Solve()
			{
				float rotationWeight = this.rotationWeight;
				if (rotationWeight > 0f || this.m_offsetRotation.sqrMagnitude != 0f)
				{
					Quaternion quaternion = this.m_toesBone.rotation;
					if (rotationWeight > 0f)
					{
						quaternion = Quaternion.Slerp(quaternion, this.rotation, this.rotationWeight);
					}
					if (this.m_offsetRotation.sqrMagnitude != 0f)
					{
						quaternion *= Quaternion.Euler(this.m_offSetToForward * this.m_offsetRotation);
					}
					this.m_toesBone.rotation = quaternion;
				}
			}

			// Token: 0x040006B8 RID: 1720
			[Range(0f, 1f)]
			[SerializeField]
			private float m_rotationWeight;

			// Token: 0x040006B9 RID: 1721
			[SerializeField]
			private Quaternion m_rotation;

			// Token: 0x040006BA RID: 1722
			[SerializeField]
			private Vector3 m_offsetRotation;

			// Token: 0x040006BB RID: 1723
			[SerializeField]
			private Transform m_heelBone;

			// Token: 0x040006BC RID: 1724
			[SerializeField]
			private Transform m_toesBone;

			// Token: 0x040006BD RID: 1725
			private ToesEffectorTValle m_effector;

			// Token: 0x040006BE RID: 1726
			private Quaternion m_offSetToForward;

			// Token: 0x040006BF RID: 1727
			private Quaternion m_defaultLocalRotation;
		}
	}
}

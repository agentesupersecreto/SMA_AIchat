using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C6 RID: 198
	public class HeadChainEffectorTValle : CustomUpdatedMonobehaviourBase, IIKCustomEffector
	{
		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06000734 RID: 1844 RVA: 0x00022C78 File Offset: 0x00020E78
		// (remove) Token: 0x06000735 RID: 1845 RVA: 0x00022CB0 File Offset: 0x00020EB0
		public event Action<HeadChainEffectorTValle> updating;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06000736 RID: 1846 RVA: 0x00022CE8 File Offset: 0x00020EE8
		// (remove) Token: 0x06000737 RID: 1847 RVA: 0x00022D20 File Offset: 0x00020F20
		public event Action<HeadChainEffectorTValle> updated;

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x00022D55 File Offset: 0x00020F55
		IReadOnlyList<CustomBipedEffector> IIKCustomEffector.effectorsTypes
		{
			get
			{
				return HeadChainEffectorTValle.m_effectorsTypes;
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00022D5C File Offset: 0x00020F5C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.m_ik = base.GetComponentInParent<FullBodyBipedIK>();
			if (this.m_ik == null)
			{
				throw new ArgumentNullException("m_ik", "m_ik null reference.");
			}
			if (this.m_ik.solver.initiated)
			{
				this.OnPostInitiate();
				return;
			}
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00022E04 File Offset: 0x00021004
		private void OnPostInitiate()
		{
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
			ICharacterRoot root = this.GetRoot();
			this.cuello1.Init(root.bodyAnimator);
			this.cuello2.Init(root.bodyAnimator);
			this.head.Init(root.bodyAnimator);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00022E77 File Offset: 0x00021077
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onFixingTransforms += this.M_updater_iKsFixedTransforms;
			this.m_updater.onSingleIKUpdatedPass1 += this.OnPassed;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00022EAD File Offset: 0x000210AD
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.onFixingTransforms -= this.M_updater_iKsFixedTransforms;
			this.m_updater.onSingleIKUpdatedPass1 -= this.OnPassed;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00022EE4 File Offset: 0x000210E4
		private void M_updater_iKsFixedTransforms(IIKUpdater obj)
		{
			this.FixTransforms();
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00022EEC File Offset: 0x000210EC
		public void FixTransforms()
		{
			this.cuello1.FixTransforms();
			this.cuello2.FixTransforms();
			this.head.FixTransforms();
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00022F10 File Offset: 0x00021110
		public void Actualizar()
		{
			Action<HeadChainEffectorTValle> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			this.cuello1.Actualizar();
			this.cuello2.Actualizar();
			this.head.Actualizar();
			Action<HeadChainEffectorTValle> action2 = this.updated;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00022F61 File Offset: 0x00021161
		private void OnPassed(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (IK != this.m_ik)
			{
				return;
			}
			if (PassEventData.index > 0)
			{
				return;
			}
			this.Actualizar();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00022F83 File Offset: 0x00021183
		bool IIKCustomEffector.IsEffectorOf(CustomBipedEffector effector)
		{
			switch (effector)
			{
			case CustomBipedEffector.head:
				return true;
			case CustomBipedEffector.cuello1:
				return true;
			case CustomBipedEffector.cuello2:
				return true;
			}
			return false;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00022FA8 File Offset: 0x000211A8
		void IIKCustomEffector.SetRotationWeightOf(CustomBipedEffector effector, float weight)
		{
			switch (effector)
			{
			case CustomBipedEffector.head:
				this.head.rotationWeight = Mathf.Clamp01(weight);
				return;
			case CustomBipedEffector.cuello1:
				this.cuello1.rotationWeight = Mathf.Clamp01(weight);
				return;
			case CustomBipedEffector.head | CustomBipedEffector.cuello1:
				break;
			case CustomBipedEffector.cuello2:
				this.cuello2.rotationWeight = Mathf.Clamp01(weight);
				break;
			default:
				return;
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00023004 File Offset: 0x00021204
		void IIKCustomEffector.SetRotationTargetOf(CustomBipedEffector effector, Quaternion rotation)
		{
			switch (effector)
			{
			case CustomBipedEffector.head:
				this.head.rotation = rotation;
				return;
			case CustomBipedEffector.cuello1:
				this.cuello1.rotation = rotation;
				return;
			case CustomBipedEffector.head | CustomBipedEffector.cuello1:
				break;
			case CustomBipedEffector.cuello2:
				this.cuello2.rotation = rotation;
				break;
			default:
				return;
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00023050 File Offset: 0x00021250
		float IIKCustomEffector.GetRotationWeightOf(CustomBipedEffector effector)
		{
			switch (effector)
			{
			case CustomBipedEffector.head:
				return this.head.rotationWeight;
			case CustomBipedEffector.cuello1:
				return this.cuello1.rotationWeight;
			case CustomBipedEffector.cuello2:
				return this.cuello2.rotationWeight;
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x000230B0 File Offset: 0x000212B0
		Quaternion IIKCustomEffector.GetRotationTargetOf(CustomBipedEffector effector)
		{
			switch (effector)
			{
			case CustomBipedEffector.head:
				return this.head.rotation;
			case CustomBipedEffector.cuello1:
				return this.cuello1.rotation;
			case CustomBipedEffector.cuello2:
				return this.cuello2.rotation;
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x040004DD RID: 1245
		public bool fixTransforms = true;

		// Token: 0x040004DE RID: 1246
		protected IIKUpdater m_updater;

		// Token: 0x040004DF RID: 1247
		public HeadChainEffectorTValle.Punto cuello1 = new HeadChainEffectorTValle.Punto();

		// Token: 0x040004E0 RID: 1248
		public HeadChainEffectorTValle.Punto cuello2 = new HeadChainEffectorTValle.Punto();

		// Token: 0x040004E1 RID: 1249
		public HeadChainEffectorTValle.Punto head = new HeadChainEffectorTValle.Punto();

		// Token: 0x040004E2 RID: 1250
		private FullBodyBipedIK m_ik;

		// Token: 0x040004E3 RID: 1251
		private static List<CustomBipedEffector> m_effectorsTypes = new List<CustomBipedEffector>
		{
			CustomBipedEffector.cuello1,
			CustomBipedEffector.cuello2,
			CustomBipedEffector.head
		};

		// Token: 0x02000195 RID: 405
		[Serializable]
		public class Punto
		{
			// Token: 0x1700025A RID: 602
			// (get) Token: 0x06000C59 RID: 3161 RVA: 0x00037533 File Offset: 0x00035733
			public bool resetOffsetRotation
			{
				get
				{
					return this.m_resetOffsetRotation;
				}
			}

			// Token: 0x1700025B RID: 603
			// (get) Token: 0x06000C5A RID: 3162 RVA: 0x0003753B File Offset: 0x0003573B
			public bool activo
			{
				get
				{
					return this.bone != null && this.rootBone != null;
				}
			}

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x06000C5B RID: 3163 RVA: 0x00037559 File Offset: 0x00035759
			public Quaternion initialFromRootCurrentWorldRotation
			{
				get
				{
					return this.rootBone.rotation * this.m_initialLocalRotationFromRoot * this.m_offSetToForward;
				}
			}

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x06000C5C RID: 3164 RVA: 0x0003757C File Offset: 0x0003577C
			public Quaternion initialCurrentWorldRotation
			{
				get
				{
					return this.rootBone.rotation * this.m_initialLocalRotation * this.m_offSetToForward;
				}
			}

			// Token: 0x1700025E RID: 606
			// (get) Token: 0x06000C5D RID: 3165 RVA: 0x0003759F File Offset: 0x0003579F
			public Quaternion currentWorldRotation
			{
				get
				{
					return this.bone.rotation * this.m_offSetToForward;
				}
			}

			// Token: 0x1700025F RID: 607
			// (get) Token: 0x06000C5E RID: 3166 RVA: 0x000375B7 File Offset: 0x000357B7
			public Vector3 currentAnglesFromRoot
			{
				get
				{
					return this.m_currentAnglesFromRoot;
				}
			}

			// Token: 0x17000260 RID: 608
			// (get) Token: 0x06000C5F RID: 3167 RVA: 0x000375BF File Offset: 0x000357BF
			public Quaternion currentLocalFromRootRotation
			{
				get
				{
					return this.m_currentLocalFromRootRotation;
				}
			}

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x06000C60 RID: 3168 RVA: 0x000375C7 File Offset: 0x000357C7
			public Vector3 currentSmoothOffsetRotation
			{
				get
				{
					return this.m_smoothOffsetRotation;
				}
			}

			// Token: 0x06000C61 RID: 3169 RVA: 0x000375D0 File Offset: 0x000357D0
			public void Init(Animator anim)
			{
				if (anim == null)
				{
					throw new ArgumentNullException("anim", "anim null reference.");
				}
				if (!this.activo || this.init)
				{
					return;
				}
				if (this.rotation.x == 0f && this.rotation.y == 0f && this.rotation.z == 0f && this.rotation.w == 0f)
				{
					this.rotation = Quaternion.identity;
				}
				this.init = true;
				this.m_initialLocalRotation = this.bone.localRotation;
				this.m_initialLocalPosition = this.bone.localPosition;
				this.m_initialLocalRotationFromRoot = Quaternion.Inverse(this.rootBone.rotation) * this.bone.rotation;
				this.m_offSetToForward = Quaternion.Inverse(this.bone.rotation) * anim.transform.rotation;
				this.m_rootOffSetToForward = Quaternion.Inverse(this.rootBone.rotation) * anim.transform.rotation;
			}

			// Token: 0x06000C62 RID: 3170 RVA: 0x000376F5 File Offset: 0x000358F5
			public void ForceSmooth()
			{
				this.m_smoothOffsetRotation = this.offsetRotation;
				this.offsetRotation = Vector3.zero;
			}

			// Token: 0x06000C63 RID: 3171 RVA: 0x0003770E File Offset: 0x0003590E
			public void FixTransforms()
			{
				if (!this.activo || !this.init)
				{
					return;
				}
				this.bone.localRotation = this.m_initialLocalRotation;
				this.bone.localPosition = this.m_initialLocalPosition;
			}

			// Token: 0x06000C64 RID: 3172 RVA: 0x00037744 File Offset: 0x00035944
			public void Actualizar()
			{
				try
				{
					if (this.activo && this.init)
					{
						Quaternion quaternion = this.bone.rotation * this.m_offSetToForward;
						Quaternion quaternion2 = this.rootBone.rotation * this.m_rootOffSetToForward;
						bool flag = this.debugDraw;
						this.m_currentLocalFromRootRotation = Quaternion.Inverse(quaternion2) * quaternion;
						this.m_currentAnglesFromRoot = this.m_currentLocalFromRootRotation.eulerAngles.PolarizarAngulos();
						float num = Time.time - this.m_lastUpdateTime;
						if (this.m_smoothOffsetRotation.sqrMagnitude != 0f || this.smoothOffsetRotation.sqrMagnitude != 0f)
						{
							float num2 = Mathf.InverseLerp(0f, 45f, Mathf.Abs(this.m_smoothOffsetRotation.x - this.smoothOffsetRotation.x)).InPow(this.m_inPowSmooth);
							num2 = Mathf.Max(this.m_minSmoothValue, num2);
							float num3 = Mathf.InverseLerp(0f, 45f, Mathf.Abs(this.m_smoothOffsetRotation.y - this.smoothOffsetRotation.y)).InPow(this.m_inPowSmooth);
							num3 = Mathf.Max(this.m_minSmoothValue, num3);
							float num4 = Mathf.InverseLerp(0f, 45f, Mathf.Abs(this.m_smoothOffsetRotation.z - this.smoothOffsetRotation.z)).InPow(this.m_inPowSmooth);
							num4 = Mathf.Max(this.m_minSmoothValue, num4);
							this.m_smoothOffsetRotation = new Vector3(Mathf.MoveTowardsAngle(this.m_smoothOffsetRotation.x, this.smoothOffsetRotation.x, this.smoothOffsetRotationSpeed * num * num2), Mathf.MoveTowardsAngle(this.m_smoothOffsetRotation.y, this.smoothOffsetRotation.y, this.smoothOffsetRotationSpeed * num * num3), Mathf.MoveTowardsAngle(this.m_smoothOffsetRotation.z, this.smoothOffsetRotation.z, this.smoothOffsetRotationSpeed * num * num4));
						}
						Vector3 vector = this.m_smoothOffsetRotation + this.offsetRotation;
						if (this.rotationWeight > 0f || vector.sqrMagnitude != 0f)
						{
							Quaternion quaternion3 = this.bone.rotation;
							if (this.rotationWeight > 0f)
							{
								quaternion3 = Quaternion.Slerp(quaternion3, this.rotation, this.rotationWeight);
							}
							if (vector.sqrMagnitude != 0f)
							{
								quaternion3 *= Quaternion.Euler(this.m_offSetToForward * vector);
							}
							this.bone.rotation = quaternion3;
						}
					}
				}
				finally
				{
					if (this.m_resetOffsetRotation)
					{
						this.offsetRotation = Vector3.zero;
					}
					this.m_lastUpdateTime = Time.time;
				}
			}

			// Token: 0x040008F2 RID: 2290
			[SerializeField]
			private bool m_resetOffsetRotation = true;

			// Token: 0x040008F3 RID: 2291
			[SerializeField]
			private bool debugDraw;

			// Token: 0x040008F4 RID: 2292
			public Transform bone;

			// Token: 0x040008F5 RID: 2293
			public Transform rootBone;

			// Token: 0x040008F6 RID: 2294
			[Range(0f, 1f)]
			public float rotationWeight;

			// Token: 0x040008F7 RID: 2295
			public Quaternion rotation = Quaternion.identity;

			// Token: 0x040008F8 RID: 2296
			public Vector3 offsetRotation;

			// Token: 0x040008F9 RID: 2297
			public float smoothOffsetRotationSpeed = 250f;

			// Token: 0x040008FA RID: 2298
			public Vector3 smoothOffsetRotation;

			// Token: 0x040008FB RID: 2299
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_smoothOffsetRotation;

			// Token: 0x040008FC RID: 2300
			private Quaternion m_initialLocalRotation;

			// Token: 0x040008FD RID: 2301
			private Quaternion m_initialLocalRotationFromRoot;

			// Token: 0x040008FE RID: 2302
			private Vector3 m_initialLocalPosition;

			// Token: 0x040008FF RID: 2303
			private Quaternion m_offSetToForward;

			// Token: 0x04000900 RID: 2304
			private Quaternion m_rootOffSetToForward;

			// Token: 0x04000901 RID: 2305
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentAnglesFromRoot;

			// Token: 0x04000902 RID: 2306
			private Quaternion m_currentLocalFromRootRotation;

			// Token: 0x04000903 RID: 2307
			[NonSerialized]
			private float m_lastUpdateTime;

			// Token: 0x04000904 RID: 2308
			[NonSerialized]
			private bool init;

			// Token: 0x04000905 RID: 2309
			[SerializeField]
			private float m_minSmoothValue = 0.01f;

			// Token: 0x04000906 RID: 2310
			[SerializeField]
			private float m_inPowSmooth = 1.1f;
		}
	}
}

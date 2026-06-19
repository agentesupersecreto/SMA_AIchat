using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000088 RID: 136
	public class ShoulderRotatorV2 : CustomUpdatedMonobehaviourBase, IHombrosIKEffector, IIKCustomEffector
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0001B01F File Offset: 0x0001921F
		public FullBodyBipedIK fullBodyBipedIK
		{
			get
			{
				return this.ik;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x0001B027 File Offset: 0x00019227
		public ShoulderRotatorV2.HombroIKEffector rEffector
		{
			get
			{
				return this.rIKEffector;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0001B02F File Offset: 0x0001922F
		public ShoulderRotatorV2.HombroIKEffector lEffector
		{
			get
			{
				return this.lIKEffector;
			}
		}

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06000558 RID: 1368 RVA: 0x0001B038 File Offset: 0x00019238
		// (remove) Token: 0x06000559 RID: 1369 RVA: 0x0001B070 File Offset: 0x00019270
		public event Action<ShoulderRotatorV2> updating;

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x0600055A RID: 1370 RVA: 0x0001B0A8 File Offset: 0x000192A8
		// (remove) Token: 0x0600055B RID: 1371 RVA: 0x0001B0E0 File Offset: 0x000192E0
		public event Action<ShoulderRotatorV2> updated;

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x0001B115 File Offset: 0x00019315
		IHombroIKEffector IHombrosIKEffector.derecho
		{
			get
			{
				return this.rIKEffector;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001B11D File Offset: 0x0001931D
		IHombroIKEffector IHombrosIKEffector.izquierdo
		{
			get
			{
				return this.lIKEffector;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001B125 File Offset: 0x00019325
		IReadOnlyList<CustomBipedEffector> IIKCustomEffector.effectorsTypes
		{
			get
			{
				return ShoulderRotatorV2.m_effectorsTypes;
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0001B12C File Offset: 0x0001932C
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
			if (this.m_updater.CantidadDePasadasDeIK(this.m_IKID) < 2)
			{
				throw new InvalidOperationException("se necesitan dos pasadas almenos para ShoulderRotator");
			}
			if (this.ik.solver.initiated)
			{
				this.OnPostInitiate();
				return;
			}
			IKSolverFullBodyBiped solver = this.ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.OnPostInitiate));
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001B1FA File Offset: 0x000193FA
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updater.onSingleIKUpdatingPass1 += this.M_updater_passing;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001B219 File Offset: 0x00019419
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_updater.onSingleIKUpdatingPass1 -= this.M_updater_passing;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001B23C File Offset: 0x0001943C
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
			this.lIKEffector.Init(Side.L, this, animator);
			this.rIKEffector.Init(Side.R, this, animator);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0001B2BD File Offset: 0x000194BD
		private void OnFixTransforms()
		{
			this.rIKEffector.FixTransfroms();
			this.rIKEffector.FixTransfroms();
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0001B2D5 File Offset: 0x000194D5
		private void M_updater_passing(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (this.m_IKID != IKEventData.id)
			{
				return;
			}
			if (!PassEventData.esUltimo)
			{
				return;
			}
			this.RotateShoulders_();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001B2F8 File Offset: 0x000194F8
		private void RotateShoulders_()
		{
			if (this.ik == null)
			{
				return;
			}
			Action<ShoulderRotatorV2> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			if (this.weight > 0f)
			{
				this.RotateShoulder(FullBodyBipedChain.LeftArm, this.weight, this.offset, this.maxAngle);
				this.RotateShoulder(FullBodyBipedChain.RightArm, this.weight, this.offset, this.maxAngle);
			}
			this.rIKEffector.Update();
			this.lIKEffector.Update();
			Action<ShoulderRotatorV2> action2 = this.updated;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0001B38C File Offset: 0x0001958C
		private void RotateShoulder(FullBodyBipedChain chain, float weight, float offset, float maxAngle)
		{
			IKEffector endEffector = this.ik.solver.GetEndEffector(chain);
			FBIKChain chain2 = this.ik.solver.GetChain(chain);
			IKMappingLimb limbMapping = this.ik.solver.GetLimbMapping(chain);
			Transform parentBone = limbMapping.parentBone;
			Vector3 vector = limbMapping.bone1.TransformDirection(this.boneLocalForward.normalized);
			Vector3 vector2 = parentBone.TransformDirection(this.localDirectionUpwards.normalized);
			float num = Vector3.Dot(vector, vector2);
			float num2 = Mathf.InverseLerp(-1f, 1f, num);
			float num3 = Mathf.Lerp(this.m_MuertoConfig.modOnMax, 1f, num2.OutPow(this.m_MuertoConfig.power));
			maxAngle *= num3;
			Quaternion quaternion = Quaternion.FromToRotation(this.GetParentBoneMap(chain).swingDirection, endEffector.position - this.GetParentBoneMap(chain).transform.position);
			Vector3 vector3 = endEffector.position - limbMapping.bone1.position;
			float num4 = chain2.nodes[0].length + chain2.nodes[1].length;
			float num5 = num3 * (vector3.magnitude / num4 - 1f + offset);
			num5 = Mathf.Clamp(num5 * weight, 0f, 1f);
			if (num5 <= 0f)
			{
				return;
			}
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, quaternion, num5 * this.ik.solver.GetEndEffector(chain).positionWeight * this.ik.solver.IKPositionWeight);
			quaternion2 = Quaternion.RotateTowards(Quaternion.identity, quaternion2, maxAngle);
			limbMapping.parentBone.rotation = quaternion2 * limbMapping.parentBone.rotation;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001B554 File Offset: 0x00019754
		[Obsolete]
		private void CustomRotation(Vector3 rotation, FullBodyBipedChain chain, FullBodyBipedIK ik)
		{
			IKMappingLimb limbMapping = ik.solver.GetLimbMapping(chain);
			if (rotation != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.Euler(rotation);
				limbMapping.parentBone.rotation = quaternion * limbMapping.parentBone.rotation;
				if (this.applyToBone1)
				{
					limbMapping.bone1.rotation = Quaternion.Inverse(quaternion) * limbMapping.bone1.rotation;
				}
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001B5C7 File Offset: 0x000197C7
		private IKMapping.BoneMap GetParentBoneMap(FullBodyBipedChain chain)
		{
			return this.ik.solver.GetLimbMapping(chain).GetBoneMap(IKMappingLimb.BoneMapType.Parent);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001B5E0 File Offset: 0x000197E0
		protected sealed override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001B5E9 File Offset: 0x000197E9
		IHombroIKEffector IHombrosIKEffector.Obtener(Side side)
		{
			switch (side)
			{
			case Side.L:
				return this.rIKEffector;
			case Side.R:
				return this.lIKEffector;
			}
			throw new ArgumentOutOfRangeException(side.ToString());
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001B628 File Offset: 0x00019828
		IHombroIKEffector IHombrosIKEffector.Obtener(FullBodyBipedEffector effector)
		{
			switch (effector)
			{
			case FullBodyBipedEffector.LeftShoulder:
				return this.lIKEffector;
			case FullBodyBipedEffector.RightShoulder:
				return this.rIKEffector;
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001B681 File Offset: 0x00019881
		bool IIKCustomEffector.IsEffectorOf(CustomBipedEffector effector)
		{
			return effector == CustomBipedEffector.hombroIzquierdo || effector == CustomBipedEffector.hombroDerecho;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001B691 File Offset: 0x00019891
		void IIKCustomEffector.SetRotationWeightOf(CustomBipedEffector effector, float weight)
		{
			if (effector != CustomBipedEffector.hombroIzquierdo)
			{
				if (effector == CustomBipedEffector.hombroDerecho)
				{
					this.rIKEffector.rotationWeight = Mathf.Clamp01(weight);
					return;
				}
			}
			else
			{
				this.lIKEffector.rotationWeight = Mathf.Clamp01(weight);
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001B6BF File Offset: 0x000198BF
		void IIKCustomEffector.SetRotationTargetOf(CustomBipedEffector effector, Quaternion rotation)
		{
			if (effector != CustomBipedEffector.hombroIzquierdo)
			{
				if (effector == CustomBipedEffector.hombroDerecho)
				{
					this.rIKEffector.rotation = rotation;
					return;
				}
			}
			else
			{
				this.lIKEffector.rotation = rotation;
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001B6E3 File Offset: 0x000198E3
		float IIKCustomEffector.GetRotationWeightOf(CustomBipedEffector effector)
		{
			if (effector == CustomBipedEffector.hombroIzquierdo)
			{
				return this.lIKEffector.rotationWeight;
			}
			if (effector == CustomBipedEffector.hombroDerecho)
			{
				return this.rIKEffector.rotationWeight;
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001B718 File Offset: 0x00019918
		Quaternion IIKCustomEffector.GetRotationTargetOf(CustomBipedEffector effector)
		{
			if (effector == CustomBipedEffector.hombroIzquierdo)
			{
				return this.lIKEffector.rotation;
			}
			if (effector == CustomBipedEffector.hombroDerecho)
			{
				return this.rIKEffector.rotation;
			}
			throw new ArgumentOutOfRangeException(effector.ToString());
		}

		// Token: 0x040003AD RID: 941
		[SerializeField]
		private Vector3 localDirectionUpwards = Vector3.up;

		// Token: 0x040003AE RID: 942
		[SerializeField]
		private Vector3 localDirectionMuerto = Vector3.down;

		// Token: 0x040003AF RID: 943
		[SerializeField]
		private ShoulderRotatorV2.MuertoConfig m_MuertoConfig = new ShoulderRotatorV2.MuertoConfig();

		// Token: 0x040003B0 RID: 944
		[SerializeField]
		private Vector3 boneLocalForward = Vector3.forward;

		// Token: 0x040003B1 RID: 945
		[Tooltip("que tanto se puede rotar el hombro")]
		public float maxAngle = 60f;

		// Token: 0x040003B2 RID: 946
		[Tooltip("Weight of shoulder rotation")]
		public float weight = 0.5f;

		// Token: 0x040003B3 RID: 947
		[Tooltip("The greater the offset, the sooner the shoulder will start rotating")]
		public float offset = 0.9f;

		// Token: 0x040003B4 RID: 948
		[Obsolete("no es local, si no global")]
		[NonSerialized]
		public Vector3 customRotR = Vector3.zero;

		// Token: 0x040003B5 RID: 949
		[Obsolete("no es local, si no global")]
		[NonSerialized]
		public Vector3 customRotL = Vector3.zero;

		// Token: 0x040003B6 RID: 950
		[Obsolete("no es local, si no global")]
		[NonSerialized]
		public bool applyToBone1 = true;

		// Token: 0x040003B7 RID: 951
		private FullBodyBipedIK ik;

		// Token: 0x040003B8 RID: 952
		[Obsolete("", true)]
		private bool skip;

		// Token: 0x040003B9 RID: 953
		[SerializeField]
		private ShoulderRotatorV2.HombroIKEffector rIKEffector = new ShoulderRotatorV2.HombroIKEffector();

		// Token: 0x040003BA RID: 954
		[SerializeField]
		private ShoulderRotatorV2.HombroIKEffector lIKEffector = new ShoulderRotatorV2.HombroIKEffector();

		// Token: 0x040003BD RID: 957
		private static List<CustomBipedEffector> m_effectorsTypes = new List<CustomBipedEffector>
		{
			CustomBipedEffector.hombroDerecho,
			CustomBipedEffector.hombroIzquierdo
		};

		// Token: 0x040003BE RID: 958
		private IIKUpdater m_updater;

		// Token: 0x040003BF RID: 959
		private int m_IKID;

		// Token: 0x0200017D RID: 381
		[Serializable]
		public class MuertoConfig
		{
			// Token: 0x040008A1 RID: 2209
			public float modOnMax = 0.25f;

			// Token: 0x040008A2 RID: 2210
			public float power = 0.5f;
		}

		// Token: 0x0200017E RID: 382
		[Serializable]
		public class HombroIKEffector : IHombroIKEffector
		{
			// Token: 0x17000248 RID: 584
			// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00036B6A File Offset: 0x00034D6A
			public bool resetOffsetRotation
			{
				get
				{
					return this.m_resetOffsetRotation;
				}
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x06000C10 RID: 3088 RVA: 0x00036B72 File Offset: 0x00034D72
			public bool activo
			{
				get
				{
					return this.m_bone != null && this.m_rootBone != null;
				}
			}

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00036B90 File Offset: 0x00034D90
			public Vector3 currentAnglesFromRoot
			{
				get
				{
					return this.m_currentAnglesFromRoot;
				}
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x06000C12 RID: 3090 RVA: 0x00036B98 File Offset: 0x00034D98
			public Quaternion currentLocalFromRootRotation
			{
				get
				{
					return this.m_currentLocalFromRootRotation;
				}
			}

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00036BA0 File Offset: 0x00034DA0
			public Vector3 currentSmoothOffsetRotation
			{
				get
				{
					return this.m_smoothOffsetRotation;
				}
			}

			// Token: 0x06000C14 RID: 3092 RVA: 0x00036BA8 File Offset: 0x00034DA8
			public void Init(Side side, ShoulderRotatorV2 Rotator, Animator anim)
			{
				if (Rotator == null)
				{
					throw new ArgumentNullException("Rotator", "Rotator null reference.");
				}
				this.m_side = side;
				this.m_ShoulderRotatorV2 = Rotator;
				IKMappingLimb limbMapping = this.m_ShoulderRotatorV2.ik.solver.GetLimbMapping(this.chain);
				this.m_arm = limbMapping.bone1;
				this.m_bone = limbMapping.parentBone;
				this.m_initiallocalRotation = this.m_bone.localRotation;
				this.m_rootBone = anim.GetBoneTransform(HumanBodyBones.UpperChest);
				if (this.m_rootBone == null)
				{
					this.m_rootBone = anim.GetBoneTransform(HumanBodyBones.Chest);
				}
				if (this.m_rootBone == null)
				{
					throw new ArgumentNullException("m_rootBone", "m_rootBone null reference.");
				}
				if (this.m_bone == null)
				{
					throw new ArgumentNullException("m_bone", "m_bone null reference.");
				}
				this.m_offSetToForward = Quaternion.Inverse(this.m_bone.rotation) * anim.transform.rotation;
				this.m_rootOffSetToForward = Quaternion.Inverse(this.m_rootBone.rotation) * anim.transform.rotation;
				bool flag = this.debugDraw;
			}

			// Token: 0x06000C15 RID: 3093 RVA: 0x00036CD9 File Offset: 0x00034ED9
			public void ForceSmooth()
			{
				this.m_smoothOffsetRotation = this.offsetRotation;
				this.offsetRotation = Vector3.zero;
			}

			// Token: 0x06000C16 RID: 3094 RVA: 0x00036CF4 File Offset: 0x00034EF4
			public void Update()
			{
				try
				{
					if (!(this.m_ShoulderRotatorV2 == null) && !(this.m_ShoulderRotatorV2.ik == null) && this.activo)
					{
						Quaternion quaternion = this.m_bone.rotation * this.m_offSetToForward;
						Quaternion quaternion2 = this.m_rootBone.rotation * this.m_rootOffSetToForward;
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
							Quaternion quaternion3 = this.m_bone.rotation;
							Quaternion quaternion4 = this.m_arm.rotation;
							if (vector.sqrMagnitude != 0f)
							{
								Quaternion quaternion5 = Quaternion.Euler(this.m_offSetToForward * vector);
								quaternion3 *= quaternion5;
							}
							if (this.rotationWeight > 0f)
							{
								Quaternion quaternion6 = Quaternion.Inverse(quaternion3) * this.rotation;
								quaternion6 = Quaternion.Slerp(Quaternion.identity, quaternion6, this.rotationWeight);
								quaternion3 *= quaternion6;
							}
							this.m_bone.rotation = quaternion3;
							this.m_arm.rotation = quaternion4;
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

			// Token: 0x06000C17 RID: 3095 RVA: 0x00037020 File Offset: 0x00035220
			public void FixTransfroms()
			{
				this.m_bone.localRotation = this.m_initiallocalRotation;
			}

			// Token: 0x06000C18 RID: 3096 RVA: 0x00037033 File Offset: 0x00035233
			public void Solve()
			{
				this.Update();
			}

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x06000C19 RID: 3097 RVA: 0x0003703B File Offset: 0x0003523B
			// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00037043 File Offset: 0x00035243
			Quaternion IHombroIKEffector.rotation
			{
				get
				{
					return this.rotation;
				}
				set
				{
					this.rotation = value;
				}
			}

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x06000C1B RID: 3099 RVA: 0x0003704C File Offset: 0x0003524C
			// (set) Token: 0x06000C1C RID: 3100 RVA: 0x00037053 File Offset: 0x00035253
			Quaternion IHombroIKEffector.rotationOffset
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x06000C1D RID: 3101 RVA: 0x0003705A File Offset: 0x0003525A
			// (set) Token: 0x06000C1E RID: 3102 RVA: 0x00037062 File Offset: 0x00035262
			float IHombroIKEffector.rotationWeight
			{
				get
				{
					return this.rotationWeight;
				}
				set
				{
					this.rotationWeight = value;
				}
			}

			// Token: 0x17000250 RID: 592
			// (get) Token: 0x06000C1F RID: 3103 RVA: 0x0003706C File Offset: 0x0003526C
			public FullBodyBipedEffector effector
			{
				get
				{
					switch (this.m_side)
					{
					case Side.L:
						return FullBodyBipedEffector.LeftShoulder;
					case Side.R:
						return FullBodyBipedEffector.RightShoulder;
					}
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
			}

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x06000C20 RID: 3104 RVA: 0x000370B8 File Offset: 0x000352B8
			public FullBodyBipedChain chain
			{
				get
				{
					switch (this.m_side)
					{
					case Side.L:
						return FullBodyBipedChain.LeftArm;
					case Side.R:
						return FullBodyBipedChain.RightArm;
					}
					throw new ArgumentOutOfRangeException(this.m_side.ToString());
				}
			}

			// Token: 0x040008A3 RID: 2211
			[SerializeField]
			private bool m_resetOffsetRotation = true;

			// Token: 0x040008A4 RID: 2212
			[SerializeField]
			private bool debugDraw;

			// Token: 0x040008A5 RID: 2213
			private Side m_side;

			// Token: 0x040008A6 RID: 2214
			[SerializeField]
			[ReadOnlyUI]
			private ShoulderRotatorV2 m_ShoulderRotatorV2;

			// Token: 0x040008A7 RID: 2215
			public Quaternion rotation = Quaternion.identity;

			// Token: 0x040008A8 RID: 2216
			public Vector3 offsetRotation;

			// Token: 0x040008A9 RID: 2217
			public float smoothOffsetRotationSpeed = 250f;

			// Token: 0x040008AA RID: 2218
			public Vector3 smoothOffsetRotation;

			// Token: 0x040008AB RID: 2219
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_smoothOffsetRotation;

			// Token: 0x040008AC RID: 2220
			[Range(0f, 1f)]
			public float rotationWeight;

			// Token: 0x040008AD RID: 2221
			private Quaternion m_initiallocalRotation;

			// Token: 0x040008AE RID: 2222
			[SerializeField]
			[ReadOnlyUI]
			private Transform m_rootBone;

			// Token: 0x040008AF RID: 2223
			[SerializeField]
			[ReadOnlyUI]
			private Transform m_bone;

			// Token: 0x040008B0 RID: 2224
			[SerializeField]
			[ReadOnlyUI]
			private Transform m_arm;

			// Token: 0x040008B1 RID: 2225
			[ReadOnlyUI]
			[SerializeField]
			private Vector3 m_currentAnglesFromRoot;

			// Token: 0x040008B2 RID: 2226
			private Quaternion m_currentLocalFromRootRotation;

			// Token: 0x040008B3 RID: 2227
			private Quaternion m_offSetToForward;

			// Token: 0x040008B4 RID: 2228
			private Quaternion m_rootOffSetToForward;

			// Token: 0x040008B5 RID: 2229
			[NonSerialized]
			private float m_lastUpdateTime;

			// Token: 0x040008B6 RID: 2230
			[SerializeField]
			private float m_minSmoothValue = 0.01f;

			// Token: 0x040008B7 RID: 2231
			[SerializeField]
			private float m_inPowSmooth = 1.1f;
		}
	}
}

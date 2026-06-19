using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Poses;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000A0 RID: 160
	[Serializable]
	public sealed class InteractionEffectorV2 : InteractionEffector
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0001E465 File Offset: 0x0001C665
		public InteractionObjectV2Base interactionObjectV2
		{
			get
			{
				return base.interactionObject as InteractionObjectV2Base;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0001E472 File Offset: 0x0001C672
		public bool inInteractionConV2
		{
			get
			{
				return this.interactionObjectV2 != null;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0001E480 File Offset: 0x0001C680
		public float InteractionWeight
		{
			get
			{
				return this.wPeso;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x0001E488 File Offset: 0x0001C688
		public float timeWeight
		{
			get
			{
				return this.m_timeWeight;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001E490 File Offset: 0x0001C690
		public float tiempoEjecutandose
		{
			get
			{
				return this.tiempo;
			}
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0001E498 File Offset: 0x0001C698
		public InteractionEffectorV2(FullBodyBipedEffector effectorType)
			: base(effectorType)
		{
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0001E4A4 File Offset: 0x0001C6A4
		public float GetDefaultValueDeWeightCurveType(InteractionObject.WeightCurve.Type tipo)
		{
			switch (tipo)
			{
			case InteractionObject.WeightCurve.Type.PositionWeight:
				return this.defaultPositionWeight;
			case InteractionObject.WeightCurve.Type.RotationWeight:
				return this.defaultRotationWeight;
			case InteractionObject.WeightCurve.Type.PositionOffsetX:
				return 0f;
			case InteractionObject.WeightCurve.Type.PositionOffsetY:
				return 0f;
			case InteractionObject.WeightCurve.Type.PositionOffsetZ:
				return 0f;
			case InteractionObject.WeightCurve.Type.Pull:
				return this.defaultPull;
			case InteractionObject.WeightCurve.Type.Reach:
				return this.defaultReach;
			case InteractionObject.WeightCurve.Type.RotateBoneWeight:
				return 0f;
			case InteractionObject.WeightCurve.Type.Push:
				return this.defaultPull;
			case InteractionObject.WeightCurve.Type.PushParent:
				return this.defaultPushParent;
			case InteractionObject.WeightCurve.Type.PoserWeight:
				return 0f;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0001E540 File Offset: 0x0001C740
		public override void Initiate(InteractionSystem interactionSystem)
		{
			this.m_isInitiating = true;
			base.Initiate(interactionSystem);
			this.poser = null;
			InteractionSystemV3 interactionSystemV = interactionSystem as InteractionSystemV3;
			if (this.effector != null && interactionSystemV != null)
			{
				this.m_poser = interactionSystemV.GetPoserDeBone(this.effector.bone);
			}
			this.m_isInitiating = false;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001E598 File Offset: 0x0001C798
		private void ForzeResetToDefaults()
		{
			this.resetTimer = 0f;
			if (this.effector.isEndEffector)
			{
				this.interactionSystem.ik.solver.GetChain(base.effectorType).pull = this.defaultPull;
				this.interactionSystem.ik.solver.GetChain(base.effectorType).reach = this.defaultReach;
				this.interactionSystem.ik.solver.GetChain(base.effectorType).push = this.defaultPush;
				this.interactionSystem.ik.solver.GetChain(base.effectorType).pushParent = this.defaultPushParent;
			}
			this.effector.positionWeight = this.defaultPositionWeight;
			this.effector.rotationWeight = this.defaultRotationWeight;
			this.interactionSystem.ik.solver.iterations = this.m_defaultIterations;
			this.defaults = true;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0001E69C File Offset: 0x0001C89C
		protected override void StoreDefaults()
		{
			if (!this.m_isInitiating && !this.defaults)
			{
				this.ForzeResetToDefaults();
			}
			this.m_defaultIterations = this.interactionSystem.ik.solver.iterations;
			base.StoreDefaults();
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001E6D8 File Offset: 0x0001C8D8
		public override bool ResetToDefaults(float speed)
		{
			if (!base.ResetToDefaults(speed))
			{
				return false;
			}
			if (this.m_iterationsUsed)
			{
				this.interactionSystem.ik.solver.iterations = Mathf.FloorToInt(Mathf.Lerp((float)this.m_defaultIterations, (float)this.interactionSystem.ik.solver.iterations, this.resetTimer));
			}
			if (this.resetTimer <= 0f)
			{
				this.m_iterationsUsed = false;
			}
			return true;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0001E750 File Offset: 0x0001C950
		public void TemporalResetToDefaults()
		{
			if (this.effector.isEndEffector)
			{
				if (this.pullUsed)
				{
					this.interactionSystem.ik.solver.GetChain(base.effectorType).pull = this.defaultPull;
				}
				if (this.reachUsed)
				{
					this.interactionSystem.ik.solver.GetChain(base.effectorType).reach = this.defaultReach;
				}
				if (this.pushUsed)
				{
					this.interactionSystem.ik.solver.GetChain(base.effectorType).push = this.defaultPush;
				}
				if (this.pushParentUsed)
				{
					this.interactionSystem.ik.solver.GetChain(base.effectorType).pushParent = this.defaultPushParent;
				}
			}
			if (this.positionWeightUsed)
			{
				this.effector.positionWeight = this.defaultPositionWeight;
			}
			if (this.rotationWeightUsed)
			{
				this.effector.rotationWeight = this.defaultRotationWeight;
			}
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0001E858 File Offset: 0x0001CA58
		protected override void RotateInteractionTarget()
		{
			if (this.interactionObjectV2 == null)
			{
				base.RotateInteractionTarget();
				return;
			}
			if ((base.effectorType == FullBodyBipedEffector.LeftHand || base.effectorType == FullBodyBipedEffector.RightHand) && this.interactionObjectV2.fixHandsInteractionTargetTwistWeight * this.interactionTarget.fixHandsInteractionTargetTwistWeightMod > 0f)
			{
				Vector3 vector = this.effector.planeBone1.position - this.effector.planeBone2.position;
				Vector3 vector2 = this.effector.bone.position - this.effector.planeBone1.position;
				float magnitude = vector2.magnitude;
				float num = magnitude / 2f;
				Vector3 vector3 = vector2.normalized + vector.normalized;
				vector3 = vector3.SetMagnitud(num);
				Vector3 vector4 = vector.SetMagnitud(magnitude);
				Vector3 vector5 = MathfExtension.SlerpConMedio(vector2, vector3, vector4, this.interactionObjectV2.fixHandsInteractionTargetTwistWeight * this.interactionTarget.fixHandsInteractionTargetTwistWeightMod, 1f, 1f);
				this.interactionTarget.RotateTo(this.effector.planeBone1.position + vector5);
				return;
			}
			base.RotateInteractionTarget();
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0001E990 File Offset: 0x0001CB90
		public override bool Start(InteractionObject interactionObject, string tag, float fadeInTime, bool interrupt)
		{
			if (!base.Start(interactionObject, tag, fadeInTime, interrupt))
			{
				return false;
			}
			this.m_firstUpdate = true;
			this.m_stoped = false;
			if (this.m_poser != null)
			{
				if (this.m_poser.poseRoot == null)
				{
					this.m_poser.weight = 0f;
				}
				if (this.interactionTarget != null)
				{
					this.m_poser.poseRoot = this.target.transform;
				}
				else
				{
					this.m_poser.poseRoot = null;
				}
				this.m_poser.AutoMapping();
			}
			InteractionObjectV2Base interactionObjectV2Base = interactionObject as InteractionObjectV2Base;
			if (interactionObjectV2Base != null)
			{
				interactionObjectV2Base.OnStartInteraction(this.interactionSystem, this);
			}
			this.tiempo = 0f;
			this.wPeso = 0f;
			this.m_timeWeight = 0f;
			InteractionObjectV2Base interactionObjectV2Base2 = interactionObject as InteractionObjectV2Base;
			this.m_iterationsUsed = ((interactionObjectV2Base2 != null) ? new bool?(interactionObjectV2Base2.CurveUsed(InteractionObjectV2Base.CustomCurva.Type.iterations)) : null).GetValueOrDefault();
			this.m_wasPaused = false;
			return true;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001EA9C File Offset: 0x0001CC9C
		public override void Update(Transform root, float speed)
		{
			InteractionObjectV2Base interactionObjectV2Base = base.interactionObject as InteractionObjectV2Base;
			if (!base.inInteraction || interactionObjectV2Base == null)
			{
				base.Update(root, speed);
				return;
			}
			if (this.m_wasPaused)
			{
				speed = Mathf.Clamp(interactionObjectV2Base.speedOutMod.total, 0.0001f, 10000f) * speed;
			}
			else if (!this.m_firstUpdate)
			{
				speed = Mathf.Clamp(interactionObjectV2Base.speedInMod.total, 0.0001f, 10000f) * speed;
			}
			if (this.m_firstUpdate)
			{
				speed = Mathf.Clamp(interactionObjectV2Base.initialSpeedInMod.total, 0.0001f, 10000f) * speed;
				interactionObjectV2Base.initialSpeedInMod = new ValorModificable(interactionObjectV2Base.defaultSpeedMod);
				this.m_firstUpdate = false;
			}
			if (Time.deltaTime > 0f)
			{
				speed = Mathf.Min(speed, this.length / 2f / Time.deltaTime);
			}
			if (base.isPaused)
			{
				this.m_wasPaused = true;
				this.m_timeWeight = 0.5f;
				interactionObjectV2Base.Applying(this.interactionSystem.ik.solver, this, base.effectorType, this.interactionTarget, this.timer, this.weight);
				base.Update(root, speed);
				interactionObjectV2Base.Applyed(this.interactionSystem.ik.solver, this, base.effectorType, this.interactionTarget, this.timer, this.weight, false);
				return;
			}
			this.tiempo = this.timer + Time.deltaTime * speed * ((this.interactionTarget != null) ? this.interactionTarget.interactionSpeedMlp : 1f);
			this.wPeso = Mathf.Clamp(this.weight + Time.deltaTime * this.fadeInSpeed * speed, 0f, 1f);
			this.m_timeWeight = Mathf.InverseLerp(0f, this.length, this.tiempo);
			interactionObjectV2Base.Applying(this.interactionSystem.ik.solver, this, base.effectorType, this.interactionTarget, this.tiempo, this.wPeso);
			float value = base.interactionObject.GetValue(InteractionObject.WeightCurve.Type.PoserWeight, this.interactionTarget, this.tiempo);
			if (this.m_poser != null)
			{
				this.m_poser.weight = Mathf.Lerp(this.m_poser.weight, value, this.wPeso);
			}
			else if (value > 0f)
			{
				Warning.Log(string.Concat(new string[]
				{
					"InteractionObject ",
					base.interactionObject.name,
					" has a curve/multipler for Poser Weight, but the bone of effector ",
					base.effectorType.ToString(),
					" has no HandPoser/GenericPoser attached."
				}), this.effector.bone, false);
			}
			base.Update(root, speed);
			if (!this.m_stoped && this.tiempo < this.length)
			{
				interactionObjectV2Base.Applyed(this.interactionSystem.ik.solver, this, base.effectorType, this.interactionTarget, this.tiempo, this.wPeso, false);
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001EDA8 File Offset: 0x0001CFA8
		public override bool Pause()
		{
			bool flag = base.Pause();
			if (base.isPaused)
			{
				InteractionObjectV2Base interactionObjectV2Base = base.interactionObject as InteractionObjectV2Base;
				if (interactionObjectV2Base != null)
				{
					interactionObjectV2Base.OnPausedInteraction(this.interactionSystem, this);
				}
			}
			return flag;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001EDE8 File Offset: 0x0001CFE8
		public override bool Resume()
		{
			bool flag = base.Resume();
			if (!base.isPaused)
			{
				InteractionObjectV2Base interactionObjectV2Base = base.interactionObject as InteractionObjectV2Base;
				if (interactionObjectV2Base != null)
				{
					interactionObjectV2Base.OnResumedInteraction(this.interactionSystem, this);
				}
			}
			return flag;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001EE28 File Offset: 0x0001D028
		public override bool Stop()
		{
			bool flag;
			try
			{
				InteractionObjectV2Base interactionObjectV2Base = base.interactionObject as InteractionObjectV2Base;
				if (!base.inInteraction || interactionObjectV2Base == null)
				{
					flag = base.Stop();
				}
				else
				{
					if (this.tiempo >= this.length)
					{
						interactionObjectV2Base.Applyed(this.interactionSystem.ik.solver, this, base.effectorType, this.interactionTarget, this.tiempo, this.wPeso, true);
					}
					if (this.m_poser != null && !this.pickedUp)
					{
						this.m_poser.weight = 0f;
					}
					interactionObjectV2Base.OnStopInteraction(this.interactionSystem, this.interactionSystem.ik.solver, this);
					this.effector.position = this.effector.bone.position;
					this.effector.rotation = this.effector.bone.rotation;
					flag = base.Stop();
				}
			}
			finally
			{
				this.m_stoped = true;
				this.tiempo = 0f;
				this.wPeso = 0f;
				this.m_timeWeight = 0f;
			}
			return flag;
		}

		// Token: 0x04000453 RID: 1107
		private PoserDeInterSys m_poser;

		// Token: 0x04000454 RID: 1108
		private float tiempo;

		// Token: 0x04000455 RID: 1109
		private float wPeso;

		// Token: 0x04000456 RID: 1110
		private float m_timeWeight;

		// Token: 0x04000457 RID: 1111
		private bool m_iterationsUsed;

		// Token: 0x04000458 RID: 1112
		private int m_defaultIterations;

		// Token: 0x04000459 RID: 1113
		private bool m_isInitiating;

		// Token: 0x0400045A RID: 1114
		private bool m_wasPaused;

		// Token: 0x0400045B RID: 1115
		private bool m_firstUpdate;

		// Token: 0x0400045C RID: 1116
		private bool m_stoped;
	}
}

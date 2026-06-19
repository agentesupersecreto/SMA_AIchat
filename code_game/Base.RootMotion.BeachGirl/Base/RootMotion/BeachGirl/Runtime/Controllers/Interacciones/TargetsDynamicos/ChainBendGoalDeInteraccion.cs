using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.TargetsDynamicos
{
	// Token: 0x0200003F RID: 63
	public sealed class ChainBendGoalDeInteraccion : AplicableBehaviour
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000DC27 File Offset: 0x0000BE27
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateAfterFinalIK);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000DC30 File Offset: 0x0000BE30
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.target0 == null)
			{
				throw new ArgumentNullException("target0", "target0 null reference.");
			}
			if (this.target2 == null)
			{
				throw new ArgumentNullException("target2", "target2 null reference.");
			}
			if (this.target3 == null)
			{
				throw new ArgumentNullException("target3", "target3 null reference.");
			}
			this.m_defaultLocalPositionFromT0 = this.target0.transform.InverseTransformPoint(this.target2.transform.position);
			this.m_defaultLocalRotationFromT0 = Quaternion.Inverse(this.target0.transform.rotation) * this.target2.transform.rotation;
			this.m_defaultLocalPositionFromT3 = this.target3.transform.InverseTransformPoint(this.target2.transform.position);
			this.m_defaultLocalRotationFromT3 = Quaternion.Inverse(this.target3.transform.rotation) * this.target2.transform.rotation;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000DD4C File Offset: 0x0000BF4C
		public void OnComienza(ICharacter character)
		{
			this.m_current = character;
			this.m_bone0 = this.ObtenerBone(this.target0.effectorType);
			this.m_bone3 = this.ObtenerBone(this.target3.effectorType);
			this.m_startPosT0 = this.m_bone0.position;
			this.m_startPosT3 = this.m_bone3.position;
			this.m_startPosT2FromT0 = this.m_bone0.transform.TransformPoint(this.m_defaultLocalPositionFromT0);
			this.m_startPosT2FromT3 = this.m_bone3.transform.TransformPoint(this.m_defaultLocalPositionFromT3);
			base.enabled = true;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000DDF0 File Offset: 0x0000BFF0
		public override void OnUpdateEvent1()
		{
			if (this.m_current == null)
			{
				return;
			}
			if (!this.m_paused || this.doCalculeEvenPaused)
			{
				float num = MathfExtension.InverseLerp(this.m_startPosT0, this.target0.transform.position, this.m_bone0.position);
				float num2 = MathfExtension.InverseLerp(this.m_startPosT3, this.target3.transform.position, this.m_bone3.position);
				float num3 = Mathf.Lerp(num, num2, this.relacionWeight);
				Vector3 vector = this.target0.transform.TransformPoint(this.m_defaultLocalPositionFromT0);
				Vector3 vector2 = this.target3.transform.TransformPoint(this.m_defaultLocalPositionFromT3);
				Vector3 vector3 = Vector3.Lerp(this.m_startPosT2FromT0, vector, num3);
				Vector3 vector4 = Vector3.Lerp(this.m_startPosT2FromT3, vector2, num3);
				this.target2.transform.position = Vector3.Lerp(vector3, vector4, this.relacionWeight);
				return;
			}
			Vector3 vector5 = this.target3.transform.TransformPoint(this.m_defaultLocalPositionFromT3);
			Vector3 position = this.target2.transform.position;
			if (!ExtendedMonoBehaviour.AlmostEqual(vector5, position, 0.001f))
			{
				this.target2.transform.position = Vector3.MoveTowards(position, vector5, Time.deltaTime * 0.1f);
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000DF3D File Offset: 0x0000C13D
		public void OnPaused()
		{
			this.m_paused = true;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000DF46 File Offset: 0x0000C146
		public void OnResume()
		{
			this.m_paused = false;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000DF50 File Offset: 0x0000C150
		public void OnTermina()
		{
			if (this.target2 != null && this.target0 != null)
			{
				InteractionTargetTValle interactionTargetTValle = this.target2;
				if (interactionTargetTValle != null)
				{
					Transform transform = interactionTargetTValle.transform;
					if (transform != null)
					{
						transform.SetPositionAndRotation(this.target0.transform.TransformPoint(this.m_defaultLocalPositionFromT0), this.target0.transform.rotation * this.m_defaultLocalRotationFromT0);
					}
				}
			}
			if (this != null)
			{
				base.enabled = false;
			}
			this.m_current = null;
			this.m_bone0 = null;
			this.m_bone3 = null;
			this.m_paused = false;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000DFF4 File Offset: 0x0000C1F4
		private Transform ObtenerBone(FullBodyBipedEffector effectorType)
		{
			HumanBodyBones humanBodyBones;
			switch (effectorType)
			{
			case FullBodyBipedEffector.Body:
				humanBodyBones = HumanBodyBones.Spine;
				break;
			case FullBodyBipedEffector.LeftShoulder:
				humanBodyBones = HumanBodyBones.LeftUpperArm;
				break;
			case FullBodyBipedEffector.RightShoulder:
				humanBodyBones = HumanBodyBones.RightUpperArm;
				break;
			case FullBodyBipedEffector.LeftThigh:
				humanBodyBones = HumanBodyBones.LeftUpperLeg;
				break;
			case FullBodyBipedEffector.RightThigh:
				humanBodyBones = HumanBodyBones.RightUpperLeg;
				break;
			case FullBodyBipedEffector.LeftHand:
				humanBodyBones = HumanBodyBones.LeftHand;
				break;
			case FullBodyBipedEffector.RightHand:
				humanBodyBones = HumanBodyBones.RightHand;
				break;
			case FullBodyBipedEffector.LeftFoot:
				humanBodyBones = HumanBodyBones.LeftFoot;
				break;
			case FullBodyBipedEffector.RightFoot:
				humanBodyBones = HumanBodyBones.RightFoot;
				break;
			default:
				throw new ArgumentOutOfRangeException(effectorType.ToString());
			}
			return this.m_current.bodyAnimator.GetBoneTransform(humanBodyBones);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000E079 File Offset: 0x0000C279
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				playTimeVisible = false,
				text = "Calular Bend Goals"
			};
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000E092 File Offset: 0x0000C292
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000E09C File Offset: 0x0000C29C
		public void CalcularBendGoalsPosition()
		{
			Transform parent = this.target2.transform.parent;
			Vector3 vector = parent.position - this.target1.transform.position;
			Vector3 vector2 = parent.position - this.target3.transform.position;
			float num = vector.magnitude + vector2.magnitude;
			Quaternion quaternion = Quaternion.LookRotation((vector + vector2).normalized, parent.up);
			Vector3 vector3 = parent.position + quaternion * Vector3.forward * (num * 0.25f);
			this.target2.SetGoals(vector3, quaternion);
		}

		// Token: 0x040001CB RID: 459
		public InteractionTarget target0;

		// Token: 0x040001CC RID: 460
		public InteractionTarget target1;

		// Token: 0x040001CD RID: 461
		public InteractionTargetTValle target2;

		// Token: 0x040001CE RID: 462
		public InteractionTarget target3;

		// Token: 0x040001CF RID: 463
		[Tooltip("zero para target0, uno para target3")]
		public float relacionWeight = 0.75f;

		// Token: 0x040001D0 RID: 464
		public bool doCalculeEvenPaused;

		// Token: 0x040001D1 RID: 465
		private Vector3 m_defaultLocalPositionFromT0;

		// Token: 0x040001D2 RID: 466
		private Quaternion m_defaultLocalRotationFromT0;

		// Token: 0x040001D3 RID: 467
		private Vector3 m_defaultLocalPositionFromT3;

		// Token: 0x040001D4 RID: 468
		private Quaternion m_defaultLocalRotationFromT3;

		// Token: 0x040001D5 RID: 469
		private ICharacter m_current;

		// Token: 0x040001D6 RID: 470
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_bone0;

		// Token: 0x040001D7 RID: 471
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_bone3;

		// Token: 0x040001D8 RID: 472
		[SerializeField]
		[ReadOnlyUI]
		private bool m_paused;

		// Token: 0x040001D9 RID: 473
		private Vector3 m_startPosT0;

		// Token: 0x040001DA RID: 474
		private Vector3 m_startPosT3;

		// Token: 0x040001DB RID: 475
		private Vector3 m_startPosT2FromT0;

		// Token: 0x040001DC RID: 476
		private Vector3 m_startPosT2FromT3;
	}
}

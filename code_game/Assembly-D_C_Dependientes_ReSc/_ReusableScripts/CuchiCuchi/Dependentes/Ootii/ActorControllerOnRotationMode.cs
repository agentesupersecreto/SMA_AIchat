using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Cameras;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii
{
	// Token: 0x0200015E RID: 350
	public sealed class ActorControllerOnRotationMode : CharacterRotationMode
	{
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x000066D6 File Offset: 0x000048D6
		public sealed override int updateEvent3Index
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x00026701 File Offset: 0x00024901
		public ModificableDeFloat pitchModificable
		{
			get
			{
				return this.m_PitchModificable;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x00026709 File Offset: 0x00024909
		public ModificableDeFloat yawRModificable
		{
			get
			{
				return this.m_YawRModificable;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00026711 File Offset: 0x00024911
		public ModificableDeFloat yawLModificable
		{
			get
			{
				return this.m_YawLModificable;
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0002671C File Offset: 0x0002491C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.motionController = base.GetComponentInChildren<MotionController>();
			this.actorController = base.GetComponentInChildren<ActorController>();
			this.m_AnimatorCharacter = this.GetComponentEnCharacter(false);
			if (this.m_AnimatorCharacter == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			if (this.motionController == null)
			{
				Debug.LogWarning("No MotionController found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the MotionController.", base.transform);
				return;
			}
			if (this.actorController == null)
			{
				Debug.LogWarning("No ActorController found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the ActorController.", base.transform);
				return;
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000267B0 File Offset: 0x000249B0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_lastStateIsMoving = false;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x000267C0 File Offset: 0x000249C0
		public override void OnUpdateEvent3()
		{
			if (this.m_motor == null)
			{
				return;
			}
			if (this.m_motor.RotateAnchor != this.m_lastMotorState)
			{
				this.flagUpdateModo = true;
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x000267E8 File Offset: 0x000249E8
		public void ActualizarMotor()
		{
			CameraController cameraController = this.motionController.CameraRig as CameraController;
			if (this.motionController.CameraRig == null)
			{
				this.m_motor = null;
				return;
			}
			this.m_motor = cameraController.ActiveMotor as ViewMotor;
			if (this.m_motor == null)
			{
				return;
			}
			this.m_defaultMinYaw = this.m_motor.MinYaw;
			this.m_defaultMaxYaw = this.m_motor.MaxYaw;
			this.m_defaultMinPitch = this.m_motor.MinPitch;
			this.m_defaultMaxPitch = this.m_motor.MaxPitch;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0002687C File Offset: 0x00024A7C
		protected override void OnModoChanged()
		{
			if (this.m_motor == null)
			{
				this.ActualizarMotor();
			}
			if (this.m_motor == null)
			{
				Debug.LogWarning("se requiere un motor de typo " + typeof(ViewMotor).Name, this);
				return;
			}
			CharacterRotationMode.Modo modo = this.modo;
			if (modo == CharacterRotationMode.Modo.bodyRotation)
			{
				this.m_lastMotorState = (this.m_motor.RotateAnchor = true);
				this.m_motor.RigController._Transform.position = this.m_motor.Anchor.position + this.m_motor.Anchor.rotation * this.m_motor.AnchorOffset + this.m_motor.Anchor.rotation * this.m_motor._Offset;
				this.m_motor.RigController._Transform.rotation = Quaternion.Euler(this.m_motor.RigController._Transform.rotation.eulerAngles.x, this.m_motor.Anchor.rotation.eulerAngles.y, 0f);
				return;
			}
			if (modo != CharacterRotationMode.Modo.headRotation)
			{
				throw new ArgumentOutOfRangeException(this.modo.ToString());
			}
			this.m_lastMotorState = (this.m_motor.RotateAnchor = false);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000269E4 File Offset: 0x00024BE4
		protected override void OnCharacterPositionChanged(Vector3 position, Quaternion rotation)
		{
			if (MainChar.current != base.character)
			{
				return;
			}
			this.m_motor.RotateAnchor = true;
			this.m_motor.RigController._Transform.position = position + rotation * this.m_motor.AnchorOffset + rotation * this.m_motor._Offset;
			this.m_motor.RigController._Transform.rotation = Quaternion.Euler(this.m_motor.RigController._Transform.rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
			Singleton<CurrentMainChar>.instance.camara.UpdateCamera();
			this.m_motor.RigController._Transform.position = position + rotation * this.m_motor.AnchorOffset + rotation * this.m_motor._Offset;
			this.m_motor.RigController._Transform.rotation = Quaternion.Euler(this.m_motor.RigController._Transform.rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
			this.flagUpdateModo = true;
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00026B44 File Offset: 0x00024D44
		protected override void CheckingMode()
		{
			if (this.m_motor == null)
			{
				this.ActualizarMotor();
			}
			if (this.m_motor == null)
			{
				Debug.LogWarning("se requiere un motor de typo " + typeof(ViewMotor).Name, this);
				return;
			}
			float num = 0f;
			if (this.limitarPitchWithInteractedRootMotion && Singleton<CurrentMainChar>.instance.camara != null && Singleton<CurrentMainChar>.instance.camara.anchorMode == CurrentMainChar.AnchorMode.animatorRootMotion)
			{
				Vector3 vector = Quaternion.Inverse(this.m_AnimatorCharacter.animatorRootMotionTransform.rotation) * this.m_AnimatorCharacter.interactedBodyAnimatorRootMotionTransform.rotation * Vector3.forward;
				Vector3 vector2 = Math3d.ProjectVectorOnPlane(Vector3.right, vector);
				if (vector2 != Vector3.zero)
				{
					num = Mathf.Atan2(vector2.y, vector2.z) * 57.29578f;
				}
			}
			ActorState state = this.actorController.State;
			bool flag = this.actorController.enabled && state.Velocity.sqrMagnitude > 0f;
			bool flag2 = flag != this.m_lastStateIsMoving;
			this.m_lastStateIsMoving = flag;
			float num2 = this.m_PitchModificable.ModificarValor(1f);
			float num3 = this.m_YawRModificable.ModificarValor(1f);
			float num4 = this.m_YawLModificable.ModificarValor(1f);
			float num5 = (flag ? (this.minYawMoving * num4) : (this.m_defaultMinYaw * num4));
			float num6 = (flag ? (this.maxYawMoving * num3) : (this.m_defaultMaxYaw * num3));
			this.m_motor._MinYaw = Mathf.MoveTowards(this.m_motor._MinYaw, num5, Time.deltaTime * 360f);
			this.m_motor._MaxYaw = Mathf.MoveTowards(this.m_motor._MaxYaw, num6, Time.deltaTime * 360f);
			this.m_motor.MinPitch = Mathf.MoveTowards(this.m_motor._MinPitch, (this.m_defaultMinPitch - num) * num2, Time.deltaTime * 360f);
			this.m_motor.MaxPitch = Mathf.MoveTowards(this.m_motor._MaxPitch, (this.m_defaultMaxPitch - num) * num2, Time.deltaTime * 360f);
			if (flag2)
			{
				this.m_motor._Smoothing = 0f;
			}
		}

		// Token: 0x040005C1 RID: 1473
		public bool limitarPitchWithInteractedRootMotion;

		// Token: 0x040005C2 RID: 1474
		public float minYawMoving = -180f;

		// Token: 0x040005C3 RID: 1475
		public float maxYawMoving = 180f;

		// Token: 0x040005C4 RID: 1476
		private MotionController motionController;

		// Token: 0x040005C5 RID: 1477
		private ActorController actorController;

		// Token: 0x040005C6 RID: 1478
		private AnimatorCharacter m_AnimatorCharacter;

		// Token: 0x040005C7 RID: 1479
		private ViewMotor m_motor;

		// Token: 0x040005C8 RID: 1480
		[SerializeField]
		private float m_defaultMinYaw;

		// Token: 0x040005C9 RID: 1481
		[SerializeField]
		private float m_defaultMaxYaw;

		// Token: 0x040005CA RID: 1482
		[SerializeField]
		private float m_defaultMinPitch;

		// Token: 0x040005CB RID: 1483
		[SerializeField]
		private float m_defaultMaxPitch;

		// Token: 0x040005CC RID: 1484
		private bool m_lastMotorState;

		// Token: 0x040005CD RID: 1485
		private bool m_lastStateIsMoving;

		// Token: 0x040005CE RID: 1486
		[SerializeField]
		private ModificableDeFloat m_PitchModificable = new ModificableDeFloat(1f);

		// Token: 0x040005CF RID: 1487
		[SerializeField]
		private ModificableDeFloat m_YawRModificable = new ModificableDeFloat(1f);

		// Token: 0x040005D0 RID: 1488
		[SerializeField]
		private ModificableDeFloat m_YawLModificable = new ModificableDeFloat(1f);
	}
}

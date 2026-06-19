using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using com.ootii.Actors;
using com.ootii.Cameras;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Camaras
{
	// Token: 0x02000169 RID: 361
	[RequireComponent(typeof(CameraController))]
	public class MainCharCamera : AplicableBehaviour, CurrentMainChar.ICamera
	{
		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x00028D8A File Offset: 0x00026F8A
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x00028D92 File Offset: 0x00026F92
		public CurrentMainChar.AnchorMode anchorMode
		{
			get
			{
				return this.m_anchorMode;
			}
			set
			{
				this.m_anchorMode = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x00028D9B File Offset: 0x00026F9B
		public Camera camara
		{
			get
			{
				return this.m_camera;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00026E57 File Offset: 0x00025057
		public override int updateEvent2Index
		{
			get
			{
				return 38;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		public Transform cameraTransform
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00028DA3 File Offset: 0x00026FA3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CameraController = base.GetComponent<CameraController>();
			if (this.m_CameraController == null)
			{
				throw new ArgumentNullException("m_CameraController", "m_CameraController null reference.");
			}
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00028DD5 File Offset: 0x00026FD5
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.forceReUpdateAnchor = true;
			this.m_camera = base.GetComponentInChildren<Camera>();
			this.ForceUpdateMainCharCamera();
			if (Singleton<CurrentMainChar>.IsInScene)
			{
				Singleton<CurrentMainChar>.instance.changed += this.Instance_changed;
			}
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00028E13 File Offset: 0x00027013
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<CurrentMainChar>.IsInScene)
			{
				Singleton<CurrentMainChar>.instance.changed -= this.Instance_changed;
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00028E39 File Offset: 0x00027039
		private void Instance_changed(MainChar nuevo, MainChar viejo, CurrentMainChar sender)
		{
			if (((viejo != null) ? viejo.character : null) != null)
			{
				this.ForceClearMainCharCamera(viejo.character);
			}
			if (nuevo != null)
			{
				this.ForceUpdateMainCharCamera();
			}
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00028E6C File Offset: 0x0002706C
		private void SetCameraOffset()
		{
			if (this.m_CameraController == null)
			{
				return;
			}
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			CurrentMainChar.AnchorMode anchorMode = this.anchorMode;
			Transform transform;
			if (anchorMode != CurrentMainChar.AnchorMode.animatorRootMotion)
			{
				if (anchorMode != CurrentMainChar.AnchorMode.interactedRootMotion)
				{
					throw new ArgumentOutOfRangeException(this.anchorMode.ToString());
				}
				transform = ((AnimatorCharacter)current).interactedBodyAnimatorRootMotionTransform;
			}
			else
			{
				transform = ((AnimatorCharacter)current).animatorRootMotionTransform;
			}
			if (transform != this.m_CameraController.Anchor)
			{
				this.m_CameraController.Anchor = transform;
			}
			if (this.m_mainController == null)
			{
				return;
			}
			if (this.m_flagUpdateAnchorOffset)
			{
				float magnitude = this.m_mainController.State.Velocity.magnitude;
				float num2;
				if (magnitude > 0f)
				{
					Vector3 centerOfMassUpDirection = MainChar.current.centerOfMassUpDirection;
					float num = Vector3.Dot(this.cameraTransform.forward, centerOfMassUpDirection);
					num = Mathf.InverseLerp(-0.5f, -1f, num).OutPow(2f);
					num2 = Mathf.Lerp(this.smoothConfig.smoothAtWalkingSpeed_MirandoAdelante, this.smoothConfig.smoothAtWalkingSpeed_MirandoAbajo, num);
				}
				else
				{
					num2 = this.smoothConfig.smoothAtWalkingSpeed_MirandoAdelante;
				}
				float num3 = MathfExtension.InverseLerpConMedio(0f, this.smoothConfig.walkingSpeed * current.escala, this.smoothConfig.runningSpeed * current.escala, magnitude);
				num3 = MathfExtension.LerpConMedio(this.smoothConfig.smoothAtStanding, num2, this.smoothConfig.smoothAtRunningSpeed, num3);
				float num4;
				if (num3 >= this.m_smoothWeight)
				{
					num4 = this.smoothConfig.incrementandoVelocityChange;
				}
				else
				{
					num4 = this.smoothConfig.disminuyendoVelocityChange;
				}
				this.m_smoothWeight = Mathf.MoveTowards(this.m_smoothWeight, num3, num4 * Time.deltaTime);
				float num5 = this.m_smoothPower * this.m_smoothWeight * Time.deltaTime;
				Vector3 vector = (this.m_lastFirstPersonViewPoint = Vector3.Lerp(this.m_lastFirstPersonViewPoint, current.worldFirstPersonViewPoint, num5));
				Vector3 vector2 = transform.InverseTransformPoint(vector);
				this.m_CameraController.AnchorOffset = Vector3.Scale(vector2, transform.lossyScale);
			}
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0002908C File Offset: 0x0002728C
		public void Ver(Vector3 point)
		{
			Vector3 vector = point - this.m_CameraController.Camera.transform.position;
			this.m_CameraController.SetTargetForward(vector, this.lookAtTargetConfig.lookAtSpeed, true);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x000290D0 File Offset: 0x000272D0
		public void ForzarVista(Vector3 point)
		{
			Vector3 vector = point - this.m_CameraController.Camera.transform.position;
			this.m_CameraController.SetTargetForward(vector, this.lookAtTargetConfig.lookAtSpeed, false);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00029111 File Offset: 0x00027311
		public void DejarDeForzarVista()
		{
			this.m_CameraController.ClearTargetForward();
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00029120 File Offset: 0x00027320
		private void UpdateAnchor()
		{
			if (this.forceReUpdateAnchor || this.m_CameraController.Anchor != this.m_currentAnchor)
			{
				this.forceReUpdateAnchor = false;
				this.UnSubscribe();
				this.m_mainController = null;
				if (this.m_CameraController.Anchor != null)
				{
					this.m_mainController = this.m_CameraController.Anchor.GetComponentEnCharacter(false);
				}
				for (int i = 0; i < this.m_CameraController.Motors.Count; i++)
				{
					ViewMotor viewMotor = this.m_CameraController.Motors[i] as ViewMotor;
					if (viewMotor != null)
					{
						viewMotor.mCharacterController = this.m_mainController;
					}
				}
				this.m_currentAnchor = this.m_CameraController.Anchor;
				if (this.m_mainController != null)
				{
					ICharacterController mainController = this.m_mainController;
					mainController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(mainController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					Character componentInParent = ((MonoBehaviour)this.m_mainController).GetComponentInParent<Character>();
					if (componentInParent)
					{
						componentInParent.SetCamera(base.transform);
						if (CurrentMainCharacter<CurrentMainChar, MainChar>.current.character == componentInParent)
						{
							Singleton<CurrentMainChar>.instance.SetCamera(this);
						}
					}
				}
				this.m_CameraController.SetManualUpdate();
			}
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0002925C File Offset: 0x0002745C
		private void UnSubscribe()
		{
			if (this.m_mainController != null)
			{
				ICharacterController mainController = this.m_mainController;
				mainController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(mainController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				Character componentInParent = ((MonoBehaviour)this.m_mainController).GetComponentInParent<Character>();
				if (componentInParent)
				{
					componentInParent.ClearCamera();
				}
			}
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x000292B8 File Offset: 0x000274B8
		public void ForceClearMainCharCamera(Character from)
		{
			Transform animatorRootMotionTransform = ((AnimatorCharacter)from).animatorRootMotionTransform;
			Transform interactedBodyAnimatorRootMotionTransform = ((AnimatorCharacter)from).interactedBodyAnimatorRootMotionTransform;
			if (this.m_CameraController.Anchor == animatorRootMotionTransform || this.m_CameraController.Anchor == interactedBodyAnimatorRootMotionTransform)
			{
				Singleton<CurrentMainChar>.instance.ClearCamera();
				this.UnSubscribe();
				this.m_mainController = null;
				this.m_CameraController.Anchor = null;
				this.m_CameraController.OnPostLateUpdate = null;
				this.m_currentAnchor = null;
			}
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002933C File Offset: 0x0002753C
		public void ForceUpdateMainCharCamera()
		{
			CameraController cameraController = this.m_CameraController;
			if (((cameraController != null) ? cameraController.Anchor : null) != null)
			{
				this.m_mainController = this.m_CameraController.Anchor.GetComponentEnCharacter(false);
			}
			if (this.m_mainController != null)
			{
				Character componentInParent = ((MonoBehaviour)this.m_mainController).GetComponentInParent<Character>();
				if (componentInParent)
				{
					componentInParent.SetCamera(base.transform);
					MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
					if (((current != null) ? current.character : null) == componentInParent)
					{
						Singleton<CurrentMainChar>.instance.SetCamera(this);
					}
				}
			}
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x000293CB File Offset: 0x000275CB
		private void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.m_UpdateData.rDeltaTime = rDeltaTime;
			this.m_UpdateData.rUpdateIndex = rUpdateIndex;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x000293E8 File Offset: 0x000275E8
		public sealed override void OnUpdateEvent2()
		{
			try
			{
				this.m_flagUpdateAnchorOffset = true;
				this.UpdateCamera();
			}
			finally
			{
				this.m_flagUpdateAnchorOffset = false;
			}
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0002941C File Offset: 0x0002761C
		public void UpdateCamera()
		{
			this.UpdateAnchor();
			this.SetCameraOffset();
			if (this.m_mainController != null)
			{
				this.m_CameraController.ManualUpdate(this.m_mainController, this.m_UpdateData.rDeltaTime, this.m_UpdateData.rUpdateIndex);
			}
		}

		// Token: 0x04000622 RID: 1570
		[SerializeField]
		private CurrentMainChar.AnchorMode m_anchorMode;

		// Token: 0x04000623 RID: 1571
		[SerializeField]
		[Range(0f, 1f)]
		private float m_smoothWeight = 0.5f;

		// Token: 0x04000624 RID: 1572
		[SerializeField]
		private float m_smoothPower = 105f;

		// Token: 0x04000625 RID: 1573
		private Vector3 m_lastFirstPersonViewPoint;

		// Token: 0x04000626 RID: 1574
		private CameraController m_CameraController;

		// Token: 0x04000627 RID: 1575
		private Camera m_camera;

		// Token: 0x04000628 RID: 1576
		private bool forceReUpdateAnchor;

		// Token: 0x04000629 RID: 1577
		private MainCharCamera.UpdateData m_UpdateData = new MainCharCamera.UpdateData();

		// Token: 0x0400062A RID: 1578
		public MainCharCamera.SmoothConfig smoothConfig = new MainCharCamera.SmoothConfig();

		// Token: 0x0400062B RID: 1579
		public MainCharCamera.LookAtTargetConfig lookAtTargetConfig = new MainCharCamera.LookAtTargetConfig();

		// Token: 0x0400062C RID: 1580
		private bool m_flagUpdateAnchorOffset;

		// Token: 0x0400062D RID: 1581
		private Transform m_currentAnchor;

		// Token: 0x0400062E RID: 1582
		private ICharacterController m_mainController;

		// Token: 0x0200016A RID: 362
		private class UpdateData
		{
			// Token: 0x060007F2 RID: 2034 RVA: 0x00029498 File Offset: 0x00027698
			public void Clear()
			{
				this.rDeltaTime = 0f;
				this.rUpdateIndex = 0;
			}

			// Token: 0x0400062F RID: 1583
			public float rDeltaTime;

			// Token: 0x04000630 RID: 1584
			public int rUpdateIndex;
		}

		// Token: 0x0200016B RID: 363
		[Serializable]
		public class LookAtTargetConfig
		{
			// Token: 0x04000631 RID: 1585
			public float lookAtSpeed = 1000f;
		}

		// Token: 0x0200016C RID: 364
		[Serializable]
		public class SmoothConfig
		{
			// Token: 0x04000632 RID: 1586
			public float smoothAtStanding = 0.12f;

			// Token: 0x04000633 RID: 1587
			public float smoothAtWalkingSpeed_MirandoAdelante = 0.225f;

			// Token: 0x04000634 RID: 1588
			public float smoothAtWalkingSpeed_MirandoAbajo = 0.75f;

			// Token: 0x04000635 RID: 1589
			public float smoothAtRunningSpeed = 0.8f;

			// Token: 0x04000636 RID: 1590
			public float walkingSpeed = 0.8f;

			// Token: 0x04000637 RID: 1591
			public float runningSpeed = 3.3f;

			// Token: 0x04000638 RID: 1592
			public float incrementandoVelocityChange = float.MaxValue;

			// Token: 0x04000639 RID: 1593
			public float disminuyendoVelocityChange = 1f;
		}
	}
}

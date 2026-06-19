using System;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands
{
	// Token: 0x02000253 RID: 595
	public sealed class HandConstraintPositionOnFingerPenetration : CustomMonobehaviour
	{
		// Token: 0x06000FC2 RID: 4034 RVA: 0x000465DC File Offset: 0x000447DC
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_HandCameraControllerV2 = this.GetComponentEnRoot(false);
			if (this.m_HandCameraControllerV2 == null)
			{
				throw new ArgumentNullException("m_HandCameraControllerV2", "m_HandCameraControllerV2 null reference.");
			}
			this.m_finger = this.GetComponentEnRoot(false);
			if (this.m_finger == null)
			{
				throw new ArgumentNullException("m_finger", "m_finger null reference.");
			}
			this.m_FingerPhyscisController = this.GetComponentEnRoot(false);
			if (this.m_FingerPhyscisController == null)
			{
				throw new ArgumentNullException("m_FingerPhyscisController", "m_FingerPhyscisController null reference.");
			}
			this.m_HandCameraControllerV2.updatingHandPosition += this.M_HandCameraControllerV2_updatingHandPosition;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00046687 File Offset: 0x00044887
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_HandCameraControllerV2)
			{
				this.m_HandCameraControllerV2.updatingHandPosition -= this.M_HandCameraControllerV2_updatingHandPosition;
			}
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x000466B4 File Offset: 0x000448B4
		private void M_HandCameraControllerV2_updatingHandPosition(ref Vector3 targetWorldPosition, ref Quaternion targetWorldRotation, Transform handBone, Transform pose, HandCameraControllerV2 sender)
		{
			BoneStretchedChain boneStretchedChain;
			HolePointsDataCollector component;
			bool flag;
			if (base.isActiveAndEnabled && this.m_finger.IsPenetratingHole(out boneStretchedChain) && (component = boneStretchedChain.GetComponent<HolePointsDataCollector>()) != null)
			{
				flag = true;
				Vector3 vector = component.worldEntradaPosition + component.worldOutHoleDirection * (this.m_finger.worldMaxWidth * 0.5f);
				if (this.fixPosition)
				{
					Vector3 vector2 = Matrix4x4.TRS(targetWorldPosition, targetWorldRotation, Vector3.one).MultiplyPoint3x4(this.m_FingerPhyscisController.fingerBoneInitialLocalPosition);
					float num;
					float num2;
					Math3dTvalle.GetVerticalAndHorizontalAngleOnPlane(out num, out num2, component.worldOutHoleDirection, component.worldUpHoleDirection, vector, vector2, false);
					float num3 = Mathf.InverseLerp(0f, 90f, num2);
					Vector3 vector3 = Math3dTvalle.ProjectPointInsideCone(component.worldOutHoleDirection, vector, this.limitConfig.coneAngleHorizontal, this.distance, vector2);
					Vector3 vector4 = Vector3.Slerp(Math3dTvalle.ProjectPointInsideCone(component.worldOutHoleDirection, vector, this.limitConfig.coneAngleVertical, this.distance, vector2), vector3, num3);
					bool flag2 = this.debugDrawCone;
					Vector3 vector5 = Math3dTvalle.ProjectPointInsideCone(component.worldOutHoleDirection, vector, this.limitConfig.coneAngleHorizontal, this.distance, targetWorldPosition);
					Vector3 vector6 = Vector3.Slerp(Math3dTvalle.ProjectPointInsideCone(component.worldOutHoleDirection, vector, this.limitConfig.coneAngleVertical, this.distance, targetWorldPosition), vector5, num3);
					this.m_lastCorrectionOffset_Position = vector4 - vector2 + (vector6 - targetWorldPosition);
					bool flag3 = this.debugDrawCone;
				}
				if (this.fixRotation)
				{
					Quaternion quaternion = targetWorldRotation * this.m_FingerPhyscisController.armatureRotationOffset;
					Vector3 vector7 = quaternion * Vector3.up;
					Quaternion quaternion2 = Quaternion.LookRotation(-component.worldOutHoleDirection, vector7);
					Quaternion quaternion3 = Quaternion.LookRotation(this.m_FingerPhyscisController.fingerPhysicsInitialLocalPosition);
					quaternion2 *= Quaternion.Inverse(quaternion3);
					quaternion2 *= Quaternion.Inverse(this.m_FingerPhyscisController.armatureRotationOffset);
					quaternion *= Quaternion.Inverse(this.m_FingerPhyscisController.armatureRotationOffset);
					this.m_rotationResultado = Quaternion.RotateTowards(quaternion2, quaternion, this.limitConfig.rotationAngle);
					this.m_lastCorrectionOffset_Rotation = 1f;
					bool flag4 = this.debugDrawDirection;
				}
				this.m_currentInVelocity = Mathf.MoveTowards(this.m_currentInVelocity, 1f, Time.deltaTime / this.inRestoreTime);
			}
			else
			{
				flag = false;
				this.m_lastCorrectionOffset_Position = Vector3.zero;
				this.m_lastCorrectionOffset_Rotation = 0f;
				this.m_currentInVelocity = 0f;
			}
			float num4 = this.m_currentInVelocity.InPow(this.offsetInVelocityInPower);
			float num5;
			if (flag)
			{
				num5 = num4 * this.offsetInVelocity;
			}
			else
			{
				num5 = this.offsetRestoreVelocity;
			}
			this.m_currentCorrectionOffset_Position = Vector3.MoveTowards(this.m_currentCorrectionOffset_Position, this.m_lastCorrectionOffset_Position, Time.deltaTime * 0.1f * num5);
			this.m_currentCorrectionOffset_Rotation = Mathf.MoveTowards(this.m_currentCorrectionOffset_Rotation, this.m_lastCorrectionOffset_Rotation, Time.deltaTime * num5);
			targetWorldPosition += this.m_currentCorrectionOffset_Position;
			targetWorldRotation = Quaternion.Lerp(targetWorldRotation, this.m_rotationResultado, this.m_currentCorrectionOffset_Rotation);
		}

		// Token: 0x04000AF7 RID: 2807
		public bool debugDrawCone;

		// Token: 0x04000AF8 RID: 2808
		public bool debugDrawDirection;

		// Token: 0x04000AF9 RID: 2809
		public bool fixPosition = true;

		// Token: 0x04000AFA RID: 2810
		public bool fixRotation = true;

		// Token: 0x04000AFB RID: 2811
		public float distance = 9999999f;

		// Token: 0x04000AFC RID: 2812
		public float inRestoreTime = 6f;

		// Token: 0x04000AFD RID: 2813
		public float offsetInVelocityInPower = 2f;

		// Token: 0x04000AFE RID: 2814
		public float offsetInVelocity = 300f;

		// Token: 0x04000AFF RID: 2815
		public HandConstraintPositionOnFingerPenetration.LimitConfig limitConfig = new HandConstraintPositionOnFingerPenetration.LimitConfig();

		// Token: 0x04000B00 RID: 2816
		public float offsetRestoreVelocity = 2f;

		// Token: 0x04000B01 RID: 2817
		private float m_currentInVelocity;

		// Token: 0x04000B02 RID: 2818
		private FingerPhyscisController m_FingerPhyscisController;

		// Token: 0x04000B03 RID: 2819
		private HandCameraControllerV2 m_HandCameraControllerV2;

		// Token: 0x04000B04 RID: 2820
		private Finger m_finger;

		// Token: 0x04000B05 RID: 2821
		[SerializeField]
		private Vector3 m_lastCorrectionOffset_Position;

		// Token: 0x04000B06 RID: 2822
		[SerializeField]
		private Vector3 m_currentCorrectionOffset_Position;

		// Token: 0x04000B07 RID: 2823
		[SerializeField]
		private float m_lastCorrectionOffset_Rotation;

		// Token: 0x04000B08 RID: 2824
		[SerializeField]
		private float m_currentCorrectionOffset_Rotation;

		// Token: 0x04000B09 RID: 2825
		private Quaternion m_rotationResultado;

		// Token: 0x02000254 RID: 596
		[Serializable]
		public class LimitConfig
		{
			// Token: 0x04000B0A RID: 2826
			public float coneAngleHorizontal = 75f;

			// Token: 0x04000B0B RID: 2827
			public float coneAngleVertical = 35f;

			// Token: 0x04000B0C RID: 2828
			public float rotationAngle = 5f;
		}
	}
}

using System;
using com.ootii.Geometry;
using com.ootii.Graphics;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F2 RID: 242
	[MotionName("Basic Idle Focus")]
	[MotionDescription("Top down game style idle where the character focuses on a mouse, input direction, target position, or target.")]
	public class BasicIdleFocus : BasicIdle
	{
		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x000401A7 File Offset: 0x0003E3A7
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x000401AF File Offset: 0x0003E3AF
		public int TargetIndex
		{
			get
			{
				return this._TargetIndex;
			}
			set
			{
				this._TargetIndex = value;
				this.mTarget = this.mMotionController.GetStoredGameObject(ref this._TargetIndex);
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x000401CF File Offset: 0x0003E3CF
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x000401D7 File Offset: 0x0003E3D7
		public GameObject Target
		{
			get
			{
				return this.mTarget;
			}
			set
			{
				this.mTarget = value;
				if (this.mTarget != null)
				{
					this._TargetPosition = Vector3.zero;
					this._RotateToInput = false;
					this._RotateToMouse = false;
				}
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x00040207 File Offset: 0x0003E407
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x0004020F File Offset: 0x0003E40F
		public Vector3 TargetPosition
		{
			get
			{
				return this._TargetPosition;
			}
			set
			{
				this._TargetPosition = value;
				if (this._TargetPosition.sqrMagnitude > 0f)
				{
					this.Target = null;
					this._RotateToInput = false;
					this._RotateToMouse = false;
				}
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x0004023F File Offset: 0x0003E43F
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x00040247 File Offset: 0x0003E447
		public bool RotateToMouse
		{
			get
			{
				return this._RotateToMouse;
			}
			set
			{
				this._RotateToMouse = value;
				if (this._RotateToMouse)
				{
					this.Target = null;
					this._TargetPosition = Vector3.zero;
					this._RotateToInput = false;
				}
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00040271 File Offset: 0x0003E471
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x00040279 File Offset: 0x0003E479
		public bool RotateToInput
		{
			get
			{
				return this._RotateToInput;
			}
			set
			{
				this._RotateToInput = value;
				if (this._RotateToInput)
				{
					this.Target = null;
					this._TargetPosition = Vector3.zero;
					this._RotateToMouse = false;
				}
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x000402A3 File Offset: 0x0003E4A3
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x000402AB File Offset: 0x0003E4AB
		public bool RotateRelativeToCamera
		{
			get
			{
				return this._RotateRelativeToCamera;
			}
			set
			{
				this._RotateRelativeToCamera = value;
			}
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x000402B4 File Offset: 0x0003E4B4
		public BasicIdleFocus()
		{
			this._RotationSpeed = 360f;
			this._RotateWithCamera = false;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x00040304 File Offset: 0x0003E504
		public BasicIdleFocus(MotionController rController)
			: base(rController)
		{
			this._RotationSpeed = 360f;
			this._RotateWithCamera = false;
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00040355 File Offset: 0x0003E555
		public override void Awake()
		{
			base.Awake();
			this.TargetIndex = this._TargetIndex;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00040369 File Offset: 0x0003E569
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			rMovement = Vector3.zero;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00040384 File Offset: 0x0003E584
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			Quaternion rotation = this.mMotionController._Transform.rotation;
			Vector3 vector = this.mMotionController._Transform.forward;
			if (this.mTarget != null)
			{
				vector = (this.mTarget.transform.position - this.mMotionController._Transform.position).normalized;
				Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
			}
			else if (this._TargetPosition.sqrMagnitude > 0f)
			{
				vector = (this._TargetPosition - this.mMotionController._Transform.position).normalized;
				Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
			}
			else if (this._RotateToMouse)
			{
				Vector2 vector2 = Camera.main.WorldToScreenPoint(this.mMotionController._Transform.position);
				Vector2 normalized = (Input.mousePosition - vector2).normalized;
				vector = new Vector3(normalized.x, 0f, normalized.y);
				if (Camera.main != null)
				{
					vector = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * vector;
				}
				Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
			}
			else if (this._RotateToInput)
			{
				Vector3 position = this.mMotionController._Transform.position;
				Vector3 vector3 = this.mMotionController.State.InputForward;
				if (vector3.sqrMagnitude == 0f)
				{
					vector3 = this.mStoredInputForward;
				}
				else
				{
					this.mStoredInputForward = vector3.normalized;
				}
				if (this._RotateRelativeToCamera)
				{
					vector3 = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * vector3;
				}
				Vector3 vector4 = position;
				vector4.x += vector3.x;
				vector4.z += vector3.z;
				vector = (vector4 - this.mMotionController._Transform.position).normalized;
				if (vector.sqrMagnitude > 0f)
				{
					Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
				}
			}
			this.RotateToDirection(vector, this._RotationSpeed, rDeltaTime, ref this.mRotation);
			if (base.ShowDebug)
			{
				GraphicsManager.DrawLine(this.mMotionController._Transform.position, this.mMotionController._Transform.position + vector, Color.blue, null, 0f);
			}
			if (this._Form <= 0 && this.mActiveForm != this.mMotionController.CurrentForm)
			{
				this.mActiveForm = this.mMotionController.CurrentForm;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			}
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x000406C8 File Offset: 0x0003E8C8
		protected void RotateToDirection(Vector3 rForward, float rSpeed, float rDeltaTime, ref Quaternion rRotation)
		{
			Quaternion quaternion = QuaternionExt.FromToRotation(this.mMotionController._Transform.up, Vector3.up);
			Vector3 vector = quaternion * this.mMotionController._Transform.forward;
			Vector3 vector2 = quaternion * rForward;
			float num = NumberHelper.GetHorizontalAngle(vector, vector2);
			if (rSpeed > 0f && Mathf.Abs(num) > rSpeed * rDeltaTime)
			{
				num = Mathf.Sign(num) * rSpeed * rDeltaTime;
			}
			rRotation = Quaternion.AngleAxis(num, Vector3.up);
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00040745 File Offset: 0x0003E945
		private float ScreenAngle(Vector2 rFrom, Vector2 rTo)
		{
			return Mathf.Atan2(rFrom.y - rTo.y, rFrom.x - rTo.x) * 57.29578f + 90f;
		}

		// Token: 0x04000728 RID: 1832
		public int _TargetIndex = -1;

		// Token: 0x04000729 RID: 1833
		[NonSerialized]
		protected GameObject mTarget;

		// Token: 0x0400072A RID: 1834
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x0400072B RID: 1835
		public bool _RotateToMouse = true;

		// Token: 0x0400072C RID: 1836
		public bool _RotateToInput;

		// Token: 0x0400072D RID: 1837
		public bool _RotateRelativeToCamera = true;

		// Token: 0x0400072E RID: 1838
		protected Vector3 mStoredInputForward = Vector3.zero;
	}
}

using System;
using com.ootii.Graphics;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F5 RID: 245
	[MotionName("Basic Walk Run Focus")]
	[MotionDescription("Top down game style movement where the character focus on a mouse, input direction, target position, or target.")]
	public class BasicWalkRunFocus : BasicWalkRunStrafe
	{
		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x00041BC5 File Offset: 0x0003FDC5
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x00041BCD File Offset: 0x0003FDCD
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

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x00041BED File Offset: 0x0003FDED
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x00041BF5 File Offset: 0x0003FDF5
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

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x00041C25 File Offset: 0x0003FE25
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x00041C2D File Offset: 0x0003FE2D
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

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x00041C5D File Offset: 0x0003FE5D
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x00041C65 File Offset: 0x0003FE65
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

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x00041C8F File Offset: 0x0003FE8F
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x00041C97 File Offset: 0x0003FE97
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

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x00041CC1 File Offset: 0x0003FEC1
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x00041CC9 File Offset: 0x0003FEC9
		public bool MoveRelativeToCamera
		{
			get
			{
				return this._MoveRelativeToCamera;
			}
			set
			{
				this._MoveRelativeToCamera = value;
				if (this._MoveRelativeToCamera)
				{
					this._MoveRelativeToActor = false;
				}
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x00041CE1 File Offset: 0x0003FEE1
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x00041CE9 File Offset: 0x0003FEE9
		public bool MoveRelativeToActor
		{
			get
			{
				return this._MoveRelativeToActor;
			}
			set
			{
				this._MoveRelativeToActor = value;
				if (this._MoveRelativeToActor)
				{
					this._MoveRelativeToCamera = false;
				}
			}
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00041D04 File Offset: 0x0003FF04
		public BasicWalkRunFocus()
		{
			this._RequireTarget = false;
			this._RotateWithCamera = false;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00041D50 File Offset: 0x0003FF50
		public BasicWalkRunFocus(MotionController rController)
			: base(rController)
		{
			this._RequireTarget = false;
			this._RotateWithCamera = false;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00041D9D File Offset: 0x0003FF9D
		public override void Awake()
		{
			base.Awake();
			this.TargetIndex = this._TargetIndex;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00041DB4 File Offset: 0x0003FFB4
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			rRotation = Quaternion.identity;
			float num = (this.IsRunActive ? this._RunSpeed : this._WalkSpeed);
			if (num > 0f)
			{
				if (this._RotateToMouse || this.mTarget != null || this._TargetPosition.sqrMagnitude > 0f)
				{
					rMovement = rMovement.normalized;
				}
				else if (this._RotateToInput)
				{
					rMovement = Vector3.forward;
				}
				rMovement = rMovement.normalized * (num * rDeltaTime);
			}
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00041E4C File Offset: 0x0004004C
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
			this.mMovement = Vector3.zero;
			this.mRotation = Quaternion.identity;
			base.SmoothInput();
			Quaternion quaternion = this.mMotionController._Transform.rotation;
			Vector3 vector = this.mMotionController._Transform.forward;
			if (this.mTarget != null)
			{
				vector = (this.mTarget.transform.position - this.mMotionController._Transform.position).normalized;
				quaternion = Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
			}
			else if (this._TargetPosition.sqrMagnitude > 0f)
			{
				vector = (this._TargetPosition - this.mMotionController._Transform.position).normalized;
				quaternion = Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
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
				quaternion = Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
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
				if (this._MoveRelativeToCamera)
				{
					vector3 = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * vector3;
				}
				Vector3 vector4 = position;
				vector4.x += vector3.x;
				vector4.z += vector3.z;
				vector = (vector4 - this.mMotionController._Transform.position).normalized;
				if (vector.sqrMagnitude > 0f)
				{
					quaternion = Quaternion.LookRotation(vector, this.mMotionController._Transform.up);
				}
			}
			base.RotateToDirection(vector, this._RotationSpeed, rDeltaTime, ref this.mRotation);
			if (base.ShowDebug)
			{
				GraphicsManager.DrawLine(this.mMotionController._Transform.position, this.mMotionController._Transform.position + vector, Color.blue, null, 0f);
			}
			Vector3 vector5 = new Vector3(this.mInputX.Average, 0f, this.mInputY.Average);
			if (this._RotateToMouse || this.mTarget != null || this._TargetPosition.sqrMagnitude > 0f)
			{
				if (this._MoveRelativeToCamera)
				{
					vector5 = Camera.main.transform.rotation * vector5;
				}
				if (this._MoveRelativeToActor)
				{
					vector5 = quaternion * vector5;
				}
				vector5 = Quaternion.Inverse(quaternion) * vector5;
			}
			else if (this._RotateToInput)
			{
				vector5 = Vector3.forward;
			}
			else
			{
				if (this._MoveRelativeToCamera)
				{
					vector5 = Camera.main.transform.rotation * vector5;
				}
				if (this._MoveRelativeToActor)
				{
					vector5 = quaternion * vector5;
				}
				vector5 = Quaternion.Inverse(quaternion) * vector5;
			}
			this.mMotionController.State.InputX = vector5.x;
			this.mMotionController.State.InputY = vector5.z;
			this.mMotionController.State.InputForward = vector5;
			if (this._Form <= 0 && this.mActiveForm != this.mMotionController.CurrentForm)
			{
				this.mActiveForm = this.mMotionController.CurrentForm;
				this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, 0, true);
			}
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000422A9 File Offset: 0x000404A9
		private float ScreenAngle(Vector2 rFrom, Vector2 rTo)
		{
			return Mathf.Atan2(rFrom.y - rTo.y, rFrom.x - rTo.x) * 57.29578f + 90f;
		}

		// Token: 0x04000760 RID: 1888
		public int _TargetIndex = -1;

		// Token: 0x04000761 RID: 1889
		[NonSerialized]
		protected GameObject mTarget;

		// Token: 0x04000762 RID: 1890
		public Vector3 _TargetPosition = Vector3.zero;

		// Token: 0x04000763 RID: 1891
		public bool _RotateToMouse = true;

		// Token: 0x04000764 RID: 1892
		public bool _RotateToInput;

		// Token: 0x04000765 RID: 1893
		public bool _MoveRelativeToCamera = true;

		// Token: 0x04000766 RID: 1894
		public bool _MoveRelativeToActor;

		// Token: 0x04000767 RID: 1895
		protected Vector3 mStoredInputForward = Vector3.zero;
	}
}

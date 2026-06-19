using System;
using com.ootii.Base;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000076 RID: 118
	[BaseName("Look At Motor")]
	[BaseDescription("Simple motor used to always look at a specific object.")]
	public class LookAtTargetMotor : CameraMotor
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0001FB6D File Offset: 0x0001DD6D
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x0001FB75 File Offset: 0x0001DD75
		public bool UseCurrentPosition
		{
			get
			{
				return this._UseCurrentPosition;
			}
			set
			{
				this._UseCurrentPosition = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0001FB7E File Offset: 0x0001DD7E
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x0001FB86 File Offset: 0x0001DD86
		public Vector3 Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				this._Position = value;
				this.mIsPositionSet = this._Position.sqrMagnitude > 0f;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0001FBA7 File Offset: 0x0001DDA7
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x0001FBB0 File Offset: 0x0001DDB0
		public virtual int TargetIndex
		{
			get
			{
				return this._TargetIndex;
			}
			set
			{
				this._TargetIndex = value;
				if (this._TargetIndex >= 0 && this.RigController != null && this._TargetIndex < this.RigController.StoredTransforms.Count)
				{
					this._Target = this.RigController.StoredTransforms[this._TargetIndex];
				}
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0001FC0F File Offset: 0x0001DE0F
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0001FC17 File Offset: 0x0001DE17
		public virtual Transform Target
		{
			get
			{
				return this._Target;
			}
			set
			{
				this._Target = value;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0001FC20 File Offset: 0x0001DE20
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0001FC28 File Offset: 0x0001DE28
		public virtual Vector3 TargetOffset
		{
			get
			{
				return this._TargetOffset;
			}
			set
			{
				this._TargetOffset = value;
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0001FC34 File Offset: 0x0001DE34
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			if (this.RigController == null)
			{
				return this.mRigTransform;
			}
			Vector3 vector = Vector3.up;
			if (this.mIsPositionSet)
			{
				this.mRigTransform.Position = this._Position;
			}
			else if (this._UseCurrentPosition)
			{
				this.mRigTransform.Position = this.RigController._Transform.position;
			}
			else if (this.Anchor != null)
			{
				vector = this.Anchor.up;
				this.mRigTransform.Position = this.AnchorPosition + this.Anchor.rotation * this._Offset;
			}
			else
			{
				this.mRigTransform.Position = this._Offset;
			}
			Vector3 vector2 = Vector3.forward;
			if (this._Target == null)
			{
				vector2 = (this._TargetOffset - this.mRigTransform.Position).normalized;
			}
			else
			{
				vector2 = (this._Target.position + this._TargetOffset - this.mRigTransform.Position).normalized;
			}
			this.mRigTransform.Rotation = Quaternion.LookRotation(vector2, vector);
			return this.mRigTransform;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0001FD74 File Offset: 0x0001DF74
		public override void DeserializeMotor(string rDefinition)
		{
			base.DeserializeMotor(rDefinition);
			if (this._TargetIndex >= 0)
			{
				if (this._TargetIndex < this.RigController.StoredTransforms.Count)
				{
					this._Target = this.RigController.StoredTransforms[this._TargetIndex];
				}
				else
				{
					this._Target = null;
					this._TargetIndex = -1;
				}
			}
			this.IsCollisionEnabled = false;
			this.IsFadingEnabled = false;
		}

		// Token: 0x040002B9 RID: 697
		public bool _UseCurrentPosition = true;

		// Token: 0x040002BA RID: 698
		public Vector3 _Position = Vector3.zero;

		// Token: 0x040002BB RID: 699
		public int _TargetIndex = -1;

		// Token: 0x040002BC RID: 700
		[NonSerialized]
		public Transform _Target;

		// Token: 0x040002BD RID: 701
		public Vector3 _TargetOffset = Vector3.zero;

		// Token: 0x040002BE RID: 702
		protected bool mIsPositionSet;
	}
}

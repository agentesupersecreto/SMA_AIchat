using System;
using System.Collections.Generic;
using com.ootii.Actors;
using com.ootii.Base;
using com.ootii.Helpers;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x0200007A RID: 122
	[BaseName("Transition")]
	[BaseDescription("Motor that transitions from one motor to another. The 'Transition' motor does the transition while the 'End' motor is the result.")]
	public class TransitionMotor : CameraMotor
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x000211B2 File Offset: 0x0001F3B2
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x000211BA File Offset: 0x0001F3BA
		public int StartMotorIndex
		{
			get
			{
				return this._StartMotorIndex;
			}
			set
			{
				this._StartMotorIndex = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000211C3 File Offset: 0x0001F3C3
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x000211CB File Offset: 0x0001F3CB
		public int EndMotorIndex
		{
			get
			{
				return this._EndMotorIndex;
			}
			set
			{
				this._EndMotorIndex = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x000211D4 File Offset: 0x0001F3D4
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x000211DC File Offset: 0x0001F3DC
		public int EndMotorIndexOverride
		{
			get
			{
				return this._EndMotorIndexOverride;
			}
			set
			{
				this._EndMotorIndexOverride = value;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x000211E5 File Offset: 0x0001F3E5
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x000211ED File Offset: 0x0001F3ED
		public int PositionBlend
		{
			get
			{
				return this._PositionBlend;
			}
			set
			{
				this._PositionBlend = value;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x000211F6 File Offset: 0x0001F3F6
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x000211FE File Offset: 0x0001F3FE
		public int RotationBlend
		{
			get
			{
				return this._RotationBlend;
			}
			set
			{
				this._RotationBlend = value;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00021207 File Offset: 0x0001F407
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x0002120F File Offset: 0x0001F40F
		public float TransitionTime
		{
			get
			{
				return this._TransitionTime;
			}
			set
			{
				this._TransitionTime = value;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00021218 File Offset: 0x0001F418
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x00021220 File Offset: 0x0001F420
		public int ActionAliasEventType
		{
			get
			{
				return this._ActionAliasEventType;
			}
			set
			{
				this._ActionAliasEventType = value;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x00021229 File Offset: 0x0001F429
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x00021231 File Offset: 0x0001F431
		public bool LimitToStart
		{
			get
			{
				return this._LimitToStart;
			}
			set
			{
				this._LimitToStart = value;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0002123A File Offset: 0x0001F43A
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x00021242 File Offset: 0x0001F442
		public bool TestDistance
		{
			get
			{
				return this._TestDistance;
			}
			set
			{
				this._TestDistance = value;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0002124B File Offset: 0x0001F44B
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x00021254 File Offset: 0x0001F454
		public string ActorStances
		{
			get
			{
				return this._ActorStances;
			}
			set
			{
				this._ActorStances = value;
				if (this._ActorStances.Length == 0)
				{
					if (this.mActorStances != null)
					{
						this.mActorStances.Clear();
						return;
					}
				}
				else
				{
					if (this.mActorStances == null)
					{
						this.mActorStances = new List<int>();
					}
					this.mActorStances.Clear();
					int num = 0;
					string[] array = this._ActorStances.Split(',', StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						if (int.TryParse(array[i], out num) && !this.mActorStances.Contains(num))
						{
							this.mActorStances.Add(num);
						}
					}
				}
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x000212EC File Offset: 0x0001F4EC
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x000212F4 File Offset: 0x0001F4F4
		public int DistanceCompareType
		{
			get
			{
				return this._DistanceCompareType;
			}
			set
			{
				this._DistanceCompareType = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x000212FD File Offset: 0x0001F4FD
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x00021305 File Offset: 0x0001F505
		public float DistanceValue
		{
			get
			{
				return this._DistanceValue;
			}
			set
			{
				this._DistanceValue = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0002130E File Offset: 0x0001F50E
		public float TransitionElapsedTime
		{
			get
			{
				return this.mTransitionElapsedTime;
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00021316 File Offset: 0x0001F516
		public override void Awake()
		{
			base.Awake();
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00021320 File Offset: 0x0001F520
		public override bool Initialize()
		{
			this.mStartMotor = null;
			if (this._StartMotorIndex < 0)
			{
				this.mStartMotor = this.RigController.ActiveMotor;
			}
			else if (this._StartMotorIndex < this.RigController.Motors.Count)
			{
				this.mStartMotor = this.RigController.Motors[this._StartMotorIndex];
			}
			if (this.mStartMotor == this)
			{
				this.mStartMotor = null;
			}
			this.mEndMotor = null;
			if (this._EndMotorIndex >= 0 && this._EndMotorIndex < this.RigController.Motors.Count)
			{
				this.mEndMotor = this.RigController.Motors[this._EndMotorIndex];
			}
			if (this.mEndMotor == this)
			{
				this.mEndMotor = null;
			}
			float num = 1f;
			if (this.RigController.ActiveMotor is TransitionMotor)
			{
				TransitionMotor transitionMotor = this.RigController.ActiveMotor as TransitionMotor;
				num = ((transitionMotor.TransitionTime > 0f) ? (transitionMotor.TransitionElapsedTime / transitionMotor.TransitionTime) : 1f);
			}
			else if (this.mStartMotor is YawPitchMotor)
			{
				YawPitchMotor yawPitchMotor = this.mStartMotor as YawPitchMotor;
				if (yawPitchMotor.MaxDistance == 0f)
				{
					num = 1f;
				}
				else
				{
					num = NumberHelper.SmoothStepTime(0f, yawPitchMotor.MaxDistance, yawPitchMotor.Distance);
				}
			}
			else if (this.mEndMotor is YawPitchMotor)
			{
				YawPitchMotor yawPitchMotor2 = this.mEndMotor as YawPitchMotor;
				if (yawPitchMotor2.MaxDistance == 0f)
				{
					num = 1f;
				}
				else
				{
					num = NumberHelper.SmoothStepTime(0f, yawPitchMotor2.MaxDistance, yawPitchMotor2.Distance);
				}
			}
			this.mTransitionElapsedTime = this._TransitionTime * (1f - num);
			if (this.mStartMotor != null && this.mEndMotor != null)
			{
				this.mStartMotor.Initialize();
				this.mEndMotor.Initialize();
				this.mStartPosition = this.RigController._Transform.position;
				this.mStartRotation = this.RigController._Transform.rotation;
				return base.Initialize();
			}
			return false;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00021534 File Offset: 0x0001F734
		public override bool TestActivate(CameraMotor rActiveMotor)
		{
			this.UpdateToggle();
			if (!this._IsEnabled)
			{
				return false;
			}
			bool flag = false;
			if ((!this._LimitToStart || this.RigController.ActiveMotorIndex == this._StartMotorIndex) && this._ActionAlias.Length > 0 && this.RigController.InputSource != null)
			{
				if (this._ActionAliasEventType == 0)
				{
					if (this.RigController.InputSource.IsJustPressed(this._ActionAlias) || (this.mIsActionAliasInUse && !this.mWasActionAliasInUse))
					{
						flag = true;
					}
				}
				else if (this._ActionAliasEventType == 1 && (this.RigController.InputSource.IsJustReleased(this._ActionAlias) || (!this.mIsActionAliasInUse && this.mWasActionAliasInUse)))
				{
					flag = true;
				}
			}
			if (this.TestDistance && this.RigController.ActiveMotor != null)
			{
				if (this.DistanceCompareType == 0)
				{
					if (this.RigController.ActiveMotor.Distance < this.DistanceValue)
					{
						flag = true;
					}
				}
				else if (this.DistanceCompareType == 1)
				{
					if (this.RigController.ActiveMotor.Distance > this.DistanceValue)
					{
						flag = true;
					}
				}
				else if (Mathf.Abs(this.RigController.ActiveMotor.Distance - this.DistanceValue) < 0.001f)
				{
					flag = true;
				}
			}
			if (flag && this.mActorStances != null && this.mActorStances.Count > 0)
			{
				flag = false;
				ActorController actorController = this.RigController.CharacterController as ActorController;
				if (actorController != null)
				{
					int stance = actorController.State.Stance;
					if (this.mActorStances.Contains(stance))
					{
						flag = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000216C8 File Offset: 0x0001F8C8
		public override CameraTransform RigLateUpdate(float rDeltaTime, int rUpdateIndex, float rTiltAngle = 0f)
		{
			this.UpdateToggle();
			if (this.mStartMotor == null || this.mEndMotor == null)
			{
				return this.mRigTransform;
			}
			this.mTransitionElapsedTime += rDeltaTime;
			float num = this.mTransitionElapsedTime / this._TransitionTime;
			CameraTransform cameraTransform = this.mStartMotor.RigLateUpdate(rDeltaTime, rUpdateIndex, rTiltAngle);
			CameraTransform cameraTransform2 = this.mEndMotor.RigLateUpdate(rDeltaTime, rUpdateIndex, rTiltAngle);
			if (this._PositionBlend == 1)
			{
				this.mRigTransform.Position = Vector3.Lerp(this.mStartPosition, cameraTransform2.Position, num);
			}
			else if (this._PositionBlend == 2)
			{
				this.mRigTransform.Position = cameraTransform.Position;
			}
			else if (this._PositionBlend == 3)
			{
				this.mRigTransform.Position = cameraTransform2.Position;
			}
			else
			{
				this.mRigTransform.Position = Vector3.Lerp(cameraTransform.Position, cameraTransform2.Position, num);
			}
			if (this._RotationBlend == 1)
			{
				this.mRigTransform.Rotation = Quaternion.Slerp(this.mStartRotation, cameraTransform2.Rotation, num);
			}
			else if (this._RotationBlend == 2)
			{
				this.mRigTransform.Rotation = cameraTransform.Rotation;
			}
			else if (this._RotationBlend == 3)
			{
				this.mRigTransform.Rotation = cameraTransform2.Rotation;
			}
			else
			{
				this.mRigTransform.Rotation = Quaternion.Slerp(cameraTransform.Rotation, cameraTransform2.Rotation, num);
			}
			return this.mRigTransform;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0002182C File Offset: 0x0001FA2C
		public override void PostRigLateUpdate()
		{
			base.PostRigLateUpdate();
			if (this.mStartMotor != null)
			{
				this.mStartMotor.PostRigLateUpdate();
			}
			if (this.mEndMotor != null)
			{
				this.mEndMotor.PostRigLateUpdate();
			}
			if (this.mTransitionElapsedTime >= this._TransitionTime)
			{
				int num = ((this._EndMotorIndexOverride >= 0 && this._EndMotorIndex < this.RigController.Motors.Count) ? this._EndMotorIndexOverride : this._EndMotorIndex);
				this.RigController.ActivateMotor(num);
			}
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000218B0 File Offset: 0x0001FAB0
		protected virtual void UpdateToggle()
		{
			if (this._ActionAlias.Length > 0 && this.RigController.InputSource != null)
			{
				this.mWasActionAliasInUse = this.mIsActionAliasInUse;
				this.mIsActionAliasInUse = this.RigController.InputSource.GetValue(this._ActionAlias) != 0f;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0002190A File Offset: 0x0001FB0A
		public override void DeserializeMotor(string rDefinition)
		{
			base.DeserializeMotor(rDefinition);
			this.ActorStances = this._ActorStances;
		}

		// Token: 0x040002D3 RID: 723
		private static string[] ActionAliasEventTypes = new string[] { "Key down", "Key up" };

		// Token: 0x040002D4 RID: 724
		public static string[] BlendTypes = new string[] { "Active Start", "Static Start", "Start Only", "End Only" };

		// Token: 0x040002D5 RID: 725
		public static string[] NumericComparisonTypes = new string[] { "<", ">", "=" };

		// Token: 0x040002D6 RID: 726
		public int _StartMotorIndex;

		// Token: 0x040002D7 RID: 727
		public int _EndMotorIndex;

		// Token: 0x040002D8 RID: 728
		public int _EndMotorIndexOverride = -1;

		// Token: 0x040002D9 RID: 729
		public int _PositionBlend;

		// Token: 0x040002DA RID: 730
		public int _RotationBlend;

		// Token: 0x040002DB RID: 731
		public float _TransitionTime = 0.5f;

		// Token: 0x040002DC RID: 732
		public int _ActionAliasEventType;

		// Token: 0x040002DD RID: 733
		public bool _LimitToStart;

		// Token: 0x040002DE RID: 734
		public bool _TestDistance;

		// Token: 0x040002DF RID: 735
		public string _ActorStances = "";

		// Token: 0x040002E0 RID: 736
		public int _DistanceCompareType;

		// Token: 0x040002E1 RID: 737
		public float _DistanceValue = 0.5f;

		// Token: 0x040002E2 RID: 738
		protected CameraMotor mStartMotor;

		// Token: 0x040002E3 RID: 739
		protected CameraMotor mEndMotor;

		// Token: 0x040002E4 RID: 740
		protected Vector3 mStartPosition = Vector3.zero;

		// Token: 0x040002E5 RID: 741
		protected Quaternion mStartRotation = Quaternion.identity;

		// Token: 0x040002E6 RID: 742
		protected bool mIsActionAliasInUse;

		// Token: 0x040002E7 RID: 743
		protected bool mWasActionAliasInUse;

		// Token: 0x040002E8 RID: 744
		protected List<int> mActorStances;

		// Token: 0x040002E9 RID: 745
		protected float mTransitionElapsedTime;
	}
}

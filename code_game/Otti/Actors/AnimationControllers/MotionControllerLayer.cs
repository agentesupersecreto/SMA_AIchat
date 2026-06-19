using System;
using System.Collections.Generic;
using com.ootii.Base;
using com.ootii.Messages;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E8 RID: 232
	[Serializable]
	public class MotionControllerLayer : BaseObject
	{
		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0003893C File Offset: 0x00036B3C
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x00038944 File Offset: 0x00036B44
		public int Index
		{
			get
			{
				return this.mIndex;
			}
			set
			{
				this.mIndex = value;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0003894D File Offset: 0x00036B4D
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x00038958 File Offset: 0x00036B58
		public MotionController MotionController
		{
			get
			{
				return this.mMotionController;
			}
			set
			{
				this.mMotionController = value;
				for (int i = 0; i < this.Motions.Count; i++)
				{
					this.Motions[i].MotionController = this.mMotionController;
				}
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x00038999 File Offset: 0x00036B99
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x000389A1 File Offset: 0x00036BA1
		public bool IgnoreMotionOverride
		{
			get
			{
				return this._IgnoreMotionOverride;
			}
			set
			{
				this._IgnoreMotionOverride = value;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x000389AA File Offset: 0x00036BAA
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x000389B4 File Offset: 0x00036BB4
		public int AnimatorLayerIndex
		{
			get
			{
				return this._AnimatorLayerIndex;
			}
			set
			{
				this._AnimatorLayerIndex = value;
				if (this.mMotionController != null && this.mMotionController.Animator != null)
				{
					this.mAnimatorLayerName = this.mMotionController.Animator.GetLayerName(this._AnimatorLayerIndex);
				}
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00038A05 File Offset: 0x00036C05
		public int AnimatorStateID
		{
			get
			{
				return this._AnimatorStateID;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00038A0D File Offset: 0x00036C0D
		public int AnimatorTransitionID
		{
			get
			{
				return this._AnimatorTransitionID;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00038A15 File Offset: 0x00036C15
		public float AnimatorStateNormalizedTime
		{
			get
			{
				return this._AnimatorStateNormalizedTime;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x00038A1D File Offset: 0x00036C1D
		public float AnimatorTransitionNormalizedTime
		{
			get
			{
				return this._AnimatorTransitionNormalizedTime;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x00038A25 File Offset: 0x00036C25
		public string AnimatorLayerName
		{
			get
			{
				return this.mAnimatorLayerName;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00038A2D File Offset: 0x00036C2D
		public MotionControllerMotion ActiveMotion
		{
			get
			{
				return this.mActiveMotion;
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x00038A35 File Offset: 0x00036C35
		public MotionControllerMotion PrevActiveMotion
		{
			get
			{
				return this.mPrevActiveMotion;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x00038A3D File Offset: 0x00036C3D
		public float ActiveMotionDuration
		{
			get
			{
				return this.mActiveMotionDuration;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x00038A45 File Offset: 0x00036C45
		public int ActiveMotionPhase
		{
			get
			{
				if (this.mActiveMotion != null)
				{
					return this.mActiveMotion.Phase;
				}
				return 0;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00038A5C File Offset: 0x00036C5C
		public Vector3 Velocity
		{
			get
			{
				return this.mVelocity;
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x00038A64 File Offset: 0x00036C64
		public Vector3 Movement
		{
			get
			{
				return this.mMovement;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00038A6C File Offset: 0x00036C6C
		public Vector3 AngularVelocity
		{
			get
			{
				return this.mAngularVelocity;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x00038A74 File Offset: 0x00036C74
		public Quaternion Rotation
		{
			get
			{
				return this.mRotation;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00038A7C File Offset: 0x00036C7C
		public Quaternion Tilt
		{
			get
			{
				return this.mTilt;
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x00038A84 File Offset: 0x00036C84
		public bool UseTrendData
		{
			get
			{
				bool flag = true;
				if (this.mActiveMotion != null)
				{
					flag = this.mActiveMotion.UseTrendData;
				}
				return flag;
			}
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x00038AA8 File Offset: 0x00036CA8
		public MotionControllerLayer()
		{
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x00038B14 File Offset: 0x00036D14
		public MotionControllerLayer(MotionController rController)
		{
			this.mMotionController = rController;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x00038B88 File Offset: 0x00036D88
		public MotionControllerLayer(string rName, MotionController rController)
		{
			this._Name = rName;
			this.mMotionController = rController;
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x00038C04 File Offset: 0x00036E04
		public void Awake()
		{
			if (this.mMotionController != null && this.mMotionController.Animator != null)
			{
				this.mAnimatorLayerName = this.mMotionController.Animator.GetLayerName(this._AnimatorLayerIndex);
			}
			for (int i = 0; i < this.Motions.Count; i++)
			{
				this.Motions[i].MotionLayer = this;
				this.Motions[i].Awake();
			}
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x00038C87 File Offset: 0x00036E87
		public void AddMotion(MotionControllerMotion rMotion)
		{
			if (!this.Motions.Contains(rMotion))
			{
				rMotion.MotionController = this.mMotionController;
				rMotion.MotionLayer = this;
				this.Motions.Add(rMotion);
			}
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00038CB6 File Offset: 0x00036EB6
		public void RemoveMotion(MotionControllerMotion rMotion)
		{
			this.Motions.Remove(rMotion);
			rMotion.MotionController = null;
			rMotion.MotionLayer = null;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x00038CD3 File Offset: 0x00036ED3
		public bool QueueMotion(MotionControllerMotion rMotion, int rParameter = 0)
		{
			if (!this.Motions.Contains(rMotion))
			{
				return false;
			}
			if (this.mActiveMotion == rMotion && this.mActiveMotion.IsActive)
			{
				return false;
			}
			rMotion.Parameter = rParameter;
			rMotion.QueueActivation = true;
			return true;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00038D0C File Offset: 0x00036F0C
		public void LoadAnimatorData()
		{
			this.InstanciateMotions();
			int count = this.Motions.Count;
			for (int i = 0; i < count; i++)
			{
				this.Motions[i].LoadAnimatorData();
			}
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00038D48 File Offset: 0x00036F48
		public void FixedUpdateMotions(float rDeltaTime)
		{
			if (this.mActiveMotion != null)
			{
				this.mActiveMotion.FixedUpdate(rDeltaTime);
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00038D5E File Offset: 0x00036F5E
		public void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
			if (this.mActiveMotion != null)
			{
				this.mActiveMotion.UpdateRootMotion(rDeltaTime, rUpdateIndex, ref rMovement, ref rRotation);
			}
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00038D78 File Offset: 0x00036F78
		public void UpdateMotions(float rDeltaTime, int rUpdateIndex)
		{
			int num = -1;
			float num2 = float.MinValue;
			MotionControllerMotion motionControllerMotion = this.mActiveMotion;
			this._AnimatorStateID = this.mMotionController.State.AnimatorStates[this._AnimatorLayerIndex].StateInfo.fullPathHash;
			this._AnimatorStateNormalizedTime = this.mMotionController.State.AnimatorStates[this._AnimatorLayerIndex].StateInfo.normalizedTime;
			this._AnimatorTransitionID = this.mMotionController.State.AnimatorStates[this._AnimatorLayerIndex].TransitionInfo.fullPathHash;
			this._AnimatorTransitionNormalizedTime = this.mMotionController.State.AnimatorStates[this._AnimatorLayerIndex].TransitionInfo.normalizedTime;
			this.mActiveMotionDuration += Time.deltaTime;
			if (this.mActiveMotion != null)
			{
				this.mActiveMotion.IsActivatedFrame = false;
				if (!this.mActiveMotion.TestUpdate())
				{
					this.mRunDeactivatedUpdate = true;
					this.mPrevActiveMotion = this.mActiveMotion;
					this.mActiveMotion.Deactivate();
					this.mActiveMotion = null;
				}
			}
			if (rUpdateIndex == 1 && (this.mActiveMotion == null || this.mActiveMotion.IsInterruptible))
			{
				bool flag = false;
				for (int i = 0; i < this.Motions.Count; i++)
				{
					MotionControllerMotion motionControllerMotion2 = this.Motions[i];
					motionControllerMotion2.IsActivatedFrame = false;
					if (motionControllerMotion2.IsEnabled && Time.time - motionControllerMotion2.DeactivationTime >= 0.001f && (motionControllerMotion2.ReactivationDelay <= 0f || motionControllerMotion2.DeactivationTime + motionControllerMotion2.ReactivationDelay <= Time.time))
					{
						if (motionControllerMotion2.QueueActivation && (this.mActiveMotion == null || this.mActiveMotion.TestInterruption(this.Motions[i])))
						{
							if (this._AnimatorTransitionID == 0)
							{
								flag = true;
								num = i;
								num2 = motionControllerMotion2.Priority;
								motionControllerMotion2.QueueActivation = false;
								break;
							}
							break;
						}
						else if (motionControllerMotion2 == this.mActiveMotion)
						{
							if (this.mActiveMotion.Priority >= num2)
							{
								num = i;
								num2 = this.mActiveMotion.Priority;
							}
						}
						else if (motionControllerMotion2.IsStartable)
						{
							bool flag2 = motionControllerMotion2.TestActivate();
							if (flag2 && this.mMotionController.MotionActivatedEvent != null)
							{
								MotionMessage motionMessage = MotionMessage.Allocate();
								motionMessage.ID = EnumMessageID.MSG_MOTION_TEST;
								motionMessage.Motion = motionControllerMotion2;
								motionMessage.Continue = true;
								motionMessage.Data = motionControllerMotion;
								this.mMotionController.MotionTestActivateEvent.Invoke(motionMessage);
								flag2 = motionMessage.Continue;
								MotionMessage.Release(motionMessage);
							}
							if (flag2 && this.mMotionController._ActorCore != null)
							{
								MotionMessage motionMessage2 = MotionMessage.Allocate();
								motionMessage2.ID = EnumMessageID.MSG_MOTION_TEST;
								motionMessage2.Motion = motionControllerMotion2;
								motionMessage2.Continue = true;
								motionMessage2.Data = motionControllerMotion;
								this.mMotionController._ActorCore.SendMessage(motionMessage2);
								flag2 = motionMessage2.Continue;
								MotionMessage.Release(motionMessage2);
							}
							if (flag2 && motionControllerMotion2.Priority >= num2)
							{
								num = i;
								num2 = motionControllerMotion2.Priority;
							}
						}
					}
				}
				if (num >= 0 && num < this.Motions.Count)
				{
					if (!flag && this.mActiveMotion != null)
					{
						if (this.mActiveMotion == this.Motions[num])
						{
							num = -1;
						}
						else if (this.mActiveMotion.Priority > num2)
						{
							num = -1;
						}
						else if (this.mActiveMotion.IsActive && !this.mActiveMotion.TestInterruption(this.Motions[num]))
						{
							num = -1;
						}
					}
					if (num >= 0)
					{
						if (this.mActiveMotion != null && this.mActiveMotion.IsActive && this.mActiveMotion != this.Motions[num])
						{
							this.mRunDeactivatedUpdate = true;
							this.mPrevActiveMotion = this.mActiveMotion;
							this.mActiveMotion.Deactivate();
						}
						if (this.mActiveMotion != this.Motions[num])
						{
							this.Motions[num].Activate(motionControllerMotion);
						}
						this.mActiveMotion = this.Motions[num];
						this.mActiveMotionDuration = 0f;
					}
				}
			}
			if (this.mRunDeactivatedUpdate && this.mPrevActiveMotion != null)
			{
				this.mRunDeactivatedUpdate = this.mPrevActiveMotion.DeactivatedUpdate(rDeltaTime, rUpdateIndex);
			}
			for (int j = 0; j < this.Motions.Count; j++)
			{
				if (this.Motions[j].IsActive)
				{
					this.Motions[j].UpdateMotion(rDeltaTime, rUpdateIndex);
					if (this.mActiveMotion == null && this.Motions[j].IsActive)
					{
						this.mActiveMotion = this.Motions[j];
						this.mActiveMotionDuration = 0f;
					}
				}
			}
			if (this.mActiveMotion != null && !this.mActiveMotion.IsActive)
			{
				this.mActiveMotion = null;
				this.mActiveMotionDuration = 0f;
			}
			this.mAngularVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mTilt = Quaternion.identity;
			this.mVelocity = Vector3.zero;
			this.mMovement = Vector3.zero;
			for (int k = 0; k < this.Motions.Count; k++)
			{
				if (this.Motions[k].IsActive)
				{
					this.mAngularVelocity += this.Motions[k].AngularVelocity;
					this.mRotation *= this.Motions[k].Rotation;
					this.mTilt *= this.Motions[k].Tilt;
					this.mVelocity += this.Motions[k].Velocity;
					this.mMovement += this.Motions[k].Movement;
				}
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00039390 File Offset: 0x00037590
		public void OnAnimatorStateChange(int rAnimatorLayer, int rLastStateID, int rNewStateID)
		{
			for (int i = 0; i < this.Motions.Count; i++)
			{
				if (this.Motions[i].IsActive)
				{
					this.Motions[i].OnAnimatorStateChange(rLastStateID, rNewStateID);
				}
			}
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x000393DC File Offset: 0x000375DC
		public void OnAnimationEvent(AnimationEvent rEvent)
		{
			for (int i = 0; i < this.Motions.Count; i++)
			{
				if (this.Motions[i].IsActive)
				{
					this.Motions[i].OnAnimationEvent(rEvent);
				}
			}
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00039424 File Offset: 0x00037624
		public void OnMessageReceived(IMessage rMessage)
		{
			for (int i = 0; i < this.Motions.Count; i++)
			{
				if (this.Motions[i].IsEnabled)
				{
					this.Motions[i].OnMessageReceived(rMessage);
					if (rMessage.IsHandled)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00039474 File Offset: 0x00037674
		public void OnDrawGizmos()
		{
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00039478 File Offset: 0x00037678
		public void InstanciateMotions()
		{
			int count = this.Motions.Count;
			int count2 = this.MotionDefinitions.Count;
			for (int i = count - 1; i >= count2; i--)
			{
				this.Motions.RemoveAt(i);
			}
			for (int j = 0; j < count2; j++)
			{
				string text = this.MotionDefinitions[j];
				JSONNode jsonnode = JSONNode.Parse(text);
				if (!(jsonnode == null))
				{
					string value = jsonnode["Type"].Value;
					Type type = Type.GetType(value);
					if (!(type == null))
					{
						float num = 0f;
						MotionControllerMotion motionControllerMotion;
						if (this.Motions.Count <= j || value != this.Motions[j].GetType().AssemblyQualifiedName)
						{
							motionControllerMotion = Activator.CreateInstance(type) as MotionControllerMotion;
							motionControllerMotion.MotionController = this.mMotionController;
							motionControllerMotion.MotionLayer = this;
							if (this.Motions.Count <= j)
							{
								this.Motions.Add(motionControllerMotion);
							}
							else
							{
								this.Motions[j] = motionControllerMotion;
							}
						}
						else
						{
							motionControllerMotion = this.Motions[j];
							num = motionControllerMotion.Priority;
						}
						if (motionControllerMotion != null)
						{
							motionControllerMotion.DeserializeMotion(text);
							if (num > 0f)
							{
								motionControllerMotion.Priority = num;
							}
							this.MotionDefinitions[j] = motionControllerMotion.SerializeMotion();
						}
					}
				}
			}
			for (int k = 0; k < this.Motions.Count; k++)
			{
				this.Motions[k].Awake();
				this.Motions[k].Initialize();
			}
		}

		// Token: 0x04000639 RID: 1593
		private int mIndex;

		// Token: 0x0400063A RID: 1594
		private MotionController mMotionController;

		// Token: 0x0400063B RID: 1595
		public bool _IgnoreMotionOverride;

		// Token: 0x0400063C RID: 1596
		public int _AnimatorLayerIndex;

		// Token: 0x0400063D RID: 1597
		[NonSerialized]
		public int _AnimatorStateID;

		// Token: 0x0400063E RID: 1598
		[NonSerialized]
		public int _AnimatorTransitionID;

		// Token: 0x0400063F RID: 1599
		[NonSerialized]
		public float _AnimatorStateNormalizedTime;

		// Token: 0x04000640 RID: 1600
		[NonSerialized]
		public float _AnimatorTransitionNormalizedTime;

		// Token: 0x04000641 RID: 1601
		public List<MotionControllerMotion> Motions = new List<MotionControllerMotion>();

		// Token: 0x04000642 RID: 1602
		public List<string> MotionDefinitions = new List<string>();

		// Token: 0x04000643 RID: 1603
		private string mAnimatorLayerName = "";

		// Token: 0x04000644 RID: 1604
		private MotionControllerMotion mActiveMotion;

		// Token: 0x04000645 RID: 1605
		private MotionControllerMotion mPrevActiveMotion;

		// Token: 0x04000646 RID: 1606
		private float mActiveMotionDuration;

		// Token: 0x04000647 RID: 1607
		private Vector3 mVelocity = Vector3.zero;

		// Token: 0x04000648 RID: 1608
		private Vector3 mMovement = Vector3.zero;

		// Token: 0x04000649 RID: 1609
		private Vector3 mAngularVelocity = Vector3.zero;

		// Token: 0x0400064A RID: 1610
		private Quaternion mRotation = Quaternion.identity;

		// Token: 0x0400064B RID: 1611
		private Quaternion mTilt = Quaternion.identity;

		// Token: 0x0400064C RID: 1612
		protected bool mRunDeactivatedUpdate;
	}
}

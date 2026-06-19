using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using com.ootii.Base;
using com.ootii.Data.Serializers;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Messages;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E9 RID: 233
	public abstract class MotionControllerMotion : BaseObject, IMotionControllerMotion
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0003961F File Offset: 0x0003781F
		public string Key
		{
			get
			{
				return this._Key;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00039627 File Offset: 0x00037827
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x0003962F File Offset: 0x0003782F
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00039638 File Offset: 0x00037838
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x00039640 File Offset: 0x00037840
		public int Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				this._Category = value;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x00039649 File Offset: 0x00037849
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x00039651 File Offset: 0x00037851
		public string Pack
		{
			get
			{
				return this._Pack;
			}
			set
			{
				this._Pack = value;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0003965A File Offset: 0x0003785A
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x00039662 File Offset: 0x00037862
		public int Form
		{
			get
			{
				return this._Form;
			}
			set
			{
				this._Form = value;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0003966B File Offset: 0x0003786B
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x00039673 File Offset: 0x00037873
		public MotionController MotionController
		{
			get
			{
				return this.mMotionController;
			}
			set
			{
				this.mMotionController = value;
				this.mActorController = ((this.mMotionController != null) ? this.mMotionController.ActorController : null);
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x0003969E File Offset: 0x0003789E
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x000396A6 File Offset: 0x000378A6
		public MotionControllerLayer MotionLayer
		{
			get
			{
				return this.mMotionLayer;
			}
			set
			{
				this.mMotionLayer = value;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x000396AF File Offset: 0x000378AF
		// (set) Token: 0x06000BFD RID: 3069 RVA: 0x000396B7 File Offset: 0x000378B7
		public float Priority
		{
			get
			{
				return this._Priority;
			}
			set
			{
				this._Priority = value;
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x000396C0 File Offset: 0x000378C0
		// (set) Token: 0x06000BFF RID: 3071 RVA: 0x000396C8 File Offset: 0x000378C8
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x000396D1 File Offset: 0x000378D1
		// (set) Token: 0x06000C01 RID: 3073 RVA: 0x000396D9 File Offset: 0x000378D9
		public bool OverrideLayers
		{
			get
			{
				return this._OverrideLayers;
			}
			set
			{
				this._OverrideLayers = value;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x000396E2 File Offset: 0x000378E2
		// (set) Token: 0x06000C03 RID: 3075 RVA: 0x00039708 File Offset: 0x00037908
		public bool ShowDebug
		{
			get
			{
				return this.mMotionController.ShowDebug && (this.mMotionController.ShowDebugForAllMotions || this._ShowDebug);
			}
			set
			{
				this._ShowDebug = value;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x00039711 File Offset: 0x00037911
		// (set) Token: 0x06000C05 RID: 3077 RVA: 0x00039719 File Offset: 0x00037919
		public string ActionAlias
		{
			get
			{
				return this._ActionAlias;
			}
			set
			{
				this._ActionAlias = value;
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x00039722 File Offset: 0x00037922
		public bool IsActive
		{
			get
			{
				return this.mIsActive;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x0003972A File Offset: 0x0003792A
		// (set) Token: 0x06000C08 RID: 3080 RVA: 0x00039732 File Offset: 0x00037932
		public bool IsAnimatorActive
		{
			get
			{
				return this.mIsAnimatorActive;
			}
			set
			{
				this.mIsAnimatorActive = value;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x0003973B File Offset: 0x0003793B
		// (set) Token: 0x06000C0A RID: 3082 RVA: 0x00039743 File Offset: 0x00037943
		public bool IsInSubStateMachine
		{
			get
			{
				return this.mIsInSubStateMachine;
			}
			set
			{
				this.mIsInSubStateMachine = value;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0003974C File Offset: 0x0003794C
		public float Age
		{
			get
			{
				return this.mAge;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x00039754 File Offset: 0x00037954
		public float StateNormalizedTime
		{
			get
			{
				return this.mMotionLayer._AnimatorStateNormalizedTime;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x00039761 File Offset: 0x00037961
		public bool IsStartable
		{
			get
			{
				return this.mIsStartable;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x00039769 File Offset: 0x00037969
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x00039771 File Offset: 0x00037971
		public int Phase
		{
			get
			{
				return this.mPhase;
			}
			set
			{
				this.mPhase = value;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x0003977A File Offset: 0x0003797A
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x00039782 File Offset: 0x00037982
		public int Parameter
		{
			get
			{
				return this.mParameter;
			}
			set
			{
				this.mParameter = value;
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0003978B File Offset: 0x0003798B
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x00039793 File Offset: 0x00037993
		public bool IsInterruptible
		{
			get
			{
				return this.mIsInterruptible;
			}
			set
			{
				this.mIsInterruptible = value;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x0003979C File Offset: 0x0003799C
		// (set) Token: 0x06000C15 RID: 3093 RVA: 0x000397A4 File Offset: 0x000379A4
		public bool QueueActivation
		{
			get
			{
				return this.mQueueActivation;
			}
			set
			{
				this.mQueueActivation = value;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x000397AD File Offset: 0x000379AD
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x000397B5 File Offset: 0x000379B5
		public float ReactivationDelay
		{
			get
			{
				return this._ReactivationDelay;
			}
			set
			{
				this._ReactivationDelay = value;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x000397BE File Offset: 0x000379BE
		public float DeactivationTime
		{
			get
			{
				return this.mDeactivationTime;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x000397C6 File Offset: 0x000379C6
		// (set) Token: 0x06000C1A RID: 3098 RVA: 0x000397CE File Offset: 0x000379CE
		public bool IsActivatedFrame
		{
			get
			{
				return this.mIsActivatedFrame;
			}
			set
			{
				this.mIsActivatedFrame = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x000397D7 File Offset: 0x000379D7
		// (set) Token: 0x06000C1C RID: 3100 RVA: 0x000397DF File Offset: 0x000379DF
		public bool UseTrendData
		{
			get
			{
				return this.mUseTrendData;
			}
			set
			{
				this.mUseTrendData = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x000397E8 File Offset: 0x000379E8
		public Vector3 Velocity
		{
			get
			{
				return this.mVelocity;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x000397F0 File Offset: 0x000379F0
		public Vector3 Movement
		{
			get
			{
				return this.mMovement;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000C1F RID: 3103 RVA: 0x000397F8 File Offset: 0x000379F8
		public Vector3 AngularVelocity
		{
			get
			{
				return this.mAngularVelocity;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x00039800 File Offset: 0x00037A00
		public Quaternion Rotation
		{
			get
			{
				return this.mRotation;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00039808 File Offset: 0x00037A08
		public Quaternion Tilt
		{
			get
			{
				return this.mTilt;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x00039810 File Offset: 0x00037A10
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x00039818 File Offset: 0x00037A18
		public virtual bool IsFixedUpdateEnabled
		{
			get
			{
				return this._IsFixedUpdateEnabled;
			}
			set
			{
				this._IsFixedUpdateEnabled = value;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x00039821 File Offset: 0x00037A21
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00039829 File Offset: 0x00037A29
		public virtual float FixedUpdateFPS
		{
			get
			{
				return this._FixedUpdateFPS;
			}
			set
			{
				this._FixedUpdateFPS = value;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00039832 File Offset: 0x00037A32
		public string[] Tags
		{
			get
			{
				if (this.mTags == null)
				{
					return null;
				}
				return this.mTags.Keys.ToArray<string>();
			}
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00039850 File Offset: 0x00037A50
		public MotionControllerMotion()
		{
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00039900 File Offset: 0x00037B00
		public MotionControllerMotion(string rGUID)
		{
			this._GUID = rGUID;
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x000399B8 File Offset: 0x00037BB8
		public MotionControllerMotion(MotionController rController)
		{
			this.MotionController = rController;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00039A70 File Offset: 0x00037C70
		public virtual void Awake()
		{
			if (this.mMotionController != null)
			{
				Animator animator = this.mMotionController.Animator;
				if (animator != null)
				{
					MotionControllerBehaviour[] behaviours = animator.GetBehaviours<MotionControllerBehaviour>();
					for (int i = 0; i < behaviours.Length; i++)
					{
						if (behaviours[i].MotionKey == ((this._Key.Length > 0) ? this._Key : base.GetType().FullName))
						{
							behaviours[i].AddMotion(this);
						}
					}
				}
			}
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00039AEE File Offset: 0x00037CEE
		public virtual void Initialize()
		{
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00039AF0 File Offset: 0x00037CF0
		public virtual void LoadAnimatorData()
		{
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00039AF2 File Offset: 0x00037CF2
		public virtual bool TestActivate()
		{
			return false;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00039AF5 File Offset: 0x00037CF5
		public virtual bool ExternalTestActivate()
		{
			return true;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00039AF8 File Offset: 0x00037CF8
		public virtual bool TestUpdate()
		{
			return true;
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00039AFB File Offset: 0x00037CFB
		public virtual bool TestInterruption(MotionControllerMotion rMotion)
		{
			return true;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00039B00 File Offset: 0x00037D00
		public virtual bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mIsActive = true;
			this.mIsAnimatorActive = false;
			this.mIsInSubStateMachine = false;
			this.mAge = 0f;
			if (this.OnActivatedEvent != null)
			{
				this.OnActivatedEvent(this.mMotionLayer._AnimatorLayerIndex, this);
			}
			if (this.mMotionController.MotionActivated != null)
			{
				this.mMotionController.MotionActivated(this.mMotionLayer._AnimatorLayerIndex, this, rPrevMotion);
			}
			MotionMessage motionMessage = MotionMessage.Allocate();
			motionMessage.ID = EnumMessageID.MSG_MOTION_ACTIVATE;
			motionMessage.Motion = this;
			motionMessage.Data = rPrevMotion;
			if (this.mMotionController.MotionActivatedEvent != null)
			{
				this.mMotionController.MotionActivatedEvent.Invoke(motionMessage);
			}
			if (this.mMotionController._ActorCore != null)
			{
				this.mMotionController._ActorCore.SendMessage(motionMessage);
			}
			MotionMessage.Release(motionMessage);
			return true;
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00039BD8 File Offset: 0x00037DD8
		public virtual bool Interrupt(object rParameter)
		{
			return true;
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00039BDC File Offset: 0x00037DDC
		public virtual void Deactivate()
		{
			this.mIsActive = false;
			this.mIsStartable = true;
			this.mMovement = Vector3.zero;
			this.mVelocity = Vector3.zero;
			this.mRotation = Quaternion.identity;
			this.mAngularVelocity = Vector3.zero;
			this.mDeactivationTime = Time.time;
			this.mIsAnimatorActive = false;
			this.mIsInSubStateMachine = false;
			if (this.OnDeactivatedEvent != null)
			{
				this.OnDeactivatedEvent(this.mMotionLayer._AnimatorLayerIndex, this);
			}
			if (this.mMotionController.MotionDeactivated != null)
			{
				this.mMotionController.MotionDeactivated(this.mMotionLayer._AnimatorLayerIndex, this);
			}
			MotionMessage motionMessage = MotionMessage.Allocate();
			motionMessage.ID = EnumMessageID.MSG_MOTION_DEACTIVATE;
			motionMessage.Motion = this;
			if (this.mMotionController.MotionDeactivatedEvent != null)
			{
				this.mMotionController.MotionDeactivatedEvent.Invoke(motionMessage);
			}
			if (this.mMotionController._ActorCore != null)
			{
				this.mMotionController._ActorCore.SendMessage(motionMessage);
			}
			MotionMessage.Release(motionMessage);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00039CE0 File Offset: 0x00037EE0
		public void UpdateMotion(float rDeltaTime, int rUpdateIndex)
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (this.mIsAnimatorActive && this.mMotionLayer._AnimatorTransitionID == 0)
			{
				this.mIsInSubStateMachine = true;
			}
			if (this.mActorController._IsFixedUpdateEnabled)
			{
				this.Update(rDeltaTime, rUpdateIndex);
				if (this.mMotionController.MotionUpdated != null)
				{
					this.mMotionController.MotionUpdated(rDeltaTime, rUpdateIndex, this.mMotionLayer._AnimatorLayerIndex, this);
				}
				return;
			}
			int num = 0;
			float num2 = rDeltaTime;
			if (!this._IsFixedUpdateEnabled || this._FixedUpdateFPS <= 0f)
			{
				num = 1;
			}
			else
			{
				num2 = 1f / this._FixedUpdateFPS;
				if (Mathf.Abs(num2 - rDeltaTime) < num2 * 0.1f)
				{
					num = 1;
				}
				else
				{
					this.mFixedElapsedTime += rDeltaTime;
					while (this.mFixedElapsedTime >= num2)
					{
						num++;
						this.mFixedElapsedTime -= num2;
						if (num >= 5)
						{
							this.mFixedElapsedTime = 0f;
							break;
						}
					}
				}
			}
			this.mAge += rDeltaTime;
			if (num > 0)
			{
				for (int i = 1; i <= num; i++)
				{
					this.Update(num2, i);
					if (this.mMotionController.MotionUpdated != null)
					{
						this.mMotionController.MotionUpdated(num2, i, this.mMotionLayer._AnimatorLayerIndex, this);
					}
					this.mIsFirstUpdate = false;
				}
				return;
			}
			this.Update(num2, num);
			if (this.mMotionController.MotionUpdated != null)
			{
				this.mMotionController.MotionUpdated(num2, num, this.mMotionLayer._AnimatorLayerIndex, this);
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00039E5A File Offset: 0x0003805A
		public virtual void FixedUpdate(float rDeltaTime)
		{
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00039E5C File Offset: 0x0003805C
		public virtual void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00039E5E File Offset: 0x0003805E
		public virtual void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00039E60 File Offset: 0x00038060
		public virtual bool DeactivatedUpdate(float rDeltaTime, int rUpdateIndex)
		{
			return false;
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00039E64 File Offset: 0x00038064
		protected virtual void ClearReachData()
		{
			if (this.mReachData == null)
			{
				this.mReachData = new List<MotionReachData>();
			}
			for (int i = 0; i < this.mReachData.Count; i++)
			{
				MotionReachData.Release(this.mReachData[i]);
			}
			this.mReachData.Clear();
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00039EB8 File Offset: 0x000380B8
		protected virtual Vector3 GetReachMovement(Vector3 rTarget, Vector3 rPosition, float rStart, float rEnd = 1f, bool rStay = true, bool rTest = true, bool rX = true, bool rY = true, bool rZ = true)
		{
			Vector3 vector = Vector3.zero;
			if (rTest && this.mMotionLayer._AnimatorStateNormalizedTime > rStart && (this.mMotionLayer._AnimatorStateNormalizedTime < rEnd || rStay))
			{
				float num = (this.mMotionLayer._AnimatorStateNormalizedTime - rStart) / (rEnd - rStart);
				if (num < 0f)
				{
					num = 0f;
				}
				else if (num > 1f)
				{
					num = 1f;
				}
				if (num <= 0f)
				{
					vector = Vector3.zero;
				}
				else if (num >= 1f)
				{
					vector = rTarget - rPosition;
				}
				else
				{
					vector = (rTarget - rPosition) * num;
				}
				if (!rX)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.right);
				}
				if (!rY)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.up);
				}
				if (!rZ)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.forward);
				}
			}
			return vector;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00039FC0 File Offset: 0x000381C0
		protected virtual Vector3 GetReachMovement(Vector3 rTarget, Vector3 rPosition, float rPercent = 1f, bool rTest = true, bool rX = true, bool rY = true, bool rZ = true)
		{
			Vector3 vector = Vector3.zero;
			if (rTest)
			{
				if (rPercent <= 0f)
				{
					vector = Vector3.zero;
				}
				else if (rPercent >= 1f)
				{
					vector = rTarget - rPosition;
				}
				else
				{
					vector = (rTarget - rPosition) * rPercent;
				}
				if (!rX)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.right);
				}
				if (!rY)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.up);
				}
				if (!rZ)
				{
					vector -= Vector3.Project(vector, this.mMotionController._Transform.forward);
				}
			}
			return vector;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0003A070 File Offset: 0x00038270
		protected virtual Vector3 GetReachMovement()
		{
			Vector3 vector = Vector3.zero;
			if (this.mReachData != null)
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				float animatorTransitionNormalizedTime = this.mMotionLayer._AnimatorTransitionNormalizedTime;
				for (int i = 0; i < this.mReachData.Count; i++)
				{
					if (!this.mReachData[i].IsComplete)
					{
						if (this.mReachData[i].StateID == animatorStateID && animatorStateNormalizedTime >= this.mReachData[i].StartTime)
						{
							float num = (animatorStateNormalizedTime - this.mReachData[i].StartTime) / (this.mReachData[i].EndTime - this.mReachData[i].StartTime);
							if (animatorStateNormalizedTime >= this.mReachData[i].EndTime)
							{
								num = 1f;
								this.mReachData[i].IsComplete = true;
							}
							Vector3 position = this.mActorController._Transform.position;
							Vector3 vector2 = this.mReachData[i].ReachTarget - position;
							vector += vector2 * NumberHelper.Pow(num, this.mReachData[i].Power);
						}
						else if (this.mReachData[i].TransitionID == animatorTransitionID && animatorTransitionNormalizedTime >= this.mReachData[i].StartTime)
						{
							float num2 = (animatorTransitionNormalizedTime - this.mReachData[i].StartTime) / (this.mReachData[i].EndTime - this.mReachData[i].StartTime);
							if (animatorTransitionNormalizedTime >= this.mReachData[i].EndTime)
							{
								num2 = 1f;
								this.mReachData[i].IsComplete = true;
							}
							Vector3 position2 = this.mActorController._Transform.position;
							Vector3 vector3 = this.mReachData[i].ReachTarget - position2;
							vector += vector3 * NumberHelper.Pow(num2, this.mReachData[i].Power);
						}
					}
				}
			}
			return vector;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0003A2E0 File Offset: 0x000384E0
		protected virtual Quaternion GetReachRotation(float rStartTime, float rEndTime, float rTotalAngle, ref float rUsedAngle)
		{
			Quaternion quaternion = Quaternion.identity;
			if (rUsedAngle != rTotalAngle)
			{
				float animatorStateNormalizedTime = this.mMotionLayer._AnimatorStateNormalizedTime;
				if (animatorStateNormalizedTime > rStartTime && animatorStateNormalizedTime <= rEndTime)
				{
					float num = (animatorStateNormalizedTime - rStartTime) / (rEndTime - rStartTime);
					quaternion = Quaternion.AngleAxis(rTotalAngle * num - rUsedAngle, Vector3.up);
					rUsedAngle = rTotalAngle * num;
				}
				else if (animatorStateNormalizedTime > rEndTime)
				{
					quaternion = Quaternion.AngleAxis(rTotalAngle - rUsedAngle, Vector3.up);
					rUsedAngle = rTotalAngle;
				}
			}
			return quaternion;
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x0003A348 File Offset: 0x00038548
		public virtual void OnAnimatorIK(Animator rAnimator, int rLayer)
		{
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x0003A34A File Offset: 0x0003854A
		public virtual void OnAnimatorStateChange(int rLastStateID, int rNewStateID)
		{
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0003A34C File Offset: 0x0003854C
		public virtual void OnAnimationEvent(AnimationEvent rEvent)
		{
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x0003A34E File Offset: 0x0003854E
		public virtual void OnMessageReceived(IMessage rMessage)
		{
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0003A350 File Offset: 0x00038550
		public virtual bool HasAutoGeneratedCode
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x0003A353 File Offset: 0x00038553
		public virtual bool VerifyTransition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0003A356 File Offset: 0x00038556
		public virtual int GetStateID(string rState)
		{
			return Animator.StringToHash(string.Format("{0}.{1}.{2}", this.mMotionLayer.AnimatorLayerName, this._EditorAnimatorSMName, rState));
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0003A379 File Offset: 0x00038579
		public virtual int GetAnyStateTransitionID(string rEndState)
		{
			return Animator.StringToHash(string.Format("AnyState -> {0}.{1}.{2}", this.mMotionLayer.AnimatorLayerName, this._EditorAnimatorSMName, rEndState));
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0003A39C File Offset: 0x0003859C
		public virtual int GetEntryTransitionID(string rEndState)
		{
			return Animator.StringToHash(string.Format("Entry -> {0}.{1}.{2}", this.mMotionLayer.AnimatorLayerName, this._EditorAnimatorSMName, rEndState));
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0003A3BF File Offset: 0x000385BF
		public virtual int GetTransitionID(string rStartState, string rEndState)
		{
			return Animator.StringToHash(string.Format("{0}.{1}.{2} -> {0}.{1}.{3}", new object[]
			{
				this.mMotionLayer.AnimatorLayerName,
				this._EditorAnimatorSMName,
				rStartState,
				rEndState
			}));
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x0003A3F5 File Offset: 0x000385F5
		public virtual bool IsInMotionState
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0003A3F8 File Offset: 0x000385F8
		public virtual bool IsMotionState(int rState)
		{
			return false;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0003A3FB File Offset: 0x000385FB
		public virtual bool IsMotionState(int rStateID, int rTransitionID)
		{
			return false;
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0003A3FE File Offset: 0x000385FE
		public virtual bool TagExists(string rTag)
		{
			return this.mTags != null && rTag != null && rTag.Length != 0 && this.mTags.ContainsKey(rTag);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0003A424 File Offset: 0x00038624
		public virtual void AddTag(string rTag)
		{
			if (rTag == null || rTag.Length == 0)
			{
				return;
			}
			if (this.mTags == null)
			{
				this.mTags = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
			}
			if (this.mTags.ContainsKey(rTag))
			{
				return;
			}
			this.mTags.Add(rTag, 0);
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0003A471 File Offset: 0x00038671
		public virtual void RemoveTag(string rTag)
		{
			if (this.mTags == null)
			{
				return;
			}
			if (rTag == null || rTag.Length == 0)
			{
				return;
			}
			this.mTags.Remove(rTag);
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x0003A498 File Offset: 0x00038698
		public virtual string SerializeMotion()
		{
			if (this._Type.Length == 0)
			{
				this._Type = base.GetType().AssemblyQualifiedName;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append(", \"Type\" : \"" + this._Type + "\"");
			stringBuilder.Append(", \"Name\" : \"" + this._Name + "\"");
			stringBuilder.Append(", \"Form\" : \"" + this._Form.ToString() + "\"");
			stringBuilder.Append(", \"Priority\" : \"" + this._Priority.ToString() + "\"");
			stringBuilder.Append(", \"OverrideLayers\" : \"" + this._OverrideLayers.ToString() + "\"");
			stringBuilder.Append(", \"ActionAlias\" : \"" + this._ActionAlias.ToString() + "\"");
			stringBuilder.Append(", \"IsEnabled\" : \"" + this._IsEnabled.ToString() + "\"");
			stringBuilder.Append(", \"ReactivationDelay\" : \"" + this._ReactivationDelay.ToString() + "\"");
			stringBuilder.Append(", \"ShowDebug\" : \"" + this._ShowDebug.ToString() + "\"");
			stringBuilder.Append(", \"Category\" : \"" + this._Category.ToString() + "\"");
			stringBuilder.Append(", \"Pack\" : \"" + this._Pack + "\"");
			string text = "";
			if (this.mTags != null)
			{
				text = string.Join("|", this.mTags.Keys.ToArray<string>());
			}
			stringBuilder.Append(", \"Tags\" : \"" + text + "\"");
			PropertyInfo[] properties = typeof(MotionControllerMotion).GetProperties();
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite && !ReflectionHelper.IsDefined(propertyInfo, typeof(SerializationIgnoreAttribute)))
				{
					bool flag = true;
					for (int j = 0; j < properties.Length; j++)
					{
						if (propertyInfo.Name == properties[j].Name)
						{
							flag = false;
							break;
						}
					}
					if (flag && propertyInfo.GetValue(this, null) != null)
					{
						object value = propertyInfo.GetValue(this, null);
						if (propertyInfo.PropertyType == typeof(Vector2))
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								", \"",
								propertyInfo.Name,
								"\" : \"",
								((Vector2)value).ToString("G8"),
								"\""
							}));
						}
						else if (propertyInfo.PropertyType == typeof(Vector3))
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								", \"",
								propertyInfo.Name,
								"\" : \"",
								((Vector3)value).ToString("G8"),
								"\""
							}));
						}
						else if (propertyInfo.PropertyType == typeof(Vector4))
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								", \"",
								propertyInfo.Name,
								"\" : \"",
								((Vector4)value).ToString("G8"),
								"\""
							}));
						}
						else if (propertyInfo.PropertyType == typeof(Transform))
						{
							Transform transform = value as Transform;
							if (transform != null)
							{
								string text2 = ((this.mMotionController.transform != null) ? JSONSerializer.GetFullPath(this.mMotionController.transform) : "");
								string text3 = JSONSerializer.GetFullPath(transform);
								if ((float)text2.Length > 0f)
								{
									text3 = JSONSerializer.ReplaceFirst(text3, text2, "[OOTII_ROOT]");
								}
								stringBuilder.Append(string.Concat(new string[] { ", \"", propertyInfo.Name, "\" : \"", text3, "\"" }));
							}
						}
						else if (propertyInfo.PropertyType == typeof(GameObject))
						{
							GameObject gameObject = value as GameObject;
							if (gameObject != null)
							{
								string text4 = ((this.mMotionController != null) ? JSONSerializer.GetFullPath(this.mMotionController.transform) : "");
								string text5 = JSONSerializer.GetFullPath(gameObject.transform);
								if ((float)text4.Length > 0f)
								{
									text5 = JSONSerializer.ReplaceFirst(text5, text4, "[OOTII_ROOT]");
								}
								stringBuilder.Append(string.Concat(new string[] { ", \"", propertyInfo.Name, "\" : \"", text5, "\"" }));
							}
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								", \"",
								propertyInfo.Name,
								"\" : \"",
								value.ToString(),
								"\""
							}));
						}
					}
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0003AA2C File Offset: 0x00038C2C
		public virtual void DeserializeMotion(string rDefinition)
		{
			JSONNode jsonnode = JSONNode.Parse(rDefinition);
			if (jsonnode == null)
			{
				return;
			}
			JSONNode jsonnode2 = jsonnode["Tags"];
			if (jsonnode2 != null)
			{
				if (jsonnode2.Value == null || jsonnode2.Value.Length == 0)
				{
					this.mTags.Clear();
					this.mTags = null;
				}
				else
				{
					if (this.mTags == null)
					{
						this.mTags = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
					}
					this.mTags.Clear();
					string[] array = jsonnode2.Value.Split('|', StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						this.mTags.Add(array[i], 0);
					}
				}
			}
			foreach (PropertyInfo propertyInfo in base.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite)
				{
					JSONNode jsonnode3 = jsonnode[propertyInfo.Name];
					if (jsonnode3 == null)
					{
						if (propertyInfo.PropertyType == typeof(string))
						{
							propertyInfo.SetValue(this, "", null);
						}
					}
					else if (propertyInfo.PropertyType == typeof(string))
					{
						propertyInfo.SetValue(this, jsonnode3.Value, null);
					}
					else if (propertyInfo.PropertyType == typeof(int))
					{
						propertyInfo.SetValue(this, jsonnode3.AsInt, null);
					}
					else if (propertyInfo.PropertyType == typeof(float))
					{
						propertyInfo.SetValue(this, jsonnode3.AsFloat, null);
					}
					else if (propertyInfo.PropertyType == typeof(bool))
					{
						propertyInfo.SetValue(this, jsonnode3.AsBool, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector2))
					{
						Vector2 vector = Vector2.zero;
						vector = vector.FromString(jsonnode3.Value);
						propertyInfo.SetValue(this, vector, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector3))
					{
						Vector3 vector2 = Vector3.zero;
						vector2 = vector2.FromString(jsonnode3.Value);
						propertyInfo.SetValue(this, vector2, null);
					}
					else if (propertyInfo.PropertyType == typeof(Vector4))
					{
						Vector4 vector3 = Vector4.zero;
						vector3 = vector3.FromString(jsonnode3.Value);
						propertyInfo.SetValue(this, vector3, null);
					}
					else if (propertyInfo.PropertyType == typeof(Transform))
					{
						string text = jsonnode3.Value;
						Transform transform = null;
						if (text.Contains("[OOTII_ROOT]") && this.mMotionController != null)
						{
							text = jsonnode3.Value.Replace("[OOTII_ROOT]", "");
							if (text.Length > 0 && text.Substring(0, 1) == "/")
							{
								text = text.Substring(1);
							}
							transform = ((text.Length == 0) ? this.mMotionController.transform : JSONSerializer.RootObject.transform.Find(text));
						}
						else
						{
							GameObject gameObject = GameObject.Find(text);
							if (gameObject != null)
							{
								transform = gameObject.transform;
							}
						}
						if (transform != null)
						{
							propertyInfo.SetValue(this, transform, null);
						}
					}
					else if (propertyInfo.PropertyType == typeof(GameObject))
					{
						string text2 = jsonnode3.Value;
						GameObject gameObject2 = null;
						if (text2.Contains("[OOTII_ROOT]") && this.mMotionController != null)
						{
							text2 = jsonnode3.Value.Replace("[OOTII_ROOT]", "");
							if (text2.Length > 0 && text2.Substring(0, 1) == "/")
							{
								text2 = text2.Substring(1);
							}
							Transform transform2 = ((text2.Length == 0) ? this.mMotionController.transform : this.mMotionController.gameObject.transform.Find(text2));
							if (transform2 != null)
							{
								gameObject2 = transform2.gameObject;
							}
						}
						else
						{
							gameObject2 = GameObject.Find(text2);
						}
						if (gameObject2 != null)
						{
							propertyInfo.SetValue(this, gameObject2, null);
						}
					}
				}
			}
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0003AEBA File Offset: 0x000390BA
		public virtual void OnStateMachineEnter(Animator rAnimator, int rStateMachinePathHash)
		{
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0003AEBC File Offset: 0x000390BC
		public virtual void OnStateMachineExit(Animator rAnimator, int rStateMachinePathHash)
		{
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0003AEBE File Offset: 0x000390BE
		public virtual void OnStateEnter(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0003AEC0 File Offset: 0x000390C0
		public virtual void OnStateExit(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0003AEC2 File Offset: 0x000390C2
		public virtual void OnStateUpdate(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0003AEC4 File Offset: 0x000390C4
		public virtual void OnStateMove(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0003AEC6 File Offset: 0x000390C6
		public virtual void OnStateIK(Animator rAnimator, AnimatorStateInfo rAnimatorStateInfo, int rLayerIndex)
		{
		}

		// Token: 0x0400064D RID: 1613
		public string _Key = "";

		// Token: 0x0400064E RID: 1614
		public string _Type = "";

		// Token: 0x0400064F RID: 1615
		public int _Category;

		// Token: 0x04000650 RID: 1616
		public string _Pack = "Basic";

		// Token: 0x04000651 RID: 1617
		public int _Form = -1;

		// Token: 0x04000652 RID: 1618
		protected ActorController mActorController;

		// Token: 0x04000653 RID: 1619
		protected MotionController mMotionController;

		// Token: 0x04000654 RID: 1620
		protected MotionControllerLayer mMotionLayer;

		// Token: 0x04000655 RID: 1621
		public float _Priority;

		// Token: 0x04000656 RID: 1622
		public bool _IsEnabled = true;

		// Token: 0x04000657 RID: 1623
		public bool _OverrideLayers;

		// Token: 0x04000658 RID: 1624
		public bool _ShowDebug;

		// Token: 0x04000659 RID: 1625
		public string _ActionAlias = "";

		// Token: 0x0400065A RID: 1626
		protected bool mIsActive;

		// Token: 0x0400065B RID: 1627
		protected bool mIsAnimatorActive;

		// Token: 0x0400065C RID: 1628
		protected bool mIsInSubStateMachine;

		// Token: 0x0400065D RID: 1629
		protected float mAge;

		// Token: 0x0400065E RID: 1630
		protected bool mIsStartable = true;

		// Token: 0x0400065F RID: 1631
		protected int mPhase;

		// Token: 0x04000660 RID: 1632
		protected int mParameter;

		// Token: 0x04000661 RID: 1633
		protected bool mIsInterruptible = true;

		// Token: 0x04000662 RID: 1634
		protected bool mQueueActivation;

		// Token: 0x04000663 RID: 1635
		public float _ReactivationDelay;

		// Token: 0x04000664 RID: 1636
		protected float mDeactivationTime;

		// Token: 0x04000665 RID: 1637
		protected bool mIsActivatedFrame;

		// Token: 0x04000666 RID: 1638
		protected bool mUseTrendData;

		// Token: 0x04000667 RID: 1639
		protected Vector3 mVelocity = Vector3.zero;

		// Token: 0x04000668 RID: 1640
		protected Vector3 mMovement = Vector3.zero;

		// Token: 0x04000669 RID: 1641
		protected Vector3 mAngularVelocity = Vector3.zero;

		// Token: 0x0400066A RID: 1642
		protected Quaternion mRotation = Quaternion.identity;

		// Token: 0x0400066B RID: 1643
		protected Quaternion mTilt = Quaternion.identity;

		// Token: 0x0400066C RID: 1644
		public bool _IsFixedUpdateEnabled;

		// Token: 0x0400066D RID: 1645
		public float _FixedUpdateFPS = 60f;

		// Token: 0x0400066E RID: 1646
		protected Dictionary<string, int> mTags;

		// Token: 0x0400066F RID: 1647
		[NonSerialized]
		public MotionDelegate OnActivatedEvent;

		// Token: 0x04000670 RID: 1648
		[NonSerialized]
		public MotionDelegate OnDeactivatedEvent;

		// Token: 0x04000671 RID: 1649
		protected bool mIsFirstUpdate = true;

		// Token: 0x04000672 RID: 1650
		protected float mFixedElapsedTime;

		// Token: 0x04000673 RID: 1651
		protected List<MotionReachData> mReachData;

		// Token: 0x04000674 RID: 1652
		public string _EditorAnimatorSMName = "";
	}
}

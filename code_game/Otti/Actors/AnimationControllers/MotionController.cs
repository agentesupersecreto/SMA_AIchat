using System;
using System.Collections;
using System.Collections.Generic;
using com.ootii.Actors.LifeCores;
using com.ootii.Cameras;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Input;
using com.ootii.Messages;
using com.ootii.Physics;
using com.ootii.Timing;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000E6 RID: 230
	[RequireComponent(typeof(ActorController))]
	[AddComponentMenu("ootii/Motion Controller")]
	public class MotionController : MonoBehaviour
	{
		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x00034E68 File Offset: 0x00033068
		public static Profiler UpdateProfiler
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x00034E6B File Offset: 0x0003306B
		// (set) Token: 0x06000B33 RID: 2867 RVA: 0x00034E73 File Offset: 0x00033073
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

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x00034E7C File Offset: 0x0003307C
		public Transform Transform
		{
			get
			{
				return this._Transform;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00034E84 File Offset: 0x00033084
		// (set) Token: 0x06000B36 RID: 2870 RVA: 0x00034E8C File Offset: 0x0003308C
		public IActorStateSource StateSource
		{
			get
			{
				return this._StateSource;
			}
			set
			{
				this._StateSource = value;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000B37 RID: 2871 RVA: 0x00034E95 File Offset: 0x00033095
		// (set) Token: 0x06000B38 RID: 2872 RVA: 0x00034EC0 File Offset: 0x000330C0
		public int Stance
		{
			get
			{
				if (this._StateSource != null)
				{
					return this._StateSource.GetStateValue("Stance");
				}
				return this._ActorController.State.Stance;
			}
			set
			{
				if (this._StateSource != null)
				{
					this._StateSource.SetStateValue("Stance", value);
				}
				this._ActorController.State.Stance = value;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x00034EEC File Offset: 0x000330EC
		// (set) Token: 0x06000B3A RID: 2874 RVA: 0x00034F0D File Offset: 0x0003310D
		public int DefaultForm
		{
			get
			{
				if (this._StateSource != null)
				{
					return this._StateSource.GetStateValue("Default Form");
				}
				return this.mDefaultForm;
			}
			set
			{
				if (this._StateSource != null)
				{
					this._StateSource.SetStateValue("Default Form", value);
				}
				this.mDefaultForm = value;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000B3B RID: 2875 RVA: 0x00034F2F File Offset: 0x0003312F
		// (set) Token: 0x06000B3C RID: 2876 RVA: 0x00034F50 File Offset: 0x00033150
		public int CurrentForm
		{
			get
			{
				if (this._StateSource != null)
				{
					return this._StateSource.GetStateValue("Current Form");
				}
				return this.mCurrentForm;
			}
			set
			{
				if (this._StateSource != null)
				{
					this._StateSource.SetStateValue("Current Form", value);
				}
				this.mCurrentForm = value;
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x00034F72 File Offset: 0x00033172
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x00034F7A File Offset: 0x0003317A
		public IActorCore ActorCore
		{
			get
			{
				return this._ActorCore;
			}
			set
			{
				this._ActorCore = value;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000B3F RID: 2879 RVA: 0x00034F83 File Offset: 0x00033183
		// (set) Token: 0x06000B40 RID: 2880 RVA: 0x00034F8B File Offset: 0x0003318B
		public ActorController ActorController
		{
			get
			{
				return this._ActorController;
			}
			set
			{
				this._ActorController = value;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x00034F94 File Offset: 0x00033194
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x00034F9C File Offset: 0x0003319C
		public Animator Animator
		{
			get
			{
				return this._Animator;
			}
			set
			{
				Animator animator = this._Animator;
				this._Animator = value;
				if (Application.isPlaying && this._Animator != null)
				{
					this.State.AnimatorStates = new AnimatorLayerState[this._Animator.layerCount];
					this.PrevState.AnimatorStates = new AnimatorLayerState[this._Animator.layerCount];
					for (int i = 0; i < this.State.AnimatorStates.Length; i++)
					{
						this.State.AnimatorStates[i] = default(AnimatorLayerState);
						this.PrevState.AnimatorStates[i] = default(AnimatorLayerState);
					}
					if (this.AnimatorChangedEvent != null && this._Animator != animator)
					{
						Message message = Message.Allocate();
						message.Data = this;
						this.AnimatorChangedEvent.Invoke(message);
						Message.Release(message);
					}
				}
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x00035083 File Offset: 0x00033283
		// (set) Token: 0x06000B44 RID: 2884 RVA: 0x0003508B File Offset: 0x0003328B
		public GameObject InputSourceOwner
		{
			get
			{
				return this._InputSourceOwner;
			}
			set
			{
				this._InputSourceOwner = value;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x00035094 File Offset: 0x00033294
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x0003509C File Offset: 0x0003329C
		public IInputSource InputSource
		{
			get
			{
				return this._InputSource;
			}
			set
			{
				this._InputSource = value;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x000350A5 File Offset: 0x000332A5
		// (set) Token: 0x06000B48 RID: 2888 RVA: 0x000350AD File Offset: 0x000332AD
		public bool AutoFindInputSource
		{
			get
			{
				return this._AutoFindInputSource;
			}
			set
			{
				this._AutoFindInputSource = value;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x000350B6 File Offset: 0x000332B6
		// (set) Token: 0x06000B4A RID: 2890 RVA: 0x000350BE File Offset: 0x000332BE
		public bool UseSimulatedInput
		{
			get
			{
				return this._UseSimulatedInput;
			}
			set
			{
				this._UseSimulatedInput = value;
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x000350C7 File Offset: 0x000332C7
		// (set) Token: 0x06000B4C RID: 2892 RVA: 0x000350CF File Offset: 0x000332CF
		public Transform CameraTransform
		{
			get
			{
				return this._CameraTransform;
			}
			set
			{
				this._CameraTransform = value;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x000350D8 File Offset: 0x000332D8
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x000350E0 File Offset: 0x000332E0
		public IBaseCameraRig CameraRig
		{
			get
			{
				return this.mCameraRig;
			}
			set
			{
				this.mCameraRig = value;
				if (this.mCameraRig != null)
				{
					this._CameraTransform = this.mCameraRig.Transform;
				}
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x00035102 File Offset: 0x00033302
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x0003510A File Offset: 0x0003330A
		public bool AutoFindCameraTransform
		{
			get
			{
				return this._AutoFindCameraTransform;
			}
			set
			{
				this._AutoFindCameraTransform = value;
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x00035113 File Offset: 0x00033313
		public MotionControllerMotion ActiveMotion
		{
			get
			{
				if (this.MotionLayers.Count > 0)
				{
					return this.MotionLayers[0].ActiveMotion;
				}
				return null;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x00035136 File Offset: 0x00033336
		// (set) Token: 0x06000B53 RID: 2899 RVA: 0x0003513E File Offset: 0x0003333E
		public bool IsTimeSmoothingEnabled
		{
			get
			{
				return this._IsTimeSmoothingEnabled;
			}
			set
			{
				this._IsTimeSmoothingEnabled = value;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x00035147 File Offset: 0x00033347
		// (set) Token: 0x06000B55 RID: 2901 RVA: 0x0003514F File Offset: 0x0003334F
		public float MaxSpeed
		{
			get
			{
				return this._MaxSpeed;
			}
			set
			{
				this._MaxSpeed = value;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x00035158 File Offset: 0x00033358
		// (set) Token: 0x06000B57 RID: 2903 RVA: 0x00035160 File Offset: 0x00033360
		public float RotationSpeed
		{
			get
			{
				return this._RotationSpeed;
			}
			set
			{
				this._RotationSpeed = value;
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x00035169 File Offset: 0x00033369
		public Vector3 TargetVelocity
		{
			get
			{
				return this.mTargetVelocity;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00035171 File Offset: 0x00033371
		public Vector3 TargetPosition
		{
			get
			{
				return this.mTargetPosition;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x00035179 File Offset: 0x00033379
		// (set) Token: 0x06000B5B RID: 2907 RVA: 0x00035181 File Offset: 0x00033381
		public float TargetStopDistance
		{
			get
			{
				return this.mTargetStopDistance;
			}
			set
			{
				this.mTargetStopDistance = value;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0003518A File Offset: 0x0003338A
		public bool IsTargetMovementSet
		{
			get
			{
				return this.mIsTargetMovementSet;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x00035192 File Offset: 0x00033392
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x0003519A File Offset: 0x0003339A
		public float TargetNormalizedSpeed
		{
			get
			{
				return this.mTargetNormalizedSpeed;
			}
			set
			{
				this.mTargetNormalizedSpeed = value;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x000351A3 File Offset: 0x000333A3
		public Quaternion TargetRotation
		{
			get
			{
				return this.mTargetRotation;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x000351AB File Offset: 0x000333AB
		public bool IsTargetRotationSet
		{
			get
			{
				return this.mIsTargetRotationSet;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x000351B3 File Offset: 0x000333B3
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x000351BB File Offset: 0x000333BB
		public bool ForceStrafing
		{
			get
			{
				return this.mForceStrafing;
			}
			set
			{
				this.mForceStrafing = value;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x000351C4 File Offset: 0x000333C4
		public bool IsGrounded
		{
			get
			{
				return this._ActorController.State.IsGrounded;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x000351D6 File Offset: 0x000333D6
		// (set) Token: 0x06000B65 RID: 2917 RVA: 0x000351DE File Offset: 0x000333DE
		public List<Force> AppliedForces
		{
			get
			{
				return this.mAppliedForces;
			}
			set
			{
				this.mAppliedForces = value;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x000351E7 File Offset: 0x000333E7
		// (set) Token: 0x06000B67 RID: 2919 RVA: 0x000351EF File Offset: 0x000333EF
		public bool ShowDebug
		{
			get
			{
				return this._ShowDebug;
			}
			set
			{
				this._ShowDebug = value;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x000351F8 File Offset: 0x000333F8
		// (set) Token: 0x06000B69 RID: 2921 RVA: 0x00035200 File Offset: 0x00033400
		public bool ShowDebugForAllMotions
		{
			get
			{
				return this._ShowDebugForAllMotions;
			}
			set
			{
				this._ShowDebugForAllMotions = value;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x00035209 File Offset: 0x00033409
		// (set) Token: 0x06000B6B RID: 2923 RVA: 0x00035211 File Offset: 0x00033411
		public int AnimatorClearType
		{
			get
			{
				return this._AnimatorClearType;
			}
			set
			{
				this._AnimatorClearType = value;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0003521A File Offset: 0x0003341A
		// (set) Token: 0x06000B6D RID: 2925 RVA: 0x00035222 File Offset: 0x00033422
		public float AnimatorClearDelay
		{
			get
			{
				return this._AnimatorClearDelay;
			}
			set
			{
				this._AnimatorClearDelay = value;
			}
		}

		// Token: 0x17000320 RID: 800
		// (set) Token: 0x06000B6E RID: 2926 RVA: 0x0003522C File Offset: 0x0003342C
		public bool AnimatorClearForced
		{
			set
			{
				if (value)
				{
					for (int i = 0; i < this.State.AnimatorStates.Length; i++)
					{
						this.State.AnimatorStates[i].SetTime = 0f;
					}
				}
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0003526F File Offset: 0x0003346F
		public Vector3 AccumulatedAcceleration
		{
			get
			{
				return this.mAccumulatedAcceleration;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x00035277 File Offset: 0x00033477
		// (set) Token: 0x06000B71 RID: 2929 RVA: 0x0003527F File Offset: 0x0003347F
		public Vector3 AccumulatedVelocity
		{
			get
			{
				return this.mAccumulatedVelocity;
			}
			set
			{
				this.mAccumulatedVelocity = value;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x00035288 File Offset: 0x00033488
		// (set) Token: 0x06000B73 RID: 2931 RVA: 0x00035290 File Offset: 0x00033490
		public Vector3 RootMotionMovement
		{
			get
			{
				return this.mRootMotionMovement;
			}
			set
			{
				this.mRootMotionMovement = value;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x00035299 File Offset: 0x00033499
		// (set) Token: 0x06000B75 RID: 2933 RVA: 0x000352A1 File Offset: 0x000334A1
		public Quaternion RootMotionRotation
		{
			get
			{
				return this.mRootMotionRotation;
			}
			set
			{
				this.mRootMotionRotation = value;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x000352AA File Offset: 0x000334AA
		public bool UseMotionStateTimes
		{
			get
			{
				return this.mUseMotionStateTimes;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x000352B2 File Offset: 0x000334B2
		public bool UseMotionForms
		{
			get
			{
				return this.mUseMotionForms;
			}
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000352BC File Offset: 0x000334BC
		protected void Awake_()
		{
			this._Transform = base.transform;
			try
			{
				this._CameraTransform.gameObject;
			}
			catch
			{
				this._CameraTransform = null;
			}
			try
			{
				this._InputSourceOwner.transform;
			}
			catch
			{
				this._InputSourceOwner = null;
			}
			this._ActorCore = base.gameObject.GetComponent<IActorCore>();
			this._ActorController = base.gameObject.GetComponent<ActorController>();
			if (base.enabled)
			{
				ActorController actorController = this._ActorController;
				actorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(actorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
			if (this._AutoFindCameraTransform && this._CameraTransform == null)
			{
				Camera camera = Camera.main;
				if (camera == null)
				{
					camera = Object.FindObjectOfType<Camera>();
				}
				if (camera != null)
				{
					this.mCameraRig = this.ExtractCameraRig(camera.transform);
					if (this.mCameraRig != null)
					{
						this._CameraTransform = ((MonoBehaviour)this.mCameraRig).gameObject.transform;
					}
					if (this._CameraTransform == null)
					{
						this._CameraTransform = camera.transform;
					}
				}
			}
			if (this._CameraTransform != null)
			{
				this.mCameraRig = this.ExtractCameraRig(this._CameraTransform);
				if (this.mCameraRig != null && this.mCameraRig.Anchor == null)
				{
					this.mCameraRig.Anchor = this._Transform;
				}
			}
			if (this._InputSourceOwner != null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			if (this._AutoFindInputSource && this._InputSource == null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(base.gameObject);
				if (this._InputSource != null)
				{
					this._InputSourceOwner = base.gameObject;
				}
			}
			if (this._AutoFindInputSource && this._InputSource == null)
			{
				IInputSource[] components = InterfaceHelper.GetComponents<IInputSource>();
				for (int i = 0; i < components.Length; i++)
				{
					GameObject gameObject = ((MonoBehaviour)components[i]).gameObject;
					if (gameObject.activeSelf && components[i].IsEnabled)
					{
						this._InputSource = components[i];
						this._InputSourceOwner = gameObject;
					}
				}
			}
			this._StateSource = base.gameObject.GetComponent<IActorStateSource>();
			if (this._Animator == null)
			{
				this._Animator = base.gameObject.GetComponent<Animator>();
			}
			if (this._Animator == null)
			{
				this._Animator = base.gameObject.GetComponentInChildren<Animator>();
			}
			for (int j = 0; j < this._Animator.parameters.Length; j++)
			{
				if (this._Animator.parameters[j].name == MotionController.MOTION_STYLE_NAMES[0])
				{
					this.mUseMotionForms = true;
				}
				if (this._Animator.parameters[j].name == MotionController.MOTION_STATE_TIME[0])
				{
					this.mUseMotionStateTimes = true;
				}
			}
			if (this._Animator != null)
			{
				this.State.AnimatorStates = new AnimatorLayerState[this._Animator.layerCount];
				this.PrevState.AnimatorStates = new AnimatorLayerState[this._Animator.layerCount];
				for (int k = 0; k < this.State.AnimatorStates.Length; k++)
				{
					this.State.AnimatorStates[k] = default(AnimatorLayerState);
					this.PrevState.AnimatorStates[k] = default(AnimatorLayerState);
				}
			}
			for (int l = 0; l < this.MotionLayers.Count; l++)
			{
				this.MotionLayers[l].MotionController = this;
				this.MotionLayers[l].Awake();
			}
			this.LoadAnimatorData();
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x00035688 File Offset: 0x00033888
		protected void Start()
		{
			if (this.AnimatorChangedEvent != null)
			{
				Message message = Message.Allocate();
				message.Data = this;
				this.AnimatorChangedEvent.Invoke(message);
				Message.Release(message);
			}
			this.m_stared = true;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x000356C4 File Offset: 0x000338C4
		protected void OnEnable()
		{
			if (this._ActorController != null)
			{
				if (this._ActorController.OnControllerPreLateUpdate != null)
				{
					ActorController actorController = this._ActorController;
					actorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(actorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
				ActorController actorController2 = this._ActorController;
				actorController2.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(actorController2.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0003573C File Offset: 0x0003393C
		protected void OnDisable()
		{
			if (this._ActorController != null && this._ActorController.OnControllerPreLateUpdate != null)
			{
				ActorController actorController = this._ActorController;
				actorController.OnControllerPreLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(actorController.OnControllerPreLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
			}
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0003578C File Offset: 0x0003398C
		protected void FixedUpdate_()
		{
			int count = this.MotionLayers.Count;
			for (int i = 0; i < count; i++)
			{
				this.MotionLayers[i].FixedUpdateMotions(Time.fixedDeltaTime);
			}
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x000357C8 File Offset: 0x000339C8
		public void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (this._Animator == null)
			{
				this.Animator = base.gameObject.GetComponent<Animator>();
				if (this._Animator == null)
				{
					this.Animator = base.gameObject.GetComponentInChildren<Animator>();
				}
				if (this._Animator == null)
				{
					return;
				}
			}
			float num = (this._IsTimeSmoothingEnabled ? TimeManager.SmoothedDeltaTime : rDeltaTime);
			bool flag = false;
			MotionState.Shift(ref this.State, ref this.PrevState);
			int num2;
			if (this._Animator != null)
			{
				num2 = this.State.AnimatorStates.Length;
				for (int i = 0; i < num2; i++)
				{
					MotionControllerMotion motionControllerMotion = null;
					if (i < this.MotionLayers.Count && this.MotionLayers[i] != null)
					{
						motionControllerMotion = this.MotionLayers[i].ActiveMotion;
					}
					this.State.AnimatorStates[i].StateInfo = this._Animator.GetCurrentAnimatorStateInfo(i);
					this.State.AnimatorStates[i].TransitionInfo = this._Animator.GetAnimatorTransitionInfo(i);
					if (motionControllerMotion != null && this.State.AnimatorStates[i].AutoClearMotionPhase)
					{
						if (motionControllerMotion.VerifyTransition)
						{
							if (motionControllerMotion.IsMotionState(this.State.AnimatorStates[i].StateInfo.fullPathHash, this.State.AnimatorStates[i].TransitionInfo.fullPathHash))
							{
								motionControllerMotion.IsAnimatorActive = true;
								this.State.AnimatorStates[i].MotionPhase = 0;
								this.State.AnimatorStates[i].AutoClearMotionPhase = false;
								this.State.AnimatorStates[i].AutoClearActiveTransitionID = 0;
							}
						}
						else if (this.State.AnimatorStates[i].TransitionInfo.fullPathHash != 0 && this.State.AnimatorStates[i].TransitionInfo.anyState && this.State.AnimatorStates[i].TransitionInfo.fullPathHash != this.State.AnimatorStates[i].AutoClearActiveTransitionID)
						{
							motionControllerMotion.IsAnimatorActive = true;
							this.State.AnimatorStates[i].MotionPhase = 0;
							this.State.AnimatorStates[i].AutoClearMotionPhase = false;
							this.State.AnimatorStates[i].AutoClearActiveTransitionID = 0;
						}
					}
					if (motionControllerMotion != null && !motionControllerMotion.HasAutoGeneratedCode && !motionControllerMotion.VerifyTransition)
					{
						if (this.State.AnimatorStates[i].AutoClearMotionPhase && this.State.AnimatorStates[i].TransitionInfo.fullPathHash != 0 && this.State.AnimatorStates[i].TransitionInfo.fullPathHash != this.State.AnimatorStates[i].AutoClearActiveTransitionID)
						{
							motionControllerMotion.IsAnimatorActive = true;
							this.State.AnimatorStates[i].AutoClearMotionPhaseReady = true;
						}
						if (this.State.AnimatorStates[i].StateInfo.fullPathHash != this.PrevState.AnimatorStates[i].StateInfo.fullPathHash && motionControllerMotion.IsMotionState(this.State.AnimatorStates[i].StateInfo.fullPathHash))
						{
							motionControllerMotion.IsAnimatorActive = true;
							this.State.AnimatorStates[i].AutoClearMotionPhaseReady = true;
						}
					}
					if (this.State.AnimatorStates[i].StateInfo.fullPathHash != this.PrevState.AnimatorStates[i].StateInfo.fullPathHash)
					{
						this.OnAnimatorStateChange(i);
					}
				}
			}
			if (this.mTargetStopDistance > 0f && this.mTargetPosition.sqrMagnitude > 0f && Vector3.Distance(this.mTargetPosition, this._Transform.position) < this.mTargetStopDistance)
			{
				if (this.mTargetRotation.IsIdentity())
				{
					this.ClearTarget();
				}
				else
				{
					this.ClearTargetPosition();
				}
			}
			if (!this.mTargetRotation.IsIdentity() && this._Transform.rotation.RotationTo(this.mTargetRotation).IsIdentity())
			{
				if (this.mTargetPosition.sqrMagnitude == 0f && this.mTargetVelocity.sqrMagnitude == 0f)
				{
					this.ClearTarget();
				}
				else
				{
					this.ClearTargetRotation();
				}
			}
			if (this._ActorController._UseTransformPosition)
			{
				this.ProcessMovementInput();
			}
			else if (this._UseSimulatedInput || this._InputSource == null || !this._InputSource.IsEnabled)
			{
				this.ProcessSimulatedInput();
			}
			else
			{
				this.ProcessUserInput();
			}
			if (this.MotionLayers.Count > 0)
			{
				this.MotionLayers[0].UpdateRootMotion(num, rUpdateIndex, ref this.mRootMotionMovement, ref this.mRootMotionRotation);
			}
			num2 = this.MotionLayers.Count;
			for (int j = 0; j < num2; j++)
			{
				if (this.MotionLayers[j].ActiveMotion != null && this.MotionLayers[j].ActiveMotion.OverrideLayers)
				{
					for (int k = j + 1; k < num2; k++)
					{
						if (!this.MotionLayers[k].IgnoreMotionOverride)
						{
							Empty motion = this.GetMotion<Empty>(k, false);
							if (motion != null)
							{
								motion.QueueActivation = true;
							}
						}
					}
				}
				this.MotionLayers[j].UpdateMotions(num, rUpdateIndex);
			}
			if (this.MotionLayers.Count > 0 && this.MotionLayers[0].UseTrendData)
			{
				flag = true;
			}
			this.DetermineTrendData();
			if (this.mIsTargetRotationSet)
			{
				this._ActorController.SetRotation(this.mTargetRotation);
			}
			else
			{
				Vector3 vector = Vector3.zero;
				Quaternion quaternion = Quaternion.identity;
				Quaternion quaternion2 = Quaternion.identity;
				for (int l = 0; l < this.MotionLayers.Count; l++)
				{
					vector += this.MotionLayers[l].AngularVelocity;
					quaternion *= this.MotionLayers[l].Rotation;
					quaternion2 *= this.MotionLayers[l].Tilt;
				}
				this._ActorController.Rotate(this.mRootMotionRotation * quaternion * Quaternion.Euler(vector * num), quaternion2);
			}
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			int count = this.MotionLayers.Count;
			if (count > 0)
			{
				for (int m = 0; m < count; m++)
				{
					vector2 += this.MotionLayers[m].Velocity;
					vector3 += this.MotionLayers[m].Movement;
				}
			}
			Vector3 vector4 = this._Transform.rotation * this.mRootMotionMovement + vector2 * num + vector3;
			this._ActorController.Move(vector4);
			if (rUpdateIndex >= 1)
			{
				this.SetAnimatorProperties(ref this.State, flag);
			}
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00035F60 File Offset: 0x00034160
		public bool IsMotionActive(int rLayerIndex, Type rType)
		{
			return rLayerIndex < this.MotionLayers.Count && this.MotionLayers[rLayerIndex].ActiveMotion != null && this.MotionLayers[rLayerIndex].ActiveMotion.GetType() == rType;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00035FB0 File Offset: 0x000341B0
		public bool IsMotionActive(int rLayerIndex, string rName)
		{
			return rLayerIndex < this.MotionLayers.Count && this.MotionLayers[rLayerIndex].ActiveMotion != null && string.Compare(this.MotionLayers[rLayerIndex].ActiveMotion.Name, rName, true) == 0;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00036004 File Offset: 0x00034204
		public T GetMotion<T>(bool rIncludeDisabled = false) where T : MotionControllerMotion
		{
			Type typeFromHandle = typeof(T);
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				for (int j = 0; j < this.MotionLayers[i].Motions.Count; j++)
				{
					if (this.MotionLayers[i].Motions[j].GetType() == typeFromHandle)
					{
						motionControllerMotion = this.MotionLayers[i].Motions[j];
						if (rIncludeDisabled || motionControllerMotion.IsEnabled)
						{
							return (T)((object)motionControllerMotion);
						}
					}
				}
			}
			return (T)((object)motionControllerMotion);
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x000360AC File Offset: 0x000342AC
		public T GetMotion<T>(int rLayerIndex, bool rIncludeDisabled = false) where T : MotionControllerMotion
		{
			if (rLayerIndex >= this.MotionLayers.Count)
			{
				return default(T);
			}
			Type typeFromHandle = typeof(T);
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
			{
				if (this.MotionLayers[rLayerIndex].Motions[i].GetType() == typeFromHandle)
				{
					motionControllerMotion = this.MotionLayers[rLayerIndex].Motions[i];
					if (rIncludeDisabled || motionControllerMotion.IsEnabled)
					{
						return (T)((object)motionControllerMotion);
					}
				}
			}
			return (T)((object)motionControllerMotion);
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00036154 File Offset: 0x00034354
		public MotionControllerMotion GetMotion(Type rType, bool rIncludeDisabled = false)
		{
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				for (int j = 0; j < this.MotionLayers[i].Motions.Count; j++)
				{
					if (this.MotionLayers[i].Motions[j].GetType() == rType)
					{
						motionControllerMotion = this.MotionLayers[i].Motions[j];
						if (rIncludeDisabled || motionControllerMotion.IsEnabled)
						{
							return motionControllerMotion;
						}
					}
				}
			}
			return motionControllerMotion;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x000361E4 File Offset: 0x000343E4
		public MotionControllerMotion GetMotion(int rLayerIndex, Type rType, bool rIncludeDisabled = false)
		{
			if (rLayerIndex >= this.MotionLayers.Count)
			{
				return null;
			}
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
			{
				if (this.MotionLayers[rLayerIndex].Motions[i].GetType() == rType)
				{
					motionControllerMotion = this.MotionLayers[rLayerIndex].Motions[i];
					if (rIncludeDisabled || motionControllerMotion.IsEnabled)
					{
						return motionControllerMotion;
					}
				}
			}
			return motionControllerMotion;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x00036270 File Offset: 0x00034470
		public MotionControllerMotion GetMotion(string rName, bool rIncludeDisabled = false)
		{
			if (rName.Length == 0)
			{
				return null;
			}
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				for (int j = 0; j < this.MotionLayers[i].Motions.Count; j++)
				{
					if (string.Compare(this.MotionLayers[i].Motions[j].Name, rName, true) == 0)
					{
						motionControllerMotion = this.MotionLayers[i].Motions[j];
						if (rIncludeDisabled || motionControllerMotion.IsEnabled)
						{
							return motionControllerMotion;
						}
					}
				}
			}
			if (motionControllerMotion == null)
			{
				for (int k = 0; k < this.MotionLayers.Count; k++)
				{
					for (int l = 0; l < this.MotionLayers[k].Motions.Count; l++)
					{
						if (string.Compare(this.MotionLayers[k].Motions[l].GetType().Name, rName, true) == 0)
						{
							motionControllerMotion = this.MotionLayers[k].Motions[l];
							if (rIncludeDisabled || motionControllerMotion.IsEnabled)
							{
								return motionControllerMotion;
							}
						}
					}
				}
			}
			return motionControllerMotion;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x000363A0 File Offset: 0x000345A0
		public MotionControllerMotion GetMotion(int rLayerIndex, string rName, bool rIncludeDisabled = false)
		{
			MotionControllerMotion motionControllerMotion = null;
			for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
			{
				if (string.Compare(this.MotionLayers[rLayerIndex].Motions[i].Name, rName, true) == 0)
				{
					motionControllerMotion = this.MotionLayers[rLayerIndex].Motions[i];
					if (rIncludeDisabled || motionControllerMotion.IsEnabled)
					{
						return motionControllerMotion;
					}
				}
			}
			if (motionControllerMotion == null)
			{
				for (int j = 0; j < this.MotionLayers[rLayerIndex].Motions.Count; j++)
				{
					if (string.Compare(this.MotionLayers[rLayerIndex].Motions[j].GetType().Name, rName, true) == 0)
					{
						motionControllerMotion = this.MotionLayers[rLayerIndex].Motions[j];
						if (rIncludeDisabled || motionControllerMotion.IsEnabled)
						{
							return motionControllerMotion;
						}
					}
				}
			}
			return motionControllerMotion;
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00036490 File Offset: 0x00034690
		public T GetMotionInterface<T>(int rLayerIndex = 0) where T : class
		{
			if (rLayerIndex < 0 || rLayerIndex >= this.MotionLayers.Count)
			{
				return default(T);
			}
			if (this.MotionLayers[rLayerIndex].Motions.Count == 0)
			{
				return default(T);
			}
			Type typeFromHandle = typeof(T);
			T t = default(T);
			for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
			{
				Type type = this.MotionLayers[rLayerIndex].Motions[i].GetType();
				if (ReflectionHelper.IsAssignableFrom(typeFromHandle, type))
				{
					t = this.MotionLayers[rLayerIndex].Motions[i] as T;
					if (this.MotionLayers[rLayerIndex].Motions[i].IsEnabled)
					{
						return t;
					}
				}
			}
			return t;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0003657D File Offset: 0x0003477D
		public MotionControllerMotion GetActiveMotion(int rLayerIndex)
		{
			if (rLayerIndex >= this.MotionLayers.Count)
			{
				return null;
			}
			return this.MotionLayers[rLayerIndex].ActiveMotion;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x000365A0 File Offset: 0x000347A0
		public void ActivateMotion(MotionControllerMotion rMotion, int rParameter = 0)
		{
			if (rMotion != null)
			{
				rMotion.MotionLayer.QueueMotion(rMotion, rParameter);
			}
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x000365B4 File Offset: 0x000347B4
		public MotionControllerMotion ActivateMotion(Type rMotion, int rParameter = 0)
		{
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				for (int j = 0; j < this.MotionLayers[i].Motions.Count; j++)
				{
					MotionControllerMotion motionControllerMotion = this.MotionLayers[i].Motions[j];
					if (motionControllerMotion.GetType() == rMotion)
					{
						this.MotionLayers[i].QueueMotion(motionControllerMotion, rParameter);
						return motionControllerMotion;
					}
				}
			}
			return null;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x00036638 File Offset: 0x00034838
		public MotionControllerMotion ActivateMotion(string rMotionName, int rParameter = 0)
		{
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				for (int j = 0; j < this.MotionLayers[i].Motions.Count; j++)
				{
					MotionControllerMotion motionControllerMotion = this.MotionLayers[i].Motions[j];
					if (motionControllerMotion._Name == rMotionName)
					{
						this.MotionLayers[i].QueueMotion(motionControllerMotion, rParameter);
						return motionControllerMotion;
					}
				}
			}
			for (int k = 0; k < this.MotionLayers.Count; k++)
			{
				for (int l = 0; l < this.MotionLayers[k].Motions.Count; l++)
				{
					MotionControllerMotion motionControllerMotion2 = this.MotionLayers[k].Motions[l];
					if (motionControllerMotion2.GetType().Name == rMotionName)
					{
						this.MotionLayers[k].QueueMotion(motionControllerMotion2, rParameter);
						return motionControllerMotion2;
					}
				}
			}
			return null;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0003673A File Offset: 0x0003493A
		public IEnumerator WaitAfterActivateMotion(int rLayerIndex, Type rType)
		{
			if (rLayerIndex < this.MotionLayers.Count)
			{
				for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
				{
					if (this.MotionLayers[rLayerIndex].Motions[i].GetType() == rType)
					{
						MotionControllerMotion lMotion = this.MotionLayers[rLayerIndex].Motions[i];
						if (!lMotion.IsActive && !lMotion.QueueActivation)
						{
							while (this.MotionLayers[rLayerIndex]._AnimatorTransitionID != 0)
							{
								yield return null;
							}
							this.ActivateMotion(lMotion, 0);
							while (lMotion.IsActive || lMotion.QueueActivation)
							{
								yield return null;
							}
							break;
						}
						lMotion = null;
					}
				}
			}
			yield break;
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00036757 File Offset: 0x00034957
		public IEnumerator WaitAfterActivateMotion(int rLayerIndex, string rName, int rParameter = 0)
		{
			if (rLayerIndex < this.MotionLayers.Count)
			{
				for (int i = 0; i < this.MotionLayers[rLayerIndex].Motions.Count; i++)
				{
					if (string.Compare(this.MotionLayers[rLayerIndex].Motions[i].Name, rName, true) == 0)
					{
						MotionControllerMotion lMotion = this.MotionLayers[rLayerIndex].Motions[i];
						if (!lMotion.IsActive && !lMotion.QueueActivation)
						{
							while (this.MotionLayers[rLayerIndex]._AnimatorTransitionID != 0)
							{
								yield return null;
							}
							lMotion.Parameter = rParameter;
							this.ActivateMotion(lMotion, 0);
							while (lMotion.IsActive || lMotion.QueueActivation)
							{
								yield return null;
							}
							break;
						}
						lMotion = null;
					}
				}
			}
			yield break;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0003677B File Offset: 0x0003497B
		public IEnumerator WaitForCurrentMotion(int rLayerIndex, bool rIncludeQueued)
		{
			if (rLayerIndex < this.MotionLayers.Count)
			{
				MotionControllerMotion lMotion = this.MotionLayers[rLayerIndex].ActiveMotion;
				while (lMotion != null && (lMotion.IsActive || (rIncludeQueued && lMotion.QueueActivation)))
				{
					yield return null;
				}
				lMotion = null;
			}
			yield break;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00036798 File Offset: 0x00034998
		public void SetTargetRotation(Quaternion rRotation)
		{
			this._UseSimulatedInput = true;
			this.mTargetRotation = rRotation;
			this.mIsTargetRotationSet = true;
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x000367AF File Offset: 0x000349AF
		public void SetTargetVelocity(Vector3 rVelocity, float rNormalizedSpeed = 0f)
		{
			this._UseSimulatedInput = true;
			this.mTargetVelocity = rVelocity;
			this.mTargetNormalizedSpeed = rNormalizedSpeed;
			this.mIsTargetMovementSet = true;
			if (this.mTargetVelocity.sqrMagnitude > 0f)
			{
				this.mTargetPosition = Vector3.zero;
			}
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x000367EA File Offset: 0x000349EA
		public void SetTargetPosition(Vector3 rPosition, float rNormalizedSpeed)
		{
			this._UseSimulatedInput = true;
			this.mTargetPosition = rPosition;
			this.mTargetNormalizedSpeed = rNormalizedSpeed;
			this.mIsTargetMovementSet = true;
			if (this.mTargetPosition.sqrMagnitude > 0f)
			{
				this.mTargetVelocity = Vector3.zero;
			}
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00036828 File Offset: 0x00034A28
		public void ClearTarget()
		{
			this._UseSimulatedInput = false;
			this.mTargetVelocity = Vector3.zero;
			this.mTargetPosition = Vector3.zero;
			this.mIsTargetMovementSet = false;
			this.mTargetRotation = Quaternion.identity;
			this.mIsTargetRotationSet = false;
			this.mForceStrafing = false;
			this.mTargetNormalizedSpeed = 1f;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0003687D File Offset: 0x00034A7D
		public void ClearTargetPosition()
		{
			this.mTargetVelocity = Vector3.zero;
			this.mTargetPosition = Vector3.zero;
			this.mIsTargetMovementSet = false;
			this.mForceStrafing = false;
			this.mTargetNormalizedSpeed = 1f;
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x000368AE File Offset: 0x00034AAE
		public void ClearTargetRotation()
		{
			this.mTargetRotation = Quaternion.identity;
			this.mIsTargetRotationSet = false;
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x000368C2 File Offset: 0x00034AC2
		public IEnumerator MoveAndRotateTo(Vector3 rPosition, Quaternion rRotation, float rTime = 0f, bool rSmooth = true, bool rMove = true, bool rRotate = true)
		{
			if (rTime == 0f)
			{
				if (rMove)
				{
					this._ActorController.SetPosition(rPosition);
				}
				if (rRotate)
				{
					this._ActorController.SetRotation(rRotation);
				}
			}
			else
			{
				float lPercent = 0f;
				float lStartTime = Time.time;
				Vector3 lOldPosition = this._ActorController._Transform.position;
				Vector3 lNewPosition = rPosition;
				Quaternion lOldRotation = this._ActorController._Transform.rotation;
				Quaternion lNewRotation = rRotation;
				while (lPercent < 1f && (rMove || rRotate))
				{
					lPercent = Mathf.Clamp01((Time.time - lStartTime) / rTime);
					if (rSmooth)
					{
						lPercent = NumberHelper.EaseInOutCubic(lPercent);
					}
					if (rMove)
					{
						Vector3 vector = Vector3.Lerp(lOldPosition, lNewPosition, lPercent);
						this._ActorController.SetPosition(vector);
					}
					if (rRotate)
					{
						Quaternion quaternion = Quaternion.Lerp(lOldRotation, lNewRotation, lPercent);
						this._ActorController.SetRotation(quaternion);
					}
					yield return null;
				}
				lOldPosition = default(Vector3);
				lNewPosition = default(Vector3);
				lOldRotation = default(Quaternion);
				lNewRotation = default(Quaternion);
			}
			yield break;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00036900 File Offset: 0x00034B00
		private void ProcessUserInput()
		{
			float movementX = this._InputSource.MovementX;
			float movementY = this._InputSource.MovementY;
			float num = Mathf.Sqrt(movementX * movementX + movementY * movementY);
			this.State.InputMagnitudeTrend.Value = num;
			if (movementY == 0f && movementX == 0f)
			{
				this.State.InputX = 0f;
				this.State.InputY = 0f;
				this.State.InputForward = Vector3.zero;
				this.State.InputFromAvatarAngle = 0f;
				this.State.InputFromCameraAngle = 0f;
				this._InputSource.InputFromCameraAngle = float.NaN;
				this._InputSource.InputFromAvatarAngle = float.NaN;
				return;
			}
			this.State.InputX = movementX;
			this.State.InputY = movementY;
			this.State.InputForward = new Vector3(movementX, 0f, movementY);
			if (!(this._CameraTransform == null))
			{
				Quaternion quaternion = QuaternionExt.FromToRotation(this._Transform.up, Vector3.up);
				Vector3 vector = quaternion * this._Transform.forward;
				Vector3 vector2 = quaternion * this._CameraTransform.forward;
				Vector3 vector3 = Quaternion.LookRotation(vector2, Vector3.up) * this.State.InputForward;
				this.State.InputFromCameraAngle = NumberHelper.GetHorizontalAngle(vector2, vector3);
				this.State.InputFromAvatarAngle = NumberHelper.GetHorizontalAngle(vector, vector3);
				this._InputSource.InputFromCameraAngle = ((this.State.InputMagnitudeTrend.Value == 0f) ? float.NaN : this.State.InputFromCameraAngle);
				this._InputSource.InputFromAvatarAngle = ((this.State.InputMagnitudeTrend.Value == 0f) ? float.NaN : this.State.InputFromAvatarAngle);
				return;
			}
			if (this._InputSource == null)
			{
				this.State.InputFromCameraAngle = 0f;
				this.State.InputFromAvatarAngle = 0f;
				return;
			}
			this.State.InputFromCameraAngle = this._InputSource.InputFromCameraAngle;
			this.State.InputFromAvatarAngle = this._InputSource.InputFromAvatarAngle;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x00036B40 File Offset: 0x00034D40
		private void ProcessMovementInput()
		{
			Vector3 velocity = this._ActorController.State.Velocity;
			if (velocity.sqrMagnitude <= 0.04f && this.mTargetPosition.sqrMagnitude == 0f && this.mTargetRotation == Quaternion.identity)
			{
				this.State.InputX = 0f;
				this.State.InputY = 0f;
				this.State.InputForward = Vector3.zero;
				this.State.InputFromCameraAngle = 0f;
				this.State.InputFromAvatarAngle = 0f;
				this.State.InputMagnitudeTrend.Value = 0f;
				return;
			}
			Vector3 vector = Vector3.zero;
			if (velocity.sqrMagnitude > 0.04f)
			{
				vector = velocity;
				if (this._MaxSpeed > 0f)
				{
					this.mTargetNormalizedSpeed = Mathf.Clamp01(vector.magnitude / this._MaxSpeed);
					if (this.mTargetNormalizedSpeed < 0.5f)
					{
						this.mTargetNormalizedSpeed = 0.5f;
					}
				}
			}
			else
			{
				NumberHelper.GetHorizontalDifference(this._Transform.position, this.mTargetPosition, ref vector);
			}
			float num;
			if (this.mIsTargetRotationSet)
			{
				num = NumberHelper.GetHorizontalAngle(this.mTargetRotation.Forward(), vector.normalized, this._Transform.up);
			}
			else
			{
				num = NumberHelper.GetHorizontalAngle(this._Transform.forward, vector.normalized);
			}
			float num2;
			if (vector.magnitude >= 0.001f)
			{
				num2 = this.mTargetNormalizedSpeed;
			}
			Vector3 vector2 = Quaternion.AngleAxis(num, this._Transform.up).Forward();
			float num3 = vector2.x * this.mTargetNormalizedSpeed;
			num2 = vector2.z * this.mTargetNormalizedSpeed;
			this.State.InputForward = new Vector3(num3, 0f, num2);
			this.State.InputX = this.State.InputForward.x;
			this.State.InputY = this.State.InputForward.z;
			this.State.InputMagnitudeTrend.Value = Mathf.Sqrt(num3 * num3 + num2 * num2);
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			if (this._CameraTransform == null)
			{
				this.State.InputFromCameraAngle = num;
			}
			else
			{
				Vector3 forward2 = this._CameraTransform.forward;
				forward2.y = 0f;
				forward2.Normalize();
				Vector3 vector3 = Quaternion.LookRotation(forward2) * this.State.InputForward;
				this.State.InputFromCameraAngle = NumberHelper.GetHorizontalAngle(forward2, vector3);
			}
			this.State.InputFromAvatarAngle = num;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00036E20 File Offset: 0x00035020
		private void ProcessSimulatedInput()
		{
			if (this.mTargetVelocity.sqrMagnitude == 0f && this.mTargetPosition.sqrMagnitude == 0f && this.mTargetRotation == Quaternion.identity)
			{
				this.State.InputX = 0f;
				this.State.InputY = 0f;
				this.State.InputForward = Vector3.zero;
				this.State.InputFromCameraAngle = 0f;
				this.State.InputFromAvatarAngle = 0f;
				this.State.InputMagnitudeTrend.Value = 0f;
				return;
			}
			float num = 0f;
			Vector3 zero = Vector3.zero;
			if (this.mIsTargetMovementSet)
			{
				if (this.mTargetVelocity.sqrMagnitude > 0f)
				{
					zero = this.mTargetVelocity;
					if (this.mTargetNormalizedSpeed == 0f && this._MaxSpeed > 0f)
					{
						this.mTargetNormalizedSpeed = Mathf.Clamp01(zero.magnitude / this._MaxSpeed);
					}
				}
				else
				{
					NumberHelper.GetHorizontalDifference(this._Transform.position, this.mTargetPosition, ref zero);
				}
				if (this.mIsTargetRotationSet)
				{
					num = NumberHelper.GetHorizontalAngle(this.mTargetRotation.Forward(), zero.normalized, this._Transform.up);
				}
				else
				{
					num = NumberHelper.GetHorizontalAngle(this._Transform.forward, zero.normalized);
				}
			}
			float num2;
			float num3;
			if (zero.magnitude < 0.001f)
			{
				num2 = 0f;
				num3 = 0f;
			}
			else
			{
				num2 = 0f;
				num3 = this.mTargetNormalizedSpeed;
			}
			if (this.mIsTargetMovementSet && this.mTargetPosition.sqrMagnitude > 0f && (this.mIsTargetRotationSet || this.mForceStrafing))
			{
				Vector3 vector = Quaternion.AngleAxis(num, this._Transform.up).Forward();
				num2 = vector.x * this.mTargetNormalizedSpeed;
				num3 = vector.z * this.mTargetNormalizedSpeed;
			}
			this.State.InputForward = new Vector3(num2, 0f, num3);
			this.State.InputX = this.State.InputForward.x;
			this.State.InputY = this.State.InputForward.z;
			this.State.InputMagnitudeTrend.Value = Mathf.Sqrt(num2 * num2 + num3 * num3);
			Vector3 forward = base.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			if (this._CameraTransform == null)
			{
				this.State.InputFromCameraAngle = num;
			}
			else
			{
				Vector3 forward2 = this._CameraTransform.forward;
				forward2.y = 0f;
				forward2.Normalize();
				Vector3 vector2 = Quaternion.LookRotation(forward2) * this.State.InputForward;
				this.State.InputFromCameraAngle = NumberHelper.GetHorizontalAngle(forward2, vector2);
			}
			this.State.InputFromAvatarAngle = num;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0003711C File Offset: 0x0003531C
		public int GetAnimatorMotionPhase(int rLayerIndex)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return 0;
			}
			return this.State.AnimatorStates[rLayerIndex].MotionPhase;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00037148 File Offset: 0x00035348
		public void SetAnimatorMotionPhase(int rLayerIndex, int rPhase)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			if (this.State.AnimatorStates[rLayerIndex].MotionPhase != rPhase)
			{
				if (this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID == this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash)
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = 0;
				}
				else
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
				}
			}
			this.State.AnimatorStates[rLayerIndex].MotionPhase = rPhase;
			this.State.AnimatorStates[rLayerIndex].MotionForm = 0;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhase = false;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhaseReady = false;
			if (rPhase != 0)
			{
				this.State.AnimatorStates[rLayerIndex].SetTime = Time.time;
			}
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00037278 File Offset: 0x00035478
		public void SetAnimatorMotionPhase(int rLayerIndex, int rPhase, bool rAutoClear)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			if (this.State.AnimatorStates[rLayerIndex].MotionPhase != rPhase)
			{
				if (this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID == this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash)
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = 0;
				}
				else
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
				}
			}
			this.State.AnimatorStates[rLayerIndex].MotionPhase = rPhase;
			this.State.AnimatorStates[rLayerIndex].MotionForm = 0;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhase = rAutoClear;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhaseReady = false;
			if (rPhase != 0)
			{
				this.State.AnimatorStates[rLayerIndex].SetTime = Time.time;
			}
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x000373A8 File Offset: 0x000355A8
		public void SetAnimatorMotionPhase(int rLayerIndex, int rPhase, int rParameter)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			if (this.State.AnimatorStates[rLayerIndex].MotionPhase != rPhase)
			{
				if (this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID == this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash)
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = 0;
				}
				else
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
				}
			}
			this.State.AnimatorStates[rLayerIndex].MotionPhase = rPhase;
			this.State.AnimatorStates[rLayerIndex].MotionForm = 0;
			this.State.AnimatorStates[rLayerIndex].MotionParameter = rParameter;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhase = false;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhaseReady = false;
			if (rPhase != 0)
			{
				this.State.AnimatorStates[rLayerIndex].SetTime = Time.time;
			}
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x000374F0 File Offset: 0x000356F0
		public void SetAnimatorMotionPhase(int rLayerIndex, int rPhase, int rParameter, bool rAutoClear)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			if (this.State.AnimatorStates[rLayerIndex].MotionPhase != rPhase)
			{
				if (this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID == this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash)
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = 0;
				}
				else
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
				}
			}
			this.State.AnimatorStates[rLayerIndex].MotionPhase = rPhase;
			this.State.AnimatorStates[rLayerIndex].MotionForm = 0;
			this.State.AnimatorStates[rLayerIndex].MotionParameter = rParameter;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhase = rAutoClear;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhaseReady = false;
			if (rPhase != 0)
			{
				this.State.AnimatorStates[rLayerIndex].SetTime = Time.time;
			}
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00037638 File Offset: 0x00035838
		public void SetAnimatorMotionPhase(int rLayerIndex, int rPhase, int rForm, int rParameter, bool rAutoClear)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			if (this.State.AnimatorStates[rLayerIndex].MotionPhase != rPhase)
			{
				if (this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID == this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash)
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = 0;
				}
				else
				{
					this.State.AnimatorStates[rLayerIndex].AutoClearActiveTransitionID = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
				}
			}
			this.State.AnimatorStates[rLayerIndex].MotionPhase = rPhase;
			this.State.AnimatorStates[rLayerIndex].MotionForm = rForm;
			this.State.AnimatorStates[rLayerIndex].MotionParameter = rParameter;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhase = rAutoClear;
			this.State.AnimatorStates[rLayerIndex].AutoClearMotionPhaseReady = false;
			if (rPhase != 0)
			{
				this.State.AnimatorStates[rLayerIndex].SetTime = Time.time;
			}
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0003777F File Offset: 0x0003597F
		public void SetAnimatorMotionParameter(int rLayerIndex, int rParameter)
		{
			if (rLayerIndex >= this.State.AnimatorStates.Length)
			{
				return;
			}
			this.State.AnimatorStates[rLayerIndex].MotionParameter = rParameter;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x000377AC File Offset: 0x000359AC
		private void SetAnimatorProperties(ref MotionState rState, bool rUseTrendData)
		{
			if (this._Animator == null)
			{
				return;
			}
			this._Animator.SetBool("IsGrounded", this._ActorController.State.IsGrounded);
			this._Animator.SetInteger("Stance", this._ActorController.State.Stance);
			if (this.MotionLayers.Count > 0 && rState.AnimatorStates.Length != 0 && this.ForcedInput.sqrMagnitude > 0f)
			{
				this._Animator.SetFloat("InputX", this.ForcedInput.x);
				this._Animator.SetFloat("InputY", this.ForcedInput.y);
				this._Animator.SetFloat("InputMagnitude", Mathf.Sqrt(this.ForcedInput.x * this.ForcedInput.x + this.ForcedInput.y * this.ForcedInput.y));
				if (rState.AnimatorStates[0].MotionPhase == 0 && this.MotionLayers[0]._AnimatorTransitionID == 0)
				{
					this.ForcedInput = Vector2.zero;
				}
			}
			else
			{
				this._Animator.SetFloat("InputX", rState.InputX);
				this._Animator.SetFloat("InputY", rState.InputY);
				this.mMecanimUpdateDelay -= Time.deltaTime;
				if (!rUseTrendData || this.mMecanimUpdateDelay <= 0f)
				{
					this._Animator.SetFloat("InputMagnitude", rState.InputMagnitudeTrend.Value);
				}
			}
			this._Animator.SetFloat("InputMagnitudeAvg", rState.InputMagnitudeTrend.Average);
			this._Animator.SetFloat("InputAngleFromAvatar", rState.InputFromAvatarAngle);
			this._Animator.SetFloat("InputAngleFromCamera", rState.InputFromCameraAngle);
			for (int i = 0; i < rState.AnimatorStates.Length; i++)
			{
				if (i < this.MotionLayers.Count)
				{
					AnimatorLayerState animatorLayerState = rState.AnimatorStates[i];
					if (this._AnimatorClearType == 0)
					{
						this._Animator.SetInteger(MotionController.MOTION_PHASE_NAMES[i], animatorLayerState.MotionPhase);
					}
					else
					{
						int integer = this._Animator.GetInteger(MotionController.MOTION_PHASE_NAMES[i]);
						if (animatorLayerState.MotionPhase != 0 || integer == 0 || (this._AnimatorClearType == 1 && animatorLayerState.SetTime + this._AnimatorClearDelay < Time.time))
						{
							this._Animator.SetInteger(MotionController.MOTION_PHASE_NAMES[i], animatorLayerState.MotionPhase);
						}
					}
					if (this.mUseMotionForms)
					{
						this._Animator.SetInteger(MotionController.MOTION_STYLE_NAMES[i], animatorLayerState.MotionForm);
					}
					this._Animator.SetInteger(MotionController.MOTION_PARAMETER_NAMES[i], animatorLayerState.MotionParameter);
					if (this.mUseMotionStateTimes)
					{
						this._Animator.SetFloat(MotionController.MOTION_STATE_TIME[i], animatorLayerState.StateInfo.normalizedTime % 1f);
					}
				}
				if (i < this.MotionLayers.Count && this.MotionLayers[i].ActiveMotion != null && !this.MotionLayers[i].ActiveMotion.HasAutoGeneratedCode && rState.AnimatorStates[i].AutoClearMotionPhase && rState.AnimatorStates[i].AutoClearMotionPhaseReady && rState.AnimatorStates[i].MotionPhase != 0)
				{
					rState.AnimatorStates[i].MotionPhase = 0;
					rState.AnimatorStates[i].AutoClearActiveTransitionID = 0;
				}
			}
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00037B44 File Offset: 0x00035D44
		private void OnAnimatorStateChange(int rAnimatorLayer)
		{
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				if (this.MotionLayers[i].AnimatorLayerIndex == rAnimatorLayer)
				{
					this.MotionLayers[i].OnAnimatorStateChange(rAnimatorLayer, this.PrevState.AnimatorStates[rAnimatorLayer].StateInfo.fullPathHash, this.State.AnimatorStates[rAnimatorLayer].StateInfo.fullPathHash);
				}
			}
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x00037BC4 File Offset: 0x00035DC4
		public void OnAnimatorMove()
		{
			if (Time.deltaTime == 0f)
			{
				return;
			}
			if (this._Animator == null)
			{
				this.mRootMotionMovement = Vector3.zero;
				this.mRootMotionRotation = Quaternion.identity;
				return;
			}
			this.mRootMotionMovement = Quaternion.Inverse(this._Transform.rotation) * (this._Animator.deltaPosition * this.rootMotionScale);
			if (this._IsTimeSmoothingEnabled)
			{
				this.mRootMotionMovement = this.mRootMotionMovement / Time.deltaTime * TimeManager.SmoothedDeltaTime;
			}
			this.mRootMotionRotation = this._Animator.deltaRotation;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x00037C70 File Offset: 0x00035E70
		public void OnAnimatorIK(int rLayerIndex)
		{
			if (this._Animator == null)
			{
				return;
			}
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				MotionControllerLayer motionControllerLayer = this.MotionLayers[i];
				if (motionControllerLayer.AnimatorLayerIndex == rLayerIndex)
				{
					MotionControllerMotion activeMotion = motionControllerLayer.ActiveMotion;
					if (activeMotion != null)
					{
						activeMotion.OnAnimatorIK(this._Animator, rLayerIndex);
					}
				}
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00037CD0 File Offset: 0x00035ED0
		public void OnAnimationEvent(AnimationEvent rEvent)
		{
			int num = 0;
			if (rEvent != null && rEvent.isFiredByAnimator)
			{
				num = rEvent.animatorStateInfo.fullPathHash;
			}
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				if (num == 0 || this.MotionLayers[i]._AnimatorStateID == num)
				{
					this.MotionLayers[i].OnAnimationEvent(rEvent);
					if (num != 0)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00037D3B File Offset: 0x00035F3B
		public void SendMessage(IMessage rMessage)
		{
			rMessage.IsSent = true;
			rMessage.IsHandled = false;
			this.OnMessageReceived(rMessage);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00037D54 File Offset: 0x00035F54
		private void OnMessageReceived(IMessage rMessage)
		{
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				this.MotionLayers[i].OnMessageReceived(rMessage);
				if (rMessage.IsHandled)
				{
					break;
				}
			}
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00037D91 File Offset: 0x00035F91
		public GameObject GetStoredGameObject(int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._StoredGameObjects.Count)
			{
				return null;
			}
			return this._StoredGameObjects[rIndex];
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00037DB4 File Offset: 0x00035FB4
		public GameObject GetStoredGameObject(ref int rIndex)
		{
			if (rIndex < 0 || rIndex >= this._StoredGameObjects.Count)
			{
				rIndex = -1;
				return null;
			}
			if (this._StoredGameObjects[rIndex] == null)
			{
				rIndex = -1;
				return null;
			}
			return this._StoredGameObjects[rIndex];
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00037E04 File Offset: 0x00036004
		public int StoreGameObject(int rIndex, GameObject rObject)
		{
			int num = rIndex;
			if (rObject == null)
			{
				if (num >= 0 && num < this._StoredGameObjects.Count)
				{
					this._StoredGameObjects[num] = null;
					int num2 = this._StoredGameObjects.Count - 1;
					while (num2 >= 0 && this._StoredGameObjects[num2] == null)
					{
						this._StoredGameObjects.RemoveAt(num2);
						num2--;
					}
				}
				num = -1;
			}
			else
			{
				if (num == -1)
				{
					num = this._StoredGameObjects.Count;
					this._StoredGameObjects.Add(null);
				}
				this._StoredGameObjects[num] = rObject;
			}
			return num;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00037EA4 File Offset: 0x000360A4
		private void LoadAnimatorData()
		{
			this.AddAnimatorName("Start");
			this.AddAnimatorName("Any State");
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				this.MotionLayers[i].LoadAnimatorData();
			}
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x00037EF0 File Offset: 0x000360F0
		public int AddAnimatorName(string rName)
		{
			int num = Animator.StringToHash(rName);
			if (!this.AnimatorStateNames.ContainsKey(num))
			{
				this.AnimatorStateNames.Add(num, rName);
			}
			if (!this.AnimatorStateIDs.ContainsKey(rName))
			{
				this.AnimatorStateIDs.Add(rName, num);
			}
			return num;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00037F3C File Offset: 0x0003613C
		public bool CompareAnimatorStateName(int rLayerIndex, string rStateName)
		{
			return this.State.AnimatorStates[rLayerIndex].StateInfo.fullPathHash == this.AnimatorStateIDs[rStateName] || this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash == this.AnimatorStateIDs[rStateName];
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00037FA0 File Offset: 0x000361A0
		public bool CompareAnimatorTransitionName(int rLayerIndex, string rTransitionName)
		{
			return this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash == this.AnimatorStateIDs[rTransitionName];
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x00037FCC File Offset: 0x000361CC
		public string GetAnimatorStateName()
		{
			string text = "";
			for (int i = 0; i < this.Animator.layerCount; i++)
			{
				text = this.GetAnimatorStateName(i);
				if (text.Length > 0)
				{
					break;
				}
			}
			return text;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x00038008 File Offset: 0x00036208
		public string GetAnimatorStateAndTransitionName()
		{
			int fullPathHash = this.State.AnimatorStates[0].StateInfo.fullPathHash;
			int fullPathHash2 = this.State.AnimatorStates[0].TransitionInfo.fullPathHash;
			return this.AnimatorHashToString(fullPathHash, fullPathHash2);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00038058 File Offset: 0x00036258
		public string GetAnimatorStateName(int rLayerIndex)
		{
			string text = "";
			int fullPathHash = this.State.AnimatorStates[rLayerIndex].StateInfo.fullPathHash;
			if (this.AnimatorStateNames.ContainsKey(fullPathHash))
			{
				text = this.AnimatorStateNames[fullPathHash];
			}
			return text;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x000380A4 File Offset: 0x000362A4
		public string GetAnimatorStateTransitionName(int rLayerIndex)
		{
			string text = "";
			int fullPathHash = this.State.AnimatorStates[rLayerIndex].StateInfo.fullPathHash;
			int num = this.State.AnimatorStates[rLayerIndex].TransitionInfo.fullPathHash;
			if (num != 0 && this.AnimatorStateNames.ContainsKey(num))
			{
				text = this.AnimatorStateNames[num];
			}
			else
			{
				num = this.State.AnimatorStates[rLayerIndex].TransitionInfo.nameHash;
				if (num != 0 && this.AnimatorStateNames.ContainsKey(num))
				{
					text = this.AnimatorStateNames[num];
				}
				else if (this.AnimatorStateNames.ContainsKey(fullPathHash))
				{
					text = this.AnimatorStateNames[fullPathHash];
				}
			}
			return text;
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00038168 File Offset: 0x00036368
		public string AnimatorHashToString(int rStateID, int rTransitionID)
		{
			string text = (this.AnimatorStateNames.ContainsKey(rStateID) ? this.AnimatorStateNames[rStateID] : rStateID.ToString());
			string text2 = (this.AnimatorStateNames.ContainsKey(rTransitionID) ? this.AnimatorStateNames[rTransitionID] : rTransitionID.ToString());
			return string.Format("state:{0} trans:{1}", text, text2);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x000381C9 File Offset: 0x000363C9
		public string StateHashToString(int rStateID)
		{
			if (!this.AnimatorStateNames.ContainsKey(rStateID))
			{
				return rStateID.ToString();
			}
			return this.AnimatorStateNames[rStateID];
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x000381ED File Offset: 0x000363ED
		public string TransitionHashToString(int rTransitionID)
		{
			if (!this.AnimatorStateNames.ContainsKey(rTransitionID))
			{
				return rTransitionID.ToString();
			}
			return this.AnimatorStateNames[rTransitionID];
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00038214 File Offset: 0x00036414
		public string AnimatorHashToString(AnimatorStateInfo rState, AnimatorTransitionInfo rTransition)
		{
			string text = "0";
			int fullPathHash = rState.fullPathHash;
			string text2;
			if (fullPathHash != 0)
			{
				text2 = (this.AnimatorStateNames.ContainsKey(fullPathHash) ? this.AnimatorStateNames[fullPathHash] : fullPathHash.ToString());
			}
			else
			{
				text2 = fullPathHash.ToString();
			}
			int num = rTransition.fullPathHash;
			if (num != 0)
			{
				if (this.AnimatorStateNames.ContainsKey(num))
				{
					text = this.AnimatorStateNames[num];
				}
				else
				{
					num = rTransition.nameHash;
					if (this.AnimatorStateNames.ContainsKey(num))
					{
						text = this.AnimatorStateNames[num];
					}
					else
					{
						text = num.ToString();
					}
				}
			}
			return string.Format("state[{1}]:{0} trans[{3}]:{2}", new object[]
			{
				text2,
				rState.normalizedTime.ToString("f3"),
				text,
				(rTransition.normalizedTime - (float)((int)rTransition.normalizedTime)).ToString("f3")
			});
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00038310 File Offset: 0x00036510
		public IBaseCameraRig ExtractCameraRig(Transform rCamera)
		{
			if (rCamera == null)
			{
				return null;
			}
			Transform transform = rCamera;
			while (transform != null)
			{
				IBaseCameraRig[] components = InterfaceHelper.GetComponents<IBaseCameraRig>(transform.gameObject);
				if (components != null && components.Length != 0)
				{
					for (int i = 0; i < components.Length; i++)
					{
						MonoBehaviour monoBehaviour = (MonoBehaviour)components[i];
						if (monoBehaviour.enabled && monoBehaviour.gameObject.activeSelf)
						{
							return components[i];
						}
					}
				}
				transform = transform.parent;
			}
			return null;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00038380 File Offset: 0x00036580
		private void DetermineTrendData()
		{
			if (this.State.InputMagnitudeTrend.Value == this.PrevState.InputMagnitudeTrend.Value)
			{
				if (this.mSpeedTrendDirection != 0)
				{
					this.mSpeedTrendDirection = 0;
					return;
				}
			}
			else if (this.State.InputMagnitudeTrend.Value < this.PrevState.InputMagnitudeTrend.Value)
			{
				if (this.mSpeedTrendDirection != 1)
				{
					this.mSpeedTrendDirection = 1;
					if (this.mMecanimUpdateDelay <= 0f)
					{
						this.mMecanimUpdateDelay = 0.2f;
						return;
					}
				}
			}
			else if (this.State.InputMagnitudeTrend.Value > this.PrevState.InputMagnitudeTrend.Value && this.mSpeedTrendDirection != 2)
			{
				this.mSpeedTrendDirection = 2;
				if (this.mMecanimUpdateDelay <= 0f)
				{
					this.mMecanimUpdateDelay = 0.2f;
				}
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00038458 File Offset: 0x00036658
		private void OnDrawGizmos()
		{
			for (int i = 0; i < this.MotionLayers.Count; i++)
			{
				this.MotionLayers[i].OnDrawGizmos();
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0003848C File Offset: 0x0003668C
		protected void Awake()
		{
			if (base.GetComponent<ITValleMotionControllerUpdater>() == null)
			{
				base.gameObject.AddComponent<DefaultMotionControllerUpdater>();
			}
			this.Awake_();
			if (this._Animator != null)
			{
				this._Animator.gameObject.AddComponent<MotionControllerAnimatorEventsListiner>();
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x000384C7 File Offset: 0x000366C7
		public void DoStart()
		{
			if (this.m_stared)
			{
				return;
			}
			this.Start();
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x000384D8 File Offset: 0x000366D8
		public void FixedUpdateMotion()
		{
			this.FixedUpdate_();
		}

		// Token: 0x040005F9 RID: 1529
		public const float GROUND_DISTANCE_TEST = 0.075f;

		// Token: 0x040005FA RID: 1530
		public static string[] MOTION_PHASE_NAMES = new string[] { "L0MotionPhase", "L1MotionPhase", "L2MotionPhase", "L3MotionPhase", "L4MotionPhase", "L5MotionPhase", "L6MotionPhase", "L7MotionPhase", "L8MotionPhase", "L9MotionPhase" };

		// Token: 0x040005FB RID: 1531
		public static string[] MOTION_STYLE_NAMES = new string[] { "L0MotionForm", "L1MotionForm", "L2MotionForm", "L3MotionForm", "L4MotionForm", "L5MotionForm", "L6MotionForm", "L7MotionForm", "L8MotionForm", "L9MotionForm" };

		// Token: 0x040005FC RID: 1532
		public static string[] MOTION_PARAMETER_NAMES = new string[] { "L0MotionParameter", "L1MotionParameter", "L2MotionParameter", "L3MotionParameter", "L4MotionParameter", "L5MotionParameter", "L6MotionParameter", "L7MotionParameter", "L8MotionParameter", "L9MotionParameter" };

		// Token: 0x040005FD RID: 1533
		public static string[] MOTION_STATE_TIME = new string[] { "L0MotionStateTime", "L1MotionStateTime", "L2MotionStateTime", "L3MotionStateTime", "L4MotionStateTime", "L5MotionStateTime", "L6MotionStateTime", "L7MotionStateTime", "L8MotionStateTime", "L9MotionStateTime" };

		// Token: 0x040005FE RID: 1534
		public bool _IsEnabled = true;

		// Token: 0x040005FF RID: 1535
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x04000600 RID: 1536
		public IActorStateSource _StateSource;

		// Token: 0x04000601 RID: 1537
		protected int mDefaultForm;

		// Token: 0x04000602 RID: 1538
		protected int mCurrentForm;

		// Token: 0x04000603 RID: 1539
		[NonSerialized]
		public IActorCore _ActorCore;

		// Token: 0x04000604 RID: 1540
		public float rootMotionScale = 1f;

		// Token: 0x04000605 RID: 1541
		[NonSerialized]
		public ActorController _ActorController;

		// Token: 0x04000606 RID: 1542
		public Animator _Animator;

		// Token: 0x04000607 RID: 1543
		public GameObject _InputSourceOwner;

		// Token: 0x04000608 RID: 1544
		[NonSerialized]
		public IInputSource _InputSource;

		// Token: 0x04000609 RID: 1545
		public bool _AutoFindInputSource = true;

		// Token: 0x0400060A RID: 1546
		public MessageEvent AnimatorChangedEvent;

		// Token: 0x0400060B RID: 1547
		public MessageEvent MotionTestActivateEvent;

		// Token: 0x0400060C RID: 1548
		public MessageEvent MotionActivatedEvent;

		// Token: 0x0400060D RID: 1549
		public MessageEvent MotionDeactivatedEvent;

		// Token: 0x0400060E RID: 1550
		public MessageEvent ActionTriggeredEvent;

		// Token: 0x0400060F RID: 1551
		[NonSerialized]
		public MotionActivationDelegate MotionActivated;

		// Token: 0x04000610 RID: 1552
		[NonSerialized]
		public MotionUpdateDelegate MotionUpdated;

		// Token: 0x04000611 RID: 1553
		[NonSerialized]
		public MotionDelegate MotionDeactivated;

		// Token: 0x04000612 RID: 1554
		public bool _UseSimulatedInput;

		// Token: 0x04000613 RID: 1555
		public Transform _CameraTransform;

		// Token: 0x04000614 RID: 1556
		protected IBaseCameraRig mCameraRig;

		// Token: 0x04000615 RID: 1557
		public bool _AutoFindCameraTransform = true;

		// Token: 0x04000616 RID: 1558
		public bool _IsTimeSmoothingEnabled;

		// Token: 0x04000617 RID: 1559
		public float _MaxSpeed = 5.668f;

		// Token: 0x04000618 RID: 1560
		public float _RotationSpeed = 360f;

		// Token: 0x04000619 RID: 1561
		protected Vector3 mTargetVelocity = Vector3.zero;

		// Token: 0x0400061A RID: 1562
		protected Vector3 mTargetPosition = Vector3.zero;

		// Token: 0x0400061B RID: 1563
		protected float mTargetStopDistance = 0.1f;

		// Token: 0x0400061C RID: 1564
		protected bool mIsTargetMovementSet;

		// Token: 0x0400061D RID: 1565
		protected float mTargetNormalizedSpeed = 1f;

		// Token: 0x0400061E RID: 1566
		protected Quaternion mTargetRotation = Quaternion.identity;

		// Token: 0x0400061F RID: 1567
		protected bool mIsTargetRotationSet;

		// Token: 0x04000620 RID: 1568
		protected bool mForceStrafing;

		// Token: 0x04000621 RID: 1569
		public MotionState State;

		// Token: 0x04000622 RID: 1570
		public MotionState PrevState;

		// Token: 0x04000623 RID: 1571
		protected List<Force> mAppliedForces = new List<Force>();

		// Token: 0x04000624 RID: 1572
		public List<MotionControllerLayer> MotionLayers = new List<MotionControllerLayer>();

		// Token: 0x04000625 RID: 1573
		public bool _ShowDebug;

		// Token: 0x04000626 RID: 1574
		public bool _ShowDebugForAllMotions;

		// Token: 0x04000627 RID: 1575
		public int _AnimatorClearType;

		// Token: 0x04000628 RID: 1576
		public float _AnimatorClearDelay = 0.2f;

		// Token: 0x04000629 RID: 1577
		[NonSerialized]
		public Vector2 ForcedInput = Vector2.zero;

		// Token: 0x0400062A RID: 1578
		private int mSpeedTrendDirection;

		// Token: 0x0400062B RID: 1579
		private float mMecanimUpdateDelay;

		// Token: 0x0400062C RID: 1580
		private Vector3 mAccumulatedAcceleration = Vector3.zero;

		// Token: 0x0400062D RID: 1581
		private Vector3 mAccumulatedVelocity = Vector3.zero;

		// Token: 0x0400062E RID: 1582
		private Vector3 mRootMotionMovement = Vector3.zero;

		// Token: 0x0400062F RID: 1583
		private Quaternion mRootMotionRotation = Quaternion.identity;

		// Token: 0x04000630 RID: 1584
		protected bool mUseMotionStateTimes;

		// Token: 0x04000631 RID: 1585
		protected bool mUseMotionForms;

		// Token: 0x04000632 RID: 1586
		public Dictionary<int, string> AnimatorStateNames = new Dictionary<int, string>();

		// Token: 0x04000633 RID: 1587
		public Dictionary<string, int> AnimatorStateIDs = new Dictionary<string, int>();

		// Token: 0x04000634 RID: 1588
		public List<GameObject> _StoredGameObjects = new List<GameObject>();

		// Token: 0x04000635 RID: 1589
		private bool m_stared;
	}
}

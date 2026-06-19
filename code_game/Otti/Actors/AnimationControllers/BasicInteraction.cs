using System;
using System.Collections;
using com.ootii.Actors.LifeCores;
using com.ootii.Geometry;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x020000F3 RID: 243
	[MotionName("Basic Interaction")]
	[MotionDescription("Simple motion to handle object interactions like opening doors, opening chests, picking up objects, etc.")]
	public class BasicInteraction : MotionControllerMotion
	{
		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000D09 RID: 3337 RVA: 0x00040772 File Offset: 0x0003E972
		public override bool VerifyTransition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x00040775 File Offset: 0x0003E975
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x0004077D File Offset: 0x0003E97D
		public bool IsInteractableRaycastEnabled
		{
			get
			{
				return this._IsInteractableRaycastEnabled;
			}
			set
			{
				this._IsInteractableRaycastEnabled = value;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00040786 File Offset: 0x0003E986
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x0004078E File Offset: 0x0003E98E
		public string InteractableRaycastRoot
		{
			get
			{
				return this._InteractableRaycastRoot;
			}
			set
			{
				this._InteractableRaycastRoot = value;
				if (Application.isPlaying)
				{
					this.mRaycastRoot = this.FindTransform(this._InteractableRaycastRoot);
				}
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x000407B0 File Offset: 0x0003E9B0
		// (set) Token: 0x06000D0F RID: 3343 RVA: 0x000407B8 File Offset: 0x0003E9B8
		public int InteractableLayers
		{
			get
			{
				return this._InteractableLayers;
			}
			set
			{
				this._InteractableLayers = value;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x000407C1 File Offset: 0x0003E9C1
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x000407C9 File Offset: 0x0003E9C9
		public float InteractableDistance
		{
			get
			{
				return this._InteractableDistance;
			}
			set
			{
				this._InteractableDistance = value;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x000407D2 File Offset: 0x0003E9D2
		// (set) Token: 0x06000D13 RID: 3347 RVA: 0x000407DA File Offset: 0x0003E9DA
		public bool IsInteractableCoreRequired
		{
			get
			{
				return this._IsInteractableCoreRequired;
			}
			set
			{
				this._IsInteractableCoreRequired = value;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x000407E3 File Offset: 0x0003E9E3
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x000407EB File Offset: 0x0003E9EB
		public string WalkRunMotion
		{
			get
			{
				return this._WalkRunMotion;
			}
			set
			{
				this._WalkRunMotion = value;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x000407F4 File Offset: 0x0003E9F4
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x000407FC File Offset: 0x0003E9FC
		public float WalkSpeed
		{
			get
			{
				return this._WalkSpeed;
			}
			set
			{
				this._WalkSpeed = value;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00040805 File Offset: 0x0003EA05
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0004080D File Offset: 0x0003EA0D
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

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00040816 File Offset: 0x0003EA16
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x0004081E File Offset: 0x0003EA1E
		public GameObject Interactable
		{
			get
			{
				return this.mInteractable;
			}
			set
			{
				this.mInteractable = value;
				this.mInteractableCore = ((this.mInteractable != null) ? this.mInteractable.GetComponent<InteractableCore>() : null);
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x00040849 File Offset: 0x0003EA49
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x00040851 File Offset: 0x0003EA51
		public IInteractableCore InteractableCore
		{
			get
			{
				return this.mInteractableCore;
			}
			set
			{
				this.mInteractableCore = value;
				this.mInteractable = ((this.mInteractableCore != null) ? this.mInteractableCore.gameObject : null);
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x00040876 File Offset: 0x0003EA76
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x0004087E File Offset: 0x0003EA7E
		public int ActiveForm
		{
			get
			{
				return this.mActiveForm;
			}
			set
			{
				this.mActiveForm = value;
			}
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00040888 File Offset: 0x0003EA88
		public BasicInteraction()
		{
			this._Category = 600;
			this._Priority = 20f;
			this._ActionAlias = "Interact";
			this._Form = 0;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x00040990 File Offset: 0x0003EB90
		public BasicInteraction(MotionController rController)
			: base(rController)
		{
			this._Category = 600;
			this._Priority = 20f;
			this._ActionAlias = "Interact";
			this._Form = 0;
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00040A97 File Offset: 0x0003EC97
		public override void Awake()
		{
			base.Awake();
			this.InteractableRaycastRoot = this._InteractableRaycastRoot;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x00040AAC File Offset: 0x0003ECAC
		public override bool TestActivate()
		{
			if (!this.mIsStartable)
			{
				return false;
			}
			if (!this.mMotionController.IsGrounded)
			{
				return false;
			}
			if (this._IsInteractableRaycastEnabled)
			{
				bool flag = false;
				Vector3 vector = ((this.mMotionController.CameraTransform != null) ? this.mMotionController.CameraTransform.position : this.mMotionController._Transform.position);
				Vector3 vector2 = ((this.mMotionController.CameraTransform != null) ? this.mMotionController.CameraTransform.forward : this.mMotionController._Transform.forward);
				RaycastHit raycastHit;
				if (RaycastExt.SafeRaycast(vector, vector2, out raycastHit, this._InteractableDistance * 5f, this._InteractableLayers, this.mMotionController._Transform, null, true, false))
				{
					bool flag2 = true;
					if (this.mRaycastRoot != null && Vector3.Distance(raycastHit.point, this.mRaycastRoot.position) > this._InteractableDistance)
					{
						flag2 = false;
					}
					if (flag2)
					{
						IInteractableCore interactableCore = raycastHit.collider.gameObject.GetComponent<IInteractableCore>();
						if (interactableCore == null)
						{
							interactableCore = raycastHit.collider.gameObject.GetComponentInParent<IInteractableCore>();
						}
						if (!this._IsInteractableCoreRequired && interactableCore == null)
						{
							flag = true;
							this.Interactable = raycastHit.collider.gameObject;
						}
						else
						{
							if (interactableCore == null)
							{
								flag2 = false;
							}
							if (flag2 && !interactableCore.IsEnabled)
							{
								flag2 = false;
							}
							if (flag2 && !interactableCore.TestActivator(this.mMotionController._Transform))
							{
								flag2 = false;
							}
							if (flag2 && interactableCore.RaycastCollider != null && raycastHit.collider != interactableCore.RaycastCollider)
							{
								flag2 = false;
							}
							if (flag2)
							{
								flag = true;
								this.InteractableCore = interactableCore;
								this.InteractableCore.StartFocus();
								this.mActiveForm = interactableCore.Form;
							}
						}
					}
				}
				if (!flag && this._IsInteractableRaycastEnabled)
				{
					this.Interactable = null;
				}
			}
			if (this._ActionAlias.Length > 0 && this.mMotionController._InputSource != null && this.mMotionController._InputSource.IsJustPressed(this._ActionAlias))
			{
				if (this.InteractableCore != null)
				{
					if (!this.InteractableCore.ForcePosition && !this.InteractableCore.ForceRotation)
					{
						return true;
					}
					this.mMotionController.StartCoroutine(this.MoveToTargetInternal(this.InteractableCore));
				}
				else if (this.Interactable != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x00040D09 File Offset: 0x0003EF09
		public override bool TestUpdate()
		{
			return !this.mMotionController.State.AnimatorStates[this.mMotionLayer._AnimatorLayerIndex].StateInfo.IsTag("Exit");
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x00040D40 File Offset: 0x0003EF40
		public override bool Activate(MotionControllerMotion rPrevMotion)
		{
			this.mActiveForm = ((this.mActiveForm >= 0) ? this.mActiveForm : this._Form);
			this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_START, this.mActiveForm, this.mParameter, true);
			return base.Activate(rPrevMotion);
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00040D9A File Offset: 0x0003EF9A
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00040DA2 File Offset: 0x0003EFA2
		public override void UpdateRootMotion(float rDeltaTime, int rUpdateIndex, ref Vector3 rMovement, ref Quaternion rRotation)
		{
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00040DA4 File Offset: 0x0003EFA4
		public override void Update(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x00040DA8 File Offset: 0x0003EFA8
		public override void OnAnimationEvent(AnimationEvent rEvent)
		{
			if (rEvent == null)
			{
				return;
			}
			if (!this.mIsActive)
			{
				return;
			}
			if (this.mInteractableCore != null)
			{
				this.mInteractableCore.OnActivated(this);
			}
			if (this.OnTriggeredEvent != null)
			{
				this.OnTriggeredEvent(this.mMotionLayer._AnimatorLayerIndex, this);
			}
			if (this.mMotionController.ActionTriggeredEvent != null)
			{
				Message message = Message.Allocate();
				message.ID = EnumMessageID.MSG_INTERACTION_ACTIVATE;
				message.Data = this.mInteractable;
				this.mMotionController.ActionTriggeredEvent.Invoke(message);
				Message.Release(message);
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00040E38 File Offset: 0x0003F038
		public override void OnMessageReceived(IMessage rMessage)
		{
			if (rMessage == null)
			{
				return;
			}
			MotionMessage motionMessage = rMessage as MotionMessage;
			if (motionMessage != null)
			{
				if (motionMessage.ID == MotionMessage.MSG_MOTION_ACTIVATE && !this.mIsActive)
				{
					this.mActiveForm = ((motionMessage.Form >= 0) ? motionMessage.Form : this._Form);
					this.Activate(this.mMotionLayer.ActiveMotion);
					motionMessage.IsHandled = true;
					motionMessage.Recipient = this;
				}
				if (motionMessage.ID == MotionMessage.MSG_MOTION_CONTINUE && this.mIsActive)
				{
					this.mMotionController.SetAnimatorMotionPhase(this.mMotionLayer.AnimatorLayerIndex, this.PHASE_CONTINUE, 0, 0, true);
					motionMessage.IsHandled = true;
					motionMessage.Recipient = this;
				}
			}
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00040EEA File Offset: 0x0003F0EA
		protected virtual IEnumerator MoveToTargetInternal(IInteractableCore rInteractableCore)
		{
			bool lStoredWalkRunMotionEnabled = false;
			bool lStoredUseTransformPosition = false;
			bool lStoredUseTransformRotation = false;
			MotionController lMotionController = this.mMotionController;
			ActorController lActorController = lMotionController._ActorController;
			lStoredUseTransformPosition = lActorController.UseTransformPosition;
			lActorController.UseTransformPosition = true;
			lStoredUseTransformRotation = lActorController.UseTransformRotation;
			lActorController.UseTransformRotation = true;
			MotionControllerMotion lWalkRunMotion = lMotionController.GetMotion(this._WalkRunMotion, true);
			if (lWalkRunMotion != null)
			{
				lStoredWalkRunMotionEnabled = lWalkRunMotion.IsEnabled;
				lWalkRunMotion.IsEnabled = true;
			}
			Vector3 lTargetPosition = lActorController._Transform.position;
			if (rInteractableCore.ForcePosition)
			{
				if (rInteractableCore.TargetLocation != null)
				{
					lTargetPosition = rInteractableCore.TargetLocation.position;
				}
				else if (rInteractableCore.TargetDistance > 0f)
				{
					Vector3 position = rInteractableCore.gameObject.transform.position;
					position.y = lActorController._Transform.position.y;
					lTargetPosition = position + (lActorController._Transform.position - position).normalized * rInteractableCore.TargetDistance;
				}
			}
			Vector3 lTargetForward = lActorController._Transform.forward;
			if (rInteractableCore.ForceRotation)
			{
				if (rInteractableCore.TargetLocation != null)
				{
					lTargetForward = rInteractableCore.TargetLocation.forward;
				}
				else
				{
					Vector3 position2 = rInteractableCore.gameObject.transform.position;
					position2.y = lActorController._Transform.position.y;
					lTargetForward = (position2 - lActorController._Transform.position).normalized;
				}
			}
			Vector3 vector = lTargetPosition - lActorController._Transform.position;
			float num = lActorController._Transform.forward.HorizontalAngleTo(lTargetForward);
			while (this.HorizontalDistance(lActorController._Transform.position, lTargetPosition) > 0.01f || Mathf.Abs(num) > 0.1f)
			{
				float num2 = Mathf.Min(vector.magnitude, this._WalkSpeed * Time.deltaTime);
				lActorController._Transform.position = lActorController._Transform.position + vector.normalized * num2;
				float num3 = Mathf.Sign(num) * Mathf.Min(Mathf.Abs(num), this._RotationSpeed * Time.deltaTime);
				lActorController._Transform.rotation = lActorController._Transform.rotation * Quaternion.Euler(0f, num3, 0f);
				yield return new WaitForEndOfFrame();
				vector = lTargetPosition - lActorController._Transform.position;
				num = lActorController._Transform.forward.HorizontalAngleTo(lTargetForward);
			}
			this.mActiveForm = rInteractableCore.Form;
			this.InteractableCore = rInteractableCore;
			lMotionController.ActivateMotion(this, 0);
			yield return new WaitForSeconds(0.2f);
			if (lWalkRunMotion != null)
			{
				lWalkRunMotion.IsEnabled = lStoredWalkRunMotionEnabled;
			}
			lActorController.UseTransformPosition = lStoredUseTransformPosition;
			lActorController.UseTransformRotation = lStoredUseTransformRotation;
			lMotionController.TargetNormalizedSpeed = 1f;
			yield break;
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00040F00 File Offset: 0x0003F100
		protected Transform FindTransform(string rName)
		{
			if (rName.Length > 0)
			{
				Transform transform = this.mMotionController._Transform.Find(rName);
				if (transform != null)
				{
					return transform;
				}
				string[] names = Enum.GetNames(typeof(HumanBodyBones));
				for (int i = 0; i < names.Length; i++)
				{
					if (string.Compare(names[i].Replace(" ", string.Empty).Replace("_", string.Empty), this._InteractableRaycastRoot) == 0)
					{
						return this.mMotionController.Animator.GetBoneTransform((HumanBodyBones)i);
					}
				}
			}
			return this.mMotionController._Transform;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x00040F9C File Offset: 0x0003F19C
		protected float HorizontalDistance(Vector3 rVector1, Vector3 rVector2)
		{
			rVector2.y = rVector1.y;
			return Vector3.Distance(rVector1, rVector2);
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00040FB2 File Offset: 0x0003F1B2
		public override bool HasAutoGeneratedCode
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x00040FB8 File Offset: 0x0003F1B8
		public override bool IsInMotionState
		{
			get
			{
				int animatorStateID = this.mMotionLayer._AnimatorStateID;
				int animatorTransitionID = this.mMotionLayer._AnimatorTransitionID;
				if (animatorTransitionID == 0)
				{
					if (animatorStateID == this.STATE_Start)
					{
						return true;
					}
					if (animatorStateID == this.STATE_Idle_GrabHighFront)
					{
						return true;
					}
					if (animatorStateID == this.STATE_Idle_PickUp)
					{
						return true;
					}
					if (animatorStateID == this.STATE_Idle_PushButton)
					{
						return true;
					}
					if (animatorStateID == this.STATE_IdlePose)
					{
						return true;
					}
				}
				return animatorTransitionID == this.TRANS_AnyState_Idle_PushButton || animatorTransitionID == this.TRANS_EntryState_Idle_PushButton || animatorTransitionID == this.TRANS_AnyState_Idle_GrabHighFront || animatorTransitionID == this.TRANS_EntryState_Idle_GrabHighFront || animatorTransitionID == this.TRANS_AnyState_Idle_PickUp || animatorTransitionID == this.TRANS_EntryState_Idle_PickUp || animatorTransitionID == this.TRANS_Idle_GrabHighFront_IdlePose || animatorTransitionID == this.TRANS_Idle_PickUp_IdlePose || animatorTransitionID == this.TRANS_Idle_PushButton_IdlePose;
			}
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0004107B File Offset: 0x0003F27B
		public override bool IsMotionState(int rStateID)
		{
			return rStateID == this.STATE_Start || rStateID == this.STATE_Idle_GrabHighFront || rStateID == this.STATE_Idle_PickUp || rStateID == this.STATE_Idle_PushButton || rStateID == this.STATE_IdlePose;
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x000410B8 File Offset: 0x0003F2B8
		public override bool IsMotionState(int rStateID, int rTransitionID)
		{
			if (rTransitionID == 0)
			{
				if (rStateID == this.STATE_Start)
				{
					return true;
				}
				if (rStateID == this.STATE_Idle_GrabHighFront)
				{
					return true;
				}
				if (rStateID == this.STATE_Idle_PickUp)
				{
					return true;
				}
				if (rStateID == this.STATE_Idle_PushButton)
				{
					return true;
				}
				if (rStateID == this.STATE_IdlePose)
				{
					return true;
				}
			}
			return rTransitionID == this.TRANS_AnyState_Idle_PushButton || rTransitionID == this.TRANS_EntryState_Idle_PushButton || rTransitionID == this.TRANS_AnyState_Idle_GrabHighFront || rTransitionID == this.TRANS_EntryState_Idle_GrabHighFront || rTransitionID == this.TRANS_AnyState_Idle_PickUp || rTransitionID == this.TRANS_EntryState_Idle_PickUp || rTransitionID == this.TRANS_Idle_GrabHighFront_IdlePose || rTransitionID == this.TRANS_Idle_PickUp_IdlePose || rTransitionID == this.TRANS_Idle_PushButton_IdlePose;
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00041164 File Offset: 0x0003F364
		public override void LoadAnimatorData()
		{
			string layerName = this.mMotionController.Animator.GetLayerName(this.mMotionLayer._AnimatorLayerIndex);
			this.TRANS_AnyState_Idle_PushButton = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicInteraction-SM.Idle_PushButton");
			this.TRANS_EntryState_Idle_PushButton = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicInteraction-SM.Idle_PushButton");
			this.TRANS_AnyState_Idle_GrabHighFront = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicInteraction-SM.Idle_GrabHighFront");
			this.TRANS_EntryState_Idle_GrabHighFront = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicInteraction-SM.Idle_GrabHighFront");
			this.TRANS_AnyState_Idle_PickUp = this.mMotionController.AddAnimatorName("AnyState -> " + layerName + ".BasicInteraction-SM.Idle_PickUp");
			this.TRANS_EntryState_Idle_PickUp = this.mMotionController.AddAnimatorName("Entry -> " + layerName + ".BasicInteraction-SM.Idle_PickUp");
			this.STATE_Start = this.mMotionController.AddAnimatorName(layerName + ".Start");
			this.STATE_Idle_GrabHighFront = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_GrabHighFront");
			this.TRANS_Idle_GrabHighFront_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_GrabHighFront -> " + layerName + ".BasicInteraction-SM.IdlePose");
			this.STATE_Idle_PickUp = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_PickUp");
			this.TRANS_Idle_PickUp_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_PickUp -> " + layerName + ".BasicInteraction-SM.IdlePose");
			this.STATE_Idle_PushButton = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_PushButton");
			this.TRANS_Idle_PushButton_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.Idle_PushButton -> " + layerName + ".BasicInteraction-SM.IdlePose");
			this.STATE_IdlePose = this.mMotionController.AddAnimatorName(layerName + ".BasicInteraction-SM.IdlePose");
		}

		// Token: 0x0400072F RID: 1839
		public int PHASE_UNKNOWN;

		// Token: 0x04000730 RID: 1840
		public int PHASE_START = 3450;

		// Token: 0x04000731 RID: 1841
		public int PHASE_CONTINUE = 3455;

		// Token: 0x04000732 RID: 1842
		public bool _IsInteractableRaycastEnabled = true;

		// Token: 0x04000733 RID: 1843
		public string _InteractableRaycastRoot = "Head";

		// Token: 0x04000734 RID: 1844
		public int _InteractableLayers = -1;

		// Token: 0x04000735 RID: 1845
		public float _InteractableDistance = 2f;

		// Token: 0x04000736 RID: 1846
		public bool _IsInteractableCoreRequired = true;

		// Token: 0x04000737 RID: 1847
		public string _WalkRunMotion = "Controlled Walk";

		// Token: 0x04000738 RID: 1848
		public float _WalkSpeed = 1f;

		// Token: 0x04000739 RID: 1849
		public float _RotationSpeed = 180f;

		// Token: 0x0400073A RID: 1850
		[NonSerialized]
		public MotionDelegate OnTriggeredEvent;

		// Token: 0x0400073B RID: 1851
		protected GameObject mInteractable;

		// Token: 0x0400073C RID: 1852
		protected IInteractableCore mInteractableCore;

		// Token: 0x0400073D RID: 1853
		protected int mActiveForm = -1;

		// Token: 0x0400073E RID: 1854
		protected Transform mRaycastRoot;

		// Token: 0x0400073F RID: 1855
		public int STATE_Start = -1;

		// Token: 0x04000740 RID: 1856
		public int STATE_Idle_GrabHighFront = -1;

		// Token: 0x04000741 RID: 1857
		public int STATE_Idle_PickUp = -1;

		// Token: 0x04000742 RID: 1858
		public int STATE_Idle_PushButton = -1;

		// Token: 0x04000743 RID: 1859
		public int STATE_IdlePose = -1;

		// Token: 0x04000744 RID: 1860
		public int TRANS_AnyState_Idle_PushButton = -1;

		// Token: 0x04000745 RID: 1861
		public int TRANS_EntryState_Idle_PushButton = -1;

		// Token: 0x04000746 RID: 1862
		public int TRANS_AnyState_Idle_GrabHighFront = -1;

		// Token: 0x04000747 RID: 1863
		public int TRANS_EntryState_Idle_GrabHighFront = -1;

		// Token: 0x04000748 RID: 1864
		public int TRANS_AnyState_Idle_PickUp = -1;

		// Token: 0x04000749 RID: 1865
		public int TRANS_EntryState_Idle_PickUp = -1;

		// Token: 0x0400074A RID: 1866
		public int TRANS_Idle_GrabHighFront_IdlePose = -1;

		// Token: 0x0400074B RID: 1867
		public int TRANS_Idle_PickUp_IdlePose = -1;

		// Token: 0x0400074C RID: 1868
		public int TRANS_Idle_PushButton_IdlePose = -1;
	}
}

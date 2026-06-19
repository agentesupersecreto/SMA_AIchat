using System;
using System.Collections;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace com.ootii.Actors.Navigation
{
	// Token: 0x0200009D RID: 157
	[RequireComponent(typeof(NavMeshAgent))]
	public class OffMeshLinkDriver : MonoBehaviour
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0002ECE7 File Offset: 0x0002CEE7
		// (set) Token: 0x060008B6 RID: 2230 RVA: 0x0002ECEF File Offset: 0x0002CEEF
		public NavMeshAgent NavMeshAgent
		{
			get
			{
				return this.mNavMeshAgent;
			}
			set
			{
				this.mNavMeshAgent = value;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0002ECF8 File Offset: 0x0002CEF8
		// (set) Token: 0x060008B8 RID: 2232 RVA: 0x0002ED00 File Offset: 0x0002CF00
		public OffMeshLinkMoveType MoveType
		{
			get
			{
				return this.mMoveType;
			}
			set
			{
				this.mMoveType = value;
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0002ED09 File Offset: 0x0002CF09
		// (set) Token: 0x060008BA RID: 2234 RVA: 0x0002ED11 File Offset: 0x0002CF11
		public float Speed
		{
			get
			{
				return this.mSpeed;
			}
			set
			{
				this.mSpeed = value;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0002ED1A File Offset: 0x0002CF1A
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x0002ED22 File Offset: 0x0002CF22
		public float Height
		{
			get
			{
				return this.mHeight;
			}
			set
			{
				this.mHeight = value;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x0002ED2B File Offset: 0x0002CF2B
		// (set) Token: 0x060008BE RID: 2238 RVA: 0x0002ED33 File Offset: 0x0002CF33
		public AnimationCurve Curve
		{
			get
			{
				return this.mCurve;
			}
			set
			{
				this.mCurve = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0002ED3C File Offset: 0x0002CF3C
		public bool HasCompleted
		{
			get
			{
				return this.mHasCompleted;
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0002ED44 File Offset: 0x0002CF44
		public IEnumerator Start()
		{
			this.mMotionController = base.gameObject.GetComponent<MotionController>();
			this.mNavMeshAgent = base.gameObject.GetComponent<NavMeshAgent>();
			this.mNavMeshAgent.autoTraverseOffMeshLink = false;
			this.mOffMeshLinkData = this.mNavMeshAgent.currentOffMeshLinkData;
			this.mHasCompleted = false;
			this.mStartPosition = this.mMotionController._Transform.position;
			float num = ((this.mSpeed > 0f) ? this.mSpeed : this.mNavMeshAgent.speed);
			if (this.mNavMeshAgent.isOnOffMeshLink)
			{
				if (this.mMoveType == OffMeshLinkMoveType.AutoDetect)
				{
					if (this.mOffMeshLinkData.offMeshLink != null)
					{
						if (this.mOffMeshLinkData.offMeshLink.area == NavMesh.GetAreaFromName("Climb Onto"))
						{
							this.MoveType = OffMeshLinkMoveType.ClimbOnto;
						}
					}
					else if (this.mOffMeshLinkData.linkType == OffMeshLinkType.LinkTypeDropDown)
					{
						this.MoveType = OffMeshLinkMoveType.Drop;
					}
					if (this.mMoveType == OffMeshLinkMoveType.AutoDetect)
					{
						this.mMoveType = OffMeshLinkMoveType.Parabola;
					}
				}
				if (this.mMoveType == OffMeshLinkMoveType.Teleport)
				{
					this.mNavMeshAgent.Warp(this.mOffMeshLinkData.endPos);
				}
				else if (this.mMoveType == OffMeshLinkMoveType.Linear)
				{
					yield return this.mMotionController.StartCoroutine(this.MoveLinear(num));
				}
				else if (this.mMoveType == OffMeshLinkMoveType.Parabola)
				{
					yield return this.mMotionController.StartCoroutine(this.MoveParabola(this.mHeight, num));
				}
				else if (this.mMoveType == OffMeshLinkMoveType.Curve)
				{
					yield return this.mMotionController.StartCoroutine(this.MoveCurve(num));
				}
				else if (this.mMoveType == OffMeshLinkMoveType.Drop)
				{
					yield return this.mMotionController.StartCoroutine(this.MoveDrop(num));
				}
				else if (this.mMoveType == OffMeshLinkMoveType.ClimbOnto)
				{
					yield return this.mMotionController.StartCoroutine(this.ClimbUp(num));
				}
				this.mNavMeshAgent.CompleteOffMeshLink();
			}
			this.mHasCompleted = true;
			yield break;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0002ED53 File Offset: 0x0002CF53
		protected IEnumerator MoveLinear(float rSpeed)
		{
			Vector3 lEndPos = this.mOffMeshLinkData.endPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			while (this.mNavMeshAgent.transform.position != lEndPos)
			{
				this.mNavMeshAgent.transform.position = Vector3.MoveTowards(this.mNavMeshAgent.transform.position, lEndPos, rSpeed * Time.deltaTime);
				yield return null;
			}
			yield break;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0002ED69 File Offset: 0x0002CF69
		protected IEnumerator MoveParabola(float rHeight, float rSpeed)
		{
			Vector3 lTargetPosition = this.mOffMeshLinkData.startPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			while (this.mMotionController._Transform.position != lTargetPosition)
			{
				this.mMotionController._Transform.position = Vector3.MoveTowards(this.mMotionController._Transform.position, lTargetPosition, rSpeed * Time.deltaTime);
				yield return null;
			}
			float lDuration = Vector3.Distance(this.mOffMeshLinkData.startPos, this.mOffMeshLinkData.endPos) / rSpeed;
			Vector3 lStartPos = this.mNavMeshAgent.transform.position;
			Vector3 lEndPos = this.mOffMeshLinkData.endPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			float lNormalizedTime = 0f;
			while (lNormalizedTime < 1f)
			{
				float num = rHeight * 4f * (lNormalizedTime - lNormalizedTime * lNormalizedTime);
				this.mNavMeshAgent.transform.position = Vector3.Lerp(lStartPos, lEndPos, lNormalizedTime) + Vector3.up * num;
				lNormalizedTime += Time.deltaTime / lDuration;
				yield return null;
			}
			yield break;
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0002ED86 File Offset: 0x0002CF86
		protected IEnumerator MoveCurve(float rSpeed)
		{
			float lDuration = Vector3.Distance(this.mOffMeshLinkData.startPos, this.mOffMeshLinkData.endPos) / rSpeed;
			Vector3 lStartPos = this.mNavMeshAgent.transform.position;
			Vector3 lEndPos = this.mOffMeshLinkData.endPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			float lNormalizedTime = 0f;
			while (lNormalizedTime < 1f)
			{
				float num = ((this.mCurve != null) ? this.mCurve.Evaluate(lNormalizedTime) : 0f);
				this.mNavMeshAgent.transform.position = Vector3.Lerp(lStartPos, lEndPos, lNormalizedTime) + Vector3.up * num;
				lNormalizedTime += Time.deltaTime / lDuration;
				yield return null;
			}
			yield break;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0002ED9C File Offset: 0x0002CF9C
		protected IEnumerator MoveDrop(float rSpeed)
		{
			Vector3 lTargetPosition = this.mOffMeshLinkData.startPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			while (this.mMotionController._Transform.position != lTargetPosition)
			{
				this.mMotionController._Transform.position = Vector3.MoveTowards(this.mMotionController._Transform.position, lTargetPosition, rSpeed * Time.deltaTime);
				yield return null;
			}
			float lFallStart = 0f;
			float lDuration = Vector3.Distance(this.mOffMeshLinkData.startPos, this.mOffMeshLinkData.endPos) / rSpeed;
			Vector3 lStartPos = this.mNavMeshAgent.transform.position;
			Vector3 lEndPos = this.mOffMeshLinkData.endPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			float lNormalizedTime = 0f;
			while (lNormalizedTime < 1f)
			{
				if (lFallStart == 0f && !this.mMotionController.IsGrounded)
				{
					lFallStart = lNormalizedTime;
				}
				Vector3 vector = Vector3.Lerp(lStartPos, lEndPos, lNormalizedTime);
				float num = 1f - ((lFallStart == 0f) ? 0f : Mathf.Clamp01((lNormalizedTime - lFallStart) / (1f - lFallStart)));
				vector += Vector3.Project(this.mStartPosition - vector, this.mMotionController._Transform.up) * num;
				this.mNavMeshAgent.transform.position = vector;
				lNormalizedTime += Time.deltaTime / lDuration;
				yield return null;
			}
			yield break;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0002EDB2 File Offset: 0x0002CFB2
		protected IEnumerator ClimbUp(float rSpeed)
		{
			bool lStoredUpdatePosition = this.mNavMeshAgent.updatePosition;
			bool lStoredUpdateRotation = this.mNavMeshAgent.updateRotation;
			this.mNavMeshAgent.updatePosition = false;
			this.mNavMeshAgent.updateRotation = false;
			Vector3 lTargetPosition = this.mOffMeshLinkData.startPos + Vector3.up * this.mNavMeshAgent.baseOffset;
			while (this.mMotionController._Transform.position != lTargetPosition)
			{
				this.mMotionController._Transform.position = Vector3.MoveTowards(this.mMotionController._Transform.position, lTargetPosition, rSpeed * Time.deltaTime);
				float horizontalAngle = NumberHelper.GetHorizontalAngle(this.mMotionController._Transform.forward, (this.mOffMeshLinkData.endPos - this.mOffMeshLinkData.startPos).normalized, this.mMotionController._Transform.up);
				this.mMotionController._Transform.rotation = this.mMotionController._Transform.rotation * Quaternion.AngleAxis(horizontalAngle * 0.05f, Vector3.up);
				yield return null;
			}
			NavigationMessage navigationMessage = NavigationMessage.Allocate();
			navigationMessage.ID = NavigationMessage.MSG_NAVIGATE_CLIMB;
			this.mMotionController.SendMessage(navigationMessage);
			if (navigationMessage.IsHandled)
			{
				this.mMotionController.ActorController.UseTransformPosition = false;
				MotionControllerMotion lMotion = navigationMessage.Recipient as MotionControllerMotion;
				while (lMotion != null && (lMotion.QueueActivation || lMotion.IsActive))
				{
					yield return null;
				}
				this.mMotionController.ActorController.UseTransformPosition = true;
				lTargetPosition = this.mOffMeshLinkData.endPos + Vector3.up * this.mNavMeshAgent.baseOffset;
				while (this.mMotionController._Transform.position != lTargetPosition)
				{
					this.mMotionController._Transform.position = Vector3.MoveTowards(this.mMotionController._Transform.position, lTargetPosition, rSpeed * Time.deltaTime);
					yield return null;
				}
				lMotion = null;
			}
			else
			{
				yield return this.mMotionController.StartCoroutine(this.MoveParabola(this.mHeight, rSpeed));
			}
			this.mNavMeshAgent.Warp(this.mMotionController._Transform.position);
			this.mNavMeshAgent.updatePosition = lStoredUpdatePosition;
			this.mNavMeshAgent.updateRotation = lStoredUpdateRotation;
			yield break;
		}

		// Token: 0x0400047F RID: 1151
		protected NavMeshAgent mNavMeshAgent;

		// Token: 0x04000480 RID: 1152
		protected OffMeshLinkMoveType mMoveType;

		// Token: 0x04000481 RID: 1153
		protected float mSpeed;

		// Token: 0x04000482 RID: 1154
		protected float mHeight = 1f;

		// Token: 0x04000483 RID: 1155
		protected AnimationCurve mCurve;

		// Token: 0x04000484 RID: 1156
		protected bool mHasCompleted;

		// Token: 0x04000485 RID: 1157
		protected OffMeshLinkData mOffMeshLinkData;

		// Token: 0x04000486 RID: 1158
		protected MotionController mMotionController;

		// Token: 0x04000487 RID: 1159
		protected Vector3 mStartPosition = Vector3.zero;
	}
}

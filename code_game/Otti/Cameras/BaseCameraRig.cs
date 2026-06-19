using System;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000081 RID: 129
	public class BaseCameraRig : MonoBehaviour, IBaseCameraRig
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x000240B7 File Offset: 0x000222B7
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x000240BF File Offset: 0x000222BF
		public bool UseFixedUpdate
		{
			get
			{
				return this._UseFixedUpdate;
			}
			set
			{
				this._UseFixedUpdate = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x000240C8 File Offset: 0x000222C8
		public virtual Transform Transform
		{
			get
			{
				return this._Transform;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x000240D0 File Offset: 0x000222D0
		public virtual Camera Camera
		{
			get
			{
				return this._Camera;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x000240D8 File Offset: 0x000222D8
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x000240E0 File Offset: 0x000222E0
		public virtual int Mode
		{
			get
			{
				return this._Mode;
			}
			set
			{
				this._Mode = value;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x000240E9 File Offset: 0x000222E9
		// (set) Token: 0x06000690 RID: 1680 RVA: 0x000240F1 File Offset: 0x000222F1
		public virtual bool LockMode
		{
			get
			{
				return this.mLockMode;
			}
			set
			{
				this.mLockMode = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x000240FA File Offset: 0x000222FA
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x00024102 File Offset: 0x00022302
		public virtual Transform Anchor
		{
			get
			{
				return this._Anchor;
			}
			set
			{
				this._Anchor = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0002410B File Offset: 0x0002230B
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x00024113 File Offset: 0x00022313
		public virtual bool FrameLockForward
		{
			get
			{
				return this.mFrameLockForward;
			}
			set
			{
				this.mFrameLockForward = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0002411C File Offset: 0x0002231C
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x00024124 File Offset: 0x00022324
		public virtual bool FrameForceToFollowAnchor
		{
			get
			{
				return this._FrameForceToFollowAnchor;
			}
			set
			{
				this._FrameForceToFollowAnchor = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0002412D File Offset: 0x0002232D
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x00024135 File Offset: 0x00022335
		public bool IsInternalUpdateEnabled
		{
			get
			{
				return this._IsInternalUpdateEnabled;
			}
			set
			{
				this._IsInternalUpdateEnabled = value;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0002413E File Offset: 0x0002233E
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x00024146 File Offset: 0x00022346
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

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0002414F File Offset: 0x0002234F
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x00024157 File Offset: 0x00022357
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00024160 File Offset: 0x00022360
		public float DeltaTime
		{
			get
			{
				return this._DeltaTime;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x00024168 File Offset: 0x00022368
		// (set) Token: 0x0600069F RID: 1695 RVA: 0x00024170 File Offset: 0x00022370
		public CameraUpdateEvent OnPostLateUpdate
		{
			get
			{
				return this.mOnPostLateUpdate;
			}
			set
			{
				this.mOnPostLateUpdate = value;
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0002417C File Offset: 0x0002237C
		protected virtual void Awake_Camera()
		{
			this._Transform = base.gameObject.transform;
			if (this._Camera == null)
			{
				this._Camera = base.gameObject.GetComponent<Camera>();
				if (this._Camera == null)
				{
					Camera[] componentsInChildren = base.gameObject.GetComponentsInChildren<Camera>();
					if (componentsInChildren != null && componentsInChildren.Length != 0)
					{
						for (int i = 0; i < componentsInChildren.Length; i++)
						{
							if (componentsInChildren[i].enabled)
							{
								this._Camera = componentsInChildren[i];
								return;
							}
						}
					}
				}
			}
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x000241FC File Offset: 0x000223FC
		protected virtual void Start()
		{
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000241FE File Offset: 0x000223FE
		public virtual void EnableMode(int rMode, bool rEnable)
		{
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00024200 File Offset: 0x00022400
		public virtual void ClearTargetYawPitch()
		{
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00024202 File Offset: 0x00022402
		public virtual void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00024204 File Offset: 0x00022404
		public virtual void ClearTargetForward()
		{
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00024206 File Offset: 0x00022406
		public virtual void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00024208 File Offset: 0x00022408
		public virtual void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation)
		{
			if (this._Anchor != null)
			{
				rPosition = this._Anchor.position;
				rRotation = this._Anchor.rotation;
				return;
			}
			rPosition = Vector3.zero;
			rRotation = Quaternion.identity;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0002425C File Offset: 0x0002245C
		protected virtual void Update_CAM()
		{
			if (!this._IsInternalUpdateEnabled)
			{
				return;
			}
			this.mUpdateCount = 0;
			this._DeltaTime = Time.deltaTime;
			if (!this._IsFixedUpdateEnabled || this._FixedUpdateFPS <= 0f)
			{
				this.mUpdateCount = 1;
			}
			else
			{
				this._DeltaTime = 1f / this._FixedUpdateFPS;
				if (Mathf.Abs(this._DeltaTime - Time.deltaTime) < this._DeltaTime * 0.1f)
				{
					this.mUpdateCount = 1;
				}
				else
				{
					this.mFixedElapsedTime += Time.deltaTime;
					while (this.mFixedElapsedTime >= this._DeltaTime)
					{
						this.mUpdateCount++;
						this.mFixedElapsedTime -= this._DeltaTime;
						if (this.mUpdateCount >= 5)
						{
							this.mFixedElapsedTime = 0f;
							break;
						}
					}
				}
			}
			this.mUpdateIndex = 1;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0002433F File Offset: 0x0002253F
		protected virtual void FixedUpdate_CAM()
		{
			if (this._IsInternalUpdateEnabled && this._UseFixedUpdate)
			{
				this.InternalUpdate();
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00024357 File Offset: 0x00022557
		protected virtual void LateUpdate_CAM()
		{
			if (!this._IsInternalUpdateEnabled || !this._UseFixedUpdate)
			{
				this.InternalUpdate();
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0002436F File Offset: 0x0002256F
		public virtual void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00024374 File Offset: 0x00022574
		protected virtual void InternalUpdate()
		{
			if (!this._IsInternalUpdateEnabled)
			{
				return;
			}
			if (this.mUpdateCount > 0)
			{
				this.mUpdateIndex = 1;
				while (this.mUpdateIndex <= this.mUpdateCount)
				{
					this.RigLateUpdate(this._DeltaTime, this.mUpdateIndex);
					this.mIsFirstUpdate = false;
					this.mUpdateIndex++;
				}
			}
			else
			{
				this.mUpdateIndex = 0;
				this.RigLateUpdate(this._DeltaTime, this.mUpdateIndex);
			}
			this.mUpdateIndex = 1;
			if (this.mOnPostLateUpdate != null)
			{
				this.mOnPostLateUpdate(this._DeltaTime, this.mUpdateIndex, this);
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00024414 File Offset: 0x00022614
		public static BaseCameraRig ExtractCameraRig(Transform rCamera)
		{
			if (rCamera == null)
			{
				return null;
			}
			Transform transform = rCamera;
			while (transform != null)
			{
				BaseCameraRig[] components = transform.gameObject.GetComponents<BaseCameraRig>();
				if (components != null && components.Length != 0)
				{
					for (int i = 0; i < components.Length; i++)
					{
						if (components[i].enabled && components[i].gameObject.activeSelf)
						{
							return components[i];
						}
					}
				}
				transform = transform.parent;
			}
			return null;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0002447F File Offset: 0x0002267F
		private void Awake()
		{
			if (base.GetComponent<ITValleCamControllerUpdater>() == null)
			{
				base.gameObject.AddComponent<DefaultCamControllerUpdater>();
			}
			this.Awake_Camera();
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0002449B File Offset: 0x0002269B
		public void FixedUpdateCamera()
		{
			this.FixedUpdate_CAM();
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000244A3 File Offset: 0x000226A3
		public void UpdateCamera()
		{
			this.Update_CAM();
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000244AB File Offset: 0x000226AB
		public void LateUpdateCamera()
		{
			this.LateUpdate_CAM();
		}

		// Token: 0x04000345 RID: 837
		public bool _UseFixedUpdate;

		// Token: 0x04000346 RID: 838
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x04000347 RID: 839
		[HideInInspector]
		[NonSerialized]
		public Camera _Camera;

		// Token: 0x04000348 RID: 840
		public int _Mode;

		// Token: 0x04000349 RID: 841
		protected bool mLockMode;

		// Token: 0x0400034A RID: 842
		public Transform _Anchor;

		// Token: 0x0400034B RID: 843
		protected bool mFrameLockForward;

		// Token: 0x0400034C RID: 844
		public bool _FrameForceToFollowAnchor;

		// Token: 0x0400034D RID: 845
		public bool _IsInternalUpdateEnabled = true;

		// Token: 0x0400034E RID: 846
		public bool _IsFixedUpdateEnabled;

		// Token: 0x0400034F RID: 847
		public float _FixedUpdateFPS = 60f;

		// Token: 0x04000350 RID: 848
		[NonSerialized]
		public float _DeltaTime;

		// Token: 0x04000351 RID: 849
		protected CameraUpdateEvent mOnPostLateUpdate;

		// Token: 0x04000352 RID: 850
		protected bool mIsFirstUpdate = true;

		// Token: 0x04000353 RID: 851
		protected int mUpdateCount;

		// Token: 0x04000354 RID: 852
		protected int mUpdateIndex = 1;

		// Token: 0x04000355 RID: 853
		protected float mFixedElapsedTime;

		// Token: 0x04000356 RID: 854
		protected float mEditorLastTime;

		// Token: 0x04000357 RID: 855
		protected float mEditorDeltaTime;
	}
}

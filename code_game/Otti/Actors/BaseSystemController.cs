using System;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000092 RID: 146
	[Serializable]
	public class BaseSystemController : MonoBehaviour
	{
		// Token: 0x06000831 RID: 2097 RVA: 0x0002BF52 File Offset: 0x0002A152
		private void Awake()
		{
			if (this.m_awaked)
			{
				return;
			}
			this.m_animator = base.GetComponentInChildren<Animator>();
			if (base.GetComponent<ITValleActorControllerUpdater>() == null)
			{
				base.gameObject.AddComponent<DefaultActorControllerUpdater>();
			}
			this.Awake_();
			this.m_awaked = true;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0002BF8A File Offset: 0x0002A18A
		public void DoStart()
		{
			if (!this.m_awaked)
			{
				this.Awake();
			}
			if (this.m_stared)
			{
				return;
			}
			if (this.m_animator != null)
			{
				this.m_animator.enabled = true;
			}
			this.Start();
			this.m_stared = true;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0002BFCA File Offset: 0x0002A1CA
		protected virtual void Start()
		{
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0002BFCC File Offset: 0x0002A1CC
		public void FixedUpdateActor()
		{
			this.FixedUpdate_();
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0002BFD4 File Offset: 0x0002A1D4
		public void UpdateActor()
		{
			this.Update_();
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002BFDC File Offset: 0x0002A1DC
		public void LateUpdateActor()
		{
			this.LateUpdate_();
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0002BFE4 File Offset: 0x0002A1E4
		public Transform Transform
		{
			get
			{
				return this._Transform;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0002BFEC File Offset: 0x0002A1EC
		// (set) Token: 0x06000839 RID: 2105 RVA: 0x0002BFF4 File Offset: 0x0002A1F4
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

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0002BFFD File Offset: 0x0002A1FD
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x0002C005 File Offset: 0x0002A205
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

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0002C00E File Offset: 0x0002A20E
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x0002C016 File Offset: 0x0002A216
		public virtual float FixedUpdateFPS
		{
			get
			{
				return this._FixedUpdateFPS;
			}
			set
			{
				this._FixedUpdateFPS = value;
				this.mFixedUpdateFrameTime = 1f / this._FixedUpdateFPS;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0002C031 File Offset: 0x0002A231
		public float DeltaTime
		{
			get
			{
				return this._DeltaTime;
			}
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0002C039 File Offset: 0x0002A239
		protected virtual void Awake_()
		{
			this.mFixedUpdateFrameTime = 1f / this._FixedUpdateFPS;
			this._Transform = base.gameObject.transform;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0002C05E File Offset: 0x0002A25E
		protected virtual void FixedUpdate_()
		{
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0002C060 File Offset: 0x0002A260
		protected virtual void Update_()
		{
			if (!this._IsInternalUpdateEnabled)
			{
				return;
			}
			float num = Time.realtimeSinceStartup;
			this.mEditorDeltaTime = num - this.mEditorLastTime;
			this.mEditorLastTime = num;
			this.mUpdateCount = 0;
			this._DeltaTime = Time.deltaTime;
			if (this._DeltaTime > 0.2f)
			{
				this._DeltaTime = 1f / this._FixedUpdateFPS;
			}
			if (!this._IsFixedUpdateEnabled || this._FixedUpdateFPS <= 0f)
			{
				this.mUpdateCount = 1;
			}
			else
			{
				this._DeltaTime = this.mFixedUpdateFrameTime * Time.timeScale;
				if (Mathf.Abs(this._DeltaTime - Time.deltaTime) < this.mFixedUpdateFrameTime * 0.0016f)
				{
					this.mUpdateCount = 1;
				}
				else
				{
					this.mFixedElapsedTime += this.mEditorDeltaTime;
					while (this.mFixedElapsedTime >= this.mFixedUpdateFrameTime)
					{
						this.mUpdateCount++;
						this.mFixedElapsedTime -= this.mFixedUpdateFrameTime;
						if (this.mUpdateCount >= 5)
						{
							this.mFixedElapsedTime = 0f;
							break;
						}
					}
				}
			}
			if (this.mUpdateCount > 0)
			{
				bool flag = this.mIsFirstUpdate;
				this.mUpdateIndex = 1;
				while (this.mUpdateIndex <= this.mUpdateCount)
				{
					this.ControllerUpdate(this._DeltaTime, this.mUpdateIndex);
					this.mIsFirstUpdate = false;
					this.mUpdateIndex++;
				}
				this.mIsFirstUpdate = flag;
			}
			else
			{
				this.mUpdateIndex = 0;
				this.ControllerUpdate(this._DeltaTime, this.mUpdateIndex);
			}
			this.mUpdateIndex = 1;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0002C1F0 File Offset: 0x0002A3F0
		protected virtual void LateUpdate_()
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
					this.ControllerLateUpdate(this._DeltaTime, this.mUpdateIndex);
					this.mIsFirstUpdate = false;
					this.mUpdateIndex++;
				}
			}
			else
			{
				this.mUpdateIndex = 0;
				this.ControllerLateUpdate(this._DeltaTime, this.mUpdateIndex);
			}
			this.mUpdateIndex = 1;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0002C26F File Offset: 0x0002A46F
		public virtual void ControllerUpdate(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0002C271 File Offset: 0x0002A471
		public virtual void ControllerLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
		}

		// Token: 0x04000436 RID: 1078
		private Animator m_animator;

		// Token: 0x04000437 RID: 1079
		private bool m_stared;

		// Token: 0x04000438 RID: 1080
		private bool m_awaked;

		// Token: 0x04000439 RID: 1081
		[NonSerialized]
		public Transform _Transform;

		// Token: 0x0400043A RID: 1082
		public bool _IsInternalUpdateEnabled = true;

		// Token: 0x0400043B RID: 1083
		public bool _IsFixedUpdateEnabled;

		// Token: 0x0400043C RID: 1084
		public float _FixedUpdateFPS = 60f;

		// Token: 0x0400043D RID: 1085
		[NonSerialized]
		public float _DeltaTime;

		// Token: 0x0400043E RID: 1086
		protected float mFixedUpdateFrameTime = 0.016666668f;

		// Token: 0x0400043F RID: 1087
		protected bool mIsFirstUpdate = true;

		// Token: 0x04000440 RID: 1088
		protected int mUpdateCount;

		// Token: 0x04000441 RID: 1089
		protected int mUpdateIndex = 1;

		// Token: 0x04000442 RID: 1090
		protected float mFixedElapsedTime;

		// Token: 0x04000443 RID: 1091
		protected float mEditorLastTime;

		// Token: 0x04000444 RID: 1092
		protected float mEditorDeltaTime;
	}
}

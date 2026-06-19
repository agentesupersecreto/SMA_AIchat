using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000047 RID: 71
	public class RingColliderProxy : ColliderProxy
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000370 RID: 880 RVA: 0x000116FB File Offset: 0x0000F8FB
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00011703 File Offset: 0x0000F903
		public int Segments
		{
			get
			{
				return this._Segments;
			}
			set
			{
				this._Segments = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0001170C File Offset: 0x0000F90C
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00011714 File Offset: 0x0000F914
		public float Thickness
		{
			get
			{
				return this._Thickness;
			}
			set
			{
				this._Thickness = value;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0001171D File Offset: 0x0000F91D
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00011725 File Offset: 0x0000F925
		public Vector3 Normal
		{
			get
			{
				return this._Normal;
			}
			set
			{
				this._Normal = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0001172E File Offset: 0x0000F92E
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00011736 File Offset: 0x0000F936
		public Vector3 Forward
		{
			get
			{
				return this._Forward;
			}
			set
			{
				this._Forward = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0001173F File Offset: 0x0000F93F
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00011747 File Offset: 0x0000F947
		public float Speed
		{
			get
			{
				return this._Speed;
			}
			set
			{
				this._Speed = value;
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00011750 File Offset: 0x0000F950
		protected override void Awake()
		{
			base.Awake();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00011758 File Offset: 0x0000F958
		protected void Start()
		{
			this.mSegmentAngle = 360f / (float)this._Segments;
			Vector3 lossyScale = base.gameObject.transform.lossyScale;
			float num = 1.1f * (this.mSegmentAngle * 0.017453292f);
			float num2 = this._Thickness / lossyScale.x;
			Vector3 vector = this._Forward;
			Quaternion quaternion = Quaternion.AngleAxis(this.mSegmentAngle, this._Normal);
			GameObject gameObject = new GameObject("collider", new Type[]
			{
				typeof(BoxCollider),
				typeof(ColliderProxy)
			});
			BoxCollider component = gameObject.GetComponent<BoxCollider>();
			component.enabled = this._Speed == 0f;
			component.isTrigger = true;
			gameObject.GetComponent<ColliderProxy>().Target = this._Target;
			GameObject gameObject2 = gameObject;
			for (int i = 0; i < this._Segments; i++)
			{
				vector = quaternion * vector;
				if (gameObject2 == null)
				{
					gameObject2 = Object.Instantiate<GameObject>(gameObject);
				}
				gameObject2.transform.parent = base.transform;
				gameObject2.transform.localScale = new Vector3(num, 1f, num2);
				gameObject2.transform.localPosition = vector;
				gameObject2.transform.forward = (gameObject2.transform.position - base.gameObject.transform.position).normalized;
				this.mColliders.Add(gameObject2.GetComponent<BoxCollider>());
				gameObject2 = null;
			}
			this.mEnable = true;
			this.mIsUpdating = this._Speed != 0f;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000118FC File Offset: 0x0000FAFC
		public override void Reset()
		{
			this.EnableColliders(false, 0f);
			this.EnableColliders(true, this._Speed);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00011918 File Offset: 0x0000FB18
		public override void EnableColliders(bool rEnable, float rSpeed = 0f)
		{
			if (rSpeed == 0f)
			{
				for (int i = 0; i < this.mColliders.Count; i++)
				{
					this.mColliders[i].enabled = rEnable;
				}
				this.mIsUpdating = false;
				return;
			}
			this._Speed = rSpeed;
			this.mEnable = rEnable;
			this.mIsUpdating = true;
			this.mElapsedAngle = 0f;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00011980 File Offset: 0x0000FB80
		protected void Update()
		{
			if (!this.mIsUpdating)
			{
				return;
			}
			float num = Mathf.Sign(this._Speed);
			float num2 = Mathf.Abs(this._Speed);
			this.mElapsedAngle += num2 * Time.deltaTime;
			if (num > 0f)
			{
				float num3 = Mathf.Floor(this.mElapsedAngle / this.mSegmentAngle);
				int num4 = 0;
				while ((float)num4 <= num3 && num4 < this.mColliders.Count)
				{
					if (this.mColliders[num4].enabled != this.mEnable)
					{
						this.mColliders[num4].enabled = this.mEnable;
					}
					num4++;
				}
				if (num3 >= (float)this.mColliders.Count)
				{
					this.mIsUpdating = false;
					return;
				}
			}
			else if (num < 0f)
			{
				float num5 = Mathf.Floor((360f - this.mElapsedAngle) / this.mSegmentAngle);
				for (int i = (int)num5; i < this.mColliders.Count; i++)
				{
					if (this.mColliders[i].enabled != this.mEnable)
					{
						this.mColliders[i].enabled = this.mEnable;
					}
				}
				if (num5 <= 0f)
				{
					this.mIsUpdating = false;
					return;
				}
			}
			else
			{
				this.mIsUpdating = false;
			}
		}

		// Token: 0x040001E8 RID: 488
		public int _Segments = 16;

		// Token: 0x040001E9 RID: 489
		public float _Thickness = 0.5f;

		// Token: 0x040001EA RID: 490
		public Vector3 _Normal = Vector3.up;

		// Token: 0x040001EB RID: 491
		public Vector3 _Forward = Vector3.forward;

		// Token: 0x040001EC RID: 492
		public float _Speed;

		// Token: 0x040001ED RID: 493
		protected float mSegmentAngle;

		// Token: 0x040001EE RID: 494
		protected bool mEnable = true;

		// Token: 0x040001EF RID: 495
		protected bool mIsUpdating = true;

		// Token: 0x040001F0 RID: 496
		protected float mElapsedAngle;

		// Token: 0x040001F1 RID: 497
		protected List<Collider> mColliders = new List<Collider>();
	}
}

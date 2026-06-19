using System;
using System.Collections.Generic;
using com.ootii.Actors.Attributes;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Graphics.UI
{
	// Token: 0x02000043 RID: 67
	public class Reticle : MonoBehaviour, IReticle
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00010130 File Offset: 0x0000E330
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00010138 File Offset: 0x0000E338
		public bool IsVisible
		{
			get
			{
				return this._IsVisible;
			}
			set
			{
				this._IsVisible = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00010141 File Offset: 0x0000E341
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00010149 File Offset: 0x0000E349
		public Vector2 Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				this._Size = value;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00010152 File Offset: 0x0000E352
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0001015A File Offset: 0x0000E35A
		public Vector2 Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00010163 File Offset: 0x0000E363
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0001016B File Offset: 0x0000E36B
		public float FillPercent
		{
			get
			{
				return this.mFillPercent;
			}
			set
			{
				if (value != this.mFillPercent)
				{
					this.CreateTexture(value);
					this.mFillPercent = value;
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00010184 File Offset: 0x0000E384
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0001018C File Offset: 0x0000E38C
		public Texture2D BGTexture
		{
			get
			{
				return this._BGTexture;
			}
			set
			{
				this._BGTexture = value;
				if (Application.isPlaying)
				{
					this.CreateTexture(this.mFillPercent);
				}
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000337 RID: 823 RVA: 0x000101A8 File Offset: 0x0000E3A8
		// (set) Token: 0x06000338 RID: 824 RVA: 0x000101B0 File Offset: 0x0000E3B0
		public Texture2D FillTexture
		{
			get
			{
				return this._FillTexture;
			}
			set
			{
				this._FillTexture = value;
				if (Application.isPlaying)
				{
					this.CreateTexture(this.mFillPercent);
				}
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000339 RID: 825 RVA: 0x000101CC File Offset: 0x0000E3CC
		// (set) Token: 0x0600033A RID: 826 RVA: 0x000101D4 File Offset: 0x0000E3D4
		public virtual Transform RaycastRoot
		{
			get
			{
				return this._RaycastRoot;
			}
			set
			{
				this._RaycastRoot = value;
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000101E0 File Offset: 0x0000E3E0
		private void Start()
		{
			if (Reticle.Instance == null)
			{
				Reticle.DefaultIsVisible = this.IsVisible;
				Reticle.Instance = this;
			}
			if (this.RaycastRoot == null && Camera.main != null)
			{
				this.RaycastRoot = Camera.main.transform;
			}
			if (this._FillTexture != null)
			{
				this.FillTexture = this._FillTexture;
			}
			if (this._BGTexture != null)
			{
				this.BGTexture = this._BGTexture;
			}
			this.FillPercent = 1f;
			this.FillPercent = 0f;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001027C File Offset: 0x0000E47C
		public virtual bool FindTarget(out RaycastHit rHitInfo, float rMinDistance, float rMaxDistance, float rRadius, int rLayerMask = -1, string rTags = "", Transform rIgnore = null, List<Transform> rIgnoreList = null)
		{
			bool flag = false;
			rHitInfo = RaycastExt.EmptyHitInfo;
			RaycastHit[] array;
			int num = this.RaycastAll(out array, rMinDistance, rMaxDistance, rRadius, rLayerMask, rIgnore, rIgnoreList);
			if (num > 0)
			{
				if (rTags == null || rTags.Length == 0)
				{
					flag = true;
					rHitInfo = array[0];
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						IAttributeSource component = array[i].collider.gameObject.GetComponent<IAttributeSource>();
						if (component != null && component.AttributesExist(rTags, false))
						{
							flag = true;
							rHitInfo = array[i];
							break;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00010314 File Offset: 0x0000E514
		public virtual int RaycastAll(out RaycastHit[] rHitInfos, float rMinDistance, float rMaxDistance, float rRadius, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null)
		{
			if (this.RaycastRoot == null && Camera.main != null)
			{
				this.RaycastRoot = Camera.main.transform;
			}
			Transform transform = ((this.RaycastRoot != null) ? this.RaycastRoot : null);
			if (transform == null)
			{
				transform = base.transform;
			}
			Vector3 vector = transform.position + transform.forward * rMinDistance;
			Vector3 forward = transform.forward;
			int num;
			if (rRadius <= 0f)
			{
				num = RaycastExt.SafeRaycastAll(vector, forward, out rHitInfos, rMaxDistance - rMinDistance, rLayerMask, rIgnore, rIgnoreList, true);
			}
			else
			{
				num = RaycastExt.SafeSphereCastAll(vector, forward, rRadius, out rHitInfos, rMaxDistance - rMinDistance, rLayerMask, rIgnore, rIgnoreList, true);
			}
			if (num > 1)
			{
				Array.Sort(rHitInfos, 0, num, RaycastExt.HitDistanceComparer);
			}
			return num;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000103DC File Offset: 0x0000E5DC
		public virtual bool Raycast(out RaycastHit rHitInfo, float rMinDistance, float rMaxDistance, float rRadius, int rLayerMask = -1, Transform rIgnore = null)
		{
			if (this.RaycastRoot == null && Camera.main != null)
			{
				this.RaycastRoot = Camera.main.transform;
			}
			Transform transform = ((this.RaycastRoot != null) ? this.RaycastRoot : null);
			if (transform == null)
			{
				transform = base.transform;
			}
			Vector3 vector = transform.position + transform.forward * rMinDistance;
			Vector3 forward = transform.forward;
			rHitInfo = RaycastExt.EmptyHitInfo;
			return (rRadius > 0f && RaycastExt.SafeSphereCast(vector, forward, rRadius, out rHitInfo, rMaxDistance - rMinDistance, rLayerMask, rIgnore, null, true)) || RaycastExt.SafeRaycast(vector, forward, out rHitInfo, rMaxDistance, rLayerMask, rIgnore, null, true, false);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0001049C File Offset: 0x0000E69C
		protected virtual void OnGUI()
		{
			if (!this._IsVisible)
			{
				return;
			}
			Texture texture = this.mRenderTexture;
			if (texture == null)
			{
				return;
			}
			this.mScreenRect.x = ((float)Screen.width - this._Size.x) / 2f + this._Offset.x;
			this.mScreenRect.y = ((float)Screen.height - this._Size.y) / 2f + this._Offset.y;
			this.mScreenRect.width = this._Size.x;
			this.mScreenRect.height = this._Size.y;
			GUI.DrawTexture(this.mScreenRect, texture);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001055C File Offset: 0x0000E75C
		protected virtual void CreateTexture(float rPercent)
		{
			if (this._BGTexture == null)
			{
				return;
			}
			if (this.mClearMaterial == null)
			{
				this.mClearMaterial = new Material(Shader.Find("Hidden/ClearBlit"));
			}
			if (this.mBlitMaterial == null)
			{
				this.mBlitMaterial = new Material(Shader.Find("Hidden/RadialBlit"));
			}
			if (this.mRenderTexture == null)
			{
				this.mRenderTexture = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				this.mRenderTexture.wrapMode = TextureWrapMode.Clamp;
				this.mRenderTexture.filterMode = FilterMode.Trilinear;
				this.mRenderTexture.anisoLevel = 2;
				this.mRenderTexture.antiAliasing = 4;
			}
			Graphics.Blit(this._BGTexture, this.mRenderTexture, this.mClearMaterial, 0);
			this.mBlitMaterial.SetFloat("_Angle", Mathf.Lerp(-3.1416f, 3.1416f, rPercent));
			this.mBlitMaterial.SetTexture("_FillTex", this._FillTexture);
			Graphics.Blit(this._BGTexture, this.mRenderTexture, this.mBlitMaterial, 0);
		}

		// Token: 0x040001CD RID: 461
		public static bool DefaultIsVisible;

		// Token: 0x040001CE RID: 462
		public static IReticle Instance;

		// Token: 0x040001CF RID: 463
		public bool _IsVisible = true;

		// Token: 0x040001D0 RID: 464
		public Vector2 _Size = new Vector2(32f, 32f);

		// Token: 0x040001D1 RID: 465
		public Vector2 _Offset = new Vector2(0f, 0f);

		// Token: 0x040001D2 RID: 466
		protected float mFillPercent;

		// Token: 0x040001D3 RID: 467
		public Texture2D _BGTexture;

		// Token: 0x040001D4 RID: 468
		public Texture2D _FillTexture;

		// Token: 0x040001D5 RID: 469
		public Transform _RaycastRoot;

		// Token: 0x040001D6 RID: 470
		protected Rect mScreenRect;

		// Token: 0x040001D7 RID: 471
		protected Material mClearMaterial;

		// Token: 0x040001D8 RID: 472
		protected Material mBlitMaterial;

		// Token: 0x040001D9 RID: 473
		protected RenderTexture mRenderTexture;
	}
}

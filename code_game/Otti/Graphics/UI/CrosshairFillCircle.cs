using System;
using UnityEngine;

namespace com.ootii.Graphics.UI
{
	// Token: 0x02000041 RID: 65
	public class CrosshairFillCircle : MonoBehaviour
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000FE9C File Offset: 0x0000E09C
		// (set) Token: 0x0600030F RID: 783 RVA: 0x0000FEA3 File Offset: 0x0000E0A3
		public static CrosshairFillCircle Instance
		{
			get
			{
				return CrosshairFillCircle.mInstance;
			}
			set
			{
				CrosshairFillCircle.mInstance = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000FEAB File Offset: 0x0000E0AB
		// (set) Token: 0x06000311 RID: 785 RVA: 0x0000FEB3 File Offset: 0x0000E0B3
		public virtual bool IsEnabled
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

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000FEBC File Offset: 0x0000E0BC
		// (set) Token: 0x06000313 RID: 787 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		public virtual float FillPercent
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

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000FEDD File Offset: 0x0000E0DD
		// (set) Token: 0x06000315 RID: 789 RVA: 0x0000FEE5 File Offset: 0x0000E0E5
		public virtual Texture2D BGTexture
		{
			get
			{
				return this._BGTexture;
			}
			set
			{
				this._BGTexture = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000FEEE File Offset: 0x0000E0EE
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000FEF6 File Offset: 0x0000E0F6
		public virtual Texture2D FillTexture
		{
			get
			{
				return this._FillTexture;
			}
			set
			{
				this._FillTexture = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000FEFF File Offset: 0x0000E0FF
		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000FF07 File Offset: 0x0000E107
		public virtual float Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000FF10 File Offset: 0x0000E110
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000FF18 File Offset: 0x0000E118
		public virtual float Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000FF24 File Offset: 0x0000E124
		private void Start()
		{
			if (CrosshairFillCircle.Instance == null)
			{
				CrosshairFillCircle.mInstance = this;
			}
			if (this._FillTexture != null)
			{
				this.FillTexture = this._FillTexture;
			}
			if (this._BGTexture != null)
			{
				this.BGTexture = this._BGTexture;
			}
			this.CreateTexture(0f);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000FF84 File Offset: 0x0000E184
		private void OnGUI()
		{
			if (!this._IsEnabled)
			{
				return;
			}
			if (this.mRenderTexture == null)
			{
				return;
			}
			this.mScreenRect.x = ((float)Screen.width - this._Width) / 2f;
			this.mScreenRect.y = ((float)Screen.height - this._Height) / 2f;
			this.mScreenRect.width = this._Width;
			this.mScreenRect.height = this._Height;
			GUI.DrawTexture(this.mScreenRect, this.mRenderTexture);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00010018 File Offset: 0x0000E218
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
			}
			Graphics.Blit(this._BGTexture, this.mRenderTexture, this.mClearMaterial, 0);
			this.mBlitMaterial.SetFloat("_Angle", Mathf.Lerp(-3.1416f, 3.1416f, rPercent));
			this.mBlitMaterial.SetTexture("_FillTex", this._FillTexture);
			Graphics.Blit(this._BGTexture, this.mRenderTexture, this.mBlitMaterial, 0);
		}

		// Token: 0x040001C2 RID: 450
		private static CrosshairFillCircle mInstance;

		// Token: 0x040001C3 RID: 451
		public bool _IsEnabled;

		// Token: 0x040001C4 RID: 452
		protected float mFillPercent;

		// Token: 0x040001C5 RID: 453
		public Texture2D _BGTexture;

		// Token: 0x040001C6 RID: 454
		public Texture2D _FillTexture;

		// Token: 0x040001C7 RID: 455
		public float _Width = 32f;

		// Token: 0x040001C8 RID: 456
		public float _Height = 32f;

		// Token: 0x040001C9 RID: 457
		private Rect mScreenRect;

		// Token: 0x040001CA RID: 458
		private Material mClearMaterial;

		// Token: 0x040001CB RID: 459
		private Material mBlitMaterial;

		// Token: 0x040001CC RID: 460
		private RenderTexture mRenderTexture;
	}
}

using System;
using UnityEngine;

namespace com.ootii.Graphics.UI
{
	// Token: 0x02000040 RID: 64
	public class Crosshair : MonoBehaviour
	{
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000FCED File Offset: 0x0000DEED
		public static Crosshair Instance
		{
			get
			{
				return Crosshair.mInstance;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000FCF4 File Offset: 0x0000DEF4
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0000FCFC File Offset: 0x0000DEFC
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

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000FD05 File Offset: 0x0000DF05
		// (set) Token: 0x06000304 RID: 772 RVA: 0x0000FD0D File Offset: 0x0000DF0D
		public bool IsCursorEnabled
		{
			get
			{
				return this._IsCursorEnabled;
			}
			set
			{
				this._IsCursorEnabled = value;
				Cursor.lockState = (this._IsCursorEnabled ? CursorLockMode.None : CursorLockMode.Locked);
				Cursor.visible = this._IsCursorEnabled;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000FD32 File Offset: 0x0000DF32
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0000FD3C File Offset: 0x0000DF3C
		public Texture2D Texture
		{
			get
			{
				return this._Texture;
			}
			set
			{
				this._Texture = value;
				if (this._Texture != null)
				{
					if (this._Width == 0f)
					{
						this._Width = (float)this._Texture.width;
					}
					if (this._Height == 0f)
					{
						this._Height = (float)this._Texture.height;
					}
					this.mPosition = new Rect(((float)Screen.width - this._Width) / 2f, ((float)Screen.height - this._Height) / 2f, this._Width, this._Height);
				}
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0000FDD9 File Offset: 0x0000DFD9
		// (set) Token: 0x06000308 RID: 776 RVA: 0x0000FDE1 File Offset: 0x0000DFE1
		public float Width
		{
			get
			{
				return this._Width;
			}
			set
			{
				this._Width = value;
				this.Texture = this._Texture;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0000FDF6 File Offset: 0x0000DFF6
		// (set) Token: 0x0600030A RID: 778 RVA: 0x0000FDFE File Offset: 0x0000DFFE
		public float Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				this._Height = value;
				this.Texture = this._Texture;
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000FE13 File Offset: 0x0000E013
		private void Start()
		{
			if (Crosshair.Instance == null)
			{
				Crosshair.mInstance = this;
			}
			if (this._Texture != null)
			{
				this.Texture = this._Texture;
			}
			this.IsCursorEnabled = this._IsCursorEnabled;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000FE4E File Offset: 0x0000E04E
		private void OnGUI()
		{
			if (this._IsEnabled && this._Texture != null)
			{
				GUI.DrawTexture(this.mPosition, this._Texture);
			}
		}

		// Token: 0x040001BB RID: 443
		private static Crosshair mInstance;

		// Token: 0x040001BC RID: 444
		public bool _IsEnabled;

		// Token: 0x040001BD RID: 445
		public bool _IsCursorEnabled = true;

		// Token: 0x040001BE RID: 446
		public Texture2D _Texture;

		// Token: 0x040001BF RID: 447
		public float _Width = 32f;

		// Token: 0x040001C0 RID: 448
		public float _Height = 32f;

		// Token: 0x040001C1 RID: 449
		private Rect mPosition;
	}
}

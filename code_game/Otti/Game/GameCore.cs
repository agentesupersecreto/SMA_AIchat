using System;
using com.ootii.Helpers;
using com.ootii.Input;
using UnityEngine;

namespace com.ootii.Game
{
	// Token: 0x0200005D RID: 93
	public class GameCore : MonoBehaviour
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x00019FC8 File Offset: 0x000181C8
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x00019FD0 File Offset: 0x000181D0
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

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00019FD9 File Offset: 0x000181D9
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00019FE1 File Offset: 0x000181E1
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00019FEA File Offset: 0x000181EA
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x00019FF2 File Offset: 0x000181F2
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00019FFB File Offset: 0x000181FB
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x0001A003 File Offset: 0x00018203
		public bool IsCursorVisible
		{
			get
			{
				return this._IsCursorVisible;
			}
			set
			{
				this._IsCursorVisible = value;
				Cursor.lockState = (this._IsCursorVisible ? CursorLockMode.None : CursorLockMode.Locked);
				Cursor.visible = this._IsCursorVisible;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x0001A028 File Offset: 0x00018228
		// (set) Token: 0x0600047A RID: 1146 RVA: 0x0001A030 File Offset: 0x00018230
		public string ShowCursorAlias
		{
			get
			{
				return this._ShowCursorAlias;
			}
			set
			{
				this._ShowCursorAlias = value;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0001A039 File Offset: 0x00018239
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x0001A041 File Offset: 0x00018241
		public string EditorPauseAlias
		{
			get
			{
				return this._EditorPauseAlias;
			}
			set
			{
				this._EditorPauseAlias = value;
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001A04C File Offset: 0x0001824C
		protected void Awake()
		{
			if (GameCore.Core != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Object.DontDestroyOnLoad(base.gameObject);
			if (GameCore.Core == null)
			{
				GameCore.Core = this;
			}
			if (this._InputSourceOwner != null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			if (this._InputSource == null)
			{
				this._InputSource = InterfaceHelper.GetComponent<IInputSource>(base.gameObject);
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
			this.IsCursorVisible = this._IsCursorVisible;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001A128 File Offset: 0x00018328
		protected void Update()
		{
			if (this._InputSource != null && this._ShowCursorAlias.Length > 0 && this._InputSource.IsJustPressed(this._ShowCursorAlias))
			{
				this.IsCursorVisible = !this.IsCursorVisible;
			}
		}

		// Token: 0x04000240 RID: 576
		public static GameCore Core;

		// Token: 0x04000241 RID: 577
		public GameObject _InputSourceOwner;

		// Token: 0x04000242 RID: 578
		[NonSerialized]
		public IInputSource _InputSource;

		// Token: 0x04000243 RID: 579
		public bool _AutoFindInputSource = true;

		// Token: 0x04000244 RID: 580
		public bool _IsCursorVisible;

		// Token: 0x04000245 RID: 581
		public string _ShowCursorAlias = "Cursor";

		// Token: 0x04000246 RID: 582
		public string _EditorPauseAlias = "";
	}
}

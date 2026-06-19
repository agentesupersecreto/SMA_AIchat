using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B1 RID: 689
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/GUI Button")]
	public class GUIButton : GUIVisibleControl
	{
		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x06001CD4 RID: 7380 RVA: 0x000361B0 File Offset: 0x000343B0
		protected override GUIStyle DefaultGUIStyle
		{
			get
			{
				return GUI.skin.button;
			}
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x000361BC File Offset: 0x000343BC
		public override void DrawSelf(Vector2 relativeMousePosition)
		{
			if (this.clickable)
			{
				this.DrawClickable(relativeMousePosition);
			}
			else
			{
				this.DrawUnclickable();
			}
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x000361DC File Offset: 0x000343DC
		private void DrawClickable(Vector2 relativeMousePosition)
		{
			if (base.rect.Contains(relativeMousePosition))
			{
				if (Input.GetMouseButton(0))
				{
					if (this.pressed != null)
					{
						this.pressed.Draw(base.rect);
					}
				}
				else
				{
					if (!this.isHovered)
					{
						this.isHovered = true;
						base.PlaySound(this.hoverSound);
					}
					if (this.hover != null)
					{
						this.hover.Draw(base.rect);
					}
				}
			}
			else
			{
				if (this.isHovered)
				{
					this.isHovered = false;
				}
				if (this.normal != null)
				{
					this.normal.Draw(base.rect);
				}
			}
			if (GUI.Button(base.rect, this.text, base.GuiStyle))
			{
				this.Click();
			}
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x000362B8 File Offset: 0x000344B8
		private void DrawUnclickable()
		{
			if (this.disabled.texture != null)
			{
				if (this.disabled != null)
				{
					this.disabled.Draw(base.rect);
				}
			}
			else if (!string.IsNullOrEmpty(this.text))
			{
				GUI.enabled = false;
				GUI.Button(base.rect, this.text, base.GuiStyle);
				GUI.enabled = true;
			}
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x00036330 File Offset: 0x00034530
		public override void Update()
		{
			base.Update();
			if (this.clickable && this.trigger.IsDown)
			{
				this.Click();
			}
		}

		// Token: 0x06001CD9 RID: 7385 RVA: 0x0003635C File Offset: 0x0003455C
		public void Click()
		{
			base.PlaySound(this.clickSound);
			Transform transform = Tools.Select(new Transform[] { this.target, base.transform });
			object obj;
			if (this.data != null)
			{
				obj = this.data;
			}
			else if (!string.IsNullOrEmpty(this.parameter))
			{
				obj = this.parameter;
			}
			else
			{
				obj = this;
			}
			transform.SendMessage(this.message, obj, SendMessageOptions.DontRequireReceiver);
		}

		// Token: 0x04001061 RID: 4193
		public bool clickable = true;

		// Token: 0x04001062 RID: 4194
		public GUIImageParams disabled;

		// Token: 0x04001063 RID: 4195
		public GUIImageParams normal;

		// Token: 0x04001064 RID: 4196
		public GUIImageParams hover;

		// Token: 0x04001065 RID: 4197
		public GUIImageParams pressed;

		// Token: 0x04001066 RID: 4198
		public AudioClip hoverSound;

		// Token: 0x04001067 RID: 4199
		public AudioClip clickSound;

		// Token: 0x04001068 RID: 4200
		public InputTrigger trigger;

		// Token: 0x04001069 RID: 4201
		public string message = "OnClick";

		// Token: 0x0400106A RID: 4202
		public string parameter;

		// Token: 0x0400106B RID: 4203
		public Transform target;

		// Token: 0x0400106C RID: 4204
		public object data;

		// Token: 0x0400106D RID: 4205
		private bool isHovered;
	}
}

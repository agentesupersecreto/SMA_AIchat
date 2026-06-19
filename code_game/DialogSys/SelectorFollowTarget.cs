using System;
using PixelCrushers.DialogueSystem.UnityGUI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200004E RID: 78
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/selector_follow_target.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/Selector Follow Target")]
	public class SelectorFollowTarget : MonoBehaviour
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0000C20D File Offset: 0x0000A40D
		private void Awake()
		{
			this.selector = base.GetComponent<Selector>();
			this.proximitySelector = base.GetComponent<ProximitySelector>();
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000C228 File Offset: 0x0000A428
		private void OnEnable()
		{
			if (this.selector != null)
			{
				this.previousUseDefaultGUI = this.selector.useDefaultGUI;
				this.selector.useDefaultGUI = false;
			}
			if (this.proximitySelector != null)
			{
				this.previousUseDefaultGUI = this.proximitySelector.useDefaultGUI;
				this.proximitySelector.useDefaultGUI = false;
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C28B File Offset: 0x0000A48B
		private void OnDisable()
		{
			if (this.selector != null)
			{
				this.selector.useDefaultGUI = this.previousUseDefaultGUI;
			}
			if (this.proximitySelector != null)
			{
				this.proximitySelector.useDefaultGUI = this.previousUseDefaultGUI;
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000C2CC File Offset: 0x0000A4CC
		public virtual void OnGUI()
		{
			if (this.selector != null)
			{
				this.DrawOnSelection(this.selector.CurrentUsable, this.selector.CurrentDistance, this.selector.reticle, this.selector.GuiStyle, this.selector.defaultUseMessage, this.selector.inRangeColor, this.selector.outOfRangeColor, this.selector.textStyle, this.selector.textStyleColor);
				return;
			}
			if (this.proximitySelector != null)
			{
				this.DrawOnSelection(this.proximitySelector.CurrentUsable, 0f, null, this.proximitySelector.GuiStyle, this.proximitySelector.defaultUseMessage, this.proximitySelector.color, this.proximitySelector.color, this.proximitySelector.textStyle, this.proximitySelector.textStyleColor);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
		protected void DrawOnSelection(Usable usable, float distance, Selector.Reticle reticle, GUIStyle guiStyle, string defaultUseMessage, Color inRangeColor, Color outOfRangeColor, TextStyle textStyle, Color textStyleColor)
		{
			if (usable == null)
			{
				return;
			}
			if (usable != this.lastUsable || string.IsNullOrEmpty(this.heading))
			{
				this.lastUsable = usable;
				this.heading = usable.GetName();
				this.useMessage = (string.IsNullOrEmpty(usable.overrideUseMessage) ? defaultUseMessage : usable.overrideUseMessage);
			}
			GameObject gameObject = usable.gameObject;
			if (gameObject != this.lastSelectionDrawn)
			{
				this.selectionHeight = Tools.GetGameObjectHeight(gameObject);
				this.selectionHeadingSize = guiStyle.CalcSize(new GUIContent(this.heading));
				this.selectionUseMessageSize = guiStyle.CalcSize(new GUIContent(this.useMessage));
			}
			bool flag = distance <= usable.maxUseDistance;
			guiStyle.normal.textColor = (flag ? inRangeColor : outOfRangeColor);
			Vector3 vector = Camera.main.WorldToScreenPoint(gameObject.transform.position + Vector3.up * this.selectionHeight);
			vector += this.offset;
			vector = new Vector3(vector.x, vector.y + this.selectionUseMessageSize.y + this.selectionHeadingSize.y, vector.z);
			if (vector.z < 0f)
			{
				return;
			}
			UnityGUITools.DrawText(new Rect(vector.x - this.selectionHeadingSize.x / 2f, (float)Screen.height - vector.y - this.selectionHeadingSize.y / 2f, this.selectionHeadingSize.x, this.selectionHeadingSize.y), this.heading, guiStyle, textStyle, textStyleColor);
			vector = Camera.main.WorldToScreenPoint(gameObject.transform.position + Vector3.up * this.selectionHeight);
			vector += this.offset;
			vector = new Vector3(vector.x, vector.y + this.selectionUseMessageSize.y, vector.z);
			UnityGUITools.DrawText(new Rect(vector.x - this.selectionUseMessageSize.x / 2f, (float)Screen.height - vector.y - this.selectionUseMessageSize.y / 2f, this.selectionUseMessageSize.x, this.selectionUseMessageSize.y), this.useMessage, guiStyle, textStyle, textStyleColor);
			if (reticle != null)
			{
				Texture2D texture2D = (flag ? reticle.inRange : reticle.outOfRange);
				if (texture2D != null)
				{
					vector = Camera.main.WorldToScreenPoint(gameObject.transform.position + Vector3.up * 0.5f * this.selectionHeight);
					GUI.Label(new Rect(vector.x - reticle.width / 2f, (float)Screen.height - vector.y - reticle.height / 2f, reticle.width, reticle.height), texture2D);
				}
			}
		}

		// Token: 0x040001D2 RID: 466
		public Vector3 offset = Vector3.zero;

		// Token: 0x040001D3 RID: 467
		private Selector selector;

		// Token: 0x040001D4 RID: 468
		private ProximitySelector proximitySelector;

		// Token: 0x040001D5 RID: 469
		private bool previousUseDefaultGUI;

		// Token: 0x040001D6 RID: 470
		private Usable lastUsable;

		// Token: 0x040001D7 RID: 471
		private string heading = string.Empty;

		// Token: 0x040001D8 RID: 472
		private string useMessage = string.Empty;

		// Token: 0x040001D9 RID: 473
		private GameObject lastSelectionDrawn;

		// Token: 0x040001DA RID: 474
		private float selectionHeight;

		// Token: 0x040001DB RID: 475
		private Vector2 selectionHeadingSize = Vector2.zero;

		// Token: 0x040001DC RID: 476
		private Vector2 selectionUseMessageSize = Vector2.zero;
	}
}

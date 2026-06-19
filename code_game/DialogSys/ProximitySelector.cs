using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.UnityGUI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000043 RID: 67
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/proximity_selector.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/Proximity Selector")]
	public class ProximitySelector : MonoBehaviour
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060001F1 RID: 497 RVA: 0x0000A434 File Offset: 0x00008634
		// (remove) Token: 0x060001F2 RID: 498 RVA: 0x0000A46C File Offset: 0x0000866C
		public event SelectedUsableObjectDelegate SelectedUsableObject;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060001F3 RID: 499 RVA: 0x0000A4A4 File Offset: 0x000086A4
		// (remove) Token: 0x060001F4 RID: 500 RVA: 0x0000A4DC File Offset: 0x000086DC
		public event DeselectedUsableObjectDelegate DeselectedUsableObject;

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000A511 File Offset: 0x00008711
		public Usable CurrentUsable
		{
			get
			{
				return this.currentUsable;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0000A519 File Offset: 0x00008719
		public GUIStyle GuiStyle
		{
			get
			{
				this.SetGuiStyle();
				return this.guiStyle;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000A527 File Offset: 0x00008727
		public void OnConversationEnd(Transform actor)
		{
			this.timeToEnableUseButton = Time.time + 0.5f;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000A53C File Offset: 0x0000873C
		private void Update()
		{
			if (!base.enabled || Time.timeScale <= 0f)
			{
				return;
			}
			if (DialogueManager.IsConversationActive)
			{
				this.timeToEnableUseButton = Time.time + 0.5f;
			}
			if (this.IsUseButtonDown() && this.currentUsable != null && Time.time >= this.timeToEnableUseButton)
			{
				Transform transform = ((this.actorTransform != null) ? this.actorTransform : base.transform);
				if (this.broadcastToChildren)
				{
					this.currentUsable.gameObject.BroadcastMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
					return;
				}
				this.currentUsable.gameObject.SendMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000A5F0 File Offset: 0x000087F0
		private bool IsUseButtonDown()
		{
			return !DialogueManager.IsDialogueSystemInputDisabled() && ((this.enableTouch && this.IsTouchDown()) || (this.useKey != KeyCode.None && Input.GetKeyDown(this.useKey)) || (!string.IsNullOrEmpty(this.useButton) && Input.GetButtonUp(this.useButton)));
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000A64C File Offset: 0x0000884C
		private bool IsTouchDown()
		{
			if (Input.touchCount >= 1)
			{
				foreach (Touch touch in Input.touches)
				{
					Vector2 vector = new Vector2(touch.position.x, (float)Screen.height - touch.position.y);
					if (this.touchArea.GetPixelRect().Contains(vector))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000A6BD File Offset: 0x000088BD
		private void OnTriggerEnter(Collider other)
		{
			this.CheckTriggerEnter(other.gameObject);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000A6CB File Offset: 0x000088CB
		private void OnTriggerEnter2D(Collider2D other)
		{
			this.CheckTriggerEnter(other.gameObject);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000A6D9 File Offset: 0x000088D9
		private void OnTriggerExit(Collider other)
		{
			this.CheckTriggerExit(other.gameObject);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000A6E7 File Offset: 0x000088E7
		private void OnTriggerExit2D(Collider2D other)
		{
			this.CheckTriggerExit(other.gameObject);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000A6F8 File Offset: 0x000088F8
		private void CheckTriggerEnter(GameObject other)
		{
			Usable component = other.GetComponent<Usable>();
			if (component != null)
			{
				this.SetCurrentUsable(component);
				if (!this.usablesInRange.Contains(component))
				{
					this.usablesInRange.Add(component);
				}
				if (this.SelectedUsableObject != null)
				{
					this.SelectedUsableObject(component);
				}
				this.onSelectedUsable.Invoke(component);
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000A758 File Offset: 0x00008958
		private void CheckTriggerExit(GameObject other)
		{
			Usable component = other.GetComponent<Usable>();
			if (component != null)
			{
				if (this.usablesInRange.Contains(component))
				{
					this.usablesInRange.Remove(component);
				}
				if (this.currentUsable == component)
				{
					if (this.DeselectedUsableObject != null)
					{
						this.DeselectedUsableObject(component);
					}
					this.onDeselectedUsable.Invoke(component);
					Usable usable = null;
					if (this.usablesInRange.Count > 0)
					{
						usable = this.usablesInRange[0];
						if (this.SelectedUsableObject != null)
						{
							this.SelectedUsableObject(usable);
						}
						this.onSelectedUsable.Invoke(component);
					}
					this.SetCurrentUsable(usable);
				}
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000A808 File Offset: 0x00008A08
		private void SetCurrentUsable(Usable usable)
		{
			this.currentUsable = usable;
			if (usable != null)
			{
				this.currentHeading = this.currentUsable.GetName();
				this.currentUseMessage = (string.IsNullOrEmpty(this.currentUsable.overrideUseMessage) ? this.defaultUseMessage : this.currentUsable.overrideUseMessage);
				return;
			}
			this.currentHeading = string.Empty;
			this.currentUseMessage = string.Empty;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000A878 File Offset: 0x00008A78
		public virtual void OnGUI()
		{
			if (this.useDefaultGUI)
			{
				this.SetGuiStyle();
				Rect rect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
				if (this.currentUsable != null)
				{
					UnityGUITools.DrawText(rect, this.currentHeading, this.guiStyle, this.textStyle, this.textStyleColor);
					UnityGUITools.DrawText(new Rect(0f, this.guiStyle.CalcSize(new GUIContent("Ay")).y, (float)Screen.width, (float)Screen.height), this.currentUseMessage, this.guiStyle, this.textStyle, this.textStyleColor);
				}
			}
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000A92C File Offset: 0x00008B2C
		protected void SetGuiStyle()
		{
			GUI.skin = UnityGUITools.GetValidGUISkin(this.guiSkin);
			if (this.guiStyle == null)
			{
				this.guiStyle = new GUIStyle(GUI.skin.FindStyle(this.guiStyleName) ?? GUI.skin.label);
				this.guiStyle.alignment = this.alignment;
				this.guiStyle.normal.textColor = this.color;
			}
		}

		// Token: 0x04000171 RID: 369
		[Tooltip("Use a default OnGUI to display selection message and targeting reticle.")]
		public bool useDefaultGUI = true;

		// Token: 0x04000172 RID: 370
		[Tooltip("GUI skin to use for the target's information (name and use message).")]
		public GUISkin guiSkin;

		// Token: 0x04000173 RID: 371
		[Tooltip("Name of the GUI style in the skin.")]
		public string guiStyleName = "label";

		// Token: 0x04000174 RID: 372
		public TextAnchor alignment = TextAnchor.UpperCenter;

		// Token: 0x04000175 RID: 373
		[Tooltip("Color of the information labels when the target is in range.")]
		public Color color = Color.yellow;

		// Token: 0x04000176 RID: 374
		public TextStyle textStyle = TextStyle.Shadow;

		// Token: 0x04000177 RID: 375
		[Tooltip("Color of the text style's outline or shadow.")]
		public Color textStyleColor = Color.black;

		// Token: 0x04000178 RID: 376
		[Tooltip("Default use message. This can be overridden in the target's Usable component.")]
		public string defaultUseMessage = "(spacebar to interact)";

		// Token: 0x04000179 RID: 377
		[Tooltip("Key that sends an OnUse message.")]
		public KeyCode useKey = KeyCode.Space;

		// Token: 0x0400017A RID: 378
		[Tooltip("Input button that sends an OnUse message.")]
		public string useButton = "Fire2";

		// Token: 0x0400017B RID: 379
		[Tooltip("Enable touch triggering.")]
		public bool enableTouch;

		// Token: 0x0400017C RID: 380
		public ScaledRect touchArea = new ScaledRect(ScaledRect.empty);

		// Token: 0x0400017D RID: 381
		[Tooltip("Broadcast OnUse message to Usable object's children.")]
		public bool broadcastToChildren = true;

		// Token: 0x0400017E RID: 382
		[Tooltip("Actor transform to send with OnUse. Defaults to this transform.")]
		public Transform actorTransform;

		// Token: 0x0400017F RID: 383
		public UsableUnityEvent onSelectedUsable = new UsableUnityEvent();

		// Token: 0x04000180 RID: 384
		public UsableUnityEvent onDeselectedUsable = new UsableUnityEvent();

		// Token: 0x04000183 RID: 387
		private List<Usable> usablesInRange = new List<Usable>();

		// Token: 0x04000184 RID: 388
		private Usable currentUsable;

		// Token: 0x04000185 RID: 389
		private string currentHeading = string.Empty;

		// Token: 0x04000186 RID: 390
		private string currentUseMessage = string.Empty;

		// Token: 0x04000187 RID: 391
		private GUIStyle guiStyle;

		// Token: 0x04000188 RID: 392
		private const float MinTimeBetweenUseButton = 0.5f;

		// Token: 0x04000189 RID: 393
		private float timeToEnableUseButton;

		// Token: 0x02000089 RID: 137
		[Serializable]
		public class Reticle
		{
			// Token: 0x040002C3 RID: 707
			public Texture2D inRange;

			// Token: 0x040002C4 RID: 708
			public Texture2D outOfRange;

			// Token: 0x040002C5 RID: 709
			public float width = 64f;

			// Token: 0x040002C6 RID: 710
			public float height = 64f;
		}
	}
}

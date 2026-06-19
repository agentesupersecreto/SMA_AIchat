using System;
using PixelCrushers.DialogueSystem.UnityGUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200004D RID: 77
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/selector.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/Selector")]
	public class Selector : MonoBehaviour
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000238 RID: 568 RVA: 0x0000B5C5 File Offset: 0x000097C5
		// (set) Token: 0x06000239 RID: 569 RVA: 0x0000B5CD File Offset: 0x000097CD
		public Vector3 CustomPosition { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000B5D6 File Offset: 0x000097D6
		public Usable CurrentUsable
		{
			get
			{
				return this.usable;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000B5DE File Offset: 0x000097DE
		public float CurrentDistance
		{
			get
			{
				return this.distance;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000B5E6 File Offset: 0x000097E6
		public GUIStyle GuiStyle
		{
			get
			{
				this.SetGuiStyle();
				return this.guiStyle;
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600023D RID: 573 RVA: 0x0000B5F4 File Offset: 0x000097F4
		// (remove) Token: 0x0600023E RID: 574 RVA: 0x0000B62C File Offset: 0x0000982C
		public event SelectedUsableObjectDelegate SelectedUsableObject;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600023F RID: 575 RVA: 0x0000B664 File Offset: 0x00009864
		// (remove) Token: 0x06000240 RID: 576 RVA: 0x0000B69C File Offset: 0x0000989C
		public event DeselectedUsableObjectDelegate DeselectedUsableObject;

		// Token: 0x06000241 RID: 577 RVA: 0x0000B6D1 File Offset: 0x000098D1
		public virtual void Start()
		{
			if (Camera.main == null)
			{
				Debug.LogError("Dialogue System: The scene is missing a camera tagged 'MainCamera'. The Selector may not behave the way you expect.", this);
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000B6EC File Offset: 0x000098EC
		protected void Update()
		{
			if (!base.enabled || Time.timeScale <= 0f)
			{
				return;
			}
			if (Camera.main == null)
			{
				return;
			}
			if (this.selectAt == Selector.SelectAt.MousePosition && EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}
			Selector.Dimension dimension = this.runRaycasts;
			if (dimension != Selector.Dimension.In2D)
			{
				if (dimension != Selector.Dimension.In3D)
				{
				}
				this.Run3DRaycast();
			}
			else
			{
				this.Run2DRaycast();
			}
			if (this.IsUseButtonDown() && this.usable != null)
			{
				this.clickedDownOn = null;
				if (this.distance <= this.usable.maxUseDistance)
				{
					Transform transform = ((this.actorTransform != null) ? this.actorTransform : base.transform);
					if (this.broadcastToChildren)
					{
						this.usable.gameObject.BroadcastMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
						return;
					}
					this.usable.gameObject.SendMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
					return;
				}
				else
				{
					if (!string.IsNullOrEmpty(this.tooFarMessage))
					{
						DialogueManager.ShowAlert(this.tooFarMessage);
					}
					this.tooFarEvent.Invoke();
				}
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000B80C File Offset: 0x00009A0C
		protected void Run2DRaycast()
		{
			if (this.raycastAll)
			{
				RaycastHit2D[] array = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(this.GetSelectionPoint()), Vector2.zero, this.maxSelectionDistance, this.layerMask);
				bool flag = false;
				foreach (RaycastHit2D raycastHit2D in array)
				{
					float num = ((this.distanceFrom == Selector.DistanceFrom.Camera) ? 0f : Vector3.Distance(base.gameObject.transform.position, raycastHit2D.collider.transform.position));
					if (this.selection == raycastHit2D.collider.gameObject)
					{
						flag = true;
						this.distance = num;
						break;
					}
					Usable component = raycastHit2D.collider.gameObject.GetComponent<Usable>();
					if (component != null)
					{
						flag = true;
						this.distance = num;
						this.usable = component;
						this.selection = raycastHit2D.collider.gameObject;
						if (this.SelectedUsableObject != null)
						{
							this.SelectedUsableObject(this.usable);
						}
						this.onSelectedUsable.Invoke(this.usable);
						break;
					}
				}
				if (!flag)
				{
					this.DeselectTarget();
					return;
				}
			}
			else
			{
				RaycastHit2D raycastHit2D2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(this.GetSelectionPoint()), Vector2.zero, this.maxSelectionDistance, this.layerMask);
				if (raycastHit2D2.collider != null)
				{
					this.distance = ((this.distanceFrom == Selector.DistanceFrom.Camera) ? 0f : Vector3.Distance(base.gameObject.transform.position, raycastHit2D2.collider.transform.position));
					if (this.selection != raycastHit2D2.collider.gameObject)
					{
						Usable component2 = raycastHit2D2.collider.gameObject.GetComponent<Usable>();
						if (component2 != null)
						{
							this.usable = component2;
							this.selection = raycastHit2D2.collider.gameObject;
							this.heading = string.Empty;
							this.useMessage = string.Empty;
							if (this.SelectedUsableObject != null)
							{
								this.SelectedUsableObject(this.usable);
							}
							this.onSelectedUsable.Invoke(this.usable);
							return;
						}
						this.DeselectTarget();
						return;
					}
				}
				else
				{
					this.DeselectTarget();
				}
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000BA6C File Offset: 0x00009C6C
		protected void Run3DRaycast()
		{
			Ray ray = Camera.main.ScreenPointToRay(this.GetSelectionPoint());
			this.lastRay = ray;
			if (this.raycastAll)
			{
				RaycastHit[] array = Physics.RaycastAll(ray, this.maxSelectionDistance, this.layerMask);
				this.lastRay = ray;
				this.lastHits = array;
				bool flag = false;
				foreach (RaycastHit raycastHit in array)
				{
					float num = ((this.distanceFrom == Selector.DistanceFrom.Camera) ? raycastHit.distance : Vector3.Distance(base.gameObject.transform.position, raycastHit.collider.transform.position));
					if (this.selection == raycastHit.collider.gameObject)
					{
						flag = true;
						this.distance = num;
						break;
					}
					Usable component = raycastHit.collider.gameObject.GetComponent<Usable>();
					if (component != null)
					{
						flag = true;
						this.distance = num;
						this.usable = component;
						this.selection = raycastHit.collider.gameObject;
						if (this.SelectedUsableObject != null)
						{
							this.SelectedUsableObject(this.usable);
						}
						this.onSelectedUsable.Invoke(this.usable);
						break;
					}
				}
				if (!flag)
				{
					this.DeselectTarget();
					return;
				}
			}
			else
			{
				RaycastHit raycastHit2;
				if (Physics.Raycast(ray, out raycastHit2, this.maxSelectionDistance, this.layerMask))
				{
					this.distance = ((this.distanceFrom == Selector.DistanceFrom.Camera) ? raycastHit2.distance : Vector3.Distance(base.gameObject.transform.position, raycastHit2.collider.transform.position));
					if (this.selection != raycastHit2.collider.gameObject)
					{
						Usable component2 = raycastHit2.collider.gameObject.GetComponent<Usable>();
						if (component2 != null)
						{
							this.usable = component2;
							this.selection = raycastHit2.collider.gameObject;
							this.heading = string.Empty;
							this.useMessage = string.Empty;
							if (this.SelectedUsableObject != null)
							{
								this.SelectedUsableObject(this.usable);
							}
							this.onSelectedUsable.Invoke(this.usable);
						}
						else
						{
							this.DeselectTarget();
						}
					}
				}
				else
				{
					this.DeselectTarget();
				}
				this.lastHit = raycastHit2;
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000BCC8 File Offset: 0x00009EC8
		protected virtual void DeselectTarget()
		{
			if (this.usable != null)
			{
				if (this.DeselectedUsableObject != null)
				{
					this.DeselectedUsableObject(this.usable);
				}
				this.onDeselectedUsable.Invoke(this.usable);
			}
			this.usable = null;
			this.selection = null;
			this.heading = string.Empty;
			this.useMessage = string.Empty;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000BD34 File Offset: 0x00009F34
		protected bool IsUseButtonDown()
		{
			if (DialogueManager.IsDialogueSystemInputDisabled())
			{
				return false;
			}
			if (!string.IsNullOrEmpty(this.useButton) && DialogueManager.GetInputButtonDown(this.useButton))
			{
				this.clickedDownOn = this.selection;
			}
			return (this.useKey != KeyCode.None && Input.GetKeyDown(this.useKey)) || (!string.IsNullOrEmpty(this.useButton) && Input.GetButtonUp(this.useButton) && this.selection == this.clickedDownOn);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000BDBC File Offset: 0x00009FBC
		protected Vector3 GetSelectionPoint()
		{
			switch (this.selectAt)
			{
			case Selector.SelectAt.MousePosition:
				return Input.mousePosition;
			case Selector.SelectAt.CustomPosition:
				return this.CustomPosition;
			}
			return new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000BE08 File Offset: 0x0000A008
		public virtual void OnGUI()
		{
			if (this.useDefaultGUI)
			{
				this.SetGuiStyle();
				Rect rect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
				if (this.usable != null)
				{
					bool flag = this.distance <= this.usable.maxUseDistance;
					this.guiStyle.normal.textColor = (flag ? this.inRangeColor : this.outOfRangeColor);
					if (string.IsNullOrEmpty(this.heading))
					{
						this.heading = this.usable.GetName();
						this.useMessage = (string.IsNullOrEmpty(this.usable.overrideUseMessage) ? this.defaultUseMessage : this.usable.overrideUseMessage);
					}
					UnityGUITools.DrawText(rect, this.heading, this.guiStyle, this.textStyle, this.textStyleColor);
					UnityGUITools.DrawText(new Rect(0f, this.guiStyle.CalcSize(new GUIContent("Ay")).y, (float)Screen.width, (float)Screen.height), this.useMessage, this.guiStyle, this.textStyle, this.textStyleColor);
					Texture2D texture2D = (flag ? this.reticle.inRange : this.reticle.outOfRange);
					if (texture2D != null)
					{
						GUI.Label(new Rect(0.5f * ((float)Screen.width - this.reticle.width), 0.5f * ((float)Screen.height - this.reticle.height), this.reticle.width, this.reticle.height), texture2D);
					}
				}
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000BFB8 File Offset: 0x0000A1B8
		protected void SetGuiStyle()
		{
			GUI.skin = UnityGUITools.GetValidGUISkin(this.guiSkin);
			if (this.guiStyle == null)
			{
				this.guiStyle = new GUIStyle(GUI.skin.FindStyle(this.guiStyleName) ?? GUI.skin.label);
				this.guiStyle.alignment = this.alignment;
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000C018 File Offset: 0x0000A218
		public virtual void OnDrawGizmos()
		{
			if (!this.debug)
			{
				return;
			}
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.lastRay.origin, this.lastRay.origin + this.lastRay.direction * this.maxSelectionDistance);
			if (this.raycastAll)
			{
				foreach (RaycastHit raycastHit in this.lastHits)
				{
					Gizmos.color = ((raycastHit.collider.GetComponent<Usable>() != null) ? Color.green : Color.red);
					Gizmos.DrawWireSphere(raycastHit.point, 0.2f);
				}
				return;
			}
			if (this.lastHit.collider != null)
			{
				Gizmos.color = ((this.lastHit.collider.GetComponent<Usable>() != null) ? Color.green : Color.red);
				Gizmos.DrawWireSphere(this.lastHit.point, 0.2f);
			}
		}

		// Token: 0x040001AB RID: 427
		private static LayerMask DefaultLayer = 1;

		// Token: 0x040001AC RID: 428
		[Tooltip("Layer mask to use when targeting objects; objects on others layers are ignored.")]
		public LayerMask layerMask = Selector.DefaultLayer;

		// Token: 0x040001AD RID: 429
		[Tooltip("How to target.")]
		public Selector.SelectAt selectAt;

		// Token: 0x040001AE RID: 430
		[Tooltip("How to compute range to targeted object.")]
		public Selector.DistanceFrom distanceFrom;

		// Token: 0x040001AF RID: 431
		[Tooltip("Don't target objects farther than this; targets may still be unusable if beyond their usable range.")]
		public float maxSelectionDistance = 30f;

		// Token: 0x040001B0 RID: 432
		public Selector.Dimension runRaycasts = Selector.Dimension.In3D;

		// Token: 0x040001B1 RID: 433
		[Tooltip("Check all objects within raycast range for usables, even passing through obstacles.")]
		public bool raycastAll;

		// Token: 0x040001B2 RID: 434
		[Tooltip("")]
		public bool useDefaultGUI = true;

		// Token: 0x040001B3 RID: 435
		[Tooltip("GUI skin to use for the target's information (name and use message).")]
		public GUISkin guiSkin;

		// Token: 0x040001B4 RID: 436
		[Tooltip("Name of the GUI style in the skin.")]
		public string guiStyleName = "label";

		// Token: 0x040001B5 RID: 437
		public TextAnchor alignment = TextAnchor.UpperCenter;

		// Token: 0x040001B6 RID: 438
		public TextStyle textStyle = TextStyle.Shadow;

		// Token: 0x040001B7 RID: 439
		public Color textStyleColor = Color.black;

		// Token: 0x040001B8 RID: 440
		[Tooltip("Color of the information labels when target is in range.")]
		public Color inRangeColor = Color.yellow;

		// Token: 0x040001B9 RID: 441
		[Tooltip("Color of the information labels when target is out of range.")]
		public Color outOfRangeColor = Color.gray;

		// Token: 0x040001BA RID: 442
		public Selector.Reticle reticle;

		// Token: 0x040001BB RID: 443
		public KeyCode useKey = KeyCode.Space;

		// Token: 0x040001BC RID: 444
		public string useButton = "Fire2";

		// Token: 0x040001BD RID: 445
		[Tooltip("Default use message; can be overridden in the target's Usable component")]
		public string defaultUseMessage = "(spacebar to interact)";

		// Token: 0x040001BE RID: 446
		[Tooltip("Tick to also broadcast to the usable object's children")]
		public bool broadcastToChildren = true;

		// Token: 0x040001BF RID: 447
		[Tooltip("Actor transform to send with OnUse; defaults to this transform")]
		public Transform actorTransform;

		// Token: 0x040001C0 RID: 448
		[Tooltip("If set, show this alert message if attempt to use something beyond its usable range")]
		public string tooFarMessage = string.Empty;

		// Token: 0x040001C1 RID: 449
		public UsableUnityEvent onSelectedUsable = new UsableUnityEvent();

		// Token: 0x040001C2 RID: 450
		public UsableUnityEvent onDeselectedUsable = new UsableUnityEvent();

		// Token: 0x040001C3 RID: 451
		public UnityEvent tooFarEvent = new UnityEvent();

		// Token: 0x040001C4 RID: 452
		[Tooltip("Tick to draw gizmos in Scene view")]
		public bool debug;

		// Token: 0x040001C8 RID: 456
		protected GameObject selection;

		// Token: 0x040001C9 RID: 457
		protected Usable usable;

		// Token: 0x040001CA RID: 458
		protected GameObject clickedDownOn;

		// Token: 0x040001CB RID: 459
		protected string heading = string.Empty;

		// Token: 0x040001CC RID: 460
		protected string useMessage = string.Empty;

		// Token: 0x040001CD RID: 461
		protected float distance;

		// Token: 0x040001CE RID: 462
		protected GUIStyle guiStyle;

		// Token: 0x040001CF RID: 463
		protected Ray lastRay;

		// Token: 0x040001D0 RID: 464
		protected RaycastHit lastHit;

		// Token: 0x040001D1 RID: 465
		protected RaycastHit[] lastHits = new RaycastHit[0];

		// Token: 0x02000090 RID: 144
		[Serializable]
		public class Reticle
		{
			// Token: 0x040002DC RID: 732
			public Texture2D inRange;

			// Token: 0x040002DD RID: 733
			public Texture2D outOfRange;

			// Token: 0x040002DE RID: 734
			public float width = 64f;

			// Token: 0x040002DF RID: 735
			public float height = 64f;
		}

		// Token: 0x02000091 RID: 145
		public enum SelectAt
		{
			// Token: 0x040002E1 RID: 737
			CenterOfScreen,
			// Token: 0x040002E2 RID: 738
			MousePosition,
			// Token: 0x040002E3 RID: 739
			CustomPosition
		}

		// Token: 0x02000092 RID: 146
		public enum DistanceFrom
		{
			// Token: 0x040002E5 RID: 741
			Camera,
			// Token: 0x040002E6 RID: 742
			GameObject
		}

		// Token: 0x02000093 RID: 147
		public enum Dimension
		{
			// Token: 0x040002E8 RID: 744
			In2D,
			// Token: 0x040002E9 RID: 745
			In3D
		}
	}
}

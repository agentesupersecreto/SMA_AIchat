using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.UnityGUI;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001E RID: 30
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/selector.html")]
	[AddComponentMenu("Dialogue System/Actor/Player/SelectorTValle")]
	public sealed class SelectorTValle : MonoBehaviour
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00005AAB File Offset: 0x00003CAB
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00005AB3 File Offset: 0x00003CB3
		public Vector3 CustomPosition { get; set; }

		// Token: 0x0600010D RID: 269 RVA: 0x00005ABC File Offset: 0x00003CBC
		private void Start()
		{
			if (Camera.main == null)
			{
				Debug.LogError("Dialogue System: The scene is missing a camera tagged 'MainCamera'. The Selector may not behave the way you expect.", this);
			}
			Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed += this.OnIdiomaChanged;
			this.LoadDefaultUseMessage();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005AF8 File Offset: 0x00003CF8
		private void LoadDefaultUseMessage()
		{
			string text = this.toInteractMessage;
			if (DialogueManager.DisplaySettings.localizationSettings.localizedText.ContainsField(text))
			{
				text = DialogueManager.DisplaySettings.localizationSettings.localizedText[text];
			}
			this.defaultUseMessage = string.Format("({0} {1})", this.useKey, text);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005B55 File Offset: 0x00003D55
		private void OnDestroy()
		{
			if (Singleton<ConfiguracionGeneralDeIdioma>.IsInScene)
			{
				Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.changed -= this.OnIdiomaChanged;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005B79 File Offset: 0x00003D79
		private void OnIdiomaChanged(ConfiguracionGeneralDeIdioma.Config.Idioma config, string last, string current)
		{
			this.heading = string.Empty;
			this.useMessage = string.Empty;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005B94 File Offset: 0x00003D94
		private void Update()
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
			this.Run3DRaycast();
			if (this.IsUseButtonDown() && this.usablesCasteados.Count > 0)
			{
				this.usablesCasteados.Sort((SelectorTValle.UsableCasteado a, SelectorTValle.UsableCasteado b) => b.usable.prioridad.CompareTo(a.usable.prioridad));
				for (int i = 0; i < this.usablesCasteados.Count; i++)
				{
					SelectorTValle.UsableCasteado usableCasteado = this.usablesCasteados[i];
					IUsable usable = usableCasteado.usable;
					if (usableCasteado.distance <= usable.maxUseDistance)
					{
						Transform transform = ((this.actorTransform != null) ? this.actorTransform : base.transform);
						if (usable.UseMessages)
						{
							if (this.broadcastToChildren)
							{
								usable.BroadcastMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
							}
							else
							{
								usable.SendMessage("OnUse", transform, SendMessageOptions.DontRequireReceiver);
							}
						}
						usable.OnUsado(transform);
						return;
					}
				}
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005CC0 File Offset: 0x00003EC0
		private void Run3DRaycast()
		{
			for (int i = 0; i < this.usablesCasteados.Count; i++)
			{
				this.m_pool.ReturnItem(this.usablesCasteados[i]);
			}
			this.usablesCasteados.Clear();
			Ray ray = Camera.main.ScreenPointToRay(this.GetSelectionPoint());
			int num = Physics.RaycastNonAlloc(ray, this.lastHits, this.maxSelectionDistance, this.layerMask);
			bool flag = false;
			for (int j = 0; j < num; j++)
			{
				RaycastHit raycastHit = this.lastHits[j];
				IUsable componentInParent = raycastHit.collider.gameObject.GetComponentInParent<IUsable>();
				if (componentInParent != null && componentInParent.enabled && componentInParent.puedeUsarse && raycastHit.distance > 0f)
				{
					flag = true;
					SelectorTValle.UsableCasteado item = this.m_pool.GetItem();
					item.usable = componentInParent;
					item.distance = raycastHit.distance;
					this.usablesCasteados.Add(item);
				}
			}
			num = Physics.OverlapSphereNonAlloc(ray.origin, 0.1f, this.lastColliders);
			for (int k = 0; k < num; k++)
			{
				IUsable componentInParent2 = this.lastColliders[k].gameObject.GetComponentInParent<IUsable>();
				if (componentInParent2 != null && componentInParent2.enabled && componentInParent2.puedeUsarse)
				{
					flag = true;
					SelectorTValle.UsableCasteado item2 = this.m_pool.GetItem();
					item2.usable = componentInParent2;
					item2.distance = 0f;
					this.usablesCasteados.Add(item2);
				}
			}
			if (!flag)
			{
				this.DeselectTarget();
			}
			if (!this.m_cleaningCoolDown.isOn)
			{
				this.m_cleaningCoolDown.ApplyNext(60f.Random(0.333f));
				Array.Clear(this.lastHits, 0, this.lastHits.Length);
				Array.Clear(this.lastColliders, 0, this.lastColliders.Length);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005E9E File Offset: 0x0000409E
		private bool IsUseButtonDown()
		{
			return (this.useKey != KeyCode.None && Input.GetKeyDown(this.useKey)) || (!string.IsNullOrEmpty(this.useButton) && Input.GetButtonUp(this.useButton));
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005ED1 File Offset: 0x000040D1
		private void DeselectTarget()
		{
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005ED4 File Offset: 0x000040D4
		private Vector3 GetSelectionPoint()
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

		// Token: 0x06000116 RID: 278 RVA: 0x00005F20 File Offset: 0x00004120
		public void OnGUI()
		{
			if (this.useDefaultGUI && this.usablesCasteados.Count > 0)
			{
				this.SetGuiStyle();
				Rect rect = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);
				SelectorTValle.UsableCasteado usableCasteado = this.usablesCasteados[0];
				IUsable usable = usableCasteado.usable;
				float distance = usableCasteado.distance;
				if (usable != null)
				{
					bool flag = distance <= usable.maxUseDistance;
					this.guiStyle.normal.textColor = (flag ? this.inRangeColor : this.outOfRangeColor);
					if (usable != this.m_lastDrawed)
					{
						this.LoadDefaultUseMessage();
						this.m_lastDrawed = usable;
						this.useMessage = (string.IsNullOrEmpty(usable.overrideUseMessage) ? this.defaultUseMessage : usable.overrideUseMessage);
					}
					this.heading = usable.GetName();
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

		// Token: 0x06000117 RID: 279 RVA: 0x000060E0 File Offset: 0x000042E0
		private void SetGuiStyle()
		{
			GUI.skin = UnityGUITools.GetValidGUISkin(this.guiSkin);
			if (this.guiStyle == null)
			{
				this.guiStyle = new GUIStyle(GUI.skin.FindStyle(this.guiStyleName) ?? GUI.skin.label);
				this.guiStyle.alignment = this.alignment;
			}
		}

		// Token: 0x0400007C RID: 124
		private static LayerMask DefaultLayer = 1;

		// Token: 0x0400007D RID: 125
		private CoolDown m_cleaningCoolDown = new CoolDown();

		// Token: 0x0400007E RID: 126
		[Tooltip("Layer mask to use when targeting objects; objects on others layers are ignored.")]
		public LayerMask layerMask = SelectorTValle.DefaultLayer;

		// Token: 0x0400007F RID: 127
		[Tooltip("How to tipTarget.")]
		public Selector.SelectAt selectAt;

		// Token: 0x04000080 RID: 128
		[Tooltip("Don't tipTarget objects farther than this; targets may still be unusable if beyond their usable range.")]
		public float maxSelectionDistance = 30f;

		// Token: 0x04000081 RID: 129
		public KeyCode useKey = KeyCode.Space;

		// Token: 0x04000082 RID: 130
		public string useButton = "Fire2";

		// Token: 0x04000083 RID: 131
		[Tooltip("Tick to also broadcast to the usable object's children")]
		public bool broadcastToChildren = true;

		// Token: 0x04000084 RID: 132
		[Tooltip("Actor transform to send with OnUse; defaults to this transform")]
		public Transform actorTransform;

		// Token: 0x04000085 RID: 133
		[Tooltip("")]
		public bool useDefaultGUI = true;

		// Token: 0x04000086 RID: 134
		[Tooltip("GUI skin to use for the tipTarget's information (name and use message).")]
		public GUISkin guiSkin;

		// Token: 0x04000087 RID: 135
		[Tooltip("Name of the GUI style in the skin.")]
		public string guiStyleName = "label";

		// Token: 0x04000088 RID: 136
		[Tooltip("Default use message; can be overridden in the tipTarget's Usable component")]
		[ReadOnlyUI]
		public string defaultUseMessage = "(spacebar to interact)";

		// Token: 0x04000089 RID: 137
		[Tooltip("mensage q se traducira y añadira a defaultUseMessage con la tecla de accion")]
		public string toInteractMessage = "to interact";

		// Token: 0x0400008A RID: 138
		public TextAnchor alignment = TextAnchor.UpperCenter;

		// Token: 0x0400008B RID: 139
		public TextStyle textStyle = TextStyle.Shadow;

		// Token: 0x0400008C RID: 140
		public Color textStyleColor = Color.black;

		// Token: 0x0400008D RID: 141
		[Tooltip("Color of the information labels when tipTarget is in range.")]
		public Color inRangeColor = Color.yellow;

		// Token: 0x0400008E RID: 142
		[Tooltip("Color of the information labels when tipTarget is out of range.")]
		public Color outOfRangeColor = Color.gray;

		// Token: 0x0400008F RID: 143
		public Selector.Reticle reticle;

		// Token: 0x04000091 RID: 145
		private RaycastHit[] lastHits = new RaycastHit[50];

		// Token: 0x04000092 RID: 146
		private Collider[] lastColliders = new Collider[50];

		// Token: 0x04000093 RID: 147
		private List<SelectorTValle.UsableCasteado> usablesCasteados = new List<SelectorTValle.UsableCasteado>();

		// Token: 0x04000094 RID: 148
		private GUIStyle guiStyle;

		// Token: 0x04000095 RID: 149
		private SimplePoolDeClearables<SelectorTValle.UsableCasteado> m_pool = new SimplePoolDeClearables<SelectorTValle.UsableCasteado>();

		// Token: 0x04000096 RID: 150
		private IUsable m_lastDrawed;

		// Token: 0x04000097 RID: 151
		private string heading = string.Empty;

		// Token: 0x04000098 RID: 152
		private string useMessage = string.Empty;

		// Token: 0x02000086 RID: 134
		[Serializable]
		public class UsableCasteado : IClearable
		{
			// Token: 0x060003FC RID: 1020 RVA: 0x0001543A File Offset: 0x0001363A
			public void Clear()
			{
				this.usable = null;
			}

			// Token: 0x04000199 RID: 409
			public IUsable usable;

			// Token: 0x0400019A RID: 410
			public float distance;
		}
	}
}

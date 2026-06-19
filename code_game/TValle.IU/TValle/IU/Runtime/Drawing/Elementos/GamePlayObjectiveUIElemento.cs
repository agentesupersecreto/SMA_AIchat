using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011D RID: 285
	public class GamePlayObjectiveUIElemento : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IPointerClickHandler, IEventSystemHandler, IUIElementoClickable
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		public Toggle toggle
		{
			get
			{
				return this.m_toggle;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x0001D5AC File Offset: 0x0001B7AC
		public TextMeshProUGUI label1
		{
			get
			{
				return this.m_label1;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x0001D5B4 File Offset: 0x0001B7B4
		public TextMeshProUGUI label2
		{
			get
			{
				return this.m_label2;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		public SimpleTooltip tooltip
		{
			get
			{
				return this.m_tooltip;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x0001D5C4 File Offset: 0x0001B7C4
		public OnElementoClicked onElementoClicked
		{
			get
			{
				return this.m_onElementoClicked;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0001D5CC File Offset: 0x0001B7CC
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0001D5DF File Offset: 0x0001B7DF
		public virtual void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0001D5FC File Offset: 0x0001B7FC
		public void SetValor(object valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			GamePlayObjectiveModel gamePlayObjectiveModel = valor as GamePlayObjectiveModel;
			if (gamePlayObjectiveModel == null)
			{
				gamePlayObjectiveModel = GamePlayObjectiveModel.empty;
			}
			foreach (RectTransform rectTransform in this.m_descripcionesInstanciadas)
			{
				if (!(rectTransform == null))
				{
					Object.Destroy(rectTransform);
				}
			}
			this.m_descripcionesInstanciadas.Clear();
			foreach (ValueTuple<string, bool> valueTuple in gamePlayObjectiveModel.subObjetives)
			{
				RectTransform rectTransform2 = Object.Instantiate<RectTransform>(this.m_descripcionPanelPrefab, this.m_elementsPanel);
				rectTransform2.GetComponentInChildren<TextMeshProUGUI>().text = valueTuple.Item1;
				rectTransform2.GetComponentInChildren<Toggle>().isOn = valueTuple.Item2;
				this.m_descripcionesInstanciadas.Add(rectTransform2);
			}
			this.m_label1.text = gamePlayObjectiveModel.description;
			this.m_label2.text = gamePlayObjectiveModel.progress;
			this.m_tooltip.infoLeft = gamePlayObjectiveModel.tooltip;
			if (string.IsNullOrWhiteSpace((gamePlayObjectiveModel != null) ? gamePlayObjectiveModel.tooltip : null))
			{
				if (this.m_canvasGroup == null)
				{
					this.m_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
				}
				this.m_canvasGroup.interactable = true;
				this.m_canvasGroup.ignoreParentGroups = false;
				this.m_canvasGroup.blocksRaycasts = false;
			}
			else if (this.m_canvasGroup != null)
			{
				Object.Destroy(this.m_canvasGroup);
				this.m_canvasGroup = null;
			}
			this.m_self.minHeight = (this.m_self.preferredHeight = (float)(20 + gamePlayObjectiveModel.subObjetives.Count * 15));
			this.toggle.isOn = gamePlayObjectiveModel.completed;
			if (gamePlayObjectiveModel != this.m_value)
			{
				this.m_value = gamePlayObjectiveModel;
				OnValueChanged onValueChanged = this.m_onValueChanged;
				if (onValueChanged == null)
				{
					return;
				}
				onValueChanged.Invoke(this);
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0001D80C File Offset: 0x0001BA0C
		public object GetValor()
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			return this.m_value;
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0001D822 File Offset: 0x0001BA22
		public void OnPointerClick(PointerEventData eventData)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			OnElementoClicked onElementoClicked = this.m_onElementoClicked;
			if (onElementoClicked != null)
			{
				onElementoClicked.Invoke(this);
			}
			GamePlayObjectiveModel value = this.m_value;
			if (value == null)
			{
				return;
			}
			value.OnClicked(this, base.modelItemIndex);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0001D87F File Offset: 0x0001BA7F
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0001D887 File Offset: 0x0001BA87
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000360 RID: 864
		[SerializeField]
		private GamePlayObjectiveModel m_value;

		// Token: 0x04000361 RID: 865
		[SerializeField]
		private LayoutElement m_self;

		// Token: 0x04000362 RID: 866
		[SerializeField]
		private Toggle m_toggle;

		// Token: 0x04000363 RID: 867
		[SerializeField]
		private TextMeshProUGUI m_label1;

		// Token: 0x04000364 RID: 868
		[SerializeField]
		private TextMeshProUGUI m_label2;

		// Token: 0x04000365 RID: 869
		[SerializeField]
		private SimpleTooltip m_tooltip;

		// Token: 0x04000366 RID: 870
		[SerializeField]
		private RectTransform m_elementsPanel;

		// Token: 0x04000367 RID: 871
		[SerializeField]
		private RectTransform m_descripcionPanelPrefab;

		// Token: 0x04000368 RID: 872
		[SerializeField]
		private List<RectTransform> m_descripcionesInstanciadas = new List<RectTransform>();

		// Token: 0x04000369 RID: 873
		[SerializeField]
		private OnElementoClicked m_onElementoClicked = new OnElementoClicked();

		// Token: 0x0400036A RID: 874
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x0400036B RID: 875
		private CanvasGroup m_canvasGroup;
	}
}

using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000118 RID: 280
	public abstract class SelectablePortraitBase : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IPointerClickHandler, IEventSystemHandler, IUIElementoClickable, IUIElementoConDescripcionSimple
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0001C877 File Offset: 0x0001AA77
		public Texture2D loadedTexture
		{
			get
			{
				return this.m_loadedTexture;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0001C87F File Offset: 0x0001AA7F
		public OnValueChanged onValueChangedPre
		{
			get
			{
				return this.m_onValueChangedPre;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0001C887 File Offset: 0x0001AA87
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0001C88F File Offset: 0x0001AA8F
		public OnElementoClicked onElementoClicked
		{
			get
			{
				return this.m_onElementoClicked;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001C897 File Offset: 0x0001AA97
		public Toggle toggle
		{
			get
			{
				return this.m_toggle;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0001C89F File Offset: 0x0001AA9F
		public RawImage loading
		{
			get
			{
				return this.m_loading;
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0001C8A7 File Offset: 0x0001AAA7
		public Image grayOut
		{
			get
			{
				return this.m_grayOut;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0001C8AF File Offset: 0x0001AAAF
		public string idDeProtrait
		{
			get
			{
				return this.m_IdDeProtrait;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0001C8B7 File Offset: 0x0001AAB7
		public string nombreDeProtrait
		{
			get
			{
				return this.m_nombreDeProtrait;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0001C8BF File Offset: 0x0001AABF
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x0001C8CC File Offset: 0x0001AACC
		string IUIElementoConDescripcionSimple.descripcion
		{
			get
			{
				return this.tooltip.infoLeft;
			}
			set
			{
				this.tooltip.infoLeft = value;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001C8DA File Offset: 0x0001AADA
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x0001C8E7 File Offset: 0x0001AAE7
		float IUIElementoConDescripcionSimple.widthMod
		{
			get
			{
				return this.tooltip.widthMod;
			}
			set
			{
				this.tooltip.widthMod = value;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x0600084F RID: 2127
		protected abstract bool linkToggleAndElementClick { get; }

		// Token: 0x06000850 RID: 2128 RVA: 0x0001C8F8 File Offset: 0x0001AAF8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_toggle == null)
			{
				throw new ArgumentNullException("m_toggle", "m_toggle null reference.");
			}
			if (this.m_portrait == null)
			{
				throw new ArgumentNullException("m_portrait", "m_portrait null reference.");
			}
			if (this.m_grayOut == null)
			{
				throw new ArgumentNullException("m_grayOut", "m_grayOut null reference.");
			}
			if (this.m_loading == null)
			{
				throw new ArgumentNullException("m_loading", "m_loading null reference.");
			}
			if (this.m_nombre == null)
			{
				throw new ArgumentNullException("m_nombre", "m_nombre null reference.");
			}
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
			this.m_portrait.texture = null;
			this.m_nombre.text = string.Empty;
			this.m_portrait.enabled = false;
			this.m_grayOut.enabled = false;
			this.m_loading.enabled = true;
			this.m_toggle.isOn = false;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0001CA0B File Offset: 0x0001AC0B
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (!this.imageIsDiskAsset && this.m_loadedTexture != null)
			{
				Object.Destroy(this.m_loadedTexture);
			}
			this.m_loadedTexture = null;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0001CA3C File Offset: 0x0001AC3C
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			base.Bind(modeloName, modeloType, isListItem);
			this.m_toggle.isOn = false;
			if (base.isBinded)
			{
				this.m_toggle.onValueChanged.AddListener(new UnityAction<bool>(this.onToggleValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0001CA99 File Offset: 0x0001AC99
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			throw new NotSupportedException("se neceita valor inicial para hacer carga de imagen");
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0001CAA5 File Offset: 0x0001ACA5
		public object GetValor()
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			return new ValueTuple<string, bool>(this.m_nombreDeProtrait, this.m_toggle.isOn);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		public virtual void SetValor(object valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (valor is IMultipleValorElemento<string, bool>)
			{
				IMultipleValorElemento<string, bool> multipleValorElemento = (IMultipleValorElemento<string, bool>)valor;
				this.m_nombreDeProtrait = multipleValorElemento.item1;
				this.m_IdDeProtrait = multipleValorElemento.item1;
				this.SetValor(multipleValorElemento.item2, silenced);
				return;
			}
			if (valor is IMultipleValorElemento<string, string, bool>)
			{
				IMultipleValorElemento<string, string, bool> multipleValorElemento2 = (IMultipleValorElemento<string, string, bool>)valor;
				this.m_nombreDeProtrait = multipleValorElemento2.item2;
				this.m_IdDeProtrait = multipleValorElemento2.item1;
				this.SetValor(multipleValorElemento2.item3, silenced);
				return;
			}
			if (valor is IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>)
			{
				IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento3 = (IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>)valor;
				this.m_nombreDeProtrait = multipleValorElemento3.item2;
				this.m_IdDeProtrait = multipleValorElemento3.item1;
				this.m_customLoader = multipleValorElemento3.item3;
				this.SetValor(multipleValorElemento3.item4, silenced);
				return;
			}
			throw new ArgumentOutOfRangeException("valor de tipo no compatible");
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		public void SetValor(bool valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (!this.m_toggle.isActiveAndEnabled || !this.m_toggle.interactable)
			{
				return;
			}
			if (silenced)
			{
				this.m_toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.onToggleValueChanged));
			}
			try
			{
				this.m_toggle.isOn = valor;
			}
			finally
			{
				if (silenced)
				{
					this.m_toggle.onValueChanged.AddListener(new UnityAction<bool>(this.onToggleValueChanged));
				}
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0001CC34 File Offset: 0x0001AE34
		public void DoLoad()
		{
			if (this.m_loadedTexture != null)
			{
				Object.Destroy(this.m_loadedTexture);
			}
			this.m_loadedTexture = null;
			if (this.m_customLoader == null)
			{
				this.CargarThumbnail(this.m_IdDeProtrait, this.m_nombreDeProtrait, ref this.m_loadedTexture);
			}
			else
			{
				this.m_customLoader(this.m_IdDeProtrait, this.m_nombreDeProtrait, ref this.m_loadedTexture);
			}
			if (this.m_loadedTexture != null)
			{
				this.m_portrait.texture = this.m_loadedTexture;
				this.m_portrait.enabled = true;
				this.m_nombre.text = this.m_nombreDeProtrait;
				this.m_loading.enabled = false;
				return;
			}
			this.m_portrait.enabled = false;
			this.m_nombre.text = string.Empty;
			this.m_portrait.texture = null;
			this.m_toggle.isOn = false;
			this.m_toggle.interactable = false;
		}

		// Token: 0x06000858 RID: 2136
		protected abstract void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture);

		// Token: 0x06000859 RID: 2137 RVA: 0x0001CD2C File Offset: 0x0001AF2C
		public void OnPointerClick(PointerEventData eventData)
		{
			if (base.isActiveAndEnabled)
			{
				OnElementoClicked onElementoClicked = this.m_onElementoClicked;
				if (onElementoClicked != null)
				{
					onElementoClicked.Invoke(this);
				}
			}
			if (this.linkToggleAndElementClick && this.m_toggle.isActiveAndEnabled && this.m_toggle.interactable)
			{
				this.m_toggle.isOn = !this.m_toggle.isOn;
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0001CD8E File Offset: 0x0001AF8E
		private void onToggleValueChanged(bool selected)
		{
			OnValueChanged onValueChangedPre = this.m_onValueChangedPre;
			if (onValueChangedPre != null)
			{
				onValueChangedPre.Invoke(this);
			}
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0001CDE4 File Offset: 0x0001AFE4
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400033F RID: 831
		[SerializeField]
		private Toggle m_toggle;

		// Token: 0x04000340 RID: 832
		[SerializeField]
		private RawImage m_portrait;

		// Token: 0x04000341 RID: 833
		[SerializeField]
		private Image m_grayOut;

		// Token: 0x04000342 RID: 834
		[SerializeField]
		private RawImage m_loading;

		// Token: 0x04000343 RID: 835
		[SerializeField]
		private TextMeshProUGUI m_nombre;

		// Token: 0x04000344 RID: 836
		public SimpleTooltip tooltip;

		// Token: 0x04000345 RID: 837
		[SerializeField]
		private string m_IdDeProtrait;

		// Token: 0x04000346 RID: 838
		[SerializeField]
		private string m_nombreDeProtrait;

		// Token: 0x04000347 RID: 839
		private SelectablePortraitCargarThumbnailHandler m_customLoader;

		// Token: 0x04000348 RID: 840
		private Texture2D m_loadedTexture;

		// Token: 0x04000349 RID: 841
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x0400034A RID: 842
		[SerializeField]
		private OnValueChanged m_onValueChangedPre = new OnValueChanged();

		// Token: 0x0400034B RID: 843
		[SerializeField]
		private OnElementoClicked m_onElementoClicked = new OnElementoClicked();

		// Token: 0x0400034C RID: 844
		public bool imageIsDiskAsset;
	}
}

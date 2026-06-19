using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x0200008D RID: 141
	public class DeslizableElementToolTip : DeslizableElementBase, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIElementoConDescripcionSimple
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000119B4 File Offset: 0x0000FBB4
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x000119C1 File Offset: 0x0000FBC1
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

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000119CF File Offset: 0x0000FBCF
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x000119DC File Offset: 0x0000FBDC
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000119EA File Offset: 0x0000FBEA
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x000119F2 File Offset: 0x0000FBF2
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000119FC File Offset: 0x0000FBFC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
			if (this.slider == null)
			{
				throw new ArgumentNullException("slider", "slider null reference.");
			}
			if (this.valueDrawer == null)
			{
				throw new ArgumentNullException("valueDrawer", "valueDrawer null reference.");
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00011A87 File Offset: 0x0000FC87
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00011AB6 File Offset: 0x0000FCB6
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00011AEE File Offset: 0x0000FCEE
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.slider != null)
			{
				this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00011B21 File Offset: 0x0000FD21
		public override object GetValor()
		{
			if (base.modelType == typeof(int))
			{
				return Mathf.RoundToInt(this.slider.value);
			}
			return this.slider.value;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00011B60 File Offset: 0x0000FD60
		public override void SetValor(object valor, bool silenced)
		{
			if (silenced)
			{
				this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
			try
			{
				IMultipleValorElemento<string, float> multipleValorElemento = valor as IMultipleValorElemento<string, float>;
				if (multipleValorElemento != null)
				{
					this.slider.value = multipleValorElemento.item2;
					this.label.text = multipleValorElemento.item1;
					IMultipleValorElemento<string, float, string> multipleValorElemento2 = valor as IMultipleValorElemento<string, float, string>;
					if (multipleValorElemento2 != null)
					{
						((IUIElementoConDescripcionSimple)this).descripcion = multipleValorElemento2.item3;
					}
				}
				else
				{
					float num = Convert.ToSingle(valor);
					this.slider.value = num;
				}
			}
			finally
			{
				if (silenced)
				{
					this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
				}
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00011C18 File Offset: 0x0000FE18
		private void OnSliderValueChanged(float value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00011C3E File Offset: 0x0000FE3E
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00011C46 File Offset: 0x0000FE46
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000166 RID: 358
		public TextMeshProUGUI label;

		// Token: 0x04000167 RID: 359
		public SliderValueText valueDrawer;

		// Token: 0x04000168 RID: 360
		public SimpleTooltip tooltip;

		// Token: 0x04000169 RID: 361
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}

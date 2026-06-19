using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x0200008B RID: 139
	public class DeslizableElement : DeslizableElementBase, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIElementoConDescripcion
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00011486 File Offset: 0x0000F686
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0001148E File Offset: 0x0000F68E
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x00011496 File Offset: 0x0000F696
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000114A0 File Offset: 0x0000F6A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
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

		// Token: 0x0600042D RID: 1069 RVA: 0x0001152B File Offset: 0x0000F72B
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001155A File Offset: 0x0000F75A
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00011592 File Offset: 0x0000F792
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.slider != null)
			{
				this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000115C5 File Offset: 0x0000F7C5
		public override object GetValor()
		{
			if (base.modelType == typeof(int))
			{
				return Mathf.RoundToInt(this.slider.value);
			}
			return this.slider.value;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00011604 File Offset: 0x0000F804
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
						this.descripcion.text = multipleValorElemento2.item3;
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

		// Token: 0x06000432 RID: 1074 RVA: 0x000116C0 File Offset: 0x0000F8C0
		private void OnSliderValueChanged(float value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000116E6 File Offset: 0x0000F8E6
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000116EE File Offset: 0x0000F8EE
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400015C RID: 348
		public TextMeshProUGUI label;

		// Token: 0x0400015D RID: 349
		public TextMeshProUGUI descripcion;

		// Token: 0x0400015E RID: 350
		public SliderValueText valueDrawer;

		// Token: 0x0400015F RID: 351
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}

using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x0200008C RID: 140
	public class DeslizableElementHelpButton : DeslizableElementBase, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConLabel, IUIBoton
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x000116F6 File Offset: 0x0000F8F6
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x000116FE File Offset: 0x0000F8FE
		OnClickedEvent IUIBoton.onClicked
		{
			get
			{
				return this.onClicked;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00011706 File Offset: 0x0000F906
		OnClickedBotonEvent IUIBoton.onClickedElement
		{
			get
			{
				return this.onClickedElement;
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0001170E File Offset: 0x0000F90E
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00011718 File Offset: 0x0000F918
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label == null)
			{
				throw new ArgumentNullException("label", "label null reference.");
			}
			if (this.boton == null)
			{
				throw new ArgumentNullException("boton", "descripcion null reference.");
			}
			if (this.slider == null)
			{
				throw new ArgumentNullException("slider", "slider null reference.");
			}
			if (this.valueDrawer == null)
			{
				throw new ArgumentNullException("valueDrawer", "valueDrawer null reference.");
			}
			this.boton.onClick.AddListener(new UnityAction(this.CallHelpClickEvents));
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000117BF File Offset: 0x0000F9BF
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000117EE File Offset: 0x0000F9EE
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00011828 File Offset: 0x0000FA28
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.slider != null)
			{
				this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
			if (this.boton != null)
			{
				this.boton.onClick.RemoveListener(new UnityAction(this.CallHelpClickEvents));
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00011890 File Offset: 0x0000FA90
		protected void CallHelpClickEvents()
		{
			OnClickedEvent onClickedEvent = this.onClicked;
			if (onClickedEvent != null)
			{
				onClickedEvent.Invoke();
			}
			OnClickedBotonEvent onClickedBotonEvent = this.onClickedElement;
			if (onClickedBotonEvent == null)
			{
				return;
			}
			onClickedBotonEvent.Invoke(this);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000118B4 File Offset: 0x0000FAB4
		public override object GetValor()
		{
			if (base.modelType == typeof(int))
			{
				return Mathf.RoundToInt(this.slider.value);
			}
			return this.slider.value;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x000118F4 File Offset: 0x0000FAF4
		public override void SetValor(object valor, bool silenced)
		{
			if (silenced)
			{
				this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderValueChanged));
			}
			try
			{
				float num = Convert.ToSingle(valor);
				this.slider.value = num;
			}
			finally
			{
				if (silenced)
				{
					this.slider.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderValueChanged));
				}
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00011968 File Offset: 0x0000FB68
		private void OnSliderValueChanged(float value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000119A4 File Offset: 0x0000FBA4
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x000119AC File Offset: 0x0000FBAC
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000160 RID: 352
		public TextMeshProUGUI label;

		// Token: 0x04000161 RID: 353
		public Button boton;

		// Token: 0x04000162 RID: 354
		public SliderValueText valueDrawer;

		// Token: 0x04000163 RID: 355
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x04000164 RID: 356
		public OnClickedEvent onClicked = new OnClickedEvent();

		// Token: 0x04000165 RID: 357
		public OnClickedBotonEvent onClickedElement = new OnClickedBotonEvent();
	}
}

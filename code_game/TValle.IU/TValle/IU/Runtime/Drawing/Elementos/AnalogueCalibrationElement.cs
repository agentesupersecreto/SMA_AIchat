using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000119 RID: 281
	public class AnalogueCalibrationElement : UIElemento, IUIElementoConMultiLabel, IUIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura, IUIElementoConDescripcion
	{
		// Token: 0x1700025B RID: 603
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0001CDEC File Offset: 0x0001AFEC
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0001CDF4 File Offset: 0x0001AFF4
		IReadOnlyList<TextMeshProUGUI> IUIElementoConMultiLabel.labels
		{
			get
			{
				if (this.m_labels == null)
				{
					this.m_labels = new TextMeshProUGUI[] { this.labelPositive, this.labelNegative, this.labelAutoCal };
				}
				return this.m_labels;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x0001CE2B File Offset: 0x0001B02B
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0001CE34 File Offset: 0x0001B034
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.labelPositive == null)
			{
				throw new ArgumentNullException("labelPositive", "labelPositive null reference.");
			}
			if (this.labelNegative == null)
			{
				throw new ArgumentNullException("labelNegative", "labelNegative null reference.");
			}
			if (this.labelAutoCal == null)
			{
				throw new ArgumentNullException("labelAutoCal", "labelAutoCal null reference.");
			}
			if (this.descripcion == null)
			{
				throw new ArgumentNullException("descripcion", "descripcion null reference.");
			}
			if (this.sliderPositive == null)
			{
				throw new ArgumentNullException("sliderPositive", "sliderPositive null reference.");
			}
			if (this.sliderNegative == null)
			{
				throw new ArgumentNullException("sliderNegative", "sliderNegative null reference.");
			}
			if (this.sliderAutoCal == null)
			{
				throw new ArgumentNullException("sliderAutoCal", "sliderAutoCal null reference.");
			}
			if (this.valueDrawerPositive == null)
			{
				throw new ArgumentNullException("valueDrawerPositive", "valueDrawerPositive null reference.");
			}
			if (this.valueDrawerNegative == null)
			{
				throw new ArgumentNullException("valueDrawerNegative", "valueDrawerNegative null reference.");
			}
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0001CF58 File Offset: 0x0001B158
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.sliderPositive != null)
			{
				this.sliderPositive.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderPositiveValueChanged));
			}
			if (this.sliderNegative != null)
			{
				this.sliderNegative.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderNegativeValueChanged));
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0001CFC0 File Offset: 0x0001B1C0
		public override void Bind(string modeloName, Type modeloType, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.sliderPositive.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderPositiveValueChanged));
				this.sliderNegative.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderNegativeValueChanged));
			}
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0001D018 File Offset: 0x0001B218
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.sliderPositive.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderPositiveValueChanged));
				this.sliderNegative.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderNegativeValueChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0001D077 File Offset: 0x0001B277
		public object GetValor()
		{
			return new Vector2(this.sliderPositive.value, this.sliderNegative.value);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0001D09C File Offset: 0x0001B29C
		public void SetValor(object valor, bool silenced)
		{
			if (silenced)
			{
				this.sliderPositive.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderPositiveValueChanged));
				this.sliderNegative.onValueChanged.RemoveListener(new UnityAction<float>(this.OnSliderNegativeValueChanged));
			}
			try
			{
				Vector2 vector = (Vector2)valor;
				this.sliderPositive.value = vector.x;
				this.sliderNegative.value = vector.y;
			}
			finally
			{
				if (silenced)
				{
					this.sliderPositive.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderPositiveValueChanged));
					this.sliderNegative.onValueChanged.AddListener(new UnityAction<float>(this.OnSliderNegativeValueChanged));
				}
			}
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0001D15C File Offset: 0x0001B35C
		private void OnSliderPositiveValueChanged(float value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0001D16F File Offset: 0x0001B36F
		private void OnSliderNegativeValueChanged(float value)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0001D195 File Offset: 0x0001B395
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0001D19D File Offset: 0x0001B39D
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400034D RID: 845
		public TextMeshProUGUI labelPositive;

		// Token: 0x0400034E RID: 846
		public TextMeshProUGUI labelNegative;

		// Token: 0x0400034F RID: 847
		public TextMeshProUGUI labelAutoCal;

		// Token: 0x04000350 RID: 848
		public Slider sliderPositive;

		// Token: 0x04000351 RID: 849
		public Slider sliderNegative;

		// Token: 0x04000352 RID: 850
		public Slider sliderAutoCal;

		// Token: 0x04000353 RID: 851
		public SliderValueText valueDrawerPositive;

		// Token: 0x04000354 RID: 852
		public SliderValueText valueDrawerNegative;

		// Token: 0x04000355 RID: 853
		private TextMeshProUGUI[] m_labels;

		// Token: 0x04000356 RID: 854
		public TextMeshProUGUI descripcion;

		// Token: 0x04000357 RID: 855
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}

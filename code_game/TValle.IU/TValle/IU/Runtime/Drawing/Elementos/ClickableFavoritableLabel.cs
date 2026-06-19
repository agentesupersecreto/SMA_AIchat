using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011A RID: 282
	public class ClickableFavoritableLabel : ClickableLabel, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x1700025E RID: 606
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0001D1A5 File Offset: 0x0001B3A5
		public Toggle toggle
		{
			get
			{
				return this.m_toggle;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0001D1AD File Offset: 0x0001B3AD
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0001D1B5 File Offset: 0x0001B3B5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_toggle == null)
			{
				throw new ArgumentNullException("m_toggle", "m_toggle null reference.");
			}
			this.m_toggle.isOn = false;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			base.Bind(modeloName, modeloType, isListItem);
			this.m_defaultColor = this.m_boton.colors.normalColor;
			this.m_toggle.isOn = false;
			if (base.isBinded)
			{
				this.m_toggle.onValueChanged.AddListener(new UnityAction<bool>(this.onSelectionChanged));
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0001D25E File Offset: 0x0001B45E
		private void onSelectionChanged(bool selected)
		{
			OnValueChanged onValueChanged = this.m_onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.Invoke(this);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0001D274 File Offset: 0x0001B474
		public void SetValor(object valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (valor == null)
			{
				return;
			}
			IMultipleValorElemento<string, string, bool, Color?, string> multipleValorElemento = (IMultipleValorElemento<string, string, bool, Color?, string>)valor;
			this.label.text = multipleValorElemento.item2;
			this.SetValor(multipleValorElemento.item3, silenced);
			if (multipleValorElemento.item4 != null)
			{
				ColorBlock colors = this.m_boton.colors;
				colors.normalColor = multipleValorElemento.item4.Value;
				this.m_boton.colors = colors;
			}
			else
			{
				ColorBlock colors2 = this.m_boton.colors;
				colors2.normalColor = this.m_defaultColor;
				this.m_boton.colors = colors2;
			}
			if (!string.IsNullOrWhiteSpace(multipleValorElemento.item5))
			{
				if (this.m_resaltoText != null)
				{
					this.m_resaltoText.gameObject.SetActive(true);
					this.m_resaltoText.text = multipleValorElemento.item5;
				}
				return;
			}
			TextMeshProUGUI resaltoText = this.m_resaltoText;
			if (resaltoText == null)
			{
				return;
			}
			resaltoText.gameObject.SetActive(false);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0001D370 File Offset: 0x0001B570
		public void SetValor(bool valor, bool silenced)
		{
			if (!base.isBinded)
			{
				throw new InvalidOperationException();
			}
			if (silenced)
			{
				this.m_toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.onSelectionChanged));
			}
			try
			{
				this.m_toggle.isOn = valor;
			}
			finally
			{
				if (silenced)
				{
					this.m_toggle.onValueChanged.AddListener(new UnityAction<bool>(this.onSelectionChanged));
				}
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0001D3EC File Offset: 0x0001B5EC
		public object GetValor()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0001D406 File Offset: 0x0001B606
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0001D40E File Offset: 0x0001B60E
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000358 RID: 856
		[SerializeField]
		private Toggle m_toggle;

		// Token: 0x04000359 RID: 857
		[SerializeField]
		private TextMeshProUGUI m_resaltoText;

		// Token: 0x0400035A RID: 858
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x0400035B RID: 859
		private Color m_defaultColor;
	}
}

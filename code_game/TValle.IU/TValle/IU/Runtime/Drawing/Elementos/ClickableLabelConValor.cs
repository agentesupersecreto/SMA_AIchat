using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x0200011C RID: 284
	public class ClickableLabelConValor : ClickableLabel, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0001D43E File Offset: 0x0001B63E
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0001D448 File Offset: 0x0001B648
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			base.Bind(modeloName, modeloType, isListItem);
			this.m_defaultColor = this.m_boton.colors.normalColor;
			if (base.isBinded)
			{
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0001D498 File Offset: 0x0001B698
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
			if (!(valor is IMultipleValorElemento<string, string, Color?>))
			{
				if (valor is IMultipleValorElemento<string, object>)
				{
					IMultipleValorElemento<string, object> multipleValorElemento = (IMultipleValorElemento<string, object>)valor;
					this.label.text = multipleValorElemento.item1;
					this.m_valor = multipleValorElemento.item2;
				}
				return;
			}
			IMultipleValorElemento<string, string, Color?> multipleValorElemento2 = (IMultipleValorElemento<string, string, Color?>)valor;
			this.label.text = multipleValorElemento2.item2;
			this.m_valor = multipleValorElemento2.item1;
			if (multipleValorElemento2.item3 != null)
			{
				ColorBlock colors = this.m_boton.colors;
				colors.normalColor = multipleValorElemento2.item3.Value;
				this.m_boton.colors = colors;
				return;
			}
			ColorBlock colors2 = this.m_boton.colors;
			colors2.normalColor = this.m_defaultColor;
			this.m_boton.colors = colors2;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0001D579 File Offset: 0x0001B779
		public object GetValor()
		{
			return this.m_valor;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0001D594 File Offset: 0x0001B794
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0001D59C File Offset: 0x0001B79C
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400035D RID: 861
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x0400035E RID: 862
		[SerializeField]
		private object m_valor;

		// Token: 0x0400035F RID: 863
		private Color m_defaultColor;
	}
}

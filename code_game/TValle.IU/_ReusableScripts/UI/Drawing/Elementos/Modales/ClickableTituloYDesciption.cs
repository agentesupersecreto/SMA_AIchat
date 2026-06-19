using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos.Modales
{
	// Token: 0x02000097 RID: 151
	public class ClickableTituloYDesciption : BotonElementConfirmable, IUIElementoConLabel, IUIElemento, IUIElementoConDescripcion, IUIElementoConValor, IUIElementoConValorMutable, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x00014469 File Offset: 0x00012669
		TextMeshProUGUI IUIElementoConDescripcion.descripcion
		{
			get
			{
				return this.descripcion;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x00014471 File Offset: 0x00012671
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00014479 File Offset: 0x00012679
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label2 != null)
			{
				this.label2.text = string.Empty;
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000144A0 File Offset: 0x000126A0
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

		// Token: 0x060004E6 RID: 1254 RVA: 0x000144F0 File Offset: 0x000126F0
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
			IMultipleValorElemento<string, string, string, Color?, string> multipleValorElemento = (IMultipleValorElemento<string, string, string, Color?, string>)valor;
			this.labelV2.text = multipleValorElemento.item2;
			this.descripcion.text = multipleValorElemento.item3;
			if (this.label2 != null)
			{
				this.label2.text = multipleValorElemento.item5;
			}
			if (multipleValorElemento.item4 != null)
			{
				ColorBlock colors = this.m_boton.colors;
				colors.normalColor = multipleValorElemento.item4.Value;
				this.m_boton.colors = colors;
				return;
			}
			ColorBlock colors2 = this.m_boton.colors;
			colors2.normalColor = this.m_defaultColor;
			this.m_boton.colors = colors2;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000145BA File Offset: 0x000127BA
		public object GetValor()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000145D4 File Offset: 0x000127D4
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000145DC File Offset: 0x000127DC
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001E5 RID: 485
		public TextMeshProUGUI label2;

		// Token: 0x040001E6 RID: 486
		public TextMeshProUGUI descripcion;

		// Token: 0x040001E7 RID: 487
		private Color m_defaultColor;

		// Token: 0x040001E8 RID: 488
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}

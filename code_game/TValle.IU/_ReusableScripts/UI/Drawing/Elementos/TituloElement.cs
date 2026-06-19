using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000095 RID: 149
	public class TituloElement : UIElemento, IUIElementoConDescripcionSimple, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConLabel
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00014024 File Offset: 0x00012224
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x00014031 File Offset: 0x00012231
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

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0001403F File Offset: 0x0001223F
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x0001404C File Offset: 0x0001224C
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

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0001405A File Offset: 0x0001225A
		public TextMeshProUGUI label
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00014062 File Offset: 0x00012262
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.text == null)
			{
				throw new ArgumentNullException("text", "text null reference.");
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00014088 File Offset: 0x00012288
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			base.Bind(modeloName, modeloType, isListItem);
			this.m_defaultColor = this.text.color;
			if (base.isBinded)
			{
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000140C4 File Offset: 0x000122C4
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
			if (valor is IMultipleValorElemento<string, string, string, Color?>)
			{
				IMultipleValorElemento<string, string, string, Color?> multipleValorElemento = (IMultipleValorElemento<string, string, string, Color?>)valor;
				this.text.text = multipleValorElemento.item2;
				this.tooltip.infoLeft = multipleValorElemento.item3;
				if (multipleValorElemento.item4 != null)
				{
					this.text.color = multipleValorElemento.item4.Value;
					return;
				}
				this.text.color = this.m_defaultColor;
				return;
			}
			else
			{
				if (!(valor is IMultipleValorElemento<string, string, Color?>))
				{
					if (valor is IMultipleValorElemento<string, string>)
					{
						IMultipleValorElemento<string, string> multipleValorElemento2 = (IMultipleValorElemento<string, string>)valor;
						this.text.text = multipleValorElemento2.item1;
						this.tooltip.infoLeft = multipleValorElemento2.item2;
					}
					return;
				}
				IMultipleValorElemento<string, string, Color?> multipleValorElemento3 = (IMultipleValorElemento<string, string, Color?>)valor;
				this.text.text = multipleValorElemento3.item1;
				this.tooltip.infoLeft = multipleValorElemento3.item2;
				if (multipleValorElemento3.item3 != null)
				{
					this.text.color = multipleValorElemento3.item3.Value;
					return;
				}
				this.text.color = this.m_defaultColor;
				return;
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000141F6 File Offset: 0x000123F6
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000141FE File Offset: 0x000123FE
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001DC RID: 476
		public SimpleTooltip tooltip;

		// Token: 0x040001DD RID: 477
		public TextMeshProUGUI text;

		// Token: 0x040001DE RID: 478
		private Color m_defaultColor;
	}
}

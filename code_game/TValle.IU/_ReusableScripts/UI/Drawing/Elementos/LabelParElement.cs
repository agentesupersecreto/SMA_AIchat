using System;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000091 RID: 145
	public class LabelParElement : UIElemento, IUIElementoConDescripcionSimple, IUIElemento, IUIElementoConMultiLabel, IUIElementoConValorSoloEscritura, IUIElementoConLabel
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0001309A File Offset: 0x0001129A
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x000130A7 File Offset: 0x000112A7
		public string descripcion
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

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x000130B5 File Offset: 0x000112B5
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x000130C2 File Offset: 0x000112C2
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

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x000130D0 File Offset: 0x000112D0
		public IReadOnlyList<TextMeshProUGUI> labels
		{
			get
			{
				if (this.m_labels == null)
				{
					this.m_labels = new TextMeshProUGUI[] { this.label1, this.label2, this.separador };
				}
				return this.m_labels;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x00013107 File Offset: 0x00011307
		public OnValueChanged onValueChanged
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0001310A File Offset: 0x0001130A
		TextMeshProUGUI IUIElementoConLabel.label
		{
			get
			{
				return this.label1;
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00013114 File Offset: 0x00011314
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.label2 == null)
			{
				throw new ArgumentNullException("label2", "label2 null reference.");
			}
			if (this.separador == null)
			{
				throw new ArgumentNullException("separador", "separador null reference.");
			}
			if (this.label1 == null)
			{
				throw new ArgumentNullException("label1", "label1 null reference.");
			}
			if (this.tooltip == null)
			{
				throw new ArgumentNullException("tooltip", "tooltip null reference.");
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001319F File Offset: 0x0001139F
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			base.Bind(modeloName, modeloType, isListItem);
			if (base.isBinded)
			{
				this.SetValor(initialValue, true);
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000131CC File Offset: 0x000113CC
		public void SetValor(object valor, bool silenced)
		{
			if (valor == null)
			{
				return;
			}
			if (valor is IMultipleValorElemento<string, string, string, string>)
			{
				IMultipleValorElemento<string, string, string, string> multipleValorElemento = (IMultipleValorElemento<string, string, string, string>)valor;
				this.label1.text = multipleValorElemento.item1;
				this.label2.text = multipleValorElemento.item2;
				this.descripcion = multipleValorElemento.item3;
				this.separador.text = multipleValorElemento.item4;
				return;
			}
			this.label2.text = valor.ToString();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00013245 File Offset: 0x00011445
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0001324D File Offset: 0x0001144D
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000182 RID: 386
		public SimpleTooltip tooltip;

		// Token: 0x04000183 RID: 387
		public TextMeshProUGUI label1;

		// Token: 0x04000184 RID: 388
		public TextMeshProUGUI separador;

		// Token: 0x04000185 RID: 389
		public TextMeshProUGUI label2;

		// Token: 0x04000186 RID: 390
		private TextMeshProUGUI[] m_labels;
	}
}

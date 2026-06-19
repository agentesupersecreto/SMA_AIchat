using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000089 RID: 137
	public class BotonElementConValor : BotonElement, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x00011388 File Offset: 0x0000F588
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00011390 File Offset: 0x0000F590
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.m_dataModel = initialValue;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000113A3 File Offset: 0x0000F5A3
		public object GetValor()
		{
			return this.m_dataModel;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000113AC File Offset: 0x0000F5AC
		public void SetValor(object valor, bool silenced)
		{
			object dataModel = this.m_dataModel;
			this.m_dataModel = valor;
			if (!silenced && dataModel != valor)
			{
				OnValueChanged onValueChanged = this.m_onValueChanged;
				if (onValueChanged == null)
				{
					return;
				}
				onValueChanged.Invoke(this);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000113F2 File Offset: 0x0000F5F2
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000113FA File Offset: 0x0000F5FA
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000159 RID: 345
		private object m_dataModel;

		// Token: 0x0400015A RID: 346
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();
	}
}

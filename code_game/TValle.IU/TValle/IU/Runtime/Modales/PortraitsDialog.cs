using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D6 RID: 214
	public class PortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00017228 File Offset: 0x00015428
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x00017230 File Offset: 0x00015430
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00017238 File Offset: 0x00015438
		public PanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x00017240 File Offset: 0x00015440
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x00017247 File Offset: 0x00015447
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0001724A File Offset: 0x0001544A
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x00017252 File Offset: 0x00015452
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00017258 File Offset: 0x00015458
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_panel == null)
			{
				throw new ArgumentNullException("m_panel", "m_panel null reference.");
			}
			if (this.m_itemsTransform == null)
			{
				throw new ArgumentNullException("m_itemsTransform", "m_itemsTransform null reference.");
			}
			if (this.m_genericUserPanel == null)
			{
				throw new ArgumentNullException("m_genericUserPanel", "m_genericUserPanel null reference.");
			}
			if (this.m_PanelDePortraits == null)
			{
				throw new ArgumentNullException("m_PanelDePortraits", "m_PanelDePortraits null reference.");
			}
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000172E3 File Offset: 0x000154E3
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x000172F8 File Offset: 0x000154F8
		public void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
			if (base.isBinded)
			{
				throw new NotSupportedException();
			}
			foreach (KeyValuePair<string, IUIElemento> keyValuePair in pares)
			{
				if (this.elementoPorModelo.ContainsKey(keyValuePair.Key))
				{
					Debug.LogError("Panel: " + base.name + ", ya contiene elemento: " + keyValuePair.Key, this);
				}
				else
				{
					this.m_elementos.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00017398 File Offset: 0x00015598
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x000173EC File Offset: 0x000155EC
		public Transform GetParentPara(int index)
		{
			if (index != 0)
			{
				if (index != 1)
				{
				}
				throw new ArgumentOutOfRangeException(index.ToString());
			}
			return this.m_itemsTransform;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001740A File Offset: 0x0001560A
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00017424 File Offset: 0x00015624
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001742C File Offset: 0x0001562C
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400025C RID: 604
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x0400025D RID: 605
		[SerializeField]
		private Image m_panel;

		// Token: 0x0400025E RID: 606
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x0400025F RID: 607
		[SerializeField]
		private PanelDePortraits m_PanelDePortraits;

		// Token: 0x04000260 RID: 608
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

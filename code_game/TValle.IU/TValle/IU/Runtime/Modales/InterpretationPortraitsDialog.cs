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
	// Token: 0x020000D3 RID: 211
	public class InterpretationPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00016AF4 File Offset: 0x00014CF4
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x00016AFC File Offset: 0x00014CFC
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00016B04 File Offset: 0x00014D04
		public PanelDeInterpretationPortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x00016B0C File Offset: 0x00014D0C
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00016B13 File Offset: 0x00014D13
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x00016B16 File Offset: 0x00014D16
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x00016B1E File Offset: 0x00014D1E
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00016B24 File Offset: 0x00014D24
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

		// Token: 0x06000615 RID: 1557 RVA: 0x00016BAF File Offset: 0x00014DAF
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00016BC4 File Offset: 0x00014DC4
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

		// Token: 0x06000617 RID: 1559 RVA: 0x00016C64 File Offset: 0x00014E64
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00016CB8 File Offset: 0x00014EB8
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

		// Token: 0x06000619 RID: 1561 RVA: 0x00016CD6 File Offset: 0x00014ED6
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00016CF0 File Offset: 0x00014EF0
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00016CF8 File Offset: 0x00014EF8
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400024D RID: 589
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x0400024E RID: 590
		[SerializeField]
		private Image m_panel;

		// Token: 0x0400024F RID: 591
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000250 RID: 592
		[SerializeField]
		private PanelDeInterpretationPortraits m_PanelDePortraits;

		// Token: 0x04000251 RID: 593
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

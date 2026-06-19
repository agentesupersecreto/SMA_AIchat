using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D4 RID: 212
	public class MakeoverPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x00016D00 File Offset: 0x00014F00
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x00016D08 File Offset: 0x00014F08
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x00016D10 File Offset: 0x00014F10
		public MakeoverPanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x00016D18 File Offset: 0x00014F18
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x00016D1F File Offset: 0x00014F1F
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x00016D22 File Offset: 0x00014F22
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x00016D2A File Offset: 0x00014F2A
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00016D30 File Offset: 0x00014F30
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
			this.m_PanelDePortraits.portraitsModel.onBindig += this.PortraitsModel_onBindig;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00016DD8 File Offset: 0x00014FD8
		private void PortraitsModel_onBindig(MakeoverPortraitsModel obj)
		{
			ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>> component = base.GetComponent<ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>>>();
			if (component != null)
			{
				obj.disponibles = component.ObtenerDisponibles();
				return;
			}
			List<string> list;
			obj.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.makeover })
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00016E42 File Offset: 0x00015042
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00016E58 File Offset: 0x00015058
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

		// Token: 0x06000628 RID: 1576 RVA: 0x00016EF8 File Offset: 0x000150F8
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00016F4C File Offset: 0x0001514C
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

		// Token: 0x0600062A RID: 1578 RVA: 0x00016F6A File Offset: 0x0001516A
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00016F84 File Offset: 0x00015184
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00016F8C File Offset: 0x0001518C
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000252 RID: 594
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x04000253 RID: 595
		[SerializeField]
		private Image m_panel;

		// Token: 0x04000254 RID: 596
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000255 RID: 597
		[SerializeField]
		private MakeoverPanelDePortraits m_PanelDePortraits;

		// Token: 0x04000256 RID: 598
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

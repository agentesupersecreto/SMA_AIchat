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
	// Token: 0x020000D7 RID: 215
	public class PosePortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00017434 File Offset: 0x00015634
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x0001743C File Offset: 0x0001563C
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00017444 File Offset: 0x00015644
		public PosePanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x0001744C File Offset: 0x0001564C
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00017453 File Offset: 0x00015653
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00017456 File Offset: 0x00015656
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0001745E File Offset: 0x0001565E
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00017464 File Offset: 0x00015664
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

		// Token: 0x06000657 RID: 1623 RVA: 0x0001750C File Offset: 0x0001570C
		private void PortraitsModel_onBindig(PosePortraitsModel obj)
		{
			ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>> component = base.GetComponent<ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>>>();
			if (component != null)
			{
				obj.disponibles = component.ObtenerDisponibles();
				return;
			}
			List<string> list;
			obj.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.poses })
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00017576 File Offset: 0x00015776
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001758C File Offset: 0x0001578C
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

		// Token: 0x0600065A RID: 1626 RVA: 0x0001762C File Offset: 0x0001582C
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x00017680 File Offset: 0x00015880
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

		// Token: 0x0600065C RID: 1628 RVA: 0x0001769E File Offset: 0x0001589E
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000176B8 File Offset: 0x000158B8
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x000176C0 File Offset: 0x000158C0
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000261 RID: 609
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x04000262 RID: 610
		[SerializeField]
		private Image m_panel;

		// Token: 0x04000263 RID: 611
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000264 RID: 612
		[SerializeField]
		private PosePanelDePortraits m_PanelDePortraits;

		// Token: 0x04000265 RID: 613
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

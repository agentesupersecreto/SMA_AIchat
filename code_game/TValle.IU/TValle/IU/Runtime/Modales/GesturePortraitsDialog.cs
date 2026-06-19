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
	// Token: 0x020000D2 RID: 210
	public class GesturePortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x00016860 File Offset: 0x00014A60
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x00016868 File Offset: 0x00014A68
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00016870 File Offset: 0x00014A70
		public GesturePanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00016878 File Offset: 0x00014A78
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0001687F File Offset: 0x00014A7F
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x00016882 File Offset: 0x00014A82
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0001688A File Offset: 0x00014A8A
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00016890 File Offset: 0x00014A90
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

		// Token: 0x06000604 RID: 1540 RVA: 0x00016938 File Offset: 0x00014B38
		private void PortraitsModel_onBindig(GesturePortraitsModel obj)
		{
			ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>> component = base.GetComponent<ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>>>();
			if (component != null)
			{
				obj.disponibles = component.ObtenerDisponibles();
				return;
			}
			List<string> list;
			obj.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.gestos })
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000169A2 File Offset: 0x00014BA2
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x000169B8 File Offset: 0x00014BB8
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

		// Token: 0x06000607 RID: 1543 RVA: 0x00016A58 File Offset: 0x00014C58
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00016AAC File Offset: 0x00014CAC
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

		// Token: 0x06000609 RID: 1545 RVA: 0x00016ACA File Offset: 0x00014CCA
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00016AE4 File Offset: 0x00014CE4
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00016AEC File Offset: 0x00014CEC
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000248 RID: 584
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x04000249 RID: 585
		[SerializeField]
		private Image m_panel;

		// Token: 0x0400024A RID: 586
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x0400024B RID: 587
		[SerializeField]
		private GesturePanelDePortraits m_PanelDePortraits;

		// Token: 0x0400024C RID: 588
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

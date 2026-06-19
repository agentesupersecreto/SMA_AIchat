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
	// Token: 0x020000D5 RID: 213
	public class OutfitPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00016F94 File Offset: 0x00015194
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x00016F9C File Offset: 0x0001519C
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00016FA4 File Offset: 0x000151A4
		public OutfitPanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00016FAC File Offset: 0x000151AC
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00016FB3 File Offset: 0x000151B3
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x00016FBB File Offset: 0x000151BB
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x00016FBE File Offset: 0x000151BE
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00016FC4 File Offset: 0x000151C4
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

		// Token: 0x06000636 RID: 1590 RVA: 0x0001706C File Offset: 0x0001526C
		private void PortraitsModel_onBindig(OutfitPortraitsModel obj)
		{
			ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>> component = base.GetComponent<ICustomDePortraitsDisponibles<MultipleValorElemento<string, bool>>>();
			if (component != null)
			{
				obj.disponibles = component.ObtenerDisponibles();
				return;
			}
			List<string> list;
			obj.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.ropa })
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000170D6 File Offset: 0x000152D6
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x000170EC File Offset: 0x000152EC
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

		// Token: 0x06000639 RID: 1593 RVA: 0x0001718C File Offset: 0x0001538C
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x000171E0 File Offset: 0x000153E0
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

		// Token: 0x0600063B RID: 1595 RVA: 0x000171FE File Offset: 0x000153FE
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00017218 File Offset: 0x00015418
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00017220 File Offset: 0x00015420
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000257 RID: 599
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x04000258 RID: 600
		[SerializeField]
		private Image m_panel;

		// Token: 0x04000259 RID: 601
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x0400025A RID: 602
		[SerializeField]
		private OutfitPanelDePortraits m_PanelDePortraits;

		// Token: 0x0400025B RID: 603
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

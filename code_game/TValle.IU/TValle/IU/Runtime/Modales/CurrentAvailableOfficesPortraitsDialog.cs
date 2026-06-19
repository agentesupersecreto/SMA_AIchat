using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Officinas.Models;
using Assets.TValle.IU.Runtime.Drawing.Officinas.Panels;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D0 RID: 208
	public class CurrentAvailableOfficesPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00016388 File Offset: 0x00014588
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00016390 File Offset: 0x00014590
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x00016398 File Offset: 0x00014598
		public CurrentAvailableOfficesPortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x000163A0 File Offset: 0x000145A0
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x000163A7 File Offset: 0x000145A7
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x000163AF File Offset: 0x000145AF
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x000163B2 File Offset: 0x000145B2
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000163B8 File Offset: 0x000145B8
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

		// Token: 0x060005E2 RID: 1506 RVA: 0x00016460 File Offset: 0x00014660
		private void PortraitsModel_onBindig(CurrentAvailableOfficesModelo obj)
		{
			ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> component = base.GetComponent<ICustomDePortraitsDisponibles<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>>>();
			if (component != null)
			{
				obj.disponibles = component.ObtenerDisponibles();
				obj.infoGetter = new Func<int, string>(component.GetToolTipOf);
				return;
			}
			Debug.LogError("debe haber un custom loader para portraits en memoria");
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000164A1 File Offset: 0x000146A1
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x000164B8 File Offset: 0x000146B8
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

		// Token: 0x060005E5 RID: 1509 RVA: 0x00016558 File Offset: 0x00014758
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000165AC File Offset: 0x000147AC
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

		// Token: 0x060005E7 RID: 1511 RVA: 0x000165CA File Offset: 0x000147CA
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000165E4 File Offset: 0x000147E4
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x000165EC File Offset: 0x000147EC
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400023E RID: 574
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x0400023F RID: 575
		[SerializeField]
		private Image m_panel;

		// Token: 0x04000240 RID: 576
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000241 RID: 577
		[SerializeField]
		private CurrentAvailableOfficesPortraits m_PanelDePortraits;

		// Token: 0x04000242 RID: 578
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

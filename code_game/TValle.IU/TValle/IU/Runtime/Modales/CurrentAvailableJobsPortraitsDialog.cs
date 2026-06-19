using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Jobs.Models;
using Assets.TValle.IU.Runtime.Drawing.Jobs.Paneles;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000CF RID: 207
	public class CurrentAvailableJobsPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0001611C File Offset: 0x0001431C
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00016124 File Offset: 0x00014324
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0001612C File Offset: 0x0001432C
		public CurrentAvailableJobsPortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x00016134 File Offset: 0x00014334
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0001613B File Offset: 0x0001433B
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x00016143 File Offset: 0x00014343
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x00016146 File Offset: 0x00014346
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001614C File Offset: 0x0001434C
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

		// Token: 0x060005D1 RID: 1489 RVA: 0x000161F4 File Offset: 0x000143F4
		private void PortraitsModel_onBindig(CurrentAvailableJobsModelo obj)
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

		// Token: 0x060005D2 RID: 1490 RVA: 0x00016235 File Offset: 0x00014435
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001624C File Offset: 0x0001444C
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

		// Token: 0x060005D4 RID: 1492 RVA: 0x000162EC File Offset: 0x000144EC
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00016340 File Offset: 0x00014540
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

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001635E File Offset: 0x0001455E
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00016378 File Offset: 0x00014578
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00016380 File Offset: 0x00014580
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000239 RID: 569
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x0400023A RID: 570
		[SerializeField]
		private Image m_panel;

		// Token: 0x0400023B RID: 571
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x0400023C RID: 572
		[SerializeField]
		private CurrentAvailableJobsPortraits m_PanelDePortraits;

		// Token: 0x0400023D RID: 573
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

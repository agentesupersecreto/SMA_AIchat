using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Paneles;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Modales
{
	// Token: 0x020000D1 RID: 209
	public class CurrentWorkingModelsPortraitsDialog : UIElemento, IUIPanel, IUIElemento
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x000165F4 File Offset: 0x000147F4
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.m_itemsTransform;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x000165FC File Offset: 0x000147FC
		public GenericUserPanel genericUserPanel
		{
			get
			{
				return this.m_genericUserPanel;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x00016604 File Offset: 0x00014804
		public CurrentModelsPanelDePortraits panelDePortraits
		{
			get
			{
				return this.m_PanelDePortraits;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0001660C File Offset: 0x0001480C
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x00016613 File Offset: 0x00014813
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0001661B File Offset: 0x0001481B
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0001661E File Offset: 0x0001481E
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00016624 File Offset: 0x00014824
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

		// Token: 0x060005F3 RID: 1523 RVA: 0x000166CC File Offset: 0x000148CC
		private void PortraitsModel_onBindig(CurrentWorkingModelsModel obj)
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

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001670D File Offset: 0x0001490D
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PanelDePortraits.CrearYDibujar(null);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00016724 File Offset: 0x00014924
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

		// Token: 0x060005F6 RID: 1526 RVA: 0x000167C4 File Offset: 0x000149C4
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00016818 File Offset: 0x00014A18
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

		// Token: 0x060005F8 RID: 1528 RVA: 0x00016836 File Offset: 0x00014A36
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00016850 File Offset: 0x00014A50
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00016858 File Offset: 0x00014A58
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000243 RID: 579
		[SerializeField]
		private Transform m_itemsTransform;

		// Token: 0x04000244 RID: 580
		[SerializeField]
		private Image m_panel;

		// Token: 0x04000245 RID: 581
		[SerializeField]
		private GenericUserPanel m_genericUserPanel;

		// Token: 0x04000246 RID: 582
		[SerializeField]
		private CurrentModelsPanelDePortraits m_PanelDePortraits;

		// Token: 0x04000247 RID: 583
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();
	}
}

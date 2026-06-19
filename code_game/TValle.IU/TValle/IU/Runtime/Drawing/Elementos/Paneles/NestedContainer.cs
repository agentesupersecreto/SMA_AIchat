using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000136 RID: 310
	[RequireComponent(typeof(Image))]
	public class NestedContainer : UIElemento, IUIPanel, IUIElemento, IUIPanelConBotones, IUIPanelConTitulo, IUIPanelConControles
	{
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0001EBB6 File Offset: 0x0001CDB6
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x0001EBBE File Offset: 0x0001CDBE
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.panelForItems;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0001EBC6 File Offset: 0x0001CDC6
		public Transform padreParaBotones
		{
			get
			{
				return this.panelParaBotones;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0001EBCE File Offset: 0x0001CDCE
		public Transform padreParaControles
		{
			get
			{
				return this.panelParaControles;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0001EBD6 File Offset: 0x0001CDD6
		Scrollbar IUIPanel.scrollbar
		{
			get
			{
				return this.scrollbar;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x0001EBDE File Offset: 0x0001CDDE
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0001EBE6 File Offset: 0x0001CDE6
		public virtual Transform padreParaTitulos
		{
			get
			{
				return this.padreParaItemsPrimario;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0001EBEE File Offset: 0x0001CDEE
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		public void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
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

		// Token: 0x0600092E RID: 2350 RVA: 0x0001EC88 File Offset: 0x0001CE88
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		public void AddBotones(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
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

		// Token: 0x06000930 RID: 2352 RVA: 0x0001ED70 File Offset: 0x0001CF70
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<Image>();
			if (this.panelForItems == null)
			{
				throw new ArgumentNullException("panelForItems", "panelForItems null reference.");
			}
			if (this.panelParaBotones == null)
			{
				throw new ArgumentNullException("panelParaBotones", "panelParaBotones null reference.");
			}
			if (this.panelParaControles == null)
			{
				throw new ArgumentNullException("panelParaControles", "panelParaControles null reference.");
			}
			if (this.scrollRect == null)
			{
				throw new ArgumentNullException("scrollRect", "scrollRect null reference.");
			}
			if (this.scrollbar == null)
			{
				throw new ArgumentNullException("scrollbar", "scrollbar null reference.");
			}
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x0001EE25 File Offset: 0x0001D025
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0001EE2D File Offset: 0x0001D02D
		public Transform GetParentPara(int index)
		{
			return this.padreParaItemsPrimario;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0001EE35 File Offset: 0x0001D035
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			if (this.elementoPorModelo.ContainsKey(model))
			{
				Debug.LogError("Panel: " + base.name + ", ya contiene elemento: " + model, this);
				return;
			}
			this.m_elementos.Add(model, element);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0001EE82 File Offset: 0x0001D082
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0001EE8A File Offset: 0x0001D08A
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003A3 RID: 931
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040003A4 RID: 932
		public Transform panelParaBotones;

		// Token: 0x040003A5 RID: 933
		public Transform panelForItems;

		// Token: 0x040003A6 RID: 934
		public Transform panelParaControles;

		// Token: 0x040003A7 RID: 935
		public ScrollRect scrollRect;

		// Token: 0x040003A8 RID: 936
		public Scrollbar scrollbar;

		// Token: 0x040003A9 RID: 937
		private Image m_panel;
	}
}

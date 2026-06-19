using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000139 RID: 313
	public class Panel1by3 : UIElemento, IUIPanel, IUIElemento, IUIPanelConControles, IUIMultiPanel, IUIPanelConTitulo, IUIPanelConSuperiorPanel
	{
		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0001F296 File Offset: 0x0001D496
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x0001F29E File Offset: 0x0001D49E
		public Transform padreParaTitulos
		{
			get
			{
				return this.panelParaTitulos;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0001F2A6 File Offset: 0x0001D4A6
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.panelForItemsPrimario;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0001F2AE File Offset: 0x0001D4AE
		public Transform padreParaControles
		{
			get
			{
				return this.panelParaControles;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0001F2B6 File Offset: 0x0001D4B6
		public Transform padreParaItemsSegundario
		{
			get
			{
				return this.panelForItemsSegundario;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0001F2BE File Offset: 0x0001D4BE
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0001F2C1 File Offset: 0x0001D4C1
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x0001F2C9 File Offset: 0x0001D4C9
		public int getParentCount
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001F2CC File Offset: 0x0001D4CC
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

		// Token: 0x06000959 RID: 2393 RVA: 0x0001F36C File Offset: 0x0001D56C
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001F3C0 File Offset: 0x0001D5C0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<Image>();
			if (this.panelParaTitulos == null)
			{
				throw new ArgumentNullException("panelParaTitulos", "panelParaTitulos null reference.");
			}
			if (this.panelForItemsPrimario == null)
			{
				throw new ArgumentNullException("panelForItemsPrimario", "panelForItemsPrimario null reference.");
			}
			if (this.panelForItemsSegundario == null)
			{
				throw new ArgumentNullException("panelForItemsSegundario", "panelForItemsSegundario null reference.");
			}
			if (this.panelParaControles == null)
			{
				throw new ArgumentNullException("panelParaControles", "panelParaControles null reference.");
			}
			if (this.panelSuperior == null)
			{
				throw new ArgumentNullException("panelSuperior", "panelSuperior null reference.");
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001F475 File Offset: 0x0001D675
		public Transform GetParentPara(int index)
		{
			if (index == 0)
			{
				return this.panelForItemsPrimario;
			}
			if (index != 1)
			{
				throw new ArgumentOutOfRangeException(index.ToString());
			}
			return this.panelForItemsSegundario;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001F49C File Offset: 0x0001D69C
		public void CheckIsVisible()
		{
			if (!this.padreParaTitulos.gameObject.activeSelf && !this.padreParaControles.gameObject.activeSelf)
			{
				this.panelSuperior.gameObject.SetActive(false);
				return;
			}
			this.panelSuperior.gameObject.SetActive(true);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001F4F0 File Offset: 0x0001D6F0
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001F50A File Offset: 0x0001D70A
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0001F512 File Offset: 0x0001D712
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003B4 RID: 948
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040003B5 RID: 949
		public Transform panelParaTitulos;

		// Token: 0x040003B6 RID: 950
		public Transform panelParaControles;

		// Token: 0x040003B7 RID: 951
		public Transform panelForItemsPrimario;

		// Token: 0x040003B8 RID: 952
		public Transform panelForItemsSegundario;

		// Token: 0x040003B9 RID: 953
		public Transform panelSuperior;

		// Token: 0x040003BA RID: 954
		private Image m_panel;
	}
}

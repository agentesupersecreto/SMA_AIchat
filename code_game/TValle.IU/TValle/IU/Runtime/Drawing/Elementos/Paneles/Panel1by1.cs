using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000138 RID: 312
	public class Panel1by1 : UIElemento, IUIPanel, IUIElemento, IUIPanelConControles, IUIMultiPanel, IUIPanelConTitulo, IUIPanelConBotones, IUIPanelConSuperiorPanel
	{
		// Token: 0x17000294 RID: 660
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0001EF58 File Offset: 0x0001D158
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0001EF60 File Offset: 0x0001D160
		public Transform padreParaTitulos
		{
			get
			{
				return this.panelParaTitulos;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0001EF68 File Offset: 0x0001D168
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.panelForItemsPrimario;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0001EF70 File Offset: 0x0001D170
		public Transform padreParaControles
		{
			get
			{
				return this.panelParaControles;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0001EF78 File Offset: 0x0001D178
		public Transform padreParaItemsSegundario
		{
			get
			{
				return this.panelForItemsSegundario;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0001EF80 File Offset: 0x0001D180
		public Transform padreParaBotones
		{
			get
			{
				return this.panelParaBotones;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0001EF88 File Offset: 0x0001D188
		public Scrollbar scrollbar
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x0001EF8B File Offset: 0x0001D18B
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x0001EF93 File Offset: 0x0001D193
		public int getParentCount
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001EF98 File Offset: 0x0001D198
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

		// Token: 0x06000947 RID: 2375 RVA: 0x0001F038 File Offset: 0x0001D238
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0001F08C File Offset: 0x0001D28C
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

		// Token: 0x06000949 RID: 2377 RVA: 0x0001F120 File Offset: 0x0001D320
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
			if (this.panelParaBotones == null)
			{
				throw new ArgumentNullException("panelParaBotones", "panelParaBotones null reference.");
			}
			if (this.panelSuperior == null)
			{
				throw new ArgumentNullException("panelSuperior", "panelSuperior null reference.");
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0001F1F3 File Offset: 0x0001D3F3
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

		// Token: 0x0600094B RID: 2379 RVA: 0x0001F218 File Offset: 0x0001D418
		public void CheckIsVisible()
		{
			if (!this.padreParaTitulos.gameObject.activeSelf && !this.padreParaControles.gameObject.activeSelf)
			{
				this.panelSuperior.gameObject.SetActive(false);
				return;
			}
			this.panelSuperior.gameObject.SetActive(true);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0001F26C File Offset: 0x0001D46C
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0001F286 File Offset: 0x0001D486
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0001F28E File Offset: 0x0001D48E
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003AC RID: 940
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040003AD RID: 941
		public Transform panelParaTitulos;

		// Token: 0x040003AE RID: 942
		public Transform panelParaControles;

		// Token: 0x040003AF RID: 943
		public Transform panelForItemsPrimario;

		// Token: 0x040003B0 RID: 944
		public Transform panelForItemsSegundario;

		// Token: 0x040003B1 RID: 945
		public Transform panelParaBotones;

		// Token: 0x040003B2 RID: 946
		public Transform panelSuperior;

		// Token: 0x040003B3 RID: 947
		private Image m_panel;
	}
}

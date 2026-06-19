using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x0200013A RID: 314
	[RequireComponent(typeof(Image))]
	public class PrimaryColorToggles : UIElemento, IUIPanel, IUIElemento, IUIPanelConBotones, IUIPanelConTitulo, IUIPanelConControles
	{
		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000961 RID: 2401 RVA: 0x0001F51A File Offset: 0x0001D71A
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x0001F522 File Offset: 0x0001D722
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.panelForItems;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x0001F52A File Offset: 0x0001D72A
		public Transform padreParaBotones
		{
			get
			{
				return this.panelParaBotones;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0001F532 File Offset: 0x0001D732
		public Transform padreParaControles
		{
			get
			{
				return this.panelParaControles;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0001F53A File Offset: 0x0001D73A
		Scrollbar IUIPanel.scrollbar
		{
			get
			{
				return this.scrollbar;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x0001F542 File Offset: 0x0001D742
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0001F54A File Offset: 0x0001D74A
		public Transform padreParaTitulos
		{
			get
			{
				return this.padreParaControles;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x0001F552 File Offset: 0x0001D752
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001F558 File Offset: 0x0001D758
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

		// Token: 0x0600096A RID: 2410 RVA: 0x0001F5F8 File Offset: 0x0001D7F8
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001F64C File Offset: 0x0001D84C
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

		// Token: 0x0600096C RID: 2412 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
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

		// Token: 0x0600096D RID: 2413 RVA: 0x0001F795 File Offset: 0x0001D995
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001F79D File Offset: 0x0001D99D
		public Transform GetParentPara(int index)
		{
			return this.padreParaItemsPrimario;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001F7A5 File Offset: 0x0001D9A5
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001F7BF File Offset: 0x0001D9BF
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001F7C7 File Offset: 0x0001D9C7
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003BB RID: 955
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040003BC RID: 956
		public Transform panelParaBotones;

		// Token: 0x040003BD RID: 957
		public Transform panelForItems;

		// Token: 0x040003BE RID: 958
		public Transform panelParaControles;

		// Token: 0x040003BF RID: 959
		public ScrollRect scrollRect;

		// Token: 0x040003C0 RID: 960
		public Scrollbar scrollbar;

		// Token: 0x040003C1 RID: 961
		private Image m_panel;
	}
}

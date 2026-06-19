using System;
using System.Collections.Generic;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Drawing.Elementos
{
	// Token: 0x02000093 RID: 147
	[RequireComponent(typeof(Image))]
	public class ScrollablePanel : UIElemento, IUIPanel, IUIElemento, IUIPanelConControles, IUIPanelConBotones, IUIPanelConTitulo
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00013ABF File Offset: 0x00011CBF
		public Image panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x00013AC7 File Offset: 0x00011CC7
		public Transform padreParaItemsPrimario
		{
			get
			{
				return this.panelForItems;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00013ACF File Offset: 0x00011CCF
		public Transform padreParaControles
		{
			get
			{
				return this.panelParaControles;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x00013AD7 File Offset: 0x00011CD7
		public Transform padreParaBotones
		{
			get
			{
				return this.panelParaBotones;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00013ADF File Offset: 0x00011CDF
		public virtual Transform padreParaTitulos
		{
			get
			{
				return this.padreParaItemsPrimario;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00013AE7 File Offset: 0x00011CE7
		Scrollbar IUIPanel.scrollbar
		{
			get
			{
				return this.scrollbar;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00013AEF File Offset: 0x00011CEF
		public IReadOnlyDictionary<string, IUIElemento> elementoPorModelo
		{
			get
			{
				return this.m_elementos;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x00013AF7 File Offset: 0x00011CF7
		public int getParentCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00013AFC File Offset: 0x00011CFC
		public virtual void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
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

		// Token: 0x060004AF RID: 1199 RVA: 0x00013B9C File Offset: 0x00011D9C
		public void ReplaceElemento(IUIElemento elemento)
		{
			if (!this.m_elementos.ContainsKey(elemento.modelName))
			{
				Debug.LogError("Panel: " + base.name + ", no contiene elemento: " + elemento.modelName, this);
				return;
			}
			this.m_elementos[elemento.modelName] = elemento;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00013BF0 File Offset: 0x00011DF0
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

		// Token: 0x060004B1 RID: 1201 RVA: 0x00013C84 File Offset: 0x00011E84
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_panel == null)
			{
				this.m_panel = base.GetComponent<Image>();
			}
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

		// Token: 0x060004B2 RID: 1202 RVA: 0x00013D48 File Offset: 0x00011F48
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			ScrollRect componentInParent = base.GetComponentInParent<ScrollRect>();
			if (((componentInParent != null) ? new bool?(componentInParent.isActiveAndEnabled) : null).GetValueOrDefault())
			{
				this.scrollRect.enabled = false;
				this.scrollbar.transform.parent.gameObject.SetActive(false);
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00013DAB File Offset: 0x00011FAB
		public Transform GetParentPara(int index)
		{
			return this.padreParaItemsPrimario;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00013DB3 File Offset: 0x00011FB3
		public void AddElementOnAsyncMode(string model, IUIElemento element)
		{
			if (this.elementoPorModelo.ContainsKey(model))
			{
				Debug.LogError("Panel: " + base.name + ", ya contiene elemento: " + model, this);
				return;
			}
			this.m_elementos.Add(model, element);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00013E00 File Offset: 0x00012000
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00013E08 File Offset: 0x00012008
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040001CE RID: 462
		private Dictionary<string, IUIElemento> m_elementos = new Dictionary<string, IUIElemento>();

		// Token: 0x040001CF RID: 463
		public Transform panelForItems;

		// Token: 0x040001D0 RID: 464
		public Transform panelParaBotones;

		// Token: 0x040001D1 RID: 465
		public Transform panelParaControles;

		// Token: 0x040001D2 RID: 466
		public ScrollRect scrollRect;

		// Token: 0x040001D3 RID: 467
		public Scrollbar scrollbar;

		// Token: 0x040001D4 RID: 468
		[Tooltip("puede ser null")]
		[SerializeField]
		private Image m_panel;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000134 RID: 308
	public class ScrollablePortraitPanelBase<TProtrait> : ScrollablePanel where TProtrait : SelectablePortraitBase
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0001E4B6 File Offset: 0x0001C6B6
		public IReadOnlyList<TProtrait> portraits
		{
			get
			{
				return this.m_retratos;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0001E4BE File Offset: 0x0001C6BE
		public override Transform padreParaTitulos
		{
			get
			{
				return this.panelParaTitle;
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
		public override void AddElementos(IEnumerable<KeyValuePair<string, IUIElemento>> pares)
		{
			base.AddElementos(pares);
			foreach (KeyValuePair<string, IUIElemento> keyValuePair in pares)
			{
				TProtrait tprotrait = keyValuePair.Value as TProtrait;
				if (!(tprotrait == null))
				{
					this.m_retratos.Add(tprotrait);
					this.m_toLoad.Enqueue(tprotrait);
					tprotrait.onValueChangedPre.AddListener(new UnityAction<IUIElementoConValor>(this.OnValueChangedPre));
				}
			}
			base.StartCoroutine(this.RoutineLoadImages());
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0001E574 File Offset: 0x0001C774
		private IEnumerator RoutineLoadImages()
		{
			yield return null;
			while (this.m_toLoad.Count > 0)
			{
				this.m_toLoad.Dequeue().DoLoad();
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0001E584 File Offset: 0x0001C784
		private void OnValueChangedPre(IUIElementoConValor portraitElemento)
		{
			TProtrait tprotrait = (TProtrait)((object)portraitElemento);
			if (tprotrait.toggle.isOn)
			{
				for (int i = 0; i < this.m_retratos.Count; i++)
				{
					TProtrait tprotrait2 = this.m_retratos[i];
					if (tprotrait2 == tprotrait)
					{
						tprotrait2.grayOut.enabled = false;
					}
					else
					{
						tprotrait2.SetValor(false, true);
						tprotrait2.grayOut.enabled = true;
					}
				}
				return;
			}
			for (int j = 0; j < this.m_retratos.Count; j++)
			{
				TProtrait tprotrait3 = this.m_retratos[j];
				tprotrait3.grayOut.enabled = false;
				tprotrait3.SetValor(false, true);
			}
		}

		// Token: 0x04000391 RID: 913
		public Transform panelParaTitle;

		// Token: 0x04000392 RID: 914
		private List<TProtrait> m_retratos = new List<TProtrait>();

		// Token: 0x04000393 RID: 915
		private Queue<TProtrait> m_toLoad = new Queue<TProtrait>();
	}
}

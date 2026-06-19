using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles
{
	// Token: 0x02000137 RID: 311
	[RequireComponent(typeof(Image))]
	public class NestedContainerConTitulo : NestedContainer, IUIPanelConSuperiorPanel, IUIPanel, IUIElemento
	{
		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0001EE92 File Offset: 0x0001D092
		public override Transform padreParaTitulos
		{
			get
			{
				return this.m_panelParaTitulo;
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0001EE9C File Offset: 0x0001D09C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_superiorPanel == null)
			{
				throw new ArgumentNullException("m_superiorPanel", "m_superiorPanel null reference.");
			}
			if (this.m_panelParaTitulo == null)
			{
				throw new ArgumentNullException("m_panelParaTitulo", "m_panelParaTitulo null reference.");
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001EEEC File Offset: 0x0001D0EC
		public void CheckIsVisible()
		{
			if (!this.padreParaTitulos.gameObject.activeSelf && !base.padreParaControles.gameObject.activeSelf)
			{
				this.m_superiorPanel.gameObject.SetActive(false);
				return;
			}
			this.m_superiorPanel.gameObject.SetActive(true);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001EF48 File Offset: 0x0001D148
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001EF50 File Offset: 0x0001D150
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003AA RID: 938
		[SerializeField]
		private Transform m_panelParaTitulo;

		// Token: 0x040003AB RID: 939
		[SerializeField]
		private Transform m_superiorPanel;
	}
}

using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000085 RID: 133
	public class GenericFlotanteUserPanel : GenericUserPanelBase
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00007BB9 File Offset: 0x00005DB9
		public override Transform target
		{
			get
			{
				return this.m_canvas.transform;
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00007BC8 File Offset: 0x00005DC8
		protected override void Binding()
		{
			this.m_canvas = base.GetComponentInChildren<Canvas>(true);
			if (this.m_canvas == null)
			{
				Debug.LogError(base.name + " requiere un canvas en hijos", this);
				return;
			}
			if (!this.dontChangeCanvasConfig)
			{
				this.m_canvas.renderMode = RenderMode.WorldSpace;
				this.m_canvas.worldCamera = Camera.main;
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00007C2B File Offset: 0x00005E2B
		protected override void Binded()
		{
			this.target.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = 5;
			}, true);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00007C58 File Offset: 0x00005E58
		protected override void Showed()
		{
			base.Showed();
			if (this.enableCanvasOnShow)
			{
				this.m_canvas.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00007C79 File Offset: 0x00005E79
		protected override void Hided()
		{
			base.Hided();
			if (this.disableCanvasOnHide)
			{
				this.m_canvas.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00007C9A File Offset: 0x00005E9A
		protected override void Clearing()
		{
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00007C9C File Offset: 0x00005E9C
		protected override void Cleared()
		{
		}

		// Token: 0x0400014C RID: 332
		[SerializeField]
		[ReadOnlyUI]
		private Canvas m_canvas;

		// Token: 0x0400014D RID: 333
		public bool dontChangeCanvasConfig;

		// Token: 0x0400014E RID: 334
		public bool enableCanvasOnShow;

		// Token: 0x0400014F RID: 335
		public bool disableCanvasOnHide;
	}
}

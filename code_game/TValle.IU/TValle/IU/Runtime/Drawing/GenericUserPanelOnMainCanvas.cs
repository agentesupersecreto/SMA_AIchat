using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Modales.Abstracts;
using Assets._ReusableScripts.UI;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing
{
	// Token: 0x020000EE RID: 238
	public class GenericUserPanelOnMainCanvas : GenericUserPanelBase, IModalWindow
	{
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00019F6A File Offset: 0x0001816A
		public static bool algunPanelEnMainCanvas
		{
			get
			{
				return GenericUserPanelOnMainCanvas.m_algunPanelMostrandose.Or(false);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00019F77 File Offset: 0x00018177
		public override Transform target
		{
			get
			{
				return MainCanvas.main.transform;
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000728 RID: 1832 RVA: 0x00019F84 File Offset: 0x00018184
		// (remove) Token: 0x06000729 RID: 1833 RVA: 0x00019FBC File Offset: 0x000181BC
		public event Action<IModalWindow> showingStateChanged;

		// Token: 0x0600072A RID: 1834 RVA: 0x00019FF1 File Offset: 0x000181F1
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_EstaMostrandoseModificador = GenericUserPanelOnMainCanvas.m_algunPanelMostrandose.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001A00A File Offset: 0x0001820A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeBool estaMostrandoseModificador = this.m_EstaMostrandoseModificador;
			if (estaMostrandoseModificador == null)
			{
				return;
			}
			estaMostrandoseModificador.TryRemoverDeOwner(true);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001A025 File Offset: 0x00018225
		protected override void Binding()
		{
			if (!Singleton<MainCanvas>.IsInScene)
			{
				throw new ArgumentNullException("MainCanvas", "MainCanvas null reference.");
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001A03E File Offset: 0x0001823E
		protected override void Binded()
		{
			PointerHandlerBroadcaster componentNotNull = base.panel.transform.GetComponentNotNull<PointerHandlerBroadcaster>();
			componentNotNull.AddListiner(this);
			componentNotNull.AddListiner(this);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0001A05D File Offset: 0x0001825D
		protected override void Clearing()
		{
			PointerHandlerBroadcaster componentNotNull = base.panel.transform.GetComponentNotNull<PointerHandlerBroadcaster>();
			componentNotNull.RemoveListiner(this);
			componentNotNull.RemoveListiner(this);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0001A07C File Offset: 0x0001827C
		protected override void Cleared()
		{
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0001A07E File Offset: 0x0001827E
		protected override void Showed()
		{
			this.m_EstaMostrandoseModificador.valor.valor = !this.m_furtivo;
			base.Showed();
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001A0B3 File Offset: 0x000182B3
		protected override void Hided()
		{
			this.m_EstaMostrandoseModificador.valor.valor = false;
			base.Hided();
			Action<IModalWindow> action = this.showingStateChanged;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x040002DA RID: 730
		private static ModificableDeBool m_algunPanelMostrandose = new ModificableDeBool(false);

		// Token: 0x040002DC RID: 732
		[SerializeField]
		private ModificadorDeBool m_EstaMostrandoseModificador;

		// Token: 0x040002DD RID: 733
		[SerializeField]
		private bool m_furtivo;
	}
}

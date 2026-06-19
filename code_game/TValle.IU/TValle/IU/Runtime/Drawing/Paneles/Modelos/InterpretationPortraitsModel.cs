using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x02000100 RID: 256
	[Modelo]
	[Label("Select a Profile...", alignment = TextAlignmentOptions.MidlineLeft, color = ColorEnum.black, fontSize = 18)]
	[Panel(tipo = TipoDePanel.scrollableDeInterpretationProfilePortraits)]
	[Serializable]
	public class InterpretationPortraitsModel : BindableModel
	{
		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000795 RID: 1941 RVA: 0x0001AE88 File Offset: 0x00019088
		// (remove) Token: 0x06000796 RID: 1942 RVA: 0x0001AEC0 File Offset: 0x000190C0
		public event Action<InterpretationPortraitsModel> canceling;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000797 RID: 1943 RVA: 0x0001AEF8 File Offset: 0x000190F8
		// (remove) Token: 0x06000798 RID: 1944 RVA: 0x0001AF30 File Offset: 0x00019130
		public event Action<InterpretationPortraitsModel> staring;

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x0001AF65 File Offset: 0x00019165
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x0001AF6D File Offset: 0x0001916D
		public int currentSelected
		{
			get
			{
				return this.m_currentSelected;
			}
			set
			{
				this.m_currentSelected = value;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0001AF76 File Offset: 0x00019176
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x0001AF7E File Offset: 0x0001917E
		[ActivatedDelegates(para = "Load")]
		public bool isSelected
		{
			get
			{
				return this.m_isSelected;
			}
			set
			{
				this.m_isSelected = value;
				this.OnDirtyChanged();
			}
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001AF8D File Offset: 0x0001918D
		[BotonDePanel(enabled = true)]
		[Label("Cancel", "US")]
		public void Cancel()
		{
			Action<InterpretationPortraitsModel> action = this.canceling;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001AFA0 File Offset: 0x000191A0
		[BotonDePanel(enabled = false)]
		[Label("Load", "US")]
		public void Load()
		{
			Action<InterpretationPortraitsModel> action = this.staring;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001AFB4 File Offset: 0x000191B4
		protected virtual void OnDirtyChanged()
		{
			if (base.panel == null)
			{
				Debug.LogError("Model: " + base.GetType().Name + " dirty state changed when it was not binded");
			}
			IUIPanel panel = base.panel;
			IUIElementoRefreshable iuielementoRefreshable = ((panel != null) ? panel.elementoPorModelo["Load"] : null) as IUIElementoRefreshable;
			if (iuielementoRefreshable == null)
			{
				return;
			}
			iuielementoRefreshable.Refresh();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001B014 File Offset: 0x00019214
		protected override void Bindig()
		{
			base.Bindig();
			List<string> list;
			this.disponibles = (from e in ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.autoRatingPortraitsV2 })
				select new MultipleValorElemento<string, bool>(e, false)).ToList<MultipleValorElemento<string, bool>>();
			if (list.Count > 0)
			{
				foreach (string text in list)
				{
					Singleton<MainCanvas>.instance.MostrartMsg("It is recommended that you load and save the following profile to keep it up to date", text, 5f, true, null, null, null);
				}
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001B0D8 File Offset: 0x000192D8
		[MemberValueChangedListener(member = "disponibles")]
		protected void OnOverallChanged(IUIElementoConValor elemento)
		{
			ScrollableProfilePortraitPanel scrollableProfilePortraitPanel = (ScrollableProfilePortraitPanel)base.panel;
			for (int i = 0; i < scrollableProfilePortraitPanel.portraits.Count; i++)
			{
				if (scrollableProfilePortraitPanel.portraits[i].toggle.isOn)
				{
					this.isSelected = true;
					this.m_currentSelected = i;
					return;
				}
			}
			this.m_currentSelected = -1;
			this.isSelected = false;
		}

		// Token: 0x040002FE RID: 766
		[InterpretationProfilePortrait]
		public List<MultipleValorElemento<string, bool>> disponibles;

		// Token: 0x04000301 RID: 769
		[SerializeField]
		private int m_currentSelected;

		// Token: 0x04000302 RID: 770
		[SerializeField]
		private bool m_isSelected;
	}
}

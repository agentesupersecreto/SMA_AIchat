using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos
{
	// Token: 0x020000FC RID: 252
	[Serializable]
	public abstract class PortraitsModelBase<T_PortraitItemData> : BindableModel
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000779 RID: 1913
		[Ignore]
		public abstract List<T_PortraitItemData> protraitsDisponibles { get; }

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x0600077A RID: 1914 RVA: 0x0001AAF0 File Offset: 0x00018CF0
		// (remove) Token: 0x0600077B RID: 1915 RVA: 0x0001AB28 File Offset: 0x00018D28
		public event Action<PortraitsModelBase<T_PortraitItemData>> canceling;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x0600077C RID: 1916 RVA: 0x0001AB60 File Offset: 0x00018D60
		// (remove) Token: 0x0600077D RID: 1917 RVA: 0x0001AB98 File Offset: 0x00018D98
		public event Action<PortraitsModelBase<T_PortraitItemData>> staring;

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0001ABCD File Offset: 0x00018DCD
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x0001ABD5 File Offset: 0x00018DD5
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

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x0001ABDE File Offset: 0x00018DDE
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x0001ABE6 File Offset: 0x00018DE6
		[ActivatedDelegates(para = "Start")]
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

		// Token: 0x06000782 RID: 1922 RVA: 0x0001ABF5 File Offset: 0x00018DF5
		[BotonDePanel(enabled = true)]
		[Label("Cancel", "US")]
		public void Cancel()
		{
			Action<PortraitsModelBase<T_PortraitItemData>> action = this.canceling;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0001AC08 File Offset: 0x00018E08
		[BotonDePanel(enabled = false)]
		[Label("Select", "US")]
		public void Start()
		{
			Action<PortraitsModelBase<T_PortraitItemData>> action = this.staring;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0001AC1C File Offset: 0x00018E1C
		protected virtual void OnDirtyChanged()
		{
			if (base.panel == null)
			{
				Debug.LogError("Model: " + base.GetType().Name + " dirty state changed when it was not binded");
			}
			IUIPanel panel = base.panel;
			IUIElementoRefreshable iuielementoRefreshable = ((panel != null) ? panel.elementoPorModelo["Start"] : null) as IUIElementoRefreshable;
			if (iuielementoRefreshable == null)
			{
				return;
			}
			iuielementoRefreshable.Refresh();
		}

		// Token: 0x06000785 RID: 1925
		protected abstract void OnBindig();

		// Token: 0x06000786 RID: 1926 RVA: 0x0001AC7B File Offset: 0x00018E7B
		protected override void Bindig()
		{
			base.Bindig();
			this.OnBindig();
		}

		// Token: 0x040002F1 RID: 753
		[SerializeField]
		protected int m_currentSelected;

		// Token: 0x040002F2 RID: 754
		[SerializeField]
		private bool m_isSelected;
	}
}

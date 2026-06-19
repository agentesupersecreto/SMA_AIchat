using System;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;

namespace Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts
{
	// Token: 0x02000108 RID: 264
	public abstract class BindableModel : IModeloBindableOnUIPanel
	{
		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060007D2 RID: 2002 RVA: 0x0001B95C File Offset: 0x00019B5C
		// (remove) Token: 0x060007D3 RID: 2003 RVA: 0x0001B994 File Offset: 0x00019B94
		public event Action<BindableModel> bindig;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060007D4 RID: 2004 RVA: 0x0001B9CC File Offset: 0x00019BCC
		// (remove) Token: 0x060007D5 RID: 2005 RVA: 0x0001BA04 File Offset: 0x00019C04
		public event Action<BindableModel, IUIPanel> binded;

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x0001BA39 File Offset: 0x00019C39
		public IUIPanel panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0001BA41 File Offset: 0x00019C41
		protected virtual void Bindig()
		{
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001BA43 File Offset: 0x00019C43
		protected virtual void Binded(IUIPanel to)
		{
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001BA45 File Offset: 0x00019C45
		protected virtual void Clearing()
		{
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001BA47 File Offset: 0x00019C47
		protected virtual void Cleared()
		{
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0001BA49 File Offset: 0x00019C49
		void IModeloBindableOnUIPanel.Bindig()
		{
			this.Bindig();
			Action<BindableModel> action = this.bindig;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001BA62 File Offset: 0x00019C62
		void IModeloBindableOnUIPanel.Binded(IUIPanel to)
		{
			this.m_panel = to;
			this.Binded(to);
			Action<BindableModel, IUIPanel> action = this.binded;
			if (action == null)
			{
				return;
			}
			action(this, this.m_panel);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0001BA89 File Offset: 0x00019C89
		void IModeloBindableOnUIPanel.Clearing()
		{
			this.Clearing();
			this.m_panel = null;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001BA98 File Offset: 0x00019C98
		void IModeloBindableOnUIPanel.Cleared()
		{
			this.Cleared();
		}

		// Token: 0x04000313 RID: 787
		private IUIPanel m_panel;
	}
}

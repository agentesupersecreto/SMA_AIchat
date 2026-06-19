using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000AF RID: 175
	[Panel(width = 920, height = 640, posX = -130, tipo = TipoDePanel.panel1by1)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class EntrevistaStartCampaing : BindableModel
	{
		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060003E9 RID: 1001 RVA: 0x00014058 File Offset: 0x00012258
		// (remove) Token: 0x060003EA RID: 1002 RVA: 0x00014090 File Offset: 0x00012290
		public event Action onStart;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060003EB RID: 1003 RVA: 0x000140C8 File Offset: 0x000122C8
		// (remove) Token: 0x060003EC RID: 1004 RVA: 0x00014100 File Offset: 0x00012300
		public event Action onCancel;

		// Token: 0x060003ED RID: 1005 RVA: 0x00014135 File Offset: 0x00012335
		[Label("Cancel", "US")]
		[BotonDePanel]
		public void Cancel()
		{
			Action action = this.onCancel;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00014147 File Offset: 0x00012347
		[Label("Launch Campaign", "US")]
		[BotonDePanel]
		public void Start()
		{
			if (!this.IsValid())
			{
				throw new InvalidOperationException();
			}
			Action action = this.onStart;
			if (action != null)
			{
				action();
			}
			this.m_isDirty = false;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0001416F File Offset: 0x0001236F
		[ModelValueChangedListener(escucharTodosLosElementosAnteriores = true)]
		protected virtual void OnModelChanged(IUIElementoConValor elemento)
		{
			this.m_isDirty = true;
			this.m_isValid = this.IsValid();
			this.OnDirtyChanged();
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001418A File Offset: 0x0001238A
		private void OnDirtyChanged()
		{
			IUIPanel panel = base.panel;
			IUIElementoRefreshable iuielementoRefreshable = ((panel != null) ? panel.elementoPorModelo["Start"] : null) as IUIElementoRefreshable;
			if (iuielementoRefreshable == null)
			{
				return;
			}
			iuielementoRefreshable.Refresh();
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000141B8 File Offset: 0x000123B8
		public bool IsValid()
		{
			return (this.info.profesionals || this.info.amateur || this.info.allPublic) && !string.IsNullOrWhiteSpace(this.profile.profile.item1) && this.info.currentMoney >= this.info.costMoney;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00014222 File Offset: 0x00012422
		[ActivatedDelegates(para = "Start")]
		private bool CanStart()
		{
			return this.m_isDirty && this.m_isValid;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00014234 File Offset: 0x00012434
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			IUIElemento iuielemento = to.elementoPorModelo["info"];
			this.info.Binded((IUIPanel)iuielemento);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0001426A File Offset: 0x0001246A
		protected override void Cleared()
		{
			base.Cleared();
			this.profile.Cleared();
		}

		// Token: 0x040001A8 RID: 424
		[ParentPanelTarget(index = 0)]
		[Modelo]
		public EntrevistaStartCampaingProfile profile = new EntrevistaStartCampaingProfile();

		// Token: 0x040001A9 RID: 425
		[ParentPanelTarget(index = 1)]
		[Modelo]
		public EntrevistaStartCampaingInfo info = new EntrevistaStartCampaingInfo();

		// Token: 0x040001AA RID: 426
		[Ignore]
		[SerializeField]
		private bool m_isDirty;

		// Token: 0x040001AB RID: 427
		[Ignore]
		[SerializeField]
		private bool m_isValid;
	}
}

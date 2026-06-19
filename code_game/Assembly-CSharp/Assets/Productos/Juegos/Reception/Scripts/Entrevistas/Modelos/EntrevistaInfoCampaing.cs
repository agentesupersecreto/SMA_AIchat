using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000B2 RID: 178
	[Panel(width = 920, height = 670, posX = -130, tipo = TipoDePanel.panel1by1)]
	[Modelo]
	[UnTittle]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class EntrevistaInfoCampaing : BindableModel
	{
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x0600040B RID: 1035 RVA: 0x000148F0 File Offset: 0x00012AF0
		// (remove) Token: 0x0600040C RID: 1036 RVA: 0x00014928 File Offset: 0x00012B28
		public event Action onGoNextPhase;

		// Token: 0x0600040D RID: 1037 RVA: 0x0001495D File Offset: 0x00012B5D
		[Label("Go Next Phase", "US")]
		[BotonDePanelConfirmable(confirmar = true)]
		[AccionName("GoNextCampaingPhase")]
		[ConfirmablePregunta("Moving on to the next phase will mean replacing all of the models from this phase with new ones.\n Do you want to progress to the next campaign phase?", "US")]
		public void GoNextPhase()
		{
			if (!this.canGoNextPhase)
			{
				throw new InvalidOperationException();
			}
			Action action = this.onGoNextPhase;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001497D File Offset: 0x00012B7D
		[ActivatedDelegates(para = "GoNextPhase")]
		private bool CanGoNextPhase()
		{
			return this.canGoNextPhase;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00014985 File Offset: 0x00012B85
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001498E File Offset: 0x00012B8E
		protected override void Cleared()
		{
			base.Cleared();
			this.profile.Cleared();
		}

		// Token: 0x040001C2 RID: 450
		[Ignore]
		public bool canGoNextPhase;

		// Token: 0x040001C3 RID: 451
		[ParentPanelTarget(index = 0)]
		[Modelo]
		public EntrevistaInfoCampaingProfile profile = new EntrevistaInfoCampaingProfile();

		// Token: 0x040001C4 RID: 452
		[ParentPanelTarget(index = 1)]
		[Modelo]
		public EntrevistaInfoCampaingInfo info = new EntrevistaInfoCampaingInfo();
	}
}

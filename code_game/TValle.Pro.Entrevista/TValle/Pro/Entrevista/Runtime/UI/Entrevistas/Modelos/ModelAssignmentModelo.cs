using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004B RID: 75
	[Modelo]
	[UnTittle]
	[Panel(tipo = TipoDePanel.panel1by1, controlChildHeight = true, controlChildWidth = true, childForceExpandHeight = true, childForceExpandWidth = true)]
	[Serializable]
	public class ModelAssignmentModelo : BindableModel
	{
		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000267 RID: 615 RVA: 0x0000F3AC File Offset: 0x0000D5AC
		// (remove) Token: 0x06000268 RID: 616 RVA: 0x0000F3E4 File Offset: 0x0000D5E4
		public event Action<ModelAssignmentModelo> onDeployClicked;

		// Token: 0x06000269 RID: 617 RVA: 0x0000F419 File Offset: 0x0000D619
		[Label("Deploy", "US")]
		[Descripcion("-Deploy talent to their next assignment. Select a model, choose a job session, and oversee their performance on-site.", "US")]
		[BotonDePanelConfirmable(confirmar = true)]
		[AccionName("DeployFemale")]
		[ConfirmablePregunta("Are you sure you want to use this model for this assignment?", "US")]
		public void Deploy()
		{
			Action<ModelAssignmentModelo> action = this.onDeployClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x04000183 RID: 387
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public ModelInfoModelo modelInfo = new ModelInfoModelo();

		// Token: 0x04000184 RID: 388
		[Modelo]
		[ParentPanelTarget(index = 1)]
		public AssignmentInfoModelo assignmentInfo = new AssignmentInfoModelo();
	}
}

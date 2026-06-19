using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x02000049 RID: 73
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Panel(width = 550, height = 750)]
	[Modelo]
	[Serializable]
	public class MeetingHiredModelModelo
	{
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600024C RID: 588 RVA: 0x0000EFD0 File Offset: 0x0000D1D0
		// (remove) Token: 0x0600024D RID: 589 RVA: 0x0000F008 File Offset: 0x0000D208
		public event Action<MeetingHiredModelModelo> onStartFiring;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x0600024E RID: 590 RVA: 0x0000F040 File Offset: 0x0000D240
		// (remove) Token: 0x0600024F RID: 591 RVA: 0x0000F078 File Offset: 0x0000D278
		public event Action<MeetingHiredModelModelo> onDispatchHerClicked;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000250 RID: 592 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
		// (remove) Token: 0x06000251 RID: 593 RVA: 0x0000F0E8 File Offset: 0x0000D2E8
		public event Action onShowModelInfo;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000252 RID: 594 RVA: 0x0000F120 File Offset: 0x0000D320
		// (remove) Token: 0x06000253 RID: 595 RVA: 0x0000F158 File Offset: 0x0000D358
		public event Action onShowPlayerInfo;

		// Token: 0x06000254 RID: 596 RVA: 0x0000F18D File Offset: 0x0000D38D
		private bool DisableTalentDeploymentOnBuild()
		{
			return !Application.isEditor;
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000255 RID: 597 RVA: 0x0000F198 File Offset: 0x0000D398
		// (remove) Token: 0x06000256 RID: 598 RVA: 0x0000F1D0 File Offset: 0x0000D3D0
		public event Action onTalentDeployment;

		// Token: 0x06000257 RID: 599 RVA: 0x0000F205 File Offset: 0x0000D405
		[IgnoreIf(method = "DisableTalentDeploymentOnBuild")]
		[Label("Talent Deployment", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		[Descripcion("Deploy talent to their next assignment. Select a model, choose a job session, and oversee their performance on-site.", "US")]
		public void TalentDeployment()
		{
			Action action = this.onTalentDeployment;
			if (action != null)
			{
				action();
			}
			Debug.Log("todo: esto no va aca, va en empty scene");
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000F222 File Offset: 0x0000D422
		[Label("Model Resume", "US")]
		[Descripcion("-View detailed information about the model.", "US")]
		[AccionName("ShowModelCurriculum")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void ShowInfo()
		{
			Action action = this.onShowModelInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000F234 File Offset: 0x0000D434
		[Label("My Info", "US")]
		[Descripcion("-Click here to see some information about the Main Hero.", "US")]
		[AccionName("ShowPlayerCurriculum")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void ShowPlayerInfo()
		{
			Action action = this.onShowPlayerInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000F246 File Offset: 0x0000D446
		[Separador(height = 30)]
		[Label("Dispatch her", "US")]
		[Descripcion("-Tell her to leave.", "US")]
		[AccionName("DispatchFemale")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("Are you sure you want her to leave?", "US")]
		public void DispatchHer()
		{
			Action<MeetingHiredModelModelo> action = this.onDispatchHerClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000F259 File Offset: 0x0000D459
		[Separador(height = 30)]
		[Label("Fire Her", "US")]
		[Descripcion("-Fire this model from the agency.", "US")]
		[AccionName("StartFiringFemale")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("Do you really wish to fire her?", "US")]
		public void StartFiring()
		{
			Action<MeetingHiredModelModelo> action = this.onStartFiring;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0400017D RID: 381
		public Func<bool> confirmarDispatchHerDelegate;
	}
}

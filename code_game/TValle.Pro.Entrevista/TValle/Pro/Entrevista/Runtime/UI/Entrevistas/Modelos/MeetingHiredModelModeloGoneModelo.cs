using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004A RID: 74
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Panel(width = 550, height = 550)]
	[Modelo]
	[Serializable]
	public class MeetingHiredModelModeloGoneModelo
	{
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x0600025D RID: 605 RVA: 0x0000F274 File Offset: 0x0000D474
		// (remove) Token: 0x0600025E RID: 606 RVA: 0x0000F2AC File Offset: 0x0000D4AC
		public event Action onShowPlayerInfo;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x0600025F RID: 607 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
		// (remove) Token: 0x06000260 RID: 608 RVA: 0x0000F31C File Offset: 0x0000D51C
		public event Action onRest;

		// Token: 0x06000261 RID: 609 RVA: 0x0000F351 File Offset: 0x0000D551
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

		// Token: 0x06000262 RID: 610 RVA: 0x0000F363 File Offset: 0x0000D563
		[Separador(height = 30)]
		[IgnoreIf(method = "IsGoHome")]
		[Label("Rest for a while", "US")]
		[Descripcion("-Take a break until the following work schedule.", "US")]
		[AccionName("StartRestingTillNextDate")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to rest?", "US")]
		public void OnRest()
		{
			Action action = this.onRest;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000F375 File Offset: 0x0000D575
		[IgnoreIf(method = "IsRest")]
		[Label("Go Home", "US")]
		[Descripcion("-Take a break until the next workday.", "US")]
		[AccionName("AccionGoHome")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to go Home?", "US")]
		public void GoHome()
		{
			Action action = this.onRest;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000F387 File Offset: 0x0000D587
		private bool IsRest()
		{
			return !this.isLastWorkSchedule();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000F397 File Offset: 0x0000D597
		private bool IsGoHome()
		{
			return this.isLastWorkSchedule();
		}

		// Token: 0x0400017F RID: 383
		public Func<bool> isLastWorkSchedule;
	}
}

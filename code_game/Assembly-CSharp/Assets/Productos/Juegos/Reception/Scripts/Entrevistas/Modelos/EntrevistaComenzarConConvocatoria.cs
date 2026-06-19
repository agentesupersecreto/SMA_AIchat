using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000AE RID: 174
	[Panel(height = 720)]
	[Modelo]
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class EntrevistaComenzarConConvocatoria : IModeloConConvocatoria, IModeloConContratadas
	{
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060003C3 RID: 963 RVA: 0x00013AEC File Offset: 0x00011CEC
		// (remove) Token: 0x060003C4 RID: 964 RVA: 0x00013B24 File Offset: 0x00011D24
		public event Action onStartWorking;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060003C5 RID: 965 RVA: 0x00013B5C File Offset: 0x00011D5C
		// (remove) Token: 0x060003C6 RID: 966 RVA: 0x00013B94 File Offset: 0x00011D94
		public event Action onShowCampaignInfo;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060003C7 RID: 967 RVA: 0x00013BCC File Offset: 0x00011DCC
		// (remove) Token: 0x060003C8 RID: 968 RVA: 0x00013C04 File Offset: 0x00011E04
		public event Action onCancelarConvocatoria;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060003C9 RID: 969 RVA: 0x00013C3C File Offset: 0x00011E3C
		// (remove) Token: 0x060003CA RID: 970 RVA: 0x00013C74 File Offset: 0x00011E74
		public event Action onSaving;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060003CB RID: 971 RVA: 0x00013CAC File Offset: 0x00011EAC
		// (remove) Token: 0x060003CC RID: 972 RVA: 0x00013CE4 File Offset: 0x00011EE4
		public event Action onCheckAgencyInfo;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060003CD RID: 973 RVA: 0x00013D1C File Offset: 0x00011F1C
		// (remove) Token: 0x060003CE RID: 974 RVA: 0x00013D54 File Offset: 0x00011F54
		public event Action onCheckModelAssignments;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060003CF RID: 975 RVA: 0x00013D8C File Offset: 0x00011F8C
		// (remove) Token: 0x060003D0 RID: 976 RVA: 0x00013DC4 File Offset: 0x00011FC4
		public event Action onRest;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060003D1 RID: 977 RVA: 0x00013DFC File Offset: 0x00011FFC
		// (remove) Token: 0x060003D2 RID: 978 RVA: 0x00013E34 File Offset: 0x00012034
		public event Action onDisplayHired;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060003D3 RID: 979 RVA: 0x00013E6C File Offset: 0x0001206C
		// (remove) Token: 0x060003D4 RID: 980 RVA: 0x00013EA4 File Offset: 0x000120A4
		public event Action onImport;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060003D5 RID: 981 RVA: 0x00013EDC File Offset: 0x000120DC
		// (remove) Token: 0x060003D6 RID: 982 RVA: 0x00013F14 File Offset: 0x00012114
		public event Action onShowMyInfo;

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00013F49 File Offset: 0x00012149
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x00013F51 File Offset: 0x00012151
		[ActivatedDelegates(para = "StartWorking")]
		public bool existenModelosPorEntrevistar
		{
			get
			{
				return this.m_existenModelosPorEntrevistar;
			}
			set
			{
				this.m_existenModelosPorEntrevistar = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00013F5A File Offset: 0x0001215A
		// (set) Token: 0x060003DA RID: 986 RVA: 0x00013F62 File Offset: 0x00012162
		[ActivatedDelegates(para = "DisplayHired")]
		[ActivatedDelegates(para = "ModelAssignments")]
		public bool existenModelosContratadas
		{
			get
			{
				return this.m_existenModelosContratadas;
			}
			set
			{
				this.m_existenModelosContratadas = value;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00013F6B File Offset: 0x0001216B
		[Label("Start interviewing now", "US")]
		[Descripcion("-Set up an interview with a model at the office.", "US")]
		[Descripcion("-Give her an honest rating so that future models are more like the ones you're looking for.", "US")]
		[Descripcion("-Earns commissions by contacting her with some other \"modeling\" agency.", "US")]
		[AccionName("StartInterviewing")]
		[ClickableLabelDescriptable(confirmar = false, enabled = false)]
		[ConfirmablePregunta("Do you really want to start interviewing?", "US")]
		public void StartWorking()
		{
			Action action = this.onStartWorking;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00013F7D File Offset: 0x0001217D
		[Label("Show Campaign Info", "US")]
		[Descripcion("-Displays information about the current campaign, including which face it is currently on.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void ShowCampaignInfo()
		{
			Action action = this.onShowCampaignInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00013F8F File Offset: 0x0001218F
		[Label("End Campaign", "US")]
		[Descripcion("-You can end the current campaign if you don't want to hire another model.", "US")]
		[Descripcion("-The campaign must end if there are no more models available, and if you want to, you can start a new one.", "US")]
		[AccionName("CancelCampaign")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("Do you really want to cancel the current campaign?", "US")]
		public void CancelCampaign()
		{
			Action action = this.onCancelarConvocatoria;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00013FA1 File Offset: 0x000121A1
		[Separador(height = 15)]
		[Label("Talent Deployment", "US")]
		[ClickableLabelDescriptable(confirmar = false, enabled = false)]
		[Descripcion("-Deploy talent to their next assignment. Select a model, choose a job session, and oversee their performance on-site.", "US")]
		public void ModelAssignments()
		{
			Action action = this.onCheckModelAssignments;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00013FB3 File Offset: 0x000121B3
		[Label("In-House Talent", "US")]
		[Descripcion("-Your active modeling staff is listed here.", "US")]
		[Descripcion("-Selecting a model will summon her to the office..", "US")]
		[AccionName("OpenHiredModelsPanel")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void DisplayHired()
		{
			Action action = this.onDisplayHired;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00013FC5 File Offset: 0x000121C5
		[Label("Agency Info", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		[Descripcion("-Check out the responses from other agencies to the models you sent them.", "US")]
		[Descripcion("-See if any other agencies are interested in collaborating with yours.", "US")]
		public void CheckEmail()
		{
			Action action = this.onCheckAgencyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00013FD7 File Offset: 0x000121D7
		[Separador(height = 15)]
		[ClickableLabelDescriptable(confirmar = false)]
		[Label("My Info", "US")]
		[Descripcion("-Click here to see some information about the Main Hero.", "US")]
		public void ShowInfo()
		{
			Action action = this.onShowMyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00013FE9 File Offset: 0x000121E9
		[Separador(height = 15)]
		[Label("Save", "US")]
		[Descripcion("-Save your game progress.", "US")]
		[AccionName("AccionSave")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to Save?", "US")]
		public void Save()
		{
			Action action = this.onSaving;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00013FFB File Offset: 0x000121FB
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

		// Token: 0x060003E4 RID: 996 RVA: 0x0001400D File Offset: 0x0001220D
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

		// Token: 0x060003E5 RID: 997 RVA: 0x0001401F File Offset: 0x0001221F
		[Separador(height = 15)]
		[Label("Import Talent", "US")]
		[Descripcion("-Select and bring in talent from your contacts. Each booking includes a fixed $500 fee for travel, lodging, and essentials.", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void ImportTalent()
		{
			Action action = this.onImport;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00014031 File Offset: 0x00012231
		private bool IsRest()
		{
			return !this.isLastWorkSchedule();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00014041 File Offset: 0x00012241
		private bool IsGoHome()
		{
			return this.isLastWorkSchedule();
		}

		// Token: 0x04000199 RID: 409
		public Func<bool> isLastWorkSchedule;

		// Token: 0x040001A4 RID: 420
		[SerializeField]
		private bool m_existenModelosPorEntrevistar;

		// Token: 0x040001A5 RID: 421
		[SerializeField]
		private bool m_existenModelosContratadas;
	}
}

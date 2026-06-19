using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000AB RID: 171
	[Panel(height = 720)]
	[Modelo]
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Serializable]
	public class EntrevistaComenzarSinConvocatoria : IModeloConContratadas
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060003A1 RID: 929 RVA: 0x00013694 File Offset: 0x00011894
		// (remove) Token: 0x060003A2 RID: 930 RVA: 0x000136CC File Offset: 0x000118CC
		public event Action onStartRecruitment;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060003A3 RID: 931 RVA: 0x00013704 File Offset: 0x00011904
		// (remove) Token: 0x060003A4 RID: 932 RVA: 0x0001373C File Offset: 0x0001193C
		public event Action onSaving;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060003A5 RID: 933 RVA: 0x00013774 File Offset: 0x00011974
		// (remove) Token: 0x060003A6 RID: 934 RVA: 0x000137AC File Offset: 0x000119AC
		public event Action onCheckAgencyInfo;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060003A7 RID: 935 RVA: 0x000137E4 File Offset: 0x000119E4
		// (remove) Token: 0x060003A8 RID: 936 RVA: 0x0001381C File Offset: 0x00011A1C
		public event Action onCheckModelAssignments;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060003A9 RID: 937 RVA: 0x00013854 File Offset: 0x00011A54
		// (remove) Token: 0x060003AA RID: 938 RVA: 0x0001388C File Offset: 0x00011A8C
		public event Action onRest;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060003AB RID: 939 RVA: 0x000138C4 File Offset: 0x00011AC4
		// (remove) Token: 0x060003AC RID: 940 RVA: 0x000138FC File Offset: 0x00011AFC
		public event Action onDisplayHired;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060003AD RID: 941 RVA: 0x00013934 File Offset: 0x00011B34
		// (remove) Token: 0x060003AE RID: 942 RVA: 0x0001396C File Offset: 0x00011B6C
		public event Action onImport;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060003AF RID: 943 RVA: 0x000139A4 File Offset: 0x00011BA4
		// (remove) Token: 0x060003B0 RID: 944 RVA: 0x000139DC File Offset: 0x00011BDC
		public event Action onShowMyInfo;

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00013A11 File Offset: 0x00011C11
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x00013A19 File Offset: 0x00011C19
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

		// Token: 0x060003B3 RID: 947 RVA: 0x00013A22 File Offset: 0x00011C22
		[Label("Launch Recruitment Campaign", "US")]
		[Descripcion("-Write and publish a job ad.", "US")]
		[Descripcion("-You can choose the budget for the job advertisement.", "US")]
		[AccionName("StartRecruitment")]
		[ClickableLabelDescriptable(confirmar = false)]
		[ConfirmablePregunta("Do you really want to launch recruitment campaign?", "US")]
		public void StartRecruitment()
		{
			Action action = this.onStartRecruitment;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00013A34 File Offset: 0x00011C34
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

		// Token: 0x060003B5 RID: 949 RVA: 0x00013A46 File Offset: 0x00011C46
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

		// Token: 0x060003B6 RID: 950 RVA: 0x00013A58 File Offset: 0x00011C58
		[Separador(height = 15)]
		[Label("Agency Info", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		[Descripcion("Check out the responses from other agencies to the models you sent them.", "US")]
		[Descripcion("See if any other agencies are interested in collaborating with yours.", "US")]
		public void CheckEmail()
		{
			Action action = this.onCheckAgencyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00013A6A File Offset: 0x00011C6A
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

		// Token: 0x060003B8 RID: 952 RVA: 0x00013A7C File Offset: 0x00011C7C
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

		// Token: 0x060003B9 RID: 953 RVA: 0x00013A8E File Offset: 0x00011C8E
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

		// Token: 0x060003BA RID: 954 RVA: 0x00013AA0 File Offset: 0x00011CA0
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

		// Token: 0x060003BB RID: 955 RVA: 0x00013AB2 File Offset: 0x00011CB2
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

		// Token: 0x060003BC RID: 956 RVA: 0x00013AC4 File Offset: 0x00011CC4
		private bool IsRest()
		{
			return !this.isLastWorkSchedule();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00013AD4 File Offset: 0x00011CD4
		private bool IsGoHome()
		{
			return this.isLastWorkSchedule();
		}

		// Token: 0x0400018F RID: 399
		public Func<bool> isLastWorkSchedule;

		// Token: 0x04000198 RID: 408
		[SerializeField]
		private bool m_existenModelosContratadas;
	}
}

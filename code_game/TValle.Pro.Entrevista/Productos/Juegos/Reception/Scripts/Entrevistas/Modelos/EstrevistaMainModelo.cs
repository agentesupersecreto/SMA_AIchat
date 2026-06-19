using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000010 RID: 16
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Panel(width = 550, height = 750)]
	[Modelo]
	[Serializable]
	public class EstrevistaMainModelo
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000A7 RID: 167 RVA: 0x00004BBC File Offset: 0x00002DBC
		// (remove) Token: 0x060000A8 RID: 168 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public event Action<EstrevistaMainModelo> onStartRating;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000A9 RID: 169 RVA: 0x00004C2C File Offset: 0x00002E2C
		// (remove) Token: 0x060000AA RID: 170 RVA: 0x00004C64 File Offset: 0x00002E64
		public event Action<EstrevistaMainModelo> onStartContacting;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000AB RID: 171 RVA: 0x00004C9C File Offset: 0x00002E9C
		// (remove) Token: 0x060000AC RID: 172 RVA: 0x00004CD4 File Offset: 0x00002ED4
		public event Action<EstrevistaMainModelo> onShowModelInfo;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000AD RID: 173 RVA: 0x00004D0C File Offset: 0x00002F0C
		// (remove) Token: 0x060000AE RID: 174 RVA: 0x00004D44 File Offset: 0x00002F44
		public event Action<EstrevistaMainModelo> onStartHiring;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000AF RID: 175 RVA: 0x00004D7C File Offset: 0x00002F7C
		// (remove) Token: 0x060000B0 RID: 176 RVA: 0x00004DB4 File Offset: 0x00002FB4
		public event Action<EstrevistaMainModelo> onDispatchHerClicked;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000B1 RID: 177 RVA: 0x00004DEC File Offset: 0x00002FEC
		// (remove) Token: 0x060000B2 RID: 178 RVA: 0x00004E24 File Offset: 0x00003024
		public event Action onCheckAgencyInfo;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060000B3 RID: 179 RVA: 0x00004E5C File Offset: 0x0000305C
		// (remove) Token: 0x060000B4 RID: 180 RVA: 0x00004E94 File Offset: 0x00003094
		public event Action onShowMyInfo;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00004EC9 File Offset: 0x000030C9
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00004ED1 File Offset: 0x000030D1
		[ActivatedDelegates(para = "StartRating")]
		public bool femaleCharacterCanBeRated
		{
			get
			{
				return this.m_modeloEsDeCampaing;
			}
			set
			{
				this.m_modeloEsDeCampaing = value;
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004EDA File Offset: 0x000030DA
		[Label("Model Resume", "US")]
		[Descripcion("-View detailed information about the model.", "US")]
		[AccionName("ShowModelCurriculum")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void ShowInfo()
		{
			Action<EstrevistaMainModelo> action = this.onShowModelInfo;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004EED File Offset: 0x000030ED
		[ClickableLabelDescriptable(confirmar = false)]
		[Label("My Info", "US")]
		[Descripcion("-Click here to see some information about the Main Hero.", "US")]
		public void ShowMyInfo()
		{
			Action action = this.onShowMyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004EFF File Offset: 0x000030FF
		[Separador(height = 15)]
		[DescripcionDinamica]
		[Label("Contact her with agency", "US")]
		[Descripcion("-Earns commissions by contacting her with some \"modeling\" agency.", "US")]
		[AccionName("StartContactingFemale")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void StartContacting()
		{
			Action<EstrevistaMainModelo> action = this.onStartContacting;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004F12 File Offset: 0x00003112
		[Label("Hire Her", "US")]
		[Descripcion("-Earns commissions through our customers.", "US")]
		[Descripcion("-<B>WARNING</B>: The current campaign will end if a model is hired.", "US")]
		[AccionName("StartHiringFemale")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("Are you sure you want to hire this model and terminate the current campaign?", "US")]
		public void StartHiring()
		{
			Action<EstrevistaMainModelo> action = this.onStartHiring;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004F25 File Offset: 0x00003125
		[Label("Dispatch her", "US")]
		[Descripcion("-Tell her to leave.", "US")]
		[AccionName("DispatchFemale")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("Are you sure you want her to leave?", "US")]
		public void DispatchHer()
		{
			Action<EstrevistaMainModelo> action = this.onDispatchHerClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004F38 File Offset: 0x00003138
		[Separador(height = 15)]
		[Label("Rating Adjustments", "US")]
		[Descripcion("-Manually adjust model ratings for attributes. This panel allows you to override based on your own evaluation.", "US")]
		[Descripcion("-If you select 'Next Phase' for the current campaign, the new models in that phase will be more (increasing scores) or less (decreasing scores) similar to this model.", "US")]
		[AccionName("StartRatingFemale")]
		[ClickableLabelDescriptable(confirmar = false, enabled = false)]
		public void StartRating()
		{
			Action<EstrevistaMainModelo> action = this.onStartRating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004F4B File Offset: 0x0000314B
		[Separador(height = 15)]
		[Label("Agency Info", "US")]
		[ClickableLabelDescriptable(confirmar = false)]
		[Descripcion("Check out the responses from other agencies to the models you sent them.", "US")]
		[Descripcion("See if any other agencies are interested in collaborating with yours.", "US")]
		public void CheckEmail()
		{
			Debug.LogError("esto se tiene q separar, debe haber una ui para economia y otra para emails");
			Action action = this.onCheckAgencyInfo;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004F68 File Offset: 0x00003168
		[ConfirmableListener(member = "DispatchHer")]
		public bool ConfirmarDispatchHer(out string msg)
		{
			Func<bool> func = this.confirmarDispatchHerDelegate;
			if (((func != null) ? new bool?(func()) : null).GetValueOrDefault())
			{
				msg = "<B>Do you really want her to leave, without rating her first?</B>\n<i><size=11>It is Ok To Ignore, the minimum score will be assigned automatically.</size></i>";
				return true;
			}
			msg = null;
			return true;
		}

		// Token: 0x0400006E RID: 110
		public Func<bool> confirmarDispatchHerDelegate;

		// Token: 0x0400006F RID: 111
		[SerializeField]
		private bool m_modeloEsDeCampaing;
	}
}

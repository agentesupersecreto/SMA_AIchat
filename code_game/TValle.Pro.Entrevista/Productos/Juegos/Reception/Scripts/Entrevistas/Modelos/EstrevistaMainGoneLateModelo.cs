using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000012 RID: 18
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Modelo]
	[Serializable]
	public class EstrevistaMainGoneLateModelo
	{
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060000CD RID: 205 RVA: 0x0000518C File Offset: 0x0000338C
		// (remove) Token: 0x060000CE RID: 206 RVA: 0x000051C4 File Offset: 0x000033C4
		public event Action<EstrevistaMainGoneLateModelo> onStartRating;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060000CF RID: 207 RVA: 0x000051FC File Offset: 0x000033FC
		// (remove) Token: 0x060000D0 RID: 208 RVA: 0x00005234 File Offset: 0x00003434
		public event Action<EstrevistaMainGoneLateModelo> onGoingHome;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060000D1 RID: 209 RVA: 0x0000526C File Offset: 0x0000346C
		// (remove) Token: 0x060000D2 RID: 210 RVA: 0x000052A4 File Offset: 0x000034A4
		public event Action onShowMyInfo;

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000052D9 File Offset: 0x000034D9
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x000052E1 File Offset: 0x000034E1
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

		// Token: 0x060000D5 RID: 213 RVA: 0x000052EA File Offset: 0x000034EA
		[Label("Rating Adjustments", "US")]
		[Descripcion("-Manually adjust model ratings for attributes. This panel allows you to override based on your own evaluation.", "US")]
		[Descripcion("-If you select 'Next Phase' for the current campaign, the new models in that phase will be more (increasing scores) or less (decreasing scores) similar to this model.", "US")]
		[AccionName("StartRatingFemale")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void StartRating()
		{
			Action<EstrevistaMainGoneLateModelo> action = this.onStartRating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000052FD File Offset: 0x000034FD
		[Label("Go Home", "US")]
		[Descripcion("-Rest at home till next appointment.", "US")]
		[AccionName("RestingTillNextDate")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("<B>Do you really want to go home without rating her?</B>\n<i><size=11>It is Ok To Ignore, the minimum score will be assigned automatically.</size></i>", "US")]
		public void GoHome()
		{
			Action<EstrevistaMainGoneLateModelo> action = this.onGoingHome;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005310 File Offset: 0x00003510
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

		// Token: 0x060000D8 RID: 216 RVA: 0x00005324 File Offset: 0x00003524
		[ConfirmableListener(member = "GoHome")]
		public bool ConfirmarGoHome(out string msg)
		{
			msg = null;
			Func<bool> func = this.confirmarGoHomeDelegate;
			return ((func != null) ? new bool?(func()) : null).GetValueOrDefault();
		}

		// Token: 0x04000077 RID: 119
		public Func<bool> confirmarGoHomeDelegate;

		// Token: 0x04000079 RID: 121
		[SerializeField]
		private bool m_modeloEsDeCampaing;
	}
}

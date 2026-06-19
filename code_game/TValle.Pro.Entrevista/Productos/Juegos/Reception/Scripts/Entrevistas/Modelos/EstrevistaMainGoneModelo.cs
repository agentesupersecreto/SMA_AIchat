using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000011 RID: 17
	[Label("Agency Hub", "US", fontStyle = FontStyles.Normal, alignment = TextAlignmentOptions.TopLeft)]
	[Cerrable(accion = CerrableAttribute.Accion.ocultar)]
	[Modelo]
	[Serializable]
	public class EstrevistaMainGoneModelo
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060000C0 RID: 192 RVA: 0x00004FB4 File Offset: 0x000031B4
		// (remove) Token: 0x060000C1 RID: 193 RVA: 0x00004FEC File Offset: 0x000031EC
		public event Action<EstrevistaMainGoneModelo> onStartRating;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060000C2 RID: 194 RVA: 0x00005024 File Offset: 0x00003224
		// (remove) Token: 0x060000C3 RID: 195 RVA: 0x0000505C File Offset: 0x0000325C
		public event Action<EstrevistaMainGoneModelo> onResting;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060000C4 RID: 196 RVA: 0x00005094 File Offset: 0x00003294
		// (remove) Token: 0x060000C5 RID: 197 RVA: 0x000050CC File Offset: 0x000032CC
		public event Action onShowMyInfo;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00005101 File Offset: 0x00003301
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00005109 File Offset: 0x00003309
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

		// Token: 0x060000C8 RID: 200 RVA: 0x00005112 File Offset: 0x00003312
		[Label("Rating Adjustments", "US")]
		[Descripcion("-Manually adjust model ratings for attributes. This panel allows you to override based on your own evaluation.", "US")]
		[Descripcion("-If you select 'Next Phase' for the current campaign, the new models in that phase will be more (increasing scores) or less (decreasing scores) similar to this model.", "US")]
		[AccionName("StartRatingFemale")]
		[ClickableLabelDescriptable(confirmar = false)]
		public void StartRating()
		{
			Action<EstrevistaMainGoneModelo> action = this.onStartRating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005125 File Offset: 0x00003325
		[Label("Rest for a while", "US")]
		[Descripcion("-Rest till next appointment.", "US")]
		[AccionName("RestingTillNextDate")]
		[ClickableLabelDescriptable(confirmar = true)]
		[ConfirmablePregunta("<B>Do you really want to rest without rating her?</B>\n<i><size=11>It is Ok To Ignore, the minimum score will be assigned automatically.</size></i>", "US")]
		public void OnRest()
		{
			Action<EstrevistaMainGoneModelo> action = this.onResting;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005138 File Offset: 0x00003338
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

		// Token: 0x060000CB RID: 203 RVA: 0x0000514C File Offset: 0x0000334C
		[ConfirmableListener(member = "OnRest")]
		public bool ConfirmarOnRest(out string msg)
		{
			msg = null;
			Func<bool> func = this.confirmarOnRestDelegate;
			return ((func != null) ? new bool?(func()) : null).GetValueOrDefault();
		}

		// Token: 0x04000072 RID: 114
		public Func<bool> confirmarOnRestDelegate;

		// Token: 0x04000074 RID: 116
		[SerializeField]
		private bool m_modeloEsDeCampaing;
	}
}

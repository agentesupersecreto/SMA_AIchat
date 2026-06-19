using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos
{
	// Token: 0x02000155 RID: 341
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.TopLeft, fontStyle = FontStyles.Normal)]
	[Panel(width = 550, height = 750, childForceExpandHeight = true, childForceExpandWidth = true, controlChildWidth = true, unlockFlexibleIfWidthWasSet = true, unlockParentFlexibleIfWidthWasSet = true)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class CurriculumVitaeModelo : BindableModel
	{
		// Token: 0x06000A05 RID: 2565 RVA: 0x000214B3 File Offset: 0x0001F6B3
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x06000A06 RID: 2566 RVA: 0x000214BC File Offset: 0x0001F6BC
		// (remove) Token: 0x06000A07 RID: 2567 RVA: 0x000214F4 File Offset: 0x0001F6F4
		public event Action<CurriculumVitaeModelo> accion1;

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x06000A08 RID: 2568 RVA: 0x0002152C File Offset: 0x0001F72C
		// (remove) Token: 0x06000A09 RID: 2569 RVA: 0x00021564 File Offset: 0x0001F764
		public event Action<CurriculumVitaeModelo> accion2;

		// Token: 0x06000A0A RID: 2570 RVA: 0x00021599 File Offset: 0x0001F799
		public string GetAccion1Label()
		{
			return this.accion1Label;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x000215A1 File Offset: 0x0001F7A1
		public string GetAccion2Label()
		{
			return this.accion2Label;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000215A9 File Offset: 0x0001F7A9
		[Order(3)]
		[IgnoreIf(method = "Action1Exist")]
		[BotonDePanelConfirmable(confirmar = true)]
		[LabelDinamico(dinamicoMethodTarget = "GetAccion1Label")]
		[AccionName("ACCION 1 Curriculum")]
		[ConfirmablePregunta("Are you sure you want to do this?", "US")]
		public void Accion1()
		{
			Action<CurriculumVitaeModelo> action = this.accion1;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x000215BC File Offset: 0x0001F7BC
		[Order(4)]
		[IgnoreIf(method = "Action2Exist")]
		[BotonDePanelConfirmable(confirmar = true)]
		[LabelDinamico(dinamicoMethodTarget = "GetAccion2Label")]
		[AccionName("ACCION 2 Curriculum")]
		[ConfirmablePregunta("Are you sure you want to do this?", "US")]
		public void Accion2()
		{
			Action<CurriculumVitaeModelo> action = this.accion2;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x000215CF File Offset: 0x0001F7CF
		[ConfirmableListener(member = "Accion1")]
		protected bool Accion1ConfirmacionDelegado(out string pregunta)
		{
			if (!string.IsNullOrWhiteSpace(this.accion1ConfirmacionPregunta))
			{
				pregunta = this.accion1ConfirmacionPregunta;
			}
			else
			{
				pregunta = null;
			}
			return !string.IsNullOrWhiteSpace(pregunta);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x000215F5 File Offset: 0x0001F7F5
		[ConfirmableListener(member = "Accion2")]
		protected bool Accion2ConfirmacionDelegado(out string pregunta)
		{
			if (!string.IsNullOrWhiteSpace(this.accion2ConfirmacionPregunta))
			{
				pregunta = this.accion2ConfirmacionPregunta;
			}
			else
			{
				pregunta = null;
			}
			return !string.IsNullOrWhiteSpace(pregunta);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0002161B File Offset: 0x0001F81B
		private bool Action1Exist()
		{
			return string.IsNullOrWhiteSpace(this.accion1Label);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00021628 File Offset: 0x0001F828
		private bool Action2Exist()
		{
			return string.IsNullOrWhiteSpace(this.accion2Label);
		}

		// Token: 0x04000402 RID: 1026
		[Ignore]
		public string title = "Curriculum";

		// Token: 0x04000403 RID: 1027
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public CurriculumVitaeModeloPortrait portrait = new CurriculumVitaeModeloPortrait();

		// Token: 0x04000404 RID: 1028
		[Modelo]
		[ParentPanelTarget(index = 0)]
		public CurriculumVitaeModeloInfo info = new CurriculumVitaeModeloInfo();

		// Token: 0x04000407 RID: 1031
		[Ignore]
		public string accion1Label = string.Empty;

		// Token: 0x04000408 RID: 1032
		[Ignore]
		public string accion1ConfirmacionPregunta;

		// Token: 0x04000409 RID: 1033
		[Ignore]
		public string accion2Label = string.Empty;

		// Token: 0x0400040A RID: 1034
		[Ignore]
		public string accion2ConfirmacionPregunta;
	}
}

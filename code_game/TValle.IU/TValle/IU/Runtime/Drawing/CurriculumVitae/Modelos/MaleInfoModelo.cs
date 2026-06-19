using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using TMPro;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos
{
	// Token: 0x02000158 RID: 344
	[Modelo]
	[LabelDinamico(dinamicoMethodTarget = "GetTittle")]
	[FontProConfigUI(alignment = TextAlignmentOptions.TopLeft, fontStyle = FontStyles.Normal)]
	[Panel(width = 550, height = 750)]
	[Cerrable(accion = CerrableAttribute.Accion.destruir)]
	[Serializable]
	public class MaleInfoModelo : BindableModel
	{
		// Token: 0x06000A15 RID: 2581 RVA: 0x0002169A File Offset: 0x0001F89A
		public string GetTittle()
		{
			return this.title;
		}

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06000A16 RID: 2582 RVA: 0x000216A4 File Offset: 0x0001F8A4
		// (remove) Token: 0x06000A17 RID: 2583 RVA: 0x000216DC File Offset: 0x0001F8DC
		public event Action<MaleInfoModelo> accion1;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06000A18 RID: 2584 RVA: 0x00021714 File Offset: 0x0001F914
		// (remove) Token: 0x06000A19 RID: 2585 RVA: 0x0002174C File Offset: 0x0001F94C
		public event Action<MaleInfoModelo> accion2;

		// Token: 0x06000A1A RID: 2586 RVA: 0x00021781 File Offset: 0x0001F981
		public bool IsAccion1Enabled()
		{
			return string.IsNullOrWhiteSpace(this.accion1Label);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0002178E File Offset: 0x0001F98E
		public string GetAccion1Label()
		{
			return this.accion1Label;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00021796 File Offset: 0x0001F996
		public bool IsAccion2Enabled()
		{
			return string.IsNullOrWhiteSpace(this.accion2Label);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x000217A3 File Offset: 0x0001F9A3
		public string GetAccion2Label()
		{
			return this.accion2Label;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000217AB File Offset: 0x0001F9AB
		[Order(3)]
		[IgnoreIf(method = "IsAccion1Enabled")]
		[BotonDePanelConfirmable(confirmar = true)]
		[LabelDinamico(dinamicoMethodTarget = "GetAccion1Label")]
		[AccionName("ACCION 1 Curriculum")]
		[ConfirmablePregunta("Are you sure you want to do this?", "US")]
		public void Accion1()
		{
			Action<MaleInfoModelo> action = this.accion1;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000217BE File Offset: 0x0001F9BE
		[Order(4)]
		[IgnoreIf(method = "IsAccion2Enabled")]
		[BotonDePanelConfirmable(confirmar = true)]
		[LabelDinamico(dinamicoMethodTarget = "GetAccion2Label")]
		[AccionName("ACCION 2 Curriculum")]
		[ConfirmablePregunta("Are you sure you want to do this?", "US")]
		public void Accion2()
		{
			Action<MaleInfoModelo> action = this.accion2;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000217D1 File Offset: 0x0001F9D1
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

		// Token: 0x06000A21 RID: 2593 RVA: 0x000217F7 File Offset: 0x0001F9F7
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

		// Token: 0x0400041B RID: 1051
		[Ignore]
		public string title = "Curriculum";

		// Token: 0x0400041C RID: 1052
		[Label("Name", "US")]
		[InfoLabel]
		public string name = "test 1";

		// Token: 0x0400041D RID: 1053
		[Label("Last Name", "US")]
		[InfoLabel]
		public string lastName = "test 2";

		// Token: 0x0400041E RID: 1054
		[Label("Age", "US")]
		[InfoLabel]
		public string age;

		// Token: 0x0400041F RID: 1055
		[Label("Sex", "US")]
		[InfoLabel]
		public string sex;

		// Token: 0x04000420 RID: 1056
		[Label("Height", "US")]
		[InfoLabel]
		public string height;

		// Token: 0x04000421 RID: 1057
		[Label("Weight", "US")]
		[InfoLabel]
		public string weight;

		// Token: 0x04000422 RID: 1058
		[Label("Body Fat", "US")]
		[InfoLabel]
		public string bodyfat;

		// Token: 0x04000423 RID: 1059
		[Label("Current Length", "US")]
		[InfoLabel]
		public string currentLength;

		// Token: 0x04000424 RID: 1060
		[Label("Current Girth", "US")]
		[InfoLabel]
		public string currentGirth;

		// Token: 0x04000427 RID: 1063
		[Ignore]
		public string accion1Label = string.Empty;

		// Token: 0x04000428 RID: 1064
		[Ignore]
		public string accion1ConfirmacionPregunta;

		// Token: 0x04000429 RID: 1065
		[Ignore]
		public string accion2Label = string.Empty;

		// Token: 0x0400042A RID: 1066
		[Ignore]
		public string accion2ConfirmacionPregunta;
	}
}

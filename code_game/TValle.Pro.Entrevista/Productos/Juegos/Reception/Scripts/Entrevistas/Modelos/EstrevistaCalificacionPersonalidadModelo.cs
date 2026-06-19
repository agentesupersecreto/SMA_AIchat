using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x02000015 RID: 21
	[Modelo]
	[Serializable]
	public class EstrevistaCalificacionPersonalidadModelo
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000ED RID: 237 RVA: 0x0000567C File Offset: 0x0000387C
		public bool isDefaultValues
		{
			get
			{
				return this.angerManagement == 0f && this.painTolerance == 0f && this.slutness == 0f && this.exhibitionism == 0f && this.servicing == 0f && this.summarizing == PersonalidadConsenting.no;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000056D8 File Offset: 0x000038D8
		public void GetScore(IDictionary<string, float> resultado)
		{
			resultado.AddOrReplase("angerManagement", Mathf.Clamp(this.angerManagement / 10f, 0f, 1f));
			resultado.AddOrReplase("painTolerance", Mathf.Clamp(this.painTolerance / 10f, 0f, 1f));
			resultado.AddOrReplase("slutness", Mathf.Clamp(this.slutness / 10f, 0f, 1f));
			resultado.AddOrReplase("exhibitionism", Mathf.Clamp(this.exhibitionism / 10f, 0f, 1f));
			resultado.AddOrReplase("servicing", Mathf.Clamp(this.servicing / 10f, 0f, 1f));
			float num = 0f;
			num += (float)this.summarizing;
			num /= 4f;
			num = Mathf.Clamp(num, 0f, 1f);
			resultado.AddOrReplase("summarizing", num);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000057D8 File Offset: 0x000039D8
		public void SetScore(IReadOnlyDictionary<string, IConjuntoDeGenes> data)
		{
			this.angerManagement = (float)Mathf.RoundToInt(data["angerManagement"].fitnes * 10f);
			this.painTolerance = (float)Mathf.RoundToInt(data["painTolerance"].fitnes * 10f);
			this.slutness = (float)Mathf.RoundToInt(data["slutness"].fitnes * 10f);
			this.exhibitionism = (float)Mathf.RoundToInt(data["exhibitionism"].fitnes * 10f);
			this.servicing = (float)Mathf.RoundToInt(data["servicing"].fitnes * 10f);
			this.summarizing = (PersonalidadConsenting)Mathf.RoundToInt(data["summarizing"].fitnes * 4f);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000058B0 File Offset: 0x00003AB0
		private string ShowGuide_angerManagement(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Anger Management</I></B>. The score for attributes:\n - <B><I>Anger Gain.</I></B> (All interactions)\n - <B><I>Anger Gain</I></B> vs Horniness.\n - <B><I>Favorability</I></B> by hero's Appearance / Responses.";
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000058BE File Offset: 0x00003ABE
		private string ShowGuide_painTolerance(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Pain Tolerance</I></B>. The score for attributes:\n - <B><I>Pain Gain.</I></B> (All interactions)\n - <B><I>Pain Gain</I></B> Modifiers for each Body Part.\n - <B><I>Pain Gain</I></B> vs Pleasure.\n - <B><I>Pain Gain</I></B> vs Horniness.";
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000058CC File Offset: 0x00003ACC
		private string ShowGuide_slutness(out float widthMod, int index)
		{
			widthMod = 2f;
			return "<B><I>Horniness</I></B>. The score for attributes:\n - <B><I>Pleasure Gain.</I></B> (All interactions)\n - <B><I>Favorability Gain.</I></B>\n - <B><I>Max Pleasure</I></B> for each Body Part.\n - <B><I>Max Pleasure</I></B> for each Body Part vs Horniness(emotion).\n - <B><I>Favorability Requirement</I></B> (Looking at Hero's Body) for each Body Part.\n - <B><I>Favorability Requirement</I></B> (Fondling) for each Body Part.\n - <B><I>Favorability Requirement</I></B> (Forcing Undress).\n - <B><I>Favorability Requirement</I></B> (Forcing Pose).\n - <B><I>Favorability Requirement</I></B> (Sex) for each \"Body Part\".\n - <B><I>Favorability Requirement</I></B> vs Horniness.";
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000058DA File Offset: 0x00003ADA
		private string ShowGuide_exhibitionism(out float widthMod, int index)
		{
			widthMod = 2f;
			return "<B><I>Exhibitionism</I></B>. The score for attributes:\n - <B><I>Favorability Requirement</I></B> (Being Watched by Hero) for each Body Part.\n - <B><I>Favorability Requirement</I></B> (Asking Undress).\n - <B><I>Favorability Requirement</I></B> (Asking Pose).";
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000058E8 File Offset: 0x00003AE8
		private string ShowGuide_servicing(out float widthMod, int index)
		{
			widthMod = 1.5f;
			return "<B><I>Servicing</I></B>. The score for attributes:\n - <B><I>Desire Initial:</I></B> Oral, Vaginal, Anal.\n - <B><I>Desire Gain:</I></B> Oral, Vaginal, Anal.\n - <B><I>Desire Gain by each Stimulus Type:</I></B> Oral, Vaginal, Anal.";
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000058F6 File Offset: 0x00003AF6
		private string ShowGuide_summarizing(out float widthMod, int index)
		{
			widthMod = 2f;
			return "<B><I>Ignoring her looks:</I></B> Do you think she is fit for a \"modeling\" career?\n - Minor aspects of the personality, such as rudeness, submission, etc.\n";
		}

		// Token: 0x04000081 RID: 129
		[Label("Anger Management", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_angerManagement")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float angerManagement;

		// Token: 0x04000082 RID: 130
		[Label("Pain Tolerance", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_painTolerance")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float painTolerance;

		// Token: 0x04000083 RID: 131
		[Label("Horniness", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_slutness")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float slutness;

		// Token: 0x04000084 RID: 132
		[Label("Exhibitionism", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_exhibitionism")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float exhibitionism;

		// Token: 0x04000085 RID: 133
		[Label("Servicing", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_servicing")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float servicing;

		// Token: 0x04000086 RID: 134
		[Label("Qualified For \"Modeling\"", "US", fontSizeMod = 0.9f)]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_summarizing")]
		[DesplegableConToolTip]
		public PersonalidadConsenting summarizing;
	}
}

using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x0200000F RID: 15
	[Modelo]
	[Serializable]
	public class EstrevistaCalificacionAparienciaFisicaModelo
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000090 RID: 144 RVA: 0x00004524 File Offset: 0x00002724
		// (remove) Token: 0x06000091 RID: 145 RVA: 0x0000455C File Offset: 0x0000275C
		public event Action<EstrevistaCalificacionAparienciaFisicaModelo> onOverallChanging;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000092 RID: 146 RVA: 0x00004594 File Offset: 0x00002794
		// (remove) Token: 0x06000093 RID: 147 RVA: 0x000045CC File Offset: 0x000027CC
		public event Action<EstrevistaCalificacionAparienciaFisicaModelo> onOverallChanged;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004604 File Offset: 0x00002804
		public bool isDefaultValues
		{
			get
			{
				return this.height == 0f && this.body == 0f && this.skin == 0f && this.hair == 0f && this.head == 0f && this.face == 0f && this.eyes == 0f && this.nose == 0f && this.mouth == 0f && this.breast == 0f && this.arms == 0f && this.waist_hip == 0f && this.crotch == 0f && this.buttocks == 0f && this.legs == 0f;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000046E8 File Offset: 0x000028E8
		public void GetScore(IDictionary<string, float> resultado)
		{
			resultado.AddOrReplase("height", Mathf.Clamp(this.height / 10f, 0f, 1f));
			resultado.AddOrReplase("body", Mathf.Clamp(this.body / 10f, 0f, 1f));
			resultado.AddOrReplase("skin", Mathf.Clamp(this.skin / 10f, 0f, 1f));
			resultado.AddOrReplase("hair", Mathf.Clamp(this.hair / 10f, 0f, 1f));
			resultado.AddOrReplase("head", Mathf.Clamp(this.head / 10f, 0f, 1f));
			resultado.AddOrReplase("face", Mathf.Clamp(this.face / 10f, 0f, 1f));
			resultado.AddOrReplase("eyes", Mathf.Clamp(this.eyes / 10f, 0f, 1f));
			resultado.AddOrReplase("nose", Mathf.Clamp(this.nose / 10f, 0f, 1f));
			resultado.AddOrReplase("mouth", Mathf.Clamp(this.mouth / 10f, 0f, 1f));
			resultado.AddOrReplase("breast", Mathf.Clamp(this.breast / 10f, 0f, 1f));
			resultado.AddOrReplase("arms", Mathf.Clamp(this.arms / 10f, 0f, 1f));
			resultado.AddOrReplase("waist_hip", Mathf.Clamp(this.waist_hip / 10f, 0f, 1f));
			resultado.AddOrReplase("crotch", Mathf.Clamp(this.crotch / 10f, 0f, 1f));
			resultado.AddOrReplase("buttocks", Mathf.Clamp(this.buttocks / 10f, 0f, 1f));
			resultado.AddOrReplase("legs", Mathf.Clamp(this.legs / 10f, 0f, 1f));
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004930 File Offset: 0x00002B30
		public void SetScore(IReadOnlyDictionary<string, IConjuntoDeGenes> data)
		{
			this.height = data["height"].fitnes * 10f;
			this.body = data["body"].fitnes * 10f;
			this.skin = data["skin"].fitnes * 10f;
			this.hair = data["hair"].fitnes * 10f;
			this.head = data["head"].fitnes * 10f;
			this.face = data["face"].fitnes * 10f;
			this.eyes = data["eyes"].fitnes * 10f;
			this.nose = data["nose"].fitnes * 10f;
			this.mouth = data["mouth"].fitnes * 10f;
			this.breast = data["breast"].fitnes * 10f;
			this.arms = data["arms"].fitnes * 10f;
			this.waist_hip = data["waist_hip"].fitnes * 10f;
			this.crotch = data["crotch"].fitnes * 10f;
			this.buttocks = data["buttocks"].fitnes * 10f;
			this.legs = data["legs"].fitnes * 10f;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004AE1 File Offset: 0x00002CE1
		private string ShowGuide_height(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Height</I></B>. The score for attributes:\n - <B><I>Height...</I></B>";
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004AEF File Offset: 0x00002CEF
		private string ShowGuide_body(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Body</I></B>. The score for attributes:\n - <B><I>Body Fat Percentage.</I></B>\n - <B><I>Rib cage thickness. </I></B>";
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004AFD File Offset: 0x00002CFD
		private string ShowGuide_skin(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Skin</I></B>. The score for attributes:\n - <B><I>Skin color.</I></B>\n - <B><I>Skin roughness.</I></B>\n - <B><I>Skin glossiness.</I></B>\n - <B><I>Amount of makeup. (cake face)</I></B>";
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004B0B File Offset: 0x00002D0B
		private string ShowGuide_hair(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Hair</I></B>. The score for attributes:\n - <B><I>Hair color.</I></B>\n - <B><I>Hair curls.</I></B>\n - <B><I>Hair volume.</I></B>\n - <B><I>Pubic Hair color.</I></B>\n - <B><I>Pubic Hair density.</I></B>";
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004B19 File Offset: 0x00002D19
		private string ShowGuide_head(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Head</I></B>. The score for attributes:\n - <B><I>Head size.</I></B>\n - <B><I>Neck thickness.</I></B>\n - <B><I>Neck length.</I></B>\n - <B><I>Forehead shape.</I></B>";
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004B27 File Offset: 0x00002D27
		private string ShowGuide_face(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Face</I></B>. The score for attributes:\n - <B><I>Face shape.</I></B>\n - <B><I>Facial aging.</I></B>\n - <B><I>Cheek shape.</I></B>\n - <B><I>Chin shape.</I></B>\n - <B><I>Jaw shape.</I></B>\n - <B><I>Eyebrow color.</I></B>\n - <B><I>Eyebrow shape.</I></B>";
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004B35 File Offset: 0x00002D35
		private string ShowGuide_eyes(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Eyes</I></B>. The score for attributes:\n - <B><I>Eye size.</I></B>\n - <B><I>Eye position.</I></B>\n - <B><I>Eye shape.</I></B>\n - <B><I>Eyelid shape.</I></B>\n - <B><I>Iris size.</I></B>\n - <B><I>Iris type.</I></B>\n - <B><I>Iris color.</I></B>\n - <B><I>Eyelash shape.</I></B>";
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004B43 File Offset: 0x00002D43
		private string ShowGuide_nose(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Nose</I></B>. The score for attributes:\n - <B><I>Nose size.</I></B>\n - <B><I>Nose position.</I></B>\n - <B><I>Nose shape.</I></B>\n - <B><I>Nostril size.</I></B>\n - <B><I>Nostril shape.</I></B>\n - <B><I>Septum shape.</I></B>";
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004B51 File Offset: 0x00002D51
		private string ShowGuide_mouth(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Mouth</I></B>. The score for attributes:\n - <B><I>Mouth size.</I></B>\n - <B><I>Mouth shape.</I></B>\n - <B><I>Lips size.</I></B>\n - <B><I>Lips shape.</I></B>\n - <B><I>Lips roughness.</I></B>\n - <B><I>Lip groove shape.</I></B>\n - <B><I>Lipstick color.</I></B>\n - <B><I>Lipstick gloss.</I></B>";
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004B5F File Offset: 0x00002D5F
		private string ShowGuide_breast(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Breast</I></B>. The score for attributes:\n - <B><I>Breast size.</I></B>\n - <B><I>Breast position.</I></B>\n - <B><I>Breast shape.</I></B>\n - <B><I>Breast sagginess.</I></B>\n - <B><I>Nipple size.</I></B>\n - <B><I>Nipple color.</I></B>\n - <B><I>Nipple roughness .</I></B>";
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004B6D File Offset: 0x00002D6D
		private string ShowGuide_arms(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Arms</I></B>. The score for attributes:\n - <B><I>Arms thickness.</I></B>\n - <B><I>Forearms thickness.</I></B>\n - <B><I>Hands size.</I></B>\n - <B><I>Fingers position .</I></B>";
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004B7B File Offset: 0x00002D7B
		private string ShowGuide_waist_hip(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Waist-Hip</I></B>. The score for attributes:\n - <B><I>Waist thickness.</I></B>\n - <B><I>Hips shape.</I></B>\n - <B><I>Hips thickness.</I></B>";
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004B89 File Offset: 0x00002D89
		private string ShowGuide_crotch(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Crotch</I></B>. The score for attributes:\n - <B><I>Thigh gap.</I></B>\n - <B><I>Vagina size.</I></B>\n - <B><I>Vagina position.</I></B>\n - <B><I>Vagina shape.</I></B>\n - <B><I>Vagina skin roughness.</I></B>\n - <B><I>Vagina skin color.</I></B>\n - <B><I>Vagina hole initial capacity.</I></B>";
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004B97 File Offset: 0x00002D97
		private string ShowGuide_buttocks(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Buttocks</I></B>. The score for attributes:\n - <B><I>Butt size.</I></B>\n - <B><I>Butt shape.</I></B>\n - <B><I>Butt sagging .</I></B>\n - <B><I>Anus butt gap.</I></B>\n - <B><I>Anus size.</I></B>\n - <B><I>Anus position.</I></B>\n - <B><I>Anus shape.</I></B>\n - <B><I>Anus skin color.</I></B>\n - <B><I>Anus skin roughness.</I></B>\n - <B><I>Anus hole initial capacity.</I></B>";
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004BA5 File Offset: 0x00002DA5
		private string ShowGuide_legs(out float widthMod, int index)
		{
			widthMod = 1f;
			return "<B><I>Legs</I></B>. The score for attributes:\n - <B><I>Thigh thickness.</I></B>\n - <B><I>Calf thickness.</I></B>\n - <B><I>Feet size .</I></B>";
		}

		// Token: 0x04000058 RID: 88
		[Label("Height", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_height")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float height;

		// Token: 0x04000059 RID: 89
		[Label("Body", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_body")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float body;

		// Token: 0x0400005A RID: 90
		[Label("Skin", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_skin")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float skin;

		// Token: 0x0400005B RID: 91
		[Label("Hair", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_hair")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float hair;

		// Token: 0x0400005C RID: 92
		[Label("Head", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_head")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float head;

		// Token: 0x0400005D RID: 93
		[Label("Face", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_face")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float face;

		// Token: 0x0400005E RID: 94
		[Label("Eyes", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_eyes")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float eyes;

		// Token: 0x0400005F RID: 95
		[Label("Nose", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_nose")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float nose;

		// Token: 0x04000060 RID: 96
		[Label("Mouth", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_mouth")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float mouth;

		// Token: 0x04000061 RID: 97
		[Label("Breast", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_breast")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float breast;

		// Token: 0x04000062 RID: 98
		[Label("Arms", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_arms")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float arms;

		// Token: 0x04000063 RID: 99
		[Label("Waist-Hip", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_waist_hip")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float waist_hip;

		// Token: 0x04000064 RID: 100
		[Label("Crotch", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_crotch")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float crotch;

		// Token: 0x04000065 RID: 101
		[Label("Buttocks", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_buttocks")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float buttocks;

		// Token: 0x04000066 RID: 102
		[Label("Legs", "US")]
		[DescripcionDinamica(dinamicoMethodTarget = "ShowGuide_legs")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 10f)]
		public float legs;
	}
}

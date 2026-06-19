using System;
using Assets.Base.Plugins.Runtime.UI;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000057 RID: 87
	[Serializable]
	public struct InterpretacionCompletaDeFemale
	{
		// Token: 0x04000187 RID: 391
		[PanelLayout(alturaMinima = 550f, alturaPreferida = 550f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Personality", "US")]
		public InterpretacionDePersonalidad interpretacionDePersonalidad;

		// Token: 0x04000188 RID: 392
		[PanelLayout(alturaMinima = 1040f, alturaPreferida = 1040f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Desires", "US")]
		public InterpretacionDeGustos interpretacionDeGustos;

		// Token: 0x04000189 RID: 393
		[PanelLayout(alturaMinima = 300f, alturaPreferida = 300f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Hair", "US")]
		public InterpretacionDeHair interpretacionDeHair;

		// Token: 0x0400018A RID: 394
		[PanelLayout(alturaMinima = 230f, alturaPreferida = 230f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Pubic Hair", "US")]
		public InterpretacionDePubicHair interpretacionDePubicHair;

		// Token: 0x0400018B RID: 395
		[PanelLayout(alturaMinima = 560f, alturaPreferida = 560f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Body", "US")]
		public InterpretacionDeBodySuperficial interpretacionDeBodySuperficial;

		// Token: 0x0400018C RID: 396
		[PanelLayout(alturaMinima = 790f, alturaPreferida = 790f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Body Skin", "US")]
		public InterpretacionDeBodySkin interpretacionDeBodySkin;

		// Token: 0x0400018D RID: 397
		[PanelLayout(alturaMinima = 320f, alturaPreferida = 320f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Face", "US")]
		public InterpretacionDeRostro interpretacionDeRostro;

		// Token: 0x0400018E RID: 398
		[PanelLayout(alturaMinima = 530f, alturaPreferida = 530f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Face Skin", "US")]
		public InterpretacionDeFacialSkin interpretacionDeFacialSkin;

		// Token: 0x0400018F RID: 399
		[PanelLayout(alturaMinima = 400f, alturaPreferida = 400f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Eyebrows", "US")]
		public InterpretacionDeEyebrows interpretacionDeEyebrows;

		// Token: 0x04000190 RID: 400
		[PanelLayout(alturaMinima = 850f, alturaPreferida = 850f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Eyes", "US")]
		public InterpretacionDeEyes interpretacionDeEyes;

		// Token: 0x04000191 RID: 401
		[PanelLayout(alturaMinima = 200f, alturaPreferida = 200f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Cheeks", "US")]
		public InterpretacionDeCheeks interpretacionDeCheeks;

		// Token: 0x04000192 RID: 402
		[PanelLayout(alturaMinima = 840f, alturaPreferida = 840f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Nose", "US")]
		public InterpretacionDeNose interpretacionDeNose;

		// Token: 0x04000193 RID: 403
		[PanelLayout(alturaMinima = 1230f, alturaPreferida = 1230f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Mouth", "US")]
		public InterpretacionDeMouth interpretacionDeMouth;

		// Token: 0x04000194 RID: 404
		[PanelLayout(alturaMinima = 480f, alturaPreferida = 480f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Jaw", "US")]
		public InterpretacionDeJaw interpretacionDeJaw;

		// Token: 0x04000195 RID: 405
		[PanelLayout(alturaMinima = 740f, alturaPreferida = 740f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Breasts", "US")]
		public InterpretacionDeSenos interpretacionDeSenos;

		// Token: 0x04000196 RID: 406
		[PanelLayout(alturaMinima = 520f, alturaPreferida = 520f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Buttocks", "US")]
		public InterpretacionDeAss interpretacionDeAss;

		// Token: 0x04000197 RID: 407
		[PanelLayout(alturaMinima = 670f, alturaPreferida = 670f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Vagina", "US")]
		public InterpretacionDeVag interpretacionDeVag;

		// Token: 0x04000198 RID: 408
		[PanelLayout(alturaMinima = 550f, alturaPreferida = 550f)]
		[FontProConfigUI(alignmentUnity = TextAnchor.MiddleRight, fontSize = 20)]
		[Modelo]
		[LabelLocalizado("Anus", "US")]
		public InterpretacionDeAnus interpretacionDeAnus;

		// Token: 0x04000199 RID: 409
		[LabelLocalizado("Demographic Traits", "US")]
		public InterpretacionDeRaza interpretacionDeRaza;
	}
}

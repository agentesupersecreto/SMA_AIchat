using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores.Clases
{
	// Token: 0x0200005B RID: 91
	[Obsolete("devidir en varios", true)]
	public class InterpretadorDePersonalidad
	{
		// Token: 0x0600043A RID: 1082 RVA: 0x0000FCBC File Offset: 0x0000DEBC
		[Obsolete("devidir en varios", true)]
		public static InterpretacionDePersonalidad_DELETE Interpretar(IPersonalidadInterpretadorHelperOLD helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			return new InterpretacionDePersonalidad_DELETE
			{
				vaginalProfundidadQueen = InterpretadorDePersonalidad.VagSizeProfundidad(helper),
				analProfundidadQueen = InterpretadorDePersonalidad.AnoSizeProfundidad(helper),
				oralProfundidadQueen = InterpretadorDePersonalidad.BocaSizeProfundidad(helper),
				vaginalAnchuraQueen = InterpretadorDePersonalidad.VagSizeAnchura(helper),
				analAnchuraQueen = InterpretadorDePersonalidad.AnoSizeAnchura(helper),
				oralAnchuraQueen = InterpretadorDePersonalidad.BocaSizeAnchura(helper),
				vaginalConsent = InterpretadorDePersonalidad.VagConsent(helper),
				analConsent = InterpretadorDePersonalidad.AnalConsent(helper),
				oralConsent = InterpretadorDePersonalidad.OralConsent(helper),
				watchedConsent = InterpretadorDePersonalidad.WatchedConsent(helper),
				watchedPrivatesConsent = InterpretadorDePersonalidad.WatchedPrivatesConsent(helper),
				touchedConsent = InterpretadorDePersonalidad.TouchedConsent(helper),
				touchedPrivatesConsent = InterpretadorDePersonalidad.TouchedPrivatesConsent(helper),
				undressedConsent = InterpretadorDePersonalidad.UndressedConsent(helper),
				undressedPrivatesConsent = InterpretadorDePersonalidad.UndressedPrivatesConsent(helper)
			};
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		private static Interpretacion.Capacidad VagConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.VaginalConsentOffset(0.5f));
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000FDBA File Offset: 0x0000DFBA
		private static Interpretacion.Capacidad AnalConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.AnalConsentOffset(0.45f));
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000FDCC File Offset: 0x0000DFCC
		private static Interpretacion.Capacidad OralConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.OralConsentOffset(0.55f));
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000FDDE File Offset: 0x0000DFDE
		private static Interpretacion.Capacidad WatchedConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.BeingWatchedConsentOffset(0.55f));
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
		private static Interpretacion.Capacidad WatchedPrivatesConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.BeingWatchedInPrivatesConsentOffset(0.45f));
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000FE02 File Offset: 0x0000E002
		private static Interpretacion.Capacidad TouchedConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.BeingTouchedConsentOffset(0.55f));
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x0000FE14 File Offset: 0x0000E014
		private static Interpretacion.Capacidad TouchedPrivatesConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.BeingTouchedInPrivatesConsentOffset(0.45f));
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000FE26 File Offset: 0x0000E026
		private static Interpretacion.Capacidad UndressedConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.UndressConsentOffset(0.55f));
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000FE38 File Offset: 0x0000E038
		private static Interpretacion.Capacidad UndressedPrivatesConsent(IPersonalidadInterpretadorHelperOLD helper)
		{
			return InterpretadorDePersonalidad.GetCapacidadConOffset(helper.UndressPrivatesConsentOffset(0.45f));
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000FE4A File Offset: 0x0000E04A
		private static Interpretacion.Capacidad GetCapacidadConOffset(float offset)
		{
			if (offset >= 1.5f)
			{
				return Interpretacion.Capacidad.veryHigh;
			}
			if (offset >= 1.25f)
			{
				return Interpretacion.Capacidad.high;
			}
			if (offset >= 1f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (offset >= 0.8f)
			{
				return Interpretacion.Capacidad.low;
			}
			return Interpretacion.Capacidad.veryLow;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000FE76 File Offset: 0x0000E076
		private static Interpretacion.Size GetCapacidadConOffsetDeEstados(float[] results)
		{
			if (results[0] < 1f)
			{
				return Interpretacion.Size.veryLarge;
			}
			if (results[1] < 1f)
			{
				return Interpretacion.Size.large;
			}
			if (results[2] < 1f)
			{
				return Interpretacion.Size.normal;
			}
			if (results[3] < 1f)
			{
				return Interpretacion.Size.small;
			}
			return Interpretacion.Size.verySmall;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000FEAA File Offset: 0x0000E0AA
		private static Interpretacion.Size VagSizeProfundidad(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.VaginalProfundidadOffset(0.5f, InterpretadorDePersonalidad.vaginalProfundidades, InterpretadorDePersonalidad.vaginalProfundidadesOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.vaginalProfundidadesOffsetsResult);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000FECB File Offset: 0x0000E0CB
		private static Interpretacion.Size AnoSizeProfundidad(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.AnalProfundidadOffset(0.45f, InterpretadorDePersonalidad.analProfundidades, InterpretadorDePersonalidad.analProfundidadesOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.analProfundidadesOffsetsResult);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000FEEC File Offset: 0x0000E0EC
		private static Interpretacion.Size BocaSizeProfundidad(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.OralProfundidadOffset(0.55f, InterpretadorDePersonalidad.oralProfundidades, InterpretadorDePersonalidad.oralProfundidadesOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.oralProfundidadesOffsetsResult);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000FF0D File Offset: 0x0000E10D
		private static Interpretacion.Size VagSizeAnchura(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.VaginalAnchuraOffset(0.5f, InterpretadorDePersonalidad.vaginalAnchuras, InterpretadorDePersonalidad.vaginalAnchurasOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.vaginalAnchurasOffsetsResult);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000FF2E File Offset: 0x0000E12E
		private static Interpretacion.Size AnoSizeAnchura(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.AnalAnchuraOffset(0.45f, InterpretadorDePersonalidad.analAnchuras, InterpretadorDePersonalidad.analAnchurasOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.analAnchurasOffsetsResult);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000FF4F File Offset: 0x0000E14F
		private static Interpretacion.Size BocaSizeAnchura(IPersonalidadInterpretadorHelperOLD helper)
		{
			helper.OralAnchuraOffset(0.55f, InterpretadorDePersonalidad.oralAnchuras, InterpretadorDePersonalidad.oralAnchurasOffsetsResult);
			return InterpretadorDePersonalidad.GetCapacidadConOffsetDeEstados(InterpretadorDePersonalidad.oralAnchurasOffsetsResult);
		}

		// Token: 0x040001B9 RID: 441
		public const float vaginalSuperSizeQueenProfundidadThresshold = 0.19999999f;

		// Token: 0x040001BA RID: 442
		public const float vaginalSizeQueenProfundidadThresshold = 0.14999999f;

		// Token: 0x040001BB RID: 443
		public const float vaginalSizeNormalProfundidadThresshold = 0.099999994f;

		// Token: 0x040001BC RID: 444
		public const float vaginalSizeSmallProfundidadThresshold = 0.08f;

		// Token: 0x040001BD RID: 445
		public const float vaginalSizeVerySmallProfundidadThresshold = 0.06f;

		// Token: 0x040001BE RID: 446
		public const float analSuperSizeQueenProfundidadThresshold = 0.19999999f;

		// Token: 0x040001BF RID: 447
		public const float analSizeQueenProfundidadThresshold = 0.14999999f;

		// Token: 0x040001C0 RID: 448
		public const float analSizeNormalProfundidadThresshold = 0.099999994f;

		// Token: 0x040001C1 RID: 449
		public const float analSizeSmallProfundidadThresshold = 0.08f;

		// Token: 0x040001C2 RID: 450
		public const float analSizeVerySmallProfundidadThresshold = 0.06f;

		// Token: 0x040001C3 RID: 451
		public const float oralSuperSizeQueenProfundidadThresshold = 0.19999999f;

		// Token: 0x040001C4 RID: 452
		public const float oralSizeQueenProfundidadThresshold = 0.14999999f;

		// Token: 0x040001C5 RID: 453
		public const float oralSizeNormalProfundidadThresshold = 0.099999994f;

		// Token: 0x040001C6 RID: 454
		public const float oralSizeSmallProfundidadThresshold = 0.08f;

		// Token: 0x040001C7 RID: 455
		public const float oralSizeVerySmallProfundidadThresshold = 0.06f;

		// Token: 0x040001C8 RID: 456
		public const float vaginalSuperSizeQueenAnchuraThresshold = 0.049999997f;

		// Token: 0x040001C9 RID: 457
		public const float vaginalSizeQueenAnchuraThresshold = 0.04f;

		// Token: 0x040001CA RID: 458
		public const float vaginalSizeNormalAnchuraThresshold = 0.03f;

		// Token: 0x040001CB RID: 459
		public const float vaginalSizeSmallAnchuraThresshold = 0.0266f;

		// Token: 0x040001CC RID: 460
		public const float vaginalSizeVerySmallAnchuraThresshold = 0.0224f;

		// Token: 0x040001CD RID: 461
		public const float analSuperSizeQueenAnchuraThresshold = 0.049999997f;

		// Token: 0x040001CE RID: 462
		public const float analSizeQueenAnchuraThresshold = 0.04f;

		// Token: 0x040001CF RID: 463
		public const float analSizeNormalAnchuraThresshold = 0.03f;

		// Token: 0x040001D0 RID: 464
		public const float analSizeSmallAnchuraThresshold = 0.0266f;

		// Token: 0x040001D1 RID: 465
		public const float analSizeVerySmallAnchuraThresshold = 0.0224f;

		// Token: 0x040001D2 RID: 466
		public const float oralSuperSizeQueenAnchuraThresshold = 0.049999997f;

		// Token: 0x040001D3 RID: 467
		public const float oralSizeQueenAnchuraThresshold = 0.04f;

		// Token: 0x040001D4 RID: 468
		public const float oralSizeNormalAnchuraThresshold = 0.03f;

		// Token: 0x040001D5 RID: 469
		public const float oralSizeSmallAnchuraThresshold = 0.0266f;

		// Token: 0x040001D6 RID: 470
		public const float oralSizeVerySmallAnchuraThresshold = 0.0224f;

		// Token: 0x040001D7 RID: 471
		public const float vaginalAceptanceMod = 0.5f;

		// Token: 0x040001D8 RID: 472
		public const float analAceptanceMod = 0.45f;

		// Token: 0x040001D9 RID: 473
		public const float oralAceptanceMod = 0.55f;

		// Token: 0x040001DA RID: 474
		public const float beingWatchedAceptanceMod = 0.55f;

		// Token: 0x040001DB RID: 475
		public const float beingWatchedPrivatesAceptanceMod = 0.45f;

		// Token: 0x040001DC RID: 476
		public const float beingTouchedAceptanceMod = 0.55f;

		// Token: 0x040001DD RID: 477
		public const float beingTouchedPrivatesAceptanceMod = 0.45f;

		// Token: 0x040001DE RID: 478
		public const float undressAceptanceMod = 0.55f;

		// Token: 0x040001DF RID: 479
		public const float undressPrivatesAceptanceMod = 0.45f;

		// Token: 0x040001E0 RID: 480
		private static readonly float[] vaginalProfundidades = new float[] { 0.19999999f, 0.14999999f, 0.099999994f, 0.08f, 0.06f };

		// Token: 0x040001E1 RID: 481
		private static readonly float[] analProfundidades = new float[] { 0.19999999f, 0.14999999f, 0.099999994f, 0.08f, 0.06f };

		// Token: 0x040001E2 RID: 482
		private static readonly float[] oralProfundidades = new float[] { 0.19999999f, 0.14999999f, 0.099999994f, 0.08f, 0.06f };

		// Token: 0x040001E3 RID: 483
		private static readonly float[] vaginalAnchuras = new float[] { 0.049999997f, 0.04f, 0.03f, 0.0266f, 0.0224f };

		// Token: 0x040001E4 RID: 484
		private static readonly float[] analAnchuras = new float[] { 0.049999997f, 0.04f, 0.03f, 0.0266f, 0.0224f };

		// Token: 0x040001E5 RID: 485
		private static readonly float[] oralAnchuras = new float[] { 0.049999997f, 0.04f, 0.03f, 0.0266f, 0.0224f };

		// Token: 0x040001E6 RID: 486
		private static readonly float[] vaginalProfundidadesOffsetsResult = new float[5];

		// Token: 0x040001E7 RID: 487
		private static readonly float[] analProfundidadesOffsetsResult = new float[5];

		// Token: 0x040001E8 RID: 488
		private static readonly float[] oralProfundidadesOffsetsResult = new float[5];

		// Token: 0x040001E9 RID: 489
		private static readonly float[] vaginalAnchurasOffsetsResult = new float[5];

		// Token: 0x040001EA RID: 490
		private static readonly float[] analAnchurasOffsetsResult = new float[5];

		// Token: 0x040001EB RID: 491
		private static readonly float[] oralAnchurasOffsetsResult = new float[5];
	}
}

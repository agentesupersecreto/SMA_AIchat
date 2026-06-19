using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200001C RID: 28
	public static class InterpretadorDeBodySkin
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x00003A54 File Offset: 0x00001C54
		public static InterpretacionDeBodySkin Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IBodySkinRangesParaInterpretadores rangosDefaults, IBodySkinRangesParaInterpretadores rangosHelper, IBodySkinInterpretadorHelper bodySkinHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (rangosHelper == null)
			{
				throw new ArgumentNullException("rangosHelper", "rangosHelper null reference.");
			}
			if (rangosDefaults == null)
			{
				throw new ArgumentNullException("rangosDefaults", "rangosDefaults null reference.");
			}
			if (rangosHelper == rangosDefaults)
			{
				throw new InvalidOperationException();
			}
			if (bodySkinHelper == null)
			{
				throw new ArgumentNullException("bodySkinHelper", "bodySkinHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeBodySkin
			{
				skinTone = InterpretadorDeBodySkin.InterpretarTonoPiel(preparedAlteradoresAparienciaDicc),
				tanLines = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(bodySkinHelper.currentSkinTanWeigth, 0.333f),
				uniformity = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(bodySkinHelper.currentSkinUniformity, 0.333f),
				fingerNailColor = InterHelper.InterpretarColor(bodySkinHelper.fingerNailsSinModificaciones),
				toeNailColor = InterHelper.InterpretarColor(bodySkinHelper.toeNailsSinModificaciones),
				difficulty = InterHelper.InterpretarDificultad(rangosDefaults, rangosHelper)
			};
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00003B34 File Offset: 0x00001D34
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeBodySkin interpretacion, out Color fingerNailColor, out Color toeNailColor, out float tanLinesWeigth, out float uniformityWeigth)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 0, InterpretadorDeBodySkin.InterpretarTonoPielInverse_Hue(interpretacion.skinTone), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 1, InterpretadorDeBodySkin.InterpretarTonoPielInverse_Saturation(interpretacion.skinTone), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 2, InterpretadorDeBodySkin.InterpretarTonoPielInverse_Brightness(interpretacion.skinTone), false);
			fingerNailColor = InterHelper.InterpretarColor_Inverse(interpretacion.fingerNailColor);
			toeNailColor = InterHelper.InterpretarColor_Inverse(interpretacion.toeNailColor);
			tanLinesWeigth = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.tanLines);
			uniformityWeigth = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.uniformity);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003BE4 File Offset: 0x00001DE4
		private static float InterpretarTonoPielInverse_Brightness(Interpretacion.SkinTone tono)
		{
			switch (tono)
			{
			case Interpretacion.SkinTone.lightPale:
				return 0.925f;
			case Interpretacion.SkinTone.pale:
				return 0.775f;
			case Interpretacion.SkinTone.olive:
				return 0.775f;
			case Interpretacion.SkinTone.reddish:
				return 0.775f;
			case Interpretacion.SkinTone.paleDark:
				return 0.6f;
			case Interpretacion.SkinTone.brown:
				return 0.41500002f;
			case Interpretacion.SkinTone.darkReddish:
				return 0.41500002f;
			case Interpretacion.SkinTone.lightBlack:
				return 0.41500002f;
			case Interpretacion.SkinTone.black:
				return 0.165f;
			default:
				throw new ArgumentOutOfRangeException(tono.ToString());
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003C68 File Offset: 0x00001E68
		private static float InterpretarTonoPielInverse_Saturation(Interpretacion.SkinTone tono)
		{
			switch (tono)
			{
			case Interpretacion.SkinTone.lightPale:
				return 0.125f;
			case Interpretacion.SkinTone.pale:
				return 0.375f;
			case Interpretacion.SkinTone.olive:
				return 0.625f;
			case Interpretacion.SkinTone.reddish:
				return 0.625f;
			case Interpretacion.SkinTone.paleDark:
				return 0.25f;
			case Interpretacion.SkinTone.brown:
				return 0.833f;
			case Interpretacion.SkinTone.darkReddish:
				return 0.833f;
			case Interpretacion.SkinTone.lightBlack:
				return 0.333f;
			case Interpretacion.SkinTone.black:
				return 0.5f;
			default:
				throw new ArgumentOutOfRangeException(tono.ToString());
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00003CEC File Offset: 0x00001EEC
		private static float InterpretarTonoPielInverse_Hue(Interpretacion.SkinTone tono)
		{
			switch (tono)
			{
			case Interpretacion.SkinTone.lightPale:
				return 0.333f;
			case Interpretacion.SkinTone.pale:
				return 0.333f;
			case Interpretacion.SkinTone.olive:
				return 0.666f;
			case Interpretacion.SkinTone.reddish:
				return 0.166f;
			case Interpretacion.SkinTone.paleDark:
				return 0.333f;
			case Interpretacion.SkinTone.brown:
				return 0.666f;
			case Interpretacion.SkinTone.darkReddish:
				return 0.166f;
			case Interpretacion.SkinTone.lightBlack:
				return 0.333f;
			case Interpretacion.SkinTone.black:
				return 0.333f;
			default:
				throw new ArgumentOutOfRangeException(tono.ToString());
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00003D70 File Offset: 0x00001F70
		private static Interpretacion.SkinTone InterpretarTonoPiel(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 0, false);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 1, false);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel, 2, false);
			if (modDeAlteradorD3 >= 0.85f)
			{
				if (modDeAlteradorD2 <= 0.25f)
				{
					return Interpretacion.SkinTone.lightPale;
				}
				if (modDeAlteradorD2 <= 0.5f)
				{
					return Interpretacion.SkinTone.pale;
				}
				if (modDeAlteradorD >= 0.33f)
				{
					return Interpretacion.SkinTone.olive;
				}
				return Interpretacion.SkinTone.reddish;
			}
			else if (modDeAlteradorD3 >= 0.7f)
			{
				if (modDeAlteradorD >= 0.33f)
				{
					if (modDeAlteradorD2 <= 0.25f)
					{
						return Interpretacion.SkinTone.pale;
					}
					return Interpretacion.SkinTone.olive;
				}
				else
				{
					if (modDeAlteradorD2 <= 0.25f)
					{
						return Interpretacion.SkinTone.pale;
					}
					return Interpretacion.SkinTone.reddish;
				}
			}
			else if (modDeAlteradorD3 >= 0.5f)
			{
				if (modDeAlteradorD >= 0.33f)
				{
					if (modDeAlteradorD2 <= 0.5f)
					{
						return Interpretacion.SkinTone.paleDark;
					}
					return Interpretacion.SkinTone.brown;
				}
				else
				{
					if (modDeAlteradorD2 <= 0.5f)
					{
						return Interpretacion.SkinTone.paleDark;
					}
					return Interpretacion.SkinTone.darkReddish;
				}
			}
			else
			{
				if (modDeAlteradorD3 < 0.33f)
				{
					return Interpretacion.SkinTone.black;
				}
				if (modDeAlteradorD >= 0.33f)
				{
					if (modDeAlteradorD2 <= 0.66f)
					{
						return Interpretacion.SkinTone.lightBlack;
					}
					return Interpretacion.SkinTone.brown;
				}
				else
				{
					if (modDeAlteradorD2 <= 0.66f)
					{
						return Interpretacion.SkinTone.lightBlack;
					}
					return Interpretacion.SkinTone.darkReddish;
				}
			}
		}
	}
}

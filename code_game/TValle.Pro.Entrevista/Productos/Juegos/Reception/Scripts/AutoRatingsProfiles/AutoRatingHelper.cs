using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x0200001A RID: 26
	public static class AutoRatingHelper
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00006080 File Offset: 0x00004280
		public static void Score(ref InterpretacionCompletaDeFemale profile, ref InterpretacionCompletaDeFemale interpretacion, IDictionary<string, float> aparienciaResult, IDictionary<string, float> personalidadResult)
		{
			AutoRatingHelper.InitMapaDeAutoRating();
			Dictionary<string, object> dictionary = new Dictionary<string, object>(AutoRatingHelper.m_ruta_A_Getter.Count);
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>(AutoRatingHelper.m_ruta_A_Getter.Count);
			object obj = profile;
			object obj2 = interpretacion;
			foreach (string text in AutoRatingHelper.m_rutas)
			{
				AutoRatingHelper.LoadValues(dictionary, obj, text, AutoRatingHelper.m_ruta_A_Getter);
				AutoRatingHelper.LoadValues(dictionary2, obj2, text, AutoRatingHelper.m_ruta_A_Getter);
			}
			Dictionary<string, float> dictionary3 = new Dictionary<string, float>(AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones.Count);
			foreach (KeyValuePair<string, AplicaAConjuntoDeFisicoAttribute> keyValuePair in AutoRatingHelper.m_ruta_A_RatingNameTargetApariencia)
			{
				float num = AutoRatingHelper.ScoreEasy(dictionary[keyValuePair.Key], dictionary2[keyValuePair.Key]);
				float num2;
				if (!dictionary3.TryGetValue(keyValuePair.Value.para, out num2))
				{
					num2 = 0f;
					dictionary3.Add(keyValuePair.Value.para, num2);
				}
				dictionary3[keyValuePair.Value.para] = num2 + num * (float)keyValuePair.Value.weigth;
			}
			Dictionary<string, float> dictionary4 = new Dictionary<string, float>(AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones.Count);
			foreach (KeyValuePair<string, AplicaAConjuntoDePersonalidadAttribute> keyValuePair2 in AutoRatingHelper.m_ruta_A_RatingNameTargetPersonalidad)
			{
				float num3 = AutoRatingHelper.ScoreSensible(dictionary[keyValuePair2.Key], dictionary2[keyValuePair2.Key]);
				float num4;
				if (!dictionary4.TryGetValue(keyValuePair2.Value.para, out num4))
				{
					num4 = 0f;
					dictionary4.Add(keyValuePair2.Value.para, num4);
				}
				dictionary4[keyValuePair2.Value.para] = num4 + num3 * (float)keyValuePair2.Value.weigth;
			}
			foreach (KeyValuePair<string, float> keyValuePair3 in dictionary3)
			{
				aparienciaResult.Add(keyValuePair3.Key, keyValuePair3.Value / (float)AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones[keyValuePair3.Key]);
			}
			foreach (KeyValuePair<string, float> keyValuePair4 in dictionary4)
			{
				personalidadResult.Add(keyValuePair4.Key, keyValuePair4.Value / (float)AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones[keyValuePair4.Key]);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00006380 File Offset: 0x00004580
		private static int DiferenciaV2(object profile, object interpretacion)
		{
			int num = Convert.ToInt32(profile);
			int num2 = Convert.ToInt32(interpretacion);
			Mathf.Abs(num);
			Mathf.Abs(num2);
			return Mathf.Abs(num - num2);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000063B0 File Offset: 0x000045B0
		private static int Diferencia(object profile, object interpretacion, out bool overflow)
		{
			int num = Convert.ToInt32(profile);
			int num2 = Convert.ToInt32(interpretacion);
			int num3 = Mathf.Abs(num);
			int num4 = Mathf.Abs(num2);
			int num5 = Mathf.Abs(num - num2);
			overflow = num3 > num4;
			return num5;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000063E8 File Offset: 0x000045E8
		private static float ScoreSensible(object profile, object interpretacion)
		{
			if (profile.GetType() == typeof(Interpretacion.SkinTone))
			{
				return AutoRatingHelper.ScoreSkinTone(profile, interpretacion);
			}
			bool flag;
			int num = AutoRatingHelper.Diferencia(profile, interpretacion, out flag);
			float num2;
			if (num == 0)
			{
				num2 = 1f;
			}
			else if (num == 1)
			{
				if (flag)
				{
					num2 = 0.11f;
				}
				else
				{
					num2 = 0.1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00006448 File Offset: 0x00004648
		private static float ScoreEasy(object profile, object interpretacion)
		{
			if (profile.GetType() == typeof(Interpretacion.SkinTone))
			{
				return AutoRatingHelper.ScoreSkinTone(profile, interpretacion);
			}
			float num;
			switch (AutoRatingHelper.DiferenciaV2(profile, interpretacion))
			{
			case 0:
				num = 1f;
				break;
			case 1:
				num = 0.5f;
				break;
			case 2:
				num = 0.25f;
				break;
			case 3:
				num = 0.125f;
				break;
			default:
				num = 0f;
				break;
			}
			return num;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000064BC File Offset: 0x000046BC
		private static float ScoreSkinTone(object profile, object interpretacion)
		{
			float num;
			switch (AutoRatingHelper.DiferenciaV2(profile, interpretacion))
			{
			case 0:
				num = 1f;
				break;
			case 1:
				num = 0.75f;
				break;
			case 2:
				num = 0.5f;
				break;
			case 3:
				num = 0.25f;
				break;
			default:
				num = 0f;
				break;
			}
			return num;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00006510 File Offset: 0x00004710
		private static void LoadValues(Dictionary<string, object> ruta_a_valores, object obj, string ruta, Dictionary<string, AutoRatingHelper.GetterHandler> ruta_A_Getter)
		{
			AutoRatingHelper.<>c__DisplayClass6_0 CS$<>8__locals1 = new AutoRatingHelper.<>c__DisplayClass6_0();
			CS$<>8__locals1.ruta_A_Getter = ruta_A_Getter;
			CS$<>8__locals1.obj = obj;
			string[] array = ruta.Split('.', StringSplitOptions.None);
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (i != 0)
				{
					text += ".";
				}
				text += array[i];
				AutoRatingHelper.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
				string text2 = text;
				Func<string, object> func;
				if ((func = CS$<>8__locals1.<>9__0) == null)
				{
					func = (CS$<>8__locals1.<>9__0 = (string key) => CS$<>8__locals1.ruta_A_Getter[key](ref CS$<>8__locals1.obj));
				}
				CS$<>8__locals2.obj = ruta_a_valores.GetValueNotNull(text2, func);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00006598 File Offset: 0x00004798
		private static void InitMapaDeAutoRating()
		{
			if (AutoRatingHelper.m_autoRatingMapInit)
			{
				return;
			}
			AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones.Clear();
			AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones.Clear();
			try
			{
				AutoRatingHelper.m_ruta_A_Getter.Add("InterpretacionCompleta", delegate(ref object instance)
				{
					return instance;
				});
				AutoRatingHelper.AddToMapa(typeof(InterpretacionCompletaDeFemale), AutoRatingHelper.m_ruta_A_Getter, AutoRatingHelper.m_ruta_A_RatingNameTargetApariencia, AutoRatingHelper.m_ruta_A_RatingNameTargetPersonalidad, "InterpretacionCompleta", null, null);
				AutoRatingHelper.m_rutas = new HashSet<string>();
				foreach (KeyValuePair<string, AplicaAConjuntoDeFisicoAttribute> keyValuePair in AutoRatingHelper.m_ruta_A_RatingNameTargetApariencia)
				{
					AutoRatingHelper.m_rutas.Add(keyValuePair.Key);
					int num;
					if (!AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones.TryGetValue(keyValuePair.Value.para, out num))
					{
						num = 0;
						AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones.Add(keyValuePair.Value.para, num);
					}
					AutoRatingHelper.m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones[keyValuePair.Value.para] = num + keyValuePair.Value.weigth;
				}
				foreach (KeyValuePair<string, AplicaAConjuntoDePersonalidadAttribute> keyValuePair2 in AutoRatingHelper.m_ruta_A_RatingNameTargetPersonalidad)
				{
					AutoRatingHelper.m_rutas.Add(keyValuePair2.Key);
					int num2;
					if (!AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones.TryGetValue(keyValuePair2.Value.para, out num2))
					{
						num2 = 0;
						AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones.Add(keyValuePair2.Value.para, num2);
					}
					AutoRatingHelper.m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones[keyValuePair2.Value.para] = num2 + keyValuePair2.Value.weigth;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			AutoRatingHelper.m_autoRatingMapInit = true;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000067A8 File Offset: 0x000049A8
		private static void AddToMapa(Type target, Dictionary<string, AutoRatingHelper.GetterHandler> ruta_A_Getter, Dictionary<string, AplicaAConjuntoDeFisicoAttribute> ruta_A_RatingNameTargetApariencia, Dictionary<string, AplicaAConjuntoDePersonalidadAttribute> ruta_A_RatingNameTargetPersonalidad, string currentRuta, AplicaAConjuntoDeFisicoAttribute currentApplicacionApariencia, AplicaAConjuntoDePersonalidadAttribute currentApplicacionPersonalidad)
		{
			if (currentApplicacionApariencia != null && currentApplicacionPersonalidad != null)
			{
				throw new InvalidOperationException(target.FullName + " esta marcado como aplicandose a personalidad y a apariencia");
			}
			MemberInfo[] members = target.GetMembers(BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < members.Length; i++)
			{
				MemberInfo miembro = members[i];
				if (!miembro.IsDefined(typeof(IgnoreAttribute), false))
				{
					Type underlyingType = miembro.GetUnderlyingType();
					string text = currentRuta + "." + miembro.Name;
					bool flag = false;
					AutoRatingHelper.GetterHandler getterHandler = null;
					if (miembro is FieldInfo)
					{
						getterHandler = delegate(ref object instance)
						{
							return ((FieldInfo)miembro).GetValue(instance);
						};
						flag = true;
					}
					else if (miembro is PropertyInfo)
					{
						getterHandler = delegate(ref object instance)
						{
							return ((PropertyInfo)miembro).GetValue(instance);
						};
						flag = true;
					}
					if (getterHandler != null)
					{
						ruta_A_Getter.Add(text, getterHandler);
					}
					if (flag && (miembro.IsDefined(typeof(ModeloAttribute), false) || underlyingType.IsDefined(typeof(ModeloAttribute), false)))
					{
						Attribute attribute = Attribute.GetCustomAttribute(miembro, typeof(AplicaAConjuntoDeFisicoAttribute)) ?? Attribute.GetCustomAttribute(underlyingType, typeof(AplicaAConjuntoDeFisicoAttribute));
						Attribute attribute2 = Attribute.GetCustomAttribute(miembro, typeof(AplicaAConjuntoDePersonalidadAttribute)) ?? Attribute.GetCustomAttribute(underlyingType, typeof(AplicaAConjuntoDePersonalidadAttribute));
						if (attribute != null && attribute2 != null)
						{
							throw new InvalidOperationException("Miembro: " + text + " esta marcado como aplicandose a personalidad y a apariencia");
						}
						if (attribute != null)
						{
							AutoRatingHelper.AddToMapa(underlyingType, ruta_A_Getter, ruta_A_RatingNameTargetApariencia, ruta_A_RatingNameTargetPersonalidad, text, (AplicaAConjuntoDeFisicoAttribute)attribute, null);
						}
						else if (attribute2 != null)
						{
							AutoRatingHelper.AddToMapa(underlyingType, ruta_A_Getter, ruta_A_RatingNameTargetApariencia, ruta_A_RatingNameTargetPersonalidad, text, null, (AplicaAConjuntoDePersonalidadAttribute)attribute2);
						}
						else if (currentApplicacionApariencia != null)
						{
							AutoRatingHelper.AddToMapa(underlyingType, ruta_A_Getter, ruta_A_RatingNameTargetApariencia, ruta_A_RatingNameTargetPersonalidad, text, currentApplicacionApariencia, null);
						}
						else if (currentApplicacionPersonalidad != null)
						{
							AutoRatingHelper.AddToMapa(underlyingType, ruta_A_Getter, ruta_A_RatingNameTargetApariencia, ruta_A_RatingNameTargetPersonalidad, text, null, currentApplicacionPersonalidad);
						}
						else
						{
							AutoRatingHelper.AddToMapa(underlyingType, ruta_A_Getter, ruta_A_RatingNameTargetApariencia, ruta_A_RatingNameTargetPersonalidad, text, null, null);
						}
					}
					else if (underlyingType.IsEnum && miembro is PropertyInfo)
					{
						Attribute customAttribute = Attribute.GetCustomAttribute(miembro, typeof(AplicaAConjuntoDeFisicoAttribute));
						Attribute customAttribute2 = Attribute.GetCustomAttribute(miembro, typeof(AplicaAConjuntoDePersonalidadAttribute));
						if (customAttribute != null && customAttribute2 != null)
						{
							throw new InvalidOperationException("Miembro: " + text + " esta marcado como aplicandose a personalidad y a apariencia");
						}
						if (customAttribute != null)
						{
							ruta_A_RatingNameTargetApariencia.Add(text, (AplicaAConjuntoDeFisicoAttribute)customAttribute);
						}
						else if (customAttribute2 != null)
						{
							ruta_A_RatingNameTargetPersonalidad.Add(text, (AplicaAConjuntoDePersonalidadAttribute)customAttribute2);
						}
						else if (currentApplicacionApariencia != null)
						{
							ruta_A_RatingNameTargetApariencia.Add(text, currentApplicacionApariencia);
						}
						else if (currentApplicacionPersonalidad != null)
						{
							ruta_A_RatingNameTargetPersonalidad.Add(text, currentApplicacionPersonalidad);
						}
						else
						{
							Debug.LogError("Miembro: " + text + " no tiene ninguna aplicacion... ");
						}
					}
				}
			}
		}

		// Token: 0x040000A3 RID: 163
		[NonSerialized]
		private static bool m_autoRatingMapInit;

		// Token: 0x040000A4 RID: 164
		[NonSerialized]
		private static Dictionary<string, AplicaAConjuntoDeFisicoAttribute> m_ruta_A_RatingNameTargetApariencia = new Dictionary<string, AplicaAConjuntoDeFisicoAttribute>();

		// Token: 0x040000A5 RID: 165
		[NonSerialized]
		private static Dictionary<string, AplicaAConjuntoDePersonalidadAttribute> m_ruta_A_RatingNameTargetPersonalidad = new Dictionary<string, AplicaAConjuntoDePersonalidadAttribute>();

		// Token: 0x040000A6 RID: 166
		[SerializeField]
		private static StringKeyIntValueDictionary m_RatingNameTargetApariencia_A_CantidadDeInterpretaciones = new StringKeyIntValueDictionary();

		// Token: 0x040000A7 RID: 167
		[SerializeField]
		private static StringKeyIntValueDictionary m_RatingNameTargetPersonalidad_A_CantidadDeInterpretaciones = new StringKeyIntValueDictionary();

		// Token: 0x040000A8 RID: 168
		[NonSerialized]
		private static HashSet<string> m_rutas;

		// Token: 0x040000A9 RID: 169
		[NonSerialized]
		private static Dictionary<string, AutoRatingHelper.GetterHandler> m_ruta_A_Getter = new Dictionary<string, AutoRatingHelper.GetterHandler>();

		// Token: 0x02000155 RID: 341
		// (Invoke) Token: 0x06000B7A RID: 2938
		private delegate object GetterHandler(ref object instance);
	}
}

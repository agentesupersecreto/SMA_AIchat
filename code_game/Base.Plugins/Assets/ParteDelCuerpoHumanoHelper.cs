using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200015A RID: 346
	public static class ParteDelCuerpoHumanoHelper
	{
		// Token: 0x060009F4 RID: 2548 RVA: 0x0002062C File Offset: 0x0001E82C
		static ParteDelCuerpoHumanoHelper()
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			list.Add(ParteDelCuerpoHumano.bocaInterno);
			list.Add(ParteDelCuerpoHumano.lengua);
			list.Add(ParteDelCuerpoHumano.labios);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionOral = list;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionOralSet = new HashSet<int>(list.Cast<int>());
			List<ParteDelCuerpoHumano> list2 = new List<ParteDelCuerpoHumano>();
			list2.Add(ParteDelCuerpoHumano.vag);
			list2.Add(ParteDelCuerpoHumano.labiosVaginales);
			list2.Add(ParteDelCuerpoHumano.clitoris);
			list2.Add(ParteDelCuerpoHumano.vientreBajo);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal = list2;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet = new HashSet<int>(list2.Cast<int>());
			List<ParteDelCuerpoHumano> list3 = new List<ParteDelCuerpoHumano>();
			list3.Add(ParteDelCuerpoHumano.ano);
			list3.Add(ParteDelCuerpoHumano.perineo);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal = list3;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet = new HashSet<int>(list3.Cast<int>());
			List<ParteDelCuerpoHumano> list4 = new List<ParteDelCuerpoHumano>();
			list4.Add(ParteDelCuerpoHumano.nalgas);
			list4.Add(ParteDelCuerpoHumano.coxis);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionNalgas = list4;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionNalgasSet = new HashSet<int>(list4.Cast<int>());
			List<ParteDelCuerpoHumano> list5 = new List<ParteDelCuerpoHumano>();
			list5.Add(ParteDelCuerpoHumano.senos);
			list5.Add(ParteDelCuerpoHumano.pezones);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos = list5;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionSenosSet = new HashSet<int>(list5.Cast<int>());
			List<ParteDelCuerpoHumano> list6 = new List<ParteDelCuerpoHumano>();
			list6.Add(ParteDelCuerpoHumano.mandibula);
			list6.Add(ParteDelCuerpoHumano.nariz);
			list6.Add(ParteDelCuerpoHumano.mejillas);
			list6.Add(ParteDelCuerpoHumano.cejas);
			list6.Add(ParteDelCuerpoHumano.cienes);
			list6.Add(ParteDelCuerpoHumano.frente);
			list6.Add(ParteDelCuerpoHumano.orejas);
			list6.Add(ParteDelCuerpoHumano.ojos);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionRostro = list6;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionRostroSet = new HashSet<int>(list6.Cast<int>());
			List<ParteDelCuerpoHumano> list7 = new List<ParteDelCuerpoHumano>();
			list7.Add(ParteDelCuerpoHumano.globosOculares);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionGlobosOculares = list7;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionGlobosOcularesSet = new HashSet<int>(list7.Cast<int>());
			List<ParteDelCuerpoHumano> list8 = new List<ParteDelCuerpoHumano>();
			list8.Add(ParteDelCuerpoHumano.cabeza);
			list8.Add(ParteDelCuerpoHumano.espalda);
			list8.Add(ParteDelCuerpoHumano.cintura);
			list8.Add(ParteDelCuerpoHumano.cuello);
			list8.Add(ParteDelCuerpoHumano.caderas);
			list8.Add(ParteDelCuerpoHumano.vientre);
			list8.Add(ParteDelCuerpoHumano.abdomen);
			list8.Add(ParteDelCuerpoHumano.hombligo);
			list8.Add(ParteDelCuerpoHumano.pecho);
			list8.Add(ParteDelCuerpoHumano.hombros);
			list8.Add(ParteDelCuerpoHumano.axilas);
			list8.Add(ParteDelCuerpoHumano.brazos);
			list8.Add(ParteDelCuerpoHumano.anteBrazos);
			list8.Add(ParteDelCuerpoHumano.manos);
			list8.Add(ParteDelCuerpoHumano.piernas);
			list8.Add(ParteDelCuerpoHumano.rodillas);
			list8.Add(ParteDelCuerpoHumano.canillas);
			list8.Add(ParteDelCuerpoHumano.pies);
			ParteDelCuerpoHumanoHelper.partesDeInteraccionCuerpoFemenino = list8;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionCuerpoFemeninoSet = new HashSet<int>(list8.Cast<int>());
			List<ParteDelCuerpoHumano> list9 = new List<ParteDelCuerpoHumano>();
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsFemenina())
				{
					list9.Add(parteDelCuerpoHumano);
				}
			}
			ParteDelCuerpoHumanoHelper.partesDeInteraccionFemenina = list9;
			ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet = new HashSet<int>(list9.Cast<int>());
			if (ParteDelCuerpoHumanoHelper.partesDeInteraccionOral.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionNalgas.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionRostro.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionGlobosOculares.Count + ParteDelCuerpoHumanoHelper.partesDeInteraccionCuerpoFemenino.Count != ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Count)
			{
				Debug.LogError("Partes de interaccion femeninas no se creo correctamente");
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano2 in ParteDelCuerpoHumanoHelper.partesDeInteraccionOral)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano2))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano2.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano3 in ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano3))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano3.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano4 in ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano4))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano4.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano5 in ParteDelCuerpoHumanoHelper.partesDeInteraccionNalgas)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano5))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano5.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano6 in ParteDelCuerpoHumanoHelper.partesDeInteraccionSenos)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano6))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano6.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano7 in ParteDelCuerpoHumanoHelper.partesDeInteraccionRostro)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano7))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano7.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano8 in ParteDelCuerpoHumanoHelper.partesDeInteraccionGlobosOculares)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano8))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano8.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano9 in ParteDelCuerpoHumanoHelper.partesDeInteraccionCuerpoFemenino)
			{
				if (!ParteDelCuerpoHumanoHelper.partesDeInteraccionFemeninaSet.Contains((int)parteDelCuerpoHumano9))
				{
					Debug.LogError("Parte: " + parteDelCuerpoHumano9.ToString() + " no existe en partes femeninas de interaccion");
				}
			}
			List<ParteDelCuerpoHumano> list10 = new List<ParteDelCuerpoHumano>();
			list10.Add(ParteDelCuerpoHumano.coxis);
			list10.Add(ParteDelCuerpoHumano.nalgas);
			list10.Add(ParteDelCuerpoHumano.perineo);
			list10.Add(ParteDelCuerpoHumano.ano);
			list10.Add(ParteDelCuerpoHumano.caderas);
			ParteDelCuerpoHumanoHelper.partesDeTrasero = list10;
			ParteDelCuerpoHumanoHelper.partesDeTraseroSet = new HashSet<int>(list10.Cast<int>());
			List<ParteDelCuerpoHumano> list11 = new List<ParteDelCuerpoHumano>();
			list11.Add(ParteDelCuerpoHumano.piernas);
			list11.Add(ParteDelCuerpoHumano.vientreBajo);
			list11.Add(ParteDelCuerpoHumano.perineo);
			list11.Add(ParteDelCuerpoHumano.clitoris);
			list11.Add(ParteDelCuerpoHumano.labiosVaginales);
			list11.Add(ParteDelCuerpoHumano.vag);
			list11.Add(ParteDelCuerpoHumano.caderas);
			ParteDelCuerpoHumanoHelper.partesDeEntrepierna = list11;
			ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet = new HashSet<int>(list11.Cast<int>());
			List<ParteDelCuerpoHumano> list12 = new List<ParteDelCuerpoHumano>();
			list12.Add(ParteDelCuerpoHumano.coxis);
			list12.Add(ParteDelCuerpoHumano.espalda);
			list12.Add(ParteDelCuerpoHumano.cintura);
			list12.Add(ParteDelCuerpoHumano.caderas);
			ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero = list12;
			ParteDelCuerpoHumanoHelper.partesDeTrozoTraseroSet = new HashSet<int>(list12.Cast<int>());
			List<ParteDelCuerpoHumano> list13 = new List<ParteDelCuerpoHumano>();
			list13.Add(ParteDelCuerpoHumano.vientreBajo);
			list13.Add(ParteDelCuerpoHumano.pecho);
			list13.Add(ParteDelCuerpoHumano.vientre);
			list13.Add(ParteDelCuerpoHumano.abdomen);
			list13.Add(ParteDelCuerpoHumano.hombligo);
			list13.Add(ParteDelCuerpoHumano.cintura);
			list13.Add(ParteDelCuerpoHumano.caderas);
			ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero = list13;
			ParteDelCuerpoHumanoHelper.partesDeTrozoDelanteroSet = new HashSet<int>(list13.Cast<int>());
			List<ParteDelCuerpoHumano> list14 = new List<ParteDelCuerpoHumano>();
			list14.Add(ParteDelCuerpoHumano.mandibula);
			list14.Add(ParteDelCuerpoHumano.nariz);
			list14.Add(ParteDelCuerpoHumano.mejillas);
			list14.Add(ParteDelCuerpoHumano.cejas);
			list14.Add(ParteDelCuerpoHumano.cienes);
			list14.Add(ParteDelCuerpoHumano.frente);
			list14.Add(ParteDelCuerpoHumano.orejas);
			list14.Add(ParteDelCuerpoHumano.labios);
			list14.Add(ParteDelCuerpoHumano.bocaInterno);
			list14.Add(ParteDelCuerpoHumano.lengua);
			list14.Add(ParteDelCuerpoHumano.globosOculares);
			list14.Add(ParteDelCuerpoHumano.ojos);
			list14.Add(ParteDelCuerpoHumano.cabeza);
			ParteDelCuerpoHumanoHelper.partesDeFacial = list14;
			ParteDelCuerpoHumanoHelper.partesDeFacialSet = new HashSet<int>(list14.Cast<int>());
			List<ParteDelCuerpoHumano> list15 = new List<ParteDelCuerpoHumano>();
			list15.Add(ParteDelCuerpoHumano.manos);
			list15.Add(ParteDelCuerpoHumano.anteBrazos);
			list15.Add(ParteDelCuerpoHumano.brazos);
			ParteDelCuerpoHumanoHelper.partesDeBrazos = list15;
			ParteDelCuerpoHumanoHelper.partesDeBrazosSet = new HashSet<int>(list15.Cast<int>());
			List<ParteDelCuerpoHumano> list16 = new List<ParteDelCuerpoHumano>();
			list16.Add(ParteDelCuerpoHumano.pies);
			list16.Add(ParteDelCuerpoHumano.canillas);
			list16.Add(ParteDelCuerpoHumano.piernas);
			ParteDelCuerpoHumanoHelper.partesDePiernas = list16;
			ParteDelCuerpoHumanoHelper.partesDePiernasSet = new HashSet<int>(list16.Cast<int>());
			List<ParteDelCuerpoHumano> list17 = new List<ParteDelCuerpoHumano>();
			list17.Add(ParteDelCuerpoHumano.bocaInterno);
			list17.Add(ParteDelCuerpoHumano.vag);
			list17.Add(ParteDelCuerpoHumano.ano);
			ParteDelCuerpoHumanoHelper.holes = list17;
			ParteDelCuerpoHumanoHelper.holesSet = new HashSet<int>(list17.Cast<int>());
			IEnumerable enumValoresObject = typeof(HumanBodyBones).GetEnumValoresObject();
			List<ParteDelCuerpoHumano> list18 = new List<ParteDelCuerpoHumano>();
			using (IEnumerator enumerator = enumValoresObject.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano10;
					if (((HumanBodyBones)enumerator.Current).TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano10))
					{
						list18.Add(parteDelCuerpoHumano10);
					}
				}
			}
			ParteDelCuerpoHumanoHelper.partesDeSkeleto = list18;
			ParteDelCuerpoHumanoHelper.partesDeSkeletoSet = new HashSet<int>(list18.Cast<int>());
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00020F14 File Offset: 0x0001F114
		public static bool TryObtenerParteDelCuerpoHumano(this string parte, out ParteDelCuerpoHumano r)
		{
			return Enum.TryParse<ParteDelCuerpoHumano>(parte, out r);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00020F22 File Offset: 0x0001F122
		public static bool EsBrazos(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeBrazosSet.Contains((int)parte);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00020F2F File Offset: 0x0001F12F
		public static bool EsOralInteraction(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeInteraccionOralSet.Contains((int)parte);
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00020F3C File Offset: 0x0001F13C
		public static bool EsVaginalInteraction(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginalSet.Contains((int)parte);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00020F49 File Offset: 0x0001F149
		public static bool EsAnalInteraction(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeInteraccionAnalSet.Contains((int)parte);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00020F56 File Offset: 0x0001F156
		public static bool EsRostro(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeInteraccionRostroSet.Contains((int)parte);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00020F64 File Offset: 0x0001F164
		public static ParteQuePuedeEstimular Switch(this ParteDelCuerpoHumano parteEstimulada)
		{
			switch (parteEstimulada)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
				break;
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.axilas:
				goto IL_00AF;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
				return ParteQuePuedeEstimular.boca;
			case ParteDelCuerpoHumano.ojos:
				return ParteQuePuedeEstimular.ojos;
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
				return ParteQuePuedeEstimular.manos;
			default:
				switch (parteEstimulada)
				{
				case ParteDelCuerpoHumano.hombligo:
					break;
				case ParteDelCuerpoHumano.piernas:
				case ParteDelCuerpoHumano.rodillas:
				case ParteDelCuerpoHumano.canillas:
				case ParteDelCuerpoHumano.pies:
					return ParteQuePuedeEstimular.piernas;
				case ParteDelCuerpoHumano.lengua:
					return ParteQuePuedeEstimular.lengua;
				case ParteDelCuerpoHumano.orejas:
					goto IL_00AF;
				case ParteDelCuerpoHumano.pene:
					return ParteQuePuedeEstimular.pene;
				default:
					goto IL_00AF;
				}
				break;
			}
			return ParteQuePuedeEstimular.torzo;
			IL_00AF:
			return ParteQuePuedeEstimular.noEspecificada;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00021024 File Offset: 0x0001F224
		public static bool EsCoitoOral(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.lengua:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x000210F8 File Offset: 0x0001F2F8
		public static bool EsCoitoVaginal(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.vag:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000211CC File Offset: 0x0001F3CC
		public static bool EsCoitoAnal(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0002129F File Offset: 0x0001F49F
		public static bool EsFemenina(this ParteDelCuerpoHumano parte)
		{
			return parte != ParteDelCuerpoHumano.pene && parte != ParteDelCuerpoHumano.testiculos;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000212B0 File Offset: 0x0001F4B0
		public static bool EsSkeleto(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeSkeletoSet.Contains((int)parte);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000212BD File Offset: 0x0001F4BD
		public static bool EsHole(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.holesSet.Contains((int)parte);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x000212CA File Offset: 0x0001F4CA
		public static bool PuedeSerPenetrada(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.holesSet.Contains((int)parte);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000212D8 File Offset: 0x0001F4D8
		public static bool PuedePenetrarReal(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.pene:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x000213AC File Offset: 0x0001F5AC
		public static bool EsAproximadoOral(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.lengua:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0002147F File Offset: 0x0001F67F
		public static bool EsFacial(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeFacialSet.Contains((int)parte);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0002148C File Offset: 0x0001F68C
		public static bool EsTrasero(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeTraseroSet.Contains((int)parte);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00021499 File Offset: 0x0001F699
		public static bool EsEntrepierna(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet.Contains((int)parte);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000214A6 File Offset: 0x0001F6A6
		public static bool EsTrozoTrasero(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeTrozoTraseroSet.Contains((int)parte);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000214B3 File Offset: 0x0001F6B3
		public static bool EsTrozoDelantero(this ParteDelCuerpoHumano parte)
		{
			return ParteDelCuerpoHumanoHelper.partesDeTrozoDelanteroSet.Contains((int)parte);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x000214C0 File Offset: 0x0001F6C0
		public static bool EsNoNaturalSocialmenteCoital(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.ano:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00021594 File Offset: 0x0001F794
		public static bool EsSemiPrivadaSocialmenteVisual(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.pies:
				return true;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0002166C File Offset: 0x0001F86C
		public static bool EsSemiPrivadaSocialmenteTactil(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.pies:
				return true;
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return false;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00021741 File Offset: 0x0001F941
		public static bool EsSemiPrivadaSocialmenteCoital(this ParteDelCuerpoHumano parte)
		{
			return parte == ParteDelCuerpoHumano.bocaInterno || (parte - ParteDelCuerpoHumano.ano > 1 && parte.EsSemiPrivadaSocialmenteVisual());
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00021759 File Offset: 0x0001F959
		public static bool EsPrivadaSocialmenteCoital(this ParteDelCuerpoHumano parte)
		{
			return parte != ParteDelCuerpoHumano.bocaInterno && (parte - ParteDelCuerpoHumano.ano <= 1 || parte.EsPrivadaSocialmenteVisual());
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00021774 File Offset: 0x0001F974
		public static bool EsMuyPrivadaSocialmenteTactil(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00021848 File Offset: 0x0001FA48
		public static bool EsPrivadaSocialmenteTactil(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0002191C File Offset: 0x0001FB1C
		public static bool EsPrivadaSocialmenteVisual(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x000219F0 File Offset: 0x0001FBF0
		public static bool EsMuyPrivadaSocialmenteVisual(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.nalgas:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.piernas:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
				return false;
			case ParteDelCuerpoHumano.pezones:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return true;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00021AC3 File Offset: 0x0001FCC3
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMayorPrioridadVisual(contexto, list);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00021ACD File Offset: 0x0001FCCD
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMenorPrioridadVisual(contexto, list);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00021AD7 File Offset: 0x0001FCD7
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMayorPrioridadTactil(contexto, list);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00021AE1 File Offset: 0x0001FCE1
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMenorPrioridadTactil(contexto, list);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00021AEB File Offset: 0x0001FCEB
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMayorPrioridadCoital(contexto, list);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00021AF5 File Offset: 0x0001FCF5
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(this IReadOnlyList<ParteDelCuerpoHumano> list, IParteDelCuerpoHumanoPrioridades prioridades, PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			return prioridades.ObtenerLaDeMenorPrioridadCoital(contexto, list);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00021B00 File Offset: 0x0001FD00
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisualFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadVisualFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadVisualFixed(sexo);
				if (num2 > num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00021B60 File Offset: 0x0001FD60
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisualFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadVisualFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadVisualFixed(sexo);
				if (num2 < num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00021BC0 File Offset: 0x0001FDC0
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactilFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadTactilFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadTactilFixed(sexo);
				if (num2 > num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00021C20 File Offset: 0x0001FE20
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactilFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadTactilFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadTactilFixed(sexo);
				if (num2 < num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00021C80 File Offset: 0x0001FE80
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoitalFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadCoitalFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadCoitalFixed(sexo);
				if (num2 > num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00021CE0 File Offset: 0x0001FEE0
		public static ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoitalFixed(this IReadOnlyList<ParteDelCuerpoHumano> list, Sexo sexo)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException();
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = list[0];
			int num = parteDelCuerpoHumano.PrioridadCoitalFixed(sexo);
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = list[i];
				int num2 = parteDelCuerpoHumano2.PrioridadCoitalFixed(sexo);
				if (num2 < num)
				{
					num = num2;
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00021D40 File Offset: 0x0001FF40
		public static int PrioridadCoitalFixed(this ParteDelCuerpoHumano parte, Sexo sexo)
		{
			if (sexo > Sexo.masculino)
			{
				if (sexo != Sexo.femenino)
				{
					throw new ArgumentOutOfRangeException(sexo.ToString());
				}
				if (parte == ParteDelCuerpoHumano.bocaInterno)
				{
					return 30;
				}
				if (parte == ParteDelCuerpoHumano.ano)
				{
					return 40;
				}
				if (parte != ParteDelCuerpoHumano.vag)
				{
					return Mathf.Clamp(parte.PrioridadVisualFixed(sexo) / 2, 1, 29);
				}
				return 35;
			}
			else
			{
				if (parte == ParteDelCuerpoHumano.bocaInterno)
				{
					return 30;
				}
				if (parte == ParteDelCuerpoHumano.ano)
				{
					return 40;
				}
				return Mathf.Clamp(parte.PrioridadVisualFixed(sexo) / 2, 1, 29);
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00021DB8 File Offset: 0x0001FFB8
		public static int PrioridadTactilFixed(this ParteDelCuerpoHumano parte, Sexo sexo)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.orejas:
				return 5;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.canillas:
				return 10;
			case ParteDelCuerpoHumano.cuello:
				return 22;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
				return 15;
			case ParteDelCuerpoHumano.labios:
				return 24;
			case ParteDelCuerpoHumano.bocaInterno:
				return 29;
			case ParteDelCuerpoHumano.ojos:
				return 35;
			case ParteDelCuerpoHumano.globosOculares:
				return 40;
			case ParteDelCuerpoHumano.axilas:
				return 21;
			case ParteDelCuerpoHumano.manos:
				return 14;
			case ParteDelCuerpoHumano.senos:
				return 27;
			case ParteDelCuerpoHumano.pezones:
				return 28;
			case ParteDelCuerpoHumano.coxis:
				return 23;
			case ParteDelCuerpoHumano.vientre:
				return 25;
			case ParteDelCuerpoHumano.nalgas:
				return 26;
			case ParteDelCuerpoHumano.vientreBajo:
				return 33;
			case ParteDelCuerpoHumano.labiosVaginales:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 36;
			case ParteDelCuerpoHumano.clitoris:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 38;
			case ParteDelCuerpoHumano.perineo:
				return 34;
			case ParteDelCuerpoHumano.ano:
				return 39;
			case ParteDelCuerpoHumano.vag:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 37;
			case ParteDelCuerpoHumano.hombligo:
				return 20;
			case ParteDelCuerpoHumano.piernas:
				return 19;
			case ParteDelCuerpoHumano.pies:
				return 18;
			case ParteDelCuerpoHumano.lengua:
				return 30;
			case ParteDelCuerpoHumano.pene:
				if (sexo != Sexo.masculino)
				{
					return 0;
				}
				return 31;
			case ParteDelCuerpoHumano.testiculos:
				if (sexo != Sexo.masculino)
				{
					return 0;
				}
				return 32;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00021EF8 File Offset: 0x000200F8
		public static int PrioridadVisualFixed(this ParteDelCuerpoHumano parte, Sexo sexo)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.orejas:
				return 10;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.canillas:
				return 15;
			case ParteDelCuerpoHumano.cuello:
				return 27;
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.lengua:
				return 1;
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
				return 5;
			case ParteDelCuerpoHumano.axilas:
				return 26;
			case ParteDelCuerpoHumano.manos:
				return 23;
			case ParteDelCuerpoHumano.senos:
				return 31;
			case ParteDelCuerpoHumano.pezones:
				return 35;
			case ParteDelCuerpoHumano.coxis:
				return 28;
			case ParteDelCuerpoHumano.vientre:
				return 29;
			case ParteDelCuerpoHumano.nalgas:
				return 30;
			case ParteDelCuerpoHumano.vientreBajo:
				return 34;
			case ParteDelCuerpoHumano.labiosVaginales:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 38;
			case ParteDelCuerpoHumano.clitoris:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 37;
			case ParteDelCuerpoHumano.perineo:
				return 32;
			case ParteDelCuerpoHumano.ano:
				return 33;
			case ParteDelCuerpoHumano.vag:
				if (sexo != Sexo.femenino)
				{
					return 0;
				}
				return 39;
			case ParteDelCuerpoHumano.hombligo:
				return 25;
			case ParteDelCuerpoHumano.piernas:
				return 24;
			case ParteDelCuerpoHumano.pies:
				return 22;
			case ParteDelCuerpoHumano.pene:
				if (sexo != Sexo.masculino)
				{
					return 0;
				}
				return 40;
			case ParteDelCuerpoHumano.testiculos:
				if (sexo != Sexo.masculino)
				{
					return 0;
				}
				return 36;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00022028 File Offset: 0x00020228
		public static bool TryParceToParteDelCuerpoHumano(this HumanBodyBones humanBodyBones, out ParteDelCuerpoHumano parteDelCuerpo)
		{
			ParteDelCuerpoHumano? parteDelCuerpoHumano = null;
			switch (humanBodyBones)
			{
			case HumanBodyBones.Hips:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.caderas);
				break;
			case HumanBodyBones.LeftUpperLeg:
			case HumanBodyBones.RightUpperLeg:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.piernas);
				break;
			case HumanBodyBones.LeftLowerLeg:
			case HumanBodyBones.RightLowerLeg:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.canillas);
				break;
			case HumanBodyBones.LeftFoot:
			case HumanBodyBones.RightFoot:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.pies);
				break;
			case HumanBodyBones.Spine:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.cintura);
				break;
			case HumanBodyBones.Chest:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.pecho);
				break;
			case HumanBodyBones.Neck:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.cuello);
				break;
			case HumanBodyBones.Head:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.cabeza);
				break;
			case HumanBodyBones.LeftShoulder:
			case HumanBodyBones.RightShoulder:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.hombros);
				break;
			case HumanBodyBones.LeftUpperArm:
			case HumanBodyBones.RightUpperArm:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.brazos);
				break;
			case HumanBodyBones.LeftLowerArm:
			case HumanBodyBones.RightLowerArm:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.anteBrazos);
				break;
			case HumanBodyBones.LeftHand:
			case HumanBodyBones.RightHand:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.manos);
				break;
			case HumanBodyBones.LeftToes:
			case HumanBodyBones.RightToes:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.pies);
				break;
			case HumanBodyBones.LeftEye:
			case HumanBodyBones.RightEye:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.globosOculares);
				break;
			case HumanBodyBones.Jaw:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.mandibula);
				break;
			case HumanBodyBones.LeftThumbProximal:
			case HumanBodyBones.LeftThumbIntermediate:
			case HumanBodyBones.LeftThumbDistal:
			case HumanBodyBones.LeftIndexProximal:
			case HumanBodyBones.LeftIndexIntermediate:
			case HumanBodyBones.LeftIndexDistal:
			case HumanBodyBones.LeftMiddleProximal:
			case HumanBodyBones.LeftMiddleIntermediate:
			case HumanBodyBones.LeftMiddleDistal:
			case HumanBodyBones.LeftRingProximal:
			case HumanBodyBones.LeftRingIntermediate:
			case HumanBodyBones.LeftRingDistal:
			case HumanBodyBones.LeftLittleProximal:
			case HumanBodyBones.LeftLittleIntermediate:
			case HumanBodyBones.LeftLittleDistal:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.manos);
				break;
			case HumanBodyBones.RightThumbProximal:
			case HumanBodyBones.RightThumbIntermediate:
			case HumanBodyBones.RightThumbDistal:
			case HumanBodyBones.RightIndexProximal:
			case HumanBodyBones.RightIndexIntermediate:
			case HumanBodyBones.RightIndexDistal:
			case HumanBodyBones.RightMiddleProximal:
			case HumanBodyBones.RightMiddleIntermediate:
			case HumanBodyBones.RightMiddleDistal:
			case HumanBodyBones.RightRingProximal:
			case HumanBodyBones.RightRingIntermediate:
			case HumanBodyBones.RightRingDistal:
			case HumanBodyBones.RightLittleProximal:
			case HumanBodyBones.RightLittleIntermediate:
			case HumanBodyBones.RightLittleDistal:
				parteDelCuerpoHumano = new ParteDelCuerpoHumano?(ParteDelCuerpoHumano.manos);
				break;
			case HumanBodyBones.UpperChest:
			case HumanBodyBones.LastBone:
				break;
			default:
				throw new ArgumentOutOfRangeException(humanBodyBones.ToString());
			}
			if (parteDelCuerpoHumano != null)
			{
				parteDelCuerpo = parteDelCuerpoHumano.Value;
				return true;
			}
			parteDelCuerpo = ParteDelCuerpoHumano.pecho;
			return false;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0002221C File Offset: 0x0002041C
		public static HumanBodyBones ParceToHumanBodyBones(this ParteDelCuerpoHumano parte, Side side)
		{
			if (side - Side.L > 1)
			{
				throw new NotSupportedException(side.ToString());
			}
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
				return HumanBodyBones.Chest;
			case ParteDelCuerpoHumano.espalda:
				return HumanBodyBones.Chest;
			case ParteDelCuerpoHumano.abdomen:
				return HumanBodyBones.Spine;
			case ParteDelCuerpoHumano.cintura:
				return HumanBodyBones.Spine;
			case ParteDelCuerpoHumano.caderas:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.cabeza:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.cuello:
				return HumanBodyBones.Neck;
			case ParteDelCuerpoHumano.mandibula:
				return HumanBodyBones.Jaw;
			case ParteDelCuerpoHumano.labios:
				return HumanBodyBones.Jaw;
			case ParteDelCuerpoHumano.bocaInterno:
				return HumanBodyBones.Jaw;
			case ParteDelCuerpoHumano.nariz:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.mejillas:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.ojos:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftEye;
				}
				return HumanBodyBones.RightEye;
			case ParteDelCuerpoHumano.globosOculares:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftEye;
				}
				return HumanBodyBones.RightEye;
			case ParteDelCuerpoHumano.cejas:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftEye;
				}
				return HumanBodyBones.RightEye;
			case ParteDelCuerpoHumano.cienes:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.frente:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.hombros:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftShoulder;
				}
				return HumanBodyBones.RightShoulder;
			case ParteDelCuerpoHumano.axilas:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftShoulder;
				}
				return HumanBodyBones.RightShoulder;
			case ParteDelCuerpoHumano.brazos:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftUpperArm;
				}
				return HumanBodyBones.RightUpperArm;
			case ParteDelCuerpoHumano.anteBrazos:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftLowerArm;
				}
				return HumanBodyBones.RightLowerArm;
			case ParteDelCuerpoHumano.manos:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftHand;
				}
				return HumanBodyBones.RightHand;
			case ParteDelCuerpoHumano.senos:
				return HumanBodyBones.Chest;
			case ParteDelCuerpoHumano.pezones:
				return HumanBodyBones.Chest;
			case ParteDelCuerpoHumano.coxis:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.vientre:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.nalgas:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.vientreBajo:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.labiosVaginales:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.clitoris:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.perineo:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.ano:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.vag:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.hombligo:
				return HumanBodyBones.Spine;
			case ParteDelCuerpoHumano.piernas:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftUpperLeg;
				}
				return HumanBodyBones.RightUpperLeg;
			case ParteDelCuerpoHumano.rodillas:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftLowerLeg;
				}
				return HumanBodyBones.RightLowerLeg;
			case ParteDelCuerpoHumano.canillas:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftLowerLeg;
				}
				return HumanBodyBones.RightLowerLeg;
			case ParteDelCuerpoHumano.pies:
				if (side != Side.R)
				{
					return HumanBodyBones.LeftFoot;
				}
				return HumanBodyBones.RightFoot;
			case ParteDelCuerpoHumano.lengua:
				return HumanBodyBones.Jaw;
			case ParteDelCuerpoHumano.orejas:
				return HumanBodyBones.Head;
			case ParteDelCuerpoHumano.pene:
				return HumanBodyBones.Hips;
			case ParteDelCuerpoHumano.testiculos:
				return HumanBodyBones.Hips;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x000223C0 File Offset: 0x000205C0
		[Obsolete("usar no invertida", true)]
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadFixedVisual(this IReadOnlyCollection<int> set)
		{
			if (set.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (set.Contains(32))
			{
				return ParteDelCuerpoHumano.vag;
			}
			if (set.Contains(28))
			{
				return ParteDelCuerpoHumano.labiosVaginales;
			}
			if (set.Contains(31))
			{
				return ParteDelCuerpoHumano.ano;
			}
			if (set.Contains(29))
			{
				return ParteDelCuerpoHumano.clitoris;
			}
			if (set.Contains(30))
			{
				return ParteDelCuerpoHumano.perineo;
			}
			if (set.Contains(27))
			{
				return ParteDelCuerpoHumano.vientreBajo;
			}
			if (set.Contains(41))
			{
				return ParteDelCuerpoHumano.testiculos;
			}
			if (set.Contains(40))
			{
				return ParteDelCuerpoHumano.pene;
			}
			if (set.Contains(23))
			{
				return ParteDelCuerpoHumano.pezones;
			}
			if (set.Contains(22))
			{
				return ParteDelCuerpoHumano.senos;
			}
			if (set.Contains(26))
			{
				return ParteDelCuerpoHumano.nalgas;
			}
			if (set.Contains(25))
			{
				return ParteDelCuerpoHumano.vientre;
			}
			if (set.Contains(12))
			{
				return ParteDelCuerpoHumano.ojos;
			}
			if (set.Contains(9))
			{
				return ParteDelCuerpoHumano.bocaInterno;
			}
			if (set.Contains(8))
			{
				return ParteDelCuerpoHumano.labios;
			}
			if (set.Contains(24))
			{
				return ParteDelCuerpoHumano.coxis;
			}
			if (set.Contains(6))
			{
				return ParteDelCuerpoHumano.cuello;
			}
			if (set.Contains(18))
			{
				return ParteDelCuerpoHumano.axilas;
			}
			if (set.Contains(33))
			{
				return ParteDelCuerpoHumano.hombligo;
			}
			if (set.Contains(34))
			{
				return ParteDelCuerpoHumano.piernas;
			}
			return (ParteDelCuerpoHumano)set.First<int>();
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x000224E4 File Offset: 0x000206E4
		[Obsolete("usar no invertida", true)]
		public static ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadFixedTactil(this IReadOnlyCollection<int> set)
		{
			if (set.Count == 0)
			{
				throw new InvalidOperationException();
			}
			if (set.Contains(31))
			{
				return ParteDelCuerpoHumano.ano;
			}
			if (set.Contains(29))
			{
				return ParteDelCuerpoHumano.clitoris;
			}
			if (set.Contains(32))
			{
				return ParteDelCuerpoHumano.vag;
			}
			if (set.Contains(28))
			{
				return ParteDelCuerpoHumano.labiosVaginales;
			}
			if (set.Contains(30))
			{
				return ParteDelCuerpoHumano.perineo;
			}
			if (set.Contains(27))
			{
				return ParteDelCuerpoHumano.vientreBajo;
			}
			if (set.Contains(41))
			{
				return ParteDelCuerpoHumano.testiculos;
			}
			if (set.Contains(40))
			{
				return ParteDelCuerpoHumano.pene;
			}
			if (set.Contains(23))
			{
				return ParteDelCuerpoHumano.pezones;
			}
			if (set.Contains(22))
			{
				return ParteDelCuerpoHumano.senos;
			}
			if (set.Contains(26))
			{
				return ParteDelCuerpoHumano.nalgas;
			}
			if (set.Contains(25))
			{
				return ParteDelCuerpoHumano.vientre;
			}
			if (set.Contains(12))
			{
				return ParteDelCuerpoHumano.ojos;
			}
			if (set.Contains(9))
			{
				return ParteDelCuerpoHumano.bocaInterno;
			}
			if (set.Contains(8))
			{
				return ParteDelCuerpoHumano.labios;
			}
			if (set.Contains(24))
			{
				return ParteDelCuerpoHumano.coxis;
			}
			if (set.Contains(6))
			{
				return ParteDelCuerpoHumano.cuello;
			}
			if (set.Contains(18))
			{
				return ParteDelCuerpoHumano.axilas;
			}
			if (set.Contains(33))
			{
				return ParteDelCuerpoHumano.hombligo;
			}
			if (set.Contains(34))
			{
				return ParteDelCuerpoHumano.piernas;
			}
			return (ParteDelCuerpoHumano)set.First<int>();
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00022605 File Offset: 0x00020805
		[Obsolete("usar no invertida", true)]
		public static int PrioridadInvertidaCoital(this ParteDelCuerpoHumano parte)
		{
			if (parte == ParteDelCuerpoHumano.bocaInterno)
			{
				return 2;
			}
			if (parte == ParteDelCuerpoHumano.ano)
			{
				return 0;
			}
			if (parte != ParteDelCuerpoHumano.vag)
			{
				return int.MaxValue;
			}
			return 1;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00022624 File Offset: 0x00020824
		[Obsolete("usar no invertida", true)]
		public static int PrioridadInvertidaTactil(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.cuello:
				return 16;
			case ParteDelCuerpoHumano.labios:
				return 14;
			case ParteDelCuerpoHumano.bocaInterno:
				return 13;
			case ParteDelCuerpoHumano.ojos:
				return 12;
			case ParteDelCuerpoHumano.axilas:
				return 17;
			case ParteDelCuerpoHumano.senos:
				return 9;
			case ParteDelCuerpoHumano.pezones:
				return 8;
			case ParteDelCuerpoHumano.coxis:
				return 15;
			case ParteDelCuerpoHumano.vientre:
				return 11;
			case ParteDelCuerpoHumano.nalgas:
				return 10;
			case ParteDelCuerpoHumano.vientreBajo:
				return 5;
			case ParteDelCuerpoHumano.labiosVaginales:
				return 3;
			case ParteDelCuerpoHumano.clitoris:
				return 1;
			case ParteDelCuerpoHumano.perineo:
				return 4;
			case ParteDelCuerpoHumano.ano:
				return 0;
			case ParteDelCuerpoHumano.vag:
				return 2;
			case ParteDelCuerpoHumano.hombligo:
				return 18;
			case ParteDelCuerpoHumano.piernas:
				return 19;
			case ParteDelCuerpoHumano.pene:
				return 7;
			case ParteDelCuerpoHumano.testiculos:
				return 6;
			}
			return int.MaxValue;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00022704 File Offset: 0x00020904
		[Obsolete("usar no invertida", true)]
		public static int PrioridadInvertidaVisual(this ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.cuello:
				return 16;
			case ParteDelCuerpoHumano.labios:
				return 14;
			case ParteDelCuerpoHumano.bocaInterno:
				return 13;
			case ParteDelCuerpoHumano.ojos:
				return 12;
			case ParteDelCuerpoHumano.axilas:
				return 17;
			case ParteDelCuerpoHumano.senos:
				return 9;
			case ParteDelCuerpoHumano.pezones:
				return 8;
			case ParteDelCuerpoHumano.coxis:
				return 15;
			case ParteDelCuerpoHumano.vientre:
				return 11;
			case ParteDelCuerpoHumano.nalgas:
				return 10;
			case ParteDelCuerpoHumano.vientreBajo:
				return 5;
			case ParteDelCuerpoHumano.labiosVaginales:
				return 1;
			case ParteDelCuerpoHumano.clitoris:
				return 3;
			case ParteDelCuerpoHumano.perineo:
				return 4;
			case ParteDelCuerpoHumano.ano:
				return 2;
			case ParteDelCuerpoHumano.vag:
				return 0;
			case ParteDelCuerpoHumano.hombligo:
				return 18;
			case ParteDelCuerpoHumano.piernas:
				return 19;
			case ParteDelCuerpoHumano.pene:
				return 7;
			case ParteDelCuerpoHumano.testiculos:
				return 6;
			}
			return int.MaxValue;
		}

		// Token: 0x040002FB RID: 763
		public const float minPezonesBrightness = 30f;

		// Token: 0x040002FC RID: 764
		public const float maxPezonesBrightness = 75f;

		// Token: 0x040002FD RID: 765
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeSkeleto;

		// Token: 0x040002FE RID: 766
		public static readonly IReadOnlyCollection<int> partesDeSkeletoSet;

		// Token: 0x040002FF RID: 767
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> holes;

		// Token: 0x04000300 RID: 768
		public static readonly IReadOnlyCollection<int> holesSet;

		// Token: 0x04000301 RID: 769
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeFacial;

		// Token: 0x04000302 RID: 770
		public static readonly IReadOnlyCollection<int> partesDeFacialSet;

		// Token: 0x04000303 RID: 771
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeTrasero;

		// Token: 0x04000304 RID: 772
		public static readonly IReadOnlyCollection<int> partesDeTraseroSet;

		// Token: 0x04000305 RID: 773
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeEntrepierna;

		// Token: 0x04000306 RID: 774
		public static readonly IReadOnlyCollection<int> partesDeEntrepiernaSet;

		// Token: 0x04000307 RID: 775
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeBrazos;

		// Token: 0x04000308 RID: 776
		public static readonly IReadOnlyCollection<int> partesDeBrazosSet;

		// Token: 0x04000309 RID: 777
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDePiernas;

		// Token: 0x0400030A RID: 778
		public static readonly IReadOnlyCollection<int> partesDePiernasSet;

		// Token: 0x0400030B RID: 779
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeTrozoTrasero;

		// Token: 0x0400030C RID: 780
		public static readonly IReadOnlyCollection<int> partesDeTrozoTraseroSet;

		// Token: 0x0400030D RID: 781
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeTrozoDelantero;

		// Token: 0x0400030E RID: 782
		public static readonly IReadOnlyCollection<int> partesDeTrozoDelanteroSet;

		// Token: 0x0400030F RID: 783
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionFemenina;

		// Token: 0x04000310 RID: 784
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionOral;

		// Token: 0x04000311 RID: 785
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionVaginal;

		// Token: 0x04000312 RID: 786
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionAnal;

		// Token: 0x04000313 RID: 787
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionNalgas;

		// Token: 0x04000314 RID: 788
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionSenos;

		// Token: 0x04000315 RID: 789
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionRostro;

		// Token: 0x04000316 RID: 790
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionGlobosOculares;

		// Token: 0x04000317 RID: 791
		public static readonly IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccionCuerpoFemenino;

		// Token: 0x04000318 RID: 792
		public static readonly IReadOnlyCollection<int> partesDeInteraccionFemeninaSet;

		// Token: 0x04000319 RID: 793
		public static readonly IReadOnlyCollection<int> partesDeInteraccionOralSet;

		// Token: 0x0400031A RID: 794
		public static readonly IReadOnlyCollection<int> partesDeInteraccionVaginalSet;

		// Token: 0x0400031B RID: 795
		public static readonly IReadOnlyCollection<int> partesDeInteraccionAnalSet;

		// Token: 0x0400031C RID: 796
		public static readonly IReadOnlyCollection<int> partesDeInteraccionNalgasSet;

		// Token: 0x0400031D RID: 797
		public static readonly IReadOnlyCollection<int> partesDeInteraccionSenosSet;

		// Token: 0x0400031E RID: 798
		public static readonly IReadOnlyCollection<int> partesDeInteraccionRostroSet;

		// Token: 0x0400031F RID: 799
		public static readonly IReadOnlyCollection<int> partesDeInteraccionGlobosOcularesSet;

		// Token: 0x04000320 RID: 800
		public static readonly IReadOnlyCollection<int> partesDeInteraccionCuerpoFemeninoSet;
	}
}

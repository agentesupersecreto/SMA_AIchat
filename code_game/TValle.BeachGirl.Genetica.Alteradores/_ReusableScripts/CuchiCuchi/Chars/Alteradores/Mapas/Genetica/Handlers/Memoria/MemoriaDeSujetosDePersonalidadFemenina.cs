using System;
using System.Collections.Generic;
using System.Text;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers.Memoria
{
	// Token: 0x0200007A RID: 122
	[MemoriaFunctions]
	public sealed class MemoriaDeSujetosDePersonalidadFemenina : CustomMonobehaviour, ISujetosMemoria<ISujetoIdentificable>
	{
		// Token: 0x060005CD RID: 1485 RVA: 0x0001594B File Offset: 0x00013B4B
		public static bool Contiene(IMemoria memoria, string PersonalidadID)
		{
			return !string.IsNullOrEmpty(PersonalidadID) && MemoriaDeSujetosDePersonalidadFemenina.LeerNodeDesdeMemoria(memoria, PersonalidadID) != null;
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00015964 File Offset: 0x00013B64
		public static bool EsValido(IMemoria memoria, string PersonalidadID)
		{
			if (string.IsNullOrEmpty(PersonalidadID))
			{
				return false;
			}
			IJsonMemoryNode jsonMemoryNode = MemoriaDeSujetosDePersonalidadFemenina.LeerNodeDesdeMemoria(memoria, PersonalidadID);
			return jsonMemoryNode != null && MapaDeAlteradoresAMemoriaUtil.IsValid(jsonMemoryNode);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00015990 File Offset: 0x00013B90
		public static T_Mapa LeerMapaDesdeMemoria<T_Mapa>(IMemoria memoria, string PersonalidadID) where T_Mapa : MapaDeAlteracionesPersonalidadFemeninaBase
		{
			IJsonMemoryNode jsonMemoryNode;
			return MemoriaDeSujetosDePersonalidadFemenina.LeerMapaDesdeMemoria<T_Mapa>(memoria, PersonalidadID, out jsonMemoryNode);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x000159A8 File Offset: 0x00013BA8
		public static T_Mapa LeerMapaDesdeMemoria<T_Mapa>(IMemoria memoria, string PersonalidadID, out IJsonMemoryNode node) where T_Mapa : MapaDeAlteracionesPersonalidadFemeninaBase
		{
			node = MemoriaDeSujetosDePersonalidadFemenina.LeerNodeDesdeMemoria(memoria, PersonalidadID);
			if (node == null)
			{
				return default(T_Mapa);
			}
			T_Mapa t_Mapa = ScriptableObject.CreateInstance<T_Mapa>();
			MapaDeAlteradoresAMemoriaUtil.AMapa(t_Mapa, node);
			return t_Mapa;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000159E0 File Offset: 0x00013BE0
		public static IJsonMemoryNode EscribirMapaAMemoria(IMemoria memoria, string PersonalidadID, MapaDeAlteracionesPersonalidadFemeninaBase mapa)
		{
			string text = "root/Personalidad/" + PersonalidadID;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			MapaDeAlteradoresAMemoriaUtil.ANode(jsonMemoryNode, mapa);
			return jsonMemoryNode;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00015A08 File Offset: 0x00013C08
		public static IJsonMemoryNode LeerNodeDesdeMemoria(IMemoria memoria, string PersonalidadID)
		{
			string text = "root/Personalidad/" + PersonalidadID;
			return memoria.LeerDeep(text, false);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00015A2C File Offset: 0x00013C2C
		public static IJsonMemoryNode BorrarPersonalidadMapa(IMemoria memoria, string PersonalidadID, bool forzar)
		{
			string text = "root/Personalidad/" + PersonalidadID;
			if (!forzar)
			{
				IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text + "/referencias", false);
				if (jsonMemoryNode != null)
				{
					IReadOnlyDictionary<string, string> data = jsonMemoryNode.data;
					if (data.Count > 0)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append(string.Concat(new string[]
						{
							"Sujeto de Personalidad: ",
							PersonalidadID,
							" cant be deleted, it has ",
							data.Count.ToString(),
							" references:"
						}));
						foreach (KeyValuePair<string, string> keyValuePair in data)
						{
							stringBuilder.Append(" ");
							stringBuilder.Append(keyValuePair.Key + "->" + keyValuePair.Value);
						}
						if (Application.isEditor)
						{
							Debug.LogError(stringBuilder.ToString());
						}
						else
						{
							Debug.LogWarning(stringBuilder.ToString());
						}
						return null;
					}
				}
			}
			return memoria.RemoverDeep(text);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00015B4C File Offset: 0x00013D4C
		public static ISujetoIdentificable LeerSujetoDesdeMemoria(IMemoria memoria, string PersonalidadID)
		{
			IJsonMemoryNode jsonMemoryNode;
			MapaDeAlteracionesPersonalidadFemeninaIndependiente mapaDeAlteracionesPersonalidadFemeninaIndependiente = MemoriaDeSujetosDePersonalidadFemenina.LeerMapaDesdeMemoria<MapaDeAlteracionesPersonalidadFemeninaIndependiente>(memoria, PersonalidadID, out jsonMemoryNode);
			if (mapaDeAlteracionesPersonalidadFemeninaIndependiente == null)
			{
				return null;
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
			sujetoIdentificableAlteradoresPersonalidadFemeninos.@base = mapaDeAlteracionesPersonalidadFemeninaIndependiente;
			sujetoIdentificableAlteradoresPersonalidadFemeninos.nivel = jsonMemoryNode.FindDataInt("Nivel", 0);
			int num = jsonMemoryNode.FindDataInt("Version", 0);
			if (num == 0)
			{
				MemoriaDeSujetosDePersonalidadFemenina.LoadFitnessZeroToOne(jsonMemoryNode, sujetoIdentificableAlteradoresPersonalidadFemeninos);
				jsonMemoryNode.AddData("Version", 1, true);
			}
			else
			{
				if (num != 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				MemoriaDeSujetosDePersonalidadFemenina.LoadFitnessSameVersion(jsonMemoryNode, sujetoIdentificableAlteradoresPersonalidadFemeninos);
			}
			sujetoIdentificableAlteradoresPersonalidadFemeninos.name = PersonalidadID;
			sujetoIdentificableAlteradoresPersonalidadFemeninos.sujetoID = Guid.Parse(PersonalidadID);
			return sujetoIdentificableAlteradoresPersonalidadFemeninos;
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00015BDC File Offset: 0x00013DDC
		private static void LoadFitnessSameVersion(IJsonMemoryNode Mem, SujetoIdentificableAlteradoresPersonalidadFemeninos sujeto)
		{
			foreach (KeyValuePair<string, string> keyValuePair in Mem.data)
			{
				if (keyValuePair.Key.StartsWith("Fitness_"))
				{
					string text = keyValuePair.Key.Replace("Fitness_", "");
					IConjuntoDeGenes conjuntoDeGenes;
					if (!sujeto.conjuntoPorNombre.TryGetValue(text, out conjuntoDeGenes))
					{
						Debug.LogError("No se encontro conjunto con nombre: " + text + ", se cargara con fitness zero...", sujeto);
					}
					conjuntoDeGenes.fitnes = keyValuePair.Value.DataToFloat(0f);
				}
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00015C8C File Offset: 0x00013E8C
		private static void LoadFitnessZeroToOne(IJsonMemoryNode Mem, SujetoIdentificableAlteradoresPersonalidadFemeninos sujeto)
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (KeyValuePair<string, string> keyValuePair in Mem.data)
			{
				if (keyValuePair.Key.StartsWith("Fitness_"))
				{
					IReadOnlyList<string> readOnlyList = ConjuntosDePersonalidad.OldVersion0.ParceName0To1(keyValuePair.Key.Replace("Fitness_", ""));
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						string text = readOnlyList[i];
						IConjuntoDeGenes conjuntoDeGenes;
						if (!sujeto.conjuntoPorNombre.TryGetValue(text, out conjuntoDeGenes))
						{
							Debug.LogError("No se encontro conjunto con nombre: " + text + ", se cargara con fitness zero...", sujeto);
						}
						else
						{
							conjuntoDeGenes.fitnes = keyValuePair.Value.DataToFloat(0f);
							hashSet.Add(keyValuePair.Key);
						}
					}
				}
			}
			foreach (string text2 in hashSet)
			{
				Mem.RemoverData(text2);
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00015DC0 File Offset: 0x00013FC0
		public static void EscribirSujetoAMemoria(IMemoria memoria, ISujetoIdentificable personalidad)
		{
			MemoriaDeSujetosDePersonalidadFemenina.EscribirMapaAMemoria(memoria, personalidad.sujetoID.ToString(), ((SujetoIdentificableAlteradoresPersonalidadFemeninos)personalidad).@base);
			MemoriaDeSujetosDePersonalidadFemenina.Escribir_DATA_DeSujetoAMemoria(memoria, personalidad);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00015DFC File Offset: 0x00013FFC
		public static void Escribir_DATA_DeSujetoAMemoria(IMemoria memoria, ISujetoIdentificable personalidad)
		{
			string text = "root/Personalidad/" + personalidad.sujetoID.ToString();
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			ISujetoNivel sujetoNivel = personalidad as ISujetoNivel;
			jsonMemoryNode.AddData("Nivel", (sujetoNivel != null) ? sujetoNivel.nivel : 0, true);
			jsonMemoryNode.AddData("Version", 1, true);
			foreach (IConjuntoDeGenes conjuntoDeGenes in personalidad.conjuntos)
			{
				jsonMemoryNode.AddData("Fitness_" + conjuntoDeGenes.conjuntoName, conjuntoDeGenes.fitnes, true);
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00015EBC File Offset: 0x000140BC
		public static void BorrarPersonalidadSujeto(IMemoria memoria, string sujetoID, bool forzar)
		{
			MemoriaDeSujetosDePersonalidadFemenina.BorrarPersonalidadMapa(memoria, sujetoID, forzar);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00015EC8 File Offset: 0x000140C8
		public static void SetSujetoReferencia(IMemoria memoria, string sujetoID, string dataID, string value)
		{
			string text = "root/Personalidad/" + sujetoID + "/referencias";
			memoria.LeerDeep(text, true).AddData(dataID, value, true);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00015EF8 File Offset: 0x000140F8
		public static string GetSujetoReferencia(IMemoria memoria, string sujetoID, string dataID)
		{
			string text = "root/Personalidad/" + sujetoID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			return jsonMemoryNode.FindData(dataID);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00015F2C File Offset: 0x0001412C
		public static void DeleteSujetoReferencia(IMemoria memoria, string sujetoID, string dataID)
		{
			string text = "root/Personalidad/" + sujetoID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return;
			}
			jsonMemoryNode.RemoverData(dataID);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x00015F5F File Offset: 0x0001415F
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00015F6F File Offset: 0x0001416F
		public ISujetoIdentificable LeerSujetoEnMemoria(string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDePersonalidadFemenina.LeerSujetoDesdeMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujetoID);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00015F8C File Offset: 0x0001418C
		public bool EscribirSujetoEnMemoria(string sujetoID, ISujetoIdentificable sujeto)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			bool flag;
			try
			{
				if (sujetoID != sujeto.sujetoID.ToString())
				{
					throw new InvalidOperationException();
				}
				MemoriaDeSujetosDePersonalidadFemenina.EscribirSujetoAMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujeto);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00015FF4 File Offset: 0x000141F4
		public void BorrarSujetoEnMemoria(string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosDePersonalidadFemenina.BorrarPersonalidadSujeto(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, false);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001600F File Offset: 0x0001420F
		bool ISujetosMemoria<ISujetoIdentificable>.Contiene(string PersonalidadID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDePersonalidadFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, PersonalidadID);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00016029 File Offset: 0x00014229
		bool ISujetosMemoria<ISujetoIdentificable>.EsValido(string PersonalidadID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDePersonalidadFemenina.EsValido(GlobalSingletonV2<MemoriaJson>.instance, PersonalidadID);
		}

		// Token: 0x04000263 RID: 611
		public const string Nivel = "Nivel";

		// Token: 0x04000264 RID: 612
		public const string Version = "Version";

		// Token: 0x04000265 RID: 613
		public const int CurrentVersion = 1;

		// Token: 0x04000266 RID: 614
		public const string Fitness = "Fitness_";
	}
}

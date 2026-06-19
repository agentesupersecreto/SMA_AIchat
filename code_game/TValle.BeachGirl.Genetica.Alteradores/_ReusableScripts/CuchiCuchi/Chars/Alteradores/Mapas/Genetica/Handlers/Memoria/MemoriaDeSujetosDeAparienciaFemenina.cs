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
	// Token: 0x02000079 RID: 121
	[MemoriaFunctions]
	public sealed class MemoriaDeSujetosDeAparienciaFemenina : CustomMonobehaviour, ISujetosMemoria<ISujetoIdentificable>
	{
		// Token: 0x060005B6 RID: 1462 RVA: 0x0001524C File Offset: 0x0001344C
		public static bool Contiene(IMemoria memoria, string AparienciaID)
		{
			return !string.IsNullOrEmpty(AparienciaID) && MemoriaDeSujetosDeAparienciaFemenina.LeerNodeDesdeMemoria(memoria, AparienciaID) != null;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00015264 File Offset: 0x00013464
		public static bool EsValido(IMemoria memoria, string AparienciaID)
		{
			if (string.IsNullOrEmpty(AparienciaID))
			{
				return false;
			}
			IJsonMemoryNode jsonMemoryNode = MemoriaDeSujetosDeAparienciaFemenina.LeerNodeDesdeMemoria(memoria, AparienciaID);
			return jsonMemoryNode != null && MapaDeAlteradoresAMemoriaUtil.IsValid(jsonMemoryNode);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00015290 File Offset: 0x00013490
		public static T_Mapa LeerMapaDesdeMemoria<T_Mapa>(IMemoria memoria, string AparienciaID) where T_Mapa : MapaDeAlteracionesAparienciaFemeninaBase
		{
			IJsonMemoryNode jsonMemoryNode;
			return MemoriaDeSujetosDeAparienciaFemenina.LeerMapaDesdeMemoria<T_Mapa>(memoria, AparienciaID, out jsonMemoryNode);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000152A8 File Offset: 0x000134A8
		public static T_Mapa LeerMapaDesdeMemoria<T_Mapa>(IMemoria memoria, string AparienciaID, out IJsonMemoryNode node) where T_Mapa : MapaDeAlteracionesAparienciaFemeninaBase
		{
			node = MemoriaDeSujetosDeAparienciaFemenina.LeerNodeDesdeMemoria(memoria, AparienciaID);
			if (node == null)
			{
				return default(T_Mapa);
			}
			T_Mapa t_Mapa = ScriptableObject.CreateInstance<T_Mapa>();
			MapaDeAlteradoresAMemoriaUtil.AMapa(t_Mapa, node);
			return t_Mapa;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x000152E0 File Offset: 0x000134E0
		public static IJsonMemoryNode EscribirMapaAMemoria(IMemoria memoria, string AparienciaID, MapaDeAlteracionesAparienciaFemeninaBase mapa)
		{
			string text = "root/AparienciaFisica/" + AparienciaID;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			MapaDeAlteradoresAMemoriaUtil.ANode(jsonMemoryNode, mapa);
			return jsonMemoryNode;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00015308 File Offset: 0x00013508
		public static IJsonMemoryNode LeerNodeDesdeMemoria(IMemoria memoria, string AparienciaID)
		{
			string text = "root/AparienciaFisica/" + AparienciaID;
			return memoria.LeerDeep(text, false);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001532C File Offset: 0x0001352C
		public static IJsonMemoryNode BorrarNodeEnMemoria(IMemoria memoria, string AparienciaID, bool forzar)
		{
			string text = "root/AparienciaFisica/" + AparienciaID;
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
							"Sujeto de Apariencia: ",
							AparienciaID,
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

		// Token: 0x060005BD RID: 1469 RVA: 0x0001544C File Offset: 0x0001364C
		public static ISujetoIdentificable LeerSujetoDesdeMemoria(IMemoria memoria, string AparienciaID)
		{
			IJsonMemoryNode jsonMemoryNode;
			MapaDeAlteracionesAparienciaFemeninaIndependiente mapaDeAlteracionesAparienciaFemeninaIndependiente = MemoriaDeSujetosDeAparienciaFemenina.LeerMapaDesdeMemoria<MapaDeAlteracionesAparienciaFemeninaIndependiente>(memoria, AparienciaID, out jsonMemoryNode);
			if (mapaDeAlteracionesAparienciaFemeninaIndependiente == null)
			{
				return null;
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
			sujetoIdentificableAlteradoresAparienciaFemeninos.@base = mapaDeAlteracionesAparienciaFemeninaIndependiente;
			sujetoIdentificableAlteradoresAparienciaFemeninos.nivel = jsonMemoryNode.FindDataInt("Nivel", 0);
			int num = jsonMemoryNode.FindDataInt("Version", 0);
			if (num == 0)
			{
				MemoriaDeSujetosDeAparienciaFemenina.LoadFitnessZeroToOne(jsonMemoryNode, sujetoIdentificableAlteradoresAparienciaFemeninos);
				jsonMemoryNode.AddData("Version", 1, true);
			}
			else
			{
				if (num != 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				MemoriaDeSujetosDeAparienciaFemenina.LoadFitnessSameVersion(jsonMemoryNode, sujetoIdentificableAlteradoresAparienciaFemeninos);
			}
			sujetoIdentificableAlteradoresAparienciaFemeninos.name = AparienciaID;
			sujetoIdentificableAlteradoresAparienciaFemeninos.sujetoID = Guid.Parse(AparienciaID);
			return sujetoIdentificableAlteradoresAparienciaFemeninos;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x000154DC File Offset: 0x000136DC
		private static void LoadFitnessSameVersion(IJsonMemoryNode Mem, SujetoIdentificableAlteradoresAparienciaFemeninos sujeto)
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
					else
					{
						conjuntoDeGenes.fitnes = keyValuePair.Value.DataToFloat(0f);
					}
				}
			}
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001558C File Offset: 0x0001378C
		private static void LoadFitnessZeroToOne(IJsonMemoryNode Mem, SujetoIdentificableAlteradoresAparienciaFemeninos sujeto)
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (KeyValuePair<string, string> keyValuePair in Mem.data)
			{
				if (keyValuePair.Key.StartsWith("Fitness_"))
				{
					IReadOnlyList<string> readOnlyList = ConjuntosDeAparienciaFisica.OldVersion0.ParceName0To1(keyValuePair.Key.Replace("Fitness_", ""));
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

		// Token: 0x060005C0 RID: 1472 RVA: 0x000156C0 File Offset: 0x000138C0
		public static void EscribirSujetoAMemoria(IMemoria memoria, ISujetoIdentificable apariencia)
		{
			MemoriaDeSujetosDeAparienciaFemenina.EscribirMapaAMemoria(memoria, apariencia.sujetoID.ToString(), ((SujetoIdentificableAlteradoresAparienciaFemeninos)apariencia).@base);
			MemoriaDeSujetosDeAparienciaFemenina.Escribir_DATA_DeSujetoAMemoria(memoria, apariencia);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x000156FC File Offset: 0x000138FC
		public static void Escribir_DATA_DeSujetoAMemoria(IMemoria memoria, ISujetoIdentificable apariencia)
		{
			string text = "root/AparienciaFisica/" + apariencia.sujetoID.ToString();
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			ISujetoNivel sujetoNivel = apariencia as ISujetoNivel;
			jsonMemoryNode.AddData("Nivel", (sujetoNivel != null) ? sujetoNivel.nivel : 0, true);
			jsonMemoryNode.AddData("Version", 1, true);
			foreach (IConjuntoDeGenes conjuntoDeGenes in apariencia.conjuntos)
			{
				jsonMemoryNode.AddData("Fitness_" + conjuntoDeGenes.conjuntoName, conjuntoDeGenes.fitnes, true);
			}
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x000157BC File Offset: 0x000139BC
		public static void BorrarAparienciaSujeto(IMemoria memoria, string sujetoID, bool forzar)
		{
			MemoriaDeSujetosDeAparienciaFemenina.BorrarNodeEnMemoria(memoria, sujetoID, forzar);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x000157C8 File Offset: 0x000139C8
		public static void SetSujetoReferencia(IMemoria memoria, string sujetoID, string dataID, string value)
		{
			string text = "root/AparienciaFisica/" + sujetoID + "/referencias";
			memoria.LeerDeep(text, true).AddData(dataID, value, true);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x000157F8 File Offset: 0x000139F8
		public static string GetSujetoReferencia(IMemoria memoria, string sujetoID, string dataID)
		{
			string text = "root/AparienciaFisica/" + sujetoID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			return jsonMemoryNode.FindData(dataID);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0001582C File Offset: 0x00013A2C
		public static void DeleteSujetoReferencia(IMemoria memoria, string sujetoID, string dataID)
		{
			string text = "root/AparienciaFisica/" + sujetoID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return;
			}
			jsonMemoryNode.RemoverData(dataID);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001585F File Offset: 0x00013A5F
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001586F File Offset: 0x00013A6F
		public ISujetoIdentificable LeerSujetoEnMemoria(string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDeAparienciaFemenina.LeerSujetoDesdeMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujetoID);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001588C File Offset: 0x00013A8C
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
				MemoriaDeSujetosDeAparienciaFemenina.EscribirSujetoAMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujeto);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x000158F4 File Offset: 0x00013AF4
		public void BorrarSujetoEnMemoria(string sujetoID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosDeAparienciaFemenina.BorrarAparienciaSujeto(GlobalSingletonV2<MemoriaJson>.instance, sujetoID, false);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001590F File Offset: 0x00013B0F
		bool ISujetosMemoria<ISujetoIdentificable>.Contiene(string AparienciaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDeAparienciaFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, AparienciaID);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00015929 File Offset: 0x00013B29
		bool ISujetosMemoria<ISujetoIdentificable>.EsValido(string AparienciaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosDeAparienciaFemenina.EsValido(GlobalSingletonV2<MemoriaJson>.instance, AparienciaID);
		}

		// Token: 0x0400025F RID: 607
		public const string Nivel = "Nivel";

		// Token: 0x04000260 RID: 608
		public const string Version = "Version";

		// Token: 0x04000261 RID: 609
		public const int CurrentVersion = 1;

		// Token: 0x04000262 RID: 610
		public const string Fitness = "Fitness_";
	}
}

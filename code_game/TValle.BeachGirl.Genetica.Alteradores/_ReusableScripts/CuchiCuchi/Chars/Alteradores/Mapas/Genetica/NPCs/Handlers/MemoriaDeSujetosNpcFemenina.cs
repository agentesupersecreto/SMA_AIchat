using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers.Memoria;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers
{
	// Token: 0x02000073 RID: 115
	[MemoriaFunctions]
	[RequireComponent(typeof(IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>))]
	public class MemoriaDeSujetosNpcFemenina : CustomMonobehaviour, ISujetosNpcMemoria<ISujetoIdentificableNpc>
	{
		// Token: 0x06000567 RID: 1383 RVA: 0x00013400 File Offset: 0x00011600
		public static void ObtenerTODOS_NPCs_IDs(IMemoria memoria, List<string> idsResultado)
		{
			foreach (IMemoryNode<string, string> memoryNode in memoria.LeerDeep("root/NPC/", false).children)
			{
				idsResultado.Add(memoryNode.nodeID);
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00013460 File Offset: 0x00011660
		public static bool Contiene(IMemoria memoria, string npcID)
		{
			if (string.IsNullOrEmpty(npcID))
			{
				return false;
			}
			string text = "root/NPC/" + npcID;
			return memoria.LeerDeep(text, false) != null;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00013490 File Offset: 0x00011690
		public static bool EsValido(IMemoria memoria, string npcID)
		{
			if (string.IsNullOrEmpty(npcID))
			{
				return false;
			}
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return false;
			}
			string text2 = jsonMemoryNode.FindData("AparienciaFisica");
			string text3 = ((text2 != null) ? text2.ToString() : null);
			string text4 = jsonMemoryNode.FindData("Personalidad");
			string text5 = ((text4 != null) ? text4.ToString() : null);
			return !string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text5) && MemoriaDeSujetosDeAparienciaFemenina.EsValido(memoria, text3) && MemoriaDeSujetosDePersonalidadFemenina.EsValido(memoria, text5);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001351C File Offset: 0x0001171C
		public static ISujetoIdentificableNpc LeerNpcEnMemoriaFirstOrDefault(IMemoria memoria)
		{
			string text = "root/NPC/";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			IMemoryNode<string, string> memoryNode = jsonMemoryNode.children.FirstOrDefault<IMemoryNode<string, string>>();
			if (memoryNode == null)
			{
				return null;
			}
			return MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(memoria, memoryNode.nodeID);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001355C File Offset: 0x0001175C
		public static void SetNpcReferencia(IMemoria memoria, string npcID, string dataID, string value)
		{
			string text = "root/NPC/" + npcID + "/referencias";
			memoria.LeerDeep(text, true).AddData(dataID, value, true);
			string text2 = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text2, false);
			if (jsonMemoryNode == null)
			{
				Debug.LogError("No se pudo definir referencias de sub mapas apariencia y personaldiad");
				return;
			}
			string text3 = jsonMemoryNode.FindData("AparienciaFisica");
			string text4 = ((text3 != null) ? text3.ToString() : null);
			string text5 = jsonMemoryNode.FindData("Personalidad");
			string text6 = ((text5 != null) ? text5.ToString() : null);
			if (!string.IsNullOrWhiteSpace(text4))
			{
				MemoriaDeSujetosDeAparienciaFemenina.SetSujetoReferencia(memoria, text4, dataID, value);
			}
			else
			{
				Debug.LogError(string.Concat(new string[] { "Npc ", npcID, " no tiene apariencia para add reference: ", dataID, " con valor ", value }));
			}
			if (!string.IsNullOrWhiteSpace(text6))
			{
				MemoriaDeSujetosDePersonalidadFemenina.SetSujetoReferencia(memoria, text6, dataID, value);
				return;
			}
			Debug.LogError(string.Concat(new string[] { "Npc ", npcID, " no tiene personalidad para add reference: ", dataID, " con valor ", value }));
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00013670 File Offset: 0x00011870
		public static string GetNpcReferencia(IMemoria memoria, string npcID, string dataID)
		{
			string text = "root/NPC/" + npcID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			string text2 = jsonMemoryNode.FindData(dataID);
			string text3 = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode2 = memoria.LeerDeep(text3, false);
			if (jsonMemoryNode2 == null)
			{
				Debug.LogError("No se pudo Obtener referencias de sub mapas apariencia y personaldiad");
				return text2;
			}
			string text4 = jsonMemoryNode2.FindData("AparienciaFisica");
			string text5 = ((text4 != null) ? text4.ToString() : null);
			string text6 = jsonMemoryNode2.FindData("Personalidad");
			string text7 = ((text6 != null) ? text6.ToString() : null);
			if (!string.IsNullOrWhiteSpace(text5))
			{
				string sujetoReferencia = MemoriaDeSujetosDeAparienciaFemenina.GetSujetoReferencia(memoria, text5, dataID);
				if (sujetoReferencia != text2)
				{
					Debug.LogError("La referencia de npc y de apariencia son diferentes: " + sujetoReferencia + " " + text2);
				}
			}
			if (!string.IsNullOrWhiteSpace(text7))
			{
				string sujetoReferencia2 = MemoriaDeSujetosDePersonalidadFemenina.GetSujetoReferencia(memoria, text7, dataID);
				if (sujetoReferencia2 != text2)
				{
					Debug.LogError("La referencia de npc y de personalidad son diferentes: " + sujetoReferencia2 + " " + text2);
				}
			}
			return text2;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001376C File Offset: 0x0001196C
		public static void DeleteNpcReferencia(IMemoria memoria, string npcID, string dataID)
		{
			string text = "root/NPC/" + npcID + "/referencias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return;
			}
			jsonMemoryNode.RemoverData(dataID);
			string text2 = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode2 = memoria.LeerDeep(text2, false);
			if (jsonMemoryNode2 == null)
			{
				Debug.LogError("No se pudo Borrar referencias de sub mapas apariencia y personaldiad");
				return;
			}
			string text3 = jsonMemoryNode2.FindData("AparienciaFisica");
			string text4 = ((text3 != null) ? text3.ToString() : null);
			string text5 = jsonMemoryNode2.FindData("Personalidad");
			string text6 = ((text5 != null) ? text5.ToString() : null);
			if (!string.IsNullOrWhiteSpace(text4))
			{
				MemoriaDeSujetosDeAparienciaFemenina.DeleteSujetoReferencia(memoria, text4, dataID);
			}
			if (!string.IsNullOrWhiteSpace(text6))
			{
				MemoriaDeSujetosDePersonalidadFemenina.DeleteSujetoReferencia(memoria, text6, dataID);
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00013818 File Offset: 0x00011A18
		public static ISujetoIdentificableNpc LeerNpcEnMemoria(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			string text2 = jsonMemoryNode.FindData("AparienciaFisica");
			string text3 = ((text2 != null) ? text2.ToString() : null);
			string text4 = jsonMemoryNode.FindData("Personalidad");
			string text5 = ((text4 != null) ? text4.ToString() : null);
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableNpcAlteradoresFemeninos>();
			sujetoIdentificableNpcAlteradoresFemeninos.name = npcID;
			sujetoIdentificableNpcAlteradoresFemeninos.NpcID = Guid.Parse(npcID);
			if (!string.IsNullOrWhiteSpace(text3))
			{
				sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisicaMapa = MemoriaDeSujetosDeAparienciaFemenina.LeerSujetoDesdeMemoria(memoria, text3) as SujetoIdentificableAlteradoresAparienciaFemeninos;
				if (sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisicaMapa == null)
				{
					Debug.LogWarning("No existia apariencia: " + text3 + " en memoria");
					sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisicaMapa = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
				}
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				sujetoIdentificableNpcAlteradoresFemeninos.personalidadMapa = MemoriaDeSujetosDePersonalidadFemenina.LeerSujetoDesdeMemoria(memoria, text5) as SujetoIdentificableAlteradoresPersonalidadFemeninos;
				if (sujetoIdentificableNpcAlteradoresFemeninos.personalidadMapa == null)
				{
					Debug.LogWarning("No existia personalidad: " + text5 + " en memoria");
					sujetoIdentificableNpcAlteradoresFemeninos.personalidadMapa = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
				}
			}
			foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNode.data)
			{
				sujetoIdentificableNpcAlteradoresFemeninos.dataContainer.AddData(keyValuePair.Key, keyValuePair.Value, true);
			}
			return sujetoIdentificableNpcAlteradoresFemeninos;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00013980 File Offset: 0x00011B80
		public static void EscribirNpcEnMemoria(IMemoria memoria, ISujetoIdentificableNpc npc)
		{
			string text = npc.NpcID.ToString();
			string text2 = "root/NPC/" + text;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text2);
			if (npc.aparienciaFisica != null)
			{
				string text3 = npc.aparienciaFisica.sujetoID.ToString();
				jsonMemoryNode.AddData("AparienciaFisica", text3, true);
				npc.dataContainer.AddData("AparienciaFisica", text3, true);
				MemoriaDeSujetosDeAparienciaFemenina.EscribirSujetoAMemoria(memoria, npc.aparienciaFisica);
				MemoriaDeSujetosDeAparienciaFemenina.SetSujetoReferencia(memoria, npc.aparienciaFisica.sujetoID.ToString(), "belongToNPC", npc.NpcID.ToString());
			}
			if (npc.personalidad != null)
			{
				string text4 = npc.personalidad.sujetoID.ToString();
				jsonMemoryNode.AddData("Personalidad", text4, true);
				npc.dataContainer.AddData("Personalidad", text4, true);
				MemoriaDeSujetosDePersonalidadFemenina.EscribirSujetoAMemoria(memoria, npc.personalidad);
				MemoriaDeSujetosDePersonalidadFemenina.SetSujetoReferencia(memoria, npc.personalidad.sujetoID.ToString(), "belongToNPC", npc.NpcID.ToString());
			}
			foreach (KeyValuePair<string, string> keyValuePair in npc.GetAllData())
			{
				if (!MemoriaDeSujetosNpcFemenina.IgnorarDataKeys.Contains(keyValuePair.Key))
				{
					jsonMemoryNode.AddData(keyValuePair.Key, keyValuePair.Value, true);
				}
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00013B34 File Offset: 0x00011D34
		public static void Escribir_DATA_DeNpcAMemoria(IMemoria memoria, ISujetoIdentificableNpc npc)
		{
			string text = npc.NpcID.ToString();
			string text2 = "root/NPC/" + text;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text2);
			foreach (KeyValuePair<string, string> keyValuePair in npc.GetAllData())
			{
				if (!MemoriaDeSujetosNpcFemenina.IgnorarDataKeys.Contains(keyValuePair.Key))
				{
					jsonMemoryNode.AddData(keyValuePair.Key, keyValuePair.Value, true);
				}
			}
			MemoriaDeSujetosDeAparienciaFemenina.Escribir_DATA_DeSujetoAMemoria(memoria, npc.aparienciaFisica);
			MemoriaDeSujetosDePersonalidadFemenina.Escribir_DATA_DeSujetoAMemoria(memoria, npc.personalidad);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00013BEC File Offset: 0x00011DEC
		public static void EscribirPortraitDeNpcAMemoria(IMemoria memoria, ISujetoIdentificableNpc npc, Texture2D portrait)
		{
			if (portrait == null)
			{
				return;
			}
			string text = npc.NpcID.ToString();
			string text2 = "root/NPC/" + text;
			memoria.EscribirDeep(text2).AddData("Portrait", portrait, true);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00013C38 File Offset: 0x00011E38
		public static void RemoverPortraitDeNpcAMemoria(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID;
			memoria.EscribirDeep(text).RemoverData("Portrait");
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00013C63 File Offset: 0x00011E63
		public static void EscribirNpcAMemoriaCompleto(IMemoria memoria, ISujetoIdentificableNpc npc, Texture2D portrait = null)
		{
			MemoriaDeSujetosNpcFemenina.EscribirNpcEnMemoria(memoria, npc);
			MemoriaDeSujetosNpcFemenina.Escribir_DATA_DeNpcAMemoria(memoria, npc);
			if (portrait != null)
			{
				MemoriaDeSujetosNpcFemenina.EscribirPortraitDeNpcAMemoria(memoria, npc, portrait);
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00013C84 File Offset: 0x00011E84
		public static void BorrarNpcEnMemoria(IMemoria memoria, string npcID, bool forzar)
		{
			string text = "root/NPC/" + npcID;
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
							"NPC: ",
							npcID,
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
							return;
						}
						Debug.LogWarning(stringBuilder.ToString());
						return;
					}
				}
			}
			IJsonMemoryNode jsonMemoryNode2 = memoria.RemoverDeep(text);
			if (jsonMemoryNode2 == null)
			{
				return;
			}
			string text2 = jsonMemoryNode2.FindData("AparienciaFisica");
			string text3 = ((text2 != null) ? text2.ToString() : null);
			string text4 = jsonMemoryNode2.FindData("Personalidad");
			string text5 = ((text4 != null) ? text4.ToString() : null);
			if (!string.IsNullOrWhiteSpace(text3))
			{
				MemoriaDeSujetosDeAparienciaFemenina.DeleteSujetoReferencia(memoria, text3, "belongToNPC");
				MemoriaDeSujetosDeAparienciaFemenina.BorrarNodeEnMemoria(memoria, text3, forzar);
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				MemoriaDeSujetosDePersonalidadFemenina.DeleteSujetoReferencia(memoria, text5, "belongToNPC");
				MemoriaDeSujetosDePersonalidadFemenina.BorrarPersonalidadMapa(memoria, text5, forzar);
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00013E1C File Offset: 0x0001201C
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00013E2C File Offset: 0x0001202C
		public string LeerData(string npcID, string key)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			return jsonMemoryNode.FindData(key);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00013E5E File Offset: 0x0001205E
		public ISujetoIdentificableNpc LeerSujetoNpcEnMemoria(string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00013E78 File Offset: 0x00012078
		public bool EscribirSujetoEnMemoria(string npcID, ISujetoIdentificableNpc sujeto)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			bool flag;
			try
			{
				if (npcID != sujeto.NpcID.ToString())
				{
					throw new InvalidOperationException();
				}
				MemoriaDeSujetosNpcFemenina.EscribirNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujeto);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00013EE0 File Offset: 0x000120E0
		public bool Escribir_DATA_DeNpcAMemoria(string npcID, ISujetoIdentificableNpc sujeto)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			bool flag;
			try
			{
				if (npcID != sujeto.NpcID.ToString())
				{
					throw new InvalidOperationException();
				}
				MemoriaDeSujetosNpcFemenina.Escribir_DATA_DeNpcAMemoria(GlobalSingletonV2<MemoriaJson>.instance, sujeto);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00013F48 File Offset: 0x00012148
		public void BorrarSujetoDeLaMemoria(string npcID, bool forzar)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, npcID, forzar);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00013F63 File Offset: 0x00012163
		bool ISujetosNpcMemoria<ISujetoIdentificableNpc>.Contiene(string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosNpcFemenina.Contiene(GlobalSingletonV2<MemoriaJson>.instance, npcID);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00013F7D File Offset: 0x0001217D
		bool ISujetosNpcMemoria<ISujetoIdentificableNpc>.EsValido(string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDeSujetosNpcFemenina.EsValido(GlobalSingletonV2<MemoriaJson>.instance, npcID);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00013F97 File Offset: 0x00012197
		void ISujetosNpcMemoria<ISujetoIdentificableNpc>.ObtenerTODOS_NPCs_IDs(List<string> idsResultado)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosNpcFemenina.ObtenerTODOS_NPCs_IDs(GlobalSingletonV2<MemoriaJson>.instance, idsResultado);
		}

		// Token: 0x0400024F RID: 591
		public const string sujetoReferencedDataName = "belongToNPC";

		// Token: 0x04000250 RID: 592
		public static HashSet<string> IgnorarDataKeys = new HashSet<string> { "Fatigue" };
	}
}

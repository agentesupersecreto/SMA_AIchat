using System;
using System.Collections.Generic;
using System.Globalization;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers
{
	// Token: 0x02000072 RID: 114
	[MemoriaRelatedBehaviour]
	public class MemoriaDePiscinaDeDeSujetosNpcFemenina : AplicableCustomMonobehaviour, ISujetosNpcMemoriaDePiscina<ISujetoIdentificableNpc>
	{
		// Token: 0x0600053F RID: 1343 RVA: 0x0001287C File Offset: 0x00010A7C
		public static void AddNivel(string PiscinaID, int adding)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/DATA/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, true);
			string text2 = jsonMemoryNode.FindData("NIVEL");
			if (text2 == null)
			{
				jsonMemoryNode.AddData("NIVEL", adding, true);
				return;
			}
			jsonMemoryNode.AddData("NIVEL", Convert.ToInt32(text2, CultureInfo.InvariantCulture) + adding, true);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x000128E8 File Offset: 0x00010AE8
		public static int GetNivel(string PiscinaID, int defaultValue)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/DATA/" + PiscinaID;
			return GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, true).FindDataInt("NIVEL", defaultValue);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00012928 File Offset: 0x00010B28
		public static void BorrarNivel(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/DATA/" + PiscinaID;
			GlobalSingletonV2<MemoriaJson>.instance.RemoverDeep(text);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001295C File Offset: 0x00010B5C
		[Obsolete("", true)]
		public static void LeerSubPiscinasIDs(string PiscinaID, out string subPiscinasIDApariencia, out string subPiscinasIDPersonalidad)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				string text2 = jsonMemoryNode.FindData("AparienciaFisica");
				subPiscinasIDApariencia = ((text2 != null) ? text2.ToString() : null);
				string text3 = jsonMemoryNode.FindData("Personalidad");
				subPiscinasIDPersonalidad = ((text3 != null) ? text3.ToString() : null);
				return;
			}
			subPiscinasIDApariencia = null;
			subPiscinasIDPersonalidad = null;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000129CC File Offset: 0x00010BCC
		[Obsolete("", true)]
		public static void EscribirSubPiscinasIDs(string PiscinaID, IPiscinaManager Apariencia, IPiscinaManager Personalidad)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep(text);
			if (Apariencia != null)
			{
				jsonMemoryNode.AddData("AparienciaFisica", Apariencia.ID, true);
			}
			if (Personalidad != null)
			{
				jsonMemoryNode.AddData("Personalidad", Personalidad.ID, true);
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00012A28 File Offset: 0x00010C28
		[Obsolete("", true)]
		public static void BorrarSubPiscinasIDs(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				string text2 = jsonMemoryNode.FindData("AparienciaFisica");
				string text3 = ((text2 != null) ? text2.ToString() : null);
				string text4 = jsonMemoryNode.FindData("Personalidad");
				string text5 = ((text4 != null) ? text4.ToString() : null);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					jsonMemoryNode.RemoverData(text3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					jsonMemoryNode.RemoverData(text5);
				}
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00012AB0 File Offset: 0x00010CB0
		public static bool Existe(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			return GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false) != null;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00012AE8 File Offset: 0x00010CE8
		public static bool ContieneNPC_ID(string PiscinaID, string sujetoID)
		{
			if (string.IsNullOrEmpty(sujetoID))
			{
				return false;
			}
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.data.ContainsKey(sujetoID);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00012B38 File Offset: 0x00010D38
		public static int LeerNPCsIDsCount(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				return jsonMemoryNode.data.Count;
			}
			return 0;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00012B7C File Offset: 0x00010D7C
		public static void LeerNPCsIDs(string PiscinaID, IList<string> sujetosIDsResultado)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNode.data)
				{
					sujetosIDsResultado.Add(keyValuePair.Key);
				}
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00012BF8 File Offset: 0x00010DF8
		public static void EscribirNPCsIDs(IMemoria memoria, string PiscinaID, IReadOnlyList<ISujetoIdentificableNpc> sujetos)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			foreach (ISujetoIdentificableNpc sujetoIdentificableNpc in sujetos)
			{
				string text2 = sujetoIdentificableNpc.NpcID.ToString();
				jsonMemoryNode.AddData(text2, "NPC_ID", true);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.SetNPCReferenceToPool(PiscinaID, text2);
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00012C84 File Offset: 0x00010E84
		public static void BorrarTodasLasIDsDeNPCs(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.RemoveNPCsReferenceToPool(PiscinaID);
			string text = "root/Piscinas/NPC/" + PiscinaID;
			GlobalSingletonV2<MemoriaJson>.instance.RemoverDeep(text);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00012CBC File Offset: 0x00010EBC
		public static void QuitarNPCsIDs(string PiscinaID, IReadOnlyList<ISujetoIdentificableNpc> sujetos)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				for (int i = 0; i < sujetos.Count; i++)
				{
					string text2 = sujetos[i].NpcID.ToString();
					MemoriaDePiscinaDeDeSujetosNpcFemenina.RemoveNPCReferenceToPool(PiscinaID, text2);
					jsonMemoryNode.RemoverData(text2);
				}
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00012D30 File Offset: 0x00010F30
		public static void QuitarNPCsIDs(string PiscinaID, string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = "root/Piscinas/NPC/" + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.RemoveNPCReferenceToPool(PiscinaID, npcID);
				jsonMemoryNode.RemoverData(npcID);
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00012D78 File Offset: 0x00010F78
		public static void LeerNPCs(string PiscinaID, IList<ISujetoIdentificableNpc> resultado, int maxCount = 2147483647)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDs(PiscinaID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp)
				{
					ISujetoIdentificableNpc sujetoIdentificableNpc = MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, text);
					if (sujetoIdentificableNpc == null)
					{
						Debug.LogWarning("Nose pudo leer Npc " + text + ". no existen datos");
					}
					else
					{
						resultado.Add(sujetoIdentificableNpc);
						if (resultado.Count >= maxCount)
						{
							break;
						}
					}
				}
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp.Clear();
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00012E2C File Offset: 0x0001102C
		public static IList<ISujetoIdentificableNpc> LeerNPCs(string PiscinaID, int maxCount = 2147483647)
		{
			List<ISujetoIdentificableNpc> list = new List<ISujetoIdentificableNpc>();
			MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCs(PiscinaID, list, maxCount);
			return list;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00012E48 File Offset: 0x00011048
		public static void EscribirNPCs(IMemoria memoria, string PiscinaID, IReadOnlyList<ISujetoIdentificableNpc> sujetos)
		{
			foreach (ISujetoIdentificableNpc sujetoIdentificableNpc in sujetos)
			{
				MemoriaDeSujetosNpcFemenina.EscribirNpcEnMemoria(memoria, sujetoIdentificableNpc);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.SetNPCReferenceToPool(PiscinaID, sujetoIdentificableNpc.NpcID.ToString());
			}
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00012EAC File Offset: 0x000110AC
		public static void BorrarNPCs(string PiscinaID, bool forzar)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDs(PiscinaID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp)
				{
					MemoriaDePiscinaDeDeSujetosNpcFemenina.RemoveNPCReferenceToPool(PiscinaID, text);
					MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, text, forzar);
				}
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp.Clear();
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00012F3C File Offset: 0x0001113C
		public static void SetNPCsReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDs(PiscinaID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp)
				{
					MemoriaDePiscinaDeDeSujetosNpcFemenina.SetNPCReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp.Clear();
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00012FC0 File Offset: 0x000111C0
		public static void SetNPCReferenceToPool(string PiscinaID, string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDeSujetosNpcFemenina.SetNpcReferencia(GlobalSingletonV2<MemoriaJson>.instance, npcID, "InPool", PiscinaID);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00012FE0 File Offset: 0x000111E0
		public static void RemoveNPCsReferenceToPool(string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDs(PiscinaID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp);
				foreach (string text in MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp)
				{
					MemoriaDePiscinaDeDeSujetosNpcFemenina.RemoveNPCReferenceToPool(PiscinaID, text);
				}
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_temp.Clear();
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00013064 File Offset: 0x00011264
		public static void RemoveNPCReferenceToPool(string PiscinaID, string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string npcReferencia = MemoriaDeSujetosNpcFemenina.GetNpcReferencia(GlobalSingletonV2<MemoriaJson>.instance, npcID, "InPool");
			if (npcReferencia == null)
			{
				return;
			}
			if (PiscinaID == npcReferencia)
			{
				MemoriaDeSujetosNpcFemenina.DeleteNpcReferencia(GlobalSingletonV2<MemoriaJson>.instance, npcID, "InPool");
				return;
			}
			Debug.LogError("No se pudo borrar sujeto: " + npcID + " de piscina: " + PiscinaID);
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x000130C3 File Offset: 0x000112C3
		public int Count
		{
			get
			{
				return MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDsCount(this.m_piscina.ID);
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x000130D5 File Offset: 0x000112D5
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_piscina = base.GetComponent<IPiscinaManagerDeSujetosBase<ISujetoIdentificableNpc>>();
			if (this.m_piscina == null)
			{
				throw new ArgumentNullException("m_piscina", "m_piscina null reference.");
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00013109 File Offset: 0x00011309
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00013111 File Offset: 0x00011311
		public bool Contiene(string npcID)
		{
			return MemoriaDePiscinaDeDeSujetosNpcFemenina.ContieneNPC_ID(this.m_piscina.ID, npcID);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00013124 File Offset: 0x00011324
		public List<ISujetoIdentificableNpc> LeerSujetosEnMemoria(int maxCount = 2147483647)
		{
			return MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCs(this.m_piscina.ID, maxCount) as List<ISujetoIdentificableNpc>;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0001313C File Offset: 0x0001133C
		public void LeerSujetosEnMemoria(IList<ISujetoIdentificableNpc> resultado, int maxCount = 2147483647)
		{
			MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCs(this.m_piscina.ID, resultado, maxCount);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00013150 File Offset: 0x00011350
		public bool EscribirAMemoria()
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			bool flag;
			try
			{
				this.m_piscina.ObtenerTodosLosSujetos(MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.EscribirNPCs(GlobalSingletonV2<MemoriaJson>.instance, this.m_piscina.ID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.EscribirNPCsIDs(GlobalSingletonV2<MemoriaJson>.instance, this.m_piscina.ID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarNivel(this.m_piscina.ID);
				if (this.m_piscina is IPiscinaManagerNivelable)
				{
					MemoriaDePiscinaDeDeSujetosNpcFemenina.AddNivel(this.m_piscina.ID, Mathf.FloorToInt(((IPiscinaManagerNivelable)this.m_piscina).nivel));
				}
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp.Clear();
			}
			return flag;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00013228 File Offset: 0x00011428
		public void BorrarMemoria(bool borrarSujetosMemoria)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				if (borrarSujetosMemoria)
				{
					MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarNPCs(this.m_piscina.ID, false);
				}
				MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarTodasLasIDsDeNPCs(this.m_piscina.ID);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.BorrarNivel(this.m_piscina.ID);
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0001328C File Offset: 0x0001148C
		public void QuitarDeMemoriaDePiscina(string npcID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.QuitarNPCsIDs(this.m_piscina.ID, npcID);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x000132AC File Offset: 0x000114AC
		public void QuitarDeMemoriaDePiscina(IReadOnlyList<ISujetoIdentificableNpc> sujetos)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.QuitarNPCsIDs(this.m_piscina.ID, sujetos);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x000132CC File Offset: 0x000114CC
		public void PonerEnMemoriaDePiscina(ISujetoIdentificableNpc sujeto)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			try
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp.Add(sujeto);
				MemoriaDePiscinaDeDeSujetosNpcFemenina.EscribirNPCsIDs(GlobalSingletonV2<MemoriaJson>.instance, this.m_piscina.ID, MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp);
			}
			finally
			{
				MemoriaDePiscinaDeDeSujetosNpcFemenina.m_sujetosTemp.Clear();
			}
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001332C File Offset: 0x0001152C
		public ISujetoIdentificableNpc LeerSujetoEnMemoria(Guid ID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return this.LeerSujetoEnMemoria(ID.ToString());
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001334E File Offset: 0x0001154E
		public ISujetoIdentificableNpc LeerSujetoEnMemoria(string ID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			if (MemoriaDePiscinaDeDeSujetosNpcFemenina.ContieneNPC_ID(this.m_piscina.ID, ID))
			{
				return MemoriaDeSujetosNpcFemenina.LeerNpcEnMemoria(GlobalSingletonV2<MemoriaJson>.instance, ID.ToString());
			}
			return null;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00013382 File Offset: 0x00011582
		public void LeerSujetoIDsEnMemoria(IList<string> resultado)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.LeerNPCsIDs(this.m_piscina.ID, resultado);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000133A2 File Offset: 0x000115A2
		public void AddNivel(int adding)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			MemoriaDePiscinaDeDeSujetosNpcFemenina.AddNivel(this.m_piscina.ID, adding);
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000133C2 File Offset: 0x000115C2
		public int GetNivel(int defaultValue)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			return MemoriaDePiscinaDeDeSujetosNpcFemenina.GetNivel(this.m_piscina.ID, defaultValue);
		}

		// Token: 0x04000248 RID: 584
		public const string rutaDeIDsSujetos = "root/Piscinas/NPC/";

		// Token: 0x04000249 RID: 585
		public const string rutaDeData = "root/Piscinas/DATA/";

		// Token: 0x0400024A RID: 586
		public const string npcReferencedDataName = "InPool";

		// Token: 0x0400024B RID: 587
		[Obsolete("No se usa, las piscinas de npcs no se guardan segun sus submapas, se guardan los npcs y las piscinas de npcs guardan ids de estos npcs", true)]
		public const string rutaDePiscina = "root/Piscinas/";

		// Token: 0x0400024C RID: 588
		private static List<string> m_temp = new List<string>();

		// Token: 0x0400024D RID: 589
		private IPiscinaManagerDeSujetosBase<ISujetoIdentificableNpc> m_piscina;

		// Token: 0x0400024E RID: 590
		private static List<ISujetoIdentificableNpc> m_sujetosTemp = new List<ISujetoIdentificableNpc>();
	}
}

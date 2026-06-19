using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Tools.Runtime.Memory;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.AI.Holders;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Memoria
{
	// Token: 0x020000BD RID: 189
	[MemoriaFunctions]
	public static class MemoriaDeSMAModelosFemeninas
	{
		// Token: 0x060006FD RID: 1789 RVA: 0x000280A4 File Offset: 0x000262A4
		public static void RegistrarHabloSobreTipoDeModelaje(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			memoria.EscribirDeep(text).AddData("TalkedAboutModeling", true, true);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000280D8 File Offset: 0x000262D8
		public static void RegistrarAceptoFotografias(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			memoria.EscribirDeep(text).AddData("ModelingPics", true, true);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0002810C File Offset: 0x0002630C
		public static void RegistrarAceptoModelar(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			memoria.EscribirDeep(text).AddData("ModelingPoses", true, true);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00028140 File Offset: 0x00026340
		public static void RegistrarAceptoLingerie(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			memoria.EscribirDeep(text).AddData("ModelingUndress", true, true);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00028174 File Offset: 0x00026374
		public static void RegistrarAceptoErotico(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			memoria.EscribirDeep(text).AddData("ModelingEro", true, true);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000281A8 File Offset: 0x000263A8
		public static bool HabloSobreTipoDeModelaje(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.FindDataBool("TalkedAboutModeling", false);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000281E0 File Offset: 0x000263E0
		public static bool AceptoFotografias(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.FindDataBool("ModelingPics", false);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00028218 File Offset: 0x00026418
		public static bool AceptoModelar(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.FindDataBool("ModelingPoses", false);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00028250 File Offset: 0x00026450
		public static bool AceptoLingerie(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.FindDataBool("ModelingUndress", false);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00028288 File Offset: 0x00026488
		public static bool AceptoErotico(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID + "/Memorias";
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			return jsonMemoryNode != null && jsonMemoryNode.FindDataBool("ModelingEro", false);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000282C0 File Offset: 0x000264C0
		public static void GetJobIntereses(IMemoria memoria, string npcID, out float nonSexual, out float softCore, out float hardcore)
		{
			nonSexual = 0f;
			softCore = 0f;
			hardcore = 0f;
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return;
			}
			string text2 = jsonMemoryNode.FindData("Personalidad");
			string text3 = ((text2 != null) ? text2.ToString() : null);
			string text4 = "root/Personalidad/" + text3;
			IJsonMemoryNode jsonMemoryNode2 = memoria.LeerDeep(text4, false);
			string text5 = AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoDeClientes];
			string text6 = AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoEspecialDeClientes];
			string text7 = AlteracionesDeTraitsDePersonalidad.nombresDeAlteradoresDeTraitHumanoTodos[TraitHumano.gustoPorTratoExplicitoDeClientes];
			HumanTraitScore humanTraitScore = MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitScore|10_1(MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitMod|10_0(text5, jsonMemoryNode2));
			HumanTraitScore humanTraitScore2 = MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitScore|10_1(MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitMod|10_0(text6, jsonMemoryNode2));
			HumanTraitScore humanTraitScore3 = MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitScore|10_1(MemoriaDeSMAModelosFemeninas.<GetJobIntereses>g__GetTraitMod|10_0(text7, jsonMemoryNode2));
			Personalidad.GetPreferredTreatmentForClientsWeights(humanTraitScore, humanTraitScore2, humanTraitScore3, out nonSexual, out softCore, out hardcore);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0002838C File Offset: 0x0002658C
		public static DateTime TryGetJobLastDate(string npcID, string jobID, DateTime defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			string text = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).FindData("Date", string.Empty);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			UDateTime udateTime = text;
			if (UDateTime.IsCorrupted(udateTime))
			{
				return defaultValue;
			}
			return udateTime;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000283E0 File Offset: 0x000265E0
		public static void SetJobLastDate(string npcID, string jobID, DateTime date)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			IContextMemory characterInMemory = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID);
			UDateTime udateTime = date;
			characterInMemory.AddData("Date", udateTime.serialTime, true);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0002841C File Offset: 0x0002661C
		public static DateTime TryGetJobLastDate(string jobID, DateTime defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			string text = AsyncSingleton<JobsManager>.instance.GetMemory(jobID).FindData("Date", string.Empty);
			if (string.IsNullOrWhiteSpace(text))
			{
				return defaultValue;
			}
			UDateTime udateTime = text;
			if (UDateTime.IsCorrupted(udateTime))
			{
				return defaultValue;
			}
			return udateTime;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00028470 File Offset: 0x00026670
		public static void SetJobLastDate(string jobID, DateTime date)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			IContextMemory memory = AsyncSingleton<JobsManager>.instance.GetMemory(jobID);
			UDateTime udateTime = date;
			memory.AddData("Date", udateTime.serialTime, true);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000284A8 File Offset: 0x000266A8
		public static float GetJobFatige(string jobID, float defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			return Mathf.Clamp(AsyncSingleton<JobsManager>.instance.GetMemory(jobID).FindDataFloat("Fatigue", defaultValue), 0f, 100f);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000284D8 File Offset: 0x000266D8
		public static float AddJobFatige(string jobID, float fatigue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return 0f;
			}
			IContextMemory memory = AsyncSingleton<JobsManager>.instance.GetMemory(jobID);
			float num = Mathf.Clamp(Mathf.Clamp(memory.FindDataFloat("Fatigue", 0f), 0f, 100f) + fatigue, 0f, 100f);
			memory.AddData("Fatigue", num, true);
			return num;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0002853C File Offset: 0x0002673C
		public static float AddNpcFatigeInJob(string jobID, string npcID, float fatigue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return 0f;
			}
			IContextMemory characterInMemory = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID);
			float num = Mathf.Clamp(Mathf.Clamp(characterInMemory.FindDataFloat("Fatigue", 0f), 0f, 100f) + fatigue, 0f, 100f);
			characterInMemory.AddData("Fatigue", num, true);
			return num;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000285A0 File Offset: 0x000267A0
		public static void SetJobFatige(string jobID, float fatigue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			IContextMemory memory = AsyncSingleton<JobsManager>.instance.GetMemory(jobID);
			fatigue = Mathf.Clamp(fatigue, 0f, 100f);
			memory.AddData("Fatigue", fatigue, true);
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000285D3 File Offset: 0x000267D3
		public static void SetNpcFatigeInJob(string jobID, string npcID, float fatigue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			IContextMemory characterInMemory = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID);
			fatigue = Mathf.Clamp(fatigue, 0f, 100f);
			characterInMemory.AddData("Fatigue", fatigue, true);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00028607 File Offset: 0x00026807
		public static float GetNpcFatigeInJob(string jobID, string npcID, float defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return 0f;
			}
			return Mathf.Clamp(AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).FindDataFloat("Fatigue", defaultValue), 0f, 100f);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0002863C File Offset: 0x0002683C
		public static DateTime TryGetJobLastDate(IMemoria memoria, string npcID, DateTime defaultValue)
		{
			string text = "root/Hired/" + npcID;
			string text2 = memoria.LeerDeep(text, true).FindData("Date", string.Empty);
			if (string.IsNullOrWhiteSpace(text2))
			{
				return defaultValue;
			}
			UDateTime udateTime = text2;
			if (UDateTime.IsCorrupted(udateTime))
			{
				return defaultValue;
			}
			return udateTime;
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00028690 File Offset: 0x00026890
		public static void SetJobLastDate(IMemoria memoria, string npcID, DateTime date)
		{
			string text = "root/Hired/" + npcID;
			IDataContainer<string> dataContainer = memoria.LeerDeep(text, true);
			UDateTime udateTime = date;
			dataContainer.AddData("Date", udateTime.serialTime, true);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000286C9 File Offset: 0x000268C9
		public static float GetNextJobIncome(string npcID, string jobID, float defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			return AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).FindDataFloat("income", defaultValue);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x000286EB File Offset: 0x000268EB
		public static void SetNextJobIncome(string npcID, string jobID, float income)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).AddData("income", income, true);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0002870D File Offset: 0x0002690D
		public static int TryGetJobLevelAssigned(string npcID, string jobID, int defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			return AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).FindDataInt("lvlAssig", defaultValue);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0002872F File Offset: 0x0002692F
		public static void SetJobLevelAssigned(string npcID, string jobID, int level)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).AddData("lvlAssig", level, true);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00028751 File Offset: 0x00026951
		public static float TryGetJobExp(string npcID, string jobID, float defaultValue)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return defaultValue;
			}
			return AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).FindDataFloat("Exp", defaultValue);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00028773 File Offset: 0x00026973
		public static void SetJobExp(string npcID, string jobID, float exp)
		{
			if (!AsyncSingleton<JobsManager>.IsInScene)
			{
				return;
			}
			AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(jobID, npcID).AddData("Exp", exp, true);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00028798 File Offset: 0x00026998
		public static void GetModeSalaryAndCommission(IMemoria memoria, string npcID, out float salary, out float commission)
		{
			string text = "root/Hired/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, true);
			salary = jsonMemoryNode.FindDataFloat("Salary", 100f);
			commission = jsonMemoryNode.FindDataFloat("Commission", 30f);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x000287E0 File Offset: 0x000269E0
		public static string GetJobOfFemale(IMemoria memoria, string npcID)
		{
			string text = "root/Hired/" + npcID;
			return memoria.LeerDeep(text, true).FindData("Job");
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0002880C File Offset: 0x00026A0C
		public static void SetJobToFemale(IMemoria memoria, string npcID, string jobID)
		{
			string text = "root/Hired/" + npcID;
			memoria.LeerDeep(text, true).AddData("Job", jobID, true);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0002883C File Offset: 0x00026A3C
		public static float TryGetModelingExp(IMemoria memoria, string npcID, float defaultValue)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return defaultValue;
			}
			return jsonMemoryNode.FindDataFloat("ModelingExp", 0f);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00028874 File Offset: 0x00026A74
		public static void SetModelingExp(IMemoria memoria, string npcID, float exp)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				throw new InvalidOperationException("no existe npc de id" + npcID);
			}
			jsonMemoryNode.AddData("ModelingExp", exp, true);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x000288B8 File Offset: 0x00026AB8
		public static void ForceWriteNPCAsHired_DEBUG(IMemoria memoria, string npcID, float salario, float comision)
		{
			string text = "root/Hired/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			jsonMemoryNode.AddData("Salary", salario, true);
			jsonMemoryNode.AddData("Commission", comision, true);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000288F4 File Offset: 0x00026AF4
		public static bool TryWriteNPCAsHired(IMemoria memoria, string npcID, float salario, float comision)
		{
			if (!MemoriaDeSujetosNpcFemenina.EsValido(memoria, npcID))
			{
				Singleton<ModalWindow>.instance.AcumularErrores("Cant Hire Npc: " + npcID + ", NPC data is not valid", null);
				Debug.LogError("Cant Hire Npc: " + npcID + ", NPC data is not valid");
				return false;
			}
			string text = "root/Hired/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.EscribirDeep(text);
			jsonMemoryNode.AddData("Salary", salario, true);
			jsonMemoryNode.AddData("Commission", comision, true);
			MemoriaDeSMAModelosFemeninas.SetNpcReferencia(memoria, npcID);
			return true;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00028970 File Offset: 0x00026B70
		public static bool IsNPCHired(IMemoria memoria, string npcID)
		{
			string text = "root/Hired/";
			return memoria.EscribirDeep(text).FindChild(npcID) != null;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00028994 File Offset: 0x00026B94
		public static void EraseNPCAsHired(IMemoria memoria, string npcID)
		{
			string text = "root/Hired/" + npcID;
			memoria.RemoverDeep(text);
			MemoriaDeSMAModelosFemeninas.DeleteNpcReferencia(memoria, npcID);
			MemoriaDeSujetosNpcFemenina.BorrarNpcEnMemoria(memoria, npcID, false);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000289C4 File Offset: 0x00026BC4
		public static void HiredNPCs(IMemoria memoria, List<string> resultIDs)
		{
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep("root/Hired/", false);
			if (jsonMemoryNode == null)
			{
				return;
			}
			foreach (IMemoryNode<string, string> memoryNode in jsonMemoryNode.children)
			{
				resultIDs.Add(memoryNode.nodeID);
			}
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00028A28 File Offset: 0x00026C28
		public static int HiredNPCCount(IMemoria memoria)
		{
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep("root/Hired/", false);
			if (jsonMemoryNode == null)
			{
				return 0;
			}
			return jsonMemoryNode.children.Count;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00028A52 File Offset: 0x00026C52
		public static void SetNpcReferencia(IMemoria memoria, string npcID)
		{
			MemoriaDeSujetosNpcFemenina.SetNpcReferencia(memoria, npcID, "IsHired", "ByPlayer");
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00028A65 File Offset: 0x00026C65
		public static string GetNpcReferencia(IMemoria memoria, string npcID)
		{
			return MemoriaDeSujetosNpcFemenina.GetNpcReferencia(memoria, npcID, "IsHired");
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00028A73 File Offset: 0x00026C73
		public static void DeleteNpcReferencia(IMemoria memoria, string npcID)
		{
			MemoriaDeSujetosNpcFemenina.DeleteNpcReferencia(memoria, npcID, "IsHired");
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00028A81 File Offset: 0x00026C81
		public static void GetNombres(IMemoria memoria, string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			MemoriaDeSMAGamePlay.GetNombres(memoria, npcID, out nombre, out apellido, out nombreCompleto);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00028A90 File Offset: 0x00026C90
		public static Texture2D GetPortrait(IMemoria memoria, string npcID)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				return null;
			}
			Texture2D texture2D = new Texture2D(2, 2);
			if (!jsonMemoryNode.TryFindDataImage("Portrait", ref texture2D))
			{
				Object.Destroy(texture2D);
				return null;
			}
			return texture2D;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00028AD8 File Offset: 0x00026CD8
		[CompilerGenerated]
		internal static float <GetJobIntereses>g__GetTraitMod|10_0(string alterName, IJsonMemoryNode MemPer)
		{
			IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)MemPer.FindChild(alterName);
			if (jsonMemoryNode == null)
			{
				return 0f;
			}
			float[] array;
			if (!jsonMemoryNode.TryFindDataArrayEmpty("Mods", out array))
			{
				return 0f;
			}
			return array.FirstOrDefault<float>();
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00028B18 File Offset: 0x00026D18
		[CompilerGenerated]
		internal static HumanTraitScore <GetJobIntereses>g__GetTraitScore|10_1(float mod)
		{
			int num = AlteracionesDeTraitsDePersonalidad.ModToIndex(mod);
			HumanTraitScore humanTraitScore;
			if (Enum.IsDefined(typeof(HumanTraitScore), num))
			{
				humanTraitScore = (HumanTraitScore)num;
			}
			else
			{
				Debug.LogError("no se pudo convertir index a enum de HumanTraitScore");
				humanTraitScore = HumanTraitScore.normal;
			}
			return humanTraitScore;
		}
	}
}

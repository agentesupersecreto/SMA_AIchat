using System;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers
{
	// Token: 0x02000074 RID: 116
	[MemoriaFunctions]
	public static class MemoriaDeNpc
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x00013FD4 File Offset: 0x000121D4
		public static float GetApplyableFatigueMod(IMemoria memoria, string npcID, float inPow)
		{
			float num = Mathf.Clamp(MemoriaDeNpc.GetFatigue(GlobalSingletonV2<MemoriaJson>.instance, npcID, 0f), 0f, 100f) / 100f;
			return Mathf.InverseLerp(0.1f, 1f, num).InPow(inPow);
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00014020 File Offset: 0x00012220
		public static float GetFatigue(IMemoria memoria, string npcID, float defaultValue)
		{
			string text = "root/NPC/" + npcID;
			return Mathf.Clamp(memoria.LeerDeep(text, true).FindDataFloat("Fatigue", defaultValue), 0f, 100f);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001405C File Offset: 0x0001225C
		public static float AddFatigue(IMemoria memoria, string npcID, float fatigue)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, true);
			float num = Mathf.Clamp(Mathf.Clamp(jsonMemoryNode.FindDataFloat("Fatigue", 0f), 0f, 100f) + fatigue, 0f, 100f);
			jsonMemoryNode.AddData("Fatigue", num, true);
			return num;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x000140BC File Offset: 0x000122BC
		public static void SetFatigue(IMemoria memoria, string npcID, float fatigue)
		{
			string text = "root/NPC/" + npcID;
			ISerializedDataContainer serializedDataContainer = memoria.LeerDeep(text, true);
			fatigue = Mathf.Clamp(fatigue, 0f, 100f);
			serializedDataContainer.AddData("Fatigue", fatigue, true);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x000140FC File Offset: 0x000122FC
		public static void SetNombres(IMemoria memoria, string npcID, string nombre, string apellido)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, true);
			jsonMemoryNode.AddData("Nombre", nombre, true);
			jsonMemoryNode.AddData("Apellido", apellido, true);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00014138 File Offset: 0x00012338
		public static bool TryGetNombres(IMemoria memoria, string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				nombre = string.Empty;
				apellido = string.Empty;
				nombreCompleto = string.Empty;
				return false;
			}
			string text2 = jsonMemoryNode.FindData("Nombre");
			nombre = ((text2 != null) ? text2.ToString() : null);
			string text3 = jsonMemoryNode.FindData("Apellido");
			apellido = ((text3 != null) ? text3.ToString() : null);
			nombre = nombre ?? string.Empty;
			apellido = apellido ?? string.Empty;
			nombreCompleto = nombre.FirstLetterOrDefaultToToUpperCase() + " " + apellido.FirstLetterOrDefaultToToUpperCase();
			return true;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x000141E0 File Offset: 0x000123E0
		public static void GetNombres(IMemoria memoria, string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = memoria.LeerDeep(text, false);
			if (jsonMemoryNode == null)
			{
				throw new InvalidOperationException("no existe npc de id" + npcID);
			}
			string text2 = jsonMemoryNode.FindData("Nombre");
			nombre = ((text2 != null) ? text2.ToString() : null);
			string text3 = jsonMemoryNode.FindData("Apellido");
			apellido = ((text3 != null) ? text3.ToString() : null);
			nombre = nombre ?? string.Empty;
			apellido = apellido ?? string.Empty;
			nombreCompleto = nombre.FirstLetterOrDefaultToToUpperCase() + " " + apellido.FirstLetterOrDefaultToToUpperCase();
		}

		// Token: 0x04000251 RID: 593
		public const float fatigueToAffect = 10f;

		// Token: 0x04000252 RID: 594
		public const float fatigueToAffectMod = 0.1f;
	}
}

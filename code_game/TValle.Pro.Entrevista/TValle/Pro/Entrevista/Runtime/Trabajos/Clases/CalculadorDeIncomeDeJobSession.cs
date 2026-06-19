using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases
{
	// Token: 0x02000074 RID: 116
	public static class CalculadorDeIncomeDeJobSession
	{
		// Token: 0x060004EA RID: 1258 RVA: 0x0001C8A4 File Offset: 0x0001AAA4
		public static Color GetIncomeColor(float mod)
		{
			if (mod > 0.8f)
			{
				return Color.green;
			}
			if (mod > 0.6f)
			{
				return Color.yellow;
			}
			if (mod > 0.4f)
			{
				return new Color(1f, 0.647f, 0f);
			}
			return Color.red;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0001C8E4 File Offset: 0x0001AAE4
		public static float GetIncomeMod(string npcID, string jobID)
		{
			float num = 1f - Mathf.Clamp(MemoriaDeSMAModelosFemeninas.GetJobFatige(jobID, 0f), 0f, 100f) / 100f;
			float num2 = 1f - Mathf.Clamp(MemoriaDeSMAModelosFemeninas.GetNpcFatigeInJob(jobID, npcID, 0f), 0f, 100f) / 100f;
			float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, npcID, 2f);
			float num3 = 1f - applyableFatigueMod;
			return num * num2 * num3;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0001C95C File Offset: 0x0001AB5C
		public static float GetIncomeMod(string jobID)
		{
			return 1f - Mathf.Clamp(MemoriaDeSMAModelosFemeninas.GetJobFatige(jobID, 0f), 0f, 100f) / 100f;
		}
	}
}

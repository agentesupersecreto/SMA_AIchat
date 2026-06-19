using System;
using Assets.Productos.Juegos.Reception;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200011A RID: 282
	public abstract class MeetingFromMemoryNPCFemale : ActrividadConFemaleNpc
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00038EE7 File Offset: 0x000370E7
		public override bool usesCustomLightingByUser
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00038EEA File Offset: 0x000370EA
		protected override bool DoLoadNpc
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00038EED File Offset: 0x000370ED
		protected override bool destruirNpcOnEndAvtivity
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x00038EF0 File Offset: 0x000370F0
		protected override bool deleteFromMemNpcOnEndAvtivity
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00038EF3 File Offset: 0x000370F3
		protected override bool saveNpcOnEndAvtivity
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x00038EF6 File Offset: 0x000370F6
		protected override bool generateFemaleRopa
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00038EFC File Offset: 0x000370FC
		protected override ISujetoIdentificableNpc LoadNpc(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			ISujetoIdentificableNpc sujetoIdentificableNpc2;
			try
			{
				string @string = PlayerPrefs.GetString("SelectedModelToMeet");
				if (string.IsNullOrWhiteSpace(@string))
				{
					throw new InvalidOperationException();
				}
				ISujetoIdentificableNpc sujetoIdentificableNpc;
				LoaderDeNpcFemeninos.ReadFromGameMemoryNPC_Character(@string, characterEnScena, out sujetoIdentificableNpc);
				IConjuntoDeRopa conjuntoDeRopa = LoaderDeNpcFemeninos.LoadFemaleRopaFromMemory(GlobalSingletonV2<MemoriaJson>.instance, @string);
				IRopaManager componentInChildren = base.currentFemaleCharacter.self.GetComponentInChildren<IRopaManager>();
				if (componentInChildren != null && conjuntoDeRopa != null)
				{
					((MonoBehaviour)componentInChildren).StartCoroutine(componentInChildren.LoadConjuntoAsset(conjuntoDeRopa, true, null, true));
				}
				else
				{
					Debug.LogWarning("cant load female outfit from memory, it was empty or null or no Manager found");
				}
				sujetoIdentificableNpc2 = sujetoIdentificableNpc;
			}
			finally
			{
				PlayerPrefs.SetString("SelectedModelToMeet", string.Empty);
			}
			return sujetoIdentificableNpc2;
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00038F98 File Offset: 0x00037198
		protected override void EscribirFemaleRopaToMemory(IConjuntoDeRopa loadedConjunto)
		{
			if (loadedConjunto == null || loadedConjunto.piezas.Count == 0)
			{
				Debug.LogError("cant save female outfit to memory, it was empty or null", base.currentFemaleCharacter);
				return;
			}
			LoaderDeNpcFemeninos.SaveFemaleRopaToMemory(GlobalSingletonV2<MemoriaJson>.instance, base.npc.NpcID.ToString(), loadedConjunto);
		}
	}
}

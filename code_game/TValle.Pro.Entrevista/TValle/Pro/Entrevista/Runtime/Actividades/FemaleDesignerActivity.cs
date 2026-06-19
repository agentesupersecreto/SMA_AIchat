using System;
using System.Collections;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.Productos.Juegos.Reception;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.TValle.BeachGirl.Runtime.Camaras;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000126 RID: 294
	public class FemaleDesignerActivity : ActrividadConSoloFemaleNpc
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00039CC2 File Offset: 0x00037EC2
		public override Character mainPlayerCharacter
		{
			get
			{
				return MainChar.current;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000A7C RID: 2684 RVA: 0x00039CC9 File Offset: 0x00037EC9
		public override string ID
		{
			get
			{
				return "TValle.Actividad.FemaleDesigner";
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x00039CD0 File Offset: 0x00037ED0
		public override string Name
		{
			get
			{
				return "Designer";
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000A7E RID: 2686 RVA: 0x00039CD7 File Offset: 0x00037ED7
		public override bool usesCustomLightingByUser
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00039CDA File Offset: 0x00037EDA
		protected override bool generateFemaleRopa
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x00039CDD File Offset: 0x00037EDD
		protected override bool destruirNpcOnEndAvtivity
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00039CE0 File Offset: 0x00037EE0
		protected override bool deleteFromMemNpcOnEndAvtivity
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00039CE3 File Offset: 0x00037EE3
		protected override bool saveNpcOnEndAvtivity
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00039CE6 File Offset: 0x00037EE6
		protected override bool DoLoadNpc
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00039CE9 File Offset: 0x00037EE9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00039CF1 File Offset: 0x00037EF1
		protected override void LoadingNPC(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00039CF4 File Offset: 0x00037EF4
		protected override void OnCharacterLoaded()
		{
			if (InstantiatedSingleton<MainInternalsXRayCamera>.IsInScene)
			{
				MainInternalsXRayCamera instance = InstantiatedSingleton<MainInternalsXRayCamera>.instance;
				if (!instance.isAwaken)
				{
					instance.ManualAwake();
				}
				if (!instance.isStared)
				{
					instance.ManualStart();
				}
				instance.gameObject.SetActive(true);
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00039D38 File Offset: 0x00037F38
		protected override ISujetoIdentificableNpc LoadNpc(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			ISujetoIdentificableNpc sujetoIdentificableNpc2;
			try
			{
				string @string = PlayerPrefs.GetString("SingleModelSelected");
				ISujetoIdentificableNpc sujetoIdentificableNpc;
				if (string.IsNullOrWhiteSpace(@string))
				{
					if (!characterEnScena.isAwaken)
					{
						characterEnScena.ManualAwake();
					}
					if (!characterEnScena.isStared)
					{
						characterEnScena.ManualStart();
					}
					sujetoIdentificableNpc = LoaderDeNpcFemeninos.GetNewNPCAssetFromCharacter(characterEnScena, true);
					Texture2D texture2D = characterEnScena.GetComponentEnRoot<SelfPortraitCamera>().TakeFemalePortrait();
					LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, sujetoIdentificableNpc, characterEnScena, texture2D);
				}
				else
				{
					sujetoIdentificableNpc = LoaderDeNpcFemeninos.ReadFromDisk(@string, characterEnScena);
				}
				sujetoIdentificableNpc2 = sujetoIdentificableNpc;
			}
			finally
			{
				PlayerPrefs.SetString("SelectedModelToMeet", string.Empty);
			}
			return sujetoIdentificableNpc2;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x00039DC4 File Offset: 0x00037FC4
		public override void AfterAIUpdate()
		{
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00039DC6 File Offset: 0x00037FC6
		public override void AfterAnimationsUpdate()
		{
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00039DC8 File Offset: 0x00037FC8
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00039DCA File Offset: 0x00037FCA
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00039DCC File Offset: 0x00037FCC
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00039DCE File Offset: 0x00037FCE
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00039DD0 File Offset: 0x00037FD0
		public override IEnumerator Conclude()
		{
			yield break;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00039DD8 File Offset: 0x00037FD8
		public override IEnumerator Introduce()
		{
			yield break;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00039DE0 File Offset: 0x00037FE0
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00039DE2 File Offset: 0x00037FE2
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00039DE5 File Offset: 0x00037FE5
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00039DE7 File Offset: 0x00037FE7
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00039DEA File Offset: 0x00037FEA
		protected override void EscribirFemaleRopaToMemory(IConjuntoDeRopa loadedConjunto)
		{
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00039DEC File Offset: 0x00037FEC
		protected override IEnumerator InstantiateFemaleCharacter(Action<FemaleChar> result)
		{
			yield break;
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00039DF4 File Offset: 0x00037FF4
		protected override IEnumerator InstantiateMaleCharacter(Action<MaleChar> result)
		{
			yield break;
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00039DFC File Offset: 0x00037FFC
		protected override IEnumerator OnEnd()
		{
			yield break;
		}

		// Token: 0x0400056A RID: 1386
		public const string actividadName = "Designer";
	}
}

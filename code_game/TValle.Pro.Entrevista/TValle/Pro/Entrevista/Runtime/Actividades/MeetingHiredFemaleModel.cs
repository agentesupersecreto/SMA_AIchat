using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000137 RID: 311
	public sealed class MeetingHiredFemaleModel : MeetingFromMemoryNPCFemale
	{
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000AEB RID: 2795 RVA: 0x00039FB1 File Offset: 0x000381B1
		public override string ID
		{
			get
			{
				return "TValle.Actividad.MeetingInOffice";
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00039FB8 File Offset: 0x000381B8
		public override string Name
		{
			get
			{
				return "MeetingInOffice";
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000AED RID: 2797 RVA: 0x00039FBF File Offset: 0x000381BF
		protected override bool deleteFromMemNpcOnEndAvtivity
		{
			get
			{
				return this.m_modelWasFired || base.deleteFromMemNpcOnEndAvtivity;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x00039FD1 File Offset: 0x000381D1
		protected override bool saveNpcOnEndAvtivity
		{
			get
			{
				return !this.m_modelWasFired && base.saveNpcOnEndAvtivity;
			}
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00039FE3 File Offset: 0x000381E3
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00039FEB File Offset: 0x000381EB
		protected override void LoadingNPC(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00039FED File Offset: 0x000381ED
		public void FlagModelWasFired()
		{
			this.m_modelWasFired = true;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00039FF6 File Offset: 0x000381F6
		public override IEnumerator Introduce()
		{
			GameplayObjectives.CountOfSingleActionObjective countOfSingleActionObjective;
			GameplayObjectives.CountOfUniqueActionObjective countOfUniqueActionObjective;
			GameplayObjectives.CountOfUniqueActionObjective countOfUniqueActionObjective2;
			base.GetDefaultObjctivesMeeting(out countOfSingleActionObjective, out countOfUniqueActionObjective, out countOfUniqueActionObjective2);
			this.m_actividadObjectives = new GameplayObjectives.Objective[] { countOfSingleActionObjective, countOfUniqueActionObjective, countOfUniqueActionObjective2 };
			Singleton<GameplayObjectives>.instance.AddObjetives(this.m_actividadObjectives, false);
			yield break;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0003A005 File Offset: 0x00038205
		public override IEnumerator Conclude()
		{
			ICharactersSceneInteractionsArchived mainArchivedInteractions = Singleton<InteraccionesEnScena>.instance.GetMainArchivedInteractions(this.mainPlayerCharacter, this.mainNonPlayerCharacter);
			float num = 0f;
			foreach (object obj in typeof(Emotion).GetEnumValoresLimpiosObject())
			{
				Emotion emotion = (Emotion)obj;
				Interaction interaction;
				mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, emotion, true, out interaction);
				Interaction interaction2;
				mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, emotion, false, out interaction2);
				if (emotion.IsGood())
				{
					num += (float)interaction.times * 5f;
					num += interaction2.damagePercentageDone / 65f;
				}
				else
				{
					num += (float)interaction.times * 2.5f;
					num += interaction2.damagePercentageDone / 65f;
				}
			}
			num *= 0.25f;
			bool flag = base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDolor || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaRabia || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDecepcion || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaMiedo;
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom;
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo;
			Singleton<InteraccionesEnScena>.instance.DefaultBuffAndDebuffGenerate(Singleton<ActividadesManager>.instance.current.GetCachedMainPlayerComponent<SceneCharacter>(), Singleton<ActividadesManager>.instance.current.GetCachedMainNonPlayerComponent<SceneCharacter>(), flag, Singleton<TiempoDeJuego>.instance.now, out BuffAndDebuffOnFrom, out BuffAndDebuffOnTo);
			int num2;
			int num3;
			int num4;
			int num5;
			Singleton<GameplayObjectives>.instance.Status(out num2, out num3, out num4, out num5);
			float num6 = (float)(num3 + num5) / (float)(num2 + num4) * 0.1f;
			float num7 = Singleton<ActividadesManager>.instance.AddModelingExpToMainNonPlayer(num6);
			float num8 = MemoriaDeNpc.AddFatigue(GlobalSingletonV2<MemoriaJson>.instance, this.mainNonPlayerCharacter.ID_UnicoString, num + 3f);
			Singleton<GameplayObjectives>.instance.RemoveObjetives(this.m_actividadObjectives);
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			yield return Singleton<ActividadesManager>.instance.ShowDefaultEndSessionPanel(flag, 0f, num6, num7, num + 3f, num8, BuffAndDebuffOnFrom, BuffAndDebuffOnTo);
			BuffAndDebuffOnFrom.Apply();
			BuffAndDebuffOnTo.Apply();
			yield break;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0003A014 File Offset: 0x00038214
		protected override IEnumerator OnEnd()
		{
			yield return base.OnEnd();
			yield break;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0003A023 File Offset: 0x00038223
		protected override IEnumerator InstantiateMaleCharacter(Action<MaleChar> result)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo");
			Character loaded = null;
			yield return Singleton<ActividadesManager>.instance.LoadDefaultMaleCharacter(goTo.transform.position, goTo.transform.forward, delegate(Character r)
			{
				loaded = r;
			});
			if (result != null)
			{
				result(loaded as MaleChar);
			}
			yield break;
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0003A032 File Offset: 0x00038232
		protected override IEnumerator InstantiateFemaleCharacter(Action<FemaleChar> result)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo");
			Character loaded = null;
			yield return Singleton<ActividadesManager>.instance.LoadDefaultFemaleCharacter(goTo.transform.position, goTo.transform.forward, delegate(Character r)
			{
				loaded = r;
			});
			if (result != null)
			{
				result(loaded as FemaleChar);
			}
			yield break;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0003A041 File Offset: 0x00038241
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0003A043 File Offset: 0x00038243
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0003A046 File Offset: 0x00038246
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0003A048 File Offset: 0x00038248
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0003A04B File Offset: 0x0003824B
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0003A04D File Offset: 0x0003824D
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0003A04F File Offset: 0x0003824F
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0003A051 File Offset: 0x00038251
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0003A053 File Offset: 0x00038253
		public override void AfterAIUpdate()
		{
		}

		// Token: 0x0400056C RID: 1388
		public const string actividadName = "MeetingInOffice";

		// Token: 0x0400056D RID: 1389
		[SerializeField]
		[ReadOnlyUI]
		private bool m_modelWasFired;

		// Token: 0x0400056E RID: 1390
		[SerializeReference]
		private GameplayObjectives.Objective[] m_actividadObjectives;
	}
}

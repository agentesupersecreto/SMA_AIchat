using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Productos.Juegos.Reception;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000114 RID: 276
	public abstract class ActrividadConFemaleNpc : EntrevistaConFemaleCharacter
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060009AE RID: 2478
		protected abstract bool destruirNpcOnEndAvtivity { get; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060009AF RID: 2479
		protected abstract bool deleteFromMemNpcOnEndAvtivity { get; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060009B0 RID: 2480
		protected abstract bool saveNpcOnEndAvtivity { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060009B1 RID: 2481
		protected abstract bool DoLoadNpc { get; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0003830E File Offset: 0x0003650E
		public int currentFemaleCharacterLvl
		{
			get
			{
				return this.m_femaleCharacterEnScenaLvl;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x00038316 File Offset: 0x00036516
		// (set) Token: 0x060009B4 RID: 2484 RVA: 0x00038323 File Offset: 0x00036523
		public ISujetoIdentificableNpc npc
		{
			get
			{
				return this.m_npc as ISujetoIdentificableNpc;
			}
			private set
			{
				this.m_npc = value as Object;
			}
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00038334 File Offset: 0x00036534
		protected sealed override void OnScenaAndFemaleCharacterLoaded(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			base.OnScenaAndFemaleCharacterLoaded(characterEnScena, rootForManagerLogicInCharacter);
			if (this.DoLoadNpc)
			{
				this.LoadingNPC(characterEnScena, rootForManagerLogicInCharacter);
				this.npc = this.LoadNpc(characterEnScena, rootForManagerLogicInCharacter);
				if (this.npc == null)
				{
					throw new ArgumentNullException("npc", "npc null reference.");
				}
				ISujetoNivel sujetoNivel = this.npc as ISujetoNivel;
				this.m_femaleCharacterEnScenaLvl = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
			}
		}

		// Token: 0x060009B6 RID: 2486
		protected abstract void LoadingNPC(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x060009B7 RID: 2487
		protected abstract ISujetoIdentificableNpc LoadNpc(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x060009B8 RID: 2488 RVA: 0x000383B1 File Offset: 0x000365B1
		protected override void OnFemaleRetirandose()
		{
			base.OnFemaleRetirandose();
			if (this.saveNpcOnEndAvtivity)
			{
				LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, this.npc, base.currentFemaleCharacter, null);
			}
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x000383D8 File Offset: 0x000365D8
		protected override IEnumerator OnEnd()
		{
			if (this.saveNpcOnEndAvtivity && this.deleteFromMemNpcOnEndAvtivity)
			{
				Debug.LogError("se quiere borrar y guardar npc al mismo tiempo", this);
			}
			LoaderDeNpcMasculinos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, base.currentMaleCharacter);
			if (this.saveNpcOnEndAvtivity)
			{
				if (base.currentFemaleCharacterAlteradoresApariencia.mapaDeValores != null)
				{
					base.currentFemaleCharacterAlteradoresApariencia.Save();
				}
				if (base.currentFemaleCharacterAlteradoresPersonalidad.mapaDeValores != null)
				{
					base.currentFemaleCharacterAlteradoresPersonalidad.Save();
				}
				LoaderDeNpcFemeninos.SaveToMemory(GlobalSingletonV2<MemoriaJson>.instance, this.npc, base.currentFemaleCharacter, null);
			}
			Guid npcID = this.npc.NpcID;
			if (this.destruirNpcOnEndAvtivity)
			{
				LoaderDeNpcFemeninos.DestroyNPC(npcID.ToString());
				this.m_npc = null;
			}
			if (this.deleteFromMemNpcOnEndAvtivity)
			{
				LoaderDeNpcFemeninos.EraseNPCFromGameMemory(npcID.ToString());
			}
			yield break;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x000383E8 File Offset: 0x000365E8
		protected void GetDefaultMeetingObjectivesData([TupleElementNames(new string[] { "id", "cantidad", "RealTime", null })] out ValueTuple<string, int, bool, ObjectiveCheckerHandler_CurrentCount> bodyPics, [TupleElementNames(new string[] { null, null, "RealTime", null })] out ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> exposingPics, [TupleElementNames(new string[] { null, null, "RealTime", null })] out ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> exposingByPosePics)
		{
			ICharactersSceneInteractionsArchived m_archivedInteractions = Singleton<InteraccionesEnScena>.instance.GetMainAndSecondaryArchivedInteractionsNotNull(this.mainPlayerCharacter, this.mainNonPlayerCharacter);
			ICharactersSceneInteractions m_currentInteractions = Singleton<InteraccionesEnScena>.instance.GetTakingPlaceInteractionsNotNull(this.mainPlayerCharacter, this.mainNonPlayerCharacter);
			IRopaManager ropaManager = this.mainNonPlayerCharacter.GetComponentEnRoot<IRopaManager>();
			bodyPics = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_CurrentCount>("tvalle.InterviewingMeeting.bodyPics", 5, false, (int capacity, int count) => m_archivedInteractions.PeekTimes(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false));
			exposingPics = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.InterviewingMeeting.exposingPics", 3, true, delegate
			{
				if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
				{
					return null;
				}
				int cubriendoFlags = (int)ropaManager.cubriendoFlags;
				return (from enumInt in typeof(RopaCubre).GetEnumValoresInt()
					where cubriendoFlags.HasFlag(enumInt)
					select enumInt).Distinct<int>().Count<int>().ToString();
			});
			Func<SensitiveBodyPart, IEnumerable<Interaction>> <>9__4;
			exposingByPosePics = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.InterviewingMeeting.exposingByPosePics", 2, true, delegate
			{
				if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
				{
					return null;
				}
				IEnumerable<SensitiveBodyPart> enumerable = typeof(SensitiveBodyPart).GetEnumValoresLimpiosObject().Cast<SensitiveBodyPart>();
				Func<SensitiveBodyPart, IEnumerable<Interaction>> func;
				if ((func = <>9__4) == null)
				{
					func = (<>9__4 = delegate(SensitiveBodyPart sp)
					{
						Interaction interaction2;
						m_archivedInteractions.Peek(TriggeringBodyPart.All, sp, InterationReceivedType.askToPose, Emotion.pleasure, false, out interaction2);
						Interaction interaction3;
						m_archivedInteractions.Peek(TriggeringBodyPart.All, sp, InterationReceivedType.forcePose, Emotion.pleasure, false, out interaction3);
						return new Interaction[] { interaction2, interaction3 };
					});
				}
				Interaction interaction = (from x in enumerable.SelectMany(func)
					where x.isValid
					select x into inter
					orderby inter.endFrame descending
					select inter).FirstOrDefault<Interaction>();
				if (!interaction.isValid)
				{
					return null;
				}
				return interaction.toPart.ToString();
			});
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x000384A0 File Offset: 0x000366A0
		protected void GetDefaultInterviewingObjectivesData(Func<bool> isTryingToHireOrDispatchDelegate, Func<bool> didScoreOverride, [TupleElementNames(new string[] { "id", "RealTime", null })] out ValueTuple<string, bool, ObjectiveCheckerHandler> hireOrDispatchToOtherAgency, [TupleElementNames(new string[] { "id", "RealTime", null })] out ValueTuple<string, bool, ObjectiveCheckerHandler> overrideScore)
		{
			hireOrDispatchToOtherAgency = new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.InterviewingMeeting.hireOrDispatch", false, () => isTryingToHireOrDispatchDelegate());
			overrideScore = new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.InterviewingMeeting.overrideScore", false, () => didScoreOverride());
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x000384FC File Offset: 0x000366FC
		protected void GetDefaultObjctivesInterviewing(Func<bool> isTryingToHireOrDispatchDelegate, Func<bool> didScoreOverride, out GameplayObjectives.SingleActionObjective hireOrDispatchToOtherAgency, out GameplayObjectives.SingleActionObjective overrideScore)
		{
			ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple;
			ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple2;
			this.GetDefaultInterviewingObjectivesData(isTryingToHireOrDispatchDelegate, didScoreOverride, out valueTuple, out valueTuple2);
			hireOrDispatchToOtherAgency = new GameplayObjectives.SingleActionObjective(valueTuple.Item1, "To generate income, hire the current model in the office or send her to another modeling agency.", false, valueTuple.Item3, false, null, string.Empty);
			overrideScore = new GameplayObjectives.SingleActionObjective(valueTuple2.Item1, "If you believe the model's rating is unfair, <B>Override It!</B> This rating will affect models in subsequent campaign phases.(Optional)", false, valueTuple2.Item3, true, null, string.Empty);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00038558 File Offset: 0x00036758
		protected void GetDefaultObjctivesMeeting(out GameplayObjectives.CountOfSingleActionObjective bodyPicsObj, out GameplayObjectives.CountOfUniqueActionObjective exposingPicsObj, out GameplayObjectives.CountOfUniqueActionObjective exposingByPosePicsObj)
		{
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_CurrentCount> valueTuple;
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> valueTuple2;
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> valueTuple3;
			this.GetDefaultMeetingObjectivesData(out valueTuple, out valueTuple2, out valueTuple3);
			bodyPicsObj = new GameplayObjectives.CountOfSingleActionObjective(valueTuple.Item1, "Focus your lens on a variety of close-up shots that highlight the model's features.(Optional)", false, valueTuple.Item2, valueTuple.Item4, false, null, "Press the '4' key on your keyboard.");
			exposingPicsObj = new GameplayObjectives.CountOfUniqueActionObjective(valueTuple2.Item1, "Photograph the model in multiple outfits that vary in coverage and reveal.(Optional)", false, valueTuple2.Item2, valueTuple2.Item4, true, null, "To save outfits, Press the '3' key and then change the capture mode with the 'MOUSE MIDDLE' key.");
			exposingByPosePicsObj = new GameplayObjectives.CountOfUniqueActionObjective(valueTuple3.Item1, "Guide the model through a series of bold and expressive poses.(Optional)", false, valueTuple3.Item2, valueTuple3.Item4, true, null, "To save poses, Press the '3' key and then change the capture mode with the 'MOUSE MIDDLE' key.");
		}

		// Token: 0x04000542 RID: 1346
		[Header("-> Actrividad Con Female Npc <-")]
		[ReadOnlyUI]
		[SerializeField]
		private int m_femaleCharacterEnScenaLvl;

		// Token: 0x04000543 RID: 1347
		[ConstraintType(typeof(ISujetoIdentificableNpc), true)]
		[SerializeField]
		private Object m_npc;
	}
}

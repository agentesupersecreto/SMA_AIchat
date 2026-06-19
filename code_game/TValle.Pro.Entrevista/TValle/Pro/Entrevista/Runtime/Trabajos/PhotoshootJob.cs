using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.Memory;
using Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.UI;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005F RID: 95
	public sealed class PhotoshootJob : TValleSMAJob, ISMAJob
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00011B27 File Offset: 0x0000FD27
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00011B2A File Offset: 0x0000FD2A
		protected override ActividadScenesLoader.SceneLoadOrder initialLoadOrder
		{
			get
			{
				return ActividadScenesLoader.SceneLoadOrder.Pre_Main_Lighting_Post;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00011B2D File Offset: 0x0000FD2D
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1000f;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00011B34 File Offset: 0x0000FD34
		public override bool nonPlayerCharacterWillRememberPlayerCharacter
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00011B37 File Offset: 0x0000FD37
		public override IEnumerator DoStart()
		{
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeAI>();
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeTrabajosDeModelaje>();
			GoToScenaManager.GoTo podioGOTO = Singleton<GoToScenaManager>.instance.Obtener("Platform_GoTo");
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("Camera_GoTo");
			Action<SceneCharacter> action = delegate(SceneCharacter sc)
			{
				CharacterWallet componentEnRoot = sc.GetComponentEnRoot(false);
				if (componentEnRoot != null)
				{
					componentEnRoot.msgChanges = false;
				}
			};
			IContextMemory jobMem = AsyncSingleton<JobsManager>.instance.GetMemory(this);
			this.m_mainPlayerCharacterID = MemoriaDeSMAJobs.GetEmpleadorID(jobMem, Singleton<TiempoDeJuego>.instance.now);
			bool requiereGuardarEmpleador = this.m_mainPlayerCharacterID == Guid.Empty;
			yield return base.LoadMaleCharacter(this.m_mainPlayerCharacterID, goTo.transform.position, goTo.transform.forward, null, action, true);
			if (requiereGuardarEmpleador)
			{
				MemoriaDeSMAJobs.AddOrReplaceEmpleadorID(jobMem, this.m_mainPlayerCharacterID, Singleton<TiempoDeJuego>.instance.now);
			}
			yield return base.LoadFemaleCharacter(this.m_mainNonPlayerCharacterID, podioGOTO.transform.position, podioGOTO.transform.forward, null, true, null);
			yield return null;
			Singleton<ActividadesManager>.instance.AddExtraComponentsAndConfigToCharacters();
			AsyncSingleton<RadialMenusForActivities>.instance.AddRadialMenus(this.m_jobManager.current.mainNonPlayerCharacter.GetComponent<Character>(), new string[] { "GOTOS", "EXPRESSIONS", "MAKEOVER", "OUTFIT", "POSES", "SERVICING" });
			this.m_jobManager.UI.showMenuKeyReleased += this.UI_showMenuKeyReleased;
			yield break;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00011B46 File Offset: 0x0000FD46
		public override IEnumerator Introduce()
		{
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(false);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractionsArchived m_archivedInteractions = this.m_jobManager.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractions m_currentInteractions = this.m_jobManager.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractions m_currentInteractionsInverted = this.m_jobManager.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainNonPlayerCharacter, instance.current.mainPlayerCharacter);
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] array = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[]
			{
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.breastPosePic", Random.Range(1, 1), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num = Mathf.Max(new int[]
					{
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.forcePose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.forcePose, Emotion.All, false)
					});
					if (num == 0)
					{
						return null;
					}
					return num.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.assPosePic", Random.Range(1, 3), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num2 = Mathf.Max(new int[]
					{
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.forcePose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.forcePose, Emotion.All, false)
					});
					if (num2 == 0)
					{
						return null;
					}
					return num2.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.crotchPosePic", Random.Range(1, 3), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num3 = Mathf.Max(new int[]
					{
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.forcePose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.forcePose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.forcePose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.askToPose, Emotion.All, false),
						m_archivedInteractions.PeekEndFrame(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.forcePose, Emotion.All, false)
					});
					if (num3 == 0)
					{
						return null;
					}
					return num3.ToString();
				})
			};
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] array2 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[]
			{
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.facePic", Random.Range(1, 10), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num4 = Mathf.Max(new int[]
					{
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.eyes, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.nose, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.lips, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.jaw, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.cheeks, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.forehead, InterationReceivedType.photoshoot, Emotion.pleasure, false),
						m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.head, InterationReceivedType.photoshoot, Emotion.pleasure, false)
					});
					if (num4 == 0)
					{
						return null;
					}
					return num4.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.handsPic", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num5 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.hands, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num5 == 0)
					{
						return null;
					}
					return num5.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.breastPic", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num6 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num6 == 0)
					{
						return null;
					}
					return num6.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.crotchPic", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num7 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num7 == 0)
					{
						return null;
					}
					return num7.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.assPic", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num8 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num8 == 0)
					{
						return null;
					}
					return num8.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.feetPic", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num9 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.feet, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num9 == 0)
					{
						return null;
					}
					return num9.ToString();
				})
			};
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] array3 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[]
			{
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.breastPicWearing", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.pleasure, false) && !m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					int num10 = this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.breasts);
					if (num10 > 1)
					{
						return null;
					}
					if (num10 == 1)
					{
						ClothingItemMap.Type firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer = this.m_jobManager.outfits.GetFirstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer(SensitiveBodyPart.breasts);
						if (firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer != ClothingItemMap.Type.lowerBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer != ClothingItemMap.Type.upperBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer != ClothingItemMap.Type.swimsuit)
						{
							return null;
						}
					}
					return Mathf.Max(m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.pleasure, false), m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.photoshoot, Emotion.pleasure, false)).ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.crotchPicWearing", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					int num11 = this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.clitorisOrPenis);
					if (num11 > 1)
					{
						return null;
					}
					if (num11 == 1)
					{
						ClothingItemMap.Type firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer2 = this.m_jobManager.outfits.GetFirstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer(SensitiveBodyPart.clitorisOrPenis);
						if (firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer2 != ClothingItemMap.Type.lowerBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer2 != ClothingItemMap.Type.upperBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer2 != ClothingItemMap.Type.swimsuit)
						{
							return null;
						}
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.assPicWearing", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					int num12 = this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.buttocks);
					if (num12 > 1)
					{
						return null;
					}
					if (num12 == 1)
					{
						ClothingItemMap.Type firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer3 = this.m_jobManager.outfits.GetFirstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer(SensitiveBodyPart.buttocks);
						if (firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer3 != ClothingItemMap.Type.lowerBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer3 != ClothingItemMap.Type.upperBodyUnderwear && firstOrDefaultClothingPiecesCoveringTypeOfMainNonPlayer3 != ClothingItemMap.Type.swimsuit)
						{
							return null;
						}
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				})
			};
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] array4 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[]
			{
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.breastPicNude", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					if (this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.breasts) > 0)
					{
						return null;
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.crotchPicNude", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					if (this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.clitorisOrPenis) > 0)
					{
						return null;
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.assPicNude", Random.Range(1, 5), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					if (this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.buttocks) > 0)
					{
						return null;
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.feetPicNude", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.feet, InterationReceivedType.photoshoot, Emotion.pleasure, false))
					{
						return null;
					}
					if (this.m_jobManager.outfits.CountOfClothingPiecesCoveringBodyPartOfMainNonPlayer(SensitiveBodyPart.feet) > 0)
					{
						return null;
					}
					return m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.feet, InterationReceivedType.photoshoot, Emotion.pleasure, false).ToString();
				})
			};
			ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] array5 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[]
			{
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.nipplesPic", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num13 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num13 == 0)
					{
						return null;
					}
					return num13.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.assholePic", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num14 = m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.pleasure, false);
					if (num14 == 0)
					{
						return null;
					}
					return num14.ToString();
				}),
				new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>("tvalle.modelingjob.pussyPic", Random.Range(1, 2), true, delegate
				{
					if (!m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false))
					{
						return null;
					}
					int num15 = Mathf.Max(m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.photoshoot, Emotion.pleasure, false), m_currentInteractions.PeekStartFrame(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.pleasure, false));
					if (num15 == 0)
					{
						return null;
					}
					return num15.ToString();
				})
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array6 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.tittsHumpPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.chest, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.breasts, InterationReceivedType.poke, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.nipples, InterationReceivedType.poke, Emotion.All, false))),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.assHumpPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.back, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.legs, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.buttocks, InterationReceivedType.poke, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.anus, InterationReceivedType.poke, Emotion.All, false))),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.crotchHumpPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.legs, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.back, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.crotch, InterationReceivedType.poke, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.poke, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.poke, Emotion.All, false)))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array7 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.oralSexPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.eyes, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nose, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.lips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.jaw, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.cheeks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.forehead, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.head, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.throat, InterationReceivedType.penetration, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.vagSexPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.back, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.legs, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.vag, InterationReceivedType.penetration, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.analSexPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.back, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.legs, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.anus, InterationReceivedType.penetration, Emotion.All, false))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array8 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.bodySemenPic", true, () => m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false) && m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.tittsSemenPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.chest, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.breasts, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.nipples, InterationReceivedType.pouringOn, Emotion.All, false))),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.assSemenPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.back, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.legs, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.buttocks, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.anus, InterationReceivedType.pouringOn, Emotion.All, false))),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.faceSemenPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.eyes, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nose, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.lips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.jaw, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.cheeks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.forehead, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.head, InterationReceivedType.photoshoot, Emotion.All, false)) && (m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.eyes, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.nose, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.lips, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.jaw, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.cheeks, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.forehead, InterationReceivedType.pouringOn, Emotion.All, false) || m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.head, InterationReceivedType.pouringOn, Emotion.All, false)))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array9 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.oralSexPic_Serv", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.eyes, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.nose, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.lips, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.jaw, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.cheeks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.forehead, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.head, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.throat, InterationReceivedType.penetration, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.handJobPic_Serv", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.hands, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.forearms, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.arms, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.shoulders, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.cheeks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.head, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.neck, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractionsInverted.PeekIsValid(TriggeringBodyPart.hand, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.handJob, Emotion.All, false))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array10 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.bodySemenPic_Serv", true, () => m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false) && m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.All, InterationReceivedType.pouringOn, Emotion.All, false))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array11 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.HardcoreSexPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.coccyx, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.vag, InterationReceivedType.penetration, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.HardcoreAnalSexPic", true, () => (m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.buttocks, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.crotch, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.coccyx, InterationReceivedType.photoshoot, Emotion.All, false) || m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.perineum, InterationReceivedType.photoshoot, Emotion.All, false)) && m_currentInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.anus, InterationReceivedType.penetration, Emotion.All, false))
			};
			ValueTuple<string, bool, ObjectiveCheckerHandler>[] array12 = new ValueTuple<string, bool, ObjectiveCheckerHandler>[]
			{
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.CreamVagPic", true, () => m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false) && m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.vag, InterationReceivedType.pouringIn, Emotion.All, false)),
				new ValueTuple<string, bool, ObjectiveCheckerHandler>("tvalle.modelingjob.CreamAnalPic", true, () => m_currentInteractions.PeekIsValid(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.photoshoot, Emotion.All, false) && m_archivedInteractions.PeekIsValid(TriggeringBodyPart.semen, SensitiveBodyPart.anus, InterationReceivedType.pouringIn, Emotion.All, false))
			};
			if (base.lvl < 3)
			{
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array13 = (from par in array.RandomTake(1)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array14 = base.CreateObjectives(array13);
				this.m_actividadObjectivesRequired.AddRange(array14);
			}
			bool flag = false;
			switch (base.lvl)
			{
			case 0:
			{
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array15 = (from par in array2.RandomTake(3)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array16 = base.CreateObjectives(array15);
				this.m_actividadObjectivesRequired.AddRange(array16);
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array17 = (from par in array5.RandomTake(1)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array18 = base.CreateObjectives(array17);
				this.m_actividadObjectivesOptional.AddRange(array18);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array19 = (from par in array6.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array20 = base.CreateObjectives(array19);
				this.m_actividadObjectivesOptional.AddRange(array20);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array21 = (from par in array7.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array22 = base.CreateObjectives(array21);
				this.m_actividadObjectivesOptional.AddRange(array22);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array23 = (from par in array8.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array24 = base.CreateObjectives(array23);
				this.m_actividadObjectivesOptional.AddRange(array24);
				break;
			}
			case 1:
			{
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array25 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] { array2[0] }.Select(([TupleElementNames(new string[] { null, null, "RealTime", null })] ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> par) => new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array26 = base.CreateObjectives(array25);
				this.m_actividadObjectivesRequired.AddRange(array26);
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array27 = (from par in array3.RandomTake(3)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array28 = base.CreateObjectives(array27);
				this.m_actividadObjectivesRequired.AddRange(array28);
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array29 = (from par in array5.RandomTake(1)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array30 = base.CreateObjectives(array29);
				this.m_actividadObjectivesOptional.AddRange(array30);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array31 = (from par in array6.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array32 = base.CreateObjectives(array31);
				this.m_actividadObjectivesOptional.AddRange(array32);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array33 = (from par in array7.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array34 = base.CreateObjectives(array33);
				this.m_actividadObjectivesOptional.AddRange(array34);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array35 = (from par in array8.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array36 = base.CreateObjectives(array35);
				this.m_actividadObjectivesOptional.AddRange(array36);
				break;
			}
			case 2:
			{
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array37 = new ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction>[] { array2[0] }.Select(([TupleElementNames(new string[] { null, null, "RealTime", null })] ValueTuple<string, int, bool, ObjectiveCheckerHandler_GetLastUniqueAction> par) => new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array38 = base.CreateObjectives(array37);
				this.m_actividadObjectivesRequired.AddRange(array38);
				ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>[] array39 = (from par in array4.RandomTake(3)
					select new ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>(par.Item1, false, par.Item2, par.Item4, par.Item3, null, null)).ToArray<ValueTuple<string, bool, int, ObjectiveCheckerHandler_GetLastUniqueAction, bool, IReadOnlyList<GameplayObjectives.Objective>, ObjectiveCountChandedHandler>>();
				GameplayObjectives.CountOfUniqueActionObjective[] array40 = base.CreateObjectives(array39);
				this.m_actividadObjectivesRequired.AddRange(array40);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array41 = (from par in array6.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array42 = base.CreateObjectives(array41);
				this.m_actividadObjectivesOptional.AddRange(array42);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array43 = (from par in array7.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array44 = base.CreateObjectives(array43);
				this.m_actividadObjectivesOptional.AddRange(array44);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array45 = (from par in array8.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array46 = base.CreateObjectives(array45);
				this.m_actividadObjectivesOptional.AddRange(array46);
				break;
			}
			case 3:
			{
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array47 = (from par in array9.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array48 = base.CreateObjectives(array47);
				this.m_actividadObjectivesRequired.AddRange(array48);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array49 = (from par in array10.RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array50 = base.CreateObjectives(array49);
				this.m_actividadObjectivesRequired.AddRange(array50);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array51 = (from par in array8.Where(([TupleElementNames(new string[] { null, "RealTime", null })] ValueTuple<string, bool, ObjectiveCheckerHandler> par) => par.Item1 != "tvalle.modelingjob.bodySemenPic").RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array52 = base.CreateObjectives(array51);
				this.m_actividadObjectivesOptional.AddRange(array52);
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] array53 = (from par in array7.Where(([TupleElementNames(new string[] { null, "RealTime", null })] ValueTuple<string, bool, ObjectiveCheckerHandler> par) => par.Item1 != "tvalle.modelingjob.oralSexPic").RandomTake(1)
					select new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(par.Item1, false, par.Item3, par.Item2, null)).ToArray<ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>>();
				GameplayObjectives.SingleActionObjective[] array54 = base.CreateObjectives(array53);
				this.m_actividadObjectivesOptional.AddRange(array54);
				break;
			}
			case 4:
			{
				flag = true;
				ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple = array11[0];
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>> valueTuple2 = new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(valueTuple.Item1, false, valueTuple.Item3, valueTuple.Item2, null);
				GameplayObjectives.SingleActionObjective[] array55 = base.CreateObjectives(new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] { valueTuple2 });
				this.m_actividadObjectivesRequired.AddRange(array55);
				ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple3 = array12[0];
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>> valueTuple4 = new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(valueTuple3.Item1, false, valueTuple3.Item3, valueTuple3.Item2, null);
				GameplayObjectives.SingleActionObjective[] array56 = base.CreateObjectives(new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] { valueTuple4 });
				this.m_actividadObjectivesOptional.AddRange(array56);
				break;
			}
			case 5:
			{
				flag = true;
				ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple5 = array11[1];
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>> valueTuple6 = new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(valueTuple5.Item1, false, valueTuple5.Item3, valueTuple5.Item2, null);
				GameplayObjectives.SingleActionObjective[] array57 = base.CreateObjectives(new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] { valueTuple6 });
				this.m_actividadObjectivesRequired.AddRange(array57);
				ValueTuple<string, bool, ObjectiveCheckerHandler> valueTuple7 = array12[1];
				ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>> valueTuple8 = new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>(valueTuple7.Item1, false, valueTuple7.Item3, valueTuple7.Item2, null);
				GameplayObjectives.SingleActionObjective[] array58 = base.CreateObjectives(new ValueTuple<string, bool, ObjectiveCheckerHandler, bool, IReadOnlyList<GameplayObjectives.Objective>>[] { valueTuple8 });
				this.m_actividadObjectivesOptional.AddRange(array58);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(base.lvl.ToString());
			}
			this.m_jobManager.objectives.AddObjectives(this.m_actividadObjectivesRequired, true);
			this.m_jobManager.objectives.AddObjectives(this.m_actividadObjectivesOptional, false);
			if (flag)
			{
				yield return this.InstanciarLube();
			}
			yield return this.GenerarBuffDeConsentPorContrato(base.lvl);
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string welcomeConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.welcome");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, welcomeConversation))
			{
				yield return null;
			}
			IAnimatorCharacter componentEnRoot = this.m_jobManager.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Singleton<CurrentMainChar>.instance.camara.Ver(componentEnRoot.bones.head.posicionFinal);
			CharacterRotationMode componentInChildren = this.m_jobManager.current.mainPlayerCharacter.GetComponentInChildren<CharacterRotationMode>();
			if (componentInChildren != null)
			{
				componentInChildren.ForzarBodyRotationPor(2f);
			}
			actividadesManager.SetUIInputsActive(true);
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
			yield break;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00011B55 File Offset: 0x0000FD55
		private IEnumerator InstanciarLube()
		{
			List<string> aInstanciarEnMesitaDeHerramientas = new List<string>();
			aInstanciarEnMesitaDeHerramientas.Add("Tvalle.Photo.Lube");
			aInstanciarEnMesitaDeHerramientas.Add("Tvalle.Photo.Lube");
			aInstanciarEnMesitaDeHerramientas.Add("Tvalle.Photo.Lube");
			MesitaParaHerramientasConSlots mesita = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.PhotoShoot.Mesita").GetComponent<MesitaParaHerramientasConSlots>();
			mesita.gameObject.SetActive(true);
			yield return null;
			int num;
			for (int i = 0; i < aInstanciarEnMesitaDeHerramientas.Count; i = num + 1)
			{
				string text = aInstanciarEnMesitaDeHerramientas[i];
				GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject(text);
				int nextSlotIndex = mesita.GetNextSlotIndex();
				Transform slot = mesita.GetSlot(nextSlotIndex);
				GameObject instance = Object.Instantiate<GameObject>(@object, slot.position, slot.rotation);
				mesita.SetSlot(nextSlotIndex, instance);
				yield return null;
				SceneManager.MoveGameObjectToScene(instance, base.gameObject.scene);
				yield return null;
				instance.GetComponentNotNull<HerramientasVuelveASuSlot>().SetSlot(slot);
				yield return null;
				slot = null;
				instance = null;
				num = i;
			}
			yield break;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00011B64 File Offset: 0x0000FD64
		private IEnumerator GenerarBuffDeConsentPorContrato(int lvl)
		{
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobContract", string.Empty);
			componentEnRoot.eventos.Remove(text);
			BuffMap map = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.FavorabilityByJobContract");
			if (map == null)
			{
				Debug.LogException(new ArgumentNullException("map", "map null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnMinFavorabilityValueArg>(efecto.argumentoID, out buffOnMinFavorabilityValueArg))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			switch (lvl)
			{
			case 0:
			{
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg2 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.Data[] array = new BuffOnMinFavorabilityValueArg.Data[3];
				int num = 0;
				BuffOnMinFavorabilityValueArg.Data data = new BuffOnMinFavorabilityValueArg.Data();
				data.tipo = TipoDeEstimulo.visual;
				data.direccion = DireccionDeEstimulo.recibida;
				data.estiulante = ParteQuePuedeEstimular.propSexToy;
				data.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where !p.EsMuyPrivadaSocialmenteVisual()
					select p).ToArray<ParteDelCuerpoHumano>();
				array[num] = data;
				int num2 = 1;
				BuffOnMinFavorabilityValueArg.Data data2 = new BuffOnMinFavorabilityValueArg.Data();
				data2.tipo = TipoDeEstimulo.guiandoBone;
				data2.direccion = DireccionDeEstimulo.recibida;
				data2.estiulante = ParteQuePuedeEstimular.boca;
				data2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				array[num2] = data2;
				array[2] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				buffOnMinFavorabilityValueArg2.data = array;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg3 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.ExclusionData[] array2 = new BuffOnMinFavorabilityValueArg.ExclusionData[7];
				int num3 = 0;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData.weight = 1.01f;
				exclusionData.tipo = TipoDeEstimulo.tactil;
				exclusionData.direccion = DireccionDeEstimulo.recibida;
				exclusionData.estiulante = ParteQuePuedeEstimular.manos;
				exclusionData.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num3] = exclusionData;
				int num4 = 1;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData2 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData2.weight = 1.02f;
				exclusionData2.tipo = TipoDeEstimulo.tactil;
				exclusionData2.direccion = DireccionDeEstimulo.recibida;
				exclusionData2.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num4] = exclusionData2;
				int num5 = 2;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData3 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData3.weight = 1.03f;
				exclusionData3.tipo = TipoDeEstimulo.tactil;
				exclusionData3.direccion = DireccionDeEstimulo.recibida;
				exclusionData3.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num5] = exclusionData3;
				int num6 = 3;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData4 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData4.weight = 1.04f;
				exclusionData4.tipo = TipoDeEstimulo.tactil;
				exclusionData4.direccion = DireccionDeEstimulo.recibida;
				exclusionData4.estiulante = ParteQuePuedeEstimular.semen;
				exclusionData4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num6] = exclusionData4;
				int num7 = 4;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData5 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData5.weight = 1.05f;
				exclusionData5.tipo = TipoDeEstimulo.coital;
				exclusionData5.direccion = DireccionDeEstimulo.recibida;
				exclusionData5.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num7] = exclusionData5;
				int num8 = 5;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData6 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData6.weight = 1.06f;
				exclusionData6.tipo = TipoDeEstimulo.coital;
				exclusionData6.direccion = DireccionDeEstimulo.recibida;
				exclusionData6.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num8] = exclusionData6;
				int num9 = 6;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData7 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData7.weight = 1.07f;
				exclusionData7.tipo = TipoDeEstimulo.coital;
				exclusionData7.direccion = DireccionDeEstimulo.recibida;
				exclusionData7.estiulante = ParteQuePuedeEstimular.propSexToy;
				exclusionData7.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array2[num9] = exclusionData7;
				buffOnMinFavorabilityValueArg3.dataExcluir = array2;
				break;
			}
			case 1:
			{
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg4 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.Data[] array3 = new BuffOnMinFavorabilityValueArg.Data[4];
				int num10 = 0;
				BuffOnMinFavorabilityValueArg.Data data3 = new BuffOnMinFavorabilityValueArg.Data();
				data3.tipo = TipoDeEstimulo.visual;
				data3.direccion = DireccionDeEstimulo.recibida;
				data3.estiulante = ParteQuePuedeEstimular.propSexToy;
				data3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where !p.EsMuyPrivadaSocialmenteVisual()
					select p).ToArray<ParteDelCuerpoHumano>();
				array3[num10] = data3;
				int num11 = 1;
				BuffOnMinFavorabilityValueArg.Data data4 = new BuffOnMinFavorabilityValueArg.Data();
				data4.tipo = TipoDeEstimulo.guiandoBone;
				data4.direccion = DireccionDeEstimulo.recibida;
				data4.estiulante = ParteQuePuedeEstimular.boca;
				data4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				array3[num11] = data4;
				array3[2] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				int num12 = 3;
				BuffOnMinFavorabilityValueArg.Data data5 = new BuffOnMinFavorabilityValueArg.Data();
				data5.tipo = TipoDeEstimulo.peticionDesvestidura;
				data5.direccion = DireccionDeEstimulo.recibida;
				data5.estiulante = ParteQuePuedeEstimular.boca;
				data5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where !p.EsMuyPrivadaSocialmenteVisual()
					select p).ToArray<ParteDelCuerpoHumano>();
				array3[num12] = data5;
				buffOnMinFavorabilityValueArg4.data = array3;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg5 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.ExclusionData[] array4 = new BuffOnMinFavorabilityValueArg.ExclusionData[7];
				int num13 = 0;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData8 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData8.weight = 1.01f;
				exclusionData8.tipo = TipoDeEstimulo.tactil;
				exclusionData8.direccion = DireccionDeEstimulo.recibida;
				exclusionData8.estiulante = ParteQuePuedeEstimular.manos;
				exclusionData8.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num13] = exclusionData8;
				int num14 = 1;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData9 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData9.weight = 1.02f;
				exclusionData9.tipo = TipoDeEstimulo.tactil;
				exclusionData9.direccion = DireccionDeEstimulo.recibida;
				exclusionData9.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData9.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num14] = exclusionData9;
				int num15 = 2;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData10 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData10.weight = 1.03f;
				exclusionData10.tipo = TipoDeEstimulo.tactil;
				exclusionData10.direccion = DireccionDeEstimulo.recibida;
				exclusionData10.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData10.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num15] = exclusionData10;
				int num16 = 3;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData11 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData11.weight = 1.04f;
				exclusionData11.tipo = TipoDeEstimulo.tactil;
				exclusionData11.direccion = DireccionDeEstimulo.recibida;
				exclusionData11.estiulante = ParteQuePuedeEstimular.semen;
				exclusionData11.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num16] = exclusionData11;
				int num17 = 4;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData12 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData12.weight = 1.05f;
				exclusionData12.tipo = TipoDeEstimulo.coital;
				exclusionData12.direccion = DireccionDeEstimulo.recibida;
				exclusionData12.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData12.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num17] = exclusionData12;
				int num18 = 5;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData13 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData13.weight = 1.06f;
				exclusionData13.tipo = TipoDeEstimulo.coital;
				exclusionData13.direccion = DireccionDeEstimulo.recibida;
				exclusionData13.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData13.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num18] = exclusionData13;
				int num19 = 6;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData14 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData14.weight = 1.07f;
				exclusionData14.tipo = TipoDeEstimulo.coital;
				exclusionData14.direccion = DireccionDeEstimulo.recibida;
				exclusionData14.estiulante = ParteQuePuedeEstimular.propSexToy;
				exclusionData14.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array4[num19] = exclusionData14;
				buffOnMinFavorabilityValueArg5.dataExcluir = array4;
				break;
			}
			case 2:
			{
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg6 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.Data[] array5 = new BuffOnMinFavorabilityValueArg.Data[7];
				array5[0] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.visual,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.propSexToy,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				int num20 = 1;
				BuffOnMinFavorabilityValueArg.Data data6 = new BuffOnMinFavorabilityValueArg.Data();
				data6.tipo = TipoDeEstimulo.guiandoBone;
				data6.direccion = DireccionDeEstimulo.recibida;
				data6.estiulante = ParteQuePuedeEstimular.boca;
				data6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				array5[num20] = data6;
				array5[2] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				array5[3] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.peticionDesvestidura,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				array5[4] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.peticionDesvestidura,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.manos,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				array5[5] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.desvestidura,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				array5[6] = new BuffOnMinFavorabilityValueArg.Data
				{
					tipo = TipoDeEstimulo.desvestidura,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.manos,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				};
				buffOnMinFavorabilityValueArg6.data = array5;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg7 = buffOnMinFavorabilityValueArg;
				BuffOnMinFavorabilityValueArg.ExclusionData[] array6 = new BuffOnMinFavorabilityValueArg.ExclusionData[7];
				int num21 = 0;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData15 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData15.weight = 1.01f;
				exclusionData15.tipo = TipoDeEstimulo.tactil;
				exclusionData15.direccion = DireccionDeEstimulo.recibida;
				exclusionData15.estiulante = ParteQuePuedeEstimular.manos;
				exclusionData15.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num21] = exclusionData15;
				int num22 = 1;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData16 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData16.weight = 1.02f;
				exclusionData16.tipo = TipoDeEstimulo.tactil;
				exclusionData16.direccion = DireccionDeEstimulo.recibida;
				exclusionData16.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData16.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num22] = exclusionData16;
				int num23 = 2;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData17 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData17.weight = 1.03f;
				exclusionData17.tipo = TipoDeEstimulo.tactil;
				exclusionData17.direccion = DireccionDeEstimulo.recibida;
				exclusionData17.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData17.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num23] = exclusionData17;
				int num24 = 3;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData18 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData18.weight = 1.04f;
				exclusionData18.tipo = TipoDeEstimulo.tactil;
				exclusionData18.direccion = DireccionDeEstimulo.recibida;
				exclusionData18.estiulante = ParteQuePuedeEstimular.semen;
				exclusionData18.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsPrivadaSocialmenteTactil() || p.EsSemiPrivadaSocialmenteTactil()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num24] = exclusionData18;
				int num25 = 4;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData19 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData19.weight = 1.05f;
				exclusionData19.tipo = TipoDeEstimulo.coital;
				exclusionData19.direccion = DireccionDeEstimulo.recibida;
				exclusionData19.estiulante = ParteQuePuedeEstimular.dedo;
				exclusionData19.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num25] = exclusionData19;
				int num26 = 5;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData20 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData20.weight = 1.06f;
				exclusionData20.tipo = TipoDeEstimulo.coital;
				exclusionData20.direccion = DireccionDeEstimulo.recibida;
				exclusionData20.estiulante = ParteQuePuedeEstimular.pene;
				exclusionData20.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num26] = exclusionData20;
				int num27 = 6;
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData21 = new BuffOnMinFavorabilityValueArg.ExclusionData();
				exclusionData21.weight = 1.07f;
				exclusionData21.tipo = TipoDeEstimulo.coital;
				exclusionData21.direccion = DireccionDeEstimulo.recibida;
				exclusionData21.estiulante = ParteQuePuedeEstimular.propSexToy;
				exclusionData21.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsHole()
					select p).ToArray<ParteDelCuerpoHumano>();
				array6[num27] = exclusionData21;
				buffOnMinFavorabilityValueArg7.dataExcluir = array6;
				break;
			}
			case 3:
			{
				List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
				List<GenericDataExclusiveOfInteractionArg> list2 = new List<GenericDataExclusiveOfInteractionArg>();
				list.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.visual,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.propSexToy,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				List<GenericDataOfInteractionArg> list3 = list;
				GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
				genericDataOfInteractionArg.tipo = TipoDeEstimulo.guiandoBone;
				genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
				genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.boca;
				genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				list3.Add(genericDataOfInteractionArg);
				list.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				this.FillInclusiveDataTratoEspecialOverrall(list);
				this.FillExclusionesDataTratoEspecialMassage(list2);
				buffOnMinFavorabilityValueArg.InyectData(list);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list2);
				Deseos componentEnRoot2 = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num28 = -100f - componentEnRoot2.thresholdsNegativo.labios.deseoParaRechazarSex;
				num28 *= -1f;
				num28 *= 1.1f;
				componentEnRoot2.AumentarDeseoLabios(num28, false, 1f);
				break;
			}
			case 4:
			{
				List<GenericDataOfInteractionArg> list4 = new List<GenericDataOfInteractionArg>();
				List<GenericDataExclusiveOfInteractionArg> list5 = new List<GenericDataExclusiveOfInteractionArg>();
				list4.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.visual,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.propSexToy,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				List<GenericDataOfInteractionArg> list6 = list4;
				GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
				genericDataOfInteractionArg2.tipo = TipoDeEstimulo.guiandoBone;
				genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
				genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.boca;
				genericDataOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				list6.Add(genericDataOfInteractionArg2);
				list4.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				this.FillInclusiveDataHardCore_Vag(list4);
				this.FillExclusionesDataHardCore_Vag(list5);
				buffOnMinFavorabilityValueArg.InyectData(list4);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list5);
				Deseos componentEnRoot3 = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num29 = -100f - componentEnRoot3.thresholdsNegativo.entrepierna.deseoParaRechazarSex;
				num29 *= -1f;
				num29 *= 1.1f;
				componentEnRoot3.AumentarDeseoEntrepierna(num29, false, 1f);
				break;
			}
			case 5:
			{
				List<GenericDataOfInteractionArg> list7 = new List<GenericDataOfInteractionArg>();
				List<GenericDataExclusiveOfInteractionArg> list8 = new List<GenericDataExclusiveOfInteractionArg>();
				list7.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.visual,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.propSexToy,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				List<GenericDataOfInteractionArg> list9 = list7;
				GenericDataOfInteractionArg genericDataOfInteractionArg3 = new GenericDataOfInteractionArg();
				genericDataOfInteractionArg3.tipo = TipoDeEstimulo.guiandoBone;
				genericDataOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
				genericDataOfInteractionArg3.estiulante = ParteQuePuedeEstimular.boca;
				genericDataOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsSkeleto()
					select p).ToArray<ParteDelCuerpoHumano>();
				list9.Add(genericDataOfInteractionArg3);
				list7.Add(new GenericDataOfInteractionArg
				{
					tipo = TipoDeEstimulo.peticionEjecucionDePose,
					direccion = DireccionDeEstimulo.recibida,
					estiulante = ParteQuePuedeEstimular.boca,
					estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
				});
				this.FillInclusiveDataHardCore_Anal(list7);
				buffOnMinFavorabilityValueArg.InyectData(list7);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list8);
				Deseos componentEnRoot4 = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num30 = -100f - componentEnRoot4.thresholdsNegativo.trasero.deseoParaRechazarSex;
				num30 *= -1f;
				num30 *= 1.1f;
				componentEnRoot4.AumentarDeseoNalgas(num30, false, 1f);
				break;
			}
			}
			buffOnMinFavorabilityValueArg.changedByFatigue = true;
			buffOnMinFavorabilityValueArg.force = true;
			DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, buffOnMinFavorabilityValueArg, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff.showSmallMsgOnApplied = true;
			eventoBuff.showSmallMsgOnEnd = false;
			eventoBuff.showSmallMsgOnStart = false;
			yield return componentEnRoot.eventos.AddOrStackUpAfterStart(eventoBuff, false, false);
			yield break;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00011B7C File Offset: 0x0000FD7C
		private void FillInclusiveDataTratoEspecialOverrall(List<GenericDataOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.bocaInterno }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.bocaInterno }
			});
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00011E70 File Offset: 0x00010070
		private void FillExclusionesDataTratoEspecialMassage(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.ano
				}
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.ano
				}
			});
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00011F08 File Offset: 0x00010108
		private void FillInclusiveDataHardCore_Vag(List<GenericDataOfInteractionArg> ToInyecData)
		{
			this.FillInclusiveDataTratoEspecialOverrall(ToInyecData);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00011FF0 File Offset: 0x000101F0
		private void FillInclusiveDataHardCore_Anal(List<GenericDataOfInteractionArg> ToInyecData)
		{
			this.FillInclusiveDataHardCore_Vag(ToInyecData);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0001206C File Offset: 0x0001026C
		private void FillExclusionesDataHardCore_Vag(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
		}

		// Token: 0x06000365 RID: 869 RVA: 0x000120B7 File Offset: 0x000102B7
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000120BC File Offset: 0x000102BC
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			switch (emotion)
			{
			case Emotion.disappointment:
			{
				ActividadesManager instance = Singleton<ActividadesManager>.instance;
				string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.boredMax");
				return instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID);
			}
			case Emotion.rage:
			{
				ActividadesManager instance2 = Singleton<ActividadesManager>.instance;
				string conversationID2 = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.rageMax");
				return instance2.current.mainNonPlayerCharacter.TrySerConversarzado(instance2.current.mainPlayerCharacter, conversationID2);
			}
			case Emotion.pain:
			{
				ActividadesManager instance3 = Singleton<ActividadesManager>.instance;
				string conversationID3 = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.painMax");
				return instance3.current.mainNonPlayerCharacter.TrySerConversarzado(instance3.current.mainPlayerCharacter, conversationID3);
			}
			case Emotion.fear:
			{
				ActividadesManager instance4 = Singleton<ActividadesManager>.instance;
				string conversationID4 = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.fearMax");
				return instance4.current.mainNonPlayerCharacter.TrySerConversarzado(instance4.current.mainPlayerCharacter, conversationID4);
			}
			default:
				return true;
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000121BD File Offset: 0x000103BD
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000121BF File Offset: 0x000103BF
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000121C4 File Offset: 0x000103C4
		private object GetMenuModel()
		{
			if (base.mainNonPlayerCharacter.gameObject.activeInHierarchy)
			{
				if (this.m_mainMenuModel == null)
				{
					this.m_mainMenuModel = new JobWithEmployerDefaultMenuModel();
					this.m_mainMenuModel.onModelDismissed += this.M_mainMenuModel_onModelDismissed;
					this.m_mainMenuModel.onShowEmployerInfo += this.M_mainMenuModel_onShowEmployerInfo;
					this.m_mainMenuModel.onShowModelInfo += this.M_mainMenuModel_onShowModelInfo;
				}
				return this.m_mainMenuModel;
			}
			if (this.m_mainMenuModelGone == null)
			{
				this.m_mainMenuModelGone = new JobWithEmployerModelGoneDefaultMenuModel();
				this.m_mainMenuModelGone.onShowEmployerInfo += this.M_mainMenuModel_onShowEmployerInfo;
				this.m_mainMenuModelGone.onEndSession += this.M_mainMenuModelGone_onEndSession;
			}
			return this.m_mainMenuModelGone;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00012289 File Offset: 0x00010489
		private void M_mainMenuModel_onShowModelInfo()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainNonPlayerCharacterInfo();
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000122AB File Offset: 0x000104AB
		private void M_mainMenuModel_onShowEmployerInfo()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			this.m_jobManager.UI.ShowMainPlayerCharacterInfo();
		}

		// Token: 0x0600036C RID: 876 RVA: 0x000122D0 File Offset: 0x000104D0
		private void M_mainMenuModel_onModelDismissed()
		{
			string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("photoshoot.dispatch");
			if (!DialogueManager.IsConversationActive && !string.IsNullOrWhiteSpace(conversationID))
			{
				ActividadesManager instance = Singleton<ActividadesManager>.instance;
				IAnimatorCharacter componentEnRoot = this.m_jobManager.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot != null && instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID))
				{
					this.m_jobManager.UI.CloseFloatingPanel();
					Singleton<CurrentMainChar>.instance.camara.Ver(componentEnRoot.bones.head.posicionFinal);
					CharacterRotationMode componentInChildren = this.m_jobManager.current.mainPlayerCharacter.GetComponentInChildren<CharacterRotationMode>();
					if (componentInChildren == null)
					{
						return;
					}
					componentInChildren.ForzarBodyRotationPor(2f);
				}
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00012393 File Offset: 0x00010593
		private void M_mainMenuModelGone_onEndSession()
		{
			this.m_jobManager.UI.CloseFloatingPanel();
			AsyncSingleton<JobsManager>.instance.AbortCurrentJob(null);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000123B0 File Offset: 0x000105B0
		private void UI_showMenuKeyReleased(ISMAJobsUIManager obj)
		{
			if (!this.m_jobManager.UI.floatingMainMenuIsShowing)
			{
				object obj2;
				this.m_jobManager.UI.DrawFloatingMainMenuPanel(this.GetMenuModel(), out obj2, new Action(this.OnHided));
				if (this.m_jobManager.UI.floatingMainMenuIsShowing)
				{
					this.m_jobManager.UI.ShowCurrentJobSessionObjetives(true, false);
					return;
				}
			}
			else
			{
				this.m_jobManager.UI.CloseFloatingPanel();
				this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, false);
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0001243A File Offset: 0x0001063A
		private void OnHided()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, false);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0001244E File Offset: 0x0001064E
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00012450 File Offset: 0x00010650
		public override void AfterAnimationsUpdate()
		{
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00012452 File Offset: 0x00010652
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00012454 File Offset: 0x00010654
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00012456 File Offset: 0x00010656
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00012458 File Offset: 0x00010658
		public override void AfterAIUpdate()
		{
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001245A File Offset: 0x0001065A
		public override IEnumerator Conclude()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, true);
			base.isAborted = base.isAborted || Actividad.running.aborted || !this.m_jobManager.objectives.CheckCompleted();
			ICharactersSceneInteractionsArchived mainArchivedInteractions = this.m_jobManager.interactions.GetMainArchivedInteractions(this.m_jobManager.current.mainPlayerCharacter.ID, this.m_jobManager.current.mainNonPlayerCharacter.ID);
			float num = base.CalcularFatiga(mainArchivedInteractions);
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFrom;
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnTo;
			this.m_jobManager.interactions.DefaultBuffAndDebuffGenerate(this.m_jobManager.current.mainPlayerCharacter, this.m_jobManager.current.mainNonPlayerCharacter, base.isAborted, base.date, out BuffAndDebuffOnFrom, out BuffAndDebuffOnTo);
			MemoriaDeSMAJobs.RegistrarNewSesionesLaboralDeCharacter(AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(this, AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter));
			int num2;
			int num3;
			int num4;
			int num5;
			this.m_jobManager.objectives.Status(out num2, out num3, out num4, out num5);
			float num6 = base.DefaultExpGainCalcule(base.lvl, num2, num3, num4, 1f, new int[] { 3, 6, 9, 6, 3, 3 });
			float num7;
			float num8;
			base.SetExpToMainCharacters(num6, out num7, out num8, 0.2f, 1f);
			float num9;
			base.SetFatigueToMainCharacters(ref num, out num9, base.lvl, new float[] { 5f, 7.5f, 10f, 10f, 15f, 15f });
			float num10;
			base.SetFatigueToJob(33f, out num10);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			float num11 = this.m_jobManager.PayMoneyToManager((base.isAborted ? 0.666f : 1f) * ((float)(num3 + num5) / (float)num2), 0f);
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			yield return this.m_jobManager.UI.ShowDefaultEndSessionPanel(base.isAborted, num11, num7, num8, num, num9, BuffAndDebuffOnFrom, BuffAndDebuffOnTo);
			BuffAndDebuffOnFrom.Apply();
			BuffAndDebuffOnTo.Apply();
			yield break;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00012469 File Offset: 0x00010669
		public override IEnumerator End()
		{
			this.m_jobManager.UI.showMenuKeyReleased -= this.UI_showMenuKeyReleased;
			this.m_jobManager.UpdateCharacterMemory(base.mainNonPlayerCharacter);
			this.m_jobManager.UpdateCharacterMemory(base.mainPlayerCharacter);
			yield break;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00012478 File Offset: 0x00010678
		protected override IEnumerator LoadingInitialScences()
		{
			yield break;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00012480 File Offset: 0x00010680
		protected override AssetReference GetMainSceneAssetReference()
		{
			return this.m_map.mainScene;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0001248D File Offset: 0x0001068D
		protected override int GetMainSceneBuildIndex()
		{
			return -1;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00012490 File Offset: 0x00010690
		protected override void OnMainSceneLoaded(Scene scene, bool success)
		{
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00012492 File Offset: 0x00010692
		protected override AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			AssetReference assetReference = this.m_map.lightingAndGeometricsScenes["Act1"];
			onSceneLoadedCallback = null;
			return assetReference;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000124AC File Offset: 0x000106AC
		protected override int GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
			return -1;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x000124B2 File Offset: 0x000106B2
		protected override void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x000124B7 File Offset: 0x000106B7
		protected override void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000124BC File Offset: 0x000106BC
		protected override void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000124C1 File Offset: 0x000106C1
		protected override void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x040001E7 RID: 487
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesRequired = new List<GameplayObjectives.Objective>();

		// Token: 0x040001E8 RID: 488
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesOptional = new List<GameplayObjectives.Objective>();

		// Token: 0x040001E9 RID: 489
		private JobWithEmployerDefaultMenuModel m_mainMenuModel;

		// Token: 0x040001EA RID: 490
		private JobWithEmployerModelGoneDefaultMenuModel m_mainMenuModelGone;
	}
}

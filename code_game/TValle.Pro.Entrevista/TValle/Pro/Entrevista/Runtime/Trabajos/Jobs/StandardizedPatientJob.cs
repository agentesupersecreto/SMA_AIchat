using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Base.Controllers.Runtime;
using Assets.Base.CustomMonoBehaviours.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.AI.Estimulos.ObjetosEstimulantes;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime.Nombres;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets.TValle.BeachGirl.Runtime.XRays.Inputs;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.Menus.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Penes;
using Assets.TValle.Pro.Entrevista.Runtime.Penes.BuffAndDebuff;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Globales;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.UI;
using PixelCrushers.DialogueSystem;
using TValleCustomClases;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs
{
	// Token: 0x02000061 RID: 97
	public class StandardizedPatientJob : TValleSMAJob_Ext, ISMAJob
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x000145B4 File Offset: 0x000127B4
		protected override bool tryToKeepScenesAlive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x000145B7 File Offset: 0x000127B7
		public float doctorLvl
		{
			get
			{
				return this.m_doctorLvl;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000145C0 File Offset: 0x000127C0
		private void AwakeDebugger()
		{
			if (Application.isEditor)
			{
				this.m_Debugger = Object.FindAnyObjectByType<StandardizedPatientDebugger>();
			}
			StandardizedPatientDebugger debugger = this.m_Debugger;
			this.isDebugging = ((debugger != null) ? new bool?(debugger.activado) : null).GetValueOrDefault();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0001460C File Offset: 0x0001280C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.AwakeDebugger();
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0001461A File Offset: 0x0001281A
		private void OnHeroineLoading_DEBUG(SceneCharacter heroineLoading)
		{
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0001461C File Offset: 0x0001281C
		private void OnHeroineLoaded_DEBUG()
		{
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001461E File Offset: 0x0001281E
		private void OnHeroLoaded_DEBUG()
		{
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00014620 File Offset: 0x00012820
		private void Update_DEBUG()
		{
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00014622 File Offset: 0x00012822
		private void OnDoctorLVL_DEBUG(ref float docLvl)
		{
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x00014624 File Offset: 0x00012824
		public override bool nonPlayerCharacterWillRememberPlayerCharacter
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x00014627 File Offset: 0x00012827
		protected override ActividadScenesLoader.SceneLoadOrder initialLoadOrder
		{
			get
			{
				return ActividadScenesLoader.SceneLoadOrder.Pre_Main_Lighting_Post;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0001462A File Offset: 0x0001282A
		protected override float phoneAndCameraScreenEmissionModifier
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x00014631 File Offset: 0x00012831
		protected override string dispatchDialogueID
		{
			get
			{
				return "SP.dispatch";
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00014638 File Offset: 0x00012838
		public override IEnumerator DoStart()
		{
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeAI>();
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeTrabajosDeModelaje>();
			this.m_LuaListener = new StandardizedPatientJob.LuaListener();
			CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>().AddListiner(this.m_LuaListener);
			GoToScenaManager.GoTo femGOTO = Singleton<GoToScenaManager>.instance.Obtener(StandardizedPatientJob.GetPatientGotoID(base.lvl));
			yield return base.ResetMainCamera(StandardizedPatientJob.GetDoctorGotoID(base.lvl));
			CameraFade.FadeOutMain(0.0001f);
			LoaderDeNpcMasculinos.RandomGeneratorOverrider randomGeneratorOverrider = default(LoaderDeNpcMasculinos.RandomGeneratorOverrider);
			randomGeneratorOverrider.height = new float?(Mathf.Lerp(0.25f, 0.75f, Random.value));
			Action<SceneCharacter> action = delegate(SceneCharacter sc)
			{
				CharacterWallet componentEnRoot2 = sc.GetComponentEnRoot(false);
				if (componentEnRoot2 != null)
				{
					componentEnRoot2.msgChanges = false;
				}
				ICharacter componentEnRoot3 = sc.GetComponentEnRoot(false);
				Transform boneTransform = ((componentEnRoot3 != null) ? componentEnRoot3.bodyAnimator : null).GetBoneTransform(HumanBodyBones.Head);
				GameObject object7 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.MedicLuz");
				Vector3 position = object7.transform.position;
				this.m_luzDeDoc = Object.Instantiate<GameObject>(object7, boneTransform.TransformPoint(position), boneTransform.rotation, sc.transform);
				this.m_luzDeDoc.GetComponentInChildren<BaseFolowTransform>().afterFollowedFixes = delegate(Transform luzTRans)
				{
					CurrentMainChar instance = Singleton<CurrentMainChar>.instance;
					Transform transform;
					if (instance == null)
					{
						transform = null;
					}
					else
					{
						CurrentMainChar.ICamera camara = instance.camara;
						transform = ((camara != null) ? camara.cameraTransform : null);
					}
					Transform transform2 = transform;
					if (transform2 != null)
					{
						luzTRans.SetPositionAndRotation(transform2.position, transform2.rotation);
					}
				};
				this.m_luzDeDoc.SetActive(true);
			};
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(StandardizedPatientJob.GetDoctorGotoID(base.lvl));
			yield return base.GenerarMaleCharacter(goTo.transform.position, goTo.transform.forward, randomGeneratorOverrider, null, action, true, "sp.MaleMedical");
			this.m_doctorLvl = Random.value;
			this.OnDoctorLVL_DEBUG(ref this.m_doctorLvl);
			yield return base.LoadFemaleCharacter(this.m_mainNonPlayerCharacterID, femGOTO.transform.position, femGOTO.transform.forward, null, true, new Action<SceneCharacter>(this.OnHeroineLoading_DEBUG));
			yield return null;
			this.OnHeroLoaded_DEBUG();
			Singleton<ActividadesManager>.instance.AddExtraComponentsAndConfigToCharacters();
			RecopiladorDeCalculosParaReactores componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			componentEnRoot.puedeIgnorarCalculosParaReactores = true;
			componentEnRoot.Ignorar(new RecopiladorDeCalculosParaReactores.IgnoracionesDeEmocion
			{
				emocion = ReaccionHumana.placer,
				maxValue = false,
				enabled = true
			});
			componentEnRoot.Ignorar(new RecopiladorDeCalculosParaReactores.IgnoracionesDeEmocion
			{
				emocion = ReaccionHumana.decepcion,
				maxValue = false,
				enabled = true
			});
			base.mainNonPlayerCharacter.GetComponentEnRoot(false).puedeMostrarXRaysAND.ObtenerModificadorNotNull(this).valor.valor = false;
			this.OnHeroineLoaded_DEBUG();
			GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.LuzCamilla");
			GameObject object2 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.LuzOficina");
			GameObject object3 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.LuzSillaGine");
			GameObject object4 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.LuzOficinaGine");
			GameObject object5 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.Camilla");
			GameObject object6 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.SillaGine");
			object6.GetComponentInChildren<IUsable>().onUsado += this.UsableDeSilla_onUsado;
			if (this.EsExamenGinecologico())
			{
				@object.SetActive(false);
				object2.SetActive(false);
				object3.SetActive(true);
				object4.SetActive(true);
				object5.SetActive(false);
				object6.SetActive(true);
			}
			else
			{
				@object.SetActive(true);
				object2.SetActive(true);
				object3.SetActive(false);
				object4.SetActive(false);
				object5.SetActive(true);
				object6.SetActive(false);
			}
			this.m_jobManager.objectives.StartSession();
			this.m_jobManager.UI.showMenuKeyReleased += base.UI_showMenuKeyReleased;
			yield break;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00014648 File Offset: 0x00012848
		private void UsableDeSilla_onUsado(Transform obj)
		{
			if (this.m_SillaControlCoolDown.isOn)
			{
				return;
			}
			if (this.m_sillaGineAlturaTarget > 0f)
			{
				this.m_sillaGineAlturaTarget = 0f;
			}
			else
			{
				this.m_sillaGineAlturaTarget = 1f;
			}
			this.m_flagUpdateSillaAlturaDeInmediato = true;
			this.m_SillaControlCoolDown.ApplyNext(1.5f);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001469F File Offset: 0x0001289F
		protected bool EsExamenGinecologico()
		{
			return base.lvl > 3;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x000146AA File Offset: 0x000128AA
		protected static bool EsExamenGinecologico(int lvl)
		{
			return lvl > 3;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000146B0 File Offset: 0x000128B0
		public override IEnumerator Introduce()
		{
			if (this.isDebugging && this.m_Debugger.forceExamen)
			{
				Character femChar = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter;
				DialogueLua.SetVariable("TVALLE.SP.EXAMEN_SELECTED", (int)this.m_Debugger.examen);
				string patientCamillaGotoID = StandardizedPatientJob.GetPatientCamillaGotoID(base.lvl);
				FemaleAnimController componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				base.TeleportToGOTO(femChar, patientCamillaGotoID, true);
				componentEnRoot.animatedPoseID = FemaleAnimatedPoseIDs.None;
				femChar.bodyAnimator.Play("Idling", 0, 0f);
				ConsentToHero componentEnRoot2 = femChar.GetComponentEnRoot<ConsentToHero>();
				Arousal componentEnRoot3 = femChar.GetComponentEnRoot<Arousal>();
				Personalidad componentEnRoot4 = femChar.GetComponentEnRoot<Personalidad>();
				List<ParteDelCuerpoHumano> list;
				List<RopaCubre> list2;
				List<RopaPosicion> list3;
				string text;
				List<ParteDelCuerpoHumano> postCorrerEn;
				StandardizedPatientJob.ConjuntoSegunExamen(this.m_Debugger.examen, componentEnRoot2, componentEnRoot3, componentEnRoot4, out list, out list2, out list3, out text, out postCorrerEn);
				ConjuntoDeRopaLoader loader = femChar.GetComponentEnRoot(true);
				if (string.IsNullOrEmpty(text))
				{
					List<string> piezasaQuitarDeConjuntoActual = new List<string>();
					if (list != null && list.Count > 0)
					{
						list.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ForEach(delegate(RopaCubre c)
						{
							loader.CantidadPiezasCubriendo(c, true, piezasaQuitarDeConjuntoActual);
						});
					}
					if (list2 != null && list2.Count > 0)
					{
						list2.ForEach(delegate(RopaCubre c)
						{
							loader.CantidadPiezasCubriendo(c, true, piezasaQuitarDeConjuntoActual);
						});
					}
					if (list3 != null && list3.Count > 0)
					{
						list3.ForEach(delegate(RopaPosicion c)
						{
							loader.CantidadPiezas(c, true, piezasaQuitarDeConjuntoActual);
						});
					}
					if (postCorrerEn != null && postCorrerEn.Count > 0)
					{
						postCorrerEn.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ForEach(delegate(RopaCubre c)
						{
							loader.CantidadPiezasCubriendo(c, true, piezasaQuitarDeConjuntoActual);
						});
					}
					piezasaQuitarDeConjuntoActual = piezasaQuitarDeConjuntoActual.Distinct<string>().ToList<string>();
					int num;
					for (int i = 0; i < piezasaQuitarDeConjuntoActual.Count; i = num + 1)
					{
						loader.RemovePieza(piezasaQuitarDeConjuntoActual[i], true, femChar);
						yield return null;
						num = i;
					}
					CameraFade.FadeInMain(0.75f);
				}
				else
				{
					MapaConjuntoDeRopa conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto(text);
					yield return Singleton<ActividadesManager>.instance.SetOutfitAndWait(this.m_mainNonPlayerCharacterID, conjunto, true);
					CameraFade.FadeInMain(0.75f);
					if (postCorrerEn != null && postCorrerEn.Count > 0)
					{
						DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
						helper.Init(femChar, femChar);
						helper.Mover(this, postCorrerEn, true, false);
						while (helper.ejecutandose)
						{
							yield return null;
						}
						helper = null;
					}
				}
				this.m_esperandoNavaCamilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.WaitNavToCamillaRutine(this.m_Debugger.examen, null), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
				yield break;
			}
			this.m_introduciendoNavegandoASilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.IntroducePatienNavToSilla(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			this.m_introduciendo = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.IntroduceToNewPatientRutine(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000146BF File Offset: 0x000128BF
		public override IEnumerator Conclude()
		{
			this.m_jobManager.UI.ShowCurrentJobSessionObjetives(false, true);
			base.isAborted = base.isAborted || Actividad.running.aborted || !this.m_jobManager.objectives.CheckCompleted();
			List<SceneCharacterFromToBuffAndDebuff> list = new List<SceneCharacterFromToBuffAndDebuff>();
			ICharactersSceneInteractionsArchived mainArchivedInteractions = this.m_jobManager.interactions.GetMainArchivedInteractions(this.m_jobManager.current.mainPlayerCharacter.ID, this.m_jobManager.current.mainNonPlayerCharacter.ID);
			float num = base.CalcularFatiga(mainArchivedInteractions) * 0.333f;
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
			this.m_jobManager.interactions.DefaultBuffAndDebuffGenerate(this.m_jobManager.current.mainPlayerCharacter.ID, this.m_jobManager.current.mainNonPlayerCharacter, base.isAborted, base.date, out sceneCharacterFromToBuffAndDebuff);
			list.Add(sceneCharacterFromToBuffAndDebuff);
			SceneCharacterFromToBuffAndDebuff BuffAndDebuffOnFemale = SceneCharacterFromToBuffAndDebuff.Combine(list);
			MemoriaDeSMAJobs.RegistrarNewSesionesLaboralDeCharacter(AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(this, AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter));
			int num2;
			int num3;
			int num4;
			int num5;
			this.m_jobManager.objectives.SessionStatus(out num2, out num3, out num4, out num5);
			float num6 = base.DefaultExpGainCalcule(base.lvl, num2, num3, num4, (base.lvl == 0) ? 0f : 0.6666f, new int[] { 1, 4, 4, 4, 4, 4, 4, 4 });
			float num7;
			float num8;
			base.SetExpToMainCharacters(num6, out num7, out num8, 0.1f, 0f);
			float num9;
			base.SetFatigueToMainCharacters(ref num, out num9, base.lvl, new float[] { 3f, 3f, 5f, 5f, 8f, 8f, 8f, 8f });
			float num10;
			base.SetFatigueToJob(0f, out num10);
			float num11;
			base.SetFatigueToMainNonPlayerInJob(50f, out num11);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			float num12 = this.m_jobManager.PayMoneyToManager((base.isAborted ? 0.333f : 1f) * ((float)(num3 + num5) * 0.05f + 1f), 0f);
			Singleton<ActividadesManager>.instance.SetUIInputsActive(true);
			yield return this.m_jobManager.UI.ShowDefaultEndSessionPanel(base.isAborted, num12, num7, num8, num, num9, null, BuffAndDebuffOnFemale);
			this.RemoverBuffDeContrato();
			BuffAndDebuffOnFemale.Apply();
			yield break;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000146CE File Offset: 0x000128CE
		public override IEnumerator End()
		{
			CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>().RemoveListiner(this.m_LuaListener);
			this.m_jobManager.UI.showMenuKeyReleased -= base.UI_showMenuKeyReleased;
			this.m_jobManager.UpdateCharacterMemory(base.mainNonPlayerCharacter);
			this.m_jobManager.DeleteAndDestroyCharacter(this.m_mainPlayerCharacterID);
			this.m_jobManager.objectives.EndSession();
			this.m_LuaListener = null;
			yield break;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x000146DD File Offset: 0x000128DD
		private static MesitaParaHerramientasConSlots GetMesaDeObjetos(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.mesaParaObjetosGine").GetComponent<MesitaParaHerramientasConSlots>();
			}
			return InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.mesaParaObjetos").GetComponent<MesitaParaHerramientasConSlots>();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00014710 File Offset: 0x00012910
		private static string GetMesaDeObjetosGoto(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "MesitaGineTarget_GoTo";
			}
			return "MesitaTarget_GoTo";
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00014725 File Offset: 0x00012925
		private static string GetMesaDeObjetosGotoInverted(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				throw new NotSupportedException("en ginecologia, no es necesario tener la mesita invertida o al otro lado");
			}
			return "MesitaTargetInvert_GoTo";
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001473F File Offset: 0x0001293F
		private static string GetDoctorGotoID(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "WelcomeMedicGine_GoTo";
			}
			return "WelcomeMedic_GoTo";
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00014754 File Offset: 0x00012954
		private static string GetPatientGotoID(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "WelcomePatientGine_GoTo";
			}
			return "WelcomePatient_GoTo";
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00014769 File Offset: 0x00012969
		private static string GetPatientSillaGotoID(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "WelcomePatientSillaGine_GoTo";
			}
			return "WelcomePatientSilla_GoTo";
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001477E File Offset: 0x0001297E
		private static string GetPatientCambiadorGotoID(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "PatientCambiarRopaGine_GoTo";
			}
			return "PatientCambiarRopa_GoTo";
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00014793 File Offset: 0x00012993
		private static string GetPatientCamillaGotoID(int lvl)
		{
			if (StandardizedPatientJob.EsExamenGinecologico(lvl))
			{
				return "GOTO.SP.CamillaGineMain.FemSentar";
			}
			return "GOTO.SP.CamillaMain.FemSentar";
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000147A8 File Offset: 0x000129A8
		private static FemaleAnimatedRecostarseIDs GetDefaultPose(StandardizedPatientJob.Examen examen)
		{
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
			case StandardizedPatientJob.Examen.MammographicExamination:
				return FemaleAnimatedRecostarseIDs.sentarseEnCamilla;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				return FemaleAnimatedRecostarseIDs.acostarseEnCamilla;
			case StandardizedPatientJob.Examen.Anoscopy:
			case StandardizedPatientJob.Examen.VaginalWallInspection:
			case StandardizedPatientJob.Examen.Proctoscopy:
			case StandardizedPatientJob.Examen.CervicalInspection:
			case StandardizedPatientJob.Examen.Rectoscopy:
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
			case StandardizedPatientJob.Examen.VideoRectoscopy:
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				return FemaleAnimatedRecostarseIDs.sentarse;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00014818 File Offset: 0x00012A18
		private static string GetDoctorCamillaExamenGotoID(StandardizedPatientJob.Examen examen)
		{
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
			case StandardizedPatientJob.Examen.MammographicExamination:
				return "DoctorExamen_GoTo";
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				return "DoctorExamenInvert_GoTo";
			case StandardizedPatientJob.Examen.Anoscopy:
			case StandardizedPatientJob.Examen.VaginalWallInspection:
			case StandardizedPatientJob.Examen.Proctoscopy:
			case StandardizedPatientJob.Examen.CervicalInspection:
			case StandardizedPatientJob.Examen.Rectoscopy:
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
			case StandardizedPatientJob.Examen.VideoRectoscopy:
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				return "DoctorExamenGine_GoTo";
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00014891 File Offset: 0x00012A91
		private void UpdateMenus()
		{
			this.RemoveMenus();
			this.AddMenus();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000148A0 File Offset: 0x00012AA0
		private void RemoveMenus()
		{
			RadialMenusForActivities instance = AsyncSingleton<RadialMenusForActivities>.instance;
			Character component = this.m_jobManager.current.mainNonPlayerCharacter.GetComponent<Character>();
			instance.RemoveAllRadialMenus(component);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000148D0 File Offset: 0x00012AD0
		private void AddMenus()
		{
			RadialMenusForActivities instance = AsyncSingleton<RadialMenusForActivities>.instance;
			Character component = this.m_jobManager.current.mainNonPlayerCharacter.GetComponent<Character>();
			((IGreyableTHSDonaItem)instance.AddRadialMenu(component, "GOTOS")).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuGOTOIsGrayOut));
			if (this.m_estadoGeneral == StandardizedPatientJob.GamePlayEstadoGeneral.examinando)
			{
				IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem = instance.AddRadialMenu(component, "FAST_GUIDEHER");
				clickableSelectableTHSDonaItem.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuGuideHerClicked));
				((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuGuideHerIsGrayOut));
				IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem2 = instance.AddRadialMenu(component, "FAST_RELAX");
				clickableSelectableTHSDonaItem2.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuRelaxClicked));
				((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem2).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuRelaxIsGrayOut));
				IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem3 = instance.AddRadialMenu(component, "OPEN_BOCA");
				clickableSelectableTHSDonaItem3.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuOpenBocaClicked));
				((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem3).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuOpenBocaIsGrayOut));
				if (!this.m_yaPreguntoSintomas)
				{
					IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem4 = instance.AddRadialMenu(component, "SINTOMAS");
					clickableSelectableTHSDonaItem4.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuSintomasClicked));
					((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem4).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuSintomasIsGrayOut));
					return;
				}
				if (!this.m_LuaListener.diagnosticada)
				{
					IClickableSelectableTHSDonaItem clickableSelectableTHSDonaItem5 = instance.AddRadialMenu(component, "DIAGNOSTICAR");
					clickableSelectableTHSDonaItem5.onOpcionClicked.AddListener(new UnityAction<THSDonaController.CurrentUserData, THSDonaController, THSDonaController.RadialItemData, object>(this.OnMenuDiagnosticarClicked));
					((IGreyableTHSDonaItem)clickableSelectableTHSDonaItem5).onCheckGreyOutEvent.AddListener(new UnityAction<EsGreyOutEventArgs, object>(this.MenuDiagnosticarIsGrayOut));
				}
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00014A78 File Offset: 0x00012C78
		private void OnMenuDiagnosticarClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			if (DialogueManager.IsConversationActive)
			{
				return;
			}
			ActividadesManager instance = Singleton<ActividadesManager>.instance;
			string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.Diagnose");
			instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00014AD6 File Offset: 0x00012CD6
		private void MenuDiagnosticarIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_LuaListener.diagnosticada || DialogueManager.IsConversationActive || this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.examinando;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00014B04 File Offset: 0x00012D04
		private void OnMenuSintomasClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			if (DialogueManager.IsConversationActive)
			{
				return;
			}
			ActividadesManager instance = Singleton<ActividadesManager>.instance;
			string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.AskSyntoms");
			if (instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID))
			{
				this.m_yaPreguntoSintomas = true;
				this.UpdateMenus();
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00014B70 File Offset: 0x00012D70
		private void MenuSintomasIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_yaPreguntoSintomas || DialogueManager.IsConversationActive || this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.examinando;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00014B98 File Offset: 0x00012D98
		private void ValidadorDeCamillaAnimPoses(StandardizedPatientJob.Examen examen)
		{
			StandardizedPatientJob.<>c__DisplayClass50_0 CS$<>8__locals1 = new StandardizedPatientJob.<>c__DisplayClass50_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.examen = examen;
			if (this.EsExamenGinecologico())
			{
				return;
			}
			IRecostableConFemaleAnimPose componentInChildren = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.Camilla").GetComponentInChildren<IRecostableConFemaleAnimPose>();
			componentInChildren.getNextPostValidator -= CS$<>8__locals1.<ValidadorDeCamillaAnimPoses>g__ValidadorDeCamillaAnimPosesNext|0;
			componentInChildren.getNextPostValidator += CS$<>8__locals1.<ValidadorDeCamillaAnimPoses>g__ValidadorDeCamillaAnimPosesNext|0;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00014BFC File Offset: 0x00012DFC
		private void OnMenuOpenBocaClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			ControladorDeGestosDeBoca componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot.Gestuandose() != TiposDeGestosDeBoca.examinarBoca)
			{
				componentEnRoot.Gestuar(TiposDeGestosDeBoca.examinarBoca, 1f, int.MaxValue, ControllerPrioridadConfig.interrumpir, 15f, true, null, 0.5f, 1f);
				CurrentMainChar instance = Singleton<CurrentMainChar>.instance;
				Transform transform;
				if (instance == null)
				{
					transform = null;
				}
				else
				{
					CurrentMainChar.ICamera camara = instance.camara;
					transform = ((camara != null) ? camara.cameraTransform : null);
				}
				Transform transform2 = transform;
				if (transform2 != null)
				{
					base.mainNonPlayerCharacter.GetComponentEnRoot(false).Mirar(1f, 1f, transform2, LookAtControllerV2.LookAtType.evadirUp, true, LookAtControllerV2.LookAtType.fijamente, true, 1f, int.MaxValue, 15f, ControllerPrioridadConfig.interrumpir, default(Vector3), true, 15f);
					return;
				}
			}
			else
			{
				componentEnRoot.DetenerGesto(TiposDeGestosDeBoca.examinarBoca);
				CurrentMainChar instance2 = Singleton<CurrentMainChar>.instance;
				Transform transform3;
				if (instance2 == null)
				{
					transform3 = null;
				}
				else
				{
					CurrentMainChar.ICamera camara2 = instance2.camara;
					transform3 = ((camara2 != null) ? camara2.cameraTransform : null);
				}
				Transform transform4 = transform3;
				if (transform4 != null)
				{
					base.mainNonPlayerCharacter.GetComponentEnRoot(false).Mirar(1f, 1f, transform4, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 1f, int.MaxValue, 5f, ControllerPrioridadConfig.interrumpir, default(Vector3), true, 5f);
				}
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00014D3C File Offset: 0x00012F3C
		private void MenuOpenBocaIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.examinando;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00014D50 File Offset: 0x00012F50
		private void OnMenuGuideHerClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			BoneGuiable.ActivateSkeletonEditorMode(Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter, false, false);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00014D7E File Offset: 0x00012F7E
		private void MenuGuideHerIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			args.esGreyOut = this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.examinando;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00014D94 File Offset: 0x00012F94
		private void OnMenuRelaxClicked(THSDonaController.CurrentUserData userData, THSDonaController dona, THSDonaController.RadialItemData itemData, object sender)
		{
			if (THSDonaController.instance.enUso)
			{
				THSDonaController.instance.StopDrawing();
			}
			foreach (InteraccionDeCharacter interaccionDeCharacter in base.mainNonPlayerCharacter.GetComponentInChildren<IInteraccionesDeCharacter>().interaccionesPrimariasBases)
			{
				if (interaccionDeCharacter.instancia.ejecutandose || interaccionDeCharacter.instancia.algunaEstaEjecutandose)
				{
					interaccionDeCharacter.instancia.Detener(false);
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00014E20 File Offset: 0x00013020
		private void MenuRelaxIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			IInteraccionesDeCharacter componentInChildren = base.mainNonPlayerCharacter.GetComponentInChildren<IInteraccionesDeCharacter>();
			args.esGreyOut = componentInChildren.ObtenerFirstEjecutandosePrimaria() == null;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00014E48 File Offset: 0x00013048
		private void MenuGOTOIsGrayOut(EsGreyOutEventArgs args, object sender)
		{
			IInteraccionesDeCharacter componentInChildren = base.mainNonPlayerCharacter.GetComponentInChildren<IInteraccionesDeCharacter>();
			args.esGreyOut = this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.examinando || componentInChildren.ObtenerFirstEjecutandosePrimaria() != null;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00014E7C File Offset: 0x0001307C
		protected override object GetUIMenuModel()
		{
			return base.GetDefaultUIModel_ForEmployers();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00014E84 File Offset: 0x00013084
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00014E86 File Offset: 0x00013086
		public override void AfterAnimationsUpdate()
		{
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00014E88 File Offset: 0x00013088
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00014E8A File Offset: 0x0001308A
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00014E8C File Offset: 0x0001308C
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00014E8E File Offset: 0x0001308E
		public override void AfterAIUpdate()
		{
			this.Update_DEBUG();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00014E96 File Offset: 0x00013096
		protected override IEnumerator LoadingInitialScences()
		{
			yield break;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00014E9E File Offset: 0x0001309E
		protected override AssetReference GetMainSceneAssetReference()
		{
			return this.m_map.mainScene;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00014EAB File Offset: 0x000130AB
		protected override int GetMainSceneBuildIndex()
		{
			return -1;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00014EAE File Offset: 0x000130AE
		protected override void OnMainSceneLoaded(Scene scene, bool success)
		{
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00014EB0 File Offset: 0x000130B0
		protected override AssetReference GetLightingAndGeometricsSceneAssetReferenceToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			string text = "Act1";
			AssetReference assetReference = this.m_map.lightingAndGeometricsScenes[text];
			onSceneLoadedCallback = null;
			return assetReference;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00014ED7 File Offset: 0x000130D7
		protected override int GetLightingAndGeometricsSceneBuildIndexToLoadOnLoadJob(out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
			return -1;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00014EDD File Offset: 0x000130DD
		protected override void GetPreSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00014EE2 File Offset: 0x000130E2
		protected override void GetPreSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00014EE7 File Offset: 0x000130E7
		protected override void GetPostSceneAssetReferencesToLoadOnLoadJob(List<AssetReference> AdditionalScenesToLoad, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00014EEC File Offset: 0x000130EC
		protected override void GetPostSceneBuildIndexToLoadOnLoadJob(List<int> BuildIndex, out ActividadScenesLoader.OnSceneLoadedHandler onSceneLoadedCallback)
		{
			onSceneLoadedCallback = null;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00014EF1 File Offset: 0x000130F1
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00014EF3 File Offset: 0x000130F3
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00014EF5 File Offset: 0x000130F5
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00014EF8 File Offset: 0x000130F8
		private static float GetEfectividadDeDrogasSeleccionadas(List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> suministradas, Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContra)
		{
			float num = 0f;
			foreach (RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta spdiagnosticoReceta in suministradas)
			{
				float num2;
				if (efectividadContra.TryGetValue(spdiagnosticoReceta, out num2))
				{
					num += num2;
				}
				else
				{
					num -= 0.25f;
				}
			}
			return num;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00014F60 File Offset: 0x00013160
		private static float GetEfectividadDeDrogasSeleccionadas(List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> suministradas, string atacandoCondicionID)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(atacandoCondicionID);
			if (num <= 2345099119U)
			{
				if (num <= 536786912U)
				{
					if (num != 250150580U)
					{
						if (num == 536786912U)
						{
							if (atacandoCondicionID == "Sick_MucosalVascularProminence_")
							{
								return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraMucosalVascularProminence);
							}
						}
					}
					else if (atacandoCondicionID == "Sick_ColonIrritable_")
					{
						return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraIrritableBowelSyndrome);
					}
				}
				else if (num != 710740112U)
				{
					if (num != 2061893184U)
					{
						if (num == 2345099119U)
						{
							if (atacandoCondicionID == "Sick_NabothianCysts_")
							{
								return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraNabothianCysts);
							}
						}
					}
					else if (atacandoCondicionID == "Sick_VaginalCyst_")
					{
						return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraVaginalCyst);
					}
				}
				else if (atacandoCondicionID == "Sick_Fiebre_")
				{
					return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraFiebre);
				}
			}
			else if (num <= 2784187069U)
			{
				if (num != 2541638720U)
				{
					if (num != 2732316013U)
					{
						if (num == 2784187069U)
						{
							if (atacandoCondicionID == "Sick_FibrocysticBreast_")
							{
								return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraFibrocysticBreast);
							}
						}
					}
					else if (atacandoCondicionID == "Sick_Constripacion_")
					{
						return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraConstipation);
					}
				}
				else if (atacandoCondicionID == "Sick_MucosalIrregularity_")
				{
					return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraMucosalIrregularity);
				}
			}
			else if (num != 2836391334U)
			{
				if (num != 2861057067U)
				{
					if (num == 3112692206U)
					{
						if (atacandoCondicionID == "Sick_FornixSwelling_")
						{
							return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraPosteriorFornixSwelling);
						}
					}
				}
				else if (atacandoCondicionID == "Sick_Amigdalitis_")
				{
					return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraAmigdalitis);
				}
			}
			else if (atacandoCondicionID == "Sick_Hemorroides_")
			{
				return StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, StandardizedPatientJob.efectividadContraHemorrhoids);
			}
			Debug.LogError("no se reconoce condicion medica: " + atacandoCondicionID);
			return -1f;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00015190 File Offset: 0x00013390
		private void RemoverBuffDeContrato()
		{
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobContract", string.Empty));
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobContract", string.Empty));
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.EmotionGainMod", "SP.Exam.Placer"));
			componentEnRoot.eventos.Remove(BuffMap.GenerateBuffID("Tvalle.Buff.EmotionGainMod", "SP.Exam.Placer"));
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0001522E File Offset: 0x0001342E
		private IEnumerator WaitForContractable()
		{
			BuffDeCharacter m_BuffDeCharacter = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			while (!m_BuffDeCharacter.isStared)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00015240 File Offset: 0x00013440
		private void GenerarBuffDeContratoInicial()
		{
			this.RemoverBuffDeContrato();
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			BuffMap buffMap;
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
			BuffMap buffMap2;
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
			this.GenerarContractBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg);
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			List<GenericDataExclusiveOfInteractionArg> list2 = new List<GenericDataExclusiveOfInteractionArg>();
			this.FillInclusiveData_Iniciales(list);
			this.FillExclusionesData_Iniciales(list2);
			buffOnMinFavorabilityValueArg.InyectData(list);
			buffOnMinFavorabilityValueArg.InyectExclusiveData(list2);
			buffOnDeshieloDeEstimuloEnPartesArg.InyectData(list);
			this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000152D0 File Offset: 0x000134D0
		private void GenerarBuffDeContratoDeExamen(StandardizedPatientJob.Examen examen)
		{
			this.RemoverBuffDeContrato();
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
			BuffMap buffMap;
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
			BuffMap buffMap2;
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
			this.GenerarContractBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg);
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			List<GenericDataExclusiveOfInteractionArg> list2 = new List<GenericDataExclusiveOfInteractionArg>();
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
				this.FillInclusiveData_ExamenGeneral(list);
				this.FillExclusionesData_ExamenGeneral(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				this.FillInclusiveData_ExamenAbdominalRadiographic(list);
				this.FillExclusionesData_ExamenAbdominalRadiographic(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				this.FillInclusiveData_ExamenClinicalBreast(list);
				this.FillExclusionesData_ExamenClinicalBreast(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.MammographicExamination:
				this.FillInclusiveData_ExamenMamografia(list);
				this.FillExclusionesData_ExamenMamografia(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				this.FillInclusiveData_Termometro(list);
				this.FillExclusionesData_Termometro(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				this.FillInclusiveData_DigitalAnus(list);
				this.FillExclusionesData_DigitalAnus(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				this.FillInclusiveData_DigitalVag(list);
				this.FillExclusionesData_DigitalVag(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.Anoscopy:
			case StandardizedPatientJob.Examen.Proctoscopy:
			case StandardizedPatientJob.Examen.Rectoscopy:
			case StandardizedPatientJob.Examen.VideoRectoscopy:
				this.FillInclusiveData_Anoscopy(list);
				this.FillExclusionesData_Anoscopy(list2);
				goto IL_0154;
			case StandardizedPatientJob.Examen.VaginalWallInspection:
			case StandardizedPatientJob.Examen.CervicalInspection:
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				this.FillInclusiveData_VaginalInspection(list);
				this.FillExclusionesData_VaginalInspection(list2);
				goto IL_0154;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
			IL_0154:
			buffOnMinFavorabilityValueArg.InyectData(list);
			buffOnMinFavorabilityValueArg.InyectExclusiveData(list2);
			buffOnDeshieloDeEstimuloEnPartesArg.InyectData(list);
			this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00015458 File Offset: 0x00013658
		private void GenerarContractBuffes(BuffDeCharacter m_BuffDeCharacter, out BuffMap favMap, out BuffOnMinFavorabilityValueArg favArgument, out BuffMap desMap, out BuffOnDeshieloDeEstimuloEnPartesArg desArgument)
		{
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobContract", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text);
			favMap = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.FavorabilityByJobContract");
			if (favMap == null)
			{
				Debug.LogException(new ArgumentNullException("favMap", "favMap null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(favMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnMinFavorabilityValueArg>(efecto.argumentoID, out favArgument))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			string text2 = BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobContract", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text2);
			desMap = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.DeshieloByJobContract");
			if (desMap == null)
			{
				Debug.LogException(new ArgumentNullException("desMap", "desMap null reference."));
			}
			Efecto efecto2 = Singleton<EfectosManager>.instance.GetEfecto(desMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnDeshieloDeEstimuloEnPartesArg>(efecto2.argumentoID, out desArgument))
			{
				Debug.LogError("arg id :" + efecto2.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00015580 File Offset: 0x00013780
		private void AddBuffToCharacter(BuffDeCharacter m_BuffDeCharacter, BuffMap favMap, BuffOnMinFavorabilityValueArg favArgument, BuffMap desMap, BuffOnDeshieloDeEstimuloEnPartesArg desArgument)
		{
			favArgument.changedByFatigue = true;
			favArgument.force = true;
			desArgument.value = 100f;
			DisplayableBuff eventoBuff = favMap.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, favArgument, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff.showSmallMsgOnApplied = false;
			eventoBuff.showSmallMsgOnEnd = false;
			eventoBuff.showSmallMsgOnStart = false;
			m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
			DisplayableBuff eventoBuff2 = desMap.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, desArgument, null);
			if (eventoBuff2 == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff2.showSmallMsgOnApplied = false;
			eventoBuff2.showSmallMsgOnEnd = false;
			eventoBuff2.showSmallMsgOnStart = false;
			m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff2, false, false);
			StandardizedPatientJob.<>c__DisplayClass99_0 CS$<>8__locals1 = new StandardizedPatientJob.<>c__DisplayClass99_0();
			Arousal componentEnRoot = m_BuffDeCharacter.GetComponentEnRoot(false);
			CS$<>8__locals1.arousalMod = ((componentEnRoot != null) ? componentEnRoot.value.mod : 0f);
			BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<DisplayableBuff, BuffOnEmocionGainArg>(m_BuffDeCharacter, "Tvalle.Buff.EmotionGainMod", this, new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<BuffOnEmocionGainArg>(CS$<>8__locals1.<AddBuffToCharacter>g__UpdateArgumentDataHandler|2), new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<DisplayableBuff>(StandardizedPatientJob.<AddBuffToCharacter>g__UpdateBuffConfigHandler|99_3), "SP.Exam.Placer", new BuffMap.Duracion
			{
				hours = 3
			});
			BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<DisplayableBuff, BuffOnEmocionGainArg>(m_BuffDeCharacter, "Tvalle.Buff.EmotionGainMod", this, new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<BuffOnEmocionGainArg>(StandardizedPatientJob.<AddBuffToCharacter>g__UpdateArgumentDataHandler|99_0), new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<DisplayableBuff>(StandardizedPatientJob.<AddBuffToCharacter>g__UpdateBuffConfigHandler|99_1), "SP.Exam.Placer", new BuffMap.Duracion
			{
				hours = 3
			});
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000156F0 File Offset: 0x000138F0
		private void FillInclusiveData_Iniciales(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000157A0 File Offset: 0x000139A0
		private void FillExclusionesData_Iniciales(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.02f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.desvestidura,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.peticionDesvestidura,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.ejecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.peticionEjecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.manipulandoBone;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg6 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg6.weight = 1f;
			genericDataExclusiveOfInteractionArg6.tipo = TipoDeEstimulo.guiandoBone;
			genericDataExclusiveOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg6.estiulante = ParteQuePuedeEstimular.boca;
			genericDataExclusiveOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg6);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00015C5C File Offset: 0x00013E5C
		private void FillInclusiveData_ExamenGeneral(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeFacial.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg2.estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Where((ParteDelCuerpoHumano p) => p != ParteDelCuerpoHumano.vientreBajo).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg2);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.cuello,
					ParteDelCuerpoHumano.mandibula,
					ParteDelCuerpoHumano.hombros
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00015F38 File Offset: 0x00014138
		private void FillExclusionesData_ExamenGeneral(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1.02f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg6 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg6.weight = 1.03f;
			genericDataExclusiveOfInteractionArg6.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg6.estiulante = ParteQuePuedeEstimular.propSexToy;
			genericDataExclusiveOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg6);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x000161FC File Offset: 0x000143FC
		private void FillInclusiveData_ExamenAbdominalRadiographic(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg2.estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Where((ParteDelCuerpoHumano p) => p != ParteDelCuerpoHumano.vientreBajo).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg2);
			GenericDataOfInteractionArg genericDataOfInteractionArg3 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg3.estiulante = ParteQuePuedeEstimular.propSexToy;
			genericDataOfInteractionArg3.estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Where((ParteDelCuerpoHumano p) => p != ParteDelCuerpoHumano.vientreBajo).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg3);
			GenericDataOfInteractionArg genericDataOfInteractionArg4 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg4.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg4.estiulante = ParteQuePuedeEstimular.semen;
			genericDataOfInteractionArg4.estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoDelantero.Where((ParteDelCuerpoHumano p) => p != ParteDelCuerpoHumano.vientreBajo).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg4);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.abdomen,
					ParteDelCuerpoHumano.hombligo,
					ParteDelCuerpoHumano.vientre
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00016518 File Offset: 0x00014718
		private void FillExclusionesData_ExamenAbdominalRadiographic(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1.02f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg6 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg6.weight = 1.03f;
			genericDataExclusiveOfInteractionArg6.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg6.estiulante = ParteQuePuedeEstimular.propSexToy;
			genericDataExclusiveOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg6);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000167DC File Offset: 0x000149DC
		private void FillInclusiveData_ExamenClinicalBreast(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000169E4 File Offset: 0x00014BE4
		private void FillExclusionesData_ExamenClinicalBreast(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where p != ParteDelCuerpoHumano.senos && p != ParteDelCuerpoHumano.pezones
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where p != ParteDelCuerpoHumano.senos && p != ParteDelCuerpoHumano.pezones
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1.02f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg6 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg6.weight = 1.03f;
			genericDataExclusiveOfInteractionArg6.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg6.estiulante = ParteQuePuedeEstimular.propSexToy;
			genericDataExclusiveOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg6);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00016CF0 File Offset: 0x00014EF0
		private void FillInclusiveData_ExamenMamografia(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pecho,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.hombros,
					ParteDelCuerpoHumano.axilas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pezones
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00016F78 File Offset: 0x00015178
		private void FillExclusionesData_ExamenMamografia(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where p != ParteDelCuerpoHumano.senos && p != ParteDelCuerpoHumano.pezones
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where p != ParteDelCuerpoHumano.senos && p != ParteDelCuerpoHumano.pezones
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1.02f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg6 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg6.weight = 1.03f;
			genericDataExclusiveOfInteractionArg6.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg6.estiulante = ParteQuePuedeEstimular.propSexToy;
			genericDataExclusiveOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg6);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00017284 File Offset: 0x00015484
		private void FillInclusiveData_Termometro(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.nalgas,
					ParteDelCuerpoHumano.coxis,
					ParteDelCuerpoHumano.espalda,
					ParteDelCuerpoHumano.perineo,
					ParteDelCuerpoHumano.bocaInterno,
					ParteDelCuerpoHumano.labios,
					ParteDelCuerpoHumano.mandibula,
					ParteDelCuerpoHumano.lengua
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.coxis }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.nalgas,
					ParteDelCuerpoHumano.coxis,
					ParteDelCuerpoHumano.perineo,
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.bocaInterno,
					ParteDelCuerpoHumano.labios,
					ParteDelCuerpoHumano.mandibula,
					ParteDelCuerpoHumano.lengua
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.bocaInterno
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00017540 File Offset: 0x00015740
		private void FillExclusionesData_Termometro(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where p != ParteDelCuerpoHumano.nalgas
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg5 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg5.weight = 1.02f;
			genericDataExclusiveOfInteractionArg5.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg5.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg5);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.03f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x000177F8 File Offset: 0x000159F8
		private void FillInclusiveData_DigitalAnus(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Concat(ParteDelCuerpoHumanoHelper.partesDeTrasero).ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.nalgas,
					ParteDelCuerpoHumano.piernas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.semen,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00017AF0 File Offset: 0x00015CF0
		private void FillExclusionesData_DigitalAnus(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where !ParteDelCuerpoHumanoHelper.partesDeTraseroSet.Contains((int)p)
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where !ParteDelCuerpoHumanoHelper.partesDeTraseroSet.Contains((int)p)
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.02f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.bocaInterno
				}
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.03f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.bocaInterno
				}
			});
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00017DA4 File Offset: 0x00015FA4
		private void FillInclusiveData_DigitalVag(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrozoTrasero.Concat(ParteDelCuerpoHumanoHelper.partesDeEntrepierna).ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.nalgas,
					ParteDelCuerpoHumano.piernas
				}
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
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
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001809C File Offset: 0x0001629C
		private void FillExclusionesData_DigitalVag(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where !ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet.Contains((int)p)
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.01f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				where !ParteDelCuerpoHumanoHelper.partesDeEntrepiernaSet.Contains((int)p)
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.02f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.03f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.02f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.dedo,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.bocaInterno
				}
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.03f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[]
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.bocaInterno
				}
			});
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00018350 File Offset: 0x00016550
		private void FillInclusiveData_Anoscopy(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
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
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000186E0 File Offset: 0x000168E0
		private void FillExclusionesData_Anoscopy(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.02f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.03f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.02f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.03f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000188FC File Offset: 0x00016AFC
		private void FillInclusiveData_VaginalInspection(List<GenericDataOfInteractionArg> ToInyecData)
		{
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where !p.EsPrivadaSocialmenteVisual()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeEntrepierna.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeTrasero.ToArray<ParteDelCuerpoHumano>()
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
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDeBrazos.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.torzo,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.tactil,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.piernas,
				estimuladas = ParteDelCuerpoHumanoHelper.partesDePiernas.ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.visual,
				direccion = DireccionDeEstimulo.dada,
				estiulante = ParteQuePuedeEstimular.ojos,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ojos }
			});
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00018C8C File Offset: 0x00016E8C
		private void FillExclusionesData_VaginalInspection(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1.01f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1.02f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsMuyPrivadaSocialmenteTactil()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1.03f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1.02f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1.03f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.propSexToy,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00018EA7 File Offset: 0x000170A7
		public override void Init(ISMAJobsManager jobManager, SMAJobMap map, int Lvl, Guid mainPlayerCharacterID, Guid mainNonPlayerCharacterID, DateTime inGameDate)
		{
			if (this.isDebugging && this.m_Debugger.forceLvl)
			{
				Lvl = this.m_Debugger.lvl;
			}
			base.Init(jobManager, map, Lvl, mainPlayerCharacterID, mainNonPlayerCharacterID, inGameDate);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00018EDA File Offset: 0x000170DA
		private IEnumerator IntroducePatienNavToSilla()
		{
			FemaleAnimController animControlle = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			if (animControlle == null)
			{
				Debug.LogException(new ArgumentNullException("animControlle", "animControlle null reference."), this);
			}
			while (!animControlle.isStared)
			{
				yield return null;
			}
			base.MainNonPlayerCharacterLookAtMainCharacter(10f, 1f, 1f, LookAtControllerV2.LookAtType.fijamente, true, LookAtControllerV2.LookAtType.fijamente, true, 3f);
			string patientSillaGotoID = StandardizedPatientJob.GetPatientSillaGotoID(base.lvl);
			yield return base.NavToGOTORutineSlow(Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter, patientSillaGotoID, false, () => animControlle.currentRecostableOnRange != null, 1f, null, true);
			animControlle.RecostarseEnCurrentRecostable(FemaleAnimatedRecostarseIDs.sentarse);
			yield break;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00018EE9 File Offset: 0x000170E9
		private IEnumerator IntroduceToNewPatientRutine()
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.introduciendo, true);
			yield return null;
			yield return this.WaitForContractable();
			this.GenerarBuffDeContratoInicial();
			yield return null;
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(false);
			CameraFade.FadeInMain(0.75f);
			bool flag = !this.isDebugging || !this.m_Debugger.ignoreWelcomeDialogue;
			string welcomeConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.Welcome");
			if (flag)
			{
				while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, welcomeConversation))
				{
					yield return null;
				}
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
			IRopaManager ropa = base.mainPlayerCharacter.GetComponentEnRoot(false);
			while (ropa.isLoadingConjunto)
			{
				yield return null;
			}
			AsyncSingleton<JobsManager>.instance.SetMainPlayerCharacterInputsActive(true);
			this.m_seleccionandoExam = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.SelectExamRutine(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00018EF8 File Offset: 0x000170F8
		private IEnumerator SelectExamRutine()
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.seleccionandoExamen, true);
			yield return null;
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string examenSelectConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.ExamenSelect");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, examenSelectConversation))
			{
				yield return null;
			}
			while (!this.m_LuaListener.seleccionoExamen || DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			string examenConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(StandardizedPatientJob.CoversationIDSegunExam((StandardizedPatientJob.Examen)this.m_LuaListener.examenID));
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, examenConversation))
			{
				yield return null;
			}
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			while (this.m_introduciendoNavegandoASilla.ejecutandose)
			{
				yield return null;
			}
			this.m_esperandoSpyOr = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update3, this, this.WaitSpyOrNoSpy(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00018F07 File Offset: 0x00017107
		private IEnumerator WaitSpyOrNoSpy()
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoEspiar, true);
			yield return null;
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string spyConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.ExamenSelectSpy");
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, spyConversation))
			{
				yield return null;
			}
			float startTime = Time.time;
			float num = 0f;
			while (num < 2f && this.m_LuaListener.quiereEspiar == null)
			{
				yield return null;
				num = Time.time - startTime;
			}
			if (DialogueManager.IsConversationActive)
			{
				DialogueManager.StopConversation();
			}
			if (this.m_LuaListener.quiereEspiar != null && this.m_LuaListener.quiereEspiar.Value)
			{
				this.m_esperandoCambioDeRopa = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.WaitRopaChangeRutine(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			}
			else
			{
				StandardizedPatientJob.<>c__DisplayClass144_0 CS$<>8__locals1 = new StandardizedPatientJob.<>c__DisplayClass144_0();
				CameraFade.FadeOutMain(0.75f);
				yield return new ManualCorrutina.TValleWaitForSeconds(1f);
				StandardizedPatientJob.Examen examen = (StandardizedPatientJob.Examen)this.m_LuaListener.examenID;
				string doctorCamillaExamenGotoID = StandardizedPatientJob.GetDoctorCamillaExamenGotoID(examen);
				Character mainPlayerCharacter = Singleton<ActividadesManager>.instance.current.mainPlayerCharacter;
				base.TeleportToGOTO(mainPlayerCharacter, doctorCamillaExamenGotoID, false);
				string patientCamillaGotoID = StandardizedPatientJob.GetPatientCamillaGotoID(base.lvl);
				Character femChar = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter;
				FemaleAnimController componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				base.TeleportToGOTO(femChar, patientCamillaGotoID, true);
				componentEnRoot.ForceIdleState();
				ConsentToHero componentEnRoot2 = femChar.GetComponentEnRoot<ConsentToHero>();
				Arousal componentEnRoot3 = femChar.GetComponentEnRoot<Arousal>();
				Personalidad componentEnRoot4 = femChar.GetComponentEnRoot<Personalidad>();
				List<ParteDelCuerpoHumano> preCorrerEn;
				List<RopaCubre> quitarEn;
				List<RopaPosicion> quitarEnPosition;
				string conjuntoACargar;
				List<ParteDelCuerpoHumano> postCorrerEn;
				StandardizedPatientJob.ConjuntoSegunExamen(examen, componentEnRoot2, componentEnRoot3, componentEnRoot4, out preCorrerEn, out quitarEn, out quitarEnPosition, out conjuntoACargar, out postCorrerEn);
				CS$<>8__locals1.loader = femChar.GetComponentEnRoot(true);
				yield return this.esperandoInstanciarExamenObjetosV2(examen);
				if (string.IsNullOrEmpty(conjuntoACargar))
				{
					CS$<>8__locals1.piezasaQuitarDeConjuntoActual = new List<string>();
					if (preCorrerEn != null && preCorrerEn.Count > 0)
					{
						preCorrerEn.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ForEach(delegate(RopaCubre c)
						{
							CS$<>8__locals1.loader.CantidadPiezasCubriendo(c, true, CS$<>8__locals1.piezasaQuitarDeConjuntoActual);
						});
					}
					if (quitarEn != null && quitarEn.Count > 0)
					{
						quitarEn.ForEach(delegate(RopaCubre c)
						{
							CS$<>8__locals1.loader.CantidadPiezasCubriendo(c, true, CS$<>8__locals1.piezasaQuitarDeConjuntoActual);
						});
					}
					if (quitarEnPosition != null && quitarEnPosition.Count > 0)
					{
						quitarEnPosition.ForEach(delegate(RopaPosicion c)
						{
							CS$<>8__locals1.loader.CantidadPiezas(c, true, CS$<>8__locals1.piezasaQuitarDeConjuntoActual);
						});
					}
					if (postCorrerEn != null && postCorrerEn.Count > 0)
					{
						postCorrerEn.Select((ParteDelCuerpoHumano p) => p.Parce()).Distinct<RopaCubre>().ForEach(delegate(RopaCubre c)
						{
							CS$<>8__locals1.loader.CantidadPiezasCubriendo(c, true, CS$<>8__locals1.piezasaQuitarDeConjuntoActual);
						});
					}
					CS$<>8__locals1.piezasaQuitarDeConjuntoActual = CS$<>8__locals1.piezasaQuitarDeConjuntoActual.Distinct<string>().ToList<string>();
					int num2;
					for (int i = 0; i < CS$<>8__locals1.piezasaQuitarDeConjuntoActual.Count; i = num2 + 1)
					{
						CS$<>8__locals1.loader.RemovePieza(CS$<>8__locals1.piezasaQuitarDeConjuntoActual[i], true, femChar);
						yield return null;
						num2 = i;
					}
					CameraFade.FadeInMain(0.75f);
				}
				else
				{
					MapaConjuntoDeRopa conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto(conjuntoACargar);
					yield return Singleton<ActividadesManager>.instance.SetOutfitAndWait(this.m_mainNonPlayerCharacterID, conjunto, true);
					CameraFade.FadeInMain(0.75f);
					if (postCorrerEn != null && postCorrerEn.Count > 0)
					{
						DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
						helper.Init(femChar, femChar);
						helper.Mover(this, postCorrerEn, true, false);
						while (helper.ejecutandose)
						{
							yield return null;
						}
						helper = null;
					}
				}
				this.m_esperandoNavaCamilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.WaitNavToCamillaRutine(examen, new FemaleAnimatedRecostarseIDs?(StandardizedPatientJob.GetDefaultPose(examen))), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
				CS$<>8__locals1 = null;
				femChar = null;
				preCorrerEn = null;
				quitarEn = null;
				quitarEnPosition = null;
				conjuntoACargar = null;
				postCorrerEn = null;
			}
			yield break;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00018F16 File Offset: 0x00017116
		private IEnumerator WaitRopaChangeRutine()
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoCambioDeRopa, true);
			yield return null;
			Character femChar = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter;
			string patientCambiadorGotoID = StandardizedPatientJob.GetPatientCambiadorGotoID(base.lvl);
			yield return base.NavToGOTORutineSlow(femChar, patientCambiadorGotoID, false, null, 1f, null, true);
			yield return AsyncSingleton<RopaParaAvatarUnificado>.TryIniciar();
			yield return AsyncSingleton<MaterialesParaRopa>.TryIniciar();
			yield return AsyncSingleton<ConjuntosDeRopa>.TryIniciar();
			ConsentToHero componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Arousal componentEnRoot2 = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Personalidad componentEnRoot3 = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			StandardizedPatientJob.Examen examen = (StandardizedPatientJob.Examen)this.m_LuaListener.examenID;
			List<ParteDelCuerpoHumano> list;
			List<RopaCubre> quitarEn;
			List<RopaPosicion> quitarEnPosition;
			string conjuntoACargar;
			List<ParteDelCuerpoHumano> postCorrerEn;
			StandardizedPatientJob.ConjuntoSegunExamen(examen, componentEnRoot, componentEnRoot2, componentEnRoot3, out list, out quitarEn, out quitarEnPosition, out conjuntoACargar, out postCorrerEn);
			if (list != null && list.Count > 0)
			{
				DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
				helper.Init(femChar, femChar);
				helper.Mover(this, list, true, false);
				while (helper.ejecutandose)
				{
					yield return null;
				}
				helper = null;
			}
			if (quitarEn != null && quitarEn.Count > 0)
			{
				DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
				helper.Init(femChar, femChar);
				helper.Quitar(this, quitarEn, true, false);
				while (helper.ejecutandose)
				{
					yield return null;
				}
				helper = null;
			}
			if (quitarEnPosition != null && quitarEnPosition.Count > 0)
			{
				DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
				helper.Init(femChar, femChar);
				helper.Quitar(this, quitarEnPosition, true, false);
				while (helper.ejecutandose)
				{
					yield return null;
				}
				helper = null;
			}
			CameraFade.FadeOutMain(0.75f);
			yield return new ManualCorrutina.TValleWaitForSeconds(1f);
			if (!string.IsNullOrEmpty(conjuntoACargar))
			{
				MapaConjuntoDeRopa conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto(conjuntoACargar);
				yield return Singleton<ActividadesManager>.instance.SetOutfitAndWait(this.m_mainNonPlayerCharacterID, conjunto, true);
			}
			yield return this.esperandoInstanciarExamenObjetosV2(examen);
			CameraFade.FadeInMain(0.75f);
			if (postCorrerEn != null && postCorrerEn.Count > 0)
			{
				DesvestirseInteractuandoConRopa helper = new DesvestirseInteractuandoConRopa();
				helper.Init(femChar, femChar);
				helper.Mover(this, postCorrerEn, true, false);
				while (helper.ejecutandose)
				{
					yield return null;
				}
				helper = null;
			}
			this.m_esperandoNavaCamilla = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.WaitNavToCamillaRutine(examen, new FemaleAnimatedRecostarseIDs?(StandardizedPatientJob.GetDefaultPose(examen))), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00018F25 File Offset: 0x00017125
		private IEnumerator WaitNavToCamillaRutine(StandardizedPatientJob.Examen examen, FemaleAnimatedRecostarseIDs? defaultPose)
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoRopaYCamilla, true);
			yield return null;
			if (defaultPose == null)
			{
				defaultPose = new FemaleAnimatedRecostarseIDs?(StandardizedPatientJob.GetDefaultPose(examen));
			}
			if (this.EsExamenGinecologico())
			{
				CamillaGineMedica componentInChildren = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.SillaGine").GetComponentInChildren<CamillaGineMedica>();
				componentInChildren.StartOperation();
				componentInChildren.lampPosW = 0f;
			}
			FemaleAnimController animControlle = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Character mainNonPlayerCharacter = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter;
			string patientCamillaGotoID = StandardizedPatientJob.GetPatientCamillaGotoID(base.lvl);
			yield return base.NavToGOTORutineSlow(mainNonPlayerCharacter, patientCamillaGotoID, false, () => animControlle.currentRecostableOnRange != null, 1f, null, true);
			animControlle.RecostarseEnCurrentRecostable(defaultPose.Value);
			this.m_esperandoExaminen = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update3, this, this.WaitExaminandoRutine(examen), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00018F42 File Offset: 0x00017142
		private IEnumerator WaitExaminandoRutine(StandardizedPatientJob.Examen examen)
		{
			this.SetEstado(StandardizedPatientJob.GetEstado(examen), true);
			yield return null;
			this.GenerarBuffDeContratoDeExamen(examen);
			this.GenerarObjetives(examen);
			yield return this.esperandoInstanciarExamenObjetosV2(examen);
			FemaleAnimController animControlle = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Coroutine controlSillaCorutina = null;
			if (this.EsExamenGinecologico())
			{
				controlSillaCorutina = base.StartCoroutine(this.controlDeSillaGinecologicaAuto(animControlle));
			}
			Coroutine controlDocLuz = base.StartCoroutine(this.controlDeLuzDocAuto());
			ReactorGeneralLookAt reactorLookAt = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			this.ValidadorDeCamillaAnimPoses(examen);
			reactorLookAt.duracionMirarMaleOjosMod = 10f;
			while (!this.m_LuaListener.diagnosticada)
			{
				yield return null;
			}
			reactorLookAt.duracionMirarMaleOjosMod = 1f;
			base.StopCoroutine(controlDocLuz);
			controlDocLuz = null;
			this.m_luzDeDoc.SetActive(true);
			this.UpdateObjetives(examen);
			this.m_LuaListener.ProcesarResetasFlags();
			if (this.m_LuaListener.recetasSinFlags.Count > 0)
			{
				if (this.m_LuaListener.recetaModo == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.inyectable)
				{
					yield return this.esperandoInyeccion(examen, this.m_LuaListener.recetasSinFlags);
				}
				else
				{
					RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo recetaModo = this.m_LuaListener.recetaModo;
				}
			}
			string text;
			string femDespachadaConverID;
			switch (this.m_LuaListener.diagnostico)
			{
			case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico.sana:
				text = "SP.DispatchStart";
				if (this.m_LuaListener.recetasSinFlags.Count == 0)
				{
					femDespachadaConverID = "SP.DispatchSaludable";
				}
				else
				{
					switch (this.m_LuaListener.recetaModo)
					{
					case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.None:
						femDespachadaConverID = "SP.DispatchSaludable";
						break;
					case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.oral:
						femDespachadaConverID = "SP.DispatchSaludableVitaminas";
						break;
					case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.inyectable:
						femDespachadaConverID = "SP.DispatchSaludableVitaminasInyected";
						break;
					default:
						throw new ArgumentOutOfRangeException(this.m_LuaListener.recetaModo.ToString());
					}
				}
				break;
			case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico.inconcluso:
				text = "SP.DispatchStart";
				femDespachadaConverID = "SP.DispatchDudoso";
				break;
			case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico.condicion:
			{
				if (this.m_LuaListener.recetasSinFlags.Count > 0 && !string.IsNullOrWhiteSpace(this.m_LuaListener.ComoCondicionMedicaID))
				{
					this.IntentarCurar(this.m_LuaListener.recetasSinFlags, examen, this.m_LuaListener.ComoCondicionMedicaID, out this.m_diagnosticoCorrecto, out this.m_tratamientoCorrecto);
				}
				text = "SP.DispatchStart";
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo recetaModo2 = this.m_LuaListener.recetaModo;
				if (recetaModo2 > RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.oral)
				{
					if (recetaModo2 != RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.inyectable)
					{
						throw new ArgumentOutOfRangeException(this.m_LuaListener.recetaModo.ToString());
					}
					femDespachadaConverID = "SP.DispatchCondicionInyected";
				}
				else
				{
					femDespachadaConverID = "SP.DispatchCondicion";
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(this.m_LuaListener.diagnostico.ToString());
			}
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string maleConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(text);
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, maleConversation))
			{
				yield return null;
			}
			if (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			if (this.EsExamenGinecologico())
			{
				if (!animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.sentarse))
				{
					animControlle.RecostarseEnCurrentRecostable(FemaleAnimatedRecostarseIDs.sentarse);
				}
			}
			else if (!animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.sentarseEnCamilla))
			{
				animControlle.RecostarseEnCurrentRecostable(FemaleAnimatedRecostarseIDs.sentarseEnCamilla);
			}
			if (controlSillaCorutina != null)
			{
				base.StopCoroutine(controlSillaCorutina);
			}
			controlSillaCorutina = null;
			string femConversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(femDespachadaConverID);
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, femConversation))
			{
				yield return null;
			}
			if (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00018F58 File Offset: 0x00017158
		private IEnumerator controlDeSillaGinecologicaAuto(FemaleAnimController animControlle)
		{
			this.m_sillaGineAlturaTarget = 1f;
			GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.SillaGine");
			CamillaGineMedica camillaGineMedica = @object.GetComponentInChildren<CamillaGineMedica>();
			WaitForSeconds w = new WaitForSeconds(0.5f);
			WaitForSeconds w2 = new WaitForSeconds(1.25f);
			for (;;)
			{
				yield return null;
				if (animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.sentarse))
				{
					yield return w;
					camillaGineMedica.alturaW = 0f;
					camillaGineMedica.lampPosW = 0f;
				}
				else if (animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.acostarseEnGine))
				{
					if (!this.m_flagUpdateSillaAlturaDeInmediato)
					{
						yield return w2;
					}
					camillaGineMedica.alturaW = this.m_sillaGineAlturaTarget;
					camillaGineMedica.lampPosW = 1f;
				}
				this.m_flagUpdateSillaAlturaDeInmediato = false;
			}
			yield break;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00018F6E File Offset: 0x0001716E
		private IEnumerator controlDeLuzDocAuto()
		{
			ManoAgarranteDeMaleChar[] agarrantes = base.mainPlayerCharacter.GetComponentsInChildren<ManoAgarranteDeMaleChar>();
			WaitForSeconds w = new WaitForSeconds(1.5f);
			for (;;)
			{
				yield return w;
				bool flag = false;
				for (int i = 0; i < agarrantes.Length; i++)
				{
					Toy componentInChildren = agarrantes[i].GetComponentInChildren<Toy>();
					Light componentInChildren2 = agarrantes[i].GetComponentInChildren<Light>();
					if (componentInChildren != null && componentInChildren2 != null && componentInChildren.isActiveAndEnabled && componentInChildren2.isActiveAndEnabled)
					{
						flag = true;
					}
				}
				if (this.m_luzDeDoc.activeSelf != !flag)
				{
					this.m_luzDeDoc.SetActive(!flag);
				}
			}
			yield break;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00018F7D File Offset: 0x0001717D
		private IEnumerator esperandoInstanciarExamenObjetosV2(StandardizedPatientJob.Examen examen)
		{
			if (this.m_yaInstancioObjetosDeExamen)
			{
				yield break;
			}
			string text = StandardizedPatientJob.GetMesaDeObjetosGoto(base.lvl);
			List<string> aInstanciarEnMesitaDeHerramientas = new List<string>();
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				goto IL_036A;
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Gel");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Gel");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.UltraSound");
				goto IL_036A;
			case StandardizedPatientJob.Examen.MammographicExamination:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Gel");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Gel");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.UltraSound");
				goto IL_036A;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				text = StandardizedPatientJob.GetMesaDeObjetosGotoInverted(base.lvl);
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Thermo");
				goto IL_036A;
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				text = StandardizedPatientJob.GetMesaDeObjetosGotoInverted(base.lvl);
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				goto IL_036A;
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				text = StandardizedPatientJob.GetMesaDeObjetosGotoInverted(base.lvl);
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				goto IL_036A;
			case StandardizedPatientJob.Examen.Anoscopy:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.BulbEnema");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Anoscope");
				goto IL_036A;
			case StandardizedPatientJob.Examen.VaginalWallInspection:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.SpeculumsSmall");
				goto IL_036A;
			case StandardizedPatientJob.Examen.Proctoscopy:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.BulbEnema");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Proctoscope");
				goto IL_036A;
			case StandardizedPatientJob.Examen.CervicalInspection:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Speculums");
				goto IL_036A;
			case StandardizedPatientJob.Examen.Rectoscopy:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.BulbEnema");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Rectoscope");
				goto IL_036A;
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.SpeculumsBig");
				goto IL_036A;
			case StandardizedPatientJob.Examen.VideoRectoscopy:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.BulbEnema");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.InternalUltraSound");
				goto IL_036A;
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.Lube");
				aInstanciarEnMesitaDeHerramientas.Add("Tvalle.SP.InternalUltraSound");
				goto IL_036A;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
			IL_036A:
			MesitaParaHerramientasConSlots mesita = StandardizedPatientJob.GetMesaDeObjetos(base.lvl);
			if (aInstanciarEnMesitaDeHerramientas.Count > 0)
			{
				GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener(text);
				if (((goTo != null) ? goTo.transform : null) == null)
				{
					Debug.LogError("can config mesita, goto not found");
				}
				else
				{
					mesita.transform.SetPositionAndRotation(goTo.transform.position, goTo.transform.rotation);
				}
			}
			int num;
			for (int i = 0; i < aInstanciarEnMesitaDeHerramientas.Count; i = num + 1)
			{
				string item = aInstanciarEnMesitaDeHerramientas[i];
				GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject(item);
				int nextSlotIndex = mesita.GetNextSlotIndex();
				Transform slot = mesita.GetSlot(nextSlotIndex);
				GameObject instance = Object.Instantiate<GameObject>(@object, slot.position, slot.rotation);
				mesita.SetSlot(nextSlotIndex, instance);
				yield return null;
				SceneManager.MoveGameObjectToScene(instance, base.gameObject.scene);
				yield return null;
				instance.GetComponentNotNull<HerramientasVuelveASuSlot>().SetSlot(slot);
				yield return null;
				yield return this.esperandoConfigurarObjetosInstanciad(examen, item, instance, slot);
				item = null;
				slot = null;
				instance = null;
				num = i;
			}
			this.m_yaInstancioObjetosDeExamen = true;
			yield break;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00018F93 File Offset: 0x00017193
		private IEnumerator esperandoConfigurarObjetosInstanciad(StandardizedPatientJob.Examen examen, string objetoID, GameObject instancia, Transform slot)
		{
			if (!(objetoID == "Tvalle.SP.UltraSound"))
			{
				if (objetoID == "Tvalle.SP.InternalUltraSound")
				{
					GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.UltraSoundTableGine");
					if (@object == null)
					{
						Debug.LogError("can config monitor, mesita not found");
					}
					else
					{
						GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("UltraSoundTableTargetGine_GoTo");
						if (((goTo != null) ? goTo.transform : null) == null)
						{
							Debug.LogError("can config monitor, goto not found");
						}
						else
						{
							@object.transform.SetPositionAndRotation(goTo.transform.position, goTo.transform.rotation);
							Transform transform = @object.transform.Find("MonitorPose");
							if (transform == null)
							{
								Debug.LogError("can config monitor, pose not found");
							}
							else
							{
								UltrasonidoTrasnVagCamera component = instancia.GetComponent<UltrasonidoTrasnVagCamera>();
								if (component == null || component.monitor == null)
								{
									Debug.LogError("can config monitor, monitor not found");
								}
								else
								{
									component.monitor.transform.SetPositionAndRotation(transform.position, transform.rotation);
								}
							}
						}
					}
				}
			}
			else
			{
				GameObject object2 = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.UltraSoundTable");
				if (object2 == null)
				{
					Debug.LogError("can config monitor, mesita not found");
				}
				else
				{
					GoToScenaManager.GoTo goTo2 = Singleton<GoToScenaManager>.instance.Obtener("UltraSoundTableTarget_GoTo");
					if (((goTo2 != null) ? goTo2.transform : null) == null)
					{
						Debug.LogError("can config monitor, goto not found");
					}
					else
					{
						object2.transform.SetPositionAndRotation(goTo2.transform.position, goTo2.transform.rotation);
						Transform transform2 = object2.transform.Find("MonitorPose");
						if (transform2 == null)
						{
							Debug.LogError("can config monitor, pose not found");
						}
						else
						{
							UltrasonidoTrasnVagCamera component2 = instancia.GetComponent<UltrasonidoTrasnVagCamera>();
							if (component2 == null || component2.monitor == null)
							{
								Debug.LogError("can config monitor, monitor not found");
							}
							else
							{
								component2.monitor.transform.SetPositionAndRotation(transform2.position, transform2.rotation);
							}
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00018FA9 File Offset: 0x000171A9
		private IEnumerator esperandoInyeccion(StandardizedPatientJob.Examen examen, List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> medicinas)
		{
			this.m_inyectando = true;
			this.UpdateObjetives(examen);
			FemaleAnimController animControlle = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			Character femChar = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter;
			string patientCamillaGotoID = StandardizedPatientJob.GetPatientCamillaGotoID(base.lvl);
			yield return base.NavToGOTORutineSlow(femChar, patientCamillaGotoID, false, () => animControlle.currentRecostableOnRange != null, 1f, null, false);
			bool esperarRecostarse = false;
			FemaleAnimatedRecostarseIDs esperandoPor = FemaleAnimatedRecostarseIDs.None;
			if (!this.EsExamenGinecologico())
			{
				if (!animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.acostarseBocaAbajoEnCamilla) && !animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.doggyEnCamilla))
				{
					esperandoPor = FemaleAnimatedRecostarseIDs.acostarseBocaAbajoEnCamilla;
					animControlle.RecostarseEnCurrentRecostable(esperandoPor);
					esperarRecostarse = true;
				}
			}
			else if (!animControlle.EstaRecostada(FemaleAnimatedRecostarseIDs.acostarseEnGine))
			{
				esperandoPor = FemaleAnimatedRecostarseIDs.acostarseEnGine;
				animControlle.RecostarseEnCurrentRecostable(esperandoPor);
				esperarRecostarse = true;
			}
			CameraFade.FadeOutMain(0.5f);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.5f);
			MesitaParaHerramientasConSlots mesaDeObjetos = StandardizedPatientJob.GetMesaDeObjetos(base.lvl);
			GameObject @object = InstantiatedSingleton<ColleccionDeObjetosSP>.instance.GetObject("Tvalle.SP.jeringa");
			Transform slot = mesaDeObjetos.GetSlot(@object);
			GameObject jeringaInstance = Object.Instantiate<GameObject>(@object, slot.position, slot.rotation);
			yield return null;
			SceneManager.MoveGameObjectToScene(jeringaInstance, base.gameObject.scene);
			yield return null;
			Jeringa jeringa = jeringaInstance.GetComponentInChildren<Jeringa>();
			jeringaInstance.GetComponentNotNull<HerramientasVuelveASuSlot>().SetSlot(slot);
			JeringaBuffCaster caster = jeringaInstance.GetComponentInChildren<JeringaBuffCaster>();
			yield return new ManualCorrutina.TValleWaitForSeconds(0.25f);
			CameraFade.FadeInMain(0.5f);
			if (esperarRecostarse)
			{
				float tiempoEsperando = 0f;
				while (tiempoEsperando < 10f && !animControlle.EstaRecostada(esperandoPor))
				{
					yield return null;
					tiempoEsperando += Time.deltaTime;
				}
			}
			DesvestirseInteractuandoConRopa helper = null;
			if (!this.EsExamenGinecologico())
			{
				helper = new DesvestirseInteractuandoConRopa();
				helper.Init(femChar, femChar);
				helper.Mover(this, new List<ParteDelCuerpoHumano> { ParteDelCuerpoHumano.nalgas }, true, false);
			}
			List<JeringaBuffCaster.BuffDataBase> list = new List<JeringaBuffCaster.BuffDataBase>();
			this.GetMedicinesBuffData(medicinas, list);
			using (List<JeringaBuffCaster.BuffDataBase>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					JeringaBuffCaster.BuffDataBase buffDataBase = enumerator.Current;
					caster.AddBuff(buffDataBase);
				}
				goto IL_03A6;
			}
			IL_038F:
			yield return null;
			IL_03A6:
			if (helper == null || !helper.ejecutandose)
			{
				GrabbablePropFireAction jeringafireAccion = jeringaInstance.GetComponentInChildren<GrabbablePropFireAction>();
				while (jeringafireAccion.fireActionWeight < 0.9f || jeringa.isPenetrating)
				{
					yield return null;
				}
				yield return new ManualCorrutina.TValleWaitForSeconds(1f);
				this.m_inyecto = true;
				this.m_inyectando = false;
				yield break;
			}
			goto IL_038F;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00018FC8 File Offset: 0x000171C8
		private void GetMedicinesBuffData(List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> medicinas, List<JeringaBuffCaster.BuffDataBase> result)
		{
			foreach (RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta spdiagnosticoReceta in medicinas)
			{
				if (spdiagnosticoReceta <= RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory)
				{
					if (spdiagnosticoReceta <= RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.quemadorasDeGrasa)
					{
						switch (spdiagnosticoReceta)
						{
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.None:
							continue;
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.sexHormones:
							result.Add(new JeringaBuffCaster.BuffDataForEmotionAdd(Emotion.arousal, 10f, new BuffMap.Duracion
							{
								days = 2
							}, new string[] { "SP", "Short" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.stressVitamines:
							result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.rage, 0.75f, new BuffMap.Duracion
							{
								days = 2
							}, new string[] { "SP", "Short" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.fear, 0.75f, new BuffMap.Duracion
							{
								days = 2
							}, new string[] { "SP", "Short" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.sexHormones | RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.stressVitamines:
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.sexHormones | RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.estrogenos:
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.stressVitamines | RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.estrogenos:
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.sexHormones | RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.stressVitamines | RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.estrogenos:
							break;
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.estrogenos:
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosSenosGeneral.Scaler_Seno_R, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosSenosGeneral.Scaler_Seno_L, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						case RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.hormonaCrecimiento:
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosNalgasGeneral.Scaler_Nalga_R, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosNalgasGeneral.Scaler_Nalga_L, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_PiernaSuperior_R, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_PiernaSuperior_L, 0, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_PiernaInferior_R, 0, 0.5f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_PiernaInferior_L, 0, 0.5f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_CanillaSuperior_R, 0, 0.25f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosLegs.Scaler_CanillaSuperior_L, 0, 0.25f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						default:
							if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.quemadorasDeGrasa)
							{
								result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosBodyGeneral.Morpher_BODY_fat, -1, -1f, new BuffMap.Duracion
								{
									days = 90
								}, new string[] { "SP", "Long" })
								{
									nombresPorID = "TValle.SP"
								});
								continue;
							}
							break;
						}
					}
					else
					{
						if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.aumentadorDeApetito)
						{
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosBodyGeneral.Morpher_BODY_fat, -1, 1f, new BuffMap.Duracion
							{
								days = 90
							}, new string[] { "SP", "Long" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						}
						if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic)
						{
							result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.pain, 0.5f, new BuffMap.Duracion
							{
								days = 2
							}, new string[] { "SP", "Short" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						}
						if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory)
						{
							result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosBodyGeneral.Morpher_BODY_fat, -1, 10f, new BuffMap.Duracion
							{
								days = 2
							}, new string[] { "SP", "Short" })
							{
								nombresPorID = "TValle.SP"
							});
							continue;
						}
					}
				}
				else if (spdiagnosticoReceta <= RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antispasmodic)
				{
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antibiotic)
					{
						result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.pain, 0.9f, new BuffMap.Duracion
						{
							days = 2
						}, new string[] { "SP", "Short" })
						{
							nombresPorID = "TValle.SP"
						});
						continue;
					}
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Laxative)
					{
						result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosBodyGeneral.Morpher_BODY_fat, -1, -5f, new BuffMap.Duracion
						{
							days = 2
						}, new string[] { "SP", "Short" })
						{
							nombresPorID = "TValle.SP"
						});
						continue;
					}
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antispasmodic)
					{
						result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.pain, 0.9f, new BuffMap.Duracion
						{
							days = 2
						}, new string[] { "SP", "Short" })
						{
							nombresPorID = "TValle.SP"
						});
						continue;
					}
				}
				else
				{
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antipyretic)
					{
						result.Add(new JeringaBuffCaster.BuffDataForEmotionGain(Emotion.pain, 0.9f, new BuffMap.Duracion
						{
							days = 2
						}, new string[] { "SP", "Short" })
						{
							nombresPorID = "TValle.SP"
						});
						continue;
					}
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Diuretic)
					{
						result.Add(new JeringaBuffCaster.BuffDataForAlteratorFemAppa(DiccionarioDeNombresDeAlteradoresFemeninosBodyGeneral.Morpher_BODY_fat, -1, -10f, new BuffMap.Duracion
						{
							days = 2
						}, new string[] { "SP", "Short" })
						{
							nombresPorID = "TValle.SP"
						});
						continue;
					}
					if (spdiagnosticoReceta == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Vasoconstrictor)
					{
						continue;
					}
				}
				throw new ArgumentOutOfRangeException(spdiagnosticoReceta.ToString());
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0001973C File Offset: 0x0001793C
		private void IntentarCurar(List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> suministradas, StandardizedPatientJob.Examen examen, string atacandoCondicionID, out bool pacienteTeniaCondicion, out bool pacienteTendraMejoriaConElTratamiento)
		{
			pacienteTeniaCondicion = false;
			pacienteTendraMejoriaConElTratamiento = false;
			float efectividadDeDrogasSeleccionadas = StandardizedPatientJob.GetEfectividadDeDrogasSeleccionadas(suministradas, atacandoCondicionID);
			BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.MedicalCondition", atacandoCondicionID);
			if (!componentEnRoot.eventos.Contains(text))
			{
				Debug.LogError("buff de condiciones medicas deberian existir en modelos");
				return;
			}
			BuffEvento buffEvento = componentEnRoot.eventos.Get(text);
			BuffOfMedicalConditionArg buffOfMedicalConditionArg = (BuffOfMedicalConditionArg)buffEvento.efectoArgumento;
			pacienteTeniaCondicion = buffOfMedicalConditionArg.EstaEnferma();
			pacienteTendraMejoriaConElTratamiento = efectividadDeDrogasSeleccionadas >= 0.5f;
			if (pacienteTendraMejoriaConElTratamiento)
			{
				float num = Mathf.InverseLerp(0.5f, 1f, efectividadDeDrogasSeleccionadas);
				if (buffEvento is DisplayableBuff)
				{
					(buffEvento as DisplayableBuff).ForceUpdateLocalizedText();
				}
				if (!buffOfMedicalConditionArg.IsFlaggedTratamientoComenzo())
				{
					buffOfMedicalConditionArg.FlagTratamientoComenzo(num, 1f);
				}
				else
				{
					buffOfMedicalConditionArg.ReforzarTratamiento(num);
				}
				if (buffOfMedicalConditionArg != null)
				{
					((IDisplayableArgumentoDeEfecto)buffOfMedicalConditionArg).flagUpdateNonLocalizedTextV2 = true;
				}
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00019815 File Offset: 0x00017A15
		private IEnumerator EsperandoRetirarsePorMaxEmocionNegativaRutine(Emotion emotion, StandardizedPatientJob.GamePlayEstadoEspecifico fromEstado)
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.autoDespachadoPorEmoNegativa, true);
			string text;
			switch (emotion)
			{
			case Emotion.rage:
				text = "SP.RagefullExam";
				break;
			case Emotion.pain:
				text = "SP.PainfullExam";
				break;
			case Emotion.fear:
				text = "SP.FearfullExam";
				break;
			default:
				throw new ArgumentOutOfRangeException(emotion.ToString());
			}
			ActividadesManager actividadesManager = Singleton<ActividadesManager>.instance;
			string conversation = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(text);
			while (DialogueManager.IsConversationActive || !actividadesManager.current.mainNonPlayerCharacter.TrySerConversarzado(actividadesManager.current.mainPlayerCharacter, conversation))
			{
				yield return null;
			}
			base.mainNonPlayerCharacter.GetComponent<FemaleAnimController>().animatedPoseID = FemaleAnimatedPoseIDs.None;
			yield return null;
			IInteraccionesDeCharacter componentInChildren = base.mainNonPlayerCharacter.GetComponentInChildren<IInteraccionesDeCharacter>();
			foreach (InteraccionDeCharacter interaccionDeCharacter in componentInChildren.interaccionesPrimariasBases)
			{
				if (interaccionDeCharacter.instancia.ejecutandose || interaccionDeCharacter.instancia.algunaEstaEjecutandose)
				{
					interaccionDeCharacter.instancia.Detener(false);
					yield return null;
				}
			}
			IEnumerator<InteraccionDeCharacter> enumerator = null;
			while (DialogueManager.IsConversationActive)
			{
				yield return null;
			}
			this.m_Retirar = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.RetirarRutine(), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			yield break;
			yield break;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001982B File Offset: 0x00017A2B
		protected override IEnumerator RetirarRutine()
		{
			this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.retirando, true);
			FemaleChar fem = base.mainNonPlayerCharacter.GetComponent<FemaleChar>();
			if (this.m_LuaListener.recetasSinFlags.Count > 0 && this.m_LuaListener.recetaModo == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo.oral)
			{
				float num = ((!string.IsNullOrWhiteSpace(this.m_LuaListener.ComoCondicionMedicaID)) ? 1f : 0.5f);
				List<JeringaBuffCaster.BuffDataBase> list = new List<JeringaBuffCaster.BuffDataBase>();
				this.GetMedicinesBuffData(this.m_LuaListener.recetasSinFlags, list);
				BuffDeCharacter componentEnRoot = base.mainNonPlayerCharacter.GetComponentEnRoot(false);
				foreach (JeringaBuffCaster.BuffDataBase buffDataBase in list)
				{
					buffDataBase.Apply(componentEnRoot, num, this);
				}
			}
			RegistroDeFuncionesDeTrabajosDeModelaje registroDeFuncionesDeTrabajosDeModelaje = CheckRegistroDeFunciones.TryGetRegistroDeFunciones<RegistroDeFuncionesDeTrabajosDeModelaje>();
			if (registroDeFuncionesDeTrabajosDeModelaje != null)
			{
				registroDeFuncionesDeTrabajosDeModelaje.BorrarAgreementDeTrato();
			}
			yield return null;
			CameraFade.FadeOutMain(1f);
			yield return new ManualCorrutina.TValleWaitForSeconds(1f);
			fem.gameObject.SetActive(false);
			yield return new ManualCorrutina.TValleWaitForSeconds(0.1f);
			CameraFade.FadeInMain(1f);
			yield return null;
			DialogueManager.Instance.StopConversation();
			AsyncSingleton<JobsManager>.instance.EndCurrentJob(null);
			yield break;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0001983C File Offset: 0x00017A3C
		protected override void StopAllGamePlayStates()
		{
			base.StopAllGamePlayStates();
			GlobalUpdater.Corrutina introduciendo = this.m_introduciendo;
			if (((introduciendo != null) ? new bool?(introduciendo.alive) : null).GetValueOrDefault())
			{
				this.m_introduciendo.Stop();
			}
			GlobalUpdater.Corrutina introduciendoNavegandoASilla = this.m_introduciendoNavegandoASilla;
			if (((introduciendoNavegandoASilla != null) ? new bool?(introduciendoNavegandoASilla.alive) : null).GetValueOrDefault())
			{
				this.m_introduciendoNavegandoASilla.Stop();
			}
			GlobalUpdater.Corrutina seleccionandoExam = this.m_seleccionandoExam;
			if (((seleccionandoExam != null) ? new bool?(seleccionandoExam.alive) : null).GetValueOrDefault())
			{
				this.m_seleccionandoExam.Stop();
			}
			GlobalUpdater.Corrutina esperandoSpyOr = this.m_esperandoSpyOr;
			if (((esperandoSpyOr != null) ? new bool?(esperandoSpyOr.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoSpyOr.Stop();
			}
			GlobalUpdater.Corrutina esperandoCambioDeRopa = this.m_esperandoCambioDeRopa;
			if (((esperandoCambioDeRopa != null) ? new bool?(esperandoCambioDeRopa.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoCambioDeRopa.Stop();
			}
			GlobalUpdater.Corrutina esperandoNavaCamilla = this.m_esperandoNavaCamilla;
			if (((esperandoNavaCamilla != null) ? new bool?(esperandoNavaCamilla.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoNavaCamilla.Stop();
			}
			GlobalUpdater.Corrutina esperandoExaminen = this.m_esperandoExaminen;
			if (((esperandoExaminen != null) ? new bool?(esperandoExaminen.alive) : null).GetValueOrDefault())
			{
				this.m_esperandoExaminen.Stop();
			}
			this.m_introduciendo = null;
			this.m_introduciendoNavegandoASilla = null;
			this.m_seleccionandoExam = null;
			this.m_esperandoSpyOr = null;
			this.m_esperandoCambioDeRopa = null;
			this.m_esperandoNavaCamilla = null;
			this.m_esperandoExaminen = null;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x000199EC File Offset: 0x00017BEC
		protected override void StopAllStates()
		{
			base.StopAllStates();
			GlobalUpdater.Corrutina despachadoPorEmoNegativa = this.m_despachadoPorEmoNegativa;
			if (((despachadoPorEmoNegativa != null) ? new bool?(despachadoPorEmoNegativa.alive) : null).GetValueOrDefault())
			{
				this.m_despachadoPorEmoNegativa.Stop();
			}
			this.m_despachadoPorEmoNegativa = null;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00019A3C File Offset: 0x00017C3C
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			if (DialogueManager.IsConversationActive)
			{
				return false;
			}
			switch (emotion)
			{
			case Emotion.disappointment:
			{
				ActividadesManager instance = Singleton<ActividadesManager>.instance;
				string conversationID = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID("SP.DecepfullExam");
				if (instance.current.mainNonPlayerCharacter.TrySerConversarzado(instance.current.mainPlayerCharacter, conversationID))
				{
					return true;
				}
				break;
			}
			case Emotion.rage:
			case Emotion.fear:
				break;
			case Emotion.pain:
				if (!this.m_inyectando)
				{
					JobsManager instance2 = AsyncSingleton<JobsManager>.instance;
					ICharactersSceneInteractionsArchived mainAndSecondaryArchivedInteractionsNotNull = instance2.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance2.current.mainPlayerCharacter, instance2.current.mainNonPlayerCharacter);
					float num = mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.anusBottom, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.anusWalls, InterationReceivedType.All, Emotion.pain, false);
					float num2 = mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.vagBottom, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.vagWalls, InterationReceivedType.All, Emotion.pain, false);
					float num3 = mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.pain, false);
					float num4 = mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.abdomen, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.waist, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.belly, InterationReceivedType.All, Emotion.pain, false) + mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.navel, InterationReceivedType.All, Emotion.pain, false);
					float num5 = mainAndSecondaryArchivedInteractionsNotNull.PeekDamagePercentageDone(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, Emotion.pain, false) - (num + num2 + num3 + num4);
					num -= this.m_lastDolorAnus;
					num2 -= this.m_lastDolorVag;
					num3 -= this.m_lastDolorBreast;
					num4 -= this.m_lastDolorBelly;
					num5 -= this.m_lastDolorGen;
					string text;
					if (num > num2 && num > num3 && num > num4 && num > num5)
					{
						text = "SP.PainfullExamAnus";
						this.m_lastDolorAnus += num;
					}
					else if (num2 > num && num2 > num3 && num2 > num4 && num2 > num5)
					{
						text = "SP.PainfullExamVag";
						this.m_lastDolorVag += num2;
					}
					else if (num3 > num && num3 > num2 && num3 > num4 && num3 > num5)
					{
						text = "SP.PainfullExamBreast";
						this.m_lastDolorBreast += num3;
					}
					else if (num4 > num && num4 > num2 && num4 > num3 && num4 > num5)
					{
						text = "SP.PainfullExamBelly";
						this.m_lastDolorBelly += num4;
					}
					else
					{
						text = "SP.PainfullExamGeneral";
						this.m_lastDolorGen += num5;
					}
					ActividadesManager instance3 = Singleton<ActividadesManager>.instance;
					string conversationID2 = AsyncSingleton<DialoguesForActivities>.instance.GetConversationID(text);
					if (instance3.current.mainNonPlayerCharacter.TrySerConversarzado(instance3.current.mainPlayerCharacter, conversationID2))
					{
						return true;
					}
				}
				break;
			default:
				return true;
			}
			StandardizedPatientJob.GamePlayEstadoEspecifico estadoEspecifico = this.m_estadoEspecifico;
			this.StopAllGamePlayStates();
			if (this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.despachando && this.m_estadoGeneral != StandardizedPatientJob.GamePlayEstadoGeneral.retirando && (this.m_despachadoPorEmoNegativa == null || !this.m_despachadoPorEmoNegativa.alive))
			{
				this.SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico.autoDespachadoPorEmoNegativa, true);
				this.m_despachadoPorEmoNegativa = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.EsperandoRetirarsePorMaxEmocionNegativaRutine(emotion, estadoEspecifico), new ManualCorrutina.OnEndedHandler(base.OnEndedRutine));
			}
			return this.m_estadoGeneral == StandardizedPatientJob.GamePlayEstadoGeneral.retirando;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00019D40 File Offset: 0x00017F40
		private void SetEstado(StandardizedPatientJob.GamePlayEstadoEspecifico estado, bool changeContract)
		{
			if (changeContract && estado != this.m_estadoEspecifico)
			{
				try
				{
				}
				catch (Exception)
				{
					throw;
				}
			}
			this.m_estadoEspecifico = estado;
			switch (estado)
			{
			case StandardizedPatientJob.GamePlayEstadoEspecifico.None:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.None;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.introduciendo:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.introduciendo;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.seleccionandoExamen:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.seleccionandoExamen;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoEspiar:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.esperandoRopaYCamilla;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoCambioDeRopa:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.esperandoRopaYCamilla:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.esperandoRopaYCamilla;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_general:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_AbdominalRadiographicExamination:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_ClinicalBreastExamination:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_MammographicExamination:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_RectalTemperatureMeasurement:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_DigitalRectalExamination:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_DigitalVaginalExamination:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Anoscopy:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VaginalWallInspection:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Proctoscopy:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_CervicalInspection:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Rectoscopy:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VaginalFornixInspection:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VideoRectoscopy:
			case StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VideoVaginoscopy:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.examinando;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.autoDespachadoPorEmoNegativa:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.autoDespachando;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.despachandoPorExmenFinalizado:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.despachando;
				break;
			case StandardizedPatientJob.GamePlayEstadoEspecifico.retirando:
				this.m_estadoGeneral = StandardizedPatientJob.GamePlayEstadoGeneral.retirando;
				break;
			default:
				throw new ArgumentOutOfRangeException(estado.ToString());
			}
			this.UpdateMenus();
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00019E48 File Offset: 0x00018048
		private static string CoversationIDSegunExam(StandardizedPatientJob.Examen examen)
		{
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
				return "SP.ExamenSelected.LVL0";
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				return "SP.ExamenSelected.LVL1.Belly";
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				return "SP.ExamenSelected.LVL1.Breast";
			case StandardizedPatientJob.Examen.MammographicExamination:
				return "SP.ExamenSelected.LVL2.Mammographic";
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				return "SP.ExamenSelected.LVL2.TemperatureMeasurement";
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				return "SP.ExamenSelected.LVL3.DigitalRectalExaminatio";
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				return "SP.ExamenSelected.LVL3.DigitalVaginalExamination";
			case StandardizedPatientJob.Examen.Anoscopy:
				return "SP.ExamenSelected.LVL4.Anoscopy";
			case StandardizedPatientJob.Examen.VaginalWallInspection:
				return "SP.ExamenSelected.LVL4.VaginalWallInspection";
			case StandardizedPatientJob.Examen.Proctoscopy:
				return "SP.ExamenSelected.LVL5.Proctoscopy";
			case StandardizedPatientJob.Examen.CervicalInspection:
				return "SP.ExamenSelected.LVL5.CervicalInspection";
			case StandardizedPatientJob.Examen.Rectoscopy:
				return "SP.ExamenSelected.LVL6.Rectoscopy";
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
				return "SP.ExamenSelected.LVL6.VaginalFornixInspection";
			case StandardizedPatientJob.Examen.VideoRectoscopy:
				return "SP.ExamenSelected.LVL7.VideoRectoscopy";
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				return "SP.ExamenSelected.LVL7.VideoVaginoscopy";
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00019F0C File Offset: 0x0001810C
		private static void ConjuntoSegunExamen(StandardizedPatientJob.Examen examen, ConsentToHero heroinaConsent, Arousal arousal, Personalidad personalidad, out List<ParteDelCuerpoHumano> preCorrerEn, out List<RopaCubre> quitarEn, out List<RopaPosicion> quitarEnPosition, out string conjuntoACargar, out List<ParteDelCuerpoHumano> postCorrerEn)
		{
			conjuntoACargar = null;
			preCorrerEn = null;
			quitarEnPosition = null;
			quitarEn = null;
			postCorrerEn = null;
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
				preCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.abdomen,
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pezones,
					ParteDelCuerpoHumano.hombros
				};
				quitarEnPosition = new List<RopaPosicion> { RopaPosicion.torzo };
				goto IL_01F7;
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				preCorrerEn = new List<ParteDelCuerpoHumano> { ParteDelCuerpoHumano.abdomen };
				postCorrerEn = new List<ParteDelCuerpoHumano> { ParteDelCuerpoHumano.vientre };
				goto IL_01F7;
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				preCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pezones
				};
				quitarEnPosition = new List<RopaPosicion> { RopaPosicion.torzo };
				goto IL_01F7;
			case StandardizedPatientJob.Examen.MammographicExamination:
				preCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.senos,
					ParteDelCuerpoHumano.pezones
				};
				quitarEnPosition = new List<RopaPosicion> { RopaPosicion.torzo };
				goto IL_01F7;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				postCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.vientreBajo,
					ParteDelCuerpoHumano.bocaInterno
				};
				goto IL_01F7;
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				postCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.vientreBajo
				};
				goto IL_01F7;
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				postCorrerEn = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.vientreBajo
				};
				goto IL_01F7;
			case StandardizedPatientJob.Examen.Anoscopy:
			case StandardizedPatientJob.Examen.VaginalWallInspection:
			case StandardizedPatientJob.Examen.Proctoscopy:
			case StandardizedPatientJob.Examen.CervicalInspection:
			case StandardizedPatientJob.Examen.Rectoscopy:
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
			case StandardizedPatientJob.Examen.VideoRectoscopy:
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				quitarEn = typeof(RopaCubre).GetEnumValoresLimpiosObject().Cast<RopaCubre>().ToList<RopaCubre>();
				conjuntoACargar = ((heroinaConsent.valorNoLimitado * (1f + arousal.value.mod) > 24f || personalidad.pervertido || personalidad.exhibicionista) ? "sp.toga" : "sp.gown");
				postCorrerEn = new List<ParteDelCuerpoHumano> { ParteDelCuerpoHumano.nalgas };
				goto IL_01F7;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
			IL_01F7:
			if (quitarEnPosition == null)
			{
				quitarEnPosition = new List<RopaPosicion>();
			}
			quitarEnPosition.Add(RopaPosicion.pies);
			if (quitarEn == null)
			{
				quitarEn = new List<RopaCubre>();
			}
			quitarEn.Add(RopaCubre.pies);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001A140 File Offset: 0x00018340
		private static StandardizedPatientJob.GamePlayEstadoEspecifico GetEstado(StandardizedPatientJob.Examen examen)
		{
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_general;
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_AbdominalRadiographicExamination;
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_ClinicalBreastExamination;
			case StandardizedPatientJob.Examen.MammographicExamination:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_MammographicExamination;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_RectalTemperatureMeasurement;
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_DigitalRectalExamination;
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_DigitalVaginalExamination;
			case StandardizedPatientJob.Examen.Anoscopy:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Anoscopy;
			case StandardizedPatientJob.Examen.VaginalWallInspection:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VaginalWallInspection;
			case StandardizedPatientJob.Examen.Proctoscopy:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Proctoscopy;
			case StandardizedPatientJob.Examen.CervicalInspection:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_CervicalInspection;
			case StandardizedPatientJob.Examen.Rectoscopy:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_Rectoscopy;
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VaginalFornixInspection;
			case StandardizedPatientJob.Examen.VideoRectoscopy:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VideoRectoscopy;
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				return StandardizedPatientJob.GamePlayEstadoEspecifico.examinando_VideoVaginoscopy;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001A1D4 File Offset: 0x000183D4
		private void GenerarGeneralExaObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.ExamBocaVisual", false, delegate
				{
					float num = currentInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.tongue, InterationReceivedType.lookAt, Emotion.All, false);
					float num2 = pastInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.tongue, InterationReceivedType.lookAt, Emotion.All, false);
					return num + num2 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(0, "tvalle.SPJob.ExamBreastVisual", false, delegate
				{
					float num3 = currentInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.nipples, InterationReceivedType.lookAt, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.nipples, InterationReceivedType.lookAt, Emotion.All, false);
					float num4 = currentInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.breasts, InterationReceivedType.lookAt, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.eyes, SensitiveBodyPart.breasts, InterationReceivedType.lookAt, Emotion.All, false);
					return num3 + num4 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				ISMAJobObjective ismajobObjective3 = base.CreateObjective(0, "tvalle.SPJob.ExamBellyTactil", false, delegate
				{
					float num5 = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.belly, InterationReceivedType.caress, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.belly, InterationReceivedType.caress, Emotion.All, false);
					float num6 = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.abdomen, InterationReceivedType.caress, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.abdomen, InterationReceivedType.caress, Emotion.All, false);
					float num7 = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.waist, InterationReceivedType.caress, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.waist, InterationReceivedType.caress, Emotion.All, false);
					float num8 = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.navel, InterationReceivedType.caress, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.navel, InterationReceivedType.caress, Emotion.All, false);
					return num5 + num6 + num7 + num8 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				this.AddObjective(ismajobObjective2, false, true);
				this.AddObjective(ismajobObjective3, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0001A308 File Offset: 0x00018508
		private void AbdominalRadiographicExaObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.ApplyGelBelly", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.belly, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.belly, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.abdomen, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.abdomen, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.waist, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.waist, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.navel, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.navel, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.ExamAbdominalRadiographic", false, delegate
				{
					float num5 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.belly, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.belly, InterationReceivedType.All, Emotion.All, false);
					float num6 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.abdomen, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.abdomen, InterationReceivedType.All, Emotion.All, false);
					float num7 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.waist, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.waist, InterationReceivedType.All, Emotion.All, false);
					float num8 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.navel, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.navel, InterationReceivedType.All, Emotion.All, false);
					return num5 + num6 + num7 + num8 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0001A418 File Offset: 0x00018618
		private void ClinicalBreastExaObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.ExamClinicalBreast", false, delegate
				{
					float num = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false);
					float num2 = currentInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false);
					float num3 = currentInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.hand, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false);
					float num4 = currentInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0001A500 File Offset: 0x00018700
		private void MammographicExaObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.MammographicGel", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false);
					return num + num2 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.ExamMammographic", false, delegate
				{
					float num3 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.breasts, InterationReceivedType.All, Emotion.All, false);
					float num4 = currentInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.tool, SensitiveBodyPart.nipples, InterationReceivedType.All, Emotion.All, false);
					return num3 + num4 > 1f;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0001A610 File Offset: 0x00018810
		private void TemperatureMeasurementExaObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.TemperatureMeasurement", false, delegate
				{
					float num = currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false);
					float num2 = currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.throat, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.throat, InterationReceivedType.propped, Emotion.All, false);
					return num + num2 > 2f;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001A6F8 File Offset: 0x000188F8
		private void DigitalRectalExaminatioObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.DigitalRectalLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.DigitalRectalExaminatio", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.anus, InterationReceivedType.fingering, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.anus, InterationReceivedType.fingering, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001A808 File Offset: 0x00018A08
		private void DigitalVaginalExaminationObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.DigitalVaginalLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.DigitalVaginalExamination", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.vag, InterationReceivedType.fingering, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.finger, SensitiveBodyPart.vag, InterationReceivedType.fingering, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001A918 File Offset: 0x00018B18
		private void AnoscopyExaminatioObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.AnoscopylLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				this.AddObjetivesEnema(currentInteractions, pastInteractions);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.Anoscopy", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001AA3C File Offset: 0x00018C3C
		private void VaginalWallInspectionExaminationObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.VaginalWallInspectionlLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.VaginalWallInspection", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001AB4C File Offset: 0x00018D4C
		private void ProctoscopyExaminatioObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.ProctoscopyLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				this.AddObjetivesEnema(currentInteractions, pastInteractions);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.Proctoscopy", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001AC70 File Offset: 0x00018E70
		private void CervicalInspectionExaminationObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.CervicalInspectionLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.CervicalInspection", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001AD80 File Offset: 0x00018F80
		private void RectoscopyExaminatioObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.RectoscopyLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				this.AddObjetivesEnema(currentInteractions, pastInteractions);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.Rectoscopy", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0001AEA4 File Offset: 0x000190A4
		private void VaginalFornixInspectionExaminationObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.VaginalFornixInspectionLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.VaginalFornixInspection", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0001AFB4 File Offset: 0x000191B4
		private void VideoRectoscopyExaminatioObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.VideoRectoscopyLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.anus, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.perineum, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.coccyx, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				this.AddObjetivesEnema(currentInteractions, pastInteractions);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.VideoRectoscopy", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.anus, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001B0D8 File Offset: 0x000192D8
		private void VideoVaginoscopyExaminationObjetives()
		{
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesRequired);
			this.m_jobManager.objectives.RemoveObjectives(this.m_actividadObjectivesOptional);
			this.m_actividadObjectivesRequired.Clear();
			this.m_actividadObjectivesOptional.Clear();
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ICharactersSceneInteractions currentInteractions = instance.interactions.GetTakingPlaceInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			ICharactersSceneInteractionsArchived pastInteractions = instance.interactions.GetMainAndSecondaryArchivedInteractionsNotNull(instance.current.mainPlayerCharacter, instance.current.mainNonPlayerCharacter);
			if (!this.m_LuaListener.diagnosticada)
			{
				ISMAJobObjective ismajobObjective = base.CreateObjective(base.lvl, "tvalle.SPJob.VideoVaginoscopyLube", false, delegate
				{
					int num = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vag, InterationReceivedType.All, Emotion.All, false);
					int num2 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.vaginalLipsOrBalls, InterationReceivedType.All, Emotion.All, false);
					int num3 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.crotch, InterationReceivedType.All, Emotion.All, false);
					int num4 = currentInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.lubricant, SensitiveBodyPart.clitorisOrPenis, InterationReceivedType.All, Emotion.All, false);
					return num + num2 + num3 + num4 >= 1;
				}, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective, false, true);
				ISMAJobObjective ismajobObjective2 = base.CreateObjective(base.lvl, "tvalle.SPJob.VideoVaginoscopy", false, () => currentInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) + pastInteractions.PeekDuration(TriggeringBodyPart.toy, SensitiveBodyPart.vag, InterationReceivedType.propped, Emotion.All, false) > 2f, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective2, false, true);
			}
			this.AddObjetivesDiagnostico();
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001B1E8 File Offset: 0x000193E8
		private void AddObjetivesEnema(ICharactersSceneInteractions currentInteractions, ICharactersSceneInteractionsArchived pastInteractions)
		{
			ISMAJobObjective ismajobObjective = base.CreateObjective(-1, "tvalle.SPJob.Enema", false, () => currentInteractions.PeekTimes(TriggeringBodyPart.water, SensitiveBodyPart.anus, InterationReceivedType.pouringIn, Emotion.All, false) + pastInteractions.PeekTimes(TriggeringBodyPart.water, SensitiveBodyPart.anus, InterationReceivedType.pouringIn, Emotion.All, false) >= 1, ObjectiveCheckFrequency.delayed, null);
			this.AddObjective(ismajobObjective, false, true);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001B230 File Offset: 0x00019430
		private void AddObjetivesDiagnostico()
		{
			JobsManager instance = AsyncSingleton<JobsManager>.instance;
			ISMAJobObjective ismajobObjective = base.CreateObjective(-1, "tvalle.SPJob.Sintomas", false, () => this.m_yaPreguntoSintomas, ObjectiveCheckFrequency.delayed, null);
			ISMAJobObjective ismajobObjective2 = base.CreateObjective(-1, "tvalle.SPJob.Diagnosticar", false, () => this.m_LuaListener.diagnosticada, ObjectiveCheckFrequency.delayed, null);
			ISMAJobObjective ismajobObjective3 = base.CreateObjective(-1, "tvalle.SPJob.DiagnosticarCorrectamente", false, () => this.m_diagnosticoCorrecto, ObjectiveCheckFrequency.delayed, null);
			ISMAJobObjective ismajobObjective4 = base.CreateObjective(-1, "tvalle.SPJob.CurarPaciente", false, () => this.m_tratamientoCorrecto, ObjectiveCheckFrequency.delayed, null);
			this.AddObjective(ismajobObjective, true, true);
			this.AddObjective(ismajobObjective2, true, true);
			this.AddObjective(ismajobObjective3, false, true);
			this.AddObjective(ismajobObjective4, false, true);
			if (this.m_inyectando)
			{
				ISMAJobObjective ismajobObjective5 = base.CreateObjective(-1, "tvalle.SPJob.Inyect", false, () => this.m_inyecto, ObjectiveCheckFrequency.delayed, null);
				this.AddObjective(ismajobObjective5, true, true);
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0001B306 File Offset: 0x00019506
		private void AddObjective(ISMAJobObjective objective, bool required, bool msgOnComplete)
		{
			this.m_jobManager.objectives.AddObjective(objective, required, msgOnComplete);
			if (required)
			{
				this.m_actividadObjectivesRequired.Add((GameplayObjectives.Objective)objective);
				return;
			}
			this.m_actividadObjectivesOptional.Add((GameplayObjectives.Objective)objective);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0001B341 File Offset: 0x00019541
		private void UpdateObjetives(StandardizedPatientJob.Examen examen)
		{
			this.GenerarObjetives(examen);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001B34C File Offset: 0x0001954C
		private void GenerarObjetives(StandardizedPatientJob.Examen examen)
		{
			switch (examen)
			{
			case StandardizedPatientJob.Examen.General:
				this.GenerarGeneralExaObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.AbdominalRadiographicExamination:
				this.AbdominalRadiographicExaObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.ClinicalBreastExamination:
				this.ClinicalBreastExaObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.MammographicExamination:
				this.MammographicExaObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.RectalTemperatureMeasurement:
				this.TemperatureMeasurementExaObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.DigitalRectalExamination:
				this.DigitalRectalExaminatioObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.DigitalVaginalExamination:
				this.DigitalVaginalExaminationObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.Anoscopy:
				this.AnoscopyExaminatioObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.VaginalWallInspection:
				this.VaginalWallInspectionExaminationObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.Proctoscopy:
				this.ProctoscopyExaminatioObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.CervicalInspection:
				this.CervicalInspectionExaminationObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.Rectoscopy:
				this.RectoscopyExaminatioObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.VaginalFornixInspection:
				this.VaginalFornixInspectionExaminationObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.VideoRectoscopy:
				this.VideoRectoscopyExaminatioObjetives();
				goto IL_00D6;
			case StandardizedPatientJob.Examen.VideoVaginoscopy:
				this.VideoVaginoscopyExaminationObjetives();
				goto IL_00D6;
			}
			throw new ArgumentOutOfRangeException(examen.ToString());
			IL_00D6:
			this.m_jobManager.objectives.RefreshUI();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001B72A File Offset: 0x0001992A
		[CompilerGenerated]
		internal static void <AddBuffToCharacter>g__UpdateBuffConfigHandler|99_3(DisplayableBuff buff, bool justInstantiated)
		{
			buff.showSmallMsgOnApplied = false;
			buff.showSmallMsgOnEnd = false;
			buff.showSmallMsgOnStart = false;
			buff.nombresPorID = "TValle.SP.Scene";
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0001B74C File Offset: 0x0001994C
		[CompilerGenerated]
		internal static void <AddBuffToCharacter>g__UpdateArgumentDataHandler|99_0(BuffOnEmocionGainArg argument, bool justInstantiated)
		{
			argument.emo = Emotion.disappointment;
			argument.gainMod = 0.001f;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0001B760 File Offset: 0x00019960
		[CompilerGenerated]
		internal static void <AddBuffToCharacter>g__UpdateBuffConfigHandler|99_1(DisplayableBuff buff, bool justInstantiated)
		{
			buff.showSmallMsgOnApplied = false;
			buff.showSmallMsgOnEnd = false;
			buff.showSmallMsgOnStart = false;
			buff.nombresPorID = "TValle.SP.Scene";
		}

		// Token: 0x04000237 RID: 567
		[SerializeField]
		private bool m_yaPreguntoSintomas;

		// Token: 0x04000238 RID: 568
		[Obsolete("", true)]
		private bool m_yaDiagnostico;

		// Token: 0x04000239 RID: 569
		[SerializeField]
		private float m_doctorLvl;

		// Token: 0x0400023A RID: 570
		[SerializeField]
		private GameObject m_luzDeDoc;

		// Token: 0x0400023B RID: 571
		[SerializeField]
		private float m_sillaGineAlturaTarget = 1f;

		// Token: 0x0400023C RID: 572
		[SerializeField]
		private bool m_flagUpdateSillaAlturaDeInmediato;

		// Token: 0x0400023D RID: 573
		private CoolDown m_SillaControlCoolDown = new CoolDown();

		// Token: 0x0400023E RID: 574
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraAmigdalitis = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antibiotic,
				0.5f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.3f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.2f
			}
		};

		// Token: 0x0400023F RID: 575
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraConstipation = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> { 
		{
			RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Laxative,
			1f
		} };

		// Token: 0x04000240 RID: 576
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraIrritableBowelSyndrome = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antispasmodic,
				0.75f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.25f
			}
		};

		// Token: 0x04000241 RID: 577
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraFibrocysticBreast = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.75f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.25f
			}
		};

		// Token: 0x04000242 RID: 578
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraFiebre = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antipyretic,
				0.8f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antibiotic,
				0.2f
			}
		};

		// Token: 0x04000243 RID: 579
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraMucosalVascularProminence = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.4f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.3f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Vasoconstrictor,
				0.3f
			}
		};

		// Token: 0x04000244 RID: 580
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraVaginalCyst = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.5f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.5f
			}
		};

		// Token: 0x04000245 RID: 581
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraHemorrhoids = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.4f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.2f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Vasoconstrictor,
				0.4f
			}
		};

		// Token: 0x04000246 RID: 582
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraNabothianCysts = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.5f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.25f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Antibiotic,
				0.25f
			}
		};

		// Token: 0x04000247 RID: 583
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraMucosalIrregularity = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.3f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.7f
			}
		};

		// Token: 0x04000248 RID: 584
		private static readonly Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float> efectividadContraPosteriorFornixSwelling = new Dictionary<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta, float>
		{
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.AntiInflammatory,
				0.5f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic,
				0.25f
			},
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Diuretic,
				0.25f
			}
		};

		// Token: 0x04000249 RID: 585
		private const string buffIDEmoGains = "Tvalle.Buff.EmotionGainMod";

		// Token: 0x0400024A RID: 586
		private const string buffIDPlacerSec = "SP.Exam.Placer";

		// Token: 0x0400024B RID: 587
		private const string buffIDDecepSec = "SP.Exam.Placer";

		// Token: 0x0400024C RID: 588
		[SerializeField]
		[ReadOnlyUI]
		private bool isDebugging;

		// Token: 0x0400024D RID: 589
		[SerializeField]
		[ReadOnlyUI]
		private StandardizedPatientDebugger m_Debugger;

		// Token: 0x0400024E RID: 590
		[SerializeField]
		private StandardizedPatientJob.GamePlayEstadoGeneral m_estadoGeneral;

		// Token: 0x0400024F RID: 591
		[SerializeField]
		private StandardizedPatientJob.GamePlayEstadoEspecifico m_estadoEspecifico;

		// Token: 0x04000250 RID: 592
		[SerializeField]
		[ReadOnlyUI]
		private int m_selectedExamId;

		// Token: 0x04000251 RID: 593
		[SerializeField]
		[ReadOnlyUI]
		private bool m_inyectando;

		// Token: 0x04000252 RID: 594
		[SerializeField]
		[ReadOnlyUI]
		private bool m_inyecto;

		// Token: 0x04000253 RID: 595
		[SerializeField]
		[ReadOnlyUI]
		private bool m_diagnosticoCorrecto;

		// Token: 0x04000254 RID: 596
		[SerializeField]
		[ReadOnlyUI]
		private bool m_tratamientoCorrecto;

		// Token: 0x04000255 RID: 597
		[SerializeField]
		[ReadOnlyUI]
		private StandardizedPatientJob.LuaListener m_LuaListener;

		// Token: 0x04000256 RID: 598
		[SerializeField]
		[ReadOnlyUI]
		private bool m_yaInstancioObjetosDeExamen;

		// Token: 0x04000257 RID: 599
		private GlobalUpdater.Corrutina m_introduciendo;

		// Token: 0x04000258 RID: 600
		private GlobalUpdater.Corrutina m_introduciendoNavegandoASilla;

		// Token: 0x04000259 RID: 601
		private GlobalUpdater.Corrutina m_seleccionandoExam;

		// Token: 0x0400025A RID: 602
		private GlobalUpdater.Corrutina m_esperandoSpyOr;

		// Token: 0x0400025B RID: 603
		private GlobalUpdater.Corrutina m_esperandoCambioDeRopa;

		// Token: 0x0400025C RID: 604
		private GlobalUpdater.Corrutina m_esperandoNavaCamilla;

		// Token: 0x0400025D RID: 605
		private GlobalUpdater.Corrutina m_esperandoExaminen;

		// Token: 0x0400025E RID: 606
		private GlobalUpdater.Corrutina m_despachadoPorEmoNegativa;

		// Token: 0x0400025F RID: 607
		[NonSerialized]
		private float m_lastDolorAnus;

		// Token: 0x04000260 RID: 608
		[NonSerialized]
		private float m_lastDolorVag;

		// Token: 0x04000261 RID: 609
		[NonSerialized]
		private float m_lastDolorBreast;

		// Token: 0x04000262 RID: 610
		[NonSerialized]
		private float m_lastDolorBelly;

		// Token: 0x04000263 RID: 611
		[NonSerialized]
		private float m_lastDolorGen;

		// Token: 0x04000264 RID: 612
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesRequired = new List<GameplayObjectives.Objective>();

		// Token: 0x04000265 RID: 613
		[SerializeField]
		private List<GameplayObjectives.Objective> m_actividadObjectivesOptional = new List<GameplayObjectives.Objective>();

		// Token: 0x020001C5 RID: 453
		private class LuaListener : RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner
		{
			// Token: 0x17000240 RID: 576
			// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00046FA0 File Offset: 0x000451A0
			public bool? quiereEspiar
			{
				get
				{
					switch (this.m_quiereEspiar)
					{
					case -1:
						return null;
					case 0:
						return new bool?(false);
					case 1:
						return new bool?(true);
					default:
						throw new ArgumentOutOfRangeException(this.m_quiereEspiar.ToString());
					}
				}
			}

			// Token: 0x06000E3F RID: 3647 RVA: 0x00046FF2 File Offset: 0x000451F2
			public void EnvioACamilla(RegistroDeFuncionesDeTrabajosDeModelaje sender)
			{
				this.envioACamilla = true;
			}

			// Token: 0x06000E40 RID: 3648 RVA: 0x00046FFB File Offset: 0x000451FB
			public void SeleccionoEspionaje(bool quiereEspiar, RegistroDeFuncionesDeTrabajosDeModelaje sender)
			{
				this.m_quiereEspiar = (quiereEspiar ? 1 : 0);
			}

			// Token: 0x06000E41 RID: 3649 RVA: 0x0004700A File Offset: 0x0004520A
			public void SeleccionoExamen(int examenID, RegistroDeFuncionesDeTrabajosDeModelaje sender)
			{
				this.seleccionoExamen = true;
				this.examenID = examenID;
			}

			// Token: 0x06000E42 RID: 3650 RVA: 0x0004701A File Offset: 0x0004521A
			public void HizoDiagnostico(RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico diagnostico, string ComoCondicionMedicaID, RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo recetaModo, RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta recetas, RegistroDeFuncionesDeTrabajosDeModelaje sender)
			{
				this.diagnosticada = true;
				if (diagnostico == RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico.inconcluso)
				{
					recetas |= RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.Analgesic;
				}
				this.diagnostico = diagnostico;
				this.ComoCondicionMedicaID = ComoCondicionMedicaID;
				this.recetaModo = recetaModo;
				this.recetas = recetas;
			}

			// Token: 0x06000E43 RID: 3651 RVA: 0x0004704B File Offset: 0x0004524B
			public void ProcesarResetasFlags()
			{
				this.recetasSinFlags = new List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta>();
				StandardizedPatientJob.LuaListener.CheckAndAdd(this.recetas, this.recetasSinFlags);
			}

			// Token: 0x06000E44 RID: 3652 RVA: 0x0004706C File Offset: 0x0004526C
			private static void CheckAndAdd(RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta recetasFlags, List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> recetasSinFlags)
			{
				foreach (object obj in typeof(RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta).GetEnumValoresLimpiosObject())
				{
					RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta spdiagnosticoReceta = (RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta)obj;
					if (recetasFlags.HasFlag(spdiagnosticoReceta))
					{
						recetasSinFlags.Add(spdiagnosticoReceta);
					}
				}
			}

			// Token: 0x0400083F RID: 2111
			public bool seleccionoExamen;

			// Token: 0x04000840 RID: 2112
			[SerializeField]
			private int m_quiereEspiar = -1;

			// Token: 0x04000841 RID: 2113
			public bool envioACamilla;

			// Token: 0x04000842 RID: 2114
			public bool diagnosticada;

			// Token: 0x04000843 RID: 2115
			public RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico diagnostico;

			// Token: 0x04000844 RID: 2116
			public string ComoCondicionMedicaID;

			// Token: 0x04000845 RID: 2117
			public RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo recetaModo;

			// Token: 0x04000846 RID: 2118
			public RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta recetas;

			// Token: 0x04000847 RID: 2119
			public List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta> recetasSinFlags = new List<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta>();

			// Token: 0x04000848 RID: 2120
			public int examenID;
		}

		// Token: 0x020001C6 RID: 454
		public enum GamePlayEstadoEspecifico
		{
			// Token: 0x0400084A RID: 2122
			None,
			// Token: 0x0400084B RID: 2123
			introduciendo,
			// Token: 0x0400084C RID: 2124
			seleccionandoExamen,
			// Token: 0x0400084D RID: 2125
			esperandoEspiar,
			// Token: 0x0400084E RID: 2126
			esperandoCambioDeRopa,
			// Token: 0x0400084F RID: 2127
			esperandoRopaYCamilla,
			// Token: 0x04000850 RID: 2128
			examinando_general,
			// Token: 0x04000851 RID: 2129
			examinando_AbdominalRadiographicExamination,
			// Token: 0x04000852 RID: 2130
			examinando_ClinicalBreastExamination,
			// Token: 0x04000853 RID: 2131
			examinando_MammographicExamination,
			// Token: 0x04000854 RID: 2132
			examinando_RectalTemperatureMeasurement,
			// Token: 0x04000855 RID: 2133
			examinando_DigitalRectalExamination,
			// Token: 0x04000856 RID: 2134
			examinando_DigitalVaginalExamination,
			// Token: 0x04000857 RID: 2135
			examinando_Anoscopy,
			// Token: 0x04000858 RID: 2136
			examinando_VaginalWallInspection,
			// Token: 0x04000859 RID: 2137
			examinando_Proctoscopy,
			// Token: 0x0400085A RID: 2138
			examinando_CervicalInspection,
			// Token: 0x0400085B RID: 2139
			examinando_Rectoscopy,
			// Token: 0x0400085C RID: 2140
			examinando_VaginalFornixInspection,
			// Token: 0x0400085D RID: 2141
			examinando_VideoRectoscopy,
			// Token: 0x0400085E RID: 2142
			examinando_VideoVaginoscopy,
			// Token: 0x0400085F RID: 2143
			autoDespachadoPorEmoNegativa,
			// Token: 0x04000860 RID: 2144
			despachandoPorExmenFinalizado,
			// Token: 0x04000861 RID: 2145
			retirando
		}

		// Token: 0x020001C7 RID: 455
		public enum Examen
		{
			// Token: 0x04000863 RID: 2147
			General,
			// Token: 0x04000864 RID: 2148
			AbdominalRadiographicExamination,
			// Token: 0x04000865 RID: 2149
			ClinicalBreastExamination,
			// Token: 0x04000866 RID: 2150
			MammographicExamination = 4,
			// Token: 0x04000867 RID: 2151
			RectalTemperatureMeasurement,
			// Token: 0x04000868 RID: 2152
			DigitalRectalExamination,
			// Token: 0x04000869 RID: 2153
			DigitalVaginalExamination,
			// Token: 0x0400086A RID: 2154
			Anoscopy,
			// Token: 0x0400086B RID: 2155
			VaginalWallInspection,
			// Token: 0x0400086C RID: 2156
			Proctoscopy,
			// Token: 0x0400086D RID: 2157
			CervicalInspection,
			// Token: 0x0400086E RID: 2158
			Rectoscopy,
			// Token: 0x0400086F RID: 2159
			VaginalFornixInspection,
			// Token: 0x04000870 RID: 2160
			VideoRectoscopy,
			// Token: 0x04000871 RID: 2161
			VideoVaginoscopy
		}

		// Token: 0x020001C8 RID: 456
		public enum GamePlayEstadoGeneral
		{
			// Token: 0x04000873 RID: 2163
			None,
			// Token: 0x04000874 RID: 2164
			introduciendo,
			// Token: 0x04000875 RID: 2165
			seleccionandoExamen,
			// Token: 0x04000876 RID: 2166
			esperandoRopaYCamilla,
			// Token: 0x04000877 RID: 2167
			examinando,
			// Token: 0x04000878 RID: 2168
			autoDespachando,
			// Token: 0x04000879 RID: 2169
			despachando,
			// Token: 0x0400087A RID: 2170
			retirando
		}
	}
}

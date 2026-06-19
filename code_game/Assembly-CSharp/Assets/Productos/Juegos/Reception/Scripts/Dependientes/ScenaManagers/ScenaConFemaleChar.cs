using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.ReductoresEnMaxValue.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.CustomPoses;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BE RID: 190
	public class ScenaConFemaleChar : ScenaCharacteresManager
	{
		// Token: 0x06000451 RID: 1105 RVA: 0x0001554A File Offset: 0x0001374A
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x00015551 File Offset: 0x00013751
		public FemaleChar currentFemaleCharacter
		{
			get
			{
				return this.femaleCharacterEnScena;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0001555C File Offset: 0x0001375C
		public bool currentFemalePuedeConversar
		{
			get
			{
				for (int i = 0; i < this.m_femaleCharacterPuedeConversarDelegados.Count; i++)
				{
					if (!this.m_femaleCharacterPuedeConversarDelegados[i].puedeConversar)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x00015595 File Offset: 0x00013795
		public ModificableDeBool puedeConversarModificable
		{
			get
			{
				return this.femaleCharacterPuedeConversar.puedeConversarModificable;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x000155A2 File Offset: 0x000137A2
		public Personalidad currentFemaleCharacterPersonalidad
		{
			get
			{
				return this.femaleCharacterPersonalidad;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000155AA File Offset: 0x000137AA
		public MemoriaDeCharacterGeneralTemporal currentFemaleCharacterMemoriaTemporal
		{
			get
			{
				return this.femaleCharacterMemoriaTemporal;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x000155B2 File Offset: 0x000137B2
		public MemoriaDeCharacterGeneralPermanente currentFemaleCharacterMemoriaPermanente
		{
			get
			{
				return this.femaleCharacterMemoriaPermanente;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x000155BA File Offset: 0x000137BA
		public AlteradoresDeAparienciaFemenina currentFemaleCharacterAlteradoresApariencia
		{
			get
			{
				return this.femaleCharacterAlteradoresApariencia;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x000155C2 File Offset: 0x000137C2
		public AlteradoresDePersonalidadFemenina currentFemaleCharacterAlteradoresPersonalidad
		{
			get
			{
				return this.femaleCharacterAlteradoresPersonalidad;
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0600045A RID: 1114 RVA: 0x000155CC File Offset: 0x000137CC
		// (remove) Token: 0x0600045B RID: 1115 RVA: 0x00015604 File Offset: 0x00013804
		public event Action<FemaleChar, ScenaConFemaleChar> onScenaAndFemaleCharacterLoaded;

		// Token: 0x0600045C RID: 1116 RVA: 0x00015639 File Offset: 0x00013839
		protected override void OnGameOverPorMax(Emocion emo)
		{
			GameOverPanel instance = Singleton<GameOverPanel>.instance;
			if (instance == null)
			{
				return;
			}
			instance.ChangeState(true);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0001564C File Offset: 0x0001384C
		protected sealed override void Onload(LoadSceneMode loadSceneMode)
		{
			if (this.femaleCharacterPrefab == null)
			{
				throw new ArgumentNullException("femaleCharacterPrefab", "femaleCharacterPrefab null reference.");
			}
			this.LoadCharacter();
			this.AddConversaciones();
			Transform childNotNull = this.femaleCharacterEnScena.transform.GetChildNotNull("ScenaManagersLogic", true);
			this.OnScenaAndFemaleCharacterLoaded(loadSceneMode, this.femaleCharacterEnScena, childNotNull);
			Action<FemaleChar, ScenaConFemaleChar> action = this.onScenaAndFemaleCharacterLoaded;
			if (action == null)
			{
				return;
			}
			action(this.femaleCharacterEnScena, this);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000156BF File Offset: 0x000138BF
		protected virtual void OnScenaAndFemaleCharacterLoaded(LoadSceneMode loadSceneMode, FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000156C1 File Offset: 0x000138C1
		protected override void OnUnload()
		{
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000156C4 File Offset: 0x000138C4
		protected void LoadCharacter()
		{
			try
			{
				if (this.femaleCharacterEnScena == null || this.femaleCharacterEnScena.isBinded)
				{
					if (this.femaleCharacterEnScena != null)
					{
						Object.Destroy(this.femaleCharacterEnScena.gameObject);
					}
					this.femaleCharacterEnScena = Object.Instantiate<FemaleChar>(this.femaleCharacterPrefab, base.transform, false);
					this.femaleCharacterEnScena.transform.SetParent(null);
				}
				Transform childNotNull = this.femaleCharacterEnScena.transform.GetChildNotNull("ScenaManagersLogic", true);
				this.femaleCharacterPuedeConversar = childNotNull.GetComponentNotNull<CharacterPuedeConversar>();
				this.femaleCharacterPersonalidad = this.femaleCharacterEnScena.GetComponentInChildren<Personalidad>();
				this.femaleCharacterMemoriaTemporal = this.femaleCharacterEnScena.GetComponentInChildren<MemoriaDeCharacterGeneralTemporal>();
				this.femaleCharacterMemoriaPermanente = this.femaleCharacterEnScena.GetComponentInChildren<MemoriaDeCharacterGeneralPermanente>();
				this.femaleCharacterAlteradoresApariencia = this.femaleCharacterEnScena.GetComponentInChildren<AlteradoresDeAparienciaFemenina>();
				this.femaleCharacterAlteradoresPersonalidad = this.femaleCharacterEnScena.GetComponentInChildren<AlteradoresDePersonalidadFemenina>();
				if (!this.femaleCharacterPersonalidad.isStared)
				{
					this.femaleCharacterPersonalidad.stared += this.OnFemalePersonalidadCargada;
				}
				else
				{
					this.OnFemalePersonalidadCargada(this.femaleCharacterPersonalidad);
				}
				Transform boneTransform = this.femaleCharacterEnScena.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
				if (this.m_opcionesDeInteraccionDeInterface.donaPrefab != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_opcionesDeInteraccionDeInterface.donaPrefab, this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, this.femaleCharacterEnScena.transform);
					ActivadorDeTHSDona componentInChildren = gameObject.GetComponentInChildren<ActivadorDeTHSDona>();
					BaseFolowTransform componentInChildren2 = gameObject.GetComponentInChildren<BaseFolowTransform>();
					componentInChildren2.transform.SetPositionAndRotation(boneTransform.position, boneTransform.rotation);
					if (componentInChildren2.isStared)
					{
						componentInChildren2.ResetOffsets();
					}
					else
					{
						componentInChildren2.ManualStart();
					}
					for (int i = 0; i < this.m_opcionesDeInteraccionDeInterface.opcionesPrefabs.Count; i++)
					{
						Object.Instantiate(this.m_opcionesDeInteraccionDeInterface.opcionesPrefabs[i], this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, componentInChildren.ownOpciones.transform);
					}
				}
				if (this.m_NoReducirMaxEmocionValueHastaSalirDeConversacion.activar)
				{
					ReductorDeEmocionValueEnMaxEmocionValue[] componentsInChildren = this.femaleCharacterEnScena.GetComponentsInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].GetComponentNotNull<BlockearReduccionDeEmocionMaxValueEnConversacion>();
					}
				}
				if (this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.activar)
				{
					foreach (ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable in this.femaleCharacterEnScena.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>())
					{
						if (!this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable.direccionDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarTipos.Contains(calculadorDeEstimuloClasificable.tipoDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnConversacion.ignorarReacciones.Contains(calculadorDeEstimuloClasificable.reaccion))
						{
							CalculoDeEstimuloEnFrame calculoDeEstimuloEnFrame = calculadorDeEstimuloClasificable as CalculoDeEstimuloEnFrame;
							if (calculoDeEstimuloEnFrame != null)
							{
								calculoDeEstimuloEnFrame.GetComponentNotNull<BlockearActualizacionDeCalculoDeEstimuloEnConversacion>();
								calculoDeEstimuloEnFrame.UpdateCheckers();
							}
						}
					}
				}
				if (this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.activar)
				{
					ICalculadorDeEstimuloClasificable[] array = this.femaleCharacterEnScena.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>();
					int j = 0;
					while (j < array.Length)
					{
						ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable2 = array[j];
						if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.invertido)
						{
							if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) && !this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo))
							{
								if (!this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
								{
									goto IL_03C2;
								}
							}
						}
						else if (this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) || this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo) || this.m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
						{
							goto IL_03C2;
						}
						IL_03EE:
						j++;
						continue;
						IL_03C2:
						CalculoDeEstimuloEnFrame calculoDeEstimuloEnFrame2 = calculadorDeEstimuloClasificable2 as CalculoDeEstimuloEnFrame;
						if (calculoDeEstimuloEnFrame2 != null)
						{
							if (calculoDeEstimuloEnFrame2.tipoDeEstimulo == TipoDeEstimulo.visual)
							{
								calculoDeEstimuloEnFrame2.GetComponentNotNull<BlockearActualizacionDeCalculoDeEstimuloEnEditarPose>();
							}
							calculoDeEstimuloEnFrame2.UpdateCheckers();
							goto IL_03EE;
						}
						goto IL_03EE;
					}
				}
				foreach (GameObject gameObject2 in this.m_extraObjectsPrefabs)
				{
					Object.Instantiate<GameObject>(gameObject2, this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, childNotNull).SetActive(true);
				}
			}
			finally
			{
				this.femaleCharacterEnScena.GetComponentsInChildren<ICharacterPuedeConversar>(this.m_femaleCharacterPuedeConversarDelegados);
				if (!this.m_femaleCharacterPuedeConversarDelegados.Contains(this.femaleCharacterPuedeConversar))
				{
					this.m_femaleCharacterPuedeConversarDelegados.Add(this.femaleCharacterPuedeConversar);
				}
				this.OnCharacterLoaded();
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00015B9C File Offset: 0x00013D9C
		protected void AddConversaciones()
		{
			Animator bodyAnimator = this.femaleCharacterEnScena.bodyAnimator;
			Transform boneTransform = this.femaleCharacterEnScena.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			if (this.configDeConversaciones.loadConversaciones)
			{
				foreach (ConversationTrigger conversationTrigger in this.m_conversaciones)
				{
					base.InstantiateConversationTrigger(conversationTrigger, boneTransform.position, bodyAnimator.transform.rotation, this.femaleCharacterEnScena.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
				}
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00015C50 File Offset: 0x00013E50
		protected void OnFemalePersonalidadCargada(object sender)
		{
			if (this.m_Overrides.personalidadRasgos.activar)
			{
				if (!this.femaleCharacterPersonalidad.mapaSonClones)
				{
					Debug.LogError("No se puede dar Override a personalidades q no son clones.");
				}
				else if (Application.isEditor || Debug.isDebugBuild)
				{
					this.femaleCharacterPersonalidad.currentPersonalidad.personalidad.rasgos = this.m_Overrides.personalidadRasgos;
				}
				else
				{
					Debug.LogError("-desactivar Overrides personalidadBasica");
				}
			}
			if (this.m_Overrides.traits.activar)
			{
				if (!this.femaleCharacterPersonalidad.mapaSonClones)
				{
					Debug.LogError("No se puede dar Override a personalidades q no son clones.");
					return;
				}
				if (Application.isEditor || Debug.isDebugBuild)
				{
					using (List<ScenaConFemaleChar.Overrides.Traits.TraitPar>.Enumerator enumerator = this.m_Overrides.traits.items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ScenaConFemaleChar.Overrides.Traits.TraitPar traitPar = enumerator.Current;
							this.femaleCharacterPersonalidad.SetTraitScore(traitPar.trait, traitPar.score);
						}
						return;
					}
				}
				Debug.LogError("-desactivar Overrides personalidadBasica");
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00015D68 File Offset: 0x00013F68
		protected virtual void OnCharacterLoaded()
		{
		}

		// Token: 0x040001EA RID: 490
		[Header("-> Scena Con Female Characteres Manager <-")]
		public ScenaConFemaleChar.ConfigDeConversaciones configDeConversaciones = new ScenaConFemaleChar.ConfigDeConversaciones();

		// Token: 0x040001EB RID: 491
		[SerializeField]
		private FemaleChar femaleCharacterPrefab;

		// Token: 0x040001EC RID: 492
		[SerializeField]
		private FemaleChar femaleCharacterEnScena;

		// Token: 0x040001ED RID: 493
		[SerializeField]
		[ReadOnlyUI]
		private CharacterPuedeConversar femaleCharacterPuedeConversar;

		// Token: 0x040001EE RID: 494
		[SerializeField]
		private List<ConversationTrigger> m_conversaciones = new List<ConversationTrigger>();

		// Token: 0x040001EF RID: 495
		[SerializeField]
		private ScenaConFemaleChar.OpcionesDeDona m_opcionesDeInteraccionDeInterface = new ScenaConFemaleChar.OpcionesDeDona();

		// Token: 0x040001F0 RID: 496
		[SerializeField]
		private ScenaConFemaleChar.LimitarEmocionesEnConversacion m_LimitarEmocionesEnConversacion = new ScenaConFemaleChar.LimitarEmocionesEnConversacion();

		// Token: 0x040001F1 RID: 497
		[SerializeField]
		private ScenaConFemaleChar.NoReducirMaxEmocionValueHastaSalirDeConversacion m_NoReducirMaxEmocionValueHastaSalirDeConversacion = new ScenaConFemaleChar.NoReducirMaxEmocionValueHastaSalirDeConversacion();

		// Token: 0x040001F2 RID: 498
		[Tooltip("la razon por la q hay glitches es q algunas penticiones o forzamients se ejecutan justo despues de la conversacion y otros en medio de esta, por eso hay q ignorarlos")]
		[SerializeField]
		private ScenaConFemaleChar.DeshabilitarCalculadoresDeEstimulosEnConversacion m_DeshabilitarCalculadoresDeEstimulosEnConversacion = new ScenaConFemaleChar.DeshabilitarCalculadoresDeEstimulosEnConversacion();

		// Token: 0x040001F3 RID: 499
		[Tooltip("si esta editando pose, es mejor des activar algunos AI")]
		[SerializeField]
		private ScenaConFemaleChar.DeshabilitarCalculadoresDeEstimulosEnEdicionPose m_DeshabilitarCalculadoresDeEstimulosEnEdicionPose = new ScenaConFemaleChar.DeshabilitarCalculadoresDeEstimulosEnEdicionPose();

		// Token: 0x040001F4 RID: 500
		[Header("Overrides")]
		[SerializeField]
		private ScenaConFemaleChar.Overrides m_Overrides = new ScenaConFemaleChar.Overrides();

		// Token: 0x040001F5 RID: 501
		[Header("Extra Objects")]
		[SerializeField]
		private List<GameObject> m_extraObjectsPrefabs = new List<GameObject>();

		// Token: 0x040001F6 RID: 502
		private List<ICharacterPuedeConversar> m_femaleCharacterPuedeConversarDelegados = new List<ICharacterPuedeConversar>();

		// Token: 0x040001F7 RID: 503
		[NonSerialized]
		private Personalidad femaleCharacterPersonalidad;

		// Token: 0x040001F8 RID: 504
		[NonSerialized]
		private MemoriaDeCharacterGeneralTemporal femaleCharacterMemoriaTemporal;

		// Token: 0x040001F9 RID: 505
		[NonSerialized]
		private MemoriaDeCharacterGeneralPermanente femaleCharacterMemoriaPermanente;

		// Token: 0x040001FA RID: 506
		[NonSerialized]
		private AlteradoresDeAparienciaFemenina femaleCharacterAlteradoresApariencia;

		// Token: 0x040001FB RID: 507
		[NonSerialized]
		private AlteradoresDePersonalidadFemenina femaleCharacterAlteradoresPersonalidad;

		// Token: 0x0200011E RID: 286
		[Serializable]
		public class OpcionesDeDona
		{
			// Token: 0x040003B7 RID: 951
			public GameObject donaPrefab;

			// Token: 0x040003B8 RID: 952
			public List<Object> opcionesPrefabs = new List<Object>();
		}

		// Token: 0x0200011F RID: 287
		[Serializable]
		public class ConfigDeConversaciones
		{
			// Token: 0x040003B9 RID: 953
			public bool loadConversaciones;
		}

		// Token: 0x02000120 RID: 288
		[Serializable]
		public class LimitarEmocionesEnConversacion
		{
		}

		// Token: 0x02000121 RID: 289
		[Serializable]
		public class NoReducirMaxEmocionValueHastaSalirDeConversacion
		{
			// Token: 0x040003BA RID: 954
			public bool activar = true;
		}

		// Token: 0x02000122 RID: 290
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnConversacion
		{
			// Token: 0x040003BB RID: 955
			public bool activar = true;

			// Token: 0x040003BC RID: 956
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x040003BD RID: 957
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x040003BE RID: 958
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x02000123 RID: 291
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnEdicionPose
		{
			// Token: 0x040003BF RID: 959
			public bool activar = true;

			// Token: 0x040003C0 RID: 960
			[Tooltip("en lugar de ignorar, lo que hace es que solo se aplican a los establecidos")]
			public bool invertido;

			// Token: 0x040003C1 RID: 961
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x040003C2 RID: 962
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x040003C3 RID: 963
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x02000124 RID: 292
		[Serializable]
		public class Overrides
		{
			// Token: 0x040003C4 RID: 964
			public ScenaConFemaleChar.Overrides.PersonalidadRasgos personalidadRasgos = new ScenaConFemaleChar.Overrides.PersonalidadRasgos();

			// Token: 0x040003C5 RID: 965
			public ScenaConFemaleChar.Overrides.Traits traits = new ScenaConFemaleChar.Overrides.Traits();

			// Token: 0x0200013B RID: 315
			[Serializable]
			public class PersonalidadRasgos : PersonalidadDinamica
			{
				// Token: 0x040003EB RID: 1003
				[Header("Activacion Override")]
				public bool activar;
			}

			// Token: 0x0200013C RID: 316
			[Serializable]
			public class Traits
			{
				// Token: 0x040003EC RID: 1004
				[Header("Activacion Override")]
				public bool activar;

				// Token: 0x040003ED RID: 1005
				public List<ScenaConFemaleChar.Overrides.Traits.TraitPar> items = new List<ScenaConFemaleChar.Overrides.Traits.TraitPar>();

				// Token: 0x0200013D RID: 317
				[Serializable]
				public struct TraitPar
				{
					// Token: 0x040003EE RID: 1006
					public TraitHumano trait;

					// Token: 0x040003EF RID: 1007
					public HumanTraitScore score;
				}
			}
		}
	}
}

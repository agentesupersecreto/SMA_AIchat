using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos;
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
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Miscellaneous;
using InterfaceFields;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000110 RID: 272
	public abstract class ActividadConMaleAndFemaleCharacter : TValleActividadSavedWithinTheScene
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x000377F7 File Offset: 0x000359F7
		public FemaleChar currentFemaleCharacter
		{
			get
			{
				return this.femaleCharacterEnScena;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000377FF File Offset: 0x000359FF
		public MaleChar currentMaleCharacter
		{
			get
			{
				return this.m_maleCharacter;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x00037807 File Offset: 0x00035A07
		public ICharacterConversador currentFemaleCharacterConversador
		{
			get
			{
				return this.m_ICharacterConversador;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0003780F File Offset: 0x00035A0F
		public ModificableDeBool puedeConversarModificable
		{
			get
			{
				return this.femaleCharacterPuedeConversar.puedeConversarModificable;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0003781C File Offset: 0x00035A1C
		public Personalidad currentFemaleCharacterPersonalidad
		{
			get
			{
				return this.femaleCharacterPersonalidad;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00037824 File Offset: 0x00035A24
		public MemoriaDeCharacterGeneralTemporal currentFemaleCharacterMemoriaTemporal
		{
			get
			{
				return this.femaleCharacterMemoriaTemporal;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x0003782C File Offset: 0x00035A2C
		public MemoriaDeCharacterGeneralPermanente currentFemaleCharacterMemoriaPermanente
		{
			get
			{
				return this.femaleCharacterMemoriaPermanente;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00037834 File Offset: 0x00035A34
		public AlteradoresDeAparienciaFemenina currentFemaleCharacterAlteradoresApariencia
		{
			get
			{
				return this.femaleCharacterAlteradoresApariencia;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x0003783C File Offset: 0x00035A3C
		public AlteradoresDePersonalidadFemenina currentFemaleCharacterAlteradoresPersonalidad
		{
			get
			{
				return this.femaleCharacterAlteradoresPersonalidad;
			}
		}

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x0600095A RID: 2394 RVA: 0x00037844 File Offset: 0x00035A44
		// (remove) Token: 0x0600095B RID: 2395 RVA: 0x0003787C File Offset: 0x00035A7C
		public event Action<FemaleChar, ActividadConMaleAndFemaleCharacter> onScenaAndFemaleCharacterLoaded;

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000378B1 File Offset: 0x00035AB1
		public sealed override Character mainPlayerCharacter
		{
			get
			{
				return this.m_maleCharacter;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600095D RID: 2397 RVA: 0x000378B9 File Offset: 0x00035AB9
		public sealed override Character mainNonPlayerCharacter
		{
			get
			{
				return this.femaleCharacterEnScena;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600095E RID: 2398
		protected abstract bool generateFemaleRopa { get; }

		// Token: 0x0600095F RID: 2399 RVA: 0x000378C1 File Offset: 0x00035AC1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ActividadConMaleAndFemaleCharacterConfigAndData = base.GetComponentInChildren<ActividadConMaleAndFemaleCharacterConfigAndData>();
			if (this.m_ActividadConMaleAndFemaleCharacterConfigAndData == null)
			{
				throw new ArgumentNullException("m_ActividadConMaleAndFemaleCharacterConfigAndData", "m_ActividadConMaleAndFemaleCharacterConfigAndData null reference.");
			}
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000378F3 File Offset: 0x00035AF3
		protected override IEnumerator OnStart()
		{
			base.gameObject.AddComponent<CheckRegistroDeFuncionesDeTrabajosDeModelaje>();
			if (CurrentMainCharacter<CurrentMainChar, MainChar>.current.character == null)
			{
				yield return this.InstantiateMaleCharacter(delegate(MaleChar c)
				{
					this.m_maleCharacter = c;
				});
			}
			else
			{
				this.m_maleCharacter = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character as MaleChar;
				Transform transform = Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo").transform;
				Transform transform2 = Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo").transform;
				if (ExtendedMonoBehaviour.AlmostEqual(this.m_maleCharacter.rootBoneTransform.position, transform2.position, 0.1f))
				{
					this.m_maleCharacter.SetPositionAndRotation(transform);
				}
			}
			if (this.m_maleCharacter == null)
			{
				throw new ArgumentNullException("m_maleCharacter", "m_maleCharacter null reference.");
			}
			this.OnMainPlayerChanged(this.m_maleCharacter, null);
			if (CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character == null)
			{
				yield return this.InstantiateFemaleCharacter(delegate(FemaleChar c)
				{
					this.femaleCharacterEnScena = c;
				});
			}
			else
			{
				this.femaleCharacterEnScena = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character as FemaleChar;
			}
			if (this.femaleCharacterEnScena == null)
			{
				throw new ArgumentNullException("femaleCharacterEnScena", "femaleCharacterEnScena null reference.");
			}
			this.OnMainNonPlayerChanged(this.femaleCharacterEnScena, null);
			this.LoadCharacter();
			Transform childNotNull = this.femaleCharacterEnScena.transform.GetChildNotNull("ScenaManagersLogic", true);
			this.OnScenaAndFemaleCharacterLoaded(this.femaleCharacterEnScena, childNotNull);
			Action<FemaleChar, ActividadConMaleAndFemaleCharacter> action = this.onScenaAndFemaleCharacterLoaded;
			if (action != null)
			{
				action(this.femaleCharacterEnScena, this);
			}
			IRopaDeCharacterAdmin admin = this.femaleCharacterEnScena.GetComponentInChildren<IRopaDeCharacterAdmin>();
			if (this.generateFemaleRopa)
			{
				if (!admin.estaGenerando && admin.manager.loadedConjunto == null)
				{
					admin.onGenerated += this.Admin_onGenerated;
					yield return null;
					float num = 1f - this.femaleCharacterPersonalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
					float exhibicionismoPorPersonalidad = this.femaleCharacterPersonalidad.exhibicionismoPorPersonalidad;
					float perverticidadPorPersonalidad = this.femaleCharacterPersonalidad.perverticidadPorPersonalidad;
					float num2 = num * 0.7f + exhibicionismoPorPersonalidad * 0.2f + perverticidadPorPersonalidad * 0.1f;
					ItemQuality itemQuality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(4f, 11f, num2));
					base.StartCoroutine(admin.Generar(itemQuality, 33f, null));
				}
			}
			else
			{
				admin.manager.conjuntoLoaded += this.Manager_conjuntoLoaded;
			}
			yield break;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00037902 File Offset: 0x00035B02
		private void Manager_conjuntoLoaded(IRopaManager obj)
		{
			obj.conjuntoLoaded -= this.Manager_conjuntoLoaded;
			this.currentFemaleCharacterMemoriaTemporal.RegistrarInitialOutfitWasLoaded();
			this.EscribirFemaleRopaToMemory(obj.loadedConjunto);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0003792D File Offset: 0x00035B2D
		private void Admin_onGenerated(IRopaDeCharacterAdmin obj)
		{
			obj.onGenerated -= this.Admin_onGenerated;
			this.currentFemaleCharacterMemoriaTemporal.RegistrarInitialOutfitWasLoaded();
			this.EscribirFemaleRopaToMemory(obj.manager.loadedConjunto);
		}

		// Token: 0x06000963 RID: 2403
		protected abstract void EscribirFemaleRopaToMemory(IConjuntoDeRopa loadedConjunto);

		// Token: 0x06000964 RID: 2404 RVA: 0x00037960 File Offset: 0x00035B60
		protected void LoadCharacter()
		{
			try
			{
				Transform childNotNull = this.femaleCharacterEnScena.transform.GetChildNotNull("ScenaManagersLogic", true);
				this.femaleCharacterPuedeConversar = childNotNull.GetComponentNotNull<CharacterPuedeConversar>();
				this.m_ICharacterConversador = this.femaleCharacterEnScena.GetComponentInChildren<ICharacterConversador>();
				this.m_ICharacterConversador.UpdateDelegados();
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
				ActividadConMaleAndFemaleCharacter.OpcionesDeDona opcionesDeInteraccionDeInterface = this.m_ActividadConMaleAndFemaleCharacterConfigAndData.opcionesDeInteraccionDeInterface;
				if (opcionesDeInteraccionDeInterface.donaPrefab != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(opcionesDeInteraccionDeInterface.donaPrefab, this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, this.femaleCharacterEnScena.transform);
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
					for (int i = 0; i < opcionesDeInteraccionDeInterface.opcionesPrefabsV2.Count; i++)
					{
						Object.Instantiate(opcionesDeInteraccionDeInterface.opcionesPrefabsV2[i], this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, componentInChildren.ownOpciones.transform);
					}
				}
				if (this.m_ActividadConMaleAndFemaleCharacterConfigAndData.noReducirMaxEmocionValueHastaSalirDeConversacion.activar)
				{
					ReductorDeEmocionValueEnMaxEmocionValue[] componentsInChildren = this.femaleCharacterEnScena.GetComponentsInChildren<ReductorDeEmocionValueEnMaxEmocionValue>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].GetComponentNotNull<BlockearReduccionDeEmocionMaxValueEnConversacion>();
					}
				}
				ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnConversacion deshabilitarCalculadoresDeEstimulosEnConversacion = this.m_ActividadConMaleAndFemaleCharacterConfigAndData.deshabilitarCalculadoresDeEstimulosEnConversacion;
				if (deshabilitarCalculadoresDeEstimulosEnConversacion.activar)
				{
					foreach (ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable in this.femaleCharacterEnScena.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>())
					{
						if (!deshabilitarCalculadoresDeEstimulosEnConversacion.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable.direccionDeEstimulo) && !deshabilitarCalculadoresDeEstimulosEnConversacion.ignorarTipos.Contains(calculadorDeEstimuloClasificable.tipoDeEstimulo) && !deshabilitarCalculadoresDeEstimulosEnConversacion.ignorarReacciones.Contains(calculadorDeEstimuloClasificable.reaccion))
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
				ActividadConMaleAndFemaleCharacter.DeshabilitarCalculadoresDeEstimulosEnEdicionPose deshabilitarCalculadoresDeEstimulosEnEdicionPose = this.m_ActividadConMaleAndFemaleCharacterConfigAndData.deshabilitarCalculadoresDeEstimulosEnEdicionPose;
				if (deshabilitarCalculadoresDeEstimulosEnEdicionPose.activar)
				{
					ICalculadorDeEstimuloClasificable[] array = this.femaleCharacterEnScena.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>();
					int j = 0;
					while (j < array.Length)
					{
						ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable2 = array[j];
						if (!deshabilitarCalculadoresDeEstimulosEnEdicionPose.invertido)
						{
							if (!deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) && !deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo))
							{
								if (!deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
								{
									goto IL_0362;
								}
							}
						}
						else if (deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarDirecciones.Contains(calculadorDeEstimuloClasificable2.direccionDeEstimulo) || deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarTipos.Contains(calculadorDeEstimuloClasificable2.tipoDeEstimulo) || deshabilitarCalculadoresDeEstimulosEnEdicionPose.ignorarReacciones.Contains(calculadorDeEstimuloClasificable2.reaccion))
						{
							goto IL_0362;
						}
						IL_038E:
						j++;
						continue;
						IL_0362:
						CalculoDeEstimuloEnFrame calculoDeEstimuloEnFrame2 = calculadorDeEstimuloClasificable2 as CalculoDeEstimuloEnFrame;
						if (calculoDeEstimuloEnFrame2 != null)
						{
							if (calculoDeEstimuloEnFrame2.tipoDeEstimulo == TipoDeEstimulo.visual)
							{
								calculoDeEstimuloEnFrame2.GetComponentNotNull<BlockearActualizacionDeCalculoDeEstimuloEnEditarPose>();
							}
							calculoDeEstimuloEnFrame2.UpdateCheckers();
							goto IL_038E;
						}
						goto IL_038E;
					}
				}
				foreach (GameObject gameObject2 in this.m_ActividadConMaleAndFemaleCharacterConfigAndData.extraObjectsPrefabs)
				{
					Object.Instantiate<GameObject>(gameObject2, this.femaleCharacterEnScena.transform.position, this.femaleCharacterEnScena.transform.rotation, childNotNull).SetActive(true);
				}
			}
			finally
			{
				this.OnCharacterLoaded();
			}
		}

		// Token: 0x06000965 RID: 2405
		protected abstract IEnumerator InstantiateMaleCharacter(Action<MaleChar> result);

		// Token: 0x06000966 RID: 2406
		protected abstract IEnumerator InstantiateFemaleCharacter(Action<FemaleChar> result);

		// Token: 0x06000967 RID: 2407
		protected abstract void OnCharacterLoaded();

		// Token: 0x06000968 RID: 2408
		protected abstract void OnScenaAndFemaleCharacterLoaded(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x06000969 RID: 2409 RVA: 0x00037DA8 File Offset: 0x00035FA8
		protected void OnFemalePersonalidadCargada(object sender)
		{
			ActividadConMaleAndFemaleCharacter.Overrides overrides = this.m_ActividadConMaleAndFemaleCharacterConfigAndData.overrides;
			if (overrides.personalidadRasgos.activar)
			{
				if (!this.femaleCharacterPersonalidad.mapaSonClones)
				{
					Debug.LogError("No se puede dar Override a personalidades q no son clones.");
				}
				else if (Application.isEditor || Debug.isDebugBuild)
				{
					this.femaleCharacterPersonalidad.currentPersonalidad.personalidad.rasgos = overrides.personalidadRasgos;
				}
				else
				{
					Debug.LogError("-desactivar Overrides personalidadBasica");
				}
			}
			if (overrides.traits.activar)
			{
				if (!this.femaleCharacterPersonalidad.mapaSonClones)
				{
					Debug.LogError("No se puede dar Override a personalidades q no son clones.");
					return;
				}
				if (Application.isEditor || Debug.isDebugBuild)
				{
					using (List<ActividadConMaleAndFemaleCharacter.Overrides.Traits.TraitPar>.Enumerator enumerator = overrides.traits.items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ActividadConMaleAndFemaleCharacter.Overrides.Traits.TraitPar traitPar = enumerator.Current;
							this.femaleCharacterPersonalidad.SetTraitScore(traitPar.trait, traitPar.score);
						}
						return;
					}
				}
				Debug.LogError("-desactivar Overrides personalidadBasica");
			}
		}

		// Token: 0x0400052A RID: 1322
		[Header("-> Scena Con Female Characteres Manager <-")]
		[ReadOnlyUI]
		[SerializeField]
		private FemaleChar femaleCharacterEnScena;

		// Token: 0x0400052B RID: 1323
		[ReadOnlyUI]
		[SerializeField]
		private MaleChar m_maleCharacter;

		// Token: 0x0400052C RID: 1324
		[NonSerialized]
		private Personalidad femaleCharacterPersonalidad;

		// Token: 0x0400052D RID: 1325
		[NonSerialized]
		private MemoriaDeCharacterGeneralTemporal femaleCharacterMemoriaTemporal;

		// Token: 0x0400052E RID: 1326
		[NonSerialized]
		private MemoriaDeCharacterGeneralPermanente femaleCharacterMemoriaPermanente;

		// Token: 0x0400052F RID: 1327
		[NonSerialized]
		private AlteradoresDeAparienciaFemenina femaleCharacterAlteradoresApariencia;

		// Token: 0x04000530 RID: 1328
		[NonSerialized]
		private AlteradoresDePersonalidadFemenina femaleCharacterAlteradoresPersonalidad;

		// Token: 0x04000531 RID: 1329
		private ICharacterConversador m_ICharacterConversador;

		// Token: 0x04000532 RID: 1330
		[SerializeField]
		[ReadOnlyUI]
		private CharacterPuedeConversar femaleCharacterPuedeConversar;

		// Token: 0x04000533 RID: 1331
		[SerializeField]
		[ReadOnlyUI]
		private ActividadConMaleAndFemaleCharacterConfigAndData m_ActividadConMaleAndFemaleCharacterConfigAndData;

		// Token: 0x02000287 RID: 647
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnConversacion
		{
			// Token: 0x04000BD7 RID: 3031
			public bool activar = true;

			// Token: 0x04000BD8 RID: 3032
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x04000BD9 RID: 3033
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x04000BDA RID: 3034
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x02000288 RID: 648
		[Serializable]
		public class DeshabilitarCalculadoresDeEstimulosEnEdicionPose
		{
			// Token: 0x04000BDB RID: 3035
			public bool activar = true;

			// Token: 0x04000BDC RID: 3036
			[Tooltip("en lugar de ignorar, lo que hace es que solo se aplican a los establecidos")]
			public bool invertido;

			// Token: 0x04000BDD RID: 3037
			public List<DireccionDeEstimulo> ignorarDirecciones = new List<DireccionDeEstimulo>();

			// Token: 0x04000BDE RID: 3038
			public List<TipoDeEstimulo> ignorarTipos = new List<TipoDeEstimulo>();

			// Token: 0x04000BDF RID: 3039
			public List<ReaccionHumana> ignorarReacciones = new List<ReaccionHumana>();
		}

		// Token: 0x02000289 RID: 649
		[Serializable]
		public class NoReducirMaxEmocionValueHastaSalirDeConversacion
		{
			// Token: 0x04000BE0 RID: 3040
			public bool activar = true;
		}

		// Token: 0x0200028A RID: 650
		[Serializable]
		public class OpcionesDeDona
		{
			// Token: 0x04000BE1 RID: 3041
			public GameObject donaPrefab;

			// Token: 0x04000BE2 RID: 3042
			[Obsolete("", true)]
			[NonSerialized]
			public List<Object> opcionesPrefabs = new List<Object>();

			// Token: 0x04000BE3 RID: 3043
			[ConstraintType(typeof(IModeloDeTHSDonaProductorDeItemInfo))]
			public List<Object> opcionesPrefabsV2 = new List<Object>();

			// Token: 0x04000BE4 RID: 3044
			[ConstraintType(typeof(IModeloDeTHSDonaProductorDeItemInfo))]
			public List<Object> opcionesPrefabsEDITORTESTING = new List<Object>();
		}

		// Token: 0x0200028B RID: 651
		[Serializable]
		public class Overrides
		{
			// Token: 0x04000BE5 RID: 3045
			public ActividadConMaleAndFemaleCharacter.Overrides.PersonalidadRasgos personalidadRasgos = new ActividadConMaleAndFemaleCharacter.Overrides.PersonalidadRasgos();

			// Token: 0x04000BE6 RID: 3046
			public ActividadConMaleAndFemaleCharacter.Overrides.Traits traits = new ActividadConMaleAndFemaleCharacter.Overrides.Traits();

			// Token: 0x02000300 RID: 768
			[Serializable]
			public class PersonalidadRasgos : PersonalidadDinamica
			{
				// Token: 0x04000D73 RID: 3443
				[Header("Activacion Override")]
				public bool activar;
			}

			// Token: 0x02000301 RID: 769
			[Serializable]
			public class Traits
			{
				// Token: 0x04000D74 RID: 3444
				[Header("Activacion Override")]
				public bool activar;

				// Token: 0x04000D75 RID: 3445
				public List<ActividadConMaleAndFemaleCharacter.Overrides.Traits.TraitPar> items = new List<ActividadConMaleAndFemaleCharacter.Overrides.Traits.TraitPar>();

				// Token: 0x02000302 RID: 770
				[Serializable]
				public struct TraitPar
				{
					// Token: 0x04000D76 RID: 3446
					public TraitHumano trait;

					// Token: 0x04000D77 RID: 3447
					public HumanTraitScore score;
				}
			}
		}
	}
}

using System;
using System.Collections;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000112 RID: 274
	public abstract class ActividadConSoloFemaleCharacter : TValleActividadSavedWithinTheScene
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00037F08 File Offset: 0x00036108
		public FemaleChar currentFemaleCharacter
		{
			get
			{
				return this.femaleCharacterEnScena;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x00037F10 File Offset: 0x00036110
		public ICharacterConversador currentFemaleCharacterConversador
		{
			get
			{
				return this.m_ICharacterConversador;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x00037F18 File Offset: 0x00036118
		public ModificableDeBool puedeConversarModificable
		{
			get
			{
				return this.femaleCharacterPuedeConversar.puedeConversarModificable;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x00037F25 File Offset: 0x00036125
		public Personalidad currentFemaleCharacterPersonalidad
		{
			get
			{
				return this.femaleCharacterPersonalidad;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x00037F2D File Offset: 0x0003612D
		public MemoriaDeCharacterGeneralTemporal currentFemaleCharacterMemoriaTemporal
		{
			get
			{
				return this.femaleCharacterMemoriaTemporal;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x00037F35 File Offset: 0x00036135
		public MemoriaDeCharacterGeneralPermanente currentFemaleCharacterMemoriaPermanente
		{
			get
			{
				return this.femaleCharacterMemoriaPermanente;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x00037F3D File Offset: 0x0003613D
		public AlteradoresDeAparienciaFemenina currentFemaleCharacterAlteradoresApariencia
		{
			get
			{
				return this.femaleCharacterAlteradoresApariencia;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x00037F45 File Offset: 0x00036145
		public AlteradoresDePersonalidadFemenina currentFemaleCharacterAlteradoresPersonalidad
		{
			get
			{
				return this.femaleCharacterAlteradoresPersonalidad;
			}
		}

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x0600097C RID: 2428 RVA: 0x00037F50 File Offset: 0x00036150
		// (remove) Token: 0x0600097D RID: 2429 RVA: 0x00037F88 File Offset: 0x00036188
		public event Action<FemaleChar, ActividadConSoloFemaleCharacter> onScenaAndFemaleCharacterLoaded;

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00037FBD File Offset: 0x000361BD
		public sealed override Character mainNonPlayerCharacter
		{
			get
			{
				return this.femaleCharacterEnScena;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600097F RID: 2431
		protected abstract bool generateFemaleRopa { get; }

		// Token: 0x06000980 RID: 2432 RVA: 0x00037FC5 File Offset: 0x000361C5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00037FCD File Offset: 0x000361CD
		protected override IEnumerator OnStart()
		{
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
			Action<FemaleChar, ActividadConSoloFemaleCharacter> action = this.onScenaAndFemaleCharacterLoaded;
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

		// Token: 0x06000982 RID: 2434 RVA: 0x00037FDC File Offset: 0x000361DC
		private void Manager_conjuntoLoaded(IRopaManager obj)
		{
			obj.conjuntoLoaded -= this.Manager_conjuntoLoaded;
			this.currentFemaleCharacterMemoriaTemporal.RegistrarInitialOutfitWasLoaded();
			this.EscribirFemaleRopaToMemory(obj.loadedConjunto);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00038007 File Offset: 0x00036207
		private void Admin_onGenerated(IRopaDeCharacterAdmin obj)
		{
			obj.onGenerated -= this.Admin_onGenerated;
			this.currentFemaleCharacterMemoriaTemporal.RegistrarInitialOutfitWasLoaded();
			this.EscribirFemaleRopaToMemory(obj.manager.loadedConjunto);
		}

		// Token: 0x06000984 RID: 2436
		protected abstract void EscribirFemaleRopaToMemory(IConjuntoDeRopa loadedConjunto);

		// Token: 0x06000985 RID: 2437 RVA: 0x00038038 File Offset: 0x00036238
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
			}
			finally
			{
				this.OnCharacterLoaded();
			}
		}

		// Token: 0x06000986 RID: 2438
		protected abstract IEnumerator InstantiateMaleCharacter(Action<MaleChar> result);

		// Token: 0x06000987 RID: 2439
		protected abstract IEnumerator InstantiateFemaleCharacter(Action<FemaleChar> result);

		// Token: 0x06000988 RID: 2440
		protected abstract void OnCharacterLoaded();

		// Token: 0x06000989 RID: 2441
		protected abstract void OnScenaAndFemaleCharacterLoaded(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter);

		// Token: 0x0600098A RID: 2442 RVA: 0x00038124 File Offset: 0x00036324
		protected void OnFemalePersonalidadCargada(object sender)
		{
		}

		// Token: 0x04000536 RID: 1334
		[Header("-> Scena Con Female Characteres Manager <-")]
		[ReadOnlyUI]
		[SerializeField]
		private FemaleChar femaleCharacterEnScena;

		// Token: 0x04000537 RID: 1335
		[NonSerialized]
		private Personalidad femaleCharacterPersonalidad;

		// Token: 0x04000538 RID: 1336
		[NonSerialized]
		private MemoriaDeCharacterGeneralTemporal femaleCharacterMemoriaTemporal;

		// Token: 0x04000539 RID: 1337
		[NonSerialized]
		private MemoriaDeCharacterGeneralPermanente femaleCharacterMemoriaPermanente;

		// Token: 0x0400053A RID: 1338
		[NonSerialized]
		private AlteradoresDeAparienciaFemenina femaleCharacterAlteradoresApariencia;

		// Token: 0x0400053B RID: 1339
		[NonSerialized]
		private AlteradoresDePersonalidadFemenina femaleCharacterAlteradoresPersonalidad;

		// Token: 0x0400053C RID: 1340
		private ICharacterConversador m_ICharacterConversador;

		// Token: 0x0400053D RID: 1341
		[SerializeField]
		[ReadOnlyUI]
		private CharacterPuedeConversar femaleCharacterPuedeConversar;
	}
}

using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000BB RID: 187
	public class EntrevistaConFemale : ScenaConFemaleChar
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x00014EC8 File Offset: 0x000130C8
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00014ECF File Offset: 0x000130CF
		public override int updateEvent1Index
		{
			get
			{
				return 6;
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000432 RID: 1074 RVA: 0x00014ED4 File Offset: 0x000130D4
		// (remove) Token: 0x06000433 RID: 1075 RVA: 0x00014F0C File Offset: 0x0001310C
		public event EntrevistaConFemale.FemalePresenciaChangedHandler femalePresenciaChanged;

		// Token: 0x06000434 RID: 1076 RVA: 0x00014F41 File Offset: 0x00013141
		protected override void OnAwake()
		{
			base.OnAwake();
			this.m_LastFemalePresencia = this.femalePresencia;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00014F55 File Offset: 0x00013155
		protected override void OnCharacterLoaded()
		{
			base.OnCharacterLoaded();
			this.femalePresencia = EntrevistaConFemale.FemalePresencia.presente;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00014F64 File Offset: 0x00013164
		protected override void OnScenaAndFemaleCharacterLoaded(LoadSceneMode loadSceneMode, FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
			base.OnScenaAndFemaleCharacterLoaded(loadSceneMode, characterEnScena, rootForManagerLogicInCharacter);
			this.m_ConcentNecesarioDeFemale = base.currentFemaleCharacter.GetComponentInChildren<ConsentNecesario>();
			if (this.m_ConcentNecesarioDeFemale == null)
			{
				throw new ArgumentNullException("m_ConcentNecesarioDeFemale", "m_ConcentNecesarioDeFemale null reference.");
			}
			ModificadorDeBool ownPuedeConversarModificador = this.m_ownPuedeConversarModificador;
			if (ownPuedeConversarModificador != null)
			{
				ownPuedeConversarModificador.TryRemoverDeOwner(true);
			}
			this.m_ownPuedeConversarModificador = base.puedeConversarModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00014FD0 File Offset: 0x000131D0
		public override void OnUpdateEvent1()
		{
			if (this.femalePresencia != this.m_LastFemalePresencia)
			{
				EntrevistaConFemale.FemalePresencia lastFemalePresencia = this.m_LastFemalePresencia;
				this.m_LastFemalePresencia = this.femalePresencia;
				this.OnPresenciaChanged(lastFemalePresencia);
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00015005 File Offset: 0x00013205
		private void OnPresenciaChanged(EntrevistaConFemale.FemalePresencia last)
		{
			EntrevistaConFemale.FemalePresenciaChangedHandler femalePresenciaChangedHandler = this.femalePresenciaChanged;
			if (femalePresenciaChangedHandler != null)
			{
				femalePresenciaChangedHandler(last, this.femalePresencia, this);
			}
			if (this.femalePresencia != EntrevistaConFemale.FemalePresencia.presente)
			{
				this.OnPresenciaNoPresente();
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00015030 File Offset: 0x00013230
		private void OnPresenciaNoPresente()
		{
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory;
			if (current == null)
			{
				maleCharInterpretacionesMemory = null;
			}
			else
			{
				Character character = current.character;
				maleCharInterpretacionesMemory = ((character != null) ? character.GetComponentEnRoot<MaleCharInterpretacionesMemory>() : null);
			}
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory2 = maleCharInterpretacionesMemory;
			if (maleCharInterpretacionesMemory2 != null)
			{
				InterpretadorDeFemales componentEnRoot = base.currentFemaleCharacter.GetComponentEnRoot<InterpretadorDeFemales>();
				if (componentEnRoot != null)
				{
					componentEnRoot.Interpretar();
					maleCharInterpretacionesMemory2.RegistrarInterpretacion(base.currentFemaleCharacter, ref componentEnRoot.interpretacion);
				}
			}
			if (this.femalePuedeRetirarse)
			{
				this.m_ownPuedeConversarModificador.valor.valor = false;
				CameraFade.FadeOutMain(1f);
				GlobalUpdater.instancia.Invokar(delegate
				{
					base.currentFemaleCharacter.gameObject.SetActive(false);
				}, 1.1f);
				GlobalUpdater.instancia.Invokar(delegate
				{
					CameraFade.FadeInMain(1f);
				}, 1.2f);
			}
		}

		// Token: 0x040001DA RID: 474
		[Header("-> Entrevista Con Female Characteres <-")]
		public bool femalePuedeRetirarse = true;

		// Token: 0x040001DB RID: 475
		public EntrevistaConFemale.FemalePresencia femalePresencia;

		// Token: 0x040001DC RID: 476
		private EntrevistaConFemale.FemalePresencia m_LastFemalePresencia;

		// Token: 0x040001DD RID: 477
		[Obsolete("", true)]
		[NonSerialized]
		public float modCoitalRecibido = 1f;

		// Token: 0x040001DE RID: 478
		[Obsolete("", true)]
		[NonSerialized]
		public float modTactilRecibido = 1f;

		// Token: 0x040001DF RID: 479
		[Obsolete("", true)]
		[NonSerialized]
		public float modVisualRecibido = 1f;

		// Token: 0x040001E0 RID: 480
		[Obsolete("", true)]
		[NonSerialized]
		public float modVisualDada = 1f;

		// Token: 0x040001E1 RID: 481
		[SerializeField]
		private ModificadorDeBool m_ownPuedeConversarModificador;

		// Token: 0x040001E2 RID: 482
		private ConsentNecesario m_ConcentNecesarioDeFemale;

		// Token: 0x02000119 RID: 281
		// (Invoke) Token: 0x06000632 RID: 1586
		public delegate void FemalePresenciaChangedHandler(EntrevistaConFemale.FemalePresencia last, EntrevistaConFemale.FemalePresencia current, EntrevistaConFemale sender);

		// Token: 0x0200011A RID: 282
		public enum FemalePresencia
		{
			// Token: 0x040003A8 RID: 936
			presente,
			// Token: 0x040003A9 RID: 937
			retiradaPorUserInteresado,
			// Token: 0x040003AA RID: 938
			retiradaPorUserNoInteresado,
			// Token: 0x040003AB RID: 939
			retiradaPorSiMismaDolor,
			// Token: 0x040003AC RID: 940
			retiradaPorSiMismaRabia,
			// Token: 0x040003AD RID: 941
			retiradaPorSiMismaDecepcion,
			// Token: 0x040003AE RID: 942
			retiradaPorSiMismaArousal,
			// Token: 0x040003AF RID: 943
			retiradaAOtraAgencia,
			// Token: 0x040003B0 RID: 944
			retiradaPorSiMismaMiedo
		}
	}
}

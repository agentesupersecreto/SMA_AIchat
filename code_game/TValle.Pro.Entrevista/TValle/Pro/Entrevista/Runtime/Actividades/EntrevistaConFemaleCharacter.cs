using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000116 RID: 278
	public abstract class EntrevistaConFemaleCharacter : ActividadConMaleAndFemaleCharacter
	{
		// Token: 0x1400004E RID: 78
		// (add) Token: 0x060009CB RID: 2507 RVA: 0x0003869C File Offset: 0x0003689C
		// (remove) Token: 0x060009CC RID: 2508 RVA: 0x000386D4 File Offset: 0x000368D4
		public event EntrevistaConFemaleCharacter.FemalePresenciaChangedHandler femalePresenciaChanged;

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x00038709 File Offset: 0x00036909
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x00038716 File Offset: 0x00036916
		public EntrevistaConFemaleCharacter.FemalePresencia femalePresencia
		{
			get
			{
				return this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia;
			}
			set
			{
				this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia = value;
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00038724 File Offset: 0x00036924
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_EntrevistaConFemaleCharacterConfigAndData = base.GetComponentInChildren<EntrevistaConFemaleCharacterConfigAndData>();
			if (this.m_EntrevistaConFemaleCharacterConfigAndData == null)
			{
				throw new ArgumentNullException("m_EntrevistaConFemaleCharacterConfigAndData", "m_EntrevistaConFemaleCharacterConfigAndData null reference.");
			}
			this.m_LastFemalePresencia = this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00038772 File Offset: 0x00036972
		protected override void OnCharacterLoaded()
		{
			this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia = EntrevistaConFemaleCharacter.FemalePresencia.presente;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00038780 File Offset: 0x00036980
		protected override void OnScenaAndFemaleCharacterLoaded(FemaleChar characterEnScena, Transform rootForManagerLogicInCharacter)
		{
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

		// Token: 0x060009D2 RID: 2514 RVA: 0x000387E4 File Offset: 0x000369E4
		public override void AfterAnimationsUpdate()
		{
			if (this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia != this.m_LastFemalePresencia)
			{
				EntrevistaConFemaleCharacter.FemalePresencia lastFemalePresencia = this.m_LastFemalePresencia;
				this.m_LastFemalePresencia = this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia;
				this.OnPresenciaChanged(lastFemalePresencia);
			}
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00038823 File Offset: 0x00036A23
		private void OnPresenciaChanged(EntrevistaConFemaleCharacter.FemalePresencia last)
		{
			EntrevistaConFemaleCharacter.FemalePresenciaChangedHandler femalePresenciaChangedHandler = this.femalePresenciaChanged;
			if (femalePresenciaChangedHandler != null)
			{
				femalePresenciaChangedHandler(last, this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia, this);
			}
			if (this.m_EntrevistaConFemaleCharacterConfigAndData.femalePresencia != EntrevistaConFemaleCharacter.FemalePresencia.presente)
			{
				this.OnPresenciaNoPresente();
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x00038858 File Offset: 0x00036A58
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
			else
			{
				Debug.LogWarning("No existe memoria de interpretacion, los desblockeadores de agecnias no funcionaran");
			}
			if (this.m_EntrevistaConFemaleCharacterConfigAndData.femalePuedeRetirarse)
			{
				this.OnFemaleRetirandose();
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

		// Token: 0x060009D5 RID: 2517 RVA: 0x0003893E File Offset: 0x00036B3E
		protected virtual void OnFemaleRetirandose()
		{
		}

		// Token: 0x04000547 RID: 1351
		[Header("-> Entrevista Con Female Characteres <-")]
		[SerializeField]
		[ReadOnlyUI]
		private EntrevistaConFemaleCharacter.FemalePresencia m_LastFemalePresencia;

		// Token: 0x04000548 RID: 1352
		private ModificadorDeBool m_ownPuedeConversarModificador;

		// Token: 0x04000549 RID: 1353
		private ConsentNecesario m_ConcentNecesarioDeFemale;

		// Token: 0x0400054A RID: 1354
		[SerializeField]
		[ReadOnlyUI]
		private EntrevistaConFemaleCharacterConfigAndData m_EntrevistaConFemaleCharacterConfigAndData;

		// Token: 0x020002AD RID: 685
		// (Invoke) Token: 0x06001228 RID: 4648
		public delegate void FemalePresenciaChangedHandler(EntrevistaConFemaleCharacter.FemalePresencia last, EntrevistaConFemaleCharacter.FemalePresencia current, EntrevistaConFemaleCharacter sender);

		// Token: 0x020002AE RID: 686
		public enum FemalePresencia
		{
			// Token: 0x04000C5D RID: 3165
			presente,
			// Token: 0x04000C5E RID: 3166
			retiradaPorUserInteresado,
			// Token: 0x04000C5F RID: 3167
			retiradaPorUserNoInteresado,
			// Token: 0x04000C60 RID: 3168
			retiradaPorSiMismaDolor,
			// Token: 0x04000C61 RID: 3169
			retiradaPorSiMismaRabia,
			// Token: 0x04000C62 RID: 3170
			retiradaPorSiMismaDecepcion,
			// Token: 0x04000C63 RID: 3171
			retiradaPorSiMismaArousal,
			// Token: 0x04000C64 RID: 3172
			retiradaAOtraAgencia,
			// Token: 0x04000C65 RID: 3173
			retiradaPorSiMismaMiedo,
			// Token: 0x04000C66 RID: 3174
			retiradaPorUser
		}
	}
}

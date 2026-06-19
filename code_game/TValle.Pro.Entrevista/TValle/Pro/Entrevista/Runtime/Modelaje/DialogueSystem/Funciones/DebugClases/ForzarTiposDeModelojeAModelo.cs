using System;
using System.Collections;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Modelaje.DialogueSystem.Funciones.DebugClases
{
	// Token: 0x020000A6 RID: 166
	public class ForzarTiposDeModelojeAModelo : AplicableBehaviour
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x00024E78 File Offset: 0x00023078
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				if (!Application.isEditor)
				{
					return null;
				}
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00024E9C File Offset: 0x0002309C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00024EAA File Offset: 0x000230AA
		protected override IEnumerator YieldStartUnityEvent()
		{
			yield return new WaitForSeconds(3f);
			if (!Application.isEditor)
			{
				yield break;
			}
			this.m_self = this.GetComponentEnRoot(false);
			MemoriaDeCharacterGeneralPermanente componentEnRoot = this.GetComponentEnRoot(false);
			RegistroDeFuncionesDeModelaje registroDeFuncionesDeModelaje = Object.FindFirstObjectByType<RegistroDeFuncionesDeModelaje>();
			DialogueLua.SetVariable("ConversantID", componentEnRoot.owner.ID_UnicoString);
			if (this.AceptoFotografias)
			{
				if (!Application.isEditor)
				{
					Debug.LogError("THIS IS MARKED A DEBUG BUILD PLEASE CHECK IF REALY IS A DEBUG BUILD", this);
				}
				componentEnRoot.RegistrarCurrentMainCharacterComoConocido();
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				if (registroDeFuncionesDeModelaje != null)
				{
					registroDeFuncionesDeModelaje.AceptoModelajeFotografias();
				}
			}
			if (this.AceptoPosar)
			{
				if (!Application.isEditor)
				{
					Debug.LogError("THIS IS MARKED A DEBUG BUILD PLEASE CHECK IF REALY IS A DEBUG BUILD", this);
				}
				componentEnRoot.RegistrarCurrentMainCharacterComoConocido();
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				if (registroDeFuncionesDeModelaje != null)
				{
					registroDeFuncionesDeModelaje.AceptoModelaje();
				}
			}
			if (this.AceptoDesvestirse)
			{
				if (!Application.isEditor)
				{
					Debug.LogError("THIS IS MARKED A DEBUG BUILD PLEASE CHECK IF REALY IS A DEBUG BUILD", this);
				}
				componentEnRoot.RegistrarCurrentMainCharacterComoConocido();
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				if (registroDeFuncionesDeModelaje != null)
				{
					registroDeFuncionesDeModelaje.AceptoModelajeUndies();
				}
			}
			if (this.AceptoSetTocada)
			{
				if (!Application.isEditor)
				{
					Debug.LogError("THIS IS MARKED A DEBUG BUILD PLEASE CHECK IF REALY IS A DEBUG BUILD", this);
				}
				componentEnRoot.RegistrarCurrentMainCharacterComoConocido();
				MemoriaDeSMAModelosFemeninas.RegistrarHabloSobreTipoDeModelaje(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoFotografias(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				MemoriaDeSMAModelosFemeninas.RegistrarAceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, componentEnRoot.owner.ID_UnicoString);
				if (registroDeFuncionesDeModelaje != null)
				{
					registroDeFuncionesDeModelaje.AceptoModelajeEro();
				}
			}
			PersonalidadDinamica rasgos = this.GetComponentEnRoot(false).currentPersonalidad.personalidad.rasgos;
			this.m_sumisaValueMod = rasgos.GetMod(PersonalidadRasgoCompleto.sumiso).sumable.ObtenerModificadorNotNull(this);
			yield break;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00024EB9 File Offset: 0x000230B9
		public override void OnUpdateEvent1()
		{
			this.m_sumisaValueMod.valor.valor = (float)(this.esSumisa ? 100 : 0);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00024ED9 File Offset: 0x000230D9
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			MemoriaDeNpc.SetFatigue(GlobalSingletonV2<MemoriaJson>.instance, this.m_self.ID_UnicoString, 0f);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00024EFB File Offset: 0x000230FB
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Clear Fatigue"
			};
		}

		// Token: 0x040003C8 RID: 968
		public bool AceptoFotografias;

		// Token: 0x040003C9 RID: 969
		public bool AceptoPosar;

		// Token: 0x040003CA RID: 970
		public bool AceptoDesvestirse;

		// Token: 0x040003CB RID: 971
		public bool AceptoSetTocada;

		// Token: 0x040003CC RID: 972
		public bool esSumisa;

		// Token: 0x040003CD RID: 973
		private ModificadorDeFloat m_sumisaValueMod;

		// Token: 0x040003CE RID: 974
		private Character m_self;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.Memory;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Updater;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys.Trabajos
{
	// Token: 0x02000103 RID: 259
	public class RegistroDeFuncionesDeTrabajosDeModelaje : CustomMonobehaviour
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x00031AE4 File Offset: 0x0002FCE4
		static RegistroDeFuncionesDeTrabajosDeModelaje()
		{
			LuaAutoRegisterAttribute.Load(MethodBase.GetCurrentMethod().DeclaringType);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00031AF5 File Offset: 0x0002FCF5
		public void AddListiner(RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner listiner)
		{
			this.m_SpaListiners.Add(listiner);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00031B04 File Offset: 0x0002FD04
		public void RemoveListiner(RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner listiner)
		{
			this.m_SpaListiners.Remove(listiner);
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x00031B14 File Offset: 0x0002FD14
		public static string currentSelectedBodyPart
		{
			get
			{
				return DialogueLua.GetVariable("SELECTED_BODYPART").AsString;
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00031B34 File Offset: 0x0002FD34
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuaAutoRegisterAttribute.Register(this);
			Lua.RegisterFunction("TrabajosDeModelajeTesting", this, base.GetType().GetMethod("TrabajosDeModelajeTesting"));
			Lua.RegisterFunction("ConversantConoceEmpleador", this, base.GetType().GetMethod("ConversantConoceEmpleador"));
			Lua.RegisterFunction("ConversantConoceCliente", this, base.GetType().GetMethod("ConversantConoceCliente"));
			Lua.RegisterFunction("ConversantConoceEmpleadorComoEmpleador", this, base.GetType().GetMethod("ConversantConoceEmpleadorComoEmpleador"));
			Lua.RegisterFunction("ConversantConocioOtroEmpleador", this, base.GetType().GetMethod("ConversantConocioOtroEmpleador"));
			Lua.RegisterFunction("RegistrarActorComoCurrentClientEnConversant", this, base.GetType().GetMethod("RegistrarActorComoCurrentClientEnConversant"));
			Lua.RegisterFunction("RegistrarActorComoCurrentEmpleadorEnConversant", this, base.GetType().GetMethod("RegistrarActorComoCurrentEmpleadorEnConversant"));
			Lua.RegisterFunction("FirstTimeDeConversant", this, base.GetType().GetMethod("FirstTimeDeConversant"));
			Lua.RegisterFunction("CantidadSesionesLaboralesDeConversant", this, base.GetType().GetMethod("CantidadSesionesLaboralesDeConversant"));
			Lua.RegisterFunction("RegistrarSesionesLaboralEnConversant", this, base.GetType().GetMethod("RegistrarSesionesLaboralEnConversant"));
			Lua.RegisterFunction("TerminarJobSelf", this, base.GetType().GetMethod("TerminarJobSelf"));
			Lua.RegisterFunction("TerminarJobUser", this, base.GetType().GetMethod("TerminarJobUser"));
			Lua.RegisterFunction("SelectBodyPart", this, base.GetType().GetMethod("SelectBodyPart"));
			Lua.RegisterFunction("GetSelectedBodyPart", this, base.GetType().GetMethod("GetSelectedBodyPart"));
			Lua.RegisterFunction("AceptacionSexualSegunDeseosMaxParaHandJob", this, base.GetType().GetMethod("AceptacionSexualSegunDeseosMaxParaHandJob"));
			Lua.RegisterFunction("AceptacionTeasingSegunDeseosMax", this, base.GetType().GetMethod("AceptacionTeasingSegunDeseosMax"));
			Lua.RegisterFunction("GenerarAgreementDeTratoExplicitoOral", this, base.GetType().GetMethod("GenerarAgreementDeTratoExplicitoOral"));
			Lua.RegisterFunction("GenerarAgreementDeTratoExplicitoAnal", this, base.GetType().GetMethod("GenerarAgreementDeTratoExplicitoAnal"));
			Lua.RegisterFunction("GenerarAgreementDeTratoExplicitoVag", this, base.GetType().GetMethod("GenerarAgreementDeTratoExplicitoVag"));
			Lua.RegisterFunction("GenerarAgreementDeTratoMassage", this, base.GetType().GetMethod("GenerarAgreementDeTratoMassage"));
			Lua.RegisterFunction("BorrarAgreementDeTrato", this, base.GetType().GetMethod("BorrarAgreementDeTrato"));
			Lua.RegisterFunction("AceptacionSexualAnalSegunDeseosMax", this, base.GetType().GetMethod("AceptacionSexualAnalSegunDeseosMax"));
			Lua.RegisterFunction("AceptacionSexualVaginalSegunDeseosMax", this, base.GetType().GetMethod("AceptacionSexualVaginalSegunDeseosMax"));
			Lua.RegisterFunction("AceptacionSexualOralSegunDeseosMax", this, base.GetType().GetMethod("AceptacionSexualOralSegunDeseosMax"));
			Lua.RegisterFunction("RegistrarAceptoSpaMassageEn", this, base.GetType().GetMethod("RegistrarAceptoSpaMassageEn"));
			Lua.RegisterFunction("RegistrarAceptoSpaHappyEnding", this, base.GetType().GetMethod("RegistrarAceptoSpaHappyEnding"));
			Lua.RegisterFunction("RegistrarAceptoSpaGetOnTopEnding", this, base.GetType().GetMethod("RegistrarAceptoSpaGetOnTopEnding"));
			Lua.RegisterFunction("HasHandjobInteraction", this, base.GetType().GetMethod("HasHandjobInteraction"));
			Lua.RegisterFunction("HandjobConsentido", this, base.GetType().GetMethod("HandjobConsentido"));
			Lua.RegisterFunction("IncreaseHandjobSpeed", this, base.GetType().GetMethod("IncreaseHandjobSpeed"));
			Lua.RegisterFunction("DecreaseHandjobSpeed", this, base.GetType().GetMethod("DecreaseHandjobSpeed"));
			Lua.RegisterFunction("StartHandjob", this, base.GetType().GetMethod("StartHandjob"));
			Lua.RegisterFunction("StopHandjob", this, base.GetType().GetMethod("StopHandjob"));
			Lua.RegisterFunction("MainPlayerDickIsOut", this, base.GetType().GetMethod("MainPlayerDickIsOut"));
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00031EE4 File Offset: 0x000300E4
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			LuaAutoRegisterAttribute.Unregister(this);
			Lua.UnregisterFunction("TrabajosDeModelajeTesting");
			Lua.UnregisterFunction("ConversantConoceEmpleador");
			Lua.UnregisterFunction("ConversantConoceCliente");
			Lua.UnregisterFunction("ConversantConoceEmpleadorComoEmpleador");
			Lua.UnregisterFunction("ConversantConocioOtroEmpleador");
			Lua.UnregisterFunction("RegistrarActorComoCurrentClientEnConversant");
			Lua.UnregisterFunction("RegistrarActorComoCurrentEmpleadorEnConversant");
			Lua.UnregisterFunction("FirstTimeDeConversant");
			Lua.UnregisterFunction("CantidadSesionesLaboralesDeConversant");
			Lua.UnregisterFunction("RegistrarSesionesLaboralEnConversant");
			Lua.UnregisterFunction("TerminarJobSelf");
			Lua.UnregisterFunction("TerminarJobUser");
			Lua.UnregisterFunction("SelectBodyPart");
			Lua.UnregisterFunction("GetSelectedBodyPart");
			Lua.UnregisterFunction("AceptacionSexualSegunDeseosMaxParaHandJob");
			Lua.UnregisterFunction("AceptacionTeasingSegunDeseosMax");
			Lua.UnregisterFunction("GenerarAgreementDeTratoExplicitoOral");
			Lua.UnregisterFunction("GenerarAgreementDeTratoExplicitoVag");
			Lua.UnregisterFunction("GenerarAgreementDeTratoExplicitoAnal");
			Lua.UnregisterFunction("GenerarAgreementDeTratoMassage");
			Lua.UnregisterFunction("BorrarAgreementDeTrato");
			Lua.UnregisterFunction("AceptacionSexualAnalSegunDeseosMax");
			Lua.UnregisterFunction("AceptacionSexualVaginalSegunDeseosMax");
			Lua.UnregisterFunction("AceptacionSexualOralSegunDeseosMax");
			Lua.UnregisterFunction("RegistrarAceptoSpaMassageEn");
			Lua.UnregisterFunction("RegistrarAceptoSpaHappyEnding");
			Lua.UnregisterFunction("RegistrarAceptoSpaGetOnTopEnding");
			Lua.UnregisterFunction("HasHandjobInteraction");
			Lua.UnregisterFunction("HandjobConsentido");
			Lua.UnregisterFunction("IncreaseHandjobSpeed");
			Lua.UnregisterFunction("DecreaseHandjobSpeed");
			Lua.UnregisterFunction("StartHandjob");
			Lua.UnregisterFunction("StopHandjob");
			Lua.UnregisterFunction("MainPlayerDickIsOut");
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00032054 File Offset: 0x00030254
		public static IContextMemory GetConversantMemoriaEnContextoDeTrabajo()
		{
			return RegistroDeFuncionesDeTrabajosDeModelaje.GetMemoriaDeCharacterEnContextoDeTrabajo(DialogueLua.GetVariable("ConversantID").AsString);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00032078 File Offset: 0x00030278
		public static IContextMemory GetMemoriaDeCharacterEnContextoDeTrabajo(string idCharacter)
		{
			SceneCharacter sceneCharacter = RegistroDeFuncionesDeTrabajosDeModelaje.ObtenerSceneCharacter(idCharacter);
			ISMAJob current = AsyncSingleton<JobsManager>.instance.current;
			return AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(current, sceneCharacter);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x000320A4 File Offset: 0x000302A4
		public static IContextMemory GetMemoriaDeDeTrabajo()
		{
			ISMAJob current = AsyncSingleton<JobsManager>.instance.current;
			return AsyncSingleton<JobsManager>.instance.GetMemory(current);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x000320C8 File Offset: 0x000302C8
		public static SceneCharacter ObtenerSceneCharacter(string idCharacter)
		{
			Guid guid = Guid.Parse(idCharacter);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponent<SceneCharacter>();
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000320EC File Offset: 0x000302EC
		public static Deseos ObtenerDesesoDeNonPlayer()
		{
			SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
			if (mainNonPlayerCharacter == null)
			{
				return null;
			}
			return mainNonPlayerCharacter.GetComponentInChildren<Deseos>();
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00032108 File Offset: 0x00030308
		public static Personalidad ObtenePersonalidadDeNonPlayer()
		{
			SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
			if (mainNonPlayerCharacter == null)
			{
				return null;
			}
			return mainNonPlayerCharacter.GetComponentInChildren<Personalidad>();
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00032124 File Offset: 0x00030324
		public void TrabajosDeModelajeTesting()
		{
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00032128 File Offset: 0x00030328
		public bool HasHandjobInteraction()
		{
			bool flag;
			try
			{
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<IInteraccionesDeCharacterFemenino>().Obtener("tvalle.inter.HandJobInMaleR".GetHashCode());
				flag = ((interaccionDeCharacterFemenino != null) ? interaccionDeCharacterFemenino.instancia : null) != null;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00032188 File Offset: 0x00030388
		public bool MainPlayerDickIsOut()
		{
			bool flag;
			try
			{
				Penis componentEnRoot = Singleton<ActividadesManager>.instance.current.mainPlayerCharacter.GetComponentEnRoot<Penis>();
				flag = !componentEnRoot.hidden && !componentEnRoot.wasBlocked;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x000321DC File Offset: 0x000303DC
		public bool HandjobConsentido()
		{
			bool flag;
			try
			{
				float num;
				float num2;
				flag = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<ConsentNecesario>().EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.manos, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0003223C File Offset: 0x0003043C
		public void IncreaseHandjobSpeed()
		{
			try
			{
				HandJobController.Orden orden = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<HandJobController>().currentStado.FirstOrDefaultEjecutandose();
				if (orden != null)
				{
					orden.velocidad = Mathf.Clamp(orden.velocidad * 1.2f, 0.25f, 5f);
					orden.slowDownVelocity = orden.velocidad / 60f;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x000322B8 File Offset: 0x000304B8
		public void DecreaseHandjobSpeed()
		{
			try
			{
				HandJobController.Orden orden = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<HandJobController>().currentStado.FirstOrDefaultEjecutandose();
				if (orden != null)
				{
					orden.velocidad = Mathf.Clamp(orden.velocidad / 1.2f, 0.25f, 5f);
					orden.slowDownVelocity = orden.velocidad / 60f;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00032334 File Offset: 0x00030534
		public void StartHandjob()
		{
			try
			{
				HandJobController componentEnRoot = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<HandJobController>();
				float num = 0.5f;
				float num2 = num / 60f;
				componentEnRoot.DoToConApoyoAutomatico(Singleton<ActividadesManager>.instance.current.mainPlayerCharacter.GetComponent<MaleChar>(), Side.R, num, num2, -1f, 0, ControllerPrioridadConfig.interrumpir);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x000323A4 File Offset: 0x000305A4
		public void StopHandjob()
		{
			try
			{
				HandJobController componentEnRoot = Singleton<ActividadesManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot<HandJobController>();
				if (componentEnRoot != null)
				{
					componentEnRoot.DetenerOrdenes();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x000323EC File Offset: 0x000305EC
		private void GenerarAgreementBuffes(BuffDeCharacter m_BuffDeCharacter, out BuffMap favMap, out BuffOnMinFavorabilityValueArg favArgument, out BuffMap desMap, out BuffOnDeshieloDeEstimuloEnPartesArg desArgument, out BuffMap painMap, out BuffOnEmotionGainOfInteractionArg painArgument, out BuffMap painIncreaseMap, out BuffOnEmotionIntervalIncreaseOfInteractionArg painIncreaseArgument, out BuffMap pleasureMap, out BuffOnEmotionGainOfInteractionArg pleasureArgument, out BuffMap pleasureExpandMap, out BuffOnEmotionIntervalExpandOfInteractionArg pleasureExpandArgument)
		{
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobAgreement", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text);
			favMap = Singleton<BuffManager>.instance.GetMap(text);
			if (favMap == null)
			{
				Debug.LogException(new ArgumentNullException("favMap", "favMap null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(favMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnMinFavorabilityValueArg>(efecto.argumentoID, out favArgument))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			string text2 = BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobAgreement", string.Empty);
			m_BuffDeCharacter.eventos.Remove(text2);
			desMap = Singleton<BuffManager>.instance.GetMap(text2);
			if (desMap == null)
			{
				Debug.LogException(new ArgumentNullException("desMap", "desMap null reference."));
			}
			Efecto efecto2 = Singleton<EfectosManager>.instance.GetEfecto(desMap.efectoId);
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnDeshieloDeEstimuloEnPartesArg>(efecto2.argumentoID, out desArgument))
			{
				Debug.LogError("arg id :" + efecto2.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			BuffAndDebuffGeneratorHelper.GenerarAgreementBuffes<BuffOnEmotionGainOfInteractionArg>(m_BuffDeCharacter, "Tvalle.Buff.PainResistanceByJobAgreement", out painMap, out painArgument);
			BuffAndDebuffGeneratorHelper.GenerarAgreementBuffes<BuffOnEmotionIntervalIncreaseOfInteractionArg>(m_BuffDeCharacter, "Tvalle.Buff.PainIntervalIncreaseByJobAgreement", out painIncreaseMap, out painIncreaseArgument);
			BuffAndDebuffGeneratorHelper.GenerarAgreementBuffes<BuffOnEmotionGainOfInteractionArg>(m_BuffDeCharacter, "Tvalle.Buff.PleasureResistanceByJobAgreement", out pleasureMap, out pleasureArgument);
			BuffAndDebuffGeneratorHelper.GenerarAgreementBuffes<BuffOnEmotionIntervalExpandOfInteractionArg>(m_BuffDeCharacter, "Tvalle.Buff.PleasureIntervalExpandByJobAgreement", out pleasureExpandMap, out pleasureExpandArgument);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00032548 File Offset: 0x00030748
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
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000326C8 File Offset: 0x000308C8
		private void FillInclusiveDataTratoExplicitoOverrallPose(List<GenericDataOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.ejecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.manos,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.ejecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.peticionEjecucionDePose,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.boca,
				estimuladas = typeof(ParteDelCuerpoHumano).GetEnumValoresObject().Cast<ParteDelCuerpoHumano>().ToArray<ParteDelCuerpoHumano>()
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.manipulandoBone;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg2.tipo = TipoDeEstimulo.guiandoBone;
			genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.boca;
			genericDataOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg2);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0003287C File Offset: 0x00030A7C
		private void FillInclusiveDataTratoExplicitoOral(List<GenericDataOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.bocaInterno }
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.semen;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				where p != ParteDelCuerpoHumano.ojos && p != ParteDelCuerpoHumano.globosOculares && p != ParteDelCuerpoHumano.cabeza
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg2);
			GenericDataOfInteractionArg genericDataOfInteractionArg3 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg3.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				where p != ParteDelCuerpoHumano.ojos && p != ParteDelCuerpoHumano.globosOculares && p != ParteDelCuerpoHumano.cabeza
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg3);
			GenericDataOfInteractionArg genericDataOfInteractionArg4 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg4.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg4.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg4);
			GenericDataOfInteractionArg genericDataOfInteractionArg5 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg5.tipo = TipoDeEstimulo.desvestidura;
			genericDataOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg5.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg5);
			GenericDataOfInteractionArg genericDataOfInteractionArg6 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg6.tipo = TipoDeEstimulo.peticionDesvestidura;
			genericDataOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg6.estiulante = ParteQuePuedeEstimular.boca;
			genericDataOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFacial()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg6);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00032B84 File Offset: 0x00030D84
		private void FillInclusiveDataTratoExplicitoVaginal(List<GenericDataOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.vag }
			});
			GenericDataOfInteractionArg genericDataOfInteractionArg = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg.estiulante = ParteQuePuedeEstimular.semen;
			genericDataOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg);
			GenericDataOfInteractionArg genericDataOfInteractionArg2 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg2.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg2.estiulante = ParteQuePuedeEstimular.pene;
			genericDataOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg2);
			GenericDataOfInteractionArg genericDataOfInteractionArg3 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg3.tipo = TipoDeEstimulo.tactil;
			genericDataOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg3.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg3);
			GenericDataOfInteractionArg genericDataOfInteractionArg4 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg4.tipo = TipoDeEstimulo.visual;
			genericDataOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg4.estiulante = ParteQuePuedeEstimular.ojos;
			genericDataOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg4);
			GenericDataOfInteractionArg genericDataOfInteractionArg5 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg5.tipo = TipoDeEstimulo.desvestidura;
			genericDataOfInteractionArg5.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg5.estiulante = ParteQuePuedeEstimular.manos;
			genericDataOfInteractionArg5.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg5);
			GenericDataOfInteractionArg genericDataOfInteractionArg6 = new GenericDataOfInteractionArg();
			genericDataOfInteractionArg6.tipo = TipoDeEstimulo.peticionDesvestidura;
			genericDataOfInteractionArg6.direccion = DireccionDeEstimulo.recibida;
			genericDataOfInteractionArg6.estiulante = ParteQuePuedeEstimular.boca;
			genericDataOfInteractionArg6.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsEntrepierna() || p.EsTrasero()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataOfInteractionArg6);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00032E44 File Offset: 0x00031044
		private void FillInclusiveDataTratoExplicitoAnal(List<GenericDataOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataOfInteractionArg
			{
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			this.FillInclusiveDataTratoExplicitoVaginal(ToInyecData);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00032E8C File Offset: 0x0003108C
		private void FillInclusiveDataTratoEspecialMassageCamilla(List<GenericDataOfInteractionArg> ToInyecData)
		{
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
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00032F20 File Offset: 0x00031120
		private void FillExclusionesDataTratoExplicitoOral(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
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

		// Token: 0x060008C3 RID: 2243 RVA: 0x00032FB8 File Offset: 0x000311B8
		private void FillExclusionesDataTratoExplicitoVag(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
			ToInyecData.Add(new GenericDataExclusiveOfInteractionArg
			{
				weight = 1f,
				tipo = TipoDeEstimulo.coital,
				direccion = DireccionDeEstimulo.recibida,
				estiulante = ParteQuePuedeEstimular.pene,
				estimuladas = new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.ano }
			});
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00033041 File Offset: 0x00031241
		private void FillExclusionesDataTratoExplicitoAnal(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00033044 File Offset: 0x00031244
		private void FillExclusionesDataTratoEspecialMassage(List<GenericDataExclusiveOfInteractionArg> ToInyecData)
		{
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg.weight = 1f;
			genericDataExclusiveOfInteractionArg.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg.estiulante = ParteQuePuedeEstimular.pene;
			genericDataExclusiveOfInteractionArg.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg2 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg2.weight = 1f;
			genericDataExclusiveOfInteractionArg2.tipo = TipoDeEstimulo.coital;
			genericDataExclusiveOfInteractionArg2.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg2.estiulante = ParteQuePuedeEstimular.dedo;
			genericDataExclusiveOfInteractionArg2.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsHole()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg2);
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
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg3 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg3.weight = 1f;
			genericDataExclusiveOfInteractionArg3.tipo = TipoDeEstimulo.manipulandoBone;
			genericDataExclusiveOfInteractionArg3.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg3.estiulante = ParteQuePuedeEstimular.manos;
			genericDataExclusiveOfInteractionArg3.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg3);
			GenericDataExclusiveOfInteractionArg genericDataExclusiveOfInteractionArg4 = new GenericDataExclusiveOfInteractionArg();
			genericDataExclusiveOfInteractionArg4.weight = 1f;
			genericDataExclusiveOfInteractionArg4.tipo = TipoDeEstimulo.guiandoBone;
			genericDataExclusiveOfInteractionArg4.direccion = DireccionDeEstimulo.recibida;
			genericDataExclusiveOfInteractionArg4.estiulante = ParteQuePuedeEstimular.boca;
			genericDataExclusiveOfInteractionArg4.estimuladas = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsSkeleto()
				select p).ToArray<ParteDelCuerpoHumano>();
			ToInyecData.Add(genericDataExclusiveOfInteractionArg4);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000333C8 File Offset: 0x000315C8
		private void AddBuffToCharacter(BuffDeCharacter m_BuffDeCharacter, BuffMap favMap, BuffOnMinFavorabilityValueArg favArgument, BuffMap desMap, BuffOnDeshieloDeEstimuloEnPartesArg desArgument, BuffMap painMap, BuffOnEmotionGainOfInteractionArg painArgument, BuffMap painIncreaseMap, BuffOnEmotionIntervalIncreaseOfInteractionArg painIncreaseArgument, BuffMap pleasureMap, BuffOnEmotionGainOfInteractionArg pleasureArgument, BuffMap pleasureExpandMap, BuffOnEmotionIntervalExpandOfInteractionArg pleasureExpandArgument)
		{
			favArgument.changedByFatigue = true;
			favArgument.force = true;
			desArgument.value = 100f;
			painArgument.changedByFatigue = true;
			painArgument.gain = 0.25f;
			painArgument.emo = ReaccionHumana.dolor;
			painIncreaseArgument.changedByFatigue = true;
			painIncreaseArgument.increase = 4f;
			painIncreaseArgument.emo = ReaccionHumana.dolor;
			painIncreaseArgument.tipo = BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.max;
			pleasureArgument.changedByFatigue = true;
			pleasureArgument.gain = 0.25f;
			pleasureArgument.emo = ReaccionHumana.placer;
			pleasureExpandArgument.changedByFatigue = true;
			pleasureExpandArgument.expand = 4f;
			pleasureExpandArgument.emo = ReaccionHumana.placer;
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
			BuffAndDebuffGeneratorHelper.AddBuff<BuffOnEmotionGainOfInteractionArg>(m_BuffDeCharacter, painMap, painArgument);
			BuffAndDebuffGeneratorHelper.AddBuff<BuffOnEmotionIntervalIncreaseOfInteractionArg>(m_BuffDeCharacter, painIncreaseMap, painIncreaseArgument);
			BuffAndDebuffGeneratorHelper.AddBuff<BuffOnEmotionGainOfInteractionArg>(m_BuffDeCharacter, pleasureMap, pleasureArgument);
			BuffAndDebuffGeneratorHelper.AddBuff<BuffOnEmotionIntervalExpandOfInteractionArg>(m_BuffDeCharacter, pleasureExpandMap, pleasureExpandArgument);
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0003353C File Offset: 0x0003173C
		private List<GenericDataOfInteractionArg> GetDataInclusionesExplicitoOral()
		{
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			this.FillInclusiveDataTratoEspecialOverrall(list);
			this.FillInclusiveDataTratoExplicitoOverrallPose(list);
			this.FillInclusiveDataTratoExplicitoOral(list);
			return list;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00033568 File Offset: 0x00031768
		private List<GenericDataOfInteractionArg> GetDataInclusionesExplicitoVag()
		{
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			this.FillInclusiveDataTratoEspecialOverrall(list);
			this.FillInclusiveDataTratoExplicitoOverrallPose(list);
			this.FillInclusiveDataTratoExplicitoVaginal(list);
			return list;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00033594 File Offset: 0x00031794
		private List<GenericDataOfInteractionArg> GetDataInclusionesExplicitoAnal()
		{
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			this.FillInclusiveDataTratoEspecialOverrall(list);
			this.FillInclusiveDataTratoExplicitoOverrallPose(list);
			this.FillInclusiveDataTratoExplicitoAnal(list);
			return list;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000335C0 File Offset: 0x000317C0
		private List<GenericDataOfInteractionArg> GetDataInclusionesExplicitoMassagesAndHandJob()
		{
			List<GenericDataOfInteractionArg> list = new List<GenericDataOfInteractionArg>();
			this.FillInclusiveDataTratoEspecialOverrall(list);
			this.FillInclusiveDataTratoEspecialMassageCamilla(list);
			return list;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x000335E4 File Offset: 0x000317E4
		public void GenerarAgreementDeTratoMassage()
		{
			try
			{
				this.BorrarAgreementDeTrato();
				BuffDeCharacter componentEnRoot = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
				}
				BuffMap buffMap;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
				BuffMap buffMap2;
				BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
				BuffMap buffMap3;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg;
				BuffMap buffMap4;
				BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg;
				BuffMap buffMap5;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg2;
				BuffMap buffMap6;
				BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg;
				this.GenerarAgreementBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg, out buffMap3, out buffOnEmotionGainOfInteractionArg, out buffMap4, out buffOnEmotionIntervalIncreaseOfInteractionArg, out buffMap5, out buffOnEmotionGainOfInteractionArg2, out buffMap6, out buffOnEmotionIntervalExpandOfInteractionArg);
				List<GenericDataOfInteractionArg> dataInclusionesExplicitoMassagesAndHandJob = this.GetDataInclusionesExplicitoMassagesAndHandJob();
				List<GenericDataExclusiveOfInteractionArg> list = new List<GenericDataExclusiveOfInteractionArg>();
				this.FillExclusionesDataTratoEspecialMassage(list);
				buffOnMinFavorabilityValueArg.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list);
				buffOnDeshieloDeEstimuloEnPartesArg.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				buffOnEmotionGainOfInteractionArg.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				buffOnEmotionIntervalIncreaseOfInteractionArg.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				buffOnEmotionGainOfInteractionArg2.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				buffOnEmotionIntervalExpandOfInteractionArg.InyectData(dataInclusionesExplicitoMassagesAndHandJob);
				this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg, buffMap3, buffOnEmotionGainOfInteractionArg, buffMap4, buffOnEmotionIntervalIncreaseOfInteractionArg, buffMap5, buffOnEmotionGainOfInteractionArg2, buffMap6, buffOnEmotionIntervalExpandOfInteractionArg);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x000336D4 File Offset: 0x000318D4
		public void GenerarAgreementDeTratoExplicitoOral()
		{
			try
			{
				this.BorrarAgreementDeTrato();
				BuffDeCharacter componentEnRoot = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
				}
				BuffMap buffMap;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
				BuffMap buffMap2;
				BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
				BuffMap buffMap3;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg;
				BuffMap buffMap4;
				BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg;
				BuffMap buffMap5;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg2;
				BuffMap buffMap6;
				BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg;
				this.GenerarAgreementBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg, out buffMap3, out buffOnEmotionGainOfInteractionArg, out buffMap4, out buffOnEmotionIntervalIncreaseOfInteractionArg, out buffMap5, out buffOnEmotionGainOfInteractionArg2, out buffMap6, out buffOnEmotionIntervalExpandOfInteractionArg);
				List<GenericDataOfInteractionArg> dataInclusionesExplicitoOral = this.GetDataInclusionesExplicitoOral();
				List<GenericDataExclusiveOfInteractionArg> list = new List<GenericDataExclusiveOfInteractionArg>();
				this.FillExclusionesDataTratoExplicitoOral(list);
				buffOnMinFavorabilityValueArg.InyectData(dataInclusionesExplicitoOral);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list);
				buffOnDeshieloDeEstimuloEnPartesArg.InyectData(dataInclusionesExplicitoOral);
				buffOnEmotionGainOfInteractionArg.InyectData(dataInclusionesExplicitoOral);
				buffOnEmotionIntervalIncreaseOfInteractionArg.InyectData(dataInclusionesExplicitoOral);
				buffOnEmotionGainOfInteractionArg2.InyectData(dataInclusionesExplicitoOral);
				buffOnEmotionIntervalExpandOfInteractionArg.InyectData(dataInclusionesExplicitoOral);
				this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg, buffMap3, buffOnEmotionGainOfInteractionArg, buffMap4, buffOnEmotionIntervalIncreaseOfInteractionArg, buffMap5, buffOnEmotionGainOfInteractionArg2, buffMap6, buffOnEmotionIntervalExpandOfInteractionArg);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x000337C4 File Offset: 0x000319C4
		public void GenerarAgreementDeTratoExplicitoVag()
		{
			try
			{
				this.BorrarAgreementDeTrato();
				BuffDeCharacter componentEnRoot = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
				}
				BuffMap buffMap;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
				BuffMap buffMap2;
				BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
				BuffMap buffMap3;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg;
				BuffMap buffMap4;
				BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg;
				BuffMap buffMap5;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg2;
				BuffMap buffMap6;
				BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg;
				this.GenerarAgreementBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg, out buffMap3, out buffOnEmotionGainOfInteractionArg, out buffMap4, out buffOnEmotionIntervalIncreaseOfInteractionArg, out buffMap5, out buffOnEmotionGainOfInteractionArg2, out buffMap6, out buffOnEmotionIntervalExpandOfInteractionArg);
				List<GenericDataOfInteractionArg> dataInclusionesExplicitoVag = this.GetDataInclusionesExplicitoVag();
				List<GenericDataExclusiveOfInteractionArg> list = new List<GenericDataExclusiveOfInteractionArg>();
				this.FillExclusionesDataTratoExplicitoVag(list);
				buffOnMinFavorabilityValueArg.InyectData(dataInclusionesExplicitoVag);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list);
				buffOnDeshieloDeEstimuloEnPartesArg.InyectData(dataInclusionesExplicitoVag);
				buffOnEmotionGainOfInteractionArg.InyectData(dataInclusionesExplicitoVag);
				buffOnEmotionIntervalIncreaseOfInteractionArg.InyectData(dataInclusionesExplicitoVag);
				buffOnEmotionGainOfInteractionArg2.InyectData(dataInclusionesExplicitoVag);
				buffOnEmotionIntervalExpandOfInteractionArg.InyectData(dataInclusionesExplicitoVag);
				this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg, buffMap3, buffOnEmotionGainOfInteractionArg, buffMap4, buffOnEmotionIntervalIncreaseOfInteractionArg, buffMap5, buffOnEmotionGainOfInteractionArg2, buffMap6, buffOnEmotionIntervalExpandOfInteractionArg);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x000338B4 File Offset: 0x00031AB4
		public void GenerarAgreementDeTratoExplicitoAnal()
		{
			try
			{
				this.BorrarAgreementDeTrato();
				BuffDeCharacter componentEnRoot = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
				}
				BuffMap buffMap;
				BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
				BuffMap buffMap2;
				BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
				BuffMap buffMap3;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg;
				BuffMap buffMap4;
				BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg;
				BuffMap buffMap5;
				BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg2;
				BuffMap buffMap6;
				BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg;
				this.GenerarAgreementBuffes(componentEnRoot, out buffMap, out buffOnMinFavorabilityValueArg, out buffMap2, out buffOnDeshieloDeEstimuloEnPartesArg, out buffMap3, out buffOnEmotionGainOfInteractionArg, out buffMap4, out buffOnEmotionIntervalIncreaseOfInteractionArg, out buffMap5, out buffOnEmotionGainOfInteractionArg2, out buffMap6, out buffOnEmotionIntervalExpandOfInteractionArg);
				List<GenericDataOfInteractionArg> dataInclusionesExplicitoAnal = this.GetDataInclusionesExplicitoAnal();
				List<GenericDataExclusiveOfInteractionArg> list = new List<GenericDataExclusiveOfInteractionArg>();
				this.FillExclusionesDataTratoExplicitoAnal(list);
				buffOnMinFavorabilityValueArg.InyectData(dataInclusionesExplicitoAnal);
				buffOnMinFavorabilityValueArg.InyectExclusiveData(list);
				buffOnDeshieloDeEstimuloEnPartesArg.InyectData(dataInclusionesExplicitoAnal);
				buffOnEmotionGainOfInteractionArg.InyectData(dataInclusionesExplicitoAnal);
				buffOnEmotionIntervalIncreaseOfInteractionArg.InyectData(dataInclusionesExplicitoAnal);
				buffOnEmotionGainOfInteractionArg2.InyectData(dataInclusionesExplicitoAnal);
				buffOnEmotionIntervalExpandOfInteractionArg.InyectData(dataInclusionesExplicitoAnal);
				this.AddBuffToCharacter(componentEnRoot, buffMap, buffOnMinFavorabilityValueArg, buffMap2, buffOnDeshieloDeEstimuloEnPartesArg, buffMap3, buffOnEmotionGainOfInteractionArg, buffMap4, buffOnEmotionIntervalIncreaseOfInteractionArg, buffMap5, buffOnEmotionGainOfInteractionArg2, buffMap6, buffOnEmotionIntervalExpandOfInteractionArg);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000339A4 File Offset: 0x00031BA4
		public void BorrarAgreementDeTrato()
		{
			try
			{
				BuffDeCharacter componentEnRoot = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.GetComponentEnRoot(false);
				if (componentEnRoot == null)
				{
					Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
				}
				string text = BuffMap.GenerateBuffID("Tvalle.Buff.FavorabilityByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text);
				string text2 = BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text2);
				string text3 = BuffMap.GenerateBuffID("Tvalle.Buff.PainResistanceByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text3);
				string text4 = BuffMap.GenerateBuffID("Tvalle.Buff.PainIntervalIncreaseByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text4);
				string text5 = BuffMap.GenerateBuffID("Tvalle.Buff.PleasureResistanceByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text5);
				string text6 = BuffMap.GenerateBuffID("Tvalle.Buff.PleasureIntervalExpandByJobAgreement", string.Empty);
				componentEnRoot.eventos.Remove(text6);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00033AAC File Offset: 0x00031CAC
		public float AceptacionSexualAnalSegunDeseosMax(float ModByFatigue, bool usePersonalityTraits)
		{
			float num12;
			try
			{
				SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, mainNonPlayerCharacter.stringID, 2f);
				float num;
				float num2;
				float num3;
				float num4;
				this.AceptacionSexualSegunDeseos(out num, out num2, out num3, out num4);
				float num5 = num4;
				if (usePersonalityTraits)
				{
					float num6;
					float num7;
					float num8;
					RegistroDeFuncionesDeTrabajosDeModelaje.ObtenePersonalidadDeNonPlayer().GetPreferredTreatmentForClientsWeights(out num6, out num7, out num8);
					if (num8 <= 0f)
					{
						num5 = -1f;
					}
				}
				ConsentNecesario componentEnRoot = mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num9 = componentEnRoot.ParaConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, null, null, null);
				float num10 = BuffOnMinFavorabilityValueEffecto.SimularValor(this.GetDataInclusionesExplicitoAnal(), componentEnRoot, new EmocionesFemeninasValues?(EmocionesFemeninasValues.emptyValid));
				float num11;
				num10 = BuffOnMinFavorabilityValueEffecto.ReduceValorByFatigue(num10, applyableFatigueMod, out num11);
				num9 = Mathf.Clamp(num9, 0f, 100f);
				if (Mathf.Max(componentEnRoot.consentActual, num10) < num9)
				{
					num5 = Mathf.Min(0f, num5);
				}
				num12 = Mathf.Lerp(num5, -1f, applyableFatigueMod * ModByFatigue);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num12 = 0f;
			}
			return num12;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00033BC4 File Offset: 0x00031DC4
		public float AceptacionSexualVaginalSegunDeseosMax(float ModByFatigue, bool usePersonalityTraits)
		{
			float num12;
			try
			{
				SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, mainNonPlayerCharacter.stringID, 2f);
				float num;
				float num2;
				float num3;
				float num4;
				this.AceptacionSexualSegunDeseos(out num, out num2, out num3, out num4);
				float num5 = num3;
				if (usePersonalityTraits)
				{
					float num6;
					float num7;
					float num8;
					RegistroDeFuncionesDeTrabajosDeModelaje.ObtenePersonalidadDeNonPlayer().GetPreferredTreatmentForClientsWeights(out num6, out num7, out num8);
					if (num8 <= 0f)
					{
						num5 = -1f;
					}
				}
				ConsentNecesario componentEnRoot = mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num9 = componentEnRoot.ParaConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, null, null, null);
				float num10 = BuffOnMinFavorabilityValueEffecto.SimularValor(this.GetDataInclusionesExplicitoVag(), componentEnRoot, new EmocionesFemeninasValues?(EmocionesFemeninasValues.emptyValid));
				float num11;
				num10 = BuffOnMinFavorabilityValueEffecto.ReduceValorByFatigue(num10, applyableFatigueMod, out num11);
				num9 = Mathf.Clamp(num9, 0f, 100f);
				if (Mathf.Max(componentEnRoot.consentActual, num10) < num9)
				{
					num5 = Mathf.Min(0f, num5);
				}
				num12 = Mathf.Lerp(num5, -1f, applyableFatigueMod * ModByFatigue);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num12 = 0f;
			}
			return num12;
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00033CDC File Offset: 0x00031EDC
		public float AceptacionSexualOralSegunDeseosMax(float ModByFatigue, bool usePersonalityTraits)
		{
			float num12;
			try
			{
				SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, mainNonPlayerCharacter.stringID, 2f);
				float num;
				float num2;
				float num3;
				float num4;
				this.AceptacionSexualSegunDeseos(out num, out num2, out num3, out num4);
				float num5 = num;
				if (usePersonalityTraits)
				{
					float num6;
					float num7;
					float num8;
					RegistroDeFuncionesDeTrabajosDeModelaje.ObtenePersonalidadDeNonPlayer().GetPreferredTreatmentForClientsWeights(out num6, out num7, out num8);
					if (num7 <= 0f)
					{
						num5 = -1f;
					}
				}
				ConsentNecesario componentEnRoot = mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num9 = componentEnRoot.ParaConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, null, null, null);
				float num10 = BuffOnMinFavorabilityValueEffecto.SimularValor(this.GetDataInclusionesExplicitoOral(), componentEnRoot, new EmocionesFemeninasValues?(EmocionesFemeninasValues.emptyValid));
				float num11;
				num10 = BuffOnMinFavorabilityValueEffecto.ReduceValorByFatigue(num10, applyableFatigueMod, out num11);
				num9 = Mathf.Clamp(num9, 0f, 100f);
				if (Mathf.Max(componentEnRoot.consentActual, num10) < num9)
				{
					num5 = Mathf.Min(0f, num5);
				}
				num12 = Mathf.Lerp(num5, -1f, applyableFatigueMod * ModByFatigue);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num12 = 0f;
			}
			return num12;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00033DF4 File Offset: 0x00031FF4
		public float AceptacionSexualSegunDeseosMaxParaHandJob(float ModByFatigue, bool usePersonalityTraits)
		{
			float num12;
			try
			{
				SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, mainNonPlayerCharacter.stringID, 2f);
				float num;
				float num2;
				float num3;
				float num4;
				this.AceptacionSexualSegunDeseos(out num, out num2, out num3, out num4);
				float num5 = Mathf.Max(num4, Mathf.Max(num3, Mathf.Max(num, num2)));
				if (usePersonalityTraits)
				{
					float num6;
					float num7;
					float num8;
					RegistroDeFuncionesDeTrabajosDeModelaje.ObtenePersonalidadDeNonPlayer().GetPreferredTreatmentForClientsWeights(out num6, out num7, out num8);
					if (num7 <= 0f)
					{
						num5 = -1f;
					}
				}
				ConsentNecesario componentEnRoot = mainNonPlayerCharacter.GetComponentEnRoot(false);
				float num9 = componentEnRoot.ParaConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.manos, ParteQuePuedeEstimular.pene, null, null, null);
				float num10 = BuffOnMinFavorabilityValueEffecto.SimularValor(this.GetDataInclusionesExplicitoMassagesAndHandJob(), componentEnRoot, new EmocionesFemeninasValues?(EmocionesFemeninasValues.emptyValid));
				float num11;
				num10 = BuffOnMinFavorabilityValueEffecto.ReduceValorByFatigue(num10, applyableFatigueMod, out num11);
				num9 = Mathf.Clamp(num9, 0f, 100f);
				if (Mathf.Max(componentEnRoot.consentActual, num10) < num9)
				{
					num5 = Mathf.Min(0f, num5);
				}
				num12 = Mathf.Lerp(num5, -1f, applyableFatigueMod * ModByFatigue);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num12 = 0f;
			}
			return num12;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00033F20 File Offset: 0x00032120
		public float AceptacionTeasingSegunDeseosMax(float ModByFatigue, bool usePersonalityTraits)
		{
			float num9;
			try
			{
				SceneCharacter mainNonPlayerCharacter = AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter;
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, mainNonPlayerCharacter.stringID, 2f);
				float num;
				float num2;
				float num3;
				float num4;
				this.AceptacionTeasingSegunDeseos(out num, out num2, out num3, out num4);
				float num5 = Mathf.Max(num4, Mathf.Max(num3, Mathf.Max(num, num2)));
				if (usePersonalityTraits)
				{
					float num6;
					float num7;
					float num8;
					RegistroDeFuncionesDeTrabajosDeModelaje.ObtenePersonalidadDeNonPlayer().GetPreferredTreatmentForClientsWeights(out num6, out num7, out num8);
					if (num6 <= 0f)
					{
						num6 = -1f;
					}
				}
				num9 = Mathf.Lerp(num5, -1f, applyableFatigueMod * ModByFatigue);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num9 = 0f;
			}
			return num9;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00033FCC File Offset: 0x000321CC
		private void AceptacionSexualSegunDeseos(out float labiosW, out float senosW, out float vagW, out float assW)
		{
			Deseos deseos = RegistroDeFuncionesDeTrabajosDeModelaje.ObtenerDesesoDeNonPlayer();
			labiosW = deseos.valores.labiosModBySexThresholds;
			senosW = deseos.valores.senosModBySexThresholds;
			vagW = deseos.valores.entrepiernaModBySexThresholds;
			assW = deseos.valores.traseroModBySexThresholds;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00034014 File Offset: 0x00032214
		private void AceptacionTeasingSegunDeseos(out float labiosW, out float senosW, out float vagW, out float assW)
		{
			Deseos deseos = RegistroDeFuncionesDeTrabajosDeModelaje.ObtenerDesesoDeNonPlayer();
			labiosW = deseos.valores.labiosModByTeasingThresholds;
			senosW = deseos.valores.senosModByTeasingThresholds;
			vagW = deseos.valores.entrepiernaModByTeasingThresholds;
			assW = deseos.valores.traseroModByTeasingThresholds;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0003405C File Offset: 0x0003225C
		public void SelectBodyPart(string bodyPart)
		{
			try
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!Enum.TryParse<ParteDelCuerpoHumano>(bodyPart, out parteDelCuerpoHumano))
				{
					throw new InvalidOperationException();
				}
				DialogueLua.SetVariable("SELECTED_BODYPART", parteDelCuerpoHumano.ToString());
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x000340AC File Offset: 0x000322AC
		public string GetSelectedBodyPart()
		{
			string text;
			try
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!Enum.TryParse<ParteDelCuerpoHumano>(DialogueLua.GetVariable("SELECTED_BODYPART").AsString, out parteDelCuerpoHumano))
				{
					throw new InvalidOperationException();
				}
				text = parteDelCuerpoHumano.ToString();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0003410C File Offset: 0x0003230C
		public void RegistrarAceptoSpaMassageEn(string parteString)
		{
			try
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!Enum.TryParse<ParteDelCuerpoHumano>(parteString, out parteDelCuerpoHumano))
				{
					throw new InvalidOperationException();
				}
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner spaListiner in this.m_SpaListiners)
				{
					spaListiner.AceptoMassageEnParte(parteDelCuerpoHumano, this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00034184 File Offset: 0x00032384
		public void RegistrarAceptoSpaHappyEnding()
		{
			try
			{
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner spaListiner in this.m_SpaListiners)
				{
					spaListiner.AceptoHappyEnding(this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x000341EC File Offset: 0x000323EC
		public void RegistrarAceptoSpaGetOnTopEnding(float aceptacionOral, float aceptacionVaginal, float aceptacionAnal)
		{
			try
			{
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner spaListiner in this.m_SpaListiners)
				{
					spaListiner.AceptoGetOnTopEnding(aceptacionOral, aceptacionVaginal, aceptacionAnal, this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00034258 File Offset: 0x00032458
		public void AddListiner(RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner listiner)
		{
			this.m_SPListiners.Add(listiner);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00034267 File Offset: 0x00032467
		public void RemoveListiner(RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner listiner)
		{
			this.m_SPListiners.Remove(listiner);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00034278 File Offset: 0x00032478
		[LuaAutoRegister]
		public bool SP_CantidadDeMedicinasSuficiente()
		{
			bool flag;
			try
			{
				flag = LuaListUtility.Count("SP.MedicinasSelected") > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x000342B0 File Offset: 0x000324B0
		[LuaAutoRegister]
		public bool SP_PuedeSeleccionarMedicina(string medicina)
		{
			bool flag;
			try
			{
				flag = LuaListUtility.CanAdd("SP.MedicinasSelected", medicina, 3);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x000342E8 File Offset: 0x000324E8
		[LuaAutoRegister]
		public void SP_DeclararMedicina(string medicina)
		{
			try
			{
				LuaListUtility.AddUniqueWithLimit("SP.MedicinasSelected", medicina, 3);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0003431C File Offset: 0x0003251C
		[LuaAutoRegister]
		public void SP_DeclararCondicion(string condicion)
		{
			try
			{
				DialogueLua.SetVariable("SP.CondicionSelected", condicion);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00034350 File Offset: 0x00032550
		[LuaAutoRegister]
		public void SP_Diagnosticar(string diagnostico, string recetaModoS)
		{
			try
			{
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico spdiagnostico = Enum.Parse<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico>(diagnostico);
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo spdiagnosticoRecetaModo = Enum.Parse<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo>(recetaModoS);
				RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta spdiagnosticoReceta = RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta.None;
				string asString = DialogueLua.GetVariable("SP.MedicinasSelected").AsString;
				if (!LuaListUtility.IsLuaNullOrEmpty(asString))
				{
					foreach (string text in asString.Split('|', StringSplitOptions.None).ToList<string>())
					{
						spdiagnosticoReceta |= Enum.Parse<RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta>(text.ToString());
					}
				}
				string text2 = DialogueLua.GetVariable("SP.CondicionSelected").AsString;
				text2 = (LuaListUtility.IsLuaNullOrEmpty(text2) ? string.Empty : text2);
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner isplistiner in this.m_SPListiners)
				{
					isplistiner.HizoDiagnostico(spdiagnostico, text2, spdiagnosticoRecetaModo, spdiagnosticoReceta, this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			finally
			{
				DialogueLua.SetVariable("SP.MedicinasSelected", string.Empty);
				DialogueLua.SetVariable("SP.CondicionSelected", string.Empty);
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00034494 File Offset: 0x00032694
		[LuaAutoRegister]
		public int SP_EsLvl()
		{
			int num;
			try
			{
				num = AsyncSingleton<JobsManager>.instance.current.lvl;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x000344D0 File Offset: 0x000326D0
		[LuaAutoRegister]
		public bool SP_PuedeInyectar()
		{
			bool flag;
			try
			{
				flag = (AsyncSingleton<JobsManager>.instance.current as StandardizedPatientJob).doctorLvl > 0.666f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00034518 File Offset: 0x00032718
		[LuaAutoRegister]
		public int SP_ExamenTipoZona()
		{
			int num;
			try
			{
				int asInt = DialogueLua.GetVariable("TVALLE.SP.EXAMEN_SELECTED").AsInt;
				switch (asInt)
				{
				case 0:
				case 3:
				case 5:
					num = 0;
					break;
				case 1:
					num = 1;
					break;
				case 2:
				case 4:
					num = 2;
					break;
				case 6:
				case 8:
				case 10:
				case 12:
				case 14:
					num = 4;
					break;
				case 7:
				case 9:
				case 11:
				case 13:
				case 15:
					num = 3;
					break;
				default:
					Debug.LogError("no se encontro categoria para examen " + asInt.ToString());
					num = 0;
					break;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x000345CC File Offset: 0x000327CC
		[LuaAutoRegister]
		public void SP_EnvioACamilla()
		{
			try
			{
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner isplistiner in this.m_SPListiners)
				{
					isplistiner.EnvioACamilla(this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00034634 File Offset: 0x00032834
		[LuaAutoRegister]
		public void RegistrarSP_Espiar(bool quiereEspiar)
		{
			try
			{
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner isplistiner in this.m_SPListiners)
				{
					isplistiner.SeleccionoEspionaje(quiereEspiar, this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0003469C File Offset: 0x0003289C
		[LuaAutoRegister]
		public void RegistrarSP_Examen(float examenIDf)
		{
			try
			{
				int num = Mathf.RoundToInt(examenIDf);
				DialogueLua.SetVariable("TVALLE.SP.EXAMEN_SELECTED", num);
				foreach (RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner isplistiner in this.m_SPListiners)
				{
					isplistiner.SeleccionoExamen(num, this);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0003471C File Offset: 0x0003291C
		[LuaAutoRegister]
		public int GetSP_Examen()
		{
			int num;
			try
			{
				num = DialogueLua.GetVariable("TVALLE.SP.EXAMEN_SELECTED").AsInt;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = -1;
			}
			return num;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0003475C File Offset: 0x0003295C
		public bool ConversantConoceEmpleador()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				MemoriaDeCharacterGeneralPermanente memoriaDeCharacterGeneralPermanente = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString);
				MemoriaDeCharacterGeneralTemporal memoriaDeCharacterGeneralTemporal = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(asString);
				flag = memoriaDeCharacterGeneralPermanente.ConoceACurrentMainCharacter() || memoriaDeCharacterGeneralTemporal.ConoceACurrentMainCharacter();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x000347B8 File Offset: 0x000329B8
		public bool ConversantConoceCliente()
		{
			return this.ConversantConoceEmpleador();
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000347C0 File Offset: 0x000329C0
		public bool ConversantConoceEmpleadorComoEmpleador()
		{
			bool flag;
			try
			{
				IContextMemory conversantMemoriaEnContextoDeTrabajo = RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo();
				string asString = DialogueLua.GetVariable("ActorID").AsString;
				flag = MemoriaDeSMAJobs.ConoceCharacterComoEmpleador(conversantMemoriaEnContextoDeTrabajo, asString, false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0003480C File Offset: 0x00032A0C
		public bool ConversantConocioOtroEmpleador()
		{
			bool flag;
			try
			{
				IContextMemory conversantMemoriaEnContextoDeTrabajo = RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo();
				string asString = DialogueLua.GetVariable("ActorID").AsString;
				flag = !MemoriaDeSMAJobs.CharacterEsCurrentEmpleador(conversantMemoriaEnContextoDeTrabajo, asString, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0003485C File Offset: 0x00032A5C
		public void RegistrarActorComoCurrentClientEnConversant()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				if (AsyncSingleton<JobsManager>.instance.current.nonPlayerCharacterWillRememberPlayerCharacter)
				{
					RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString).RegistrarCurrentMainCharacterComoConocido();
					IContextMemory conversantMemoriaEnContextoDeTrabajo = RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo();
					string asString2 = DialogueLua.GetVariable("ActorID").AsString;
					MemoriaDeSMAJobs.RegistrarCharacterComoCliente(conversantMemoriaEnContextoDeTrabajo, asString2);
					MemoriaDeSMAJobs.RegistrarCharacterComoLastClient(conversantMemoriaEnContextoDeTrabajo, asString2);
				}
				else
				{
					RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(asString).RegistrarCurrentMainCharacterComoConocido();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x000348E4 File Offset: 0x00032AE4
		public void RegistrarActorComoCurrentEmpleadorEnConversant()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				if (AsyncSingleton<JobsManager>.instance.current.nonPlayerCharacterWillRememberPlayerCharacter)
				{
					RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString).RegistrarCurrentMainCharacterComoConocido();
					IContextMemory conversantMemoriaEnContextoDeTrabajo = RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo();
					string asString2 = DialogueLua.GetVariable("ActorID").AsString;
					MemoriaDeSMAJobs.RegistrarCharacterComoEmpleador(conversantMemoriaEnContextoDeTrabajo, asString2);
					MemoriaDeSMAJobs.RegistrarCharacterComoCurrentEmpleador(conversantMemoriaEnContextoDeTrabajo, asString2);
				}
				else
				{
					RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(asString).RegistrarCurrentMainCharacterComoConocido();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0003496C File Offset: 0x00032B6C
		public bool FirstTimeDeConversant()
		{
			bool flag;
			try
			{
				flag = this.CantidadSesionesLaboralesDeConversant() == 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000349A0 File Offset: 0x00032BA0
		public int CantidadSesionesLaboralesDeConversant()
		{
			int num;
			try
			{
				num = MemoriaDeSMAJobs.SesionesLaboralesDeCharacter(RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo(), 0);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x000349D8 File Offset: 0x00032BD8
		public void RegistrarSesionesLaboralEnConversant()
		{
			try
			{
				MemoriaDeSMAJobs.RegistrarNewSesionesLaboralDeCharacter(RegistroDeFuncionesDeTrabajosDeModelaje.GetConversantMemoriaEnContextoDeTrabajo());
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00034A0C File Offset: 0x00032C0C
		public void TerminarJobSelf(object reaccionObj)
		{
			try
			{
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(reaccionObj.ToString(), out reaccionHumana))
				{
					Debug.LogException(new InvalidOperationException(), this);
				}
				else
				{
					this.ModelDespachadaSelf(reaccionHumana);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00034A58 File Offset: 0x00032C58
		public void TerminarJobUser()
		{
			try
			{
				DialogueManager.Instance.StopConversation();
				AsyncSingleton<JobsManager>.instance.EndCurrentJob(null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00034A94 File Offset: 0x00032C94
		public void ModelDespachada()
		{
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00034A98 File Offset: 0x00032C98
		public void ModelDespachadaSelf(ReaccionHumana reaccion)
		{
			SceneCharacter currentFemaleCharacter = RegistroDeFuncionesDeTrabajosDeModelaje.ObtenerSceneCharacter(DialogueLua.GetVariable("ConversantID").AsString);
			CameraFade.FadeOutMain(1f);
			GlobalUpdater.instancia.Invokar(delegate
			{
				currentFemaleCharacter.gameObject.SetActive(false);
			}, 1.1f);
			GlobalUpdater.instancia.Invokar(delegate
			{
				CameraFade.FadeInMain(1f);
			}, 1.2f);
		}

		// Token: 0x040004BF RID: 1215
		private HashSet<RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner> m_SpaListiners = new HashSet<RegistroDeFuncionesDeTrabajosDeModelaje.ISpaListiner>();

		// Token: 0x040004C0 RID: 1216
		public const string SelectedBodyPartVarName = "SELECTED_BODYPART";

		// Token: 0x040004C1 RID: 1217
		private HashSet<RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner> m_SPListiners = new HashSet<RegistroDeFuncionesDeTrabajosDeModelaje.ISPListiner>();

		// Token: 0x040004C2 RID: 1218
		private const string MedicinasSelectedName = "SP.MedicinasSelected";

		// Token: 0x040004C3 RID: 1219
		private const string CondicionSelectedName = "SP.CondicionSelected";

		// Token: 0x040004C4 RID: 1220
		public const int maxCantidadDeMedicidas = 3;

		// Token: 0x02000272 RID: 626
		public interface ISpaListiner
		{
			// Token: 0x06001140 RID: 4416
			void AceptoMassageEnParte(ParteDelCuerpoHumano parte, RegistroDeFuncionesDeTrabajosDeModelaje sender);

			// Token: 0x06001141 RID: 4417
			void AceptoHappyEnding(RegistroDeFuncionesDeTrabajosDeModelaje sender);

			// Token: 0x06001142 RID: 4418
			void AceptoGetOnTopEnding(float aceptacionOral, float aceptacionVaginal, float aceptacionAnal, RegistroDeFuncionesDeTrabajosDeModelaje sender);
		}

		// Token: 0x02000273 RID: 627
		public interface ISPListiner
		{
			// Token: 0x06001143 RID: 4419
			void SeleccionoExamen(int examenID, RegistroDeFuncionesDeTrabajosDeModelaje sender);

			// Token: 0x06001144 RID: 4420
			void EnvioACamilla(RegistroDeFuncionesDeTrabajosDeModelaje sender);

			// Token: 0x06001145 RID: 4421
			void SeleccionoEspionaje(bool quiereEspiar, RegistroDeFuncionesDeTrabajosDeModelaje sender);

			// Token: 0x06001146 RID: 4422
			void HizoDiagnostico(RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnostico diagnostico, string ComoCondicionMedicaID, RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoRecetaModo recetaModo, RegistroDeFuncionesDeTrabajosDeModelaje.SPDiagnosticoReceta recetas, RegistroDeFuncionesDeTrabajosDeModelaje sender);
		}

		// Token: 0x02000274 RID: 628
		[Flags]
		public enum SPDiagnosticoRecetaModo
		{
			// Token: 0x04000B7B RID: 2939
			None = 0,
			// Token: 0x04000B7C RID: 2940
			oral = 1,
			// Token: 0x04000B7D RID: 2941
			inyectable = 2
		}

		// Token: 0x02000275 RID: 629
		[Flags]
		public enum SPDiagnosticoReceta
		{
			// Token: 0x04000B7F RID: 2943
			None = 0,
			// Token: 0x04000B80 RID: 2944
			sexHormones = 1,
			// Token: 0x04000B81 RID: 2945
			stressVitamines = 2,
			// Token: 0x04000B82 RID: 2946
			estrogenos = 4,
			// Token: 0x04000B83 RID: 2947
			hormonaCrecimiento = 8,
			// Token: 0x04000B84 RID: 2948
			quemadorasDeGrasa = 16,
			// Token: 0x04000B85 RID: 2949
			aumentadorDeApetito = 32,
			// Token: 0x04000B86 RID: 2950
			Analgesic = 64,
			// Token: 0x04000B87 RID: 2951
			AntiInflammatory = 128,
			// Token: 0x04000B88 RID: 2952
			Antibiotic = 256,
			// Token: 0x04000B89 RID: 2953
			Laxative = 512,
			// Token: 0x04000B8A RID: 2954
			Antispasmodic = 1024,
			// Token: 0x04000B8B RID: 2955
			Antipyretic = 2048,
			// Token: 0x04000B8C RID: 2956
			Diuretic = 4096,
			// Token: 0x04000B8D RID: 2957
			Vasoconstrictor = 8192
		}

		// Token: 0x02000276 RID: 630
		public enum SPDiagnostico
		{
			// Token: 0x04000B8F RID: 2959
			sana,
			// Token: 0x04000B90 RID: 2960
			inconcluso,
			// Token: 0x04000B91 RID: 2961
			condicion
		}
	}
}

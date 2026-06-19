using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.DialogueSystem
{
	// Token: 0x020000D7 RID: 215
	public class RegistroDeFuncionesDeMandarAOtraAgencia : AplicableCustomMonobehaviour
	{
		// Token: 0x060007DF RID: 2015 RVA: 0x0002D7D8 File Offset: 0x0002B9D8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0002D7E0 File Offset: 0x0002B9E0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("YaHabiaQueridoEnviarlaALaMismaAgenciaAntes", this, base.GetType().GetMethod("YaHabiaQueridoEnviarlaALaMismaAgenciaAntes"));
			Lua.RegisterFunction("NombreDeLaAgenciaSeleccionadaParaEnviarla", this, base.GetType().GetMethod("NombreDeLaAgenciaSeleccionadaParaEnviarla"));
			Lua.RegisterFunction("CalcularProbDeIrAAgenciaSeleccionada", this, base.GetType().GetMethod("CalcularProbDeIrAAgenciaSeleccionada"));
			Lua.RegisterFunction("IrAAgenciaEsConsentido", this, base.GetType().GetMethod("IrAAgenciaEsConsentido"));
			Lua.RegisterFunction("ProcDeQuererIrAAgencia", this, base.GetType().GetMethod("ProcDeQuererIrAAgencia"));
			Lua.RegisterFunction("TipoDePersonajeDeAgenciaEsPlural", this, base.GetType().GetMethod("TipoDePersonajeDeAgenciaEsPlural"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion3Persona", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion3Persona"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPasado", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPasado"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPresente", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPresente"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion3Persona", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion3Persona"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPasado", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPasado"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPresente", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPresente"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion3Persona", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion3Persona"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPasado", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPasado"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPresente", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPresente"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion3Persona", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion3Persona"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPasado", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPasado"));
			Lua.RegisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPresente", this, base.GetType().GetMethod("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPresente"));
			Lua.RegisterFunction("RespuestaDeAgenciaTipoDePersonajeEntimulante", this, base.GetType().GetMethod("RespuestaDeAgenciaTipoDePersonajeEntimulante"));
			Lua.RegisterFunction("RespuestaDeAgenciaTipoDePersonajeEntimulanteWithIndefiniteArticle", this, base.GetType().GetMethod("RespuestaDeAgenciaTipoDePersonajeEntimulanteWithIndefiniteArticle"));
			Lua.RegisterFunction("ResgistrarPreguntoSiEsApta", this, base.GetType().GetMethod("ResgistrarPreguntoSiEsApta"));
			Lua.RegisterFunction("LeerPreguntoSiEsApta", this, base.GetType().GetMethod("LeerPreguntoSiEsApta"));
			Lua.RegisterFunction("ModeloSeraAceptadaPorAgenciaSeleccionada", this, base.GetType().GetMethod("ModeloSeraAceptadaPorAgenciaSeleccionada"));
			Lua.RegisterFunction("ModeloForzadaAIrAAgencia", this, base.GetType().GetMethod("ModeloForzadaAIrAAgencia"));
			Lua.RegisterFunction("ModeloDespachadaAAgencia", this, base.GetType().GetMethod("ModeloDespachadaAAgencia"));
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0002DB04 File Offset: 0x0002BD04
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("YaHabiaQueridoEnviarlaALaMismaAgenciaAntes");
			Lua.UnregisterFunction("NombreDeLaAgenciaSeleccionadaParaEnviarla");
			Lua.UnregisterFunction("CalcularProbDeIrAAgenciaSeleccionada");
			Lua.UnregisterFunction("IrAAgenciaEsConsentido");
			Lua.UnregisterFunction("ProcDeQuererIrAAgencia");
			Lua.UnregisterFunction("TipoDePersonajeDeAgenciaEsPlural");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion3Persona");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPasado");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPresente");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion3Persona");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPasado");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPresente");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion3Persona");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPasado");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPresente");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion3Persona");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPasado");
			Lua.UnregisterFunction("RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPresente");
			Lua.UnregisterFunction("RespuestaDeAgenciaTipoDePersonajeEntimulante");
			Lua.UnregisterFunction("RespuestaDeAgenciaTipoDePersonajeEntimulanteWithIndefiniteArticle");
			Lua.UnregisterFunction("ResgistrarPreguntoSiEsApta");
			Lua.UnregisterFunction("LeerPreguntoSiEsApta");
			Lua.UnregisterFunction("ModeloSeraAceptadaPorAgenciaSeleccionada");
			Lua.UnregisterFunction("ModeloForzadaAIrAAgencia");
			Lua.UnregisterFunction("ModeloDespachadaAAgencia");
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002DC3C File Offset: 0x0002BE3C
		public void ModeloDespachadaAAgencia()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				string asString2 = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				Guid guid = Guid.Parse(asString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeCharacterGeneralPermanente memoriaDeCharacterGeneralPermanente = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString);
				IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias/" + asString2, true);
				jsonMemoryNode.AddData("Used", true, true);
				Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(asString2);
				string text = "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				bool flag = MemoriaDeCharacterBase.LeerDeepBoolean(memoriaDeCharacterGeneralPermanente, text, "Consentida", false);
				float num = MemoriaDeCharacterBase.LeerDeepFloat(memoriaDeCharacterGeneralPermanente, text, "DudaProc", 0f);
				OtrasAgencias instance = Singleton<OtrasAgencias>.instance;
				bool flag2 = flag || num.OutPow(2f).ProcMod(1f);
				EmailModelResponseFromAgencyEvento emailModelResponseFromAgencyEvento = new EmailModelResponseFromAgencyEvento();
				emailModelResponseFromAgencyEvento.agencyID = asString2;
				emailModelResponseFromAgencyEvento.id = asString;
				emailModelResponseFromAgencyEvento.nombre = agencia.nombre;
				emailModelResponseFromAgencyEvento.showMessageOnStart = false;
				emailModelResponseFromAgencyEvento.startDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual + new TimeSpan(1, 0, 0, 0);
				emailModelResponseFromAgencyEvento.endDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual + new TimeSpan(8, 0, 0, 0);
				if (!flag2)
				{
					emailModelResponseFromAgencyEvento.msg = instance.GetMsgModeloNoAsistio(asString2, asString);
					emailModelResponseFromAgencyEvento.incomeChangeWithAgencyBuffID = null;
					emailModelResponseFromAgencyEvento.bonusDesblokeados = new List<string>();
					emailModelResponseFromAgencyEvento.acepted = false;
					emailModelResponseFromAgencyEvento.incomeEfectoID = null;
					emailModelResponseFromAgencyEvento.incomeEfectoArgID = null;
					emailModelResponseFromAgencyEvento.incomeEfectoArg = null;
				}
				else
				{
					AgenciasHelper.ModeloEsAceptadaPorAgencia(character, agencia, jsonMemoryNode, ref this.m_respuestaDeModeloSeraAceptada);
					string text2;
					string text3;
					if (this.m_respuestaDeModeloSeraAceptada.esAceptada)
					{
						text2 = instance.incomeChangeBuffAndDebuff.smallIncrease;
						text3 = instance.incomeChangeBuffAndDebuff.increase;
					}
					else
					{
						text2 = instance.incomeChangeBuffAndDebuff.smallDecrease;
						text3 = instance.incomeChangeBuffAndDebuff.decrease;
					}
					emailModelResponseFromAgencyEvento.acepted = this.m_respuestaDeModeloSeraAceptada.esAceptada;
					if (emailModelResponseFromAgencyEvento.acepted)
					{
						emailModelResponseFromAgencyEvento.incomeEfectoID = Efecto<AgencyEarningsEfecto, AgencyEarningsArg>.ID;
						emailModelResponseFromAgencyEvento.incomeEfectoArgID = Efecto<AgencyEarningsEfecto, AgencyEarningsArg>.ID_Arg;
						emailModelResponseFromAgencyEvento.incomeEfectoArg = new AgencyEarningsArg
						{
							income = agencia.incomeConfig.defaultIncome,
							bonusMod = agencia.incomeConfig.bonusMod,
							antiBonusMod = agencia.incomeConfig.antiBonusMod,
							bonuses = this.m_respuestaDeModeloSeraAceptada.bonusesActivados.Count,
							antiBonuses = this.m_respuestaDeModeloSeraAceptada.antiBonusesActivados.Count
						};
					}
					else
					{
						emailModelResponseFromAgencyEvento.incomeEfectoID = null;
						emailModelResponseFromAgencyEvento.incomeEfectoArgID = null;
						emailModelResponseFromAgencyEvento.incomeEfectoArg = null;
					}
					int rewardTier = agencia.incomeConfig.rewardTier;
					if (rewardTier != 0)
					{
						if (rewardTier != 1)
						{
							throw new ArgumentOutOfRangeException(agencia.incomeConfig.rewardTier.ToString());
						}
						emailModelResponseFromAgencyEvento.incomeChangeWithAgencyBuffID = text3;
					}
					else
					{
						emailModelResponseFromAgencyEvento.incomeChangeWithAgencyBuffID = text2;
					}
					emailModelResponseFromAgencyEvento.msg = instance.GetMsgModelo(asString2, asString, this.m_respuestaDeModeloSeraAceptada);
					IEnumerable<string> enumerable = from b in this.m_respuestaDeModeloSeraAceptada.bonusesActivados
						where !b.estaDesblokeado
						select b.bonus.rutaV2;
					IEnumerable<string> enumerable2 = from b in this.m_respuestaDeModeloSeraAceptada.antiBonusesActivados
						where !b.estaDesblokeado
						select b.bonus.rutaV2;
					emailModelResponseFromAgencyEvento.bonusDesblokeados = enumerable.Concat(enumerable2).Distinct<string>().ToList<string>();
				}
				string asString3 = DialogueLua.GetVariable("ActorID").AsString;
				Singleton<CharacteresActivos>.instance.Obtener<Character>(asString3).GetComponentEnRoot<EmailsInbox>().eventos.Add(emailModelResponseFromAgencyEvento, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			finally
			{
				this.m_respuestaDeModeloSeraAceptada.Clear();
			}
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002E098 File Offset: 0x0002C298
		public bool ModeloSeraAceptadaPorAgenciaSeleccionada()
		{
			bool flag;
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				string asString2 = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				Guid guid = Guid.Parse(asString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(asString2);
				AgenciasHelper.ModeloEsAceptadaPorAgencia(character, agencia, null, ref this.m_respuestaDeModeloSeraAceptada);
				flag = this.m_respuestaDeModeloSeraAceptada.esAceptada;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			finally
			{
				this.m_respuestaDeModeloSeraAceptada.Clear();
			}
			return flag;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002E138 File Offset: 0x0002C338
		public bool YaHabiaQueridoEnviarlaALaMismaAgenciaAntes()
		{
			bool flag;
			try
			{
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(DialogueLua.GetVariable("ConversantID").AsString), "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString, "Ofertada", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0002E1A4 File Offset: 0x0002C3A4
		public string NombreDeLaAgenciaSeleccionadaParaEnviarla()
		{
			string text;
			try
			{
				text = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_NAME").AsString;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0002E1E8 File Offset: 0x0002C3E8
		public void CalcularProbDeIrAAgenciaSeleccionada()
		{
			try
			{
				string asString = DialogueLua.GetVariable("ConversantID").AsString;
				string asString2 = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				Guid guid = Guid.Parse(asString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				MemoriaDeCharacterGeneralPermanente memoriaDeCharacterGeneralPermanente = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(asString);
				Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(asString2);
				Agencia.AI.Par par;
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				float num;
				float num2;
				float num3;
				float num4;
				float num5;
				bool flag;
				bool flag2;
				AgenciasHelper.ModeloQuiereIrAgencia(character, agencia, out par, out parteDelCuerpoHumano, out num, out num2, out num3, out num4, out num5, out flag, out flag2);
				float num6 = Mathf.InverseLerp(0.5f, 1f, num2);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_CONSENTIDA", flag2);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_CONSENT_PROC", num6);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE", (int)par.tipoDePersonaje);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TIPO_ESTIMULO", (int)par.tipoDeEstimulo);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TIPO_DIRECCION", (int)par.direccion);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_USE_ESTIMULADA", par.estimuladas.Count > 0);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_ESTIMULADA", (int)parteDelCuerpoHumano);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_ESTIMULANTE", (int)par.estimulante);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TIPO_RESPUESTA", (int)par.tipoDeRespuesta);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TAG", par.tag);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE_PLURAL", par.TipoDePersonajeEsPlural);
				string text = "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				MemoriaDeCharacterBase.RegistrarDeep(memoriaDeCharacterGeneralPermanente, text, "Ofertada", true);
				MemoriaDeCharacterBase.RegistrarDeep(memoriaDeCharacterGeneralPermanente, text, "Consentida", flag2);
				MemoriaDeCharacterBase.RegistrarDeep(memoriaDeCharacterGeneralPermanente, text, "DudaProc", num6);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0002E3C4 File Offset: 0x0002C5C4
		public bool IrAAgenciaEsConsentido()
		{
			bool flag;
			try
			{
				flag = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_CONSENTIDA").AsBool;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0002E404 File Offset: 0x0002C604
		public float ProcDeQuererIrAAgencia()
		{
			float num;
			try
			{
				num = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_CONSENT_PROC").AsFloat;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0002E448 File Offset: 0x0002C648
		public void ModeloForzadaAIrAAgencia()
		{
			try
			{
				MemoriaDeCharacterBase memoriaDeCharacterBase = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(DialogueLua.GetVariable("ConversantID").AsString);
				string text = "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				MemoriaDeCharacterBase.RegistrarDeep(memoriaDeCharacterBase, text, "DudaProc", 1);
				DialogueLua.SetVariable("SELECTED_AGENCY_BY_USER_CONSENT_PROC", 1);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0002E4C0 File Offset: 0x0002C6C0
		public bool TipoDePersonajeDeAgenciaEsPlural()
		{
			bool flag;
			try
			{
				flag = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE_PLURAL").AsBool;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0002E500 File Offset: 0x0002C700
		public string RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0002E554 File Offset: 0x0002C754
		public string RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccion3Persona()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002E5A8 File Offset: 0x0002C7A8
		public string RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPasado()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002E5FC File Offset: 0x0002C7FC
		public string RespuestaAccionParteEstimuladaNegativaGroseraDeAgenciaAccionPresente()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0002E650 File Offset: 0x0002C850
		public string RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0002E6A4 File Offset: 0x0002C8A4
		public string RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccion3Persona()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0002E6F8 File Offset: 0x0002C8F8
		public string RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPasado()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0002E74C File Offset: 0x0002C94C
		public string RespuestaAccionParteEstimuladaNegativaTimidaDeAgenciaAccionPresente()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0002E7A0 File Offset: 0x0002C9A0
		public string RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002E7F4 File Offset: 0x0002C9F4
		public string RespuestaAccionParteEstimuladaNegativaDeAgenciaAccion3Persona()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002E848 File Offset: 0x0002CA48
		public string RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPasado()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002E89C File Offset: 0x0002CA9C
		public string RespuestaAccionParteEstimuladaNegativaDeAgenciaAccionPresente()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.rabia, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002E8F0 File Offset: 0x0002CAF0
		public string RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.placer, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0002E944 File Offset: 0x0002CB44
		public string RespuestaAccionParteEstimuladaPositivaDeAgenciaAccion3Persona()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.placer, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0002E998 File Offset: 0x0002CB98
		public string RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPasado()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.placer, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0002E9EC File Offset: 0x0002CBEC
		public string RespuestaAccionParteEstimuladaPositivaDeAgenciaAccionPresente()
		{
			string text;
			try
			{
				text = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, ReaccionHumana.placer, true, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0002EA40 File Offset: 0x0002CC40
		[Obsolete("si pregunta por confirmacion se puede volver tedioso para el jugador")]
		public void ResgistrarPreguntoSiEsApta()
		{
			try
			{
				MemoriaDeCharacterBase memoriaDeCharacterBase = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(DialogueLua.GetVariable("ConversantID").AsString);
				string text = "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				MemoriaDeCharacterBase.RegistrarDeep(memoriaDeCharacterBase, text, "Puedo", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0002EAA8 File Offset: 0x0002CCA8
		[Obsolete("si pregunta por confirmacion se puede volver tedioso para el jugador")]
		public bool LeerPreguntoSiEsApta()
		{
			bool flag;
			try
			{
				MemoriaDeCharacterBase memoriaDeCharacterBase = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(DialogueLua.GetVariable("ConversantID").AsString);
				string text = "Agencias/" + DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ID").AsString;
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(memoriaDeCharacterBase, text, "Puedo", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002EB14 File Offset: 0x0002CD14
		private static Personalidad.TipoDeRespuestaDeDialogoDeHeroina ObtenerTipoDeRespuestaDeConversant()
		{
			return RegistroDeFuncionesDeAI.MaxTipoDePersonalidadDeConversantStatic(new Personalidad.Tipo[]
			{
				Personalidad.Tipo.timido,
				Personalidad.Tipo.extrovertido,
				Personalidad.Tipo.pervertido,
				Personalidad.Tipo.respetuoso,
				Personalidad.Tipo.grosero
			}).Parse();
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0002EB34 File Offset: 0x0002CD34
		public string RespuestaDeAgenciaTipoDePersonajeEntimulanteWithIndefiniteArticle()
		{
			string text2;
			try
			{
				string text = this.RespuestaDeAgenciaTipoDePersonajeEntimulante();
				if (!DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE_PLURAL").AsBool)
				{
					if ("aeiouAEIOU".IndexOf(text.First<char>()) >= 0)
					{
						text2 = "an " + text;
					}
					else
					{
						text2 = "a " + text;
					}
				}
				else
				{
					text2 = text;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0002EBB0 File Offset: 0x0002CDB0
		public string RespuestaDeAgenciaTipoDePersonajeEntimulante()
		{
			string text;
			try
			{
				bool asBool = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE_PLURAL").AsBool;
				TipoDePersonaje asInt = (TipoDePersonaje)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_PERSONAJE").AsInt;
				text = Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.ObtenerDialogoTipoDePersonaje(asInt, asBool);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0002EC14 File Offset: 0x0002CE14
		private static string ObtenerDialogo(Object contexto, DialogosLocalizadosGenericos sinCosaPropia, DialogosLocalizadosGenericos conCosaPropia, ObtenerDialogosUtil Util, ReaccionHumana reaccionHumana, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			DialogosLocalizadosGenericos dialogosLocalizadosGenericos = (DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_USE_ESTIMULADA").AsBool ? conCosaPropia : sinCosaPropia);
			return RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(contexto, dialogosLocalizadosGenericos, Util, reaccionHumana, ignorarRedundancia, ignorarContextoErrado);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0002EC48 File Offset: 0x0002CE48
		private static string ObtenerDialogo(Object contexto, DialogosLocalizadosGenericos lista, ObtenerDialogosUtil Util, ReaccionHumana reaccionHumana, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
			TipoDeEstimulo asInt = (TipoDeEstimulo)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_ESTIMULO").AsInt;
			DireccionDeEstimulo asInt2 = (DireccionDeEstimulo)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_DIRECCION").AsInt;
			ParteDelCuerpoHumano asInt3 = (ParteDelCuerpoHumano)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ESTIMULADA").AsInt;
			ParteQuePuedeEstimular asInt4 = (ParteQuePuedeEstimular)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_ESTIMULANTE").AsInt;
			string asString = DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TAG").AsString;
			return RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerDialogo(contexto, lista, Util, character, reaccionHumana, asInt2, asInt, asInt3, asInt4, asString, ignorarRedundancia, ignorarContextoErrado);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0002ECF8 File Offset: 0x0002CEF8
		private static string ObtenerDialogo(Object contexto, DialogosLocalizadosGenericos lista, ObtenerDialogosUtil Util, Character modelo, ReaccionHumana reaccionHumana, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)DialogueLua.GetVariable("SELECTED_AGENCY_BY_USER_TIPO_RESPUESTA").AsInt;
			if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
			{
				tipoDeRespuestaDeDialogoDeHeroina = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerTipoDeRespuestaDeConversant();
			}
			return GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogo(contexto, lista, Util, modelo, reaccionHumana, direccion, tipoDeEstimulo, estimulada, estimulante, tag, ignorarRedundancia, ignorarContextoErrado, tipoDeRespuestaDeDialogoDeHeroina);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0002ED3B File Offset: 0x0002CF3B
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			if (DialogueManager.IsConversationActive)
			{
				return null;
			}
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "print all agency dialogues"
			};
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0002ED60 File Offset: 0x0002CF60
		protected override void OnAplicar()
		{
			base.OnAplicar();
			Character current = TargetChar.current;
			DialogueLua.SetVariable("ConversantID", current.ID_Unico.ToString());
			ReaccionHumana[] array = new ReaccionHumana[]
			{
				ReaccionHumana.rabia,
				ReaccionHumana.placer
			};
			HashSet<string> hashSet = new HashSet<string>();
			foreach (ReaccionHumana reaccionHumana in array)
			{
				foreach (Agencia agencia in Singleton<OtrasAgencias>.instance.agencias)
				{
					foreach (Agencia.AI.Par par in agencia.aI.equivalentes)
					{
						string text = Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.ObtenerDialogoTipoDePersonaje(par.tipoDePersonaje, par.TipoDePersonajeEsPlural);
						Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = par.tipoDeRespuesta;
						if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
						{
							tipoDeRespuestaDeDialogoDeHeroina = RegistroDeFuncionesDeMandarAOtraAgencia.ObtenerTipoDeRespuestaDeConversant();
						}
						if (par.estimuladas.Count > 0)
						{
							using (List<ParteDelCuerpoHumano>.Enumerator enumerator3 = par.estimuladas.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									ParteDelCuerpoHumano parteDelCuerpoHumano = enumerator3.Current;
									string text2 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, true, parteDelCuerpoHumano, par.estimulante, par.tag, false, false);
									hashSet.Add(string.Concat(new string[] { text2, " Por: ", text, " agencia: ", agencia.ID }));
									string text3 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, true, parteDelCuerpoHumano, par.estimulante, par.tag, false, false);
									hashSet.Add(string.Concat(new string[] { text3, " Por: ", text, " agencia: ", agencia.ID }));
									string text4 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, true, parteDelCuerpoHumano, par.estimulante, par.tag, true, true);
									hashSet.Add(string.Concat(new string[] { text4, " Por: ", text, " agencia: ", agencia.ID }));
									string text5 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, true, parteDelCuerpoHumano, par.estimulante, par.tag, false, false);
									hashSet.Add(string.Concat(new string[] { text5, " Por: ", text, " agencia: ", agencia.ID }));
								}
								continue;
							}
						}
						ParteDelCuerpoHumano parteDelCuerpoHumano2 = AgenciasHelper.ParteConMenosConsentNesesaria(current, par.tipoDeEstimulo, DireccionDeEstimulo.recibida, par.estimulante, par.tag);
						string text6 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, false, parteDelCuerpoHumano2, par.estimulante, par.tag, false, false);
						hashSet.Add(string.Concat(new string[] { text6, " Por: ", text, " agencia: ", agencia.ID }));
						string text7 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, false, parteDelCuerpoHumano2, par.estimulante, par.tag, false, false);
						hashSet.Add(string.Concat(new string[] { text7, " Por: ", text, " agencia: ", agencia.ID }));
						string text8 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, false, parteDelCuerpoHumano2, par.estimulante, par.tag, true, true);
						hashSet.Add(string.Concat(new string[] { text8, " Por: ", text, " agencia: ", agencia.ID }));
						string text9 = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(this, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, current, tipoDeRespuestaDeDialogoDeHeroina, reaccionHumana, par.direccion, par.tipoDeEstimulo, false, parteDelCuerpoHumano2, par.estimulante, par.tag, false, false);
						hashSet.Add(string.Concat(new string[] { text9, " Por: ", text, " agencia: ", agencia.ID }));
					}
				}
			}
			foreach (string text10 in hashSet)
			{
				MonoBehaviour.print(text10);
			}
		}

		// Token: 0x04000494 RID: 1172
		[SerializeField]
		private ObtenerDialogosUtil m_ObtenerDialogosUtil = new ObtenerDialogosUtil();

		// Token: 0x04000495 RID: 1173
		[SerializeField]
		private AgenciasHelper.Respuesta m_respuestaDeModeloSeraAceptada = new AgenciasHelper.Respuesta();

		// Token: 0x0200026E RID: 622
		[Serializable]
		public class Par
		{
			// Token: 0x04000B70 RID: 2928
			public TipoDePersonaje tipoDePersonaje;

			// Token: 0x04000B71 RID: 2929
			public bool esMultiple;

			// Token: 0x04000B72 RID: 2930
			public DialogosLocalizadosDeTipoDeRespuesta respuestas;
		}
	}
}

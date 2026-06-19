using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Textos;
using PixelCrushers.DialogueSystem;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.Funciones
{
	// Token: 0x02000046 RID: 70
	public class RegistroDeFuncionesDeCambioDePose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000201 RID: 513 RVA: 0x00009D1C File Offset: 0x00007F1C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("PoseCambiarPlayerEsObstaculo", this, base.GetType().GetMethod("PoseCambiarPlayerEsObstaculo"));
			Lua.RegisterFunction("PoseCambiarHayObstaculo", this, base.GetType().GetMethod("PoseCambiarHayObstaculo"));
			Lua.RegisterFunction("CambioDePoseNombrePri", this, base.GetType().GetMethod("CambioDePoseNombrePri"));
			Lua.RegisterFunction("CambioDePoseNombreSeg", this, base.GetType().GetMethod("CambioDePoseNombreSeg"));
			Lua.RegisterFunction("PosePuedeCambiar", this, base.GetType().GetMethod("PosePuedeCambiar"));
			Lua.RegisterFunction("EstaAtadoEffector", this, base.GetType().GetMethod("EstaAtadoEffector"));
			Lua.RegisterFunction("EstaAtadoEffectorTodos", this, base.GetType().GetMethod("EstaAtadoEffectorTodos"));
			Lua.RegisterFunction("ParteAtadaPosesivoPri", this, base.GetType().GetMethod("ParteAtadaPosesivoPri"));
			Lua.RegisterFunction("ParteAtadaNombre", this, base.GetType().GetMethod("ParteAtadaNombre"));
			Lua.RegisterFunction("EsConsentidoCambioDePose", this, base.GetType().GetMethod("EsConsentidoCambioDePose"));
			Lua.RegisterFunction("AlgunaPoseConsentida", this, base.GetType().GetMethod("AlgunaPoseConsentida"));
			Lua.RegisterFunction("RegisDijoEstarAtadaTodas", this, base.GetType().GetMethod("RegisDijoEstarAtadaTodas"));
			Lua.RegisterFunction("DijoEstarAtadaTodas", this, base.GetType().GetMethod("DijoEstarAtadaTodas"));
			Lua.RegisterFunction("RegisDijoEstarAtada", this, base.GetType().GetMethod("RegisDijoEstarAtada"));
			Lua.RegisterFunction("DijoEstarAtada", this, base.GetType().GetMethod("DijoEstarAtada"));
			Lua.RegisterFunction("RegisDijoPoseNoConsentida", this, base.GetType().GetMethod("RegisDijoPoseNoConsentida"));
			Lua.RegisterFunction("DijoPoseNoConsentida", this, base.GetType().GetMethod("DijoPoseNoConsentida"));
			Lua.RegisterFunction("BorrarDijoPoseNoConsentida", this, base.GetType().GetMethod("BorrarDijoPoseNoConsentida"));
			Lua.RegisterFunction("RegisDijoPoseAceptada", this, base.GetType().GetMethod("RegisDijoPoseAceptada"));
			Lua.RegisterFunction("DijoPoseAceptada", this, base.GetType().GetMethod("DijoPoseAceptada"));
			Lua.RegisterFunction("RegisDijoPoseNingunaConsentida", this, base.GetType().GetMethod("RegisDijoPoseNingunaConsentida"));
			Lua.RegisterFunction("DijoPoseNingunaConsentida", this, base.GetType().GetMethod("DijoPoseNingunaConsentida"));
			Lua.RegisterFunction("BorrarDijoPoseNingunaConsentida", this, base.GetType().GetMethod("BorrarDijoPoseNingunaConsentida"));
			Lua.RegisterFunction("EsCustomPose", this, base.GetType().GetMethod("EsCustomPose"));
			Lua.RegisterFunction("EsoCosaLocalizadoPosing", this, base.GetType().GetMethod("EsoCosaLocalizadoPosing"));
			Lua.RegisterFunction("MiPartLocalizadoPosing", this, base.GetType().GetMethod("MiPartLocalizadoPosing"));
			Lua.RegisterFunction("TodasLasPeticionesDePosesConsentidas", this, base.GetType().GetMethod("TodasLasPeticionesDePosesConsentidas"));
			Lua.RegisterFunction("MiParteNoConsentidoLocalizado", this, base.GetType().GetMethod("MiParteNoConsentidoLocalizado"));
			Lua.RegisterFunction("PoseActualEsSobornada", this, base.GetType().GetMethod("PoseActualEsSobornada"));
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000A040 File Offset: 0x00008240
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("PoseCambiarPlayerEsObstaculo");
			Lua.UnregisterFunction("PoseCambiarHayObstaculo");
			Lua.UnregisterFunction("CambioDePoseNombrePri");
			Lua.UnregisterFunction("CambioDePoseNombreSeg");
			Lua.UnregisterFunction("PosePuedeCambiar");
			Lua.UnregisterFunction("EstaAtadoEffector");
			Lua.UnregisterFunction("EstaAtadoEffectorTodos");
			Lua.UnregisterFunction("ParteAtadaPosesivoPri");
			Lua.UnregisterFunction("ParteAtadaNombre");
			Lua.UnregisterFunction("EsConsentidoCambioDePose");
			Lua.UnregisterFunction("AlgunaPoseConsentida");
			Lua.UnregisterFunction("RegisDijoEstarAtadaTodas");
			Lua.UnregisterFunction("DijoEstarAtadaTodas");
			Lua.UnregisterFunction("RegisDijoEstarAtada");
			Lua.UnregisterFunction("DijoEstarAtada");
			Lua.UnregisterFunction("RegisDijoPoseNoConsentida");
			Lua.UnregisterFunction("DijoPoseNoConsentida");
			Lua.UnregisterFunction("BorrarDijoPoseNoConsentida");
			Lua.UnregisterFunction("RegisDijoPoseAceptada");
			Lua.UnregisterFunction("DijoPoseAceptada");
			Lua.UnregisterFunction("RegisDijoPoseNingunaConsentida");
			Lua.UnregisterFunction("DijoPoseNingunaConsentida");
			Lua.UnregisterFunction("BorrarDijoPoseNingunaConsentida");
			Lua.UnregisterFunction("EsCustomPose");
			Lua.UnregisterFunction("EsoCosaLocalizadoPosing");
			Lua.UnregisterFunction("MiPartLocalizadoPosing");
			Lua.UnregisterFunction("TodasLasPeticionesDePosesConsentidas");
			Lua.UnregisterFunction("MiParteNoConsentidoLocalizado");
			Lua.UnregisterFunction("PoseActualEsSobornada");
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000A178 File Offset: 0x00008378
		public string MiParteNoConsentidoLocalizado()
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString);
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
				string text;
				if (character is FemaleChar)
				{
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.femenino, parteDelCuerpoHumano);
				}
				else
				{
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.masculino, parteDelCuerpoHumano);
				}
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000A264 File Offset: 0x00008464
		public string EsoCosaLocalizadoPosing()
		{
			string text;
			try
			{
				text = ObtenerDialogosUtil.ObtenerEsoCosa(RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString), false).plural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000A2BC File Offset: 0x000084BC
		public string MiPartLocalizadoPosing()
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString);
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
				string text;
				if (character is FemaleChar)
				{
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.femenino, parteDelCuerpoHumano);
				}
				else
				{
					text = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.masculino, parteDelCuerpoHumano);
				}
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000A3A8 File Offset: 0x000085A8
		public bool TodasLasPeticionesDePosesConsentidas(string id)
		{
			bool flag2;
			try
			{
				Guid guid = Guid.Parse(id);
				ConsentNecesario componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentNecesario>();
				ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
				ParteDelCuerpoHumano? parteDelCuerpoHumano2 = null;
				ParteDelCuerpoHumano[] array = (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
					where p.EsFemenina()
					select p).ToArray<ParteDelCuerpoHumano>();
				float num;
				float? num2;
				bool flag = array.Length == 0 || componentInChildren.TodosConsentidosConJerarquia(array, TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, 1f, null, null, null);
				if (!flag)
				{
					DialogueLua.SetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA", parteDelCuerpoHumano.ToString());
					if (parteDelCuerpoHumano2 != null)
					{
						DialogueLua.SetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA", parteDelCuerpoHumano2.Value.ToString());
					}
					else
					{
						DialogueLua.SetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA", string.Empty);
					}
				}
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000A4C4 File Offset: 0x000086C4
		public bool EsCustomPose()
		{
			bool flag;
			try
			{
				int asInt = DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt;
				flag = asInt == InteraccionPrimariaName.customA.GetInteractionID() || asInt == InteraccionPrimariaName.customB.GetInteractionID();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000A51C File Offset: 0x0000871C
		public string CambioDePoseNombrePri(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				InteraccionStrings component = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerBase(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt)
					.instancia.GetComponent<InteraccionStrings>();
				if (component == null)
				{
					text = DialogueLua.GetVariable("SELECTED_POSE_TEXTO").AsString.ToLowerInvariant();
				}
				else
				{
					bool asBool = DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool;
					text = component.primera.CurrentTextLower(asBool);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000A5CC File Offset: 0x000087CC
		public string CambioDePoseNombreSeg(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				InteraccionStrings component = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerBase(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt)
					.instancia.GetComponent<InteraccionStrings>();
				if (component == null)
				{
					text = DialogueLua.GetVariable("SELECTED_POSE_TEXTO").AsString.ToLowerInvariant();
				}
				else
				{
					bool asBool = DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool;
					text = component.segunda.CurrentTextLower(asBool);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000A67C File Offset: 0x0000887C
		public bool PosePuedeCambiar(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				Interaccion interaccion;
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					flag = true;
				}
				else if (!character.GetComponentInChildren<IInteraccionesDeCharacter>().TryObtenerSiEsValida(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt, out interaccion))
				{
					flag = false;
				}
				else
				{
					flag = interaccion.PuedeEjecutarse();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000A704 File Offset: 0x00008904
		public string EstaAtadoEffector(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				Interaccion interaccion;
				FullBodyBipedEffector fullBodyBipedEffector;
				if (!character.GetComponentInChildren<IInteraccionesDeCharacter>().TryObtenerSiEsValida(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt, out interaccion))
				{
					text = null;
				}
				else if (!RegistroDeFuncionesDeCambioDePose.EnConflicto(character, interaccion, out fullBodyBipedEffector))
				{
					text = null;
				}
				else
				{
					text = fullBodyBipedEffector.ToString();
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = null;
			}
			return text;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000A78C File Offset: 0x0000898C
		public bool EstaAtadoEffectorTodos(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = RegistroDeFuncionesDeCambioDePose.EnConflictoTodos(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000A7D0 File Offset: 0x000089D0
		public string ParteAtadaPosesivoPri(string id, string effectorName)
		{
			string text;
			try
			{
				FullBodyBipedEffector fullBodyBipedEffector;
				if (!Enum.TryParse<FullBodyBipedEffector>(effectorName, out fullBodyBipedEffector))
				{
					fullBodyBipedEffector = FullBodyBipedEffector.Body;
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano = fullBodyBipedEffector.ParceAParteHumama();
				text = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parteDelCuerpoHumano).plural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000A828 File Offset: 0x00008A28
		public string ParteAtadaNombre(string id, string effectorName)
		{
			string text;
			try
			{
				FullBodyBipedEffector fullBodyBipedEffector;
				if (!Enum.TryParse<FullBodyBipedEffector>(effectorName, out fullBodyBipedEffector))
				{
					fullBodyBipedEffector = FullBodyBipedEffector.Body;
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano = fullBodyBipedEffector.ParceAParteHumama();
				text = Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parteDelCuerpoHumano).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, 1);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000A88C File Offset: 0x00008A8C
		public bool PoseActualEsSobornada()
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				IInteraccionesDeCharacter componentInChildren = character.GetComponentInChildren<IInteraccionesDeCharacter>();
				ConsentCorrupted consentCorrupted = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante();
				int asInt = DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt;
				InteraccionDeCharacter interaccionDeCharacter = componentInChildren.ObtenerBase(asInt);
				if (interaccionDeCharacter == null || interaccionDeCharacter.instancia == null)
				{
					Debug.LogWarning("Consentido ejecutar pose " + asInt.ToString() + " por que no existe pose en character.", character);
					flag = true;
				}
				else
				{
					InteraccionPersonalidadData component = interaccionDeCharacter.instancia.GetComponent<InteraccionPersonalidadData>();
					if (component == null)
					{
						Debug.LogWarning("Consentido ejecutar pose " + asInt.ToString() + " por que no existe InteraccionExponePartes en interaccion.", character);
						flag = true;
					}
					else
					{
						IReadOnlyList<ParteDelCuerpoHumano> readOnlyList;
						IReadOnlyCollection<int> readOnlyCollection;
						component.ObtenerExponiendoPartes(out readOnlyList, out readOnlyCollection, null);
						for (int i = 0; i < readOnlyList.Count; i++)
						{
							if (consentCorrupted.EsCorrupted(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, readOnlyList[i], ParteQuePuedeEstimular.boca, null))
							{
								return true;
							}
						}
						flag = false;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000A9D0 File Offset: 0x00008BD0
		public bool EsConsentidoCambioDePose(string id, bool modificarResultado)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
				IInteraccionesDeCharacter componentInChildren2 = character.GetComponentInChildren<IInteraccionesDeCharacter>();
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", true);
					flag = true;
				}
				else
				{
					ConsentNecesario componentInChildren3 = character.GetComponentInChildren<ConsentNecesario>();
					float num;
					ParteDelCuerpoHumano parteDelCuerpoHumano;
					float? num2;
					ParteDelCuerpoHumano? parteDelCuerpoHumano2;
					bool flag2 = RegistroDeFuncionesDeCambioDePose.EsConsentidoEjecutarPose(character, componentInChildren3, DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt, modificarResultado, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, componentInChildren, componentInChildren2);
					if (!flag2)
					{
						DialogueLua.SetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA", parteDelCuerpoHumano.ToString());
						if (parteDelCuerpoHumano2 != null)
						{
							DialogueLua.SetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA", parteDelCuerpoHumano2.Value.ToString());
						}
						else
						{
							DialogueLua.SetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA", string.Empty);
						}
					}
					DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", flag2);
					flag = flag2;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		public bool AlgunaPoseConsentida(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentNecesario>().AlgunoConsentidoSinJerarquia(TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000AB3C File Offset: 0x00008D3C
		public bool DijoEstarAtadaTodas(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().EstaRegistrardaDijoEstarAtadaTodas();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000AB84 File Offset: 0x00008D84
		public void RegisDijoEstarAtadaTodas(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().RegistrarDijoEstarAtadaTodas();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		public bool DijoEstarAtada(string id, string effectorName)
		{
			bool flag;
			try
			{
				FullBodyBipedEffector fullBodyBipedEffector = (FullBodyBipedEffector)Enum.Parse(typeof(FullBodyBipedEffector), effectorName);
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().EstaRegistrardaDijoEstarAtada(fullBodyBipedEffector);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000AC28 File Offset: 0x00008E28
		public void RegisDijoEstarAtada(string id, string effectorName)
		{
			try
			{
				FullBodyBipedEffector fullBodyBipedEffector = (FullBodyBipedEffector)Enum.Parse(typeof(FullBodyBipedEffector), effectorName);
				Guid guid = Guid.Parse(id);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().RegistrarDijoEstarAtada(fullBodyBipedEffector);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000AC84 File Offset: 0x00008E84
		public bool DijoPoseNoConsentida(string id)
		{
			bool flag2;
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeEjecutarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>();
				bool flag;
				if (this.EsCustomPose())
				{
					flag = componentInChildrenNotNull.EstaRegistrardaPoseNegadaV2(DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString);
				}
				else
				{
					flag = componentInChildrenNotNull.EstaRegistrardaPoseNegadaV2(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
				}
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000AD08 File Offset: 0x00008F08
		public void RegisDijoPoseNoConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeEjecutarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>();
				if (this.EsCustomPose())
				{
					componentInChildrenNotNull.RegistrarPoseNegadaV2(DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString);
				}
				else
				{
					componentInChildrenNotNull.RegistrarPoseNegadaV2(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000AD84 File Offset: 0x00008F84
		public void BorrarDijoPoseNoConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeEjecutarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>();
				if (this.EsCustomPose())
				{
					componentInChildrenNotNull.BorrarPoseNegadaV2(DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString);
				}
				else
				{
					componentInChildrenNotNull.BorrarPoseNegadaV2(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000AE00 File Offset: 0x00009000
		public bool DijoPoseAceptada(string id)
		{
			bool flag2;
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeEjecutarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>();
				bool flag;
				if (this.EsCustomPose())
				{
					flag = componentInChildrenNotNull.EstaRegistrardaPoseAceptadaV2(DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString);
				}
				else
				{
					flag = componentInChildrenNotNull.EstaRegistrardaPoseAceptadaV2(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
				}
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000AE84 File Offset: 0x00009084
		public void RegisDijoPoseAceptada(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeEjecutarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>();
				if (this.EsCustomPose())
				{
					componentInChildrenNotNull.RegistrarPoseAceptadaV2(DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString);
				}
				else
				{
					componentInChildrenNotNull.RegistrarPoseAceptadaV2(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000AF00 File Offset: 0x00009100
		public bool DijoPoseNingunaConsentida(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().EstaRegistrardaDijoTodasNegadas();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000AF48 File Offset: 0x00009148
		public void RegisDijoPoseNingunaConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().RegistrarDijoTodasNegadas();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000AF8C File Offset: 0x0000918C
		public void BorrarDijoPoseNingunaConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeEjecutarPose>().BorrarDijoTodasNegadas();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000AFD0 File Offset: 0x000091D0
		public bool PoseCambiarPlayerEsObstaculo(string id)
		{
			bool flag;
			try
			{
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					flag = false;
				}
				else
				{
					Guid guid = Guid.Parse(id);
					Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
					InteraccionDeCharacter interaccionDeCharacter = character.GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerBase(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
					InteraccionCheckers component = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null).GetComponent<InteraccionCheckers>();
					InteraccionChecker[] array;
					if (component == null)
					{
						array = null;
					}
					else
					{
						Transform checkersRoot = component.checkersRoot;
						array = ((checkersRoot != null) ? checkersRoot.GetComponentsInChildren<InteraccionChecker>(true) : null);
					}
					InteraccionChecker[] array2 = array;
					if (array2 == null || array2.Length == 0)
					{
						flag = false;
					}
					else
					{
						bool flag2 = false;
						foreach (InteraccionChecker interaccionChecker in array2)
						{
							InteraccionChecker.Checking checking = interaccionChecker.checking;
							interaccionChecker.checking = InteraccionChecker.Checking.SoloPlayer();
							flag2 = flag2 || interaccionChecker.DoCheck(character as AnimatorCharacter);
							interaccionChecker.checking = checking;
						}
						flag = flag2;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000B0D0 File Offset: 0x000092D0
		public bool PoseCambiarHayObstaculo(string id)
		{
			bool flag;
			try
			{
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					flag = false;
				}
				else
				{
					Guid guid = Guid.Parse(id);
					Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
					InteraccionDeCharacter interaccionDeCharacter = character.GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerBase(DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt);
					InteraccionCheckers component = ((interaccionDeCharacter != null) ? interaccionDeCharacter.instancia : null).GetComponent<InteraccionCheckers>();
					InteraccionChecker[] array;
					if (component == null)
					{
						array = null;
					}
					else
					{
						Transform checkersRoot = component.checkersRoot;
						array = ((checkersRoot != null) ? checkersRoot.GetComponentsInChildren<InteraccionChecker>(true) : null);
					}
					InteraccionChecker[] array2 = array;
					if (array2 == null || array2.Length == 0)
					{
						flag = false;
					}
					else
					{
						bool flag2 = false;
						foreach (InteraccionChecker interaccionChecker in array2)
						{
							flag2 = flag2 || interaccionChecker.DoCheck(character as AnimatorCharacter);
						}
						flag = flag2;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000B1B4 File Offset: 0x000093B4
		private static bool EnConflicto(Character c, Interaccion inter, out FullBodyBipedEffector enConflicto)
		{
			AtadurasPorUsuarioController componentInChildren = c.GetComponentInChildren<AtadurasPorUsuarioController>();
			if (componentInChildren == null)
			{
				enConflicto = FullBodyBipedEffector.Body;
				return false;
			}
			foreach (InteraccionEffectorParInfo interaccionEffectorParInfo in inter.datosDeParesDeEfecctors.effectorsInteractions)
			{
				if (interaccionEffectorParInfo.activado && interaccionEffectorParInfo.isValid && componentInChildren.EstaAtado(interaccionEffectorParInfo.fullBodyBipedEffector))
				{
					enConflicto = interaccionEffectorParInfo.fullBodyBipedEffector;
					return true;
				}
			}
			enConflicto = FullBodyBipedEffector.Body;
			return false;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000B244 File Offset: 0x00009444
		private static bool EnConflictoTodos(Character c)
		{
			AtadurasPorUsuarioController componentInChildren = c.GetComponentInChildren<AtadurasPorUsuarioController>();
			return !(componentInChildren == null) && componentInChildren.EstanTodosAtados();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000B26C File Offset: 0x0000946C
		public static bool EsConsentidoEjecutarPose(Character character, ConsentNecesario necesario, int poseID, bool modificarResultado, Personalidad personalidad = null, IInteraccionesDeCharacter interacciones = null)
		{
			float num;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			float? num2;
			ParteDelCuerpoHumano? parteDelCuerpoHumano2;
			return RegistroDeFuncionesDeCambioDePose.EsConsentidoEjecutarPose(character, necesario, poseID, modificarResultado, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, personalidad, interacciones);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000B290 File Offset: 0x00009490
		public static bool EsConsentidoEjecutarPose(Character character, ConsentNecesario necesario, int poseID, bool modificarResultado, out float menosOffsetMod, out ParteDelCuerpoHumano menorConsentida, out float? masNoConsentidaOffsetMod, out ParteDelCuerpoHumano? masNoConsentida, Personalidad personalidad = null, IInteraccionesDeCharacter interacciones = null)
		{
			if (interacciones == null)
			{
				interacciones = character.GetComponentInChildren<IInteraccionesDeCharacter>();
			}
			menosOffsetMod = 0f;
			menorConsentida = ParteDelCuerpoHumano.pecho;
			masNoConsentida = null;
			masNoConsentidaOffsetMod = null;
			InteraccionDeCharacter interaccionDeCharacter = interacciones.ObtenerBase(poseID);
			if (interaccionDeCharacter == null || interaccionDeCharacter.instancia == null)
			{
				Debug.LogWarning("Consentido ejecutar pose " + poseID.ToString() + " por que no existe pose en character.", character);
				return true;
			}
			InteraccionPersonalidadData component = interaccionDeCharacter.instancia.GetComponent<InteraccionPersonalidadData>();
			if (component == null)
			{
				Debug.LogWarning("Consentido ejecutar pose " + poseID.ToString() + " por que no existe InteraccionExponePartes en interaccion.", character);
				return true;
			}
			if (personalidad == null)
			{
				personalidad = character.GetComponentInChildren<Personalidad>();
			}
			Personalidad.Tipo tipo = personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
			float num = component.ObtenerDificultadDeTipoDePersonalidad(tipo);
			IReadOnlyList<ParteDelCuerpoHumano> readOnlyList;
			IReadOnlyCollection<int> readOnlyCollection;
			component.ObtenerExponiendoPartes(out readOnlyList, out readOnlyCollection, null);
			if (readOnlyList.Count == 0)
			{
				return true;
			}
			bool flag = necesario.TodosConsentidosConJerarquia(readOnlyList, TipoDeEstimulo.peticionEjecucionDePose, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out menosOffsetMod, out menorConsentida, out masNoConsentidaOffsetMod, out masNoConsentida, num, null, null, null);
			if (!flag)
			{
				return false;
			}
			if (!modificarResultado)
			{
				return flag;
			}
			int num2 = Mathf.Clamp(readOnlyCollection.Count, 1, 2);
			return ((0.6666f + (personalidad.sumicion + personalidad.exhibicionismo + personalidad.perverticidad) / 3f * 0.3333f) / (1f + 0.05f * (float)(num2 - 1))).ProcMod(menosOffsetMod);
		}
	}
}

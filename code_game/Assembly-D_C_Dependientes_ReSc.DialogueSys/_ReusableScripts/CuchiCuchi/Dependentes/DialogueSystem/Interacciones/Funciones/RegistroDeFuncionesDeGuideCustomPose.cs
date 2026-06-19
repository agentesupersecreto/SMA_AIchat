using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Textos;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.Funciones
{
	// Token: 0x02000047 RID: 71
	public class RegistroDeFuncionesDeGuideCustomPose : CustomMonobehaviour
	{
		// Token: 0x06000225 RID: 549 RVA: 0x0000B404 File Offset: 0x00009604
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("PoseActualEsConsentida", this, base.GetType().GetMethod("PoseActualEsConsentida"));
			Lua.RegisterFunction("EsConsentidoMoverTodosLosHuesos", this, base.GetType().GetMethod("EsConsentidoMoverTodosLosHuesos"));
			Lua.RegisterFunction("PoseActualMuestraPartePrivada", this, base.GetType().GetMethod("PoseActualMuestraPartePrivada"));
			Lua.RegisterFunction("DijoGuiarPoseCustomNoConsentida", this, base.GetType().GetMethod("DijoGuiarPoseCustomNoConsentida"));
			Lua.RegisterFunction("RegisDijoGuiarPoseCustomNoConsentida", this, base.GetType().GetMethod("RegisDijoGuiarPoseCustomNoConsentida"));
			Lua.RegisterFunction("BorrarDijoGuiarPoseCustomNoConsentida", this, base.GetType().GetMethod("BorrarDijoGuiarPoseCustomNoConsentida"));
			Lua.RegisterFunction("AlgunaPoseEjecutandose", this, base.GetType().GetMethod("AlgunaPoseEjecutandose"));
			Lua.RegisterFunction("ActivarPoseEditMode", this, base.GetType().GetMethod("ActivarPoseEditMode"));
			Lua.RegisterFunction("DetenerCurrentPose", this, base.GetType().GetMethod("DetenerCurrentPose"));
			Lua.RegisterFunction("RegistrarPedidoFallidoPoseGuideCustom", this, base.GetType().GetMethod("RegistrarPedidoFallidoPoseGuideCustom"));
			Lua.RegisterFunction("MiHuesoNoConsentidoLocalizado", this, base.GetType().GetMethod("MiHuesoNoConsentidoLocalizado"));
			Lua.RegisterFunction("MiParteMasNoConsentidoLocalizado", this, base.GetType().GetMethod("MiParteMasNoConsentidoLocalizado"));
			Lua.RegisterFunction("CustomPoseActualEsSobornada", this, base.GetType().GetMethod("CustomPoseActualEsSobornada"));
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000B578 File Offset: 0x00009778
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("PoseActualEsConsentida");
			Lua.UnregisterFunction("EsConsentidoMoverTodosLosHuesos");
			Lua.UnregisterFunction("PoseActualMuestraPartePrivada");
			Lua.UnregisterFunction("DijoGuiarPoseCustomNoConsentida");
			Lua.UnregisterFunction("RegisDijoGuiarPoseCustomNoConsentida");
			Lua.UnregisterFunction("BorrarDijoGuiarPoseCustomNoConsentida");
			Lua.UnregisterFunction("AlgunaPoseEjecutandose");
			Lua.UnregisterFunction("ActivarPoseEditMode");
			Lua.UnregisterFunction("DetenerCurrentPose");
			Lua.UnregisterFunction("RegistrarPedidoFallidoPoseGuideCustom");
			Lua.UnregisterFunction("MiHuesoNoConsentidoLocalizado");
			Lua.UnregisterFunction("MiParteMasNoConsentidoLocalizado");
			Lua.UnregisterFunction("CustomPoseActualEsSobornada");
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000B60E File Offset: 0x0000980E
		[Obsolete]
		public static void ActivateSkeletonEditorMode(Character c, bool fastSwitch, bool invisibleMode)
		{
			BoneGuiable.ActivateSkeletonEditorMode(c, fastSwitch, invisibleMode);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000B618 File Offset: 0x00009818
		public bool CustomPoseActualEsSobornada()
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				character.GetComponentInChildren<AnimController>();
				CustomPosesDeFemaleCharacter componentInChildren = character.GetComponentInChildren<CustomPosesDeFemaleCharacter>();
				int interactionID = componentInChildren.interacciones.ObtenerNextCustom().GetInteractionID();
				componentInChildren.ObtenerPrepararCustomPoseOnEditMode(interactionID).SetCustomPoseSkeletonToCurrentSkeletonPose();
				ConsentCorrupted consentCorrupted = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante();
				InteraccionDeCharacter interaccionDeCharacter = componentInChildren.interacciones.ObtenerBase(interactionID);
				if (interaccionDeCharacter == null || interaccionDeCharacter.instancia == null)
				{
					Debug.LogWarning("Consentido ejecutar pose " + interactionID.ToString() + " por que no existe pose en character.", character);
					flag = true;
				}
				else
				{
					InteraccionPersonalidadData component = interaccionDeCharacter.instancia.GetComponent<InteraccionPersonalidadData>();
					if (component == null)
					{
						Debug.LogWarning("Consentido ejecutar pose " + interactionID.ToString() + " por que no existe InteraccionExponePartes en interaccion.", character);
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

		// Token: 0x06000229 RID: 553 RVA: 0x0000B770 File Offset: 0x00009970
		public string MiHuesoNoConsentidoLocalizado()
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!string.IsNullOrWhiteSpace(DialogueLua.GetVariable("CURRENT_GUIDING_POSE_BONE_MAS_NO_CONSENTIDO").AsString))
				{
					parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_GUIDING_POSE_BONE_MAS_NO_CONSENTIDO").AsString);
				}
				else
				{
					parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_GUIDING_POSE_BONE_MENOS_CONSENTIDO").AsString);
				}
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

		// Token: 0x0600022A RID: 554 RVA: 0x0000B894 File Offset: 0x00009A94
		public string MiParteMasNoConsentidoLocalizado()
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!string.IsNullOrWhiteSpace(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA").AsString))
				{
					parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MAS_NO_CONSENTIDA").AsString);
				}
				else
				{
					parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString);
				}
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

		// Token: 0x0600022B RID: 555 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		public void RegistrarPedidoFallidoPoseGuideCustom()
		{
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				PeticionEstadoDeInteraccionesConAI componentInChildren = character.GetComponentInChildren<PeticionEstadoDeInteraccionesConAI>(true);
				InteraccionDeCharacter interaccionDeCharacter = character.GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerFirstEjecutandosePrimaria();
				int num;
				if (interaccionDeCharacter != null)
				{
					num = interaccionDeCharacter.id;
				}
				else
				{
					num = DialogueLua.GetVariable("SELECTED_POSE_ID").AsInt;
				}
				bool asBool = DialogueLua.GetVariable("SELECTED_POSE_PUEDE_EJECUTARSE").AsBool;
				componentInChildren.IDFlag = num;
				componentInChildren.RegistrarToggle(MainChar.current, true, ParteQuePuedeEstimular.boca, asBool, false, null, false, false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000BA74 File Offset: 0x00009C74
		public void ActivarPoseEditMode(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				BoneGuiable.ActivateSkeletonEditorMode(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid), false, false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000BAB4 File Offset: 0x00009CB4
		public void DetenerCurrentPose(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				InteraccionDeCharacter interaccionDeCharacter = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerFirstEjecutandosePrimaria();
				if (interaccionDeCharacter != null)
				{
					Interaccion instancia = interaccionDeCharacter.instancia;
					if (instancia != null)
					{
						instancia.Detener(false);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000BB10 File Offset: 0x00009D10
		public bool DijoGuiarPoseCustomNoConsentida(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeGuiarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeGuiarPose>();
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!Enum.TryParse<ParteDelCuerpoHumano>(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString, out parteDelCuerpoHumano))
				{
					flag = false;
				}
				else
				{
					flag = componentInChildrenNotNull.EstaRegistrardaGuiarPoseNegadaPorParte(parteDelCuerpoHumano);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000BB80 File Offset: 0x00009D80
		public void RegisDijoGuiarPoseCustomNoConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeGuiarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeGuiarPose>();
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (Enum.TryParse<ParteDelCuerpoHumano>(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString, out parteDelCuerpoHumano))
				{
					componentInChildrenNotNull.RegistrarGuiarPoseNegadaPorParte(parteDelCuerpoHumano);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000BBE4 File Offset: 0x00009DE4
		public void BorrarDijoGuiarPoseCustomNoConsentida(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeRegistroDePeticionesDeGuiarPose componentInChildrenNotNull = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeGuiarPose>();
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (Enum.TryParse<ParteDelCuerpoHumano>(DialogueLua.GetVariable("CURRENT_POSE_PARTE_MENOS_CONSENTIDA").AsString, out parteDelCuerpoHumano))
				{
					componentInChildrenNotNull.BorrarGuiarPoseNegadaPorParte(parteDelCuerpoHumano);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000BC48 File Offset: 0x00009E48
		public bool PoseActualMuestraPartePrivada(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				character.GetComponentInChildren<AnimController>();
				CustomPosesDeFemaleCharacter componentInChildren = character.GetComponentInChildren<CustomPosesDeFemaleCharacter>();
				int interactionID = componentInChildren.interacciones.ObtenerNextCustom().GetInteractionID();
				componentInChildren.ObtenerPrepararCustomPoseOnEditMode(interactionID).SetCustomPoseSkeletonToCurrentSkeletonPose();
				IReadOnlyList<ParteDelCuerpoHumano> readOnlyList;
				IReadOnlyCollection<int> readOnlyCollection;
				componentInChildren.interacciones.ObtenerBase(interactionID).instancia.GetComponent<InteraccionPersonalidadData>().ObtenerExponiendoPartes(out readOnlyList, out readOnlyCollection, null);
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					if (readOnlyList[i].EsPrivadaSocialmenteVisual())
					{
						return true;
					}
				}
				flag = false;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000BD04 File Offset: 0x00009F04
		public bool PoseActualEsConsentida(string id)
		{
			bool flag2;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				character.GetComponentInChildren<AnimController>();
				Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
				CustomPosesDeFemaleCharacter componentInChildren2 = character.GetComponentInChildren<CustomPosesDeFemaleCharacter>();
				int interactionID = componentInChildren2.interacciones.ObtenerNextCustom().GetInteractionID();
				componentInChildren2.ObtenerPrepararCustomPoseOnEditMode(interactionID).SetCustomPoseSkeletonToCurrentSkeletonPose();
				ConsentNecesario componentInChildren3 = character.GetComponentInChildren<ConsentNecesario>();
				float num;
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				float? num2;
				ParteDelCuerpoHumano? parteDelCuerpoHumano2;
				bool flag = RegistroDeFuncionesDeCambioDePose.EsConsentidoEjecutarPose(character, componentInChildren3, interactionID, false, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, componentInChildren, componentInChildren2.interacciones);
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
				DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", flag);
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000BE00 File Offset: 0x0000A000
		public bool EsConsentidoMoverTodosLosHuesos(string id)
		{
			bool flag3;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				character.GetComponentInChildren<Personalidad>();
				InteraccionesBasicasDeFemale componentInChildren = character.GetComponentInChildren<InteraccionesBasicasDeFemale>();
				bool flag;
				ParteDelCuerpoHumano[] array = ((InteraccionPrimariaBase)componentInChildren.ObtenerBase(componentInChildren.ObtenerCurrentCustom(out flag).GetInteractionID()).instancia).interactionRootBone.GetComponentsInChildren<BoneGuiable>().Where(delegate(BoneGuiable b)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano3;
					return b.boneInfo.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano3);
				}).Select(delegate(BoneGuiable b)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano4;
					b.boneInfo.humanBone.TryParceToParteDelCuerpoHumano(out parteDelCuerpoHumano4);
					return parteDelCuerpoHumano4;
				})
					.Distinct<ParteDelCuerpoHumano>()
					.ToArray<ParteDelCuerpoHumano>();
				ConsentNecesario componentInChildren2 = character.GetComponentInChildren<ConsentNecesario>();
				ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
				ParteDelCuerpoHumano? parteDelCuerpoHumano2 = null;
				float num;
				float? num2;
				bool flag2 = array.Length == 0 || RegistroDeFuncionesDeGuideCustomPose.EsConsentidoGuiarPartes(componentInChildren2, array, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2);
				if (!flag2)
				{
					DialogueLua.SetVariable("CURRENT_GUIDING_POSE_BONE_MENOS_CONSENTIDO", parteDelCuerpoHumano.ToString());
					if (parteDelCuerpoHumano2 != null)
					{
						DialogueLua.SetVariable("CURRENT_GUIDING_POSE_BONE_MAS_NO_CONSENTIDO", parteDelCuerpoHumano2.Value.ToString());
					}
					else
					{
						DialogueLua.SetVariable("CURRENT_GUIDING_POSE_BONE_MAS_NO_CONSENTIDO", string.Empty);
					}
				}
				flag3 = flag2;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag3 = false;
			}
			return flag3;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000BF54 File Offset: 0x0000A154
		public bool AlgunaPoseEjecutandose(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				character.GetComponentInChildren<Personalidad>();
				flag = character.GetComponentInChildren<IInteraccionesDeCharacter>().ObtenerFirstEjecutandosePrimaria() != null;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000BFA8 File Offset: 0x0000A1A8
		public static bool EsConsentidoGuiarPartes(ConsentNecesario necesario, IReadOnlyList<ParteDelCuerpoHumano> partes, out float menosOffsetMod, out ParteDelCuerpoHumano menorConsentida, out float? masNoConsentidaOffsetMod, out ParteDelCuerpoHumano? masNoConsentida)
		{
			if (partes.Count == 0)
			{
				throw new InvalidOperationException();
			}
			float num = 1f;
			return necesario.TodosConsentidosConJerarquia(partes, TipoDeEstimulo.guiandoBone, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out menosOffsetMod, out menorConsentida, out masNoConsentidaOffsetMod, out masNoConsentida, num, null, null, null);
		}
	}
}

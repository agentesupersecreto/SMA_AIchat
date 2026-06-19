using System;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime.IK;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.CustomPoses;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.Funciones
{
	// Token: 0x02000045 RID: 69
	public class RegistroDeFuncionesDeCambiarACustomPose : CustomMonobehaviour
	{
		// Token: 0x060001FB RID: 507 RVA: 0x00009983 File Offset: 0x00007B83
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("EsConsentidoCargarPoseCustom", this, base.GetType().GetMethod("EsConsentidoCargarPoseCustom"));
			Lua.RegisterFunction("PoseCargadaCustomSePuedeEjecutar", this, base.GetType().GetMethod("PoseCargadaCustomSePuedeEjecutar"));
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000099C1 File Offset: 0x00007BC1
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("EsConsentidoCargarPoseCustom");
			Lua.UnregisterFunction("PoseCargadaCustomSePuedeEjecutar");
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000099E0 File Offset: 0x00007BE0
		private void LoadCustomPoseFileACustomInteraction()
		{
			string asString = DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_NAME").AsString;
			if (!string.IsNullOrWhiteSpace(asString))
			{
				string empty = string.Empty;
				Texture2D texture2D;
				SaveLoadPoses.Cargar(asString, out texture2D, ref empty);
				try
				{
					if (empty.Length == 0)
					{
						Singleton<MainCanvas>.instance.MostrartMsg("Custom Poses", "Invalid Pose File", 3f, true, null, null, null);
					}
					else
					{
						TargetChar instance = TargetChar.instance;
						Character character = ((instance != null) ? instance.character : null);
						if (character == null)
						{
							throw new ArgumentNullException("currentChar", "currentChar null reference.");
						}
						InteraccionesBasicasDeFemale componentEnRoot = character.GetComponentEnRoot<InteraccionesBasicasDeFemale>();
						if (componentEnRoot == null)
						{
							throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
						}
						InteraccionPrimariaName interaccionPrimariaName;
						bool flag;
						componentEnRoot.ObtenerNextCustom(out interaccionPrimariaName, out flag);
						SaveLoadCustomPoses.LoadSavedData(character, ref empty, interaccionPrimariaName.GetInteractionID(), null, delegate(GizmosDeSkeleton s)
						{
							PoseQueExponePartesVestidas componentInParent = s.GetComponentInParent<PoseQueExponePartesVestidas>();
							if (componentInParent != null)
							{
								componentInParent.UpdateInitialPartsBeingExposed();
							}
							PrepararCustomPoseOnEditMode componentInParent2 = s.GetComponentInParent<PrepararCustomPoseOnEditMode>();
							if (componentInParent2 == null)
							{
								return;
							}
							componentInParent2.GetComponentsInChildren<LimbIKDeCustomPose>().ForEach(delegate(LimbIKDeCustomPose ik)
							{
								ik.FollowBones();
							});
						});
						DialogueLua.SetVariable("SELECTED_CUSTOM_POSE_CARGADA", true);
					}
				}
				finally
				{
					Object.Destroy(texture2D);
				}
				return;
			}
			if (Application.isEditor)
			{
				Debug.LogWarning("Nombre a cargar es invalido: " + asString, this);
				return;
			}
			Debug.LogError("Nombre a cargar es invalido: " + asString, this);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00009B28 File Offset: 0x00007D28
		public bool EsConsentidoCargarPoseCustom(string id)
		{
			bool flag;
			try
			{
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", true);
					flag = true;
				}
				else
				{
					Guid guid = Guid.Parse(id);
					Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
					character.GetComponentInChildren<AnimController>();
					Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
					InteraccionesBasicasDeFemale componentInChildren2 = character.GetComponentInChildren<InteraccionesBasicasDeFemale>();
					if (!DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_CARGADA").AsBool)
					{
						this.LoadCustomPoseFileACustomInteraction();
					}
					InteraccionPrimariaName interaccionPrimariaName;
					bool flag2;
					componentInChildren2.ObtenerNextCustom(out interaccionPrimariaName, out flag2);
					ConsentNecesario componentInChildren3 = character.GetComponentInChildren<ConsentNecesario>();
					float num;
					ParteDelCuerpoHumano parteDelCuerpoHumano;
					float? num2;
					ParteDelCuerpoHumano? parteDelCuerpoHumano2;
					bool flag3 = RegistroDeFuncionesDeCambioDePose.EsConsentidoEjecutarPose(character, componentInChildren3, interaccionPrimariaName.GetInteractionID(), false, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, componentInChildren, componentInChildren2);
					if (!flag3)
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
					DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", flag3);
					flag = flag3;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00009C68 File Offset: 0x00007E68
		public bool PoseCargadaCustomSePuedeEjecutar(string id)
		{
			bool flag;
			try
			{
				if (DialogueLua.GetVariable("SELECTED_POSE_ES_DETENER").AsBool)
				{
					flag = true;
				}
				else
				{
					Guid guid = Guid.Parse(id);
					Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
					character.GetComponentInChildren<AnimController>();
					character.GetComponentInChildren<Personalidad>();
					InteraccionesBasicasDeFemale componentInChildren = character.GetComponentInChildren<InteraccionesBasicasDeFemale>();
					if (!DialogueLua.GetVariable("SELECTED_CUSTOM_POSE_CARGADA").AsBool)
					{
						this.LoadCustomPoseFileACustomInteraction();
					}
					InteraccionPrimariaName interaccionPrimariaName;
					bool flag2;
					componentInChildren.ObtenerNextCustom(out interaccionPrimariaName, out flag2);
					Interaccion interaccion;
					if (!componentInChildren.TryObtenerSiEsValida(interaccionPrimariaName.GetInteractionID(), out interaccion))
					{
						flag = false;
					}
					else
					{
						flag = interaccion.PuedeEjecutarse();
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
	}
}

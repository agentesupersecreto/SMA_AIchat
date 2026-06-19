using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos;
using Assets.TValle.Pro.Entrevista.Runtime.Modelaje.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys
{
	// Token: 0x020000FD RID: 253
	public class RegistroDeFuncionesDeGestosDeModelaje : CustomMonobehaviour
	{
		// Token: 0x06000875 RID: 2165 RVA: 0x0003059C File Offset: 0x0002E79C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("GestuarModelajeConversante", this, base.GetType().GetMethod("GestuarModelajeConversante"));
			Lua.RegisterFunction("GestuarStopModelajeConversante", this, base.GetType().GetMethod("GestuarStopModelajeConversante"));
			Lua.RegisterFunction("StartCustomGestuar", this, base.GetType().GetMethod("StartCustomGestuar"));
			Lua.RegisterFunction("LoadCustomGestuarConversante", this, base.GetType().GetMethod("LoadCustomGestuarConversante"));
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0003061B File Offset: 0x0002E81B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("GestuarModelajeConversante");
			Lua.UnregisterFunction("GestuarStopModelajeConversante");
			Lua.UnregisterFunction("StartCustomGestuar");
			Lua.UnregisterFunction("LoadCustomGestuarConversante");
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0003064C File Offset: 0x0002E84C
		public static ControlladorDeGestosDeModelaje ObtenerControlladorGestosDeModelajeDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ControlladorDeGestosDeModelaje>();
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00030684 File Offset: 0x0002E884
		public static CustomGestosDeModelaje ObtenerCustomGestosDeModelajeDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<CustomGestosDeModelaje>();
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x000306BC File Offset: 0x0002E8BC
		public static FemaleCharacterModelo ObtenerModeloDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<FemaleCharacterModelo>();
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000306F4 File Offset: 0x0002E8F4
		public static FemaleChar ObtenerModeloConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<FemaleChar>(guid);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00030724 File Offset: 0x0002E924
		private void LoadCustomGestureFileACustomGestos()
		{
			string asString = DialogueLua.GetVariable("SELECTED_CUSTOM_GESTURE_NAME").AsString;
			if (!string.IsNullOrWhiteSpace(asString))
			{
				string empty = string.Empty;
				Texture2D texture2D;
				SaveLoadGestos.Cargar(asString, out texture2D, ref empty);
				try
				{
					if (empty.Length == 0)
					{
						Singleton<MainCanvas>.instance.MostrartMsg("Custom Gesture", "Invalid Gesture File", 3f, true, null, null, null);
					}
					else
					{
						TargetChar instance = TargetChar.instance;
						if (((instance != null) ? instance.character : null) == null)
						{
							throw new ArgumentNullException("currentChar", "currentChar null reference.");
						}
						try
						{
							GestosFacialesToDisk gestosFacialesToDisk = JsonUtility.FromJson<GestosFacialesToDisk>(empty);
							CustomGestosDeModelaje customGestosDeModelaje = RegistroDeFuncionesDeGestosDeModelaje.ObtenerCustomGestosDeModelajeDeConversant();
							customGestosDeModelaje.StartGestos();
							GestosFacialesShapesToEdit.LoadToCustomGestos(gestosFacialesToDisk.gestos, customGestosDeModelaje);
						}
						catch (Exception ex)
						{
							Debug.LogException(ex, this);
							Singleton<ModalWindow>.instance.AcumularErrores(ex.Message, null);
						}
						finally
						{
							Object.Destroy(texture2D);
						}
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

		// Token: 0x0600087C RID: 2172 RVA: 0x00030860 File Offset: 0x0002EA60
		public void GestuarModelajeConversante(object reaccionObj)
		{
			try
			{
				ControlladorDeGestosDeModelaje controlladorDeGestosDeModelaje = RegistroDeFuncionesDeGestosDeModelaje.ObtenerControlladorGestosDeModelajeDeConversant();
				FemaleCharacterModelo femaleCharacterModelo = RegistroDeFuncionesDeGestosDeModelaje.ObtenerModeloDeConversant();
				ControlladorDeGestosDeModelaje.TipoDeExpresion tipoDeExpresion;
				if (!Enum.TryParse<ControlladorDeGestosDeModelaje.TipoDeExpresion>(reaccionObj.ToString(), out tipoDeExpresion))
				{
					Debug.LogException(new InvalidOperationException(), this);
				}
				else
				{
					RegistroDeFuncionesDeGestosDeModelaje.ObtenerCustomGestosDeModelajeDeConversant().EndGestos();
					int modelingExpInt = femaleCharacterModelo.GetModelingExpInt();
					controlladorDeGestosDeModelaje.Gestuar(tipoDeExpresion, Mathf.Lerp(20f, 60f, Mathf.InverseLerp(0f, 2f, (float)modelingExpInt)), modelingExpInt);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000308EC File Offset: 0x0002EAEC
		public void GestuarStopModelajeConversante()
		{
			try
			{
				RegistroDeFuncionesDeGestosDeModelaje.ObtenerControlladorGestosDeModelajeDeConversant().DetenerOrdenes();
				RegistroDeFuncionesDeGestosDeModelaje.ObtenerCustomGestosDeModelajeDeConversant().EndGestos();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00030928 File Offset: 0x0002EB28
		public void StartCustomGestuar()
		{
			try
			{
				PanelDeEditarGestosFaciales panel = Singleton<PanelDeEditarGestosFacialesGetter>.instance.panel;
				panel.SetTarget(RegistroDeFuncionesDeGestosDeModelaje.ObtenerModeloConversant());
				panel.CrearYDibujar(null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0003096C File Offset: 0x0002EB6C
		public void LoadCustomGestuarConversante()
		{
			try
			{
				RegistroDeFuncionesDeGestosDeModelaje.ObtenerControlladorGestosDeModelajeDeConversant().DetenerOrdenes();
				this.LoadCustomGestureFileACustomGestos();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}
	}
}

using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Modelaje.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.DialogueSys
{
	// Token: 0x020000FE RID: 254
	public class RegistroDeFuncionesDeMakeover : AplicableCustomMonobehaviour
	{
		// Token: 0x06000881 RID: 2177 RVA: 0x000309AC File Offset: 0x0002EBAC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("StartCustomMakeover", this, base.GetType().GetMethod("StartCustomMakeover"));
			Lua.RegisterFunction("LoadCustomMakeoverConversante", this, base.GetType().GetMethod("LoadCustomMakeoverConversante"));
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000309EA File Offset: 0x0002EBEA
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("StartCustomMakeover");
			Lua.UnregisterFunction("LoadCustomMakeoverConversante");
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00030A08 File Offset: 0x0002EC08
		public static FemaleCharacterModelo ObtenerModeloDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<FemaleCharacterModelo>();
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00030A40 File Offset: 0x0002EC40
		public static FemaleChar ObtenerModeloConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<FemaleChar>(guid);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00030A70 File Offset: 0x0002EC70
		public static AlteradoresDeAparienciaFemenina ObtenerAlteradoresDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<AlteradoresDeAparienciaFemenina>();
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00030AA8 File Offset: 0x0002ECA8
		private void LoadCustomMakeoverFileACharacter()
		{
			string asString = DialogueLua.GetVariable("SELECTED_CUSTOM_MAKEOVER_NAME").AsString;
			if (!string.IsNullOrWhiteSpace(asString))
			{
				string empty = string.Empty;
				Texture2D texture2D;
				SaveLoadMakeover.Cargar(asString, out texture2D, ref empty);
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
							MakeoverToDisk makeoverToDisk = JsonUtility.FromJson<MakeoverToDisk>(empty);
							AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina = RegistroDeFuncionesDeMakeover.ObtenerAlteradoresDeConversant();
							PanelDeEditarMakeover.SetValoresToAlteradores(makeoverToDisk.makeover, alteradoresDeAparienciaFemenina);
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

		// Token: 0x06000887 RID: 2183 RVA: 0x00030BE0 File Offset: 0x0002EDE0
		public void GestuarModelajeConversante(object reaccionObj)
		{
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00030BE2 File Offset: 0x0002EDE2
		public void GestuarStopModelajeConversante()
		{
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00030BE4 File Offset: 0x0002EDE4
		public void StartCustomMakeover()
		{
			try
			{
				PanelDeEditarMakeover panel = Singleton<PanelDeEditarMakeoverGetter>.instance.panel;
				panel.SetTarget(RegistroDeFuncionesDeMakeover.ObtenerModeloConversant());
				panel.CrearYDibujar(null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00030C28 File Offset: 0x0002EE28
		public void LoadCustomMakeoverConversante()
		{
			try
			{
				this.LoadCustomMakeoverFileACharacter();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00030C58 File Offset: 0x0002EE58
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			PanelDeEditarMakeover panel = Singleton<PanelDeEditarMakeoverGetter>.instance.panel;
			panel.SetTarget(TargetChar.current as FemaleChar);
			panel.CrearYDibujar(null);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00030C80 File Offset: 0x0002EE80
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Show Editar Makeover Panel"
			};
		}
	}
}

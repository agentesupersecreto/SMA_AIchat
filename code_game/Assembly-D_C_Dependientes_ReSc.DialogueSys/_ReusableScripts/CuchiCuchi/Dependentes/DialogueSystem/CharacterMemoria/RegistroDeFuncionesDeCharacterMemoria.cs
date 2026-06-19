using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria
{
	// Token: 0x02000070 RID: 112
	public class RegistroDeFuncionesDeCharacterMemoria : CustomMonobehaviour
	{
		// Token: 0x06000333 RID: 819 RVA: 0x000108C8 File Offset: 0x0000EAC8
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("ConversantConoceAlMainChatacter", this, base.GetType().GetMethod("ConversantConoceAlMainChatacter"));
			Lua.RegisterFunction("CantidadDeOrgasmosEnSession", this, base.GetType().GetMethod("CantidadDeOrgasmosEnSession"));
			Lua.RegisterFunction("DatoRegistradoEnSessionToActor", this, base.GetType().GetMethod("DatoRegistradoEnSessionToActor"));
			Lua.RegisterFunction("RegistrarDatoEnSessionToActor", this, base.GetType().GetMethod("RegistrarDatoEnSessionToActor"));
			Lua.RegisterFunction("DatoRegistradoEnSession", this, base.GetType().GetMethod("DatoRegistradoEnSession"));
			Lua.RegisterFunction("RegistrarDatoEnSession", this, base.GetType().GetMethod("RegistrarDatoEnSession"));
			Lua.RegisterFunction("CantidadDeDatoRegistradoEnSession", this, base.GetType().GetMethod("CantidadDeDatoRegistradoEnSession"));
			Lua.RegisterFunction("RegistrarCantidadAddDeDatoEnSession", this, base.GetType().GetMethod("RegistrarCantidadAddDeDatoEnSession"));
			Lua.RegisterFunction("TochedByMainEnSession", this, base.GetType().GetMethod("TochedByMainEnSession"));
			Lua.RegisterFunction("CaressByMainEnSession", this, base.GetType().GetMethod("CaressByMainEnSession"));
			Lua.RegisterFunction("LookedAtByMainEnSession", this, base.GetType().GetMethod("LookedAtByMainEnSession"));
			Lua.RegisterFunction("PenetratedByMainEnSession", this, base.GetType().GetMethod("PenetratedByMainEnSession"));
			Lua.RegisterFunction("CaressByMainEnSessionANY", this, base.GetType().GetMethod("CaressByMainEnSessionANY"));
			Lua.RegisterFunction("EstimuladoByMainEnSession", this, base.GetType().GetMethod("EstimuladoByMainEnSession"));
			Lua.RegisterFunction("EstimuladoByMainEnSessionANY", this, base.GetType().GetMethod("EstimuladoByMainEnSessionANY"));
			Lua.RegisterFunction("CurrentConversantFotografiadaEnSession", this, base.GetType().GetMethod("CurrentConversantFotografiadaEnSession"));
			Lua.RegisterFunction("CurrentConversantAcariciadaEnSession", this, base.GetType().GetMethod("CurrentConversantAcariciadaEnSession"));
			Lua.RegisterFunction("CurrentConversantSolicitadaCambiarDePoseEnSession", this, base.GetType().GetMethod("CurrentConversantSolicitadaCambiarDePoseEnSession"));
			Lua.RegisterFunction("CurrentConversantSolicitadaMoverBoneEnSession", this, base.GetType().GetMethod("CurrentConversantSolicitadaMoverBoneEnSession"));
			Lua.RegisterFunction("CurrentConversantCambiadaDePoseEnSession", this, base.GetType().GetMethod("CurrentConversantCambiadaDePoseEnSession"));
			Lua.RegisterFunction("CurrentConversantManipuladaBoneEnSession", this, base.GetType().GetMethod("CurrentConversantManipuladaBoneEnSession"));
			Lua.RegisterFunction("CurrentConversantSolicitadaDesvestirEnSession", this, base.GetType().GetMethod("CurrentConversantSolicitadaDesvestirEnSession"));
			Lua.RegisterFunction("CurrentConversantDesvestidaEnSession", this, base.GetType().GetMethod("CurrentConversantDesvestidaEnSession"));
			Lua.RegisterFunction("YaConversadoEnSession", this, base.GetType().GetMethod("YaConversadoEnSession"));
			Lua.RegisterFunction("RegistrarConversadoEnSession", this, base.GetType().GetMethod("RegistrarConversadoEnSession"));
			Lua.RegisterFunction("ConversantFueAsustada", this, base.GetType().GetMethod("ConversantFueAsustada"));
			Lua.RegisterFunction("ConversantFueEnojada", this, base.GetType().GetMethod("ConversantFueEnojada"));
			Lua.RegisterFunction("ConversantFueAdolorida", this, base.GetType().GetMethod("ConversantFueAdolorida"));
			Lua.RegisterFunction("ConversantFueDecepcionada", this, base.GetType().GetMethod("ConversantFueDecepcionada"));
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00010BEC File Offset: 0x0000EDEC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("ConversantConoceAlMainChatacter");
			Lua.UnregisterFunction("CantidadDeOrgasmosEnSession");
			Lua.UnregisterFunction("DatoRegistradoEnSessionToActor");
			Lua.UnregisterFunction("RegistrarDatoEnSessionToActor");
			Lua.UnregisterFunction("DatoRegistradoEnSession");
			Lua.UnregisterFunction("RegistrarDatoEnSession");
			Lua.UnregisterFunction("CantidadDeDatoRegistradoEnSession");
			Lua.UnregisterFunction("RegistrarCantidadAddDeDatoEnSession");
			Lua.UnregisterFunction("TochedByMainEnSession");
			Lua.UnregisterFunction("CaressByMainEnSession");
			Lua.UnregisterFunction("LookedAtByMainEnSession");
			Lua.UnregisterFunction("PenetratedByMainEnSession");
			Lua.UnregisterFunction("CaressByMainEnSessionANY");
			Lua.UnregisterFunction("EstimuladoByMainEnSession");
			Lua.UnregisterFunction("EstimuladoByMainEnSessionANY");
			Lua.UnregisterFunction("CurrentConversantFotografiadaEnSession");
			Lua.UnregisterFunction("CurrentConversantAcariciadaEnSession");
			Lua.UnregisterFunction("CurrentConversantSolicitadaCambiarDePoseEnSession");
			Lua.UnregisterFunction("CurrentConversantSolicitadaMoverBoneEnSession");
			Lua.UnregisterFunction("CurrentConversantCambiadaDePoseEnSession");
			Lua.UnregisterFunction("CurrentConversantManipuladaBoneEnSession");
			Lua.UnregisterFunction("CurrentConversantSolicitadaDesvestirEnSession");
			Lua.UnregisterFunction("CurrentConversantDesvestidaEnSession");
			Lua.UnregisterFunction("YaConversadoEnSession");
			Lua.UnregisterFunction("RegistrarConversadoEnSession");
			Lua.UnregisterFunction("ConversantFueAsustada");
			Lua.UnregisterFunction("ConversantFueEnojada");
			Lua.UnregisterFunction("ConversantFueAdolorida");
			Lua.UnregisterFunction("ConversantFueDecepcionada");
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00010D24 File Offset: 0x0000EF24
		public static MemoriaDeCharacterGeneralPermanente ObtenerMemoriaDeCharacterGeneralPermanente(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeCharacterGeneralPermanente>();
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00010D48 File Offset: 0x0000EF48
		public static MemoriaDeCharacterGeneralTemporal ObtenerMemoriaDeCharacterGeneralTemporal(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeCharacterGeneralTemporal>();
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00010D6C File Offset: 0x0000EF6C
		public static MemoriaDeCharacterGeneralTemporal ObtenerMemoriaGeneralTemporalDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeCharacterGeneralTemporal>();
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00010DA4 File Offset: 0x0000EFA4
		public static MemoriaDeIntereaccionesDeCharacter ObtenerMemoriaIntereaccionesDeConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeIntereaccionesDeCharacter>();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00010DDC File Offset: 0x0000EFDC
		public static MemoriaDeIntereaccionesDeCharacter ObtenerMemoriaIntereacciones(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeIntereaccionesDeCharacter>();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00010E00 File Offset: 0x0000F000
		public bool ConversantFueAsustada()
		{
			bool flag;
			try
			{
				flag = this.CantidadDeDatoRegistradoEnSession(DialogueLua.GetVariable("ConversantID").AsString, DialogueLua.GetVariable("MiedoOportunidad").AsString) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00010E58 File Offset: 0x0000F058
		public bool ConversantFueEnojada()
		{
			bool flag;
			try
			{
				flag = this.CantidadDeDatoRegistradoEnSession(DialogueLua.GetVariable("ConversantID").AsString, DialogueLua.GetVariable("RabiaOportunidad").AsString) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00010EB0 File Offset: 0x0000F0B0
		public bool ConversantFueAdolorida()
		{
			bool flag;
			try
			{
				flag = this.CantidadDeDatoRegistradoEnSession(DialogueLua.GetVariable("ConversantID").AsString, DialogueLua.GetVariable("DolorOportunidad").AsString) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00010F08 File Offset: 0x0000F108
		public bool ConversantFueDecepcionada()
		{
			bool flag;
			try
			{
				flag = this.CantidadDeDatoRegistradoEnSession(DialogueLua.GetVariable("ConversantID").AsString, DialogueLua.GetVariable("DecepOportunidad").AsString) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00010F60 File Offset: 0x0000F160
		public static bool DatoHaSidoRegistradoEnSession(string IDCharacter, string childKey, string dataKey)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(IDCharacter), childKey, dataKey);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00010F6F File Offset: 0x0000F16F
		public static bool CharacterConoceAlMainChatacterStatic(string IDCharacter)
		{
			return RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralPermanente(IDCharacter).ConoceACurrentMainCharacter();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00010F7C File Offset: 0x0000F17C
		public bool ConversantConoceAlMainChatacter()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.CharacterConoceAlMainChatacterStatic(DialogueLua.GetVariable("ConversantID").AsString);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00010FC0 File Offset: 0x0000F1C0
		public bool YaConversadoEnSession(string conversacionName)
		{
			bool flag;
			try
			{
				flag = MemoriaDeCharacterBase.LeerInt(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(DialogueLua.GetVariable("ConversantID").AsString), "Conversaciones_" + conversacionName, DialogueLua.GetVariable("ActorID").AsString, 0) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00011028 File Offset: 0x0000F228
		public void RegistrarConversadoEnSession(string conversacionName)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(DialogueLua.GetVariable("ConversantID").AsString), "Conversaciones_" + conversacionName, DialogueLua.GetVariable("ActorID").AsString, 1);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0001108C File Offset: 0x0000F28C
		public int CantidadDeOrgasmosEnSession(string id)
		{
			int num;
			try
			{
				num = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(id).CantidadDeOrgasmosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000110D0 File Offset: 0x0000F2D0
		public static bool DatoRegistradoEnSessionStatic(string IDCharacter, string idData)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(IDCharacter), idData, idData);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000110DF File Offset: 0x0000F2DF
		public static void RegistrarDatoEnSessionStatic(string IDCharacter, string idData)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(IDCharacter), idData, idData);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000110F0 File Offset: 0x0000F2F0
		public bool DatoRegistradoEnSessionToActor(string idData)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.DatoRegistradoEnSessionStatic(DialogueLua.GetVariable("ActorID").AsString, idData);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00011134 File Offset: 0x0000F334
		public void RegistrarDatoEnSessionToActor(string idData)
		{
			try
			{
				RegistroDeFuncionesDeCharacterMemoria.RegistrarDatoEnSessionStatic(DialogueLua.GetVariable("ActorID").AsString, idData);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00011174 File Offset: 0x0000F374
		public bool DatoRegistradoEnSession(string IDCharacter, string idData)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.DatoRegistradoEnSessionStatic(IDCharacter, idData);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000111A8 File Offset: 0x0000F3A8
		public void RegistrarDatoEnSession(string IDCharacter, string idData)
		{
			try
			{
				RegistroDeFuncionesDeCharacterMemoria.RegistrarDatoEnSessionStatic(IDCharacter, idData);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000111D8 File Offset: 0x0000F3D8
		public int CantidadDeDatoRegistradoEnSession(string IDCharacter, string idData)
		{
			int num;
			try
			{
				num = MemoriaDeCharacterBase.CantidadRegistrada(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(IDCharacter), idData, idData);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00011210 File Offset: 0x0000F410
		public void RegistrarCantidadAddDeDatoEnSession(string IDCharacter, string idData, float cantidadAdd)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaDeCharacterGeneralTemporal(IDCharacter), idData, idData, Mathf.RoundToInt(cantidadAdd));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001124C File Offset: 0x0000F44C
		public bool TochedByMainEnSession(string IDCharacter)
		{
			bool flag;
			try
			{
				MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(IDCharacter);
				flag = memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.caress) + memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.kiss) + memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.hump) + memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.poke) + memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.dryhump) + memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.lick) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000112FC File Offset: 0x0000F4FC
		public bool CaressByMainEnSession(string IDCharacter)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(IDCharacter).CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.caress) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00011344 File Offset: 0x0000F544
		public bool CaressByMainEnSessionANY(string IDCharacter, LuaTable partes)
		{
			bool flag;
			try
			{
				if (partes.Length == 0)
				{
					flag = false;
				}
				else
				{
					MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(IDCharacter);
					using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano))
							{
								SensitiveBodyPart part = parteDelCuerpoHumano.GetPart();
								if (memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.caress, part) > 0)
								{
									return true;
								}
							}
						}
					}
					flag = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000113F0 File Offset: 0x0000F5F0
		public bool LookedAtByMainEnSession(string IDCharacter)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(IDCharacter).CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.lookAt) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00011438 File Offset: 0x0000F638
		public bool PenetratedByMainEnSession(string IDCharacter)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(IDCharacter).CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.penetration) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00011480 File Offset: 0x0000F680
		[Obsolete("", true)]
		public bool PenetratedByMainPorParteEnSession(string IDCharacter, string parteQuePuedeEstimular)
		{
			return false;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00011484 File Offset: 0x0000F684
		public bool EstimuladoByMainEnSession()
		{
			bool flag;
			try
			{
				string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
				float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
				float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
				TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
				int num = Convert.ToInt32(asFloat2);
				InterationReceivedType interationReceivedType_Recibida = tipoDeEstimulo.GetInterationReceivedType_Recibida(num);
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(lastConversantID).CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, interationReceivedType_Recibida) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00011510 File Offset: 0x0000F710
		public bool EstimuladoByMainEnSessionANY(LuaTable partes)
		{
			bool flag;
			try
			{
				if (partes.Length == 0)
				{
					flag = false;
				}
				else
				{
					string lastConversantID = Singleton<DialogueSystemCharacterIDVariables>.instance.lastConversantID;
					float asFloat = DialogueLua.GetVariable("TipoDeEstimulo").AsFloat;
					float asFloat2 = DialogueLua.GetVariable("TipoDeEstimuloEspecifico").AsFloat;
					TipoDeEstimulo tipoDeEstimulo = (TipoDeEstimulo)Convert.ToInt32(asFloat);
					int num = Convert.ToInt32(asFloat2);
					InterationReceivedType interationReceivedType_Recibida = tipoDeEstimulo.GetInterationReceivedType_Recibida(num);
					MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereacciones(lastConversantID);
					using (IEnumerator<LuaValue> enumerator = partes.ListValues.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							if (enumerator.Current.Value.ToString().TryObtenerParteDelCuerpoHumano(out parteDelCuerpoHumano) && memoriaDeIntereaccionesDeCharacter.CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, interationReceivedType_Recibida, parteDelCuerpoHumano.GetPart()) > 0)
							{
								return true;
							}
						}
					}
					flag = false;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00011608 File Offset: 0x0000F808
		public bool CurrentConversantFotografiadaEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.photoshoot) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x00011650 File Offset: 0x0000F850
		public bool CurrentConversantAcariciadaEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.caress) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00011698 File Offset: 0x0000F898
		public bool CurrentConversantSolicitadaCambiarDePoseEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.askToPose) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000116E0 File Offset: 0x0000F8E0
		public bool CurrentConversantSolicitadaMoverBoneEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.guideBody) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00011728 File Offset: 0x0000F928
		public bool CurrentConversantCambiadaDePoseEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.forcePose) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00011770 File Offset: 0x0000F970
		public bool CurrentConversantManipuladaBoneEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.manipulateBody) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000117B8 File Offset: 0x0000F9B8
		public bool CurrentConversantSolicitadaDesvestirEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.askToExpose) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00011800 File Offset: 0x0000FA00
		public bool CurrentConversantDesvestidaEnSession()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaIntereaccionesDeConversant().CantidadDePlacenterosJunto(MainChar.current.ID_Unico, MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.session, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.recibido, InterationReceivedType.expose) > 0;
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

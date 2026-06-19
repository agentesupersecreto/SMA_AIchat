using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.Funciones
{
	// Token: 0x0200003C RID: 60
	public class RegistroDeFuncionesDeDesvestirPieza : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x00008BEC File Offset: 0x00006DEC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("DesvestirPiezaPosesivoPri", this, base.GetType().GetMethod("DesvestirPiezaPosesivoPri"));
			Lua.RegisterFunction("DesvestirPiezaPosesivoSeg", this, base.GetType().GetMethod("DesvestirPiezaPosesivoSeg"));
			Lua.RegisterFunction("DesvestirPiezaNombre", this, base.GetType().GetMethod("DesvestirPiezaNombre"));
			Lua.RegisterFunction("EsPiezaUsada", this, base.GetType().GetMethod("EsPiezaUsada"));
			Lua.RegisterFunction("EsConsentidoDesvestirPieza", this, base.GetType().GetMethod("EsConsentidoDesvestirPieza"));
			Lua.RegisterFunction("DijoDesvestirPiezaNoConsentido", this, base.GetType().GetMethod("DijoDesvestirPiezaNoConsentido"));
			Lua.RegisterFunction("RegisDijoDesvestirPiezaNoConsentido", this, base.GetType().GetMethod("RegisDijoDesvestirPiezaNoConsentido"));
			Lua.RegisterFunction("DijoDesvestidaPiezaNoNecesario", this, base.GetType().GetMethod("DijoDesvestidaPiezaNoNecesario"));
			Lua.RegisterFunction("RegisDijoDesvestidaPiezaNoNecesario", this, base.GetType().GetMethod("RegisDijoDesvestidaPiezaNoNecesario"));
			Lua.RegisterFunction("DijoDesvestidaPiezaAcepto", this, base.GetType().GetMethod("DijoDesvestidaPiezaAcepto"));
			Lua.RegisterFunction("RegisDijoDesvestidaPiezaAcepto", this, base.GetType().GetMethod("RegisDijoDesvestidaPiezaAcepto"));
			Lua.RegisterFunction("PiezaDeRopaEsSobornada", this, base.GetType().GetMethod("PiezaDeRopaEsSobornada"));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00008D44 File Offset: 0x00006F44
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("DesvestirPiezaPosesivoPri");
			Lua.UnregisterFunction("DesvestirPiezaPosesivoSeg");
			Lua.UnregisterFunction("DesvestirPiezaNombre");
			Lua.UnregisterFunction("EsPiezaUsada");
			Lua.UnregisterFunction("EsConsentidoDesvestirPieza");
			Lua.UnregisterFunction("DijoDesvestirPiezaNoConsentido");
			Lua.UnregisterFunction("RegisDijoDesvestirPiezaNoConsentido");
			Lua.UnregisterFunction("DijoDesvestidaPiezaNoNecesario");
			Lua.UnregisterFunction("RegisDijoDesvestidaPiezaNoNecesario");
			Lua.UnregisterFunction("DijoDesvestidaPiezaAcepto");
			Lua.UnregisterFunction("RegisDijoDesvestidaPiezaAcepto");
			Lua.UnregisterFunction("PiezaDeRopaEsSobornada");
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00008DD0 File Offset: 0x00006FD0
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00008DF0 File Offset: 0x00006FF0
		public bool PiezaDeRopaEsSobornada(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				string text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				MapaDeRopa.RopaData ropaData = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(text);
				ConsentCorrupted consentCorrupted = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante();
				foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
				{
					if (num != 0 && ((int)ropaData.cubreFlag).HasFlag(num) && consentCorrupted.EsCorrupted(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ((RopaCubre)num).ParceToParteDelCuerpoHumano(), ParteQuePuedeEstimular.boca, null))
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

		// Token: 0x060001C6 RID: 454 RVA: 0x00008EC8 File Offset: 0x000070C8
		public bool DijoDesvestirPiezaNoConsentido(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				flag = componentInChildrenNotNull.RegistradaPeticion_Negada(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008F18 File Offset: 0x00007118
		public void RegisDijoDesvestirPiezaNoConsentido(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				componentInChildrenNotNull.RegistrarPeticion_Negada(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00008F64 File Offset: 0x00007164
		public bool DijoDesvestidaPiezaNoNecesario(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				flag = componentInChildrenNotNull.RegistradaPeticion_FueraDeRango(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00008FB4 File Offset: 0x000071B4
		public void RegisDijoDesvestidaPiezaNoNecesario(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				componentInChildrenNotNull.RegistrarPeticion_FueraDeRango(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00009000 File Offset: 0x00007200
		public bool DijoDesvestidaPiezaAcepto(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				flag = componentInChildrenNotNull.RegistradaPeticion_Cumplida(text);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00009050 File Offset: 0x00007250
		public void RegisDijoDesvestidaPiezaAcepto(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				OpcionesDeTHSDonaDePiezaDeRopaPuesta componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>();
				IRopaManager componentInChildren2 = character.GetComponentInChildren<IRopaManager>();
				string text = componentInChildren.selectedKeys.Last<string>();
				this.m_ropaIdTemp.Add(text);
				RegistroDeFuncionesDeDesvestirPieza.RegistrarDijoDesvestidaPiezaAcepto(componentInChildrenNotNull, this.m_ropaIdTemp);
				RegistroDeFuncionesDeDesvestirParte.RegistrarDijoDesvestidaParteAcepto(componentInChildren2, componentInChildrenNotNull, this.m_ropaIdTemp);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			finally
			{
				this.m_ropaIdTemp.Clear();
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000090DC File Offset: 0x000072DC
		public static void RegistrarDijoDesvestidaPiezaAcepto(MemoriaDeRegistroDePeticionesDeQuitarRopa mem, IReadOnlyList<string> ropaIDs)
		{
			foreach (string text in ropaIDs)
			{
				mem.RegistrarPeticion_Cumplida(text);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00009124 File Offset: 0x00007324
		public bool EsConsentidoDesvestirPieza(string id, bool modificarResultado)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				OpcionesDeTHSDonaDePiezaDeRopaPuesta componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>();
				ConsentNecesario componentInChildren2 = character.GetComponentInChildren<ConsentNecesario>();
				string text = componentInChildren.selectedKeys.Last<string>();
				RopaCubre ropaCubre = character.GetComponentInChildren<IRopaManager>().CurrentPiezaCubreFlags(text, true);
				componentInChildren.puedeDesvestirse = RegistroDeFuncionesDeDesvestirParte.EsConsentidoDesvestirParteFlags(character, componentInChildren2, modificarResultado, ropaCubre, Sexo.femenino, null);
				flag = componentInChildren.puedeDesvestirse;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00009198 File Offset: 0x00007398
		public bool EsPiezaUsada(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				string text = character.GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				flag = character.GetComponentInChildren<IRopaManager>().Usando(text, true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000091E8 File Offset: 0x000073E8
		public string DesvestirPiezaNombre(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selected.Last<THSDonaController.RadialItemData>().text.ToLowerInvariant();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00009244 File Offset: 0x00007444
		public string DesvestirPiezaPosesivoPri(string id)
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(id);
				string text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(text).nombreEsPlural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000092AC File Offset: 0x000074AC
		public string DesvestirPiezaPosesivoSeg(string id)
		{
			string text2;
			try
			{
				Guid guid = Guid.Parse(id);
				string text = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDePiezaDeRopaPuesta>().selectedKeys.Last<string>();
				text2 = ObtenerDialogosUtil.ObtenerPosesivoSegundaPersona(AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(text).nombreEsPlural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x040000D6 RID: 214
		private List<string> m_ropaIdTemp = new List<string>();
	}
}

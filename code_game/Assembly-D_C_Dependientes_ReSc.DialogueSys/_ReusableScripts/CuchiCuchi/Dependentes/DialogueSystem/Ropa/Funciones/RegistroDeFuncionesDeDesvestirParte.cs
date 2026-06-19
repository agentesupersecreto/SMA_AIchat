using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Textos;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.Funciones
{
	// Token: 0x0200003B RID: 59
	public class RegistroDeFuncionesDeDesvestirParte : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060001AD RID: 429 RVA: 0x0000810C File Offset: 0x0000630C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("DesvestirParteNombreM", this, base.GetType().GetMethod("DesvestirParteNombreM"));
			Lua.RegisterFunction("DesvestirPartePosesivoPri", this, base.GetType().GetMethod("DesvestirPartePosesivoPri"));
			Lua.RegisterFunction("DesvestirParteNombreF", this, base.GetType().GetMethod("DesvestirParteNombreF"));
			Lua.RegisterFunction("DesvestirParteNombreFemDesdeMale", this, base.GetType().GetMethod("DesvestirParteNombreFemDesdeMale"));
			Lua.RegisterFunction("DesvestirPartePosesivoSeg", this, base.GetType().GetMethod("DesvestirPartePosesivoSeg"));
			Lua.RegisterFunction("EsParteCubierta", this, base.GetType().GetMethod("EsParteCubierta"));
			Lua.RegisterFunction("EsConsentidoDesvestirParte", this, base.GetType().GetMethod("EsConsentidoDesvestirParte"));
			Lua.RegisterFunction("DijoDesvestirParteNoConsentido", this, base.GetType().GetMethod("DijoDesvestirParteNoConsentido"));
			Lua.RegisterFunction("RegisDijoDesvestirParteNoConsentido", this, base.GetType().GetMethod("RegisDijoDesvestirParteNoConsentido"));
			Lua.RegisterFunction("DijoDesvestidaParteNoNecesario", this, base.GetType().GetMethod("DijoDesvestidaParteNoNecesario"));
			Lua.RegisterFunction("RegisDijoDesvestidaParteNoNecesario", this, base.GetType().GetMethod("RegisDijoDesvestidaParteNoNecesario"));
			Lua.RegisterFunction("DijoDesvestidaParteAcepto", this, base.GetType().GetMethod("DijoDesvestidaParteAcepto"));
			Lua.RegisterFunction("RegisDijoDesvestidaParteAcepto", this, base.GetType().GetMethod("RegisDijoDesvestidaParteAcepto"));
			Lua.RegisterFunction("ParteDesvestibleEsSobornada", this, base.GetType().GetMethod("ParteDesvestibleEsSobornada"));
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000829C File Offset: 0x0000649C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("DesvestirParteNombreM");
			Lua.UnregisterFunction("DesvestirPartePosesivoPri");
			Lua.UnregisterFunction("DesvestirParteNombreF");
			Lua.UnregisterFunction("DesvestirParteNombreFemDesdeMale");
			Lua.UnregisterFunction("DesvestirPartePosesivoSeg");
			Lua.UnregisterFunction("EsParteCubierta");
			Lua.UnregisterFunction("EsConsentidoDesvestirParte");
			Lua.UnregisterFunction("DijoDesvestirParteNoConsentido");
			Lua.UnregisterFunction("RegisDijoDesvestirParteNoConsentido");
			Lua.UnregisterFunction("DijoDesvestidaParteNoNecesario");
			Lua.UnregisterFunction("RegisDijoDesvestidaParteNoNecesario");
			Lua.UnregisterFunction("DijoDesvestidaParteAcepto");
			Lua.UnregisterFunction("RegisDijoDesvestidaParteAcepto");
			Lua.UnregisterFunction("ParteDesvestibleEsSobornada");
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000833C File Offset: 0x0000653C
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000835C File Offset: 0x0000655C
		public bool ParteDesvestibleEsSobornada(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				OpcionesDeTHSDonaDeRopaCubreConTextoMutado componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>();
				character.GetComponentInChildren<ConsentNecesario>();
				RopaCubre ropaCubre = componentInChildren.selectedEnums.Last<RopaCubre>();
				IRopaManager componentInChildren2 = character.GetComponentInChildren<IRopaManager>();
				componentInChildren2.CantidadPiezasCubriendo(ropaCubre, true, RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP);
				RopaCubre ropaCubre2 = RopaCubre.None;
				for (int i = 0; i < RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP.Count; i++)
				{
					ropaCubre2 |= componentInChildren2.PiezaCubreFlags(RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP[i], true);
				}
				ConsentCorrupted consentCorrupted = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante();
				foreach (int num in typeof(RopaCubre).GetEnumValoresInt())
				{
					if (num != 0 && ((int)ropaCubre2).HasFlag(num) && consentCorrupted.EsCorrupted(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ((RopaCubre)num).ParceToParteDelCuerpoHumano(), ParteQuePuedeEstimular.boca, null))
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

		// Token: 0x060001B1 RID: 433 RVA: 0x00008468 File Offset: 0x00006668
		public bool DijoDesvestirParteNoConsentido(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				flag = componentInChildrenNotNull.RegistradaPeticion_Negada(ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000084B8 File Offset: 0x000066B8
		public void RegisDijoDesvestirParteNoConsentido(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				componentInChildrenNotNull.RegistrarPeticion_Negada(ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00008504 File Offset: 0x00006704
		public bool DijoDesvestidaParteNoNecesario(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				flag = componentInChildrenNotNull.RegistradaPeticion_FueraDeRango(ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00008554 File Offset: 0x00006754
		public void RegisDijoDesvestidaParteNoNecesario(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				componentInChildrenNotNull.RegistrarPeticion_FueraDeRango(ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000085A0 File Offset: 0x000067A0
		public bool DijoDesvestidaParteAcepto(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				flag = componentInChildrenNotNull.RegistradaPeticion_Cumplida(ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x000085F0 File Offset: 0x000067F0
		public void RegisDijoDesvestidaParteAcepto(string id)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				MemoriaDeRegistroDePeticionesDeQuitarRopa componentInChildrenNotNull = character.GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>();
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				IRopaManager componentInChildren = character.GetComponentInChildren<IRopaManager>();
				componentInChildren.CantidadPiezasCubriendo(ropaCubre, true, this.m_idsDesvestidas);
				RegistroDeFuncionesDeDesvestirParte.RegistrarDijoDesvestidaParteAcepto(componentInChildren, componentInChildrenNotNull, this.m_idsDesvestidas);
				RegistroDeFuncionesDeDesvestirPieza.RegistrarDijoDesvestidaPiezaAcepto(componentInChildrenNotNull, this.m_idsDesvestidas);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			finally
			{
				this.m_idsDesvestidas.Clear();
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000867C File Offset: 0x0000687C
		public static void RegistrarDijoDesvestidaParteAcepto(IRopaManager manager, MemoriaDeRegistroDePeticionesDeQuitarRopa mem, IReadOnlyList<string> ropaIDs)
		{
			try
			{
				RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
				IReadOnlyList<int> enumValoresInt = typeof(RopaCubre).GetEnumValoresInt();
				foreach (string text in ropaIDs)
				{
					MapaDeRopa.RopaData ropaData = instance.ObtenerData(text);
					foreach (int num in enumValoresInt)
					{
						if (num != 0 && ((int)ropaData.cubreFlag).HasFlag(num))
						{
							RegistroDeFuncionesDeDesvestirParte.m_DesvestidasRopaCubre.Add(num);
						}
					}
				}
				foreach (int num2 in RegistroDeFuncionesDeDesvestirParte.m_DesvestidasRopaCubre)
				{
					mem.RegistrarPeticion_Cumplida((RopaCubre)num2);
				}
			}
			finally
			{
				RegistroDeFuncionesDeDesvestirParte.m_DesvestidasRopaCubre.Clear();
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00008790 File Offset: 0x00006990
		public bool EsConsentidoDesvestirParte(string id, bool modificarResultado)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				OpcionesDeTHSDonaDeRopaCubreConTextoMutado componentInChildren = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>();
				ConsentNecesario componentInChildren2 = character.GetComponentInChildren<ConsentNecesario>();
				RopaCubre ropaCubre = componentInChildren.selectedEnums.Last<RopaCubre>();
				IRopaManager componentInChildren3 = character.GetComponentInChildren<IRopaManager>();
				componentInChildren3.CantidadPiezasCubriendo(ropaCubre, true, RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP);
				RopaCubre ropaCubre2 = RopaCubre.None;
				for (int i = 0; i < RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP.Count; i++)
				{
					ropaCubre2 |= componentInChildren3.PiezaCubreFlags(RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP[i], true);
				}
				componentInChildren.puedeDesvestir = RegistroDeFuncionesDeDesvestirParte.EsConsentidoDesvestirParteFlags(character, componentInChildren2, modificarResultado, ropaCubre2, Sexo.femenino, componentInChildren.personalidad);
				flag = componentInChildren.puedeDesvestir;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			finally
			{
				RegistroDeFuncionesDeDesvestirParte.m_piezasCubriendoTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008860 File Offset: 0x00006A60
		public static bool EsConsentidoDesvestirParteFlags(Character character, ConsentNecesario necesario, bool modificarResultado, RopaCubre flags, Sexo sexo, Personalidad personalidad = null)
		{
			bool flag;
			try
			{
				if (flags == RopaCubre.None)
				{
					flag = true;
				}
				else
				{
					flags = flags.FiltrarFlags(sexo);
					if (flags == RopaCubre.None)
					{
						Debug.LogError("al filtrar flags de piezacubre, estas flags quedaron vacias");
						flag = false;
					}
					else
					{
						flags.FlagsToList(RegistroDeFuncionesDeDesvestirParte.m_PartesADescubrirTEMP);
						if (RegistroDeFuncionesDeDesvestirParte.m_PartesADescubrirTEMP.Count == 0)
						{
							flag = true;
						}
						else
						{
							float num;
							ParteDelCuerpoHumano parteDelCuerpoHumano;
							float? num2;
							ParteDelCuerpoHumano? parteDelCuerpoHumano2;
							bool flag2 = necesario.TodosConsentidosConJerarquia(RegistroDeFuncionesDeDesvestirParte.m_PartesADescubrirTEMP, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, 1f, null, null, null);
							if (!flag2)
							{
								flag = false;
							}
							else if (!modificarResultado)
							{
								flag = flag2;
							}
							else
							{
								character.GetComponentInChildren<IRopaManager>();
								int num3 = 1;
								if (personalidad == null)
								{
									personalidad = character.GetComponentInChildren<Personalidad>();
								}
								flag = ((0.5f + (personalidad.sumicion + personalidad.exhibicionismo + personalidad.perverticidad) / 3f * 0.5f).OutPow(2f) / (1f + 0.5f * (float)(num3 - 1))).ProcMod(num);
							}
						}
					}
				}
			}
			finally
			{
				RegistroDeFuncionesDeDesvestirParte.m_PartesADescubrirTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000897C File Offset: 0x00006B7C
		public bool EsParteCubierta(string id)
		{
			bool flag;
			try
			{
				Character character = this.ObtenerCharacter(id);
				RopaCubre ropaCubre = character.GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				flag = character.GetComponentInChildren<IRopaManager>().CantidadPiezasCubriendo(ropaCubre, true, null) > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000089D0 File Offset: 0x00006BD0
		public string DesvestirParteNombreM(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				text = OpcionesDeTHSDonaDeRopaCubreConTextoMutado.NombreLocalizadoNoMutadoDeRopaCubre(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>());
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00008A28 File Offset: 0x00006C28
		public string DesvestirParteNombreF(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				RopaCubre ropaCubre = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				text = OpcionesDeTHSDonaDeRopaCubreConTextoMutado.NombreLocalizadoMutadoDeRopaCubre((Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.femenino, ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00008A90 File Offset: 0x00006C90
		public string DesvestirParteNombreFemDesdeMale(string conversantID)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(conversantID);
				RopaCubre ropaCubre = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>();
				text = OpcionesDeTHSDonaDeRopaCubreConTextoMutado.NombreLocalizadoMutadoDeRopaCubre((Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.femenino, ropaCubre);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public string DesvestirPartePosesivoPri(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				text = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(OpcionesDeTHSDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>()).plural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00008B58 File Offset: 0x00006D58
		public string DesvestirPartePosesivoSeg(string id)
		{
			string text;
			try
			{
				Guid guid = Guid.Parse(id);
				text = ObtenerDialogosUtil.ObtenerPosesivoSegundaPersona(OpcionesDeTHSDonaDeRopaCubreConTextoMutado.DialogoDeRopaCubre(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<OpcionesDeTHSDonaDeRopaCubreConTextoMutado>().selectedEnums.Last<RopaCubre>()).plural, DireccionDeEstimulo.recibida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x040000D2 RID: 210
		private List<string> m_idsDesvestidas = new List<string>();

		// Token: 0x040000D3 RID: 211
		private static HashSet<int> m_DesvestidasRopaCubre = new HashSet<int>();

		// Token: 0x040000D4 RID: 212
		private static List<string> m_piezasCubriendoTEMP = new List<string>();

		// Token: 0x040000D5 RID: 213
		private static List<ParteDelCuerpoHumano> m_PartesADescubrirTEMP = new List<ParteDelCuerpoHumano>();
	}
}

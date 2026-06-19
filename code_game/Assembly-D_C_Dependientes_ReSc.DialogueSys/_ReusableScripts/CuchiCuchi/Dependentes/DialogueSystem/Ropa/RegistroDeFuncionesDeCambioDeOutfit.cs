using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Chars.Ropa.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.Textos;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa
{
	// Token: 0x02000032 RID: 50
	public class RegistroDeFuncionesDeCambioDeOutfit : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000170 RID: 368 RVA: 0x000071B4 File Offset: 0x000053B4
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("EsConsentidoCurrentSelectedOutfit", this, base.GetType().GetMethod("EsConsentidoCurrentSelectedOutfit"));
			Lua.RegisterFunction("MiParteNoConsentidoParaOutfitLocalizado", this, base.GetType().GetMethod("MiParteNoConsentidoParaOutfitLocalizado"));
			Lua.RegisterFunction("MiParteNoConsentidoParaOutfitLocalizadoConMedio", this, base.GetType().GetMethod("MiParteNoConsentidoParaOutfitLocalizadoConMedio"));
			Lua.RegisterFunction("PoseePrendasDeRopaDeCurrentConjunto", this, base.GetType().GetMethod("PoseePrendasDeRopaDeCurrentConjunto"));
			Lua.RegisterFunction("CambiarAtuendo", this, base.GetType().GetMethod("CambiarAtuendo"));
			Lua.RegisterFunction("CambiarAtuendoCheap", this, base.GetType().GetMethod("CambiarAtuendoCheap"));
			Lua.RegisterFunction("CambiarAtuendoCommon", this, base.GetType().GetMethod("CambiarAtuendoCommon"));
			Lua.RegisterFunction("CambiarAtuendoExpensive", this, base.GetType().GetMethod("CambiarAtuendoExpensive"));
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000072A0 File Offset: 0x000054A0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("EsConsentidoCurrentSelectedOutfit");
			Lua.UnregisterFunction("MiParteNoConsentidoParaOutfitLocalizado");
			Lua.UnregisterFunction("MiParteNoConsentidoParaOutfitLocalizadoConMedio");
			Lua.UnregisterFunction("PoseePrendasDeRopaDeCurrentConjunto");
			Lua.UnregisterFunction("CambiarAtuendo");
			Lua.UnregisterFunction("CambiarAtuendoCheap");
			Lua.UnregisterFunction("CambiarAtuendoCommon");
			Lua.UnregisterFunction("CambiarAtuendoExpensive");
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00007304 File Offset: 0x00005504
		public bool PoseePrendasDeRopaDeCurrentConjunto()
		{
			bool flag;
			try
			{
				JsonUtility.FromJson<ConjuntoDeRopa>(DialogueLua.GetVariable(DiccMemOutfits.currentConjuntoSerializedData).AsString);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00007348 File Offset: 0x00005548
		public bool EsConsentidoCurrentSelectedOutfit()
		{
			bool flag2;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				ConsentNecesario componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentNecesario>();
				RopaCubre asInt = (RopaCubre)DialogueLua.GetVariable(DiccMemOutfits.currentConjuntoCubreFlags).AsInt;
				HashSet<int> hashSet = new HashSet<int>();
				foreach (object obj in typeof(RopaCubre).GetEnumValoresObject())
				{
					RopaCubre ropaCubre = (RopaCubre)obj;
					if (ropaCubre != RopaCubre.None && !((int)asInt).HasFlag((int)ropaCubre))
					{
						hashSet.Add((int)ropaCubre.ParceToParteDelCuerpoHumano());
					}
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
				ParteDelCuerpoHumano? parteDelCuerpoHumano2 = null;
				ParteDelCuerpoHumano[] array = (from ParteDelCuerpoHumano p in hashSet
					where p.EsFemenina()
					select p).ToArray<ParteDelCuerpoHumano>();
				float num;
				float? num2;
				bool flag = array.Length == 0 || componentInChildren.TodosConsentidosConJerarquia(array, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.boca, out num, out parteDelCuerpoHumano, out num2, out parteDelCuerpoHumano2, 1f, null, null, null);
				if (!flag)
				{
					DialogueLua.SetVariable(DiccMemOutfits.currentParteMenosConsentida, parteDelCuerpoHumano.ToString());
					if (parteDelCuerpoHumano2 != null)
					{
						DialogueLua.SetVariable(DiccMemOutfits.currentParteMasNoConsentida, parteDelCuerpoHumano2.Value.ToString());
					}
					else
					{
						DialogueLua.SetVariable(DiccMemOutfits.currentParteMasNoConsentida, string.Empty);
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

		// Token: 0x06000174 RID: 372 RVA: 0x00007508 File Offset: 0x00005708
		public string MiParteNoConsentidoParaOutfitLocalizado()
		{
			string text3;
			try
			{
				string text;
				string text2;
				RegistroDeFuncionesDeCambioDeOutfit.ObtenerMiDialogoYParteDialogoDeConversante(out text, out text2);
				text3 = text2 + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text3 = "ERROR";
			}
			return text3;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000754C File Offset: 0x0000574C
		public string MiParteNoConsentidoParaOutfitLocalizadoConMedio(string medio)
		{
			string text3;
			try
			{
				string text;
				string text2;
				RegistroDeFuncionesDeCambioDeOutfit.ObtenerMiDialogoYParteDialogoDeConversante(out text, out text2);
				text3 = string.Concat(new string[] { text2, " ", medio, " ", text });
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text3 = "ERROR";
			}
			return text3;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x000075AC File Offset: 0x000057AC
		public static void ObtenerMiDialogoYParteDialogoDeConversante(out string parteLocal, out string miLocal)
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (!string.IsNullOrWhiteSpace(DialogueLua.GetVariable(DiccMemOutfits.currentParteMasNoConsentida).AsString))
			{
				parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable(DiccMemOutfits.currentParteMasNoConsentida).AsString);
			}
			else
			{
				parteDelCuerpoHumano = RegistroDeFuncionesDeCanEstimular.ObtenerParteDelCuerpoHumano(DialogueLua.GetVariable(DiccMemOutfits.currentParteMenosConsentida).AsString);
			}
			DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo(parteDelCuerpoHumano, false);
			if (character is FemaleChar)
			{
				Personalidad componentInChildren = character.GetComponentInChildren<Personalidad>();
				parteLocal = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), Sexo.femenino, parteDelCuerpoHumano);
			}
			else
			{
				parteLocal = RegistroDeFuncionesDeCanEstimular.NombreLocalizadoMutadoDeParteDelCuerpoHumano(dialogoInfoParteDelCuerpo, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, Sexo.masculino, parteDelCuerpoHumano);
			}
			miLocal = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000076A0 File Offset: 0x000058A0
		public void CambiarAtuendo()
		{
			CameraFade.FadeOutMain(0f);
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ConjuntoDeRopaLoader componentInChildren = character.GetComponentInChildren<ConjuntoDeRopaLoader>();
				RopaCubre asInt = (RopaCubre)DialogueLua.GetVariable(DiccMemOutfits.currentConjuntoCubreFlags).AsInt;
				RopaCubre cubriendoFlags = componentInChildren.manager.cubriendoFlags;
				List<ValueTuple<string, RopaCubre>> list = new List<ValueTuple<string, RopaCubre>>();
				foreach (object obj in typeof(RopaCubre).GetEnumValoresObject())
				{
					RopaCubre ropaCubre = (RopaCubre)obj;
					if (ropaCubre != RopaCubre.None && ((int)cubriendoFlags).HasFlag((int)ropaCubre) && !((int)asInt).HasFlag((int)ropaCubre))
					{
						bool flag = false;
						foreach (PiezaDeRopaBase piezaDeRopaBase in componentInChildren.piezasPuestas)
						{
							if (((int)componentInChildren.CurrentPiezaCubreFlags(piezaDeRopaBase.dataDeRopa.stringId, true)).HasFlag((int)ropaCubre))
							{
								flag = true;
								list.Add(new ValueTuple<string, RopaCubre>(piezaDeRopaBase.dataDeRopa.stringId, ropaCubre));
							}
						}
						if (!flag)
						{
							list.Add(new ValueTuple<string, RopaCubre>(string.Empty, ropaCubre));
						}
					}
				}
				EstimulosPorQuitarPrendasDeRopa componentInChildren2 = character.GetComponentInChildren<EstimulosPorQuitarPrendasDeRopa>();
				if (componentInChildren2 != null)
				{
					foreach (ValueTuple<string, RopaCubre> valueTuple in list)
					{
						if (!string.IsNullOrWhiteSpace(valueTuple.Item1))
						{
							componentInChildren2.TryRegistrarPedido(valueTuple.Item1, false, false, CurrentMainCharacter<CurrentMainChar, MainChar>.current);
						}
					}
				}
				ConjuntoDeRopa conjuntoDeRopa = JsonUtility.FromJson<ConjuntoDeRopa>(DialogueLua.GetVariable(DiccMemOutfits.currentConjuntoSerializedData).AsString);
				ConjuntoDeRopa.VerificarYCorregirIntegridadPiezasConMsg(conjuntoDeRopa, null);
				ConjuntoDeRopa.VerificarYCorregirIntegridadMaterialesConMsg(conjuntoDeRopa, null);
				componentInChildren.StartCoroutine(componentInChildren.LoadConjuntoAsset(conjuntoDeRopa, true, delegate
				{
					CameraFade.FadeInMain(1f);
				}, true));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00007928 File Offset: 0x00005B28
		public void CambiarAtuendoCheap()
		{
			CameraFade.FadeOutMain(0f);
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				RopaAdminDeCharacter componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<RopaAdminDeCharacter>();
				componentInChildren.generated += this.RopaConjuntoGenerador_generated;
				base.StartCoroutine(componentInChildren.Generar(ItemQuality.Defective, 75f, null));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000079A8 File Offset: 0x00005BA8
		public void CambiarAtuendoCommon()
		{
			CameraFade.FadeOutMain(0f);
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				RopaAdminDeCharacter componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<RopaAdminDeCharacter>();
				componentInChildren.generated += this.RopaConjuntoGenerador_generated;
				base.StartCoroutine(componentInChildren.Generar(ItemQuality.Uncommon, 75f, null));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007A28 File Offset: 0x00005C28
		public void CambiarAtuendoExpensive()
		{
			CameraFade.FadeOutMain(0f);
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				RopaAdminDeCharacter componentInChildren = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<RopaAdminDeCharacter>();
				componentInChildren.generated += this.RopaConjuntoGenerador_generated;
				base.StartCoroutine(componentInChildren.Generar(ItemQuality.Legendary, 75f, null));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00007AAC File Offset: 0x00005CAC
		private void RopaConjuntoGenerador_generated(RopaAdminDeCharacter obj)
		{
			obj.generated -= this.RopaConjuntoGenerador_generated;
			CameraFade.FadeInMain(1f);
		}
	}
}

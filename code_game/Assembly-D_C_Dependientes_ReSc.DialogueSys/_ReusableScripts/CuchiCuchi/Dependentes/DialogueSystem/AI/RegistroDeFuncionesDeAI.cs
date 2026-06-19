using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.Funciones;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.NombresDePartesDelCuerpo;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using Assets._ReusableScripts.Textos;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI
{
	// Token: 0x02000073 RID: 115
	public class RegistroDeFuncionesDeAI : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600035F RID: 863 RVA: 0x00011860 File Offset: 0x0000FA60
		static RegistroDeFuncionesDeAI()
		{
			LuaAutoRegisterAttribute.Load(MethodBase.GetCurrentMethod().DeclaringType);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00011874 File Offset: 0x0000FA74
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			LuaAutoRegisterAttribute.Register(this);
			Lua.RegisterFunction("ResetDeseosDeConversante", this, base.GetType().GetMethod("ResetDeseosDeConversante"));
			Lua.RegisterFunction("EsTimido", this, base.GetType().GetMethod("EsTimido"));
			Lua.RegisterFunction("EsExtrovertido", this, base.GetType().GetMethod("EsExtrovertido"));
			Lua.RegisterFunction("EsSumiso", this, base.GetType().GetMethod("EsSumiso"));
			Lua.RegisterFunction("EsConversanteSumiso", this, base.GetType().GetMethod("EsConversanteSumiso"));
			Lua.RegisterFunction("EsPervertido", this, base.GetType().GetMethod("EsPervertido"));
			Lua.RegisterFunction("EsDesinhibido", this, base.GetType().GetMethod("EsDesinhibido"));
			Lua.RegisterFunction("EsRespetuoso", this, base.GetType().GetMethod("EsRespetuoso"));
			Lua.RegisterFunction("EsGrosero", this, base.GetType().GetMethod("EsGrosero"));
			Lua.RegisterFunction("EsHonesto", this, base.GetType().GetMethod("EsHonesto"));
			Lua.RegisterFunction("EsConversanteHonesto", this, base.GetType().GetMethod("EsConversanteHonesto"));
			Lua.RegisterFunction("EsConversanteAmable", this, base.GetType().GetMethod("EsConversanteAmable"));
			Lua.RegisterFunction("EsDeshonesto", this, base.GetType().GetMethod("EsDeshonesto"));
			Lua.RegisterFunction("EsExhibicionista", this, base.GetType().GetMethod("EsExhibicionista"));
			Lua.RegisterFunction("ConsentToHero", this, base.GetType().GetMethod("ConsentToHero"));
			Lua.RegisterFunction("MaxTipoDePersonalidad", this, base.GetType().GetMethod("MaxTipoDePersonalidad"));
			Lua.RegisterFunction("OportunidadesDeReaccion", this, base.GetType().GetMethod("OportunidadesDeReaccion"));
			Lua.RegisterFunction("CambiarEmocionAutoGestuadaPorTipoDeRespuestaLerp", this, base.GetType().GetMethod("CambiarEmocionAutoGestuadaPorTipoDeRespuestaLerp"));
			Lua.RegisterFunction("CambiarEmocion", this, base.GetType().GetMethod("CambiarEmocion"));
			Lua.RegisterFunction("CambiarEmocionDeConversante", this, base.GetType().GetMethod("CambiarEmocionDeConversante"));
			Lua.RegisterFunction("CambiarEmocionUnicaVez", this, base.GetType().GetMethod("CambiarEmocionUnicaVez"));
			Lua.RegisterFunction("PartesConsentidasCariciaStringCheat", this, base.GetType().GetMethod("PartesConsentidasCariciaStringCheat"));
			Lua.RegisterFunction("PartesConsentidasCoitoStringCheat", this, base.GetType().GetMethod("PartesConsentidasCoitoStringCheat"));
			Lua.RegisterFunction("PartesConsentidasClutchStringCheat", this, base.GetType().GetMethod("PartesConsentidasClutchStringCheat"));
			Lua.RegisterFunction("PartesConsentidasHumpStringCheat", this, base.GetType().GetMethod("PartesConsentidasHumpStringCheat"));
			Lua.RegisterFunction("PartesConsentidasCummingStringCheat", this, base.GetType().GetMethod("PartesConsentidasCummingStringCheat"));
			Lua.RegisterFunction("ConversantAtraidaSexualmenteVisualmenteAActor", this, base.GetType().GetMethod("ConversantAtraidaSexualmenteVisualmenteAActor"));
			Lua.RegisterFunction("ConversantAtraidaSexualmenteTactilmenteAActor", this, base.GetType().GetMethod("ConversantAtraidaSexualmenteTactilmenteAActor"));
			Lua.RegisterFunction("ConversantAtraidaSexualmenteCoitalmenteAActor", this, base.GetType().GetMethod("ConversantAtraidaSexualmenteCoitalmenteAActor"));
			Lua.RegisterFunction("ConversantNecesitaDinero", this, base.GetType().GetMethod("ConversantNecesitaDinero"));
			Lua.RegisterFunction("ConversantEstaAsustada", this, base.GetType().GetMethod("ConversantEstaAsustada"));
			Lua.RegisterFunction("ConversantEstaEnojada", this, base.GetType().GetMethod("ConversantEstaEnojada"));
			Lua.RegisterFunction("ConversantEstaAdolorida", this, base.GetType().GetMethod("ConversantEstaAdolorida"));
			Lua.RegisterFunction("ConversantEstaDecepcionada", this, base.GetType().GetMethod("ConversantEstaDecepcionada"));
			Lua.RegisterFunction("ConversantEstaExitada", this, base.GetType().GetMethod("ConversantEstaExitada"));
			Lua.RegisterFunction("ConversantHadSadisticOrgasm", this, base.GetType().GetMethod("ConversantHadSadisticOrgasm"));
			Lua.RegisterFunction("ConversantHadMasoquisticOrgasm", this, base.GetType().GetMethod("ConversantHadMasoquisticOrgasm"));
			Lua.RegisterFunction("ConversantHadHybristophilicOrgasm", this, base.GetType().GetMethod("ConversantHadHybristophilicOrgasm"));
			Lua.RegisterFunction("ConversantEsDominante", this, base.GetType().GetMethod("ConversantEsDominante"));
			Lua.RegisterFunction("ConversantEsMasoquista", this, base.GetType().GetMethod("ConversantEsMasoquista"));
			Lua.RegisterFunction("ConversantEsHibristofilica", this, base.GetType().GetMethod("ConversantEsHibristofilica"));
			Lua.RegisterFunction("ConversantEsSumisa", this, base.GetType().GetMethod("ConversantEsSumisa"));
			Lua.RegisterFunction("Conversant_MyBodyPartsDialog", this, base.GetType().GetMethod("Conversant_MyBodyPartsDialog"));
			Lua.RegisterFunction("Conversant_YourBodyPartsDialog", this, base.GetType().GetMethod("Conversant_YourBodyPartsDialog"));
			Lua.RegisterFunction("Actor_MyBodyPartsDialog", this, base.GetType().GetMethod("Actor_MyBodyPartsDialog"));
			Lua.RegisterFunction("Actor_YourBodyPartsDialog", this, base.GetType().GetMethod("Actor_YourBodyPartsDialog"));
			Lua.RegisterFunction("Conversant_BodyPartsDialog", this, base.GetType().GetMethod("Conversant_BodyPartsDialog"));
			Lua.RegisterFunction("Actor_BodyPartsDialog", this, base.GetType().GetMethod("Actor_BodyPartsDialog"));
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00011DA0 File Offset: 0x0000FFA0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			LuaAutoRegisterAttribute.Unregister(this);
			Lua.UnregisterFunction("ResetDeseosDeConversante");
			Lua.UnregisterFunction("EsTimido");
			Lua.UnregisterFunction("EsExtrovertido");
			Lua.UnregisterFunction("EsSumiso");
			Lua.UnregisterFunction("EsConversanteSumiso");
			Lua.UnregisterFunction("EsPervertido");
			Lua.UnregisterFunction("EsDesinhibido");
			Lua.UnregisterFunction("EsRespetuoso");
			Lua.UnregisterFunction("EsGrosero");
			Lua.UnregisterFunction("EsHonesto");
			Lua.UnregisterFunction("EsConversanteHonesto");
			Lua.UnregisterFunction("EsConversanteAmable");
			Lua.UnregisterFunction("EsDeshonesto");
			Lua.UnregisterFunction("EsExhibicionista");
			Lua.UnregisterFunction("ConsentToHero");
			Lua.UnregisterFunction("MaxTipoDePersonalidad");
			Lua.UnregisterFunction("OportunidadesDeReaccion");
			Lua.UnregisterFunction("CambiarEmocionAutoGestuadaPorTipoDeRespuestaLerp");
			Lua.UnregisterFunction("CambiarEmocion");
			Lua.UnregisterFunction("CambiarEmocionDeConversante");
			Lua.UnregisterFunction("CambiarEmocionUnicaVez");
			Lua.UnregisterFunction("PartesConsentidasCariciaStringCheat");
			Lua.UnregisterFunction("PartesConsentidasCoitoStringCheat");
			Lua.UnregisterFunction("PartesConsentidasClutchStringCheat");
			Lua.UnregisterFunction("PartesConsentidasHumpStringCheat");
			Lua.UnregisterFunction("PartesConsentidasCummingStringCheat");
			Lua.UnregisterFunction("ConversantAtraidaSexualmenteVisualmenteAActor");
			Lua.UnregisterFunction("ConversantAtraidaSexualmenteTactilmenteAActor");
			Lua.UnregisterFunction("ConversantAtraidaSexualmenteCoitalmenteAActor");
			Lua.UnregisterFunction("ConversantNecesitaDinero");
			Lua.UnregisterFunction("ConversantEstaAsustada");
			Lua.UnregisterFunction("ConversantEstaEnojada");
			Lua.UnregisterFunction("ConversantEstaAdolorida");
			Lua.UnregisterFunction("ConversantEstaDecepcionada");
			Lua.UnregisterFunction("ConversantEstaExitada");
			Lua.UnregisterFunction("ConversantHadSadisticOrgasm");
			Lua.UnregisterFunction("ConversantHadMasoquisticOrgasm");
			Lua.UnregisterFunction("ConversantHadHybristophilicOrgasm");
			Lua.UnregisterFunction("ConversantEsDominante");
			Lua.UnregisterFunction("ConversantEsMasoquista");
			Lua.UnregisterFunction("ConversantEsHibristofilica");
			Lua.UnregisterFunction("ConversantEsSumisa");
			Lua.UnregisterFunction("Conversant_MyBodyPartsDialog");
			Lua.UnregisterFunction("Conversant_YourBodyPartsDialog");
			Lua.UnregisterFunction("Actor_MyBodyPartsDialog");
			Lua.UnregisterFunction("Actor_YourBodyPartsDialog");
			Lua.UnregisterFunction("Conversant_BodyPartsDialog");
			Lua.UnregisterFunction("Actor_BodyPartsDialog");
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00011F9C File Offset: 0x0001019C
		private static Personalidad ObtenerPersonalidad(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<Personalidad>();
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00011FC0 File Offset: 0x000101C0
		public static Personalidad ObtenerPersonalidadDeConversante()
		{
			return RegistroDeFuncionesDeAI.ObtenerPersonalidad(DialogueLua.GetVariable("ConversantID").AsString);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00011FE4 File Offset: 0x000101E4
		private EmocionesFemeninas ObtenerEmosDeConversante()
		{
			string asString = DialogueLua.GetVariable("ConversantID").AsString;
			return this.ObtenerEmos(asString);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0001200C File Offset: 0x0001020C
		private EmocionesFemeninas ObtenerEmos(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<EmocionesFemeninas>();
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00012030 File Offset: 0x00010230
		public static ConsentNecesario ObtenerConsentNecesario(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentNecesario>();
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00012054 File Offset: 0x00010254
		public static ConsentCorrupted ObtenerConsentForzado(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<ConsentCorrupted>();
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00012078 File Offset: 0x00010278
		private static Deseos ObtenerDeseos(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<Deseos>();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0001209C File Offset: 0x0001029C
		public static ConsentNecesario ObtenerConsentNecesarioDeConversante()
		{
			return RegistroDeFuncionesDeAI.ObtenerConsentNecesario(DialogueLua.GetVariable("ConversantID").AsString);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000120C0 File Offset: 0x000102C0
		public static ConsentCorrupted ObtenerConsentForzadoDeConversante()
		{
			return RegistroDeFuncionesDeAI.ObtenerConsentForzado(DialogueLua.GetVariable("ConversantID").AsString);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000120E4 File Offset: 0x000102E4
		public static Deseos ObtenerDeseosDeConversante()
		{
			return RegistroDeFuncionesDeAI.ObtenerDeseos(DialogueLua.GetVariable("ConversantID").AsString);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00012108 File Offset: 0x00010308
		public static ICharactersSceneInteractionsArchived GetArchivedMainAndSecInteractionBetweenActorAndConversant()
		{
			if (!Singleton<InteraccionesEnScena>.IsInScene)
			{
				return null;
			}
			string asString = DialogueLua.GetVariable("ConversantID").AsString;
			string asString2 = DialogueLua.GetVariable("ActorID").AsString;
			Guid guid = Guid.Parse(asString);
			Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
			Guid guid2 = Guid.Parse(asString2);
			Character character2 = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid2);
			return Singleton<InteraccionesEnScena>.instance.GetMainAndSecondaryArchivedInteractions(character2, character);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00012178 File Offset: 0x00010378
		public static Character GetConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000121A8 File Offset: 0x000103A8
		public static Character GetActor()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ActorID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000121D8 File Offset: 0x000103D8
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000121F8 File Offset: 0x000103F8
		public void ResetDeseosDeConversante()
		{
			try
			{
				RegistroDeFuncionesDeAI.ObtenerDeseosDeConversante().ResetDeseos();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001222C File Offset: 0x0001042C
		private static ParteDelCuerpoHumano ObtenerParteDelCuerpoHumano(string parte)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			if (Enum.TryParse<ParteDelCuerpoHumano>(parte, out parteDelCuerpoHumano))
			{
				return parteDelCuerpoHumano;
			}
			Debug.LogError("No se pudo convertir string: " + parte + " a enum.");
			return ParteDelCuerpoHumano.pecho;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001225C File Offset: 0x0001045C
		private static string NombreLocalizadoMutadoDeParteDelCuerpoHumano(DialogoInfoParteDelCuerpo diag, RestriccionDeEdad restriccion, Sexo sexRestriction, ParteDelCuerpoHumano parte)
		{
			if (diag == null)
			{
				string text = parte.ToString();
				Debug.LogError("No se pudo hallar nombre de parte del cuerpo localizado, " + text);
				return text;
			}
			return diag.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccion, sexRestriction, 2);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000122B0 File Offset: 0x000104B0
		private static string NombreParte(Character c, string parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte tipo, Sexo sexoDePArte, out DialogoInfoParteDelCuerpo diag)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = RegistroDeFuncionesDeAI.ObtenerParteDelCuerpoHumano(parteString);
			switch (tipo)
			{
			case RegistroDeFuncionesDeAI.TipoDeNombreDeParte.primero:
				diag = Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroDeCurrentLocalization(parteDelCuerpoHumano);
				break;
			case RegistroDeFuncionesDeAI.TipoDeNombreDeParte.real:
				diag = Singleton<NombresLocalizadosDePartes>.instance.ObtenerRealDeCurrentLocalization(parteDelCuerpoHumano);
				break;
			case RegistroDeFuncionesDeAI.TipoDeNombreDeParte.plural:
				diag = Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroPluralDeCurrentLocalization(parteDelCuerpoHumano);
				break;
			case RegistroDeFuncionesDeAI.TipoDeNombreDeParte.singular:
				diag = Singleton<NombresLocalizadosDePartes>.instance.ObtenerPrimeroSingularDeCurrentLocalization(parteDelCuerpoHumano);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			string text;
			if (c is FemaleChar)
			{
				Personalidad componentInChildren = c.GetComponentInChildren<Personalidad>();
				text = RegistroDeFuncionesDeAI.NombreLocalizadoMutadoDeParteDelCuerpoHumano(diag, ((componentInChildren != null) ? new RestriccionDeEdad?(componentInChildren.ObtenerRestriccion()) : null).GetValueOrDefault(RestriccionDeEdad.adolecentes), sexoDePArte, parteDelCuerpoHumano);
			}
			else
			{
				text = RegistroDeFuncionesDeAI.NombreLocalizadoMutadoDeParteDelCuerpoHumano(diag, (Random.value > 0.5f) ? RestriccionDeEdad.adultos : RestriccionDeEdad.adolecentes, sexoDePArte, parteDelCuerpoHumano);
			}
			return text;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001238C File Offset: 0x0001058C
		public string Conversant_MyBodyPartsDialog(string parteString)
		{
			string text2;
			try
			{
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				string text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetConversant(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.primero, Sexo.femenino, out dialogoInfoParteDelCuerpo);
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000123E4 File Offset: 0x000105E4
		public string Conversant_YourBodyPartsDialog(string parteString)
		{
			string text2;
			try
			{
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				string text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetConversant(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.primero, Sexo.masculino, out dialogoInfoParteDelCuerpo);
				text2 = ObtenerDialogosUtil.ObtenerPosesivoSegundaPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001243C File Offset: 0x0001063C
		public string Actor_MyBodyPartsDialog(string parteString)
		{
			string text2;
			try
			{
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				string text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetActor(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.primero, Sexo.masculino, out dialogoInfoParteDelCuerpo);
				text2 = ObtenerDialogosUtil.ObtenerPosesivoPrimeraPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00012494 File Offset: 0x00010694
		public string Actor_YourBodyPartsDialog(string parteString)
		{
			string text2;
			try
			{
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				string text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetActor(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.primero, Sexo.femenino, out dialogoInfoParteDelCuerpo);
				text2 = ObtenerDialogosUtil.ObtenerPosesivoSegundaPersona(dialogoInfoParteDelCuerpo.plural, DireccionDeEstimulo.recibida) + " " + text;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000124EC File Offset: 0x000106EC
		public string Conversant_BodyPartsDialog(string parteString, string parteSexoString)
		{
			string text;
			try
			{
				Sexo sexo;
				if (!Enum.TryParse<Sexo>(parteSexoString, out sexo))
				{
					Debug.LogError("no se pudo cambiar " + parteSexoString + " a sexo");
					sexo = Sexo.noDefinido;
				}
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetConversant(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.plural, sexo, out dialogoInfoParteDelCuerpo);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0001254C File Offset: 0x0001074C
		public string Actor_BodyPartsDialog(string parteString, string parteSexoString)
		{
			string text;
			try
			{
				Sexo sexo;
				if (!Enum.TryParse<Sexo>(parteSexoString, out sexo))
				{
					Debug.LogError("no se pudo cambiar " + parteSexoString + " a sexo");
					sexo = Sexo.noDefinido;
				}
				DialogoInfoParteDelCuerpo dialogoInfoParteDelCuerpo;
				text = RegistroDeFuncionesDeAI.NombreParte(RegistroDeFuncionesDeAI.GetActor(), parteString, RegistroDeFuncionesDeAI.TipoDeNombreDeParte.plural, sexo, out dialogoInfoParteDelCuerpo);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000125AC File Offset: 0x000107AC
		public bool ConversantEsDominante()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().actuaComoDominante;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000125E4 File Offset: 0x000107E4
		public bool ConversantEsMasoquista()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().actuaComoMasoquista;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0001261C File Offset: 0x0001081C
		public bool ConversantEsHibristofilica()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().actuaComoHibristofilica;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00012654 File Offset: 0x00010854
		public bool ConversantEsSumisa()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().actuaComoSumisa;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001268C File Offset: 0x0001088C
		public bool ConversantHadSadisticOrgasm()
		{
			bool flag;
			try
			{
				EmotionDamagePair emotionDamagePair;
				RegistroDeFuncionesDeAI.GetArchivedMainAndSecInteractionBetweenActorAndConversant().PeekEmotionDamagePair(Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.rage, EmotionPercentageRange.ninetyToOneHundred, out emotionDamagePair);
				flag = emotionDamagePair.isValid && emotionDamagePair.times > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x000126E0 File Offset: 0x000108E0
		public bool ConversantHadMasoquisticOrgasm()
		{
			bool flag;
			try
			{
				EmotionDamagePair emotionDamagePair;
				RegistroDeFuncionesDeAI.GetArchivedMainAndSecInteractionBetweenActorAndConversant().PeekEmotionDamagePair(Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.pain, EmotionPercentageRange.ninetyToOneHundred, out emotionDamagePair);
				flag = emotionDamagePair.isValid && emotionDamagePair.times > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00012734 File Offset: 0x00010934
		public bool ConversantHadHybristophilicOrgasm()
		{
			bool flag;
			try
			{
				EmotionDamagePair emotionDamagePair;
				RegistroDeFuncionesDeAI.GetArchivedMainAndSecInteractionBetweenActorAndConversant().PeekEmotionDamagePair(Emotion.pleasure, EmotionPercentageRange.oneHundred, Emotion.fear, EmotionPercentageRange.ninetyToOneHundred, out emotionDamagePair);
				flag = emotionDamagePair.isValid && emotionDamagePair.times > 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00012788 File Offset: 0x00010988
		public bool ConversantEstaAsustada(float mayor)
		{
			bool flag;
			try
			{
				flag = this.ObtenerEmosDeConversante().fear.value.total >= mayor;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000127D4 File Offset: 0x000109D4
		public bool ConversantEstaEnojada(float mayor)
		{
			bool flag;
			try
			{
				flag = this.ObtenerEmosDeConversante().rage.value.total >= mayor;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00012820 File Offset: 0x00010A20
		public bool ConversantEstaAdolorida(float mayor)
		{
			bool flag;
			try
			{
				flag = this.ObtenerEmosDeConversante().dolor.value.total >= mayor;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0001286C File Offset: 0x00010A6C
		public bool ConversantEstaDecepcionada(float mayor)
		{
			bool flag;
			try
			{
				flag = this.ObtenerEmosDeConversante().decepcion.value.total >= mayor;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000128B8 File Offset: 0x00010AB8
		public bool ConversantEstaExitada(float mayor)
		{
			bool flag;
			try
			{
				flag = this.ObtenerEmosDeConversante().placer.value.total >= mayor;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00012904 File Offset: 0x00010B04
		public bool EsTimido(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).timido;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001293C File Offset: 0x00010B3C
		public bool EsExtrovertido(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).extrovertido;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00012974 File Offset: 0x00010B74
		public bool EsSumiso(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).sumiso;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x000129AC File Offset: 0x00010BAC
		public bool EsConversanteSumiso()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidadDeConversante().sumiso;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x000129E4 File Offset: 0x00010BE4
		public bool EsConversanteHonesto()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidadDeConversante().honesto;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00012A1C File Offset: 0x00010C1C
		public bool EsConversanteAmable()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidadDeConversante().amable;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00012A54 File Offset: 0x00010C54
		public bool EsPervertido(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).pervertido;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00012A8C File Offset: 0x00010C8C
		public bool EsExhibicionista(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).exhibicionista;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00012AC4 File Offset: 0x00010CC4
		public bool EsDesinhibido(string id)
		{
			return this.EsExhibicionista(id);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00012AD0 File Offset: 0x00010CD0
		public bool EsRespetuoso(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).respetuoso;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00012B08 File Offset: 0x00010D08
		public bool EsGrosero(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).grosero;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00012B40 File Offset: 0x00010D40
		public bool EsHonesto(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).honesto;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00012B78 File Offset: 0x00010D78
		public bool EsDeshonesto(string id)
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).deshonesto;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00012BB0 File Offset: 0x00010DB0
		public string MaxTipoDePersonalidad(string id, LuaTable seleccion)
		{
			string text;
			try
			{
				using (IEnumerator<LuaValue> enumerator = seleccion.ListValues.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Personalidad.Tipo tipo;
						if (Enum.TryParse<Personalidad.Tipo>(enumerator.Current.Value.ToString(), out tipo))
						{
							this.m_selecionTemp.Add((int)tipo);
						}
					}
				}
				text = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id).ObtenerTipoMayorDeCurrentFrame(false, this.m_selecionTemp, false, false).ToString();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = string.Empty;
			}
			finally
			{
				this.m_selecionTemp.Clear();
			}
			return text;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00012C6C File Offset: 0x00010E6C
		public static Personalidad.Tipo MaxTipoDePersonalidadDeConversantStatic(params Personalidad.Tipo[] tipos)
		{
			return RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().ObtenerTipoMayorDeCurrentFrame(false, tipos.Select((Personalidad.Tipo t) => (int)t).ToArray<int>(), false, false);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00012CA8 File Offset: 0x00010EA8
		public static Personalidad PersonalidadDeConversantStatic()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<Personalidad>();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00012CE0 File Offset: 0x00010EE0
		public static DesHielo DesHieloDeConversantStatic()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<DesHielo>();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00012D18 File Offset: 0x00010F18
		public float ConsentToHero(string id)
		{
			float num;
			try
			{
				num = this.ObtenerEmos(id).consentToHero.value.total;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00012D60 File Offset: 0x00010F60
		public bool ConversantAtraidaSexualmenteVisualmenteAActor()
		{
			bool flag;
			try
			{
				ConsentNecesario consentNecesario = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante();
				EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
				emptyValid.consentToHero = Mathf.Max(consentNecesario.consentToHero.valorNoLimitado, consentNecesario.consentToHero.limiteMinimo2) / 100f;
				for (int i = 0; i < ParteQuePuedeEstimularHelper.puedenVer.Count; i++)
				{
					ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenVer[i];
					for (int j = 0; j < ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal.Count; j++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal[j];
						float num;
						float num2;
						if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, out num, out num2, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
						{
							return true;
						}
					}
					for (int k = 0; k < ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal.Count; k++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal[k];
						float num3;
						float num4;
						if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular, out num3, out num4, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
						{
							return true;
						}
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

		// Token: 0x06000399 RID: 921 RVA: 0x00012E84 File Offset: 0x00011084
		public bool ConversantAtraidaSexualmenteTactilmenteAActor()
		{
			bool flag;
			try
			{
				ConsentNecesario consentNecesario = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante();
				EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
				emptyValid.consentToHero = Mathf.Max(consentNecesario.consentToHero.valorNoLimitado, consentNecesario.consentToHero.limiteMinimo2) / 100f;
				for (int i = 0; i < ParteQuePuedeEstimularHelper.puedenTocarSexualmente.Count; i++)
				{
					ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenTocarSexualmente[i];
					for (int j = 0; j < ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal.Count; j++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal[j];
						float num;
						float num2;
						if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, out num, out num2, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
						{
							return true;
						}
					}
					for (int k = 0; k < ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal.Count; k++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal[k];
						float num3;
						float num4;
						if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular, out num3, out num4, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
						{
							return true;
						}
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

		// Token: 0x0600039A RID: 922 RVA: 0x00012FA8 File Offset: 0x000111A8
		public bool ConversantAtraidaSexualmenteCoitalmenteAActor()
		{
			bool flag;
			try
			{
				ConsentNecesario consentNecesario = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante();
				EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
				emptyValid.consentToHero = Mathf.Max(consentNecesario.consentToHero.valorNoLimitado, consentNecesario.consentToHero.limiteMinimo2) / 100f;
				for (int i = 0; i < ParteQuePuedeEstimularHelper.puedenPenetrar.Count; i++)
				{
					ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimularHelper.puedenPenetrar[i];
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
					float num;
					float num2;
					if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, parteQuePuedeEstimular, out num, out num2, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
					{
						return true;
					}
					ParteDelCuerpoHumano parteDelCuerpoHumano2 = ParteDelCuerpoHumano.ano;
					float num3;
					float num4;
					if (consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteDelCuerpoHumano2, parteQuePuedeEstimular, out num3, out num4, 1f, new EmocionesFemeninasValues?(emptyValid), null, null))
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

		// Token: 0x0600039B RID: 923 RVA: 0x0001307C File Offset: 0x0001127C
		public bool ConversantNecesitaDinero()
		{
			bool flag;
			try
			{
				HumanTraitScore traitScore = RegistroDeFuncionesDeAI.ObtenerPersonalidadDeConversante().GetTraitScore(TraitHumano.pobreza);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
				case HumanTraitScore.bajo:
				case HumanTraitScore.muyBajo:
					flag = false;
					break;
				case HumanTraitScore.alto:
				case HumanTraitScore.muyAlto:
					flag = true;
					break;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x000130E8 File Offset: 0x000112E8
		public int OportunidadesDeReaccion(string id, object reaccion)
		{
			int num;
			try
			{
				ConfiguracionGeneralDeCheats.UserData current = Singleton<ConfiguracionGeneralDeCheats>.instance.current;
				if (Singleton<ConfiguracionGeneralDeCheats>.instance.activadas && current.heroineIsForgiveness)
				{
					num = 2147482647;
				}
				else
				{
					Personalidad personalidad = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id);
					ReaccionHumana reaccionHumana;
					if (!Enum.TryParse<ReaccionHumana>((reaccion != null) ? reaccion.ToString() : null, out reaccionHumana))
					{
						num = 0;
					}
					else
					{
						TraitHumano traitHumano;
						float num2;
						if (reaccionHumana <= ReaccionHumana.rabia)
						{
							if (reaccionHumana == ReaccionHumana.dolor)
							{
								traitHumano = TraitHumano.painPatience;
								num2 = 1.51f;
								goto IL_00B2;
							}
							if (reaccionHumana == ReaccionHumana.rabia)
							{
								traitHumano = TraitHumano.ragePatience;
								num2 = 1f;
								goto IL_00B2;
							}
						}
						else
						{
							if (reaccionHumana == ReaccionHumana.miedo)
							{
								traitHumano = TraitHumano.fearPatience;
								num2 = 0.19f;
								goto IL_00B2;
							}
							if (reaccionHumana == ReaccionHumana.decepcion)
							{
								traitHumano = TraitHumano.deceptionPatience;
								num2 = 0.49f;
								goto IL_00B2;
							}
						}
						throw new ArgumentOutOfRangeException(reaccionHumana.ToString());
						IL_00B2:
						HumanTraitScore traitScore = personalidad.GetTraitScore(TraitHumano.patience);
						HumanTraitScore traitScore2 = personalidad.GetTraitScore(traitHumano);
						float num3 = 1f;
						switch (traitScore)
						{
						case HumanTraitScore.normal:
							num3 *= 1f;
							break;
						case HumanTraitScore.alto:
							num3 *= 1.5f;
							break;
						case HumanTraitScore.muyAlto:
							num3 *= 2f;
							break;
						case HumanTraitScore.bajo:
							num3 *= 0.6666f;
							break;
						case HumanTraitScore.muyBajo:
							num3 *= 0.5f;
							break;
						default:
							throw new ArgumentOutOfRangeException(traitScore.ToString());
						}
						switch (traitScore2)
						{
						case HumanTraitScore.normal:
							num3 *= 1f;
							break;
						case HumanTraitScore.alto:
							num3 *= 1.5f;
							break;
						case HumanTraitScore.muyAlto:
							num3 *= 2f;
							break;
						case HumanTraitScore.bajo:
							num3 *= 0.6666f;
							break;
						case HumanTraitScore.muyBajo:
							num3 *= 0.5f;
							break;
						default:
							throw new ArgumentOutOfRangeException(traitScore2.ToString());
						}
						num = Mathf.RoundToInt(num3 * num2);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0;
			}
			return num;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000132D0 File Offset: 0x000114D0
		public string PartesConsentidasCariciaStringCheat(string id)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			return this.ObtenerConsentidos(id, (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFemenina()
				select p).ToArray<ParteDelCuerpoHumano>(), TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, list, Array.Empty<ParteQuePuedeEstimular>());
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00013330 File Offset: 0x00011530
		public string PartesConsentidasCoitoStringCheat(string id)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			return this.ObtenerConsentidos(id, (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.PuedeSerPenetrada()
				select p).ToArray<ParteDelCuerpoHumano>(), TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list, Array.Empty<ParteQuePuedeEstimular>());
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00013390 File Offset: 0x00011590
		public string PartesConsentidasClutchStringCheat(string id)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			return this.ObtenerConsentidos(id, (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFemenina()
				select p).ToArray<ParteDelCuerpoHumano>(), TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.pene, list, Array.Empty<ParteQuePuedeEstimular>());
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000133F0 File Offset: 0x000115F0
		public string PartesConsentidasHumpStringCheat(string id)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			return this.ObtenerConsentidos(id, (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFemenina()
				select p).ToArray<ParteDelCuerpoHumano>(), TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.torzo, list, new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.piernas });
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00013458 File Offset: 0x00011658
		public string PartesConsentidasCummingStringCheat(string id)
		{
			List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
			return this.ObtenerConsentidos(id, (from ParteDelCuerpoHumano p in typeof(ParteDelCuerpoHumano).GetEnumValoresObject()
				where p.EsFemenina()
				select p).ToArray<ParteDelCuerpoHumano>(), TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.semen, list, Array.Empty<ParteQuePuedeEstimular>());
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000134BC File Offset: 0x000116BC
		public string ObtenerConsentidos(string id, IReadOnlyList<ParteDelCuerpoHumano> aEvaluar, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, IList<ParteDelCuerpoHumano> resultado, params ParteQuePuedeEstimular[] extraEstimulantes)
		{
			string text2;
			try
			{
				ConsentNecesario consentNecesario = RegistroDeFuncionesDeAI.ObtenerConsentNecesario(id);
				consentNecesario.ObtenerConsentidosConJerarquia(aEvaluar, tipo, direccion, estimulante, resultado, null, null, null);
				if (extraEstimulantes != null)
				{
					for (int i = 0; i < extraEstimulantes.Length; i++)
					{
						consentNecesario.ObtenerConsentidosConJerarquia(aEvaluar, tipo, direccion, extraEstimulantes[i], resultado, null, null, null);
					}
				}
				if (resultado.Count > 0)
				{
					HashSet<string> hashSet = new HashSet<string>();
					StringBuilder stringBuilder = new StringBuilder(resultado.Count * 10);
					int num = 10;
					for (int j = 0; j < resultado.Count; j += num)
					{
						bool flag = false;
						bool flag2 = false;
						bool flag3 = true;
						int num2 = 0;
						while (num2 < num && num2 + j < resultado.Count)
						{
							int num3 = num2 + j;
							ParteDelCuerpoHumano parteDelCuerpoHumano = resultado[num3];
							flag2 = num3.IsLastIndex(resultado.Count);
							num2.IsLastIndex(num);
							string text = RegistroDeFuncionesDeCanEstimular.DialogoLocalParteDelCuerpo_NombreReal(parteDelCuerpoHumano).NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, 1);
							if (hashSet.Add(text))
							{
								flag = true;
								if (!flag3)
								{
									stringBuilder.Append(' ');
									stringBuilder.Append(' ');
								}
								stringBuilder.Append(text);
								flag3 = false;
							}
							num2++;
						}
						if (!flag2 && flag)
						{
							stringBuilder.Append('\n');
						}
					}
					text2 = stringBuilder.ToString();
				}
				else
				{
					text2 = "Nowhere. (▰\u02d8︹\u02d8▰)";
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text2 = "ERROR";
			}
			return text2;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00013654 File Offset: 0x00011854
		[Obsolete]
		public void PartesQuePuedenSerAcariciadas(string id, IList<ParteDelCuerpoHumano> resultado)
		{
			this.PartesQuePuedenSerAcariciadas(RegistroDeFuncionesDeAI.ObtenerConsentNecesario(id), resultado);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00013664 File Offset: 0x00011864
		[Obsolete]
		public void PartesQuePuedenSerAcariciadas(ConsentNecesario consentNesesario, IList<ParteDelCuerpoHumano> resultado)
		{
			consentNesesario.ObtenerConsentidosConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteQuePuedeEstimular.manos, resultado, null, null, null);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00013688 File Offset: 0x00011888
		[LuaAutoRegister]
		public float LastSelectedTipoDeRespuestasScore(LuaTable respuestaTable)
		{
			float num2;
			try
			{
				float num = 0f;
				foreach (LuaValue luaValue in respuestaTable.ListValues)
				{
					num += DialogueLua.GetVariable("LAST_" + luaValue.Value.ToString()).AsFloat;
				}
				num2 = num;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num2 = 0f;
			}
			return num2;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0001371C File Offset: 0x0001191C
		[LuaAutoRegister]
		public void ClearLastSelectedTipoDeRespuestas()
		{
			try
			{
				foreach (object obj in typeof(Personalidad.TipoDeRespuestaDeDialogoDePlayer).GetEnumValoresLimpiosObject())
				{
					DialogueLua.SetVariable("LAST_" + ((Personalidad.TipoDeRespuestaDeDialogoDePlayer)obj).ToString(), 0f);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000137B4 File Offset: 0x000119B4
		private void RegistrarLastSelectedTipoDeRespuestas(List<ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>> respuestas)
		{
			foreach (ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float> valueTuple in respuestas)
			{
				DialogueLua.SetVariable("LAST_" + valueTuple.Item1.ToString(), valueTuple.Item2);
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00013828 File Offset: 0x00011A28
		public float CambiarEmocionAutoGestuadaPorTipoDeRespuestaLerp(string id, LuaTable respuestaTable, LuaTable aumentarTable, LuaTable overFlowTable, LuaTable toleranciaBonusesAtMaxValue)
		{
			float num;
			try
			{
				this.ClearLastSelectedTipoDeRespuestas();
				List<ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>> list = this.ObtenerRespuestas(respuestaTable);
				if (list.Count == 0)
				{
					num = 0f;
				}
				else
				{
					this.RegistrarLastSelectedTipoDeRespuestas(list);
					List<ValueTuple<ReaccionHumana, float>> list2 = this.ObtenerPares(aumentarTable);
					if (list2.Count == 0)
					{
						num = 0f;
					}
					else
					{
						List<ValueTuple<ReaccionHumana, float>> list3 = this.ObtenerPares(overFlowTable);
						EmocionesFemeninas emocionesFemeninas = this.ObtenerEmos(id);
						Personalidad personalidad = RegistroDeFuncionesDeAI.ObtenerPersonalidad(id);
						float num2 = this.ObtenerToleranciaBonus(emocionesFemeninas, toleranciaBonusesAtMaxValue);
						ValueTuple<ReaccionHumana, float> valueTuple = default(ValueTuple<ReaccionHumana, float>);
						float num3 = 0f;
						foreach (ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float> valueTuple2 in list)
						{
							num3 += this.CalcularCambiarEmocion(ref valueTuple, emocionesFemeninas, personalidad, valueTuple2.Item1, valueTuple2.Item2, list2, list3, num2);
						}
						num3 /= (float)list.Count;
						if (num3 > 0f)
						{
							float num4 = 5f * Mathf.Clamp01(num3);
							personalidad.deseos.AumentarDeseoEntrepierna(num4, false, 1f);
							personalidad.deseos.AumentarDeseoSenos(num4, false, 1f);
							personalidad.deseos.AumentarDeseoLabios(num4, false, 1f);
							personalidad.deseos.AumentarDeseoNalgas(num4, false, 1f);
						}
						RegistroDeFuncionesDeGestos.Gestuar(personalidad.character, valueTuple.Item1, Mathf.InverseLerp(0f, 15f, valueTuple.Item2));
						num = num3;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 0f;
			}
			return num;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000139E4 File Offset: 0x00011BE4
		public void CambiarEmocionDeConversante(string reaccionString, float valor)
		{
			try
			{
				EmocionesFemeninas emocionesFemeninas = this.ObtenerEmosDeConversante();
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(reaccionString, out reaccionHumana))
				{
					Debug.LogError("No se encontro reaccion: " + reaccionString, this);
				}
				else
				{
					RegistroDeFuncionesDeAI.ChangeEmocionValue(emocionesFemeninas, reaccionHumana, valor);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00013A38 File Offset: 0x00011C38
		public void CambiarEmocion(string id, string reaccionString, float valor)
		{
			try
			{
				EmocionesFemeninas emocionesFemeninas = this.ObtenerEmos(id);
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(reaccionString, out reaccionHumana))
				{
					Debug.LogError("No se encontro reaccion: " + reaccionString, this);
				}
				else
				{
					RegistroDeFuncionesDeAI.ChangeEmocionValue(emocionesFemeninas, reaccionHumana, valor);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00013A8C File Offset: 0x00011C8C
		public void CambiarEmocionUnicaVez(string id, string reaccionString, string idCambioUnico, float valor)
		{
			try
			{
				EmocionesFemeninas emocionesFemeninas = this.ObtenerEmos(id);
				MemoriaDeRegistroDeCambiosDeEmocionUnicos componentInChildrenNotNull = ((Component)emocionesFemeninas.owner).GetComponentInChildrenNotNull<MemoriaDeRegistroDeCambiosDeEmocionUnicos>();
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(reaccionString, out reaccionHumana))
				{
					Debug.LogError("No se encontro reaccion: " + reaccionString, this);
				}
				else if (!componentInChildrenNotNull.EstaRegistrardoCambioDeEmocion(reaccionHumana, idCambioUnico))
				{
					componentInChildrenNotNull.RegistrarCambioDeEmocion(reaccionHumana, idCambioUnico);
					RegistroDeFuncionesDeAI.ChangeEmocionValue(emocionesFemeninas, reaccionHumana, valor);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00013B08 File Offset: 0x00011D08
		private float CalcularCambiarEmocion(ref ValueTuple<ReaccionHumana, float> mayorCambio, EmocionesFemeninasBase emos, Personalidad per, Personalidad.TipoDeRespuestaDeDialogoDePlayer tipoDeRespuesta, float puntajeDeRespuesta, IEnumerable<ValueTuple<ReaccionHumana, float>> aumentos, IEnumerable<ValueTuple<ReaccionHumana, float>> overflows, float modDeToleranciaARespuestas = 1f)
		{
			if (emos == null)
			{
				Debug.LogWarning("no se encontraron emociones humanas", this);
				return 0f;
			}
			if (per == null)
			{
				Debug.LogWarning("no se encontro Personalidad", this);
				return 0f;
			}
			float num;
			float num2;
			per.CalcularModificadorDeRespuestaV2(out num, out num2, tipoDeRespuesta, puntajeDeRespuesta, modDeToleranciaARespuestas);
			foreach (ValueTuple<ReaccionHumana, float> valueTuple in aumentos)
			{
				float num3 = valueTuple.Item2 * num;
				RegistroDeFuncionesDeAI.ChangeEmocionValue(emos, valueTuple.Item1, num3);
				if (num3 > mayorCambio.Item2)
				{
					mayorCambio = new ValueTuple<ReaccionHumana, float>(valueTuple.Item1, num3);
				}
			}
			if (num2 > 0f)
			{
				foreach (ValueTuple<ReaccionHumana, float> valueTuple2 in overflows)
				{
					float num4 = valueTuple2.Item2 * num2;
					RegistroDeFuncionesDeAI.ChangeEmocionValue(emos, valueTuple2.Item1, num4);
					if (num4 >= mayorCambio.Item2)
					{
						mayorCambio = new ValueTuple<ReaccionHumana, float>(valueTuple2.Item1, num4);
					}
				}
			}
			if (num > 0f)
			{
				return num;
			}
			return -num2;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00013C44 File Offset: 0x00011E44
		public static void ChangeEmocionValue(EmocionesFemeninasBase emos, ReaccionHumana reaccion, float valor)
		{
			if (reaccion == ReaccionHumana.None)
			{
				return;
			}
			if (valor == 0f)
			{
				return;
			}
			Emocion emocion = emos.ObtenerEmocion(reaccion);
			if (emocion == null)
			{
				return;
			}
			if (valor < 0f)
			{
				emocion.ReduceValueNextUpdate(-valor);
				return;
			}
			emocion.IncreaseValueNextUpdate(valor);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00013C88 File Offset: 0x00011E88
		private float ObtenerToleranciaBonus(EmocionesFemeninasBase emos, LuaTable toleranciaBonusesAtMaxValue)
		{
			if (emos == null || toleranciaBonusesAtMaxValue == null)
			{
				return 1f;
			}
			List<ValueTuple<ReaccionHumana, float>> list = this.ObtenerPares(toleranciaBonusesAtMaxValue);
			float num = 1f;
			foreach (ValueTuple<ReaccionHumana, float> valueTuple in list)
			{
				float total = emos.ObtenerEmocion(valueTuple.Item1).value.total;
				num *= Mathf.Lerp(1f, valueTuple.Item2, total / 100f);
			}
			return num;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00013D24 File Offset: 0x00011F24
		private List<ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>> ObtenerRespuestas(LuaTable respuestaTable)
		{
			List<ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>> list = new List<ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>>(respuestaTable.Count);
			if (respuestaTable == null || respuestaTable.KeyValuePairs == null)
			{
				return list;
			}
			foreach (KeyValuePair<LuaValue, LuaValue> keyValuePair in respuestaTable.KeyValuePairs)
			{
				Personalidad.TipoDeRespuestaDeDialogoDePlayer tipoDeRespuestaDeDialogoDePlayer;
				if (!Enum.TryParse<Personalidad.TipoDeRespuestaDeDialogoDePlayer>(keyValuePair.Key.Value.ToString(), out tipoDeRespuestaDeDialogoDePlayer))
				{
					Debug.LogException(new NotSupportedException("respuesta no es " + typeof(Personalidad.TipoDeRespuestaDeDialogoDePlayer).Name), this);
				}
				else
				{
					float num = Convert.ToSingle(keyValuePair.Value.Value);
					list.Add(new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDePlayer, float>(tipoDeRespuestaDeDialogoDePlayer, num));
				}
			}
			return list;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00013DE8 File Offset: 0x00011FE8
		private List<ValueTuple<ReaccionHumana, float>> ObtenerPares(LuaTable table)
		{
			List<ValueTuple<ReaccionHumana, float>> list = new List<ValueTuple<ReaccionHumana, float>>(table.Count);
			if (table == null || table.KeyValuePairs == null)
			{
				return list;
			}
			foreach (KeyValuePair<LuaValue, LuaValue> keyValuePair in table.KeyValuePairs)
			{
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(keyValuePair.Key.Value.ToString(), out reaccionHumana))
				{
					string text = "key: ";
					LuaValue key = keyValuePair.Key;
					string text2;
					if (key == null)
					{
						text2 = null;
					}
					else
					{
						object value = key.Value;
						text2 = ((value != null) ? value.ToString() : null);
					}
					Debug.LogException(new NotSupportedException(text + text2 + " no es " + typeof(ReaccionHumana).Name), this);
				}
				else
				{
					float num = Convert.ToSingle(keyValuePair.Value.Value);
					list.Add(new ValueTuple<ReaccionHumana, float>(reaccionHumana, num));
				}
			}
			return list;
		}

		// Token: 0x0400014C RID: 332
		private List<int> m_selecionTemp = new List<int>();

		// Token: 0x020000A4 RID: 164
		private enum TipoDeNombreDeParte
		{
			// Token: 0x040001BF RID: 447
			primero,
			// Token: 0x040001C0 RID: 448
			real,
			// Token: 0x040001C1 RID: 449
			plural,
			// Token: 0x040001C2 RID: 450
			singular
		}
	}
}

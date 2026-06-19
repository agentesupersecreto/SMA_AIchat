using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.CharacterMemoria;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem.Funciones
{
	// Token: 0x02000082 RID: 130
	public class RegistroDeFuncionesDeSobornos : CustomMonobehaviour
	{
		// Token: 0x0600051E RID: 1310 RVA: 0x0001D25C File Offset: 0x0001B45C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("ObtenerDownPaymentAmount", this, base.GetType().GetMethod("ObtenerDownPaymentAmount"));
			Lua.RegisterFunction("ActorTieneCantidadDeDinero", this, base.GetType().GetMethod("ActorTieneCantidadDeDinero"));
			Lua.RegisterFunction("DescontarDineroAActor", this, base.GetType().GetMethod("DescontarDineroAActor"));
			Lua.RegisterFunction("RegistrarHablaronSobreDownPayment", this, base.GetType().GetMethod("RegistrarHablaronSobreDownPayment"));
			Lua.RegisterFunction("RegistrarConversanteRecibioDownPayment", this, base.GetType().GetMethod("RegistrarConversanteRecibioDownPayment"));
			Lua.RegisterFunction("EsConversanteSobornable0", this, base.GetType().GetMethod("EsConversanteSobornable0"));
			Lua.RegisterFunction("EsConversanteSobornable1", this, base.GetType().GetMethod("EsConversanteSobornable1"));
			Lua.RegisterFunction("RegistrarConversanteAceptoSerSobornable1", this, base.GetType().GetMethod("RegistrarConversanteAceptoSerSobornable1"));
			Lua.RegisterFunction("RegistrarConversantePreguntadoSobornable1", this, base.GetType().GetMethod("RegistrarConversantePreguntadoSobornable1"));
			Lua.RegisterFunction("ConversanteAceptaSobornoExplicito", this, base.GetType().GetMethod("ConversanteAceptaSobornoExplicito"));
			Lua.RegisterFunction("ConversanteAceptaSobornoEspecial", this, base.GetType().GetMethod("ConversanteAceptaSobornoEspecial"));
			Lua.RegisterFunction("ConversanteAnalEsConsentido", this, base.GetType().GetMethod("ConversanteAnalEsConsentido"));
			Lua.RegisterFunction("CantidadNecesariaParaConversanteAnal", this, base.GetType().GetMethod("CantidadNecesariaParaConversanteAnal"));
			Lua.RegisterFunction("LeerCantidadFijadaPorConversanteSobornoAnal", this, base.GetType().GetMethod("LeerCantidadFijadaPorConversanteSobornoAnal"));
			Lua.RegisterFunction("LeerConversanteFuePreguntadaPorSobornoAnal", this, base.GetType().GetMethod("LeerConversanteFuePreguntadaPorSobornoAnal"));
			Lua.RegisterFunction("RegistrarConversanteFuePreguntadaPorSobornoAnal", this, base.GetType().GetMethod("RegistrarConversanteFuePreguntadaPorSobornoAnal"));
			Lua.RegisterFunction("RegistrarConversanteFueOfrecidaAnal", this, base.GetType().GetMethod("RegistrarConversanteFueOfrecidaAnal"));
			Lua.RegisterFunction("RegistrarConversanteFijoPrecioAnal", this, base.GetType().GetMethod("RegistrarConversanteFijoPrecioAnal"));
			Lua.RegisterFunction("ConversanteAceptoSobornoAnal", this, base.GetType().GetMethod("ConversanteAceptoSobornoAnal"));
			Lua.RegisterFunction("ConversanteVaginalEsConsentido", this, base.GetType().GetMethod("ConversanteVaginalEsConsentido"));
			Lua.RegisterFunction("CantidadNecesariaParaConversanteVaginal", this, base.GetType().GetMethod("CantidadNecesariaParaConversanteVaginal"));
			Lua.RegisterFunction("LeerCantidadFijadaPorConversanteSobornoVaginal", this, base.GetType().GetMethod("LeerCantidadFijadaPorConversanteSobornoVaginal"));
			Lua.RegisterFunction("LeerConversanteFuePreguntadaPorSobornoVaginal", this, base.GetType().GetMethod("LeerConversanteFuePreguntadaPorSobornoVaginal"));
			Lua.RegisterFunction("RegistrarConversanteFuePreguntadaPorSobornoVaginal", this, base.GetType().GetMethod("RegistrarConversanteFuePreguntadaPorSobornoVaginal"));
			Lua.RegisterFunction("RegistrarConversanteFueOfrecidaVaginal", this, base.GetType().GetMethod("RegistrarConversanteFueOfrecidaVaginal"));
			Lua.RegisterFunction("RegistrarConversanteFijoPrecioVaginal", this, base.GetType().GetMethod("RegistrarConversanteFijoPrecioVaginal"));
			Lua.RegisterFunction("ConversanteAceptoSobornoVaginal", this, base.GetType().GetMethod("ConversanteAceptoSobornoVaginal"));
			Lua.RegisterFunction("ConversanteOralEsConsentido", this, base.GetType().GetMethod("ConversanteOralEsConsentido"));
			Lua.RegisterFunction("CantidadNecesariaParaConversanteOral", this, base.GetType().GetMethod("CantidadNecesariaParaConversanteOral"));
			Lua.RegisterFunction("LeerCantidadFijadaPorConversanteSobornoOral", this, base.GetType().GetMethod("LeerCantidadFijadaPorConversanteSobornoOral"));
			Lua.RegisterFunction("LeerConversanteFuePreguntadaPorSobornoOral", this, base.GetType().GetMethod("LeerConversanteFuePreguntadaPorSobornoOral"));
			Lua.RegisterFunction("RegistrarConversanteFuePreguntadaPorSobornoOral", this, base.GetType().GetMethod("RegistrarConversanteFuePreguntadaPorSobornoOral"));
			Lua.RegisterFunction("RegistrarConversanteFueOfrecidaOral", this, base.GetType().GetMethod("RegistrarConversanteFueOfrecidaOral"));
			Lua.RegisterFunction("RegistrarConversanteFijoPrecioOral", this, base.GetType().GetMethod("RegistrarConversanteFijoPrecioOral"));
			Lua.RegisterFunction("ConversanteAceptoSobornoOral", this, base.GetType().GetMethod("ConversanteAceptoSobornoOral"));
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001D620 File Offset: 0x0001B820
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("ObtenerDownPaymentAmount");
			Lua.UnregisterFunction("ActorTieneCantidadDeDinero");
			Lua.UnregisterFunction("DescontarDineroAActor");
			Lua.UnregisterFunction("RegistrarHablaronSobreDownPayment");
			Lua.UnregisterFunction("RegistrarConversanteRecibioDownPayment");
			Lua.UnregisterFunction("EsConversanteSobornable0");
			Lua.UnregisterFunction("EsConversanteSobornable1");
			Lua.UnregisterFunction("RegistrarConversanteAceptoSerSobornable1");
			Lua.UnregisterFunction("RegistrarConversantePreguntadoSobornable1");
			Lua.UnregisterFunction("ConversanteAceptaSobornoExplicito");
			Lua.UnregisterFunction("ConversanteAceptaSobornoEspecial");
			Lua.UnregisterFunction("ConversanteAnalEsConsentido");
			Lua.UnregisterFunction("CantidadNecesariaParaConversanteAnal");
			Lua.UnregisterFunction("LeerCantidadFijadaPorConversanteSobornoAnal");
			Lua.UnregisterFunction("LeerConversanteFuePreguntadaPorSobornoAnal");
			Lua.UnregisterFunction("RegistrarConversanteFuePreguntadaPorSobornoAnal");
			Lua.UnregisterFunction("RegistrarConversanteFueOfrecidaAnal");
			Lua.UnregisterFunction("RegistrarConversanteFijoPrecioAnal");
			Lua.UnregisterFunction("ConversanteAceptoSobornoAnal");
			Lua.UnregisterFunction("ConversanteVaginalEsConsentido");
			Lua.UnregisterFunction("CantidadNecesariaParaConversanteVaginal");
			Lua.UnregisterFunction("LeerCantidadFijadaPorConversanteSobornoVaginal");
			Lua.UnregisterFunction("LeerConversanteFuePreguntadaPorSobornoVaginal");
			Lua.UnregisterFunction("RegistrarConversanteFuePreguntadaPorSobornoVaginal");
			Lua.UnregisterFunction("RegistrarConversanteFueOfrecidaVaginal");
			Lua.UnregisterFunction("RegistrarConversanteFijoPrecioVaginal");
			Lua.UnregisterFunction("ConversanteAceptoSobornoVaginal");
			Lua.UnregisterFunction("ConversanteOralEsConsentido");
			Lua.UnregisterFunction("CantidadNecesariaParaConversanteOral");
			Lua.UnregisterFunction("LeerCantidadFijadaPorConversanteSobornoOral");
			Lua.UnregisterFunction("LeerConversanteFuePreguntadaPorSobornoOral");
			Lua.UnregisterFunction("RegistrarConversanteFuePreguntadaPorSobornoOral");
			Lua.UnregisterFunction("RegistrarConversanteFueOfrecidaOral");
			Lua.UnregisterFunction("RegistrarConversanteFijoPrecioOral");
			Lua.UnregisterFunction("ConversanteAceptoSobornoOral");
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001D794 File Offset: 0x0001B994
		public static CharacterWallet GetActorWallet()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ActorID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<CharacterWallet>();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0001D7CC File Offset: 0x0001B9CC
		private static Character GetConversant()
		{
			Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001D7FC File Offset: 0x0001B9FC
		public float ObtenerDownPaymentAmount()
		{
			float num;
			try
			{
				num = 50f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 5000f;
			}
			return num;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001D830 File Offset: 0x0001BA30
		public bool ActorTieneCantidadDeDinero(float cantidad)
		{
			bool flag;
			try
			{
				CharacterWallet actorWallet = RegistroDeFuncionesDeSobornos.GetActorWallet();
				flag = ((actorWallet != null) ? new float?(actorWallet.Current("fiat")) : null).GetValueOrDefault(0f) >= cantidad;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001D894 File Offset: 0x0001BA94
		public void DescontarDineroAActor(float cantidad)
		{
			try
			{
				CharacterWallet actorWallet = RegistroDeFuncionesDeSobornos.GetActorWallet();
				if (actorWallet != null)
				{
					string text = "fiat";
					float num = -cantidad;
					Character conversant = RegistroDeFuncionesDeSobornos.GetConversant();
					actorWallet.Change(text, num, (conversant != null) ? conversant.nombreCompleto : null);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001D8E4 File Offset: 0x0001BAE4
		public void RegistrarHablaronSobreDownPayment()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "DownPaymentTalked", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001D91C File Offset: 0x0001BB1C
		public void RegistrarConversanteRecibioDownPayment()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "DownPaymentPaid", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001D954 File Offset: 0x0001BB54
		public bool EsConversanteSobornable0()
		{
			bool flag;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float weigthDeScore = personalidad.GetTraitScore(TraitHumano.gustoPorTratoDeClientes).GetWeigthDeScore();
				float weigthDeScore2 = personalidad.GetTraitScore(TraitHumano.gustoPorTratoEspecialDeClientes).GetWeigthDeScore();
				float weigthDeScore3 = personalidad.GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes).GetWeigthDeScore();
				float weigthDeScore4 = personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
				float weigthDeScore5 = personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
				flag = (weigthDeScore + weigthDeScore2 + weigthDeScore3 + weigthDeScore4 + weigthDeScore5) / 5f >= 0.5f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		public bool EsConversanteSobornable1()
		{
			bool flag;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float weigthDeScore = personalidad.GetTraitScore(TraitHumano.gustoPorTratoEspecialDeClientes).GetWeigthDeScore();
				float weigthDeScore2 = personalidad.GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes).GetWeigthDeScore();
				flag = weigthDeScore >= 0.5f || weigthDeScore2 >= 0.5f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001DA4C File Offset: 0x0001BC4C
		public void RegistrarConversantePreguntadoSobornable1()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "BribableAsked", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001DA84 File Offset: 0x0001BC84
		public void RegistrarConversanteAceptoSerSobornable1()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "BribableAny", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001DABC File Offset: 0x0001BCBC
		public bool ConversanteAceptaSobornoExplicito()
		{
			bool flag;
			try
			{
				flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes).GetWeigthDeScore() >= 0.5f;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001DB04 File Offset: 0x0001BD04
		public bool ConversanteAceptaSobornoEspecial()
		{
			bool flag;
			try
			{
				if (this.ConversanteAceptaSobornoExplicito())
				{
					flag = true;
				}
				else
				{
					flag = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic().GetTraitScore(TraitHumano.gustoPorTratoEspecialDeClientes).GetWeigthDeScore() >= 0.5f;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001DB58 File Offset: 0x0001BD58
		public bool ConversanteAnalEsConsentido()
		{
			bool flag;
			try
			{
				float num;
				float num2;
				flag = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001DBA8 File Offset: 0x0001BDA8
		public float CantidadNecesariaParaConversanteAnal()
		{
			float num3;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float num;
				float num2;
				RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
				if (num >= 1f)
				{
					num3 = 500f;
				}
				else
				{
					float num4 = Mathf.Lerp(5000f, 500f, num.InPow(2f));
					float weigthDeScore = personalidad.GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes).GetWeigthDeScore();
					float weigthDeScore2 = personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
					float num5 = 1f - personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
					num4 = Mathf.Lerp(num4, num4 * 0.666f, weigthDeScore);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, weigthDeScore2);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, num5);
					num4 = Mathf.Clamp(num4, 500f, 5000f);
					num4 = Mathf.Ceil(num4);
					num3 = num4;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num3 = 5000f;
			}
			return num3;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001DCB0 File Offset: 0x0001BEB0
		public float LeerCantidadFijadaPorConversanteSobornoAnal()
		{
			float num;
			try
			{
				num = MemoriaDeCharacterBase.LeerDeepFloat(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribeCost", 5000f);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 5000f;
			}
			return num;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001DCF4 File Offset: 0x0001BEF4
		public bool LeerConversanteFuePreguntadaPorSobornoAnal()
		{
			bool flag;
			try
			{
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribeAsked", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001DD30 File Offset: 0x0001BF30
		public void RegistrarConversanteFuePreguntadaPorSobornoAnal()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribeAsked", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001DD68 File Offset: 0x0001BF68
		public void RegistrarConversanteFueOfrecidaAnal(float cantidadOfrecida)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribeOffer", cantidadOfrecida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0001DDA0 File Offset: 0x0001BFA0
		public void RegistrarConversanteFijoPrecioAnal(float cantidadFijada)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribeCost", cantidadFijada);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0001DDD8 File Offset: 0x0001BFD8
		public void ConversanteAceptoSobornoAnal()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "AnalBribed", true);
				float asFloat = DialogueLua.GetVariable("CANTIDAD_DE_PAGO").AsFloat;
				if (asFloat > 0f)
				{
					this.DescontarDineroAActor(asFloat);
				}
				IEnumerable<ConsensualTree.Data> enumerable = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante().CorruptEstimulo(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, null);
				DesHielo desHielo = RegistroDeFuncionesDeAI.DesHieloDeConversantStatic();
				foreach (ConsensualTree.Data data in enumerable)
				{
					desHielo.SetTo(100f, data.tipoDeEstimulo, data.parteEstimulada, data.direccion, data.parteEstimulante);
				}
				Deseos deseos = RegistroDeFuncionesDeAI.ObtenerDeseosDeConversante();
				if (deseos.valores.traseroPercentage < 0f)
				{
					deseos.AumentarDeseoNalgas(-deseos.valores.traseroPercentage, false, 1f);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001DED4 File Offset: 0x0001C0D4
		public bool ConversanteVaginalEsConsentido()
		{
			bool flag;
			try
			{
				float num;
				float num2;
				flag = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001DF24 File Offset: 0x0001C124
		public float CantidadNecesariaParaConversanteVaginal()
		{
			float num3;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float num;
				float num2;
				RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
				if (num >= 1f)
				{
					num3 = 250f;
				}
				else
				{
					float num4 = Mathf.Lerp(2500f, 250f, num.InPow(2f));
					float weigthDeScore = personalidad.GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes).GetWeigthDeScore();
					float weigthDeScore2 = personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
					float num5 = 1f - personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
					num4 = Mathf.Lerp(num4, num4 * 0.666f, weigthDeScore);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, weigthDeScore2);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, num5);
					num4 = Mathf.Clamp(num4, 250f, 2500f);
					num4 = Mathf.Ceil(num4);
					num3 = num4;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num3 = 2500f;
			}
			return num3;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001E02C File Offset: 0x0001C22C
		public float LeerCantidadFijadaPorConversanteSobornoVaginal()
		{
			float num;
			try
			{
				num = MemoriaDeCharacterBase.LeerDeepFloat(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribeCost", 2500f);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 2500f;
			}
			return num;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001E070 File Offset: 0x0001C270
		public bool LeerConversanteFuePreguntadaPorSobornoVaginal()
		{
			bool flag;
			try
			{
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribeAsked", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001E0AC File Offset: 0x0001C2AC
		public void RegistrarConversanteFuePreguntadaPorSobornoVaginal()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribeAsked", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
		public void RegistrarConversanteFueOfrecidaVaginal(float cantidadOfrecida)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribeOffer", cantidadOfrecida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001E11C File Offset: 0x0001C31C
		public void RegistrarConversanteFijoPrecioVaginal(float cantidadFijada)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribeCost", cantidadFijada);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001E154 File Offset: 0x0001C354
		public void ConversanteAceptoSobornoVaginal()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "VaginalBribed", true);
				float asFloat = DialogueLua.GetVariable("CANTIDAD_DE_PAGO").AsFloat;
				if (asFloat > 0f)
				{
					this.DescontarDineroAActor(asFloat);
				}
				IEnumerable<ConsensualTree.Data> enumerable = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante().CorruptEstimulo(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, null);
				DesHielo desHielo = RegistroDeFuncionesDeAI.DesHieloDeConversantStatic();
				foreach (ConsensualTree.Data data in enumerable)
				{
					desHielo.SetTo(100f, data.tipoDeEstimulo, data.parteEstimulada, data.direccion, data.parteEstimulante);
				}
				Deseos deseos = RegistroDeFuncionesDeAI.ObtenerDeseosDeConversante();
				if (deseos.valores.entrepiernaPercentage < 0f)
				{
					deseos.AumentarDeseoEntrepierna(-deseos.valores.entrepiernaPercentage, false, 1f);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001E250 File Offset: 0x0001C450
		public bool ConversanteOralEsConsentido()
		{
			bool flag;
			try
			{
				float num;
				float num2;
				flag = RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001E2A0 File Offset: 0x0001C4A0
		public float CantidadNecesariaParaConversanteOral()
		{
			float num3;
			try
			{
				Personalidad personalidad = RegistroDeFuncionesDeAI.PersonalidadDeConversantStatic();
				float num;
				float num2;
				RegistroDeFuncionesDeAI.ObtenerConsentNecesarioDeConversante().EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, out num, out num2, 1f, null, null, null);
				if (num >= 1f)
				{
					num3 = 125f;
				}
				else
				{
					float num4 = Mathf.Lerp(1250f, 125f, num.InPow(2f));
					float weigthDeScore = personalidad.GetTraitScore(TraitHumano.gustoPorTratoEspecialDeClientes).GetWeigthDeScore();
					float weigthDeScore2 = personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
					float num5 = 1f - personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
					num4 = Mathf.Lerp(num4, num4 * 0.666f, weigthDeScore);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, weigthDeScore2);
					num4 = Mathf.Lerp(num4 * 0.666f, num4, num5);
					num4 = Mathf.Clamp(num4, 125f, 1250f);
					num4 = Mathf.Ceil(num4);
					num3 = num4;
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num3 = 1250f;
			}
			return num3;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001E3A8 File Offset: 0x0001C5A8
		public float LeerCantidadFijadaPorConversanteSobornoOral()
		{
			float num;
			try
			{
				num = MemoriaDeCharacterBase.LeerDeepFloat(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribeCost", 1250f);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				num = 1250f;
			}
			return num;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001E3EC File Offset: 0x0001C5EC
		public bool LeerConversanteFuePreguntadaPorSobornoOral()
		{
			bool flag;
			try
			{
				flag = MemoriaDeCharacterBase.LeerDeepBoolean(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribeAsked", false);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001E428 File Offset: 0x0001C628
		public void RegistrarConversanteFuePreguntadaPorSobornoOral()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribeAsked", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001E460 File Offset: 0x0001C660
		public void RegistrarConversanteFueOfrecidaOral(float cantidadOfrecida)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribeOffer", cantidadOfrecida);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001E498 File Offset: 0x0001C698
		public void RegistrarConversanteFijoPrecioOral(float cantidadFijada)
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribeCost", cantidadFijada);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
		public void ConversanteAceptoSobornoOral()
		{
			try
			{
				MemoriaDeCharacterBase.RegistrarDeep(RegistroDeFuncionesDeCharacterMemoria.ObtenerMemoriaGeneralTemporalDeConversant(), null, "OralBribed", true);
				float asFloat = DialogueLua.GetVariable("CANTIDAD_DE_PAGO").AsFloat;
				if (asFloat > 0f)
				{
					this.DescontarDineroAActor(asFloat);
				}
				IEnumerable<ConsensualTree.Data> enumerable = RegistroDeFuncionesDeAI.ObtenerConsentForzadoDeConversante().CorruptEstimulo(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, null);
				DesHielo desHielo = RegistroDeFuncionesDeAI.DesHieloDeConversantStatic();
				foreach (ConsensualTree.Data data in enumerable)
				{
					desHielo.SetTo(100f, data.tipoDeEstimulo, data.parteEstimulada, data.direccion, data.parteEstimulante);
				}
				Deseos deseos = RegistroDeFuncionesDeAI.ObtenerDeseosDeConversante();
				if (deseos.valores.labiosPercentage < 0f)
				{
					deseos.AumentarDeseoLabios(-deseos.valores.labiosPercentage, false, 1f);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x04000323 RID: 803
		public const float downPaymentAmount = 50f;

		// Token: 0x04000324 RID: 804
		private const float maxValorAnal = 5000f;

		// Token: 0x04000325 RID: 805
		private const float minValorAnal = 500f;

		// Token: 0x04000326 RID: 806
		private const float maxValorVaginal = 2500f;

		// Token: 0x04000327 RID: 807
		private const float minValorVaginal = 250f;

		// Token: 0x04000328 RID: 808
		private const float maxValorOral = 1250f;

		// Token: 0x04000329 RID: 809
		private const float minValorOral = 125f;
	}
}

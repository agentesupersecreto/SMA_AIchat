using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.AI
{
	// Token: 0x02000074 RID: 116
	public class RegistroDeFuncionesDeAIP2 : CustomMonobehaviour
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x00013EE8 File Offset: 0x000120E8
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("DivergenciaSumisaSetTargetInteraction", this, base.GetType().GetMethod("DivergenciaSumisaSetTargetInteraction"));
			Lua.RegisterFunction("DivergenciaSumisaSetTargetInteractionConEstimulada", this, base.GetType().GetMethod("DivergenciaSumisaSetTargetInteractionConEstimulada"));
			Lua.RegisterFunction("DivergenciaAddEndDelegado", this, base.GetType().GetMethod("DivergenciaAddEndDelegado"));
			Lua.RegisterFunction("DivergenciaEnd", this, base.GetType().GetMethod("DivergenciaEnd"));
			Lua.RegisterFunction("AccionDadaDialogue", this, base.GetType().GetMethod("AccionDadaDialogue"));
			Lua.RegisterFunction("Accion3PersonaDadaDialogue", this, base.GetType().GetMethod("Accion3PersonaDadaDialogue"));
			Lua.RegisterFunction("AccionPasadoDadaDialogue", this, base.GetType().GetMethod("AccionPasadoDadaDialogue"));
			Lua.RegisterFunction("AccionPresenteDadaDialogue", this, base.GetType().GetMethod("AccionPresenteDadaDialogue"));
			Lua.RegisterFunction("AccionRecibidaDialogue", this, base.GetType().GetMethod("AccionRecibidaDialogue"));
			Lua.RegisterFunction("Accion3PersonaRecibidaDialogue", this, base.GetType().GetMethod("Accion3PersonaRecibidaDialogue"));
			Lua.RegisterFunction("AccionPasadoRecibidaDialogue", this, base.GetType().GetMethod("AccionPasadoRecibidaDialogue"));
			Lua.RegisterFunction("AccionPresenteRecibidaDialogue", this, base.GetType().GetMethod("AccionPresenteRecibidaDialogue"));
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00014040 File Offset: 0x00012240
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("DivergenciaSumisaSetTargetInteraction");
			Lua.UnregisterFunction("DivergenciaSumisaSetTargetInteractionConEstimulada");
			Lua.UnregisterFunction("DivergenciaAddEndDelegado");
			Lua.UnregisterFunction("DivergenciaEnd");
			Lua.UnregisterFunction("AccionDadaDialogue");
			Lua.UnregisterFunction("Accion3PersonaDadaDialogue");
			Lua.UnregisterFunction("AccionPasadoDadaDialogue");
			Lua.UnregisterFunction("AccionPresenteDadaDialogue");
			Lua.UnregisterFunction("AccionRecibidaDialogue");
			Lua.UnregisterFunction("Accion3PersonaRecibidaDialogue");
			Lua.UnregisterFunction("AccionPasadoRecibidaDialogue");
			Lua.UnregisterFunction("AccionPresenteRecibidaDialogue");
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000140CC File Offset: 0x000122CC
		public void DivergenciaSumisaSetTargetInteraction(string tipoDeEstimuloString, string estimulanteString)
		{
			try
			{
				if (this.m_Pedido != null)
				{
					throw new InvalidOperationException("pedido anterior no fue finalizado");
				}
				TipoDeEstimulo tipoDeEstimulo;
				if (!Enum.TryParse<TipoDeEstimulo>(tipoDeEstimuloString, out tipoDeEstimulo))
				{
					throw new InvalidOperationException(tipoDeEstimuloString + " is invalid enum if " + typeof(TipoDeEstimulo).Name);
				}
				ParteQuePuedeEstimular parteQuePuedeEstimular;
				if (!Enum.TryParse<ParteQuePuedeEstimular>(estimulanteString, out parteQuePuedeEstimular))
				{
					throw new InvalidOperationException(estimulanteString + " is invalid enum if " + typeof(ParteQuePuedeEstimular).Name);
				}
				this.m_Pedido = new RegistroDeFuncionesDeAIP2.Pedido();
				this.m_Pedido.tipoDeRespuesta = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.timida;
				this.m_Pedido.reaccionHumana = ReaccionHumana.placer;
				this.m_Pedido.tipoDeEstimulo = tipoDeEstimulo;
				this.m_Pedido.usaParteEstimulada = false;
				this.m_Pedido.estimulada = ParteDelCuerpoHumano.pecho;
				this.m_Pedido.estimulante = parteQuePuedeEstimular;
				this.m_Pedido.tag = null;
				this.m_Pedido.ignorarRedundancia = true;
				this.m_Pedido.ignorarContextoErrado = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x000141D4 File Offset: 0x000123D4
		public void DivergenciaSumisaSetTargetInteractionConEstimulada(string tipoDeEstimuloString, string estimulanteString, string estimuladaString)
		{
			try
			{
				if (this.m_Pedido != null)
				{
					throw new InvalidOperationException("pedido anterior no fue finalizado");
				}
				TipoDeEstimulo tipoDeEstimulo;
				if (!Enum.TryParse<TipoDeEstimulo>(tipoDeEstimuloString, out tipoDeEstimulo))
				{
					throw new InvalidOperationException(tipoDeEstimuloString + " is invalid enum if " + typeof(TipoDeEstimulo).Name);
				}
				ParteQuePuedeEstimular parteQuePuedeEstimular;
				if (!Enum.TryParse<ParteQuePuedeEstimular>(estimulanteString, out parteQuePuedeEstimular))
				{
					throw new InvalidOperationException(estimulanteString + " is invalid enum if " + typeof(ParteQuePuedeEstimular).Name);
				}
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				if (!Enum.TryParse<ParteDelCuerpoHumano>(estimuladaString, out parteDelCuerpoHumano))
				{
					throw new InvalidOperationException(estimuladaString + " is invalid enum if " + typeof(ParteDelCuerpoHumano).Name);
				}
				this.m_Pedido = new RegistroDeFuncionesDeAIP2.Pedido();
				this.m_Pedido.tipoDeRespuesta = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.timida;
				this.m_Pedido.reaccionHumana = ReaccionHumana.placer;
				this.m_Pedido.tipoDeEstimulo = tipoDeEstimulo;
				this.m_Pedido.usaParteEstimulada = true;
				this.m_Pedido.estimulada = parteDelCuerpoHumano;
				this.m_Pedido.estimulante = parteQuePuedeEstimular;
				this.m_Pedido.tag = null;
				this.m_Pedido.ignorarRedundancia = true;
				this.m_Pedido.ignorarContextoErrado = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00014310 File Offset: 0x00012510
		public void DivergenciaAddEndDelegado(string ending, LuaFunc delegado, LuaTable args)
		{
			try
			{
				this.m_endDelegados.GetValueNotNull(ending).Add(new ValueTuple<LuaFunc, LuaTable>(delegado, args));
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00014350 File Offset: 0x00012550
		public void DivergenciaEnd(string ending)
		{
			try
			{
				foreach (ValueTuple<LuaFunc, LuaTable> valueTuple in this.m_endDelegados[ending])
				{
					LuaFunc item = valueTuple.Item1;
					LuaTable item2 = valueTuple.Item2;
					item((((item2 != null) ? item2.ListValues : null) != null) ? item2.ListValues.ToArray<LuaValue>() : new LuaValue[0]);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
			finally
			{
				this.m_Pedido = null;
				Dictionary<string, List<ValueTuple<LuaFunc, LuaTable>>> endDelegados = this.m_endDelegados;
				if (endDelegados != null)
				{
					endDelegados.Clear();
				}
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00014414 File Offset: 0x00012614
		public string AccionDadaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.dada, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000144E8 File Offset: 0x000126E8
		public string Accion3PersonaDadaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.dada, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000145BC File Offset: 0x000127BC
		public string AccionPasadoDadaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.dada, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00014690 File Offset: 0x00012890
		public string AccionPresenteDadaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.dada, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00014764 File Offset: 0x00012964
		public string AccionRecibidaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.recibida, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00014838 File Offset: 0x00012A38
		public string Accion3PersonaRecibidaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3Persona, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccion3PersonaConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.recibida, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0001490C File Offset: 0x00012B0C
		public string AccionPasadoRecibidaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasado, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPasadoConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.recibida, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000149E0 File Offset: 0x00012BE0
		public string AccionPresenteRecibidaDialogue()
		{
			string text;
			try
			{
				if (this.m_Pedido == null)
				{
					throw new ArgumentNullException("m_Pedido", "m_Pedido null reference.");
				}
				Character conversant = RegistroDeFuncionesDeAI.GetConversant();
				text = GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogoGeneric(conversant, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresente, Singleton<GeneradorDeDialogosGenericosDeInteracciones>.instance.dialogosAccionPresenteConCosaPropia, this.m_ObtenerDialogosUtil, conversant, this.m_Pedido.tipoDeRespuesta, this.m_Pedido.reaccionHumana, DireccionDeEstimulo.recibida, this.m_Pedido.tipoDeEstimulo, this.m_Pedido.usaParteEstimulada, this.m_Pedido.estimulada, this.m_Pedido.estimulante, this.m_Pedido.tag, this.m_Pedido.ignorarRedundancia, this.m_Pedido.ignorarContextoErrado);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = "ERROR";
			}
			return text;
		}

		// Token: 0x0400014D RID: 333
		public const string idSumisaPerdonada = "Perdonada";

		// Token: 0x0400014E RID: 334
		public const string idSumisaFrozada = "Frozada";

		// Token: 0x0400014F RID: 335
		[SerializeField]
		private ObtenerDialogosUtil m_ObtenerDialogosUtil = new ObtenerDialogosUtil();

		// Token: 0x04000150 RID: 336
		[SerializeReference]
		private RegistroDeFuncionesDeAIP2.Pedido m_Pedido;

		// Token: 0x04000151 RID: 337
		private Dictionary<string, List<ValueTuple<LuaFunc, LuaTable>>> m_endDelegados = new Dictionary<string, List<ValueTuple<LuaFunc, LuaTable>>>();

		// Token: 0x020000A6 RID: 166
		[Serializable]
		public class Pedido
		{
			// Token: 0x040001CA RID: 458
			public Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta;

			// Token: 0x040001CB RID: 459
			public ReaccionHumana reaccionHumana;

			// Token: 0x040001CC RID: 460
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040001CD RID: 461
			public bool usaParteEstimulada;

			// Token: 0x040001CE RID: 462
			public ParteDelCuerpoHumano estimulada;

			// Token: 0x040001CF RID: 463
			public ParteQuePuedeEstimular estimulante;

			// Token: 0x040001D0 RID: 464
			public string tag;

			// Token: 0x040001D1 RID: 465
			public bool ignorarRedundancia;

			// Token: 0x040001D2 RID: 466
			public bool ignorarContextoErrado;
		}
	}
}

using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Textos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200000D RID: 13
	public static class ObtenerDialogoHelper
	{
		// Token: 0x0600007A RID: 122 RVA: 0x00003204 File Offset: 0x00001404
		public static bool ObtenerDialogo(ObtenerDialogosUtil Util, IReadOnlyList<DialogosLocalizadosGenericos> dialogosInfo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, Character conversante, ReaccionHumana reaccion, DireccionDeEstimulo direccion, object productor, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, out string dialogo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			bool flag;
			try
			{
				for (int i = 0; i < dialogosInfo.Count; i++)
				{
					ObtenerDialogoHelper.m_dialogosInfo_TEMP.Add(dialogosInfo[i].Obtener(null));
				}
				flag = ObtenerDialogoHelper.ObtenerDialogo(Util, ObtenerDialogoHelper.m_dialogosInfo_TEMP, tipoDeRespuesta, conversante, reaccion, direccion, productor, tipoDeEstimulo, estimulada, estimulante, tag, out dialogo, ignorarRedundancia, ignorarContextoErrado);
			}
			finally
			{
				ObtenerDialogoHelper.m_dialogosInfo_TEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000327C File Offset: 0x0000147C
		public static bool ObtenerDialogo(ObtenerDialogosUtil Util, DialogosLocalizadosGenericos dialogoInfo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, Character conversante, ReaccionHumana reaccion, DireccionDeEstimulo direccion, object productor, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, out string dialogo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			bool flag;
			try
			{
				ObtenerDialogoHelper.m_dialogosInfo_TEMP.Add(dialogoInfo.Obtener(null));
				flag = ObtenerDialogoHelper.ObtenerDialogo(Util, ObtenerDialogoHelper.m_dialogosInfo_TEMP, tipoDeRespuesta, conversante, reaccion, direccion, productor, tipoDeEstimulo, estimulada, estimulante, tag, out dialogo, ignorarRedundancia, ignorarContextoErrado);
			}
			finally
			{
				ObtenerDialogoHelper.m_dialogosInfo_TEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000032DC File Offset: 0x000014DC
		public static bool ObtenerDialogo(ObtenerDialogosUtil Util, IReadOnlyList<DialogoInfoGenerico> dialogosInfo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, Character conversante, ReaccionHumana reaccion, DireccionDeEstimulo direccion, object productor, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, out string dialogo, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			if (tipoDeRespuesta == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
			{
				tipoDeRespuesta = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)(-1);
			}
			Personalidad componentInChildren = conversante.GetComponentInChildren<Personalidad>();
			ICalculoDeEstimulo calculoDeEstimulo = ObtenerDialogoHelper.ObternerDummy(conversante.GetComponentInChildren<EmocionesFemeninas>(), reaccion, direccion, tipoDeEstimulo, estimulada, estimulante, tag);
			int i = 0;
			while (i < dialogosInfo.Count)
			{
				DialogoInfoGenerico dialogoInfoGenerico = dialogosInfo[i];
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (Util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, productor, dialogoInfoGenerico, calculoDeEstimulo, null, null, tipoDeRespuesta, ignorarRedundancia, ignorarContextoErrado))
				{
					dialogo = ObtenerDialogoHelper.ObtenerTextoDeDialogo(dialogoInfoGenerico, componentInChildren, direccion);
					return true;
				}
				switch (resultado)
				{
				case ObtenerDialogosUtil.Resultado.redundante:
				case ObtenerDialogosUtil.Resultado.contextoErrado:
					i++;
					break;
				case ObtenerDialogosUtil.Resultado.noExisteDialogo:
				case ObtenerDialogosUtil.Resultado.error:
				case ObtenerDialogosUtil.Resultado.noExisteDialogoTipoDeRespuesta:
					throw new InvalidOperationException();
				default:
					throw new ArgumentOutOfRangeException(resultado.ToString());
				}
			}
			dialogo = null;
			return false;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000339C File Offset: 0x0000159C
		private static string ObtenerTextoDeDialogo(DialogoInfo dialogoInfo, Personalidad personalidad, DireccionDeEstimulo direccion)
		{
			bool flag = Singleton<DiccionarioDeSinonimos>.IsInScene && Singleton<DiccionarioDeSinonimos>.instance.EsMutable(dialogoInfo);
			RestriccionDeEdad restriccionDeEdad = personalidad.ObtenerRestriccion();
			string text;
			if (flag)
			{
				text = dialogoInfo.Mutado(Singleton<DiccionarioDeSinonimos>.instance.mutadorConRestriccion, Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, restriccionDeEdad, Sexo.noDefinido, direccion.ObtenerDireccionParaDialogos());
			}
			else
			{
				text = dialogoInfo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, direccion.ObtenerDireccionParaDialogos());
			}
			return text;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003410 File Offset: 0x00001610
		private static ICalculoDeEstimulo ObternerDummy(EmocionesFemeninas emociones, ReaccionHumana reaccion, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
				if (ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado = new CalculoDeEstimuloPorCariciasResultado();
					ObtenerDialogoHelper.m_EstimuloTactil = new EstimuloTactil();
					ObtenerDialogoHelper.m_EstimuloTactil.EstimuloSoloUsaPrioridadesFixed();
					ObtenerDialogoHelper.m_EstimuloTactil.velocidadRelativaEmuladaMaxima = 1f;
					ObtenerDialogoHelper.m_EstimuloTactilDeSemen = new EstimuloTactilDeSemen();
					ObtenerDialogoHelper.m_EstimuloTactilDeSemen.EstimuloSoloUsaPrioridadesFixed();
					ObtenerDialogoHelper.m_EstimuloTactilDeSemen.velocidadRelativaEmuladaMaxima = 1f;
					UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado.rango = UmbralBasico.RangoEstado.enRango;
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					estado.offsetMod = 1f;
					estado.spotScore = SpotScore.fuera;
					estado.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.data.estado = estado;
				}
				if (estimulante == ParteQuePuedeEstimular.semen)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloTactilDeSemen, null);
				}
				else
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloTactil, null);
				}
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.Poblar(emociones.ObtenerEmocion(reaccion), null, TipoDeCalculoDeEstimulo.frame);
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.data.tag = tag;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.SetTipoDeEstimuloTactil(ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado.estimulo.ObtenerTipoDeEstimuloTactil(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, estimulante, false));
				return ObtenerDialogoHelper.m_CalculoDeEstimuloPorCariciasResultado;
			case TipoDeEstimulo.visual:
				if (ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado = new CalculoDeEstimuloVisualResultado();
					ObtenerDialogoHelper.m_EstimuloVisual = new EstimuloVisual();
					ObtenerDialogoHelper.m_EstimuloVisual.EstimuloSoloUsaPrioridadesFixed();
					UmbralBasico.Estado estado2 = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado2.rango = UmbralBasico.RangoEstado.enRango;
					estado2.SetEstimulacionGeneradaEnFrame(1f);
					estado2.SetEstimulacionGeneradaTotal(1f);
					estado2.offsetMod = 1f;
					estado2.spotScore = SpotScore.fuera;
					estado2.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloVisual, null);
					ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.data.estado = estado2;
				}
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.Poblar(emociones.ObtenerEmocion(reaccion), null, TipoDeCalculoDeEstimulo.frame);
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.data.tag = tag;
				ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado.estimulo.SetTipoDeEstimuloVisual(estimulante.ObtenerTipoDeEstimuloVisual());
				return ObtenerDialogoHelper.m_CalculoDeEstimuloVisualResultado;
			case TipoDeEstimulo.coital:
				if (ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado = new CalculoDeEstimuloPorPenetracionHoleResultado();
					ObtenerDialogoHelper.m_EstimuloPenetrante = new EstimuloPenetrante();
					ObtenerDialogoHelper.m_EstimuloPenetrante.EstimuloSoloUsaPrioridadesFixed();
					UmbralBasico.Estado estado3 = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado3.rango = UmbralBasico.RangoEstado.enRango;
					estado3.SetEstimulacionGeneradaEnFrame(1f);
					estado3.SetEstimulacionGeneradaTotal(1f);
					estado3.offsetMod = 1f;
					estado3.spotScore = SpotScore.fuera;
					estado3.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloPenetrante, null);
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.penetracion = estado3;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.apertura = estado3;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.movimiento = estado3;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.profundidad = estado3;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.anchura = estado3;
					ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.tipo = TipoDeCalculoDeEstimulo.frame;
				}
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.Poblar(emociones.ObtenerEmocion(reaccion), null);
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.data.tag = tag;
				ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado.estimulo.tipoDeEstimuloCoital = estimulante.ObtenerTipoDeEstimuloCoital();
				return ObtenerDialogoHelper.m_CalculoDeEstimuloPorPenetracionHoleResultado;
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
				if (ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado = new CalculoDeEstimuloDesvestidoResultado();
					ObtenerDialogoHelper.m_EstimuloPorDesvestir = new EstimuloPorDesvestir();
					ObtenerDialogoHelper.m_EstimuloPorDesvestir.EstimuloSoloUsaPrioridadesFixed();
					UmbralBasico.Estado estado4 = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado4.rango = UmbralBasico.RangoEstado.enRango;
					estado4.SetEstimulacionGeneradaEnFrame(1f);
					estado4.SetEstimulacionGeneradaTotal(1f);
					estado4.offsetMod = 1f;
					estado4.spotScore = SpotScore.fuera;
					estado4.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloPorDesvestir, null);
					ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.data.estado = estado4;
				}
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.Poblar(emociones.ObtenerEmocion(reaccion), null, TipoDeCalculoDeEstimulo.frame);
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado.data.tag = tag;
				return ObtenerDialogoHelper.m_CalculoDeEstimuloDesvestidoResultado;
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
				if (ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado = new CalculoDeEstimuloCambioDePoseResultado();
					ObtenerDialogoHelper.m_EstimuloPorCambiarPose = new EstimuloPorCambiarPose();
					ObtenerDialogoHelper.m_EstimuloPorCambiarPose.EstimuloSoloUsaPrioridadesFixed();
					UmbralBasico.Estado estado5 = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado5.rango = UmbralBasico.RangoEstado.enRango;
					estado5.SetEstimulacionGeneradaEnFrame(1f);
					estado5.SetEstimulacionGeneradaTotal(1f);
					estado5.offsetMod = 1f;
					estado5.spotScore = SpotScore.fuera;
					estado5.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloPorCambiarPose, null);
					ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.data.estado = estado5;
				}
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.Poblar(emociones.ObtenerEmocion(reaccion), null, TipoDeCalculoDeEstimulo.frame);
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado.data.tag = tag;
				return ObtenerDialogoHelper.m_CalculoDeEstimuloCambioDePoseResultado;
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				if (ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado == null)
				{
					ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado = new CalculoDeEmocionesPorMovimientoDeBonesResultado();
					ObtenerDialogoHelper.m_EstimuloPorManipulacionDeBone = new EstimuloPorManipulacionDeBone();
					ObtenerDialogoHelper.m_EstimuloPorManipulacionDeBone.EstimuloSoloUsaPrioridadesFixed();
					UmbralBasico.Estado estado6 = new UmbralBasico.Estado(ForcedUpdateId.current);
					estado6.rango = UmbralBasico.RangoEstado.enRango;
					estado6.SetEstimulacionGeneradaEnFrame(1f);
					estado6.SetEstimulacionGeneradaTotal(1f);
					estado6.offsetMod = 1f;
					estado6.spotScore = SpotScore.fuera;
					estado6.spotRango = UmbralBasico.RangoEstado.sinEstimulo;
					ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.SetEstimuloInstance(ObtenerDialogoHelper.m_EstimuloPorManipulacionDeBone, null);
					ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.data.estado = estado6;
				}
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.Poblar(emociones.ObtenerEmocion(reaccion), null, TipoDeCalculoDeEstimulo.frame);
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.estimulo.ClearPartesEstimuladas();
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.estimulo.tipo = direccion;
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.estimulo.tipoDeEstimulo = tipoDeEstimulo;
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.estimulo.AddParteEstimulada(estimulada);
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.data.estimulanteParte = estimulante;
				ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado.data.tag = tag;
				return ObtenerDialogoHelper.m_CalculoDeEmocionesPorMovimientoDeBonesResultado;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x0400001C RID: 28
		private static List<DialogoInfoGenerico> m_dialogosInfo_TEMP = new List<DialogoInfoGenerico>();

		// Token: 0x0400001D RID: 29
		private static EstimuloTactilDeSemen m_EstimuloTactilDeSemen;

		// Token: 0x0400001E RID: 30
		private static EstimuloTactil m_EstimuloTactil;

		// Token: 0x0400001F RID: 31
		private static CalculoDeEstimuloPorCariciasResultado m_CalculoDeEstimuloPorCariciasResultado;

		// Token: 0x04000020 RID: 32
		private static EstimuloVisual m_EstimuloVisual;

		// Token: 0x04000021 RID: 33
		private static CalculoDeEstimuloVisualResultado m_CalculoDeEstimuloVisualResultado;

		// Token: 0x04000022 RID: 34
		private static EstimuloPenetrante m_EstimuloPenetrante;

		// Token: 0x04000023 RID: 35
		private static CalculoDeEstimuloPorPenetracionHoleResultado m_CalculoDeEstimuloPorPenetracionHoleResultado;

		// Token: 0x04000024 RID: 36
		private static EstimuloPorDesvestir m_EstimuloPorDesvestir;

		// Token: 0x04000025 RID: 37
		private static CalculoDeEstimuloDesvestidoResultado m_CalculoDeEstimuloDesvestidoResultado;

		// Token: 0x04000026 RID: 38
		private static EstimuloPorCambiarPose m_EstimuloPorCambiarPose;

		// Token: 0x04000027 RID: 39
		private static CalculoDeEstimuloCambioDePoseResultado m_CalculoDeEstimuloCambioDePoseResultado;

		// Token: 0x04000028 RID: 40
		private static EstimuloPorManipulacionDeBone m_EstimuloPorManipulacionDeBone;

		// Token: 0x04000029 RID: 41
		private static CalculoDeEmocionesPorMovimientoDeBonesResultado m_CalculoDeEmocionesPorMovimientoDeBonesResultado;
	}
}

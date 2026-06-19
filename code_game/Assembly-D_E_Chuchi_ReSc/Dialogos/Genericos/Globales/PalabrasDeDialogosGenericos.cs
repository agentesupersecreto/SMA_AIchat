using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Globales
{
	// Token: 0x02000212 RID: 530
	public sealed class PalabrasDeDialogosGenericos : Singleton<PalabrasDeDialogosGenericos>
	{
		// Token: 0x06000C21 RID: 3105 RVA: 0x00035F48 File Offset: 0x00034148
		protected override void InitData(bool esEditorTime)
		{
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.prefijos, TipoDePalabraGenerica.prefijo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.sufijos, TipoDePalabraGenerica.sufijo);
			PalabrasDeDialogosGenericos.LoadListasPeticionesPersonalesPositivas(this.US, this.ES, this.m_userDialogos.peticionesPersonales.positivos, TipoDePalabraGenerica.peticionPersonal);
			PalabrasDeDialogosGenericos.LoadListasPeticionesPersonalesNegativas(this.US, this.ES, this.m_userDialogos.peticionesPersonales.negativos, TipoDePalabraGenerica.peticionPersonal);
			PalabrasDeDialogosGenericos.LoadListasPeticionesPresentesPositivas(this.US, this.ES, this.m_userDialogos.peticionesPresente.positivos, TipoDePalabraGenerica.peticionPresente);
			PalabrasDeDialogosGenericos.LoadListasPeticionesPresentesNegativas(this.US, this.ES, this.m_userDialogos.peticionesPresente.negativos, TipoDePalabraGenerica.peticionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil(this.US, this.ES, this.m_userDialogos.accionesTactiles.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3Persona(this.US, this.ES, this.m_userDialogos.accionesTactiles3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesTactiles3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilConjugada(this.US, this.ES, this.m_userDialogos.accionesTactilesConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesPlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPresentes(this.US, this.ES, this.m_userDialogos.accionesTactilesPresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPasado(this.US, this.ES, this.m_userDialogos.accionesTactilesPasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil(this.US, this.ES, this.m_userDialogos.accionesTactiles.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3Persona(this.US, this.ES, this.m_userDialogos.accionesTactiles3Persona.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesTactiles3PersonaPlural.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilConjugada(this.US, this.ES, this.m_userDialogos.accionesTactilesConjugadas.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesPlurales.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPresentes(this.US, this.ES, this.m_userDialogos.accionesTactilesPresente.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPasado(this.US, this.ES, this.m_userDialogos.accionesTactilesPasado.dialogosDeAccionesInvertidas, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobre.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3Persona(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobre3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobre3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilConjugada(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobreConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobrePlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPresentes(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobrePresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPasado(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesSobrePasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentro.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3Persona(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentro3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccionTactil3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentro3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilConjugada(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentroConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPlural(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentroPlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPresentes(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentroPresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionTactilPasado(this.US, this.ES, this.m_userDialogos.accionesTactilesDerramantesDentroPasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccionCoital(this.US, this.ES, this.m_userDialogos.accionesCoitalesConTool.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccionCoital3Persona(this.US, this.ES, this.m_userDialogos.accionesCoitalesConTool3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccionCoital3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesCoitalesConTool3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionCoitalConjugada(this.US, this.ES, this.m_userDialogos.accionesCoitalesConToolConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionCoitalPlural(this.US, this.ES, this.m_userDialogos.accionesCoitalesConToolPlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionCoitalPresentes(this.US, this.ES, this.m_userDialogos.accionesCoitalesConToolPresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionCoitalPasado(this.US, this.ES, this.m_userDialogos.accionesCoitalesConToolPasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccion(this.US, this.ES, this.m_userDialogos.accionesVisuales.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccion3Persona(this.US, this.ES, this.m_userDialogos.accionesVisuales3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccion3PersonaPlural(this.US, this.ES, this.m_userDialogos.accionesVisuales3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionConjugada(this.US, this.ES, this.m_userDialogos.accionesVisualesConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionPlural(this.US, this.ES, this.m_userDialogos.accionesVisualesPlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionPresentes(this.US, this.ES, this.m_userDialogos.accionesVisualesPresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionPasado(this.US, this.ES, this.m_userDialogos.accionesVisualesPasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasAccion(this.US, this.ES, this.m_userDialogos.acciones.dialogosDeAcciones, TipoDePalabraGenerica.accion);
			PalabrasDeDialogosGenericos.LoadListasAccion3Persona(this.US, this.ES, this.m_userDialogos.acciones3Persona.dialogosDeAcciones, TipoDePalabraGenerica.accion3Persona);
			PalabrasDeDialogosGenericos.LoadListasAccion3PersonaPlural(this.US, this.ES, this.m_userDialogos.acciones3PersonaPlural.dialogosDeAcciones, TipoDePalabraGenerica.accion3PersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionConjugada(this.US, this.ES, this.m_userDialogos.accionesConjugadas.dialogosDeAcciones, TipoDePalabraGenerica.accionConjugada);
			PalabrasDeDialogosGenericos.LoadListasAccionPlural(this.US, this.ES, this.m_userDialogos.accionesPlurales.dialogosDeAcciones, TipoDePalabraGenerica.accionPlural);
			PalabrasDeDialogosGenericos.LoadListasAccionPresentes(this.US, this.ES, this.m_userDialogos.accionesPresente.dialogosDeAcciones, TipoDePalabraGenerica.accionPresente);
			PalabrasDeDialogosGenericos.LoadListasAccionPasado(this.US, this.ES, this.m_userDialogos.accionesPasado.dialogosDeAcciones, TipoDePalabraGenerica.accionPasado);
			PalabrasDeDialogosGenericos.LoadListasEmocionales(this.m_userDialogos.peticionesSerConjugado, TipoDePalabraGenerica.peticionSerConjugado, this.US.peticionesSerConjugadoDeTipoDeRespuesta, this.ES.peticionesSerConjugadoDeTipoDeRespuesta);
			PalabrasDeDialogosGenericos.LoadListasEmocionPersonal(this.US, this.ES, this.m_userDialogos.emocionesPersonales, TipoDePalabraGenerica.emocionPersonal);
			PalabrasDeDialogosGenericos.LoadListasEmocionPersonalPlural(this.US, this.ES, this.m_userDialogos.emocionesPersonalesPlural, TipoDePalabraGenerica.emocionPersonalPlural);
			PalabrasDeDialogosGenericos.LoadListasEmocionPresentes(this.US, this.ES, this.m_userDialogos.emocionesPresente, TipoDePalabraGenerica.emocionPresente);
			PalabrasDeDialogosGenericos.LoadListasEmocionTerceraPersona(this.US, this.ES, this.m_userDialogos.emocionesTerceraPersona, TipoDePalabraGenerica.emocionTerceraPersona);
			PalabrasDeDialogosGenericos.LoadListasEmocionTerceraPersonaPlural(this.US, this.ES, this.m_userDialogos.emocionesTerceraPersonaPlural, TipoDePalabraGenerica.emocionTerceraPersonaPlural);
			PalabrasDeDialogosGenericos.LoadListasSentimientoPerfectos(this.US, this.ES, this.m_userDialogos.sentimientosPerfectos, TipoDePalabraGenerica.sentimientoPerfecto);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.yo, TipoDePalabraGenerica.yo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.yoEstoy, TipoDePalabraGenerica.yoEstoy);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.yoMismo, TipoDePalabraGenerica.yoMismo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.porYoMismo, TipoDePalabraGenerica.porYoMismo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.tu, TipoDePalabraGenerica.tu);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.mi, TipoDePalabraGenerica.mi);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.miPlural, TipoDePalabraGenerica.miPlural);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.con, TipoDePalabraGenerica.con);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.articulos.el, TipoDePalabraGenerica.el);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.articulos.la, TipoDePalabraGenerica.la);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.articulos.los, TipoDePalabraGenerica.los);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.articulos.las, TipoDePalabraGenerica.las);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.articulos.a, TipoDePalabraGenerica.a);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.en.enDentro, TipoDePalabraGenerica.enDentro);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.en.enSobre, TipoDePalabraGenerica.enSobre);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.en.enUbicacion, TipoDePalabraGenerica.enUbicacion);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.eso, TipoDePalabraGenerica.eso);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.esoEs, TipoDePalabraGenerica.esoEs);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.esoEsta, TipoDePalabraGenerica.esoEsta);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.esoCosa, TipoDePalabraGenerica.esoCosa);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.esoCosaPlural, TipoDePalabraGenerica.esoCosaPlural);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.esto, TipoDePalabraGenerica.esto);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.cuando, TipoDePalabraGenerica.cuando);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.muy, TipoDePalabraGenerica.muy);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.muymuy, TipoDePalabraGenerica.muymuy);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.estas, TipoDePalabraGenerica.estas);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.esta, TipoDePalabraGenerica.esta);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.me, TipoDePalabraGenerica.me);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.tuyo, TipoDePalabraGenerica.tuyo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.pronombres.tuyoPlural, TipoDePalabraGenerica.tuyoPlural);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.hacerConjugado, TipoDePalabraGenerica.hacerConjugado);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.hacerPlural, TipoDePalabraGenerica.hacerPlural);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.haciendo, TipoDePalabraGenerica.haciendo);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.deEstar, TipoDePalabraGenerica.deEstar);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.queEstes, TipoDePalabraGenerica.queEstes);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.ponerPerfecto, TipoDePalabraGenerica.ponerPerfecto);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.tomarPerfecto, TipoDePalabraGenerica.tomarPerfecto);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.voltearPerfecto, TipoDePalabraGenerica.voltearPerfecto);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.lejos, TipoDePalabraGenerica.lejos);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.desde, TipoDePalabraGenerica.desde);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.de, TipoDePalabraGenerica.de);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.off, TipoDePalabraGenerica.off);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.why, TipoDePalabraGenerica.why);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.hacerPasado, TipoDePalabraGenerica.hacerPasado);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.stop, TipoDePalabraGenerica.stop);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.again, TipoDePalabraGenerica.again);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.just, TipoDePalabraGenerica.just);
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar bajasAltasPar in this.m_userDialogos.intensidadAdjetivos)
			{
				PalabrasDeDialogosGenericos.LoadListasBajaAlta(bajasAltasPar.listas, TipoDePalabraGenerica.intensidadAdjetivo, Mathf.Abs((int)bajasAltasPar.intensidad), this.US.intensidadAdjetivo, this.ES.intensidadAdjetivo);
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar bajasAltasPar2 in this.m_userDialogos.intensidadAdverbios)
			{
				PalabrasDeDialogosGenericos.LoadListasBajaAlta(bajasAltasPar2.listas, TipoDePalabraGenerica.intensidadAdverbio, Mathf.Abs((int)bajasAltasPar2.intensidad), this.US.intensidadAdverbio, this.ES.intensidadAdverbio);
			}
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.exclamacionPlacer, TipoDePalabraGenerica.exclamacionPlacer);
			PalabrasDeDialogosGenericos.LoadListas(this.US, this.ES, this.m_userDialogos.empty, TipoDePalabraGenerica.empty);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00036E8C File Offset: 0x0003508C
		public PalabrasDeDialogosGenericos.DialogosDeLocal DialogosDeCurrentLocal()
		{
			if (string.Equals(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura, "US", StringComparison.InvariantCultureIgnoreCase))
			{
				return this.US;
			}
			if (string.Equals(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.cultura, "ES", StringComparison.InvariantCultureIgnoreCase))
			{
				return this.ES;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00036EE4 File Offset: 0x000350E4
		private static void LoadListasPeticionesPersonalesPositivas(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, List<DialogosLocalizadosDeTipoDeRespuesta> listaDeMapas, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.peticionPersonal)
			{
				throw new InvalidOperationException();
			}
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in listaDeMapas)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeUS.peticionesPersonalesPositivasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeES.peticionesPersonalesPositivasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00036F9C File Offset: 0x0003519C
		private static void LoadListasPeticionesPersonalesNegativas(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, List<DialogosLocalizadosDeTipoDeRespuesta> listaDeMapas, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.peticionPersonal)
			{
				throw new InvalidOperationException();
			}
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in listaDeMapas)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeUS.peticionesPersonalesNegativasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeES.peticionesPersonalesNegativasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
			}
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00037054 File Offset: 0x00035254
		private static void LoadListasPeticionesPresentesPositivas(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, List<DialogosLocalizadosDeTipoDeRespuesta> listaDeMapas, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.peticionPresente)
			{
				throw new InvalidOperationException();
			}
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in listaDeMapas)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeUS.peticionesPresentesPositivasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeES.peticionesPresentesPositivasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
			}
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x0003710C File Offset: 0x0003530C
		private static void LoadListasPeticionesPresentesNegativas(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, List<DialogosLocalizadosDeTipoDeRespuesta> listaDeMapas, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.peticionPresente)
			{
				throw new InvalidOperationException();
			}
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in listaDeMapas)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeUS.peticionesPresentesNegativasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadToPeticiones(diagsDeES.peticionesPresentesNegativasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta);
				}
			}
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x000371C4 File Offset: 0x000353C4
		private static void LoadListas(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, List<DialogosLocalizadosDeTipoDeRespuesta> listaDeMapas, TipoDePalabraGenerica tipoPalabra)
		{
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in listaDeMapas)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadToTipoDePalabra(diagsDeUS, dialogosLocalizadosDeTipoDeRespuesta, tipoPalabra);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadToTipoDePalabra(diagsDeES, dialogosLocalizadosDeTipoDeRespuesta, tipoPalabra);
				}
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00037268 File Offset: 0x00035468
		private static void LoadListasAccionTactil3PersonaPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3PersonaPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00037398 File Offset: 0x00035598
		private static void LoadListasAccionTactil(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x000374C8 File Offset: 0x000356C8
		private static void LoadListasAccionTactil3Persona(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3Persona)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x000375F8 File Offset: 0x000357F8
		private static void LoadListasAccionTactilConjugada(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionConjugada)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00037728 File Offset: 0x00035928
		private static void LoadListasAccionTactilPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00037858 File Offset: 0x00035A58
		private static void LoadListasAccionTactilPresentes(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPresente)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00037988 File Offset: 0x00035B88
		private static void LoadListasAccionTactilPasado(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPasado)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.tactil, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00037AB8 File Offset: 0x00035CB8
		private static void LoadListasAccionCoital3PersonaPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3PersonaPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x00037BE8 File Offset: 0x00035DE8
		private static void LoadListasAccionCoital(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00037D18 File Offset: 0x00035F18
		private static void LoadListasAccionCoital3Persona(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3Persona)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00037E48 File Offset: 0x00036048
		private static void LoadListasAccionCoitalConjugada(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionConjugada)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00037F78 File Offset: 0x00036178
		private static void LoadListasAccionCoitalPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x000380A8 File Offset: 0x000362A8
		private static void LoadListasAccionCoitalPresentes(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPresente)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x000381D8 File Offset: 0x000363D8
		private static void LoadListasAccionCoitalPasado(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPasado)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimuloEspecificoInt == 0)
				{
					Debug.LogError("TipoDeEstimuloTactil de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, TipoDeEstimulo.coital, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00038308 File Offset: 0x00036508
		private static void LoadListasAccion3PersonaPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3PersonaPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaPluralDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00038440 File Offset: 0x00036640
		private static void LoadListasAccion(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00038578 File Offset: 0x00036778
		private static void LoadListasAccion3Persona(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accion3Persona)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.acciones3PersonaDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x000386B0 File Offset: 0x000368B0
		private static void LoadListasAccionConjugada(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionConjugada)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesConjugadasDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x000387E8 File Offset: 0x000369E8
		private static void LoadListasAccionPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPlural)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPluralesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00038920 File Offset: 0x00036B20
		private static void LoadListasAccionPresentes(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPresente)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPresentesDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00038A58 File Offset: 0x00036C58
		private static void LoadListasAccionPasado(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, IReadOnlyList<PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones> pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.accionPasado)
			{
				throw new InvalidOperationException();
			}
			foreach (PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones parAcciones in pares)
			{
				if (parAcciones.tipoDeEstimulo == TipoDeEstimulo.None)
				{
					Debug.LogError("TipoDeEstimulo de accion es None");
				}
				else
				{
					foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parAcciones.dialogos)
					{
						if (dialogosLocalizadosDeTipoDeRespuesta == null)
						{
							throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
						}
						if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
						{
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeUS.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
						else
						{
							if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
							{
								throw new ArgumentOutOfRangeException();
							}
							PalabrasDeDialogosGenericos.LoadToTipoDeEstimulo(diagsDeES.accionesPasadoDeTipoDeRespuesta, dialogosLocalizadosDeTipoDeRespuesta, parAcciones.tipoDeEstimulo, parAcciones.direccionDeEstimuloV2, parAcciones.tipoDeEstimuloEspecificoInt, parAcciones.CompatibilidadConPartes);
						}
					}
				}
			}
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x00038B90 File Offset: 0x00036D90
		private static void LoadListasEmocionales(PalabrasDeDialogosGenericos.IParesEmocionales pares, TipoDePalabraGenerica tipoPalabra, DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> US, DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> ES)
		{
			foreach (PalabrasDeDialogosGenericos.IParEmocional parEmocional in pares.pares)
			{
				foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in parEmocional.dialogos)
				{
					if (dialogosLocalizadosDeTipoDeRespuesta == null)
					{
						throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
					}
					if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
					{
						PalabrasDeDialogosGenericos.LoadToTipoDeEmocion(US, dialogosLocalizadosDeTipoDeRespuesta, parEmocional.tipo);
					}
					else
					{
						if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
						{
							throw new ArgumentOutOfRangeException();
						}
						PalabrasDeDialogosGenericos.LoadToTipoDeEmocion(ES, dialogosLocalizadosDeTipoDeRespuesta, parEmocional.tipo);
					}
				}
			}
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x00038C78 File Offset: 0x00036E78
		private static void LoadListasEmocionPersonal(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.emocionPersonal)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.emocionesPersonalesDeTipoDeRespuesta, diagsDeES.emocionesPersonalesDeTipoDeRespuesta);
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x00038C98 File Offset: 0x00036E98
		private static void LoadListasEmocionPersonalPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.emocionPersonalPlural)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.emocionesPersonalesPluralesDeTipoDeRespuesta, diagsDeES.emocionesPersonalesPluralesDeTipoDeRespuesta);
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00038CB8 File Offset: 0x00036EB8
		private static void LoadListasEmocionPresentes(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.emocionPresente)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.emocionesPresentesDeTipoDeRespuesta, diagsDeES.emocionesPresentesDeTipoDeRespuesta);
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00038CD8 File Offset: 0x00036ED8
		private static void LoadListasEmocionTerceraPersona(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.emocionTerceraPersona)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.emocionesTerceraPersonaDeTipoDeRespuesta, diagsDeES.emocionesTerceraPersonaDeTipoDeRespuesta);
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00038CF8 File Offset: 0x00036EF8
		private static void LoadListasEmocionTerceraPersonaPlural(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.emocionTerceraPersonaPlural)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.emocionesTerceraPersonaPluralesDeTipoDeRespuesta, diagsDeES.emocionesTerceraPersonaPluralesDeTipoDeRespuesta);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00038D18 File Offset: 0x00036F18
		private static void LoadListasSentimientoPerfectos(PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeUS, PalabrasDeDialogosGenericos.DialogosDeLocal diagsDeES, PalabrasDeDialogosGenericos.DialogosMapas.Emociones pares, TipoDePalabraGenerica tipoPalabra)
		{
			if (tipoPalabra != TipoDePalabraGenerica.sentimientoPerfecto)
			{
				throw new InvalidOperationException();
			}
			PalabrasDeDialogosGenericos.LoadListasEmocionales(pares, tipoPalabra, diagsDeUS.sentimientoPerfectoDeTipoDeRespuesta, diagsDeES.sentimientoPerfectoDeTipoDeRespuesta);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00038D38 File Offset: 0x00036F38
		private static void LoadToTipoDeEmocion(DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> dicc, DialogosLocalizadosDeTipoDeRespuesta dialogo, ReaccionHumana emo)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum;
			if (dicc.ContainsKey(emo))
			{
				diccionaryEnum = dicc[emo];
			}
			else
			{
				diccionaryEnum = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);
				dicc.Add(emo, diccionaryEnum);
			}
			PalabrasDeDialogosGenericos.LoadToDiccTipoDeRespuesta(diccionaryEnum, dialogo);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00038D98 File Offset: 0x00036F98
		private static void LoadToTipoDePalabra(PalabrasDeDialogosGenericos.DialogosDeLocal diags, DialogosLocalizadosDeTipoDeRespuesta dialogo, TipoDePalabraGenerica tipoPalabra)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum;
			if (diags.tipoDeRespuestaDeTipoDePalabras.ContainsKey(tipoPalabra))
			{
				diccionaryEnum = diags.tipoDeRespuestaDeTipoDePalabras[tipoPalabra];
			}
			else
			{
				diccionaryEnum = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);
				diags.tipoDeRespuestaDeTipoDePalabras.Add(tipoPalabra, diccionaryEnum);
			}
			PalabrasDeDialogosGenericos.LoadToDiccTipoDeRespuesta(diccionaryEnum, dialogo);
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00038E04 File Offset: 0x00037004
		private static void LoadToTipoDeEstimulo(Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> dicc, DialogosLocalizadosDeTipoDeRespuesta dialogo, TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimuloFlags direcciones, int extraEnum, PalabrasDeDialogosGenericos.CompatibilidadConPartes compatibleConPartesFlags)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			if (compatibleConPartesFlags == PalabrasDeDialogosGenericos.CompatibilidadConPartes.None)
			{
				Debug.LogError("no es compatible con nada");
				return;
			}
			IEnumerable<int> enumValoresInt = typeof(PalabrasDeDialogosGenericos.CompatibilidadConPartes).GetEnumValoresInt();
			IReadOnlyList<int> enumValoresInt2 = typeof(DireccionDeEstimuloFlags).GetEnumValoresInt();
			foreach (int num in enumValoresInt)
			{
				if (((int)compatibleConPartesFlags).HasFlag(num))
				{
					using (IEnumerator<int> enumerator2 = enumValoresInt2.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							DireccionDeEstimuloFlags direccionDeEstimuloFlags = (DireccionDeEstimuloFlags)enumerator2.Current;
							if (direccionDeEstimuloFlags != DireccionDeEstimuloFlags.None && ((int)direcciones).HasFlag((int)direccionDeEstimuloFlags))
							{
								DireccionDeEstimulo direccionDeEstimulo = direccionDeEstimuloFlags.DeFlag();
								ValueTuple<int, int, int, int> valueTuple = new ValueTuple<int, int, int, int>((int)tipoDeEstimulo, (int)direccionDeEstimulo, extraEnum, num);
								DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum;
								if (dicc.ContainsKey(valueTuple))
								{
									diccionaryEnum = dicc[valueTuple];
								}
								else
								{
									diccionaryEnum = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);
									dicc.Add(valueTuple, diccionaryEnum);
								}
								PalabrasDeDialogosGenericos.LoadToDiccTipoDeRespuesta(diccionaryEnum, dialogo);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00038F40 File Offset: 0x00037140
		private static void LoadToPeticiones(DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> dicc, DialogosLocalizadosDeTipoDeRespuesta dialogo)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			PalabrasDeDialogosGenericos.LoadToDiccTipoDeRespuesta(dicc, dialogo);
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00038F54 File Offset: 0x00037154
		private static void LoadToDiccTipoDeRespuesta(DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> dicc, DialogosLocalizadosDeTipoDeRespuesta dialogo)
		{
			IEnumerable<int> enumValoresInt = typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumValoresInt();
			int para = (int)dialogo.para;
			foreach (int num in enumValoresInt)
			{
				int num2 = num;
				if (para.IsAnyFlagSet(num2))
				{
					PalabrasDeDialogosGenericos.LoadToTipoDeRespuesta(dicc, dialogo, (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)num, para != -1);
				}
			}
			if (para == -1)
			{
				PalabrasDeDialogosGenericos.LoadToTipoDeRespuesta(dicc, dialogo, (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)(-1), false);
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00038FD4 File Offset: 0x000371D4
		private static void LoadToTipoDeRespuesta(DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionarioDePalabras, DialogosLocalizadosDeTipoDeRespuesta dialogo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina, bool insertar)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			ListaDeDialogos listaDeDialogos;
			if (diccionarioDePalabras.ContainsKey(tipoDeRespuestaDeDialogoDeHeroina))
			{
				listaDeDialogos = diccionarioDePalabras[tipoDeRespuestaDeDialogoDeHeroina];
			}
			else
			{
				listaDeDialogos = ScriptableObject.CreateInstance<ListaDeDialogos>();
				diccionarioDePalabras.Add(tipoDeRespuestaDeDialogoDeHeroina, listaDeDialogos);
			}
			listaDeDialogos.Add(dialogo.dialogosInfo, insertar);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00039018 File Offset: 0x00037218
		private static void LoadListasBajaAlta(PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas pares, TipoDePalabraGenerica tipoPalabra, int intensidad, Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> US, Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> ES)
		{
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta in pares.baja)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadBajaAlta(-intensidad, US, dialogosLocalizadosDeTipoDeRespuesta);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadBajaAlta(-intensidad, ES, dialogosLocalizadosDeTipoDeRespuesta);
				}
			}
			foreach (DialogosLocalizadosDeTipoDeRespuesta dialogosLocalizadosDeTipoDeRespuesta2 in pares.alta)
			{
				if (dialogosLocalizadosDeTipoDeRespuesta2 == null)
				{
					throw new ArgumentNullException("mapa", "mapa de tipo de palabra: " + tipoPalabra.ToString() + " es null, por vaor verificar mapas inspector.");
				}
				if (dialogosLocalizadosDeTipoDeRespuesta2.ParaCultura(Localizacion.US))
				{
					PalabrasDeDialogosGenericos.LoadBajaAlta(intensidad, US, dialogosLocalizadosDeTipoDeRespuesta2);
				}
				else
				{
					if (!dialogosLocalizadosDeTipoDeRespuesta2.ParaCultura(Localizacion.ES))
					{
						throw new ArgumentOutOfRangeException();
					}
					PalabrasDeDialogosGenericos.LoadBajaAlta(intensidad, ES, dialogosLocalizadosDeTipoDeRespuesta2);
				}
			}
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0003915C File Offset: 0x0003735C
		private static void LoadBajaAlta(int id, Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> dicc, DialogosLocalizadosDeTipoDeRespuesta dialogo)
		{
			if (!dialogo.IsValid())
			{
				return;
			}
			DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> diccionaryEnum;
			if (dicc.ContainsKey(id))
			{
				diccionaryEnum = dicc[id];
			}
			else
			{
				diccionaryEnum = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);
				dicc.Add(id, diccionaryEnum);
			}
			PalabrasDeDialogosGenericos.LoadToDiccTipoDeRespuesta(diccionaryEnum, dialogo);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x000391BC File Offset: 0x000373BC
		public static PalabrasDeDialogosGenericos.CompatibilidadConPartes GetCompatibilidad(DialogoInfoGenerico diag)
		{
			bool flag = diag.Contiene(TipoDePalabraGenerica.cosaPropia);
			bool flag2 = diag.Contiene(TipoDePalabraGenerica.cosaOther);
			if (flag && flag2)
			{
				return PalabrasDeDialogosGenericos.CompatibilidadConPartes.siHayParteOtherYSiHayPartePropia;
			}
			if (flag)
			{
				return PalabrasDeDialogosGenericos.CompatibilidadConPartes.siHayPartePropia;
			}
			if (flag2)
			{
				return PalabrasDeDialogosGenericos.CompatibilidadConPartes.siHayParteOther;
			}
			return PalabrasDeDialogosGenericos.CompatibilidadConPartes.siNoHayPartes;
		}

		// Token: 0x040009CB RID: 2507
		[SerializeField]
		private PalabrasDeDialogosGenericos.DialogosMapas m_userDialogos = new PalabrasDeDialogosGenericos.DialogosMapas();

		// Token: 0x040009CC RID: 2508
		public PalabrasDeDialogosGenericos.DialogosDeLocal US = new PalabrasDeDialogosGenericos.DialogosDeLocal();

		// Token: 0x040009CD RID: 2509
		public PalabrasDeDialogosGenericos.DialogosDeLocal ES = new PalabrasDeDialogosGenericos.DialogosDeLocal();

		// Token: 0x02000213 RID: 531
		[Flags]
		public enum CompatibilidadConPartes
		{
			// Token: 0x040009CF RID: 2511
			None = 0,
			// Token: 0x040009D0 RID: 2512
			siNoHayPartes = 1,
			// Token: 0x040009D1 RID: 2513
			siHayPartePropia = 2,
			// Token: 0x040009D2 RID: 2514
			siHayParteOther = 4,
			// Token: 0x040009D3 RID: 2515
			siHayParteOtherYSiHayPartePropia = 8
		}

		// Token: 0x02000214 RID: 532
		[Serializable]
		public class DialogosDeLocal
		{
			// Token: 0x06000C4E RID: 3150 RVA: 0x00039218 File Offset: 0x00037418
			public void Destruir()
			{
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair in this.intensidadAdverbio)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair2 in keyValuePair.Value)
					{
						if (keyValuePair2.Value != null)
						{
							Object.Destroy(keyValuePair2.Value);
						}
					}
				}
				this.intensidadAdverbio = null;
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair3 in this.intensidadAdjetivo)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair4 in keyValuePair3.Value)
					{
						if (keyValuePair4.Value != null)
						{
							Object.Destroy(keyValuePair4.Value);
						}
					}
				}
				this.intensidadAdjetivo = null;
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair5 in this.peticionesSerConjugadoDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair6 in keyValuePair5.Value)
					{
						if (keyValuePair6.Value != null)
						{
							Object.Destroy(keyValuePair6.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair7 in this.peticionesSerConjugadoDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair8 in keyValuePair7.Value)
					{
						if (keyValuePair8.Value != null)
						{
							Object.Destroy(keyValuePair8.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair9 in this.tipoDeRespuestaDeTipoDePalabras)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair10 in keyValuePair9.Value)
					{
						if (keyValuePair10.Value != null)
						{
							Object.Destroy(keyValuePair10.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair11 in this.accionesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair12 in keyValuePair11.Value)
					{
						if (keyValuePair12.Value != null)
						{
							Object.Destroy(keyValuePair12.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair13 in this.acciones3PersonaDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair14 in keyValuePair13.Value)
					{
						if (keyValuePair14.Value != null)
						{
							Object.Destroy(keyValuePair14.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair15 in this.acciones3PersonaPluralDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair16 in keyValuePair15.Value)
					{
						if (keyValuePair16.Value != null)
						{
							Object.Destroy(keyValuePair16.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair17 in this.accionesConjugadasDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair18 in keyValuePair17.Value)
					{
						if (keyValuePair18.Value != null)
						{
							Object.Destroy(keyValuePair18.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair19 in this.accionesPluralesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair20 in keyValuePair19.Value)
					{
						if (keyValuePair20.Value != null)
						{
							Object.Destroy(keyValuePair20.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair21 in this.accionesPresentesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair22 in keyValuePair21.Value)
					{
						if (keyValuePair22.Value != null)
						{
							Object.Destroy(keyValuePair22.Value);
						}
					}
				}
				foreach (KeyValuePair<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair23 in this.accionesPasadoDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair24 in keyValuePair23.Value)
					{
						if (keyValuePair24.Value != null)
						{
							Object.Destroy(keyValuePair24.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair25 in this.emocionesPersonalesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair26 in keyValuePair25.Value)
					{
						if (keyValuePair26.Value != null)
						{
							Object.Destroy(keyValuePair26.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair27 in this.emocionesPersonalesPluralesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair28 in keyValuePair27.Value)
					{
						if (keyValuePair28.Value != null)
						{
							Object.Destroy(keyValuePair28.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair29 in this.emocionesPresentesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair30 in keyValuePair29.Value)
					{
						if (keyValuePair30.Value != null)
						{
							Object.Destroy(keyValuePair30.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair31 in this.emocionesTerceraPersonaDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair32 in keyValuePair31.Value)
					{
						if (keyValuePair32.Value != null)
						{
							Object.Destroy(keyValuePair32.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair33 in this.emocionesTerceraPersonaPluralesDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair34 in keyValuePair33.Value)
					{
						if (keyValuePair34.Value != null)
						{
							Object.Destroy(keyValuePair34.Value);
						}
					}
				}
				foreach (KeyValuePair<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> keyValuePair35 in this.sentimientoPerfectoDeTipoDeRespuesta)
				{
					foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair36 in keyValuePair35.Value)
					{
						if (keyValuePair36.Value != null)
						{
							Object.Destroy(keyValuePair36.Value);
						}
					}
				}
				foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair37 in this.peticionesPersonalesPositivasDeTipoDeRespuesta)
				{
					if (keyValuePair37.Value != null)
					{
						Object.Destroy(keyValuePair37.Value);
					}
				}
				foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair38 in this.peticionesPersonalesNegativasDeTipoDeRespuesta)
				{
					if (keyValuePair38.Value != null)
					{
						Object.Destroy(keyValuePair38.Value);
					}
				}
				foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair39 in this.peticionesPresentesPositivasDeTipoDeRespuesta)
				{
					if (keyValuePair39.Value != null)
					{
						Object.Destroy(keyValuePair39.Value);
					}
				}
				foreach (KeyValuePair<int, ListaDeDialogos> keyValuePair40 in this.peticionesPresentesNegativasDeTipoDeRespuesta)
				{
					if (keyValuePair40.Value != null)
					{
						Object.Destroy(keyValuePair40.Value);
					}
				}
				this.peticionesSerConjugadoDeTipoDeRespuesta = null;
				this.tipoDeRespuestaDeTipoDePalabras = null;
				this.accionesDeTipoDeRespuesta = null;
				this.acciones3PersonaDeTipoDeRespuesta = null;
				this.acciones3PersonaPluralDeTipoDeRespuesta = null;
				this.accionesConjugadasDeTipoDeRespuesta = null;
				this.accionesPluralesDeTipoDeRespuesta = null;
				this.accionesPresentesDeTipoDeRespuesta = null;
				this.accionesPasadoDeTipoDeRespuesta = null;
				this.emocionesPersonalesDeTipoDeRespuesta = null;
				this.emocionesPersonalesPluralesDeTipoDeRespuesta = null;
				this.emocionesPresentesDeTipoDeRespuesta = null;
				this.emocionesTerceraPersonaDeTipoDeRespuesta = null;
				this.emocionesTerceraPersonaPluralesDeTipoDeRespuesta = null;
				this.sentimientoPerfectoDeTipoDeRespuesta = null;
				this.peticionesPersonalesPositivasDeTipoDeRespuesta = null;
				this.peticionesPersonalesNegativasDeTipoDeRespuesta = null;
				this.peticionesPresentesPositivasDeTipoDeRespuesta = null;
				this.peticionesPresentesNegativasDeTipoDeRespuesta = null;
			}

			// Token: 0x040009D4 RID: 2516
			public DiccionaryEnum<TipoDePalabraGenerica, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> tipoDeRespuestaDeTipoDePalabras = new DiccionaryEnum<TipoDePalabraGenerica, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((TipoDePalabraGenerica x) => (int)x);

			// Token: 0x040009D5 RID: 2517
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> accionesDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009D6 RID: 2518
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> acciones3PersonaDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009D7 RID: 2519
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> acciones3PersonaPluralDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009D8 RID: 2520
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> accionesConjugadasDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009D9 RID: 2521
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> accionesPluralesDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009DA RID: 2522
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> accionesPresentesDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009DB RID: 2523
			public Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> accionesPasadoDeTipoDeRespuesta = new Dictionary<ValueTuple<int, int, int, int>, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009DC RID: 2524
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> emocionesPersonalesDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009DD RID: 2525
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> emocionesPersonalesPluralesDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009DE RID: 2526
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> emocionesPresentesDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009DF RID: 2527
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> emocionesTerceraPersonaDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009E0 RID: 2528
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> emocionesTerceraPersonaPluralesDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009E1 RID: 2529
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> peticionesSerConjugadoDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009E2 RID: 2530
			public DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> sentimientoPerfectoDeTipoDeRespuesta = new DiccionaryEnum<ReaccionHumana, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>((ReaccionHumana x) => (int)x);

			// Token: 0x040009E3 RID: 2531
			public DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> peticionesPersonalesPositivasDeTipoDeRespuesta = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);

			// Token: 0x040009E4 RID: 2532
			public DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> peticionesPersonalesNegativasDeTipoDeRespuesta = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);

			// Token: 0x040009E5 RID: 2533
			public DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> peticionesPresentesPositivasDeTipoDeRespuesta = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);

			// Token: 0x040009E6 RID: 2534
			public DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos> peticionesPresentesNegativasDeTipoDeRespuesta = new DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>((Personalidad.TipoDeRespuestaDeDialogoDeHeroina x) => (int)x);

			// Token: 0x040009E7 RID: 2535
			public Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> intensidadAdverbio = new Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();

			// Token: 0x040009E8 RID: 2536
			public Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>> intensidadAdjetivo = new Dictionary<int, DiccionaryEnum<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, ListaDeDialogos>>();
		}

		// Token: 0x02000216 RID: 534
		[Serializable]
		public class DialogosMapas
		{
			// Token: 0x040009F6 RID: 2550
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> prefijos = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x040009F7 RID: 2551
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> sufijos = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x040009F8 RID: 2552
			public PalabrasDeDialogosGenericos.DialogosMapas.DialogosPositivosYNegativos peticionesPersonales = new PalabrasDeDialogosGenericos.DialogosMapas.DialogosPositivosYNegativos();

			// Token: 0x040009F9 RID: 2553
			public PalabrasDeDialogosGenericos.DialogosMapas.DialogosPositivosYNegativos peticionesPresente = new PalabrasDeDialogosGenericos.DialogosMapas.DialogosPositivosYNegativos();

			// Token: 0x040009FA RID: 2554
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones acciones = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x040009FB RID: 2555
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones acciones3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x040009FC RID: 2556
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones acciones3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x040009FD RID: 2557
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones accionesConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x040009FE RID: 2558
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones accionesPlurales = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x040009FF RID: 2559
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones accionesPresente = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x04000A00 RID: 2560
			public PalabrasDeDialogosGenericos.DialogosMapas.Acciones accionesPasado = new PalabrasDeDialogosGenericos.DialogosMapas.Acciones();

			// Token: 0x04000A01 RID: 2561
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactiles = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A02 RID: 2562
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactiles3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A03 RID: 2563
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactiles3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A04 RID: 2564
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactilesConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A05 RID: 2565
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactilesPlurales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A06 RID: 2566
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactilesPresente = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A07 RID: 2567
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles accionesTactilesPasado = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles();

			// Token: 0x04000A08 RID: 2568
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobre = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A09 RID: 2569
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobre3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0A RID: 2570
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobre3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0B RID: 2571
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobreConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0C RID: 2572
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobrePlurales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0D RID: 2573
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobrePresente = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0E RID: 2574
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesSobrePasado = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A0F RID: 2575
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentro = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A10 RID: 2576
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentro3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A11 RID: 2577
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentro3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A12 RID: 2578
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentroConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A13 RID: 2579
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentroPlurales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A14 RID: 2580
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentroPresente = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A15 RID: 2581
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes accionesTactilesDerramantesDentroPasado = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes();

			// Token: 0x04000A16 RID: 2582
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConTool = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A17 RID: 2583
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConTool3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A18 RID: 2584
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConTool3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A19 RID: 2585
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConToolConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A1A RID: 2586
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConToolPlurales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A1B RID: 2587
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConToolPresente = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A1C RID: 2588
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas accionesCoitalesConToolPasado = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas();

			// Token: 0x04000A1D RID: 2589
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisuales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A1E RID: 2590
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisuales3Persona = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A1F RID: 2591
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisuales3PersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A20 RID: 2592
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisualesConjugadas = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A21 RID: 2593
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisualesPlurales = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A22 RID: 2594
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisualesPresente = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A23 RID: 2595
			public PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales accionesVisualesPasado = new PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales();

			// Token: 0x04000A24 RID: 2596
			public PalabrasDeDialogosGenericos.DialogosMapas.PeticionesSer peticionesSerConjugado = new PalabrasDeDialogosGenericos.DialogosMapas.PeticionesSer();

			// Token: 0x04000A25 RID: 2597
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones emocionesPersonales = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A26 RID: 2598
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones emocionesPersonalesPlural = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A27 RID: 2599
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones emocionesPresente = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A28 RID: 2600
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones emocionesTerceraPersona = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A29 RID: 2601
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones emocionesTerceraPersonaPlural = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A2A RID: 2602
			public PalabrasDeDialogosGenericos.DialogosMapas.Emociones sentimientosPerfectos = new PalabrasDeDialogosGenericos.DialogosMapas.Emociones();

			// Token: 0x04000A2B RID: 2603
			public PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas intensidadAdverbio = new PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas();

			// Token: 0x04000A2C RID: 2604
			public PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas intensidadAdjetivo = new PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas();

			// Token: 0x04000A2D RID: 2605
			public List<PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar> intensidadAdverbios = new List<PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar>();

			// Token: 0x04000A2E RID: 2606
			public List<PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar> intensidadAdjetivos = new List<PalabrasDeDialogosGenericos.DialogosMapas.BajasAltasPar>();

			// Token: 0x04000A2F RID: 2607
			public PalabrasDeDialogosGenericos.DialogosMapas.Pronombres pronombres = new PalabrasDeDialogosGenericos.DialogosMapas.Pronombres();

			// Token: 0x04000A30 RID: 2608
			public PalabrasDeDialogosGenericos.DialogosMapas.Articulos articulos = new PalabrasDeDialogosGenericos.DialogosMapas.Articulos();

			// Token: 0x04000A31 RID: 2609
			public PalabrasDeDialogosGenericos.DialogosMapas.En en = new PalabrasDeDialogosGenericos.DialogosMapas.En();

			// Token: 0x04000A32 RID: 2610
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> hacerConjugado = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A33 RID: 2611
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> hacerPlural = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A34 RID: 2612
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> haciendo = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A35 RID: 2613
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> eso = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A36 RID: 2614
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> esoEs = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A37 RID: 2615
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> esoEsta = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A38 RID: 2616
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> con = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A39 RID: 2617
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> deEstar = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3A RID: 2618
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> queEstes = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3B RID: 2619
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> esoCosa = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3C RID: 2620
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> esoCosaPlural = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3D RID: 2621
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> esto = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3E RID: 2622
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> cuando = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A3F RID: 2623
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> muy = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A40 RID: 2624
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> muymuy = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A41 RID: 2625
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> ponerPerfecto = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A42 RID: 2626
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> tomarPerfecto = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A43 RID: 2627
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> voltearPerfecto = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A44 RID: 2628
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> lejos = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A45 RID: 2629
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> desde = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A46 RID: 2630
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> de = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A47 RID: 2631
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> off = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A48 RID: 2632
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> why = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A49 RID: 2633
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> stop = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A4A RID: 2634
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> hacerPasado = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A4B RID: 2635
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> again = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A4C RID: 2636
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> just = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A4D RID: 2637
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> exclamacionPlacer = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x04000A4E RID: 2638
			[CoolArrayItem]
			public List<DialogosLocalizadosDeTipoDeRespuesta> empty = new List<DialogosLocalizadosDeTipoDeRespuesta>();

			// Token: 0x02000217 RID: 535
			[Serializable]
			public class En
			{
				// Token: 0x04000A4F RID: 2639
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> enDentro = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A50 RID: 2640
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> enSobre = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A51 RID: 2641
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> enUbicacion = new List<DialogosLocalizadosDeTipoDeRespuesta>();
			}

			// Token: 0x02000218 RID: 536
			[Serializable]
			public class Articulos
			{
				// Token: 0x04000A52 RID: 2642
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> el = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A53 RID: 2643
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> la = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A54 RID: 2644
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> los = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A55 RID: 2645
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> las = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A56 RID: 2646
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> a = new List<DialogosLocalizadosDeTipoDeRespuesta>();
			}

			// Token: 0x02000219 RID: 537
			[Serializable]
			public class DialogosPositivosYNegativos
			{
				// Token: 0x04000A57 RID: 2647
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> negativos = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A58 RID: 2648
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> positivos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
			}

			// Token: 0x0200021A RID: 538
			[Serializable]
			public class Pronombres
			{
				// Token: 0x04000A59 RID: 2649
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> yo = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5A RID: 2650
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> yoEstoy = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5B RID: 2651
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> yoMismo = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5C RID: 2652
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> porYoMismo = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5D RID: 2653
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> tu = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5E RID: 2654
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> mi = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A5F RID: 2655
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> miPlural = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A60 RID: 2656
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> estas = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A61 RID: 2657
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> esta = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A62 RID: 2658
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> me = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A63 RID: 2659
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> tuyo = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A64 RID: 2660
				[CoolArrayItem]
				public List<DialogosLocalizadosDeTipoDeRespuesta> tuyoPlural = new List<DialogosLocalizadosDeTipoDeRespuesta>();
			}

			// Token: 0x0200021B RID: 539
			public interface IParAcciones
			{
				// Token: 0x1700029D RID: 669
				// (get) Token: 0x06000C63 RID: 3171
				TipoDeEstimulo tipoDeEstimulo { get; }

				// Token: 0x1700029E RID: 670
				// (get) Token: 0x06000C64 RID: 3172
				DireccionDeEstimuloFlags direccionDeEstimuloV2 { get; }

				// Token: 0x1700029F RID: 671
				// (get) Token: 0x06000C65 RID: 3173
				PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes { get; }

				// Token: 0x170002A0 RID: 672
				// (get) Token: 0x06000C66 RID: 3174
				IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> dialogos { get; }

				// Token: 0x170002A1 RID: 673
				// (get) Token: 0x06000C67 RID: 3175
				int tipoDeEstimuloEspecificoInt { get; }
			}

			// Token: 0x0200021C RID: 540
			public interface IParAccionesEspecificas<TEnum> : PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones where TEnum : Enum
			{
				// Token: 0x170002A2 RID: 674
				// (get) Token: 0x06000C68 RID: 3176
				TEnum tipoDeEstimuloEspecifico { get; }
			}

			// Token: 0x0200021D RID: 541
			[Serializable]
			public class Acciones
			{
				// Token: 0x04000A65 RID: 2661
				public List<PalabrasDeDialogosGenericos.DialogosMapas.Acciones.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.Acciones.Par>();

				// Token: 0x0200021E RID: 542
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002A3 RID: 675
					// (get) Token: 0x06000C6A RID: 3178 RVA: 0x0003A76A File Offset: 0x0003896A
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return this.tipoDeEstimulo;
						}
					}

					// Token: 0x170002A4 RID: 676
					// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0003A772 File Offset: 0x00038972
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002A5 RID: 677
					// (get) Token: 0x06000C6C RID: 3180 RVA: 0x0003A77A File Offset: 0x0003897A
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002A6 RID: 678
					// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0003A782 File Offset: 0x00038982
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002A7 RID: 679
					// (get) Token: 0x06000C6E RID: 3182 RVA: 0x00004252 File Offset: 0x00002452
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return 0;
						}
					}

					// Token: 0x04000A66 RID: 2662
					public TipoDeEstimulo tipoDeEstimulo;

					// Token: 0x04000A67 RID: 2663
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A68 RID: 2664
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A69 RID: 2665
					[CoolArrayItem]
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x0200021F RID: 543
			[Serializable]
			public class AccionesTactilesDerramantes
			{
				// Token: 0x04000A6A RID: 2666
				public List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactilesDerramantes.Par>();

				// Token: 0x02000220 RID: 544
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactilDerramante>, PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002A8 RID: 680
					// (get) Token: 0x06000C71 RID: 3185 RVA: 0x0003A7BE File Offset: 0x000389BE
					TipoDeEstimuloTactilDerramante PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactilDerramante>.tipoDeEstimuloEspecifico
					{
						get
						{
							return this.tipoDeDerramamiento;
						}
					}

					// Token: 0x170002A9 RID: 681
					// (get) Token: 0x06000C72 RID: 3186 RVA: 0x00005F51 File Offset: 0x00004151
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return TipoDeEstimulo.tactil;
						}
					}

					// Token: 0x170002AA RID: 682
					// (get) Token: 0x06000C73 RID: 3187 RVA: 0x0003A7C6 File Offset: 0x000389C6
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002AB RID: 683
					// (get) Token: 0x06000C74 RID: 3188 RVA: 0x0003A7CE File Offset: 0x000389CE
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002AC RID: 684
					// (get) Token: 0x06000C75 RID: 3189 RVA: 0x0003A7D6 File Offset: 0x000389D6
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002AD RID: 685
					// (get) Token: 0x06000C76 RID: 3190 RVA: 0x0003A7BE File Offset: 0x000389BE
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return (int)this.tipoDeDerramamiento;
						}
					}

					// Token: 0x04000A6B RID: 2667
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A6C RID: 2668
					public TipoDeEstimuloTactilDerramante tipoDeDerramamiento;

					// Token: 0x04000A6D RID: 2669
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A6E RID: 2670
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x02000221 RID: 545
			[Serializable]
			public class AccionesTactiles
			{
				// Token: 0x04000A6F RID: 2671
				public List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles.Par>();

				// Token: 0x04000A70 RID: 2672
				public List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles.ParInvertido> dialogosDeAccionesInvertidas = new List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesTactiles.ParInvertido>();

				// Token: 0x02000222 RID: 546
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactil>, PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002AE RID: 686
					// (get) Token: 0x06000C79 RID: 3193 RVA: 0x0003A81D File Offset: 0x00038A1D
					TipoDeEstimuloTactil PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactil>.tipoDeEstimuloEspecifico
					{
						get
						{
							return this.tipoDeEstimuloTactil;
						}
					}

					// Token: 0x170002AF RID: 687
					// (get) Token: 0x06000C7A RID: 3194 RVA: 0x00005F51 File Offset: 0x00004151
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return TipoDeEstimulo.tactil;
						}
					}

					// Token: 0x170002B0 RID: 688
					// (get) Token: 0x06000C7B RID: 3195 RVA: 0x0003A825 File Offset: 0x00038A25
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002B1 RID: 689
					// (get) Token: 0x06000C7C RID: 3196 RVA: 0x0003A82D File Offset: 0x00038A2D
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002B2 RID: 690
					// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0003A835 File Offset: 0x00038A35
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002B3 RID: 691
					// (get) Token: 0x06000C7E RID: 3198 RVA: 0x0003A81D File Offset: 0x00038A1D
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return (int)this.tipoDeEstimuloTactil;
						}
					}

					// Token: 0x04000A71 RID: 2673
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A72 RID: 2674
					public TipoDeEstimuloTactil tipoDeEstimuloTactil;

					// Token: 0x04000A73 RID: 2675
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A74 RID: 2676
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}

				// Token: 0x02000223 RID: 547
				[Serializable]
				public class ParInvertido : PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactilInvertido>, PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002B4 RID: 692
					// (get) Token: 0x06000C80 RID: 3200 RVA: 0x0003A85E File Offset: 0x00038A5E
					TipoDeEstimuloTactilInvertido PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloTactilInvertido>.tipoDeEstimuloEspecifico
					{
						get
						{
							return this.tipoDeEstimuloTactil;
						}
					}

					// Token: 0x170002B5 RID: 693
					// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00005F51 File Offset: 0x00004151
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return TipoDeEstimulo.tactil;
						}
					}

					// Token: 0x170002B6 RID: 694
					// (get) Token: 0x06000C82 RID: 3202 RVA: 0x0003A866 File Offset: 0x00038A66
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002B7 RID: 695
					// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0003A86E File Offset: 0x00038A6E
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002B8 RID: 696
					// (get) Token: 0x06000C84 RID: 3204 RVA: 0x0003A876 File Offset: 0x00038A76
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002B9 RID: 697
					// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0003A85E File Offset: 0x00038A5E
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return (int)this.tipoDeEstimuloTactil;
						}
					}

					// Token: 0x04000A75 RID: 2677
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A76 RID: 2678
					public TipoDeEstimuloTactilInvertido tipoDeEstimuloTactil;

					// Token: 0x04000A77 RID: 2679
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A78 RID: 2680
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x02000224 RID: 548
			[Serializable]
			public class AccionesVisuales
			{
				// Token: 0x04000A79 RID: 2681
				public List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesVisuales.Par>();

				// Token: 0x02000225 RID: 549
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloVisual>, PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002BA RID: 698
					// (get) Token: 0x06000C88 RID: 3208 RVA: 0x0003A8B2 File Offset: 0x00038AB2
					TipoDeEstimuloVisual PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloVisual>.tipoDeEstimuloEspecifico
					{
						get
						{
							return this.tipoDeEstimuloVisual;
						}
					}

					// Token: 0x170002BB RID: 699
					// (get) Token: 0x06000C89 RID: 3209 RVA: 0x0000D704 File Offset: 0x0000B904
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return TipoDeEstimulo.visual;
						}
					}

					// Token: 0x170002BC RID: 700
					// (get) Token: 0x06000C8A RID: 3210 RVA: 0x0003A8BA File Offset: 0x00038ABA
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002BD RID: 701
					// (get) Token: 0x06000C8B RID: 3211 RVA: 0x0003A8C2 File Offset: 0x00038AC2
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002BE RID: 702
					// (get) Token: 0x06000C8C RID: 3212 RVA: 0x0003A8CA File Offset: 0x00038ACA
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002BF RID: 703
					// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0003A8B2 File Offset: 0x00038AB2
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return (int)this.tipoDeEstimuloVisual;
						}
					}

					// Token: 0x04000A7A RID: 2682
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A7B RID: 2683
					public TipoDeEstimuloVisual tipoDeEstimuloVisual;

					// Token: 0x04000A7C RID: 2684
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A7D RID: 2685
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x02000226 RID: 550
			[Serializable]
			public class AccionesCoitalesConHerramientas
			{
				// Token: 0x04000A7E RID: 2686
				public List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.AccionesCoitalesConHerramientas.Par>();

				// Token: 0x02000227 RID: 551
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloCoitalConPenes>, PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones
				{
					// Token: 0x170002C0 RID: 704
					// (get) Token: 0x06000C90 RID: 3216 RVA: 0x0003A906 File Offset: 0x00038B06
					TipoDeEstimuloCoitalConPenes PalabrasDeDialogosGenericos.DialogosMapas.IParAccionesEspecificas<TipoDeEstimuloCoitalConPenes>.tipoDeEstimuloEspecifico
					{
						get
						{
							return this.tipo;
						}
					}

					// Token: 0x170002C1 RID: 705
					// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00005F51 File Offset: 0x00004151
					TipoDeEstimulo PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimulo
					{
						get
						{
							return TipoDeEstimulo.tactil;
						}
					}

					// Token: 0x170002C2 RID: 706
					// (get) Token: 0x06000C92 RID: 3218 RVA: 0x0003A90E File Offset: 0x00038B0E
					DireccionDeEstimuloFlags PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.direccionDeEstimuloV2
					{
						get
						{
							return this.direccionDeEstimuloV2;
						}
					}

					// Token: 0x170002C3 RID: 707
					// (get) Token: 0x06000C93 RID: 3219 RVA: 0x0003A916 File Offset: 0x00038B16
					PalabrasDeDialogosGenericos.CompatibilidadConPartes PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.CompatibilidadConPartes
					{
						get
						{
							return this.CompatibilidadConPartes;
						}
					}

					// Token: 0x170002C4 RID: 708
					// (get) Token: 0x06000C94 RID: 3220 RVA: 0x0003A91E File Offset: 0x00038B1E
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x170002C5 RID: 709
					// (get) Token: 0x06000C95 RID: 3221 RVA: 0x0003A906 File Offset: 0x00038B06
					int PalabrasDeDialogosGenericos.DialogosMapas.IParAcciones.tipoDeEstimuloEspecificoInt
					{
						get
						{
							return (int)this.tipo;
						}
					}

					// Token: 0x04000A7F RID: 2687
					public DireccionDeEstimuloFlags direccionDeEstimuloV2 = (DireccionDeEstimuloFlags)(-1);

					// Token: 0x04000A80 RID: 2688
					public TipoDeEstimuloCoitalConPenes tipo;

					// Token: 0x04000A81 RID: 2689
					public PalabrasDeDialogosGenericos.CompatibilidadConPartes CompatibilidadConPartes = (PalabrasDeDialogosGenericos.CompatibilidadConPartes)(-1);

					// Token: 0x04000A82 RID: 2690
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x02000228 RID: 552
			[Serializable]
			public class PeticionesSer : PalabrasDeDialogosGenericos.IParesEmocionales
			{
				// Token: 0x170002C6 RID: 710
				// (get) Token: 0x06000C97 RID: 3223 RVA: 0x0003A947 File Offset: 0x00038B47
				IReadOnlyList<PalabrasDeDialogosGenericos.IParEmocional> PalabrasDeDialogosGenericos.IParesEmocionales.pares
				{
					get
					{
						return this.dialogos;
					}
				}

				// Token: 0x04000A83 RID: 2691
				[CoolArrayItem]
				public List<PalabrasDeDialogosGenericos.DialogosMapas.PeticionesSer.Par> dialogos = new List<PalabrasDeDialogosGenericos.DialogosMapas.PeticionesSer.Par>();

				// Token: 0x02000229 RID: 553
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.IParEmocional
				{
					// Token: 0x170002C7 RID: 711
					// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0003A962 File Offset: 0x00038B62
					ReaccionHumana PalabrasDeDialogosGenericos.IParEmocional.tipo
					{
						get
						{
							return this.tipo;
						}
					}

					// Token: 0x170002C8 RID: 712
					// (get) Token: 0x06000C9A RID: 3226 RVA: 0x0003A96A File Offset: 0x00038B6A
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.IParEmocional.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x04000A84 RID: 2692
					public ReaccionHumana tipo;

					// Token: 0x04000A85 RID: 2693
					[CoolArrayItem]
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x0200022A RID: 554
			[Serializable]
			public class Emociones : PalabrasDeDialogosGenericos.IParesEmocionales
			{
				// Token: 0x170002C9 RID: 713
				// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0003A985 File Offset: 0x00038B85
				IReadOnlyList<PalabrasDeDialogosGenericos.IParEmocional> PalabrasDeDialogosGenericos.IParesEmocionales.pares
				{
					get
					{
						return this.dialogosDeAcciones;
					}
				}

				// Token: 0x04000A86 RID: 2694
				[CoolArrayItem]
				public List<PalabrasDeDialogosGenericos.DialogosMapas.Emociones.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.DialogosMapas.Emociones.Par>();

				// Token: 0x0200022B RID: 555
				[Serializable]
				public class Par : PalabrasDeDialogosGenericos.IParEmocional
				{
					// Token: 0x170002CA RID: 714
					// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0003A9A0 File Offset: 0x00038BA0
					ReaccionHumana PalabrasDeDialogosGenericos.IParEmocional.tipo
					{
						get
						{
							return this.tipo;
						}
					}

					// Token: 0x170002CB RID: 715
					// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0003A9A8 File Offset: 0x00038BA8
					IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> PalabrasDeDialogosGenericos.IParEmocional.dialogos
					{
						get
						{
							return this.dialogos;
						}
					}

					// Token: 0x04000A87 RID: 2695
					public ReaccionHumana tipo;

					// Token: 0x04000A88 RID: 2696
					[CoolArrayItem]
					public List<DialogosLocalizadosDeTipoDeRespuesta> dialogos = new List<DialogosLocalizadosDeTipoDeRespuesta>();
				}
			}

			// Token: 0x0200022C RID: 556
			[Serializable]
			public class BajasAltasPar
			{
				// Token: 0x04000A89 RID: 2697
				public TipoDeIntensidad intensidad;

				// Token: 0x04000A8A RID: 2698
				public PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas listas = new PalabrasDeDialogosGenericos.DialogosMapas.BajasAltas();
			}

			// Token: 0x0200022D RID: 557
			[Serializable]
			public class BajasAltas
			{
				// Token: 0x04000A8B RID: 2699
				public List<DialogosLocalizadosDeTipoDeRespuesta> baja = new List<DialogosLocalizadosDeTipoDeRespuesta>();

				// Token: 0x04000A8C RID: 2700
				public List<DialogosLocalizadosDeTipoDeRespuesta> alta = new List<DialogosLocalizadosDeTipoDeRespuesta>();
			}
		}

		// Token: 0x0200022E RID: 558
		private interface IParEmocional
		{
			// Token: 0x170002CC RID: 716
			// (get) Token: 0x06000CA3 RID: 3235
			ReaccionHumana tipo { get; }

			// Token: 0x170002CD RID: 717
			// (get) Token: 0x06000CA4 RID: 3236
			IReadOnlyList<DialogosLocalizadosDeTipoDeRespuesta> dialogos { get; }
		}

		// Token: 0x0200022F RID: 559
		private interface IParesEmocionales
		{
			// Token: 0x170002CE RID: 718
			// (get) Token: 0x06000CA5 RID: 3237
			IReadOnlyList<PalabrasDeDialogosGenericos.IParEmocional> pares { get; }
		}

		// Token: 0x02000230 RID: 560
		[Serializable]
		public class Dialogos
		{
			// Token: 0x04000A8D RID: 2701
			[CoolArrayItem]
			public List<DialogoInfo> prefijos = new List<DialogoInfo>();

			// Token: 0x04000A8E RID: 2702
			public PalabrasDeDialogosGenericos.Dialogos.DialogosPositivosYNegativos peticionresPersonales = new PalabrasDeDialogosGenericos.Dialogos.DialogosPositivosYNegativos();

			// Token: 0x04000A8F RID: 2703
			public PalabrasDeDialogosGenericos.Dialogos.DialogosPositivosYNegativos peticionesPresente = new PalabrasDeDialogosGenericos.Dialogos.DialogosPositivosYNegativos();

			// Token: 0x04000A90 RID: 2704
			public PalabrasDeDialogosGenericos.Dialogos.Acciones accionesPersonales = new PalabrasDeDialogosGenericos.Dialogos.Acciones();

			// Token: 0x04000A91 RID: 2705
			public PalabrasDeDialogosGenericos.Dialogos.Acciones accionesPresente = new PalabrasDeDialogosGenericos.Dialogos.Acciones();

			// Token: 0x04000A92 RID: 2706
			public PalabrasDeDialogosGenericos.Dialogos.Pronombres pronombres = new PalabrasDeDialogosGenericos.Dialogos.Pronombres();

			// Token: 0x04000A93 RID: 2707
			[CoolArrayItem]
			public List<DialogoInfo> sufijos = new List<DialogoInfo>();

			// Token: 0x02000231 RID: 561
			[Serializable]
			public class DialogosPositivosYNegativos
			{
				// Token: 0x04000A94 RID: 2708
				[CoolArrayItem]
				public List<DialogoInfo> negativos = new List<DialogoInfo>();

				// Token: 0x04000A95 RID: 2709
				[CoolArrayItem]
				public List<DialogoInfo> positivos = new List<DialogoInfo>();
			}

			// Token: 0x02000232 RID: 562
			[Serializable]
			public class Pronombres
			{
				// Token: 0x04000A96 RID: 2710
				[CoolArrayItem]
				public List<DialogoInfo> mi = new List<DialogoInfo>();

				// Token: 0x04000A97 RID: 2711
				[CoolArrayItem]
				public List<DialogoInfo> miPlural = new List<DialogoInfo>();

				// Token: 0x04000A98 RID: 2712
				[CoolArrayItem]
				public List<DialogoInfo> eso = new List<DialogoInfo>();

				// Token: 0x04000A99 RID: 2713
				[CoolArrayItem]
				public List<DialogoInfo> estas = new List<DialogoInfo>();

				// Token: 0x04000A9A RID: 2714
				[CoolArrayItem]
				public List<DialogoInfo> me = new List<DialogoInfo>();

				// Token: 0x04000A9B RID: 2715
				[CoolArrayItem]
				public List<DialogoInfo> tuyo = new List<DialogoInfo>();

				// Token: 0x04000A9C RID: 2716
				[CoolArrayItem]
				public List<DialogoInfo> con = new List<DialogoInfo>();
			}

			// Token: 0x02000233 RID: 563
			[Serializable]
			public class Acciones
			{
				// Token: 0x04000A9D RID: 2717
				[CoolArrayItem]
				public List<PalabrasDeDialogosGenericos.Dialogos.Acciones.Par> dialogosDeAcciones = new List<PalabrasDeDialogosGenericos.Dialogos.Acciones.Par>();

				// Token: 0x02000234 RID: 564
				[Serializable]
				public class Par
				{
					// Token: 0x04000A9E RID: 2718
					public TipoDeEstimulo tipo;

					// Token: 0x04000A9F RID: 2719
					[CoolArrayItem]
					public List<DialogoInfo> dialogos = new List<DialogoInfo>();
				}
			}
		}
	}
}

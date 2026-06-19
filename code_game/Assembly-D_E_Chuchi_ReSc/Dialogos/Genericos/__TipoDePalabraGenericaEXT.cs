using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos
{
	// Token: 0x02000207 RID: 519
	public static class __TipoDePalabraGenericaEXT
	{
		// Token: 0x06000BE9 RID: 3049 RVA: 0x00035490 File Offset: 0x00033690
		public static bool TipoDePalabraDeTipoEsAccion(this TipoDePalabraGenerica tipoDePalabraGenerica)
		{
			switch (tipoDePalabraGenerica)
			{
			case TipoDePalabraGenerica.None:
			case TipoDePalabraGenerica.prefijo:
			case TipoDePalabraGenerica.sufijo:
			case TipoDePalabraGenerica.peticionPersonal:
			case TipoDePalabraGenerica.peticionPresente:
			case TipoDePalabraGenerica.emocionPersonal:
			case TipoDePalabraGenerica.emocionPresente:
			case TipoDePalabraGenerica.mi:
			case TipoDePalabraGenerica.eso:
			case TipoDePalabraGenerica.esoEsta:
			case TipoDePalabraGenerica.esoEs:
			case TipoDePalabraGenerica.estas:
			case TipoDePalabraGenerica.me:
			case TipoDePalabraGenerica.tuyo:
			case TipoDePalabraGenerica.tuyoPlural:
			case TipoDePalabraGenerica.con:
			case TipoDePalabraGenerica.miPlural:
			case TipoDePalabraGenerica.cosaPropia:
			case TipoDePalabraGenerica.cosaOther:
			case TipoDePalabraGenerica.hacerConjugado:
			case TipoDePalabraGenerica.haciendo:
			case TipoDePalabraGenerica.deEstar:
			case TipoDePalabraGenerica.queEstes:
			case TipoDePalabraGenerica.sentimientoPerfecto:
			case TipoDePalabraGenerica.esoCosa:
			case TipoDePalabraGenerica.cuando:
			case TipoDePalabraGenerica.tu:
			case TipoDePalabraGenerica.yo:
			case TipoDePalabraGenerica.ponerPerfecto:
			case TipoDePalabraGenerica.tomarPerfecto:
			case TipoDePalabraGenerica.voltearPerfecto:
			case TipoDePalabraGenerica.lejos:
			case TipoDePalabraGenerica.desde:
			case TipoDePalabraGenerica.de:
			case TipoDePalabraGenerica.off:
			case TipoDePalabraGenerica.why:
			case TipoDePalabraGenerica.stop:
			case TipoDePalabraGenerica.hacerPasado:
			case TipoDePalabraGenerica.again:
			case TipoDePalabraGenerica.hacerPlural:
			case TipoDePalabraGenerica.just:
			case TipoDePalabraGenerica.peticionSerConjugado:
			case TipoDePalabraGenerica.muy:
			case TipoDePalabraGenerica.intensidadAdverbio:
			case TipoDePalabraGenerica.intensidadAdjetivo:
			case TipoDePalabraGenerica.el:
			case TipoDePalabraGenerica.la:
			case TipoDePalabraGenerica.los:
			case TipoDePalabraGenerica.las:
			case TipoDePalabraGenerica.muymuy:
			case TipoDePalabraGenerica.exclamacionPlacer:
			case TipoDePalabraGenerica.enDentro:
			case TipoDePalabraGenerica.enSobre:
			case TipoDePalabraGenerica.enUbicacion:
			case TipoDePalabraGenerica.enAccionAuto:
			case TipoDePalabraGenerica.enCosaPropiaAuto:
			case TipoDePalabraGenerica.empty:
			case TipoDePalabraGenerica.yoEstoy:
			case TipoDePalabraGenerica.esoCosaPlural:
			case TipoDePalabraGenerica.emocionTerceraPersona:
			case TipoDePalabraGenerica.yoMismo:
			case TipoDePalabraGenerica.esta:
			case TipoDePalabraGenerica.emocionPersonalPlural:
			case TipoDePalabraGenerica.emocionTerceraPersonaPlural:
			case TipoDePalabraGenerica.porYoMismo:
				return false;
			case TipoDePalabraGenerica.accion3Persona:
			case TipoDePalabraGenerica.accion3PersonaPlural:
			case TipoDePalabraGenerica.accionConjugada:
			case TipoDePalabraGenerica.accionPlural:
			case TipoDePalabraGenerica.accionPresente:
			case TipoDePalabraGenerica.accionPasado:
			case TipoDePalabraGenerica.accion:
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipoDePalabraGenerica.ToString());
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x000355DC File Offset: 0x000337DC
		public static TipoDePalabraGenerica TipoDePalabraDeTipoAccion(this TipoDeStringAccion tipoDeStringAccion)
		{
			switch (tipoDeStringAccion)
			{
			case TipoDeStringAccion.nombre:
				return TipoDePalabraGenerica.accion;
			case TipoDeStringAccion._3Persona:
				return TipoDePalabraGenerica.accion3Persona;
			case TipoDeStringAccion._3PersonaPlural:
				return TipoDePalabraGenerica.accion3PersonaPlural;
			case TipoDeStringAccion.conjugada:
				return TipoDePalabraGenerica.accionConjugada;
			case TipoDeStringAccion.plural:
				return TipoDePalabraGenerica.accionPlural;
			case TipoDeStringAccion.presente:
				return TipoDePalabraGenerica.accionPresente;
			case TipoDeStringAccion.pasado:
				return TipoDePalabraGenerica.accionPasado;
			default:
				throw new ArgumentOutOfRangeException(tipoDeStringAccion.ToString());
			}
		}
	}
}

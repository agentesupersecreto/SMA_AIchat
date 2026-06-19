using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000E7 RID: 231
	public sealed class DesblokeoDeAgenciasPorDesvestirPartesPrivadas5Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesPrivadas5Efecto>
	{
		// Token: 0x06000831 RID: 2097 RVA: 0x0002FBC0 File Offset: 0x0002DDC0
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.pezones, ParteQuePuedeEstimularHelper.puedenDesvestir) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, ParteQuePuedeEstimularHelper.puedenDesvestir) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimularHelper.puedenDesvestir) >= 5;
		}
	}
}

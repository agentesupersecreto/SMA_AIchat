using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000E6 RID: 230
	public sealed class DesblokeoDeAgenciasPorDesvestirPartesSemiPrivadas5Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesSemiPrivadas5Efecto>
	{
		// Token: 0x0600082F RID: 2095 RVA: 0x0002FB48 File Offset: 0x0002DD48
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesSemiPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, ParteQuePuedeEstimularHelper.puedenDesvestir) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesSemiPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, ParteQuePuedeEstimularHelper.puedenDesvestir) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorDesvestirPartesSemiPrivadas5Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vientreBajo, ParteQuePuedeEstimularHelper.puedenDesvestir) >= 5;
		}
	}
}

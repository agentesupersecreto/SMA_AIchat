using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000E8 RID: 232
	public sealed class DesblokeoDeAgenciasPorCoital1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1Efecto>
	{
		// Token: 0x06000833 RID: 2099 RVA: 0x0002FC38 File Offset: 0x0002DE38
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimularHelper.puedenPenetrar) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimularHelper.puedenPenetrar) >= 1;
		}
	}
}

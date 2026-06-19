using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000F5 RID: 245
	public sealed class DesblokeoDeAgenciasPorCoital2Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital2Efecto>
	{
		// Token: 0x0600084D RID: 2125 RVA: 0x0003019C File Offset: 0x0002E39C
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital2Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimularHelper.puedenPenetrar) + DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital2Efecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimularHelper.puedenPenetrar) >= 2;
		}
	}
}

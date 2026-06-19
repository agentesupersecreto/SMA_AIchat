using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000F1 RID: 241
	public sealed class DesblokeoDeAgenciasPorCoital1SemiAfricanasEfecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiAfricanasEfecto>
	{
		// Token: 0x06000845 RID: 2117 RVA: 0x0002FF6C File Offset: 0x0002E16C
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiAfricanasEfecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimularHelper.puedenPenetrar) >= 1 && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiAfricanasEfecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "african" }) >= 1;
		}
	}
}

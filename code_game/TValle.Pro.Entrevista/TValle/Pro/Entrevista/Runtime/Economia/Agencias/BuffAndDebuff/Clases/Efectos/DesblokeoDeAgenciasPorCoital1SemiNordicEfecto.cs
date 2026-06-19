using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000F4 RID: 244
	public sealed class DesblokeoDeAgenciasPorCoital1SemiNordicEfecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiNordicEfecto>
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x00030110 File Offset: 0x0002E310
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MemoriaDeIntereaccionesDeCharacter memoriaDeIntereaccionesDeCharacter = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			return !(memoriaDeIntereaccionesDeCharacter == null) && !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiNordicEfecto>.HanSidoInteractuadaCantidad(memoriaDeIntereaccionesDeCharacter, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimularHelper.puedenPenetrar) >= 1 && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorCoital1SemiNordicEfecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "nordic" }) >= 1;
		}
	}
}

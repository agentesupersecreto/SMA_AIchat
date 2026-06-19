using System;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000EA RID: 234
	public sealed class DesblokeoDeAgenciasPorSemiAsiaticas1Efecto : DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiAsiaticas1Efecto>
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x0002FCF0 File Offset: 0x0002DEF0
		protected override bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			MaleCharInterpretacionesMemory maleCharInterpretacionesMemory = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			return !(maleCharInterpretacionesMemory == null) && DesblokeoDeAgenciasEfecto<DesblokeoDeAgenciasPorSemiAsiaticas1Efecto>.HanSidoEntrevistadaCantidad(maleCharInterpretacionesMemory, 0, 1, 2, new string[] { "interpretacionDeRaza", "asian" }) >= 1;
		}
	}
}

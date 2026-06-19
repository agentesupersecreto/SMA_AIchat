using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using RootMotion.Dynamics;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Adders.Estimulos
{
	// Token: 0x0200013F RID: 319
	public class ManoGenericAgarranteToHandsMusclesAdder : ToMusclePuppetAdder<GenericAgarranteObjeto>
	{
		// Token: 0x0600064C RID: 1612 RVA: 0x0002343E File Offset: 0x0002163E
		protected override bool AddToMuscleChecker(Muscle muscle)
		{
			return base.AddToMuscleChecker(muscle) && muscle.grupo == Muscle.GroupCompleto.Hand;
		}
	}
}

using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000DC RID: 220
	public interface IInteraccionesDeCharacterFemenino : IInteraccionesDeCharacter<InteraccionDeCharacterFemenino>, IInteraccionesDeCharacter, IComponentAwakeable
	{
		// Token: 0x06000836 RID: 2102
		bool TryAddInteraction(int id, Interaccion interaccion, TipoDePose invalidas);
	}
}

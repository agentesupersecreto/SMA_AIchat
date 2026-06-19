using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000CF RID: 207
	public interface IByInteraccionEnScenaArg : IDisplayableArgumentoDeEfecto
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600044E RID: 1102
		IIdentifiableBuff buffOnCopy { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600044F RID: 1103
		bool buffIsOutOfContext { get; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000450 RID: 1104
		bool byInteraccionEnScenaBuffIsValid { get; }

		// Token: 0x06000451 RID: 1105
		bool TrySetyInteraccionEnScenaBuffValue(IIdentifiableBuff interaccionEnScenaBuff);
	}
}

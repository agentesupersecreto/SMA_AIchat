using System;
using Assets.TValle.BeachGirl.Runtime;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync
{
	// Token: 0x02000266 RID: 614
	public interface IDecoDeCasilla
	{
		// Token: 0x06000DB6 RID: 3510
		void Decodificar(ref Silaba owner, ref Casilla casilla, int casillaIndex, out TipoDeCasillaPronunciable tipo, out Phoneme phoneme);

		// Token: 0x06000DB7 RID: 3511
		bool CasillaSegundariaEsMuda(ref Casilla segunda, ref Casilla primera);

		// Token: 0x06000DB8 RID: 3512
		bool CasillaPrimariaEsMuda(ref Casilla casilla);
	}
}

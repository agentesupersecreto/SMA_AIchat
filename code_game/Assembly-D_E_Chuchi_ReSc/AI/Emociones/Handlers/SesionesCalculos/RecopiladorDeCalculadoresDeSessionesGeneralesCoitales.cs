using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004B9 RID: 1209
	[Obsolete("NO RECUERDO PARA Q SON", true)]
	public sealed class RecopiladorDeCalculadoresDeSessionesGeneralesCoitales : RecopiladorDeCalculadoresDeSesionesGenerales<TipoDeEstimuloCoital>
	{
		// Token: 0x06001CC1 RID: 7361 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override TipoDeEstimuloCoital Parce(int valor)
		{
			return (TipoDeEstimuloCoital)valor;
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override int Parce(TipoDeEstimuloCoital enumerable)
		{
			return (int)enumerable;
		}
	}
}

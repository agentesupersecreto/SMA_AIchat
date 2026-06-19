using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004BA RID: 1210
	[Obsolete("NO RECUERDO PARA Q SON", true)]
	public sealed class RecopiladorDeCalculadoresDeSessionesGeneralesTactiles : RecopiladorDeCalculadoresDeSesionesGenerales<TipoDeEstimuloTactil>
	{
		// Token: 0x06001CC4 RID: 7364 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override TipoDeEstimuloTactil Parce(int valor)
		{
			return (TipoDeEstimuloTactil)valor;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x0000386D File Offset: 0x00001A6D
		protected override int Parce(TipoDeEstimuloTactil enumerable)
		{
			return (int)enumerable;
		}
	}
}

using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using TValleCustomClases;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector
{
	// Token: 0x020002D5 RID: 725
	public class CoolDownPorTipo : CoolDownPorID<EffectorsController.Tipo>
	{
		// Token: 0x06001273 RID: 4723 RVA: 0x00057B3D File Offset: 0x00055D3D
		public CoolDownPorTipo(Func<float> defaultCooldwonGetter)
			: base(defaultCooldwonGetter)
		{
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x000118D7 File Offset: 0x0000FAD7
		protected override int ConvertirTipoAId(EffectorsController.Tipo tipo)
		{
			return (int)tipo;
		}
	}
}

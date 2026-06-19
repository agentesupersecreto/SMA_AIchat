using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.BeachGirl.Estimulos.Informers
{
	// Token: 0x0200001B RID: 27
	public interface IInformerDeEstimulosUser
	{
		// Token: 0x060000E6 RID: 230
		void RetornarInstancia<T>(T instnace) where T : InteracionEstimulanteBasica;

		// Token: 0x060000E7 RID: 231
		T ProducirInstancia<T>() where T : InteracionEstimulanteBasica;
	}
}

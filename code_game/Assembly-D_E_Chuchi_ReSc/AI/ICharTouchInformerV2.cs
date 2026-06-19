using System;
using Assets.TValle.BeachGirl.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000308 RID: 776
	public interface ICharTouchInformerV2
	{
		// Token: 0x060010F6 RID: 4342
		void EstimulosProducidosPor(ICharacter productor, ICharTouchInformerV2User user, DictionaryDeEstimulosTactiles result);
	}
}

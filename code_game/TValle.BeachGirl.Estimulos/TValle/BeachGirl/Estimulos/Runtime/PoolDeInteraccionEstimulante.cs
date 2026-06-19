using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.TValle.BeachGirl.Estimulos.Runtime
{
	// Token: 0x02000023 RID: 35
	public sealed class PoolDeInteraccionEstimulante<T> : SimplePoolDeClearables<T> where T : InteracionEstimulanteBasica, IClearable, new()
	{
		// Token: 0x060000FC RID: 252 RVA: 0x0000435C File Offset: 0x0000255C
		public override T GetItem()
		{
			T item = base.GetItem();
			item.GenerateNewID();
			return item;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000436F File Offset: 0x0000256F
		public T GetItemDefault()
		{
			return base.GetItem();
		}
	}
}

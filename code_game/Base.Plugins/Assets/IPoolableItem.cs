using System;

namespace Assets
{
	// Token: 0x02000136 RID: 310
	public interface IPoolableItem
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060008CC RID: 2252
		Guid poolOwner { get; }

		// Token: 0x060008CD RID: 2253
		void SetOwner(ref Guid id);

		// Token: 0x060008CE RID: 2254
		bool Compare(ref Guid id);
	}
}

using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000062 RID: 98
	public interface IValuableBuff<T> where T : struct
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001EF RID: 495
		T buffValue { get; }
	}
}

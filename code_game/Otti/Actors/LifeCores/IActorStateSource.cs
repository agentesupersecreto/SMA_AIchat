using System;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A9 RID: 169
	public interface IActorStateSource
	{
		// Token: 0x06000978 RID: 2424
		bool StateExists(string rName);

		// Token: 0x06000979 RID: 2425
		void RemoveState(string rName);

		// Token: 0x0600097A RID: 2426
		int GetStateValue(string rName);

		// Token: 0x0600097B RID: 2427
		void SetStateValue(string rName, int rValue);
	}
}

using System;
using com.ootii.Base;
using com.ootii.Items;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000B1 RID: 177
	public interface IWeaponCore : IItemCore, IItem, IBaseObject, ILifeCore
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060009D2 RID: 2514
		// (set) Token: 0x060009D3 RID: 2515
		bool IsActive { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060009D4 RID: 2516
		bool HasColliders { get; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060009D5 RID: 2517
		float MinRange { get; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060009D6 RID: 2518
		float MaxRange { get; }
	}
}

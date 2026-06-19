using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;

namespace TValle.BeachGirl.Runtime.Colliders
{
	// Token: 0x02000007 RID: 7
	public interface ICreadorDeCollidersParaManosProducer : IComponentStartable
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000013 RID: 19
		CreadorDeCollidersParaManos r { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000014 RID: 20
		CreadorDeCollidersParaManos l { get; }
	}
}

using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000ED RID: 237
	public interface IStepVelocitySaverEmulated : IStepVelocitySaver
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000688 RID: 1672
		Vector3 velocidadEnDeltaTime { get; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000689 RID: 1673
		[Obsolete("algunos objetos solo se mueven cada update y no cada fixed update, lo cual es propenso a generar errores", true)]
		Vector3 velocidadEnFixedDeltaTime { get; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600068A RID: 1674
		Vector3 metrosPorSegundo { get; }
	}
}

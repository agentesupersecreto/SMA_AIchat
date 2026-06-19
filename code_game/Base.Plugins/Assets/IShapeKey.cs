using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016A RID: 362
	public interface IShapeKey
	{
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000ABE RID: 2750
		string nombre { get; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000ABF RID: 2751
		bool polar { get; }

		// Token: 0x06000AC0 RID: 2752
		float GetValor(SkinnedMeshRenderer renderer);

		// Token: 0x06000AC1 RID: 2753
		void SetValor(SkinnedMeshRenderer renderer, float valor);

		// Token: 0x06000AC2 RID: 2754
		bool TryGetValor(SkinnedMeshRenderer renderer, out float valor);

		// Token: 0x06000AC3 RID: 2755
		bool TrySetValor(SkinnedMeshRenderer renderer, float valor);
	}
}

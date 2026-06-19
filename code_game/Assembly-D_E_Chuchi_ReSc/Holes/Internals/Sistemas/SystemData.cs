using System;
using Unity.Collections;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001B2 RID: 434
	internal class SystemData : IDisposable
	{
		// Token: 0x06000A3F RID: 2623 RVA: 0x0002E202 File Offset: 0x0002C402
		public void Init()
		{
			this.fixedDeltaTime = new NativeReference<float>(Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.iterations = new NativeReference<int>(Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.collisionForce = new NativeReference<float>(Allocator.Persistent, NativeArrayOptions.ClearMemory);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x0002E23C File Offset: 0x0002C43C
		public void UpdateData(SistemaLocalDePuntosElasticosDeInternal sistema)
		{
			try
			{
				this.fixedDeltaTime.Value = Time.fixedDeltaTime;
				this.iterations.Value = sistema.configElastic.loops;
				this.collisionForce.Value = sistema.configElastic.collisionForce;
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0002E29C File Offset: 0x0002C49C
		public void Dispose()
		{
			if (this.fixedDeltaTime.IsCreated)
			{
				this.fixedDeltaTime.Dispose();
			}
			if (this.iterations.IsCreated)
			{
				this.iterations.Dispose();
			}
			if (this.collisionForce.IsCreated)
			{
				this.collisionForce.Dispose();
			}
		}

		// Token: 0x04000817 RID: 2071
		public NativeReference<float> fixedDeltaTime;

		// Token: 0x04000818 RID: 2072
		public NativeReference<int> iterations;

		// Token: 0x04000819 RID: 2073
		public NativeReference<float> collisionForce;
	}
}

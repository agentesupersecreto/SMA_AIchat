using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class TestCloneMeshCollider : MonoBehaviour
{
	// Token: 0x06000033 RID: 51 RVA: 0x00005F87 File Offset: 0x00004187
	private void Start()
	{
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00005F8C File Offset: 0x0000418C
	private void Update()
	{
		if (this.source == null || this.target == null)
		{
			return;
		}
		this.stopwatch.Start();
		this.target.sharedMesh = this.source.sharedMesh;
		this.stopwatch.Stop();
		this.duration = this.stopwatch.Elapsed.TotalMilliseconds;
		this.stopwatch.Reset();
	}

	// Token: 0x0400007E RID: 126
	public MeshCollider source;

	// Token: 0x0400007F RID: 127
	public MeshCollider target;

	// Token: 0x04000080 RID: 128
	public double duration;

	// Token: 0x04000081 RID: 129
	private Stopwatch stopwatch = new Stopwatch();
}

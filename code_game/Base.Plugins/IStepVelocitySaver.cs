using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public interface IStepVelocitySaver
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x06000053 RID: 83
	string name { get; }

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000054 RID: 84
	// (set) Token: 0x06000055 RID: 85
	bool enabled { get; set; }

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000056 RID: 86
	bool usaRigidBody { get; }

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000057 RID: 87
	Rigidbody rigid { get; }

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000058 RID: 88
	Transform transform { get; }

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000059 RID: 89
	Vector3 physicsMetrosPorSegundo { get; }

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x0600005A RID: 90
	IMassModifier massModifier { get; }
}

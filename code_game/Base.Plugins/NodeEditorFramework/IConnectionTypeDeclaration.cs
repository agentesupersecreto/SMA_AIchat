using System;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000089 RID: 137
	public interface IConnectionTypeDeclaration
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060003DC RID: 988
		string Identifier { get; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060003DD RID: 989
		Type Type { get; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060003DE RID: 990
		Color Color { get; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060003DF RID: 991
		string InKnobTex { get; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060003E0 RID: 992
		string OutKnobTex { get; }
	}
}

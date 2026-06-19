using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000228 RID: 552
	public interface IViewPortPositionContainer
	{
		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000E35 RID: 3637
		// (set) Token: 0x06000E36 RID: 3638
		Vector2 viewportPosition { get; set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000E37 RID: 3639
		// (set) Token: 0x06000E38 RID: 3640
		Vector2 viewportLookAtPosition { get; set; }
	}
}

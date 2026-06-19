using System;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x0200008A RID: 138
	public class FloatType : IConnectionTypeDeclaration
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x000108D4 File Offset: 0x0000EAD4
		public string Identifier
		{
			get
			{
				return "Float";
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x000108DB File Offset: 0x0000EADB
		public Type Type
		{
			get
			{
				return typeof(float);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x000108E7 File Offset: 0x0000EAE7
		public Color Color
		{
			get
			{
				return Color.cyan;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x000108EE File Offset: 0x0000EAEE
		public string InKnobTex
		{
			get
			{
				return "Textures/In_Knob.png";
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x000108F5 File Offset: 0x0000EAF5
		public string OutKnobTex
		{
			get
			{
				return "Textures/Out_Knob.png";
			}
		}
	}
}

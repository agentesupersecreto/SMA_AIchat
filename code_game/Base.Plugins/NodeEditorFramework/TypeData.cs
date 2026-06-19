using System;
using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x02000088 RID: 136
	public class TypeData
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00010694 File Offset: 0x0000E894
		// (set) Token: 0x060003CF RID: 975 RVA: 0x0001069C File Offset: 0x0000E89C
		public IConnectionTypeDeclaration declaration { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x000106A5 File Offset: 0x0000E8A5
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x000106AD File Offset: 0x0000E8AD
		public Type Type { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x000106B6 File Offset: 0x0000E8B6
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x000106BE File Offset: 0x0000E8BE
		public Color Color { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x000106C7 File Offset: 0x0000E8C7
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x000106CF File Offset: 0x0000E8CF
		public Texture2D InKnobTex { get; private set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x000106D8 File Offset: 0x0000E8D8
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x000106E0 File Offset: 0x0000E8E0
		public Texture2D OutKnobTex { get; private set; }

		// Token: 0x060003D8 RID: 984 RVA: 0x000106EC File Offset: 0x0000E8EC
		internal TypeData(IConnectionTypeDeclaration typeDecl)
		{
			this.declaration = typeDecl;
			this.Type = this.declaration.Type;
			this.Color = this.declaration.Color;
			this.InKnobTex = ResourceManager.GetTintedTexture(this.declaration.InKnobTex, this.Color);
			this.OutKnobTex = ResourceManager.GetTintedTexture(this.declaration.OutKnobTex, this.Color);
			if (this.InKnobTex == null || this.InKnobTex == null)
			{
				throw new UnityException("Invalid textures for default typeData " + this.declaration.Identifier + "!");
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001079C File Offset: 0x0000E99C
		internal TypeData(Type type)
		{
			this.declaration = null;
			this.Type = type;
			this.Color = Color.white;
			this.InKnobTex = ResourceManager.GetTintedTexture("Textures/In_Knob.png", this.Color);
			this.OutKnobTex = ResourceManager.GetTintedTexture("Textures/Out_Knob.png", this.Color);
			if (this.InKnobTex == null || this.InKnobTex == null)
			{
				throw new UnityException("Invalid textures for default typeData " + type.ToString() + "!");
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001082C File Offset: 0x0000EA2C
		internal TypeData()
		{
			this.declaration = null;
			this.Type = typeof(object);
			this.Color = Color.white;
			this.InKnobTex = ResourceManager.LoadTexture("Textures/In_Knob.png");
			this.OutKnobTex = ResourceManager.LoadTexture("Textures/Out_Knob.png");
			if (this.InKnobTex == null || this.InKnobTex == null)
			{
				throw new UnityException("Invalid textures for default typeData!");
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000108A8 File Offset: 0x0000EAA8
		public bool isValid()
		{
			return this.Type != null && this.InKnobTex != null && this.OutKnobTex != null;
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016B RID: 363
	public class ShapeKey : IShapeKey
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x000249A2 File Offset: 0x00022BA2
		public ShapeKey(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new InvalidOperationException();
			}
			this.m_nombre = name;
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x000249CA File Offset: 0x00022BCA
		public string nombre
		{
			get
			{
				return this.m_nombre;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x000249D2 File Offset: 0x00022BD2
		public bool polar
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x000249D8 File Offset: 0x00022BD8
		public float GetValor(SkinnedMeshRenderer renderer)
		{
			float num;
			if (!this.TryGetValor(renderer, out num))
			{
				throw new InvalidOperationException("Shape key Error");
			}
			return num;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x000249FC File Offset: 0x00022BFC
		public void SetValor(SkinnedMeshRenderer renderer, float valor)
		{
			if (!this.TrySetValor(renderer, valor))
			{
				throw new InvalidOperationException("Shape key Error");
			}
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00024A14 File Offset: 0x00022C14
		public bool TryGetValor(SkinnedMeshRenderer renderer, out float valor)
		{
			valor = 0f;
			if (renderer == null)
			{
				return false;
			}
			int index = this.GetIndex(renderer);
			if (index < 0)
			{
				return false;
			}
			valor = renderer.GetBlendShapeWeight(index);
			return true;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00024A4C File Offset: 0x00022C4C
		public bool TrySetValor(SkinnedMeshRenderer renderer, float valor)
		{
			if (renderer == null)
			{
				return false;
			}
			int index = this.GetIndex(renderer);
			if (index < 0)
			{
				return false;
			}
			renderer.SetBlendShapeWeight(index, valor);
			return true;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00024A7C File Offset: 0x00022C7C
		private int GetIndex(SkinnedMeshRenderer renderer)
		{
			if (renderer == null)
			{
				throw new ArgumentNullException("renderer", "renderer null reference.");
			}
			int blendShapeIndex;
			if (!this.m_indexEnRenderer.TryGetValue(renderer, out blendShapeIndex))
			{
				blendShapeIndex = renderer.sharedMesh.GetBlendShapeIndex(this.nombre);
				if (blendShapeIndex < 0)
				{
					return -1;
				}
				this.m_indexEnRenderer.Add(renderer, blendShapeIndex);
			}
			return blendShapeIndex;
		}

		// Token: 0x0400035D RID: 861
		private string m_nombre;

		// Token: 0x0400035E RID: 862
		private Dictionary<SkinnedMeshRenderer, int> m_indexEnRenderer = new Dictionary<SkinnedMeshRenderer, int>();
	}
}

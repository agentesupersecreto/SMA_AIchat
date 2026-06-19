using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200016C RID: 364
	public class ShapeKeyPolarizada : IShapeKey
	{
		// Token: 0x06000ACC RID: 2764 RVA: 0x00024AD8 File Offset: 0x00022CD8
		public ShapeKeyPolarizada(string positiveName, string negativeName)
		{
			if (string.IsNullOrEmpty(positiveName))
			{
				throw new InvalidOperationException();
			}
			this.m_positiveNombre = positiveName;
			if (string.IsNullOrEmpty(negativeName))
			{
				throw new InvalidOperationException();
			}
			this.m_negativeNombre = negativeName;
			this.m_nombre = negativeName + "/" + positiveName;
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x00024B3D File Offset: 0x00022D3D
		public bool polar
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x00024B40 File Offset: 0x00022D40
		public string positiveNombre
		{
			get
			{
				return this.m_positiveNombre;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x00024B48 File Offset: 0x00022D48
		public string negativeNombre
		{
			get
			{
				return this.m_negativeNombre;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x00024B50 File Offset: 0x00022D50
		public string nombre
		{
			get
			{
				return this.m_nombre;
			}
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00024B58 File Offset: 0x00022D58
		private void GetIndex(SkinnedMeshRenderer renderer, out int positiveIndex, out int negativeIndex)
		{
			if (renderer == null)
			{
				throw new ArgumentNullException("renderer", "renderer null reference.");
			}
			positiveIndex = ShapeKeyPolarizada.GetIndex(renderer, this.m_positiveNombre, this.m_positiveIndexEnRenderer);
			negativeIndex = ShapeKeyPolarizada.GetIndex(renderer, this.m_negativeNombre, this.m_negativeIndexEnRenderer);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00024BA8 File Offset: 0x00022DA8
		private static int GetIndex(SkinnedMeshRenderer renderer, string name, Dictionary<SkinnedMeshRenderer, int> indexEnRenderer)
		{
			if (renderer == null)
			{
				throw new ArgumentNullException("renderer", "renderer null reference.");
			}
			int blendShapeIndex;
			if (!indexEnRenderer.TryGetValue(renderer, out blendShapeIndex))
			{
				blendShapeIndex = renderer.sharedMesh.GetBlendShapeIndex(name);
				if (blendShapeIndex < 0)
				{
					return -1;
				}
				indexEnRenderer.Add(renderer, blendShapeIndex);
			}
			return blendShapeIndex;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00024BF8 File Offset: 0x00022DF8
		public float GetValor(SkinnedMeshRenderer renderer)
		{
			float num;
			if (!this.TryGetValor(renderer, out num))
			{
				throw new InvalidOperationException("Shape key Error");
			}
			return num;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00024C1C File Offset: 0x00022E1C
		public void SetValor(SkinnedMeshRenderer renderer, float valor)
		{
			if (!this.TrySetValor(renderer, valor))
			{
				throw new InvalidOperationException("Shape key Error");
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00024C34 File Offset: 0x00022E34
		public bool TryGetValor(SkinnedMeshRenderer renderer, out float polarPercentage)
		{
			polarPercentage = 0f;
			float num;
			float num2;
			if (!this.TryGetValor(renderer, out num, out num2))
			{
				return false;
			}
			polarPercentage = num - num2;
			return true;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00024C60 File Offset: 0x00022E60
		public bool TrySetValor(SkinnedMeshRenderer renderer, float polarPercentage)
		{
			if (renderer == null)
			{
				return false;
			}
			int num;
			int num2;
			this.GetIndex(renderer, out num, out num2);
			if (num < 0 || num2 < 0)
			{
				return false;
			}
			float num3 = Mathf.Clamp(polarPercentage, 0f, 100f);
			float num4 = Mathf.Clamp(polarPercentage, -100f, 0f) * -1f;
			renderer.SetBlendShapeWeight(num, num3);
			renderer.SetBlendShapeWeight(num2, num4);
			return true;
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x00024CC8 File Offset: 0x00022EC8
		public bool TryGetValor(SkinnedMeshRenderer renderer, out float positiveValor, out float negativeValor)
		{
			positiveValor = 0f;
			negativeValor = 0f;
			if (renderer == null)
			{
				return false;
			}
			int num;
			int num2;
			this.GetIndex(renderer, out num, out num2);
			if (num < 0 || num2 < 0)
			{
				return false;
			}
			positiveValor = renderer.GetBlendShapeWeight(num);
			negativeValor = renderer.GetBlendShapeWeight(num2);
			return true;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00024D18 File Offset: 0x00022F18
		public bool TrySetValor(SkinnedMeshRenderer renderer, float positiveValor, float negativeValor)
		{
			if (renderer == null)
			{
				return false;
			}
			int num;
			int num2;
			this.GetIndex(renderer, out num, out num2);
			if (num < 0 || num2 < 0)
			{
				return false;
			}
			renderer.SetBlendShapeWeight(num, positiveValor);
			renderer.SetBlendShapeWeight(num2, negativeValor);
			return true;
		}

		// Token: 0x0400035F RID: 863
		private string m_positiveNombre;

		// Token: 0x04000360 RID: 864
		private string m_negativeNombre;

		// Token: 0x04000361 RID: 865
		private string m_nombre;

		// Token: 0x04000362 RID: 866
		private Dictionary<SkinnedMeshRenderer, int> m_positiveIndexEnRenderer = new Dictionary<SkinnedMeshRenderer, int>();

		// Token: 0x04000363 RID: 867
		private Dictionary<SkinnedMeshRenderer, int> m_negativeIndexEnRenderer = new Dictionary<SkinnedMeshRenderer, int>();
	}
}

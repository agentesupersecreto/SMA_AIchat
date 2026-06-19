using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200010C RID: 268
	public class ValoresFlotantesMateriales
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x0001A7C8 File Offset: 0x000189C8
		public static void LoadDefaultAlpha(Material mat, int fieldID, BaseFlotanteSingleLayer valor, Component instance)
		{
			if (mat == null)
			{
				return;
			}
			if (!mat.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + mat.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			Color color = mat.GetColor(fieldID);
			valor.InitBase(color.a);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001A820 File Offset: 0x00018A20
		public static void LoadDefaultColor(Material mat, int fieldID, ValorDeColorHSV valor, Component instance)
		{
			if (mat == null)
			{
				return;
			}
			if (!mat.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + mat.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			Color color = mat.GetColor(fieldID);
			valor.InitBase(color);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001A874 File Offset: 0x00018A74
		public static void LoadDefaultFloat(Material mat, int fieldID, ValorFlotante valor, Component instance)
		{
			if (mat == null)
			{
				return;
			}
			if (!mat.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + mat.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			float @float = mat.GetFloat(fieldID);
			valor.InitBase(@float);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001A8C8 File Offset: 0x00018AC8
		public static void LoadDefaultTexxScale(Material mat, int fieldID, ValorFlotanteDoble valor, Component instance)
		{
			if (mat == null)
			{
				return;
			}
			if (!mat.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + mat.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			Vector2 textureScale = mat.GetTextureScale(fieldID);
			valor.InitBase(textureScale.x);
			valor.InitBase2(textureScale.y);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001A92B File Offset: 0x00018B2B
		public static void Set(Material material, int fieldID, Color color, Component instance)
		{
			if (material == null)
			{
				return;
			}
			if (!material.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			material.SetColor(fieldID, color);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001A96B File Offset: 0x00018B6B
		public static void SetTexxScale(Material material, int fieldID, Vector2 scale, Component instance)
		{
			if (material == null)
			{
				return;
			}
			if (!material.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			material.SetTextureScale(fieldID, scale);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001A9AB File Offset: 0x00018BAB
		public static void Set(Material material, int fieldID, float valor, Component instance)
		{
			if (material == null)
			{
				return;
			}
			if (!material.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			material.SetFloat(fieldID, valor);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001A9EC File Offset: 0x00018BEC
		public static void SetAlpha(Material material, int fieldID, float valor, Component instance)
		{
			if (material == null)
			{
				return;
			}
			if (!material.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				return;
			}
			Color color = ValoresFlotantesMateriales.GetColor(material, fieldID, instance);
			color.a = valor;
			material.SetColor(fieldID, color);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001AA48 File Offset: 0x00018C48
		public static void Set(List<Material> materiales, int fieldID, Color color, Component instance)
		{
			for (int i = 0; i < materiales.Count; i++)
			{
				ValoresFlotantesMateriales.Set(materiales[i], fieldID, color, instance);
			}
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001AA78 File Offset: 0x00018C78
		public static void SetColorIgnoreAlpha(List<Material> materiales, int fieldID, Color color, Component instance)
		{
			for (int i = 0; i < materiales.Count; i++)
			{
				Material material = materiales[i];
				Color color2 = ValoresFlotantesMateriales.GetColor(material, fieldID, instance);
				Color color3 = color;
				color3.a = color2.a;
				ValoresFlotantesMateriales.Set(material, fieldID, color3, instance);
			}
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001AAC0 File Offset: 0x00018CC0
		public static void Set(List<Material> materiales, int fieldID, float valor, Component instance, Material ignorar = null)
		{
			for (int i = 0; i < materiales.Count; i++)
			{
				Material material = materiales[i];
				if (!(material == ignorar))
				{
					ValoresFlotantesMateriales.Set(material, fieldID, valor, instance);
				}
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001AAFC File Offset: 0x00018CFC
		public static Color GetPromedioColor(List<Material> materiales, int fieldID, Component instance)
		{
			Color color = default(Color);
			int num = 0;
			for (int i = 0; i < materiales.Count; i++)
			{
				Material material = materiales[i];
				if (!material.HasProperty(fieldID))
				{
					Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
				}
				else
				{
					num++;
					color += material.GetColor(fieldID);
				}
			}
			if (num == 0)
			{
				return Color.black;
			}
			return color / (float)num;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001AB7C File Offset: 0x00018D7C
		public static float GetPromedioFloat(List<Material> materiales, int fieldID, Component instance, ICollection<Material> ignorar = null)
		{
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < materiales.Count; i++)
			{
				Material material = materiales[i];
				if (ignorar == null || !ignorar.Contains(material))
				{
					if (!material.HasProperty(fieldID))
					{
						Debug.LogWarning("Material: " + material.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
					}
					else
					{
						num2++;
						num += material.GetFloat(fieldID);
					}
				}
			}
			if (num2 == 0)
			{
				return 0f;
			}
			return num / (float)num2;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001AC00 File Offset: 0x00018E00
		public static float GetFloat(Material materiales, int fieldID, Component instance)
		{
			float num = 0f;
			if (materiales == null)
			{
				return num;
			}
			if (!materiales.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + materiales.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
			}
			return num + materiales.GetFloat(fieldID);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001AC58 File Offset: 0x00018E58
		public static float GetFloatAlpha(Material materiales, int fieldID, Component instance)
		{
			if (!materiales.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + materiales.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
			}
			return materiales.GetColor(fieldID).a;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001ACA0 File Offset: 0x00018EA0
		public static Color GetColor(Material materiales, int fieldID, Component instance)
		{
			if (!materiales.HasProperty(fieldID))
			{
				Debug.LogWarning("Material: " + materiales.name + ". no contiene fieldID: " + fieldID.ToString(), instance);
			}
			return materiales.GetColor(fieldID);
		}
	}
}

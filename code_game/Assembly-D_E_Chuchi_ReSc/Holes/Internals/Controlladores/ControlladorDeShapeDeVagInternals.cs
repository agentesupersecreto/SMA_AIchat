using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores
{
	// Token: 0x020001BD RID: 445
	public class ControlladorDeShapeDeVagInternals : ControlladorDeShapeDeInternals
	{
		// Token: 0x06000A7C RID: 2684 RVA: 0x0002F9E4 File Offset: 0x0002DBE4
		protected override void InstantiateShapeKeys(List<IShapeKey> resultado)
		{
			resultado.Add(new ShapeKey("PlieguesHorizontales1"));
			resultado.Add(new ShapeKey("PlieguesHorizontales2"));
			resultado.Add(new ShapeKey("PlieguesVerticales1"));
			resultado.Add(new ShapeKey("PlieguesVerticales2"));
			resultado.Add(new ShapeKeyPolarizada("CervixSize_P", "CervixSize_N"));
			resultado.Add(new ShapeKeyPolarizada("CervixProyeccion_P", "CervixProyeccion_N"));
			resultado.Add(new ShapeKey("CervixCapsulePliegues1"));
			resultado.Add(new ShapeKey("CervixCapsulePliegues2"));
			resultado.Add(new ShapeKey("CervixCapsulePliegues3"));
			resultado.Add(new ShapeKey("CervixCapsulePliegues4"));
			resultado.Add(new ShapeKey("CervixCapsulePliegues5"));
			resultado.Add(new ShapeKey("CervixCapsuleVariacion1"));
			resultado.Add(new ShapeKey("CervixCapsuleVariacion2"));
			resultado.Add(new ShapeKey("CervixCapsuleVariacion3"));
			resultado.Add(new ShapeKey("CervixCapsuleApertura"));
			resultado.Add(new ShapeKey("CervixVariacion1"));
			resultado.Add(new ShapeKey("CervixVariacion2"));
			resultado.Add(new ShapeKey("CervixVariacion3"));
			resultado.Add(new ShapeKey("CervixVariacion4"));
			resultado.Add(new ShapeKey("CanalCama"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal000"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal001"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal002"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal003"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal004"));
			resultado.Add(new ShapeKey("BeforePenSurfDefCanal005"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal000"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal001"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal002"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal003"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal004"));
			resultado.Add(new ShapeKey("BeforePenSurfDef2Canal005"));
			resultado.Add(new ShapeKeyPolarizada("UterusSize_P", "UterusSize_N"));
			resultado.Add(new ShapeKey("Rugae1"));
			resultado.Add(new ShapeKey("Rugae2"));
			resultado.Add(new ShapeKey("Swelling1"));
			resultado.Add(new ShapeKey("Swelling2"));
			resultado.Add(new ShapeKey("Swelling3"));
			resultado.Add(new ShapeKey("Swelling4"));
			resultado.Add(new ShapeKey("Swelling5"));
			resultado.Add(new ShapeKey("Nabothian1"));
			resultado.Add(new ShapeKey("Nabothian2"));
			resultado.Add(new ShapeKey("Nabothian3"));
			resultado.Add(new ShapeKey("Nabothian4"));
			resultado.Add(new ShapeKey("Nabothian5"));
			resultado.Add(new ShapeKey("FornixSwelling1"));
			resultado.Add(new ShapeKey("FornixSwelling2"));
			resultado.Add(new ShapeKey("FornixSwelling3"));
			resultado.Add(new ShapeKey("FornixSwelling4"));
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0002FD10 File Offset: 0x0002DF10
		protected override void ProducirGrupos()
		{
			base.ProducirGrupos();
			string[] array = new string[] { "Swelling1", "Swelling2", "Swelling3", "Swelling4", "Swelling5" };
			string[] array2 = new string[] { "FornixSwelling1", "FornixSwelling2", "FornixSwelling3", "FornixSwelling4" };
			base.AgruparNormalizando(array, new string[] { "CanalCama" });
			base.AgruparNormalizando(array, new string[] { "PlieguesHorizontales1", "PlieguesHorizontales2", "PlieguesVerticales1", "PlieguesVerticales2" });
			base.AgruparNormalizando(array2, new string[] { "CervixCapsulePliegues1", "CervixCapsulePliegues2", "CervixCapsulePliegues3", "CervixCapsulePliegues4", "CervixCapsulePliegues5" });
			base.AgruparNormalizando(array2, new string[] { "CervixCapsuleVariacion1", "CervixCapsuleVariacion2", "CervixCapsuleVariacion3" });
			base.AgruparNormalizando(new string[] { "CervixVariacion1", "CervixVariacion2", "CervixVariacion3", "CervixVariacion4" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal000", "BeforePenSurfDef2Canal000" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal001", "BeforePenSurfDef2Canal001" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal002", "BeforePenSurfDef2Canal002" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal003", "BeforePenSurfDef2Canal003" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal004", "BeforePenSurfDef2Canal004" });
			base.AgruparNormalizando(array, new string[] { "BeforePenSurfDefCanal005", "BeforePenSurfDef2Canal005" });
			base.AgruparNormalizandoExagerado(array, 6f, new string[] { "Rugae1", "Rugae2" });
			base.AgruparNormalizandoExagerado(3f, new string[] { "Swelling1", "Swelling2", "Swelling3", "Swelling4", "Swelling5" });
			base.AgruparNormalizandoExagerado(3f, new string[] { "Nabothian1", "Nabothian2", "Nabothian3", "Nabothian4", "Nabothian5" });
			base.AgruparNormalizandoExagerado(6f, new string[] { "FornixSwelling1", "FornixSwelling2", "FornixSwelling3", "FornixSwelling4" });
		}

		// Token: 0x04000873 RID: 2163
		public const string PlieguesHorizontales1 = "PlieguesHorizontales1";

		// Token: 0x04000874 RID: 2164
		public const string PlieguesHorizontales2 = "PlieguesHorizontales2";

		// Token: 0x04000875 RID: 2165
		public const string PlieguesVerticales1 = "PlieguesVerticales1";

		// Token: 0x04000876 RID: 2166
		public const string PlieguesVerticales2 = "PlieguesVerticales2";

		// Token: 0x04000877 RID: 2167
		public const string CervixSize_P = "CervixSize_P";

		// Token: 0x04000878 RID: 2168
		public const string CervixSize_N = "CervixSize_N";

		// Token: 0x04000879 RID: 2169
		public const string CervixProyeccion_P = "CervixProyeccion_P";

		// Token: 0x0400087A RID: 2170
		public const string CervixProyeccion_N = "CervixProyeccion_N";

		// Token: 0x0400087B RID: 2171
		public const string CervixCapsulePliegues1 = "CervixCapsulePliegues1";

		// Token: 0x0400087C RID: 2172
		public const string CervixCapsulePliegues2 = "CervixCapsulePliegues2";

		// Token: 0x0400087D RID: 2173
		public const string CervixCapsulePliegues3 = "CervixCapsulePliegues3";

		// Token: 0x0400087E RID: 2174
		public const string CervixCapsulePliegues4 = "CervixCapsulePliegues4";

		// Token: 0x0400087F RID: 2175
		public const string CervixCapsulePliegues5 = "CervixCapsulePliegues5";

		// Token: 0x04000880 RID: 2176
		public const string CervixCapsuleVariacion1 = "CervixCapsuleVariacion1";

		// Token: 0x04000881 RID: 2177
		public const string CervixCapsuleVariacion2 = "CervixCapsuleVariacion2";

		// Token: 0x04000882 RID: 2178
		public const string CervixCapsuleVariacion3 = "CervixCapsuleVariacion3";

		// Token: 0x04000883 RID: 2179
		public const string CervixCapsuleApertura = "CervixCapsuleApertura";

		// Token: 0x04000884 RID: 2180
		public const string CervixVariacion1 = "CervixVariacion1";

		// Token: 0x04000885 RID: 2181
		public const string CervixVariacion2 = "CervixVariacion2";

		// Token: 0x04000886 RID: 2182
		public const string CervixVariacion3 = "CervixVariacion3";

		// Token: 0x04000887 RID: 2183
		public const string CervixVariacion4 = "CervixVariacion4";

		// Token: 0x04000888 RID: 2184
		public const string CanalCama = "CanalCama";

		// Token: 0x04000889 RID: 2185
		public const string BeforePenSurfDefCanal000 = "BeforePenSurfDefCanal000";

		// Token: 0x0400088A RID: 2186
		public const string BeforePenSurfDefCanal001 = "BeforePenSurfDefCanal001";

		// Token: 0x0400088B RID: 2187
		public const string BeforePenSurfDefCanal002 = "BeforePenSurfDefCanal002";

		// Token: 0x0400088C RID: 2188
		public const string BeforePenSurfDefCanal003 = "BeforePenSurfDefCanal003";

		// Token: 0x0400088D RID: 2189
		public const string BeforePenSurfDefCanal004 = "BeforePenSurfDefCanal004";

		// Token: 0x0400088E RID: 2190
		public const string BeforePenSurfDefCanal005 = "BeforePenSurfDefCanal005";

		// Token: 0x0400088F RID: 2191
		public const string BeforePenSurfDef2Canal000 = "BeforePenSurfDef2Canal000";

		// Token: 0x04000890 RID: 2192
		public const string BeforePenSurfDef2Canal001 = "BeforePenSurfDef2Canal001";

		// Token: 0x04000891 RID: 2193
		public const string BeforePenSurfDef2Canal002 = "BeforePenSurfDef2Canal002";

		// Token: 0x04000892 RID: 2194
		public const string BeforePenSurfDef2Canal003 = "BeforePenSurfDef2Canal003";

		// Token: 0x04000893 RID: 2195
		public const string BeforePenSurfDef2Canal004 = "BeforePenSurfDef2Canal004";

		// Token: 0x04000894 RID: 2196
		public const string BeforePenSurfDef2Canal005 = "BeforePenSurfDef2Canal005";

		// Token: 0x04000895 RID: 2197
		public const string UterusSize_P = "UterusSize_P";

		// Token: 0x04000896 RID: 2198
		public const string UterusSize_N = "UterusSize_N";

		// Token: 0x04000897 RID: 2199
		public const string Rugae1 = "Rugae1";

		// Token: 0x04000898 RID: 2200
		public const string Rugae2 = "Rugae2";

		// Token: 0x04000899 RID: 2201
		public const string Swelling1 = "Swelling1";

		// Token: 0x0400089A RID: 2202
		public const string Swelling2 = "Swelling2";

		// Token: 0x0400089B RID: 2203
		public const string Swelling3 = "Swelling3";

		// Token: 0x0400089C RID: 2204
		public const string Swelling4 = "Swelling4";

		// Token: 0x0400089D RID: 2205
		public const string Swelling5 = "Swelling5";

		// Token: 0x0400089E RID: 2206
		public const string Nabothian1 = "Nabothian1";

		// Token: 0x0400089F RID: 2207
		public const string Nabothian2 = "Nabothian2";

		// Token: 0x040008A0 RID: 2208
		public const string Nabothian3 = "Nabothian3";

		// Token: 0x040008A1 RID: 2209
		public const string Nabothian4 = "Nabothian4";

		// Token: 0x040008A2 RID: 2210
		public const string Nabothian5 = "Nabothian5";

		// Token: 0x040008A3 RID: 2211
		public const string FornixSwelling1 = "FornixSwelling1";

		// Token: 0x040008A4 RID: 2212
		public const string FornixSwelling2 = "FornixSwelling2";

		// Token: 0x040008A5 RID: 2213
		public const string FornixSwelling3 = "FornixSwelling3";

		// Token: 0x040008A6 RID: 2214
		public const string FornixSwelling4 = "FornixSwelling4";
	}
}

using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores
{
	// Token: 0x020001BC RID: 444
	public class ControlladorDeShapeDeAnusInternals : ControlladorDeShapeDeInternals
	{
		// Token: 0x06000A79 RID: 2681 RVA: 0x0002F868 File Offset: 0x0002DA68
		protected override void InstantiateShapeKeys(List<IShapeKey> resultado)
		{
			resultado.Add(new ShapeKey("AnusInternal.Shape1.In"));
			resultado.Add(new ShapeKey("AnusInternal.Shape2.In"));
			resultado.Add(new ShapeKey("AnusInternal.Shape3.In"));
			resultado.Add(new ShapeKey("Hemo1"));
			resultado.Add(new ShapeKey("Hemo2"));
			resultado.Add(new ShapeKey("Hemo3"));
			resultado.Add(new ShapeKey("Irregular1"));
			resultado.Add(new ShapeKey("Irregular2"));
			resultado.Add(new ShapeKey("Irregular3"));
			resultado.Add(new ShapeKey("Irregular4"));
			resultado.Add(new ShapeKey("Irregular5"));
			resultado.Add(new ShapeKey("Irregular6"));
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0002F938 File Offset: 0x0002DB38
		protected override void ProducirGrupos()
		{
			base.ProducirGrupos();
			base.AgruparNormalizando(new string[] { "AnusInternal.Shape1.In", "AnusInternal.Shape2.In", "AnusInternal.Shape3.In" });
			base.AgruparNormalizandoExagerado(1.25f, new string[] { "Hemo1", "Hemo2", "Hemo3" });
			base.AgruparNormalizandoExagerado(3f, new string[] { "Irregular1", "Irregular2", "Irregular3", "Irregular4", "Irregular5", "Irregular6" });
		}

		// Token: 0x04000867 RID: 2151
		public const string AnusInternalShape1In = "AnusInternal.Shape1.In";

		// Token: 0x04000868 RID: 2152
		public const string AnusInternalShape2In = "AnusInternal.Shape2.In";

		// Token: 0x04000869 RID: 2153
		public const string AnusInternalShape3In = "AnusInternal.Shape3.In";

		// Token: 0x0400086A RID: 2154
		public const string Hemo1 = "Hemo1";

		// Token: 0x0400086B RID: 2155
		public const string Hemo2 = "Hemo2";

		// Token: 0x0400086C RID: 2156
		public const string Hemo3 = "Hemo3";

		// Token: 0x0400086D RID: 2157
		public const string Irregular1 = "Irregular1";

		// Token: 0x0400086E RID: 2158
		public const string Irregular2 = "Irregular2";

		// Token: 0x0400086F RID: 2159
		public const string Irregular3 = "Irregular3";

		// Token: 0x04000870 RID: 2160
		public const string Irregular4 = "Irregular4";

		// Token: 0x04000871 RID: 2161
		public const string Irregular5 = "Irregular5";

		// Token: 0x04000872 RID: 2162
		public const string Irregular6 = "Irregular6";
	}
}

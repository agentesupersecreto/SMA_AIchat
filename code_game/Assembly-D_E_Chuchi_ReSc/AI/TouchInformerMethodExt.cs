using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000317 RID: 791
	public static class TouchInformerMethodExt
	{
		// Token: 0x0600111B RID: 4379 RVA: 0x0004A492 File Offset: 0x00048692
		[Obsolete]
		public static bool HasFlag(this TouchInformerMethod variable, TouchInformerMethod value)
		{
			return ((int)variable).HasFlag((int)value);
		}
	}
}

using System;

namespace Assets
{
	// Token: 0x0200014F RID: 335
	public static class EXT_AxisEXT
	{
		// Token: 0x060009EE RID: 2542 RVA: 0x0002053B File Offset: 0x0001E73B
		public static Axis Parse(this AxisPolarizado polar)
		{
			return (Axis)polar;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0002053E File Offset: 0x0001E73E
		public static AxisPolarizado Parse(this Axis polar)
		{
			return (AxisPolarizado)polar;
		}
	}
}

using System;

namespace TValleCustomClases
{
	// Token: 0x02000068 RID: 104
	[Serializable]
	public class ModificablePercentage : RealModificablePercentage
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000E1BE File Offset: 0x0000C3BE
		public override float minValue
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x040000A8 RID: 168
		public new const float MinValue = 0f;
	}
}

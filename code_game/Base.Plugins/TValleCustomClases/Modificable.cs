using System;

namespace TValleCustomClases
{
	// Token: 0x02000067 RID: 103
	[Serializable]
	public class Modificable : RealModificable
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000E1AF File Offset: 0x0000C3AF
		public override float minValue
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x040000A7 RID: 167
		public new const float MinValue = 0f;
	}
}

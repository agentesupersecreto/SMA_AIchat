using System;

namespace TValleCustomClases
{
	// Token: 0x02000066 RID: 102
	[Serializable]
	public class AngleModificable : RealAngleModificable
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000E1A0 File Offset: 0x0000C3A0
		public override float minValue
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x040000A6 RID: 166
		public new const float MinValue = 0f;
	}
}

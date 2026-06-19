using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000171 RID: 369
	[Serializable]
	public struct ForcedUpdateId : IEquatable<ForcedUpdateId>
	{
		// Token: 0x06000AFE RID: 2814 RVA: 0x000252A8 File Offset: 0x000234A8
		public static ForcedUpdateId Create(int id)
		{
			return new ForcedUpdateId(id);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x000252B0 File Offset: 0x000234B0
		private ForcedUpdateId(int id)
		{
			this.m_id = id;
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x000252B9 File Offset: 0x000234B9
		public static ForcedUpdateId current
		{
			get
			{
				return new ForcedUpdateId(Time.frameCount);
			}
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000252C5 File Offset: 0x000234C5
		public static bool isCurrent(ForcedUpdateId id)
		{
			return Time.frameCount > 0 && id.m_id == Time.frameCount;
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x000252DE File Offset: 0x000234DE
		// (set) Token: 0x06000B03 RID: 2819 RVA: 0x000252E6 File Offset: 0x000234E6
		public int id
		{
			get
			{
				return this.m_id;
			}
			private set
			{
				this.m_id = value;
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000252EF File Offset: 0x000234EF
		public static bool operator ==(ForcedUpdateId x, ForcedUpdateId y)
		{
			return x.m_id == y.m_id;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x000252FF File Offset: 0x000234FF
		public static bool operator !=(ForcedUpdateId x, ForcedUpdateId y)
		{
			return x.m_id != y.m_id;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00025312 File Offset: 0x00023512
		public override int GetHashCode()
		{
			return this.m_id.GetHashCode();
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00025320 File Offset: 0x00023520
		public override bool Equals(object obj)
		{
			if (!(obj is ForcedUpdateId))
			{
				return false;
			}
			ForcedUpdateId forcedUpdateId = (ForcedUpdateId)obj;
			return this.m_id == forcedUpdateId.m_id;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0002534C File Offset: 0x0002354C
		public bool Equals(ForcedUpdateId other)
		{
			return this.m_id == other.m_id;
		}

		// Token: 0x0400036F RID: 879
		[ReadOnlyUI]
		[SerializeField]
		private int m_id;
	}
}

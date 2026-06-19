using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000170 RID: 368
	[Serializable]
	public struct ForcedFixedUpdateId : IEquatable<ForcedFixedUpdateId>
	{
		// Token: 0x06000AF4 RID: 2804 RVA: 0x000251FD File Offset: 0x000233FD
		private ForcedFixedUpdateId(int id)
		{
			this.m_id = id;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x00025206 File Offset: 0x00023406
		public static ForcedFixedUpdateId current
		{
			get
			{
				return new ForcedFixedUpdateId(FixedFrameCounter.frameCount);
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x00025212 File Offset: 0x00023412
		public static bool isCurrent(ForcedFixedUpdateId id)
		{
			return FixedFrameCounter.frameCount > 0 && id.m_id == FixedFrameCounter.frameCount;
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x0002522B File Offset: 0x0002342B
		// (set) Token: 0x06000AF8 RID: 2808 RVA: 0x00025233 File Offset: 0x00023433
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

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0002523C File Offset: 0x0002343C
		public static bool operator ==(ForcedFixedUpdateId x, ForcedFixedUpdateId y)
		{
			return x.m_id == y.m_id;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0002524C File Offset: 0x0002344C
		public static bool operator !=(ForcedFixedUpdateId x, ForcedFixedUpdateId y)
		{
			return x.m_id != y.m_id;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0002525F File Offset: 0x0002345F
		public override int GetHashCode()
		{
			return this.m_id.GetHashCode();
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0002526C File Offset: 0x0002346C
		public override bool Equals(object obj)
		{
			if (!(obj is ForcedFixedUpdateId))
			{
				return false;
			}
			ForcedFixedUpdateId forcedFixedUpdateId = (ForcedFixedUpdateId)obj;
			return this.m_id == forcedFixedUpdateId.m_id;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00025298 File Offset: 0x00023498
		public bool Equals(ForcedFixedUpdateId other)
		{
			return this.m_id == other.m_id;
		}

		// Token: 0x0400036E RID: 878
		[ReadOnlyUI]
		[SerializeField]
		private int m_id;
	}
}

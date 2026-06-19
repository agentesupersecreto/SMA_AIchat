using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000172 RID: 370
	[Serializable]
	public struct UpdateAutoId : IEquatable<UpdateAutoId>
	{
		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0002535C File Offset: 0x0002355C
		public static UpdateAutoId zero
		{
			get
			{
				return new UpdateAutoId(0);
			}
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00025364 File Offset: 0x00023564
		public UpdateAutoId(int id)
		{
			this.m_id = id;
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0002536D File Offset: 0x0002356D
		public static UpdateAutoId current
		{
			get
			{
				if (Time.inFixedTimeStep)
				{
					return new UpdateAutoId(FixedFrameCounter.frameCount);
				}
				return new UpdateAutoId(Time.frameCount);
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0002538B File Offset: 0x0002358B
		public static bool isCurrent(UpdateAutoId id)
		{
			if (Time.inFixedTimeStep)
			{
				return FixedFrameCounter.frameCount > 0 && id.m_id == FixedFrameCounter.frameCount;
			}
			return Time.frameCount > 0 && id.m_id == Time.frameCount;
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x000253C3 File Offset: 0x000235C3
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x000253CB File Offset: 0x000235CB
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

		// Token: 0x06000B0F RID: 2831 RVA: 0x000253D4 File Offset: 0x000235D4
		public static bool operator ==(UpdateAutoId x, UpdateAutoId y)
		{
			return x.m_id == y.m_id;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000253E4 File Offset: 0x000235E4
		public static bool operator !=(UpdateAutoId x, UpdateAutoId y)
		{
			return x.m_id != y.m_id;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x000253F7 File Offset: 0x000235F7
		public override int GetHashCode()
		{
			return this.m_id.GetHashCode();
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00025404 File Offset: 0x00023604
		public override bool Equals(object obj)
		{
			if (!(obj is UpdateAutoId))
			{
				return false;
			}
			UpdateAutoId updateAutoId = (UpdateAutoId)obj;
			return this.m_id == updateAutoId.m_id;
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00025430 File Offset: 0x00023630
		public bool Equals(UpdateAutoId other)
		{
			return this.m_id == other.m_id;
		}

		// Token: 0x04000370 RID: 880
		[ReadOnlyUI]
		[SerializeField]
		private int m_id;
	}
}

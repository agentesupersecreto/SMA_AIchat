using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000DD RID: 221
	public abstract class Linear7BoneChain<T> : Linear7BoneChainBase where T : ChainPointStretcherJoint
	{
		// Token: 0x17000376 RID: 886
		// (get) Token: 0x060008CD RID: 2253
		public abstract T _000 { get; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x060008CE RID: 2254
		public abstract T _001 { get; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x060008CF RID: 2255
		public abstract T _002 { get; }

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x060008D0 RID: 2256
		public abstract T _003 { get; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060008D1 RID: 2257
		public abstract T _004 { get; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060008D2 RID: 2258
		public abstract T _005 { get; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x060008D3 RID: 2259
		public abstract T _006 { get; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0001C066 File Offset: 0x0001A266
		public sealed override ChainPointStretcherJoint _000Base
		{
			get
			{
				return this._000;
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x0001C073 File Offset: 0x0001A273
		public sealed override ChainPointStretcherJoint _001Base
		{
			get
			{
				return this._001;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0001C080 File Offset: 0x0001A280
		public sealed override ChainPointStretcherJoint _002Base
		{
			get
			{
				return this._002;
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0001C08D File Offset: 0x0001A28D
		public sealed override ChainPointStretcherJoint _003Base
		{
			get
			{
				return this._003;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x0001C09A File Offset: 0x0001A29A
		public sealed override ChainPointStretcherJoint _004Base
		{
			get
			{
				return this._004;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0001C0A7 File Offset: 0x0001A2A7
		public sealed override ChainPointStretcherJoint _005Base
		{
			get
			{
				return this._005;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
		public sealed override ChainPointStretcherJoint _006Base
		{
			get
			{
				return this._006;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x0001C0C1 File Offset: 0x0001A2C1
		public sealed override IList<ChainPointStretcherJoint> puntosBase
		{
			get
			{
				return this.m_puntosBase;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0001C0C9 File Offset: 0x0001A2C9
		public IList<T> puntos
		{
			get
			{
				return this.m_puntos;
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001C0D4 File Offset: 0x0001A2D4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			List<T> list = new List<T>(7);
			List<ChainPointStretcherJoint> list2 = new List<ChainPointStretcherJoint>(7);
			list.Add(this._000);
			list2.Add(this._000);
			list.Add(this._001);
			list2.Add(this._001);
			list.Add(this._002);
			list2.Add(this._002);
			list.Add(this._003);
			list2.Add(this._003);
			list.Add(this._004);
			list2.Add(this._004);
			list.Add(this._005);
			list2.Add(this._005);
			list.Add(this._006);
			list2.Add(this._006);
			this.m_puntos = new ReadOnlyCollection<T>(list);
			this.m_puntosBase = new ReadOnlyCollection<ChainPointStretcherJoint>(list2);
		}

		// Token: 0x040004B4 RID: 1204
		private ReadOnlyCollection<T> m_puntos;

		// Token: 0x040004B5 RID: 1205
		private ReadOnlyCollection<ChainPointStretcherJoint> m_puntosBase;
	}
}

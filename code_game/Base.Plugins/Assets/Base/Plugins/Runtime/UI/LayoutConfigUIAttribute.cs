using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x02000194 RID: 404
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class LayoutConfigUIAttribute : Attribute, IBaseLayoutAttribute
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x000263A5 File Offset: 0x000245A5
		// (set) Token: 0x06000BC0 RID: 3008 RVA: 0x000263B2 File Offset: 0x000245B2
		public float scaleMod
		{
			get
			{
				return this.m_scaleMod.GetValueOrDefault();
			}
			set
			{
				this.m_scaleMod = new float?(value);
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x000263C0 File Offset: 0x000245C0
		public bool scaleModByUser
		{
			get
			{
				return this.m_scaleMod != null;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000263CD File Offset: 0x000245CD
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x000263DA File Offset: 0x000245DA
		public int height
		{
			get
			{
				return this.m_height.GetValueOrDefault();
			}
			set
			{
				this.m_height = new int?(value);
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000263E8 File Offset: 0x000245E8
		// (set) Token: 0x06000BC5 RID: 3013 RVA: 0x000263F5 File Offset: 0x000245F5
		public int width
		{
			get
			{
				return this.m_width.GetValueOrDefault();
			}
			set
			{
				this.m_width = new int?(value);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x00026403 File Offset: 0x00024603
		public bool heightByUser
		{
			get
			{
				return this.m_height != null;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x00026410 File Offset: 0x00024610
		public bool widthByUser
		{
			get
			{
				return this.m_width != null;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0002641D File Offset: 0x0002461D
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x0002642A File Offset: 0x0002462A
		public float heightMod
		{
			get
			{
				return this.m_heightMod.GetValueOrDefault();
			}
			set
			{
				this.m_heightMod = new float?(value);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00026438 File Offset: 0x00024638
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x00026445 File Offset: 0x00024645
		public float widthMod
		{
			get
			{
				return this.m_widthMod.GetValueOrDefault();
			}
			set
			{
				this.m_widthMod = new float?(value);
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x00026453 File Offset: 0x00024653
		public bool heightModByUser
		{
			get
			{
				return this.m_heightMod != null;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x00026460 File Offset: 0x00024660
		public bool widthModByUser
		{
			get
			{
				return this.m_widthMod != null;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x0002646D File Offset: 0x0002466D
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x0002647A File Offset: 0x0002467A
		public int leftPadding
		{
			get
			{
				return this.m_leftPadding.GetValueOrDefault();
			}
			set
			{
				this.m_leftPadding = new int?(value);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00026488 File Offset: 0x00024688
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x00026495 File Offset: 0x00024695
		public int rightPadding
		{
			get
			{
				return this.m_rightPadding.GetValueOrDefault();
			}
			set
			{
				this.m_rightPadding = new int?(value);
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x000264A3 File Offset: 0x000246A3
		// (set) Token: 0x06000BD3 RID: 3027 RVA: 0x000264B0 File Offset: 0x000246B0
		public int topPadding
		{
			get
			{
				return this.m_topPadding.GetValueOrDefault();
			}
			set
			{
				this.m_topPadding = new int?(value);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x000264BE File Offset: 0x000246BE
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x000264CB File Offset: 0x000246CB
		public int bottomPadding
		{
			get
			{
				return this.m_bottomPadding.GetValueOrDefault();
			}
			set
			{
				this.m_bottomPadding = new int?(value);
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x000264D9 File Offset: 0x000246D9
		public bool leftPaddingByUser
		{
			get
			{
				return this.m_leftPadding != null;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x000264E6 File Offset: 0x000246E6
		public bool rightPaddingByUser
		{
			get
			{
				return this.m_rightPadding != null;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x000264F3 File Offset: 0x000246F3
		public bool topPaddingByUser
		{
			get
			{
				return this.m_topPadding != null;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00026500 File Offset: 0x00024700
		public bool bottomPaddingByUser
		{
			get
			{
				return this.m_bottomPadding != null;
			}
		}

		// Token: 0x040003D2 RID: 978
		private float? m_scaleMod;

		// Token: 0x040003D3 RID: 979
		private int? m_height;

		// Token: 0x040003D4 RID: 980
		private int? m_width;

		// Token: 0x040003D5 RID: 981
		private float? m_heightMod;

		// Token: 0x040003D6 RID: 982
		private float? m_widthMod;

		// Token: 0x040003D7 RID: 983
		private int? m_leftPadding;

		// Token: 0x040003D8 RID: 984
		private int? m_rightPadding;

		// Token: 0x040003D9 RID: 985
		private int? m_topPadding;

		// Token: 0x040003DA RID: 986
		private int? m_bottomPadding;
	}
}

using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200031B RID: 795
	public class EmptyZonaErogenaData<Tdata> : IZonaErogenaData<Tdata>, IDataSet<Tdata>
	{
		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x0600112F RID: 4399 RVA: 0x0004A49B File Offset: 0x0004869B
		public static EmptyZonaErogenaData<Tdata> instance
		{
			get
			{
				if (EmptyZonaErogenaData<Tdata>.m_inst == null)
				{
					EmptyZonaErogenaData<Tdata>.m_inst = new EmptyZonaErogenaData<Tdata>();
				}
				return EmptyZonaErogenaData<Tdata>.m_inst;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x0004A4B4 File Offset: 0x000486B4
		public Tdata altaSensibilidad
		{
			get
			{
				return default(Tdata);
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001131 RID: 4401 RVA: 0x0004A4CC File Offset: 0x000486CC
		public Tdata bajaSensibilidad
		{
			get
			{
				return default(Tdata);
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x0004A4E4 File Offset: 0x000486E4
		public Tdata muyAltaSensibilidad
		{
			get
			{
				return default(Tdata);
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06001133 RID: 4403 RVA: 0x0004A4FC File Offset: 0x000486FC
		public Tdata muyBajaSensibilidad
		{
			get
			{
				return default(Tdata);
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x0004A514 File Offset: 0x00048714
		public Tdata normalSensibilidad
		{
			get
			{
				return default(Tdata);
			}
		}

		// Token: 0x04000DA4 RID: 3492
		private static EmptyZonaErogenaData<Tdata> m_inst;
	}
}

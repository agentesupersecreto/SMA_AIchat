using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables
{
	// Token: 0x0200017D RID: 381
	public class RecorridoDeMassgeOnMaleBody : CustomMonobehaviour
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x00028CD0 File Offset: 0x00026ED0
		public InteraccionRootRecorridoCircular Chest_R
		{
			get
			{
				return this.m_Chest_R;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00028CD8 File Offset: 0x00026ED8
		public InteraccionRootRecorridoCircular Chest_L
		{
			get
			{
				return this.m_Chest_L;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00028CE0 File Offset: 0x00026EE0
		public InteraccionRootRecorridoCircular Nipple_R
		{
			get
			{
				return this.m_Nipple_R;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00028CE8 File Offset: 0x00026EE8
		public InteraccionRootRecorridoCircular Nipple_L
		{
			get
			{
				return this.m_Nipple_L;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00028CF0 File Offset: 0x00026EF0
		public InteraccionRootRecorridoCircular Shoulder_R
		{
			get
			{
				return this.m_Shoulder_R;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x00028CF8 File Offset: 0x00026EF8
		public InteraccionRootRecorridoCircular Shoulder_L
		{
			get
			{
				return this.m_Shoulder_L;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x00028D00 File Offset: 0x00026F00
		public InteraccionRootRecorridoCircular Abdomen_R
		{
			get
			{
				return this.m_Abdomen_R;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x00028D08 File Offset: 0x00026F08
		public InteraccionRootRecorridoCircular Abdomen_L
		{
			get
			{
				return this.m_Abdomen_L;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x00028D10 File Offset: 0x00026F10
		public InteraccionRootRecorridoCircular Groin_R
		{
			get
			{
				return this.m_Groin_R;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00028D18 File Offset: 0x00026F18
		public InteraccionRootRecorridoCircular Groin_L
		{
			get
			{
				return this.m_Groin_L;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x00028D20 File Offset: 0x00026F20
		public InteraccionRootRecorridoCircular Leg_R
		{
			get
			{
				return this.m_Leg_R;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00028D28 File Offset: 0x00026F28
		public InteraccionRootRecorridoCircular Leg_L
		{
			get
			{
				return this.m_Leg_L;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x00028D30 File Offset: 0x00026F30
		public InteraccionRootRecorridoCircular Calf_R
		{
			get
			{
				return this.m_Calf_R;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00028D38 File Offset: 0x00026F38
		public InteraccionRootRecorridoCircular Calf_L
		{
			get
			{
				return this.m_Calf_L;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x00028D40 File Offset: 0x00026F40
		public Transform KneeApoyo_R
		{
			get
			{
				return this.m_KneeApoyo_R;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00028D48 File Offset: 0x00026F48
		public Transform KneeApoyo_L
		{
			get
			{
				return this.m_KneeApoyo_L;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x00028D50 File Offset: 0x00026F50
		public Transform LegApoyo_R
		{
			get
			{
				return this.m_LegApoyo_R;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x00028D58 File Offset: 0x00026F58
		public Transform LegApoyo_L
		{
			get
			{
				return this.m_LegApoyo_L;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x00028D60 File Offset: 0x00026F60
		public Transform ChestApoyo_R
		{
			get
			{
				return this.m_ChestApoyo_R;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00028D68 File Offset: 0x00026F68
		public Transform ChestApoyo_L
		{
			get
			{
				return this.m_ChestApoyo_L;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x00028D70 File Offset: 0x00026F70
		public Transform AbdomenApoyo_R
		{
			get
			{
				return this.m_AbdomenApoyo_R;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00028D78 File Offset: 0x00026F78
		public Transform AbdomenApoyo_L
		{
			get
			{
				return this.m_AbdomenApoyo_L;
			}
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00028D80 File Offset: 0x00026F80
		public InteraccionRootRecorridoCircular GetRecorrido(RecorridoDeMassgeOnMaleBody.Recorrido recorrido, Side side)
		{
			switch (recorrido)
			{
			case RecorridoDeMassgeOnMaleBody.Recorrido.Chest:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Chest_R, this.m_Chest_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Nipple:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Nipple_R, this.m_Nipple_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Shoulder:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Shoulder_R, this.m_Shoulder_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Abdomen:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Abdomen_R, this.m_Abdomen_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Groin:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Groin_R, this.m_Groin_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Leg:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Leg_R, this.m_Leg_L), side);
			case RecorridoDeMassgeOnMaleBody.Recorrido.Calf:
				return this.GetRecorrido(new ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular>(this.m_Calf_R, this.m_Calf_L), side);
			default:
				throw new ArgumentOutOfRangeException(recorrido.ToString());
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00028E77 File Offset: 0x00027077
		private InteraccionRootRecorridoCircular GetRecorrido([TupleElementNames(new string[] { "r", "l" })] ValueTuple<InteraccionRootRecorridoCircular, InteraccionRootRecorridoCircular> par, Side side)
		{
			if (side == Side.L)
			{
				return par.Item2;
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			return par.Item1;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00028EA4 File Offset: 0x000270A4
		public Transform GetApoyo(PuntoDeApoyoSobreMaleBody apoyo, Side side)
		{
			switch (apoyo)
			{
			case PuntoDeApoyoSobreMaleBody.Knee:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_KneeApoyo_R, this.m_KneeApoyo_L), side);
			case PuntoDeApoyoSobreMaleBody.Leg:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_LegApoyo_R, this.m_LegApoyo_L), side);
			case PuntoDeApoyoSobreMaleBody.Chest:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_ChestApoyo_R, this.m_ChestApoyo_L), side);
			case PuntoDeApoyoSobreMaleBody.Abdomen:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_AbdomenApoyo_R, this.m_AbdomenApoyo_L), side);
			case PuntoDeApoyoSobreMaleBody.Sholder:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_ShoulderApoyo_R, this.m_ShoulderApoyo_L), side);
			case PuntoDeApoyoSobreMaleBody.Groin:
				return this.GetApoyo(new ValueTuple<Transform, Transform>(this.m_GroinApoyo_R, this.m_GroinApoyo_L), side);
			default:
				throw new ArgumentOutOfRangeException(apoyo.ToString());
			}
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00028F7E File Offset: 0x0002717E
		private Transform GetApoyo([TupleElementNames(new string[] { "r", "l" })] ValueTuple<Transform, Transform> par, Side side)
		{
			if (side == Side.L)
			{
				return par.Item2;
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			return par.Item1;
		}

		// Token: 0x040006E6 RID: 1766
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Chest_R;

		// Token: 0x040006E7 RID: 1767
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Chest_L;

		// Token: 0x040006E8 RID: 1768
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Nipple_R;

		// Token: 0x040006E9 RID: 1769
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Nipple_L;

		// Token: 0x040006EA RID: 1770
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Shoulder_R;

		// Token: 0x040006EB RID: 1771
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Shoulder_L;

		// Token: 0x040006EC RID: 1772
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Abdomen_R;

		// Token: 0x040006ED RID: 1773
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Abdomen_L;

		// Token: 0x040006EE RID: 1774
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Groin_R;

		// Token: 0x040006EF RID: 1775
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Groin_L;

		// Token: 0x040006F0 RID: 1776
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Leg_R;

		// Token: 0x040006F1 RID: 1777
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Leg_L;

		// Token: 0x040006F2 RID: 1778
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Calf_R;

		// Token: 0x040006F3 RID: 1779
		[SerializeField]
		private InteraccionRootRecorridoCircular m_Calf_L;

		// Token: 0x040006F4 RID: 1780
		[SerializeField]
		private Transform m_KneeApoyo_R;

		// Token: 0x040006F5 RID: 1781
		[SerializeField]
		private Transform m_KneeApoyo_L;

		// Token: 0x040006F6 RID: 1782
		[SerializeField]
		private Transform m_LegApoyo_R;

		// Token: 0x040006F7 RID: 1783
		[SerializeField]
		private Transform m_LegApoyo_L;

		// Token: 0x040006F8 RID: 1784
		[SerializeField]
		private Transform m_ChestApoyo_R;

		// Token: 0x040006F9 RID: 1785
		[SerializeField]
		private Transform m_ChestApoyo_L;

		// Token: 0x040006FA RID: 1786
		[SerializeField]
		private Transform m_AbdomenApoyo_R;

		// Token: 0x040006FB RID: 1787
		[SerializeField]
		private Transform m_AbdomenApoyo_L;

		// Token: 0x040006FC RID: 1788
		[SerializeField]
		private Transform m_ShoulderApoyo_R;

		// Token: 0x040006FD RID: 1789
		[SerializeField]
		private Transform m_ShoulderApoyo_L;

		// Token: 0x040006FE RID: 1790
		[SerializeField]
		private Transform m_GroinApoyo_R;

		// Token: 0x040006FF RID: 1791
		[SerializeField]
		private Transform m_GroinApoyo_L;

		// Token: 0x0200017E RID: 382
		public enum Recorrido
		{
			// Token: 0x04000701 RID: 1793
			None,
			// Token: 0x04000702 RID: 1794
			Chest,
			// Token: 0x04000703 RID: 1795
			Nipple,
			// Token: 0x04000704 RID: 1796
			Shoulder,
			// Token: 0x04000705 RID: 1797
			Abdomen,
			// Token: 0x04000706 RID: 1798
			Groin,
			// Token: 0x04000707 RID: 1799
			Leg,
			// Token: 0x04000708 RID: 1800
			Calf
		}
	}
}

using System;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000147 RID: 327
	public class DummyGrabbableProp : CustomMonobehaviour, IGrabableProp
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00023905 File Offset: 0x00021B05
		public GrabbablePropEstado estado
		{
			get
			{
				return GrabbablePropEstado.Grabbed;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		public Transform physcisRoot
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		public Transform skeletonRoot
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00006DC5 File Offset: 0x00004FC5
		public float worldLength
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x00023908 File Offset: 0x00021B08
		public GameObject notGrabedPhysics
		{
			get
			{
				return base.gameObject;
			}
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores
{
	// Token: 0x02000185 RID: 389
	public class RecorridoDeLinearesOnMaleBody : CustomMonobehaviour
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x000293A1 File Offset: 0x000275A1
		public InteraccionRootRecorridoLinear pene
		{
			get
			{
				return this.m_nepe;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x000293A9 File Offset: 0x000275A9
		public InteraccionRootRecorridoLinear peneVirtual
		{
			get
			{
				return this.m_nepeVirtual;
			}
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x000293B1 File Offset: 0x000275B1
		public InteraccionRootRecorridoLinear GetRecorrido(RecorridoDeLinearesOnMaleBody.Recorrido recorrido, Side side)
		{
			if (recorrido == RecorridoDeLinearesOnMaleBody.Recorrido.nepe)
			{
				return this.m_nepe;
			}
			if (recorrido != RecorridoDeLinearesOnMaleBody.Recorrido.nepeVirtual)
			{
				throw new ArgumentOutOfRangeException(recorrido.ToString());
			}
			return this.m_nepeVirtual;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000293DD File Offset: 0x000275DD
		private InteraccionRootRecorridoLinear GetRecorrido([TupleElementNames(new string[] { "r", "l" })] ValueTuple<InteraccionRootRecorridoLinear, InteraccionRootRecorridoLinear> par, Side side)
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

		// Token: 0x0400071F RID: 1823
		[SerializeField]
		private InteraccionRootRecorridoLinear m_nepe;

		// Token: 0x04000720 RID: 1824
		[SerializeField]
		private InteraccionRootRecorridoLinear m_nepeVirtual;

		// Token: 0x02000186 RID: 390
		public enum Recorrido
		{
			// Token: 0x04000722 RID: 1826
			None,
			// Token: 0x04000723 RID: 1827
			nepe,
			// Token: 0x04000724 RID: 1828
			nepeVirtual
		}
	}
}

using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000053 RID: 83
	public abstract class CoolDownPorID<Ttipo>
	{
		// Token: 0x0600029F RID: 671 RVA: 0x0000D21F File Offset: 0x0000B41F
		public CoolDownPorID(Func<float> defaultCooldwonGetter)
		{
			this.defaultCooldwonGetter = defaultCooldwonGetter;
		}

		// Token: 0x060002A0 RID: 672
		protected abstract int ConvertirTipoAId(Ttipo tipo);

		// Token: 0x060002A1 RID: 673 RVA: 0x0000D23C File Offset: 0x0000B43C
		public bool IsOn(Ttipo tipo, float mod = 1f)
		{
			int num = this.ConvertirTipoAId(tipo);
			CoolDown coolDown;
			if (this.m_dic.TryGetValue(num, out coolDown))
			{
				return coolDown.IsOn(mod);
			}
			coolDown = new CoolDown(this.defaultCooldwonGetter());
			this.m_dic.Add(num, coolDown);
			return coolDown.IsOn(mod);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000D290 File Offset: 0x0000B490
		public float Left(Ttipo tipo)
		{
			int num = this.ConvertirTipoAId(tipo);
			CoolDown coolDown;
			if (this.m_dic.TryGetValue(num, out coolDown))
			{
				return coolDown.left;
			}
			coolDown = new CoolDown(this.defaultCooldwonGetter());
			this.m_dic.Add(num, coolDown);
			return coolDown.left;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
		public void Apply(Ttipo tipo)
		{
			int num = this.ConvertirTipoAId(tipo);
			CoolDown coolDown;
			if (this.m_dic.TryGetValue(num, out coolDown))
			{
				coolDown.ApplyNext(this.defaultCooldwonGetter());
				return;
			}
			coolDown = new CoolDown(this.defaultCooldwonGetter());
			this.m_dic.Add(num, coolDown);
			coolDown.Apply();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000D33C File Offset: 0x0000B53C
		public void ApplyNext(Ttipo tipo, float next)
		{
			int num = this.ConvertirTipoAId(tipo);
			CoolDown coolDown;
			if (this.m_dic.TryGetValue(num, out coolDown))
			{
				coolDown.ApplyNext(next);
				return;
			}
			coolDown = new CoolDown(next);
			this.m_dic.Add(num, coolDown);
			coolDown.ApplyNext(next);
		}

		// Token: 0x0400008E RID: 142
		public Func<float> defaultCooldwonGetter;

		// Token: 0x0400008F RID: 143
		private Dictionary<int, CoolDown> m_dic = new Dictionary<int, CoolDown>();
	}
}

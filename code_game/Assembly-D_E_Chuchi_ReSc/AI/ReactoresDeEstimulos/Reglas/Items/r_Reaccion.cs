using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C3 RID: 963
	[Serializable]
	public sealed class r_Reaccion : ReglaItem
	{
		// Token: 0x060014DA RID: 5338 RVA: 0x00059208 File Offset: 0x00057408
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			Emocion emocion = calculo.emocion;
			ReaccionHumana? reaccionHumana = ((emocion != null) ? new ReaccionHumana?(emocion.reaccion) : null);
			if (reaccionHumana == null)
			{
				return false;
			}
			int value = (int)reaccionHumana.Value;
			return ((int)this.paraReacciones).HasFlag(value);
		}

		// Token: 0x040010F2 RID: 4338
		public ReaccionHumana paraReacciones = ReaccionHumana.All;
	}
}

using System;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes.Holes
{
	// Token: 0x0200008E RID: 142
	public class HoleTemperature : CustomMonobehaviour
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x000216E7 File Offset: 0x0001F8E7
		public float currentTemp
		{
			get
			{
				return this.m_currentTemp;
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x000216F0 File Offset: 0x0001F8F0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_hole = base.GetComponent<IHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			this.m_TemperaturaCorporal = this.GetComponentEnRoot(false);
			if (this.m_TemperaturaCorporal == null)
			{
				throw new ArgumentNullException("m_TemperaturaCorporal", "m_TemperaturaCorporal null reference.");
			}
			IHole hole = this.m_hole;
			if (!(hole is IVagHole))
			{
				if (!(hole is IAnusHole))
				{
					if (!(hole is IBocaHole))
					{
						throw new ArgumentOutOfRangeException(this.m_hole.ToString());
					}
					this.m_parte = ParteDelCuerpoHumanoHole.bocaInterno;
				}
				else
				{
					this.m_parte = ParteDelCuerpoHumanoHole.ano;
				}
			}
			else
			{
				this.m_parte = ParteDelCuerpoHumanoHole.vag;
			}
			this.Generate(this.m_parte);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x000217B0 File Offset: 0x0001F9B0
		private void Generate(ParteDelCuerpoHumanoHole hole)
		{
			if (hole == ParteDelCuerpoHumanoHole.bocaInterno)
			{
				this.m_currentTemp = this.m_TemperaturaCorporal.currentTemp - 0.2f;
				return;
			}
			if (hole == ParteDelCuerpoHumanoHole.ano)
			{
				this.m_currentTemp = this.m_TemperaturaCorporal.currentTemp + 0.3f;
				return;
			}
			if (hole != ParteDelCuerpoHumanoHole.vag)
			{
				throw new ArgumentOutOfRangeException(hole.ToString());
			}
			this.m_currentTemp = this.m_TemperaturaCorporal.currentTemp + 0.3f;
		}

		// Token: 0x0400038F RID: 911
		private float m_currentTemp;

		// Token: 0x04000390 RID: 912
		private IHole m_hole;

		// Token: 0x04000391 RID: 913
		private ParteDelCuerpoHumanoHole m_parte;

		// Token: 0x04000392 RID: 914
		private TemperaturaCorporal m_TemperaturaCorporal;
	}
}

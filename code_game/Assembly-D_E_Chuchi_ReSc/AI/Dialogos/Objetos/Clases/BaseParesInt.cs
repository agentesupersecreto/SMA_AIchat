using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Dialogos.Objetos.Clases
{
	// Token: 0x02000553 RID: 1363
	public abstract class BaseParesInt<T_Par, T_Flag> where T_Par : BaseParInt<T_Flag>
	{
		// Token: 0x0600213E RID: 8510
		public abstract int GetInt(T_Flag flag);

		// Token: 0x0600213F RID: 8511 RVA: 0x0007BDE1 File Offset: 0x00079FE1
		public bool ContieneFlag(T_Flag flag, out T_Par par)
		{
			this.checkInit();
			return this.m_dicc.TryGetValue(this.GetInt(flag), out par);
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x0007BDFC File Offset: 0x00079FFC
		private void checkInit()
		{
			if (this.m_init)
			{
				return;
			}
			if (Application.isPlaying)
			{
				this.m_init = true;
			}
			this.m_dicc = new Dictionary<int, T_Par>();
			float num = float.MaxValue;
			foreach (T_Par t_Par in this.pares)
			{
				T_Par t_Par2;
				if (!this.m_dicc.TryGetValue(t_Par.GetInt(), out t_Par2))
				{
					this.m_dicc.Add(t_Par.GetInt(), t_Par);
					if (t_Par.puntaje <= 0f)
					{
						Debug.LogWarning(string.Concat(new string[]
						{
							"puntaje de par ",
							t_Par.GetType().Name,
							", de Config ",
							base.GetType().Name,
							" es zero, pusible error al momento de configurar"
						}));
					}
					if (t_Par.puntaje < num)
					{
						num = t_Par.puntaje;
					}
				}
			}
			if ((this.invertirFlags || this.pares.Count == 0) && this.cualquieraConfig.puntajeParaCualquiera == 0f)
			{
				Debug.LogWarning("puntaje para cualquiera es zero en mapa de: " + base.GetType().Name);
			}
		}

		// Token: 0x04001589 RID: 5513
		[Tooltip("para todos menos:")]
		public bool invertirFlags;

		// Token: 0x0400158A RID: 5514
		public BaseParesIntCualquieraConfig cualquieraConfig = new BaseParesIntCualquieraConfig();

		// Token: 0x0400158B RID: 5515
		[Range(0f, 1f)]
		public float modDePuntaje = 1f;

		// Token: 0x0400158C RID: 5516
		[SerializeField]
		[CoolArrayItem]
		protected List<T_Par> pares = new List<T_Par>();

		// Token: 0x0400158D RID: 5517
		private Dictionary<int, T_Par> m_dicc;

		// Token: 0x0400158E RID: 5518
		[NonSerialized]
		private bool m_init;
	}
}

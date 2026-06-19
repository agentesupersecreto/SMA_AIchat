using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Diccionarios
{
	// Token: 0x02000371 RID: 881
	public abstract class DiccionarioDeReaccionBase : ScriptableObject
	{
		// Token: 0x06001325 RID: 4901
		public abstract void ReordenarSegunChance();

		// Token: 0x06001326 RID: 4902
		public abstract void AutoGenerar();

		// Token: 0x06001327 RID: 4903
		public abstract void RemoverRepetidos();

		// Token: 0x06001328 RID: 4904
		public abstract void RemoverVacios();

		// Token: 0x04001005 RID: 4101
		public ReaccionHumana reaccion;

		// Token: 0x04001006 RID: 4102
		[TextArea]
		public string auto;

		// Token: 0x02000372 RID: 882
		public abstract class LineaDeTextoBase
		{
			// Token: 0x0600132A RID: 4906 RVA: 0x00053067 File Offset: 0x00051267
			public LineaDeTextoBase(string text)
			{
				this.texto = text;
			}

			// Token: 0x170004D7 RID: 1239
			// (get) Token: 0x0600132B RID: 4907 RVA: 0x00053081 File Offset: 0x00051281
			public float chanceMod
			{
				get
				{
					return this.chance / 100f;
				}
			}

			// Token: 0x0600132C RID: 4908 RVA: 0x0005308F File Offset: 0x0005128F
			public bool Proc()
			{
				return this.chance >= 100f || this.chance > Random.value * 100f;
			}

			// Token: 0x0600132D RID: 4909 RVA: 0x000530B4 File Offset: 0x000512B4
			public float Score()
			{
				if (this.chance >= 100f)
				{
					return 1f;
				}
				float num = Random.Range(this.chanceMod, 1f);
				if (this.Proc())
				{
					return num;
				}
				return num * this.chanceMod;
			}

			// Token: 0x04001007 RID: 4103
			public string texto;

			// Token: 0x04001008 RID: 4104
			[Range(0f, 100f)]
			public float chance = 50f;
		}
	}
}

using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200034D RID: 845
	[Serializable]
	public struct EmocionesHumanasValuesOld
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x0004F2A8 File Offset: 0x0004D4A8
		public static EmocionesHumanasValuesOld emptyValid
		{
			get
			{
				return new EmocionesHumanasValuesOld
				{
					m_loaded = true
				};
			}
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0004F2C8 File Offset: 0x0004D4C8
		internal EmocionesHumanasValuesOld(EmocionesHumanasBase emos)
		{
			this.m_loaded = true;
			this.alegria = emos.alegria.value.mod;
			this.fear = emos.fear.value.mod;
			this.placer = emos.placer.value.mod;
			this.dolor = emos.dolor.value.mod;
			this.decepcion = emos.decepcion.value.mod;
			this.boredom = emos.boredom.value.mod;
			this.rage = emos.rage.value.mod;
			this.alivio = emos.alivio.value.mod;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x0004F3A4 File Offset: 0x0004D5A4
		internal EmocionesHumanasValuesOld(EmocionesHumanasBase emos, bool NoLimitado)
		{
			this = new EmocionesHumanasValuesOld(emos);
			if (NoLimitado)
			{
				this.alegria = emos.alegria.valorNoLimitado / 100f;
				this.fear = emos.fear.valorNoLimitado / 100f;
				this.placer = emos.placer.valorNoLimitado / 100f;
				this.dolor = emos.dolor.valorNoLimitado / 100f;
				this.decepcion = emos.decepcion.valorNoLimitado / 100f;
				this.boredom = emos.boredom.valorNoLimitado / 100f;
				this.rage = emos.rage.valorNoLimitado / 100f;
				this.alivio = emos.alivio.valorNoLimitado / 100f;
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x0600123E RID: 4670 RVA: 0x0004F476 File Offset: 0x0004D676
		public bool loaded
		{
			get
			{
				return this.m_loaded;
			}
		}

		// Token: 0x04000F58 RID: 3928
		[SerializeField]
		private bool m_loaded;

		// Token: 0x04000F59 RID: 3929
		public float alegria;

		// Token: 0x04000F5A RID: 3930
		public float fear;

		// Token: 0x04000F5B RID: 3931
		public float placer;

		// Token: 0x04000F5C RID: 3932
		public float dolor;

		// Token: 0x04000F5D RID: 3933
		public float decepcion;

		// Token: 0x04000F5E RID: 3934
		public float boredom;

		// Token: 0x04000F5F RID: 3935
		public float rage;

		// Token: 0x04000F60 RID: 3936
		public float alivio;
	}
}

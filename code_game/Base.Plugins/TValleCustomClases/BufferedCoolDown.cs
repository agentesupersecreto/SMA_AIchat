using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000054 RID: 84
	[Serializable]
	public class BufferedCoolDown : IClearable
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0000D3B8 File Offset: 0x0000B5B8
		public void Reset()
		{
			this.m_tiempoDeComienzo = -1f;
			this.m_tiempoDeTermiando = -1f;
			this.m_tiempoDeLastCheck = 0f;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000D3DC File Offset: 0x0000B5DC
		public bool IsBuffered(bool signalExiste, out float bufferWeigth)
		{
			bufferWeigth = 1f;
			float num = Time.time - this.m_tiempoDeLastCheck;
			float num2 = Mathf.Clamp(this.bufferResetTime, Time.deltaTime * 2f, float.MaxValue);
			if (num > num2)
			{
				this.m_tiempoDeComienzo = -1f;
			}
			this.m_tiempoDeLastCheck = Time.time;
			bool flag;
			if (signalExiste)
			{
				if (this.m_tiempoDeComienzo < 0f)
				{
					this.m_tiempoDeComienzo = Time.time;
				}
				float num3 = Time.time - this.m_tiempoDeComienzo;
				flag = num3 < this.bufferTime;
				bufferWeigth = Mathf.InverseLerp(this.bufferTime, 0f, num3);
				this.m_tiempoDeTermiando = -1f;
			}
			else
			{
				if (this.m_tiempoDeTermiando < 0f)
				{
					this.m_tiempoDeTermiando = Time.time;
				}
				if (Time.time - this.m_tiempoDeTermiando >= this.bufferResetTime)
				{
					this.m_tiempoDeComienzo = -1f;
				}
				flag = true;
			}
			return flag;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000D4BD File Offset: 0x0000B6BD
		public void Clear()
		{
			this.bufferTime = 1f;
			this.bufferResetTime = 0.25f;
			this.Reset();
		}

		// Token: 0x04000090 RID: 144
		public float bufferTime = 1f;

		// Token: 0x04000091 RID: 145
		public float bufferResetTime = 0.25f;

		// Token: 0x04000092 RID: 146
		[ReadOnlyUI]
		[SerializeField]
		private float m_tiempoDeComienzo = -1f;

		// Token: 0x04000093 RID: 147
		[ReadOnlyUI]
		[SerializeField]
		private float m_tiempoDeTermiando = -1f;

		// Token: 0x04000094 RID: 148
		[ReadOnlyUI]
		[SerializeField]
		private float m_tiempoDeLastCheck;
	}
}

using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos.Abstractos
{
	// Token: 0x020001E7 RID: 487
	[Serializable]
	public class RansgoDePersonalidadPuntajeInfo
	{
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00034697 File Offset: 0x00032897
		public static RansgoDePersonalidadPuntajeInfo @default
		{
			get
			{
				return RansgoDePersonalidadPuntajeInfo.m_default;
			}
		}

		// Token: 0x04000945 RID: 2373
		private static RansgoDePersonalidadPuntajeInfo m_default = new RansgoDePersonalidadPuntajeInfo
		{
			puntaje = 50f
		};

		// Token: 0x04000946 RID: 2374
		public PersonalidadRasgo rasgo;

		// Token: 0x04000947 RID: 2375
		[Range(0f, 100f)]
		public float puntaje = 50f;
	}
}

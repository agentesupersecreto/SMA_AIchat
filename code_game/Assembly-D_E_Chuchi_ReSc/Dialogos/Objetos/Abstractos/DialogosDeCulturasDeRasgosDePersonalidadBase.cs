using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos.Objetos.Abstractos
{
	// Token: 0x020001E5 RID: 485
	public abstract class DialogosDeCulturasDeRasgosDePersonalidadBase<T_dialogos, T_dialogoInfo> : SimpleHolderDeDialogosDeCulturas<T_dialogos, T_dialogoInfo> where T_dialogos : ListaDeDialogos<T_dialogoInfo> where T_dialogoInfo : DialogoInfo, new()
	{
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x000344DF File Offset: 0x000326DF
		public ICollection<int> rasgosQContiene
		{
			get
			{
				this.CheckInit();
				return this.m_dic.Keys;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x000344F2 File Offset: 0x000326F2
		public override bool paraCualquierRasgo
		{
			get
			{
				return this.cualquierRasgo;
			}
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x000344FA File Offset: 0x000326FA
		public override bool ContieneRasgo(PersonalidadRasgo rasgo)
		{
			this.CheckInit();
			return this.cualquierRasgo || this.m_dic.ContainsKey(rasgo);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00034518 File Offset: 0x00032718
		[Obsolete("TODO: alterar el puntajeBuscando con las emociones del character")]
		public override bool Proc(PersonalidadRasgo rasgo, float puntajeBuscando, out float score)
		{
			score = 0f;
			this.CheckInit();
			if (!this.ContieneRasgo(rasgo))
			{
				return false;
			}
			float num = 1f;
			RansgoDePersonalidadPuntajeInfo ransgoDePersonalidadPuntajeInfo;
			float num2;
			if (!this.m_dic.TryGetValue(rasgo, out ransgoDePersonalidadPuntajeInfo))
			{
				num2 = 50f;
				num = this.scoreModificadorParaCualquierRasgo;
			}
			else
			{
				num2 = ransgoDePersonalidadPuntajeInfo.puntaje;
			}
			float num3 = Mathf.Clamp01(Mathf.Abs(puntajeBuscando - num2) / 100f);
			float num4 = Mathf.Clamp01(Mathf.Abs(puntajeBuscando - 50f) / 100f);
			if ((double)num3 < 0.05)
			{
				score = num;
				return true;
			}
			float num5 = Mathf.Lerp(0.15f, 0.51f, num4 * 2f);
			if (num3 >= num5)
			{
				return false;
			}
			num3 = 1f - num3;
			score = num3 * num;
			num3 = num3.OutPow(2f);
			return num3 >= Random.value;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x000345EC File Offset: 0x000327EC
		private void CheckInit()
		{
			if (this.m_init)
			{
				return;
			}
			if (Application.isPlaying)
			{
				this.m_init = true;
			}
			this.m_dic = new DiccionaryEnum<PersonalidadRasgo, RansgoDePersonalidadPuntajeInfo>((PersonalidadRasgo i) => (int)i);
			foreach (RansgoDePersonalidadPuntajeInfo ransgoDePersonalidadPuntajeInfo in this.m_rasgosInfo)
			{
				if (!this.m_dic.ContainsKey(ransgoDePersonalidadPuntajeInfo.rasgo))
				{
					this.m_dic.Add(ransgoDePersonalidadPuntajeInfo.rasgo, ransgoDePersonalidadPuntajeInfo);
				}
			}
		}

		// Token: 0x0400093E RID: 2366
		public bool cualquierRasgo;

		// Token: 0x0400093F RID: 2367
		[Range(0f, 1f)]
		[NonSerialized]
		public float scoreModificadorParaCualquierRasgo = 0.66f;

		// Token: 0x04000940 RID: 2368
		[SerializeField]
		[CoolArrayItem]
		private RansgoDePersonalidadPuntajeInfo[] m_rasgosInfo;

		// Token: 0x04000941 RID: 2369
		private DiccionaryEnum<PersonalidadRasgo, RansgoDePersonalidadPuntajeInfo> m_dic;

		// Token: 0x04000942 RID: 2370
		[NonSerialized]
		private bool m_init;
	}
}

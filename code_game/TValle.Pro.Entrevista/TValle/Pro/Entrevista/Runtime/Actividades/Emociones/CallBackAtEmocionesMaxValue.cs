using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades.Emociones
{
	// Token: 0x02000143 RID: 323
	public class CallBackAtEmocionesMaxValue : CustomMonobehaviour
	{
		// Token: 0x06000B40 RID: 2880 RVA: 0x0003A998 File Offset: 0x00038B98
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_emociones = this.GetComponentEnRoot(false);
			if (this.m_emociones == null)
			{
				throw new ArgumentNullException("m_emociones", "m_emociones null reference.");
			}
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0003AA00 File Offset: 0x00038C00
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			foreach (object obj in typeof(ReaccionHumana).GetEnumValoresObject())
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)obj;
				Emocion emocion = this.m_emociones.ObtenerEmocion(reaccionHumana);
				if (emocion != null)
				{
					emocion.onMaxValue += this.M_emocion_onMaxValue;
				}
			}
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0003AA8C File Offset: 0x00038C8C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_emociones != null)
			{
				foreach (object obj in typeof(ReaccionHumana).GetEnumValoresObject())
				{
					ReaccionHumana reaccionHumana = (ReaccionHumana)obj;
					Emocion emocion = this.m_emociones.ObtenerEmocion(reaccionHumana);
					if (emocion != null)
					{
						emocion.onMaxValue -= this.M_emocion_onMaxValue;
					}
				}
			}
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0003AB24 File Offset: 0x00038D24
		private void M_emocion_onMaxValue(Emocion obj)
		{
			Singleton<ActividadesManager>.instance.OnEmotionMaxValue(this.m_character, obj);
		}

		// Token: 0x0400057C RID: 1404
		private EmocionesHumanasBase m_emociones;

		// Token: 0x0400057D RID: 1405
		private Character m_character;
	}
}

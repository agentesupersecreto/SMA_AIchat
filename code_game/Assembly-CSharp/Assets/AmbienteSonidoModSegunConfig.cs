using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000041 RID: 65
	[RequireComponent(typeof(AudioSource))]
	public class AmbienteSonidoModSegunConfig : MonoBehaviour
	{
		// Token: 0x06000141 RID: 321 RVA: 0x0000B494 File Offset: 0x00009694
		private void Awake()
		{
			this.m_AudioSource = base.GetComponent<AudioSource>();
			this.m_initialVolumen = this.m_AudioSource.volume;
			this.m_AudioSource.Stop();
			float num = Random.Range(0f, this.m_AudioSource.clip.length);
			this.m_AudioSource.time = num;
			this.m_AudioSource.Play();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000B4FB File Offset: 0x000096FB
		private void Update()
		{
			this.m_AudioSource.volume = this.m_initialVolumen * Singleton<ConfiguracionGeneralDeAudio>.instance.ambiente;
		}

		// Token: 0x040000AF RID: 175
		private AudioSource m_AudioSource;

		// Token: 0x040000B0 RID: 176
		[SerializeField]
		private float m_initialVolumen;
	}
}

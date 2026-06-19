using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200034C RID: 844
	[Serializable]
	public struct EmocionesHumanasValues
	{
		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x0004ECD0 File Offset: 0x0004CED0
		public static EmocionesHumanasValues emptyValid
		{
			get
			{
				return new EmocionesHumanasValues
				{
					m_loaded = true
				};
			}
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x0004ECF0 File Offset: 0x0004CEF0
		internal EmocionesHumanasValues(EmocionesHumanasBase emos)
		{
			this.m_loaded = true;
			Alegria alegria = emos.alegria;
			this.alegria = ((alegria != null) ? new float?(alegria.value.mod) : null).GetValueOrDefault();
			Fear fear = emos.fear;
			this.fear = ((fear != null) ? new float?(fear.value.mod) : null).GetValueOrDefault();
			PlacerBase placerBase = emos.placer;
			this.placer = ((placerBase != null) ? new float?(placerBase.value.mod) : null).GetValueOrDefault();
			Dolor dolor = emos.dolor;
			this.dolor = ((dolor != null) ? new float?(dolor.value.mod) : null).GetValueOrDefault();
			Decepcion decepcion = emos.decepcion;
			this.decepcion = ((decepcion != null) ? new float?(decepcion.value.mod) : null).GetValueOrDefault();
			Boredom boredom = emos.boredom;
			this.boredom = ((boredom != null) ? new float?(boredom.value.mod) : null).GetValueOrDefault();
			Rage rage = emos.rage;
			this.rage = ((rage != null) ? new float?(rage.value.mod) : null).GetValueOrDefault();
			Alivio alivio = emos.alivio;
			this.alivio = ((alivio != null) ? new float?(alivio.value.mod) : null).GetValueOrDefault();
			if (emos is IEmocionesMasculinas)
			{
				IEmocionesMasculinas emocionesMasculinas = (IEmocionesMasculinas)emos;
				AscoBase ascoBase = emocionesMasculinas.asco;
				this.asco = ((ascoBase != null) ? new float?(ascoBase.value.mod) : null).GetValueOrDefault();
			}
			else
			{
				this.asco = 0f;
			}
			if (emos is EmocionesFemeninasBase)
			{
				EmocionesFemeninasBase emocionesFemeninasBase = (EmocionesFemeninasBase)emos;
				Arousal arousal = emocionesFemeninasBase.arousal;
				this.arousal = ((arousal != null) ? new float?(arousal.value.mod) : null).GetValueOrDefault();
				ConsentToHero consentToHero = emocionesFemeninasBase.consentToHero;
				this.consentToHero = ((consentToHero != null) ? new float?(consentToHero.value.mod) : null).GetValueOrDefault();
				DesHielo desHielo = emocionesFemeninasBase.desHielo;
				this.desHielo = ((desHielo != null) ? new float?(desHielo.value.mod) : null).GetValueOrDefault();
				return;
			}
			this.arousal = 0f;
			this.consentToHero = 0f;
			this.desHielo = 0f;
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0004EFD0 File Offset: 0x0004D1D0
		internal EmocionesHumanasValues(EmocionesHumanasBase emos, bool NoLimitado)
		{
			this = new EmocionesHumanasValues(emos);
			if (NoLimitado)
			{
				Alegria alegria = emos.alegria;
				this.alegria = ((alegria != null) ? new float?(alegria.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Fear fear = emos.fear;
				this.fear = ((fear != null) ? new float?(fear.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				PlacerBase placerBase = emos.placer;
				this.placer = ((placerBase != null) ? new float?(placerBase.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Dolor dolor = emos.dolor;
				this.dolor = ((dolor != null) ? new float?(dolor.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Decepcion decepcion = emos.decepcion;
				this.decepcion = ((decepcion != null) ? new float?(decepcion.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Boredom boredom = emos.boredom;
				this.boredom = ((boredom != null) ? new float?(boredom.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Rage rage = emos.rage;
				this.rage = ((rage != null) ? new float?(rage.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				Alivio alivio = emos.alivio;
				this.alivio = ((alivio != null) ? new float?(alivio.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				if (emos is IEmocionesMasculinas)
				{
					IEmocionesMasculinas emocionesMasculinas = (IEmocionesMasculinas)emos;
					AscoBase ascoBase = emocionesMasculinas.asco;
					this.asco = ((ascoBase != null) ? new float?(ascoBase.valorNoLimitado) : null).GetValueOrDefault() / 100f;
				}
				else
				{
					this.asco = 0f;
				}
				if (emos is EmocionesFemeninasBase)
				{
					EmocionesFemeninasBase emocionesFemeninasBase = (EmocionesFemeninasBase)emos;
					Arousal arousal = emocionesFemeninasBase.arousal;
					this.arousal = ((arousal != null) ? new float?(arousal.valorNoLimitado) : null).GetValueOrDefault() / 100f;
					ConsentToHero consentToHero = emocionesFemeninasBase.consentToHero;
					this.consentToHero = ((consentToHero != null) ? new float?(consentToHero.valorNoLimitado) : null).GetValueOrDefault() / 100f;
					DesHielo desHielo = emocionesFemeninasBase.desHielo;
					this.desHielo = ((desHielo != null) ? new float?(desHielo.valorNoLimitado) : null).GetValueOrDefault() / 100f;
					return;
				}
				this.arousal = 0f;
				this.consentToHero = 0f;
				this.desHielo = 0f;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x0600123A RID: 4666 RVA: 0x0004F29E File Offset: 0x0004D49E
		public bool loaded
		{
			get
			{
				return this.m_loaded;
			}
		}

		// Token: 0x04000F4B RID: 3915
		[SerializeField]
		private bool m_loaded;

		// Token: 0x04000F4C RID: 3916
		public float alegria;

		// Token: 0x04000F4D RID: 3917
		public float fear;

		// Token: 0x04000F4E RID: 3918
		public float placer;

		// Token: 0x04000F4F RID: 3919
		public float dolor;

		// Token: 0x04000F50 RID: 3920
		public float decepcion;

		// Token: 0x04000F51 RID: 3921
		public float boredom;

		// Token: 0x04000F52 RID: 3922
		public float rage;

		// Token: 0x04000F53 RID: 3923
		public float alivio;

		// Token: 0x04000F54 RID: 3924
		[Header("fem")]
		public float arousal;

		// Token: 0x04000F55 RID: 3925
		public float consentToHero;

		// Token: 0x04000F56 RID: 3926
		public float desHielo;

		// Token: 0x04000F57 RID: 3927
		[Header("male")]
		public float asco;
	}
}

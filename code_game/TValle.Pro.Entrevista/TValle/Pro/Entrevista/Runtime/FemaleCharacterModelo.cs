using System;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Animations;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime
{
	// Token: 0x02000029 RID: 41
	public class FemaleCharacterModelo : CustomMonobehaviour, IFemeninityWeightProducer
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000196 RID: 406 RVA: 0x000094DE File Offset: 0x000076DE
		public ModificableDeFloat modelingExpModificable
		{
			get
			{
				return this.m_modelingExpModificable;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000094E6 File Offset: 0x000076E6
		public float femeninity
		{
			get
			{
				this.m_lastModelingExp = this.GetModelingExp();
				this.m_lastFemeninity = Mathf.InverseLerp(0.5f, 2.5f, this.m_lastModelingExp);
				return this.m_lastFemeninity;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00009515 File Offset: 0x00007715
		public float prom
		{
			get
			{
				return this.femeninity;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000951D File Offset: 0x0000771D
		public float adding
		{
			get
			{
				return this.m_FemeninityAddOverride;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00009525 File Offset: 0x00007725
		public float modding
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000952C File Offset: 0x0000772C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			if (this.m_character.isMemoryLoaded || this.m_Personalidad.isStared)
			{
				throw new NotSupportedException("character debe cargarse al mismo tiempo");
			}
			this.m_character.charMemoryJustLoaded += this.CharMemoryJustLoaded;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000095D1 File Offset: 0x000077D1
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000095DC File Offset: 0x000077DC
		private void CharMemoryJustLoaded(Character obj)
		{
			this.m_defaultModelingExp += this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			this.m_defaultModelingExp += this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore();
			this.m_defaultModelingExp += this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore();
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00009648 File Offset: 0x00007848
		public float GetDesiredComisionByPobrezaYAvaricia()
		{
			float num = 1f - this.m_Personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
			float weigthDeScore = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
			float num2 = num * 0.25f + weigthDeScore * 0.75f;
			float num3 = Mathf.Lerp(30f, 80f, num2);
			float weigthDeScore2 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			float weigthDeScore3 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore();
			float weigthDeScore4 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore();
			float num4 = weigthDeScore2 * 0.2f + weigthDeScore3 * 0.3f + weigthDeScore4 * 0.5f;
			float num5 = MathfExtension.LerpConMedio(num3 * 0.875f, num3, num3 * 1.0625f, num4);
			float weigthDeScore5 = this.m_Personalidad.GetTraitScore(TraitHumano.inteligencia).GetWeigthDeScore();
			num3 = Mathf.Lerp(num5 * 0.875f, num5 * 1.0588235f, weigthDeScore5);
			return (float)Mathf.RoundToInt(num3);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00009740 File Offset: 0x00007940
		public float GetDesiredSalaryByPobrezaYAvaricia()
		{
			float num = 1f - this.m_Personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
			float weigthDeScore = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
			float num2 = num * 0.25f + weigthDeScore * 0.75f;
			float num3 = Mathf.Lerp(100f, 1000f, num2);
			float weigthDeScore2 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			float weigthDeScore3 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore();
			float weigthDeScore4 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore();
			float num4 = weigthDeScore2 * 0.2f + weigthDeScore3 * 0.3f + weigthDeScore4 * 0.5f;
			float num5 = MathfExtension.LerpConMedio(num3 * 0.9f, num3, num3 * 1.1f, num4);
			float weigthDeScore5 = this.m_Personalidad.GetTraitScore(TraitHumano.inteligencia).GetWeigthDeScore();
			num3 = Mathf.Lerp(num5 * 0.9f, num5 * 1.090909f, weigthDeScore5);
			return Mathf.Round(num3 / 5f) * 5f;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00009840 File Offset: 0x00007A40
		public float GetDesiredComisionByGustosModelaje()
		{
			float weigthDeScore = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			float weigthDeScore2 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore();
			float weigthDeScore3 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore();
			float num = weigthDeScore * 0.2f + weigthDeScore2 * 0.3f + weigthDeScore3 * 0.5f;
			float num2 = Mathf.Lerp(30f, 80f, num);
			float weigthDeScore4 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
			float num3 = MathfExtension.LerpConMedio(num2 * 0.8888f, num2, num2 * 1.125f, weigthDeScore4);
			float weigthDeScore5 = this.m_Personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
			float num4 = Mathf.Lerp(num3, num3 * 0.75f, weigthDeScore5);
			float weigthDeScore6 = this.m_Personalidad.GetTraitScore(TraitHumano.inteligencia).GetWeigthDeScore();
			return (float)Mathf.RoundToInt(Mathf.Lerp(num4, num4 * 1.05555f, weigthDeScore6));
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00009924 File Offset: 0x00007B24
		public float GetDesiredSalaryByGustosModelaje()
		{
			float weigthDeScore = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			float weigthDeScore2 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore();
			float weigthDeScore3 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore();
			float num = weigthDeScore * 0.2f + weigthDeScore2 * 0.3f + weigthDeScore3 * 0.5f;
			float num2 = Mathf.Lerp(100f, 1000f, num);
			float weigthDeScore4 = this.m_Personalidad.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore();
			float num3 = MathfExtension.LerpConMedio(num2 * 0.8f, num2, num2 * 1.25f, weigthDeScore4);
			float weigthDeScore5 = this.m_Personalidad.GetTraitScore(TraitHumano.pobreza).GetWeigthDeScore();
			float num4 = Mathf.Lerp(num3, num3 * 0.5f, weigthDeScore5);
			float weigthDeScore6 = this.m_Personalidad.GetTraitScore(TraitHumano.inteligencia).GetWeigthDeScore();
			return Mathf.Round(Mathf.Lerp(num4, num3 * 1.2f, weigthDeScore6) / 5f) * 5f;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00009A18 File Offset: 0x00007C18
		public float GetModelingExp()
		{
			return this.m_modelingExpModificable.ModificarValor(this.m_defaultModelingExp + MemoriaDeSMAModelosFemeninas.TryGetModelingExp(GlobalSingletonV2<MemoriaJson>.instance, this.m_character.ID_Unico.ToString(), 0f));
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00009A5F File Offset: 0x00007C5F
		public int GetModelingExpInt()
		{
			return Mathf.FloorToInt(this.GetModelingExp());
		}

		// Token: 0x040000EC RID: 236
		private FemaleChar m_character;

		// Token: 0x040000ED RID: 237
		private Personalidad m_Personalidad;

		// Token: 0x040000EE RID: 238
		private ModificableDeFloat m_modelingExpModificable = new ModificableDeFloat(1f);

		// Token: 0x040000EF RID: 239
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultModelingExp;

		// Token: 0x040000F0 RID: 240
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastFemeninity;

		// Token: 0x040000F1 RID: 241
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastModelingExp;

		// Token: 0x040000F2 RID: 242
		[SerializeField]
		private float m_FemeninityAddOverride;
	}
}

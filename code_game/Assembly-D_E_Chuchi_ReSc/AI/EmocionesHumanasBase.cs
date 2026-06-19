using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000350 RID: 848
	public abstract class EmocionesHumanasBase : AplicableBehaviour
	{
		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06001249 RID: 4681 RVA: 0x0004F5A4 File Offset: 0x0004D7A4
		public bool reportToProfiler
		{
			get
			{
				return this.profileDebug && (Application.isEditor || Debug.isDebugBuild);
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x0600124A RID: 4682 RVA: 0x0004F5BE File Offset: 0x0004D7BE
		public ICharacter owner
		{
			get
			{
				return this.m_ICharacter;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x0600124B RID: 4683
		public abstract Alegria alegria { get; }

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x0600124C RID: 4684
		public abstract Fear fear { get; }

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x0600124D RID: 4685
		public abstract PlacerBase placer { get; }

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x0600124E RID: 4686
		public abstract Dolor dolor { get; }

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x0600124F RID: 4687
		public abstract Decepcion decepcion { get; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001250 RID: 4688
		public abstract Boredom boredom { get; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06001251 RID: 4689
		public abstract Rage rage { get; }

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001252 RID: 4690
		public abstract Alivio alivio { get; }

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06001253 RID: 4691 RVA: 0x0004F5C8 File Offset: 0x0004D7C8
		// (remove) Token: 0x06001254 RID: 4692 RVA: 0x0004F600 File Offset: 0x0004D800
		public event Action<EmocionesHumanasBase> updateEmociones2Base;

		// Token: 0x06001255 RID: 4693 RVA: 0x0004F635 File Offset: 0x0004D835
		protected void CalleEvent_UpdateEmociones2Base()
		{
			Action<EmocionesHumanasBase> action = this.updateEmociones2Base;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x0004F648 File Offset: 0x0004D848
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
		}

		// Token: 0x06001257 RID: 4695
		public abstract Emocion ObtenerEmocion(ReaccionHumana reaccion);

		// Token: 0x06001258 RID: 4696 RVA: 0x0004F675 File Offset: 0x0004D875
		public EmocionesHumanasValues ObtenerModsHumanos()
		{
			return new EmocionesHumanasValues(this);
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x0004F67D File Offset: 0x0004D87D
		public EmocionesHumanasValuesOld ObtenerModsHumanosOld()
		{
			return new EmocionesHumanasValuesOld(this);
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x0004F685 File Offset: 0x0004D885
		public EmocionesHumanasValues ObtenerModsHumanos(bool NoLimitado)
		{
			return new EmocionesHumanasValues(this, NoLimitado);
		}

		// Token: 0x04000F66 RID: 3942
		[SerializeField]
		private bool profileDebug;

		// Token: 0x04000F67 RID: 3943
		[HideInInspector]
		[Obsolete("", true)]
		public float modificadorDeEmociones = 1f;

		// Token: 0x04000F68 RID: 3944
		private ICharacter m_ICharacter;

		// Token: 0x02000351 RID: 849
		[Serializable]
		public class Config
		{
			// Token: 0x04000F6A RID: 3946
			public EmocionesHumanasBase.Config.LimitesDeEmociones limitesDeEmociones = new EmocionesHumanasBase.Config.LimitesDeEmociones();

			// Token: 0x02000352 RID: 850
			[Serializable]
			public class LimitesDeEmociones
			{
				// Token: 0x0600125D RID: 4701 RVA: 0x0004F6B4 File Offset: 0x0004D8B4
				public void SetLimiteMax(ReaccionHumana reacc, float limite)
				{
					if (reacc <= ReaccionHumana.miedo)
					{
						if (reacc <= ReaccionHumana.placer)
						{
							switch (reacc)
							{
							case ReaccionHumana.None:
								return;
							case ReaccionHumana.concentToHero:
								this.concentToHero.max = limite;
								return;
							case ReaccionHumana.asombro:
							case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
							case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
							case ReaccionHumana.asombro | ReaccionHumana.dolor:
							case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
								break;
							case ReaccionHumana.dolor:
								this.dolor.max = limite;
								return;
							case ReaccionHumana.rabia:
								this.rage.max = limite;
								return;
							default:
								if (reacc == ReaccionHumana.asco)
								{
									this.asco.max = limite;
									return;
								}
								if (reacc == ReaccionHumana.placer)
								{
									this.placer.max = limite;
									return;
								}
								break;
							}
						}
						else
						{
							if (reacc == ReaccionHumana.arousal)
							{
								this.arousal.max = limite;
								return;
							}
							if (reacc != ReaccionHumana.tristeza)
							{
								if (reacc == ReaccionHumana.miedo)
								{
									this.miedo.max = limite;
									return;
								}
							}
						}
					}
					else if (reacc <= ReaccionHumana.decepcion)
					{
						if (reacc == ReaccionHumana.alegria)
						{
							this.alegria.max = limite;
							return;
						}
						if (reacc != ReaccionHumana.felicidad)
						{
							if (reacc == ReaccionHumana.decepcion)
							{
								this.decepcion.max = limite;
								return;
							}
						}
					}
					else
					{
						if (reacc == ReaccionHumana.alivio)
						{
							this.alivio.max = limite;
							return;
						}
						if (reacc == ReaccionHumana.aburrimiento)
						{
							this.aburrimiento.max = limite;
							return;
						}
						if (reacc == ReaccionHumana.desHielo)
						{
							this.desHielo.max = limite;
							return;
						}
					}
					throw new ArgumentOutOfRangeException(reacc.ToString());
				}

				// Token: 0x0600125E RID: 4702 RVA: 0x0004F82C File Offset: 0x0004DA2C
				public void SetLimiteMin(ReaccionHumana reacc, float limite)
				{
					if (reacc <= ReaccionHumana.miedo)
					{
						if (reacc <= ReaccionHumana.placer)
						{
							switch (reacc)
							{
							case ReaccionHumana.None:
								return;
							case ReaccionHumana.concentToHero:
								this.concentToHero.min = limite;
								return;
							case ReaccionHumana.asombro:
							case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
							case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
							case ReaccionHumana.asombro | ReaccionHumana.dolor:
							case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
								break;
							case ReaccionHumana.dolor:
								this.dolor.min = limite;
								return;
							case ReaccionHumana.rabia:
								this.rage.min = limite;
								return;
							default:
								if (reacc == ReaccionHumana.asco)
								{
									this.asco.min = limite;
									return;
								}
								if (reacc == ReaccionHumana.placer)
								{
									this.placer.min = limite;
									return;
								}
								break;
							}
						}
						else
						{
							if (reacc == ReaccionHumana.arousal)
							{
								this.arousal.min = limite;
								return;
							}
							if (reacc != ReaccionHumana.tristeza)
							{
								if (reacc == ReaccionHumana.miedo)
								{
									this.miedo.min = limite;
									return;
								}
							}
						}
					}
					else if (reacc <= ReaccionHumana.decepcion)
					{
						if (reacc == ReaccionHumana.alegria)
						{
							this.alegria.min = limite;
							return;
						}
						if (reacc != ReaccionHumana.felicidad)
						{
							if (reacc == ReaccionHumana.decepcion)
							{
								this.decepcion.min = limite;
								return;
							}
						}
					}
					else
					{
						if (reacc == ReaccionHumana.alivio)
						{
							this.alivio.min = limite;
							return;
						}
						if (reacc == ReaccionHumana.aburrimiento)
						{
							this.aburrimiento.min = limite;
							return;
						}
						if (reacc == ReaccionHumana.desHielo)
						{
							this.desHielo.min = limite;
							return;
						}
					}
					throw new ArgumentOutOfRangeException(reacc.ToString());
				}

				// Token: 0x04000F6B RID: 3947
				public EmocionesHumanasBase.Config.Limite placer = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F6C RID: 3948
				public EmocionesHumanasBase.Config.Limite rage = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F6D RID: 3949
				public EmocionesHumanasBase.Config.Limite dolor = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F6E RID: 3950
				public EmocionesHumanasBase.Config.Limite concentToHero = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F6F RID: 3951
				public EmocionesHumanasBase.Config.Limite miedo = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F70 RID: 3952
				public EmocionesHumanasBase.Config.Limite aburrimiento = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F71 RID: 3953
				public EmocionesHumanasBase.Config.Limite arousal = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F72 RID: 3954
				public EmocionesHumanasBase.Config.Limite alivio = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F73 RID: 3955
				public EmocionesHumanasBase.Config.Limite alegria = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F74 RID: 3956
				public EmocionesHumanasBase.Config.Limite desHielo = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F75 RID: 3957
				public EmocionesHumanasBase.Config.Limite decepcion = new EmocionesHumanasBase.Config.Limite(100f);

				// Token: 0x04000F76 RID: 3958
				public EmocionesHumanasBase.Config.Limite asco = new EmocionesHumanasBase.Config.Limite(100f);
			}

			// Token: 0x02000353 RID: 851
			[Serializable]
			public struct Limite
			{
				// Token: 0x06001260 RID: 4704 RVA: 0x0004FA77 File Offset: 0x0004DC77
				public Limite(float max)
				{
					this.m_min = 0f;
					this.m_max = 100f;
					this.max = max;
					this.min = 0f;
				}

				// Token: 0x1700048B RID: 1163
				// (get) Token: 0x06001261 RID: 4705 RVA: 0x0004FAA1 File Offset: 0x0004DCA1
				// (set) Token: 0x06001262 RID: 4706 RVA: 0x0004FAA9 File Offset: 0x0004DCA9
				public float min
				{
					get
					{
						return this.m_min;
					}
					set
					{
						this.m_min = Mathf.Clamp(value, 0f, 100f);
					}
				}

				// Token: 0x1700048C RID: 1164
				// (get) Token: 0x06001263 RID: 4707 RVA: 0x0004FAC1 File Offset: 0x0004DCC1
				// (set) Token: 0x06001264 RID: 4708 RVA: 0x0004FAC9 File Offset: 0x0004DCC9
				public float max
				{
					get
					{
						return this.m_max;
					}
					set
					{
						this.m_max = Mathf.Clamp(value, 0f, 100f);
					}
				}

				// Token: 0x06001265 RID: 4709 RVA: 0x0004FAE4 File Offset: 0x0004DCE4
				public void Limitar(ref PorcentageModificable value)
				{
					if (this.m_min > this.m_max)
					{
						this.m_min = this.m_max;
					}
					float total = value.total;
					if (total > this.m_max)
					{
						value = default(PorcentageModificable);
						value.moded = this.m_max;
						return;
					}
					if (total < this.m_min)
					{
						value = default(PorcentageModificable);
						value.moded = this.m_min;
					}
				}

				// Token: 0x04000F77 RID: 3959
				[SerializeField]
				private float m_min;

				// Token: 0x04000F78 RID: 3960
				[SerializeField]
				private float m_max;
			}
		}
	}
}

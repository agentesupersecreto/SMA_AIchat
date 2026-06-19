using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002C6 RID: 710
	public abstract class Emocion : AplicableBehaviour, IActivable
	{
		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x0004828C File Offset: 0x0004648C
		// (set) Token: 0x06000FC7 RID: 4039 RVA: 0x00048294 File Offset: 0x00046494
		public bool activado
		{
			get
			{
				return this.m_activado;
			}
			set
			{
				this.m_activado = value;
			}
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x000482A0 File Offset: 0x000464A0
		public static double APrioridad(Emocion emo)
		{
			if (emo == null)
			{
				return 1.0;
			}
			ReaccionHumana reaccion = emo.reaccion;
			if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion <= ReaccionHumana.placer)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
						return 1.0;
					case ReaccionHumana.concentToHero:
						return 8.0;
					case ReaccionHumana.asombro:
						return 20.0;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						break;
					case ReaccionHumana.dolor:
						return 90.0;
					case ReaccionHumana.rabia:
						return 95.0;
					default:
						if (reaccion == ReaccionHumana.asco)
						{
							return 85.0;
						}
						if (reaccion == ReaccionHumana.placer)
						{
							return 9.0;
						}
						break;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.arousal)
					{
						return 10.0;
					}
					if (reaccion == ReaccionHumana.tristeza)
					{
						return 70.0;
					}
					if (reaccion == ReaccionHumana.miedo)
					{
						return 100.0;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.decepcion)
			{
				if (reaccion == ReaccionHumana.alegria)
				{
					return 7.0;
				}
				if (reaccion == ReaccionHumana.felicidad)
				{
					return 6.0;
				}
				if (reaccion == ReaccionHumana.decepcion)
				{
					return 80.0;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.alivio)
				{
					return 5.0;
				}
				if (reaccion == ReaccionHumana.aburrimiento)
				{
					return 75.0;
				}
				if (reaccion == ReaccionHumana.desHielo)
				{
					return 4.0;
				}
			}
			throw new ArgumentOutOfRangeException(emo.reaccion.ToString());
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0004843A File Offset: 0x0004663A
		[Obsolete("usar metodo especializado", true)]
		public float modificadorDeAumentoDeEmocion
		{
			get
			{
				return this.modificadorDeAumentoDeEmocionPorPersonalidad * this.m_modificadorDeEmocion;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00048449 File Offset: 0x00046649
		[Obsolete("usar metodo especializado", true)]
		public float modificadorDeDisminucionEmocion
		{
			get
			{
				return this.modificadorDeDisminucionEmocionPorPersonalidad * this.m_modificadorDeEmocion;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000FCB RID: 4043
		protected abstract float modificadorDeAumentoDeEmocionPorPersonalidad { get; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000FCC RID: 4044
		protected abstract float modificadorDeDisminucionEmocionPorPersonalidad { get; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000FCD RID: 4045
		protected abstract bool limiteMinimoPuedeAlcanzar100 { get; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000FCE RID: 4046
		public abstract float prioridad { get; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000FCF RID: 4047 RVA: 0x00048458 File Offset: 0x00046658
		public PercentageInv value
		{
			get
			{
				return this.m_Percentage;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x00048460 File Offset: 0x00046660
		public float valorNoLimitado
		{
			get
			{
				return this.m_clampedValor;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x00048468 File Offset: 0x00046668
		public float limiteMinimo1
		{
			get
			{
				return this.m_limiteMinimo;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x00048470 File Offset: 0x00046670
		public float limiteMinimo2
		{
			get
			{
				return this.m_limiteMinimoSumado;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x00048478 File Offset: 0x00046678
		public float limiteMaximo
		{
			get
			{
				return this.m_limiteMaximo;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x00048480 File Offset: 0x00046680
		public bool valueAtMax
		{
			get
			{
				return this.m_valueAtMax;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x00048488 File Offset: 0x00046688
		public bool currentFrameIsValueAtMax
		{
			get
			{
				return this.m_currentFrameIsValueAtMax;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x00048490 File Offset: 0x00046690
		public ModificableDeFloat sumadorDeValor
		{
			get
			{
				return this.m_sumadorDeValor;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x00048498 File Offset: 0x00046698
		public ModificableDeFloat multiplicadorDeValor
		{
			get
			{
				return this.m_multiplicadorDeValor;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x000484A0 File Offset: 0x000466A0
		public ModificableDeFloat minimoLimiteValor
		{
			get
			{
				return this.m_minimoLimiteValor;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x000484A8 File Offset: 0x000466A8
		public ModificableDeFloat minimoLimiteValorSumado
		{
			get
			{
				return this.m_minimoLimiteValorSumado;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x000484B0 File Offset: 0x000466B0
		public ModificableDeFloat maximoLimiteValor
		{
			get
			{
				return this.m_maximoLimiteValor;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000FDB RID: 4059 RVA: 0x000484B8 File Offset: 0x000466B8
		protected virtual float aumentosDespuesDeValorRealDe
		{
			get
			{
				return float.MinValue;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x000484BF File Offset: 0x000466BF
		public ModificableDeFloat modificarAumentosDespuesDeValorRealDe
		{
			get
			{
				return this.m_modificarAumentosDespuesDeValorRealDe;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000FDD RID: 4061 RVA: 0x000484C7 File Offset: 0x000466C7
		public ModificableDeFloat sumadorDeAumento
		{
			get
			{
				return this.m_sumadorDeAumento;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x000484CF File Offset: 0x000466CF
		public ModificableDeFloat multiplicadorDeAumento
		{
			get
			{
				return this.m_multiplicadorDeAumento;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000FDF RID: 4063 RVA: 0x000484D7 File Offset: 0x000466D7
		public ModificableDeFloat multiplicadorDeAumentoNext
		{
			get
			{
				return this.m_multiplicadorDeAumentoNext;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x000484DF File Offset: 0x000466DF
		public ModificableDeFloat multiplicadorDeDisminucion
		{
			get
			{
				return this.m_multiplicadorDeDisminucion;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000FE1 RID: 4065 RVA: 0x000484E7 File Offset: 0x000466E7
		public ModificableDeFloat multiplicadorDeDisminucionNext
		{
			get
			{
				return this.m_multiplicadorDeDisminucionNext;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x000484EF File Offset: 0x000466EF
		public float valueChangedAmount
		{
			get
			{
				return this.m_valueChangedAmount;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x000484F7 File Offset: 0x000466F7
		public float clampedValorChangedAmount
		{
			get
			{
				return this.m_clampedValorChangedAmount;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x000484FF File Offset: 0x000466FF
		public float valueChangedAmountMayorAZero
		{
			get
			{
				if (this.m_valueChangedAmount < 0f)
				{
					return 0f;
				}
				return this.m_valueChangedAmount;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0004851C File Offset: 0x0004671C
		public virtual float? minValue
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000FE6 RID: 4070
		public abstract ReaccionHumana reaccion { get; }

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06000FE7 RID: 4071 RVA: 0x00048534 File Offset: 0x00046734
		// (remove) Token: 0x06000FE8 RID: 4072 RVA: 0x0004856C File Offset: 0x0004676C
		public event Emocion.ValueChangedHandler valueChanged;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06000FE9 RID: 4073 RVA: 0x000485A4 File Offset: 0x000467A4
		// (remove) Token: 0x06000FEA RID: 4074 RVA: 0x000485DC File Offset: 0x000467DC
		public event Action<Emocion> onMaxValue;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000FEB RID: 4075 RVA: 0x00048614 File Offset: 0x00046814
		// (remove) Token: 0x06000FEC RID: 4076 RVA: 0x0004864C File Offset: 0x0004684C
		public event Action<Emocion> afterUpdate;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000FED RID: 4077 RVA: 0x00048684 File Offset: 0x00046884
		// (remove) Token: 0x06000FEE RID: 4078 RVA: 0x000486BC File Offset: 0x000468BC
		public event Action<Emocion> beforeUpdate;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000FEF RID: 4079 RVA: 0x000486F4 File Offset: 0x000468F4
		// (remove) Token: 0x06000FF0 RID: 4080 RVA: 0x0004872C File Offset: 0x0004692C
		public event Action<Emocion.EventValueData> updatingValue;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x06000FF1 RID: 4081 RVA: 0x00048764 File Offset: 0x00046964
		// (remove) Token: 0x06000FF2 RID: 4082 RVA: 0x0004879C File Offset: 0x0004699C
		public event Action valueUpdated;

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x000487D1 File Offset: 0x000469D1
		public EmocionesHumanasBase owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x000487D9 File Offset: 0x000469D9
		protected void DisminuirPorSegundo(ref float aumento, float minCantidadPorSegundo, float maxCantidadPorSegundo, float lerpMod)
		{
			this.Disminuir(ref aumento, Mathf.Lerp(minCantidadPorSegundo, maxCantidadPorSegundo, lerpMod) * Time.deltaTime);
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x000487F1 File Offset: 0x000469F1
		protected void DisminuirPorSegundo(ref float aumento, float cantidadPorSegundo)
		{
			this.Disminuir(ref aumento, cantidadPorSegundo * Time.deltaTime);
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x00048804 File Offset: 0x00046A04
		protected void Disminuir(ref float aumento, float cantidad)
		{
			if (cantidad <= 0f)
			{
				return;
			}
			float total = this.value.total;
			if (cantidad > total)
			{
				cantidad = total;
			}
			aumento -= cantidad;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00048836 File Offset: 0x00046A36
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
			this.m_EventUpdateValueData = new Emocion.EventValueData(this);
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x00048856 File Offset: 0x00046A56
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_valorRealOnUpdate = this.m_valorReal;
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0004886C File Offset: 0x00046A6C
		public void Init(EmocionesHumanasBase owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner", "owner null reference.");
			}
			this.m_owner = owner;
			this.m_Personalidad = this.owner.transform.parent.GetComponentInChildren<Personalidad>();
			base.Initialize();
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x000488BA File Offset: 0x00046ABA
		protected override void OnAfterInit()
		{
			base.OnAfterInit();
			base.ManualStart();
		}

		// Token: 0x06000FFB RID: 4091
		protected abstract void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar);

		// Token: 0x06000FFC RID: 4092 RVA: 0x000488C8 File Offset: 0x00046AC8
		public void UpdateEmotion(EmocionesHumanasBase.Config.Limite limite)
		{
			bool reportToProfiler = this.owner.reportToProfiler;
			float total = this.value.total;
			bool activado = this.m_activado;
			try
			{
				Action<Emocion> action = this.beforeUpdate;
				if (action != null)
				{
					action(this);
				}
				this.m_currentFrameIsValueAtMax = false;
				bool valueAtMax = this.m_valueAtMax;
				this.m_valueAtMax = false;
				float num = float.MinValue;
				float num2 = float.MaxValue;
				if (this.minValue != null)
				{
					num = this.minValue.Value;
				}
				num = Mathf.Max(this.internal_minValue, num);
				num2 = Mathf.Min(this.internal_maxValue, num2);
				float num3 = 0f;
				float num4 = 100f;
				if (this.internal_minLimit != null)
				{
					num3 = Mathf.Max(this.internal_minLimit.Value, num);
				}
				num3 = Mathf.Max(limite.min, num3);
				num3 = Mathf.Clamp(num3, 0f, 100f);
				if (this.internal_maxLimit != null)
				{
					num4 = Mathf.Min(this.internal_maxLimit.Value, num4);
				}
				num4 = Mathf.Min(limite.max, num4);
				num4 = Mathf.Clamp(num4, 0f, 100f);
				num3 = Mathf.Min(num3, num4);
				float num5 = this.m_valorReal - this.m_valorRealOnUpdate;
				float num6 = 0f;
				float num7 = 0f;
				this.m_EventUpdateValueData.Clear();
				Action<Emocion.EventValueData> action2 = this.updatingValue;
				if (action2 != null)
				{
					action2(this.m_EventUpdateValueData);
				}
				if (!this.m_activado)
				{
					this.m_EventUpdateValueData.Clear();
				}
				num7 += this.m_EventUpdateValueData.value;
				this.UpdateValue(ref num7, ref num6, ref this.m_valorACambiar);
				Action action3 = this.valueUpdated;
				if (action3 != null)
				{
					action3();
				}
				float num8 = this.m_modificarAumentosDespuesDeValorRealDe.MaximoValorIncluyendo(this.aumentosDespuesDeValorRealDe);
				float num9;
				float num10;
				if (this.m_valorRealOnUpdate >= num8)
				{
					this.m_cambioAddMod = this.m_sumadorDeAumento.AdicinarValorIncluyendo(0f);
					this.m_cambioAumentoMod = this.m_multiplicadorDeAumento.ModificarValor(1f);
					num9 = this.m_multiplicadorDeAumentoNext.ModificarValor(1f);
					this.m_cambioDisminucionMod = this.m_multiplicadorDeDisminucion.ModificarValor(1f);
					num10 = this.m_multiplicadorDeDisminucionNext.ModificarValor(1f);
				}
				else
				{
					this.m_cambioAddMod = 0f;
					this.m_cambioAumentoMod = 1f;
					num9 = 1f;
					this.m_cambioDisminucionMod = 1f;
					num10 = 1f;
				}
				float num11 = this.m_minimoLimiteValor.MaximoValorIncluyendo(num3);
				float num12 = this.m_minimoLimiteValorSumado.MaximoValorIncluyendo(num3);
				this.m_limiteMinimo = num11;
				this.m_limiteMinimoSumado = num12;
				float num13 = this.m_limiteMinimo + this.m_limiteMinimoSumado;
				num13 = (this.limiteMinimoPuedeAlcanzar100 ? num13 : Mathf.Clamp(num13, float.MinValue, 99f));
				float num14 = (this.m_limiteMaximo = this.m_maximoLimiteValor.MinimoValorIncluyendo(num4));
				if (this.m_activado)
				{
					num6 += num5;
					num7 += num5;
					num6 += this.m_cambioAddMod;
					num7 += this.m_cambioAddMod;
					this.m_cambioAumentoMod *= this.modificadorDeAumentoDeEmocionPorPersonalidad * this.m_modificadorDeEmocion;
					this.m_cambioDisminucionMod *= this.modificadorDeDisminucionEmocionPorPersonalidad * this.m_modificadorDeEmocion;
					if (num6 > 0f)
					{
						num6 *= this.m_cambioAumentoMod;
					}
					else
					{
						num6 *= this.m_cambioDisminucionMod;
					}
					if (num7 > 0f)
					{
						num7 *= this.m_cambioAumentoMod;
					}
					else
					{
						num7 *= this.m_cambioDisminucionMod;
					}
					float num15;
					if (this.m_valorACambiar > 0f)
					{
						num15 = this.m_valorACambiar * num9;
					}
					else
					{
						num15 = this.m_valorACambiar * num10;
					}
					float num16 = -this.m_valorRealOnUpdate - 0.01f;
					float num17 = 100.01f - this.m_valorRealOnUpdate;
					num15 = Mathf.Clamp(num15, num16, num17);
					num6 += num15;
					num7 += num15;
					this.m_valorACambiar = 0f;
				}
				else
				{
					num7 = 0f;
					num6 = 0f;
				}
				float num18 = this.m_sumadorDeValor.AdicinarValorIncluyendo(0f);
				float num19 = this.m_multiplicadorDeValor.ModificarValor(1f);
				float num20 = Mathf.Clamp(this.m_valorRealOnUpdate + num7, float.MinValue, float.MaxValue);
				bool flag = num20 < 100f;
				float num21 = (num20 + num18) * num19;
				num21 = (flag ? Mathf.Clamp(num21, float.MinValue, 99f) : num21);
				float num22 = Mathf.Clamp(num21, num, num2);
				float num23 = Mathf.Clamp(Mathf.Clamp(num22, num3, num4), num13, num14);
				this.m_Percentage = new PercentageInv(num23);
				if (num23 >= 100f)
				{
					this.m_valueAtMax = true;
					if (!valueAtMax || this.flagToOnMaxValue)
					{
						this.m_currentFrameIsValueAtMax = true;
						this.OnMaxValue();
					}
				}
				this.flagToOnMaxValue = false;
				float postLimitedValor = this.m_postLimitedValor;
				float num24 = num23;
				this.m_valueChangedAmount = num23 - this.m_postLimitedValor;
				this.m_clampedValorChangedAmount = num22 - this.m_clampedValor;
				this.m_moddedValor = num21;
				this.m_postLimitedValor = num23;
				this.m_valorRealOnUpdate = (this.m_valorReal = num20);
				this.m_clampedValor = num22;
				if (postLimitedValor != num24)
				{
					Emocion.ValueChangedHandler valueChangedHandler = this.valueChanged;
					if (valueChangedHandler != null)
					{
						valueChangedHandler(postLimitedValor, num24, this);
					}
				}
				this.AfterUpdate();
			}
			finally
			{
				this.flagToMax = false;
				bool reportToProfiler2 = this.owner.reportToProfiler;
				if (!activado && total != this.value.total)
				{
					Debug.LogError("Total cambio estando emocion: " + base.name + ", desactivada");
				}
			}
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x00048E78 File Offset: 0x00047078
		public void SetValueNextUpdate(float val)
		{
			this.ChangeValueNextUpdate(-(this.m_valorReal - val));
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x00048E89 File Offset: 0x00047089
		public void ChangeValueNextUpdate(float amount)
		{
			this.m_valorACambiar += amount;
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00048E99 File Offset: 0x00047099
		public float SimularAumento(float aumento)
		{
			aumento += this.m_cambioAddMod;
			if (aumento > 0f)
			{
				aumento *= this.m_cambioAumentoMod;
			}
			else
			{
				aumento *= this.m_cambioDisminucionMod;
			}
			return aumento;
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x00048EC4 File Offset: 0x000470C4
		public void ChangeValueNextUpdateModified(float amount)
		{
			this.m_valorACambiar += this.SimularAumento(amount);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00048EDA File Offset: 0x000470DA
		public void IncreaseValueNextUpdate(float amount)
		{
			if (amount < 0f)
			{
				Debug.LogWarning("cant increase emotion value by a negative number", this);
				return;
			}
			this.IncreaseValueNextUpdatePostMod(ref amount);
			this.m_valorACambiar += amount;
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00048F06 File Offset: 0x00047106
		public void ReduceValueNextUpdate(float amount)
		{
			if (amount < 0f)
			{
				Debug.LogWarning("cant reduce emotion value by a negative number", this);
				return;
			}
			this.ReduceValueNextUpdatePostMod(ref amount);
			this.m_valorACambiar -= amount;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void IncreaseValueNextUpdatePostMod(ref float amount)
		{
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void ReduceValueNextUpdatePostMod(ref float amount)
		{
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x00048F32 File Offset: 0x00047132
		public void SetMinLimit(float? amount)
		{
			this.internal_minLimit = amount;
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00048F3B File Offset: 0x0004713B
		public void SetMaxLimit(float? amount)
		{
			this.internal_maxLimit = amount;
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x00048F44 File Offset: 0x00047144
		public void SetMinValue(float amount)
		{
			this.internal_minValue = amount;
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x00048F4D File Offset: 0x0004714D
		public void SetMaxValue(float amount)
		{
			this.internal_maxValue = amount;
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00048F56 File Offset: 0x00047156
		protected void OnMaxValue()
		{
			Action<Emocion> action = this.onMaxValue;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00048F69 File Offset: 0x00047169
		protected void AfterUpdate()
		{
			Action<Emocion> action = this.afterUpdate;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00003B39 File Offset: 0x00001D39
		[Obsolete]
		public void ObtenerMaximoEstimuloEnFrame(Emocion.FrameEstimuloData result)
		{
		}

		// Token: 0x04000D2F RID: 3375
		[Tooltip("false para congelar valor, exepto si se aumenta munalmente")]
		[SerializeField]
		private bool m_activado = true;

		// Token: 0x04000D30 RID: 3376
		[Tooltip("modifica el valor generado cada update")]
		[SerializeField]
		[Range(0f, 100f)]
		private float m_modificadorDeEmocion = 1f;

		// Token: 0x04000D31 RID: 3377
		[SerializeField]
		[ReadOnlyUI]
		private float m_cambioAddMod;

		// Token: 0x04000D32 RID: 3378
		[SerializeField]
		[ReadOnlyUI]
		private float m_cambioAumentoMod;

		// Token: 0x04000D33 RID: 3379
		[SerializeField]
		[ReadOnlyUI]
		private float m_cambioDisminucionMod;

		// Token: 0x04000D34 RID: 3380
		public bool flagToMax;

		// Token: 0x04000D35 RID: 3381
		public bool flagToOnMaxValue;

		// Token: 0x04000D36 RID: 3382
		[SerializeField]
		private PercentageInv m_Percentage;

		// Token: 0x04000D37 RID: 3383
		[SerializeField]
		private float m_valorReal;

		// Token: 0x04000D38 RID: 3384
		[ReadOnlyUI]
		[SerializeField]
		private float m_limiteMinimo;

		// Token: 0x04000D39 RID: 3385
		[ReadOnlyUI]
		[SerializeField]
		private float m_limiteMinimoSumado;

		// Token: 0x04000D3A RID: 3386
		[ReadOnlyUI]
		[SerializeField]
		private float m_limiteMaximo;

		// Token: 0x04000D3B RID: 3387
		[ReadOnlyUI]
		[SerializeField]
		private float m_moddedValor;

		// Token: 0x04000D3C RID: 3388
		[ReadOnlyUI]
		[SerializeField]
		private float m_clampedValor;

		// Token: 0x04000D3D RID: 3389
		[ReadOnlyUI]
		[SerializeField]
		private float m_postLimitedValor;

		// Token: 0x04000D3E RID: 3390
		[NonSerialized]
		private float m_valorRealOnUpdate;

		// Token: 0x04000D3F RID: 3391
		[SerializeField]
		[ReadOnlyUI]
		private float m_valueChangedAmount;

		// Token: 0x04000D40 RID: 3392
		[SerializeField]
		[ReadOnlyUI]
		private float m_clampedValorChangedAmount;

		// Token: 0x04000D41 RID: 3393
		[SerializeField]
		[ReadOnlyUI]
		private bool m_valueAtMax;

		// Token: 0x04000D42 RID: 3394
		[SerializeField]
		[ReadOnlyUI]
		private bool m_currentFrameIsValueAtMax;

		// Token: 0x04000D43 RID: 3395
		[SerializeField]
		[ReadOnlyUI]
		private float m_valorACambiar;

		// Token: 0x04000D44 RID: 3396
		[SerializeField]
		private ModificableDeFloat m_sumadorDeValor = new ModificableDeFloat(0f);

		// Token: 0x04000D45 RID: 3397
		[SerializeField]
		private ModificableDeFloat m_multiplicadorDeValor = new ModificableDeFloat(1f);

		// Token: 0x04000D46 RID: 3398
		[SerializeField]
		private ModificableDeFloat m_minimoLimiteValor = new ModificableDeFloat(float.MinValue);

		// Token: 0x04000D47 RID: 3399
		[SerializeField]
		private ModificableDeFloat m_minimoLimiteValorSumado = new ModificableDeFloat(float.MinValue);

		// Token: 0x04000D48 RID: 3400
		[SerializeField]
		private ModificableDeFloat m_maximoLimiteValor = new ModificableDeFloat(float.MaxValue);

		// Token: 0x04000D49 RID: 3401
		[SerializeField]
		private ModificableDeFloat m_modificarAumentosDespuesDeValorRealDe = new ModificableDeFloat(float.MinValue);

		// Token: 0x04000D4A RID: 3402
		[SerializeField]
		private ModificableDeFloat m_sumadorDeAumento = new ModificableDeFloat(0f);

		// Token: 0x04000D4B RID: 3403
		[SerializeField]
		private ModificableDeFloat m_multiplicadorDeAumento = new ModificableDeFloat(1f);

		// Token: 0x04000D4C RID: 3404
		[SerializeField]
		private ModificableDeFloat m_multiplicadorDeAumentoNext = new ModificableDeFloat(1f);

		// Token: 0x04000D4D RID: 3405
		[SerializeField]
		private ModificableDeFloat m_multiplicadorDeDisminucion = new ModificableDeFloat(1f);

		// Token: 0x04000D4E RID: 3406
		[SerializeField]
		private ModificableDeFloat m_multiplicadorDeDisminucionNext = new ModificableDeFloat(1f);

		// Token: 0x04000D4F RID: 3407
		private const float minValueReal = -3.4028235E+38f;

		// Token: 0x04000D50 RID: 3408
		private const float maxValueReal = 3.4028235E+38f;

		// Token: 0x04000D51 RID: 3409
		private float? internal_minLimit;

		// Token: 0x04000D52 RID: 3410
		private float? internal_maxLimit;

		// Token: 0x04000D53 RID: 3411
		[SerializeField]
		private float internal_minValue;

		// Token: 0x04000D54 RID: 3412
		[SerializeField]
		private float internal_maxValue = float.MaxValue;

		// Token: 0x04000D5B RID: 3419
		private Emocion.EventValueData m_EventUpdateValueData;

		// Token: 0x04000D5C RID: 3420
		private EmocionesHumanasBase m_owner;

		// Token: 0x04000D5D RID: 3421
		protected Personalidad m_Personalidad;

		// Token: 0x020002C7 RID: 711
		// (Invoke) Token: 0x0600100E RID: 4110
		public delegate void ValueChangedHandler(float last, float current, Emocion emo);

		// Token: 0x020002C8 RID: 712
		public class EventValueData
		{
			// Token: 0x06001011 RID: 4113 RVA: 0x0004905C File Offset: 0x0004725C
			public EventValueData(Emocion emo)
			{
				this.emocion = emo;
			}

			// Token: 0x1700039F RID: 927
			// (get) Token: 0x06001012 RID: 4114 RVA: 0x0004906B File Offset: 0x0004726B
			// (set) Token: 0x06001013 RID: 4115 RVA: 0x00049073 File Offset: 0x00047273
			public Emocion emocion { get; private set; }

			// Token: 0x170003A0 RID: 928
			// (get) Token: 0x06001014 RID: 4116 RVA: 0x0004907C File Offset: 0x0004727C
			public float value
			{
				get
				{
					return this.m_value;
				}
			}

			// Token: 0x06001015 RID: 4117 RVA: 0x00049084 File Offset: 0x00047284
			public void Add(float val)
			{
				this.m_value += val;
			}

			// Token: 0x06001016 RID: 4118 RVA: 0x00049094 File Offset: 0x00047294
			public void Clear()
			{
				this.m_value = 0f;
			}

			// Token: 0x04000D5F RID: 3423
			private float m_value;
		}

		// Token: 0x020002C9 RID: 713
		[Obsolete]
		[Serializable]
		public class FrameEstimuloData
		{
			// Token: 0x06001017 RID: 4119 RVA: 0x000490A1 File Offset: 0x000472A1
			public void Clear()
			{
				this.data = null;
				this.parteAI = PartesHumanasParaAi.cuerpo;
				this.severidad = Emocion.EstimuloSeveridad.zero;
			}

			// Token: 0x06001018 RID: 4120 RVA: 0x000490B8 File Offset: 0x000472B8
			public void Copiar(Emocion.FrameEstimuloData other)
			{
				this.data = other.data;
				this.parteAI = other.parteAI;
				this.severidad = other.severidad;
			}

			// Token: 0x04000D60 RID: 3424
			public bool currentFrameIsAtMax;

			// Token: 0x04000D61 RID: 3425
			public PorcentageModificable valueAtUpdate;

			// Token: 0x04000D62 RID: 3426
			public EstimuloTactilData data;

			// Token: 0x04000D63 RID: 3427
			[Obsolete("usar parteAi", true)]
			public PartesHumanasParaAi parte;

			// Token: 0x04000D64 RID: 3428
			public PartesHumanasParaAi parteAI;

			// Token: 0x04000D65 RID: 3429
			public Emocion.EstimuloSeveridad severidad;
		}

		// Token: 0x020002CA RID: 714
		[Obsolete]
		[Serializable]
		public class SessionDeEstimulo
		{
			// Token: 0x0600101A RID: 4122 RVA: 0x000490DE File Offset: 0x000472DE
			public SessionDeEstimulo(float tiempoParaTerminarSession, float severidadMod, Emocion emo, EstimuloTipo tipos)
				: this(severidadMod, emo, tipos)
			{
				this.tiempoParaTerminarSession = tiempoParaTerminarSession;
			}

			// Token: 0x0600101B RID: 4123 RVA: 0x000490F1 File Offset: 0x000472F1
			public SessionDeEstimulo(float severidadMod, Emocion emo, EstimuloTipo tipos)
				: this(emo, tipos)
			{
				this.severidadMod = severidadMod;
			}

			// Token: 0x0600101C RID: 4124 RVA: 0x00049104 File Offset: 0x00047304
			public SessionDeEstimulo(Emocion emo, EstimuloTipo tipos)
			{
				this.m_emo = emo;
				this.m_tipos = tipos;
			}

			// Token: 0x170003A1 RID: 929
			// (get) Token: 0x0600101D RID: 4125 RVA: 0x0004915C File Offset: 0x0004735C
			public EstimuloTipo tipos
			{
				get
				{
					return this.m_tipos;
				}
			}

			// Token: 0x170003A2 RID: 930
			// (get) Token: 0x0600101E RID: 4126 RVA: 0x00049164 File Offset: 0x00047364
			public int frames
			{
				get
				{
					return this.m_frames;
				}
			}

			// Token: 0x170003A3 RID: 931
			// (get) Token: 0x0600101F RID: 4127 RVA: 0x0004916C File Offset: 0x0004736C
			public float duration
			{
				get
				{
					return this.m_duration;
				}
			}

			// Token: 0x170003A4 RID: 932
			// (get) Token: 0x06001020 RID: 4128 RVA: 0x00049174 File Offset: 0x00047374
			public float sumaDeTodosLosEstimulosEnFrames
			{
				get
				{
					return this.m_sumaDeTodosLosEstimulosEnFrames;
				}
			}

			// Token: 0x170003A5 RID: 933
			// (get) Token: 0x06001021 RID: 4129 RVA: 0x0004917C File Offset: 0x0004737C
			public PartesHumanasParaAi maximaParteEstimuladaAlFinalizar
			{
				get
				{
					return this.m_maximaParteEstimuladaAlFinalizar;
				}
			}

			// Token: 0x170003A6 RID: 934
			// (get) Token: 0x06001022 RID: 4130 RVA: 0x00049184 File Offset: 0x00047384
			private float delta
			{
				get
				{
					return Time.time - this.lastTimeUpdate;
				}
			}

			// Token: 0x06001023 RID: 4131 RVA: 0x00049194 File Offset: 0x00047394
			private void Clear()
			{
				this.m_frames = 0;
				this.m_duration = 0f;
				this.m_sumaDeTodosLosEstimulosEnFrames = 0f;
				this.m_acumuladoPorPartesIndex.Clear();
				this.m_acumuladoPorPartesIndexInvert.Clear();
				this.m_acumulados.Clear();
				this.m_maximaParteEstimuladaAlFinalizar = PartesHumanasParaAi.cuello;
			}

			// Token: 0x06001024 RID: 4132 RVA: 0x000491E8 File Offset: 0x000473E8
			public void Acumular(float estimulo, PartesHumanasParaAi parte)
			{
				this.m_estimuloAcumulado += estimulo;
				int count;
				if (!this.m_acumuladoPorPartesIndex.TryGetValue(parte, out count))
				{
					count = this.m_acumulados.Count;
					this.m_acumuladoPorPartesIndex.Add(parte, count);
					this.m_acumuladoPorPartesIndexInvert.Add(count, parte);
					this.m_acumulados.Add(0f);
				}
				float num = this.m_acumulados[count];
				this.m_acumulados[count] = num + estimulo;
			}

			// Token: 0x170003A7 RID: 935
			// (get) Token: 0x06001025 RID: 4133 RVA: 0x00049268 File Offset: 0x00047468
			public Emocion.EstimuloSeveridad severidad
			{
				get
				{
					float num = this.sumaDeTodosLosEstimulosEnFrames * this.severidadMod;
					if (num <= 0f)
					{
						return Emocion.EstimuloSeveridad.zero;
					}
					if (num >= 10f)
					{
						return Emocion.EstimuloSeveridad.alto;
					}
					if (num >= 4f)
					{
						return Emocion.EstimuloSeveridad.medio;
					}
					return Emocion.EstimuloSeveridad.bajo;
				}
			}

			// Token: 0x04000D66 RID: 3430
			[SerializeField]
			private Emocion m_emo;

			// Token: 0x04000D67 RID: 3431
			[SerializeField]
			private EstimuloTipo m_tipos;

			// Token: 0x04000D68 RID: 3432
			[SerializeField]
			private int m_frames;

			// Token: 0x04000D69 RID: 3433
			[SerializeField]
			private float m_duration;

			// Token: 0x04000D6A RID: 3434
			[SerializeField]
			private float m_sumaDeTodosLosEstimulosEnFrames;

			// Token: 0x04000D6B RID: 3435
			[SerializeField]
			private PartesHumanasParaAi m_maximaParteEstimuladaAlFinalizar;

			// Token: 0x04000D6C RID: 3436
			public float tiempoParaTerminarSession = 2f;

			// Token: 0x04000D6D RID: 3437
			public float severidadMod = 1f;

			// Token: 0x04000D6E RID: 3438
			private float lastTimeUpdate;

			// Token: 0x04000D6F RID: 3439
			private float timeInZero;

			// Token: 0x04000D70 RID: 3440
			private float m_estimuloAcumulado;

			// Token: 0x04000D71 RID: 3441
			private bool puedeLamarASessionEnds;

			// Token: 0x04000D72 RID: 3442
			private Dictionary<PartesHumanasParaAi, int> m_acumuladoPorPartesIndex = new Dictionary<PartesHumanasParaAi, int>();

			// Token: 0x04000D73 RID: 3443
			private Dictionary<int, PartesHumanasParaAi> m_acumuladoPorPartesIndexInvert = new Dictionary<int, PartesHumanasParaAi>();

			// Token: 0x04000D74 RID: 3444
			private List<float> m_acumulados = new List<float>();
		}

		// Token: 0x020002CB RID: 715
		public enum EstimuloSeveridad
		{
			// Token: 0x04000D76 RID: 3446
			zero,
			// Token: 0x04000D77 RID: 3447
			bajo,
			// Token: 0x04000D78 RID: 3448
			medio = 4,
			// Token: 0x04000D79 RID: 3449
			alto = 10
		}
	}
}

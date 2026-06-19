using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Desgastables.Handlers
{
	// Token: 0x02000293 RID: 659
	[RequireComponent(typeof(IHoleDesgastable))]
	public class DesgasteCiclicoTemporal : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00044388 File Offset: 0x00042588
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_desgsatable = base.GetComponent<IHoleDesgastable>();
			this.m_modificador = this.m_desgsatable.anchura.sumable.ObtenerModificadorNotNull(this);
			this.m_currentTiempo = 0f;
			this.m_currentTiempoWeight = 0f;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x000443D9 File Offset: 0x000425D9
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat modificador = this.m_modificador;
			if (modificador == null)
			{
				return;
			}
			modificador.TryRemoverDeOwner(true);
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000443F4 File Offset: 0x000425F4
		public override void OnUpdateEvent1()
		{
			bool flag = false;
			try
			{
				if (this.m_desgsatable == null)
				{
					flag = true;
				}
				else
				{
					if (this.m_currentTiempo > this.config.duracion)
					{
						this.m_currentTiempo = this.config.duracion;
					}
					if (this.m_currentTiempoWeight > 1f)
					{
						this.m_currentTiempoWeight = 1f;
					}
					if (this.m_currentTiempoWeight == 1f)
					{
						flag = true;
					}
					if (this.m_currentTiempoWeight <= 0f)
					{
						this.m_startDesgasteInvertido = this.m_desgsatable.anchura.current;
						this.m_fixingTime = this.cicloDefault.GetCurveTimeForValue(-(1f - this.m_startDesgasteInvertido), 10);
						this.m_cicloUsando = this.cicloDefault.MoverHaciaAdelanteConInicialEnZero(this.m_fixingTime, false, false);
					}
					float num = this.config.duracion / (float)this.config.cantidadDeCiclos;
					this.m_currentCiclo = 0;
					float num2;
					for (num2 = this.m_currentTiempo; num2 > num; num2 -= num)
					{
						this.m_currentCiclo++;
					}
					float num3 = Mathf.Clamp01(num2 / num);
					float num4 = this.m_cicloUsando.Evaluate(num3);
					float num5;
					if (num4 < 0f)
					{
						num5 = num4 * this.config.maxAmplitudContrayendoWeight;
					}
					else
					{
						num5 = num4 * this.config.maxAmplitudExpandiendoWeight;
					}
					if (this.config.smoothEndAmplitud && this.m_currentTiempoWeight >= this.config.startSmoothEndAmplitudOnTiempoWeight)
					{
						float num6 = Mathf.InverseLerp(1f, this.config.startSmoothEndAmplitudOnTiempoWeight, this.m_currentTiempoWeight);
						num6 = num6.InPow(this.config.smoothEndAmplitudInPower);
						num5 *= num6;
					}
					this.m_modificador.valor.valor = num5;
				}
			}
			finally
			{
				if (this.config.duracion <= 0f)
				{
					this.config.duracion = 1E-05f;
				}
				float num7 = Time.deltaTime;
				if (this.config.smoothEndTime && this.m_currentTiempoWeight >= this.config.startSmoothEndTimeOnTiempoWeight)
				{
					float num8 = Mathf.InverseLerp(1f, this.config.startSmoothEndTimeOnTiempoWeight, this.m_currentTiempoWeight);
					num8 = num8.OutPow(this.config.smoothEndTimeOutPower);
					num7 *= num8;
					num7 = Mathf.Clamp(num7, Time.deltaTime * 0.075f, Time.deltaTime);
				}
				this.m_currentTiempo += num7;
				this.m_currentTiempoWeight = this.m_currentTiempo / this.config.duracion;
				if (flag)
				{
					base.enabled = false;
					Object.Destroy(this);
				}
			}
		}

		// Token: 0x04000C74 RID: 3188
		[Tooltip("UN solo ciclo, osea una sola vuelta")]
		public AnimationCurve cicloDefault = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.25f, -0.5f, -5f, -5f),
			new Keyframe(0.5f, -1f),
			new Keyframe(0.75f, -0.5f, 5f, 5f),
			new Keyframe(1f, 0f)
		});

		// Token: 0x04000C75 RID: 3189
		public DesgasteCiclicoTemporal.Config config = new DesgasteCiclicoTemporal.Config();

		// Token: 0x04000C76 RID: 3190
		[Header("current State")]
		[SerializeField]
		private AnimationCurve m_cicloUsando;

		// Token: 0x04000C77 RID: 3191
		[SerializeField]
		[ReadOnlyUI]
		[Range(0f, 1f)]
		private float m_startDesgasteInvertido;

		// Token: 0x04000C78 RID: 3192
		[SerializeField]
		[ReadOnlyUI]
		[Range(0f, 1f)]
		private float m_fixingTime;

		// Token: 0x04000C79 RID: 3193
		[SerializeField]
		[ReadOnlyUI]
		private int m_currentCiclo;

		// Token: 0x04000C7A RID: 3194
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentTiempo;

		// Token: 0x04000C7B RID: 3195
		[SerializeField]
		[ReadOnlyUI]
		[Range(0f, 1f)]
		private float m_currentTiempoWeight;

		// Token: 0x04000C7C RID: 3196
		private ModificadorDeFloat m_modificador;

		// Token: 0x04000C7D RID: 3197
		private IHoleDesgastable m_desgsatable;

		// Token: 0x02000294 RID: 660
		[Serializable]
		public class Config
		{
			// Token: 0x04000C7E RID: 3198
			public float duracion = 7f;

			// Token: 0x04000C7F RID: 3199
			public int cantidadDeCiclos = 19;

			// Token: 0x04000C80 RID: 3200
			[Tooltip("Valor de 1 equivale a 100 porciento de desgaste negativo")]
			[Range(0f, 1f)]
			public float maxAmplitudContrayendoWeight = 0.9f;

			// Token: 0x04000C81 RID: 3201
			[Tooltip("Valor de 1 equivale a 100 porciento de desgaste positivo")]
			[Range(0f, 1f)]
			public float maxAmplitudExpandiendoWeight = 0.666f;

			// Token: 0x04000C82 RID: 3202
			[Header("Smooth Amplitud end Config")]
			public bool smoothEndAmplitud = true;

			// Token: 0x04000C83 RID: 3203
			[Range(0f, 1f)]
			public float startSmoothEndAmplitudOnTiempoWeight = 0.5f;

			// Token: 0x04000C84 RID: 3204
			public float smoothEndAmplitudInPower = 1.5f;

			// Token: 0x04000C85 RID: 3205
			[Header("Smooth En Time end Config")]
			public bool smoothEndTime = true;

			// Token: 0x04000C86 RID: 3206
			[Range(0f, 1f)]
			public float startSmoothEndTimeOnTiempoWeight = 0.1f;

			// Token: 0x04000C87 RID: 3207
			[Range(1f, 10f)]
			public float smoothEndTimeOutPower = 2f;
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Animations;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.AnimCollection.Idles
{
	// Token: 0x0200055F RID: 1375
	[RequireComponent(typeof(FemaleAnimController))]
	public class FemaleCharacterIdleLoader : AplicableCustomMonobehaviour
	{
		// Token: 0x06002168 RID: 8552 RVA: 0x0007C924 File Offset: 0x0007AB24
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_AnimController = base.GetComponent<FemaleAnimController>();
			this.m_Character = this.GetComponentEnRoot(false);
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_Character.charMemoryLoaded += this.M_Character_memoryLoaded;
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x0007C9B0 File Offset: 0x0007ABB0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_updatePoseEmoWeightsCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.UpdatePoseEmoWeightsRutina(), null);
			this.m_updatePoseEmoCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update2, this, this.UpdatePoseEmoRutina(), null);
		}

		// Token: 0x0600216A RID: 8554 RVA: 0x0007C9EC File Offset: 0x0007ABEC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_updatePoseEmoWeightsCorutina != null)
			{
				GlobalUpdater.instancia.StopCorrutina(this.m_updatePoseEmoWeightsCorutina);
			}
			if (this.m_updatePoseEmoCorutina != null)
			{
				GlobalUpdater.instancia.StopCorrutina(this.m_updatePoseEmoCorutina);
			}
			this.m_targets.Clear();
			this.m_currents.Clear();
			this.m_targetsFingers.Clear();
			this.m_currentsFingers.Clear();
		}

		// Token: 0x0600216B RID: 8555 RVA: 0x0007CA5C File Offset: 0x0007AC5C
		private void M_Character_memoryLoaded(Character obj)
		{
			this.UpdatePose();
		}

		// Token: 0x0600216C RID: 8556 RVA: 0x0007CA64 File Offset: 0x0007AC64
		public void UpdatePose()
		{
			this.m_weigthsV2 = this.GetComponentsEnRoot(false).Cast<Object>().ToList<Object>();
			this.UpdateIdlePoseStyle();
			this.UpdatePoseEmoWeights();
			this.UpdatePoseEmo();
			this.m_AnimController.currentPose = TipoDePose.dePieRigida;
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x0007CA9C File Offset: 0x0007AC9C
		public void UpdateIdlePoseStyle()
		{
			if (this.m_overrideIdlePoseStyle < 0f)
			{
				if (this.m_weigthsV2.Count == 0)
				{
					float weigthDeScore = this.m_personalidad.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
					this.m_lastModelajeAnimValue = weigthDeScore;
					this.m_lastModelajeAnimValue = this.m_lastModelajeAnimValue.InInOutOutPow(2f, 2f, 0.3333f);
					this.m_lastModelajeAnimValue = 1f - Mathf.Clamp01(this.m_lastModelajeAnimValue);
					Debug.LogWarning("No femeninity w getter found in character");
				}
				else
				{
					this.m_lastModelajeAnimValue = 1f - this.m_weigthsV2.CalculeFemeninityFrom();
				}
				this.m_AnimController.SetIdlePoseStyle(this.m_lastModelajeAnimValue);
				return;
			}
			this.m_AnimController.SetIdlePoseStyle(this.m_overrideIdlePoseStyle);
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x0007CB60 File Offset: 0x0007AD60
		public void UpdatePoseEmoWeights()
		{
			float num = this.m_personalidad.extroversionExgeradoPorEmociones.InPow(2f);
			float num2 = this.m_personalidad.iRespetoExgeradoPorEmociones.InPow(2f);
			float num3 = Mathf.Max(this.m_personalidad.perverticidadExgeradoPorEmociones, this.m_personalidad.exhibicionismoExgeradoPorEmociones).InPow(2f);
			float num4 = this.m_personalidad.timidezExgeradoPorEmociones.InPow(2f);
			float num5 = this.m_personalidad.terrorExgeradoPorEmociones.InPow(2f);
			float weigthDeScore = this.m_personalidad.GetTraitScore(TraitHumano.mimicas).GetWeigthDeScore();
			MathfExtension.ExagerarWeigths(ref num, ref num2, ref num3, ref num4, ref num5, 2f);
			float num6 = MathfExtension.LerpConMedio(0.7f, 0.85f, 1f, weigthDeScore);
			float num7 = MathfExtension.LerpConMedio(0.5f, 0.75f, 1f, weigthDeScore);
			float num8 = MathfExtension.LerpConMedio(0.5f, 0.75f, 1f, weigthDeScore);
			float num9 = MathfExtension.LerpConMedio(0.5f, 0.75f, 1f, weigthDeScore);
			float num10 = MathfExtension.LerpConMedio(0.5f, 0.75f, 1f, weigthDeScore);
			this.m_targets.extro = num * num6;
			this.m_targets.grosera = num2 * num7;
			this.m_targets.pervert = num3 * num8;
			this.m_targets.timida = num4 * num9;
			this.m_targets.asustada = num5 * num10;
			this.m_targetsFingers.extro = this.m_personalidad.extroversionExgeradoPorEmociones.OutPow(2f);
			this.m_targetsFingers.grosera = this.m_personalidad.iRespetoExgeradoPorEmociones.OutPow(2f);
			this.m_targetsFingers.pervert = Mathf.Max(this.m_personalidad.perverticidadExgeradoPorEmociones, this.m_personalidad.exhibicionismoExgeradoPorEmociones).OutPow(2f);
			this.m_targetsFingers.timida = this.m_personalidad.timidezExgeradoPorEmociones.OutPow(2f);
			this.m_targetsFingers.asustada = this.m_personalidad.terrorExgeradoPorEmociones.OutPow(2f);
			MathfExtension.ExagerarWeigths(ref this.m_targetsFingers.extro, ref this.m_targetsFingers.grosera, ref this.m_targetsFingers.pervert, ref this.m_targetsFingers.timida, ref this.m_targetsFingers.asustada, 2f);
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x0007CDCC File Offset: 0x0007AFCC
		public void UpdatePoseEmo()
		{
			this.m_currents.extro = MathfExtension.SmoothDamp(this.m_currents.extro, this.m_targets.extro, ref this.vels.extro, 0.333f, 1f);
			this.m_currents.grosera = MathfExtension.SmoothDamp(this.m_currents.grosera, this.m_targets.grosera, ref this.vels.grosera, 0.333f, 1f);
			this.m_currents.pervert = MathfExtension.SmoothDamp(this.m_currents.pervert, this.m_targets.pervert, ref this.vels.pervert, 0.333f, 1f);
			this.m_currents.timida = MathfExtension.SmoothDamp(this.m_currents.timida, this.m_targets.timida, ref this.vels.timida, 0.333f, 1f);
			this.m_currents.asustada = MathfExtension.SmoothDamp(this.m_currents.asustada, this.m_targets.asustada, ref this.vels.asustada, 0.333f, 1f);
			this.m_AnimController.SetIdlePoseEmos(this.m_currents.extro, this.m_currents.grosera, this.m_currents.pervert, this.m_currents.timida, this.m_currents.asustada);
			this.m_currentsFingers.extro = MathfExtension.SmoothDamp(this.m_currentsFingers.extro, this.m_targetsFingers.extro, ref this.FingersVel.extro, 0.333f, 1f);
			this.m_currentsFingers.grosera = MathfExtension.SmoothDamp(this.m_currentsFingers.grosera, this.m_targetsFingers.grosera, ref this.FingersVel.grosera, 0.333f, 1f);
			this.m_currentsFingers.pervert = MathfExtension.SmoothDamp(this.m_currentsFingers.pervert, this.m_targetsFingers.pervert, ref this.FingersVel.pervert, 0.333f, 1f);
			this.m_currentsFingers.timida = MathfExtension.SmoothDamp(this.m_currentsFingers.timida, this.m_targetsFingers.timida, ref this.FingersVel.timida, 0.333f, 1f);
			this.m_currentsFingers.asustada = MathfExtension.SmoothDamp(this.m_currentsFingers.asustada, this.m_targetsFingers.asustada, ref this.FingersVel.asustada, 0.333f, 1f);
			this.m_AnimController.SetFingersIdlePoseEmos(this.m_currentsFingers.extro, this.m_currentsFingers.grosera, this.m_currentsFingers.pervert, this.m_currentsFingers.timida, this.m_currentsFingers.asustada);
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x0007D0AB File Offset: 0x0007B2AB
		private IEnumerator UpdatePoseEmoWeightsRutina()
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(2f.Random(0.1f));
			for (;;)
			{
				yield return w;
				this.UpdatePoseEmoWeights();
			}
			yield break;
		}

		// Token: 0x06002171 RID: 8561 RVA: 0x0007D0BA File Offset: 0x0007B2BA
		private IEnumerator UpdatePoseEmoRutina()
		{
			for (;;)
			{
				yield return null;
				this.UpdatePoseEmo();
			}
			yield break;
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x0007D0C9 File Offset: 0x0007B2C9
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.UpdatePose();
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x0007D0D7 File Offset: 0x0007B2D7
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Re aplicar"
			};
		}

		// Token: 0x040015B3 RID: 5555
		[SerializeField]
		private float m_overrideIdlePoseStyle = -1f;

		// Token: 0x040015B4 RID: 5556
		private FemaleAnimController m_AnimController;

		// Token: 0x040015B5 RID: 5557
		private Character m_Character;

		// Token: 0x040015B6 RID: 5558
		private Personalidad m_personalidad;

		// Token: 0x040015B7 RID: 5559
		private GlobalUpdater.Corrutina m_updatePoseEmoWeightsCorutina;

		// Token: 0x040015B8 RID: 5560
		private GlobalUpdater.Corrutina m_updatePoseEmoCorutina;

		// Token: 0x040015B9 RID: 5561
		[ReadOnlyUI]
		[SerializeField]
		private FemaleCharacterIdleLoader.Emociones m_targets = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x040015BA RID: 5562
		[ReadOnlyUI]
		[SerializeField]
		private FemaleCharacterIdleLoader.Emociones m_currents = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x040015BB RID: 5563
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastModelajeAnimValue;

		// Token: 0x040015BC RID: 5564
		[ReadOnlyUI]
		[SerializeField]
		private FemaleCharacterIdleLoader.Emociones m_targetsFingers = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x040015BD RID: 5565
		[ReadOnlyUI]
		[SerializeField]
		private FemaleCharacterIdleLoader.Emociones m_currentsFingers = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x040015BE RID: 5566
		[ConstraintType(typeof(IFemeninityWeightProducer), true)]
		[SerializeField]
		private List<Object> m_weigthsV2 = new List<Object>();

		// Token: 0x040015BF RID: 5567
		private FemaleCharacterIdleLoader.Emociones vels = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x040015C0 RID: 5568
		private FemaleCharacterIdleLoader.Emociones FingersVel = new FemaleCharacterIdleLoader.Emociones();

		// Token: 0x02000560 RID: 1376
		[Serializable]
		public class Emociones
		{
			// Token: 0x06002175 RID: 8565 RVA: 0x0007D15B File Offset: 0x0007B35B
			public void Clear()
			{
				this.extro = 0f;
				this.grosera = 0f;
				this.pervert = 0f;
				this.timida = 0f;
				this.asustada = 0f;
			}

			// Token: 0x040015C1 RID: 5569
			public float extro;

			// Token: 0x040015C2 RID: 5570
			public float grosera;

			// Token: 0x040015C3 RID: 5571
			public float pervert;

			// Token: 0x040015C4 RID: 5572
			public float timida;

			// Token: 0x040015C5 RID: 5573
			public float asustada;
		}
	}
}

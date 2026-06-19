using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000062 RID: 98
	public class CamillaGineMedica : AplicableCustomMonobehaviour
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0001B7AF File Offset: 0x000199AF
		public float currentAlturaW
		{
			get
			{
				return this.m_currentAlturaW;
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001B7B8 File Offset: 0x000199B8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_mainSentadero == null)
			{
				throw new ArgumentNullException("m_mainSentadero", "m_mainSentadero null reference.");
			}
			this.m_defLampRot = this.m_lampPivot.localEulerAngles;
			this.m_lampControl = new CoroutineCapsule(this.LampControlRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001B81F File Offset: 0x00019A1F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_mainSentadero.updatedGoto += this.M_mainSentadero_updatedGoto;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001B83E File Offset: 0x00019A3E
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_defaultSillaPos = this.m_sillaBone.localPosition;
			this.m_defaultReposoRPos = this.m_pernaReposoR.localPosition;
			this.m_defaultReposoLPos = this.m_pernaReposoL.localPosition;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001B879 File Offset: 0x00019A79
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_mainSentadero == null)
			{
				this.m_mainSentadero.updatedGoto -= this.M_mainSentadero_updatedGoto;
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0001B8A8 File Offset: 0x00019AA8
		private void M_mainSentadero_updatedGoto(ICharacter obj)
		{
			float @float = obj.GetComponentEnRoot<FemaleAnimController>().animator.GetFloat(FemaleAnimController.FemaleAnimatorVariables.SuperficieRecostadaAlturaMod);
			float num = MathfExtension.InverseLerpConMedio(0.49693f, 0.7f, 1f, @float);
			if (this.m_calibrandoReposos != null)
			{
				base.StopCoroutine(this.m_calibrandoReposos);
			}
			this.m_calibrandoReposos = base.StartCoroutine(this.CalibrarRutine(num));
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001B908 File Offset: 0x00019B08
		private IEnumerator LampControlRutine()
		{
			for (;;)
			{
				yield return null;
				float num = Mathf.Lerp(this.m_lampOffAngle, 0f, this.lampPosW);
				Vector3 vector = this.m_lampPivot.localEulerAngles;
				float num2 = Mathf.MoveTowardsAngle(vector.z, num, Time.deltaTime * 90f);
				vector = this.m_defLampRot;
				vector.z = num2;
				this.m_lampPivot.localEulerAngles = vector;
			}
			yield break;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001B917 File Offset: 0x00019B17
		private IEnumerator CalibrarRutine(float alturaW)
		{
			float num = MathfExtension.LerpConMedio(0.001953615f, -5E-05f, -0.000988385f, alturaW);
			float num2 = MathfExtension.LerpConMedio(35.626f, 33f, 8.871f, alturaW);
			Vector3 m_pernaReposoRInitialRot = this.m_pernaReposoR.localEulerAngles;
			Vector3 m_pernaReposoLInitialRot = this.m_pernaReposoL.localEulerAngles;
			Vector3 vector = new Vector3(0f, 0f, num);
			Vector3 reposoPosRTarget = this.m_defaultReposoRPos + vector;
			Vector3 reposoPosLTarget = this.m_defaultReposoLPos + vector;
			float reposoZTarget = this.m_defaultReposoRPos.z + num;
			Vector3 reposoRotRTarget = new Vector3(0f, 0f, num2);
			Vector3 reposoRotLTarget = new Vector3(0f, 0f, -num2);
			for (;;)
			{
				this.m_pernaReposoR.localPosition = Vector3.MoveTowards(this.m_pernaReposoR.localPosition, reposoPosRTarget, this.m_operatingSpeed * Time.deltaTime * 0.01f * 2f);
				this.m_pernaReposoL.localPosition = Vector3.MoveTowards(this.m_pernaReposoL.localPosition, reposoPosLTarget, this.m_operatingSpeed * Time.deltaTime * 0.01f * 2f);
				float num3 = Mathf.InverseLerp(this.m_defaultReposoRPos.z, reposoZTarget, this.m_pernaReposoR.localPosition.z);
				Vector3 vector2 = Vector3.Lerp(m_pernaReposoRInitialRot, reposoRotRTarget, num3);
				Vector3 vector3 = Vector3.Lerp(m_pernaReposoLInitialRot, reposoRotLTarget, num3);
				this.m_pernaReposoR.localEulerAngles = vector2;
				this.m_pernaReposoL.localEulerAngles = vector3;
				if (MathfExtension.Approximately(this.m_pernaReposoR.localPosition * 100f, reposoPosRTarget * 100f, 0.0001f) && MathfExtension.Approximately(this.m_pernaReposoL.localPosition * 100f, reposoPosLTarget * 100f, 0.0001f))
				{
					break;
				}
				yield return null;
			}
			this.m_pernaReposoR.localPosition = reposoPosRTarget;
			this.m_pernaReposoL.localPosition = reposoPosLTarget;
			this.m_pernaReposoR.localEulerAngles = reposoRotRTarget;
			this.m_pernaReposoL.localEulerAngles = reposoRotLTarget;
			this.m_calibrandoReposos = null;
			yield break;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001B92D File Offset: 0x00019B2D
		private IEnumerator IniciarRutine(bool operate)
		{
			if (this.m_operando != null)
			{
				base.StopCoroutine(this.m_operando);
			}
			this.m_operando = null;
			Vector3 acorInitialScale = this.m_acordeonBone.localScale;
			this.m_Estado = CamillaGineMedica.Estado.iniciando;
			Vector3 acordeonTarget = new Vector3(1f, 0.8512779f, 1f);
			Vector3 sillaTarget = this.m_defaultSillaPos + new Vector3(0f, 0f, -0.000546382f);
			float sillaZTarget = this.m_defaultSillaPos.z + -0.000546382f;
			for (;;)
			{
				this.m_sillaBone.localPosition = Vector3.MoveTowards(this.m_sillaBone.localPosition, sillaTarget, this.m_operatingSpeed * Time.deltaTime * 0.01f);
				float num = (this.m_currentAlturaW = Mathf.InverseLerp(this.m_defaultSillaPos.z, sillaZTarget, this.m_sillaBone.localPosition.z));
				this.m_acordeonBone.localScale = Vector3.Lerp(acorInitialScale, acordeonTarget, num);
				bool flag = !MathfExtension.Approximately(this.m_currentAlturaW, this.m_lastAlturaW, float.Epsilon);
				this.m_lastAlturaW = this.m_currentAlturaW;
				this.PlaySonido(flag);
				if (MathfExtension.Approximately(this.m_sillaBone.localPosition * 100f, sillaTarget * 100f, 0.0001f))
				{
					break;
				}
				yield return null;
			}
			this.m_sillaBone.localPosition = sillaTarget;
			this.m_acordeonBone.localScale = acordeonTarget;
			this.m_currentAlturaW = 0f;
			this.m_iniciando = null;
			if (operate)
			{
				if (this.m_operando != null)
				{
					base.StopCoroutine(this.m_operando);
				}
				this.m_operando = base.StartCoroutine(this.OperandoRutine());
			}
			yield break;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0001B943 File Offset: 0x00019B43
		private IEnumerator OperandoRutine()
		{
			if (this.m_iniciando != null)
			{
				base.StopCoroutine(this.m_iniciando);
			}
			this.m_iniciando = null;
			this.m_Estado = CamillaGineMedica.Estado.operando;
			Vector3 acordeonMin = new Vector3(1f, 0.8512779f, 1f);
			Vector3 sillaMin = this.m_defaultSillaPos + new Vector3(0f, 0f, -0.000546382f);
			float sillaZMin = this.m_defaultSillaPos.z + -0.000546382f;
			Vector3 acordeonMax = new Vector3(1f, 1.75f, 1f);
			Vector3 sillaMax = this.m_defaultSillaPos + new Vector3(0f, 0f, 0.0035f);
			float sillaZMax = this.m_defaultSillaPos.z + 0.0035f;
			for (;;)
			{
				Vector3 vector = Vector3.Lerp(sillaMin, sillaMax, this.alturaW);
				this.m_sillaBone.localPosition = Vector3.MoveTowards(this.m_sillaBone.localPosition, vector, this.m_operatingSpeed * Time.deltaTime * 0.01f);
				float num = (this.m_currentAlturaW = MathfExtension.InverseLerpConMedio(sillaZMin, this.m_defaultSillaPos.z, sillaZMax, this.m_sillaBone.localPosition.z));
				this.m_acordeonBone.localScale = MathfExtension.LerpConMedio(acordeonMin, Vector3.one, acordeonMax, num, 1f, 1f);
				this.m_mainSentadero.alturaOffset = (this.m_sillaBone.localPosition.z - sillaZMin) * 100f;
				bool flag = !MathfExtension.Approximately(this.m_currentAlturaW, this.m_lastAlturaW, float.Epsilon);
				this.m_lastAlturaW = this.m_currentAlturaW;
				this.PlaySonido(flag);
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001B952 File Offset: 0x00019B52
		private void PlaySonido(bool reproducir)
		{
			if (reproducir)
			{
				if (!this.m_audioSource.isPlaying)
				{
					this.m_audioSource.Play();
					return;
				}
			}
			else if (this.m_audioSource.isPlaying)
			{
				this.m_audioSource.Pause();
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001B988 File Offset: 0x00019B88
		public void StartOperation()
		{
			if (this.m_iniciando != null)
			{
				base.StopCoroutine(this.m_iniciando);
			}
			this.m_iniciando = base.StartCoroutine(this.IniciarRutine(true));
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001B9B1 File Offset: 0x00019BB1
		public void StopOperation()
		{
			if (this.m_iniciando != null)
			{
				base.StopCoroutine(this.m_iniciando);
			}
			this.m_iniciando = base.StartCoroutine(this.IniciarRutine(false));
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001B9DA File Offset: 0x00019BDA
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Comenzar Operacion"
			};
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001B9F3 File Offset: 0x00019BF3
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.StartOperation();
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001BA01 File Offset: 0x00019C01
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Detener Operacion"
			};
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0001BA1A File Offset: 0x00019C1A
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.StopOperation();
		}

		// Token: 0x04000266 RID: 614
		private const float acordeonInitialScale = 0.8512779f;

		// Token: 0x04000267 RID: 615
		private const float sillaInitialAlturaOffset = -0.000546382f;

		// Token: 0x04000268 RID: 616
		private const float acordeonMaxScale = 1.75f;

		// Token: 0x04000269 RID: 617
		private const float sillaMaxAlturaOffset = 0.0035f;

		// Token: 0x0400026A RID: 618
		private const float muyAlta_reposadorPiernaAngle = 8.871f;

		// Token: 0x0400026B RID: 619
		private const float muyAlta_reposadorPiernaAlturaOffset = -0.000988385f;

		// Token: 0x0400026C RID: 620
		private const float alta_reposadorPiernaAngle = 33f;

		// Token: 0x0400026D RID: 621
		private const float alta_reposadorPiernaAlturaOffset = -5E-05f;

		// Token: 0x0400026E RID: 622
		private const float med_reposadorPiernaAngle = 35.626f;

		// Token: 0x0400026F RID: 623
		private const float med_reposadorPiernaAlturaOffset = 0.001953615f;

		// Token: 0x04000270 RID: 624
		[SerializeField]
		private Transform m_acordeonBone;

		// Token: 0x04000271 RID: 625
		[SerializeField]
		private Transform m_sillaBone;

		// Token: 0x04000272 RID: 626
		[SerializeField]
		private Transform m_pernaReposoR;

		// Token: 0x04000273 RID: 627
		[SerializeField]
		private Transform m_pernaReposoL;

		// Token: 0x04000274 RID: 628
		[SerializeField]
		private Transform m_pernaReposoTipR;

		// Token: 0x04000275 RID: 629
		[SerializeField]
		private Transform m_pernaReposoTipL;

		// Token: 0x04000276 RID: 630
		[SerializeField]
		private Transform m_lampPivot;

		// Token: 0x04000277 RID: 631
		[SerializeField]
		private CamillaGineRecostable m_mainSentadero;

		// Token: 0x04000278 RID: 632
		[Range(0f, 1f)]
		public float alturaW;

		// Token: 0x04000279 RID: 633
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentAlturaW;

		// Token: 0x0400027A RID: 634
		private float m_lastAlturaW;

		// Token: 0x0400027B RID: 635
		[SerializeField]
		private CamillaGineMedica.Estado m_Estado;

		// Token: 0x0400027C RID: 636
		[SerializeField]
		private float m_operatingSpeed = 1f;

		// Token: 0x0400027D RID: 637
		[SerializeField]
		private AudioSource m_audioSource;

		// Token: 0x0400027E RID: 638
		private Vector3 m_defaultReposoRPos;

		// Token: 0x0400027F RID: 639
		private Vector3 m_defaultReposoLPos;

		// Token: 0x04000280 RID: 640
		private Vector3 m_defaultSillaPos;

		// Token: 0x04000281 RID: 641
		private Coroutine m_iniciando;

		// Token: 0x04000282 RID: 642
		private Coroutine m_operando;

		// Token: 0x04000283 RID: 643
		private Coroutine m_calibrandoReposos;

		// Token: 0x04000284 RID: 644
		[Range(0f, 1f)]
		public float lampPosW;

		// Token: 0x04000285 RID: 645
		private Vector3 m_defLampRot;

		// Token: 0x04000286 RID: 646
		private float m_lampOffAngle = -140f;

		// Token: 0x04000287 RID: 647
		private CoroutineCapsule m_lampControl;

		// Token: 0x04000288 RID: 648
		private static bool todosErrorDebug;

		// Token: 0x020001F5 RID: 501
		public enum Estado
		{
			// Token: 0x04000981 RID: 2433
			None,
			// Token: 0x04000982 RID: 2434
			iniciando,
			// Token: 0x04000983 RID: 2435
			operando
		}
	}
}

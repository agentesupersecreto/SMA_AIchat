using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.Globales.Updater;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000358 RID: 856
	public class ParpadeoDeOjosAI : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x0600126F RID: 4719 RVA: 0x0004FD83 File Offset: 0x0004DF83
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.onAI1);
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06001270 RID: 4720 RVA: 0x0004FD8C File Offset: 0x0004DF8C
		public float ResequedadMod
		{
			get
			{
				HumanTraitScore traitScore = this.m_Personalidad.GetTraitScore(TraitHumano.eyesResequedad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.5f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.6666667f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x0004FDF4 File Offset: 0x0004DFF4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlDeParpadeo = this.GetComponentEnRoot(false);
			this.m_character = this.GetComponentEnRoot(false);
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_ControlDeParpadeo == null)
			{
				throw new ArgumentNullException("m_ControlDeParpadeo", "m_ControlDeParpadeo null reference.");
			}
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x0004FE88 File Offset: 0x0004E088
		public override void OnUpdateEvent1()
		{
			float resequedadMod = this.ResequedadMod;
			if (!this.m_CoolDownParpadeo.isOn && this.proc(resequedadMod))
			{
				this.m_ControlDeParpadeo.parpadearFlag = true;
				if (this.probabilidadDeActivarCoolDown.ProcPorcentaje(1f))
				{
					this.m_CoolDownParpadeo.ApplyNextRandomMod(this.coolDownTime, 0.666f);
				}
				return;
			}
			if (!this.m_FrecuenciaDeCheckeoDeDireccion.isOn)
			{
				this.m_FrecuenciaDeCheckeoDeDireccion.ApplyNext(0.1f);
				if (!this.m_CoolDownCheckDirectionParpadeo.isOn && this.proc(resequedadMod * 2f))
				{
					Quaternion currentWorldRotation = this.m_character.bones.head.currentWorldRotation;
					Vector3 vector = (this.m_character.bones.eyeL.currentForward + this.m_character.bones.eyeR.currentForward) / 2f;
					Vector3 vector2 = Math3d.InverseTransformDirectionMath(currentWorldRotation, vector);
					if (Vector3.Angle(vector2, this.m_lastDireccionLocalDesdeCabeza) >= this.direcctionAngleParaParpadear)
					{
						this.m_lastDireccionLocalDesdeCabeza = vector2;
						if (this.m_lastDireccionLocalDesdeCabeza == Vector3.zero)
						{
							this.m_lastDireccionLocalDesdeCabeza = Vector3.forward;
						}
						this.m_ControlDeParpadeo.parpadearFlag = true;
						this.m_CoolDownCheckDirectionParpadeo.ApplyNextRandomMod(this.coolDownTimePorDireccion, 0.666f);
						return;
					}
				}
			}
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x0004FFDC File Offset: 0x0004E1DC
		protected bool proc(float mod = 1f)
		{
			bool flag = false;
			bool flag2;
			try
			{
				float num = Mathf.Clamp(Random.Range(this.minProbabilidadPorSegundo, this.maxProbabilidadPorSegundo) * mod, 0f, 100f);
				float num2 = Time.time - this.m_lastProcTime;
				float num3 = ((this.coolDownTime < 1f) ? this.coolDownTime : 1f);
				float num4;
				if (Mathf.Clamp(num2, 0f, num3) == num3)
				{
					num4 = num * num3;
					this.m_lastProcTime = Time.time;
				}
				else
				{
					num4 = num * Time.deltaTime;
				}
				if (num4 >= 100f)
				{
					flag = true;
					flag2 = flag;
				}
				else if (num4 <= 0f)
				{
					flag = false;
					flag2 = flag;
				}
				else
				{
					flag = num4 > Random.value * 100f;
					flag2 = flag;
				}
			}
			finally
			{
				if (flag)
				{
					this.m_lastProcTime = Time.time;
				}
			}
			return flag2;
		}

		// Token: 0x04000F83 RID: 3971
		public float minProbabilidadPorSegundo = 10f;

		// Token: 0x04000F84 RID: 3972
		public float maxProbabilidadPorSegundo = 50f;

		// Token: 0x04000F85 RID: 3973
		public float probabilidadDeActivarCoolDown = 66f;

		// Token: 0x04000F86 RID: 3974
		public float coolDownTime = 2f;

		// Token: 0x04000F87 RID: 3975
		public float direcctionAngleParaParpadear = 20f;

		// Token: 0x04000F88 RID: 3976
		public float coolDownTimePorDireccion = 0.333f;

		// Token: 0x04000F89 RID: 3977
		private ControlDeParpadeo m_ControlDeParpadeo;

		// Token: 0x04000F8A RID: 3978
		private CoolDown m_CoolDownParpadeo = new CoolDown();

		// Token: 0x04000F8B RID: 3979
		private CoolDown m_CoolDownCheckDirectionParpadeo = new CoolDown();

		// Token: 0x04000F8C RID: 3980
		[NonSerialized]
		private Vector3 m_lastDireccionLocalDesdeCabeza = Vector3.forward;

		// Token: 0x04000F8D RID: 3981
		private AnimatorCharacter m_character;

		// Token: 0x04000F8E RID: 3982
		private CoolDown m_FrecuenciaDeCheckeoDeDireccion = new CoolDown();

		// Token: 0x04000F8F RID: 3983
		private Personalidad m_Personalidad;

		// Token: 0x04000F90 RID: 3984
		private float m_lastProcTime;
	}
}

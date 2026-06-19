using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.EyeAdvance;
using Assets._ReusableScripts.Globales;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.AI
{
	// Token: 0x0200002E RID: 46
	public class AjustadorDeDilatacionDePupilas : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000066E1 File Offset: 0x000048E1
		public sealed override int updateEvent1Index
		{
			get
			{
				return 70;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000066E8 File Offset: 0x000048E8
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = base.GetComponentInParent<Character>();
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			this.m_owner.stared += this.Cha_stared;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000673C File Offset: 0x0000493C
		private void Cha_stared(object obj)
		{
			this.m_Placer = ((MonoBehaviour)obj).GetComponentInChildren<Placer>();
			Animator componentInChildren = ((MonoBehaviour)obj).GetComponentInChildren<Animator>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.ojoL = componentInChildren.GetBoneTransform(HumanBodyBones.LeftEye).GetComponentInChildren<ControlDeDilatacionDePupila>();
			this.ojoR = componentInChildren.GetBoneTransform(HumanBodyBones.RightEye).GetComponentInChildren<ControlDeDilatacionDePupila>();
			if (this.ojoL == null)
			{
				throw new ArgumentNullException("ojoL", "ojoL null reference.");
			}
			if (this.ojoR == null)
			{
				throw new ArgumentNullException("ojoR", "ojoR null reference.");
			}
			this.m_lucesPropias = ((MonoBehaviour)obj).GetComponentsInChildren<Light>();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000067F4 File Offset: 0x000049F4
		public sealed override void OnUpdateEvent1()
		{
			if (this.ojoL == null || this.ojoR == null)
			{
				Debug.LogWarning("No se encontro ojo izq o der", this);
				return;
			}
			float num = this.ObtenerTamañoMinimoDePupilas();
			float num2 = this.ObtenerTamañoPorIluminacion();
			this.ojoL.dilatacion = (this.ojoR.dilatacion = Mathf.Max(num, num2));
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00006858 File Offset: 0x00004A58
		private float ObtenerTamañoPorIluminacion()
		{
			if (this.m_iluminacionCoolDown.isOn)
			{
				return this.last_illuminacionDilatacion;
			}
			this.m_iluminacionCoolDown.ApplyNextRandomMod(this.iluminacionCoolDown, 0.33f);
			float num = this.CalcularIluminParaOjo(this.ojoL);
			float num2 = this.CalcularIluminParaOjo(this.ojoR);
			this.last_illuminacionDilatacion = Mathf.Min(num, num2);
			return this.last_illuminacionDilatacion;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000068BC File Offset: 0x00004ABC
		private float CalcularIluminParaOjo(ControlDeDilatacionDePupila ojo)
		{
			if (!ojo.render.isVisible)
			{
				return this.last_illuminacionDilatacion;
			}
			LuzEnEscena luzEnEscena;
			float num;
			if (!Singleton<LucesEnEscena>.instance.ObjetoEsIluminado(this.m_owner.transform, ojo.render, 0.02f * this.m_owner.escala, ojo.transform.forward, 100f, out luzEnEscena, out num, null, this.m_lucesPropias, new Vector3?(ojo.posicionDePupilaGlobal)))
			{
				return this.maxDilatacionPorLuz;
			}
			float num2 = 1f - Mathf.InverseLerp(0f, (luzEnEscena.light.intensity == 0f) ? this.sensibilidadALaLuz : (luzEnEscena.light.intensity * num), this.sensibilidadALaLuz).InPow(this.sensibilidadALaLuzInPower);
			return Mathf.Lerp(this.maxDilatacionPorLuz, 0f, num2);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006994 File Offset: 0x00004B94
		private float ObtenerTamañoMinimoDePupilas()
		{
			float num = this.last_DistanciaFocalDilatacion;
			if (!this.m_distanciaFocalCoolDown.isOn)
			{
				this.m_distanciaFocalCoolDown.ApplyNextRandomMod(this.distanciaFocaCoolDown, 0.33f);
				Vector3 position = this.ojoR.transform.position;
				Vector3 position2 = this.ojoL.transform.position;
				Vector3 forward = this.ojoR.transform.forward;
				Vector3 forward2 = this.ojoL.transform.forward;
				Vector3 vector = position + position2;
				vector /= 2f;
				Vector3 vector2;
				Vector3 vector3;
				float num2;
				if (Vector3.Angle(forward, forward2) > 2f && Math3d.ClosestPointsOnTwoLines(out vector2, out vector3, position, forward, position2, forward2))
				{
					num2 = Mathf.Clamp(((vector2 + vector3) / 2f - vector).magnitude * 1.05f, 0f, 15f);
				}
				else
				{
					num2 = 15f;
				}
				float num3 = Mathf.InverseLerp(15f, 0f, num2).OutPow(4f);
				num = (this.last_DistanciaFocalDilatacion = Mathf.Lerp(0f, this.maxDilatacionPorDistanciaFocal, num3));
			}
			if (this.m_Placer == null)
			{
				return num;
			}
			float num4 = Mathf.Lerp(0f, this.maxDilatacionPorPlacer, this.m_Placer.value.mod.OutPow(2f));
			return Mathf.Max(num, num4);
		}

		// Token: 0x040000AD RID: 173
		public float iluminacionCoolDown = 1.2f;

		// Token: 0x040000AE RID: 174
		public float distanciaFocaCoolDown = 0.2f;

		// Token: 0x040000AF RID: 175
		public float sensibilidadALaLuz = 40f;

		// Token: 0x040000B0 RID: 176
		public float sensibilidadALaLuzInPower = 0.1f;

		// Token: 0x040000B1 RID: 177
		public float maxDilatacionPorLuz = 0.67f;

		// Token: 0x040000B2 RID: 178
		public float maxDilatacionPorDistanciaFocal = 0.5f;

		// Token: 0x040000B3 RID: 179
		public float maxDilatacionPorPlacer = 0.61f;

		// Token: 0x040000B4 RID: 180
		private ControlDeDilatacionDePupila ojoL;

		// Token: 0x040000B5 RID: 181
		private ControlDeDilatacionDePupila ojoR;

		// Token: 0x040000B6 RID: 182
		private Character m_owner;

		// Token: 0x040000B7 RID: 183
		private Placer m_Placer;

		// Token: 0x040000B8 RID: 184
		private CoolDown m_iluminacionCoolDown = new CoolDown();

		// Token: 0x040000B9 RID: 185
		private CoolDown m_distanciaFocalCoolDown = new CoolDown();

		// Token: 0x040000BA RID: 186
		private float last_DistanciaFocalDilatacion;

		// Token: 0x040000BB RID: 187
		private float last_illuminacionDilatacion;

		// Token: 0x040000BC RID: 188
		private Light[] m_lucesPropias;
	}
}

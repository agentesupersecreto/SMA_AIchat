using System;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.HandPoses;
using UnityEngine;

namespace Assets.FinalIk
{
	// Token: 0x02000008 RID: 8
	public class FinalIKUtils
	{
		// Token: 0x06000013 RID: 19 RVA: 0x00002588 File Offset: 0x00000788
		[Obsolete]
		public static Vector3 ObtenerPosicionDeTarget(ref Vector3 lastTarget, ref float weight, LookAtIKTargets targets, BoneState headState, BoneState lastSpineState, LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, float minDistanceTarget, bool debugDraw, out float velMod)
		{
			Vector3 vector = headState.position + headState.forward;
			Vector3 vector2;
			float num;
			bool flag = LookAtTargetWieghtParCollection.CalcularCurrentTargetConPrioridad(targets.primariosCollection, targets.segundariosCollection, evaluadorEnRango, lastSpineState.forward, headState.position, out vector2, out num, out velMod, minDistanceTarget);
			if (num < weight)
			{
				weight = Mathf.MoveTowards(weight, num, Time.deltaTime * 5f * Mathf.Max(0.1f, weight.OutPow(2f)));
			}
			else
			{
				weight = Mathf.MoveTowards(weight, num, Time.deltaTime * 5f);
			}
			flag = flag && weight > 0f;
			if (!flag)
			{
				if (weight <= 0f)
				{
					return vector;
				}
				vector2 = lastTarget;
			}
			Vector3 vector3 = FinalIKUtils.CalculeCurrentTargetPosition(headState.position, vector, vector2, weight, debugDraw);
			if (flag)
			{
				lastTarget = vector3;
			}
			return vector3;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002660 File Offset: 0x00000860
		[Obsolete]
		public static Vector3 AlteradorDeDireccionATarget(Vector3 posicionDeTarget, BoneState headEstado, BoneState lastSpineEstado, LookAtEstadisticas estadisticasHaciaTarget, FinalIKUtils.ProyectOnUp proyectOnUp, bool debugDraw)
		{
			Vector3 vector = posicionDeTarget - headEstado.position;
			if (!proyectOnUp.activar)
			{
				return vector;
			}
			Vector3 up = lastSpineEstado.up;
			float num = Vector3.Angle(vector, up);
			if (num > 90f)
			{
				num = Vector3.Angle(vector, -up);
			}
			if (num > 90f)
			{
				throw new NotSupportedException();
			}
			num = 90f - num;
			if (num < 0f)
			{
				num = 0f;
			}
			float num2 = Mathf.InverseLerp(0f, 90f, num);
			num2 = num2.InPow(proyectOnUp.power);
			float num3 = Mathf.Lerp(proyectOnUp.maxModAdelante, proyectOnUp.maxModAtras, estadisticasHaciaTarget.haciaAtrasModAprox);
			num2 = Mathf.Lerp(0f, num3, num2);
			Vector3 vector2 = Math3d.ProjectPointOnPlane(up, headEstado.position, posicionDeTarget);
			return Vector3.Slerp(posicionDeTarget, vector2, num2) - headEstado.position;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000273C File Offset: 0x0000093C
		public static float ResolverLookAtIKWeight(float weightActual, float weightDeseado, float weightCambioVelocidad, Vector3 targetGlobalActual, Vector3 posicionGlobalOrigen, Vector3 origenForwardGlobal, float anguloNecesarioParaResolver = 5f)
		{
			if (weightActual != weightDeseado)
			{
				if (!ExtendedMonoBehaviour.AlmostEqual(weightDeseado, 0f, 0.001f))
				{
					return Mathf.MoveTowards(weightActual, weightDeseado, weightCambioVelocidad * Time.deltaTime);
				}
				Vector3 vector = targetGlobalActual - posicionGlobalOrigen;
				float num = Vector3.Angle(origenForwardGlobal, vector);
				if (ExtendedMonoBehaviour.AlmostEqual(num, 0f, anguloNecesarioParaResolver))
				{
					float num2 = Mathf.Clamp01(num / anguloNecesarioParaResolver);
					return Mathf.MoveTowards(weightActual, weightDeseado, weightCambioVelocidad * Time.deltaTime * num2);
				}
			}
			return weightActual;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000027AB File Offset: 0x000009AB
		public static Vector3 CalculeCurrentTargetDirection(Quaternion rotacionGlobalOrigen, Vector3 targetGlobalDirection, float weight)
		{
			return Vector3.Slerp(targetGlobalDirection, rotacionGlobalOrigen * Vector3.forward, weight.OutPow(2.2f));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000027CC File Offset: 0x000009CC
		public static Vector3 CalculeCurrentTargetPosition(Vector3 posicionGlobalOrigen, Vector3 targetPorDefecto, Vector3 targetGlobalDeseado, float wieight, bool debug = false)
		{
			Vector3 vector = targetPorDefecto - posicionGlobalOrigen;
			Vector3 vector2 = targetGlobalDeseado - posicionGlobalOrigen;
			Vector3 normalized = Vector3.Cross(vector, vector2).normalized;
			Vector3 vector3 = Vector3.Slerp(vector, vector2, wieight.OutPow(2.2f));
			vector3 = Math3d.ProjectVectorOnPlane(normalized, vector3);
			return posicionGlobalOrigen + vector3;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000281C File Offset: 0x00000A1C
		public static Vector3 CalculeDirection(Vector3 posicionGlobalOrigen, Vector3 targetGlobalActual, Vector3 targetGlobalDeseado)
		{
			targetGlobalActual - posicionGlobalOrigen;
			Vector3 vector = targetGlobalDeseado - posicionGlobalOrigen;
			return posicionGlobalOrigen + vector;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002840 File Offset: 0x00000A40
		[Obsolete("")]
		public static Vector3 RotateTowardsV2(Vector3 posicionGlobalOrigen, Vector3 originalUp, Vector3 targetGlobalActual, Vector3 targetGlobalDeseado, float velocidadDeGiro, bool suavizarAlosExtremos, out float anguloFaltante, bool debug = false, float suavizarAlosExtremosAngulo = 45f)
		{
			Vector3 vector = targetGlobalActual - posicionGlobalOrigen;
			Vector3 vector2 = targetGlobalDeseado - posicionGlobalOrigen;
			anguloFaltante = Vector3.Angle(vector, vector2);
			float num;
			if (suavizarAlosExtremos)
			{
				num = Mathf.Clamp01(anguloFaltante / suavizarAlosExtremosAngulo).InPow(1.1f);
			}
			else
			{
				num = 1f;
			}
			Vector3 vector3 = Vector3.RotateTowards(vector, vector2, velocidadDeGiro * 0.017453292f * num * Time.deltaTime, 3f * Time.deltaTime);
			float num2 = Mathf.InverseLerp(suavizarAlosExtremosAngulo, 90f, anguloFaltante);
			if (num2 > 0f)
			{
				Vector3 vector4 = vector3;
				Vector3 vector5 = vector3;
				vector5 = Math3d.ProjectVectorOnPlane(originalUp, vector5);
				vector5 = Vector3.Lerp(vector3.normalized, vector5.normalized, num2);
				vector5 = vector5.SetMagnitud(vector4);
				float num3 = Mathf.Clamp01(Vector3.Angle(vector5, vector3) / suavizarAlosExtremosAngulo);
				vector3 = Vector3.RotateTowards(vector3, vector5, num2 * num3 * velocidadDeGiro * 5f * 0.017453292f * Time.deltaTime, 1f);
			}
			return posicionGlobalOrigen + vector3;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002944 File Offset: 0x00000B44
		public static Vector3 RotateTowards(Vector3 posicionGlobalOrigen, Vector3 originalForward, Vector3 originalUp, float wieight, Vector3 targetGlobalActual, Vector3 targetGlobalDeseado, float velocidadDeGiro, bool suavizarAlosExtremos, bool debug = false, float suavizarAlosExtremosAngulo = 45f)
		{
			if (!ExtendedMonoBehaviour.AlmostEqual(originalForward.sqrMagnitude, 1f, 0.001f))
			{
				originalForward = originalForward.normalized;
			}
			Vector3 vector = originalForward * 2f;
			Vector3 vector2 = targetGlobalActual - posicionGlobalOrigen;
			Vector3 vector3 = targetGlobalDeseado - posicionGlobalOrigen;
			Vector3 vector4 = Vector3.Lerp(vector, vector3, wieight);
			float num = Vector3.Angle(vector2, vector4);
			float num2;
			if (suavizarAlosExtremos)
			{
				num2 = Mathf.Clamp01(num / suavizarAlosExtremosAngulo);
			}
			else
			{
				num2 = 1f;
			}
			Vector3 vector5 = Vector3.RotateTowards(vector2, vector4, velocidadDeGiro * 0.017453292f * num2 * Time.deltaTime, 3f * Time.deltaTime);
			float num3 = Mathf.InverseLerp(suavizarAlosExtremosAngulo, 90f, num);
			if (num3 > 0f)
			{
				Vector3 vector6 = vector5;
				Vector3 vector7 = vector5;
				vector7 = Math3d.ProjectVectorOnPlane(originalUp, vector7);
				vector7 = Vector3.Lerp(vector5.normalized, vector7.normalized, num3);
				vector7 = vector7.SetMagnitud(vector6);
				float num4 = Mathf.Clamp01(Vector3.Angle(vector7, vector5) / 45f);
				vector5 = Vector3.RotateTowards(vector5, vector7, num3 * num4 * velocidadDeGiro * 0.017453292f * Time.deltaTime, 1f);
			}
			return posicionGlobalOrigen + vector5;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002A74 File Offset: 0x00000C74
		public static HandPoserByName InitHandPoser(Transform hand, Animator anim)
		{
			HandPoserByName componentNotNull = hand.GetComponentNotNull<HandPoserByName>();
			componentNotNull.SetAnimator(anim);
			if (!componentNotNull.esComponenteIniciado)
			{
				componentNotNull.InitiateComponent();
			}
			return componentNotNull;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public static HandPoserByName InitHandPoser(Animator anim, Side s)
		{
			HumanBodyBones humanBodyBones;
			switch (s)
			{
			case Side.L:
				humanBodyBones = HumanBodyBones.LeftHand;
				goto IL_0039;
			case Side.R:
				humanBodyBones = HumanBodyBones.RightHand;
				goto IL_0039;
			}
			throw new ArgumentOutOfRangeException(s.ToString());
			IL_0039:
			return FinalIKUtils.InitHandPoser(anim.GetBoneTransform(humanBodyBones), anim);
		}

		// Token: 0x0200010F RID: 271
		[Obsolete]
		[Serializable]
		public class ProyectOnUp
		{
			// Token: 0x0400066D RID: 1645
			public bool activar = true;

			// Token: 0x0400066E RID: 1646
			[Range(0f, 1f)]
			public float maxModAdelante = 0.15f;

			// Token: 0x0400066F RID: 1647
			[Range(0f, 1f)]
			public float maxModAtras = 0.9f;

			// Token: 0x04000670 RID: 1648
			public float power = 1.5f;
		}
	}
}

using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.FinalIK;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020000CB RID: 203
	public class EffectorsController : ControllerColaDePrioridadBase<EffectorsController.Stado, EffectorsController.Orden, EffectorsController.Colas, EffectorsController, EffectorsController.Tipo>
	{
		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00023D46 File Offset: 0x00021F46
		public Transform animatorTransform
		{
			get
			{
				return this.m_animatorEffector.transform;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x00023D53 File Offset: 0x00021F53
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update3);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00023D5B File Offset: 0x00021F5B
		protected override int cantidadDeEstados
		{
			get
			{
				return 9;
			}
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00023D60 File Offset: 0x00021F60
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Animator componentInChildren = (this.m_AnimatorCharacter = base.GetComponentInParent<AnimatorCharacter>()).GetComponentInChildren<Animator>();
			IIKUpdater componentEnRoot = this.GetComponentEnRoot(false);
			IReadOnlyList<Component> readOnlyList = componentEnRoot.SortedIKsDeLayer(0);
			if (componentEnRoot.CantidadDePasadasDeIK(0) < 2)
			{
				Debug.LogWarning("seria bueno tener mas de una pasada de ik:", readOnlyList[0]);
			}
			this.m_animatorEffector = componentInChildren.transform.CreateChild("EffectorDe_" + base.GetType().Name).gameObject.AddComponent<LocalEffectorOffset>();
			this.m_animatorEffector.Init(IKLayerFlag.primero, IKOrderFlag.primero, IKPassOrderFlag.ultimo);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				Component component = readOnlyList[i];
				((FullBodyBipedIK)component).solver.leftHandEffector.maintainRelativePositionWeight = 0.2f;
				((FullBodyBipedIK)component).solver.rightHandEffector.maintainRelativePositionWeight = 0.2f;
			}
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00023E3B File Offset: 0x0002203B
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_animatorEffector)
			{
				Object.Destroy(this.m_animatorEffector.gameObject);
			}
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00023E61 File Offset: 0x00022061
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_animatorEffector.weight = 0f;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00023E7A File Offset: 0x0002207A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_animatorEffector.weight = 1f;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00023E94 File Offset: 0x00022094
		public bool TryMove(EffectorsController.Tipo tipo, Vector3 worldOffset, float duracion, int prioridad, AnimationCurve curve = null, EffectorsController.Tipo? tipo2 = null)
		{
			return this.TryMoveComplete(tipo, worldOffset, duracion, EffectorsController.EffectorType.animator, prioridad, ControllerPrioridadConfig.prioridad, false, null, null, true, curve, true, tipo2);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00023EB8 File Offset: 0x000220B8
		public bool TryMove(EffectorsController.Tipo tipo, Vector3 worldOffset, float duracion, int prioridad, bool prioridadInclusive, AnimationCurve curve = null, bool convinable = true, EffectorsController.Tipo? tipo2 = null)
		{
			return this.TryMoveComplete(tipo, worldOffset, duracion, EffectorsController.EffectorType.animator, prioridad, ControllerPrioridadConfig.prioridad, prioridadInclusive, null, null, true, curve, convinable, tipo2);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00023EE0 File Offset: 0x000220E0
		public bool TryMoveComplete(EffectorsController.Tipo tipo, Vector3 offset, float duracion, EffectorsController.EffectorType effectorType, int prioridad, ControllerPrioridadConfig priConfig, bool prioridadInclusive, Action<EffectorsController.Orden> comenzadaCallBack, Action<EffectorsController.Orden> terminadaCallBack, bool isWorldOffset = true, AnimationCurve curve = null, bool convinable = true, EffectorsController.Tipo? tipo2 = null)
		{
			if (this.debugLog)
			{
				Debug.Log("//Mode de Tipo: " + tipo.ToString() + ", TryMove().");
			}
			if (offset == Vector3.zero)
			{
				throw new InvalidOperationException("controllador de efector, orden con offset zero");
			}
			EffectorsController.Orden orden;
			if (base.OrdenAnuladaPorPrioridadBaja(priConfig, tipo, out orden))
			{
				if (this.debugLog)
				{
					Debug.Log("Mode de Tipo: " + tipo.ToString() + ", anulado por PrioridadBaja");
				}
				return false;
			}
			bool flag = false;
			if (base.OrdenAnuladaPorPrioridadMenor(priConfig, prioridad, tipo, prioridadInclusive, out orden, out flag))
			{
				if (this.debugLog)
				{
					Debug.Log("Mode de Tipo: " + tipo.ToString() + ", anulado por PrioridadMenor");
				}
				return false;
			}
			if (priConfig == ControllerPrioridadConfig.interrumpir && !base.TipoDeOrdenEstaLibre(tipo, out orden))
			{
				flag = true;
			}
			bool flag2 = this.permitirCombinaciones && convinable && flag && orden.stared;
			bool flag3 = false;
			float num = 0f;
			if (flag2)
			{
				AnimationCurve animationCurve = curve;
				Keyframe keyframe = orden.CurrentKey(this.m_curve);
				float num2;
				curve = EffectorsController.ConvinarV3((curve == null) ? this.m_curve : curve, keyframe, out num2);
				num = duracion * num2;
				duracion += num;
				if (this.m_DebugCurvaGenerada.debugConvinacionDeCurvas)
				{
					this.m_DebugCurvaGenerada.debugCurvaConvinada = curve;
					this.m_DebugCurvaGenerada.debugCurvaOriginal = animationCurve;
				}
				flag3 = true;
				if (this.debugLog)
				{
					Debug.Log(string.Concat(new string[]
					{
						"Convinacion de Curvas: ORIGINAL: t:",
						keyframe.time.ToString(),
						" v:",
						keyframe.value.ToString(),
						" NUEVA: t:",
						curve[0].time.ToString(),
						" v:",
						curve[0].value.ToString()
					}));
				}
			}
			EffectorsController.Orden orden2 = new EffectorsController.Orden(tipo, prioridad, duracion, priConfig, comenzadaCallBack, terminadaCallBack);
			orden2.offset = this.ObtenerEffector(effectorType).transform.InverseTransformDirection(offset);
			orden2.effectorType = effectorType;
			orden2.curve = curve;
			if (flag3)
			{
				Vector3 vector;
				if (orden.isBlending)
				{
					if (this.debugLog)
					{
						Debug.Log("FROM as Blending");
					}
					vector = orden.ObtenerCurrentBlend();
				}
				else
				{
					vector = orden.offset;
				}
				orden2.FlagAsBlending(num, vector);
				if (this.debugLog)
				{
					Debug.Log(string.Concat(new string[]
					{
						"SET Blending Offsets: CURRENT*1000: ",
						(orden2.ObtenerCurrentBlend() * 1000f).ToString(),
						" FROM*1000: ",
						(vector * 1000f).ToString(),
						" TARGET*1000: ",
						(orden2.offset * 1000f).ToString()
					}));
				}
			}
			if (orden != null && orden.tipo != orden2.tipo)
			{
				throw new InvalidOperationException();
			}
			base.Procesar(orden == null, flag, priConfig, orden2, true, this.debugLog);
			if (this.debugLog)
			{
				Debug.Log("//Mode de Tipo: " + tipo.ToString() + ", PROCESADO.");
			}
			if (tipo2 != null)
			{
				bool flag4 = this.TryMoveComplete(tipo2.Value, offset, duracion, effectorType, prioridad, priConfig, prioridadInclusive, comenzadaCallBack, terminadaCallBack, isWorldOffset, curve, convinable, null);
				if (this.debugLog && !flag4)
				{
					Debug.Log("Tipo2:" + tipo2.Value.ToString() + " no pudo Moverse.");
				}
			}
			return true;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x000242A8 File Offset: 0x000224A8
		[Obsolete]
		public void Move(EffectorsController.Tipo tipo, Vector3 offset, float time, EffectorsController.EffectorType effectorType, int prioridad, ControllerPrioridadConfig priConfig, bool prioridadInclusive, bool isWorldOffset = true, AnimationCurve curve = null, EffectorsController.Tipo? tipo2 = null)
		{
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000242AC File Offset: 0x000224AC
		public static AnimationCurve ConvinarV3(AnimationCurve basica, Keyframe currentKey, out float duracionAñadida)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(new Keyframe(0f, currentKey.value));
			Keyframe keyframe = basica[0];
			float time = basica[basica.length - 1].time;
			duracionAñadida = EffectorsController.CalcularTiempoAnumentar(currentKey, keyframe);
			for (int i = 0; i < basica.length; i++)
			{
				Keyframe keyframe2 = basica[i];
				float num = keyframe2.value;
				if (i == 0)
				{
					num = Mathf.Clamp(Mathf.Lerp(num, currentKey.value, 0.55f), -1f, 1f);
				}
				animationCurve.AddKey(EffectorsController.TiempoComprimido(keyframe2.time, time, time + duracionAñadida), num);
			}
			for (int j = 0; j < animationCurve.length; j++)
			{
				animationCurve.SmoothTangents(j, 0f);
			}
			return animationCurve;
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0002438C File Offset: 0x0002258C
		public static AnimationCurve ConvinarV2(AnimationCurve target, Keyframe currentKey, out float duracionMod)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(new Keyframe(0f, currentKey.value));
			float time = target[target.length - 1].time;
			Keyframe keyframe = target[0];
			int num = 0;
			Keyframe keyframe2 = target[1];
			float num2 = keyframe.value - currentKey.value;
			float num3 = keyframe2.value - currentKey.value;
			bool flag = (num2 <= currentKey.value && num3 <= currentKey.value) || (num2 >= currentKey.value && num3 >= currentKey.value);
			if (!flag || (flag && Mathf.Abs(num2) > Mathf.Abs(num3)))
			{
				num = 1;
			}
			Keyframe keyframe3 = target[num];
			float num4 = time - keyframe3.time;
			float num5 = EffectorsController.CalcularTiempoAnumentar(currentKey, keyframe3);
			float num6 = time - (num4 + num5);
			duracionMod = Mathf.InverseLerp(0f, time, time - num6);
			for (int i = num; i < target.length; i++)
			{
				Keyframe keyframe4 = target[i];
				animationCurve.AddKey(keyframe4.time - num6, keyframe4.value);
			}
			for (int j = 0; j < animationCurve.length; j++)
			{
				animationCurve.SmoothTangents(j, 0f);
			}
			return animationCurve;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x000244E8 File Offset: 0x000226E8
		public Transform ObtenerBoneDeTipo(EffectorsController.Tipo tipo)
		{
			switch (tipo)
			{
			case EffectorsController.Tipo.body:
				return this.m_AnimatorCharacter.bones.hips.transform;
			case EffectorsController.Tipo.leftShoulder:
				return this.m_AnimatorCharacter.bones.armsL.transform;
			case EffectorsController.Tipo.rightShoulder:
				return this.m_AnimatorCharacter.bones.armsR.transform;
			case EffectorsController.Tipo.leftThigh:
				return this.m_AnimatorCharacter.bones.legL.transform;
			case EffectorsController.Tipo.rightThigh:
				return this.m_AnimatorCharacter.bones.legR.transform;
			case EffectorsController.Tipo.leftHand:
				return this.m_AnimatorCharacter.bones.handL.transform;
			case EffectorsController.Tipo.rightHand:
				return this.m_AnimatorCharacter.bones.handR.transform;
			case EffectorsController.Tipo.leftFoot:
				return this.m_AnimatorCharacter.bones.footL.transform;
			case EffectorsController.Tipo.rightFoot:
				return this.m_AnimatorCharacter.bones.footR.transform;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000245FC File Offset: 0x000227FC
		private static float CalcularTiempoAnumentar(Keyframe key, Keyframe primeraKey)
		{
			return Mathf.Abs(key.value - primeraKey.value) * 0.75f;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00024618 File Offset: 0x00022818
		private static Keyframe TiempoComprimido(Keyframe original, float duracionOriginal, float nuevaDuracion)
		{
			float num = nuevaDuracion - duracionOriginal;
			return new Keyframe((duracionOriginal * original.time + num) / nuevaDuracion, original.value);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00024644 File Offset: 0x00022844
		private static float TiempoComprimido(float time, float duracionOriginal, float nuevaDuracion)
		{
			float num = nuevaDuracion - duracionOriginal;
			return (duracionOriginal * time + num) / nuevaDuracion;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0002465C File Offset: 0x0002285C
		public static AnimationCurve Convinar(AnimationCurve target, Keyframe key)
		{
			int num = -1;
			float num2 = float.MaxValue;
			Vector2 vector = new Vector2(key.time, key.value);
			for (int i = 0; i < target.length; i++)
			{
				Keyframe keyframe = target[i];
				float num3 = Vector2.Distance(new Vector2(keyframe.time, keyframe.value), vector);
				float num4 = keyframe.time - key.time;
				if (num3 < num2 && num4 > 0f)
				{
					num2 = num3;
					num = i;
				}
			}
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(new Keyframe(0f, key.value));
			for (int j = num; j < target.length; j++)
			{
				animationCurve.AddKey(target[j]);
			}
			animationCurve.SmoothTangents(0, 1f);
			return animationCurve;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00024734 File Offset: 0x00022934
		public TValleEffectorOffsetInteremedio ObtenerEffector(EffectorsController.EffectorType effectorType)
		{
			if (effectorType == EffectorsController.EffectorType.animator)
			{
				return this.m_animatorEffector;
			}
			throw new ArgumentOutOfRangeException(effectorType.ToString());
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00024752 File Offset: 0x00022952
		public override EffectorsController.Tipo ParseIndexToTipoId(int index)
		{
			return (EffectorsController.Tipo)index;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00024755 File Offset: 0x00022955
		public override int ParseTipoIdToindex(EffectorsController.Tipo id)
		{
			return (int)id;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00024758 File Offset: 0x00022958
		protected override EffectorsController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0002475C File Offset: 0x0002295C
		public static FullBodyBipedEffector ParceTipoAFullBodyBipedEffector(EffectorsController.Tipo tipo)
		{
			switch (tipo)
			{
			case EffectorsController.Tipo.body:
				return FullBodyBipedEffector.Body;
			case EffectorsController.Tipo.leftShoulder:
				return FullBodyBipedEffector.LeftShoulder;
			case EffectorsController.Tipo.rightShoulder:
				return FullBodyBipedEffector.RightShoulder;
			case EffectorsController.Tipo.leftThigh:
				return FullBodyBipedEffector.LeftThigh;
			case EffectorsController.Tipo.rightThigh:
				return FullBodyBipedEffector.RightThigh;
			case EffectorsController.Tipo.leftHand:
				return FullBodyBipedEffector.LeftHand;
			case EffectorsController.Tipo.rightHand:
				return FullBodyBipedEffector.RightHand;
			case EffectorsController.Tipo.leftFoot:
				return FullBodyBipedEffector.LeftFoot;
			case EffectorsController.Tipo.rightFoot:
				return FullBodyBipedEffector.RightFoot;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x04000505 RID: 1285
		public bool debugLog;

		// Token: 0x04000506 RID: 1286
		public bool debugDraw;

		// Token: 0x04000507 RID: 1287
		public bool permitirCombinaciones = true;

		// Token: 0x04000508 RID: 1288
		private LocalEffectorOffset m_animatorEffector;

		// Token: 0x04000509 RID: 1289
		[Obsolete("", true)]
		private LocalEffectorOffset m_pelvisEffector;

		// Token: 0x0400050A RID: 1290
		[SerializeField]
		private AnimationCurve m_curve;

		// Token: 0x0400050B RID: 1291
		[SerializeField]
		private EffectorsController.DebugCurvaGenerada m_DebugCurvaGenerada;

		// Token: 0x0400050C RID: 1292
		private AnimatorCharacter m_AnimatorCharacter;

		// Token: 0x020001A0 RID: 416
		public enum EffectorType
		{
			// Token: 0x04000952 RID: 2386
			animator
		}

		// Token: 0x020001A1 RID: 417
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<EffectorsController.Stado, EffectorsController.Orden, EffectorsController.Colas, EffectorsController, EffectorsController.Tipo>.OrdenBaseDeControllador
		{
			// Token: 0x06000C84 RID: 3204 RVA: 0x000385B1 File Offset: 0x000367B1
			public Orden(EffectorsController.Tipo id, int prioridad, float duracion, ControllerPrioridadConfig priConfig, Action<EffectorsController.Orden> comenzadaCallBack, Action<EffectorsController.Orden> terminadaCallBack)
				: base(id, prioridad, duracion, priConfig, comenzadaCallBack, terminadaCallBack)
			{
			}

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x06000C85 RID: 3205 RVA: 0x000385CD File Offset: 0x000367CD
			public EffectorsController.Tipo tipo
			{
				get
				{
					return base.tipoId;
				}
			}

			// Token: 0x17000263 RID: 611
			// (get) Token: 0x06000C86 RID: 3206 RVA: 0x000385D5 File Offset: 0x000367D5
			public bool isBlending
			{
				get
				{
					return this.m_flagToBlend || this.m_isBlending.isOn;
				}
			}

			// Token: 0x17000264 RID: 612
			// (get) Token: 0x06000C87 RID: 3207 RVA: 0x000385EC File Offset: 0x000367EC
			public float blendingWeight
			{
				get
				{
					if (this.m_flagToBlend)
					{
						return 0f;
					}
					return Mathf.InverseLerp(0.1f, 1f, 1f - this.m_isBlending.mod);
				}
			}

			// Token: 0x06000C88 RID: 3208 RVA: 0x0003861C File Offset: 0x0003681C
			public void FlagAsBlending(float duracionDeBlending, Vector3 fromOffset)
			{
				if (duracionDeBlending <= 0f)
				{
					duracionDeBlending = base.duracion * 0.1f;
				}
				if (this.isBlending)
				{
					throw new NotSupportedException();
				}
				this.m_BlendingFromOffset = fromOffset;
				if (!base.stared)
				{
					this.m_flagToBlendTime = duracionDeBlending;
					this.m_flagToBlend = true;
					return;
				}
				duracionDeBlending = Mathf.Min(duracionDeBlending, base.tiempoRestante);
				if (duracionDeBlending <= 0f)
				{
					return;
				}
				this.m_isBlending.ApplyNext(duracionDeBlending);
			}

			// Token: 0x06000C89 RID: 3209 RVA: 0x00038690 File Offset: 0x00036890
			public Vector3 ObtenerCurrentBlend()
			{
				if (!this.isBlending)
				{
					throw new InvalidOperationException();
				}
				if (this.m_BlendingFromOffset.sqrMagnitude == 0f)
				{
					Debug.LogError("Blending es zero");
				}
				return Vector3.Lerp(this.m_BlendingFromOffset, this.offset, this.blendingWeight);
			}

			// Token: 0x06000C8A RID: 3210 RVA: 0x000386E0 File Offset: 0x000368E0
			private void ObtenerOffsetYEvaluacion(EffectorsController dataUpdate, out Vector3 Offset, out float Evaluacion)
			{
				float currentTimeMod = base.currentTimeMod;
				AnimationCurve animationCurve = ((this.curve == null) ? dataUpdate.m_curve : this.curve);
				Evaluacion = animationCurve.Evaluate(currentTimeMod);
				Evaluacion = Mathf.Clamp(Evaluacion, -1f, 1f);
				if (this.isBlending)
				{
					Offset = this.ObtenerCurrentBlend();
					return;
				}
				Offset = this.offset;
			}

			// Token: 0x06000C8B RID: 3211 RVA: 0x00038748 File Offset: 0x00036948
			protected override void OnDetenidaPorUsuario(EffectorsController dataUpdate)
			{
				if (this.effectorType == EffectorsController.EffectorType.animator)
				{
					this.SetTarget(dataUpdate.m_animatorEffector, Vector3.zero, dataUpdate);
					return;
				}
				throw new ArgumentOutOfRangeException();
			}

			// Token: 0x06000C8C RID: 3212 RVA: 0x00038778 File Offset: 0x00036978
			protected override bool UpdateOrden(EffectorsController dataUpdate, bool esPrimerUpdate)
			{
				if (esPrimerUpdate && this.m_flagToBlend)
				{
					this.m_isBlending.ApplyNext(this.m_flagToBlendTime);
					this.m_flagToBlend = false;
				}
				if (this.Termino())
				{
					if (this.effectorType == EffectorsController.EffectorType.animator)
					{
						this.SetTarget(dataUpdate.m_animatorEffector, Vector3.zero, dataUpdate);
						return false;
					}
					throw new ArgumentOutOfRangeException();
				}
				else
				{
					Vector3 vector;
					float num;
					this.ObtenerOffsetYEvaluacion(dataUpdate, out vector, out num);
					vector *= num;
					if (this.effectorType == EffectorsController.EffectorType.animator)
					{
						this.SetTarget(dataUpdate.m_animatorEffector, vector, dataUpdate);
						base.DisminuirPrioridadAcumulativaDelta(0.2f);
						return true;
					}
					throw new ArgumentOutOfRangeException();
				}
			}

			// Token: 0x06000C8D RID: 3213 RVA: 0x00038814 File Offset: 0x00036A14
			private void SetTarget(LocalEffectorOffset effector, Vector3 nuevoOffset, EffectorsController dataUpdate)
			{
				if (dataUpdate.debugDraw)
				{
					dataUpdate.ObtenerBoneDeTipo(this.tipo);
					effector.transform.TransformDirection(nuevoOffset);
				}
				switch (this.tipo)
				{
				case EffectorsController.Tipo.body:
					effector.bodyOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.leftShoulder:
					effector.leftShoulderOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.rightShoulder:
					effector.rightShoulderOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.leftThigh:
					effector.leftThighOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.rightThigh:
					effector.rightThighOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.leftHand:
					effector.leftHandOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.rightHand:
					effector.rightHandOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.leftFoot:
					effector.leftFootOffset = nuevoOffset;
					return;
				case EffectorsController.Tipo.rightFoot:
					effector.rightFootOffset = nuevoOffset;
					return;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}

			// Token: 0x06000C8E RID: 3214 RVA: 0x000388C4 File Offset: 0x00036AC4
			public Keyframe CurrentKey(AnimationCurve defaultcurve)
			{
				if (defaultcurve == null)
				{
					throw new ArgumentNullException("defaultcurve", "defaultcurve null reference.");
				}
				AnimationCurve animationCurve = ((this.curve == null) ? defaultcurve : this.curve);
				if (!base.stared)
				{
					return animationCurve[0];
				}
				float num = (Time.time - base.startTime) / base.duracion;
				float num2 = animationCurve.Evaluate(num);
				return new Keyframe(num, num2);
			}

			// Token: 0x06000C8F RID: 3215 RVA: 0x0003892C File Offset: 0x00036B2C
			public Keyframe CurrentKey(AnimationCurve defaultcurve, out Keyframe beforeCurrentKey)
			{
				Keyframe keyframe = this.CurrentKey(defaultcurve);
				AnimationCurve animationCurve = ((this.curve == null) ? defaultcurve : this.curve);
				for (int i = animationCurve.length - 1; i >= 0; i--)
				{
					Keyframe keyframe2 = animationCurve[i];
					if (keyframe2.time <= keyframe.time)
					{
						beforeCurrentKey = keyframe2;
						return keyframe;
					}
				}
				beforeCurrentKey = animationCurve[0];
				return keyframe;
			}

			// Token: 0x06000C90 RID: 3216 RVA: 0x00038995 File Offset: 0x00036B95
			protected override void OnTerminada(EffectorsController dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x06000C91 RID: 3217 RVA: 0x00038997 File Offset: 0x00036B97
			protected override bool OnTerminando(EffectorsController dataUpdate, bool primerUpdate, EffectorsController.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000C92 RID: 3218 RVA: 0x0003899A File Offset: 0x00036B9A
			protected override void OnStart(EffectorsController dataUpdate)
			{
			}

			// Token: 0x04000953 RID: 2387
			public Vector3 offset;

			// Token: 0x04000954 RID: 2388
			public EffectorsController.EffectorType effectorType;

			// Token: 0x04000955 RID: 2389
			public AnimationCurve curve;

			// Token: 0x04000956 RID: 2390
			[SerializeField]
			[ReadOnlyUI]
			private CoolDown m_isBlending = new CoolDown();

			// Token: 0x04000957 RID: 2391
			[SerializeField]
			[ReadOnlyUI]
			private Vector3 m_BlendingFromOffset;

			// Token: 0x04000958 RID: 2392
			private bool m_flagToBlend;

			// Token: 0x04000959 RID: 2393
			private float m_flagToBlendTime;
		}

		// Token: 0x020001A2 RID: 418
		[Serializable]
		public class DebugCurvaGenerada
		{
			// Token: 0x0400095A RID: 2394
			public bool debugConvinacionDeCurvas;

			// Token: 0x0400095B RID: 2395
			public AnimationCurve debugCurvaOriginal;

			// Token: 0x0400095C RID: 2396
			public AnimationCurve debugCurvaConvinada;
		}

		// Token: 0x020001A3 RID: 419
		public sealed class Colas : ControllerColaDePrioridadBase<EffectorsController.Stado, EffectorsController.Orden, EffectorsController.Colas, EffectorsController, EffectorsController.Tipo>.ColasBase
		{
		}

		// Token: 0x020001A4 RID: 420
		public sealed class Stado : ControllerColaDePrioridadBase<EffectorsController.Stado, EffectorsController.Orden, EffectorsController.Colas, EffectorsController, EffectorsController.Tipo>.StadoBase
		{
		}

		// Token: 0x020001A5 RID: 421
		public enum Tipo
		{
			// Token: 0x0400095E RID: 2398
			body,
			// Token: 0x0400095F RID: 2399
			leftShoulder,
			// Token: 0x04000960 RID: 2400
			rightShoulder,
			// Token: 0x04000961 RID: 2401
			leftThigh,
			// Token: 0x04000962 RID: 2402
			rightThigh,
			// Token: 0x04000963 RID: 2403
			leftHand,
			// Token: 0x04000964 RID: 2404
			rightHand,
			// Token: 0x04000965 RID: 2405
			leftFoot,
			// Token: 0x04000966 RID: 2406
			rightFoot
		}
	}
}

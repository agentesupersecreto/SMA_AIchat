using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.UserControllers;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers
{
	// Token: 0x020001AB RID: 427
	[RequireComponent(typeof(PelvisMovementController))]
	public sealed class PelvisMovementLimitSegunHoleFondo : MovementLimitSegunHoleFondoBase
	{
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000A32 RID: 2610 RVA: 0x000329CE File Offset: 0x00030BCE
		protected override bool isMoving
		{
			get
			{
				return this.m_PelvisMovementController.isMovingPelvis || base.holeOwner.enAutoInteraccionCoitalHead || base.holeOwner.enAutoInteraccionCoitalHips;
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x000329F8 File Offset: 0x00030BF8
		protected override float acumulandoForceMod
		{
			get
			{
				InputProxyVirtuales characterMovement = Singleton<PlayerInputProxy>.instance.characterMovement;
				float num = 1f;
				if (characterMovement.goingFaster && this.m_PelvisMovementController.isMovingPelvis)
				{
					num *= 2f;
				}
				if (characterMovement.goingSlower && this.m_PelvisMovementController.isMovingPelvis)
				{
					num *= 0.5f;
				}
				return num;
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x00032A50 File Offset: 0x00030C50
		protected override float acumulandoForceModPorAceptacion
		{
			get
			{
				if (base.hole == null)
				{
					return 0f;
				}
				if (this.m_aceptaciones == null)
				{
					return 1f;
				}
				float num = ((base.holeOwner.enAutoInteraccionCoitalHead || base.holeOwner.enAutoInteraccionCoitalHips) ? 1f : 0.333f);
				float num2 = ((base.hole is IBocaHole) ? 0.333f : 1f);
				float num3 = Mathf.InverseLerp(0f, 1f, this.m_aceptaciones.GetLastMaxScoreParaPene(base.hole)).OutPow(2f);
				num3 = Mathf.Lerp(this.configInverted.minForceModWhenNoAceptacionV2, 1f, num3);
				return num * num2 * num3;
			}
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00032B08 File Offset: 0x00030D08
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PelvisMovementController = base.GetComponent<PelvisMovementController>();
			this.m_pelvisByMouseUserControl = base.GetComponent<PelvisMovementMouseUserController>();
			this.m_modSensiX = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoX.ObtenerModificadorNotNull(this);
			this.m_modSensiMinusX = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoMinusX.ObtenerModificadorNotNull(this);
			this.m_modSensiY = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoY.ObtenerModificadorNotNull(this);
			this.m_modSensiMinusY = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoMinusY.ObtenerModificadorNotNull(this);
			this.m_modSensiZ = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoZ.ObtenerModificadorNotNull(this);
			this.m_modSensiMinusZ = this.m_PelvisMovementController.modificableDeDificultadDeMovimientoMinusZ.ObtenerModificadorNotNull(this);
			this.m_PelvisMovementController.updatingPelvisPosition += this.M_PelvisMovementController_updatingPelvisPosition;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00032BD4 File Offset: 0x00030DD4
		protected override Penetrador TryGetPenetrator()
		{
			return this.GetComponentEnRoot(true);
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00032BE0 File Offset: 0x00030DE0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_modSensiX != null)
			{
				this.m_modSensiX.valor.valor = 1f;
			}
			if (this.m_modSensiMinusX != null)
			{
				this.m_modSensiMinusX.valor.valor = 1f;
			}
			if (this.m_modSensiY != null)
			{
				this.m_modSensiY.valor.valor = 1f;
			}
			if (this.m_modSensiMinusY != null)
			{
				this.m_modSensiMinusY.valor.valor = 1f;
			}
			if (this.m_modSensiZ != null)
			{
				this.m_modSensiZ.valor.valor = 1f;
			}
			if (this.m_modSensiMinusZ != null)
			{
				this.m_modSensiMinusZ.valor.valor = 1f;
			}
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00032CA4 File Offset: 0x00030EA4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat modSensiX = this.m_modSensiX;
			if (modSensiX != null)
			{
				modSensiX.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modSensiMinusX = this.m_modSensiMinusX;
			if (modSensiMinusX != null)
			{
				modSensiMinusX.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modSensiY = this.m_modSensiY;
			if (modSensiY != null)
			{
				modSensiY.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modSensiMinusY = this.m_modSensiMinusY;
			if (modSensiMinusY != null)
			{
				modSensiMinusY.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modSensiZ = this.m_modSensiZ;
			if (modSensiZ != null)
			{
				modSensiZ.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modSensiMinusZ = this.m_modSensiMinusZ;
			if (modSensiMinusZ != null)
			{
				modSensiMinusZ.TryRemoverDeOwner(true);
			}
			if (this.m_PelvisMovementController)
			{
				this.m_PelvisMovementController.updatingPelvisPosition -= this.M_PelvisMovementController_updatingPelvisPosition;
			}
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00032D50 File Offset: 0x00030F50
		private void M_PelvisMovementController_updatingPelvisPosition(ref Vector3 currentLocalTarget, Transform effectorTransform, PelvisMovementController sender)
		{
			try
			{
				this.m_modSensiX.valor.valor = 1f;
				this.m_modSensiMinusX.valor.valor = 1f;
				this.m_modSensiY.valor.valor = 1f;
				this.m_modSensiMinusY.valor.valor = 1f;
				this.m_modSensiZ.valor.valor = 1f;
				this.m_modSensiMinusZ.valor.valor = 1f;
				if (base.enabled)
				{
					if (this.m_peneAdentro)
					{
						float num;
						float num2;
						PelvisMovementLimitSegunHoleFondo.CalculePenW(this.config, this.configInverted, this.m_fondo, this.m_ancho, this.m_entrada, out num, out num2);
						float num3 = num.InPow(this.config.penWInPowerToForce);
						float num4 = num2.InPow(this.configInverted.penWInPowerToForce);
						InputProxyVirtuales characterMovement = Singleton<PlayerInputProxy>.instance.characterMovement;
						bool activo = this.m_pelvisByMouseUserControl.activo;
						PelvisMovementLimitSegunHoleFondo.MovePelvisPorDeuda(ref currentLocalTarget, ref this.m_deudaAcumulada, activo, characterMovement.goingDown, !characterMovement.goingDown, this.config.deudaRestoreSpeed, 1f - num3);
						PelvisMovementLimitSegunHoleFondo.MovePelvisPorDeuda(ref currentLocalTarget, ref this.m_deudaAcumuladaInvertida, activo, characterMovement.goingDown, !characterMovement.goingDown, this.configInverted.deudaRestoreSpeed, 1f - num4);
						PelvisMovementLimitSegunHoleFondo.MovePelvisTarget(ref currentLocalTarget, this.m_forceAcumulada, this.m_forceAcumuladaInvertida, num3, num4, activo, characterMovement.goingDown, !characterMovement.goingDown, effectorTransform, this.weight, this.config, this.configInverted, this.debugDraw);
						Vector3 localDirToHole = this.GetLocalDirToHole(effectorTransform);
						if (num > 0f)
						{
							this.SetMods(localDirToHole, num, (!activo) ? this.config.sensibilidadMin : this.config.sensibilidadMinGrabingDick, this.config.penWOutPowerToInputs);
						}
						if (num2 > 0f)
						{
							this.SetMods(-localDirToHole, num2, (!activo) ? this.configInverted.sensibilidadMin : this.configInverted.sensibilidadMinGrabingDick, this.configInverted.penWOutPowerToInputs);
						}
					}
					else
					{
						float num5 = MovementLimitSegunHoleFondoBase.CalculeStressModPolarizado(this.m_Penetrador, this.configPenisStress);
						float num6 = 0f;
						float num7 = 0f;
						if (num5 > 0f)
						{
							num6 = Mathf.Abs(num5);
						}
						else
						{
							num7 = Mathf.Abs(num5);
						}
						InputProxyVirtuales characterMovement2 = Singleton<PlayerInputProxy>.instance.characterMovement;
						bool activo2 = this.m_pelvisByMouseUserControl.activo;
						PelvisMovementLimitSegunHoleFondo.MovePelvisTarget(ref currentLocalTarget, this.m_forceAcumulada, this.m_forceAcumuladaInvertida, num6, num7, activo2, characterMovement2.goingDown, !characterMovement2.goingDown, effectorTransform, this.weight);
						Vector3 localDirNoHole = this.GetLocalDirNoHole(effectorTransform);
						if (num6 > 0f)
						{
							this.SetMods(localDirNoHole, num6, this.config.sensibilidadMin, this.config.penWOutPowerToInputs);
						}
						if (num7 > 0f)
						{
							this.SetMods(-localDirNoHole, num7, this.configInverted.sensibilidadMin, this.configInverted.penWOutPowerToInputs);
						}
					}
				}
			}
			finally
			{
				this.m_forceAcumulada = Vector3.zero;
				this.m_forceAcumuladaInvertida = Vector3.zero;
			}
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0003309C File Offset: 0x0003129C
		private Vector3 GetLocalDirToHole(Transform effectorTransform)
		{
			Vector3 vector = this.m_hole.entrada.position - effectorTransform.position;
			Vector3 vector2 = -Math3d.ProjectDirectionOnConeSurfaceOrInside(this.m_hole.worldOutHoleDirection, this.configPelvis.maxAngleConeDificulty, -vector);
			return effectorTransform.InverseTransformDirection(vector2);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x000330F4 File Offset: 0x000312F4
		private Vector3 GetLocalDirNoHole(Transform effectorTransform)
		{
			Vector3 vector = this.m_Penetrador.penisLinearChain.tipBone.position - effectorTransform.position;
			Vector3 vector2 = -Math3d.ProjectDirectionOnConeSurfaceOrInside(-this.m_Penetrador.rootDefaultForwardWorldDirection, this.configPelvis.maxAngleConeDificulty, -vector);
			return effectorTransform.InverseTransformDirection(vector2);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00033158 File Offset: 0x00031358
		private void SetMods(Vector3 localDirToHoleProyected, float penW, float sensibilidadMin, float outPower)
		{
			penW = penW.OutPow(outPower);
			float num = Vector3.Angle(localDirToHoleProyected, Vector3.forward);
			float num2 = Vector3.Angle(localDirToHoleProyected, Vector3.up);
			float num3 = Vector3.Angle(localDirToHoleProyected, Vector3.right);
			float num4 = Mathf.InverseLerp(90f, 0f, num3);
			float num5 = Mathf.InverseLerp(90f, 180f, num3);
			float num6 = Mathf.InverseLerp(90f, 0f, num2);
			float num7 = Mathf.InverseLerp(90f, 180f, num2);
			float num8 = Mathf.InverseLerp(90f, 0f, num);
			float num9 = Mathf.InverseLerp(90f, 180f, num);
			float num10 = Mathf.Lerp(1f, sensibilidadMin, penW);
			ModificadorDeFloat modSensiX = this.m_modSensiX;
			modSensiX.valor.valor = modSensiX.valor.valor * Mathf.Lerp(1f, num10, num4);
			ModificadorDeFloat modSensiMinusX = this.m_modSensiMinusX;
			modSensiMinusX.valor.valor = modSensiMinusX.valor.valor * Mathf.Lerp(1f, num10, num5);
			ModificadorDeFloat modSensiY = this.m_modSensiY;
			modSensiY.valor.valor = modSensiY.valor.valor * Mathf.Lerp(1f, num10, num6);
			ModificadorDeFloat modSensiMinusY = this.m_modSensiMinusY;
			modSensiMinusY.valor.valor = modSensiMinusY.valor.valor * Mathf.Lerp(1f, num10, num7);
			ModificadorDeFloat modSensiZ = this.m_modSensiZ;
			modSensiZ.valor.valor = modSensiZ.valor.valor * Mathf.Lerp(1f, num10, num8);
			ModificadorDeFloat modSensiMinusZ = this.m_modSensiMinusZ;
			modSensiMinusZ.valor.valor = modSensiMinusZ.valor.valor * Mathf.Lerp(1f, num10, num9);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000332D8 File Offset: 0x000314D8
		public static void MovePelvisPorDeuda(ref Vector3 pelvisLocalTarget, ref Vector3 deudaAcumulada, bool moveX, bool moveY, bool moveZ, float velocity, float w)
		{
			Vector3 vector = Vector3.Lerp(Vector3.zero, deudaAcumulada, Time.deltaTime * velocity);
			deudaAcumulada -= vector;
			vector *= w;
			if (moveY)
			{
				pelvisLocalTarget.y += vector.y;
			}
			if (moveZ)
			{
				pelvisLocalTarget.z += vector.z;
			}
			if (moveX)
			{
				pelvisLocalTarget.x += vector.x;
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00033354 File Offset: 0x00031554
		public static void CalculePenW(MovementLimitSegunHoleFondoBase.Config config, MovementLimitSegunHoleFondoBase.ConfigInverted configInverted, HoleFondoHitSkin fondo, HoleAnchuraHitSkin ancho, HoleEntradaHitSkin entrada, out float penetrationWeight, out float extraccionWeight)
		{
			penetrationWeight = 0f;
			extraccionWeight = 0f;
			for (int i = 0; i < fondo.checksDeCollisiones.Count; i++)
			{
				penetrationWeight = Mathf.Max(penetrationWeight, fondo.checksDeCollisiones[i].lastPenetrationWeightResistente);
			}
			for (int j = 0; j < ancho.checksDeCollisiones.Count; j++)
			{
				penetrationWeight = Mathf.Max(penetrationWeight, ancho.checksDeCollisiones[j].lastPenetrationWeight);
			}
			for (int k = 0; k < entrada.checksDeCollisiones.Count; k++)
			{
				extraccionWeight = Mathf.Max(extraccionWeight, entrada.checksDeCollisiones[k].lastPenetrationWeight);
			}
			penetrationWeight = Mathf.InverseLerp(config.applyForcesAfterPenW, 1f, penetrationWeight);
			extraccionWeight = Mathf.InverseLerp(configInverted.applyForcesAfterPenW, configInverted.applyForcesBeforePenW, extraccionWeight);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00033438 File Offset: 0x00031638
		public static void MovePelvisTarget(ref Vector3 pelvisLocalTarget, Vector3 forceAcumulada, Vector3 forceAcumuladaInvertida, float penetrationWeight, float extraccionWeight, bool moveX, bool moveY, bool moveZ, Transform transform, float weight, MovementLimitSegunHoleFondoBase.Config config, MovementLimitSegunHoleFondoBase.ConfigInverted configInverted, bool debugDraw)
		{
			forceAcumulada = forceAcumulada.ClampMagnitud(0f, config.maxforceMag);
			forceAcumuladaInvertida = forceAcumuladaInvertida.ClampMagnitud(0f, configInverted.maxforceMagV2);
			PelvisMovementLimitSegunHoleFondo.MovePelvisTarget(ref pelvisLocalTarget, forceAcumulada, forceAcumuladaInvertida, penetrationWeight, extraccionWeight, moveX, moveY, moveZ, transform, weight);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00033484 File Offset: 0x00031684
		public static void MovePelvisTarget(ref Vector3 pelvisLocalTarget, Vector3 forceAcumulada, Vector3 forceAcumuladaInvertida, float penetrationWeight, float extraccionWeight, bool moveX, bool moveY, bool moveZ, Transform transform, float weight)
		{
			Vector3 vector = transform.InverseTransformDirection(-forceAcumulada);
			Vector3 vector2 = transform.InverseTransformDirection(-forceAcumuladaInvertida);
			if (moveY)
			{
				pelvisLocalTarget.y += vector.y * weight * penetrationWeight;
				pelvisLocalTarget.y += vector2.y * weight * extraccionWeight;
			}
			if (moveZ)
			{
				pelvisLocalTarget.z += vector.z * weight * penetrationWeight;
				pelvisLocalTarget.z += vector2.z * weight * extraccionWeight;
			}
			if (moveX)
			{
				pelvisLocalTarget.x += vector.x * weight * penetrationWeight;
				pelvisLocalTarget.x += vector2.x * weight * extraccionWeight;
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0003353A File Offset: 0x0003173A
		protected override void OnPeneEnteredInHole(IHole target, IPene sender)
		{
			if (base.hole != null)
			{
				this.m_aceptaciones = base.hole.gameObject.GetComponentInParent<ICharacterRoot>().GetComponentInChildren<RecopiladorDeSexScores>();
			}
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0003355F File Offset: 0x0003175F
		protected override void OnPeneExitedInHole(IHole target, IPene sender)
		{
			this.m_aceptaciones = null;
		}

		// Token: 0x040007B1 RID: 1969
		[SerializeReference]
		private ModificadorDeFloat m_modSensiX;

		// Token: 0x040007B2 RID: 1970
		[SerializeReference]
		private ModificadorDeFloat m_modSensiMinusX;

		// Token: 0x040007B3 RID: 1971
		[SerializeReference]
		private ModificadorDeFloat m_modSensiY;

		// Token: 0x040007B4 RID: 1972
		[SerializeReference]
		private ModificadorDeFloat m_modSensiMinusY;

		// Token: 0x040007B5 RID: 1973
		[SerializeReference]
		private ModificadorDeFloat m_modSensiZ;

		// Token: 0x040007B6 RID: 1974
		[SerializeReference]
		private ModificadorDeFloat m_modSensiMinusZ;

		// Token: 0x040007B7 RID: 1975
		private PelvisMovementController m_PelvisMovementController;

		// Token: 0x040007B8 RID: 1976
		private PelvisMovementMouseUserController m_pelvisByMouseUserControl;

		// Token: 0x040007B9 RID: 1977
		private RecopiladorDeSexScores m_aceptaciones;

		// Token: 0x040007BA RID: 1978
		public PelvisMovementLimitSegunHoleFondo.ConfigPelvis configPelvis = new PelvisMovementLimitSegunHoleFondo.ConfigPelvis();

		// Token: 0x020001AC RID: 428
		[Serializable]
		public class ConfigPelvis
		{
			// Token: 0x040007BB RID: 1979
			public float maxAngleConeDificulty = 85f;
		}
	}
}

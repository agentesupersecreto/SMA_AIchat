using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Checkers
{
	// Token: 0x020000F6 RID: 246
	public class InteraccionRayCastChecker : InteraccionChecker
	{
		// Token: 0x06000933 RID: 2355 RVA: 0x00029DDC File Offset: 0x00027FDC
		public override bool DoCheck()
		{
			Transform transform;
			Vector3 vector;
			return this.DoCheck(out transform, out vector);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00029DF4 File Offset: 0x00027FF4
		public override bool DoCheck(out Transform obstacle, out Vector3 worldPosition)
		{
			bool ejecutandose = this.m_Interaccion.ejecutandose;
			for (int i = 0; i < this.m_Interaccion.datosDeParesDeEfecctors.effectorsInteractions.Count; i++)
			{
				InteraccionEffectorParInfo interaccionEffectorParInfo = this.m_Interaccion.datosDeParesDeEfecctors.effectorsInteractions[i];
				if (interaccionEffectorParInfo.activado && interaccionEffectorParInfo.isValid && this.CheckObj(interaccionEffectorParInfo.interactionObject, ejecutandose, out obstacle, out worldPosition))
				{
					return true;
				}
			}
			obstacle = null;
			worldPosition = Vector3.zero;
			return false;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00029E78 File Offset: 0x00028078
		private bool CheckObj(InteractionObjectV2Base obj, bool ejecutandose, out Transform obstacle, out Vector3 worldPosition)
		{
			if (obj == null)
			{
				obstacle = null;
				worldPosition = Vector3.zero;
				return false;
			}
			int layerMask = this.checking.GetLayerMask(this.extraLayerMask);
			InteractionTarget[] targets = obj.GetTargets();
			InteractionTargetTValle[] customTargets = obj.GetCustomTargets();
			foreach (InteractionTarget interactionTarget in targets)
			{
				bool flag = this.debugDraw;
				RaycastHit raycastHit;
				if ((interactionTarget.effectorType == FullBodyBipedEffector.Body || interactionTarget.effectorType == FullBodyBipedEffector.LeftShoulder || interactionTarget.effectorType == FullBodyBipedEffector.RightShoulder || interactionTarget.effectorType == FullBodyBipedEffector.LeftThigh || interactionTarget.effectorType == FullBodyBipedEffector.RightThigh) && this.Check(interactionTarget.transform, interactionTarget.effectorType, layerMask, ejecutandose, out raycastHit))
				{
					obstacle = raycastHit.transform;
					worldPosition = raycastHit.point;
					return true;
				}
			}
			foreach (InteractionTargetTValle interactionTargetTValle in customTargets)
			{
				bool flag2 = this.debugDraw;
				RaycastHit raycastHit2;
				if (interactionTargetTValle.effectorType == CustomBipedEffector.head && this.Check(interactionTargetTValle.transform, interactionTargetTValle.effectorType, layerMask, ejecutandose, out raycastHit2))
				{
					obstacle = raycastHit2.transform;
					worldPosition = raycastHit2.point;
					return true;
				}
			}
			obstacle = null;
			worldPosition = Vector3.zero;
			return false;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00029FB0 File Offset: 0x000281B0
		private bool Check(Transform target, CustomBipedEffector effector, int layerMask, bool ejecutandose, out RaycastHit hit)
		{
			DatosDeBoneBase datosDeBoneBase = base.currentCharacter.bones.Obtener(effector.ParceAHumanBone());
			Vector3 vector;
			if (!ejecutandose)
			{
				vector = datosDeBoneBase.posicionFinal;
			}
			else
			{
				vector = datosDeBoneBase.animationPosition;
			}
			return InteraccionRayCastChecker.Check(base.currentCharacter, vector, target.transform.position, layerMask, this.debugDraw, out hit);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0002A010 File Offset: 0x00028210
		private bool Check(Transform target, FullBodyBipedEffector effector, int layerMask, bool ejecutandose, out RaycastHit hit)
		{
			DatosDeBoneBase datosDeBoneBase = base.currentCharacter.bones.Obtener(effector.ParceAHumanBone());
			Vector3 vector;
			if (!ejecutandose)
			{
				vector = datosDeBoneBase.posicionFinal;
			}
			else
			{
				vector = datosDeBoneBase.animationPosition;
			}
			return InteraccionRayCastChecker.Check(base.currentCharacter, vector, target.transform.position, layerMask, this.debugDraw, out hit);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0002A070 File Offset: 0x00028270
		private static bool Check(IAnimatorCharacter owner, Vector3 start, Vector3 end, int layerMask, bool debugDraw, out RaycastHit hit)
		{
			Vector3 vector = end - start;
			int num = Physics.RaycastNonAlloc(start, vector, InteraccionRayCastChecker.results, vector.magnitude, layerMask, QueryTriggerInteraction.Ignore);
			bool flag = false;
			hit = default(RaycastHit);
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = InteraccionRayCastChecker.results[i];
				InteraccionRayCastChecker.results[i] = default(RaycastHit);
				if (!owner.ObjetoMePertenece(raycastHit.collider.transform))
				{
					hit = raycastHit;
					flag = true;
					break;
				}
			}
			if (debugDraw)
			{
				if (flag)
				{
					Debug.DrawLine(start, hit.point, Color.red, 2f, false);
				}
				else
				{
					Debug.DrawLine(start, end, Color.green, 2f, false);
				}
			}
			return flag;
		}

		// Token: 0x040005C4 RID: 1476
		public bool debugDraw;

		// Token: 0x040005C5 RID: 1477
		private static RaycastHit[] results = new RaycastHit[100];
	}
}

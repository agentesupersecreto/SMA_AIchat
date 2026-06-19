using System;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x02000231 RID: 561
	[RequireComponent(typeof(DetectorDeCollisionesDeCamaraDeCharacter))]
	public class MoverHombrosDeCharParaEscaparDeCollisionDeCamera : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x000424C6 File Offset: 0x000406C6
		public sealed override int updateEvent1Index
		{
			get
			{
				return 41;
			}
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x000424CC File Offset: 0x000406CC
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DetectorDeCollisionesDeCamaraDeCharacter = base.GetComponent<DetectorDeCollisionesDeCamaraDeCharacter>();
			if (!this.m_DetectorDeCollisionesDeCamaraDeCharacter.isAwaken)
			{
				this.m_DetectorDeCollisionesDeCamaraDeCharacter.ManualAwake();
			}
			if (this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.character.isStared)
			{
				this.Character_stared(this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.character);
				return;
			}
			this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.character.stared += this.Character_stared;
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00042554 File Offset: 0x00040754
		private void Character_stared(object sender)
		{
			DetectorDeCollisionesDeCamaraDeCharacter detectorDeCollisionesDeCamaraDeCharacter = this.m_DetectorDeCollisionesDeCamaraDeCharacter;
			Object @object;
			if (detectorDeCollisionesDeCamaraDeCharacter == null)
			{
				@object = null;
			}
			else
			{
				IPuppetChar puppetChar = detectorDeCollisionesDeCamaraDeCharacter.puppetChar;
				@object = ((puppetChar != null) ? puppetChar.puppetBehaviour : null);
			}
			if (@object != null)
			{
				if (!this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.puppetBehaviour.estaIniciado)
				{
					BehaviourPuppet puppetBehaviour = this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.puppetBehaviour;
					puppetBehaviour.OnPostInitiate = (BehaviourBase.BehaviourDelegate)Delegate.Combine(puppetBehaviour.OnPostInitiate, new BehaviourBase.BehaviourDelegate(this.OnPostInitiatePuppetBeha));
					return;
				}
				this.OnPostInitiatePuppetBeha();
			}
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x000425D8 File Offset: 0x000407D8
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ik = this.GetComponentEnCharacter(false);
			if (this.m_ik == null)
			{
				throw new ArgumentNullException("m_ik", "m_ik null reference.");
			}
			if (this.m_ik.esSolverIniciado)
			{
				this.SEtEfecctors();
				return;
			}
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Combine(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.SEtEfecctors));
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00042658 File Offset: 0x00040858
		private void OnPostInitiatePuppetBeha()
		{
			BehaviourPuppet puppetBehaviour = this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.puppetBehaviour;
			puppetBehaviour.OnPostInitiate = (BehaviourBase.BehaviourDelegate)Delegate.Remove(puppetBehaviour.OnPostInitiate, new BehaviourBase.BehaviourDelegate(this.OnPostInitiatePuppetBeha));
			this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.puppetBehaviour.onLoseBalance.unityEvent.AddListener(new UnityAction(this.OnLoseBalance));
			this.m_DetectorDeCollisionesDeCamaraDeCharacter.puppetChar.puppetBehaviour.onRegainBalance.unityEvent.AddListener(new UnityAction(this.OnRegainBalance));
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x000426EC File Offset: 0x000408EC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			DetectorDeCollisionesDeCamaraDeCharacter detectorDeCollisionesDeCamaraDeCharacter = this.m_DetectorDeCollisionesDeCamaraDeCharacter;
			if (detectorDeCollisionesDeCamaraDeCharacter != null)
			{
				IPuppetChar puppetChar = detectorDeCollisionesDeCamaraDeCharacter.puppetChar;
				if (puppetChar != null)
				{
					BehaviourPuppet puppetBehaviour = puppetChar.puppetBehaviour;
					if (puppetBehaviour != null)
					{
						UnityEvent unityEvent = puppetBehaviour.onLoseBalance.unityEvent;
						if (unityEvent != null)
						{
							unityEvent.RemoveListener(new UnityAction(this.OnLoseBalance));
						}
					}
				}
			}
			DetectorDeCollisionesDeCamaraDeCharacter detectorDeCollisionesDeCamaraDeCharacter2 = this.m_DetectorDeCollisionesDeCamaraDeCharacter;
			if (detectorDeCollisionesDeCamaraDeCharacter2 == null)
			{
				return;
			}
			IPuppetChar puppetChar2 = detectorDeCollisionesDeCamaraDeCharacter2.puppetChar;
			if (puppetChar2 == null)
			{
				return;
			}
			BehaviourPuppet puppetBehaviour2 = puppetChar2.puppetBehaviour;
			if (puppetBehaviour2 == null)
			{
				return;
			}
			UnityEvent unityEvent2 = puppetBehaviour2.onRegainBalance.unityEvent;
			if (unityEvent2 == null)
			{
				return;
			}
			unityEvent2.RemoveListener(new UnityAction(this.OnRegainBalance));
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x00042782 File Offset: 0x00040982
		private void OnLoseBalance()
		{
			this.m_DetectorDeCollisionesDeCamaraDeCharacter.activado = false;
			this.activado = false;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x00042797 File Offset: 0x00040997
		private void OnRegainBalance()
		{
			this.m_DetectorDeCollisionesDeCamaraDeCharacter.activado = true;
			this.activado = true;
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x000427AC File Offset: 0x000409AC
		private void SEtEfecctors()
		{
			IKSolverFullBodyBiped solver = this.m_ik.solver;
			solver.OnPostInitiate = (IKSolver.UpdateDelegate)Delegate.Remove(solver.OnPostInitiate, new IKSolver.UpdateDelegate(this.SEtEfecctors));
			this.m_hombroL = this.m_ik.solver.leftShoulderEffector;
			this.m_hombroR = this.m_ik.solver.rightShoulderEffector;
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x00042811 File Offset: 0x00040A11
		public sealed override void OnUpdateEvent1()
		{
			this.V1();
			bool flag = this.debugDraw;
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00042820 File Offset: 0x00040A20
		private void V2()
		{
			Vector3 vector = (this.m_lastDirection = this.m_DetectorDeCollisionesDeCamaraDeCharacter.direccionDeEscapeCalculada * this.modDistancia);
			this.m_hombroL.positionOffset += vector;
			this.m_hombroR.positionOffset += vector;
			if (this.positionOffsetToRadiusMod > 0f)
			{
				this.m_DetectorDeCollisionesDeCamaraDeCharacter.cameraTrigger.radius = this.m_DetectorDeCollisionesDeCamaraDeCharacter.defaultCameraTriggerRadius + this.m_lastDirection.magnitude * this.positionOffsetToRadiusMod;
			}
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x000428B8 File Offset: 0x00040AB8
		private void V1()
		{
			Vector3 vector;
			float num;
			if (this.activado)
			{
				vector = this.m_DetectorDeCollisionesDeCamaraDeCharacter.direccionDeEscapeCalculada * this.modDistancia;
				num = 1f;
			}
			else
			{
				vector = Vector3.zero;
				num = 10f;
			}
			if (vector == Vector3.zero)
			{
				this.m_lastVelocidadBajandoNoObs = Mathf.MoveTowards(this.m_lastVelocidadBajandoNoObs, this.velocidadModPorNoObstaculo, Time.deltaTime * 0.25f);
				num *= this.m_lastVelocidadBajandoNoObs;
			}
			else
			{
				float magnitude = vector.magnitude;
				float num2 = Mathf.InverseLerp(0f, this.distanceScapeToMaxVelocity * this.modDistancia, magnitude).OutPow(this.distanceScapeOutPower);
				num *= num2;
				if (vector.sqrMagnitude > this.m_lastDirection.sqrMagnitude)
				{
					this.m_lastVelocidadBajandoNoObs = 0f;
					this.m_lastVelocidadBajandoMenosDis = 0f;
					if (this.usarDistanceToTarget)
					{
						float magnitude2 = (vector - this.m_lastDirection).magnitude;
						float num3 = Mathf.InverseLerp(0f, this.distanceToTargetToMaxVelocity * this.modDistancia, magnitude2).OutPow(this.distanceToTargetOutPower);
						num *= Mathf.Lerp(1f, 2f, num3);
					}
				}
				else
				{
					this.m_lastVelocidadBajandoMenosDis = Mathf.MoveTowards(this.m_lastVelocidadBajandoMenosDis, this.velocidadPorDisminucion, Time.deltaTime * 0.25f);
					num *= this.m_lastVelocidadBajandoMenosDis;
				}
			}
			float num4 = this.maxVelocity * Time.deltaTime * num * this.m_DetectorDeCollisionesDeCamaraDeCharacter.cameraScaleCalculada;
			this.m_lastDirection = Vector3.RotateTowards(this.m_lastDirection, vector, num4, num4);
			this.m_hombroL.positionOffset += this.m_lastDirection;
			this.m_hombroR.positionOffset += this.m_lastDirection;
			if (this.positionOffsetToRadiusMod > 0f && this.m_DetectorDeCollisionesDeCamaraDeCharacter.cameraTrigger != null)
			{
				this.m_DetectorDeCollisionesDeCamaraDeCharacter.cameraTrigger.radius = Mathf.Min(this.m_DetectorDeCollisionesDeCamaraDeCharacter.defaultCameraTriggerRadius * 2f, this.m_DetectorDeCollisionesDeCamaraDeCharacter.defaultCameraTriggerRadius + this.m_lastDirection.magnitude * this.positionOffsetToRadiusMod);
			}
		}

		// Token: 0x04000A1D RID: 2589
		public bool activado = true;

		// Token: 0x04000A1E RID: 2590
		private DetectorDeCollisionesDeCamaraDeCharacter m_DetectorDeCollisionesDeCamaraDeCharacter;

		// Token: 0x04000A1F RID: 2591
		private FullBodyBipedIK m_ik;

		// Token: 0x04000A20 RID: 2592
		private IKEffector m_hombroL;

		// Token: 0x04000A21 RID: 2593
		private IKEffector m_hombroR;

		// Token: 0x04000A22 RID: 2594
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_lastDirection;

		// Token: 0x04000A23 RID: 2595
		public bool debugDraw;

		// Token: 0x04000A24 RID: 2596
		public float modDistancia = 6f;

		// Token: 0x04000A25 RID: 2597
		public float maxVelocity = 2f;

		// Token: 0x04000A26 RID: 2598
		public float positionOffsetToRadiusMod = 0.15f;

		// Token: 0x04000A27 RID: 2599
		public float velocidadModPorNoObstaculo = 0.25f;

		// Token: 0x04000A28 RID: 2600
		public float velocidadPorDisminucion = 0.1f;

		// Token: 0x04000A29 RID: 2601
		[Header("Distance To Target")]
		public bool usarDistanceToTarget;

		// Token: 0x04000A2A RID: 2602
		public float distanceToTargetToMaxVelocity = 0.01f;

		// Token: 0x04000A2B RID: 2603
		public float distanceToTargetOutPower = 0.1f;

		// Token: 0x04000A2C RID: 2604
		[Header("Distance To Scape")]
		public float distanceScapeToMaxVelocity = 0.08f;

		// Token: 0x04000A2D RID: 2605
		public float distanceScapeOutPower = 0.1f;

		// Token: 0x04000A2E RID: 2606
		private float m_lastVelocidadBajandoNoObs;

		// Token: 0x04000A2F RID: 2607
		private float m_lastVelocidadBajandoMenosDis;
	}
}

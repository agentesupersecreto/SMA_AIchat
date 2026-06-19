using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ControllerPoses;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Navigation
{
	// Token: 0x0200037B RID: 891
	public sealed class SimpleFemaleNavigation : AplicableBehaviour, ICharacterNavegable
	{
		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001625 RID: 5669 RVA: 0x0000B284 File Offset: 0x00009484
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06001626 RID: 5670 RVA: 0x00069DF8 File Offset: 0x00067FF8
		// (remove) Token: 0x06001627 RID: 5671 RVA: 0x00069E30 File Offset: 0x00068030
		public event Action<SimpleFemaleNavigation.InstanciaDeNavegacion> onNavStarting;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06001628 RID: 5672 RVA: 0x00069E68 File Offset: 0x00068068
		// (remove) Token: 0x06001629 RID: 5673 RVA: 0x00069EA0 File Offset: 0x000680A0
		public event Action<SimpleFemaleNavigation.InstanciaDeNavegacion> onNavStoped;

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x0600162A RID: 5674 RVA: 0x00069ED5 File Offset: 0x000680D5
		public bool isNavigating
		{
			get
			{
				return this.m_currentNavigation != null;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x00069EE0 File Offset: 0x000680E0
		public bool isGoingToNavite
		{
			get
			{
				return this.m_colaDeNavegacion.Count > 0;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x00069EF0 File Offset: 0x000680F0
		public SimpleFemaleNavigation.InstanciaDeNavegacion currentNavigation
		{
			get
			{
				return this.m_currentNavigation;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x0600162D RID: 5677 RVA: 0x00069EF8 File Offset: 0x000680F8
		public ICharacter self
		{
			get
			{
				return this.m_FemaleChar;
			}
		}

		// Token: 0x0600162E RID: 5678 RVA: 0x00069F00 File Offset: 0x00068100
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SimpleFemalePoseLoader = this.GetComponentEnRoot(false);
			if (this.m_SimpleFemalePoseLoader == null)
			{
				throw new ArgumentNullException("m_SimpleFemalePoseLoader", "m_SimpleFemalePoseLoader null reference.");
			}
			this.m_FemaleChar = this.GetComponentEnRoot(false);
			if (this.m_FemaleChar == null)
			{
				throw new ArgumentNullException("m_FemaleChar", "m_FemaleChar null reference.");
			}
		}

		// Token: 0x0600162F RID: 5679 RVA: 0x00069F6C File Offset: 0x0006816C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			List<Transform> list = this.m_extraObstacles.ToList<Transform>();
			List<Transform> list2 = list;
			MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
			Transform transform;
			if (current == null)
			{
				transform = null;
			}
			else
			{
				Character character = current.character;
				if (character == null)
				{
					transform = null;
				}
				else
				{
					Animator bodyAnimator = character.bodyAnimator;
					transform = ((bodyAnimator != null) ? bodyAnimator.transform : null);
				}
			}
			list2.Add(transform);
			this.m_Obstacles = list.Where((Transform t) => t != null).Distinct<Transform>().ToArray<Transform>();
		}

		// Token: 0x06001630 RID: 5680 RVA: 0x00069FEF File Offset: 0x000681EF
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Interrupt();
			SimpleFemalePoseLoader simpleFemalePoseLoader = this.m_SimpleFemalePoseLoader;
			if (simpleFemalePoseLoader == null)
			{
				return;
			}
			simpleFemalePoseLoader.StopMoving();
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x0006A010 File Offset: 0x00068210
		public void Interrupt()
		{
			SimpleFemaleNavigation.InstanciaDeNavegacion currentNavigation = this.m_currentNavigation;
			if (currentNavigation != null)
			{
				currentNavigation.Stop();
			}
			for (int i = this.m_colaDeNavegacion.Count - 1; i >= 0; i--)
			{
				SimpleFemaleNavigation.InstanciaDeNavegacion instanciaDeNavegacion = this.m_colaDeNavegacion[i];
				if (instanciaDeNavegacion != null)
				{
					instanciaDeNavegacion.Stop();
				}
			}
			this.m_colaDeNavegacion.Clear();
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x0006A068 File Offset: 0x00068268
		public void NavToTarget(Transform target, bool interrupt, float maxMagnitude, float cornerDistanceMod, bool OnlyStrafe, Vector3? finalOrientation = null, Action staredCallback = null, Action<bool> stoppedCallback = null)
		{
			if (interrupt)
			{
				this.Interrupt();
				this.m_SimpleFemalePoseLoader.animatedPoseID = FemaleAnimatedPoseIDs.None;
			}
			SimpleFemaleNavigation.NavegacionAPunto navegacionAPunto = new SimpleFemaleNavigation.NavegacionAPunto(this, staredCallback, maxMagnitude, cornerDistanceMod, (finalOrientation != null) ? null : stoppedCallback, OnlyStrafe);
			navegacionAPunto.target = target;
			this.m_colaDeNavegacion.Insert(0, navegacionAPunto);
			if (finalOrientation != null)
			{
				SimpleFemaleNavigation.NavegacionTurnTo navegacionTurnTo = new SimpleFemaleNavigation.NavegacionTurnTo(this, null, stoppedCallback);
				navegacionTurnTo.worldDirection = finalOrientation.Value;
				navegacionTurnTo.errorAngleMod = 1f;
				navegacionTurnTo.startVelMod = 1f;
				navegacionTurnTo.stopVelMod = 1f;
				this.m_colaDeNavegacion.Insert(0, navegacionTurnTo);
			}
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x0006A108 File Offset: 0x00068308
		public void TurnTo(Vector3 worldDirection, bool interrupt, float errorAngleMod = 1f, float startVelMod = 1f, float stopVelMod = 1f, Action staredCallback = null, Action<bool> stoppedCallback = null)
		{
			if (interrupt)
			{
				this.Interrupt();
			}
			SimpleFemaleNavigation.NavegacionTurnTo navegacionTurnTo = new SimpleFemaleNavigation.NavegacionTurnTo(this, staredCallback, stoppedCallback);
			navegacionTurnTo.worldDirection = worldDirection;
			navegacionTurnTo.errorAngleMod = errorAngleMod;
			navegacionTurnTo.startVelMod = startVelMod;
			navegacionTurnTo.stopVelMod = stopVelMod;
			this.m_colaDeNavegacion.Insert(0, navegacionTurnTo);
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x0006A154 File Offset: 0x00068354
		public override void OnUpdateEvent1()
		{
			if (this.m_SimpleFemalePoseLoader.tipoDePose != TipoDePose.dePieRigida)
			{
				return;
			}
			this.m_SimpleFemalePoseLoader.animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.LegSwitch, 1f);
			float y = this.m_FemaleChar.bones.footR.posicionFinal.y;
			float y2 = this.m_FemaleChar.bones.footL.posicionFinal.y;
			bool flag = y > y2;
			this.m_SimpleFemalePoseLoader.animator.SetBool(FemaleAnimController.FemaleAnimatorVariables.IsRightLegUp, flag);
			if (this.m_currentNavigation != null && this.m_currentNavigation.stared && this.m_currentNavigation.finished)
			{
				Action<SimpleFemaleNavigation.InstanciaDeNavegacion> action = this.onNavStoped;
				if (action != null)
				{
					action(this.m_currentNavigation);
				}
				this.m_currentNavigation = null;
			}
			if (this.m_currentNavigation == null && this.m_colaDeNavegacion.Count > 0 && this.m_SimpleFemalePoseLoader.CanAnimatedTraslate())
			{
				int num = this.m_colaDeNavegacion.Count - 1;
				this.m_currentNavigation = this.m_colaDeNavegacion[num];
				this.m_colaDeNavegacion.RemoveAt(num);
			}
			if (this.m_currentNavigation != null)
			{
				if (!this.m_currentNavigation.stared)
				{
					Action<SimpleFemaleNavigation.InstanciaDeNavegacion> action2 = this.onNavStarting;
					if (action2 != null)
					{
						action2(this.m_currentNavigation);
					}
					this.m_currentNavigation.Start();
				}
				this.m_currentNavigation.Update();
			}
			else
			{
				this.m_SimpleFemalePoseLoader.StopMoving();
			}
			int layerMaskGround = ConfiguracionGlobal.layersStatic.layerMaskGround;
			RaycastHit raycastHit;
			if (Physics.Raycast(this.m_FemaleChar.rootBoneTransform.position + Vector3.up * this.m_FemaleChar.estatura * 0.5f, Vector3.down, out raycastHit, this.m_FemaleChar.estatura, layerMaskGround, QueryTriggerInteraction.Ignore))
			{
				this.m_FemaleChar.bodyAnimator.transform.position = raycastHit.point;
			}
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0006A330 File Offset: 0x00068530
		private static SimpleFemaleNavigation.TurnStyle GetTurnStyle(float angle)
		{
			angle = Mathf.Abs(angle);
			if (angle <= 90f)
			{
				return SimpleFemaleNavigation.TurnStyle._90;
			}
			if (angle <= 180f)
			{
				return SimpleFemaleNavigation.TurnStyle._180;
			}
			throw new ArgumentOutOfRangeException("not a valdi turn angle: " + angle.ToString());
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0006A364 File Offset: 0x00068564
		[Obsolete("", true)]
		private static void GetStartAndEndAngles(float angle, out float startAngle, out float endAngle)
		{
			float num = Mathf.Abs(angle);
			if (num < 90f)
			{
				startAngle = 46f;
				float num2 = Mathf.InverseLerp(0f, 90f, num);
				num = Mathf.Lerp(0f, 90f, num2.OutPow(6f));
			}
			else
			{
				startAngle = 136f;
				float num3 = Mathf.InverseLerp(90f, 180f, num);
				num = Mathf.Lerp(90f, 180f, num3.OutPow(6f));
			}
			angle = ((angle < 0f) ? (-num) : num);
			startAngle = ((angle < 0f) ? (-startAngle) : startAngle);
			endAngle = angle;
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x0006A40C File Offset: 0x0006860C
		private static void GetCurrentLocalDirectionAndAngle(Vector3 worldDirection, Transform character, out Vector3 localdirection, out float localAngle)
		{
			worldDirection.y = character.position.y;
			localdirection = character.InverseTransformDirection(worldDirection);
			localdirection = localdirection.normalized;
			localAngle = Mathf.Atan2(localdirection.x, localdirection.z) * 57.29578f;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0006A45D File Offset: 0x0006865D
		private void OnDrawGizmos()
		{
			SimpleFemaleNavigation.InstanciaDeNavegacion currentNavigation = this.m_currentNavigation;
			if (currentNavigation == null)
			{
				return;
			}
			currentNavigation.Visualize();
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x0006A46F File Offset: 0x0006866F
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "go to test target"
			};
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x0006A488 File Offset: 0x00068688
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.NavToTarget(this.m_testTarget, true, 1f, 1f, false, null, null, null);
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0006A4BE File Offset: 0x000686BE
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "turn to test target"
			};
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x0006A4D8 File Offset: 0x000686D8
		protected override void OnAplicar3()
		{
			base.OnAplicar2();
			this.TurnTo(this.m_testTarget.position - this.m_FemaleChar.bodyAnimator.transform.position, true, 1f, 1f, 1f, null, null);
		}

		// Token: 0x04000FFA RID: 4090
		private SimpleFemalePoseLoader m_SimpleFemalePoseLoader;

		// Token: 0x04000FFB RID: 4091
		private FemaleChar m_FemaleChar;

		// Token: 0x04000FFC RID: 4092
		[SerializeField]
		private Transform[] m_extraObstacles;

		// Token: 0x04000FFD RID: 4093
		[SerializeField]
		private Transform[] m_Obstacles;

		// Token: 0x04000FFE RID: 4094
		public SimpleFemaleNavigation.Config config = new SimpleFemaleNavigation.Config();

		// Token: 0x04000FFF RID: 4095
		public SimpleFemaleNavigation.TurnAroundConfig turnAroundConfig = new SimpleFemaleNavigation.TurnAroundConfig();

		// Token: 0x04001000 RID: 4096
		public SimpleFemaleNavigation.StrafeConfig strafeConfig = new SimpleFemaleNavigation.StrafeConfig();

		// Token: 0x04001001 RID: 4097
		public SimpleFemaleNavigation.WalkConfig walkConfig = new SimpleFemaleNavigation.WalkConfig();

		// Token: 0x04001002 RID: 4098
		public SimpleFemaleNavigation.SingleTurnAroundConfig singleTurnAroundConfig = new SimpleFemaleNavigation.SingleTurnAroundConfig();

		// Token: 0x04001005 RID: 4101
		[SerializeField]
		private Transform m_testTarget;

		// Token: 0x04001006 RID: 4102
		[SerializeReference]
		private SimpleFemaleNavigation.InstanciaDeNavegacion m_currentNavigation;

		// Token: 0x04001007 RID: 4103
		[SerializeReference]
		private List<SimpleFemaleNavigation.InstanciaDeNavegacion> m_colaDeNavegacion = new List<SimpleFemaleNavigation.InstanciaDeNavegacion>();

		// Token: 0x0200037C RID: 892
		private enum TurnStyle
		{
			// Token: 0x04001009 RID: 4105
			_90,
			// Token: 0x0400100A RID: 4106
			_180
		}

		// Token: 0x0200037D RID: 893
		public interface ICornerNavegacion
		{
			// Token: 0x170004D4 RID: 1236
			// (get) Token: 0x0600163E RID: 5694
			IReadOnlyList<Vector3> corners { get; }

			// Token: 0x170004D5 RID: 1237
			// (get) Token: 0x0600163F RID: 5695
			int currentCornerIndex { get; }

			// Token: 0x170004D6 RID: 1238
			// (get) Token: 0x06001640 RID: 5696
			float distanceToNextCorner { get; }

			// Token: 0x170004D7 RID: 1239
			// (get) Token: 0x06001641 RID: 5697
			float angleToNextCorner { get; }

			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x06001642 RID: 5698
			float angleToNextNextCorner { get; }

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x06001643 RID: 5699
			float distanceToEndCorner { get; }

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x06001644 RID: 5700
			bool stared { get; }

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x06001645 RID: 5701
			bool finished { get; }
		}

		// Token: 0x0200037E RID: 894
		[Serializable]
		public abstract class InstanciaDeNavegacion
		{
			// Token: 0x06001646 RID: 5702 RVA: 0x0006A57D File Offset: 0x0006877D
			public InstanciaDeNavegacion(SimpleFemaleNavigation SimpleFemaleNavigation, Action StaredCallback, Action<bool> StoppedCallback)
			{
				this.m_simpleFemaleNavigation = SimpleFemaleNavigation;
				this.m_staredCallback = StaredCallback;
				this.m_stoppedCallback = StoppedCallback;
			}

			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x06001647 RID: 5703 RVA: 0x0006A59A File Offset: 0x0006879A
			public bool stared
			{
				get
				{
					return this.m_stared;
				}
			}

			// Token: 0x170004DD RID: 1245
			// (get) Token: 0x06001648 RID: 5704 RVA: 0x0006A5A2 File Offset: 0x000687A2
			public bool finished
			{
				get
				{
					return this.m_finished;
				}
			}

			// Token: 0x06001649 RID: 5705 RVA: 0x0006A5AA File Offset: 0x000687AA
			internal void Start()
			{
				if (this.m_stared)
				{
					return;
				}
				this.m_finished = false;
				this.m_stared = true;
				this.Stared();
				Action staredCallback = this.m_staredCallback;
				if (staredCallback == null)
				{
					return;
				}
				staredCallback();
			}

			// Token: 0x0600164A RID: 5706 RVA: 0x0006A5DC File Offset: 0x000687DC
			internal void Stop()
			{
				if (this.m_finished)
				{
					return;
				}
				this.m_finished = true;
				bool flag = this.Stopped();
				Action<bool> stoppedCallback = this.m_stoppedCallback;
				if (stoppedCallback == null)
				{
					return;
				}
				stoppedCallback(flag);
			}

			// Token: 0x0600164B RID: 5707
			protected abstract void Stared();

			// Token: 0x0600164C RID: 5708
			protected abstract bool Stopped();

			// Token: 0x0600164D RID: 5709
			public abstract void Update();

			// Token: 0x0600164E RID: 5710
			public abstract void Visualize();

			// Token: 0x0400100B RID: 4107
			private Action m_staredCallback;

			// Token: 0x0400100C RID: 4108
			private Action<bool> m_stoppedCallback;

			// Token: 0x0400100D RID: 4109
			protected SimpleFemaleNavigation m_simpleFemaleNavigation;

			// Token: 0x0400100E RID: 4110
			[SerializeField]
			[ReadOnlyUI]
			private bool m_stared;

			// Token: 0x0400100F RID: 4111
			[SerializeField]
			[ReadOnlyUI]
			private bool m_finished;
		}

		// Token: 0x0200037F RID: 895
		[Serializable]
		public sealed class NavegacionTurnTo : SimpleFemaleNavigation.InstanciaDeNavegacion
		{
			// Token: 0x0600164F RID: 5711 RVA: 0x0006A611 File Offset: 0x00068811
			public NavegacionTurnTo(SimpleFemaleNavigation SimpleFemaleNavigation, Action StaredCallback, Action<bool> StoppedCallback)
				: base(SimpleFemaleNavigation, StaredCallback, StoppedCallback)
			{
			}

			// Token: 0x06001650 RID: 5712 RVA: 0x0006A640 File Offset: 0x00068840
			protected override void Stared()
			{
				SimpleFemaleNavigation.SingleTurnAroundConfig singleTurnAroundConfig = this.m_simpleFemaleNavigation.singleTurnAroundConfig;
				IEnumerator enumerator = this.TurnToAsync(this.worldDirection, singleTurnAroundConfig.errorAngle * this.errorAngleMod, singleTurnAroundConfig.startVelocity * this.startVelMod, singleTurnAroundConfig.stopVelocity * this.stopVelMod);
				this.m_TurnToCorutina = new ManualCorrutina(enumerator, this.m_simpleFemaleNavigation, null);
			}

			// Token: 0x06001651 RID: 5713 RVA: 0x0006A6A0 File Offset: 0x000688A0
			protected override bool Stopped()
			{
				ManualCorrutina turnToCorutina = this.m_TurnToCorutina;
				bool valueOrDefault = ((turnToCorutina != null) ? new bool?(turnToCorutina.finalizada) : null).GetValueOrDefault();
				ManualCorrutina turnToCorutina2 = this.m_TurnToCorutina;
				if (turnToCorutina2 != null)
				{
					turnToCorutina2.Stop();
				}
				this.m_TurnToCorutina = null;
				return valueOrDefault;
			}

			// Token: 0x06001652 RID: 5714 RVA: 0x0006A6EC File Offset: 0x000688EC
			public override void Update()
			{
				if (!this.m_TurnToCorutina.finalizada)
				{
					this.m_TurnToCorutina.Update();
				}
				if (this.m_TurnToCorutina.finalizada)
				{
					base.Stop();
				}
			}

			// Token: 0x06001653 RID: 5715 RVA: 0x00002BEA File Offset: 0x00000DEA
			public override void Visualize()
			{
			}

			// Token: 0x06001654 RID: 5716 RVA: 0x0006A719 File Offset: 0x00068919
			private IEnumerator TurnToAsync(Vector3 worldDirection, float angleToStop, float startVel, float stopVel)
			{
				Vector3 vector;
				float num;
				SimpleFemaleNavigation.GetCurrentLocalDirectionAndAngle(worldDirection, this.m_simpleFemaleNavigation.m_FemaleChar.bodyAnimator.transform, out vector, out num);
				SimpleFemaleNavigation.TurnStyle turnStyle = SimpleFemaleNavigation.GetTurnStyle(num);
				float smoothTurnAroundAngle = 0f;
				float targetTurnAroundAngle = (float)((num < 0f) ? (-1) : 1);
				for (;;)
				{
					if (Mathf.Abs(num) <= angleToStop)
					{
						targetTurnAroundAngle = 0f;
					}
					if (Mathf.Abs(targetTurnAroundAngle) > Mathf.Abs(smoothTurnAroundAngle))
					{
						smoothTurnAroundAngle = Mathf.MoveTowards(smoothTurnAroundAngle, targetTurnAroundAngle, Time.deltaTime * startVel);
					}
					else
					{
						smoothTurnAroundAngle = Mathf.MoveTowards(smoothTurnAroundAngle, targetTurnAroundAngle, Time.deltaTime * stopVel);
					}
					SimpleFemaleNavigation.TurnStyle turnStyle2 = turnStyle;
					if (turnStyle2 != SimpleFemaleNavigation.TurnStyle._90)
					{
						if (turnStyle2 != SimpleFemaleNavigation.TurnStyle._180)
						{
							break;
						}
						this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader.Turn180(smoothTurnAroundAngle);
					}
					else
					{
						this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader.Turn90(smoothTurnAroundAngle);
					}
					if (smoothTurnAroundAngle == 0f)
					{
						goto IL_01A1;
					}
					yield return null;
					if (!this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader.CanAnimatedTraslate())
					{
						goto IL_01A1;
					}
					SimpleFemaleNavigation.GetCurrentLocalDirectionAndAngle(worldDirection, this.m_simpleFemaleNavigation.m_FemaleChar.bodyAnimator.transform, out vector, out num);
				}
				throw new ArgumentOutOfRangeException(turnStyle.ToString());
				IL_01A1:
				yield break;
			}

			// Token: 0x04001010 RID: 4112
			public Vector3 worldDirection;

			// Token: 0x04001011 RID: 4113
			public float errorAngleMod = 1f;

			// Token: 0x04001012 RID: 4114
			public float startVelMod = 1f;

			// Token: 0x04001013 RID: 4115
			public float stopVelMod = 1f;

			// Token: 0x04001014 RID: 4116
			[SerializeReference]
			private ManualCorrutina m_TurnToCorutina;
		}

		// Token: 0x02000381 RID: 897
		[Serializable]
		public sealed class NavegacionAPunto : SimpleFemaleNavigation.InstanciaDeNavegacion, SimpleFemaleNavigation.ICornerNavegacion
		{
			// Token: 0x170004E0 RID: 1248
			// (get) Token: 0x0600165B RID: 5723 RVA: 0x0006A90B File Offset: 0x00068B0B
			IReadOnlyList<Vector3> SimpleFemaleNavigation.ICornerNavegacion.corners
			{
				get
				{
					return this.navigator.corners;
				}
			}

			// Token: 0x170004E1 RID: 1249
			// (get) Token: 0x0600165C RID: 5724 RVA: 0x0006A918 File Offset: 0x00068B18
			int SimpleFemaleNavigation.ICornerNavegacion.currentCornerIndex
			{
				get
				{
					return this.navigator.cornerIndex;
				}
			}

			// Token: 0x170004E2 RID: 1250
			// (get) Token: 0x0600165D RID: 5725 RVA: 0x0006A925 File Offset: 0x00068B25
			float SimpleFemaleNavigation.ICornerNavegacion.distanceToNextCorner
			{
				get
				{
					return this.navigator.nextCornerDistance;
				}
			}

			// Token: 0x170004E3 RID: 1251
			// (get) Token: 0x0600165E RID: 5726 RVA: 0x0006A932 File Offset: 0x00068B32
			float SimpleFemaleNavigation.ICornerNavegacion.distanceToEndCorner
			{
				get
				{
					return this.navigator.endCornerDistance;
				}
			}

			// Token: 0x170004E4 RID: 1252
			// (get) Token: 0x0600165F RID: 5727 RVA: 0x0006A93F File Offset: 0x00068B3F
			float SimpleFemaleNavigation.ICornerNavegacion.angleToNextCorner
			{
				get
				{
					return this.navigator.nextCornerAngle;
				}
			}

			// Token: 0x170004E5 RID: 1253
			// (get) Token: 0x06001660 RID: 5728 RVA: 0x0006A94C File Offset: 0x00068B4C
			float SimpleFemaleNavigation.ICornerNavegacion.angleToNextNextCorner
			{
				get
				{
					return this.navigator.nextNextCornerAngle;
				}
			}

			// Token: 0x06001661 RID: 5729 RVA: 0x0006A95C File Offset: 0x00068B5C
			public NavegacionAPunto(SimpleFemaleNavigation SimpleFemaleNavigation, Action StaredCallback, float maxMagnitude, float cornerDistanceMod, Action<bool> StoppedCallback, bool OnlyStrafe)
				: base(SimpleFemaleNavigation, StaredCallback, StoppedCallback)
			{
				this.m_maxMagnitude = maxMagnitude;
				this.m_onlyStrafe = OnlyStrafe;
				this.m_cornerDistanceMod = cornerDistanceMod;
				this.m_maxMagnitude = Mathf.Clamp(this.m_maxMagnitude, 0.2f, 1f);
			}

			// Token: 0x06001662 RID: 5730 RVA: 0x0006A9B0 File Offset: 0x00068BB0
			protected override void Stared()
			{
				FemaleChar femaleChar = this.m_simpleFemaleNavigation.m_FemaleChar;
				this.navigator.cornerRadius = 0.2f * this.m_cornerDistanceMod;
				this.navigator.characterScale = femaleChar.escala;
				this.navigator.Initiate(femaleChar.bodyAnimator.transform, this.m_simpleFemaleNavigation.m_Obstacles);
				this.navigator.CalculatePath(this.target.position);
				this.navigator.onObstacleInTheWay += this.M_navigator_onObstacleIncreasedCornerCount;
			}

			// Token: 0x06001663 RID: 5731 RVA: 0x0006AA3F File Offset: 0x00068C3F
			protected override bool Stopped()
			{
				this.Clean();
				this.navigator.Clean();
				this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader.StopMoving();
				return this.navigator.lastCornersLeftCount == 0;
			}

			// Token: 0x06001664 RID: 5732 RVA: 0x0006AA70 File Offset: 0x00068C70
			private void M_navigator_onObstacleIncreasedCornerCount(Transform obs, SimpleFemaleNavigation.Navigator obj)
			{
				FemaleChar femaleChar = this.m_simpleFemaleNavigation.m_FemaleChar;
				this.navigator.Stop();
				base.Stop();
				this.m_simpleFemaleNavigation.TurnTo(obs.position - femaleChar.bodyAnimator.transform.position, true, 1f, 1f, 1f, null, null);
			}

			// Token: 0x06001665 RID: 5733 RVA: 0x0006AAD4 File Offset: 0x00068CD4
			public override void Update()
			{
				if (this.target == null || !this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader.CanAnimatedTraslate())
				{
					base.Stop();
					return;
				}
				FemaleChar femaleChar = this.m_simpleFemaleNavigation.m_FemaleChar;
				SimpleFemalePoseLoader simpleFemalePoseLoader = this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader;
				SimpleFemaleNavigation.Config config = this.m_simpleFemaleNavigation.config;
				this.navigator.characterScale = femaleChar.escala;
				this.navigator.Update(this.target.position);
				if (this.navigator.nextCornerDirection != Vector3.zero && this.navigator.nextCornerDistance > 0f)
				{
					float num = this.navigator.nextCornerDistance * simpleFemalePoseLoader.character.escala;
					Vector3 vector;
					float num2;
					SimpleFemaleNavigation.GetCurrentLocalDirectionAndAngle(this.navigator.nextCornerDirection, femaleChar.bodyAnimator.transform, out vector, out num2);
					if (this.m_onlyStrafe || (num <= config.distanceToUseOnlyStrafe * this.navigator.characterScale && this.navigator.totalCornerCount <= config.maxCornerCountToUseOnlyStrafe))
					{
						Vector2 vector2 = new Vector2(vector.x, vector.z);
						this.StrafeTo(vector2, num, this.navigator.cornersLeftCount);
					}
					else if (this.m_isTurningAround || (this.m_lastMagnitude <= 0.2f && Mathf.Abs(num2) > config.angleToUseTurnAround))
					{
						this.TurnAngle(num2);
					}
					else
					{
						this.WalkTo(this.navigator.nextCornerDirection, num, this.navigator.cornersLeftCount);
					}
				}
				else
				{
					this.Clean();
					simpleFemalePoseLoader.StopMoving();
				}
				if (this.navigator.state == SimpleFemaleNavigation.Navigator.State.Idle)
				{
					base.Stop();
				}
			}

			// Token: 0x06001666 RID: 5734 RVA: 0x0006AC80 File Offset: 0x00068E80
			private void StrafeTo(Vector2 localDirectionToCorner, float localDistanceToCorner, int cornersLeft)
			{
				SimpleFemaleNavigation.StrafeConfig strafeConfig = this.m_simpleFemaleNavigation.strafeConfig;
				FemaleAnimController simpleFemalePoseLoader = this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader;
				this.m_lastStrafeLocalDirection = Vector2.MoveTowards(this.m_lastStrafeLocalDirection, localDirectionToCorner, Time.deltaTime * strafeConfig.changeDirectionVelocity);
				float num = Vector2.Angle(this.m_lastStrafeLocalDirection, localDirectionToCorner);
				localDirectionToCorner = this.m_lastStrafeLocalDirection.normalized;
				float num2 = Mathf.InverseLerp(strafeConfig.distanceToFullStop, strafeConfig.distanceToStartToSlowDown, localDistanceToCorner);
				num2 *= Mathf.InverseLerp(180f, 0f, num);
				if (cornersLeft > 1)
				{
					num2 = Mathf.Lerp(0.3f, 1f, num2);
				}
				if (num2 > this.m_lastMagnitude)
				{
					this.m_lastMagnitude = Mathf.MoveTowards(this.m_lastMagnitude, num2, Time.deltaTime * strafeConfig.startVelocity);
				}
				else
				{
					this.m_lastMagnitude = Mathf.MoveTowards(this.m_lastMagnitude, num2, Time.deltaTime * strafeConfig.stopVelocity);
				}
				this.m_lastMagnitude = Mathf.Clamp(this.m_lastMagnitude, -1f, this.m_maxMagnitude);
				simpleFemalePoseLoader.Strafe(localDirectionToCorner.x, localDirectionToCorner.y, this.m_lastMagnitude);
			}

			// Token: 0x06001667 RID: 5735 RVA: 0x0006AD94 File Offset: 0x00068F94
			private void WalkTo(Vector3 worldDirectionToCorner, float localDistanceToCorner, int cornersLeft)
			{
				SimpleFemaleNavigation.WalkConfig walkConfig = this.m_simpleFemaleNavigation.walkConfig;
				FemaleAnimController simpleFemalePoseLoader = this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader;
				FemaleChar femaleChar = this.m_simpleFemaleNavigation.m_FemaleChar;
				float num = walkConfig.turnTime;
				num *= Mathf.Lerp(10f, 1f, this.m_lastMagnitude.OutPow(2f));
				Vector3 forward = femaleChar.bodyAnimator.transform.forward;
				float num2 = Mathf.Atan2(forward.x, forward.z) * 57.29578f;
				float num3 = Mathf.Atan2(worldDirectionToCorner.x, worldDirectionToCorner.z) * 57.29578f;
				if (Mathf.Abs(Mathf.DeltaAngle(num2, num3)) > 3f)
				{
					float num4 = Mathf.Lerp(120f, 300f, this.m_lastMagnitude);
					float num5 = Mathf.SmoothDampAngle(num2, num3, ref this.angleVel, num, num4);
					femaleChar.bodyAnimator.transform.rotation = Quaternion.AngleAxis(num5, Vector3.up);
				}
				float num6 = Mathf.InverseLerp(walkConfig.distanceToFullStop, walkConfig.distanceToStartToSlowDown, localDistanceToCorner);
				num6 *= Mathf.InverseLerp(180f, 0f, Mathf.Abs(Mathf.Abs(num3) - Mathf.Abs(num2)));
				if (cornersLeft > 1)
				{
					num6 = Mathf.Lerp(0.3f, 1f, num6);
				}
				if (num6 > this.m_lastMagnitude)
				{
					this.m_lastMagnitude = Mathf.SmoothDamp(this.m_lastMagnitude, num6, ref this.speedVel, walkConfig.accelerationTime);
				}
				else
				{
					this.m_lastMagnitude = Mathf.SmoothDamp(this.m_lastMagnitude, num6, ref this.speedVel, walkConfig.deAccelerationTime);
				}
				this.m_lastMagnitude = Mathf.Clamp(this.m_lastMagnitude, -1f, this.m_maxMagnitude);
				simpleFemalePoseLoader.Walk(0f, 1f, this.m_lastMagnitude);
			}

			// Token: 0x06001668 RID: 5736 RVA: 0x0006AF5C File Offset: 0x0006915C
			private void TurnAngle(float angle)
			{
				SimpleFemaleNavigation.Config config = this.m_simpleFemaleNavigation.config;
				SimpleFemaleNavigation.TurnAroundConfig turnAroundConfig = this.m_simpleFemaleNavigation.turnAroundConfig;
				SimpleFemalePoseLoader simpleFemalePoseLoader = this.m_simpleFemaleNavigation.m_SimpleFemalePoseLoader;
				SimpleFemaleNavigation.WalkConfig walkConfig = this.m_simpleFemaleNavigation.walkConfig;
				if (!this.m_isTurningAround)
				{
					this.m_isTurningAround = true;
					this.m_turnStyle = SimpleFemaleNavigation.GetTurnStyle(angle);
					this.m_lastTurnAroundAngle = 0f;
					this.m_targetTurnAroundAngle = (float)((angle < 0f) ? (-1) : 1);
				}
				else if (Mathf.Abs(angle) <= config.angleToUseTurnAround)
				{
					this.m_targetTurnAroundAngle = 0f;
				}
				this.m_lastMagnitude = Mathf.SmoothDamp(this.m_lastMagnitude, 0f, ref this.speedVel, walkConfig.deAccelerationTime);
				simpleFemalePoseLoader.animator.SetFloat(FemaleAnimController.FemaleAnimatorVariables.Magnitude, this.m_lastMagnitude);
				if (this.m_lastMagnitude > 0.1f)
				{
					return;
				}
				if (Mathf.Abs(this.m_targetTurnAroundAngle) > Mathf.Abs(this.m_lastTurnAroundAngle))
				{
					this.m_lastTurnAroundAngle = Mathf.MoveTowards(this.m_lastTurnAroundAngle, this.m_targetTurnAroundAngle, Time.deltaTime * turnAroundConfig.startVelocity);
				}
				else
				{
					this.m_lastTurnAroundAngle = Mathf.MoveTowards(this.m_lastTurnAroundAngle, this.m_targetTurnAroundAngle, Time.deltaTime * turnAroundConfig.stopVelocity);
				}
				SimpleFemaleNavigation.TurnStyle turnStyle = this.m_turnStyle;
				if (turnStyle != SimpleFemaleNavigation.TurnStyle._90)
				{
					if (turnStyle != SimpleFemaleNavigation.TurnStyle._180)
					{
						throw new ArgumentOutOfRangeException(this.m_turnStyle.ToString());
					}
					simpleFemalePoseLoader.Turn180(this.m_lastTurnAroundAngle);
				}
				else
				{
					simpleFemalePoseLoader.Turn90(this.m_lastTurnAroundAngle);
				}
				if (this.m_lastTurnAroundAngle == 0f)
				{
					this.m_isTurningAround = false;
				}
			}

			// Token: 0x06001669 RID: 5737 RVA: 0x0006B0ED File Offset: 0x000692ED
			private void Clean()
			{
				this.m_isTurningAround = false;
				this.m_lastTurnAroundAngle = 0f;
				this.m_targetTurnAroundAngle = 0f;
				this.m_lastMagnitude = 0f;
				this.m_lastStrafeLocalDirection = Vector2.zero;
			}

			// Token: 0x0600166A RID: 5738 RVA: 0x0006B122 File Offset: 0x00069322
			public override void Visualize()
			{
				this.navigator.Visualize();
			}

			// Token: 0x0400101F RID: 4127
			public Transform target;

			// Token: 0x04001020 RID: 4128
			private bool m_onlyStrafe;

			// Token: 0x04001021 RID: 4129
			private float m_maxMagnitude;

			// Token: 0x04001022 RID: 4130
			private float m_cornerDistanceMod;

			// Token: 0x04001023 RID: 4131
			private float m_lastMagnitude;

			// Token: 0x04001024 RID: 4132
			private Vector2 m_lastStrafeLocalDirection;

			// Token: 0x04001025 RID: 4133
			private float m_targetTurnAroundAngle;

			// Token: 0x04001026 RID: 4134
			private SimpleFemaleNavigation.TurnStyle m_turnStyle;

			// Token: 0x04001027 RID: 4135
			private float m_lastTurnAroundAngle;

			// Token: 0x04001028 RID: 4136
			private bool m_isTurningAround;

			// Token: 0x04001029 RID: 4137
			public SimpleFemaleNavigation.Navigator navigator = new SimpleFemaleNavigation.Navigator();

			// Token: 0x0400102A RID: 4138
			private float angleVel;

			// Token: 0x0400102B RID: 4139
			private float speedVel;
		}

		// Token: 0x02000382 RID: 898
		[Serializable]
		public class TurnAroundConfig
		{
			// Token: 0x0400102C RID: 4140
			public float stopVelocity = 1f;

			// Token: 0x0400102D RID: 4141
			public float startVelocity = 3f;
		}

		// Token: 0x02000383 RID: 899
		[Serializable]
		public class SingleTurnAroundConfig
		{
			// Token: 0x0400102E RID: 4142
			public float errorAngle = 10f;

			// Token: 0x0400102F RID: 4143
			public float stopVelocity = 3f;

			// Token: 0x04001030 RID: 4144
			public float startVelocity = 4.5f;
		}

		// Token: 0x02000384 RID: 900
		[Serializable]
		public class MovementConfig
		{
			// Token: 0x04001031 RID: 4145
			public float distanceToStartToSlowDown = 1f;

			// Token: 0x04001032 RID: 4146
			public float distanceToFullStop;
		}

		// Token: 0x02000385 RID: 901
		[Serializable]
		public class StrafeConfig : SimpleFemaleNavigation.MovementConfig
		{
			// Token: 0x04001033 RID: 4147
			public float stopVelocity = 4f;

			// Token: 0x04001034 RID: 4148
			public float startVelocity = 2f;

			// Token: 0x04001035 RID: 4149
			public float changeDirectionVelocity = 2f;
		}

		// Token: 0x02000386 RID: 902
		[Serializable]
		public class WalkConfig : SimpleFemaleNavigation.MovementConfig
		{
			// Token: 0x04001036 RID: 4150
			public float deAccelerationTime = 0.1f;

			// Token: 0x04001037 RID: 4151
			public float accelerationTime = 0.3f;

			// Token: 0x04001038 RID: 4152
			public float turnTime = 0.1f;
		}

		// Token: 0x02000387 RID: 903
		[Serializable]
		public class Config
		{
			// Token: 0x04001039 RID: 4153
			[Range(0f, 45f)]
			public float angleToUseTurnAround = 30f;

			// Token: 0x0400103A RID: 4154
			public float distanceToUseOnlyStrafe = 0.66f;

			// Token: 0x0400103B RID: 4155
			public int maxCornerCountToUseOnlyStrafe = 2;

			// Token: 0x0400103C RID: 4156
			[NonSerialized]
			public float distanceToUseStrafe = 1f;

			// Token: 0x0400103D RID: 4157
			[NonSerialized]
			public float angleToUseStrafe = 45f;
		}

		// Token: 0x02000388 RID: 904
		[Serializable]
		public class Navigator
		{
			// Token: 0x170004E6 RID: 1254
			// (get) Token: 0x06001671 RID: 5745 RVA: 0x0006B216 File Offset: 0x00069416
			// (set) Token: 0x06001672 RID: 5746 RVA: 0x0006B21E File Offset: 0x0006941E
			public Vector3 nextCornerDirection { get; private set; }

			// Token: 0x170004E7 RID: 1255
			// (get) Token: 0x06001673 RID: 5747 RVA: 0x0006B227 File Offset: 0x00069427
			// (set) Token: 0x06001674 RID: 5748 RVA: 0x0006B22F File Offset: 0x0006942F
			public float nextCornerDistance { get; private set; }

			// Token: 0x170004E8 RID: 1256
			// (get) Token: 0x06001675 RID: 5749 RVA: 0x0006B238 File Offset: 0x00069438
			// (set) Token: 0x06001676 RID: 5750 RVA: 0x0006B240 File Offset: 0x00069440
			public float nextCornerAngle { get; private set; }

			// Token: 0x170004E9 RID: 1257
			// (get) Token: 0x06001677 RID: 5751 RVA: 0x0006B249 File Offset: 0x00069449
			// (set) Token: 0x06001678 RID: 5752 RVA: 0x0006B251 File Offset: 0x00069451
			public float nextNextCornerAngle { get; private set; }

			// Token: 0x170004EA RID: 1258
			// (get) Token: 0x06001679 RID: 5753 RVA: 0x0006B25C File Offset: 0x0006945C
			public float endCornerDistance
			{
				get
				{
					if (this.m_corners.Length != 0 && !(this.transform == null))
					{
						return Vector3.Distance(this.transform.position, this.m_corners[this.m_corners.Length - 1]);
					}
					return 0f;
				}
			}

			// Token: 0x170004EB RID: 1259
			// (get) Token: 0x0600167A RID: 5754 RVA: 0x0006B2AB File Offset: 0x000694AB
			public int lastCornerCount
			{
				get
				{
					return this.m_lastCornerCountL;
				}
			}

			// Token: 0x170004EC RID: 1260
			// (get) Token: 0x0600167B RID: 5755 RVA: 0x0006B2B3 File Offset: 0x000694B3
			public int totalCornerCount
			{
				get
				{
					return this.m_corners.Length;
				}
			}

			// Token: 0x170004ED RID: 1261
			// (get) Token: 0x0600167C RID: 5756 RVA: 0x0006B2BD File Offset: 0x000694BD
			public int cornersLeftCount
			{
				get
				{
					return this.m_corners.Length - this.m_cornerIndex;
				}
			}

			// Token: 0x170004EE RID: 1262
			// (get) Token: 0x0600167D RID: 5757 RVA: 0x0006B2CE File Offset: 0x000694CE
			public int lastCornersLeftCount
			{
				get
				{
					return this.m_lastCornerCountC - this.m_cornerIndex;
				}
			}

			// Token: 0x170004EF RID: 1263
			// (get) Token: 0x0600167E RID: 5758 RVA: 0x0006B2DD File Offset: 0x000694DD
			public Vector3[] corners
			{
				get
				{
					return this.m_corners;
				}
			}

			// Token: 0x170004F0 RID: 1264
			// (get) Token: 0x0600167F RID: 5759 RVA: 0x0006B2E5 File Offset: 0x000694E5
			public int cornerIndex
			{
				get
				{
					return this.m_cornerIndex;
				}
			}

			// Token: 0x170004F1 RID: 1265
			// (get) Token: 0x06001680 RID: 5760 RVA: 0x0006B2ED File Offset: 0x000694ED
			// (set) Token: 0x06001681 RID: 5761 RVA: 0x0006B2F5 File Offset: 0x000694F5
			public SimpleFemaleNavigation.Navigator.State state { get; private set; }

			// Token: 0x14000022 RID: 34
			// (add) Token: 0x06001682 RID: 5762 RVA: 0x0006B300 File Offset: 0x00069500
			// (remove) Token: 0x06001683 RID: 5763 RVA: 0x0006B338 File Offset: 0x00069538
			public event Action<Transform, SimpleFemaleNavigation.Navigator> onObstacleInTheWay;

			// Token: 0x06001684 RID: 5764 RVA: 0x0006B370 File Offset: 0x00069570
			public void Initiate(Transform transform, Transform[] obstacles)
			{
				this.m_obstacles = obstacles.Select((Transform o) => new SimpleFemaleNavigation.Navigator.Obstacle
				{
					transform = o,
					lastPosition = o.position
				}).ToArray<SimpleFemaleNavigation.Navigator.Obstacle>();
				this.transform = transform;
				this.path = new NavMeshPath();
				this.initiated = true;
				this.m_cornerIndex = 0;
				this.m_corners = new Vector3[0];
				this.state = SimpleFemaleNavigation.Navigator.State.Idle;
				this.lastTargetPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
			}

			// Token: 0x06001685 RID: 5765 RVA: 0x0006B3FC File Offset: 0x000695FC
			public void Clean()
			{
				this.m_lastCornerCountC = 0;
				this.m_lastCornerCountL = 0;
				this.m_currentObstacleMovido = null;
				this.m_cornerIndex = 0;
				this.m_corners = new Vector3[0];
				this.state = SimpleFemaleNavigation.Navigator.State.Idle;
				this.lastTargetPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
			}

			// Token: 0x06001686 RID: 5766 RVA: 0x0006B454 File Offset: 0x00069654
			public void Update(Vector3 currentTargetPosition)
			{
				if (!this.initiated)
				{
					Debug.LogError("Trying to update an uninitiated Navigator.");
					return;
				}
				SimpleFemaleNavigation.Navigator.State state = this.state;
				if (state != SimpleFemaleNavigation.Navigator.State.Seeking)
				{
					if (state != SimpleFemaleNavigation.Navigator.State.OnPath)
					{
						return;
					}
					Transform transform;
					if (this.ObstalesMoved(out transform))
					{
						this.m_currentObstacleMovido = transform;
						this.CalculatePath(currentTargetPosition);
						return;
					}
					if (Time.time > this.nextPathTime && SimpleFemaleNavigation.Navigator.HorDistance(currentTargetPosition, this.lastTargetPosition) > this.recalculateOnPathDistance * this.characterScale)
					{
						this.CalculatePath(currentTargetPosition);
						return;
					}
					if (this.m_cornerIndex < this.m_corners.Length)
					{
						this.SetDirection(this.m_cornerIndex);
						if (this.nextCornerDistance < this.cornerRadius * this.characterScale || (this.m_cornerIndex == 0 && this.EnTrayectoria(0, 1)))
						{
							if (this.m_cornerIndex == 0)
							{
								int num = this.m_cornerIndex + 1;
								if (this.m_corners.ContieneIndex(num))
								{
									this.SetDirection(num);
								}
							}
							this.m_cornerIndex++;
							if (this.m_cornerIndex >= this.m_corners.Length)
							{
								this.Stop();
							}
						}
					}
				}
				else
				{
					if (this.path.status == NavMeshPathStatus.PathComplete || this.path.status == NavMeshPathStatus.PathPartial)
					{
						this.m_corners = this.path.corners;
						this.m_cornerIndex = 0;
						if (this.m_corners.Length == 0)
						{
							if (this.path.status == NavMeshPathStatus.PathPartial)
							{
								this.Stop();
							}
							else
							{
								this.CalculatePath(currentTargetPosition);
							}
						}
						else
						{
							this.state = SimpleFemaleNavigation.Navigator.State.OnPath;
							this.m_lastCornerCountL = this.m_lastCornerCountC;
							this.m_lastCornerCountC = this.m_corners.Length;
							if (this.m_currentObstacleMovido != null)
							{
								Transform currentObstacleMovido = this.m_currentObstacleMovido;
								this.m_currentObstacleMovido = null;
								float magnitude = (currentObstacleMovido.position - this.transform.position).magnitude;
								bool flag = magnitude < this.obstacleTooCloseDistance * this.characterScale;
								bool flag2 = magnitude < this.stopByObstacleDistance * this.characterScale;
								if (this.m_lastCornerCountC > this.m_lastCornerCountL + (flag ? 0 : 1) || flag2)
								{
									Action<Transform, SimpleFemaleNavigation.Navigator> action = this.onObstacleInTheWay;
									if (action != null)
									{
										action(currentObstacleMovido, this);
									}
								}
							}
						}
					}
					if (this.path.status == NavMeshPathStatus.PathInvalid)
					{
						Debug.LogWarning("Path Invalid", this.transform);
						this.Stop();
						return;
					}
				}
			}

			// Token: 0x06001687 RID: 5767 RVA: 0x0006B69C File Offset: 0x0006989C
			private bool EnTrayectoria(int currentIndex, int nextIndex)
			{
				if (!this.m_corners.ContieneIndex(currentIndex) || !this.m_corners.ContieneIndex(nextIndex))
				{
					return false;
				}
				Vector3 vector = this.m_corners[currentIndex];
				Vector3 vector2 = this.m_corners[nextIndex];
				Vector3 vector3 = Math3d.ProjectPointOnLineSegment(vector, vector2, this.transform.position);
				vector3.y = 0f;
				return vector3.magnitude < this.cornerRadius * this.characterScale;
			}

			// Token: 0x06001688 RID: 5768 RVA: 0x0006B714 File Offset: 0x00069914
			private void SetDirection(int cornerIndex)
			{
				this.nextCornerAngle = 0f;
				this.nextCornerDistance = 0f;
				this.nextNextCornerAngle = 0f;
				this.nextCornerDirection = Vector3.zero;
				Vector3 vector = this.m_corners[cornerIndex];
				Vector3 vector2 = vector - this.transform.position;
				vector2.y = 0f;
				float magnitude = vector2.magnitude;
				if (magnitude > 0f)
				{
					this.nextCornerDistance = magnitude;
					this.nextCornerDirection = vector2 / magnitude;
					this.nextCornerAngle = Vector3.Angle(this.transform.forward, this.nextCornerDirection);
					int num = cornerIndex + 1;
					if (num < this.m_corners.Length)
					{
						Vector3 normalized = (this.m_corners[num] - vector).normalized;
						this.nextNextCornerAngle = Vector3.Angle(this.nextCornerDirection, normalized);
					}
				}
			}

			// Token: 0x06001689 RID: 5769 RVA: 0x0006B7F8 File Offset: 0x000699F8
			public void CalculatePath(Vector3 targetPosition)
			{
				if (SimpleFemaleNavigation.Navigator.Find(this.path, this.transform.position, this.cornerRadius, targetPosition, this.characterScale, this.maxSampleDistance))
				{
					this.lastTargetPosition = targetPosition;
					this.state = SimpleFemaleNavigation.Navigator.State.Seeking;
				}
				else
				{
					this.Stop();
				}
				this.nextPathTime = Time.time + this.nextPathInterval;
			}

			// Token: 0x0600168A RID: 5770 RVA: 0x0006B858 File Offset: 0x00069A58
			public static bool IsOnTarget(Vector3 startPosition, float cornerRadius, Vector3 targetPosition, float characterScale = 1f)
			{
				return SimpleFemaleNavigation.Navigator.HorDistance(startPosition, targetPosition) < cornerRadius * 2f * characterScale;
			}

			// Token: 0x0600168B RID: 5771 RVA: 0x0006B86C File Offset: 0x00069A6C
			private static float HorDistance(Vector3 p1, Vector3 p2)
			{
				return Vector2.Distance(new Vector2(p1.x, p1.z), new Vector2(p2.x, p2.z));
			}

			// Token: 0x0600168C RID: 5772 RVA: 0x0006B898 File Offset: 0x00069A98
			public static bool Find(NavMeshPath path, Vector3 startPosition, float cornerRadius, Vector3 targetPosition, float characterScale = 1f, float maxSampleDistance = 1f)
			{
				if (SimpleFemaleNavigation.Navigator.IsOnTarget(startPosition, cornerRadius, targetPosition, characterScale))
				{
					return false;
				}
				if (NavMesh.CalculatePath(startPosition, targetPosition, -1, path))
				{
					return true;
				}
				NavMeshHit navMeshHit = default(NavMeshHit);
				NavMeshHit navMeshHit2 = default(NavMeshHit);
				return NavMesh.SamplePosition(targetPosition, out navMeshHit, maxSampleDistance * characterScale, -1) && NavMesh.SamplePosition(startPosition, out navMeshHit2, maxSampleDistance * characterScale, -1) && NavMesh.CalculatePath(navMeshHit2.position, navMeshHit.position, -1, path);
			}

			// Token: 0x0600168D RID: 5773 RVA: 0x0006B90A File Offset: 0x00069B0A
			public void Stop()
			{
				this.m_currentObstacleMovido = null;
				this.state = SimpleFemaleNavigation.Navigator.State.Idle;
				this.nextCornerDirection = Vector3.zero;
				this.nextCornerDistance = 0f;
				this.nextCornerAngle = 0f;
				this.nextNextCornerAngle = 0f;
			}

			// Token: 0x0600168E RID: 5774 RVA: 0x0006B948 File Offset: 0x00069B48
			private bool ObstalesMoved(out Transform obs)
			{
				obs = null;
				bool flag = false;
				for (int i = 0; i < this.m_obstacles.Length; i++)
				{
					if (this.m_obstacles[i].Moved(this.recalculateOnObstacleMovedDistance * this.characterScale))
					{
						flag = true;
						obs = this.m_obstacles[i].transform;
					}
				}
				return flag;
			}

			// Token: 0x0600168F RID: 5775 RVA: 0x0006B99C File Offset: 0x00069B9C
			public void Visualize()
			{
				if (this.nextCornerDistance <= 0f)
				{
					return;
				}
				if (this.state == SimpleFemaleNavigation.Navigator.State.Idle)
				{
					Gizmos.color = Color.gray;
				}
				if (this.state == SimpleFemaleNavigation.Navigator.State.Seeking)
				{
					Gizmos.color = Color.red;
				}
				if (this.state == SimpleFemaleNavigation.Navigator.State.OnPath)
				{
					Gizmos.color = Color.green;
				}
				if (this.m_corners.Length != 0 && this.state == SimpleFemaleNavigation.Navigator.State.OnPath && this.m_cornerIndex == 0)
				{
					Gizmos.DrawLine(this.transform.position + Vector3.up * 0.01f, this.m_corners[0] + Vector3.up * 0.01f);
				}
				for (int i = 0; i < this.m_corners.Length; i++)
				{
					Gizmos.DrawSphere(this.m_corners[i] + Vector3.up * 0.01f, 0.1f);
				}
				if (this.m_corners.Length > 1)
				{
					for (int j = 0; j < this.m_corners.Length - 1; j++)
					{
						Gizmos.DrawLine(this.m_corners[j] + Vector3.up * 0.01f, this.m_corners[j + 1] + Vector3.up * 0.01f);
					}
				}
				Gizmos.color = Color.white;
			}

			// Token: 0x0400103E RID: 4158
			public const float defaultCornerRadius = 0.2f;

			// Token: 0x0400103F RID: 4159
			public const float defaultMaxSampleDistance = 1f;

			// Token: 0x04001040 RID: 4160
			[Tooltip("Increase this value if the character starts running in a circle, not able to reach the corner because of a too large turning radius.")]
			public float cornerRadius = 0.2f;

			// Token: 0x04001041 RID: 4161
			[Tooltip("Recalculate path if target position has moved by this distance from the position it was at when the path was originally calculated")]
			public float recalculateOnPathDistance = 0.333f;

			// Token: 0x04001042 RID: 4162
			public float recalculateOnObstacleMovedDistance = 0.2f;

			// Token: 0x04001043 RID: 4163
			public float obstacleTooCloseDistance = 1.5f;

			// Token: 0x04001044 RID: 4164
			public float stopByObstacleDistance = 0.75f;

			// Token: 0x04001045 RID: 4165
			[Tooltip("Sample within this distance from sourcePosition.")]
			public float maxSampleDistance = 1f;

			// Token: 0x04001046 RID: 4166
			[Tooltip("Interval of updating the path")]
			public float nextPathInterval = 0.333f;

			// Token: 0x0400104B RID: 4171
			[HideInInspector]
			public float characterScale;

			// Token: 0x0400104C RID: 4172
			[SerializeField]
			private SimpleFemaleNavigation.Navigator.Obstacle[] m_obstacles;

			// Token: 0x0400104E RID: 4174
			private Transform transform;

			// Token: 0x0400104F RID: 4175
			private int m_cornerIndex;

			// Token: 0x04001050 RID: 4176
			private Vector3[] m_corners = new Vector3[0];

			// Token: 0x04001051 RID: 4177
			private NavMeshPath path;

			// Token: 0x04001052 RID: 4178
			private Vector3 lastTargetPosition;

			// Token: 0x04001053 RID: 4179
			private bool initiated;

			// Token: 0x04001054 RID: 4180
			private float nextPathTime;

			// Token: 0x04001055 RID: 4181
			[ReadOnlyUI]
			[SerializeField]
			private int m_lastCornerCountC = int.MaxValue;

			// Token: 0x04001056 RID: 4182
			private int m_lastCornerCountL = int.MaxValue;

			// Token: 0x04001057 RID: 4183
			private Transform m_currentObstacleMovido;

			// Token: 0x02000389 RID: 905
			public enum State
			{
				// Token: 0x0400105A RID: 4186
				Idle,
				// Token: 0x0400105B RID: 4187
				Seeking,
				// Token: 0x0400105C RID: 4188
				OnPath
			}

			// Token: 0x0200038A RID: 906
			[Serializable]
			private class Obstacle
			{
				// Token: 0x06001691 RID: 5777 RVA: 0x0006BB80 File Offset: 0x00069D80
				public bool Moved(float distanceThreshold)
				{
					if (this.transform == null)
					{
						return false;
					}
					Vector3 position = this.transform.position;
					if (Vector3.Distance(position, this.lastPosition) > distanceThreshold)
					{
						this.lastPosition = position;
						return true;
					}
					return false;
				}

				// Token: 0x0400105D RID: 4189
				public Transform transform;

				// Token: 0x0400105E RID: 4190
				public Vector3 lastPosition;
			}
		}
	}
}

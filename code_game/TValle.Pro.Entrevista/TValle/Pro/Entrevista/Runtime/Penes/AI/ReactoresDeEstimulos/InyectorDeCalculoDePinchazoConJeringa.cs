using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes.AI.ReactoresDeEstimulos
{
	// Token: 0x02000091 RID: 145
	public class InyectorDeCalculoDePinchazoConJeringa : CustomMonobehaviour, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00021B26 File Offset: 0x0001FD26
		public TipoDeCalculadorDeEstimulo tipo
		{
			get
			{
				return TipoDeCalculadorDeEstimulo.frame;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00021B29 File Offset: 0x0001FD29
		public Emocion emo
		{
			get
			{
				return this.m_inyectadoFallido.emocion ?? this.m_inyectadoExito.emocion;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00021B45 File Offset: 0x0001FD45
		public double prioridad
		{
			get
			{
				return 9999.0 * Emocion.APrioridad(this.emo);
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00021B5C File Offset: 0x0001FD5C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_jeringa = base.GetComponent<Jeringa>();
			if (this.m_jeringa == null)
			{
				throw new ArgumentNullException("m_jeringa", "m_jeringa null reference.");
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00021B90 File Offset: 0x0001FD90
		public void OneTimePinchazo(ICharacter victim, HitSkinBasica victimSkin, Collider colliderChocandonos, ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, float angleScore, float pumpScore, float zoneScore)
		{
			IReactorInyectable componentEnRoot = victim.GetComponentEnRoot<IReactorInyectable>();
			if (componentEnRoot == null)
			{
				Debug.LogError("victim has no Reactor");
				return;
			}
			IParteDelCuerpoHumanoPrioridades componentEnRoot2 = victim.GetComponentEnRoot<IParteDelCuerpoHumanoPrioridades>();
			if (componentEnRoot2 == null)
			{
				Debug.LogError("victim has no ParteDelCuerpoHumanoPrioridades");
				return;
			}
			this.DetenerPinchazo();
			new InyectorDeCalculoDePinchazoConJeringa.PinchazoPenetrante().Start(true, this, this.m_inyectadoFallido, componentEnRoot, victimSkin, colliderChocandonos, ref collisionData, componentEnRoot2, angleScore, pumpScore, zoneScore);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00021BEC File Offset: 0x0001FDEC
		public void StartPinchazo(ICharacter victim, HitSkinBasica victimSkin, Collider colliderChocandonos, ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, float angleScore, float pumpScore, float zoneScore)
		{
			IReactorInyectable componentEnRoot = victim.GetComponentEnRoot<IReactorInyectable>();
			if (componentEnRoot == null)
			{
				Debug.LogError("victim has no Reactor");
				return;
			}
			IParteDelCuerpoHumanoPrioridades componentEnRoot2 = victim.GetComponentEnRoot<IParteDelCuerpoHumanoPrioridades>();
			if (componentEnRoot2 == null)
			{
				Debug.LogError("victim has no ParteDelCuerpoHumanoPrioridades");
				return;
			}
			this.DetenerPinchazo();
			this.m_currentPinchazo = new InyectorDeCalculoDePinchazoConJeringa.PinchazoPenetrante();
			this.m_currentPinchazo.Start(false, this, this.m_inyectadoExito, componentEnRoot, victimSkin, colliderChocandonos, ref collisionData, componentEnRoot2, angleScore, pumpScore, zoneScore);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00021C53 File Offset: 0x0001FE53
		public void UpdatePinchazo(ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, float pumpScore)
		{
			if (this.m_currentPinchazo == null)
			{
				Debug.LogError("tratando de dar update a pinchazo pero no ha sido pinchada", this);
				return;
			}
			this.m_currentPinchazo.Update(ref collisionData, pumpScore);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00021C76 File Offset: 0x0001FE76
		public void DetenerPinchazo()
		{
			InyectorDeCalculoDePinchazoConJeringa.PinchazoPenetrante currentPinchazo = this.m_currentPinchazo;
			if (currentPinchazo != null)
			{
				currentPinchazo.Detener();
			}
			this.m_currentPinchazo = null;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00021C90 File Offset: 0x0001FE90
		public bool IgnorarPinchazoPenetracionPorAngulo(float penetrationAngle, out float angleScore)
		{
			angleScore = 0f;
			if (penetrationAngle > this.dolorConfig.penetracionAngleParaIgnorar)
			{
				return true;
			}
			angleScore = Mathf.InverseLerp(this.dolorConfig.maxPenetracionAngle, this.dolorConfig.minPenetracionAngle, penetrationAngle).OutPow(2f);
			return false;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00021CE0 File Offset: 0x0001FEE0
		private static void SetPinchazoCalculo(InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado inyectado, Emocion emocion, ICalculadorDeEstimulo calculador, IReadOnlyList<BodyPartEnum> PartPinchadas, HitSkinBasica victimSkin, IParteDelCuerpoHumanoPrioridades prioridadesDeObjetoEstimulado, TocanteObjeto tocador, ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, bool esPinchazoInicial, InyectorDeCalculoDePinchazoConJeringa.DolorConfig config, float deltaTime, float scoreByAngle, float scoreByVel, float scoreByPumpVel, float scoreByZone)
		{
			inyectado.Clear();
			inyectado.Set(calculador);
			inyectado.emocion = emocion;
			inyectado.prioridad = 1000000000.0 / calculador.prioridad;
			if (esPinchazoInicial)
			{
				inyectado.ignorarCoolDown = true;
				inyectado.ignorarProbabilidad = true;
			}
			else
			{
				inyectado.ignorarCoolDown = false;
				inyectado.ignorarProbabilidad = false;
			}
			EstimuloTactil estimulo = inyectado.estimulo;
			estimulo.DefinirReferencias(victimSkin, prioridadesDeObjetoEstimulado, tocador, tocador.transform, null);
			estimulo.DefinirTransformsYVectores(victimSkin.boneTarget, new Vector3?(collisionData.collisionNormal), new Vector3?(collisionData.collisionPoint), null);
			scoreByAngle = scoreByAngle.OutPow(2f);
			scoreByVel = scoreByVel.OutPow(2f);
			scoreByPumpVel = scoreByPumpVel.OutPow(2f);
			scoreByZone = scoreByZone.OutPow(2f);
			estimulo.side = Side.none;
			for (int i = 0; i < PartPinchadas.Count; i++)
			{
				estimulo.AddParteEstimulada(PartPinchadas[i].ParseAParteHumana());
			}
			estimulo.tipoDeEstimulo = TipoDeEstimulo.tactil;
			estimulo.tipo = DireccionDeEstimulo.recibida;
			estimulo.SetTipoDeEstimuloTactil(TipoDeEstimuloTactil.poking);
			estimulo.velocidadRelativaEmuladaMaxima = collisionData.collisionVelocityMag;
			estimulo.velocidadRelativaEmuladaTotal = collisionData.collisionVelocityMag;
			estimulo.velocidadEstimuladoEmulada = collisionData.skinVelocity;
			estimulo.velocidadEstimulanteEmulada = collisionData.agujaVelocity;
			estimulo.velocidadRelativaEmulada = collisionData.collisionVelocity;
			estimulo.velocidadRelativaPhysics = collisionData.collisionVelocity;
			estimulo.velocidadRelativaPhysicsMagnitud = collisionData.collisionVelocityMag;
			estimulo.impulsoPhysics = collisionData.collisionVelocity;
			estimulo.esDePhysicsEngine = false;
			estimulo.cantidadDeContanctos = 1;
			estimulo.esUnaVez = esPinchazoInicial;
			UmbralBasico.Estado estado = new UmbralBasico.Estado(ForcedUpdateId.current);
			if (esPinchazoInicial)
			{
				estado.rango = UmbralBasico.RangoEstado.enRango;
				estado.offsetMod = 1f;
				estado.spotScore = SpotScore.enSpot;
				estado.spotRango = UmbralBasico.RangoEstado.enRango;
				float num = config.maxDolorPorSegundoPorAnguloV2 * (1f - scoreByAngle);
				float num2 = config.maxDolorPorSegundoPorVelocidadV2 * (1f - scoreByVel);
				float num3 = config.maxDolorPorSegundoBombeoV2 * (1f - scoreByPumpVel);
				float num4 = config.maxDolorPorSegundoPorZonaErrada * (1f - scoreByZone);
				float num5 = config.minDolorPorSegundoV2 + num + num2 + num3 + num4;
				estado.SobreEscribirEstimulacionGeneradaEnFrame(num5, num5, 100f);
			}
			else
			{
				estado.rango = UmbralBasico.RangoEstado.enRango;
				estado.offsetMod = 1f;
				estado.spotScore = SpotScore.enSpot;
				estado.spotRango = UmbralBasico.RangoEstado.enRango;
				float num6 = Mathf.Lerp(config.maxDolorPorSegundoPorAnguloV2, config.minDolorPorSegundoV2, scoreByAngle);
				float num7 = Mathf.Lerp(config.maxDolorPorSegundoPorVelocidadV2, config.minDolorPorSegundoV2, scoreByVel);
				float num8 = Mathf.Lerp(config.maxDolorPorSegundoBombeoV2, config.minDolorPorSegundoV2, scoreByPumpVel);
				float num9 = Mathf.Lerp(config.maxDolorPorSegundoPorZonaErrada, config.minDolorPorSegundoV2, scoreByZone.OutPow(6f));
				float num10 = (num6 + num7 + num8 + num9) * deltaTime;
				estado.SobreEscribirEstimulacionGeneradaEnFrame(num10, num10, 1f);
			}
			inyectado.estado = estado;
			inyectado.estimulante = ParteQuePuedeEstimular.propSexToy;
			emocion.ChangeValueNextUpdateModified(estado.estimulacionGeneradaEnFrame);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00022002 File Offset: 0x00020202
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0002200A File Offset: 0x0002020A
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00022012 File Offset: 0x00020212
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0002201B File Offset: 0x0002021B
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00022023 File Offset: 0x00020223
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0002202B File Offset: 0x0002022B
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04000399 RID: 921
		public InyectorDeCalculoDePinchazoConJeringa.DolorConfig dolorConfig = new InyectorDeCalculoDePinchazoConJeringa.DolorConfig();

		// Token: 0x0400039A RID: 922
		[ReadOnlyUI]
		[SerializeField]
		private InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado m_inyectadoExito = new InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado();

		// Token: 0x0400039B RID: 923
		[ReadOnlyUI]
		[SerializeField]
		private InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado m_inyectadoFallido = new InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado();

		// Token: 0x0400039C RID: 924
		[NonSerialized]
		private InyectorDeCalculoDePinchazoConJeringa.PinchazoPenetrante m_currentPinchazo;

		// Token: 0x0400039D RID: 925
		private Jeringa m_jeringa;

		// Token: 0x0200021D RID: 541
		[Serializable]
		public struct CollisionData
		{
			// Token: 0x04000A28 RID: 2600
			public Vector3 collisionPoint;

			// Token: 0x04000A29 RID: 2601
			public Vector3 collisionNormal;

			// Token: 0x04000A2A RID: 2602
			public Vector3 collisionVelocity;

			// Token: 0x04000A2B RID: 2603
			public float collisionVelocityMag;

			// Token: 0x04000A2C RID: 2604
			public Vector3 agujaVelocity;

			// Token: 0x04000A2D RID: 2605
			public Vector3 skinVelocity;

			// Token: 0x04000A2E RID: 2606
			public Vector3 agujaPos;

			// Token: 0x04000A2F RID: 2607
			public Vector3 skinPos;
		}

		// Token: 0x0200021E RID: 542
		public class PinchazoPenetrante
		{
			// Token: 0x06000FF5 RID: 4085 RVA: 0x0004DC3C File Offset: 0x0004BE3C
			public void Start(bool volatil, InyectorDeCalculoDePinchazoConJeringa inyector, InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado calculo, IReactorInyectable reactor, HitSkinBasica skin, Collider colliderChocandonos, ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, IParteDelCuerpoHumanoPrioridades prioridadesDeObjetoEstimulado, float angleScore, float pumpScore, float zoneScore)
			{
				this.m_volatil = volatil;
				this.m_calculo = calculo;
				this.m_reactor = reactor;
				this.m_victimSkin = skin;
				this.m_inyector = inyector;
				this.m_victimCollider = colliderChocandonos;
				this.m_CollisionData = collisionData;
				this.m_PrioridadesDeObjetoEstimulado = prioridadesDeObjetoEstimulado;
				this.m_angleScore = angleScore;
				this.m_pumpScore = pumpScore;
				this.m_zoneScore = zoneScore;
				RaycastHit raycastHit;
				if (!this.m_victimSkin.TryCalcularPartesImpactadasDeCollision(this.m_CollisionData.collisionPoint, this.m_CollisionData.collisionNormal, this.m_victimCollider, out raycastHit, this.PartPinchadas, false))
				{
					Debug.LogError("no se pudo calcular la parte impactada por jeringa, parte: " + this.m_victimSkin.name, this.m_victimSkin);
				}
				Component component = reactor as Component;
				this.m_dolor = ((component != null) ? component.GetComponentEnRoot(false) : null);
				if (this.m_dolor == null)
				{
					Debug.LogError("victim as no Dolor Emotion");
					return;
				}
				reactor.reaccionando -= this.OnReaccionando;
				reactor.reaccionando += this.OnReaccionando;
				if (volatil)
				{
					reactor.reaccionado -= this.OnReaccionado;
					reactor.reaccionado += this.OnReaccionado;
				}
			}

			// Token: 0x06000FF6 RID: 4086 RVA: 0x0004DD77 File Offset: 0x0004BF77
			public void Update(ref InyectorDeCalculoDePinchazoConJeringa.CollisionData collisionData, float pumpScore)
			{
				this.m_CollisionData = collisionData;
				this.m_pumpScore = pumpScore;
			}

			// Token: 0x06000FF7 RID: 4087 RVA: 0x0004DD8C File Offset: 0x0004BF8C
			private void OnReaccionando(IList<ICalculoDeEstimulo> calculos, IReactorInyectable reactor)
			{
				TocanteObjeto tipTocante = this.m_inyector.m_jeringa.tipTocante;
				Transform transform = tipTocante.transform;
				if (this.PartPinchadas.Count == 0)
				{
					Debug.LogError("no se pudo calcular la parte impactada por jeringa, parte: " + this.m_victimSkin.name, this.m_victimSkin);
					return;
				}
				InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado calculo = this.m_calculo;
				EstimuloTactil estimulo = calculo.estimulo;
				float num = Mathf.InverseLerp(this.m_inyector.dolorConfig.maxVelPenetracion, this.m_inyector.dolorConfig.minVelPenetracion, this.m_CollisionData.collisionVelocityMag);
				InyectorDeCalculoDePinchazoConJeringa.SetPinchazoCalculo(calculo, this.m_dolor, this.m_inyector, this.PartPinchadas, this.m_victimSkin, this.m_PrioridadesDeObjetoEstimulado, tipTocante, ref this.m_CollisionData, this.m_firstTime, this.m_inyector.dolorConfig, Time.deltaTime, this.m_angleScore, num, this.m_pumpScore, this.m_zoneScore);
				calculos.Insert(0, calculo);
				this.m_firstTime = false;
			}

			// Token: 0x06000FF8 RID: 4088 RVA: 0x0004DE81 File Offset: 0x0004C081
			private void OnReaccionado(IReactorInyectable reactor)
			{
				if (this.m_volatil)
				{
					this.Detener();
					return;
				}
				throw new NotSupportedException("si es volvatil no deberia recibir este evento");
			}

			// Token: 0x06000FF9 RID: 4089 RVA: 0x0004DE9C File Offset: 0x0004C09C
			public void Detener()
			{
				InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado calculo = this.m_calculo;
				if (calculo != null)
				{
					calculo.Clear();
				}
				if (this.m_reactor != null)
				{
					this.m_reactor.reaccionado -= this.OnReaccionado;
					this.m_reactor.reaccionando -= this.OnReaccionando;
				}
			}

			// Token: 0x04000A30 RID: 2608
			private List<BodyPartEnum> PartPinchadas = new List<BodyPartEnum>();

			// Token: 0x04000A31 RID: 2609
			private InyectorDeCalculoDePinchazoConJeringa.PinchazoCalculoInyectado m_calculo;

			// Token: 0x04000A32 RID: 2610
			private InyectorDeCalculoDePinchazoConJeringa m_inyector;

			// Token: 0x04000A33 RID: 2611
			private IReactorInyectable m_reactor;

			// Token: 0x04000A34 RID: 2612
			private HitSkinBasica m_victimSkin;

			// Token: 0x04000A35 RID: 2613
			private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

			// Token: 0x04000A36 RID: 2614
			private Collider m_victimCollider;

			// Token: 0x04000A37 RID: 2615
			private InyectorDeCalculoDePinchazoConJeringa.CollisionData m_CollisionData;

			// Token: 0x04000A38 RID: 2616
			private float m_angleScore;

			// Token: 0x04000A39 RID: 2617
			private float m_pumpScore;

			// Token: 0x04000A3A RID: 2618
			private float m_zoneScore;

			// Token: 0x04000A3B RID: 2619
			private Dolor m_dolor;

			// Token: 0x04000A3C RID: 2620
			[NonSerialized]
			private bool m_firstTime = true;

			// Token: 0x04000A3D RID: 2621
			[NonSerialized]
			private bool m_volatil = true;
		}

		// Token: 0x0200021F RID: 543
		[Serializable]
		public class DolorConfig
		{
			// Token: 0x04000A3E RID: 2622
			public float penetracionAngleParaIgnorar = 85f;

			// Token: 0x04000A3F RID: 2623
			public float maxPenetracionAngle = 45f;

			// Token: 0x04000A40 RID: 2624
			public float minPenetracionAngle = 10f;

			// Token: 0x04000A41 RID: 2625
			public float minVelPenetracion = 0.0333f;

			// Token: 0x04000A42 RID: 2626
			public float maxVelPenetracion = 0.6666f;

			// Token: 0x04000A43 RID: 2627
			public float maxDolorPorSegundoPorZonaErrada = 100f;

			// Token: 0x04000A44 RID: 2628
			public float maxDolorPorSegundoPorAnguloV2 = 50f;

			// Token: 0x04000A45 RID: 2629
			public float maxDolorPorSegundoPorVelocidadV2 = 15f;

			// Token: 0x04000A46 RID: 2630
			public float maxDolorPorSegundoBombeoV2 = 25f;

			// Token: 0x04000A47 RID: 2631
			public float minDolorPorSegundoV2 = 0.001f;
		}

		// Token: 0x02000220 RID: 544
		[Serializable]
		public class PinchazoCalculoInyectado : ICalculoDeEstimulo, ICalculoDeEstimuloBuffeador, ICalculoDeEstimuloReaccionable, ICalculoDeEstimuloTactil, ICalculoDeEstimulo<EstimuloTactil>, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x1700028E RID: 654
			// (get) Token: 0x06000FFC RID: 4092 RVA: 0x0004DF95 File Offset: 0x0004C195
			// (set) Token: 0x06000FFD RID: 4093 RVA: 0x0004DF9D File Offset: 0x0004C19D
			public bool causoMaxValue { get; set; }

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x06000FFE RID: 4094 RVA: 0x0004DFA6 File Offset: 0x0004C1A6
			// (set) Token: 0x06000FFF RID: 4095 RVA: 0x0004DFAE File Offset: 0x0004C1AE
			public bool canProduceBuff { get; set; } = true;

			// Token: 0x06001000 RID: 4096 RVA: 0x0004DFB7 File Offset: 0x0004C1B7
			public void Set(ICalculadorDeEstimulo Calculador)
			{
				if (Calculador == null)
				{
					throw new ArgumentNullException("Calculador", "Calculador null reference.");
				}
				this.m_calculador = Calculador;
			}

			// Token: 0x06001001 RID: 4097 RVA: 0x0004DFD3 File Offset: 0x0004C1D3
			public void Clear()
			{
				this.estado = default(UmbralBasico.Estado);
				this.estimulo.Clear();
				this.m_calculador = null;
				this.m_calculadorSec = null;
				this.emocion = null;
			}

			// Token: 0x17000290 RID: 656
			// (get) Token: 0x06001002 RID: 4098 RVA: 0x0004E001 File Offset: 0x0004C201
			// (set) Token: 0x06001003 RID: 4099 RVA: 0x0004E009 File Offset: 0x0004C209
			Emocion ICalculoDeEstimulo.emocion
			{
				get
				{
					return this.emocion;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x06001004 RID: 4100 RVA: 0x0004E010 File Offset: 0x0004C210
			double ICalculoDeEstimulo.prioridad
			{
				get
				{
					return this.prioridad;
				}
			}

			// Token: 0x17000292 RID: 658
			// (get) Token: 0x06001005 RID: 4101 RVA: 0x0004E018 File Offset: 0x0004C218
			// (set) Token: 0x06001006 RID: 4102 RVA: 0x0004E020 File Offset: 0x0004C220
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return this.m_calculador;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000293 RID: 659
			// (get) Token: 0x06001007 RID: 4103 RVA: 0x0004E027 File Offset: 0x0004C227
			// (set) Token: 0x06001008 RID: 4104 RVA: 0x0004E02A File Offset: 0x0004C22A
			public string tag
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000294 RID: 660
			// (get) Token: 0x06001009 RID: 4105 RVA: 0x0004E031 File Offset: 0x0004C231
			// (set) Token: 0x0600100A RID: 4106 RVA: 0x0004E034 File Offset: 0x0004C234
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000295 RID: 661
			// (get) Token: 0x0600100B RID: 4107 RVA: 0x0004E03B File Offset: 0x0004C23B
			// (set) Token: 0x0600100C RID: 4108 RVA: 0x0004E043 File Offset: 0x0004C243
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					return this.m_calculadorSec;
				}
				set
				{
					this.m_calculadorSec = value;
				}
			}

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x0600100D RID: 4109 RVA: 0x0004E04C File Offset: 0x0004C24C
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x17000297 RID: 663
			// (get) Token: 0x0600100E RID: 4110 RVA: 0x0004E054 File Offset: 0x0004C254
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x0600100F RID: 4111 RVA: 0x0004E057 File Offset: 0x0004C257
			// (set) Token: 0x06001010 RID: 4112 RVA: 0x0004E05F File Offset: 0x0004C25F
			public bool reaccionable { get; set; } = true;

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x06001011 RID: 4113 RVA: 0x0004E068 File Offset: 0x0004C268
			// (set) Token: 0x06001012 RID: 4114 RVA: 0x0004E070 File Offset: 0x0004C270
			public bool ignorarCoolDown { get; set; } = true;

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x06001013 RID: 4115 RVA: 0x0004E079 File Offset: 0x0004C279
			// (set) Token: 0x06001014 RID: 4116 RVA: 0x0004E081 File Offset: 0x0004C281
			public bool ignorarProbabilidad { get; set; } = true;

			// Token: 0x1700029B RID: 667
			// (get) Token: 0x06001015 RID: 4117 RVA: 0x0004E08A File Offset: 0x0004C28A
			UmbralBasico.Estado ICalculoDeEstimuloTactil.estado
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x06001016 RID: 4118 RVA: 0x0004E092 File Offset: 0x0004C292
			EstimuloTactil ICalculoDeEstimulo<EstimuloTactil>.estimulo
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x1700029D RID: 669
			// (get) Token: 0x06001017 RID: 4119 RVA: 0x0004E09A File Offset: 0x0004C29A
			public EstimuloTactil estimuloInvertido
			{
				get
				{
					return null;
				}
			}

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x06001018 RID: 4120 RVA: 0x0004E09D File Offset: 0x0004C29D
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x06001019 RID: 4121 RVA: 0x0004E0A0 File Offset: 0x0004C2A0
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x0600101A RID: 4122 RVA: 0x0004E0A3 File Offset: 0x0004C2A3
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x0600101B RID: 4123 RVA: 0x0004E0B0 File Offset: 0x0004C2B0
			// (set) Token: 0x0600101C RID: 4124 RVA: 0x0004E0B8 File Offset: 0x0004C2B8
			public ParteQuePuedeEstimular estimulanteParte
			{
				get
				{
					return this.estimulante;
				}
				set
				{
					this.estimulante = value;
				}
			}

			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x0600101D RID: 4125 RVA: 0x0004E0C1 File Offset: 0x0004C2C1
			// (set) Token: 0x0600101E RID: 4126 RVA: 0x0004E0C4 File Offset: 0x0004C2C4
			public ParteQuePuedeEstimular estimulanteParteInvertido
			{
				get
				{
					return ParteQuePuedeEstimular.None;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600101F RID: 4127 RVA: 0x0004E0CB File Offset: 0x0004C2CB
			public void FixEstimuloInstanceTypes(EstimuloTactil instance, EstimuloTactil instanceInverted)
			{
				this.estimulo = instance;
				if (instanceInverted != null)
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x06001020 RID: 4128 RVA: 0x0004E0DD File Offset: 0x0004C2DD
			public void SetEstimuloInstance(EstimuloTactil instance, EstimuloTactil instanceInverted)
			{
				this.estimulo = instance;
				if (instanceInverted != null)
				{
					throw new NotSupportedException();
				}
			}

			// Token: 0x06001021 RID: 4129 RVA: 0x0004E0EF File Offset: 0x0004C2EF
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06001022 RID: 4130 RVA: 0x0004E0FD File Offset: 0x0004C2FD
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				this.estado = estado;
			}

			// Token: 0x06001023 RID: 4131 RVA: 0x0004E10B File Offset: 0x0004C30B
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06001024 RID: 4132 RVA: 0x0004E123 File Offset: 0x0004C323
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
				if (index == 0)
				{
					this.estado = estado;
				}
			}

			// Token: 0x06001025 RID: 4133 RVA: 0x0004E134 File Offset: 0x0004C334
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}

			// Token: 0x06001026 RID: 4134 RVA: 0x0004E13C File Offset: 0x0004C33C
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				this.estado = masFuerte;
			}

			// Token: 0x04000A49 RID: 2633
			private ICalculadorDeEstimulo m_calculador;

			// Token: 0x04000A4A RID: 2634
			private ICalculadorDeEstimulo m_calculadorSec;

			// Token: 0x04000A4C RID: 2636
			public Emocion emocion;

			// Token: 0x04000A4D RID: 2637
			public double prioridad;

			// Token: 0x04000A4E RID: 2638
			public EstimuloTactil estimulo = new EstimuloTactil();

			// Token: 0x04000A4F RID: 2639
			public UmbralBasico.Estado estado;

			// Token: 0x04000A50 RID: 2640
			public ParteQuePuedeEstimular estimulante;
		}
	}
}

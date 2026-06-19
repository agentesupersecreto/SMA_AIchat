using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Assets.Base.Joints;
using Assets.PhysicsAndBonesScripts;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000DB RID: 219
	[RequireComponent(typeof(Rigidbody))]
	public abstract class BoneStretchedChain : ChainStretched, IPhysicsHole, IHole, IPenetrable, IComponentStartable
	{
		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x0001A9FE File Offset: 0x00018BFE
		public float maxProfundidadPhysicsLocal
		{
			get
			{
				if (!this.holeConfig.hasVirtualProfundidad)
				{
					return this.castProfundidad;
				}
				return this.holeConfig.fixedVirtualProfundidad;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0001AA1F File Offset: 0x00018C1F
		public bool maximaProfundidadPhysicsAlcanzada
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalInternals >= this.maxProfundidadPhysicsLocal;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x0001AA3C File Offset: 0x00018C3C
		public float profundidadPhysicsUnClampWeigth
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.penetratedDepthModUnClamp;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0001AA4E File Offset: 0x00018C4E
		public float defaultAnchuraPhysicsLocal
		{
			get
			{
				return this.m_EstadoDePuntos.iniciales.aperturaLocalInternals;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0001AA60 File Offset: 0x00018C60
		[Obsolete("controlado por internals", true)]
		public float maxProfundidadVirtualLocal
		{
			get
			{
				return this.holeConfig.maxProfundidadVirtual;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0001AA6D File Offset: 0x00018C6D
		[Obsolete("controlado por internals", true)]
		public bool maximaProfundidadVirtualAlcanzada
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalInternals >= this.maxProfundidadVirtualLocal;
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0001AA8A File Offset: 0x00018C8A
		[Obsolete("controlado por internals", true)]
		public float profundidadVirtualUnClampWeigth
		{
			get
			{
				return Mathf.Clamp(MathfExtension.InverseLerpUnclamped(0f, this.maxProfundidadVirtualLocal, this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalInternals), 0f, float.MaxValue);
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0001AABB File Offset: 0x00018CBB
		public float maxAnchuraVirtualLocal
		{
			get
			{
				return this.holeConfig.maxAnchuraVirtual;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x0001AAC8 File Offset: 0x00018CC8
		public bool maximaAnchuraVirtualAlcanzada
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.maxLocalInternals >= this.maxAnchuraVirtualLocal;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0001AAE5 File Offset: 0x00018CE5
		public float anchuraVirtualUnClampWeigth
		{
			get
			{
				return Mathf.Clamp(MathfExtension.InverseLerpUnclamped(0f, this.maxAnchuraVirtualLocal, this.m_EstadoDePuntos.actualLocal.maxLocalInternals), 0f, float.MaxValue);
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0001AB16 File Offset: 0x00018D16
		public float maxMotionPerSecVirtualLocal
		{
			get
			{
				return this.holeConfig.maxMotionPerSecVirtual;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x0001AB23 File Offset: 0x00018D23
		public bool maxMotionPerSecVirtualAlcanzada
		{
			get
			{
				return this.m_HolePointsDataCollector.stepData.localHoleDeepVelocity >= this.maxMotionPerSecVirtualLocal;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0001AB40 File Offset: 0x00018D40
		public float motionVirtualUnClampWeigth
		{
			get
			{
				return Mathf.Clamp(MathfExtension.InverseLerpUnclamped(0f, this.maxMotionPerSecVirtualLocal, this.m_HolePointsDataCollector.stepData.localHoleDeepVelocity), 0f, float.MaxValue);
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x0001AB71 File Offset: 0x00018D71
		public IReadOnlyDictionary<string, HoleVirtualHardPoint> hardPoints
		{
			get
			{
				return this.m_hardPoints;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0001AB79 File Offset: 0x00018D79
		public IReadOnlyList<HoleVirtualHardPoint> hardPointsList
		{
			get
			{
				return this.m_hardPointsList;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0001AB81 File Offset: 0x00018D81
		public bool escondePenetradores
		{
			get
			{
				return this.m_escondePenetradores;
			}
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0001AB8C File Offset: 0x00018D8C
		public void AddOrReplacePunto(HoleVirtualHardPoint data)
		{
			if (base.isStared)
			{
				throw new NotSupportedException();
			}
			if (this.m_hardPoints.ContainsKey(data.id))
			{
				this.m_hardPoints[data.id] = data;
				this.m_hardPointsList = this.m_hardPoints.Values.ToList<HoleVirtualHardPoint>();
				return;
			}
			this.m_hardPoints.Add(data.id, data);
			this.m_hardPointsList.Add(data);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0001AC04 File Offset: 0x00018E04
		public float HardPointCurrentWeigth(int index)
		{
			HoleVirtualHardPoint holeVirtualHardPoint = this.m_hardPointsList[index];
			if (holeVirtualHardPoint.resistenciaMod <= 0f)
			{
				return 0f;
			}
			return holeVirtualHardPoint.ToCenterWeightResistanciaInfluenced(this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalInternals);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0001AC48 File Offset: 0x00018E48
		public bool CercaDeHardPoints()
		{
			float profundidadPhysicsUnClampWeigth = this.profundidadPhysicsUnClampWeigth;
			if (profundidadPhysicsUnClampWeigth > 0.9f && profundidadPhysicsUnClampWeigth < 1.1f)
			{
				return true;
			}
			for (int i = 0; i < this.m_hardPointsList.Count; i++)
			{
				if (this.HardPointCurrentWeigth(i) > 0f)
				{
					return true;
				}
			}
			return this.CercaDeHardPointsExtra();
		}

		// Token: 0x0600086B RID: 2155
		protected abstract bool CercaDeHardPointsExtra();

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0001AC9A File Offset: 0x00018E9A
		public float anchuraHoleLocalActual
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.maxLocalHole;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0001ACAC File Offset: 0x00018EAC
		public float profundidadHoleLocalActual
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalHole;
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0001ACBE File Offset: 0x00018EBE
		public float anchuraInternalsLocalActual
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.maxLocalInternals;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0001ACD0 File Offset: 0x00018ED0
		public float profundidadInternalsLocalActual
		{
			get
			{
				return this.m_EstadoDePuntos.actualLocal.penetratedDepthLocalInternals;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x0001ACE2 File Offset: 0x00018EE2
		IReadOnlyList<IPhysicsHolePoint> IPhysicsHole.points
		{
			get
			{
				return this.m_points;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0001ACEA File Offset: 0x00018EEA
		public PenetrationJointCreator penetrationJointCreator
		{
			get
			{
				return this.m_PenetrationJointCreator;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0001ACF2 File Offset: 0x00018EF2
		public Penetraciones penetraciones
		{
			get
			{
				return this.m_penetraciones;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x0001ACFA File Offset: 0x00018EFA
		public virtual bool isPenetrated
		{
			get
			{
				return this.m_penetraciones.isPenetratedByAny;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0001AD07 File Offset: 0x00018F07
		public float castProfundidad
		{
			get
			{
				return this.holeConfig.castProfundidad;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000875 RID: 2165 RVA: 0x0001AD14 File Offset: 0x00018F14
		public float wallCollidersProfundidad
		{
			get
			{
				return this.holeConfig.wallCollidersProfundidad;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0001AD21 File Offset: 0x00018F21
		public Transform entrada
		{
			get
			{
				return this.centroDePuntos;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0001AD29 File Offset: 0x00018F29
		public Vector3 worldOutHole
		{
			get
			{
				return this.centroDePuntos.position - this.fondoPhysics.position;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0001AD48 File Offset: 0x00018F48
		public Vector3 worldOutHoleDirection
		{
			get
			{
				Vector3 vector;
				try
				{
					vector = this.centroDePuntos.position - this.fondoPhysics.position;
					vector = vector.normalized;
				}
				catch (Exception)
				{
					throw;
				}
				return vector;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0001AD90 File Offset: 0x00018F90
		public Vector3 worldUpHoleDirection
		{
			get
			{
				return this.centroDePuntos.TransformDirection(this.holeConfig.upLocalDirection).normalized;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0001ADBB File Offset: 0x00018FBB
		public BoneStretchedChain.EstadoDePuntos estadoDePuntos
		{
			get
			{
				return this.m_EstadoDePuntos;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x0001ADC3 File Offset: 0x00018FC3
		public ScaleChangedBroadcaster scaleChangedBroadcaster
		{
			get
			{
				return this.m_ScaleChangedBroadcaster;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0001ADCB File Offset: 0x00018FCB
		public Rigidbody centroDePuntosRigid
		{
			get
			{
				return this.m_centroDePuntosRigid;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x0001ADD3 File Offset: 0x00018FD3
		public Rigidbody chainRigidbody
		{
			get
			{
				return this.m_Rigidbody;
			}
		}

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600087E RID: 2174 RVA: 0x0001ADDC File Offset: 0x00018FDC
		// (remove) Token: 0x0600087F RID: 2175 RVA: 0x0001AE14 File Offset: 0x00019014
		public event Action<BoneStretchedChain> beforeStartPoints;

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0001AE49 File Offset: 0x00019049
		public IReadOnlyCollection<CircularChainPointStretcherJoint> points
		{
			get
			{
				return this.m_points;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x0001AE51 File Offset: 0x00019051
		public object checkeadorDeProximidad
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000882 RID: 2178
		protected abstract bool useScaleBroadcaster { get; }

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000883 RID: 2179
		public abstract Transform centroDePuntos { get; }

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000884 RID: 2180
		public abstract Transform fondoPhysics { get; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000885 RID: 2181
		public abstract IHoleInternals internals { get; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0001AE58 File Offset: 0x00019058
		public bool tieneInternals
		{
			get
			{
				return this.m_tieneInternals;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000887 RID: 2183
		protected abstract bool chainRigidbodyIsKinematic { get; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0001AE60 File Offset: 0x00019060
		public virtual bool usarLimitadorDePolaridad
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000889 RID: 2185
		public abstract CircularChainPointStretcherJoint _12 { get; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x0600088A RID: 2186
		public abstract CircularChainPointStretcherJoint _6 { get; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0001AE63 File Offset: 0x00019063
		[Obsolete("dividido en dos, visual(hole) y real(internals)", true)]
		public float worldScale
		{
			get
			{
				return this.m_worldHoleScale;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x0001AE6B File Offset: 0x0001906B
		public float worldHoleScale
		{
			get
			{
				return this.m_worldHoleScale;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x0001AE73 File Offset: 0x00019073
		public float worldScaleReal
		{
			get
			{
				return this.m_worldInternalScale;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x0001AE7B File Offset: 0x0001907B
		[Obsolete("era virtual, ahora se usa uno real: fondoPhysics")]
		public Transform fondo
		{
			get
			{
				return this.fondoPhysics;
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x0600088F RID: 2191
		public abstract ICharacter owner { get; }

		// Token: 0x06000890 RID: 2192 RVA: 0x0001AE84 File Offset: 0x00019084
		protected override void AwakeUnityEvent()
		{
			this.m_worldInternalScale = (this.m_worldHoleScale = 1f);
			this.holeConfig.upLocalDirection = this.holeConfig.upLocalDirection.normalized;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			base.AwakeUnityEvent();
			this.m_centroDePuntosRigid = this.centroDePuntos.GetComponentNotNull<Rigidbody>();
			this.m_centroDePuntosRigid.isKinematic = true;
			this.m_PenetrationJointCreator = this.GetComponentNotNull<PenetrationJointCreator>();
			this.m_HolePointsDataCollector = this.GetComponentNotNull<HolePointsDataCollector>();
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0001AF08 File Offset: 0x00019108
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.LoadPhysics();
			this.StartPoints();
			this.m_EstadoDePuntos = new BoneStretchedChain.EstadoDePuntos(this);
			if (this.useScaleBroadcaster)
			{
				this.LoadBroadcasters();
			}
			this.AddPenetration();
			this.m_worldHoleScale = this.entrada.lossyScale.Escala();
			this.m_tieneInternals = this.internals != null;
			this.m_worldInternalScale = (this.m_tieneInternals ? this.internals.root.lossyScale.Escala() : this.m_worldHoleScale);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0001AF97 File Offset: 0x00019197
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x0001AFA0 File Offset: 0x000191A0
		private void LoadPhysics()
		{
			this.m_Rigidbody.centerOfMass = Vector3.zero;
			this.m_Rigidbody.useGravity = false;
			this.m_Rigidbody.isKinematic = this.chainRigidbodyIsKinematic;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0001AFD0 File Offset: 0x000191D0
		protected void StartPoints()
		{
			try
			{
				this.m_pointsSet = new HashSet<CircularChainPointStretcherJoint>();
				this.LoadPointsToSet(this.m_pointsSet);
				CircularChainPointStretcherJoint[] array = this.m_pointsSet.ToArray<CircularChainPointStretcherJoint>();
				this.m_points = new ReadOnlyCollection<CircularChainPointStretcherJoint>(array);
				foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in array)
				{
					circularChainPointStretcherJoint.SetManualStart();
					circularChainPointStretcherJoint.parentChain = this;
					if (this.usarLimitadorDePolaridad && this.polaridadLimiterConfig.axisPolarizado != AxisPolarizado.None)
					{
						circularChainPointStretcherJoint.gameObject.AddComponent<LimitarPolaridadDeAxis>().configuracion = this.polaridadLimiterConfig;
					}
					if (this.usarLimitadorDePolaridad && this.polaridadLimiterConfig2.axisPolarizado != AxisPolarizado.None)
					{
						circularChainPointStretcherJoint.gameObject.AddComponent<LimitarPolaridadDeAxis>().configuracion = this.polaridadLimiterConfig2;
					}
				}
				this.OnBeforeStartPoints();
				CircularChainPointStretcherJoint[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].ManualStart();
				}
				foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint2 in this.m_pointsSet)
				{
					this.m_distancesDic.Add(circularChainPointStretcherJoint2, new BoneStretchedChain.PointDistances());
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0001B120 File Offset: 0x00019320
		protected virtual void LoadPointsToSet(HashSet<CircularChainPointStretcherJoint> target)
		{
			target.Add(this._12);
			target.Add(this._6);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0001B13C File Offset: 0x0001933C
		protected virtual void OnBeforeStartPoints()
		{
			Action<BoneStretchedChain> action = this.beforeStartPoints;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0001B150 File Offset: 0x00019350
		private void LoadBroadcasters()
		{
			this.m_ScaleChangedBroadcaster = this.GetComponentNotNull<ScaleChangedBroadcaster>();
			this.m_ScaleChangedBroadcaster.AddTarget(base.transform, false);
			this.m_ScaleChangedBroadcaster.updateEvent = GlobalUpdater.UpdateType.fixedUpdate1;
			this.m_ScaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChanged);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0001B1A4 File Offset: 0x000193A4
		protected virtual void ScaleChanged(object target)
		{
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.m_points)
			{
				circularChainPointStretcherJoint.RestaurarPosicion();
				circularChainPointStretcherJoint.EliminarFuerzas();
			}
			this.m_EstadoDePuntos.iniciales.ActualizarApeturaInicial();
			this.m_worldHoleScale = this.centroDePuntos.lossyScale.Escala();
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0001B21C File Offset: 0x0001941C
		private void AddPenetration()
		{
			CalculadorDePenetracion componentNotNull = this.GetComponentNotNull<CalculadorDePenetracion>();
			componentNotNull.rayTransformConfig = new CalculadorDePenetracion.RayTransformConfig
			{
				entrada = this.centroDePuntos,
				fondo = this.fondoPhysics
			};
			componentNotNull.rayConfig = new CalculadorDePenetracion.RayConfig
			{
				layerMaskHelper = Singleton<ConfiguracionGeneral>.instance.layers.penes.ToLayerMask(),
				layerMaskPenesInHole = Singleton<ConfiguracionGeneral>.instance.layers.layerDeteccionDePenes,
				ancho = this.m_EstadoDePuntos.iniciales.aperturaLocalInternals
			};
			this.m_penetraciones = new Penetraciones(this.penetracionesConfig, this, componentNotNull, () => this.m_EstadoDePuntos.globalActual.minValue);
			this.m_penetraciones.isDebug = (this.m_PenetrationJointCreator.debug = this.isDebugPenetraciones);
			this.m_PenetrationJointCreator.configuracion = this.penetrationJointConfig;
			this.m_PenetrationJointCreator.Init(this.m_penetraciones);
			this.m_penetraciones.tryingPenetration += this.M_penetraciones_tryingPenetration;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0001B328 File Offset: 0x00019528
		private void M_penetraciones_tryingPenetration(Penetraciones.TryPenetrationArgs args, PenisPart parte, PenisPartHit hit, Penetraciones penetracionesChecker)
		{
			if (!this.canBePenetrated)
			{
				args.DenyPenetration();
			}
		}

		// Token: 0x0600089B RID: 2203
		protected abstract void UpdateWallColliders();

		// Token: 0x0600089C RID: 2204 RVA: 0x0001B338 File Offset: 0x00019538
		public sealed override void OnUpdateEvent6()
		{
			this.UpdateWallColliders();
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001B340 File Offset: 0x00019540
		public sealed override void OnUpdateEvent1()
		{
			this.m_worldInternalScale = (this.m_tieneInternals ? this.internals.worldScale : this.m_worldHoleScale);
			this.m_penetraciones.UpdatePenetrationState();
			this.m_EstadoDePuntos.globalActual.Actializar();
			this.m_EstadoDePuntos.actualLocal.Actializar();
			this.m_EstadoDePuntos.centroDePuntos.Actializar();
			this.UpdateFondoTransform();
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0001B3AF File Offset: 0x000195AF
		public sealed override void OnUpdateEvent2()
		{
			if (this.isPenetrated)
			{
				this.FixDriversPorAperturaYProfundidad();
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0001B3C0 File Offset: 0x000195C0
		public void FixDriversPorAperturaYProfundidad()
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = null;
			float num = 0f;
			CircularChainPointStretcherJoint circularChainPointStretcherJoint2 = null;
			float num2 = 0f;
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint3 in this.m_pointsSet)
			{
				float num3;
				float num4;
				this.ObtenerAperturaYProfundidad(circularChainPointStretcherJoint3, out num3, out num4);
				num4 = Mathf.Abs(num4);
				if (circularChainPointStretcherJoint == null || num3 < num)
				{
					num = num3;
					circularChainPointStretcherJoint = circularChainPointStretcherJoint3;
				}
				if (circularChainPointStretcherJoint2 == null || num3 > num2)
				{
					num2 = num3;
					circularChainPointStretcherJoint2 = circularChainPointStretcherJoint3;
				}
				BoneStretchedChain.PointDistances pointDistances = this.m_distancesDic[circularChainPointStretcherJoint3];
				pointDistances.apertura = num3;
				pointDistances.profundidad = num4;
			}
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint4 in this.m_pointsSet)
			{
				BoneStretchedChain.PointDistances pointDistances2 = this.m_distancesDic[circularChainPointStretcherJoint4];
				if (circularChainPointStretcherJoint4.isStared)
				{
					circularChainPointStretcherJoint4.UpdateDrives(pointDistances2.apertura, pointDistances2.profundidad, num);
				}
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0001B4E4 File Offset: 0x000196E4
		public void GetWallColliders(List<Collider> result)
		{
			for (int i = 0; i < this.m_points.Count; i++)
			{
				CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.m_points[i];
				result.AddRange(circularChainPointStretcherJoint.ObtenerCollidersDePunto());
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001B520 File Offset: 0x00019720
		public void ExpulsarPenes()
		{
			if (!this.isPenetrated)
			{
				return;
			}
			this.penetraciones.flagedToCleanPenetrations = true;
		}

		// Token: 0x060008A2 RID: 2210
		protected abstract Vector3 GetEdgeOfColliderWorldPosition(CircularChainPointStretcherJoint chainPoint);

		// Token: 0x060008A3 RID: 2211
		protected abstract Vector3 GetColliderLocalOffset(CircularChainPointStretcherJoint chainPoint);

		// Token: 0x060008A4 RID: 2212 RVA: 0x0001B538 File Offset: 0x00019738
		public virtual void ObtenerAperturaEntreColliderDePuntosUnidadesGlobales(out float max, out float min)
		{
			Vector3 vector = this.GetEdgeOfColliderWorldPosition(this._12);
			Vector3 vector2 = this.GetEdgeOfColliderWorldPosition(this._6);
			Vector3 worldOutHoleDirection = this.worldOutHoleDirection;
			Vector3 position = this.centroDePuntos.position;
			vector = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector);
			vector2 = Math3d.ProjectPointOnPlane(worldOutHoleDirection, position, vector2);
			float num = Vector3.Distance(vector, vector2);
			max = num;
			min = num;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0001B590 File Offset: 0x00019790
		public virtual void ObtenerAperturaEntreColliderDePuntos(out float max, out float min)
		{
			Transform centroDePuntos = this.centroDePuntos;
			Vector3 vector = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._12));
			Vector3 vector2 = centroDePuntos.InverseTransformPoint(this.GetEdgeOfColliderWorldPosition(this._6));
			Vector3 vector3 = centroDePuntos.InverseTransformDirection(this.worldOutHoleDirection);
			Vector3 zero = Vector3.zero;
			vector = Math3d.ProjectPointOnPlane(vector3, zero, vector);
			vector2 = Math3d.ProjectPointOnPlane(vector3, zero, vector2);
			float num = Vector3.Distance(vector, vector2);
			max = num;
			min = num;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0001B5FC File Offset: 0x000197FC
		public virtual Vector3 ObtenerCentroDePuntosLocal()
		{
			if (this._12.transform.parent != this.centroDePuntos.parent || this._12.otherBody.transform.parent != this.centroDePuntos.parent)
			{
				throw new NotSupportedException("este algoritmo se desarrollo teniendo en cuenta q los puntos tendrian el mismo padre, para amentar el rendimiento");
			}
			Vector3 localPosition = this._12.otherBody.transform.localPosition;
			Vector3 localPosition2 = this._6.otherBody.transform.localPosition;
			return (localPosition + localPosition2) / 2f;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0001B698 File Offset: 0x00019898
		public float ObtenerProfundidad(BoneStretchedChain.PuntoSimple punto)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			return this.centroDePuntos.InverseTransformPoint(circularChainPointStretcherJoint.otherBody.transform.position).z;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0001B6D0 File Offset: 0x000198D0
		public Vector3 ObtenerCentroDePuntosGlobal()
		{
			Vector3 vector = this.ObtenerCentroDePuntosLocal();
			return this.centroDePuntos.parent.TransformPoint(vector);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0001B6F8 File Offset: 0x000198F8
		protected void ObtenerAperturaYProfundidad(CircularChainPointStretcherJoint point, out float apertura, out float profundidad)
		{
			Vector3 vector = this.centroDePuntos.InverseTransformPoint(point.otherBody.transform.position);
			profundidad = vector.z;
			vector.z = 0f;
			apertura = vector.magnitude;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0001B73E File Offset: 0x0001993E
		public CircularChainPointStretcherJoint ObtenerPunto(BoneStretchedChain.PuntoSimple point)
		{
			if (point == BoneStretchedChain.PuntoSimple._12)
			{
				return this._12;
			}
			if (point != BoneStretchedChain.PuntoSimple._6)
			{
				throw new ArgumentOutOfRangeException();
			}
			return this._6;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0001B75C File Offset: 0x0001995C
		public BoneStretchedChain.PuntoSimple ObtenerPuntoSimpleEnum(CircularChainPointStretcherJoint point)
		{
			if (this._12 == point)
			{
				return BoneStretchedChain.PuntoSimple._12;
			}
			if (this._6 == point)
			{
				return BoneStretchedChain.PuntoSimple._6;
			}
			throw new InvalidOperationException();
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0001B784 File Offset: 0x00019984
		public float ObtenerApertura(int punto)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			Vector3 vector = this.centroDePuntos.InverseTransformPoint(circularChainPointStretcherJoint.otherBody.transform.position);
			vector.z = 0f;
			return vector.magnitude;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0001B7C8 File Offset: 0x000199C8
		public float ObtenerProfundidad(int punto)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			return this.centroDePuntos.InverseTransformPoint(circularChainPointStretcherJoint.otherBody.transform.position).z;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0001B800 File Offset: 0x00019A00
		public void ObtenerAperturaYProfundidad(int punto, out float apertura, out float profundidad)
		{
			CircularChainPointStretcherJoint circularChainPointStretcherJoint = this.ObtenerPunto(punto);
			this.ObtenerAperturaYProfundidad(circularChainPointStretcherJoint, out apertura, out profundidad);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0001B81E File Offset: 0x00019A1E
		public virtual int ObtenerPunto(CircularChainPointStretcherJoint point)
		{
			if (this._12 == point)
			{
				return 0;
			}
			if (this._6 == point)
			{
				return 1;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0001B845 File Offset: 0x00019A45
		public virtual CircularChainPointStretcherJoint ObtenerPunto(int point)
		{
			if (point == 0)
			{
				return this._12;
			}
			if (point != 1)
			{
				throw new ArgumentOutOfRangeException();
			}
			return this._6;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001B864 File Offset: 0x00019A64
		public bool IsPenetratedBy(Collider other)
		{
			PenetradorHits currentHits = this.m_penetraciones.currentHits;
			return currentHits.ContainsCollider(other) || currentHits.primero.penisPart.ChainContiene(other);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0001B899 File Offset: 0x00019A99
		public IPene PenetradoPor()
		{
			PenetradorHits currentHits = this.m_penetraciones.currentHits;
			if (currentHits == null)
			{
				return null;
			}
			PenisPartHit primero = currentHits.primero;
			if (primero == null)
			{
				return null;
			}
			return primero.penis;
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001B8BC File Offset: 0x00019ABC
		public IPene Cercano()
		{
			return this.m_penetraciones.PeneCercano();
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0001B8CC File Offset: 0x00019ACC
		protected void DefaultGenerarFondoTransform(ref Transform target)
		{
			if (target == null)
			{
				target = new GameObject(base.name + "_Fondo").transform;
			}
			Transform centroDePuntos = this.centroDePuntos;
			target.gameObject.layer = base.gameObject.layer;
			target.parent = centroDePuntos.parent;
			target.position = centroDePuntos.TransformPoint(this.holeConfig.fondoLocalPosition);
			target.rotation = Quaternion.LookRotation(centroDePuntos.position - target.position, centroDePuntos.rotation * this.holeConfig.upLocalDirection);
			target.localScale = Vector3.one;
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0001B984 File Offset: 0x00019B84
		protected void UpdateFondoTransform()
		{
			Matrix4x4 matrix4x;
			if (this.m_tieneInternals)
			{
				matrix4x = Matrix4x4.TRS(this.entrada.position, this.entrada.rotation, Vector3.one * this.internals.worldScale);
			}
			else
			{
				matrix4x = this.entrada.localToWorldMatrix;
			}
			this.fondoPhysics.position = matrix4x.MultiplyPoint3x4(this.holeConfig.fondoLocalPosition);
			this.fondoPhysics.rotation = Quaternion.LookRotation(this.entrada.position - this.fondoPhysics.position, this.entrada.rotation * this.holeConfig.upLocalDirection);
			this.fondoPhysics.localScale = Vector3.one;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0001BAD6 File Offset: 0x00019CD6
		GameObject IHole.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x0400049B RID: 1179
		private Dictionary<string, HoleVirtualHardPoint> m_hardPoints = new Dictionary<string, HoleVirtualHardPoint>();

		// Token: 0x0400049C RID: 1180
		[SerializeField]
		private List<HoleVirtualHardPoint> m_hardPointsList = new List<HoleVirtualHardPoint>();

		// Token: 0x0400049E RID: 1182
		public bool isDebugPenetraciones;

		// Token: 0x0400049F RID: 1183
		public bool canBePenetrated = true;

		// Token: 0x040004A0 RID: 1184
		public BoneStretchedChain.HoleConfig holeConfig = new BoneStretchedChain.HoleConfig();

		// Token: 0x040004A1 RID: 1185
		public PenetrationJointCreator.Configuracion penetrationJointConfig = new PenetrationJointCreator.Configuracion();

		// Token: 0x040004A2 RID: 1186
		public Penetraciones.Config penetracionesConfig = new Penetraciones.Config();

		// Token: 0x040004A3 RID: 1187
		public LimitarPolaridadDeAxis.Configuracion polaridadLimiterConfig = new LimitarPolaridadDeAxis.Configuracion(AxisPolarizado.yPositive);

		// Token: 0x040004A4 RID: 1188
		public LimitarPolaridadDeAxis.Configuracion polaridadLimiterConfig2 = new LimitarPolaridadDeAxis.Configuracion(AxisPolarizado.None);

		// Token: 0x040004A5 RID: 1189
		[SerializeField]
		private bool m_escondePenetradores;

		// Token: 0x040004A6 RID: 1190
		[SerializeField]
		[ReadOnlyUI]
		protected bool m_tieneInternals;

		// Token: 0x040004A7 RID: 1191
		[SerializeField]
		[ReadOnlyUI]
		private float m_worldHoleScale = 1f;

		// Token: 0x040004A8 RID: 1192
		[SerializeField]
		[ReadOnlyUI]
		private float m_worldInternalScale = 1f;

		// Token: 0x040004A9 RID: 1193
		[Obsolete("usar fondo real physcis", true)]
		private Transform m_fondoVirtual;

		// Token: 0x040004AA RID: 1194
		[SerializeField]
		private BoneStretchedChain.EstadoDePuntos m_EstadoDePuntos;

		// Token: 0x040004AB RID: 1195
		private Penetraciones m_penetraciones;

		// Token: 0x040004AC RID: 1196
		private PenetrationJointCreator m_PenetrationJointCreator;

		// Token: 0x040004AD RID: 1197
		private ScaleChangedBroadcaster m_ScaleChangedBroadcaster;

		// Token: 0x040004AE RID: 1198
		private Rigidbody m_centroDePuntosRigid;

		// Token: 0x040004AF RID: 1199
		private Rigidbody m_Rigidbody;

		// Token: 0x040004B0 RID: 1200
		protected ReadOnlyCollection<CircularChainPointStretcherJoint> m_points;

		// Token: 0x040004B1 RID: 1201
		protected HashSet<CircularChainPointStretcherJoint> m_pointsSet;

		// Token: 0x040004B2 RID: 1202
		protected Dictionary<CircularChainPointStretcherJoint, BoneStretchedChain.PointDistances> m_distancesDic = new Dictionary<CircularChainPointStretcherJoint, BoneStretchedChain.PointDistances>();

		// Token: 0x040004B3 RID: 1203
		private HolePointsDataCollector m_HolePointsDataCollector;

		// Token: 0x020001B3 RID: 435
		protected class PointDistances
		{
			// Token: 0x040009CB RID: 2507
			public float apertura;

			// Token: 0x040009CC RID: 2508
			public float profundidad;
		}

		// Token: 0x020001B4 RID: 436
		public enum PuntoSimple
		{
			// Token: 0x040009CE RID: 2510
			_12,
			// Token: 0x040009CF RID: 2511
			_6
		}

		// Token: 0x020001B5 RID: 437
		[Serializable]
		public class HoleConfig
		{
			// Token: 0x17000516 RID: 1302
			// (get) Token: 0x06000F33 RID: 3891 RVA: 0x0003403E File Offset: 0x0003223E
			public float castProfundidad
			{
				get
				{
					return this.fondoLocalPosition.magnitude;
				}
			}

			// Token: 0x040009D0 RID: 2512
			public bool hasVirtualProfundidad;

			// Token: 0x040009D1 RID: 2513
			public float fixedVirtualProfundidad = -1f;

			// Token: 0x040009D2 RID: 2514
			public Vector3 fondoLocalPosition = -Vector3.forward * 0.1f;

			// Token: 0x040009D3 RID: 2515
			public float wallCollidersProfundidad = 0.03f;

			// Token: 0x040009D4 RID: 2516
			[Obsolete("", true)]
			public float profundidad = 0.1f;

			// Token: 0x040009D5 RID: 2517
			[Obsolete("", true)]
			public Transform entrada;

			// Token: 0x040009D6 RID: 2518
			[Tooltip("direccion hacia afuera local de entrada")]
			public Vector3 outLocalDirection = Vector3.forward;

			// Token: 0x040009D7 RID: 2519
			public Vector3 upLocalDirection = Vector3.up;

			// Token: 0x040009D8 RID: 2520
			[Obsolete("controlado por internals", true)]
			public float maxProfundidadVirtual = 0.07f;

			// Token: 0x040009D9 RID: 2521
			public float maxAnchuraVirtual = 0.025f;

			// Token: 0x040009DA RID: 2522
			public float maxMotionPerSecVirtual = 0.001f;
		}

		// Token: 0x020001B6 RID: 438
		[Serializable]
		public class EstadoDePuntos
		{
			// Token: 0x06000F35 RID: 3893 RVA: 0x000340D4 File Offset: 0x000322D4
			public EstadoDePuntos(BoneStretchedChain owner)
			{
				if (owner == null)
				{
					throw new ArgumentNullException("owner", "owner null reference.");
				}
				this.m_owner = owner;
				this.m_Iniciales = new BoneStretchedChain.EstadoDePuntos.Iniciales(owner);
				this.m_GlobalActual = new BoneStretchedChain.EstadoDePuntos.RangeGlobal(owner, new BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal(owner.ObtenerAperturaEntreColliderDePuntosUnidadesGlobales));
				this.m_ActualLocal = new BoneStretchedChain.EstadoDePuntos.ActualLocal(owner, new BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal(owner.ObtenerAperturaEntreColliderDePuntos), this.m_Iniciales);
				this.m_centroDePuntos = new BoneStretchedChain.EstadoDePuntos.CentroDePuntos(owner, this.m_Iniciales);
			}

			// Token: 0x17000517 RID: 1303
			// (get) Token: 0x06000F36 RID: 3894 RVA: 0x0003415D File Offset: 0x0003235D
			public BoneStretchedChain.EstadoDePuntos.Iniciales iniciales
			{
				get
				{
					return this.m_Iniciales;
				}
			}

			// Token: 0x17000518 RID: 1304
			// (get) Token: 0x06000F37 RID: 3895 RVA: 0x00034165 File Offset: 0x00032365
			public BoneStretchedChain.EstadoDePuntos.RangeGlobal globalActual
			{
				get
				{
					return this.m_GlobalActual;
				}
			}

			// Token: 0x17000519 RID: 1305
			// (get) Token: 0x06000F38 RID: 3896 RVA: 0x0003416D File Offset: 0x0003236D
			public BoneStretchedChain.EstadoDePuntos.ActualLocal actualLocal
			{
				get
				{
					return this.m_ActualLocal;
				}
			}

			// Token: 0x1700051A RID: 1306
			// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00034175 File Offset: 0x00032375
			public BoneStretchedChain.EstadoDePuntos.CentroDePuntos centroDePuntos
			{
				get
				{
					return this.m_centroDePuntos;
				}
			}

			// Token: 0x1700051B RID: 1307
			// (get) Token: 0x06000F3A RID: 3898 RVA: 0x0003417D File Offset: 0x0003237D
			public BoneStretchedChain owner
			{
				get
				{
					return this.m_owner;
				}
			}

			// Token: 0x06000F3B RID: 3899 RVA: 0x00034188 File Offset: 0x00032388
			public void CopiarA(BoneStretchedChain.EstadoDePuntos other)
			{
				if (other == null)
				{
					throw new ArgumentNullException("other", "other null reference.");
				}
				this.m_Iniciales.CopiarA(other.m_Iniciales);
				this.m_GlobalActual.CopiarA(other.m_GlobalActual);
				this.m_ActualLocal.CopiarA(other.m_ActualLocal);
				this.m_centroDePuntos.CopiarA(other.m_centroDePuntos);
			}

			// Token: 0x040009DB RID: 2523
			private BoneStretchedChain m_owner;

			// Token: 0x040009DC RID: 2524
			[SerializeField]
			private BoneStretchedChain.EstadoDePuntos.Iniciales m_Iniciales;

			// Token: 0x040009DD RID: 2525
			[SerializeField]
			private BoneStretchedChain.EstadoDePuntos.RangeGlobal m_GlobalActual;

			// Token: 0x040009DE RID: 2526
			[SerializeField]
			private BoneStretchedChain.EstadoDePuntos.ActualLocal m_ActualLocal;

			// Token: 0x040009DF RID: 2527
			[SerializeField]
			private BoneStretchedChain.EstadoDePuntos.CentroDePuntos m_centroDePuntos;

			// Token: 0x02000227 RID: 551
			[Serializable]
			public class CentroDePuntos : BoneStretchedChain.EstadoDePuntos.Base
			{
				// Token: 0x0600102E RID: 4142 RVA: 0x00036198 File Offset: 0x00034398
				public CentroDePuntos(BoneStretchedChain owner, BoneStretchedChain.EstadoDePuntos.Iniciales inis)
					: base(owner)
				{
					if (inis == null)
					{
						throw new ArgumentNullException("inis", "inis null reference.");
					}
					this.m_inis = inis;
				}

				// Token: 0x17000545 RID: 1349
				// (get) Token: 0x0600102F RID: 4143 RVA: 0x000361BB File Offset: 0x000343BB
				public Vector3 centroLocal
				{
					get
					{
						return this.m_centroLocal;
					}
				}

				// Token: 0x17000546 RID: 1350
				// (get) Token: 0x06001030 RID: 4144 RVA: 0x000361C3 File Offset: 0x000343C3
				public float movimientoLocal
				{
					get
					{
						return this.m_movimientoLocal;
					}
				}

				// Token: 0x06001031 RID: 4145 RVA: 0x000361CC File Offset: 0x000343CC
				public virtual void Actializar()
				{
					this.m_centroLocal = this.m_owner.ObtenerCentroDePuntosLocal();
					this.m_movimientoLocal = Vector3.Distance(this.m_inis.centroDePuntos, this.m_centroLocal);
					this.m_movimientoLocal = base.ConvertirDeLocalHoleToLocalInternals(this.m_movimientoLocal);
				}

				// Token: 0x06001032 RID: 4146 RVA: 0x00036218 File Offset: 0x00034418
				protected override void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					((BoneStretchedChain.EstadoDePuntos.CentroDePuntos)other).m_centroLocal = this.m_centroLocal;
				}

				// Token: 0x04000B35 RID: 2869
				private BoneStretchedChain.EstadoDePuntos.Iniciales m_inis;

				// Token: 0x04000B36 RID: 2870
				[SerializeField]
				[ReadOnlyUI]
				protected Vector3 m_centroLocal;

				// Token: 0x04000B37 RID: 2871
				[SerializeField]
				[ReadOnlyUI]
				protected float m_movimientoLocal;
			}

			// Token: 0x02000228 RID: 552
			[Serializable]
			public class Iniciales : BoneStretchedChain.EstadoDePuntos.Basicos
			{
				// Token: 0x06001033 RID: 4147 RVA: 0x0003622B File Offset: 0x0003442B
				public Iniciales(BoneStretchedChain owner)
					: base(owner)
				{
				}

				// Token: 0x17000547 RID: 1351
				// (get) Token: 0x06001034 RID: 4148 RVA: 0x00036234 File Offset: 0x00034434
				public Vector3 centroDePuntos
				{
					get
					{
						return this.m_centroDePuntos;
					}
				}

				// Token: 0x06001035 RID: 4149 RVA: 0x0003623C File Offset: 0x0003443C
				public void ActualizarApeturaInicial()
				{
					try
					{
						CircularChainPointStretcherJoint _ = this.m_owner._6;
						CircularChainPointStretcherJoint _2 = this.m_owner._12;
						ConfigurableJoint joint = _.joint;
						ConfigurableJoint joint2 = _2.joint;
						Transform transform = joint2.transform;
						Transform transform2 = joint.transform;
						Vector3 colliderLocalOffset = this.m_owner.GetColliderLocalOffset(this.m_owner._12);
						Vector3 colliderLocalOffset2 = this.m_owner.GetColliderLocalOffset(this.m_owner._6);
						if (transform.parent != transform2.parent)
						{
							throw new InvalidOperationException();
						}
						float num = Vector3.Distance(transform.localPosition + colliderLocalOffset, transform2.localPosition + colliderLocalOffset2);
						float num2 = _.jointDistancesAdmin.ScaleToOtherBody();
						float num3;
						if (num2 == 0f)
						{
							num3 = 0f;
						}
						else
						{
							num3 = joint.targetPosition.z / num2;
						}
						float num4 = _2.jointDistancesAdmin.ScaleToOtherBody();
						float num5;
						if (num4 == 0f)
						{
							num5 = 0f;
						}
						else
						{
							num5 = joint2.targetPosition.z / num4;
						}
						this.m_aperturaLocalHole = num - (num3 + num5);
						this.m_aperturaLocalHole = ((this.m_aperturaLocalHole < 0f) ? 0f : this.m_aperturaLocalHole);
						this.m_aperturaLocalInternals = base.ConvertirDeLocalHoleToLocalInternals(this.m_aperturaLocalHole);
						this.m_centroDePuntos = this.m_owner.ObtenerCentroDePuntosLocal();
					}
					catch (Exception)
					{
						throw;
					}
				}

				// Token: 0x06001036 RID: 4150 RVA: 0x000363B4 File Offset: 0x000345B4
				protected override void OnInit()
				{
					base.OnInit();
					this.ActualizarApeturaInicial();
				}

				// Token: 0x06001037 RID: 4151 RVA: 0x000363C2 File Offset: 0x000345C2
				protected override void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					base.OnCopiarA(other);
					((BoneStretchedChain.EstadoDePuntos.Iniciales)other).m_centroDePuntos = this.m_centroDePuntos;
				}

				// Token: 0x04000B38 RID: 2872
				[SerializeField]
				[ReadOnlyUI]
				protected Vector3 m_centroDePuntos;
			}

			// Token: 0x02000229 RID: 553
			[Serializable]
			public sealed class ActualLocal : BoneStretchedChain.EstadoDePuntos.RangeLocal
			{
				// Token: 0x06001038 RID: 4152 RVA: 0x000363DC File Offset: 0x000345DC
				public ActualLocal(BoneStretchedChain owner, BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal getter, BoneStretchedChain.EstadoDePuntos.Iniciales iniciales)
					: base(owner, getter)
				{
					if (iniciales == null)
					{
						throw new ArgumentNullException("iniciales", "iniciales null reference.");
					}
					this.m_iniciales = iniciales;
				}

				// Token: 0x17000548 RID: 1352
				// (get) Token: 0x06001039 RID: 4153 RVA: 0x00036400 File Offset: 0x00034600
				public float maxLimpiaLocalHole
				{
					get
					{
						return this.m_maxLimpiaLocalHole;
					}
				}

				// Token: 0x17000549 RID: 1353
				// (get) Token: 0x0600103A RID: 4154 RVA: 0x00036408 File Offset: 0x00034608
				public float maxLimpiaLocalInternals
				{
					get
					{
						return this.m_maxLimpiaLocalInternals;
					}
				}

				// Token: 0x1700054A RID: 1354
				// (get) Token: 0x0600103B RID: 4155 RVA: 0x00036410 File Offset: 0x00034610
				public float penetratedDepthLocalHole
				{
					get
					{
						return this.m_fromHolePenetratedDepth;
					}
				}

				// Token: 0x1700054B RID: 1355
				// (get) Token: 0x0600103C RID: 4156 RVA: 0x00036418 File Offset: 0x00034618
				public float penetratedDepthLocalInternals
				{
					get
					{
						return this.m_fromInternalsPenetratedDepth;
					}
				}

				// Token: 0x1700054C RID: 1356
				// (get) Token: 0x0600103D RID: 4157 RVA: 0x00036420 File Offset: 0x00034620
				public float penisPenetratedDepthLocalHole
				{
					get
					{
						return this.m_penisPenetratedDepthLocalHole;
					}
				}

				// Token: 0x1700054D RID: 1357
				// (get) Token: 0x0600103E RID: 4158 RVA: 0x00036428 File Offset: 0x00034628
				public float penisPenetratedDepthLocalInternals
				{
					get
					{
						return this.m_penisPenetratedDepthLocalInternals;
					}
				}

				// Token: 0x1700054E RID: 1358
				// (get) Token: 0x0600103F RID: 4159 RVA: 0x00036430 File Offset: 0x00034630
				public float penetratedDepthModUnClamp
				{
					get
					{
						if (this.m_fromInternalsPenetratedDepth <= 0f)
						{
							return 0f;
						}
						float maxProfundidadPhysicsLocal = this.m_owner.maxProfundidadPhysicsLocal;
						return MathfExtension.InverseLerpUnclamped(0f, maxProfundidadPhysicsLocal, this.m_fromInternalsPenetratedDepth);
					}
				}

				// Token: 0x06001040 RID: 4160 RVA: 0x00036470 File Offset: 0x00034670
				public sealed override void Actializar()
				{
					base.Actializar();
					this.m_maxLimpiaLocalInternals = base.maxLocalInternals - this.m_iniciales.aperturaLocalInternals;
					if (this.m_maxLimpiaLocalInternals < 0f)
					{
						this.m_maxLimpiaLocalInternals = 0f;
					}
					this.m_maxLimpiaLocalHole = base.maxLocalHole - this.m_iniciales.aperturaLocalHole;
					if (this.m_maxLimpiaLocalHole < 0f)
					{
						this.m_maxLimpiaLocalHole = 0f;
					}
					this.UpdateDeep();
				}

				// Token: 0x06001041 RID: 4161 RVA: 0x000364EC File Offset: 0x000346EC
				private void UpdateDeep()
				{
					BoneStretchedChain owner = this.m_owner;
					Penetraciones penetraciones = owner.penetraciones;
					if (!penetraciones.isPenetratedByAny)
					{
						this.m_penisPenetratedDepthLocalHole = 0f;
						this.m_penisPenetratedDepthLocalInternals = 0f;
						this.m_fromHolePenetratedDepth = 0f;
						this.m_fromInternalsPenetratedDepth = 0f;
						return;
					}
					Penetrador penis = penetraciones.currentHits.primero.penis;
					Vector3 tipPhysicsWorldPosition = penis.penisLinearChain.tipPhysicsWorldPosition;
					this.m_fromHolePenetratedDepth = owner.entrada.InverseTransformPoint(tipPhysicsWorldPosition).magnitude;
					this.m_fromInternalsPenetratedDepth = base.ConvertirDeLocalHoleToLocalInternals(this.m_fromHolePenetratedDepth);
					this.m_penisPenetratedDepthLocalHole = penis.penetratingWorldLength / owner.worldHoleScale;
					this.m_penisPenetratedDepthLocalInternals = penis.penetratingWorldLength / owner.worldScaleReal;
				}

				// Token: 0x06001042 RID: 4162 RVA: 0x000365AC File Offset: 0x000347AC
				protected override void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					base.OnCopiarA(other);
					BoneStretchedChain.EstadoDePuntos.ActualLocal actualLocal = (BoneStretchedChain.EstadoDePuntos.ActualLocal)other;
					actualLocal.m_maxLimpiaLocalHole = this.m_maxLimpiaLocalHole;
					actualLocal.m_maxLimpiaLocalInternals = this.m_maxLimpiaLocalInternals;
					actualLocal.m_fromHolePenetratedDepth = this.m_fromHolePenetratedDepth;
					actualLocal.m_fromInternalsPenetratedDepth = this.m_fromInternalsPenetratedDepth;
					actualLocal.m_penisPenetratedDepthLocalHole = this.m_penisPenetratedDepthLocalHole;
					actualLocal.m_penisPenetratedDepthLocalInternals = this.m_penisPenetratedDepthLocalInternals;
				}

				// Token: 0x04000B39 RID: 2873
				private BoneStretchedChain.EstadoDePuntos.Iniciales m_iniciales;

				// Token: 0x04000B3A RID: 2874
				[SerializeField]
				[ReadOnlyUI]
				private float m_maxLimpiaLocalHole;

				// Token: 0x04000B3B RID: 2875
				[SerializeField]
				[ReadOnlyUI]
				private float m_maxLimpiaLocalInternals;

				// Token: 0x04000B3C RID: 2876
				[SerializeField]
				[ReadOnlyUI]
				private float m_fromHolePenetratedDepth;

				// Token: 0x04000B3D RID: 2877
				[SerializeField]
				[ReadOnlyUI]
				private float m_fromInternalsPenetratedDepth;

				// Token: 0x04000B3E RID: 2878
				[SerializeField]
				[ReadOnlyUI]
				private float m_penisPenetratedDepthLocalHole;

				// Token: 0x04000B3F RID: 2879
				[SerializeField]
				[ReadOnlyUI]
				private float m_penisPenetratedDepthLocalInternals;
			}

			// Token: 0x0200022A RID: 554
			[Serializable]
			public class RangeLocal : BoneStretchedChain.EstadoDePuntos.RangeBase
			{
				// Token: 0x06001043 RID: 4163 RVA: 0x0003660D File Offset: 0x0003480D
				public RangeLocal(BoneStretchedChain owner, BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal getter)
					: base(owner, getter)
				{
				}

				// Token: 0x1700054F RID: 1359
				// (get) Token: 0x06001044 RID: 4164 RVA: 0x00036617 File Offset: 0x00034817
				public float minLocalHole
				{
					get
					{
						return base.minValue;
					}
				}

				// Token: 0x17000550 RID: 1360
				// (get) Token: 0x06001045 RID: 4165 RVA: 0x0003661F File Offset: 0x0003481F
				public float maxLocalHole
				{
					get
					{
						return base.maxValue;
					}
				}

				// Token: 0x17000551 RID: 1361
				// (get) Token: 0x06001046 RID: 4166 RVA: 0x00036627 File Offset: 0x00034827
				public float minLocalInternals
				{
					get
					{
						return base.ConvertirDeLocalHoleToLocalInternals(base.minValue);
					}
				}

				// Token: 0x17000552 RID: 1362
				// (get) Token: 0x06001047 RID: 4167 RVA: 0x00036635 File Offset: 0x00034835
				public float maxLocalInternals
				{
					get
					{
						return base.ConvertirDeLocalHoleToLocalInternals(base.maxValue);
					}
				}
			}

			// Token: 0x0200022B RID: 555
			[Serializable]
			public class RangeGlobal : BoneStretchedChain.EstadoDePuntos.RangeBase
			{
				// Token: 0x06001048 RID: 4168 RVA: 0x00036643 File Offset: 0x00034843
				public RangeGlobal(BoneStretchedChain owner, BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal getter)
					: base(owner, getter)
				{
				}
			}

			// Token: 0x0200022C RID: 556
			[Serializable]
			public abstract class RangeBase : BoneStretchedChain.EstadoDePuntos.Base
			{
				// Token: 0x06001049 RID: 4169 RVA: 0x0003664D File Offset: 0x0003484D
				public RangeBase(BoneStretchedChain owner, BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal getter)
					: base(owner)
				{
					if (getter == null)
					{
						throw new ArgumentNullException("getter", "getter null reference.");
					}
					this.m_getter = getter;
				}

				// Token: 0x17000553 RID: 1363
				// (get) Token: 0x0600104A RID: 4170 RVA: 0x00036670 File Offset: 0x00034870
				public float minValue
				{
					get
					{
						return this.m_min;
					}
				}

				// Token: 0x17000554 RID: 1364
				// (get) Token: 0x0600104B RID: 4171 RVA: 0x00036678 File Offset: 0x00034878
				public float maxValue
				{
					get
					{
						return this.m_max;
					}
				}

				// Token: 0x0600104C RID: 4172 RVA: 0x00036680 File Offset: 0x00034880
				public virtual void Actializar()
				{
					this.m_getter(out this.m_max, out this.m_min);
				}

				// Token: 0x0600104D RID: 4173 RVA: 0x00036699 File Offset: 0x00034899
				protected override void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					BoneStretchedChain.EstadoDePuntos.RangeBase rangeBase = (BoneStretchedChain.EstadoDePuntos.RangeBase)other;
					rangeBase.m_min = this.m_min;
					rangeBase.m_max = this.m_max;
				}

				// Token: 0x04000B40 RID: 2880
				protected BoneStretchedChain.EstadoDePuntos.RangeBase.GetterDeRangoLocalOrGlobal m_getter;

				// Token: 0x04000B41 RID: 2881
				[SerializeField]
				[ReadOnlyUI]
				private float m_min;

				// Token: 0x04000B42 RID: 2882
				[SerializeField]
				[ReadOnlyUI]
				private float m_max;

				// Token: 0x02000262 RID: 610
				// (Invoke) Token: 0x06001097 RID: 4247
				public delegate void GetterDeRangoLocalOrGlobal(out float max, out float min);
			}

			// Token: 0x0200022D RID: 557
			[Serializable]
			public class Basicos : BoneStretchedChain.EstadoDePuntos.Base
			{
				// Token: 0x0600104E RID: 4174 RVA: 0x000366B8 File Offset: 0x000348B8
				public Basicos(BoneStretchedChain owner)
					: base(owner)
				{
				}

				// Token: 0x17000555 RID: 1365
				// (get) Token: 0x0600104F RID: 4175 RVA: 0x000366C1 File Offset: 0x000348C1
				public float aperturaLocalInternals
				{
					get
					{
						return this.m_aperturaLocalInternals;
					}
				}

				// Token: 0x17000556 RID: 1366
				// (get) Token: 0x06001050 RID: 4176 RVA: 0x000366C9 File Offset: 0x000348C9
				public float aperturaLocalHole
				{
					get
					{
						return this.m_aperturaLocalHole;
					}
				}

				// Token: 0x06001051 RID: 4177 RVA: 0x000366D1 File Offset: 0x000348D1
				protected override void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					BoneStretchedChain.EstadoDePuntos.Basicos basicos = (BoneStretchedChain.EstadoDePuntos.Basicos)other;
					basicos.m_aperturaLocalInternals = this.m_aperturaLocalInternals;
					basicos.m_aperturaLocalHole = this.m_aperturaLocalHole;
				}

				// Token: 0x04000B43 RID: 2883
				[SerializeField]
				[ReadOnlyUI]
				protected float m_aperturaLocalInternals;

				// Token: 0x04000B44 RID: 2884
				[SerializeField]
				[ReadOnlyUI]
				protected float m_aperturaLocalHole;
			}

			// Token: 0x0200022E RID: 558
			[Serializable]
			public abstract class Base
			{
				// Token: 0x06001052 RID: 4178 RVA: 0x000366F0 File Offset: 0x000348F0
				public Base(BoneStretchedChain owner)
				{
					if (owner == null)
					{
						throw new ArgumentNullException("owner", "owner null reference.");
					}
					this.m_owner = owner;
					this.OnInit();
				}

				// Token: 0x06001053 RID: 4179 RVA: 0x0003671E File Offset: 0x0003491E
				protected virtual void OnInit()
				{
				}

				// Token: 0x06001054 RID: 4180 RVA: 0x00036720 File Offset: 0x00034920
				public void CopiarA(BoneStretchedChain.EstadoDePuntos.Base other)
				{
					this.OnCopiarA(other);
				}

				// Token: 0x06001055 RID: 4181
				protected abstract void OnCopiarA(BoneStretchedChain.EstadoDePuntos.Base other);

				// Token: 0x06001056 RID: 4182 RVA: 0x00036729 File Offset: 0x00034929
				protected float ConvertirDeLocalHoleToLocalInternals(float value)
				{
					value *= this.m_owner.m_worldHoleScale;
					value /= this.m_owner.m_worldInternalScale;
					return value;
				}

				// Token: 0x04000B45 RID: 2885
				protected BoneStretchedChain m_owner;
			}
		}
	}
}

using System;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Ai;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.Holes.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200021D RID: 541
	public class FemaleCharPenetrationInformer : FemaleInformer, ICharPenetrationInformer, ICharPenetrationData<IPenetrationInformer>, IDataSet<IPenetrationInformer>, ICharPenetrationInformerV2, ICharPenetrationData<IPenetrationInformerV2>, IDataSet<IPenetrationInformerV2>
	{
		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x0003D287 File Offset: 0x0003B487
		public IPenetrationInformer anus
		{
			get
			{
				return this.m_anusInformer;
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x0003D28F File Offset: 0x0003B48F
		public IPenetrationInformer facial
		{
			get
			{
				return this.m_bocaInformer;
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000DB0 RID: 3504 RVA: 0x0003D297 File Offset: 0x0003B497
		public IPenetrationInformer vag
		{
			get
			{
				return this.m_vagInformer;
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x0003D287 File Offset: 0x0003B487
		IPenetrationInformerV2 ICharPenetrationData<IPenetrationInformerV2>.anus
		{
			get
			{
				return this.m_anusInformer;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x0003D297 File Offset: 0x0003B497
		IPenetrationInformerV2 ICharPenetrationData<IPenetrationInformerV2>.vag
		{
			get
			{
				return this.m_vagInformer;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x0003D28F File Offset: 0x0003B48F
		IPenetrationInformerV2 ICharPenetrationData<IPenetrationInformerV2>.facial
		{
			get
			{
				return this.m_bocaInformer;
			}
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x0003D29F File Offset: 0x0003B49F
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x0003D2A8 File Offset: 0x0003B4A8
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			VagController componentInChildren = this.m_FemaleChar.GetComponentInChildren<VagController>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("vagController", "vagController null reference.");
			}
			this.m_vagInformer.Init(this.m_PrioridadesDeObjetoEstimulado, componentInChildren.vagHoleController, FemalePenetracionTipo.vag);
			AnusController componentInChildren2 = this.m_FemaleChar.GetComponentInChildren<AnusController>();
			if (componentInChildren2 == null)
			{
				throw new ArgumentNullException("aController", "aController null reference.");
			}
			this.m_anusInformer.Init(this.m_PrioridadesDeObjetoEstimulado, componentInChildren2.anusHoleController, FemalePenetracionTipo.anus);
			BocaSexController componentInChildren3 = this.m_FemaleChar.GetComponentInChildren<BocaSexController>();
			if (componentInChildren3 == null)
			{
				throw new ArgumentNullException("bocaController", "bocaController null reference.");
			}
			this.m_bocaInformer.Init(this.m_PrioridadesDeObjetoEstimulado, componentInChildren3.bocaHoleController, FemalePenetracionTipo.facial);
		}

		// Token: 0x0400096C RID: 2412
		[SerializeField]
		private FemaleCharPenetrationInformer.BaseInformer m_vagInformer = new FemaleCharPenetrationInformer.BaseInformer();

		// Token: 0x0400096D RID: 2413
		[SerializeField]
		private FemaleCharPenetrationInformer.BaseInformer m_anusInformer = new FemaleCharPenetrationInformer.BaseInformer();

		// Token: 0x0400096E RID: 2414
		[SerializeField]
		private FemaleCharPenetrationInformer.BaseInformer m_bocaInformer = new FemaleCharPenetrationInformer.BaseInformer();

		// Token: 0x0400096F RID: 2415
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x0200021E RID: 542
		public class BaseInformer : IPenetrationInformer, IPenetrationInformerV2
		{
			// Token: 0x06000DB7 RID: 3511 RVA: 0x0003D3C0 File Offset: 0x0003B5C0
			public virtual void Init(IParteDelCuerpoHumanoPrioridades PrioridadesDeObjetoEstimulado, HoleController holeController, FemalePenetracionTipo @enum)
			{
				if (PrioridadesDeObjetoEstimulado == null)
				{
					throw new ArgumentNullException("PrioridadesDeObjetoEstimulado", "PrioridadesDeObjetoEstimulado null reference.");
				}
				if (holeController == null)
				{
					throw new ArgumentNullException("holeController", "holeController null reference.");
				}
				this.m_holeController = holeController;
				if (this.m_holeController.hole == null)
				{
					throw new ArgumentNullException("m_holeController.hole", "m_holeController.hole null reference.");
				}
				this.m_enum = @enum;
				this.m_PrioridadesDeObjetoEstimulado = PrioridadesDeObjetoEstimulado;
			}

			// Token: 0x06000DB8 RID: 3512 RVA: 0x0003D434 File Offset: 0x0003B634
			public bool CargarPenetracionAEstimulo(ICharacter penetrando, EstimuloPenetrante resultado)
			{
				if (resultado == null)
				{
					return false;
				}
				if (penetrando == null)
				{
					return false;
				}
				Penetrador penetradoPor = this.penetradoPor;
				if (penetradoPor == null)
				{
					return false;
				}
				if (penetradoPor.inmediateOwner != penetrando)
				{
					return false;
				}
				resultado.cambiosEnElUltimoFrame = this.cambiosEnElUltimoFrame;
				resultado.velocidadDeCambios = this.velocidadDeCambios;
				resultado.desgasteVisualActualMotion = this.m_holeController.motionDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualMotion = this.m_holeController.motionDesgaste.desgasteAI.percent;
				resultado.desgasteVisualActualProfundidad = this.m_holeController.profundidadDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualProfundidad = this.m_holeController.profundidadDesgaste.desgasteAI.percent;
				resultado.desgasteVisualActualAnchura = this.m_holeController.anchuraDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualAnchura = this.m_holeController.anchuraDesgaste.desgasteAI.percent;
				resultado.estadoActual = this.estadoActual;
				resultado.justPenetrated = this.collector.stepData.justEntered;
				resultado.DefinirReferencias(this.m_holeController.hole, this.m_PrioridadesDeObjetoEstimulado, penetradoPor, penetradoPor.punta.physicBone.transform, null);
				resultado.DefinirTransformsYVectores(this.m_holeController.hole.entrada, new Vector3?(this.m_holeController.hole.worldOutHoleDirection), new Vector3?(this.m_holeController.hole.entrada.position), null);
				switch (this.m_enum)
				{
				case FemalePenetracionTipo.anus:
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.ano);
					break;
				case FemalePenetracionTipo.vag:
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.vag);
					break;
				case FemalePenetracionTipo.facial:
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.bocaInterno);
					break;
				default:
					throw new ArgumentOutOfRangeException(this.m_enum.ToString());
				}
				resultado.penetradoPor = penetradoPor;
				resultado.holePenetrado = this.hole;
				resultado.side = Side.none;
				resultado.tipoDeEstimulo = TipoDeEstimulo.coital;
				((IInteracionEstimulanteReutilizable)resultado).GenerateNewID();
				return true;
			}

			// Token: 0x06000DB9 RID: 3513 RVA: 0x0003D630 File Offset: 0x0003B830
			public bool CargarPenetracionAEstimuloInvertido(ICharacter penetrando, EstimuloPenetrante resultado, EstimuloPenetrante original, ParteQuePuedeEstimular estimulanteParteOriginal)
			{
				if (resultado == null)
				{
					return false;
				}
				if (penetrando == null)
				{
					return false;
				}
				Penetrador penetradoPor = this.penetradoPor;
				if (penetradoPor == null)
				{
					return false;
				}
				if (penetradoPor.inmediateOwner != penetrando)
				{
					return false;
				}
				resultado.tipo = DireccionDeEstimulo.dada;
				resultado.cambiosEnElUltimoFrame = this.cambiosEnElUltimoFrame;
				resultado.velocidadDeCambios = this.velocidadDeCambios;
				resultado.desgasteVisualActualMotion = this.m_holeController.motionDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualMotion = this.m_holeController.motionDesgaste.desgasteAI.percent;
				resultado.desgasteVisualActualProfundidad = this.m_holeController.profundidadDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualProfundidad = this.m_holeController.profundidadDesgaste.desgasteAI.percent;
				resultado.desgasteVisualActualAnchura = this.m_holeController.anchuraDesgaste.desgasteVisual.percent;
				resultado.desgasteAIActualAnchura = this.m_holeController.anchuraDesgaste.desgasteAI.percent;
				resultado.estadoActual = this.estadoActual;
				resultado.justPenetrated = this.collector.stepData.justEntered;
				Transform transform = penetradoPor.punta.physicBone.transform;
				resultado.DefinirReferencias(penetradoPor, this.m_PrioridadesDeObjetoEstimulado, this.m_holeController.hole, this.m_holeController.hole.entrada, null);
				resultado.DefinirTransformsYVectores(transform, new Vector3?(transform.forward), new Vector3?(transform.position), null);
				if (estimulanteParteOriginal <= ParteQuePuedeEstimular.propSexToy)
				{
					if (estimulanteParteOriginal <= ParteQuePuedeEstimular.manos)
					{
						if (estimulanteParteOriginal == ParteQuePuedeEstimular.noEspecificada)
						{
							goto IL_01C1;
						}
						if (estimulanteParteOriginal != ParteQuePuedeEstimular.manos)
						{
							goto IL_01ED;
						}
					}
					else
					{
						if (estimulanteParteOriginal == ParteQuePuedeEstimular.pene)
						{
							goto IL_01C1;
						}
						if (estimulanteParteOriginal != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_01ED;
						}
					}
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.manos);
					goto IL_0200;
				}
				if (estimulanteParteOriginal <= ParteQuePuedeEstimular.boca)
				{
					if (estimulanteParteOriginal == ParteQuePuedeEstimular.lengua)
					{
						resultado.AddParteEstimulada(ParteDelCuerpoHumano.lengua);
						goto IL_0200;
					}
					if (estimulanteParteOriginal != ParteQuePuedeEstimular.boca)
					{
						goto IL_01ED;
					}
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.bocaInterno);
					goto IL_0200;
				}
				else if (estimulanteParteOriginal != ParteQuePuedeEstimular.semen)
				{
					if (estimulanteParteOriginal != ParteQuePuedeEstimular.dedo)
					{
						goto IL_01ED;
					}
					resultado.AddParteEstimulada(ParteDelCuerpoHumano.manos);
					goto IL_0200;
				}
				IL_01C1:
				resultado.AddParteEstimulada(ParteDelCuerpoHumano.pene);
				goto IL_0200;
				IL_01ED:
				throw new ArgumentOutOfRangeException(estimulanteParteOriginal.ToString());
				IL_0200:
				resultado.penetradoPor = penetradoPor;
				resultado.holePenetrado = this.hole;
				resultado.side = Side.none;
				resultado.tipoDeEstimulo = TipoDeEstimulo.coital;
				((IInteracionEstimulanteReutilizable)resultado).GenerateNewID();
				((IInteracionEstimulanteInversible)resultado).SetAsInvertedCopy(original);
				return true;
			}

			// Token: 0x17000354 RID: 852
			// (get) Token: 0x06000DBA RID: 3514 RVA: 0x0003D86C File Offset: 0x0003BA6C
			protected BoneStretchedChain.EstadoDePuntos estadoDePuntos
			{
				get
				{
					return this.hole.estadoDePuntos;
				}
			}

			// Token: 0x17000355 RID: 853
			// (get) Token: 0x06000DBB RID: 3515 RVA: 0x0003D879 File Offset: 0x0003BA79
			public BoneStretchedChain hole
			{
				get
				{
					return this.m_holeController.hole;
				}
			}

			// Token: 0x17000356 RID: 854
			// (get) Token: 0x06000DBC RID: 3516 RVA: 0x0003D886 File Offset: 0x0003BA86
			protected HolePointsDataCollector collector
			{
				get
				{
					return this.m_holeController.collector;
				}
			}

			// Token: 0x17000357 RID: 855
			// (get) Token: 0x06000DBD RID: 3517 RVA: 0x0003D893 File Offset: 0x0003BA93
			public bool isPenetrated
			{
				get
				{
					return this.hole.isPenetrated;
				}
			}

			// Token: 0x17000358 RID: 856
			// (get) Token: 0x06000DBE RID: 3518 RVA: 0x0003D8A0 File Offset: 0x0003BAA0
			public Penetrador penetradoPor
			{
				get
				{
					if (this.isPenetrated)
					{
						return this.hole.penetraciones.currentHits.primero.penis;
					}
					return null;
				}
			}

			// Token: 0x17000359 RID: 857
			// (get) Token: 0x06000DBF RID: 3519 RVA: 0x0003D8C8 File Offset: 0x0003BAC8
			public PenetrationInfoLocal estadoActual
			{
				get
				{
					return new PenetrationInfoLocal
					{
						aperturaLocal = this.estadoDePuntos.actualLocal.maxLocalInternals,
						centroDePuntosLocal = this.estadoDePuntos.centroDePuntos.movimientoLocal,
						profundidadHoleLocal = this.estadoDePuntos.actualLocal.penetratedDepthLocalInternals,
						profundidadPeneLocal = this.estadoDePuntos.actualLocal.penisPenetratedDepthLocalInternals
					};
				}
			}

			// Token: 0x1700035A RID: 858
			// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x0003D93C File Offset: 0x0003BB3C
			public PenetrationInfoLocal cambiosEnElUltimoFrame
			{
				get
				{
					return new PenetrationInfoLocal
					{
						aperturaLocal = this.collector.stepData.localApertureChange,
						centroDePuntosLocal = this.collector.stepData.localCenterMovement,
						profundidadHoleLocal = this.collector.stepData.localHoleDeepMovement,
						profundidadPeneLocal = this.collector.stepData.localPenisDeepMovementV2
					};
				}
			}

			// Token: 0x1700035B RID: 859
			// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x0003D9B0 File Offset: 0x0003BBB0
			public PenetrationInfoLocal velocidadDeCambios
			{
				get
				{
					return new PenetrationInfoLocal
					{
						aperturaLocal = this.collector.stepData.localApertureVelocity,
						centroDePuntosLocal = this.collector.stepData.localCenterVelocity,
						profundidadHoleLocal = this.collector.stepData.localHoleDeepVelocity,
						profundidadPeneLocal = this.collector.stepData.localPenisDeepVelocityV2
					};
				}
			}

			// Token: 0x1700035C RID: 860
			// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x0003DA22 File Offset: 0x0003BC22
			public FemalePenetracionTipo @enum
			{
				get
				{
					return this.m_enum;
				}
			}

			// Token: 0x1700035D RID: 861
			// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x0003D8A0 File Offset: 0x0003BAA0
			IPeneConPartes IPenetrationInformerV2.penetradoPor
			{
				get
				{
					if (this.isPenetrated)
					{
						return this.hole.penetraciones.currentHits.primero.penis;
					}
					return null;
				}
			}

			// Token: 0x04000970 RID: 2416
			private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

			// Token: 0x04000971 RID: 2417
			private FemalePenetracionTipo m_enum;

			// Token: 0x04000972 RID: 2418
			protected HoleController m_holeController;
		}

		// Token: 0x0200021F RID: 543
		public class EmptyInformer : IPenetrationInformer, IPenetrationInformerV2
		{
			// Token: 0x1700035E RID: 862
			// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x0003DA2A File Offset: 0x0003BC2A
			public static FemaleCharPenetrationInformer.EmptyInformer instance
			{
				get
				{
					if (FemaleCharPenetrationInformer.EmptyInformer.m_instance == null)
					{
						FemaleCharPenetrationInformer.EmptyInformer.m_instance = new FemaleCharPenetrationInformer.EmptyInformer();
					}
					return FemaleCharPenetrationInformer.EmptyInformer.m_instance;
				}
			}

			// Token: 0x1700035F RID: 863
			// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x0003DA44 File Offset: 0x0003BC44
			public PenetrationInfoLocal cambiosEnElUltimoFrame
			{
				get
				{
					return default(PenetrationInfoLocal);
				}
			}

			// Token: 0x17000360 RID: 864
			// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x0003DA5C File Offset: 0x0003BC5C
			public Percentage desgasteActual
			{
				get
				{
					return default(Percentage);
				}
			}

			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public FemalePenetracionTipo @enum
			{
				get
				{
					return FemalePenetracionTipo.anus;
				}
			}

			// Token: 0x17000362 RID: 866
			// (get) Token: 0x06000DC9 RID: 3529 RVA: 0x0003DA74 File Offset: 0x0003BC74
			public PenetrationInfoLocal estadoActual
			{
				get
				{
					return default(PenetrationInfoLocal);
				}
			}

			// Token: 0x17000363 RID: 867
			// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00023ABA File Offset: 0x00021CBA
			public BoneStretchedChain hole
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17000364 RID: 868
			// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public bool isPenetrated
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000365 RID: 869
			// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00023ABA File Offset: 0x00021CBA
			public Penetrador penetradoPor
			{
				get
				{
					return null;
				}
			}

			// Token: 0x17000366 RID: 870
			// (get) Token: 0x06000DCD RID: 3533 RVA: 0x000380AB File Offset: 0x000362AB
			public float profundidadDelHole
			{
				get
				{
					return 0f;
				}
			}

			// Token: 0x17000367 RID: 871
			// (get) Token: 0x06000DCE RID: 3534 RVA: 0x0003DA8C File Offset: 0x0003BC8C
			public Percentage desgasteVisualActual
			{
				get
				{
					return default(Percentage);
				}
			}

			// Token: 0x17000368 RID: 872
			// (get) Token: 0x06000DCF RID: 3535 RVA: 0x0003DAA4 File Offset: 0x0003BCA4
			public Percentage desgasteAIActual
			{
				get
				{
					return default(Percentage);
				}
			}

			// Token: 0x17000369 RID: 873
			// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00023ABA File Offset: 0x00021CBA
			IPeneConPartes IPenetrationInformerV2.penetradoPor
			{
				get
				{
					return null;
				}
			}

			// Token: 0x06000DD1 RID: 3537 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public bool CargarPenetracionAEstimulo(ICharacter penetrando, EstimuloPenetrante resultado)
			{
				return false;
			}

			// Token: 0x06000DD2 RID: 3538 RVA: 0x00002BE7 File Offset: 0x00000DE7
			public bool CargarPenetracionAEstimuloInvertido(ICharacter penetrando, EstimuloPenetrante resultado, EstimuloPenetrante original, ParteQuePuedeEstimular estimulanteParteOriginal)
			{
				return false;
			}

			// Token: 0x06000DD3 RID: 3539 RVA: 0x000380AB File Offset: 0x000362AB
			public float UnClampPenetrationMod()
			{
				return 0f;
			}

			// Token: 0x04000973 RID: 2419
			private static FemaleCharPenetrationInformer.EmptyInformer m_instance;
		}
	}
}

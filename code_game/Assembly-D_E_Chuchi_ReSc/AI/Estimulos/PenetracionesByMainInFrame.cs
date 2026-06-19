using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003F0 RID: 1008
	public class PenetracionesByMainInFrame : EstimuloInFrame
	{
		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x0005C006 File Offset: 0x0005A206
		public bool estimulosInFrame
		{
			get
			{
				return this.m_vag != null || this.m_anus != null || this.m_facial != null;
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001609 RID: 5641 RVA: 0x0005C023 File Offset: 0x0005A223
		public IReadOnlyList<PenetracionesByMainInFrame.Penetracion> penetracionesEnFrame
		{
			get
			{
				return this.m_penetracionesEnFrame;
			}
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x0005C02C File Offset: 0x0005A22C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Idleable = this.m_character.GetComponentInChildren<IFemaleCharacterIdleable>();
			if (this.m_Idleable == null)
			{
				throw new ArgumentNullException("m_Idleable", "m_Idleable null reference.");
			}
			this.m_CharPenetrationInformer = this.m_character.GetComponentInChildren<ICharPenetrationInformerV2>();
			this.m_estimuloGetter = new Func<EstimuloPenetrante>(this.m_poolDePenetrantes.GetItem);
			if (this.m_CharPenetrationInformer == null)
			{
				throw new ArgumentNullException("m_CharPenetrationInformer", "m_CharPenetrationInformer null reference.");
			}
			this.m_vagTemp = new PenetracionesByMainInFrame.Penetracion();
			this.m_vagTemp.tipo = FemalePenetracionTipo.vag;
			this.m_anusTemp = new PenetracionesByMainInFrame.Penetracion();
			this.m_anusTemp.tipo = FemalePenetracionTipo.anus;
			this.m_facialTemp = new PenetracionesByMainInFrame.Penetracion();
			this.m_facialTemp.tipo = FemalePenetracionTipo.facial;
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0005C0F0 File Offset: 0x0005A2F0
		public void ObtenerPenetraciones(ICollection<PenetracionesByMainInFrame.Penetracion> result)
		{
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			if (this.m_vag != null)
			{
				result.Add(this.m_vag);
			}
			if (this.m_anus != null)
			{
				result.Add(this.m_anus);
			}
			if (this.m_facial != null)
			{
				result.Add(this.m_facial);
			}
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0005C14C File Offset: 0x0005A34C
		protected sealed override void OnUpdateEstimulo(EmocionesFemeninas emos)
		{
			this.m_penetracionesEnFrame.Clear();
			Character current = MainChar.current;
			this.Procesar(current, this.m_anusTemp, ref this.m_anus, this.m_CharPenetrationInformer.anus);
			this.Procesar(current, this.m_vagTemp, ref this.m_vag, this.m_CharPenetrationInformer.vag);
			this.Procesar(current, this.m_facialTemp, ref this.m_facial, this.m_CharPenetrationInformer.facial);
			if (current != null)
			{
				IReadOnlyList<ICharacter> slavesDe = Singleton<CharacteresActivos>.instance.GetSlavesDe(current);
				if (slavesDe != null)
				{
					for (int i = 0; i < slavesDe.Count; i++)
					{
						ICharacter character = slavesDe[i];
						if (this.m_anus == null)
						{
							this.Procesar(character, this.m_anusTemp, ref this.m_anus, this.m_CharPenetrationInformer.anus);
						}
						if (this.m_vag == null)
						{
							this.Procesar(character, this.m_vagTemp, ref this.m_vag, this.m_CharPenetrationInformer.vag);
						}
						if (this.m_facial == null)
						{
							this.Procesar(character, this.m_facialTemp, ref this.m_facial, this.m_CharPenetrationInformer.facial);
						}
					}
				}
			}
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0005C270 File Offset: 0x0005A470
		private void Procesar(ICharacter main, PenetracionesByMainInFrame.Penetracion temp, ref PenetracionesByMainInFrame.Penetracion penetracion, IPenetrationInformerV2 informer)
		{
			if (!informer.isPenetrated || main == null || informer.penetradoPor == null || informer.penetradoPor.inmediateOwner != main)
			{
				temp.Clear();
				penetracion = null;
				return;
			}
			PenetracionesByMainInFrame.Penetracion penetracion2 = penetracion;
			if (((penetracion2 != null) ? penetracion2.estimulo : null) != null)
			{
				((IInteracionEstimulanteInversible)penetracion.estimulo).ClearInvertedCopy();
			}
			PenetracionesByMainInFrame.Penetracion penetracion3 = penetracion;
			if (((penetracion3 != null) ? penetracion3.estimuloInverted : null) != null)
			{
				((IInteracionEstimulanteInversible)penetracion.estimuloInverted).ClearOriginalCopy();
			}
			this.ProcesarSingle(main, temp, ref penetracion, informer);
			if (penetracion != null && (this.m_Idleable.enAutoInteraccionCoitalHead || this.m_Idleable.enAutoInteraccionCoitalHips))
			{
				this.ProcesarSingleInv(main, penetracion, informer);
			}
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x0005C318 File Offset: 0x0005A518
		private void ProcesarSingle(ICharacter main, PenetracionesByMainInFrame.Penetracion temp, ref PenetracionesByMainInFrame.Penetracion penetracion, IPenetrationInformerV2 informer)
		{
			EstimuloPenetrante estimulo = temp.estimulo;
			if (!informer.CargarPenetracionAEstimulo(main, estimulo))
			{
				temp.Clear();
				penetracion = null;
				return;
			}
			ParteQuePuedeEstimular parteQuePuedeEstimular = main.ParteQuePuedeEstimularDeTransform(estimulo.transformEstimulante);
			if (parteQuePuedeEstimular == ParteQuePuedeEstimular.None)
			{
				temp.Clear();
				penetracion = null;
				return;
			}
			((PenetracionesByMainInFrame.IPenetracionPartsSetter)temp).estimulanteParte = parteQuePuedeEstimular;
			temp.tipo = informer.@enum;
			penetracion = temp;
			if (penetracion != null)
			{
				this.m_penetracionesEnFrame.Add(penetracion);
			}
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x0005C384 File Offset: 0x0005A584
		private void ProcesarSingleInv(ICharacter main, PenetracionesByMainInFrame.Penetracion Penetracion, IPenetrationInformerV2 informer)
		{
			if (!informer.CargarPenetracionAEstimuloInvertido(main, Penetracion.estimuloInverted, Penetracion.estimulo, Penetracion.estimulanteParte))
			{
				return;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = Penetracion.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
			ParteQuePuedeEstimular parteQuePuedeEstimular;
			if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
			{
				if (parteDelCuerpoHumano != ParteDelCuerpoHumano.ano)
				{
					if (parteDelCuerpoHumano != ParteDelCuerpoHumano.vag)
					{
						Debug.LogException(new ArgumentOutOfRangeException(Penetracion.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString()));
						return;
					}
					parteQuePuedeEstimular = ParteQuePuedeEstimular.propSexToy;
				}
				else
				{
					parteQuePuedeEstimular = ParteQuePuedeEstimular.noEspecificada;
				}
			}
			else
			{
				parteQuePuedeEstimular = ParteQuePuedeEstimular.boca;
			}
			((PenetracionesByMainInFrame.IPenetracionPartsSetter)Penetracion).estimulanteParteInvertida = parteQuePuedeEstimular;
		}

		// Token: 0x04001182 RID: 4482
		private ICharPenetrationInformerV2 m_CharPenetrationInformer;

		// Token: 0x04001183 RID: 4483
		[ReadOnlyUI]
		[SerializeField]
		private PenetracionesByMainInFrame.Penetracion m_vagTemp;

		// Token: 0x04001184 RID: 4484
		[ReadOnlyUI]
		[SerializeField]
		private PenetracionesByMainInFrame.Penetracion m_anusTemp;

		// Token: 0x04001185 RID: 4485
		[ReadOnlyUI]
		[SerializeField]
		private PenetracionesByMainInFrame.Penetracion m_facialTemp;

		// Token: 0x04001186 RID: 4486
		[NonSerialized]
		private PenetracionesByMainInFrame.Penetracion m_vag;

		// Token: 0x04001187 RID: 4487
		[NonSerialized]
		private PenetracionesByMainInFrame.Penetracion m_anus;

		// Token: 0x04001188 RID: 4488
		[NonSerialized]
		private PenetracionesByMainInFrame.Penetracion m_facial;

		// Token: 0x04001189 RID: 4489
		private Func<EstimuloPenetrante> m_estimuloGetter;

		// Token: 0x0400118A RID: 4490
		[ReadOnlyUI]
		[SerializeField]
		private List<PenetracionesByMainInFrame.Penetracion> m_penetracionesEnFrame = new List<PenetracionesByMainInFrame.Penetracion>();

		// Token: 0x0400118B RID: 4491
		private PoolDeInteraccionEstimulante<EstimuloPenetrante> m_poolDePenetrantes = new PoolDeInteraccionEstimulante<EstimuloPenetrante>();

		// Token: 0x0400118C RID: 4492
		private IFemaleCharacterIdleable m_Idleable;

		// Token: 0x020003F1 RID: 1009
		private interface IPenetracionPartsSetter
		{
			// Token: 0x17000568 RID: 1384
			// (set) Token: 0x06001611 RID: 5649
			ParteQuePuedeEstimular estimulanteParte { set; }

			// Token: 0x17000569 RID: 1385
			// (set) Token: 0x06001612 RID: 5650
			ParteQuePuedeEstimular estimulanteParteInvertida { set; }
		}

		// Token: 0x020003F2 RID: 1010
		[Serializable]
		public class Penetracion : IClearable, PenetracionesByMainInFrame.IPenetracionPartsSetter
		{
			// Token: 0x06001613 RID: 5651 RVA: 0x0005C426 File Offset: 0x0005A626
			public Penetracion()
			{
				this.m_esSimulacionInstance = false;
			}

			// Token: 0x06001614 RID: 5652 RVA: 0x0005C44B File Offset: 0x0005A64B
			public Penetracion(bool esSimulacionInstance)
			{
				this.m_esSimulacionInstance = esSimulacionInstance;
			}

			// Token: 0x1700056A RID: 1386
			// (set) Token: 0x06001615 RID: 5653 RVA: 0x0005C470 File Offset: 0x0005A670
			ParteQuePuedeEstimular PenetracionesByMainInFrame.IPenetracionPartsSetter.estimulanteParte
			{
				set
				{
					this.m_estimulanteParte = value;
				}
			}

			// Token: 0x1700056B RID: 1387
			// (set) Token: 0x06001616 RID: 5654 RVA: 0x0005C479 File Offset: 0x0005A679
			ParteQuePuedeEstimular PenetracionesByMainInFrame.IPenetracionPartsSetter.estimulanteParteInvertida
			{
				set
				{
					this.m_estimulanteParteInvertida = value;
				}
			}

			// Token: 0x1700056C RID: 1388
			// (get) Token: 0x06001617 RID: 5655 RVA: 0x0005C482 File Offset: 0x0005A682
			public ParteQuePuedeEstimular estimulanteParte
			{
				get
				{
					return this.m_estimulanteParte;
				}
			}

			// Token: 0x1700056D RID: 1389
			// (get) Token: 0x06001618 RID: 5656 RVA: 0x0005C48A File Offset: 0x0005A68A
			public ParteQuePuedeEstimular estimulanteParteInvertida
			{
				get
				{
					return this.m_estimulanteParteInvertida;
				}
			}

			// Token: 0x1700056E RID: 1390
			// (get) Token: 0x06001619 RID: 5657 RVA: 0x0005C492 File Offset: 0x0005A692
			public EstimuloPenetrante estimulo
			{
				get
				{
					return this.m_estimulo;
				}
			}

			// Token: 0x1700056F RID: 1391
			// (get) Token: 0x0600161A RID: 5658 RVA: 0x0005C49A File Offset: 0x0005A69A
			public EstimuloPenetrante estimuloInverted
			{
				get
				{
					return this.m_estimuloInverted;
				}
			}

			// Token: 0x0600161B RID: 5659 RVA: 0x0005C4A2 File Offset: 0x0005A6A2
			public void SetEstimuloInstance(EstimuloPenetrante instance, EstimuloPenetrante instanceInverted, ParteQuePuedeEstimular EstimulanteParte, ParteQuePuedeEstimular EstimulanteParteInvertida)
			{
				this.m_estimulo = instance;
				this.m_estimuloInverted = instanceInverted;
				this.m_estimulanteParte = EstimulanteParte;
				this.m_estimulanteParteInvertida = EstimulanteParteInvertida;
			}

			// Token: 0x0600161C RID: 5660 RVA: 0x0005C4C4 File Offset: 0x0005A6C4
			public void Clear()
			{
				this.m_estimulanteParte = ParteQuePuedeEstimular.pene;
				this.m_estimulanteParteInvertida = ParteQuePuedeEstimular.pene;
				if (this.m_estimulo.estimulado != null)
				{
					this.m_estimulo.Clear();
				}
				if (this.m_estimuloInverted.estimulado != null)
				{
					this.m_estimuloInverted.Clear();
				}
			}

			// Token: 0x0400118D RID: 4493
			private bool m_esSimulacionInstance;

			// Token: 0x0400118E RID: 4494
			public FemalePenetracionTipo tipo;

			// Token: 0x0400118F RID: 4495
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParte;

			// Token: 0x04001190 RID: 4496
			[SerializeField]
			private ParteQuePuedeEstimular m_estimulanteParteInvertida;

			// Token: 0x04001191 RID: 4497
			[SerializeField]
			private EstimuloPenetrante m_estimulo = new EstimuloPenetrante();

			// Token: 0x04001192 RID: 4498
			[SerializeField]
			private EstimuloPenetrante m_estimuloInverted = new EstimuloPenetrante();
		}
	}
}

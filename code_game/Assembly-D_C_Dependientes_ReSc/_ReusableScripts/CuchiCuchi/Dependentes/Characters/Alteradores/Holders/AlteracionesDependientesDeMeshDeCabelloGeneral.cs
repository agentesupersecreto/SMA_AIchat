using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using Assets._ReusableScripts.Globales.Updater;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders
{
	// Token: 0x02000286 RID: 646
	[LabelLocalizado("<i>Mesh:</i> Hair", "US")]
	public sealed class AlteracionesDependientesDeMeshDeCabelloGeneral : HolderDualDeAlteradores<AlteradorGenericoDeIndex, AlteradorGenericoDirectoSingleConInicial>
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060010EF RID: 4335 RVA: 0x0002956C File Offset: 0x0002776C
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate1;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060010F0 RID: 4336 RVA: 0x0004FEC4 File Offset: 0x0004E0C4
		protected override GlobalUpdater.UpdateType? updateTypeB
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0004FEDA File Offset: 0x0004E0DA
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeCabelloGpu = this.GetComponentEnCharacter(false);
			if (this.m_ControlladorDeCabelloGpu == null)
			{
				throw new ArgumentNullException("m_ControlladorDeCabelloGpu", "m_ControlladorDeCabelloGpu null reference.");
			}
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0004FF10 File Offset: 0x0004E110
		protected override void InstanciarAlteradores(List<AlteradorGenericoDeIndex> resultado)
		{
			resultado.Add(new AlteradorGenericoDeIndex(DiccionarioDeNombresDeAlteradoresFemeninos.Reemplazador_StyloDeCabello, this, delegate
			{
				if (this.m_ControlladorDeCabelloGpu.estiloPrefab == null)
				{
					this.m_ControlladorDeCabelloGpu.flagCambiarStyloAIndex = 0;
					this.m_ControlladorDeCabelloGpu.ActualizarStylo();
				}
				return this.m_ControlladorDeCabelloGpu.IndexDeCurrentStyloDeCabello();
			}, () => this.m_ControlladorDeCabelloGpu.cantidadDeStylosDeCabello, delegate(int v)
			{
				this.m_ControlladorDeCabelloGpu.flagCambiarStyloAIndex = v;
				this.m_ControlladorDeCabelloGpu.ActualizarStylo();
			})
			{
				esVolatil = true
			});
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0004FF5C File Offset: 0x0004E15C
		protected override void InstanciarAlteradoresB(List<AlteradorGenericoDirectoSingleConInicial> resultado)
		{
			AlteradorGenericoDirectoSingleConInicial alteradorGenericoDirectoSingleConInicial = new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CerdasDeCabello, this, delegate(float a)
			{
				this.m_ControlladorDeCabelloGpu.radioDeCerdas.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarRadioDeCerdas();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.radioDeCerdas.@base, 0f, 1f);
			resultado.Add(alteradorGenericoDirectoSingleConInicial);
			AlteradorGenericoDirectoSingleConInicial alteradorGenericoDirectoSingleConInicial2 = new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_RisosDeCabello, this, delegate(float a)
			{
				this.m_ControlladorDeCabelloGpu.risosScale.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarRisos();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.risosScale.@base, 0f, 1f);
			AlteradorGenericoDirectoSingleConInicial alteradorGenericoDirectoSingleConInicial3 = new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Incrementador_FrequenciaRisosDeCabello, this, delegate(float a)
			{
				this.m_ControlladorDeCabelloGpu.risosFrequency.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarRisos();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.risosFrequency.@base, 0f, 1f);
			AlteradorGenericoDirectoSingleConInicial alteradorGenericoDirectoSingleConInicial4 = new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AxisDeRisosDeCabello, this, delegate(float a)
			{
				this.m_ControlladorDeCabelloGpu.risosAxis.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarRisos();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.risosAxis.@base, 0f, 1f);
			AlteradorGenericoDirectoSingleConInicial alteradorGenericoDirectoSingleConInicial5 = new AlteradorGenericoDirectoSingleConInicial(DiccionarioDeNombresDeAlteradoresFemeninos.Interpolador_CabelloTip, this, delegate(float a)
			{
				a = MathfExtension.Clamp01(a, 0.2f, 0.8f);
				this.m_ControlladorDeCabelloGpu.tipInterpolation.SetBase(a);
				this.m_ControlladorDeCabelloGpu.ActualizarInterpalacion();
				this.m_ControlladorDeCabelloGpu.ReDibujar();
			}, () => this.m_ControlladorDeCabelloGpu.tipInterpolation.@base, 0f, 1f);
			resultado.Add(alteradorGenericoDirectoSingleConInicial2);
			resultado.Add(alteradorGenericoDirectoSingleConInicial3);
			resultado.Add(alteradorGenericoDirectoSingleConInicial4);
			resultado.Add(alteradorGenericoDirectoSingleConInicial5);
		}

		// Token: 0x04000C66 RID: 3174
		private ControlladorDeCabelloGpu m_ControlladorDeCabelloGpu;
	}
}

using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200032E RID: 814
	[Obsolete]
	[Serializable]
	public class EstimuloTactilData : EstimuloDataEdicionDirecta
	{
		// Token: 0x06001186 RID: 4486 RVA: 0x0004B4B0 File Offset: 0x000496B0
		private EstimuloTactilData()
		{
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06001187 RID: 4487 RVA: 0x0004B4D5 File Offset: 0x000496D5
		public static EstimuloTactilData nuevaInstancia
		{
			get
			{
				return new EstimuloTactilData();
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x0004B4DC File Offset: 0x000496DC
		public Component objetoQueHaceElEstimulo
		{
			get
			{
				return this.m_objetoQueHaceElEstimulo;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x0004B4E4 File Offset: 0x000496E4
		public Component objetoSiendoEstimulado
		{
			get
			{
				return this.m_objetoSiendoEstimulado;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x0004B4EC File Offset: 0x000496EC
		public float estimulo
		{
			get
			{
				return this.m_estimulo;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x0600118B RID: 4491 RVA: 0x0004B4F4 File Offset: 0x000496F4
		public bool posicionDefinida
		{
			get
			{
				return this.m_posicionDefinida;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x0004B4FC File Offset: 0x000496FC
		public Vector3 posicionDeObjetoEstimulante
		{
			get
			{
				return this.m_posicionDeObjetoEstimulante;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x0004B504 File Offset: 0x00049704
		public bool normalDefinida
		{
			get
			{
				return this.m_normalDefinida;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x0004B50C File Offset: 0x0004970C
		public Vector3 normalDelEstimulo
		{
			get
			{
				return this.m_normalDelEstimulo;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x0600118F RID: 4495 RVA: 0x0004B514 File Offset: 0x00049714
		public EstimuloTipo tipo
		{
			get
			{
				return this.m_tipo;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x0004B51C File Offset: 0x0004971C
		public EstimuloTipo2 tipo2
		{
			get
			{
				return this.m_tipo2;
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06001191 RID: 4497 RVA: 0x0004B524 File Offset: 0x00049724
		public Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001192 RID: 4498 RVA: 0x0004B52C File Offset: 0x0004972C
		public SpotScore umbralSpotScore
		{
			get
			{
				return this.m_umbralSpotScore;
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x0004B534 File Offset: 0x00049734
		public List<ParteDelCuerpoHumano> parts
		{
			get
			{
				return this.m_parts;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06001194 RID: 4500 RVA: 0x0004B53C File Offset: 0x0004973C
		public HashSet<int> partsSet
		{
			get
			{
				return this.m_partsSet;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06001195 RID: 4501 RVA: 0x0004B4EC File Offset: 0x000496EC
		// (set) Token: 0x06001196 RID: 4502 RVA: 0x0004B544 File Offset: 0x00049744
		float EstimuloDataEdicionDirecta.estimulo
		{
			get
			{
				return this.m_estimulo;
			}
			set
			{
				this.m_estimulo = value;
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06001197 RID: 4503 RVA: 0x0004B514 File Offset: 0x00049714
		// (set) Token: 0x06001198 RID: 4504 RVA: 0x0004B54D File Offset: 0x0004974D
		EstimuloTipo EstimuloDataEdicionDirecta.tipo
		{
			get
			{
				return this.m_tipo;
			}
			set
			{
				this.m_tipo = value;
			}
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x0004B556 File Offset: 0x00049756
		public void PoblarSinSource(float esti, EstimuloTipo t, SpotScore sScore)
		{
			this.m_estimulo = esti;
			this.m_tipo = t;
			this.m_umbralSpotScore = sScore;
			this.onPoblado();
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x0004B573 File Offset: 0x00049773
		public void PoblarSinSource(float esti, EstimuloTipo t, EstimuloTipo2 t2, SpotScore sScore)
		{
			this.m_tipo2 = t2;
			this.PoblarSinSource(esti, t, sScore);
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0004B586 File Offset: 0x00049786
		public void PoblarSinSource(float esti, EstimuloTipo t, SpotScore sScore, Side s)
		{
			this.m_side = s;
			this.PoblarSinSource(esti, t, sScore);
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0004B599 File Offset: 0x00049799
		private void onPoblado()
		{
			if (!this.m_cleared)
			{
				throw new InvalidOperationException("EstimuloData fue poblado sin haber sido limpiado");
			}
			this.m_cleared = false;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0004B5B8 File Offset: 0x000497B8
		public void SobreEscribirDesde(ref EstimuloTactilData destino, float? esti, EstimuloTipo? t, EstimuloTipo2? t2, SpotScore? sScore)
		{
			this.Copia(ref destino);
			if (esti != null)
			{
				destino.m_estimulo = esti.Value;
			}
			if (t != null)
			{
				destino.m_tipo = t.Value;
			}
			if (t2 != null)
			{
				destino.m_tipo2 = t2.Value;
			}
			if (sScore != null)
			{
				destino.m_umbralSpotScore = sScore.Value;
			}
			destino.onPoblado();
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0004B630 File Offset: 0x00049830
		public EstimuloTactilData SobreEscribir(float? esti, EstimuloTipo? t, EstimuloTipo2? t2, SpotScore? sScore)
		{
			EstimuloTactilData estimuloTactilData = null;
			this.SobreEscribirDesde(ref estimuloTactilData, esti, t, t2, sScore);
			return estimuloTactilData;
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0004B64D File Offset: 0x0004984D
		public void SetPosicionObjetoEstimulante(Vector3 posicion)
		{
			this.m_posicionDefinida = true;
			this.m_posicionDeObjetoEstimulante = posicion;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0004B65D File Offset: 0x0004985D
		public void SetNormalEstimulo(Vector3 normal)
		{
			this.m_normalDefinida = true;
			this.m_normalDelEstimulo = normal;
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0004B66D File Offset: 0x0004986D
		public void Poblar(InteracionEstimulanteBasica source, float esti, EstimuloTipo t, SpotScore sScore)
		{
			this.m_estimulo = esti;
			this.m_tipo = t;
			this.m_umbralSpotScore = sScore;
			this.OnPoblado(source);
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0004B68C File Offset: 0x0004988C
		public void Poblar(InteracionEstimulanteBasica source, float esti, EstimuloTipo t, EstimuloTipo2 t2, SpotScore sScore)
		{
			this.m_tipo2 = t2;
			this.Poblar(source, esti, t, sScore);
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0004B6A1 File Offset: 0x000498A1
		public void Poblar(InteracionEstimulanteBasica source, float esti, EstimuloTipo t, SpotScore sScore, Side s)
		{
			this.m_side = s;
			this.Poblar(source, esti, t, sScore);
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x0004B6B6 File Offset: 0x000498B6
		protected virtual void OnPoblado(InteracionEstimulanteBasica source)
		{
			this.m_objetoQueHaceElEstimulo = source.estimulante;
			this.m_objetoSiendoEstimulado = source.estimulado;
			this.CalcularBodyPart(source);
			this.onPoblado();
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x0004B6DD File Offset: 0x000498DD
		public void CalcularBodyPart(InteracionEstimulanteBasica toq)
		{
			this.AddPArtes(toq);
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x0004B6E8 File Offset: 0x000498E8
		private void AddPArtes(InteracionEstimulanteBasica toq)
		{
			for (int i = 0; i < toq.CantidadDePartes; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = toq.ObtenerParteEn(i);
				if (this.m_partsSet.Add((int)parteDelCuerpoHumano))
				{
					this.m_parts.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0004B728 File Offset: 0x00049928
		public void Clear()
		{
			this.m_objetoQueHaceElEstimulo = null;
			this.m_objetoSiendoEstimulado = null;
			this.m_cleared = true;
			if (this.m_parts != null)
			{
				this.m_parts.Clear();
			}
			if (this.m_partsSet != null)
			{
				this.m_partsSet.Clear();
			}
			this.m_estimulo = 0f;
			this.m_posicionDefinida = false;
			this.m_normalDefinida = false;
			this.m_posicionDeObjetoEstimulante = Vector3.zero;
			this.m_normalDelEstimulo = Vector3.zero;
			this.m_tipo = EstimuloTipo.noDefinido;
			this.m_side = Side.none;
			this.m_tipo2 = EstimuloTipo2.noDefinido;
			this.m_umbralSpotScore = SpotScore.fuera;
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0004B7BC File Offset: 0x000499BC
		public void Copia(ref EstimuloTactilData destino)
		{
			if (destino == null)
			{
				destino = this.Copia();
				return;
			}
			destino.m_objetoQueHaceElEstimulo = this.m_objetoQueHaceElEstimulo;
			destino.m_objetoSiendoEstimulado = this.m_objetoSiendoEstimulado;
			destino.m_cleared = true;
			destino.m_estimulo = this.m_estimulo;
			destino.m_posicionDefinida = this.m_posicionDefinida;
			destino.m_normalDefinida = this.m_normalDefinida;
			destino.m_posicionDeObjetoEstimulante = this.m_posicionDeObjetoEstimulante;
			destino.m_normalDelEstimulo = this.m_normalDelEstimulo;
			destino.m_tipo = this.m_tipo;
			destino.m_side = this.m_side;
			destino.m_tipo2 = this.m_tipo2;
			destino.m_umbralSpotScore = this.m_umbralSpotScore;
			destino.m_parts.Clear();
			destino.m_partsSet.Clear();
			for (int i = 0; i < this.m_parts.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.m_parts[i];
				if (destino.m_partsSet.Add((int)parteDelCuerpoHumano))
				{
					destino.m_parts.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0004B8C4 File Offset: 0x00049AC4
		public EstimuloTactilData Copia()
		{
			EstimuloTactilData estimuloTactilData = (EstimuloTactilData)base.MemberwiseClone();
			estimuloTactilData.m_cleared = true;
			estimuloTactilData.m_parts = new List<ParteDelCuerpoHumano>();
			estimuloTactilData.m_partsSet = new HashSet<int>();
			for (int i = 0; i < this.m_parts.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = this.m_parts[i];
				if (estimuloTactilData.m_partsSet.Add((int)parteDelCuerpoHumano))
				{
					estimuloTactilData.m_parts.Add(parteDelCuerpoHumano);
				}
			}
			return estimuloTactilData;
		}

		// Token: 0x04000E00 RID: 3584
		[SerializeField]
		private Component m_objetoQueHaceElEstimulo;

		// Token: 0x04000E01 RID: 3585
		[SerializeField]
		private Component m_objetoSiendoEstimulado;

		// Token: 0x04000E02 RID: 3586
		[SerializeField]
		private float m_estimulo;

		// Token: 0x04000E03 RID: 3587
		[SerializeField]
		private bool m_posicionDefinida;

		// Token: 0x04000E04 RID: 3588
		[SerializeField]
		private Vector3 m_posicionDeObjetoEstimulante;

		// Token: 0x04000E05 RID: 3589
		[SerializeField]
		private bool m_normalDefinida;

		// Token: 0x04000E06 RID: 3590
		[SerializeField]
		private Vector3 m_normalDelEstimulo;

		// Token: 0x04000E07 RID: 3591
		[SerializeField]
		private EstimuloTipo m_tipo;

		// Token: 0x04000E08 RID: 3592
		[SerializeField]
		private EstimuloTipo2 m_tipo2;

		// Token: 0x04000E09 RID: 3593
		[SerializeField]
		private Side m_side;

		// Token: 0x04000E0A RID: 3594
		[SerializeField]
		private SpotScore m_umbralSpotScore;

		// Token: 0x04000E0B RID: 3595
		[SerializeField]
		private List<ParteDelCuerpoHumano> m_parts = new List<ParteDelCuerpoHumano>();

		// Token: 0x04000E0C RID: 3596
		private HashSet<int> m_partsSet = new HashSet<int>();

		// Token: 0x04000E0D RID: 3597
		[SerializeField]
		[ReadOnlyUI]
		private bool m_cleared = true;
	}
}

using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000310 RID: 784
	public abstract class ReacctorDeInteraccionesPartesPrivadas<TCalculo> : ReacctorDeInteracciones<TCalculo> where TCalculo : class, ICalculoDeInteracionEstimulante
	{
		// Token: 0x060013BD RID: 5053 RVA: 0x0005C6EC File Offset: 0x0005A8EC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_partesDeNalgas.Add(24);
			this.m_partesDeNalgas.Add(26);
			this.m_partesDeAno.Add(31);
			this.m_partesDeAno.Add(30);
			this.m_partesDeVientre.Add(25);
			this.m_partesDeVagina.Add(27);
			this.m_partesDeVagina.Add(32);
			this.m_partesDeVagina.Add(28);
			this.m_partesDeVagina.Add(29);
			this.m_partesDeTetas.Add(22);
			this.m_partesDePezones.Add(23);
		}

		// Token: 0x060013BE RID: 5054
		protected abstract void OnCalculoEnEnPartePrivada(TCalculo calculo);

		// Token: 0x060013BF RID: 5055
		protected abstract bool IncluirTetas(TCalculo calculo);

		// Token: 0x060013C0 RID: 5056
		protected abstract bool IncluirNalgas(TCalculo calculo);

		// Token: 0x060013C1 RID: 5057
		protected abstract bool IncluirVientre(TCalculo calculo);

		// Token: 0x060013C2 RID: 5058
		protected abstract bool IncluirPezones(TCalculo calculo);

		// Token: 0x060013C3 RID: 5059
		protected abstract bool IncluirAno(TCalculo calculo);

		// Token: 0x060013C4 RID: 5060
		protected abstract bool IncluirVagina(TCalculo calculo);

		// Token: 0x060013C5 RID: 5061
		protected abstract float ObtenerModificadorDeCoolDown(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo, TCalculo calculo);

		// Token: 0x060013C6 RID: 5062
		protected abstract float ObtenerModificadorDeProbabilidad(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo, TCalculo calculo);

		// Token: 0x060013C7 RID: 5063
		protected abstract bool EstimuloEnPartesPrivadasEsValido(TCalculo calculo);

		// Token: 0x060013C8 RID: 5064 RVA: 0x0005C79C File Offset: 0x0005A99C
		protected sealed override bool CalculoEsValido(TCalculo calculo)
		{
			if (!base.CalculoEsValido(calculo))
			{
				return false;
			}
			if (!this.EstimulandoPartePrivada(calculo) || !this.EstimuloEnPartesPrivadasEsValido(calculo))
			{
				this.m_Tipo = ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None;
				return false;
			}
			this.m_Tipo = this.ObtenerTipo(calculo);
			return this.m_Tipo != ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None;
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x0005C7EC File Offset: 0x0005A9EC
		protected sealed override float ProbabilidadPorSegundoModificadorParaCalculo(TCalculo calculo)
		{
			return this.ObtenerModificadorDeProbabilidad(this.m_Tipo, calculo);
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float CoolDownModificadorParaCalculo(TCalculo calculo)
		{
			return 1f;
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0005C7FC File Offset: 0x0005A9FC
		protected override bool IsOnCoolDown(object arg)
		{
			TCalculo tcalculo = arg as TCalculo;
			bool flag = base.IsOnCoolDown(arg);
			if (flag || tcalculo == null)
			{
				return flag;
			}
			return this.TipoEnCoolDown(this.m_Tipo, this.ObtenerModificadorDeCoolDown(this.m_Tipo, tcalculo));
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x0005C843 File Offset: 0x0005AA43
		protected sealed override bool ReaccionarCalculo(TCalculo calculo)
		{
			bool flag = this.ReaccionarAEstimuloEnPartesPrivadas(calculo);
			if (flag)
			{
				this.ApplyCoolDownPorTipo(this.m_Tipo);
			}
			return flag;
		}

		// Token: 0x060013CD RID: 5069
		protected abstract bool ReaccionarAEstimuloEnPartesPrivadas(TCalculo calculo);

		// Token: 0x060013CE RID: 5070 RVA: 0x0005C85C File Offset: 0x0005AA5C
		private bool EstimulandoPartePrivada(TCalculo calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			bool flag = this.m_partesDeTetas.Contains(num);
			bool flag2 = this.m_partesDeNalgas.Contains(num);
			bool flag3 = this.m_partesDeVientre.Contains(num);
			bool flag4 = this.m_partesDePezones.Contains(num);
			bool flag5 = this.m_partesDeAno.Contains(num);
			bool flag6 = this.m_partesDeVagina.Contains(num);
			if (flag || flag2 || flag3 || flag4 || flag5 || flag6)
			{
				this.OnCalculoEnEnPartePrivada(calculo);
				return (flag && this.IncluirTetas(calculo)) || (flag2 && this.IncluirNalgas(calculo)) || (flag3 && this.IncluirVientre(calculo)) || (flag4 && this.IncluirPezones(calculo)) || (flag5 && this.IncluirAno(calculo)) || (flag6 && this.IncluirVagina(calculo));
			}
			return false;
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0005C93C File Offset: 0x0005AB3C
		private bool EstimulandoTetas(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDeTetas.Contains(num);
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0005C964 File Offset: 0x0005AB64
		private bool EstimulandoNalgas(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDeNalgas.Contains(num);
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0005C98C File Offset: 0x0005AB8C
		private bool EstimulandoVientre(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDeVientre.Contains(num);
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x0005C9B4 File Offset: 0x0005ABB4
		private bool EstimulandoVagina(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDeVagina.Contains(num);
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x0005C9DC File Offset: 0x0005ABDC
		private bool EstimulandoAno(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDeAno.Contains(num);
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x0005CA04 File Offset: 0x0005AC04
		private bool EstimulandoPezones(ICalculoDeInteracionEstimulante calculo)
		{
			int num = (int)ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			return this.m_partesDePezones.Contains(num);
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0005CA2C File Offset: 0x0005AC2C
		[Obsolete]
		private bool ListContains(InteracionEstimulanteBasica estimulo, HashSetList<int> buscando)
		{
			for (int i = 0; i < buscando.Count; i++)
			{
				int num = buscando[i];
				if (estimulo.ContineParte((ParteDelCuerpoHumano)num))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x0005CA60 File Offset: 0x0005AC60
		[Obsolete("", true)]
		protected float ChangeModPorEmo(ICalculoDeInteracionEstimulante calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.tristeza)
			{
				if (reaccion <= ReaccionHumana.asco)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
					case ReaccionHumana.concentToHero:
					case ReaccionHumana.asombro:
						break;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						goto IL_00B6;
					case ReaccionHumana.dolor:
						return 1.1f;
					case ReaccionHumana.rabia:
						return 1.2f;
					default:
						if (reaccion != ReaccionHumana.asco)
						{
							goto IL_00B6;
						}
						break;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.placer)
					{
						return 0.1f;
					}
					if (reaccion != ReaccionHumana.arousal && reaccion != ReaccionHumana.tristeza)
					{
						goto IL_00B6;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.felicidad)
			{
				if (reaccion != ReaccionHumana.miedo && reaccion != ReaccionHumana.alegria && reaccion != ReaccionHumana.felicidad)
				{
					goto IL_00B6;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.decepcion)
				{
					return 1f;
				}
				if (reaccion != ReaccionHumana.alivio && reaccion != ReaccionHumana.aburrimiento)
				{
					goto IL_00B6;
				}
			}
			return 0f;
			IL_00B6:
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0005CB44 File Offset: 0x0005AD44
		private void ApplyCoolDownPorTipo(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo)
		{
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None:
				throw new InvalidOperationException();
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.nalgas:
				this.m_NalgasCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.ano:
				this.m_AnoCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vientre:
				this.m_VientreCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vagina:
				this.m_VaginaCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.tetas:
				this.m_TetasCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.pezones:
				this.m_PezonesCoolDown.ApplyNext(this.baseConfig.coolDownGeneral);
				return;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x0005CC1C File Offset: 0x0005AE1C
		private bool TipoEnCoolDown(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo, float modificador)
		{
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None:
				throw new InvalidOperationException();
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.nalgas:
				return this.m_NalgasCoolDown.IsOn(modificador);
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.ano:
				return this.m_AnoCoolDown.IsOn(modificador);
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vientre:
				return this.m_VientreCoolDown.IsOn(modificador);
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vagina:
				return this.m_VaginaCoolDown.IsOn(modificador);
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.tetas:
				return this.m_TetasCoolDown.IsOn(modificador);
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.pezones:
				return this.m_PezonesCoolDown.IsOn(modificador);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x0005CCB4 File Offset: 0x0005AEB4
		protected bool TryObtenerParaUsar(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo, Side handSide, out Interaccion interaccion)
		{
			Interaccion interaccion2 = null;
			Interaccion interaccion3 = null;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None:
				throw new InvalidOperationException();
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.nalgas:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.ano:
				if (handSide == Side.R && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparColaConManoDerecha, out interaccion2))
				{
					interaccion2 = null;
				}
				if (handSide == Side.L && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparColaConManoIzquierda, out interaccion3))
				{
					interaccion3 = null;
				}
				break;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vientre:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vagina:
				if (handSide == Side.R && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparVagConManoDerecha, out interaccion2))
				{
					interaccion2 = null;
				}
				if (handSide == Side.L && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparVagConManoIzquierda, out interaccion3))
				{
					interaccion3 = null;
				}
				break;
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.tetas:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.pezones:
				if (handSide == Side.R && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparSenosConManoDerecha, out interaccion2))
				{
					interaccion2 = null;
				}
				if (handSide == Side.L && !this.m_InteraccionesBasicasDeFemale.TryObtenerSiEsValida(InteraccionSegundariaName.taparSenosConManoIzquierda, out interaccion3))
				{
					interaccion3 = null;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			switch (handSide)
			{
			case Side.none:
			case Side.F:
			case Side.B:
				throw new InvalidOperationException();
			case Side.L:
				interaccion = interaccion3;
				break;
			case Side.R:
				interaccion = interaccion2;
				break;
			default:
				throw new ArgumentOutOfRangeException(handSide.ToString());
			}
			return interaccion != null;
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x0005CDDC File Offset: 0x0005AFDC
		protected bool YaSeEstaTapando(ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo tipo, out Interaccion ejecutandose)
		{
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None:
				throw new InvalidOperationException();
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.nalgas:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.ano:
			{
				Interaccion interaccion;
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparColaConManoDerecha, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparColaConManoIzquierda, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				break;
			}
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vientre:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vagina:
			{
				Interaccion interaccion;
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparVagConManoDerecha, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparVagConManoIzquierda, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				break;
			}
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.tetas:
			case ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.pezones:
			{
				Interaccion interaccion;
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparSenosConManoDerecha, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				if (this.m_InteraccionesBasicasDeFemale.Ejecutandose(InteraccionSegundariaName.taparSenosConManoIzquierda, out interaccion))
				{
					ejecutandose = interaccion;
					return true;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			ejecutandose = null;
			return false;
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x0005CEAC File Offset: 0x0005B0AC
		private ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo ObtenerTipo(ICalculoDeInteracionEstimulante calculo)
		{
			if (this.EstimulandoTetas(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.tetas;
			}
			if (this.EstimulandoNalgas(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.nalgas;
			}
			if (this.EstimulandoVientre(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vientre;
			}
			if (this.EstimulandoPezones(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.pezones;
			}
			if (this.EstimulandoAno(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.ano;
			}
			if (this.EstimulandoVagina(calculo))
			{
				return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.vagina;
			}
			return ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo.None;
		}

		// Token: 0x04000E48 RID: 3656
		[Header("Partes Privadas Config")]
		[ReadOnlyUI]
		[SerializeField]
		protected ReacctorDeInteraccionesPartesPrivadas<TCalculo>.Tipo m_Tipo;

		// Token: 0x04000E49 RID: 3657
		private HashSetList<int> m_partesDeNalgas = new HashSetList<int>();

		// Token: 0x04000E4A RID: 3658
		private HashSetList<int> m_partesDeAno = new HashSetList<int>();

		// Token: 0x04000E4B RID: 3659
		private HashSetList<int> m_partesDeVientre = new HashSetList<int>();

		// Token: 0x04000E4C RID: 3660
		private HashSetList<int> m_partesDeVagina = new HashSetList<int>();

		// Token: 0x04000E4D RID: 3661
		private HashSetList<int> m_partesDeTetas = new HashSetList<int>();

		// Token: 0x04000E4E RID: 3662
		private HashSetList<int> m_partesDePezones = new HashSetList<int>();

		// Token: 0x04000E4F RID: 3663
		private CoolDown m_NalgasCoolDown = new CoolDown();

		// Token: 0x04000E50 RID: 3664
		private CoolDown m_AnoCoolDown = new CoolDown();

		// Token: 0x04000E51 RID: 3665
		private CoolDown m_VientreCoolDown = new CoolDown();

		// Token: 0x04000E52 RID: 3666
		private CoolDown m_VaginaCoolDown = new CoolDown();

		// Token: 0x04000E53 RID: 3667
		private CoolDown m_TetasCoolDown = new CoolDown();

		// Token: 0x04000E54 RID: 3668
		private CoolDown m_PezonesCoolDown = new CoolDown();

		// Token: 0x02000311 RID: 785
		public enum Tipo
		{
			// Token: 0x04000E56 RID: 3670
			None,
			// Token: 0x04000E57 RID: 3671
			nalgas,
			// Token: 0x04000E58 RID: 3672
			ano,
			// Token: 0x04000E59 RID: 3673
			vientre,
			// Token: 0x04000E5A RID: 3674
			vagina,
			// Token: 0x04000E5B RID: 3675
			tetas,
			// Token: 0x04000E5C RID: 3676
			pezones
		}
	}
}

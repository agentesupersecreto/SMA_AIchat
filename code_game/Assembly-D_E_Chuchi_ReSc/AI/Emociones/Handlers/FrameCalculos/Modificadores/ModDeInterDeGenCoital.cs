using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores
{
	// Token: 0x02000524 RID: 1316
	public sealed class ModDeInterDeGenCoital : CustomMonobehaviour, IModDeInterDeGenCoitalProfundidad, IModDeInterDeGenCoitalAnchura, IModDeInterDeGenCoitalPenVel, IModDeInterDeGenTactil, IHolesRangosClamp
	{
		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x06002018 RID: 8216 RVA: 0x000795F0 File Offset: 0x000777F0
		private float bodyHolesVirtualEnduranceMod
		{
			get
			{
				switch (this.m_personalidad.GetTraitScore(TraitHumano.bodyHolesVirtualEndurance))
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.1f;
				case HumanTraitScore.muyAlto:
					return 1.2f;
				case HumanTraitScore.bajo:
					return 0.9090909f;
				case HumanTraitScore.muyBajo:
					return 0.8333333f;
				default:
					throw new ArgumentOutOfRangeException(this.m_personalidad.GetTraitScore(TraitHumano.bodyHolesVirtualEndurance).ToString());
				}
			}
		}

		// Token: 0x06002019 RID: 8217 RVA: 0x00079668 File Offset: 0x00077868
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_desgastePenVelDeVag == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgastePenVelDeAnus == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgastePenVelDeBoca == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgasteProdundidadDeBoca == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgasteAnchuraDeAnus == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgasteAnchuraDeVag == null)
			{
				throw new NullReferenceException();
			}
			if (this.m_desgasteAnchuraDeBoca == null)
			{
				throw new NullReferenceException();
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_IHolesDesgastables = this.GetComponentEnRoot(false);
			if (this.m_IHolesDesgastables == null)
			{
				throw new ArgumentNullException("m_IHolesDesgastables", "m_IHolesDesgastables null reference.");
			}
			this.vag = new ModDeInterDeGenCoital.FemaleHoleRangos
			{
				motion = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgastePenVelDeVag),
				anchura = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgasteAnchuraDeVag)
			};
			this.anus = new ModDeInterDeGenCoital.FemaleHoleRangos
			{
				motion = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgastePenVelDeAnus),
				anchura = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgasteAnchuraDeAnus)
			};
			this.garganta = new ModDeInterDeGenCoital.FemaleHoleRangos
			{
				motion = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgastePenVelDeBoca),
				anchura = new ModDeInterDeGenCoital.FemaleHoleRangoEspecifico(this.m_desgasteAnchuraDeBoca)
			};
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x000797E0 File Offset: 0x000779E0
		[Obsolete("no se usan ya", true)]
		void IModDeInterDeGenCoitalProfundidad.Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			RangeValueV2 rangeValueV;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				if (this.m_desgasteProdundidadDeAnus)
				{
					rangeValueV = this.m_desgasteProdundidadDeAnus.Modificar(intervalo, this.m_IHolesDesgastables.anus.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.vag:
				if (this.m_desgasteProdundidadDeVag)
				{
					rangeValueV = this.m_desgasteProdundidadDeVag.Modificar(intervalo, this.m_IHolesDesgastables.vag.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.facial:
				if (this.m_desgasteProdundidadDeBoca)
				{
					rangeValueV = this.m_desgasteProdundidadDeBoca.Modificar(intervalo, this.m_IHolesDesgastables.boca.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			intervalo = rangeValueV;
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x000798F0 File Offset: 0x00077AF0
		[Obsolete("no se usan ya", true)]
		void IModDeInterDeGenCoitalAnchura.Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			RangeValueV2 rangeValueV;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				if (this.m_desgasteAnchuraDeAnus)
				{
					rangeValueV = this.m_desgasteAnchuraDeAnus.Modificar(intervalo, this.m_IHolesDesgastables.anus.anchura.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.vag:
				if (this.m_desgasteAnchuraDeVag)
				{
					rangeValueV = this.m_desgasteAnchuraDeVag.Modificar(intervalo, this.m_IHolesDesgastables.vag.anchura.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.facial:
				if (this.m_desgasteAnchuraDeBoca)
				{
					rangeValueV = this.m_desgasteAnchuraDeBoca.Modificar(intervalo, this.m_IHolesDesgastables.boca.anchura.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			intervalo = rangeValueV;
		}

		// Token: 0x0600201C RID: 8220 RVA: 0x00079A00 File Offset: 0x00077C00
		[Obsolete("no se usan ya", true)]
		void IModDeInterDeGenCoitalPenVel.Modificar(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			RangeValueV2 rangeValueV;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				if (this.m_desgastePenVelDeAnus)
				{
					rangeValueV = this.m_desgastePenVelDeAnus.Modificar(intervalo, this.m_IHolesDesgastables.anus.motion.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.vag:
				if (this.m_desgastePenVelDeVag)
				{
					rangeValueV = this.m_desgastePenVelDeVag.Modificar(intervalo, this.m_IHolesDesgastables.vag.motion.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			case FemalePenetracionTipo.facial:
				if (this.m_desgastePenVelDeBoca)
				{
					rangeValueV = this.m_desgastePenVelDeBoca.Modificar(intervalo, this.m_IHolesDesgastables.boca.motion.currentAI * bodyHolesVirtualEnduranceMod);
				}
				else
				{
					rangeValueV = intervalo;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			intervalo = rangeValueV;
		}

		// Token: 0x0600201D RID: 8221 RVA: 0x00079B10 File Offset: 0x00077D10
		[Obsolete("no se usan ya", true)]
		void IModDeInterDeGenTactil.Modificar(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ref RangeValueV2 intervalo)
		{
			float num;
			ModifcadorDeIntervalo modifcadorDeIntervalo;
			if (estimuladaParte.EsCoitoOral())
			{
				num = this.m_IHolesDesgastables.boca.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeBoca;
			}
			else if (estimuladaParte.EsCoitoVaginal())
			{
				num = this.m_IHolesDesgastables.vag.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeVag;
			}
			else
			{
				if (!estimuladaParte.EsCoitoAnal())
				{
					return;
				}
				num = this.m_IHolesDesgastables.anus.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeAnus;
			}
			if (modifcadorDeIntervalo != null)
			{
				float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
				RangeValueV2 rangeValueV = modifcadorDeIntervalo.Modificar(intervalo, num * bodyHolesVirtualEnduranceMod);
				intervalo = rangeValueV;
			}
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x00079BBC File Offset: 0x00077DBC
		[Obsolete("reemplazado por internals y hard  points", true)]
		private float GetMaxCoitalProfundidad(FemalePenetracionTipo tipo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				return Mathf.Lerp(this.anus.profundidad.min, this.anus.profundidad.max, this.m_IHolesDesgastables.anus.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.vag:
				return Mathf.Lerp(this.vag.profundidad.min, this.vag.profundidad.max, this.m_IHolesDesgastables.vag.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.facial:
				return this.m_desgasteProdundidadDeBoca.Lerp(this.m_IHolesDesgastables.boca.profundidad.currentAI * bodyHolesVirtualEnduranceMod);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600201F RID: 8223 RVA: 0x00079C98 File Offset: 0x00077E98
		private float GetMaxCoitalAnchura(FemalePenetracionTipo tipo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				return this.m_desgasteAnchuraDeAnus.Lerp(this.m_IHolesDesgastables.anus.anchura.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.vag:
				return this.m_desgasteAnchuraDeVag.Lerp(this.m_IHolesDesgastables.vag.anchura.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.facial:
				return this.m_desgasteAnchuraDeBoca.Lerp(this.m_IHolesDesgastables.boca.anchura.currentAI * bodyHolesVirtualEnduranceMod);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06002020 RID: 8224 RVA: 0x00079D3C File Offset: 0x00077F3C
		private float GetMaxCoitalMotion(FemalePenetracionTipo tipo)
		{
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				return this.m_desgastePenVelDeAnus.Lerp(this.m_IHolesDesgastables.anus.motion.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.vag:
				return this.m_desgastePenVelDeVag.Lerp(this.m_IHolesDesgastables.vag.motion.currentAI * bodyHolesVirtualEnduranceMod);
			case FemalePenetracionTipo.facial:
				return this.m_desgastePenVelDeBoca.Lerp(this.m_IHolesDesgastables.boca.motion.currentAI * bodyHolesVirtualEnduranceMod);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06002021 RID: 8225 RVA: 0x00079DE0 File Offset: 0x00077FE0
		private bool TryGetMaxTactil(ParteDelCuerpoHumano estimuladaParte, ParteQuePuedeEstimular estimulante, out float max)
		{
			max = -1f;
			bool flag = estimulante.EsHumpingParte();
			float num;
			ModifcadorDeIntervalo modifcadorDeIntervalo;
			if (estimuladaParte.EsCoitoOral() || (flag && estimuladaParte.EsAproximadoOral()))
			{
				num = this.m_IHolesDesgastables.boca.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeBoca;
			}
			else if (estimuladaParte.EsCoitoVaginal())
			{
				num = this.m_IHolesDesgastables.vag.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeVag;
			}
			else if (estimuladaParte.EsCoitoAnal())
			{
				num = this.m_IHolesDesgastables.anus.motion.currentAI;
				modifcadorDeIntervalo = this.m_desgastePenVelDeAnus;
			}
			else
			{
				if (!flag || (!estimuladaParte.EsEntrepierna() && !estimuladaParte.EsTrasero()))
				{
					return false;
				}
				if (this.m_IHolesDesgastables.vag.motion.currentAI >= this.m_IHolesDesgastables.anus.motion.currentAI)
				{
					num = this.m_IHolesDesgastables.vag.motion.currentAI;
					modifcadorDeIntervalo = this.m_desgastePenVelDeVag;
				}
				else
				{
					num = this.m_IHolesDesgastables.anus.motion.currentAI;
					modifcadorDeIntervalo = this.m_desgastePenVelDeAnus;
				}
			}
			float bodyHolesVirtualEnduranceMod = this.bodyHolesVirtualEnduranceMod;
			max = modifcadorDeIntervalo.Lerp(num * bodyHolesVirtualEnduranceMod);
			return true;
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x00079F14 File Offset: 0x00078114
		[Obsolete("reemplazado por internals y hard  points", true)]
		void IModDeInterDeGenCoitalProfundidad.Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalProfundidad = this.GetMaxCoitalProfundidad(tipo);
			intervalo = RangeValueV2.SetMaxWithCeilAndKeepLength(ref intervalo, maxCoitalProfundidad, 0.55f);
		}

		// Token: 0x06002023 RID: 8227 RVA: 0x00079F3C File Offset: 0x0007813C
		[Obsolete("reemplazado por internals y hard  points", true)]
		void IModDeInterDeGenCoitalProfundidad.StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalProfundidad = this.GetMaxCoitalProfundidad(tipo);
			intervalo = RangeValueV2.SetMinWithCeilAndKeepLength(ref intervalo, maxCoitalProfundidad, 0.45f);
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x00079F64 File Offset: 0x00078164
		void IModDeInterDeGenCoitalAnchura.Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalAnchura = this.GetMaxCoitalAnchura(tipo);
			intervalo = RangeValueV2.SetMaxWithCeilAndKeepLength(ref intervalo, maxCoitalAnchura, 0.55f);
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x00079F8C File Offset: 0x0007818C
		void IModDeInterDeGenCoitalAnchura.StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalAnchura = this.GetMaxCoitalAnchura(tipo);
			intervalo = RangeValueV2.SetMinWithCeilAndKeepLength(ref intervalo, maxCoitalAnchura, 0.45f);
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x00079FB4 File Offset: 0x000781B4
		void IModDeInterDeGenCoitalPenVel.Max(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalMotion = this.GetMaxCoitalMotion(tipo);
			intervalo = RangeValueV2.SetMaxWithCeilAndKeepLength(ref intervalo, maxCoitalMotion, 0.55f);
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x00079FDC File Offset: 0x000781DC
		void IModDeInterDeGenCoitalPenVel.StackIfGreater(ReaccionHumana reacc, FemalePenetracionTipo tipo, ref RangeValueV2 intervalo)
		{
			float maxCoitalMotion = this.GetMaxCoitalMotion(tipo);
			intervalo = RangeValueV2.SetMinWithCeilAndKeepLength(ref intervalo, maxCoitalMotion, 0.45f);
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x0007A004 File Offset: 0x00078204
		void IModDeInterDeGenTactil.Max(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ParteQuePuedeEstimular estimulante, ref RangeValueV2 intervalo)
		{
			float num;
			if (!this.TryGetMaxTactil(estimuladaParte, estimulante, out num))
			{
				return;
			}
			intervalo = RangeValueV2.SetMaxWithCeilAndKeepLength(ref intervalo, num, 0.55f);
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x0007A034 File Offset: 0x00078234
		void IModDeInterDeGenTactil.StackIfGreater(ReaccionHumana reacc, ParteDelCuerpoHumano estimuladaParte, ParteQuePuedeEstimular estimulante, ref RangeValueV2 intervalo)
		{
			float num;
			if (!this.TryGetMaxTactil(estimuladaParte, estimulante, out num))
			{
				return;
			}
			intervalo = RangeValueV2.SetMinWithCeilAndKeepLength(ref intervalo, num, 0.45f);
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x0600202A RID: 8234 RVA: 0x0007A062 File Offset: 0x00078262
		IHoleRangos IHolesRangosClamp.vag
		{
			get
			{
				return this.vag;
			}
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x0600202B RID: 8235 RVA: 0x0007A06A File Offset: 0x0007826A
		IHoleRangos IHolesRangosClamp.anus
		{
			get
			{
				return this.anus;
			}
		}

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x0600202C RID: 8236 RVA: 0x0007A072 File Offset: 0x00078272
		IHoleRangos IHolesRangosClamp.garganta
		{
			get
			{
				return this.garganta;
			}
		}

		// Token: 0x04001523 RID: 5411
		[SerializeField]
		private ModifcadorDeIntervalo m_desgastePenVelDeVag;

		// Token: 0x04001524 RID: 5412
		[SerializeField]
		private ModifcadorDeIntervalo m_desgastePenVelDeAnus;

		// Token: 0x04001525 RID: 5413
		[SerializeField]
		private ModifcadorDeIntervalo m_desgastePenVelDeBoca;

		// Token: 0x04001526 RID: 5414
		[Obsolete("ahora es controllado por fondo", true)]
		private ModifcadorDeIntervalo m_desgasteProdundidadDeVag;

		// Token: 0x04001527 RID: 5415
		[Obsolete("ahora es controllado por fondo", true)]
		private ModifcadorDeIntervalo m_desgasteProdundidadDeAnus;

		// Token: 0x04001528 RID: 5416
		[SerializeField]
		private ModifcadorDeIntervalo m_desgasteProdundidadDeBoca;

		// Token: 0x04001529 RID: 5417
		[SerializeField]
		private ModifcadorDeIntervalo m_desgasteAnchuraDeVag;

		// Token: 0x0400152A RID: 5418
		[SerializeField]
		private ModifcadorDeIntervalo m_desgasteAnchuraDeAnus;

		// Token: 0x0400152B RID: 5419
		[SerializeField]
		private ModifcadorDeIntervalo m_desgasteAnchuraDeBoca;

		// Token: 0x0400152C RID: 5420
		private IHolesDesgastables m_IHolesDesgastables;

		// Token: 0x0400152D RID: 5421
		private Personalidad m_personalidad;

		// Token: 0x0400152E RID: 5422
		[NonSerialized]
		public ModDeInterDeGenCoital.FemaleHoleRangos vag;

		// Token: 0x0400152F RID: 5423
		[NonSerialized]
		public ModDeInterDeGenCoital.FemaleHoleRangos anus;

		// Token: 0x04001530 RID: 5424
		[NonSerialized]
		public ModDeInterDeGenCoital.FemaleHoleRangos garganta;

		// Token: 0x02000525 RID: 1317
		public abstract class FemaleHoleRangoBase : IHoleRangoEspecifico
		{
			// Token: 0x1700089F RID: 2207
			// (get) Token: 0x0600202E RID: 8238
			public abstract float min { get; }

			// Token: 0x170008A0 RID: 2208
			// (get) Token: 0x0600202F RID: 8239
			public abstract float max { get; }
		}

		// Token: 0x02000526 RID: 1318
		public class FemaleHoleRangoEspecifico : ModDeInterDeGenCoital.FemaleHoleRangoBase
		{
			// Token: 0x06002031 RID: 8241 RVA: 0x0007A07A File Offset: 0x0007827A
			public FemaleHoleRangoEspecifico(ModifcadorDeIntervalo modinter)
			{
				this.m_modinter = modinter;
			}

			// Token: 0x170008A1 RID: 2209
			// (get) Token: 0x06002032 RID: 8242 RVA: 0x0007A089 File Offset: 0x00078289
			public override float min
			{
				get
				{
					return this.m_modinter.min;
				}
			}

			// Token: 0x170008A2 RID: 2210
			// (get) Token: 0x06002033 RID: 8243 RVA: 0x0007A096 File Offset: 0x00078296
			public override float max
			{
				get
				{
					return this.m_modinter.max;
				}
			}

			// Token: 0x04001531 RID: 5425
			[NonSerialized]
			private ModifcadorDeIntervalo m_modinter;
		}

		// Token: 0x02000527 RID: 1319
		public class FemaleHoleRangos : IHoleRangos
		{
			// Token: 0x170008A3 RID: 2211
			// (get) Token: 0x06002034 RID: 8244 RVA: 0x0007A0A3 File Offset: 0x000782A3
			IHoleRangoEspecifico IHoleRangos.motion
			{
				get
				{
					return this.motion;
				}
			}

			// Token: 0x170008A4 RID: 2212
			// (get) Token: 0x06002035 RID: 8245 RVA: 0x0007A0AB File Offset: 0x000782AB
			[Obsolete("reemplazado por internals y hard  points", true)]
			IHoleRangoEspecifico IHoleRangos.profundidad
			{
				get
				{
					return this.profundidad;
				}
			}

			// Token: 0x170008A5 RID: 2213
			// (get) Token: 0x06002036 RID: 8246 RVA: 0x0007A0B3 File Offset: 0x000782B3
			IHoleRangoEspecifico IHoleRangos.anchura
			{
				get
				{
					return this.anchura;
				}
			}

			// Token: 0x04001532 RID: 5426
			[NonSerialized]
			public ModDeInterDeGenCoital.FemaleHoleRangoBase motion;

			// Token: 0x04001533 RID: 5427
			[Obsolete("reemplazado por internals y hard  points", true)]
			[NonSerialized]
			public ModDeInterDeGenCoital.FemaleHoleRangoBase profundidad;

			// Token: 0x04001534 RID: 5428
			[NonSerialized]
			public ModDeInterDeGenCoital.FemaleHoleRangoBase anchura;
		}
	}
}

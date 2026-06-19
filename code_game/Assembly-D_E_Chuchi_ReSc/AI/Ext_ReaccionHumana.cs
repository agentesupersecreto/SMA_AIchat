using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000337 RID: 823
	public static class Ext_ReaccionHumana
	{
		// Token: 0x060011BC RID: 4540 RVA: 0x0004BFBC File Offset: 0x0004A1BC
		public static DisplayableBuffCategory ParseToCategory(this ReaccionHumana emo)
		{
			if (emo <= ReaccionHumana.arousal)
			{
				if (emo <= ReaccionHumana.rabia)
				{
					switch (emo)
					{
					case ReaccionHumana.None:
						return DisplayableBuffCategory.None;
					case ReaccionHumana.concentToHero:
						return DisplayableBuffCategory.favorability;
					case ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
						break;
					case ReaccionHumana.dolor:
						return DisplayableBuffCategory.pain;
					default:
						if (emo == ReaccionHumana.rabia)
						{
							return DisplayableBuffCategory.rage;
						}
						break;
					}
				}
				else
				{
					if (emo == ReaccionHumana.placer)
					{
						return DisplayableBuffCategory.pleasure;
					}
					if (emo == ReaccionHumana.arousal)
					{
						return DisplayableBuffCategory.pleasure;
					}
				}
			}
			else if (emo <= ReaccionHumana.decepcion)
			{
				if (emo == ReaccionHumana.miedo)
				{
					return DisplayableBuffCategory.fear;
				}
				if (emo == ReaccionHumana.decepcion)
				{
					return DisplayableBuffCategory.decep;
				}
			}
			else
			{
				if (emo == ReaccionHumana.alivio)
				{
					return DisplayableBuffCategory.pain;
				}
				if (emo == ReaccionHumana.desHielo)
				{
					return DisplayableBuffCategory.fear;
				}
			}
			return DisplayableBuffCategory.other;
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0004C040 File Offset: 0x0004A240
		public static PrioridadDeParteDelCuerpoHumanoContexto Parce(this ReaccionHumana reacc)
		{
			if (reacc <= ReaccionHumana.miedo)
			{
				if (reacc <= ReaccionHumana.placer)
				{
					switch (reacc)
					{
					case ReaccionHumana.None:
						return PrioridadDeParteDelCuerpoHumanoContexto.@fixed;
					case ReaccionHumana.concentToHero:
						return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
					case ReaccionHumana.asombro:
						goto IL_009E;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						goto IL_00AA;
					case ReaccionHumana.dolor:
						return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
					case ReaccionHumana.rabia:
						break;
					default:
						if (reacc != ReaccionHumana.asco)
						{
							if (reacc != ReaccionHumana.placer)
							{
								goto IL_00AA;
							}
							return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
						}
						break;
					}
				}
				else
				{
					if (reacc == ReaccionHumana.arousal)
					{
						return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
					}
					if (reacc == ReaccionHumana.tristeza)
					{
						goto IL_009E;
					}
					if (reacc != ReaccionHumana.miedo)
					{
						goto IL_00AA;
					}
				}
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
			if (reacc <= ReaccionHumana.decepcion)
			{
				if (reacc != ReaccionHumana.alegria)
				{
					if (reacc == ReaccionHumana.felicidad)
					{
						goto IL_009E;
					}
					if (reacc != ReaccionHumana.decepcion)
					{
						goto IL_00AA;
					}
				}
			}
			else
			{
				if (reacc == ReaccionHumana.alivio || reacc == ReaccionHumana.aburrimiento)
				{
					goto IL_009E;
				}
				if (reacc != ReaccionHumana.desHielo)
				{
					goto IL_00AA;
				}
			}
			return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			IL_009E:
			Debug.LogException(new NotImplementedException());
			return PrioridadDeParteDelCuerpoHumanoContexto.@fixed;
			IL_00AA:
			throw new ArgumentOutOfRangeException(reacc.ToString());
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0004C10C File Offset: 0x0004A30C
		public static bool EsPositiva(this ReaccionHumana reacc)
		{
			if (reacc <= ReaccionHumana.miedo)
			{
				if (reacc <= ReaccionHumana.placer)
				{
					switch (reacc)
					{
					case ReaccionHumana.None:
					case ReaccionHumana.dolor:
					case ReaccionHumana.rabia:
						break;
					case ReaccionHumana.concentToHero:
					case ReaccionHumana.asombro:
						return true;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						goto IL_009A;
					default:
						if (reacc != ReaccionHumana.asco)
						{
							if (reacc != ReaccionHumana.placer)
							{
								goto IL_009A;
							}
							return true;
						}
						break;
					}
				}
				else
				{
					if (reacc == ReaccionHumana.arousal)
					{
						return true;
					}
					if (reacc != ReaccionHumana.tristeza && reacc != ReaccionHumana.miedo)
					{
						goto IL_009A;
					}
				}
			}
			else if (reacc <= ReaccionHumana.decepcion)
			{
				if (reacc == ReaccionHumana.alegria || reacc == ReaccionHumana.felicidad)
				{
					return true;
				}
				if (reacc != ReaccionHumana.decepcion)
				{
					goto IL_009A;
				}
			}
			else
			{
				if (reacc == ReaccionHumana.alivio)
				{
					return true;
				}
				if (reacc != ReaccionHumana.aburrimiento)
				{
					if (reacc != ReaccionHumana.desHielo)
					{
						goto IL_009A;
					}
					return true;
				}
			}
			return false;
			IL_009A:
			throw new ArgumentOutOfRangeException(reacc.ToString());
		}
	}
}

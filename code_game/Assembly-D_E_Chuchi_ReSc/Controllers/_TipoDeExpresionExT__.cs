using System;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x02000248 RID: 584
	public static class _TipoDeExpresionExT__
	{
		// Token: 0x06000D14 RID: 3348 RVA: 0x0003C1EC File Offset: 0x0003A3EC
		public static bool TryParceAExpresion(this ReaccionHumana reaccion, out ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion)
		{
			if (reaccion <= ReaccionHumana.arousal)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_006E;
						}
						goto IL_005A;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
						return true;
					}
					if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.arousal)
					{
						goto IL_006E;
					}
					tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
					return true;
				}
			}
			else if (reaccion <= ReaccionHumana.alegria)
			{
				if (reaccion == ReaccionHumana.miedo)
				{
					tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo;
					return true;
				}
				if (reaccion != ReaccionHumana.alegria)
				{
					goto IL_006E;
				}
			}
			else if (reaccion != ReaccionHumana.felicidad)
			{
				if (reaccion == ReaccionHumana.decepcion)
				{
					goto IL_005A;
				}
				if (reaccion != ReaccionHumana.desHielo)
				{
					goto IL_006E;
				}
			}
			tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
			return true;
			IL_005A:
			tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
			return true;
			IL_006E:
			tipoDeExpresion = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
			return false;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0003C26C File Offset: 0x0003A46C
		public static ControlladorDeGestosFacialesEmocionales.TipoDeExpresion ParceAExpresion(this ReaccionHumana reaccion)
		{
			if (reaccion <= ReaccionHumana.arousal)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_005F;
						}
						return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					}
					if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.arousal)
					{
						goto IL_005F;
					}
					return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
				}
			}
			else if (reaccion <= ReaccionHumana.alegria)
			{
				if (reaccion == ReaccionHumana.miedo)
				{
					return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo;
				}
				if (reaccion != ReaccionHumana.alegria)
				{
					goto IL_005F;
				}
			}
			else if (reaccion != ReaccionHumana.felicidad)
			{
				if (reaccion == ReaccionHumana.decepcion)
				{
					return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
				}
				if (reaccion != ReaccionHumana.desHielo)
				{
					goto IL_005F;
				}
			}
			return ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
			IL_005F:
			throw new ArgumentOutOfRangeException(reaccion.ToString());
		}
	}
}

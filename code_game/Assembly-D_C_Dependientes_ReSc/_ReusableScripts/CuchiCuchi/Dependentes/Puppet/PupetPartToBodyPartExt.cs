using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.Skins;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000113 RID: 275
	public static class PupetPartToBodyPartExt
	{
		// Token: 0x06000590 RID: 1424 RVA: 0x0001FB30 File Offset: 0x0001DD30
		public static ParteDelCuerpoHumano ParseAParteHumana(this PuppetParte parte)
		{
			switch (parte)
			{
			case PuppetParte.cadera:
				return ParteDelCuerpoHumano.caderas;
			case PuppetParte.spine1:
				return ParteDelCuerpoHumano.cintura;
			case PuppetParte.spine2:
				return ParteDelCuerpoHumano.pecho;
			case PuppetParte.head:
				return ParteDelCuerpoHumano.cabeza;
			case PuppetParte.brazoL:
				return ParteDelCuerpoHumano.brazos;
			case PuppetParte.brazoR:
				return ParteDelCuerpoHumano.brazos;
			case PuppetParte.anteBrazoL:
				return ParteDelCuerpoHumano.anteBrazos;
			case PuppetParte.anteBrazoR:
				return ParteDelCuerpoHumano.anteBrazos;
			case PuppetParte.manoL:
				return ParteDelCuerpoHumano.manos;
			case PuppetParte.manoR:
				return ParteDelCuerpoHumano.manos;
			case PuppetParte.piernaL:
				return ParteDelCuerpoHumano.piernas;
			case PuppetParte.piernaR:
				return ParteDelCuerpoHumano.piernas;
			case PuppetParte.canillaL:
				return ParteDelCuerpoHumano.canillas;
			case PuppetParte.canillaR:
				return ParteDelCuerpoHumano.canillas;
			case PuppetParte.pieL:
				return ParteDelCuerpoHumano.pies;
			case PuppetParte.pieR:
				return ParteDelCuerpoHumano.pies;
			case PuppetParte.neck:
				return ParteDelCuerpoHumano.cuello;
			case PuppetParte.hombroL:
			case PuppetParte.hombroR:
				return ParteDelCuerpoHumano.hombros;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001FBD4 File Offset: 0x0001DDD4
		public static BodyPartEnum ParseABodyPart(this PuppetParte parte)
		{
			switch (parte)
			{
			case PuppetParte.cadera:
				return BodyPartEnum.cintura;
			case PuppetParte.spine1:
				return BodyPartEnum.cintura;
			case PuppetParte.spine2:
				return BodyPartEnum.pecho;
			case PuppetParte.head:
				return BodyPartEnum.cabeza;
			case PuppetParte.brazoL:
				return BodyPartEnum.brazo_L;
			case PuppetParte.brazoR:
				return BodyPartEnum.brazo_R;
			case PuppetParte.anteBrazoL:
				return BodyPartEnum.anteBrazo_R;
			case PuppetParte.anteBrazoR:
				return BodyPartEnum.anteBrazo_L;
			case PuppetParte.manoL:
				return BodyPartEnum.mano_L;
			case PuppetParte.manoR:
				return BodyPartEnum.mano_R;
			case PuppetParte.piernaL:
				return BodyPartEnum.pierna_L;
			case PuppetParte.piernaR:
				return BodyPartEnum.pierna_R;
			case PuppetParte.canillaL:
				return BodyPartEnum.canilla_L;
			case PuppetParte.canillaR:
				return BodyPartEnum.canilla_R;
			case PuppetParte.pieL:
				return BodyPartEnum.pie_L;
			case PuppetParte.pieR:
				return BodyPartEnum.pie_R;
			case PuppetParte.neck:
				return BodyPartEnum.cuello;
			case PuppetParte.hombroL:
				return BodyPartEnum.hombro_L;
			case PuppetParte.hombroR:
				return BodyPartEnum.hombro_R;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}
	}
}

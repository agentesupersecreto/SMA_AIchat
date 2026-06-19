using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas
{
	// Token: 0x02000398 RID: 920
	[CreateAssetMenu(fileName = "MapaSingletonDefaultInterpretacionData", menuName = "Objetos/Genetica/Mapa Singleton Default Interpretacion Data")]
	public class MapaSingletonDefaultInterpretacionData : MapaSingleton<MapaSingletonDefaultInterpretacionData>
	{
		// Token: 0x060016F8 RID: 5880 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x040010AE RID: 4270
		[Header("Data")]
		public PersonalidadData personalidadData = new PersonalidadData();

		// Token: 0x040010AF RID: 4271
		public DeseosData deseosData = new DeseosData();

		// Token: 0x040010B0 RID: 4272
		public HairData hairData = new HairData();

		// Token: 0x040010B1 RID: 4273
		public PubicHairData pubicHairData = new PubicHairData();

		// Token: 0x040010B2 RID: 4274
		public BodySkinData bodySkinData = new BodySkinData();

		// Token: 0x040010B3 RID: 4275
		public HoleRangesData holeRangesData = new HoleRangesData();

		// Token: 0x040010B4 RID: 4276
		public NalgasSkinRangesData nalgasSkinRangesData = new NalgasSkinRangesData();

		// Token: 0x040010B5 RID: 4277
		public FacialSkinData facialSkinData = new FacialSkinData();

		// Token: 0x040010B6 RID: 4278
		public SenosSkinRangesData senosSkinRangesData = new SenosSkinRangesData();

		// Token: 0x040010B7 RID: 4279
		public RazaData razaData = new RazaData();

		// Token: 0x040010B8 RID: 4280
		[Header("Interpretacion")]
		public InterpretacionCompletaDeFemale interpretacion;
	}
}

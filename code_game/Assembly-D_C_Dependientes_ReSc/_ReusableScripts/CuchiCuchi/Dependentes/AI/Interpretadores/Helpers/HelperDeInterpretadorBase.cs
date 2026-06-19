using System;
using Assets.Base.BeachGirl.Controladores.Materiales.Runtime;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Apariencia;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x02000399 RID: 921
	public abstract class HelperDeInterpretadorBase : AplicableCustomMonobehaviour
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060016FA RID: 5882 RVA: 0x0006DD6D File Offset: 0x0006BF6D
		public ICharacter character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060016FB RID: 5883 RVA: 0x0006DD75 File Offset: 0x0006BF75
		public Personalidad personalidad
		{
			get
			{
				return this.m_Personalidad;
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060016FC RID: 5884 RVA: 0x0006DD7D File Offset: 0x0006BF7D
		public Deseos deseos
		{
			get
			{
				return this.m_Deseos;
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x0006DD85 File Offset: 0x0006BF85
		public ConsentNecesario consentNecesario
		{
			get
			{
				return this.m_consentNecesario;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x060016FE RID: 5886 RVA: 0x0006DD8D File Offset: 0x0006BF8D
		public EmocionesFemeninas emocionesFemeninas
		{
			get
			{
				return this.m_EmocionesFemeninas;
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x0006DD95 File Offset: 0x0006BF95
		public IBocaHole boca
		{
			get
			{
				return this.m_boca;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x0006DD9D File Offset: 0x0006BF9D
		public IVagHole vag
		{
			get
			{
				return this.m_vag;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06001701 RID: 5889 RVA: 0x0006DDA5 File Offset: 0x0006BFA5
		public IAnusHole anus
		{
			get
			{
				return this.m_anus;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x0006DDAD File Offset: 0x0006BFAD
		public DolorPorToques dolorPorToques
		{
			get
			{
				return this.m_DolorPorToques;
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06001703 RID: 5891 RVA: 0x0006DDB5 File Offset: 0x0006BFB5
		public DolorPorGolpes dolorPorGolpes
		{
			get
			{
				return this.m_DolorPorGolpes;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0006DDBD File Offset: 0x0006BFBD
		public DolorPorPenetracion dolorPorPenetracion
		{
			get
			{
				return this.m_DolorPorPenetracion;
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06001705 RID: 5893 RVA: 0x0006DDC5 File Offset: 0x0006BFC5
		public PlacerPorToques placerPorToques
		{
			get
			{
				return this.m_PlacerPorToques;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x0006DDCD File Offset: 0x0006BFCD
		public PlacerPorPenetraciones placerPorPenetraciones
		{
			get
			{
				return this.m_PlacerPorPenetraciones;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06001707 RID: 5895 RVA: 0x0006DDD5 File Offset: 0x0006BFD5
		public PlacerPorSerVistoPorMain placerPorSerVistoPorMain
		{
			get
			{
				return this.m_PlacerPorSerVistoPorMain;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0006DDDD File Offset: 0x0006BFDD
		public PlacerPorVerPartesMasculinas placerPorVerPartesMasculinas
		{
			get
			{
				return this.m_PlacerPorVerPartesMasculinas;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06001709 RID: 5897 RVA: 0x0006DDE5 File Offset: 0x0006BFE5
		public RagePorToques ragePorToques
		{
			get
			{
				return this.m_RagePorToques;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x0006DDED File Offset: 0x0006BFED
		public RagePorGolpes ragePorGolpes
		{
			get
			{
				return this.m_RagePorGolpes;
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600170B RID: 5899 RVA: 0x0006DDF5 File Offset: 0x0006BFF5
		public RagePorPenetracion ragePorPenetracion
		{
			get
			{
				return this.m_RagePorPenetracion;
			}
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x0600170C RID: 5900 RVA: 0x0006DDFD File Offset: 0x0006BFFD
		public RagePorVerPartesMasculinas ragePorVerPartesMasculinas
		{
			get
			{
				return this.m_RagePorVerPartesMasculinas;
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600170D RID: 5901 RVA: 0x0006DE05 File Offset: 0x0006C005
		public RagePorSerVistoPorMain ragePorSerVistoPorMain
		{
			get
			{
				return this.m_RagePorSerVistoPorMain;
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x0006DE0D File Offset: 0x0006C00D
		public RagePorSerDesvestidoPorMain ragePorSerDesvestidoPorMain
		{
			get
			{
				return this.m_RagePorSerDesvestidoPorMain;
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x0006DE15 File Offset: 0x0006C015
		public RagePorPeticionDesvestidirPorMain ragePorPeticionDesvestidirPorMain
		{
			get
			{
				return this.m_RagePorPeticionDesvestidirPorMain;
			}
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x0006DE1D File Offset: 0x0006C01D
		public RagePorEjecucionDePose ragePorEjecucionDePose
		{
			get
			{
				return this.m_RagePorEjecucionDePose;
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06001711 RID: 5905 RVA: 0x0006DE25 File Offset: 0x0006C025
		public RagePorPeticionDeEjecucionDePose ragePorPeticionDeEjecucionDePose
		{
			get
			{
				return this.m_RagePorPeticionDeEjecucionDePose;
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0006DE2D File Offset: 0x0006C02D
		public ControlladorDeCabelloGpu controlladorDeCabelloGpu
		{
			get
			{
				return this.m_ControlladorDeCabelloGpu;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x0006DE35 File Offset: 0x0006C035
		public ControlladorDeFemalePubesApariencia controlladorDeFemalePubesApariencia
		{
			get
			{
				return this.m_ControlladorDeFemalePubesApariencia;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0006DE3D File Offset: 0x0006C03D
		public ControlladorDeFemalePiel controlladorDeFemalePiel
		{
			get
			{
				return this.m_ControlladorDeFemalePiel;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06001715 RID: 5909 RVA: 0x0006DE45 File Offset: 0x0006C045
		public ControlladorDeFemaleMakeUp controlladorDeFemaleMakeUp
		{
			get
			{
				return this.m_ControlladorDeFemaleMakeUp;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0006DE4D File Offset: 0x0006C04D
		public ControlladorDeEyeAdvanceColores controlladorDeEyeAdvanceColores
		{
			get
			{
				return this.m_ControlladorDeEyeAdvanceColores;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06001717 RID: 5911 RVA: 0x0006DE55 File Offset: 0x0006C055
		public ControlladorDeFemaleCejasApariencia ControlladorDeFemaleCejasApariencia
		{
			get
			{
				return this.m_ControlladorDeFemaleCejasApariencia;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0006DE5D File Offset: 0x0006C05D
		public AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina
		{
			get
			{
				return this.m_AlteradoresDeAparienciaFemenina;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x0006DE65 File Offset: 0x0006C065
		public AlteradoresDePersonalidadFemenina alteradoresDePersonalidadFemenina
		{
			get
			{
				return this.m_AlteradoresDePersonalidadFemenina;
			}
		}

		// Token: 0x0600171A RID: 5914 RVA: 0x0006DE70 File Offset: 0x0006C070
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacterRoot root = this.GetRoot();
			this.m_Character = root.GetComponentInChildren<ICharacter>();
			this.m_Personalidad = root.GetComponentInChildren<Personalidad>();
			this.m_Deseos = root.GetComponentInChildren<Deseos>();
			this.m_consentNecesario = root.GetComponentInChildren<ConsentNecesario>();
			this.m_EmocionesFemeninas = root.GetComponentInChildren<EmocionesFemeninas>();
			this.m_boca = root.GetComponentInChildren<IBocaHole>();
			this.m_vag = root.GetComponentInChildren<IVagHole>();
			this.m_anus = root.GetComponentInChildren<IAnusHole>();
			this.m_ControlladorDeCabelloGpu = root.GetComponentInChildren<ControlladorDeCabelloGpu>();
			this.m_ControlladorDeFemalePubesApariencia = root.GetComponentInChildren<ControlladorDeFemalePubesApariencia>();
			this.m_ControlladorDeFemalePiel = root.GetComponentInChildren<ControlladorDeFemalePiel>();
			this.m_ControlladorDeFemaleMakeUp = root.GetComponentInChildren<ControlladorDeFemaleMakeUp>();
			this.m_ControlladorDeEyeAdvanceColores = root.GetComponentInChildren<ControlladorDeEyeAdvanceColores>();
			this.m_ControlladorDeFemaleCejasApariencia = root.GetComponentInChildren<ControlladorDeFemaleCejasApariencia>();
			this.m_AlteradoresDeAparienciaFemenina = root.GetComponentInChildren<AlteradoresDeAparienciaFemenina>();
			this.m_AlteradoresDePersonalidadFemenina = root.GetComponentInChildren<AlteradoresDePersonalidadFemenina>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			if (this.m_EmocionesFemeninas == null)
			{
				throw new ArgumentNullException("m_EmocionesFemeninas", "m_EmocionesFemeninas null reference.");
			}
			if (this.m_consentNecesario == null)
			{
				throw new ArgumentNullException("m_consentNecesario", "m_consentNecesario null reference.");
			}
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
			if (this.m_boca == null)
			{
				throw new ArgumentNullException("m_boca", "m_boca null reference.");
			}
			if (this.m_vag == null)
			{
				throw new ArgumentNullException("m_vag", "m_vag null reference.");
			}
			if (this.m_anus == null)
			{
				throw new ArgumentNullException("m_anus", "m_anus null reference.");
			}
			if (this.m_ControlladorDeCabelloGpu == null)
			{
				throw new ArgumentNullException("m_ControlladorDeCabelloGpu", "m_ControlladorDeCabelloGpu null reference.");
			}
			if (this.m_ControlladorDeFemalePubesApariencia == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemalePubesApariencia", "m_ControlladorDeFemalePubesApariencia null reference.");
			}
			if (this.m_ControlladorDeFemalePiel == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemalePiel", "m_ControlladorDeFemalePiel null reference.");
			}
			if (this.m_ControlladorDeFemaleMakeUp == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemaleMakeUp", "m_ControlladorDeFemaleMakeUp null reference.");
			}
			if (this.m_ControlladorDeEyeAdvanceColores == null)
			{
				throw new ArgumentNullException("m_ControlladorDeEyeAdvanceColores", "m_ControlladorDeEyeAdvanceColores null reference.");
			}
			if (this.m_ControlladorDeFemaleCejasApariencia == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemaleCejasApariencia", "m_ControlladorDeFemaleCejasApariencia null reference.");
			}
			if (this.m_AlteradoresDeAparienciaFemenina == null)
			{
				throw new ArgumentNullException("m_AlteradoresDeAparienciaFemenina", "m_AlteradoresDeAparienciaFemenina null reference.");
			}
			if (this.m_AlteradoresDePersonalidadFemenina == null)
			{
				throw new ArgumentNullException("m_AlteradoresDePersonalidadFemenina", "m_AlteradoresDePersonalidadFemenina null reference.");
			}
			this.m_DolorPorToques = this.m_EmocionesFemeninas.GetComponentInChildren<DolorPorToques>();
			this.m_DolorPorGolpes = this.m_EmocionesFemeninas.GetComponentInChildren<DolorPorGolpes>();
			this.m_DolorPorPenetracion = this.m_EmocionesFemeninas.GetComponentInChildren<DolorPorPenetracion>();
			this.m_PlacerPorToques = this.m_EmocionesFemeninas.GetComponentInChildren<PlacerPorToques>();
			this.m_PlacerPorPenetraciones = this.m_EmocionesFemeninas.GetComponentInChildren<PlacerPorPenetraciones>();
			this.m_PlacerPorSerVistoPorMain = this.m_EmocionesFemeninas.GetComponentInChildren<PlacerPorSerVistoPorMain>();
			this.m_PlacerPorVerPartesMasculinas = this.m_EmocionesFemeninas.GetComponentInChildren<PlacerPorVerPartesMasculinas>();
			this.m_RagePorToques = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorToques>();
			this.m_RagePorGolpes = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorGolpes>();
			this.m_RagePorPenetracion = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorPenetracion>();
			this.m_RagePorVerPartesMasculinas = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorVerPartesMasculinas>();
			this.m_RagePorSerVistoPorMain = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorSerVistoPorMain>();
			this.m_RagePorSerDesvestidoPorMain = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorSerDesvestidoPorMain>();
			this.m_RagePorPeticionDesvestidirPorMain = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorPeticionDesvestidirPorMain>();
			this.m_RagePorEjecucionDePose = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorEjecucionDePose>();
			this.m_RagePorPeticionDeEjecucionDePose = this.m_EmocionesFemeninas.GetComponentInChildren<RagePorPeticionDeEjecucionDePose>();
			if (this.m_DolorPorToques == null)
			{
				throw new ArgumentNullException("m_DolorPorToques", "m_DolorPorToques null reference.");
			}
			if (this.m_DolorPorGolpes == null)
			{
				throw new ArgumentNullException("m_DolorPorGolpes", "m_DolorPorGolpes null reference.");
			}
			if (this.m_DolorPorPenetracion == null)
			{
				throw new ArgumentNullException("m_DolorPorPenetracion", "m_DolorPorPenetracion null reference.");
			}
			if (this.m_PlacerPorToques == null)
			{
				throw new ArgumentNullException("m_PlacerPorToques", "m_PlacerPorToques null reference.");
			}
			if (this.m_PlacerPorPenetraciones == null)
			{
				throw new ArgumentNullException("m_PlacerPorPenetraciones", "m_PlacerPorPenetraciones null reference.");
			}
			if (this.m_PlacerPorSerVistoPorMain == null)
			{
				throw new ArgumentNullException("m_PlacerPorSerVistoPorMain", "m_PlacerPorSerVistoPorMain null reference.");
			}
			if (this.m_PlacerPorVerPartesMasculinas == null)
			{
				throw new ArgumentNullException("m_PlacerPorVerPartesMasculinas", "m_PlacerPorVerPartesMasculinas null reference.");
			}
			if (this.m_RagePorToques == null)
			{
				throw new ArgumentNullException("m_RagePorToques", "m_RagePorToques null reference.");
			}
			if (this.m_RagePorGolpes == null)
			{
				throw new ArgumentNullException("m_RagePorGolpes", "m_RagePorGolpes null reference.");
			}
			if (this.m_RagePorPenetracion == null)
			{
				throw new ArgumentNullException("m_RagePorPenetracion", "m_RagePorPenetracion null reference.");
			}
			if (this.m_RagePorVerPartesMasculinas == null)
			{
				throw new ArgumentNullException("m_RagePorVerPartesMasculinas", "m_RagePorVerPartesMasculinas null reference.");
			}
			if (this.m_RagePorSerVistoPorMain == null)
			{
				throw new ArgumentNullException("m_RagePorSerVistoPorMain", "m_RagePorSerVistoPorMain null reference.");
			}
			if (this.m_RagePorSerDesvestidoPorMain == null)
			{
				throw new ArgumentNullException("m_RagePorSerDesvestidoPorMain", "m_RagePorSerDesvestidoPorMain null reference.");
			}
			if (this.m_RagePorPeticionDesvestidirPorMain == null)
			{
				throw new ArgumentNullException("m_RagePorPeticionDesvestidirPorMain", "m_RagePorPeticionDesvestidirPorMain null reference.");
			}
			if (this.m_RagePorEjecucionDePose == null)
			{
				throw new ArgumentNullException("m_RagePorEjecucionDePose", "m_RagePorEjecucionDePose null reference.");
			}
			if (this.m_RagePorPeticionDeEjecucionDePose == null)
			{
				throw new ArgumentNullException("m_RagePorPeticionDeEjecucionDePose", "m_RagePorPeticionDeEjecucionDePose null reference.");
			}
		}

		// Token: 0x040010B9 RID: 4281
		private Personalidad m_Personalidad;

		// Token: 0x040010BA RID: 4282
		private Deseos m_Deseos;

		// Token: 0x040010BB RID: 4283
		private ConsentNecesario m_consentNecesario;

		// Token: 0x040010BC RID: 4284
		private EmocionesFemeninas m_EmocionesFemeninas;

		// Token: 0x040010BD RID: 4285
		private DolorPorToques m_DolorPorToques;

		// Token: 0x040010BE RID: 4286
		private DolorPorGolpes m_DolorPorGolpes;

		// Token: 0x040010BF RID: 4287
		private DolorPorPenetracion m_DolorPorPenetracion;

		// Token: 0x040010C0 RID: 4288
		private PlacerPorToques m_PlacerPorToques;

		// Token: 0x040010C1 RID: 4289
		private PlacerPorPenetraciones m_PlacerPorPenetraciones;

		// Token: 0x040010C2 RID: 4290
		private PlacerPorSerVistoPorMain m_PlacerPorSerVistoPorMain;

		// Token: 0x040010C3 RID: 4291
		private PlacerPorVerPartesMasculinas m_PlacerPorVerPartesMasculinas;

		// Token: 0x040010C4 RID: 4292
		private RagePorToques m_RagePorToques;

		// Token: 0x040010C5 RID: 4293
		private RagePorGolpes m_RagePorGolpes;

		// Token: 0x040010C6 RID: 4294
		private RagePorPenetracion m_RagePorPenetracion;

		// Token: 0x040010C7 RID: 4295
		private RagePorVerPartesMasculinas m_RagePorVerPartesMasculinas;

		// Token: 0x040010C8 RID: 4296
		private RagePorSerVistoPorMain m_RagePorSerVistoPorMain;

		// Token: 0x040010C9 RID: 4297
		private RagePorSerDesvestidoPorMain m_RagePorSerDesvestidoPorMain;

		// Token: 0x040010CA RID: 4298
		private RagePorPeticionDesvestidirPorMain m_RagePorPeticionDesvestidirPorMain;

		// Token: 0x040010CB RID: 4299
		private RagePorEjecucionDePose m_RagePorEjecucionDePose;

		// Token: 0x040010CC RID: 4300
		private RagePorPeticionDeEjecucionDePose m_RagePorPeticionDeEjecucionDePose;

		// Token: 0x040010CD RID: 4301
		private ControlladorDeCabelloGpu m_ControlladorDeCabelloGpu;

		// Token: 0x040010CE RID: 4302
		private ControlladorDeFemalePubesApariencia m_ControlladorDeFemalePubesApariencia;

		// Token: 0x040010CF RID: 4303
		private ControlladorDeFemalePiel m_ControlladorDeFemalePiel;

		// Token: 0x040010D0 RID: 4304
		private ControlladorDeFemaleMakeUp m_ControlladorDeFemaleMakeUp;

		// Token: 0x040010D1 RID: 4305
		private ControlladorDeEyeAdvanceColores m_ControlladorDeEyeAdvanceColores;

		// Token: 0x040010D2 RID: 4306
		private ControlladorDeFemaleCejasApariencia m_ControlladorDeFemaleCejasApariencia;

		// Token: 0x040010D3 RID: 4307
		private AlteradoresDeAparienciaFemenina m_AlteradoresDeAparienciaFemenina;

		// Token: 0x040010D4 RID: 4308
		private AlteradoresDePersonalidadFemenina m_AlteradoresDePersonalidadFemenina;

		// Token: 0x040010D5 RID: 4309
		private IBocaHole m_boca;

		// Token: 0x040010D6 RID: 4310
		private IVagHole m_vag;

		// Token: 0x040010D7 RID: 4311
		private IAnusHole m_anus;

		// Token: 0x040010D8 RID: 4312
		private ICharacter m_Character;
	}
}
